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
    public partial class ListAccountForm : Form
    {
        User user = new User();
        public ListAccountForm()
        {
            InitializeComponent();
        }

        private void ListAccountForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet1.Account' table. You can move, or remove it, as needed.
            //this.accountTableAdapter.Fill(this.qLSVDataSet1.Account);
            SqlCommand command = new SqlCommand("SELECT * FROM Account  ");
            //SqlCommand command = new SqlCommand("SELECT username as UserName, password as Password, gmail as Gmail FROM Login ");


            dataGridViewAccount.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewAccount.RowTemplate.Height = 80;
            dataGridViewAccount.DataSource = user.getUser(command);

            dataGridViewAccount.AllowUserToAddRows = false;
        }

        private void dataGridViewAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteAccountForm deleteAccountForm = new DeleteAccountForm();

            deleteAccountForm.textBoxUsername.Text = dataGridViewAccount.CurrentRow.Cells[0].Value.ToString().Trim();
            deleteAccountForm.textBoxPass.Text = dataGridViewAccount.CurrentRow.Cells[1].Value.ToString().Trim();
            deleteAccountForm.textBoxFN.Text = dataGridViewAccount.CurrentRow.Cells[2].Value.ToString().Trim();
            deleteAccountForm.textBoxLN.Text = dataGridViewAccount.CurrentRow.Cells[3].Value.ToString().Trim();
            deleteAccountForm.textBoxGender.Text = dataGridViewAccount.CurrentRow.Cells[4].Value.ToString().Trim();
            deleteAccountForm.textBoxPhone.Text = dataGridViewAccount.CurrentRow.Cells[5].Value.ToString().Trim();
            deleteAccountForm.textBoxEmail.Text = dataGridViewAccount.CurrentRow.Cells[6].Value.ToString().Trim();
            deleteAccountForm.textBoxRole.Text = dataGridViewAccount.CurrentRow.Cells[7].Value.ToString().Trim();


            deleteAccountForm.ShowDialog();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Account");


            dataGridViewAccount.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewAccount.RowTemplate.Height = 80;
            dataGridViewAccount.DataSource = user.getUser(command);

            dataGridViewAccount.AllowUserToAddRows = false;
        }
    }
}
