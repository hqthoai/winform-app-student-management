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
using System.IO;
using System.Drawing.Printing;
using iTextSharp.text.pdf;
using iTextSharp.text;

using System.Drawing.Imaging;
using Image = System.Drawing.Image;
using Excel = Microsoft.Office.Interop.Excel;
using Document = iTextSharp.text.Document;
using Microsoft.Office.Interop.Word;
using System.Windows.Controls;

using DataTable = System.Data.DataTable;
using PrintDialog = System.Windows.Forms.PrintDialog;
using System.Windows.Documents;
using Table = Microsoft.Office.Interop.Word.Table;
using System.Reflection;
using Xceed.Document.NET;
using ExcelDataReader;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace StudentManagement
{
    public partial class PrintStudentForm : Form
    {
        Student student = new Student();
        My_DB db = new My_DB();
        public PrintStudentForm()
        {
            InitializeComponent();
        }

        private void PrintStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVStudent.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.qLSVStudent.Student);
            // TODO: This line of code loads data into the 'qLSVnew.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.qLSVnew.Student);
            // TODO: This line of code loads data into the 'qLSVDataSet.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.Fill(this.qLSVDataSet.Student);
            fillGrid(new SqlCommand("SELECT * FROM Student"));

            radioButtonAll.Checked = true;
            radioButtonNo.Checked = true;

        }


        public void fillGrid(SqlCommand command)
        {
            dataGridViewPrint.ReadOnly = true;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewPrint.RowTemplate.Height = 60;
            dataGridViewPrint.DataSource = student.getStudent(command);
            picCol = (DataGridViewImageColumn)dataGridViewPrint.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewPrint.AllowUserToAddRows = false;
        }

        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerBdayFrom.Enabled = true;
            dateTimePickerBdayTo.Enabled = true;
        }

        private void radioButtonNo_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerBdayFrom.Enabled = false;
            dateTimePickerBdayTo.Enabled = false;
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM Student";
            if (radioButtonNo.Checked == true)
            {
                if (radioButtonMale.Checked == true)
                    strSQL += " WHERE gender = 'Male'";
                else if (radioButtonFemale.Checked == true)
                    strSQL += " WHERE gender = 'Female'";
            }
            else
            if (radioButtonYes.Checked == true)
            {
                DateTime start = dateTimePickerBdayFrom.Value;
                DateTime end = dateTimePickerBdayTo.Value;
                if (radioButtonAll.Checked == true)
                    strSQL += " WHERE bday BETWEEN '" + start.ToString() + "' AND '" + end.ToString() + "'";
                if (radioButtonMale.Checked == true)
                    strSQL += " WHERE gender = 'Male' AND bday BETWEEN '" + start.ToString() + "' AND '" +
                   end.ToString() + "'";
                if (radioButtonFemale.Checked == true)
                    strSQL += " WHERE gender = 'Female' AND bday BETWEEN '" + start.ToString() + "' AND '" +
                   end.ToString() + "'";
            }


            dataGridViewPrint.RowTemplate.Height = 80;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            try
            {
                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(strSQL, db.getConnection);
                DataSet ds = new DataSet("Student");
                adapter.Fill(ds, "Student");
                DataTable table = ds.Tables["Student"];
                dataGridViewPrint.DataSource = table;
                picCol = (DataGridViewImageColumn)dataGridViewPrint.Columns[8];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridViewPrint.AllowUserToAddRows = false;
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Loi roi ne!");
                db.closeConnection();
            }

        }

        public void Export_Data_To_Word(DataGridView DGV)
        {
            if (DGV.Rows.Count != 0)
            {
                int rowCount = DGV.Rows.Count;
                int colCount = DGV.Columns.Count;
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document oDoc = word.Documents.Add();

                // Thêm bảng vào tài liệu
                Microsoft.Office.Interop.Word.Table tbl = oDoc.Tables.Add(oDoc.Range(), rowCount + 1, colCount);

                // Đặt tiêu đề cho các cột của bảng
                for (int col = 0; col < colCount; col++)
                {
                    tbl.Cell(1, col + 1).Range.Text = DGV.Columns[col].HeaderText;
                }

                // Thêm dữ liệu từ DataGridView vào bảng
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        if (DGV.Rows[row].Cells[col].ValueType == typeof(byte[]))
                        {
                            // Nếu kiểu dữ liệu của ô là byte[], chứa ảnh
                            byte[] imageData = (byte[])DGV.Rows[row].Cells[col].Value;
                            if (imageData != null && imageData.Length > 0)
                            {
                                // Tạo ảnh từ dữ liệu byte[]
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageData);
                                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                                // Thêm ảnh vào tài liệu
                                Clipboard.SetImage(img);
                                tbl.Cell(row + 2, col + 1).Range.Paste();
                            }
                        }
                        else
                            tbl.Cell(row + 2, col + 1).Range.Text = DGV.Rows[row].Cells[col].Value.ToString();

                    }
                }

                // Lưu tài liệu

                object filename = @"C:\Users\HP\Desktop\HK2_Nam_3\Window_Programming\export\StudentExport.docx";
                oDoc.SaveAs2(ref filename);
                word.Quit();
            }
        }
    

        

        //public void Export_Data_To_Word(DataGridView DGV, string filename)
        //{
        //    if (dataGridViewPrint.Rows.Count != 0)
        //    {
        //        int RowCount = dataGridViewPrint.Rows.Count;
        //        int ColumnCount = dataGridViewPrint.Columns.Count;
        //        Microsoft.Office.Interop.Word.Document oDoc = new Microsoft.Office.Interop.Word.Document();
        //        oDoc.Application.Visible = true;
        //        oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;



        //        //dynamic oRange = oDoc.Content.Application.Selection.Range;
        //        string oTemp = "";
        //        Object oMissing = System.Reflection.Missing.Value;


        //        for (int r = 0; r <= RowCount - 1; r++)
        //        {
        //            oTemp = "";
        //            for (int c = 0; c <= ColumnCount - 1; c++)
        //            {
        //                oTemp = oTemp + dataGridViewPrint.Rows[r].Cells[c].Value + "\t";
        //            }
        //            var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
        //            oPara1.Range.Text = oTemp;
        //            oPara1.Range.InsertParagraphAfter();
        //            byte[] imgbyte = (byte[])dataGridViewPrint.Rows[r].Cells[8].Value;
        //            MemoryStream ms = new MemoryStream(imgbyte);
        //            System.Drawing.Image sparePicture = System.Drawing.Image.FromStream(ms);
        //            System.Drawing.Image finalPic = (System.Drawing.Image)(new Bitmap(sparePicture, new Size(90, 90)));
        //            Clipboard.SetDataObject(finalPic);
        //            var oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
        //            oPara2.Range.Paste();
        //            oPara2.Range.InsertParagraphAfter();
        //            oTemp += "\n";
        //        }
        //        //save the file
        //        oDoc.SaveAs2(filename);
        //    }

        //}
        private void buttonSaveToText_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrint.Rows.Count > 0)
            {
                try
                {
                    Export_Data_To_Word(dataGridViewPrint);
                }
                catch 
                {
                    MessageBox.Show("Loi roi!!", "Error");
                }

                MessageBox.Show("Export Successfully !!!", "Info");
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void buttonToPrint_Click(object sender, EventArgs e)
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

        private void buttonSavePDF_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrint.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
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
                            PdfPTable pdfTable = new PdfPTable(dataGridViewPrint.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn column in dataGridViewPrint.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);

                            }
                            foreach (DataGridViewRow row in dataGridViewPrint.Rows)
                            {
                                string id = row.Cells[0].Value.ToString();
                                pdfTable.AddCell(id);
                                string Fname = row.Cells[1].Value.ToString();
                                pdfTable.AddCell(Fname);
                                string Lname = row.Cells[2].Value.ToString();
                                pdfTable.AddCell(Lname);
                                string Bdate = row.Cells[3].Value.ToString();
                                pdfTable.AddCell(Bdate);
                                string gender = row.Cells[4].Value.ToString();
                                pdfTable.AddCell(gender);
                                string phone = row.Cells[5].Value.ToString();
                                pdfTable.AddCell(phone);
                                string email = row.Cells[6].Value.ToString();
                                pdfTable.AddCell(email);
                                string address = row.Cells[7].Value.ToString();
                                pdfTable.AddCell(address);

                                byte[] imageByte = (byte[])row.Cells[8].Value;
                                iTextSharp.text.Image Image = iTextSharp.text.Image.GetInstance(imageByte);
                                pdfTable.AddCell(Image);

                                string department = row.Cells[9].Value.ToString();
                                pdfTable.AddCell(department);
                                string major = row.Cells[10].Value.ToString();
                                pdfTable.AddCell(major);
                                string hometown = row.Cells[11].Value.ToString();
                                pdfTable.AddCell(hometown);
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
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

        private DataTable ReadExcelFile(string fileName) // tham khao tren chat gpt
        {
            // Sử dụng thư viện ExcelDataReader để đọc dữ liệu từ tệp Excel
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Đọc dữ liệu vào DataTable
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    return result.Tables[0];
                }
            }
        }
        private void buttonImport_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại chọn tệp Excel
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            //openFileDialog.Title = "Select an Excel File";

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{


            //}
            MessageBox.Show("Loi nhieu qua, it will complete soon!");

        } 
    }

}
