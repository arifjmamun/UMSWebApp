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
                if (Request.QueryString["regNo"] != null)
                {
                    ShowStduentByRegNo();
                    saveButton.Text = "Update";
                    regNoTextBox.Attributes.Add("readonly", "readonly");
                }
            }
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (departmentDropDownList.SelectedValue != null && nameTextBox.Text != String.Empty &&
                regNoTextBox.Text != String.Empty && phoneNoTextBox.Text != String.Empty && addressTextBox.Text != String.Empty)
            {
                int departmentId = Convert.ToInt32(departmentDropDownList.SelectedValue);
                string name = nameTextBox.Text;
                string regNo = regNoTextBox.Text;
                string phoneNo = phoneNoTextBox.Text;
                string address = addressTextBox.Text;
                Student student = new Student(name, regNo, phoneNo, address, departmentId);
                if (saveButton.Text == "Save")
                {
                    msgLabel.Text = _studentManager.SaveStudent(student);
                    ResetFields();
                }
                else
                {
                    msgLabel.Text = _studentManager.UpdateStudent(student);
                    ResetFields();

                }
                ShowAllStudents();
            }
            else
            {
                msgLabel.Text = "Each of these fields are required.";
            }
        }

        private void ResetFields()
        {
            saveButton.Text = "Save";
            departmentDropDownList.SelectedIndex = 0;
            nameTextBox.Text = String.Empty;
            regNoTextBox.Text = String.Empty;
            regNoTextBox.Attributes.Remove("readonly");
            phoneNoTextBox.Text = String.Empty;
            addressTextBox.Text = String.Empty;
        }


        protected void showButton_Click(object sender, EventArgs e)
        {
            ShowAllStudents();
        }

        private void LoadDepartments()
        {
            departmentDropDownList.DataSource = _departmentManager.GetDepartments();
            departmentDropDownList.DataTextField = "Name";
            departmentDropDownList.DataValueField = "Id";
            departmentDropDownList.DataBind();
        }


        private void ShowAllStudents()
        {
            msgLabel.Text = String.Empty;
            studentGridView.DataSource = _studentManager.GetAllStudents();
            studentGridView.DataBind();
        }

        private void ShowStduentByRegNo()
        {
            string regNo = Request.QueryString["regNo"];
            Student student = _studentManager.GetStudentByRegNo(regNo);
            if (student != null)
            {
                departmentDropDownList.SelectedValue = student.DepartmentId.ToString();
                nameTextBox.Text = student.Name;
                regNoTextBox.Text = student.RegNo;
                phoneNoTextBox.Text = student.PhoneNo;
                addressTextBox.Text = student.Address;
            }
        }

    }
}