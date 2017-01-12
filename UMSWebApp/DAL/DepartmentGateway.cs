using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.Model;

namespace UMSWebApp.DAL
{
    public class DepartmentGateway : DBconnection
    {

        public List<Department> GetDepartments()
        {
            try
            {
                List<Department> departments = new List<Department>();
                const string query = @"SELECT * FROM Department";
                Connection.Open();
                Command.CommandText = query;
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Department department = new Department();
                        department.Id = (int)Reader["Id"];
                        department.Name = Reader["Name"].ToString();
                        departments.Add(department);
                    }
                    Reader.Close();
                }
                return departments;
            }
            finally
            {
                Connection.Close();
            }
        }

    }
}