namespace THADotNetTrainingBatch1.WinFormsApp
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            textUsername = new TextBox();
            textPassword = new TextBox();
            btlCancel = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(56, 142, 60);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(314, 278);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(129, 41);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "&Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btlLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 56);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 28);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 165);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 2;
            label2.Text = "Passwrod:";
            // 
            // textUsername
            // 
            textUsername.Location = new Point(99, 88);
            textUsername.Margin = new Padding(4);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(379, 34);
            textUsername.TabIndex = 3;
            textUsername.TextChanged += textBox1_TextChanged;
            textUsername.KeyDown += textUsername_KeyDown;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(99, 197);
            textPassword.Margin = new Padding(4);
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(379, 34);
            textPassword.TabIndex = 4;
            textPassword.UseSystemPasswordChar = true;
            textPassword.TextChanged += textBox2_TextChanged;
            //textPassword.KeyDown += textPassword_KeyDown;
            // 
            // btlCancel
            // 
            btlCancel.BackColor = Color.FromArgb(69, 90, 100);
            btlCancel.FlatAppearance.BorderSize = 0;
            btlCancel.FlatStyle = FlatStyle.Flat;
            btlCancel.ForeColor = Color.White;
            btlCancel.Location = new Point(146, 278);
            btlCancel.Margin = new Padding(4);
            btlCancel.Name = "btlCancel";
            btlCancel.Size = new Size(129, 41);
            btlCancel.TabIndex = 5;
            btlCancel.Text = "&Cancel";
            btlCancel.UseVisualStyleBackColor = false;
            btlCancel.Click += btlCancel_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 364);
            Controls.Add(btlCancel);
            Controls.Add(textPassword);
            Controls.Add(textUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private Label label2;
        private TextBox textUsername;
        private TextBox textPassword;
        private Button btlCancel;
    }
}
