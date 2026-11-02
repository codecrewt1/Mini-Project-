using System;

namespace Student_Grades_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            GradeCalculator calculator = new GradeCalculator();
            StudentReport report = new StudentReport();
            bool running = true;

            Console.WriteLine("========================================");
            Console.WriteLine("   Welcome to Student Grades Manager");
            Console.WriteLine("========================================");

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("-------------- Main Menu ---------------");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Student Report");
                Console.WriteLine("5. Exit");
                Console.WriteLine("----------------------------------------");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("--- Add New Student ---");
                        manager.AddStudent();
                        break;

                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("--- All Registered Students ---");
                        manager.DisplayStudents();
                        break;

                    case "3":
                        SearchStudent(manager);
                        break;

                    case "4":
                        GenerateStudentReport(manager, calculator, report);
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using Student Grades Manager!");
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 5.");
                        break;
                }
            }
        }

        private static void SearchStudent(StudentManager manager)
        {
            Console.WriteLine();
            Console.WriteLine("--- Search Student ---");
            Console.Write("Enter Student ID to search: ");
            string searchInput = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(searchInput, out int searchId) || searchId <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }

            Student? found = manager.SearchStudentById(searchId);
            if (found != null)
            {
                Console.WriteLine("Student Found!");
                manager.DisplayStudentDetails(found);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        private static void GenerateStudentReport(StudentManager manager, GradeCalculator calculator, StudentReport report)
        {
            Console.WriteLine();
            Console.WriteLine("--- Student Report ---");
            Console.Write("Enter Student ID for report: ");
            string reportInput = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(reportInput, out int reportId) || reportId <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                return;
            }

            Student? student = manager.SearchStudentById(reportId);
            if (student != null)
            {
                double average = calculator.CalculateAverage(student.Grades);
                int highest = calculator.GetHighestGrade(student.Grades);
                int lowest = calculator.GetLowestGrade(student.Grades);
                string status = report.GetStudentStatus(average);

                Console.WriteLine("========================================");
                Console.WriteLine("          STUDENT REPORT");
                Console.WriteLine("========================================");
                Console.WriteLine($"  ID:             {student.ID}");
                Console.WriteLine($"  Name:           {student.Name}");
                Console.WriteLine($"  Age:            {student.Age}");
                Console.WriteLine($"  Grades:         {string.Join(", ", student.Grades)}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"  Average:        {average:F2}");
                Console.WriteLine($"  Highest Grade:  {highest}");
                Console.WriteLine($"  Lowest Grade:   {lowest}");
                Console.WriteLine($"  Status:         {status}");
                Console.WriteLine("========================================");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
