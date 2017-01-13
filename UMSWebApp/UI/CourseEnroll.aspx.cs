using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UMSWebApp.BLL;
using UMSWebApp.Model;

namespace UMSWebApp.UI
{
    public partial class CourseEnroll : System.Web.UI.Page
    {
        StudentManager _studentManager = new StudentManager();
        CourseManager _courseManager =new CourseManager();
        StudentCourseManager _studentCourseManager = new StudentCourseManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllStudentsRegNo();
                LoadAllCourses();
            }
        }


        protected void enrollButton_Click(object sender, EventArgs e)
        {
            EnrollCourse();
        }

        private void EnrollCourse()
        {
            int studentId = Convert.ToInt32(studentRegNoDropDownList.SelectedValue);
            int courseId = Convert.ToInt32(coursesDropDownList.SelectedValue);
            string enrollDate = enrollDateTextBox.Text;
            StudentCourse studentCourse = new StudentCourse(studentId, courseId, enrollDate);
            msgLabel.Text = _studentCourseManager.AddStudentCourse(studentCourse);
        }
        
        private void LoadAllCourses()
        {
            coursesDropDownList.DataSource = _courseManager.GetAllCourses();
            coursesDropDownList.DataTextField = "Title";
            coursesDropDownList.DataValueField = "Id";
            coursesDropDownList.DataBind();
        }

        private void LoadAllStudentsRegNo()
        {
            studentRegNoDropDownList.DataSource = _studentManager.GetAllStudentRegNo();
            studentRegNoDropDownList.DataTextField = "RegNo";
            studentRegNoDropDownList.DataValueField = "Id";
            studentRegNoDropDownList.DataBind();
        }

    }
}