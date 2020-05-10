using HorariosMaker.Algorithm;
using HorariosMaker.Entities;
using HorariosMaker.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorariosMaker
{
    public partial class MainForm : Form
    {
        private Database database;
        private Genetics genetics;
        private string DatabaseFilePath = Database.DefaultFilePath;
        private int populationSize = 6;
        private int maxGenerations = 250;
        private double delay = 0.3;
        private int courseMaxCount = 50;
        private string[] courses = new string[] {
                    "Mate 1", "Progra 1", "Lengua 1", "Introduccion 1",
                    "Mecanica 2", "Computacion", "Religion", "Historia",
                    "Quimica", "Física", "IA", "Lectura", "Biología"
                };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UIConfiguration();
            CleanSchedule();
        }

        private void UIConfiguration()
        {
            this.scheduleDataGrid.DefaultCellStyle.SelectionBackColor = this.scheduleDataGrid.DefaultCellStyle.BackColor;
            this.scheduleDataGrid.DefaultCellStyle.SelectionForeColor = this.scheduleDataGrid.DefaultCellStyle.ForeColor;
            this.populationTextBox.Text = populationSize.ToString();
            this.maxGenerationTextBox.Text = maxGenerations.ToString();
            this.delayTextBox.Text = delay.ToString();
            this.coursesTextBox.Text = String.Join("\n", courses);
            this.courseMaxCountTextBox.Text = courseMaxCount.ToString();
        }

        private void LoadConfiguration()
        {
            populationSize = Convert.ToInt32(this.populationTextBox.Text);
            maxGenerations = Convert.ToInt32(this.maxGenerationTextBox.Text);
            delay = Convert.ToDouble(this.delayTextBox.Text);
            var databaseFilePath = this.databaseFilePathTextBox.Text;
            if (databaseFilePath == string.Empty || !File.Exists(databaseFilePath))
                throw new FileNotFoundException();
            DatabaseFilePath = databaseFilePath;
        }

        private async void DrawWhenComplete(Task<Individual> geneticTask)
        {
            var schedule = (Schedule)await geneticTask;
            Console.WriteLine("se termino!");
            SaveResult(schedule);
            await Task.Delay((int)genetics.SleepSeconds);
            DrawSchedule(schedule);
            this.startButton.Enabled = true;
            this.configGroupBox.Enabled = true;
            MessageBox.Show("Se termino la busqueda!. Resultado guardado en:" +
                Environment.CurrentDirectory + "\\result.json");
        }

        private static void SaveResult(Schedule schedule)
        {
            File.WriteAllText(
                Environment.CurrentDirectory + "\\result.json",
                JsonConvert.SerializeObject(schedule, Formatting.Indented));
        }

        public void UpdateUI(Individual[] schedules, int generation)
        {
            Console.WriteLine("Generation: " + generation);
            this.generationLabel.Text = "Generation: " + generation;
            var schedule = (Schedule)schedules.First(); // se dibuja el mejor resultado de la generacion
            DrawSchedule(schedule);
        }

        private void DrawSchedule(Schedule schedule)
        {
            CleanSchedule();
            foreach (var course in schedule.Courses)
            {
                int startTime = course.StartTime.Hour - Database.MIN_TIME;
                int duration = course.EndTime.Hour - Database.MIN_TIME - startTime;
                int day = course.StartTime.Day;

                for (int i = 0; i < duration; i++)
                {
                    var cell = this.scheduleDataGrid.Rows[startTime + i].Cells[day];
                    if ((string)cell.Value == string.Empty)
                        cell.Style.ForeColor = Color.Black;
                    else
                        cell.Style.ForeColor = Color.Red;

                    cell.Value = course.Name;
                }
            }
        }

        private void CleanSchedule()
        {
            this.scheduleDataGrid.Rows.Clear();
            for (int i = Database.MIN_TIME; i < Database.MAX_TIME + Database.MAX_HOURS; i++)
                this.scheduleDataGrid.Rows.Add(i + ":00", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            this.scheduleDataGrid.ClearSelection();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try { LoadConfiguration(); }
            catch
            {
                MessageBox.Show("Algunos parametros de configuración no son válidos.");
                return;
            }
            if (!File.Exists(Database.DefaultFilePath))
            {
                MessageBox.Show("El archivo de base de datos no ha sido encontrado.");
                return;
            }
            this.startButton.Enabled = false;
            this.configGroupBox.Enabled = false;
            //database = Database.GenerateRandom(courses, courseMaxCount);
            database = Database.LoadFromFile(DatabaseFilePath);
            genetics = new Genetics(database, maxGenerations);
            genetics.OnNewGeneration += UpdateUI;
            genetics.SleepSeconds = delay;

            var population = database.GetRandomPopulation(populationSize);
            var task = genetics.RunAsync(population.ToArray(), Schedule.Suitability);
            DrawWhenComplete(task);
        }

        private void generateDbButton_Click(object sender, EventArgs e)
        {
            try
            {
                courses = this.coursesTextBox.Text.Split('\n').ToArray();
                courseMaxCount = Convert.ToInt32(this.courseMaxCountTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Algunos parametros para crear la base de datos no son válidos.");
                return;
            }
            var newDatabase = Database.GenerateRandom(courses, courseMaxCount);
            newDatabase.Save();
            MessageBox.Show("Base de datos creada en: " + Database.DefaultFilePath, "Exito");
        }

        private void searchDbTextBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Seleccione la base de datos en formato JSON";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    DatabaseFilePath = fileDialog.FileName;
                    this.databaseFilePathTextBox.Text = DatabaseFilePath;
                }
            }
        }


    }
}
