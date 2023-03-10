using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StudentManagement
{
    public partial class VerifyForm : Form
    {
        User user = new User();
        public static string userName;
        public static string passWord;
        public static string firstName;
        public static string lastName;
        public static string phoneNum;
        public static string eMail;
        public static string genderCheck;
        public static string random;
        public VerifyForm(string username, string password, string fname, string lname, string phone, string email, string gender, string randomCode)
        {
            InitializeComponent();
            userName = username;
            passWord = password;
            firstName = fname;
            lastName = lname;
            phoneNum = phone;
            eMail = email;
            genderCheck = gender;
            random = randomCode;
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {

            if (random == textBoxVerCode.Text)
            {
                if (user.insertUser(userName, passWord, firstName, lastName, genderCheck, phoneNum, eMail))
                {
                    MessageBox.Show("Them tai khoan thanh cong", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Loi", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Code khong dung. Vui long kiem tra lai", "Them tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
