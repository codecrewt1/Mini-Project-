using System;
using System.Collections.Generic;

namespace Student_Grades_Manager
{
    public class StudentManager
    {
        private readonly List<Student> students = new List<Student>();
        private readonly InputValidator validator = new InputValidator();

        public void AddStudent()
        {
            Console.Write("Enter Student ID: ");
            string idInput = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(idInput, out int id) || !validator.IsValidId(id))
            {
                Console.WriteLine("Invalid ID: Please enter a valid positive number.");
                return;
            }

            if (!validator.IsUniqueId(id, students))
            {
                Console.WriteLine("Invalid ID: This ID already exists.");
                return;
            }

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            if (!validator.IsValidName(name))
            {
                Console.WriteLine("Invalid Name: Name cannot be empty.");
                return;
            }

            Console.Write("Enter Student Age: ");
            string ageInput = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(ageInput, out int age) || !validator.IsValidAge(age))
            {
                Console.WriteLine("Invalid Age: Age must be between 5 and 60.");
                return;
            }

            Console.Write("Enter number of grades (1-7): ");
            string countInput = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(countInput, out int count) || !validator.IsValidGradeCount(count))
            {
                Console.WriteLine("Invalid input: Number of grades must be between 1 and 7.");
                return;
            }

            int[] grades = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter grade {i + 1} (0-100): ");
                string gradeInput = Console.ReadLine() ?? string.Empty;

                if (!int.TryParse(gradeInput, out int grade) || !validator.IsValidGrade(grade))
                {
                    Console.WriteLine("Invalid Grade: Must be a number between 0 and 100. Student not added.");
                    return;
                }

                grades[i] = grade;
            }

            Student student = new Student(id, name, age, grades);
            students.Add(student);

            Console.WriteLine("Student added successfully!");
        }

        public void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students registered.");
                return;
            }

            Console.WriteLine();
            foreach (Student student in students)
            {
                DisplayStudentDetails(student);
                Console.WriteLine("  ----------------------------------------");
            }
        }

        public void DisplayStudentDetails(Student student)
        {
            if (student == null)
            {
                return;
            }

            Console.WriteLine($"  ID:     {student.ID}");
            Console.WriteLine($"  Name:   {student.Name}");
            Console.WriteLine($"  Age:    {student.Age}");
            Console.WriteLine($"  Grades: {string.Join(", ", student.Grades)}");
        }

        public Student? SearchStudentById(int id)
        {
            foreach (Student student in students)
            {
                if (student.ID == id)
                {
                    return student;
                }
            }

            return null;
        }
    }
}
