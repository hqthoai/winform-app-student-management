using iTextSharp.text.pdf;
using iTextSharp.text;
using StudentManagement.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace StudentManagement.Score
{
    public partial class PrintScoreForm : Form
    {
        public PrintScoreForm()
        {
            InitializeComponent();
        }
        Score score = new Score();

        private void PrintScoreForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet.Score' table. You can move, or remove it, as needed.
            
            
            dataGridView1.DataSource = score.getStudentScore();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void buttonToFile_Click(object sender, EventArgs e)
        {

            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ScoreList.txt";

            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (j == dataGridView1.Columns.Count - 2)
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                    }
                    writer.WriteLine("");
                    writer.WriteLine("--------------------------------------------------------------------------------------------------");

                }
            }
            MessageBox.Show("File saved", "Save to File", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void ExportToWord(DataGridView DGV)
        {
            // Khởi tạo ứng dụng Word
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            // Tạo một tài liệu mới
            Microsoft.Office.Interop.Word.Document document = word.Documents.Add();

            int numRows = dataGridView1.Rows.Count;
            int numColumns = dataGridView1.Columns.Count;
            Microsoft.Office.Interop.Word.Table table = document.Tables.Add(document.Range(), numRows + 1, numColumns);

            // Đặt tiêu đề cho các cột của bảng
            for (int col = 0; col < numColumns; col++)
            {
                table.Cell(1, col + 1).Range.Text = DGV.Columns[col].HeaderText;
            }
            // Điền dữ liệu vào bảng từ DataGridView
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    table.Cell(i + 2, j + 1).Range.Text = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Lưu tài liệu và đóng ứng dụng Word
            object fileName = @"C:\Users\HP\Desktop\HK2_Nam_3\Window_Programming\export\ScoreExport.docx";

            document.SaveAs2(ref fileName);
            word.Quit();

        }
        private void buttonWord_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ExportToWord(dataGridView1);
                MessageBox.Show("Export Successfully !!!", "Info");
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Score Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }
    }
}
