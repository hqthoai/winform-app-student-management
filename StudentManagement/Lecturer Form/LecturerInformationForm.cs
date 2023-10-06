using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Lecturer_Form
{
    public partial class LecturerInformationForm : Form
    {
        public LecturerInformationForm()
        {
            InitializeComponent();
        }
        Contact.Contact contact = new Contact.Contact();
        Group.Group group = new Group.Group();
        My_DB db = new My_DB();
        private void LecturerInformationForm_Load(object sender, EventArgs e)
        {
            DataTable table = contact.GetContactByID(Global.GlobalUserID1);
            txb_ID.Text = table.Rows[0]["id"].ToString();
            txb_Fname.Text = table.Rows[0]["fname"].ToString();
            txb_Lname.Text = table.Rows[0]["lname"].ToString();

            int gid =Int32.Parse( table.Rows[0]["group_id"].ToString());

            SqlCommand command = new SqlCommand("Select name from MyGroups where id = @gid", db.getConnection);
            command.Parameters.Add("@gid",SqlDbType.Int).Value= gid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table1 = new DataTable();
            db.openConnection();
            adapter.Fill(table1);
            db.closeConnection();

            cbb_Group.Text = table1.Rows[0]["name"].ToString();


            txb_Phone.Text = table.Rows[0]["phone"].ToString();
            txb_Email.Text = table.Rows[0]["email"].ToString();
            txb_Address.Text = table.Rows[0]["address"].ToString();

            byte[] pic = (byte[])table.Rows[0]["pic"];
            MemoryStream ms = new MemoryStream(pic);
            PicBox_ContactImage.Image = Image.FromStream(ms);
        }
    }
}
