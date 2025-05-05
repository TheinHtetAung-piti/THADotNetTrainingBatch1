using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using THADotNetTrainingBatch1.WinFormsApp.Queries;

namespace THADotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmProduct : Form
    {
        private readonly SqlService _sqlService = new SqlService();
        private object textProductPrice;

        public FrmProduct()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _sqlService = new SqlService();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dt = _sqlService.Query(ProductQuery.GetAllProduct);
            dgvData.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string code = textProductCode.Text.Trim();
            string name = textProductName.Text.Trim();
            decimal price = Convert.ToDecimal(textPrice.Text.Trim());
            int quantity = Convert.ToInt32(textQuantity.Text.Trim());

            int result = _sqlService.Execute(ProductQuery.InsertProduct,
                new SqlParameter("@ProductCode", code),
                new SqlParameter("@ProductName", name),
                new SqlParameter("@Price", price),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@CreatedDateTime", DateTime.Now),
                new SqlParameter("@CreatedBy", AppSetting.CurrentUser)
                );

            string message = result != 0 ? "Create Successful" : "Fail to create";
            MessageBox.Show(message,"Inventory Control System",MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            ControlClear();
            BindData();


        }

        private void ControlClear()
        {
            textProductCode.Clear();
            textProductName.Clear();
            textPrice.Clear();
            textQuantity.Clear();
            textProductCode.Focus();
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ControlClear();
        }

        private void textProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textProductName.Focus();
            }
        }

        private void textProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPrice.Focus();
            }
        }

        private void textPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textQuantity.Focus();
            }
        }

        private void textQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(sender, e);
            }
        }
    }
}
