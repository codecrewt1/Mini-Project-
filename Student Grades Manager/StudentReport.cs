namespace Student_Grades_Manager
{
    public class StudentReport
    {
        public string GetStudentStatus(double average)
        {
            return average >= 50 ? "Pass" : "Fail";
        }
    }
}