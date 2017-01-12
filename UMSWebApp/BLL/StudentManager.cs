using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.DAL;
using UMSWebApp.Model;
using UMSWebApp.ViewModel;

namespace UMSWebApp.BLL
{
    public class StudentManager
    {
        StudentGateway _studentGateway = new StudentGateway();

        public string SaveStudent(Student student)
        {
            if (!IsRegNoExist(student.RegNo))
            {
                int countAffectedRows = _studentGateway.SaveStudent(student);
                if (countAffectedRows > 0) return "Student Info Saved.";
                return "Student info not saved";

            }
            return "Student already registered.";
        }

        private bool IsRegNoExist(string regNo)
        {
            int countRegNo = _studentGateway.IsRegNoExist(regNo);
            if (countRegNo > 0) return true;
            return false;
        }

        public List<StudentWithDepartment> GetAllStudents()
        {
            return _studentGateway.GetAllStudents();
        }
    }
}