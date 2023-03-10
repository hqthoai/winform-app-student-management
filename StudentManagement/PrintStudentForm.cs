using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Word = Microsoft.Office.Interop.Word;

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
                MessageBox.Show("Error", ex.Message);
                db.closeConnection();
            }

        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (dataGridViewPrint.Rows.Count != 0)
            {
                int RowCount = dataGridViewPrint.Rows.Count;
                int ColumnCount = dataGridViewPrint.Columns.Count;
                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                //dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                Object oMissing = System.Reflection.Missing.Value;
                for (int r = 0; r <= RowCount - 1; r++)
                {
                    oTemp = "";
                    for (int c = 0; c < ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + dataGridViewPrint.Rows[r].Cells[c].Value + "\t";
                    }
                    var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara1.Range.Text = oTemp;
                    oPara1.Range.InsertParagraphAfter();
                    byte[] imgbyte = (byte[])dataGridViewPrint.Rows[r].Cells[8].Value;
                    MemoryStream ms = new MemoryStream(imgbyte);
                    System.Drawing.Image sparePicture = System.Drawing.Image.FromStream(ms);
                    System.Drawing.Image finalPic = (System.Drawing.Image)(new Bitmap(sparePicture, new
                   Size(90, 90)));
                    Clipboard.SetDataObject(finalPic);
                    var oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara2.Range.Paste();
                    oPara2.Range.InsertParagraphAfter();
                    //oTemp += "\n";
                }
                //save the file
                oDoc.SaveAs2(filename);
            }
        }
        private void buttonSaveToText_Click(object sender, EventArgs e)
        {

        }
    }
}
