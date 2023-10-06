using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Score
{
    internal class Score
    {
        My_DB mydb = new My_DB();
        Course.Course course = new Course.Course();
        public bool insertScore(int studentID, int courseID, float scoreValue, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Score (student_id, course_id, student_score, description) VALUES (@sid,@cid,@scr,@descr)", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.NVarChar).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;
            command.Parameters.Add("@scr", SqlDbType.Float).Value = scoreValue;
            command.Parameters.Add("@descr", SqlDbType.VarChar).Value = description;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool deleteScore(int studentID, int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Score WHERE student_id = @sid AND course_id = @cid", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool studentScoreExist(int StudentID, int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM  Score WHERE student_id = @sid AND course_id = @cid", mydb.getConnection);
            command.Parameters.Add("@sid", SqlDbType.Int).Value = StudentID;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if ((table.Rows.Count) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable getStudentScore()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            //command.CommandText = "SELECT score.student_id, std.fname, std.lname, score.course_id, course.label, round(score.student_score,3) as student_score " +
            //"FROM std INNER JOIN score on std.id = score.student_id INNER JOIN course on score.course_id = Course.id order by course.label";
            command.CommandText = "SELECT Score.student_id as StudentID , Student.firstname as FirstName, Student.lastname as LastName, " +
                "Score.course_id as CourseID, Course.label as Label, round(Score.student_score,3) as Score FROM Student INNER JOIN Score " +
                "on Student.mssv = Score.student_id INNER JOIN Course on Score.course_id = Course.id order by Course.label";
            //command.CommandText = "SELECT score.student_id, std.fname, std.lname, score.course_id, course.label, score.student_score " +
            //"FROM std INNER JOIN score on std.id = score.student_id INNER JOIN course on score.course_id = Course.id";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public DataTable getStudentScoreByLecturer()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            //command.CommandText = "SELECT score.student_id, std.fname, std.lname, score.course_id, course.label, round(score.student_score,3) as student_score " +
            //"FROM std INNER JOIN score on std.id = score.student_id INNER JOIN course on score.course_id = Course.id order by course.label";
            command.CommandText = "SELECT Score.student_id as StudentID , Student.firstname as FirstName, Student.lastname as LastName, " +
                "Score.course_id as CourseID, Course.label as CourseName, round(Score.student_score,3) as Score FROM Student INNER JOIN Score " +
                "on Student.mssv = Score.student_id INNER JOIN Course on Score.course_id = Course.id where contactID =@id";
            command.Parameters.Add("@id", SqlDbType.Int).Value = Global.GlobalUserID1;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        //tính dtb
        public DataTable getAVGScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT Course.label, round(AVG(Score.student_score),3) AS AverageGrade FROM Course, Score " +
                "WHERE Course.id = Score.course_id GROUP BY Course.label";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //Lấy bảng điểm môn học và 1 số thông tin cơ bản: mssv-fname-lname-courseID-CourseName-student_score
        public DataTable getCourseScore(int courseID)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT Score.student_id, Student.firstname, Student.lastname, Score.course_id, Course.label, Score.student_score" +
                                   " FROM Student INNER JOIN Score on Student.mssv = Score.student_id INNER JOIN Course on Score.course_id = Course.id WHERE Score.course_id = " + courseID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getStudentScore(int studentID)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT Score.student_id, Student.firstname, Student.lastname, Score.course_id, Course.label, Score.student_score" +
            "FROM Student INNER JOIN Score on Student.id = Score.student_id INNER JOIN Course on Score.course_id = Course.id WHERE Score.student_id = " + studentID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAllCourseScoreAndResult()
        {
            SqlCommand command = new SqlCommand("SELECT mssv , firstname , lastname  FROM Student", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            DataTable tableCourse = new DataTable();
            tableCourse = course.getAllCourse();

            //lấy khóa học theo chiều ngang
            for (int i = 0; i < tableCourse.Rows.Count; i++)
            {
                DataColumn CourseNamecolumn = new DataColumn();
                CourseNamecolumn.ColumnName = tableCourse.Rows[i]["label"].ToString();
                table.Columns.Add(CourseNamecolumn);
            }
            //lấy điểm của từng khóa học dựa theo id của học sinh
            DataTable tableScore = new DataTable();
            tableScore = this.getStudentScore();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int c = 0; c < tableScore.Rows.Count; c++)
                {
                    if (table.Rows[i]["mssv"].ToString() == tableScore.Rows[c]["StudentID"].ToString())
                    {
                        for (int k = 3; k < table.Columns.Count; k++)
                        {
                            if (table.Columns[k].ColumnName == tableScore.Rows[c]["label"].ToString())
                            {
                                //string coursename = table.Columns[k].ColumnName;
                                //table.Rows[i][coursename] = tableScore.Rows[c]["student_score"].ToString();
                                table.Rows[i][k] = tableScore.Rows[c]["Score"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            table.Columns.Add("AVG_Score", typeof(float));
            table.Columns.Add("Result", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int count = 0;
                float sum = 0;
                for (int j = 3; j < table.Columns.Count - 2; j++)
                {
                    float temp;
                    string coursename = table.Columns[j].ColumnName;
                    if (float.TryParse(table.Rows[i][coursename].ToString(), out temp))
                    {
                        sum += temp;
                        count++;
                    }
                }

                float avg = sum / count;
                Math.Round(avg, 2);
                table.Rows[i]["AVG_Score"] = Math.Round(avg, 2);

                if (avg < 5) table.Rows[i]["Result"] = "Fail";
                if (avg >= 5 && avg <= 6.5) table.Rows[i]["Result"] = "Average";
                if (avg > 6.5 && avg <= 7.9) table.Rows[i]["Result"] = "Good";
                if (avg >= 8) table.Rows[i]["Result"] = "Excellent";
                if (count == 0) table.Rows[i]["Result"] = "Drop Out Of University!";
                if (avg.ToString() == "NaN") table.Rows[i]["AVG_Score"] = 0;
            }

            return table;
        }
    }
}
