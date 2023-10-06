using StudentManagement.Account;
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
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
        }
        User HRuser = new User();
        Contact contact = new Contact();
        Group.Group group = new Group.Group();
        private void ContactForm_Load(object sender, EventArgs e)
        {
           
            DataTable table = new DataTable();
            table = HRuser.GetHR(Global.GlobalUserID1);
            byte[] pic = (byte[])table.Rows[0]["fig"];
            MemoryStream ms = new MemoryStream(pic);
            pictureBoxUser.Image = Image.FromStream(ms);
            pictureBoxUser.SizeMode = PictureBoxSizeMode.StretchImage;

            labelWelcome.Text = ("Welcome User (" + table.Rows[0]["ID"].ToString() + ")");


            comboBoxGrName.DataSource = group.GetUserGroups(Global.GlobalUserID1);
            comboBoxGrName.DisplayMember = "Name";
            comboBoxGrName.ValueMember = "id";

            comboBoxSelectGr.DataSource = group.GetUserGroups(Global.GlobalUserID1);
            comboBoxSelectGr.DisplayMember = "Name";
            comboBoxSelectGr.ValueMember = "id";

        }

        private void buttonShowList_Click(object sender, EventArgs e)
        {
            FullContactForm FCF = new FullContactForm();
            FCF.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddContactForm ACF = new AddContactForm();
            ACF.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditContactForm ECF = new EditContactForm();
            ECF.Show();
        }

        private void buttonSelectContact_Click(object sender, EventArgs e)
        {
            Contact_sGroupForm CGF = new Contact_sGroupForm();
            CGF.Show();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int num = -1; // checking input is interger or not
            if (textBoxID.Text.Trim() == "")
            {
                MessageBox.Show("Please Add An ID", "Select Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Int32.TryParse(textBoxID.Text, out num))
            {
                MessageBox.Show("Please Add An InterGer", "Select Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int ContactID = Convert.ToInt32(textBoxID.Text);
                if (!contact.CheckContactID(ContactID, Global.GlobalUserID1))
                {
                    if ((MessageBox.Show("Are you sure want to delete this Contact?", "Delete Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (contact.deleteContact(ContactID))
                        {
                            MessageBox.Show("Contact Deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBoxID.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Can Not Delete Contact", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ID Can Not Be Found!", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxID.Text = "";
                }
            }
        }

        private void buttonAddGrName_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                int num = -1;
                if (textBoxGrID.Text.Trim() == "")
                {
                    MessageBox.Show("Please Add An ID", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Int32.TryParse(textBoxGrID.Text, out num))
                {
                    MessageBox.Show("Please Add An InterGer For Group's ID", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int GroupID = Convert.ToInt32(textBoxGrID.Text);
                    string GroupName = textBoxGrName.Text;
                    if (group.CheckGroupID(GroupID))
                    {
                        if (group.CheckGroupName(GroupName))
                        {
                            if (group.insertGroup(GroupID, GroupName, Global.GlobalUserID1))
                            {
                                MessageBox.Show("Group Added!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBoxGrID.Text = ""; textBoxGrName.Text = "";
                                ContactForm_Load(null, null);
                            }
                            else
                            {
                                MessageBox.Show("Can Not Add Group!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Group's Name Existed!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxGrName.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Group's ID Existed!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxGrID.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if (textBoxGrID.Text.Trim() == "" || textBoxGrName.Text.Trim() == "")
                return false;
            else
                return true;

        }

        private void buttonEditGr_Click(object sender, EventArgs e)
        {
            if (textBoxNewName.Text.Trim() != "")
            {
                string GroupName = textBoxNewName.Text;
                int GroupID = (int)comboBoxGrName.SelectedValue;
                if (group.CheckGroupName(GroupName))
                {
                    if (group.updateGroupName(GroupID, GroupName))
                    {
                        MessageBox.Show("Group's Name Edited", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxNewName.Text = "";
                        ContactForm_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Can Not Update Group's Name", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Group's Name Existed!", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNewName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonRemoveGr_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure want to delete this Group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                int GroupID = (int)comboBoxSelectGr.SelectedValue;
                //int GroupID = (int)cbb_EditGroup.SelectedIndex;
                if (group.deleteGroup(GroupID))
                {
                    MessageBox.Show("Group Deleted", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ContactForm_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Can Not Delete Group!", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonManageForm_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm("");
            mainForm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditHRForm EHRF = new EditHRForm();
            EHRF.Show(this);
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }
    }


}
