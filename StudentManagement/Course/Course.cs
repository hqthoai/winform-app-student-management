using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using DataTable = System.Data.DataTable;
using StudentManagement.Contact;

namespace StudentManagement.Course
{
    internal class Course
    {
        My_DB db = new My_DB();

        public bool insertCourse (int id, string courseName, int hoursNumber, string description, int semester)
        {

            SqlCommand command = new SqlCommand(
                "INSERT INTO Course (id,label,period,description,semester)" +
            "VALUES (@id,@lb,@peri,@dsc,@sem)", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            command.Parameters.Add("@lb", SqlDbType.NVarChar).Value = courseName;

            command.Parameters.Add("@peri", SqlDbType.Int).Value = hoursNumber;

            command.Parameters.Add("@dsc", SqlDbType.Text).Value = description;

            command.Parameters.Add("@sem", SqlDbType.Int).Value = semester;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }


        public bool CheckContactID(int courseID)
        {
            SqlCommand command = new SqlCommand("Select contactID from Course where id=@courid", db.getConnection);
            command.Parameters.Add("@courid", SqlDbType.Int).Value = courseID;
            db.openConnection();
   
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count >= 2)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        //public bool updateTeachingLecturer(int courseID, int contactID )
        //{
        //    SqlCommand command = new SqlCommand("update Course SET contactID = @contid where courseid = @courid", db.getConnection);
        //    command.Parameters.Add("@courid", SqlDbType.Int).Value = courseID;
        //    command.Parameters.Add("@contid", SqlDbType.Int).Value = contactID;
        //    db.openConnection();

        //    if (command.ExecuteNonQuery() == 1)
        //    {
        //        db.closeConnection();
        //        return true;
        //    }
        //    else
        //    {
        //        db.closeConnection();
        //        return false;
        //    }
        //}
        public bool RegisterTeachingCourse(int courseID, int contactID)
        {
            SqlCommand command = new SqlCommand("Update Course SET contactID = @contID where id = @courid", db.getConnection);
            command.Parameters.Add("@courid", SqlDbType.Int).Value = courseID;

            command.Parameters.Add("@contID", SqlDbType.NVarChar).Value = contactID;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool updateCourse(int id, string courseName, int hoursNumber, string description, int semester)
        {

            SqlCommand command = new SqlCommand( "UPDATE Course SET id=@id , label=@lb, period=@peri , description=@dsc, " +
                "semester=@sem WHERE id=@id", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            command.Parameters.Add("@lb", SqlDbType.NVarChar).Value = courseName;

            command.Parameters.Add("@peri", SqlDbType.Int).Value = hoursNumber;

            command.Parameters.Add("@dsc", SqlDbType.Text).Value = description;

            command.Parameters.Add("@sem", SqlDbType.Int).Value = semester;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool deleteCourse(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id = @id", db.getConnection);
            command.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        string execCount(string querry)
        {
            SqlCommand command = new SqlCommand(querry, db.getConnection);
            db.openConnection();
            string count = command.ExecuteScalar().ToString();
            //string count = command.ExecuteNonQuery().ToString();
            db.closeConnection();
            return count;
        }
        public string totalCourse()
        {
            return execCount("SELECT COUNT(*) FROM course");
        }
        public bool checkCourseName(string name, int id=0)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE label=@name AND id<>@id", db.getConnection);
            command.Parameters.Add("@id",SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            db.openConnection();
            if (table.Rows.Count > 0)
            {
                db.closeConnection();
                return false;
            }
            else
            {
                db.closeConnection();
                return true;
            }
        }
        public bool checkCourseID(int CourseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE  id = @cID", db.getConnection);
            command.Parameters.Add("@cID", SqlDbType.Int).Value = CourseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                //phát hiện có 1 DÒNG tồn tại trùng ID
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable getAllCourseByLecturer(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course where contactID =@id", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public DataTable getAllCourse()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;   
           
        }

        public DataTable getCourseById(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE id=@id", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseBySemester(int semester)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE semester=@sem", db.getConnection);
            command.Parameters.Add("@sem", SqlDbType.Int).Value = semester;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }



    }
}
