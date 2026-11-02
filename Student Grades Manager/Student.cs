using System;
using System.Collections.Generic;

namespace Student_Grades_Manager
{
    public class Student
    {
        public int ID { get; }
        public string Name { get; }
        public int Age { get; }
        public IReadOnlyList<int> Grades { get; }

        public Student(int id, string name, int age, int[] grades)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be a positive integer greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null, empty, or whitespace only.", nameof(name));
            }

            if (age < 5 || age > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 5 and 60.");
            }

            if (grades == null)
            {
                throw new ArgumentNullException(nameof(grades), "Grades array cannot be null.");
            }

            if (grades.Length < 1 || grades.Length > 7)
            {
                throw new ArgumentException("Number of grades must be between 1 and 7.", nameof(grades));
            }

            foreach (int grade in grades)
            {
                if (grade < 0 || grade > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(grades), "Each grade must be between 0 and 100.");
                }
            }

            ID = id;
            Name = name;
            Age = age;

            int[] gradesCopy = new int[grades.Length];
            Array.Copy(grades, gradesCopy, grades.Length);
            Grades = Array.AsReadOnly(gradesCopy);
        }
    }
}