using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class CRUDModel
    {
        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DotNet\studentCRUD\student\App_Data\Database.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from student", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        public DataTable GetStudentByID(int intStudentID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DotNet\studentCRUD\student\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from student where Id=" + intStudentID, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }



        public int UpdateStudent(int intStudentID, string strStudentName, string strGender, int intAge)
        {
            string strConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DotNet\studentCRUD\student\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update student SET Name=@studname, age=@studage , gender=@gender where Id=@studid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", strStudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@gender", strGender);
                cmd.Parameters.AddWithValue("@studid", intStudentID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertStudent(string strStudentName, string strGender, int intAge)
        {
            string strConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DotNet\studentCRUD\student\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into student (Name,age,gender) values(@studname, @studage , @gender)";
                SqlCommand cmd = new SqlCommand(query, con);
                
                cmd.Parameters.AddWithValue("@studname", strStudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@gender", strGender);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteStudent(int intStudentID)
        {
            string strConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DotNet\studentCRUD\student\App_Data\Database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from student where Id=@studid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studid", intStudentID);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}  

  
