using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            _sqlService = new SqlService();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmProduct_Load(object sender, EventArgs e)
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
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

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
    }
}
