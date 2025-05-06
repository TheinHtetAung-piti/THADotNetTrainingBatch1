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
            btnUpdate = new Button();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colProductId = new DataGridViewTextBoxColumn();
            colProductCode = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colCreatedDateTime = new DataGridViewTextBoxColumn();
            colCreatedBy = new DataGridViewTextBoxColumn();
            colModifiedDateTime = new DataGridViewTextBoxColumn();
            colModifiedBy = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colProductId, colProductCode, colQuantity, colProductName, colPrice, colCreatedDateTime, colCreatedBy, colModifiedDateTime, colModifiedBy });
            dgvData.Dock = DockStyle.Bottom;
            dgvData.Location = new Point(0, 368);
            dgvData.Margin = new Padding(4);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(1100, 262);
            dgvData.TabIndex = 0;
            dgvData.CellContentClick += dgvData_CellContentClick;
            dgvData.KeyPress += textPrice_KeyPress;
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
            textProductCode.KeyDown += textProductCode_KeyDown;
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
            textProductName.KeyDown += textProductName_KeyDown;
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
            textPrice.KeyDown += textPrice_KeyDown;
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
            textQuantity.KeyDown += textQuantity_KeyDown;
            textQuantity.KeyPress += textPrice_KeyPress;
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
            btn_Save.BackColor = Color.FromArgb(56, 142, 60);
            btn_Save.ForeColor = Color.White;
            btn_Save.Location = new Point(430, 282);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(123, 44);
            btn_Save.TabIndex = 10;
            btn_Save.Text = "&Save";
            btn_Save.UseVisualStyleBackColor = false;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.BackColor = Color.FromArgb(69, 90, 100);
            btn_Clear.ForeColor = Color.White;
            btn_Clear.Location = new Point(292, 282);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(123, 44);
            btn_Clear.TabIndex = 11;
            btn_Clear.Text = "&Clear";
            btn_Clear.UseVisualStyleBackColor = false;
            btn_Clear.Click += btn_Clear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(56, 142, 60);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(430, 282);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(123, 44);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 6;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 125;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 125;
            // 
            // colProductId
            // 
            colProductId.DataPropertyName = "ProductId";
            colProductId.HeaderText = "ProductId";
            colProductId.MinimumWidth = 6;
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            colProductId.Width = 125;
            // 
            // colProductCode
            // 
            colProductCode.DataPropertyName = "ProductCode";
            colProductCode.HeaderText = "Product Code";
            colProductCode.MinimumWidth = 6;
            colProductCode.Name = "colProductCode";
            colProductCode.ReadOnly = true;
            colProductCode.Width = 125;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Width = 125;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "ProductName";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colProductName.Width = 125;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 125;
            // 
            // colCreatedDateTime
            // 
            colCreatedDateTime.DataPropertyName = "CreateDateTime";
            colCreatedDateTime.HeaderText = "CDT";
            colCreatedDateTime.MinimumWidth = 6;
            colCreatedDateTime.Name = "colCreatedDateTime";
            colCreatedDateTime.ReadOnly = true;
            colCreatedDateTime.Width = 125;
            // 
            // colCreatedBy
            // 
            colCreatedBy.DataPropertyName = "CreatedBy";
            colCreatedBy.HeaderText = "CB";
            colCreatedBy.MinimumWidth = 6;
            colCreatedBy.Name = "colCreatedBy";
            colCreatedBy.ReadOnly = true;
            colCreatedBy.Width = 125;
            // 
            // colModifiedDateTime
            // 
            colModifiedDateTime.DataPropertyName = "ModifiedDateTime";
            colModifiedDateTime.HeaderText = "MDT";
            colModifiedDateTime.MinimumWidth = 6;
            colModifiedDateTime.Name = "colModifiedDateTime";
            colModifiedDateTime.ReadOnly = true;
            colModifiedDateTime.Width = 125;
            // 
            // colModifiedBy
            // 
            colModifiedBy.DataPropertyName = "ModifiedBy";
            colModifiedBy.HeaderText = "MB";
            colModifiedBy.MinimumWidth = 6;
            colModifiedBy.Name = "colModifiedBy";
            colModifiedBy.ReadOnly = true;
            colModifiedBy.Width = 125;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 630);
            Controls.Add(btnUpdate);
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
            KeyPress += textPrice_KeyPress;
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
        private Button btnUpdate;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductCode;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colCreatedDateTime;
        private DataGridViewTextBoxColumn colCreatedBy;
        private DataGridViewTextBoxColumn colModifiedDateTime;
        private DataGridViewTextBoxColumn colModifiedBy;
    }
}