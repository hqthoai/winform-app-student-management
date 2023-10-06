using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Course
{
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }
        Course course = new Course();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {     
                    int num = -1;
                    if (textBoxLabel.Text.Trim() == "")
                    {
                        MessageBox.Show("Add a Course Name", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (!Int32.TryParse(textBoxID.Text, out num))
                    {
                        MessageBox.Show("Please Add An InterGer For Course's ID", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (course.checkCourseName(textBoxLabel.Text))
                    {
                        int id = Convert.ToInt32(textBoxID.Text);
                        string nameCourse = textBoxLabel.Text;
                        int hourse = Int32.Parse( textBoxPeriod.Text.ToString());
                        string description = textBoxDescription.Text;
                        int semester =Int32.Parse(comboBoxSemester.SelectedItem.ToString());
                        if (hourse < 10)
                        {
                            MessageBox.Show("Period Require At Least 10 ", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (course.checkCourseID(id))
                            {
                                if (course.insertCourse(id, nameCourse, hourse, description, semester))
                                {
                                    MessageBox.Show("New Course Insert", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Course Not Insert", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("ID Existed!", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("This Course Name Already Exists", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        bool verif()
        {
            if (textBoxID.Text.Trim() == "" || textBoxLabel.Text.Trim() == "")
                return false;
            else
                return true;

        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {
            comboBoxSemester.SelectedIndex = 0;
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))    
            {
                MessageBox.Show("Chi duoc nhap so!!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxID.Clear();
                e.Handled = true;
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Chi duoc nhap so!!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPeriod.Clear();
                e.Handled = true;
            }
        }

        private void comboBoxSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
