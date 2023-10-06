using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagement
{
    public partial class ResetPassWordForm : Form
    {
        string uEmail = ForgotPassForm.to;
        My_DB db = new My_DB();

        public ResetPassWordForm()
        {
            InitializeComponent();
        }

        private void buttonResetPass_Click(object sender, EventArgs e)
        {
            if (textBoxNewPass.Text == textBoxVerNewPass.Text)
            {
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Account] SET [password] = "
                    + textBoxVerNewPass.Text+" WHERE email=@ema", db.getConnection);
                command.Parameters.AddWithValue("@ema", SqlDbType.NChar).Value = uEmail;
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    db.closeConnection();
                else
                    db.closeConnection();
                MessageBox.Show("Reset Password Successfully !", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("The password does not match !", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
