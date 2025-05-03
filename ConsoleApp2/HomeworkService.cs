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
        private readonly sqlSevices _sqlServices = new sqlSevices();
        public HomeworkService() 
        {
            _sqlServices = new sqlSevices();
        }
        public void ReadDetail()
        {
        beforeNo:
            Console.Write("Enter the no you wanna to see : ");
            string inputNo = Console.ReadLine()!;
            bool resultNo = int.TryParse(inputNo, out int no);
            if (!resultNo)
            {
                Console.WriteLine("Invalid No");
                goto beforeNo;
            }
            string qurey = $"select * from Tbl_Homework where No = @No";
             DataTable dt = _sqlServices.Query(qurey, new SqlParameter("@No", no));

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
            string query = "select * from Tbl_Homework";
            DataTable dt = _sqlServices.Query(query);

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

            int result = _sqlServices.cuQuery(query, new SqlParameter("@UserName", name),
             new SqlParameter("@GithubUserName",githubUserName) , new SqlParameter("@GithubRepoLink",githubRepoLink));
            if (result == 0)
            {
                Console.WriteLine("fail creation");
                return;
            }
            Console.WriteLine("Success");


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
            DataTable dt = _sqlServices.Query(query, new SqlParameter("@UserName", name), new SqlParameter("@Password", password));
            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("Invalid Login");
                return; 
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["Name"]);
        }

        public void Update()
        {
        beforeNo:
            Console.Write("Enter No you want to edit : ");
            string inputNo = Console.ReadLine()!;
            bool resultNo = int.TryParse(inputNo, out int no);
            if (!resultNo)
            {
                Console.WriteLine("Something Went wrong !");
                goto beforeNo;
            }

            string query = $@"select * from Tbl_Homework where No = @No";
            DataTable dt = _sqlServices.Query(query, new SqlParameter("@No", no));

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

            int result = _sqlServices.cuQuery(queryUpdate, new SqlParameter("@Name", name),
             new SqlParameter("@GithubUserName", githubUserName), new SqlParameter("@GithubRepoLink", githubRepoLink),
             new SqlParameter ("@No",no));
            if (result == 0)
            {
                Console.WriteLine("Fail to update");
            }
            Console.WriteLine("Success");
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
            string query = $@"select * from Tbl_Homework where No = @No";
            DataTable dt = _sqlServices.Query(query, new SqlParameter("@No", no));

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
                string queryDelete = @"DELETE FROM [dbo].[Tbl_Homework]
              WHERE No = @No";
                int result = _sqlServices.cuQuery(queryDelete, new SqlParameter("@No", no));
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
