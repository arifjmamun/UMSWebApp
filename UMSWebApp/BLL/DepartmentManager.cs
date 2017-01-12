using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMSWebApp.DAL;
using UMSWebApp.Model;
using UMSWebApp.ViewModel;

namespace UMSWebApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway _departmentGateway = new DepartmentGateway();

        
        public List<Department> GetDepartments()
        {
            return _departmentGateway.GetDepartments();
        }

        
    }
}