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
    public partial class FullContactForm : Form
    {
        public FullContactForm()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        Group.Group group = new Group.Group();
        private void FullContactForm_Load(object sender, EventArgs e)
        {
            //List Box
            listbox_Group.DataSource = group.GetUserGroups(Global.GlobalUserID1);
            listbox_Group.ValueMember = "Id";
            listbox_Group.DisplayMember = "name";
            listbox_Group.SelectedItem = null;

            //DataGridView
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = contact.ContactListByUserID(Global.GlobalUserID1);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }
        }
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void bt_ShowFull_Click(object sender, EventArgs e)
        {
            FullContactForm_Load(null, null);
        }
        private void listbox_Group_Click(object sender, EventArgs e)
        {
            int GroupID = (Int32)listbox_Group.SelectedValue;
            dataGridView1.DataSource = contact.ContactListByUserIDandGroupID(Global.GlobalUserID1, GroupID);
            //dataGridView1.DataSource = contact
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ContactClassForm CCF = new ContactClassForm();
            CCF.ContactID = (int)(dataGridView1.CurrentRow.Cells[0].Value);
            CCF.Show(this);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ContactClassForm CCF = new ContactClassForm();
            CCF.ContactID = (int)(dataGridView1.CurrentRow.Cells[0].Value);
            CCF.Show(this);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ContactClassForm CCF = new ContactClassForm();
            CCF.ContactID = (int)(dataGridView1.CurrentRow.Cells[0].Value);
            CCF.Show(this);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
