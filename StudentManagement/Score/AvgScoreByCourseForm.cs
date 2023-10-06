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
    public partial class AvgScoreByCourseForm : Form
    {
        Score score = new Score();
        public AvgScoreByCourseForm()
        {
            InitializeComponent();
        }

        private void AvgScoreByCourseForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = score.getAVGScoreByCourse();
        }
    }
}
