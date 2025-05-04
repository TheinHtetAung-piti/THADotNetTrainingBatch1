using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace THADotNetTrainingBatch1.WinFormsApp
{
    public class SqlService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
        public DataTable Query(string query , List<SqlParameter> parameters)
        {
            
            //string query = $"select * from Tbl_user where Name = @UserName and Password = @Password ";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@UserName", userName);
            //cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddRange(parameters.ToArray());
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }
        public DataTable Query(string query,params SqlParameter[] parameters)
        {

            //string query = $"select * from Tbl_user where Name = @UserName and Password = @Password ";
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@UserName", userName);
            //cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddRange(parameters);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }

        public int Execute(string query , params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());  
            connection.Open();
            SqlCommand cmd = new SqlCommand(query , connection);
            cmd.Parameters.AddRange(parameters);
            int result = cmd.ExecuteNonQuery(); 
            connection.Close();
            return result;
        }
    }
}
