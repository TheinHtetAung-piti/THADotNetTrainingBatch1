using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace THADotNetTrainingBatch1.Shared;

public class DapperService : IDbV2Service
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public DapperService(IConfiguration configuration)
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));
    }
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
