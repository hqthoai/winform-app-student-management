using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Contact
{
    public partial class Contact_sGroupForm : Form
    {
        public Contact_sGroupForm()
        {
            InitializeComponent();
        }

        Contact contact = new Contact();

        private void Contact_sGroupForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = contact.GetContactAndGroup(Global.GlobalUserID1);
            dataGridView1.RowTemplate.Height = 120;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[5];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedContactForm SCF = new SelectedContactForm();
            SCF.ContactID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SCF.Show();
        }
    }
}
