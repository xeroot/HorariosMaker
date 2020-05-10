using HorariosMaker.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorariosMaker.Entities
{
    public class Database
    {
        private static Random random = new Random();
        public Dictionary<string, List<Course>> Courses { get; set; }
        public const int MIN_TIME = 7;
        public const int MAX_TIME = 20;
        public const int DAYS = 5;
        public const int MIN_HOURS = 2;
        public const int MAX_HOURS = 3;
        public static string DefaultFilePath = Environment.CurrentDirectory + "\\database.json";

        public Database()
        {
            Courses = new Dictionary<string, List<Course>>();
        }

        public static Database GenerateRandom(string[] courseNames, int courseCount)
        {
            var database = new Database();
            var random = new Random();
            for (int i = 0; i < courseNames.Length; i++)
            {
                var courses = new List<Course>();
                for (int j = 0; j < courseCount; j++)
                {
                    var newCourse = new Course()
                    {
                        Id = j + 1,
                        Name = courseNames[i],
                        StartTime = default(DateTime).AddHours(random.Next(MIN_TIME, MAX_TIME + 1)).AddDays(random.Next(0, DAYS)),
                    };
                    newCourse.EndTime = newCourse.StartTime.AddHours(random.Next(MIN_HOURS, MAX_HOURS + 1));
                    courses.Add(newCourse);
                }
                database.Courses.Add(courseNames[i], courses);
            }
            return database;
        }

        public void Save()
        {
            var jsonDatabase = JsonConvert.SerializeObject(Courses, Formatting.Indented);
            File.WriteAllText(DefaultFilePath, jsonDatabase);
        }

        public static Database LoadFromFile(string filePath)
        {
            var database = new Database();
            string jsonDatabase = File.ReadAllText(filePath);
            var courses = JsonConvert.DeserializeObject<Dictionary<string, List<Course>>>(jsonDatabase);
            database.Courses = courses;
            return database;
        }

        public Schedule GetRandomSchedule()
        {
            var schedule = new Schedule();
            foreach (var course in Courses)
                schedule.Courses.Add(course.Value[random.Next(0, course.Value.Count)]);
            return schedule;
        }

        public Gen GetRandomFromCategory(int categoryPosition)
        {
            var courseTimeTable = Courses.ElementAt(categoryPosition).Value;
            return courseTimeTable[random.Next(0, courseTimeTable.Count)];
        }

        public List<Schedule> GetRandomPopulation(int capacity)
        {
            var population = new List<Schedule>(capacity);
            for (int i = 0; i < population.Capacity; i++)
                population.Add(this.GetRandomSchedule());
            return population;
        }

    }
}
