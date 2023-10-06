using Microsoft.Office.Interop.Word;
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

namespace StudentManagement.Student_Form
{
    public partial class ViewScoreForm : Form
    {
        public ViewScoreForm()
        {
            InitializeComponent();
        }
        Student student = new Student();
        private void ViewScoreForm_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT Course.label as CourseName, round(Score.student_score,3) as Score FROM Student INNER JOIN Score"+
               " on Student.mssv = Score.student_id INNER JOIN Course on Score.course_id = Course.id where mssv = @id order by Course.label");
            sqlCommand.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = labelID.Text;
            System.Data.DataTable table = student.getStudent(sqlCommand);
            dataGridView1.DataSource = table;
        }

        public void loadScore()
        {

        }
        public void ExportToWord(DataGridView DGV, string backgroundImageFilePath)
        {

            if (DGV.Rows.Count != 0)
            {
                int rowCount = DGV.Rows.Count;
                int colCount = DGV.Columns.Count;
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

                //Microsoft.Office.Interop.Word.Document oDoc = word.Documents.Add();


                _Document oDoc = word.Documents.Add();
                int ColumnCount = DGV.Columns.Count;
                object missing = System.Reflection.Missing.Value;
                Paragraph para1 = oDoc.Content.Paragraphs.Add(ref missing);
                string time = DateTime.Today.Day.ToString("00") + "/" + DateTime.Today.Month.ToString("00") + "/"
               + DateTime.Today.Year.ToString("0000");

                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para1.Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;   // Màu
                    para1.Range.Font.Bold = 2;        // Độ Đậm Chữ
                    para1.Range.Font.Size = 14;
                    para1.Range.Text = "Trường Đại Học Sư Phạm Kỹ Thuật Tp Hồ Chí Minh\t\t" + time
                    + "\n\t\tPhòng Đào Tạo"
                        + "\n\n \t\t\t\t\tBảng Điểm Sinh Viên\n";

                   


                    para1.Range.Text = "MSSV: " + labelID.Text;
                    para1.Range.Font.Size = 12;
                    para1.Range.Bold = 0;
                    para1.Range.Underline = 0;
                    para1.Range.Font.Name = "Times New Roman";
                    para1.Range.InsertParagraphAfter();



                    Microsoft.Office.Interop.Word.Range footersRange = section.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    para1.Range.Fields.Add(footersRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    para1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para1.Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;   // Màu
                    para1.Range.Font.Bold = 2;        // Độ Đậm Chữ
                    para1.Range.Font.Size = 14;
                    para1.Range.Text = "TP.HCM, " + time;


                    section.Borders.Enable = 1;
                    section.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                    section.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth300pt;
                    section.Borders.OutsideColor = WdColor.wdColorBlack;

                }
                Table tableST = oDoc.Tables.Add(para1.Range, DGV.Rows.Count + 1, DGV.Columns.Count, ref missing, ref missing);


                tableST.Borders.Enable = 1;

                for (int c = 0; c < colCount; c++)
                {
                    tableST.Rows[1].Cells[c + 1].Range.Text = DGV.Columns[c].HeaderText;
                    tableST.Rows[1].Cells[c + 1].Range.Font.Name = "Times New Roman";
                    tableST.Rows[1].Cells[c + 1].Range.Font.Bold = 1;
                }

                for (int i = 2; i < tableST.Rows.Count; i++)
                {
                    for (int j = 1; j < tableST.Columns.Count + 1; j++)
                    {

                        {
                            //Lưu text
                            tableST.Rows[i].Cells[j].Range.Text = DGV.Rows[i - 2].Cells[j - 1].Value.ToString();
                        }
                        tableST.Rows[i].Cells[j].Range.Font.Bold = 0;
                        tableST.Rows[i].Cells[j].Range.Font.Size = 12;
                        tableST.Rows[i].Cells[j].Range.Font.Name = "Times New Roman";
                    }
                }

                object filename = @"C:\Users\HP\Desktop\HK2_Nam_3\Window_Programming\export\StudentScoreExport.docx";
                oDoc.SaveAs2(ref filename);
                word.Quit();

            }
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string backgroundImageFilePath = @"C:\Users\HP\Desktop\HK2_Nam_3\Window_Programming\images\img1.jpg";
            if (dataGridView1.Rows.Count > 0)
            {
                ExportToWord(dataGridView1, backgroundImageFilePath);
                MessageBox.Show("Export Successfully !!!", "Info");
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }

        }
    }
}
