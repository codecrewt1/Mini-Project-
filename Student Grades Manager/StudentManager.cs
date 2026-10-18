using System;
using System.Collections.Generic;

public class StudentManager
{
    private List<Student> students = new List<Student>();
    private InputValidator validator = new InputValidator();

    public void AddStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter Student Age: ");
        int age = int.Parse(Console.ReadLine()!);

        Console.Write("Enter number of grades: ");
        int count = int.Parse(Console.ReadLine()!);

        if (count <= 0)
        {
            Console.WriteLine("Invalid number of grades.");
            return;
        }

        int[] grades = new int[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Enter grade {i + 1}: ");
            grades[i] = int.Parse(Console.ReadLine()!);
        }
        if (!validator.IsUniqueId(id, students))
        {
            Console.WriteLine("Invalid ID: This ID already exists.");
            return;
        }
        if (!validator.IsValidName(name))
        {
            Console.WriteLine("Invalid Name: Name cannot be empty.");
            return;
        }

        if (age <= 0)
        {
            Console.WriteLine("Invalid Age: Age must be greater than zero.");
            return;
        }
        if (!validator.AreValidGrades(grades))
        {
            Console.WriteLine("Invalid Grades: All grades must be between 0 and 100.");
            return;
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

        foreach (Student student in students)
        {
            Console.WriteLine($"ID: {student.ID}");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"Grades: {string.Join(", ", student.Grades)}");
        }
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