// See https://aka.ms/new-console-template for more information
using System.Data;
using ConsoleApp2;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = ".";
//sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch1";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sa@123";
//sqlConnectionStringBuilder.TrustServerCertificate = true;
HomeworkService homewrokService = new HomeworkService();
homewrokService.Read();
