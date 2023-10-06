using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentManagement
{
    internal class User
    {
        My_DB mydb = new My_DB();

        public bool insertUser1(string username, string password, string fname, string lname, string gender, string phone, string email)
        {

            SqlCommand command = new SqlCommand("INSERT INTO Account (username,password,firstname,lastname,gender,phone,email)" +
                "VALUES (@user,@pass,@fn,@ln,@gdr,@phn,@ema)", mydb.getConnection);

            command.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;

            command.Parameters.Add("@pass", SqlDbType.NVarChar).Value = password;

            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;

            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;

            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;

            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;

            command.Parameters.Add("@ema", SqlDbType.NVarChar).Value = email;

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

        public bool insertUser(int id, string username, string password, String email)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Login (id, username, password, gmail)" +
                " VALUES (@id ,@un, @pw, @gm)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pw", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@gm", SqlDbType.VarChar).Value = email;
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

        public bool updateUser (string username, string password, string fname, string lname, string gender, string phone, string email, string role)
        {
            SqlCommand command = new SqlCommand("UPDATE Account SET" +
                "username=@user,password=@pass,firstname=@fn,lastname=@ln,gender=@gdr,phone=@phn,email=@ema,roles=@role", mydb.getConnection);

            command.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;

            command.Parameters.Add("@pass", SqlDbType.NVarChar).Value = password;

            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;

            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;

            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;

            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;

            command.Parameters.Add("@ema", SqlDbType.NVarChar).Value = email;

            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;

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
        public bool deleteUser(string username)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Account WHERE username = @user"  , mydb.getConnection);
            command.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;

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

        public DataTable getUser(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public bool CheckID(int UserID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM login where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = UserID;
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
        public bool CheckUserName(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM login where username = @un", mydb.getConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
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

        public bool insertHumanResource(int id, string fname, string lname, string username, string password, MemoryStream picture, string email)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HumanResource (id, f_name, l_name, uname, pwd, fig, gmail)" +
                " VALUES (@id ,@fn, @ln, @un, @pw, @pic, @gm)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pw", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@gm", SqlDbType.VarChar).Value = email;
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
        public bool updateHumanResource(int id, string fname, string lname, string username, string password, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE HumanResource SET f_name = @fn, l_name = @ln, uname = @un , pwd = @pass, fig = @pic WHERE id = @uid", mydb.getConnection);
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = id;

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
        public bool CheckHRID(int UserID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HumanResource where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = UserID;
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
        public bool CheckHRUserName(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HumanResource where uname = @un", mydb.getConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
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
        public bool CheckHRUserNameForEdit(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HumanResource where uname = @un", mydb.getConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 1)
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
        public DataTable GetHR(int Global_ID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HumanResource Where id = @HRID", mydb.getConnection);
            command.Parameters.Add("@HRID", SqlDbType.Int).Value = Global_ID;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
