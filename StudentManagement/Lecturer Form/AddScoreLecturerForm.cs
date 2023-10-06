using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Lecturer_Form
{
    public partial class AddScoreLecturerForm : Form
    {
        public AddScoreLecturerForm()
        {
            InitializeComponent();
        }
        Score.Score score = new Score.Score();
        Course.Course course = new Course.Course();
        Student student = new Student();

        private void AddScoreLecturerForm_Load(object sender, EventArgs e)
        {
            comboBoxCourse.DataSource = course.getAllCourseByLecturer(Global.GlobalUserID1);
            comboBoxCourse.DisplayMember = "Label";
            comboBoxCourse.ValueMember = "Id";

            //
            SqlCommand command = new SqlCommand("SELECT mssv as MSSV, firstname as FirstName, lastname as LastName FROM Student " +
                " where selectedCourse like N'%"+comboBoxCourse.Text+"%'");
            dataGridView1.DataSource = student.getStudent(command);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxScore.Text.Trim() == "")
                {
                    MessageBox.Show("Please Add An Score", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int studentID = Convert.ToInt32(textBoxID.Text);
                    int courseID = Convert.ToInt32(comboBoxCourse.SelectedValue);
                    float scoreValue = float.Parse(textBoxScore.Text);
                    string description = textBoxDescription.Text;
                    if (scoreValue >= 0 && scoreValue <= 10)
                    {
                        //Check if the score is already set for student on this course
                        if (!score.studentScoreExist(studentID, courseID))
                        {
                            if (score.insertScore(studentID, courseID, scoreValue, description))
                                MessageBox.Show("Score Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Score Not Inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("The Score For This Course Are Already Set", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("The Score Must Between 0 And 10!", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT mssv as MSSV, firstname as FirstName, lastname as LastName FROM Student " +
                " where selectedCourse like N'%" + comboBoxCourse.Text + "%'");
            dataGridView1.DataSource = student.getStudent(command);
        }
    }
}
