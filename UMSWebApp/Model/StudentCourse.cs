using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSWebApp.Model
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string EnrollDate { get; set; }

        public StudentCourse(int studentId, int courseId, string enrollDate)
        {
            StudentId = studentId;
            CourseId = courseId;
            EnrollDate = enrollDate;
        }
    }
}