using HorariosMaker.Algorithm;
using HorariosMaker.Entities;
using HorariosMaker.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorariosMaker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Test();
        }

        // notas sobre geneticos:
        // - cada individuo es una posible solucion que tiene un fitnes(valor que define su nivel de bondad, mas alto es mejor)
        // - para este caso, cada invidivio es un horario con cursos y el valor de bondad que tiene cada uno es "cuantos cursos no chocan"
        // - ademas, cada gen es un curso
        private static void Test()
        {
            Console.WriteLine("[Start]");

            var database = Database.GenerateRandom(
                new string[] {
                    "Mate 1", "Progra 1", "Lengua 1", "Introduccion 1",
                    "Mecanica 2", "Computacion", "Religion", "Historia",
                    "Quimica", "Física", "IA", "Lectura", "Biología"
                },
                50);
            //database.Save();

            var population = new List<Schedule>(4); // poblacion inicial de 4 :v
            for (int i = 0; i < population.Capacity; i++)
                population.Add(database.GetRandomSchedule());

            //File.WriteAllText(Environment.CurrentDirectory + "\\test.json", JsonConvert.SerializeObject(population));

            var genetics = new Genetics(database, 500);
            genetics.OnNewGeneration += UpdateUI;
            var result = genetics.RunAsync(population.ToArray(), Schedule.Suitability);
            result.ToString();

            Console.WriteLine("[Finished]");
            Console.ReadLine();
        }

        public static void UpdateUI(Individual[] schedules, int generation)
        {

            Console.WriteLine("new try: " + generation);

        }

    }
}
