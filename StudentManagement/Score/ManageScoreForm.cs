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

namespace StudentManagement.Score
{
    public partial class ManageScoreForm : Form
    {
        public ManageScoreForm()
        {
            InitializeComponent();
        }
        Score score = new Score();
        Student student = new Student();
        Course.Course course = new Course.Course();
        string data = "Score";

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = score.getStudentScore();
            data = "Score";

            comboBoxCourse.DataSource = course.getAllCourse();
            comboBoxCourse.DisplayMember = "label";
            comboBoxCourse.ValueMember = "id";
        }

        private void buttonShowSt_Click(object sender, EventArgs e)
        {
            data = "Student";
            SqlCommand command = new SqlCommand("SELECT mssv as MSSV, firstname as 'First Name', lastname as 'Last Name', bday as Birthday FROM Student");
            dataGridView1.DataSource = student.getStudent(command);
        }

        private void buttonShowScore_Click(object sender, EventArgs e)
        {
            data = "Score";
            dataGridView1.DataSource = score.getStudentScore();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataFromDatagridView();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (data == "Score")
            {
                int student_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                int course_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                if ((MessageBox.Show("Are you sure you want to delete this Score", "Remove Score", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    if (score.deleteScore(student_id, course_id))
                    {
                        MessageBox.Show("Score Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = score.getStudentScore();
                    }
                    else
                    {
                        MessageBox.Show("Score Not Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Chose Score Before Delete!", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void getDataFromDatagridView()
        {
            if (data == "Student")
            {
                textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            else if (data == "Score")
            {
                textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxCourse.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value;
            }
        }

        private void buttonAvgScore_Click(object sender, EventArgs e)
        {
            AvgScoreByCourseForm frm = new AvgScoreByCourseForm();
            frm.ShowDialog();
        }

        private void textBoxScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Chi duoc nhap so!!", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxScore.Clear();
                e.Handled = true;
            }
        }
    }

}
