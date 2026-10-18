using System;
using System.Collections.Generic;

public class InputValidator
{
    // Checks name is not empty or whitespace
    public bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    // Checks all grades are between 0 and 100 inclusive
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

    // Checks student ID does not already exist
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
