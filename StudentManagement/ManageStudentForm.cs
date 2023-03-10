using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class ManageStudentForm : Form
    {
        Student student = new Student();
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.Fill(this.qLSVDataSet.Student);

            fillGrid(new SqlCommand("SELECT * FROM Student"));

        }

        public void fillGrid (SqlCommand command)
        {
            dataGridViewManagement.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewManagement.RowTemplate.Height = 60;
            dataGridViewManagement.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridViewManagement.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewManagement.AllowUserToAddRows = false;

            labelTotal.Text = ("Total Students: " + dataGridViewManagement.Rows.Count);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE CONCAT(firstname,lastname,address) LIKE '%"+textBoxSearch.Text+"%'");
            fillGrid(command);
        }

        private void dataGridViewManagement_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteStudentForm = new UpdateDeleteStudentForm();
            //thu tu cac cot: id - fn- ln - bd - gend- phn -email - adr - pic - dep - major - hometown
            updateDeleteStudentForm.textBoxID.Text = dataGridViewManagement.CurrentRow.Cells[0].Value.ToString();
            updateDeleteStudentForm.textBoxFN.Text = dataGridViewManagement.CurrentRow.Cells[1].Value.ToString();
            updateDeleteStudentForm.textBoxLN.Text = dataGridViewManagement.CurrentRow.Cells[2].Value.ToString();
            updateDeleteStudentForm.dateTimePickerBday.Value = (DateTime)dataGridViewManagement.CurrentRow.Cells[3].Value;

            if (dataGridViewManagement.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
            {
                updateDeleteStudentForm.radioButtonFemale.Checked = true;
            }
            else
            {
                updateDeleteStudentForm.radioButtonMale.Checked = true;
            }

            updateDeleteStudentForm.textBoxPhone.Text = dataGridViewManagement.CurrentRow.Cells[5].Value.ToString();
            updateDeleteStudentForm.textBoxEmail.Text = dataGridViewManagement.CurrentRow.Cells[6].Value.ToString();
            updateDeleteStudentForm.textBoxAdrs.Text = dataGridViewManagement.CurrentRow.Cells[7].Value.ToString();


            byte[] pic;
            pic = (byte[])dataGridViewManagement.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteStudentForm.pictureBoxSt.Image = Image.FromStream(picture);

            updateDeleteStudentForm.comboBoxDpt.SelectedItem = dataGridViewManagement.CurrentRow.Cells[9].Value.ToString();
            updateDeleteStudentForm.textBoxMajor.Text = dataGridViewManagement.CurrentRow.Cells[10].Value.ToString();
            updateDeleteStudentForm.textBoxHometown.Text = dataGridViewManagement.CurrentRow.Cells[11].Value.ToString();

            //this.Show();
            updateDeleteStudentForm.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            try
            {
                string id = textBoxID.Text;
                string fname = textBoxFN.Text;
                string lname = textBoxLN.Text;
                DateTime bdate = dateTimePickerBday.Value;
                int phone = Convert.ToInt32(textBoxPhone.Text);
                string email = textBoxEmail.Text;
                string address = textBoxAdrs.Text;
                string gender = "Male";

                if (radioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                if (comboBoxDpt.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui long chon Khoa cua sinh vien", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxDpt.SelectedIndex = 0;
                }
                string department = comboBoxDpt.SelectedItem.ToString();
                string major = textBoxMajor.Text;
                string town = textBoxHometown.Text;
                MemoryStream pic = new MemoryStream();

                int born_year = dateTimePickerBday.Value.Year;
                int this_year = DateTime.Now.Year;

                if ((this_year - born_year) < 17 || ((this_year - born_year) > 100))
                {

                    MessageBox.Show("Tuoi cua sinh vien phai tu 18 tuoi tro len", "Ngay sinh khong hop le", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Student WHERE email = @ema");
                    sqlCommand.Parameters.AddWithValue("@ema", SqlDbType.NVarChar).Value = email;
                    DataTable emailtb = student.getStudent(sqlCommand);
                    if (emailtb.Rows.Count > 0)
                    {
                        MessageBox.Show("Email da ton tai!!", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        pictureBoxSt.Image.Save(pic, pictureBoxSt.Image.RawFormat);
                        SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Student WHERE id =@id");
                        sqlcommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;

                        DataTable table = student.getStudent(sqlcommand);
                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("ID da ton tai!!", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (!email.Contains("@gmail.com") && !email.Contains("@email.com"))
                        {
                            MessageBox.Show("Email khong dung dinh dang", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (student.insertStudent(id, fname, lname, bdate, gender, phone, email, address, pic, department, major, town))
                        {
                            MessageBox.Show("Them sinh vien thanh cong", "Them Sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Loi", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui long dien day du cac thong tin", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui long dien day du thong tin !!", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }




        bool verif()
        {
            if ((textBoxID.Text.Trim() == ""
                || textBoxFN.Text.Trim() == "")
                || (textBoxLN.Text.Trim() == "")
                || textBoxAdrs.Text.Trim() == ""
                || textBoxPhone.Text.Trim() == ""
                || textBoxEmail.Text.Trim() == ""
                || textBoxMajor.Text.Trim() == ""
                || comboBoxDpt.SelectedIndex == -1
                || pictureBoxSt.Image == null
                || textBoxHometown.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif) | *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSt.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {

            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = "student_" + textBoxID.Text;
            if (pictureBoxSt.Image == null)
            {
                MessageBox.Show("No Image In the PictureBox");
            }
            else if (svf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSt.Image.Save((svf.FileName + "." + ImageFormat.Jpeg.ToString()));
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBoxID.Text;
                string fname = textBoxFN.Text;
                string lname = textBoxLN.Text;
                DateTime bdate = dateTimePickerBday.Value;
                int phone = Convert.ToInt32(textBoxPhone.Text);
                string email = textBoxEmail.Text;
                string address = textBoxAdrs.Text;
                string gender = "Male";

                if (radioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                string department = comboBoxDpt.SelectedItem.ToString();
                string major = textBoxMajor.Text;
                string town = textBoxHometown.Text;
                MemoryStream pic = new MemoryStream();

                int born_year = dateTimePickerBday.Value.Year;
                int this_year = DateTime.Now.Year;

                if ((this_year - born_year) < 17 || ((this_year - born_year) > 100))
                {

                    MessageBox.Show("Tuoi cua sinh vien phai tu 18 tuoi tro len", "Ngay sinh khong hop le", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    pictureBoxSt.Image.Save(pic, pictureBoxSt.Image.RawFormat);
                    if (!email.Contains("@gmail.com") && !email.Contains("@email.com"))
                    {
                        MessageBox.Show("Email khong dung dinh dang", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (student.updateStudent(id, fname, lname, bdate, gender, phone, email, address, pic, department, major, town))
                    {
                        MessageBox.Show("Update vien thanh cong", "Update Sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Loi", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui long dien day du cac thong tin", "Update sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui long dien day du thong tin!!", "Update sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string message = "Ban co thuc su muon xoa khong?";
            string title = "Xoa Sinh vien";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string id = textBoxID.Text;
                SqlCommand command = new SqlCommand("SELECT id,firstname,lastname,bday,gender,phone,email,address,picture,department,major FROM Student WHERE id = @id");
                command.Parameters.AddWithValue("id", id);
                DataTable table = student.getStudent(command);
                if (table.Rows.Count > 0)
                {
                    if (student.deleteStudent(id))
                    {
                        MessageBox.Show("Xoa thanh cong", "Xoa Sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Khong tim thay ID", "Xoa Sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                textBoxID.Text = null;
                textBoxFN.Text = null;
                textBoxLN.Text = null;
                radioButtonFemale.Checked = false;
                radioButtonMale.Checked = false;
                textBoxPhone.Text = null;
                textBoxEmail.Text = null;
                textBoxAdrs.Text = null;
                pictureBoxSt.Image = null;
                comboBoxDpt.SelectedIndex = -1;
                textBoxMajor.Text = null;
                
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {

            textBoxID.ReadOnly = false;
            textBoxID.Text = null;
            textBoxFN.Text = null;
            textBoxLN.Text = null;
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            textBoxPhone.Text = null;
            textBoxEmail.Text = null;
            textBoxAdrs.Text = null;
            pictureBoxSt.Image = null;
            textBoxHometown.Text = null;
            comboBoxDpt.SelectedIndex = -1;
            textBoxMajor.Text = null;
        }

        private void dataGridViewManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.ReadOnly = true;
            textBoxID.Text = dataGridViewManagement.CurrentRow.Cells[0].Value.ToString();
            textBoxFN.Text = dataGridViewManagement.CurrentRow.Cells[1].Value.ToString();
            textBoxLN.Text = dataGridViewManagement.CurrentRow.Cells[2].Value.ToString();
            dateTimePickerBday.Value = (DateTime)dataGridViewManagement.CurrentRow.Cells[3].Value;

            if (dataGridViewManagement.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
            {
                radioButtonFemale.Checked = true;
            }
            else
            {
                radioButtonMale.Checked = true;
            }

            textBoxPhone.Text = dataGridViewManagement.CurrentRow.Cells[5].Value.ToString();
            textBoxEmail.Text = dataGridViewManagement.CurrentRow.Cells[6].Value.ToString();
            textBoxAdrs.Text = dataGridViewManagement.CurrentRow.Cells[7].Value.ToString();


            byte[] pic;
            pic = (byte[])dataGridViewManagement.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            pictureBoxSt.Image = Image.FromStream(picture);

            comboBoxDpt.SelectedItem = dataGridViewManagement.CurrentRow.Cells[9].Value.ToString();
            textBoxMajor.Text = dataGridViewManagement.CurrentRow.Cells[10].Value.ToString();
            textBoxHometown.Text = dataGridViewManagement.CurrentRow.Cells[11].Value.ToString();
        }
    }
}
