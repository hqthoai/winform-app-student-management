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
    public partial class ManageCourseForm : Form
    {
        public ManageCourseForm()
        {
            InitializeComponent();
        }

        Course course = new Course();
        int pos;

        void reloadListBoxData()
        {
            listBoxCourse.DataSource = course.getAllCourse();
            listBoxCourse.ValueMember = "Id";
            listBoxCourse.DisplayMember = "label";
            listBoxCourse.SelectedItem = null;
            labelTotal.Text = ("Total Course: " + course.totalCourse());
        }

        void showData(int index)
        {
            if (index < 0)
            {
                return;
            }
            else
            {
                DataRow dr = course.getAllCourse().Rows[index];
                listBoxCourse.SelectedIndex = index;
                textBoxID.Text = dr.ItemArray[0].ToString();
                textBoxLabel.Text = dr.ItemArray[1].ToString();
                numericUpDownPeriod.Value = int.Parse(dr.ItemArray[2].ToString());
                textBoxDescription.Text = dr.ItemArray[3].ToString();
                comboBoxSemester.Text = (dr.ItemArray[4].ToString());
            }
        }
        bool verif()
        {
            if (textBoxID.Text.Trim() == "" || textBoxLabel.Text.Trim() == "")
                return false;
            else
                return true;

        }


        private void buttonFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
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
                    int hourse = (int)numericUpDownPeriod.Value;
                    string description = textBoxDescription.Text;
                    int semester = Int32.Parse(comboBoxSemester.SelectedItem.ToString());
                    if (hourse < 10)
                    {
                        MessageBox.Show("Period Require At Least 10 ", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (course.checkCourseID(id))
                        {
                            if (course.insertCourse(id, nameCourse, hourse, description,semester))
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

            reloadListBoxData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLabel.Text.Trim() == "")
                {
                    MessageBox.Show("Add a Course Name", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if ((int)numericUpDownPeriod.Value < 10)
                {
                    MessageBox.Show("Period Require At Least 10 ", "Add Course ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string name = textBoxLabel.Text;
                    int hrs = (int)numericUpDownPeriod.Value;
                    string descr = textBoxDescription.Text;
                    int id = int.Parse(textBoxID.Text);
                    int semester = Int32.Parse(comboBoxSemester.SelectedItem.ToString());
                    //Lấy lại phần kiểm tra tên course
                    if (!course.checkCourseName(name, id))
                    {
                        MessageBox.Show("This Course Name Already Exist", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (course.updateCourse(id, name, hrs, descr, semester))
                    {
                        MessageBox.Show("Course Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Updated", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            pos = 0;
            reloadListBoxData();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int CourseID = Convert.ToInt32(textBoxID.Text);
                if ((MessageBox.Show("Are you sure you want to delete this course", "Remove Course", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    if (course.deleteCourse(CourseID))
                    {
                        MessageBox.Show("Course Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Clear Fields
                        textBoxID.Text = "";
                        textBoxLabel.Text = "";
                        numericUpDownPeriod.Value = 10;
                        textBoxDescription.Text = "";

                        reloadListBoxData();
                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter A Valid Numeric ID", "Remove Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            pos = 0;
            reloadListBoxData();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pos < (course.getAllCourse().Rows.Count - 1))
            {
                pos = pos + 1;
                showData(pos);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos = pos - 1;
                showData(pos);
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            pos = course.getAllCourse().Rows.Count - 1;
            showData(pos);
        }

        private void listBoxCourse_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)listBoxCourse.SelectedItem;
            pos = listBoxCourse.SelectedIndex;
            showData(pos);
        }

        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            comboBoxSemester.SelectedIndex = 0;
            reloadListBoxData();
        }

        private void listBoxCourse_DoubleClick(object sender, EventArgs e)
        {
            CourseStudentList course = new CourseStudentList();
            course.textBoxCourseName.Text = textBoxLabel.Text;
            course.labelShowSemeter.Text = comboBoxSemester.SelectedItem.ToString();
            course.ShowDialog();
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

    }
}
