using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Contact
{
    internal class Contact
    {
        #region CRUD
        My_DB mydb = new My_DB();
        public bool insertContact(int id, string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO contact (id, fname, lname, group_id , phone, email, address, pic )" +
                " VALUES (@id, @fn, @ln, @gid, @phn, @mail,@adrs,@pic)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateContact(int ContactID, string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture, int RefferenceID)
        {
            SqlCommand command = new SqlCommand("UPDATE contact SET fname = @fn, lname = @ln, phone = @phn, address = @adrs," +
                " email= @mail, group_id = @gid, pic = @pic,id = @cid WHERE id = @rid", mydb.getConnection);
            command.Parameters.Add("@rid", SqlDbType.Int).Value = RefferenceID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = ContactID;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool deleteContact(int ContactID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM contact WHERE id = @cid", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = ContactID;
            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        #endregion

        //Lấy List Contact dựa theo user ID
        public DataTable ContactListByUserID(int userID)
        {
            SqlCommand command = new SqlCommand("SELECT contact.id as ContactID, contact.fname as FirstName , contact.lname as LastName, " +
                "Mygroups.id as GroupID, Mygroups.name as GroupName, HumanResource.id as UserID, contact.pic as Picture FROM contact inner join Mygroups " +
                "on contact.group_id = Mygroups.id inner join HumanResource on Mygroups.userid = HumanResource.id WHERE HumanResource.id = @userID " +
                "order by contact.id", mydb.getConnection);
            command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //Lấy List Contact dựa theo user ID và Group ID
        public DataTable ContactListByUserIDandGroupID(int userID, int GroupID)
        {
            SqlCommand command = new SqlCommand("SELECT contact.id as ContactID, contact.fname as FirstName , contact.lname as LastName, Mygroups.id as GroupID, Mygroups.name as GroupName, HumanResource.id as UserID, contact.pic FROM contact inner join Mygroups on contact.group_id = Mygroups.id inner join HumanResource on Mygroups.userid = HumanResource.id WHERE HumanResource.id = @userID AND Mygroups.id = @gID order by contact.id", mydb.getConnection);
            command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
            command.Parameters.Add("@gID", SqlDbType.Int).Value = GroupID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable GetContactByID(int ContactID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM contact WHERE id = @cid ", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = ContactID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //kiểm tra xem đối với USER này thì có tồn tại CONTACT thuộc GROUP do USER đó điều hành hay ko
        public bool CheckContactID(int ContactID, int UserID)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * FROM contact inner join mygroups on contact.group_id = mygroups.id inner join HumanResource on HumanResource.id = mygroups.userid " +
            "Where contact.id = @cid and HumanResource.id = @uid order by mygroups.id";
            command.Connection = mydb.getConnection;
            command.Parameters.Add("cid", SqlDbType.Int).Value = ContactID;
            command.Parameters.Add("uid", SqlDbType.Int).Value = UserID;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count >= 1)
            {
                mydb.closeConnection();
                return false;
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }
        //Kiểm tra tồn tại ID của Contact với tất cả user
        public bool CheckContactIDForAllUser(int ContactID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM contact Where id = @cid ", mydb.getConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = ContactID;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                mydb.closeConnection();
                return false;
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }

        public DataTable GetContactAndGroup(int UserID)
        {
            SqlCommand command = new SqlCommand("SELECT contact.id as ContactID, contact.fname as FirstName , " +
                "contact.lname as LastName, Mygroups.id as GroupID, Mygroups.name as GroupName, " +
                "contact.pic as Picture FROM contact inner join Mygroups on contact.group_id = Mygroups.id inner join HumanResource " +
                "on Mygroups.userid = HumanResource.id WHERE HumanResource.id = @userID order by contact.id", mydb.getConnection);
            command.Parameters.Add("@userID", SqlDbType.Int).Value = UserID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
