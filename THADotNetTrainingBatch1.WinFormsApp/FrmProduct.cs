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
        private string _productId = string.Empty;

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
            MessageBox.Show(message, "Inventory Control System", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            ControlClear();
            BindData();


        }

        private void ControlClear()
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }

            textProductCode.Focus();
            btn_Save.Visible = true;
            btnUpdate.Visible = false;
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
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save_Click(sender, e);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // Edit
            {
                string? id = dgvData.Rows[e.RowIndex].Cells["colProductId"].Value.ToString();

                DataTable dt = _sqlService.Query("select * from Tbl_Product where ProductId = @ProductId",
                    new SqlParameter("@ProductId", id));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Product Not Found",
                        "Inventory Control System",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                textProductCode.Text = dt.Rows[0]["ProductCode"].ToString();
                textProductName.Text = dt.Rows[0]["ProductName"].ToString();
                textPrice.Text = dt.Rows[0]["Price"].ToString();
                textQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                _productId = id;

                btnUpdate.Visible = true;
                btn_Save.Visible = false;
            }
            else if (e.ColumnIndex == 1 ) // delete
            {
                string? id = dgvData.Rows[e.RowIndex].Cells["colProductId"].Value.ToString();
                string? deleteCode = dgvData.Rows[e.RowIndex].Cells["colProductCode"].Value.ToString();
              var result =  MessageBox.Show($"Are you sure to delete {deleteCode}?",
                    "Inventory Control System",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return; 
                }

                int result1 = _sqlService.Execute(ProductQuery.DeleteProduct,
                    new SqlParameter("@ProductCode", deleteCode));

                string message1 = result == 0 ? "Not Success" : "Success";
                MessageBox.Show(message1, "Inventory Control System",
                    MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                BindData();


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string code = textProductCode.Text.Trim();
            string name = textProductName.Text.Trim();
            decimal price = Convert.ToDecimal(textPrice.Text.Trim());
            int quantity = Convert.ToInt32(textQuantity.Text.Trim());

            int result = _sqlService.Execute(ProductQuery.UpdateProduct,
                new SqlParameter("@ProductCode", code),
                new SqlParameter("@ProductName", name),
                new SqlParameter("@Price", price),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@ModifiedDT", DateTime.Now),
                new SqlParameter("@ProductId",_productId),
                new SqlParameter("@CurrentUser", AppSetting.CurrentUser));

            string message = result == 0 ? "Fail To create!" : "Success";
            MessageBox.Show(message, "Inventory Control System", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            ControlClear();
            _productId = string.Empty;
            BindData();
        }
    }
}
