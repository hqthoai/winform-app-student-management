using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Account
{
    public partial class AddHumanReForm : Form
    {
        public AddHumanReForm()
        {
            InitializeComponent();
        }
        User user = new User();
        My_DB mydb = new My_DB();
        private void bt_UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*gif)|*.jpg;*.pngl*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PicBox_HRImage.Image = Image.FromFile(opf.FileName);
            }
        }
        private void bt_SignIn_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                int userID = Convert.ToInt32(txb_UserID.Text);
                string firstname = txb_Fname.Text;
                string lastname = txb_Lname.Text;
                string username = txb_UserName.Text;
                string password = txb_PassWord.Text;
                string ConfirmPass = txb_ConfirmPassword.Text;
                string Gmail = txb_gmail.Text;
                string ConfirmMail = txb_ConfirmCode.Text;
                MemoryStream pic = new MemoryStream();
                if (user.CheckHRUserName(username))
                {
                    if (user.CheckHRID(userID))
                    {
                        int id = Int32.Parse(txb_UserID.Text);
                        if (String.Compare(password, ConfirmPass) != 0)
                        {
                            MessageBox.Show("Password Not Match!", "Invalid Password Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (randomCode == (txb_ConfirmCode.Text).ToString())
                            {
                                PicBox_HRImage.Image.Save(pic, PicBox_HRImage.Image.RawFormat);
                                //PicBox_HRImage.Image.Save(pic, System.Drawing.Imaging.ImageFormat.Png);
                                if (user.insertHumanResource(id, firstname, lastname, username, password, pic, Gmail))
                                {
                                    MessageBox.Show("New Lecturer User Added!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Error", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Code!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("ID Existed!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("UserName Existed!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                || (txb_ConfirmCode.Text.Trim() == "")
                || (txb_gmail.Text.Trim() == "")
                || (PicBox_HRImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        string randomCode;
        public static string to;
        private void bt_SendConfirm_Click(object sender, EventArgs e)
        {
            if (txb_gmail.Text.Trim() != "")
            {
                Random rand = new Random();
                randomCode = (rand.Next(999999)).ToString();

                string from, pass, messageBody;
                MailMessage message = new MailMessage();
                to = (txb_gmail.Text).ToString();
                from = "khaihkttran@gmail.com";
                pass = "vrwbsjxttjtfgmey";
                messageBody = "Your confirmation code is " + randomCode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Topdev's HumanResource Confirmation Code!";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Code Send Successfully!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid Gmail!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bt_ConfirmCode_Click(object sender, EventArgs e)
        {
            if (randomCode == (txb_ConfirmCode.Text).ToString())
            {
                MessageBox.Show("Congratulation! Email has been confirmed!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid Code!", "Confirmation Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bt_Cancel_SignIn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txb_UserID_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM HumanResource WHERE id = @uid ", mydb.getConnection);

            command.Parameters.Add("@uid", SqlDbType.VarChar).Value = txb_UserID.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0 || txb_UserID.Text.Trim() == "")
            {
                lb_UserID.ForeColor = Color.Red;
                lb_UserID.Text = "ID Existed!";

            }
            else
            {
                lb_UserID.ForeColor = Color.Green;
                lb_UserID.Text = "Valid UserID";
            }
        }
        private void txb_UserName_Leave(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM HumanResource WHERE uname = @un ", mydb.getConnection);

            command.Parameters.Add("@un", SqlDbType.VarChar).Value = txb_UserName.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0 || txb_UserName.Text.Trim() == "")
            {
                lb_UserName.ForeColor = Color.Red;
                lb_UserName.Text = "Username Existed!";

            }
            else
            {
                lb_UserName.ForeColor = Color.Green;
                lb_UserName.Text = "Valid Username";
            }
        }
    }
}
