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
    public partial class EditContactForm : Form
    {
        int FirstContactID;
        public EditContactForm()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        Group.Group group = new Group.Group();

        private void EditContactForm_Load(object sender, EventArgs e)
        {

        }

        private void bt_SelectContact_Click(object sender, EventArgs e)
        {
            int num = -1; // checking input is interger or not
            if (txb_ID.Text.Trim() == "")
            {
                MessageBox.Show("Please Add An ID", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Int32.TryParse(txb_ID.Text, out num))
            {
                MessageBox.Show("Please Add An InterGer", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int ContactID = Convert.ToInt32(txb_ID.Text);
                FirstContactID = Convert.ToInt32(txb_ID.Text);
                if (!contact.CheckContactID(ContactID, Global.GlobalUserID1))
                {
                    DataTable table = new DataTable();
                    table = contact.GetContactByID(ContactID);
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
                else
                {
                    MessageBox.Show("Contact's ID Of This User Can Not Be Found!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CleanForm();
                }
            }
        }

        private void bt_UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*gif)|*.jpg;*.pngl*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PicBox_ContactImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_EditContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                    int ContactID = Convert.ToInt32(txb_ID.Text);
                    string fname = txb_Fname.Text;
                    string lname = txb_Lname.Text;
                    string phone = txb_Phone.Text;
                    string email = txb_Email.Text;
                    string address = txb_Address.Text;
                    int GroupID = (int)cbb_Group.SelectedValue;
                    MemoryStream pic = new MemoryStream();
                    PicBox_ContactImage.Image.Save(pic, PicBox_ContactImage.Image.RawFormat);
                    //giữ nguyên ID
                    if (FirstContactID == ContactID)
                    {
                        if (contact.updateContact(ContactID, fname, lname, phone, address, email, GroupID, pic, FirstContactID))
                        {
                            MessageBox.Show("Contact Edited", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CleanForm();
                        }
                        else
                        {
                            MessageBox.Show("Can not Update Contact ", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //Thay đổi ID => kiểm tra xem có trùng ID đối với các user khác không
                    else
                    {
                        if (contact.CheckContactIDForAllUser(ContactID))
                        {
                            if (contact.updateContact(ContactID, fname, lname, phone, address, email, GroupID, pic, FirstContactID))
                            {
                                MessageBox.Show("Contact Edited", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CleanForm();
                            }
                            else
                            {
                                MessageBox.Show("Can not Update Contact!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("ID Already Existed!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        bool verif()
        {
            if ((txb_Fname.Text.Trim() == "")
                || (txb_Lname.Text.Trim() == "")
                || (txb_Address.Text.Trim() == "")
                || (txb_Phone.Text.Trim() == "")
                || (txb_Email.Text.Trim() == "")
                || (txb_Address.Text.Trim() == "")
                || (txb_ID.Text.Trim() == "")
                || (PicBox_ContactImage.Image == null)
                || (cbb_Group.DataSource == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        void CleanForm()
        {
            txb_ID.Text = "";
            txb_Fname.Text = "";
            txb_Lname.Text = "";
            txb_Address.Text = "";
            txb_Phone.Text = "";
            txb_Email.Text = "";
            cbb_Group.DataSource = null;
            PicBox_ContactImage.Image = null;
        }

        private void txb_ID_TextChanged(object sender, EventArgs e)
        {
            if (txb_ID.Text.Trim() == "")
            {
                CleanForm();
            }
        }
    }
}
