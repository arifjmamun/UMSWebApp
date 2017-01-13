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

        public int IsCourseExist(Course course)
        {
            try
            {
                const string query = @"SELECT COUNT(*) FROM Course WHERE Code = @Code";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Code", course.Code);
                int countCourse = (int)Command.ExecuteScalar();
                return countCourse;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int AddCourse(Course course)
        {
            try
            {
                const string query = @"INSERT INTO Course(Code, Title, Credit) VALUES(@Code, @Title, @Credit)";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Title", course.Title);
                Command.Parameters.AddWithValue("@Code", course.Code);
                Command.Parameters.AddWithValue("@Credit", course.Credit);
                int countAffectedRow = (int)Command.ExecuteNonQuery();
                return countAffectedRow;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Course> GetAllCourseInfo()
        {
            try
            {
                List<Course> courses = new List<Course>();
                const string query = @"SELECT * FROM Course";
                Connection.Open();
                Command.CommandText = query;
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Course course = new Course();
                        course.Id = (int)Reader["Id"];
                        course.Code = Reader["Code"].ToString();
                        course.Title = Reader["Title"].ToString();
                        course.Credit = (decimal) Reader["Credit"];
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

        public Course GetCourseById(int courseId)
        {
            try
            {
                Course course = null;
                const string query = @"SELECT * FROM Course WHERE Id = @CourseId";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@CourseId", courseId);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    if (Reader.Read())
                    {
                        string code = Reader["Code"].ToString();
                        string title = Reader["Title"].ToString();
                        decimal credit = (decimal)Reader["Credit"];
                        course = new Course(title,code,credit);
                        Reader.Close();
                    }
                }
                return course;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int UpdateCourse(Course course)
        {
            try
            {
                const string query = @"UPDATE Course SET Code = @Code, Title = @Title, Credit = @Credit WHERE Id = @CourseId";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@CourseId", course.Id);
                Command.Parameters.AddWithValue("@Code", course.Code);
                Command.Parameters.AddWithValue("@Title", course.Title);
                Command.Parameters.AddWithValue("@Credit", course.Credit);
                int updatedRow = Command.ExecuteNonQuery();
                return updatedRow;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}