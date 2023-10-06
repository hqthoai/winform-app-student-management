using StudentManagement.Course;
using StudentManagement.Lecturer_Form;
using StudentManagement.Result;
using StudentManagement.Score;
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

        private void genderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatictisFormPieChart statictisForm = new StatictisFormPieChart();
            statictisForm.ShowDialog();
        }

        private void totalStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatictisForm statictisForm = new StatictisForm();
            statictisForm.ShowDialog();
        }

        private void ageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Course.ManageCourseForm manageCourseForm = new Course.ManageCourseForm();
            manageCourseForm.ShowDialog();
        }
        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Course.RemoveCourseForm removeCourseForm = new Course.RemoveCourseForm();
            removeCourseForm.ShowDialog();
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Course.EditCourseForm editCourseForm = new Course.EditCourseForm();
            editCourseForm.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Course.PrintCourseForm printCourseForm = new PrintCourseForm();
            printCourseForm.ShowDialog();
        }
        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Course.AddCourseForm addCourseForm = new Course.AddCourseForm();
            addCourseForm.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Score.AddScoreForm addCourseForm = new Score.AddScoreForm();
            addCourseForm.ShowDialog();
        }

        private void aVGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvgResultForm avgResultForm = new AvgResultForm();
            avgResultForm.ShowDialog();
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm manageScoreForm = new ManageScoreForm();
            manageScoreForm.ShowDialog();
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScoreForm remove = new RemoveScoreForm();
            remove.ShowDialog();
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvgScoreByCourseForm avg = new AvgScoreByCourseForm();
            avg.ShowDialog();
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintScoreForm printScoreForm = new PrintScoreForm();
            printScoreForm.ShowDialog();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pieChart staticsResultForm = new pieChart();
            staticsResultForm.ShowDialog();
        }

        private void registerTeachingCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterClassForm registerClassForm = new RegisterClassForm();
            registerClassForm.ShowDialog();
        }
    }
}
