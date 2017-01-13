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
    }
}