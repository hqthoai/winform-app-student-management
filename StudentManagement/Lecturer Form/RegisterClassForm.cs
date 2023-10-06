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
    public partial class RegisterClassForm : Form
    {
        public RegisterClassForm()
        {
            InitializeComponent();
        }
        My_DB mydb = new My_DB();
        Course.Course course = new Course.Course();
        private void RegisterClassForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select id,label as CourseName from Course",mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            comboBoxSelectCourse.DataSource = table;
            comboBoxSelectCourse.DisplayMember = "CourseName";
            comboBoxSelectCourse.ValueMember = "id";
        }

        private void buttonRegisterClass_Click(object sender, EventArgs e)
        {
            int courseID=0;
            if (comboBoxSelectCourse.SelectedValue != null && Int32.TryParse(comboBoxSelectCourse.SelectedValue.ToString(), out courseID))
            {
                courseID = Int32.Parse(comboBoxSelectCourse.SelectedValue.ToString());
            }

            if (!course.CheckContactID(courseID))
            {
                course.RegisterTeachingCourse(courseID, Global.GlobalUserID1);
                MessageBox.Show("Dang ky course thanh cong");
            }
            else
            {
                MessageBox.Show("Da dang ky course roi");
            }
        }
        // xu ly them phần đăng ký dạy cho giáo viên , rồi chia form cho từng role lại là xong !!
    }
}
