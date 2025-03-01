using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            var sortedGrades = Students.Select(s => s.AverageGrade).OrderByDescending(g => g).ToList();   //sorts grades in descending order

            int value = (int)Math.Ceiling(Students.Count * 0.2);  //20% of students

            if (sortedGrades.IndexOf(averageGrade) < value)
            {
                return 'A';
            }
            else if (sortedGrades.IndexOf(averageGrade) < value * 2)
            {
                return 'B';
            }
            else if (sortedGrades.IndexOf(averageGrade) < value * 3)
            {
                return 'C';
            }
            else if (sortedGrades.IndexOf(averageGrade) < value * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }

           
        }


        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");

            }
            else
            {
                base.CalculateStatistics();
            }
        }
    }

}
