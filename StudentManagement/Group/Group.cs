using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Group
{
    internal class Group
    {
        My_DB mydb = new My_DB();
        public bool insertGroup(int GroupID, string GroupName, int userID)
        {
            SqlCommand command = new SqlCommand("INSERT INTO MyGroups (id, name, userid)  VALUES (@gid, @name,@uid)", mydb.getConnection);
            command.Parameters.Add("@gid", SqlDbType.Int).Value = GroupID;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = GroupName;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userID;

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
        public bool updateGroupName(int GroupID, string GroupName)
        {
            SqlCommand command = new SqlCommand("UPDATE MyGroups SET name=@name WHERE id=@gid", mydb.getConnection);
            command.Parameters.Add("@gid", SqlDbType.Int).Value = GroupID;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = GroupName;

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
        public bool deleteGroup(int GroupID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM MyGroups WHERE id = @gid", mydb.getConnection);
            command.Parameters.Add("@gid", SqlDbType.Int).Value = GroupID;
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
        public bool CheckGroupID(int GroupID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MyGroups WHERE id = @cid", mydb.getConnection);
            command.Parameters.Add("cid", SqlDbType.Int).Value = GroupID;
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
        public bool CheckGroupName(string GroupName)
        {
            //Id <> @cID để phân biệt sự tồn tại của khóa học trong database và 1 khóa có khả năng trùng
            SqlCommand command = new SqlCommand("SELECT * FROM MyGroups WHERE name =@gName ", mydb.getConnection);
            command.Parameters.Add("@gName", SqlDbType.VarChar).Value = GroupName;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count > 0))
            {
                //phát hiện có 1 DÒNG tồn tại trùng tên
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckGroupIDForEdit(int GroupID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MyGroups WHERE id = @cid", mydb.getConnection);
            command.Parameters.Add("cid", SqlDbType.Int).Value = GroupID;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count >= 1)
            {
                if (Convert.ToInt32(table.Rows[0]["id"]) == GroupID)
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                mydb.closeConnection();
                return true;
            }
        }
        public DataTable GetUserGroups(int UserID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MyGroups WHERE userID = @uid ", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = UserID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
