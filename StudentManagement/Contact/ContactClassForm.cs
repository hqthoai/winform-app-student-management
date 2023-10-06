using StudentManagement.Course;
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

namespace StudentManagement.Contact
{
    public partial class ContactClassForm : Form
    {
        public int ContactID;
        public ContactClassForm()
        {
            InitializeComponent();
        }

        My_DB mydb = new My_DB();
        public ContactClassForm(int contactID)
        {
            this.ContactID = contactID;
        }
        private void ContactClassForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select contact.fname as FirstName, contact.lname as LastName, Course.id as CourseID, Course.label as CourseName " +
                "from contact inner join Course on contact.id = course.contactID WHERE contact.id = @cid", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = ContactID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CourseStudentList course = new CourseStudentList();

            course.textBoxCourseName.Text = dataGridView1.CurrentRow.Cells["CourseName"].Value.ToString();
            course.Show(this);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CourseStudentList course = new CourseStudentList();
            course.ContactID = ContactID;
            course.textBoxCourseName.Text = dataGridView1.CurrentRow.Cells["CourseName"].Value.ToString();
            course.Show(this);
        }
    }
}
