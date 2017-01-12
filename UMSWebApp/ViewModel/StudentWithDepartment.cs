using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSWebApp.ViewModel
{
    [Serializable]
    public class StudentWithDepartment
    {
        public int Serial { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
}