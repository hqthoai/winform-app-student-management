using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Microsoft.Office.Interop.Word;
using Paragraph = Microsoft.Office.Interop.Word.Paragraph;
using Document = iTextSharp.text.Document;
using System.Windows.Input;

namespace StudentManagement.Course
{
    public partial class CourseStudentList : Form
    {
        public CourseStudentList()
        {
            InitializeComponent();
        }
        Student student = new Student();
        public int ContactID;
        string lecturerName ="";
        Contact.Contact contact = new Contact.Contact();

        private void CourseStudentList_Load(object sender, EventArgs e)
        {
            string course = textBoxCourseName.Text;
            SqlCommand command = new SqlCommand("SELECT mssv as MSSV, firstname as FirstName, lastname as LastName,bday as Birthday,gender as Gender, " +
                "department as Department, major as Major FROM Student WHERE selectedCourse LIKE N'%" + @course+ "%'" );
            dataGridView1.DataSource = student.getStudentByCourse(command);

            DataTable dt = contact.GetContactByID(ContactID);
            if (dt.Rows.Count > 0)
            {
                lecturerName += dt.Rows[0]["fname"].ToString() + " ";
                lecturerName += dt.Rows[0]["lname"].ToString();
            }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print List Student Course Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf"; bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                string id = row.Cells[0].Value.ToString();
                                pdfTable.AddCell(id);
                                string Label = row.Cells[1].Value.ToString();
                                pdfTable.AddCell(Label);
                                string Period = row.Cells[2].Value.ToString();
                                pdfTable.AddCell(Period);
                                string Description = row.Cells[3].Value.ToString();
                                pdfTable.AddCell(Description);
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream); pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
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
                        + "\n\n \t\t\t\t\tDanh Sách Sinh Viên\n";

                    para1.Range.Text = "Tên môn học: " + textBoxCourseName.Text;
                    para1.Range.Font.Size = 12;
                    para1.Range.Bold = 0;
                    para1.Range.Underline = 0;
                    para1.Range.Font.Name = "Times New Roman";
                    para1.Range.InsertParagraphAfter();

                    para1.Range.Text = "Giáo viên bộ môn: " + lecturerName ;
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
                        if (DGV.Columns[j-1].HeaderText == "Birthday")
                        {
                            tableST.Rows[i].Cells[j].Range.Text = Convert.ToDateTime(DGV.Rows[i - 2].Cells[j - 1].Value).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            //Lưu text
                            tableST.Rows[i].Cells[j].Range.Text = DGV.Rows[i - 2].Cells[j - 1].Value.ToString();
                        }
                        tableST.Rows[i].Cells[j].Range.Font.Bold = 0;
                        tableST.Rows[i].Cells[j].Range.Font.Size = 12;
                        tableST.Rows[i].Cells[j].Range.Font.Name = "Times New Roman";
                    }
                }

                //// Thêm bảng vào tài liệu
                //Microsoft.Office.Interop.Word.Table tbl = oDoc.Tables.Add(oDoc.Range(), rowCount + 1, colCount);

                //// Đặt tiêu đề cho các cột của bảng
                //for (int col = 0; col < colCount; col++)
                //{
                //    tbl.Cell(1, col + 1).Range.Text = DGV.Columns[col].HeaderText;
                //}

                //// Thêm dữ liệu từ DataGridView vào bảng
                //for (int row = 0; row < rowCount - 1; row++)
                //{
                //    for (int col = 0; col < colCount; col++)
                //    {

                //        tbl.Cell(row + 2, col + 1).Range.Text = DGV.Rows[row].Cells[col].Value.ToString();

                //    }
                //}

                // Lưu tài liệu

                object filename = @"C:\Users\HP\Desktop\HK2_Nam_3\Window_Programming\export\ListStudentCourseExport.docx";
                oDoc.SaveAs2(ref filename);
                word.Quit();

            }
        }
        private void buttonWord_Click(object sender, EventArgs e)
        {
            string backgroundImageFilePath = @"C:\Users\HP\Desktop\HK2_Nam_3\Window_Programming\images\img1.jpg";
            if (dataGridView1.Rows.Count > 0)
            {
                ExportToWord(dataGridView1,backgroundImageFilePath);
                MessageBox.Show("Export Successfully !!!", "Info");
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}
