using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace THADotNetTrainingBatch1.ConsoleApp3
{
    internal class SqlService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,
        };
        public List<T> Query<T>(string query, object? parameters = null)
        {
            using IDbConnection conneciton = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            conneciton.Open();
            var lst = conneciton.Query<T>(query, parameters).ToList();
            return lst;
        }

        public int Execute(string query, object? parameters = null)
        {
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);    
            connection.Open();
            int result = connection.Execute(query, parameters);
            return result;
        }
    }

}
