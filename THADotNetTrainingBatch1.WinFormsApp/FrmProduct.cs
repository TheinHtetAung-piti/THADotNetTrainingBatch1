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
    }
}
