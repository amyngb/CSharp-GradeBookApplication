using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook 
    {
        public RankedGradeBook (string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("There must be at least 5 students.");

            //find 20% of total number of students
            var gradeRange = Students.Count / 5;

            //find ranked student grades
            List<double> rankedAvgGrades = new List<double>();
            foreach (var student in Students.OrderByDescending(s => s.AverageGrade))
            {
                rankedAvgGrades.Add(student.AverageGrade);
            }

            //calculate grade ranges
            if (averageGrade > (rankedAvgGrades[gradeRange]))
                return 'A';
            else if (averageGrade > (rankedAvgGrades[gradeRange * 2]))
                return 'B';
            else if (averageGrade > (rankedAvgGrades[gradeRange * 3]))
                return 'C';
            else if (averageGrade > (rankedAvgGrades[gradeRange * 4]))
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
                
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
