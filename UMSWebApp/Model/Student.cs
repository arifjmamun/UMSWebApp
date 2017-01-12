using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSWebApp.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }

        public Student(string name, string regNo, string phoneNo, string address, int departmentId)
        {
            Name = name;
            RegNo = regNo;
            PhoneNo = phoneNo;
            Address = address;
            DepartmentId = departmentId;
        }
    }
}