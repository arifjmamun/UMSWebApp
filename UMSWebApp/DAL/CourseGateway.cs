using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.Model;

namespace UMSWebApp.DAL
{
    public class CourseGateway : DBconnection
    {
        public List<Course> GetAllCourses()
        {
            try
            {
                List<Course> courses = new List<Course>();
                const string query = @"SELECT Id, Title FROM Course";
                Connection.Open();
                Command.CommandText = query;
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Course course = new Course();
                        course.Id = (int)Reader["Id"];
                        course.Title = Reader["Title"].ToString();
                        courses.Add(course);
                    }
                    Reader.Close();
                }
                return courses;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}