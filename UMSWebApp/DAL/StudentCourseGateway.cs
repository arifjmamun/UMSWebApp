using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.Model;

namespace UMSWebApp.DAL
{
    public class StudentCourseGateway : DBconnection
    {
        public int IsEnrolled(StudentCourse studentCourse)
        {
            try
            {
                const string query = @"SELECT COUNT(*) FROM StudentCourse WHERE StudentId = @StudentId AND CourseId = @CourseId";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@StudentId", studentCourse.StudentId);
                Command.Parameters.AddWithValue("@CourseId", studentCourse.CourseId);
                int countEnroll = (int)Command.ExecuteScalar();
                return countEnroll;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int AddStudentCourse(StudentCourse studentCourse)
        {
            try
            {
                const string query = @"INSERT INTO StudentCourse(StudentId, CourseId, EnrollDate) VALUES(@StudentId, @CourseId, @EnrollDate)";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("StudentId",studentCourse.StudentId);
                Command.Parameters.AddWithValue("@CourseId", studentCourse.CourseId);
                Command.Parameters.AddWithValue("@EnrollDate", studentCourse.EnrollDate);
                int countaffectedRows = Command.ExecuteNonQuery();
                return countaffectedRows;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}