using BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class AccountDAL
    {
        public static bool Validate(string Username, string Password)

        {
            bool status = false;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ankush\Documents\Study\DotNet\MVC_CRUD\MVC_Crud\App_Data\ECommDB.mdf;Integrated Security=True";


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Student where SName=@Username and SPass=@Password";
            cmd.Parameters.Add(new SqlParameter("@Username", Username));
            cmd.Parameters.Add(new SqlParameter("@Password", Password));

            cmd.Connection = conn;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    status = true;
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
			return status;
        }

        public static bool Register(int Sid, string Name, string Password)
        {
            bool status = false;

            string query = "insert into Student values(@SId,@SName,@SPass)";
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ankush\Documents\Study\DotNet\MVC_CRUD\MVC_Crud\App_Data\ECommDB.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add(new SqlParameter("@SId", Sid));
                    cmd.Parameters.Add(new SqlParameter("@SName", Name));
                    cmd.Parameters.Add(new SqlParameter("@Spass", Password));

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    status = true;
                }

            }
            return status;
        }

        public static bool Update(int Sid, string Name, string Password)
        {
            bool status = false;

            string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Ankush\Documents\Study\DotNet\MVC_CRUD\MVC_Crud\App_Data\ECommDB.mdf; Integrated Security = True";
            string query = "update Student set SName=@Name, SPass=@Password where SId=@Sid";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add(new SqlParameter("@Sid", Sid));
                    cmd.Parameters.Add(new SqlParameter("@Name", Name));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    status = true;
                    conn.Close();
                }
            }
            return status;

        }

        public static bool registerEmployee(Employee e)
        {
            bool status = false;

            string query = "insert into Employee values(@EId,@EName)";
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ankush\Documents\Study\DotNet\MVC_CRUD\MVC_Crud\App_Data\ECommDB.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add(new SqlParameter("@EId", e.EId));
                    cmd.Parameters.Add(new SqlParameter("@EName", e.EName));

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    status = true;
                }

            }
            return status;

        }

        public static List<Student> getStudents()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ankush\Documents\Study\DotNet\MVC_CRUD\MVC_Crud\App_Data\ECommDB.mdf;Integrated Security=True";
            string query = "select SId, SName from Student";
            List<Student> slist = new List<Student>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd =new SqlCommand(query))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    SqlDataReader reader =  cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        { 
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);

                            slist.Add(new Student()
                            {
                                SId = id,
                                SName = name
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return slist;
        }
    }
}
