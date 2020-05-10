using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HorariosMaker.Entities.Interfaces;

namespace HorariosMaker.Entities
{
    public class Schedule : Individual
    {
        private static Random random = new Random();
        public List<Course> Courses { get; set; }

        // test, borrar luego
        public int SuitabilityTest { get { return Suitability(this); } }
        public int MaxSuitabilityTest { get { return GetMaxSuitability(this); } }

        public Schedule()
        {
            Courses = new List<Course>();
        }

        public Course this[int pos]
        {
            get { return Courses[pos]; }
            set { Courses[pos] = value; }
        }

        public int Size()
        {
            return Courses.Count;
        }

        /// <summary>
        /// Calcula el número de cursos pares que no se cruzan
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public static int Suitability(Individual individual)
        {
            var schedule = (Schedule)individual;
            var maxSuitability = GetMaxSuitability(schedule);
            var intersections = 0;
            for (int i = 0; i < schedule.Size() - 1; i++)
            {
                var course1 = schedule[i];
                for (int j = i + 1; j < schedule.Size(); j++)
                {
                    var course2 = schedule[j];
                    if ((course1.StartTime >= course2.StartTime && course1.StartTime < course2.EndTime)
                        || (course2.StartTime >= course1.StartTime && course2.StartTime < course1.EndTime))
                        intersections++;
                }
            }
            return maxSuitability - intersections;
        }

        public int GetAcceptableSuitability()
        {
            return GetMaxSuitability(this);
        }

        private static int GetMaxSuitability(Schedule schedule)
        {
            return (schedule.Size() * (schedule.Size() - 1)) / 2;
        }

        public static Schedule GetRandom(Dictionary<string, List<Course>> database)
        {
            var schedule = new Schedule();
            foreach (var course in database)
                schedule.Courses.Add(course.Value[random.Next(0, course.Value.Count)]);
            return schedule;
        }


        public Individual GetGenSlice(int fromPosition, int toPosition)
        {
            var subArray = new Schedule();
            for (int i = fromPosition; i < toPosition; i++)
                subArray.Courses.Add(this[i]);
            return subArray;
        }

        public Individual AppendToEnd(Individual individual)
        {
            var newSchedule = (Schedule)individual;
            var actualSchedule = new Schedule() { Courses = this.Courses };
            for (int i = 0; i < newSchedule.Size(); i++)
                actualSchedule.Courses.Add(newSchedule[i]);
            return actualSchedule;
        }

        public void SwapGen(int positionToSwap, Gen individual)
        {
            this[positionToSwap] = (Course)individual;
        }
    }
}
