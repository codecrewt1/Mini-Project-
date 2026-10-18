using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades_Manager
{
    public class GradeCalculator
    {
        public double CalculateAverage(int[] grades)
        {
            if (grades == null || grades.Length == 0)
                return 0;

            int sumOfGrads = 0;
            foreach (int grade in grades)
            {
                sumOfGrads += grade;
            }
            double Avg = (double)sumOfGrads / grades.Length;
            return Avg;
        }

        public int GetHighestGrade(int[] grades)
        {
            if (grades == null || grades.Length == 0)
                return 0;

            int maxGrade = grades[0];
            foreach (int grade in grades)
            {
                if (grade > maxGrade)
                {
                    maxGrade = grade;
                }
            }
            return maxGrade;
        }

        public int GetLowestGrade(int[] grades) 
        {
            if (grades == null || grades.Length == 0)
                return 0;

            int minGrade = grades[0];
            foreach (int grade in grades) {
                if (grade < minGrade) { 
                    minGrade = grade;
                }
            
            }

            return minGrade;
        
        }
    }
}
