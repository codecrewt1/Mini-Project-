public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int[] Grades { get; set; }

    public Student(int id, string name, int age, int[] grades)
    {
        ID = id;
        Name = name;
        Age = age;
        Grades = grades;
    }
}