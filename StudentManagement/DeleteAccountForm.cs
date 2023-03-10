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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StudentManagement
{
    public partial class DeleteAccountForm : Form
    {
        User user = new User();
        My_DB db = new My_DB();
        public DeleteAccountForm()
        {
            InitializeComponent();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string message = "Ban co thuc su muon xoa khong?";
            string title = "Xoa Tai khoan";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                SqlCommand command = new SqlCommand("SELECT * FROM Account WHERE username = @user");
                command.Parameters.Add("@user", SqlDbType.NVarChar).Value = textBoxUsername.Text.Trim();
                DataTable table = user.getUser(command);
                if (table.Rows.Count > 0)
                {

                    if (user.deleteUser(textBoxUsername.Text.Trim()))
                    {
                        MessageBox.Show("Xoa thanh cong", "Xoa Tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxUsername.Text = "";
                        textBoxPass.Text = "";
                        textBoxFN.Text = "";
                        textBoxLN.Text = "";
                        textBoxGender.Text = "";
                        textBoxPhone.Text = "";
                        textBoxEmail.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Khong tim thay username", "Xoa Tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void DeleteAccountForm_Load(object sender, EventArgs e)
        {
            textBoxUsername.ReadOnly = true;
            textBoxPass.ReadOnly = true;
            textBoxFN.ReadOnly = true;
            textBoxLN.ReadOnly = true;
            textBoxGender.ReadOnly = true;
            textBoxPhone.ReadOnly = true;
            textBoxEmail.ReadOnly = true;
            textBoxRole.ReadOnly = true;

            if (textBoxUsername.Text == "admin")
            {
                buttonDelete.Enabled = false;
            }
        }
    }
}
