using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class StudentListForm : Form
    {
        Student student = new Student();
        public StudentListForm()
        {
            InitializeComponent();
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVnew.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter2.Fill(this.qLSVnew.Student);
            // TODO: This line of code loads data into the 'qLSVDataSet1.Student' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'qLSVDataSet.Student' table. You can move, or remove it, as needed.
            // this.studentTableAdapter.Fill(this.qLSVDataSet.Student);


            SqlCommand command = new SqlCommand("SELECT * FROM Student");


            dataGridViewSt.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewSt.RowTemplate.Height = 80;
            dataGridViewSt.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridViewSt.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewSt.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student");
            dataGridViewSt.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewSt.RowTemplate.Height = 80;
            dataGridViewSt.DataSource = student.getStudent(command);


            picCol = (DataGridViewImageColumn)dataGridViewSt.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewSt.AllowUserToAddRows = false;
            dataGridViewSt.Sort(dataGridViewSt.Columns[0], ListSortDirection.Ascending);
        }

        private void dataGridViewSt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteStudentForm = new UpdateDeleteStudentForm();
            //thu tu cac cot: id - fn- ln - bd - gend- phn -email - adr - pic - dep - major - hometown
            updateDeleteStudentForm.textBoxID.Text = dataGridViewSt.CurrentRow.Cells[0].Value.ToString();
            updateDeleteStudentForm.textBoxFN.Text = dataGridViewSt.CurrentRow.Cells[1].Value.ToString();
            updateDeleteStudentForm.textBoxLN.Text = dataGridViewSt.CurrentRow.Cells[2].Value.ToString();
            updateDeleteStudentForm.dateTimePickerBday.Value = (DateTime)dataGridViewSt.CurrentRow.Cells[3].Value;

            if (dataGridViewSt.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
            {
                updateDeleteStudentForm.radioButtonFemale.Checked = true;
            }
            else
            {
                updateDeleteStudentForm.radioButtonMale.Checked = true;
            }

            updateDeleteStudentForm.textBoxPhone.Text = dataGridViewSt.CurrentRow.Cells[5].Value.ToString();
            updateDeleteStudentForm.textBoxEmail.Text = dataGridViewSt.CurrentRow.Cells[6].Value.ToString();
            updateDeleteStudentForm.textBoxAdrs.Text = dataGridViewSt.CurrentRow.Cells[7].Value.ToString();


            byte[] pic;
            pic = (byte[])dataGridViewSt.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteStudentForm.pictureBoxSt.Image = Image.FromStream(picture);

            updateDeleteStudentForm.comboBoxDpt.SelectedItem = dataGridViewSt.CurrentRow.Cells[9].Value.ToString();
            updateDeleteStudentForm.textBoxMajor.Text = dataGridViewSt.CurrentRow.Cells[10].Value.ToString();
            updateDeleteStudentForm.textBoxHometown.Text = dataGridViewSt.CurrentRow.Cells[11].Value.ToString();

            //this.Show();
            updateDeleteStudentForm.Show();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            FindStudentForm findStudentForm = new FindStudentForm();
            findStudentForm.ShowDialog();
        }
    }
}
