using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Course
{
    public partial class EditCourseForm : Form
    {
        Course course = new Course();
        public EditCourseForm()
        {
            InitializeComponent();
        }

        private bool checkInput()
        {
            string name = textBoxLabel.Text;
            int period = (int)numericUpDownPeriod.Value;
            string description = textBoxDescription.Text;
            int id = (int)comboBoxSelectCourse.SelectedValue;

            if (name.Trim() == "")
            {
                MessageBox.Show("Vui long dien ten cua course", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            if (period < 10)
            {
                MessageBox.Show("Period time phai > 10 !", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {        
            string name = textBoxLabel.Text;
            int period = (int)numericUpDownPeriod.Value;
            string description = textBoxDescription.Text;
            int id = (int)comboBoxSelectCourse.SelectedValue;
            int semester =Int32.Parse(comboBoxSemester.SelectedItem.ToString());
            
            if (checkInput())
            {
                if (!course.checkCourseName(name, id))
                {
                    MessageBox.Show("Course khong ton tai!", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (course.updateCourse(id,name,period,description,semester))
                {
                    MessageBox.Show("Cap nhat course thanh cong!", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillCombobox(comboBoxSelectCourse.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Cap nhat that bai !", "Edit Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
           
        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {
            comboBoxSemester.SelectedIndex = 0;
            comboBoxSelectCourse.DataSource = course.getAllCourse();
            comboBoxSelectCourse.DisplayMember = "label";
            comboBoxSelectCourse.ValueMember = "id";
            comboBoxSelectCourse.SelectedItem = null;
        }

        public void fillCombobox(int index)
        {
            comboBoxSemester.SelectedIndex = 0;
            comboBoxSelectCourse.DataSource = course.getAllCourse();
            comboBoxSelectCourse.DisplayMember = "label";
            comboBoxSelectCourse.ValueMember = "id";
            comboBoxSelectCourse.SelectedItem = null;
        }

        private void comboBoxSelectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBoxSelectCourse.SelectedValue);
                DataTable table = new DataTable();
                table = course.getCourseById(id);
                textBoxLabel.Text = table.Rows[0][1].ToString();
                numericUpDownPeriod.Value = Int32.Parse(table.Rows[0][2].ToString());
                textBoxDescription.Text = table.Rows[0][3].ToString();


            }
            catch { }
        }
    }
}
