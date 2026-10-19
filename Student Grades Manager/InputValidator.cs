using System;
using System.Collections.Generic;

public class InputValidator
{
    public bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    public bool AreValidGrades(int[] grades)
    {
        if (grades == null || grades.Length == 0)
        {
            return false;
        }

        foreach (int grade in grades)
        {
            if (grade < 0 || grade > 100)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsUniqueId(int id, List<Student> students)
    {
        if (students == null)
        {
            return true;
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
