using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Account
{
    public partial class EditHRForm : Form
    {
        public EditHRForm()
        {
            InitializeComponent();
        }
        User HRuser = new User();
        private void EditHRForm_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = HRuser.GetHR(Global.GlobalUserID1);
            txb_UserID.Text = table.Rows[0]["ID"].ToString();
            txb_Fname.Text = table.Rows[0]["f_name"].ToString();
            txb_Lname.Text = table.Rows[0]["l_name"].ToString();
            txb_UserName.Text = table.Rows[0]["uname"].ToString();
            txb_PassWord.Text = table.Rows[0]["pwd"].ToString();
            txb_ConfirmPassword.Text = table.Rows[0]["pwd"].ToString();

            byte[] pic = (byte[])table.Rows[0]["fig"];
            MemoryStream ms = new MemoryStream(pic);
            pictureBoxHRImage.Image = Image.FromStream(ms);
        }
        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                int userID = Convert.ToInt32(txb_UserID.Text);
                string firstname = txb_Fname.Text;
                string lastname = txb_Lname.Text;
                string username = txb_UserName.Text;
                string password = txb_PassWord.Text;
                string ConfirmPass = txb_ConfirmPassword.Text;
                MemoryStream pic = new MemoryStream();
                if (HRuser.CheckHRUserNameForEdit(username))
                {
                    int id = Int32.Parse(txb_UserID.Text);
                    if (String.Compare(password, ConfirmPass) != 0)
                    {
                        MessageBox.Show("Password Not Match!", "Invalid Password Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        pictureBoxHRImage.Image.Save(pic, pictureBoxHRImage.Image.RawFormat);
                        if (HRuser.updateHumanResource(id, firstname, lastname, username, password, pic))
                        {
                            MessageBox.Show("Human Resource User Edited!", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("UserName Existed!", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void bt_UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*gif)|*.jpg;*.pngl*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxHRImage.Image = Image.FromFile(opf.FileName);
            }
        }
        bool verif()
        {
            if ((txb_Fname.Text.Trim() == "")
                || (txb_Lname.Text.Trim() == "")
                || (txb_UserID.Text.Trim() == "")
                || (txb_UserName.Text.Trim() == "")
                || (txb_PassWord.Text.Trim() == "")
                || (txb_ConfirmPassword.Text.Trim() == "")
                || (pictureBoxHRImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
