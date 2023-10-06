using Microsoft.Office.Interop.Word;
using StudentManagement.Course;
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
using DataTable = System.Data.DataTable;

namespace StudentManagement.Result
{
    public partial class pieChart : Form
    {
        public pieChart()
        {
            InitializeComponent();
        }
        Score.Score score = new Score.Score();
        Course.Course course = new Course.Course();
        Student student = new Student();
        My_DB mydb = new My_DB();

        private void StaticsResultForm_Load(object sender, EventArgs e)
        {

            StaticByCourse_Load();
            StaticByResult_Load();

        }
        void StaticByCourse_Load()
        {
            DataTable table = new DataTable();
            table = score.getAVGScoreByCourse();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (labelCourse1.Text == table.Rows[i]["label"].ToString())
                    labelScore1.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse2.Text == table.Rows[i]["label"].ToString())
                    labelScore2.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse3.Text == table.Rows[i]["label"].ToString())
                    labelScore3.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse4.Text == table.Rows[i]["label"].ToString())
                    labelScore4.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse5.Text == table.Rows[i]["label"].ToString())
                    labelScore5.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse6.Text == table.Rows[i]["label"].ToString())
                    labelScore6.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse7.Text == table.Rows[i]["label"].ToString())
                    labelScore7.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse8.Text == table.Rows[i]["label"].ToString())
                    labelScore8.Text = table.Rows[i]["AverageGrade"].ToString();
                if (labelCourse9.Text == table.Rows[i]["label"].ToString())
                    labelScore9.Text = table.Rows[i]["AverageGrade"].ToString();
            }
        }
        void StaticByResult_Load()
        {
            DataTable table = new DataTable();
            table = score.getAllCourseScoreAndResult();
            double totalStudent = Convert.ToDouble(student.totalStudent());
            double ExcellentStudent = 0;
            double GoodStudent = 0;
            double AverageStudent = 0;
            double FailStudent = 0;
            double OutStudent = 0;

            //trích xuất bảng để lấy dữ liệu result cho từng loại học sinh
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["Result"].ToString() == "Excellent") ExcellentStudent++;
                if (table.Rows[i]["Result"].ToString() == "Good") GoodStudent++;
                if (table.Rows[i]["Result"].ToString() == "Average") AverageStudent++;
                if (table.Rows[i]["Result"].ToString() == "Fail") FailStudent++;
                if (table.Rows[i]["Result"].ToString() == "Drop Out Of University!") OutStudent++;
            }

            //Tính %
            double PExcellentStudent = Math.Round((ExcellentStudent / totalStudent) * 100, 2);
            double PGoodStudent = Math.Round((GoodStudent / totalStudent) * 100, 2);
            double PAverageStudent = Math.Round((AverageStudent / totalStudent) * 100, 2);
            double PFailStudent = Math.Round((FailStudent / totalStudent) * 100, 2);
            double POutStudent = Math.Round((OutStudent / totalStudent) * 100, 2);

            //lb_excellent.Text = (PExcellentStudent.ToString() + " %");
            //lb_Good.Text = (PGoodStudent.ToString() + " %");
            //lb_Average.Text = (PAverageStudent.ToString() + " %");
            //lb_Fail.Text = (PFailStudent.ToString() + " %");
            //lb_DropOut.Text = (POutStudent.ToString() + " %");

            labelExcellent.Text = (ExcellentStudent.ToString());
            labelGood.Text = GoodStudent.ToString() ;
            labelAverage.Text = AverageStudent.ToString() ;
            labelFail.Text = FailStudent.ToString() ;

            //Pie Chart
            chartResult.Series["Result"].Points.AddXY("Excellent", PExcellentStudent);
            chartResult.Series["Result"].Points[0].AxisLabel = (PExcellentStudent.ToString("0.00") + "%");
            chartResult.Series["Result"].Points[0].LegendText = "Excellent";

            chartResult.Series["Result"].Points.AddXY("Good", PGoodStudent);
            chartResult.Series["Result"].Points[1].AxisLabel = (PGoodStudent.ToString("0.00") + "%");
            chartResult.Series["Result"].Points[1].LegendText = "Good";

            chartResult.Series["Result"].Points.AddXY("Average", PAverageStudent);
            chartResult.Series["Result"].Points[2].AxisLabel = (PAverageStudent.ToString("0.00") + "%");
            chartResult.Series["Result"].Points[2].LegendText = "Average";

            chartResult.Series["Result"].Points.AddXY("Fail", PFailStudent);
            chartResult.Series["Result"].Points[3].AxisLabel = (PFailStudent.ToString("0.00") + "%");
            chartResult.Series["Result"].Points[3].LegendText = "Fail";


        }
      
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
