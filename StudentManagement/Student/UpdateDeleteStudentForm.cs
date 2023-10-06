using StudentManagement.Course;
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
    public partial class UpdateDeleteStudentForm : Form
    {
        Student student = new Student();
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }
        My_DB mydb = new My_DB();

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image (*.jpg; *.png; *.gif) | *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSt.Image = Image.FromFile(opf.FileName);
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
                string id =textBoxID.Text;
                SqlCommand command = new SqlCommand("SELECT mssv,firstname,lastname,bday,gender,phone,email,address,picture,department,major FROM Student WHERE mssv = @id");
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
                textBoxHometown.Text = null;
                this.Close();
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
                || comboBoxDpt.Text.Trim() == ""
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
        void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id =textBoxID.Text;
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
                    }else if (student.updateStudent(id, fname, lname, bdate, gender, phone, email, address, pic, department, major, town))
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
                MessageBox.Show("So dien thoai khong duoc dien chu !!", "Update sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhone.Clear();
            }
            if (textBoxPhone.Text.Length > 10)
            {
                MessageBox.Show("So dien thoai khong duoc qua 10 chu so !!", "Update sinh vien", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhone.Clear();
            }
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

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            AddCourse addCourse = new AddCourse();
            addCourse.textBoxID.Text = textBoxID.Text;
            addCourse.Show();
        }
    }
}
