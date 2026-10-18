using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades_Manager
{
    internal class StudentReport
    {
        public string GetStudentStatus(double average)
        {
            if (average >= 50)
            {
                return "Pass";
            }

            return "Fail";
        }
    }
}