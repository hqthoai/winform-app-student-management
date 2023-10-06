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

namespace StudentManagement
{
    public partial class FindStudentForm : Form
    {
        Student student = new Student();
        My_DB db = new My_DB();
        public FindStudentForm()
        {
            InitializeComponent();
        }

        private void FindStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVnew.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.qLSVnew.Student);
            // TODO: This line of code loads data into the 'qLSVDataSet.Student' table. You can move, or remove it, as needed.
           

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            string name = textBoxName.Text;
            string adrs = textBoxAddress.Text;
            string town = textBoxPBirth.Text;

            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE mssv LIKE N'%" + @id + "%'" + " AND lastname LIKE N'%" + @name + "%'" + " AND address LIKE N'%" + @adrs + "%'" + " AND hometown LIKE N'%" + @town + "%'");
            DataTable table = student.getStudent(command);

            if (table.Rows.Count > 0)
            {
                dataGridViewResult.ReadOnly = true;

                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGridViewResult.RowTemplate.Height = 60;
                dataGridViewResult.DataSource = student.getStudent(command);

                picCol = (DataGridViewImageColumn)dataGridViewResult.Columns[8];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridViewResult.AllowUserToAddRows = false;
            }
            else
            {
                dataGridViewResult.ReadOnly = true;

                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGridViewResult.RowTemplate.Height = 60;
                dataGridViewResult.DataSource = student.getStudent(command);

                picCol = (DataGridViewImageColumn)dataGridViewResult.Columns[8];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridViewResult.AllowUserToAddRows = false;
                MessageBox.Show("Khong tim thay SV nay!!", "Tim sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
