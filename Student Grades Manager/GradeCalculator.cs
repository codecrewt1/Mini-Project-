using System;
using System.Collections.Generic;

namespace Student_Grades_Manager
{
    public class GradeCalculator
    {
        private void ValidateGrades(IReadOnlyList<int> grades)
        {
            if (grades == null)
            {
                throw new ArgumentNullException(nameof(grades), "Grades collection cannot be null.");
            }

            if (grades.Count == 0)
            {
                throw new ArgumentException("Grades collection cannot be empty.", nameof(grades));
            }

            foreach (int grade in grades)
            {
                if (grade < 0 || grade > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(grades), "Each grade must be between 0 and 100.");
                }
            }
        }

        public double CalculateAverage(IReadOnlyList<int> grades)
        {
            ValidateGrades(grades);

            int sum = 0;
            foreach (int grade in grades)
            {
                sum += grade;
            }

            return (double)sum / grades.Count;
        }

        public int GetHighestGrade(IReadOnlyList<int> grades)
        {
            ValidateGrades(grades);

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

        public int GetLowestGrade(IReadOnlyList<int> grades)
        {
            ValidateGrades(grades);

            int minGrade = grades[0];
            foreach (int grade in grades)
            {
                if (grade < minGrade)
                {
                    minGrade = grade;
                }
            }

            return minGrade;
        }
    }
}
