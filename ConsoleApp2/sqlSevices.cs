using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace ConsoleApp2
{
    public class sqlSevices
    {
        public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
        public DataTable Query(string query , params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
            connection.Open();
            SqlCommand cmd = new SqlCommand(query , connection);
            cmd.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public DataTable Query(string query, List<SqlParameter> parameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters.ToArray());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public DataTable Query(string query)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }
        public int cuQuery(string query,params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
