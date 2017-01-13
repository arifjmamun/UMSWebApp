using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.DAL;
using UMSWebApp.Model;

namespace UMSWebApp.BLL
{
    public class CourseManager
    {
        CourseGateway _courseGateway = new CourseGateway();

        public List<Course> GetAllCourses()
        {
            return _courseGateway.GetAllCourses();
        }

        public string AddCourse(Course course)
        {
            if (!IsCourseExist(course))
            {
                int countAffectedRows = _courseGateway.AddCourse(course);
                if (countAffectedRows > 0) return "Course Added.";
                return "Course Not Added.";
            }
            return "Course already exist.";
        }

        private bool IsCourseExist(Course course)
        {
            int countCourse = _courseGateway.IsCourseExist(course);
            if (countCourse > 0) return true;
            return false;
        }

        internal string UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCourseInfo()
        {
            return _courseGateway.GetAllCourseInfo();
        }
    }
}