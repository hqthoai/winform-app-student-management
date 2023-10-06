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

namespace StudentManagement.Contact
{
    public partial class SelectedContactForm : Form
    {
        public int ContactID;
        public SelectedContactForm()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        Group.Group group = new Group.Group();

        private void SelectedContactForm_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = contact.GetContactByID(ContactID);
            txb_ID.Text = table.Rows[0]["id"].ToString();
            txb_Fname.Text = table.Rows[0]["fname"].ToString();
            txb_Lname.Text = table.Rows[0]["lname"].ToString();
            //cbb_Group.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value;
            cbb_Group.DataSource = group.GetUserGroups(Global.GlobalUserID1);
            cbb_Group.DisplayMember = "name";
            cbb_Group.ValueMember = "id";
            cbb_Group.SelectedValue = table.Rows[0]["group_id"];

            txb_Phone.Text = table.Rows[0]["phone"].ToString();
            txb_Email.Text = table.Rows[0]["email"].ToString();
            txb_Address.Text = table.Rows[0]["address"].ToString();

            byte[] pic = (byte[])table.Rows[0]["pic"];
            MemoryStream ms = new MemoryStream(pic);
            PicBox_ContactImage.Image = Image.FromStream(ms);
        }
    }
}
