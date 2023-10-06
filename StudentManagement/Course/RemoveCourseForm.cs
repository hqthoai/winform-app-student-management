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

namespace StudentManagement.Course
{
    public partial class RemoveCourseForm : Form
    {
        Course course = new Course();
        public RemoveCourseForm()
        {
            InitializeComponent();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string message = "Ban co thuc su muon xoa khong?";
            string title = "Xoa Course";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(textBoxID.Text);

                DataTable table = course.getCourseById(id);
                if (table.Rows.Count > 0)
                {
                    if (course.deleteCourse(id))
                    {
                        MessageBox.Show("Xoa thanh cong", "Xoa Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Khong tim thay ID", "Xoa Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                textBoxID.Text = null;
            }
        }
    }
}
