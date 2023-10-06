using StudentManagement.Account;
using StudentManagement.Lecturer_Form;
using StudentManagement.Student_Form;
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
            if (radioButtonStd.Checked == true)
            {
                if (txbEmail.Text == "")
                {
                    errorProviderLogin.SetError(txbEmail, "Blank is not valid!");
                    errorProviderLogin.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                }
                else
                {
                    errorProviderLogin.Clear();
                    if (txbPassword.Text == "")
                    {
                        errorProviderLogin.SetError(txbPassword, "Blank is not valid!");
                    }
                    else
                    {
                        errorProviderLogin.Clear();

                        if (chbRemember.Checked)
                        {
                            Properties.Settings.Default.username = txbEmail.Text;
                            Properties.Settings.Default.password = txbPassword.Text;
                            Properties.Settings.Default.Save();

                        }
                        My_DB my_DB = new My_DB();

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        DataTable table = new DataTable();
                        SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username=@User AND password=@Pass", my_DB.getConnection);

                        command.Parameters.Add("@User", SqlDbType.VarChar).Value = txbEmail.Text;
                        command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txbPassword.Text;

                        adapter.SelectCommand = command;
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            Hide();
                            MainFormStudent mainForm = new MainFormStudent(txbEmail.Text);
                            mainForm.Show();
                            

                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            else if (radioButtonHuman.Checked==true)
            {
                if (txbEmail.Text == "")
                {
                    errorProviderLogin.SetError(txbEmail, "Blank is not valid!");
                    errorProviderLogin.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                }
                else
                {
                    errorProviderLogin.Clear();
                    if (txbPassword.Text == "")
                    {
                        errorProviderLogin.SetError(txbPassword, "Blank is not valid!");
                    }
                    else
                    {
                        errorProviderLogin.Clear();

                        if (chbRemember.Checked)
                        {
                            Properties.Settings.Default.username = txbEmail.Text;
                            Properties.Settings.Default.password = txbPassword.Text;
                            Properties.Settings.Default.Save();

                        }
                        My_DB my_DB = new My_DB();

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        DataTable table = new DataTable();
                        SqlCommand command = new SqlCommand("SELECT * FROM Lecturer WHERE uname=@User AND pwd=@Pass", my_DB.getConnection);

                        command.Parameters.Add("@User", SqlDbType.VarChar).Value = txbEmail.Text;
                        command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txbPassword.Text;

                        adapter.SelectCommand = command;
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            Hide();
                            int HRID = Convert.ToInt16(table.Rows[0][0].ToString());
                            Global.SetGlobalUserId(HRID);

                            MainFormLecturer mainFormLecturer = new MainFormLecturer();
                            mainFormLecturer.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            } 
            else if (radioButtonAdmin.Checked==true)
            {
                if (txbEmail.Text == "")
                {
                    errorProviderLogin.SetError(txbEmail, "Blank is not valid!");
                    errorProviderLogin.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                }
                else
                {
                    errorProviderLogin.Clear();
                    if (txbPassword.Text == "")
                    {
                        errorProviderLogin.SetError(txbPassword, "Blank is not valid!");
                    }
                    else
                    {
                        errorProviderLogin.Clear();

                        if (chbRemember.Checked)
                        {
                            Properties.Settings.Default.username = txbEmail.Text;
                            Properties.Settings.Default.password = txbPassword.Text;
                            Properties.Settings.Default.Save();
                        }
                        My_DB my_DB = new My_DB();

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        DataTable table = new DataTable();
                        SqlCommand command = new SqlCommand("SELECT * FROM HumanResource WHERE uname=@User AND pwd=@Pass", my_DB.getConnection);

                        command.Parameters.Add("@User", SqlDbType.VarChar).Value = txbEmail.Text;
                        command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txbPassword.Text;

                        adapter.SelectCommand = command;
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            Hide();
                            int HRID = Convert.ToInt16(table.Rows[0][0].ToString());
                            Global.SetGlobalUserId(HRID);
                            Contact.ContactForm contactForm = new Contact.ContactForm();
                            contactForm.Show();
                           
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Chose User Type", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (radioButtonStd.Checked == true)
            {
                SignupForm signupForm = new SignupForm();
                signupForm.ShowDialog();
            }
            else if (radioButtonHuman.Checked == true)
            {
                AddHumanReForm AHRF = new AddHumanReForm();
                AHRF.Show();
            }
            else if (radioButtonAdmin.Checked==true)
            {
                MessageBox.Show("Not Allow To Register Admin Account", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Please Chose User Type", "Register Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            
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
