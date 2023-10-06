using LiveCharts;
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
    public partial class StatictisFormPieChart : Form
    {
        Student student = new Student();
        My_DB db = new My_DB();
        public StatictisFormPieChart()
        {
            InitializeComponent();
        }

        private void StatictisFormPieChart_Load(object sender, EventArgs e)
        {
            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());

            double maleStudentPercent = totalMale * (100 / total);
            double femaleStudentPercent = totalFemale * (100 / total);


            chartGender.Series["Gender"].IsValueShownAsLabel = true;
            chartGender.Series["Gender"].Points.AddXY("Male",maleStudentPercent);
            chartGender.Series["Gender"].Points.AddXY("Female",femaleStudentPercent);

        }


    }
}
