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

namespace StudentManagement.Student_Form
{
    public partial class PrintRegisterCourse : Form
    {
        public PrintRegisterCourse()
        {
            InitializeComponent();
        }
        Student student = new Student();
        private void PrintRegisterCourse_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT mssv as MSSV,firstname as FirstName, lastname as LastName," +
                "department as Faculty,selectedCourse as 'Selected Course' from Student where mssv = @id");
            sqlCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = labelID.Text;
            DataTable table = student.getStudent(sqlCommand);
            dataGridView1.DataSource = table;
        }
    }
}
