using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StudentManagement
{
    public partial class ForgotPassForm : Form
    {
        string randomCode = "";
        public static string to;
        My_DB db = new My_DB();
        User user = new User();
        public ForgotPassForm()
        {
            InitializeComponent();
        }

        private void buttonSendCode_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random random = new Random();
            randomCode = (random.Next(999999).ToString());
            MailMessage mailMessage = new MailMessage();
            to = textBoxEmail.Text.ToString();

            from = "autohoisinh01@gmail.com";
            pass = "ouhtpsgukvlsbekj";
            messageBody = "Your code is " + randomCode;
            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress(from);
            mailMessage.Body = messageBody;
            mailMessage.Subject = "Reset Your Password !";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


            SqlCommand command = new SqlCommand("SELECT * FROM Account WHERE email =@ema");
            command.Parameters.Add("@ema", SqlDbType.NChar).Value = textBoxEmail.Text;
            DataTable table = user.getUser(command);
            if (table.Rows.Count > 0)
            {
                try
                {
                    smtp.Send(mailMessage);
                    MessageBox.Show("Code send Successfully !", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Email khong ton tai!!", "Quen mat khau ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if (randomCode == textBoxVerCode.Text)
            {
                to = textBoxEmail.Text;
                ResetPassWordForm resetPassWordForm = new ResetPassWordForm();
                this.Hide();
                resetPassWordForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong Code !","Reset Password", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
