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
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }
        bool verif()
        {
            if ((textBoxID.Text.Trim()==""
                ||textBoxFN.Text.Trim() == "") 
                || (textBoxLN.Text.Trim() == "")
                || textBoxAdrs.Text.Trim() == ""
                || textBoxPhone.Text.Trim() == ""
                || textBoxEmail.Text.Trim() == ""
                || textBoxMajor.Text.Trim() == ""
                || comboBoxDpt.SelectedIndex == -1
                || pictureBoxSt.Image == null
                || textBoxHometown.Text.Trim()=="")
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
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
                        SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Student WHERE mssv = @id" );
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
                        } }
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
        bool checkDigit(string s) // neu co chu return false
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > '9' || s[i] < '0')
                    return false;
            }
            return true;
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (!checkDigit(textBoxPhone.Text))
            {
                MessageBox.Show("So dien thoai khong duoc dien chu !!", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhone.Clear();
            }
            if (textBoxPhone.Text.Length > 10)
            {
                MessageBox.Show("So dien thoai khong duoc qua 10 chu so !!", "Them sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhone.Clear();
            }
        }
        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBoxDpt_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void textBoxFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Chi duoc nhap chu!!", "Nhap ten", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void textBoxLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Chi duoc nhap chu!!", "Nhap ten", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void textBoxMajor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Chi duoc nhap chu!!", "Nhap ten", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
