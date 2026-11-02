using System;
using System.Collections.Generic;

namespace Student_Grades_Manager
{
    public class InputValidator
    {
        public bool IsValidId(int id)
        {
            return id > 0;
        }

        public bool IsValidName(string? name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public bool IsValidAge(int age)
        {
            return age >= 5 && age <= 60;
        }

        public bool IsValidGradeCount(int count)
        {
            return count >= 1 && count <= 7;
        }

        public bool IsValidGrade(int grade)
        {
            return grade >= 0 && grade <= 100;
        }

        public bool IsUniqueId(int id, List<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students));
            }

            foreach (Student student in students)
            {
                if (student.ID == id)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
