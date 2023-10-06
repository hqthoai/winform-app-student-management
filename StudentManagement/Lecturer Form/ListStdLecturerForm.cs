using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace StudentManagement.Lecturer_Form
{
    public partial class ListStdLecturerForm : Form
    {
        public ListStdLecturerForm()
        {
            InitializeComponent();
        }
        My_DB db = new My_DB();
        Student student = new Student();
        Course.Course course = new Course.Course();
        private void ListStdLecturerForm_Load(object sender, EventArgs e)
        {
            DataTable table = course.getAllCourseByLecturer(Global.GlobalUserID1);
            DataTable table1 = new DataTable();
            int row = 0;

            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns.Add("MSSV", "MSSV");
            dataGridView1.Columns.Add("FirstName", "FirstName");
            dataGridView1.Columns.Add("LastName", "LastName");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string c = table.Rows[i]["label"].ToString();
                int scoreid = Int32.Parse(table.Rows[i]["id"].ToString());
                SqlCommand command = new SqlCommand("SELECT mssv as MSSV,firstname as FirstName, lastname as LastName FROM Student " +
                    "WHERE selectedCourse like N'%" + c + "%' ");
                command.Parameters.Add("@id", SqlDbType.Int).Value = scoreid;
                table1 = student.getStudent(command);
                for (int u = 0; u < table1.Rows.Count; u++)
                {
                    dataGridView1.Rows.Add();
                    for (int j = 0; j < table1.Columns.Count; j++)
                    {
                        dataGridView1.Rows[row].Cells[j].Value = table1.Rows[u][j];
                    }
                    row++;
                }

            }
        }
    }
}
