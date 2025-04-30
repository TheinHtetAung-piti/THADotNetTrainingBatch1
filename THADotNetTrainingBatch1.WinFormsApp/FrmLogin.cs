using System.Data;
using Microsoft.Data.SqlClient;

namespace THADotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmLogin : Form
    {
        private readonly SqlService _sqlService = new SqlService();
        public FrmLogin()
        {
            InitializeComponent();
            _sqlService = new SqlService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btlLogin_Click(object sender, EventArgs e)
        {
            string userName = textUername.Text.Trim();
            string password = textPassword.Text.Trim();
            string query = $"select * from Tbl_user where Name = @UserName and Password = @Password ";
            //List<SqlParameter> parameters = new List<SqlParameter>()
            //{
            //    new SqlParameter("@UserName", userName), 
            //    new SqlParameter("@Password", password)
            //}
            //;
            //DataTable dt = _sqlService.Qurey(query, parameters);
            DataTable dt = _sqlService.Qurey(query, new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password));
            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            //{
            //    DataSource = ".",
            //    InitialCatalog = "DotNetTrainingBatch1",
            //    UserID = "sa",
            //    Password = "sa@123",
            //    TrustServerCertificate = true
            //};
            
            //SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand( query , connection);
            //cmd.Parameters.AddWithValue("@UserName" , userName );   
            //cmd.Parameters.AddWithValue ("@Password" , password );
            //DataTable dt = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //adapter.Fill(dt);

            //connection.Close(); 
            
            if (dt.Rows.Count == 0 )
            {
                MessageBox.Show("User Doesn't exst.");
                return;
            }

            MessageBox.Show("Success!");
                   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btlCancel_Click(object sender, EventArgs e)
        {
            textUername.Clear();
            textPassword.Clear();

        }
    }
}
