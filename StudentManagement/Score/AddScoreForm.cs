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
    public partial class AddScoreForm : Form
    {
        public AddScoreForm()
        {
            InitializeComponent();
        }
        Score score = new Score();
        Course.Course course = new Course.Course();
        Student student = new Student();


        private void AddScoreForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet.Score' table. You can move, or remove it, as needed.
            comboBoxCourse.DataSource = course.getAllCourse();
            comboBoxCourse.DisplayMember = "Label";
            comboBoxCourse.ValueMember = "Id";

            //
            SqlCommand command = new SqlCommand("SELECT mssv as MSSV, firstname as FirstName, lastname as LastName FROM Student");
            dataGridView1.DataSource = student.getStudent(command);

        }

        private void dataGridView1_Click(object sender, EventArgs e)
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

        private void textBoxScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Chi duoc nhap so!!", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxID.Clear();
                e.Handled = true;
            }
        }
    }
}
