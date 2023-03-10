using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace StudentManagement
{
    public partial class SignupForm : Form
    {
   
        User user = new User();
        My_DB my_DB = new My_DB();
        string randomCode = "";
        public static string to;

        //luu thong tin ca nhan de tiep tuc dang nhap
        public static string userName;
        public static string passWord;
        public static string firstName;
        public static string lastName;
        public static string phoneNum;
        public static string eMail;
        public static string genderCheck;



        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsn.Text;
            string pass = textBoxPass.Text;
            string fname = textBoxFN.Text;
            string lname = textBoxLN.Text;
            string phone = textBoxPhone.Text; //nen de thanh string roi xu ly 
            string email = textBoxEmail.Text;
            string gender = "Male";
            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            userName = username;
            passWord = pass;
            firstName = fname;
            lastName = lname;
            phoneNum = phone;
            eMail = email;
            genderCheck = gender;
            try
            {
                if (verif())
                {
                   

                    SqlCommand command = new SqlCommand("SELECT * FROM Account WHERE username = @user OR email =@ema");
                    command.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;
                    command.Parameters.Add("@ema", SqlDbType.NVarChar).Value = email;
                    DataTable table = user.getUser(command);
                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Username hoac email da ton tai!!", "Them tai khoan ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        
                        if (!email.Contains("@gmail.com") && !email.Contains("@email.com"))
                        {
                            MessageBox.Show("Email khong dung dinh dang", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else 
                        if (textBoxPhone.Text.Length < 10 || textBoxPhone.Text.Length >10)
                        {
                            MessageBox.Show("SDT phai du 10 so", "Them tai khoan",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        else
                        if (textBoxPass.Text != textBoxCP.Text)
                        {
                            MessageBox.Show("Mat khau khong trung khop", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           
                        }
                        else
                        {

                            this.Hide();
                            SendCode();


                            //if (user.insertUser(username, pass, fname, lname, gender, phone, email))
                            //{
                            //    MessageBox.Show("Them tai khoan thanh cong", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Loi", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}                

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui long dien day du thong tin", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xay ra loi trong qua trinh dang ky tai khoan. Vui long thu lai sau !");
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
        bool verif()
        {
            if (textBoxFN.Text.Trim() == ""
                || textBoxLN.Text.Trim() == ""
                || textBoxUsn.Text.Trim() == ""
                || textBoxPass.Text.Trim() == ""
                || textBoxCP.Text.Trim() == ""
                || textBoxPhone.Text.Trim() == ""
                || textBoxEmail.Text.Trim() == "")
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (!checkDigit(textBoxPhone.Text))
            {
                MessageBox.Show("So dien thoai khong duoc dien chu !!", "Nhap SDT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhone.Clear();
            }
            
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

        public void SendCode()
        {
            string from, passw, messageBody;
            Random random = new Random();
            randomCode = (random.Next(999999).ToString());
            MailMessage mailMessage = new MailMessage();
            to = textBoxEmail.Text.ToString();

            from = "autohoisinh01@gmail.com";
            passw = "ouhtpsgukvlsbekj";
            messageBody = "Your code is " + randomCode;
            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress(from);
            mailMessage.Body = messageBody;
            mailMessage.Subject = "Create new account for Management Student App !";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(from, passw);
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(mailMessage);
                MessageBox.Show("Code send Successfully. Please check Your Email to Verify Account !", "Them Tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VerifyForm verifyForm = new VerifyForm(userName,  passWord , firstName, lastName,   phoneNum , eMail , genderCheck, randomCode);
                verifyForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
