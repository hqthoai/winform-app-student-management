using StudentManagement.Contact;
using StudentManagement.Score;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Lecturer_Form
{
    public partial class MainFormLecturer : Form
    {
        public MainFormLecturer()
        {
            InitializeComponent();
        }

        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LecturerInformationForm form = new LecturerInformationForm();
            form.Show();
        }

        private void registerTeachingCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RegisterClassForm registerClassForm = new RegisterClassForm();
            registerClassForm.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreLecturerForm form = new AddScoreLecturerForm();
            form.ShowDialog();
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteScoreLecturerForm remove = new DeleteScoreLecturerForm();
            remove.ShowDialog();
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScoreForm manageScoreForm = new ManageScoreForm();
            manageScoreForm.ShowDialog();
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintScoreForm printScoreForm = new PrintScoreForm();
            printScoreForm.ShowDialog();
        }

        private void listStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListStdLecturerForm listStudentForm = new ListStdLecturerForm();
            listStudentForm.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }
    }
}
