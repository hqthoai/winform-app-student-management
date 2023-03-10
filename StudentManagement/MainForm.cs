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
    public partial class MainForm : Form
    {
        int imgNum = 1; 

        public MainForm(string username)
        {
            InitializeComponent();
            labelUsername.Text = username;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        User user = new User();

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StudentListForm studentListForm = new StudentListForm();
            studentListForm.Show(this);
        }

        private void mANAGEMENTACCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListAccountForm listAccountForm = new ListAccountForm();
            listAccountForm.Show(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string role;

            SqlCommand sqlcommand = new SqlCommand("SELECT roles FROM Account WHERE username = @user");
            sqlcommand.Parameters.Add("@user", SqlDbType.NChar).Value = labelUsername.Text;
            DataTable table = user.getUser(sqlcommand);
            if (table.Rows.Count > 0)
            {
                role = table.Rows[0][0].ToString().Trim();
                if (role == "admin")
                    mANAGEMENTACCOUNTToolStripMenuItem.Enabled = true;
                else
                {
                    mANAGEMENTACCOUNTToolStripMenuItem.Enabled = false;
                }
            }
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = string.Format(@"C:\Users\HP\Desktop\HK2_Nam_3\Window_Programming\images\img{0}.jpg", imgNum);
            imgNum++;
            
            if (imgNum == 4)
                imgNum = 1;
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatictisForm statictisForm = new StatictisForm();
            statictisForm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm manageStudentForm = new ManageStudentForm();
            manageStudentForm.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStudentForm printStudentForm = new PrintStudentForm();
            printStudentForm.ShowDialog();
        }
    }
}
