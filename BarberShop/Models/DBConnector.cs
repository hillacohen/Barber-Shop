using System;
using System.Data;
using System.Data.SqlClient;

namespace DBTest
{
    public  class DBConnector
    {
        private string connectionString= "Data Source=LT10-HILLAC\\PRINTBOS;Initial Catalog=newdb;Integrated Security=True";

        public DBConnector()
        {
            try
            {
                //String connectionString = "Data Source=LT10-HILLAC\\PRINTBOS;Initial Catalog=newdb;Integrated Security=True";
                // string connetionString;
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
               
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public DataTable SelectAll(string table)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT * FROM {table}";
            using (SqlConnection conn=new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query,conn);
                command.Connection.Open();
               // command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            return dt;
        }

        public void AddUser(string Username, string name,string password)
        {
            
            DataTable dt = new DataTable();
            string query = $"INSERT INTO [BarberShopDB].[dbo].[Users] (UserName, Name, Password) VALUES('{Username}', '{name}', '{password}'); ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Connection.Open();
                 command.ExecuteNonQuery();
             
               
            }
           
        }

        public void RemoveUser(string Username)
        {

            DataTable dt = new DataTable();
            string query = $" DELETE FROM [BarberShopDB].[dbo].[Users] WHERE Name={Username}";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

        }
      
        public void IfUserNameExist(string Username)
        {

            DataTable dt = new DataTable();
            string query = $"SELECT count (*) FROM[BarberShopDB].[dbo].[Users] where UserName = '{Username}'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

        }


    }
}
