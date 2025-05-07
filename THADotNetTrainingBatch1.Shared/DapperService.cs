using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace THADotNetTrainingBatch1.Shared;

public class DapperService
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

    public DapperService(SqlConnectionStringBuilder sqlConnectionBuilder)
    {
        _sqlConnectionStringBuilder = sqlConnectionBuilder;
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
