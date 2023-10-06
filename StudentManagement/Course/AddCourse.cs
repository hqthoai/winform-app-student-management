using StudentManagement.Contact;
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
    public partial class AddCourse : Form
    {
        
        public AddCourse()
        {
            InitializeComponent();
        }
        My_DB db = new My_DB();
        Student student = new Student();
        Course course = new Course();   
        private void AddCourse_Load(object sender, EventArgs e)
        {
            comboBoxSemeter.SelectedIndex = -1;

            DataTable dt = course.getAllCourse();

            foreach (DataRow row in dt.Rows)
            {
                listBoxAvailable.Items.Add(row["label"].ToString());
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listBoxAvailable.SelectedIndex != -1)
            {
                listBoxSelected.Items.Add(listBoxAvailable.SelectedItem);
                listBoxAvailable.Items.Remove(listBoxAvailable.SelectedItem);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxSelected.SelectedIndex != -1)
            {
                listBoxAvailable.Items.Add(listBoxSelected.SelectedItem);
                listBoxSelected.Items.Remove(listBoxSelected.SelectedItem);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string ctemp="";

            foreach (string a in listBoxSelected.Items)
            {
                ctemp += a + ", ";
                //SqlCommand command = new SqlCommand("Select id from Course where label = @cname", db.getConnection);
                //command.Parameters.Add("@cname", SqlDbType.NVarChar).Value = a;

                //SqlDataAdapter adapter = new SqlDataAdapter(command);
                //DataTable table = new DataTable();
                //adapter.Fill(table);
                //int id =Int32.Parse(table.Rows[0]["id"].ToString());


            }
            if (student.updateCourse(textBoxID.Text, ctemp))
            {
                MessageBox.Show("Dang ki course thanh cong", "Dang ki course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBoxSelected.Items.Clear();
            }
            else
            {
                MessageBox.Show("Loi", "Dang ki course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listBoxAvailable_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxSemeter_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAvailable.Items.Clear();
            System.Data.DataTable dt = course.getCourseBySemester(Int32.Parse( comboBoxSemeter.SelectedItem.ToString()) );

            foreach (DataRow row in dt.Rows)
            {
                listBoxAvailable.Items.Add(row["label"].ToString());
            }
        }
    }
}
