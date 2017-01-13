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
        }

        private void ShowAllStudents()
        {
            courseGridView.DataSource = _courseManager.GetAllCourseInfo();
            courseGridView.DataBind();
        }
    }
}