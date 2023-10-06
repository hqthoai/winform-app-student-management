using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Score
{
    public partial class RemoveScoreForm : Form
    {
        public RemoveScoreForm()
        {
            InitializeComponent();
        }

        Score score = new Score();
        Student student = new Student();

        private void RemoveScoreForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = score.getStudentScore();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int student_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int course_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if ((MessageBox.Show("Are you sure you want to delete this score", "Remove score", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                if (score.deleteScore(student_id, course_id))
                {
                    MessageBox.Show("Score Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = score.getStudentScore();
                }
                else
                {
                    MessageBox.Show("Score Not Deleted", "Remove Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
