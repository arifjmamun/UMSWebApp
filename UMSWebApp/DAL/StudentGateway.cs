using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.Model;
using UMSWebApp.ViewModel;

namespace UMSWebApp.DAL
{
    public class StudentGateway : DBconnection
    {
        public int IsRegNoExist(string regNo)
        {
            try
            {
                const string query = @"SELECT COUNT(*) FROM Student WHERE RegNo = @RegNo";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@RegNo", regNo);
                int countRegNo = (int)Command.ExecuteScalar();
                return countRegNo;
            }
            finally
            {
                Connection.Close();
            }
        }

        public int SaveStudent(Student student)
        {
            try
            {
                const string query = @"INSERT INTO Student(Name, RegNo, PhoneNo, Address, DepartmentId) 
                                        VALUES(@Name, @RegNo, @PhoneNo, @Address, @DepartmentId)";
                Connection.Open();
                Command.CommandText = query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@Name", student.Name);
                Command.Parameters.AddWithValue("@RegNo", student.RegNo);
                Command.Parameters.AddWithValue("@PhoneNo", student.PhoneNo);
                Command.Parameters.AddWithValue("@Address", student.Address);
                Command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
                int countaffectedRows = Command.ExecuteNonQuery();
                return countaffectedRows;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<StudentWithDepartment> GetAllStudents()
        {
            try
            {
                List<StudentWithDepartment> studentWithDepartments = new List<StudentWithDepartment>();
                const string query = @"SELECT * FROM StudentWithDepartment";
                Connection.Open();
                Command.CommandText = query;
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    int serial = 0;
                    while (Reader.Read())
                    {
                        StudentWithDepartment studentWithDepartment = new StudentWithDepartment();
                        studentWithDepartment.Serial = ++serial;
                        studentWithDepartment.Name = Reader["Name"].ToString();
                        studentWithDepartment.RegNo = Reader["RegNo"].ToString();
                        studentWithDepartment.PhoneNo = Reader["PhoneNo"].ToString();
                        studentWithDepartment.Department = Reader["DeptName"].ToString();
                        studentWithDepartments.Add(studentWithDepartment);
                    }
                    Reader.Close();
                }
                return studentWithDepartments;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}