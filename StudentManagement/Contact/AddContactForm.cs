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
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        Group.Group group = new Group.Group();
        bool verif()
        {
            if ((txb_Fname.Text.Trim() == "")
                || (txb_Lname.Text.Trim() == "")
                || (txb_Address.Text.Trim() == "")
                || (txb_Phone.Text.Trim() == "")
                || (txb_Email.Text.Trim() == "")
                || (txb_Address.Text.Trim() == "")
                || (txb_ID.Text.Trim() == "")
                || (PicBox_ContactImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void bt_AddStudent_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                //biến này dùng để kiểm tra ID nhập vào là Interger
                int num = -1;
                if (txb_ID.Text.Trim() == "")
                {
                    MessageBox.Show("Please Add An ID", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Int32.TryParse(txb_ID.Text, out num))
                {
                    MessageBox.Show("Please Add An Interger For ID", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
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
                    //Kiểm Tra ID của User Này
                    if (contact.CheckContactID(ContactID, Global.GlobalUserID1))
                    {
                        //Nếu User Này ko trùng ID => Kiểm sang các user khác
                        if (contact.CheckContactIDForAllUser(ContactID))
                        {
                            if (contact.insertContact(ContactID, fname, lname, phone, address, email, GroupID, pic))
                            {
                                MessageBox.Show("New Contact Added", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //Sau khi Add Contact vào thì làm sạch form
                                CleanForm();
                            }
                            else
                            {
                                MessageBox.Show("Error", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ID Already Existed!", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contact's Of This User Already Existed!", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
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
        private void AddContactForm_Load(object sender, EventArgs e)
        {
            cbb_Group.DataSource = group.GetUserGroups(Global.GlobalUserID1);
            cbb_Group.DisplayMember = "Name";
            cbb_Group.ValueMember = "id";
        }
        void CleanForm()
        {
            txb_ID.Text = "";
            txb_Fname.Text = "";
            txb_Lname.Text = "";
            txb_Address.Text = "";
            txb_Phone.Text = "";
            txb_Email.Text = "";
            //cbb_Group.DataSource = null;
            PicBox_ContactImage.Image = null;
        }
    }
}
