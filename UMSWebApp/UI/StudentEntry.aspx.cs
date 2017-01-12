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
    public partial class StudentEntry : Page
    {
        StudentManager _studentManager = new StudentManager();
        DepartmentManager _departmentManager  = new DepartmentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartments();
                ShowAllStudents();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (departmentDropDownList.SelectedValue != null && nameTextBox.Text != String.Empty &&
                regNoTextBox.Text != String.Empty && phoneNoTextBox.Text != String.Empty && addressTextBox.Text != String.Empty)
            {
                AddStudent();
                ShowAllStudents();
            }
            else
            {
                msgLabel.Text = "Each of these fields are required.";
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadDepartments()
        {
            departmentDropDownList.DataSource = _departmentManager.GetDepartments();
            departmentDropDownList.DataTextField = "Name";
            departmentDropDownList.DataValueField = "Id";
            departmentDropDownList.DataBind();
        }

        private void AddStudent()
        {
            int departmentId = Convert.ToInt32(departmentDropDownList.SelectedValue);
            string name = nameTextBox.Text;
            string regNo = regNoTextBox.Text;
            string phoneNo = phoneNoTextBox.Text;
            string address = addressTextBox.Text;
            Student student = new Student(name, regNo,phoneNo,address,departmentId);
            msgLabel.Text = _studentManager.SaveStudent(student);
        }

        private void ShowAllStudents()
        {
            studentGridView.DataSource = _studentManager.GetAllStudents();
            studentGridView.DataBind();
        }

    }
}