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

namespace StudentManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            if (Properties.Settings.Default.username != string.Empty)
            {
                txbEmail.Text = Properties.Settings.Default.username;
                txbPassword.Text = Properties.Settings.Default.password;
            }
            registerEvent();
        }
        void registerEvent()
        {
            lbExit.Click += LbExit_Click;
        }
        private void LbExit_Click( object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (chbRemember.Checked)
            {
                Properties.Settings.Default.username = txbEmail.Text;
                Properties.Settings.Default.password = txbPassword.Text;
                Properties.Settings.Default.Save();
                
            }
            My_DB my_DB = new My_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Account WHERE username=@User AND password=@Pass", my_DB.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = txbEmail.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txbPassword.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignupForm signupForm = new SignupForm();   
            signupForm.ShowDialog();
        }

        private void linkLabelForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassForm forgot = new ForgotPassForm ();
            forgot.ShowDialog();
        }


     

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            if (pictureBoxShow.Visible)
            {
                txbPassword.PasswordChar = '\0';
                pictureBoxHide.Visible = true;
                pictureBoxShow.Visible = false;
            }
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            if (pictureBoxHide.Visible)
            {
                txbPassword.PasswordChar = '*';

                pictureBoxShow.Visible = true;
                pictureBoxHide.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }
    }
}
