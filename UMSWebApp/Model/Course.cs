using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMSWebApp.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public decimal Credit { get; set; }

        //used for set
        public Course(string title, string code, decimal credit)
        {
            Title = title;
            Code = code;
            Credit = credit;
        }

        //used for get
        public Course()
        {
            
        }
    }
}