using StudentManagement.Course;
using StudentManagement.Score;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Result
{
    public partial class AvgResultForm : Form
    {
        public AvgResultForm()
        {
            InitializeComponent();
        }
        Score.Score score = new Score.Score();
        Course.Course course = new Course.Course();
        Student student = new Student();
        My_DB mydb = new My_DB();


        private void AvgResultForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = score.getAllCourseScoreAndResult();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Student ID";
            dataGridView1.Columns[1].HeaderText = "First Name";
            dataGridView1.Columns[2].HeaderText = "Last Name";
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFN.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLN.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT mssv, firstname, lastname FROM Student WHERE CONCAT(firstname, mssv) LIKE '%" + textBoxSearch.Text + "%' ", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            DataTable tableCourse = new DataTable();
            tableCourse = course.getAllCourse();

            
            for (int i = 0; i < tableCourse.Rows.Count; i++)
            {
                DataColumn CourseNamecolumn = new DataColumn();
                CourseNamecolumn.ColumnName = tableCourse.Rows[i]["label"].ToString();
                table.Columns.Add(CourseNamecolumn);
            }
            //lấy điểm của từng khóa học dựa theo id của học sinh
            DataTable tableScore = new DataTable();
            tableScore = score.getStudentScore();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int c = 0; c < tableScore.Rows.Count; c++)
                {
                    if (table.Rows[i]["mssv"].ToString() == tableScore.Rows[c]["StudentID"].ToString())
                    {
                        for (int k = 3; k < table.Columns.Count; k++)
                        {
                            if (table.Columns[k].ColumnName == tableScore.Rows[c]["label"].ToString())
                            {
                                //string coursename = table.Columns[k].ColumnName;
                                //table.Rows[i][coursename] = tableScore.Rows[c]["student_score"].ToString();
                                table.Rows[i][k] = tableScore.Rows[c]["Score"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            table.Columns.Add("AVG_Score");
            table.Columns.Add("Result");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                int count = 0;
                float sum = 0;
                for (int j = 3; j < table.Columns.Count - 2; j++)
                {
                    float temp;
                    string coursename = table.Columns[j].ColumnName;
                    if (float.TryParse(table.Rows[i][coursename].ToString(), out temp))
                    {
                        sum += temp;
                        count++;
                    }
                }

                float avg = sum / count;
                Math.Round(avg, 2);
                table.Rows[i]["AVG_Score"] = Math.Round(avg, 2);

                if (avg < 5)
                {
                    table.Rows[i]["Result"] = "Fail";
                }
                if (avg >= 5 && avg <= 6.5) table.Rows[i]["Result"] = "Average";
                if (avg > 6.5 && avg <= 7.9) table.Rows[i]["Result"] = "Goods";
                if (avg >= 8) table.Rows[i]["Result"] = "Excellent";
                if (count == 0) table.Rows[i]["Result"] = "No Score to display!";
                if (avg.ToString() == "NaN") table.Rows[i]["AVG_Score"] = 0;
            }
            dataGridView1.DataSource = table;
           
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ScoreStudentDetailForm viewScoreForm = new ScoreStudentDetailForm();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            viewScoreForm.sid = id;
            

            viewScoreForm.Show();
        }
    }
}
