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
    public partial class AddCourse : Page
    {
        CourseManager _courseManager = new CourseManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    ShowCourseById();
                }
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (courseTtileTextBox.Text != String.Empty && courseCodeTextBox.Text != String.Empty && courseCreditTextBox.Text != String.Empty)
            {
                string title = courseTtileTextBox.Text;
                string code = courseCodeTextBox.Text;
                decimal credit = Convert.ToDecimal(courseCreditTextBox.Text);
                Course course  = new Course(title,code,credit);
                if (addButton.Text == "Add")
                {
                    msgLabel.Text = _courseManager.AddCourse(course);
                    ResetFields();
                }
                else
                {
                    int courseId = (int) ViewState["CourseId"];
                    course.Id = courseId;
                    msgLabel.Text = _courseManager.UpdateCourse(course);
                    ResetFields();

                }
                ShowAllStudents();
            }
            else
            {
                msgLabel.Text = "Each of the field is required.";
            }
        }


        protected void showButton_Click(object sender, EventArgs e)
        {
            ShowAllStudents();
        }

        private void ResetFields()
        {
            addButton.Text = "Add";
            courseTtileTextBox.Text = String.Empty;
            courseCodeTextBox.Text = String.Empty;
            courseCreditTextBox.Text = String.Empty;
            if (ViewState["CourseId"] != null) ViewState.Remove("CourseId");
        }

        private void ShowAllStudents()
        {
            courseGridView.DataSource = _courseManager.GetAllCourseInfo();
            courseGridView.DataBind();
        }

        private void ShowCourseById()
        {
            int courseId = Convert.ToInt32(Request.QueryString["Id"]);
            Course course = _courseManager.GetCourseById(courseId);
            if (course != null)
            {
                courseCodeTextBox.Text = course.Code;
                courseTtileTextBox.Text = course.Title;
                courseCreditTextBox.Text = course.Credit.ToString("F");
                addButton.Text = "Update";
                if (ViewState["CourseId"] == null)
                {
                    ViewState["CourseId"] = courseId;
                }
                else
                {
                    ViewState.Remove("CourseId");
                    ViewState["CourseId"] = courseId;
                }
            }
        }
    }
}