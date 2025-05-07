using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace THADotNetTrainingBatch1.Shared;

public class AdoDotNetService
{
    public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

    public AdoDotNetService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
    }

    public DataTable Query(string query, params SqlParameter[] parameters )
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddRange(parameters);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        connection.Close();
        return dt;
    }

    public DataTable Query(string query, List<SqlParameter>? parameters = null)
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

    //public DataTable Query(string query)
    //{
    //    SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
    //    connection.Open();
    //    SqlCommand cmd = new SqlCommand(query, connection);
    //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    adapter.Fill(dt);
    //    connection.Close();
    //    return dt;
    //}

    public int Execute(string query, params SqlParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddRange(parameters);
        int result = cmd.ExecuteNonQuery();
        connection.Close();
        return result;
    }

    public List<T> QueryV2<T>(string query, params SqlParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddRange(parameters);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        connection.Close();
        string jsonStr = JsonConvert.SerializeObject(dt);
        var lst = JsonConvert.DeserializeObject<List<T>>(jsonStr);
        return lst;

    }
}
