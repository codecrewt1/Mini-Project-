InputValidator validator = new InputValidator();

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

if (!validator.AreValidGrades(grades))
{
    Console.WriteLine("Invalid Grades: All grades must be between 0 and 100.");
    return;
}
