using StudentManagement.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Student_Form
{
    public partial class MainFormStudent : Form
    {
        
        public MainFormStudent(string username)
        {
            InitializeComponent();
            labelUsername.Text = username;

        }
        Student student = new Student();

        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteStudentForm = new UpdateDeleteStudentForm();
            updateDeleteStudentForm.buttonRemove.Enabled = false;


            SqlCommand sqlCommand = new SqlCommand("select mssv, firstname,lastname,bday,gender,phone,email,address,picture,department,major,hometown " +
                "FROM Student inner join Login on Login.gmail = Student.email where Login.username = @user");
            sqlCommand.Parameters.AddWithValue("@user", SqlDbType.NVarChar).Value = labelUsername.Text;
            DataTable table = student.getStudent(sqlCommand);

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                updateDeleteStudentForm.textBoxID.Text = row["mssv"].ToString();
               
                updateDeleteStudentForm.textBoxFN.Text = row["firstname"].ToString();
                updateDeleteStudentForm.textBoxLN.Text = row["lastname"].ToString();
                updateDeleteStudentForm.dateTimePickerBday.Value = (DateTime)row["bday"];

                if (row["gender"].ToString().Trim() == "Female")
                {
                    updateDeleteStudentForm.radioButtonFemale.Checked = true;
                }
                else
                {
                    updateDeleteStudentForm.radioButtonMale.Checked = true;
                }

                updateDeleteStudentForm.textBoxPhone.Text = row["phone"].ToString();
                updateDeleteStudentForm.textBoxEmail.Text = row["email"].ToString();
                updateDeleteStudentForm.textBoxAdrs.Text = row["address"].ToString();


                byte[] pic;
                pic = (byte[])row["picture"];
                MemoryStream picture = new MemoryStream(pic);
                updateDeleteStudentForm.pictureBoxSt.Image = Image.FromStream(picture);

                updateDeleteStudentForm.comboBoxDpt.Text = row["department"].ToString();
                updateDeleteStudentForm.textBoxMajor.Text = row["major"].ToString();
                updateDeleteStudentForm.textBoxHometown.Text = row["hometown"].ToString();
                
                updateDeleteStudentForm.Show();

            }
            else
            {
                MessageBox.Show("No data found.");
            }
        }

        private void viewScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ViewScoreForm form = new ViewScoreForm();

            SqlCommand sqlCommand = new SqlCommand("select mssv " +
                "FROM Student inner join Login on Login.gmail = Student.email where Login.username = @user");
            sqlCommand.Parameters.AddWithValue("@user", SqlDbType.NVarChar).Value = labelUsername.Text;
            DataTable table = student.getStudent(sqlCommand);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                form.labelID.Text = row["mssv"].ToString();
                form.Show();
            }

            
        }

        private void registerCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse addCourse = new AddCourse();

            SqlCommand sqlCommand = new SqlCommand("select mssv " +
                "FROM Student inner join Login on Login.gmail = Student.email where Login.username = @user");
            sqlCommand.Parameters.AddWithValue("@user", SqlDbType.NVarChar).Value = labelUsername.Text;
            DataTable table = student.getStudent(sqlCommand);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                addCourse.textBoxID.Text = row["mssv"].ToString();
                
                addCourse.Show();
            }
        }


        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintRegisterCourse form = new PrintRegisterCourse();
            SqlCommand sqlCommand = new SqlCommand("select mssv " +
                "FROM Student inner join Login on Login.gmail = Student.email where Login.username = @user");
            sqlCommand.Parameters.AddWithValue("@user", SqlDbType.NVarChar).Value = labelUsername.Text;
            DataTable table = student.getStudent(sqlCommand);
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                form.labelID.Text = row["mssv"].ToString();

                form.Show();
            }
        }
        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }
    }
}
