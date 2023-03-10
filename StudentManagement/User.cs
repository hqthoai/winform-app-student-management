using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class User
    {
        My_DB mydb = new My_DB();

        public bool insertUser(string username, string password, string fname, string lname, string gender, string phone, string email)
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
    }
}
