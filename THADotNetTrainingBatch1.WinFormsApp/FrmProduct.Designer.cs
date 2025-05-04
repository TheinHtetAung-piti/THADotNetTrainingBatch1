namespace THADotNetTrainingBatch1.WinFormsApp
{
    partial class FrmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvData = new DataGridView();
            textProductCode = new TextBox();
            textProductName = new TextBox();
            textPrice = new TextBox();
            textQuantity = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btn_Save = new Button();
            btn_Clear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Dock = DockStyle.Bottom;
            dgvData.Location = new Point(0, 368);
            dgvData.Margin = new Padding(4);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(1100, 262);
            dgvData.TabIndex = 0;
            // 
            // textProductCode
            // 
            textProductCode.Font = new Font("Segoe UI", 12F);
            textProductCode.Location = new Point(60, 72);
            textProductCode.Margin = new Padding(4);
            textProductCode.Name = "textProductCode";
            textProductCode.Size = new Size(170, 34);
            textProductCode.TabIndex = 1;
            textProductCode.TextChanged += textBox1_TextChanged;
            // 
            // textProductName
            // 
            textProductName.Font = new Font("Segoe UI", 12F);
            textProductName.Location = new Point(60, 142);
            textProductName.Margin = new Padding(4);
            textProductName.Name = "textProductName";
            textProductName.Size = new Size(170, 34);
            textProductName.TabIndex = 2;
            textProductName.TextChanged += textProductName_TextChanged;
            // 
            // textPrice
            // 
            textPrice.Font = new Font("Segoe UI", 12F);
            textPrice.Location = new Point(60, 212);
            textPrice.Margin = new Padding(4);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(170, 34);
            textPrice.TabIndex = 3;
            textPrice.TextChanged += textPrice_TextChanged;
            textPrice.KeyPress += textPrice_KeyPress;
            // 
            // textQuantity
            // 
            textQuantity.Font = new Font("Segoe UI", 12F);
            textQuantity.Location = new Point(60, 282);
            textQuantity.Margin = new Padding(4);
            textQuantity.Name = "textQuantity";
            textQuantity.Size = new Size(170, 34);
            textQuantity.TabIndex = 4;
            textQuantity.TextChanged += textBox4_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(60, 40);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 5;
            label1.Text = "Product Code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(60, 110);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 6;
            label2.Text = "Product Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(60, 180);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(54, 28);
            label3.TabIndex = 7;
            label3.Text = "Price";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(60, 250);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(88, 28);
            label4.TabIndex = 8;
            label4.Text = "Quantity";
            label4.Click += label4_Click;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(430, 282);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(123, 44);
            btn_Save.TabIndex = 10;
            btn_Save.Text = "&Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.Location = new Point(292, 282);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(123, 44);
            btn_Clear.TabIndex = 11;
            btn_Clear.Text = "&Clear";
            btn_Clear.UseVisualStyleBackColor = true;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 630);
            Controls.Add(btn_Clear);
            Controls.Add(btn_Save);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textQuantity);
            Controls.Add(textPrice);
            Controls.Add(textProductName);
            Controls.Add(textProductCode);
            Controls.Add(dgvData);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmProduct";
            Load += FrmProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvData;
        private TextBox textProductCode;
        private TextBox textProductName;
        private TextBox textPrice;
        private TextBox textQuantity;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btn_Save;
        private Button btn_Clear;
    }
}