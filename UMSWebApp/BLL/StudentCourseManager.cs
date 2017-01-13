using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.DAL;
using UMSWebApp.Model;

namespace UMSWebApp.BLL
{
    public class StudentCourseManager
    {
        StudentCourseGateway _studentCourseGateway = new StudentCourseGateway();
        
        public string AddStudentCourse(StudentCourse studentCourse)
        {
            if (!IsEnrolled(studentCourse))
            {
                int affectedRows = _studentCourseGateway.AddStudentCourse(studentCourse);
                if (affectedRows > 0) return "Course Enrolled";
                return "Course Enrollment failed.";
            }
            return "Already enrolled to this course.";
        }

        private bool IsEnrolled(StudentCourse studentCourse)
        {
            int countEnroll = _studentCourseGateway.IsEnrolled(studentCourse);
            if (countEnroll > 0) return true;
            return false;
        }
    }
}