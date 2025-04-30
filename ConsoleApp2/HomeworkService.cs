using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp2
{
    internal class HomeworkService
    {
       private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
        public void ReadDetail(int no)
        {   
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string qurey = $"select * from Tbl_Homewrok where No = @No";
            SqlCommand cmd = new SqlCommand(qurey, connection);
            cmd.Parameters.AddWithValue("@No", no);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0 )
            {
                Console.WriteLine("No record Found");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["No"]);
            Console.WriteLine(dr["Name"]);
            Console.WriteLine(dr["GitHubUserName"]);
            Console.WriteLine(dr["GitHubRepoLink"]);
        }
        public void Read()
        {   
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string qurey = "select * from Tbl_Homework";
            SqlCommand cmd = new SqlCommand(qurey, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                //DataColumn dc = dt.Columns[i];
                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine(dr["GitHubRepoLink"]);
            }
        }

        public void Create()
        {
            Console.Write("Enter name : ");
            string name = Console.ReadLine()!;

            
            Console.Write("Enter the github username : ");
            string githubUserName = Console.ReadLine()!;

            Console.Write("Enter the github Repo link : ");
            string githubRepoLink = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection( _sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"USE [DotNetTrainingBatch1]
        INSERT INTO [dbo].[Tbl_Homework]
           ([Name]
           ,[GitHubUserName]
           ,[GitHubRepoLink])
        VALUES
           (@UserName
           ,@GithubUserName
           ,@GithubRepoLink )
            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", name);
            command.Parameters.AddWithValue("@GithubUserName", githubUserName);
            command.Parameters.AddWithValue("@UserName", githubRepoLink);

            int result = command.ExecuteNonQuery();
            connection.Close();
        
        }
        public void Login()
        {
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine()!;

            Console.Write("Enter the Password : ");
            string password = Console.ReadLine()!;

            string query = $@"Select * from Tbl_user 
where Name = @UserName
and Password = @Password ";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ToString());
            connection.Open();

            SqlCommand command = new SqlCommand(query , connection);
            command.Parameters.AddWithValue("@UserName", name);
            command.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            connection.Close();
        }

        public void Update()
        { beforeNo:
            Console.Write("Enter No you want to edit : ");
            string inputNo = Console.ReadLine()!;
            bool resultNo = int.TryParse(inputNo,out int no);
            if (!resultNo)
            {
                Console.WriteLine("Something Went wrong !");
                goto beforeNo;
            }

            
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"select * from Tbl_Homework where No = @No";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@No", no);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            Console.Write("Enter name : ");
            string name = Console.ReadLine()!;

            Console.Write("Enter the github username : ");
            string githubUserName = Console.ReadLine()!;

            Console.Write("Enter the github Repo link : ");
            string githubRepoLink = Console.ReadLine()!;

            string queryUpdate = @"UPDATE [dbo].[Tbl_Homework]
   SET [Name] = @Name
      ,[GitHubUserName] = @GithubUserName
      ,[GitHubRepoLink] = @GithubRepoLink
 WHERE No = @No";

            SqlConnection connection1= new SqlConnection(_sqlConnectionStringBuilder.ToString());
            connection1.Open();

            SqlCommand command = new SqlCommand(queryUpdate, connection);

            command.Parameters.AddWithValue("@No", no);
            command.Parameters.AddWithValue("@GithubUserName", githubUserName);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@GithubRepoLink", githubRepoLink);

            int result = command.ExecuteNonQuery();
            connection1.Close();
        }

        public void delete()
        {
        beforeNo:
            Console.Write("Enter the No you wanna to delete : ");
            string inputNo = Console.ReadLine()!;
            bool resultNo = int.TryParse(inputNo, out int no);
            if (!resultNo)
            {
                Console.WriteLine("Something Went wrong !");
                goto beforeNo;
            }


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = $@"select * from Tbl_Homework where No = @No";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@No", no);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record Found");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.Write($"Sure to delete {dr["Name"]} (y/n) : ");
            string comfirm = Console.ReadLine()!;
            if (comfirm is null)
            {
                Console.WriteLine("Select the correct command");
                goto beforeNo;
            }
            else if (comfirm.ToUpper() == "Y")
            {
                SqlConnection connection1 = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
                connection1.Open();
                string queryDelete = @"DELETE FROM [dbo].[Tbl_Homework]
      WHERE No = @No";
                SqlCommand command = new SqlCommand(queryDelete, connection1);
                command.Parameters.AddWithValue("@No", no);
                int result = command.ExecuteNonQuery();
                connection1.Close();
1
            }
            else if (comfirm.ToUpper() == "N")
            {
                Console.WriteLine("Data is not delete!");
            }
            else
            {
                Console.WriteLine("Select the correct command");
                goto beforeNo;
            }
            {

            }
        }
    }
}
