namespace Company
{
    partial class DataConnection
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.l_Server = new System.Windows.Forms.Label();
            this.l_Authentication = new System.Windows.Forms.Label();
            this.l_Username = new System.Windows.Forms.Label();
            this.l_Password = new System.Windows.Forms.Label();
            this.b_OK = new System.Windows.Forms.Button();
            this.b_Cancel = new System.Windows.Forms.Button();
            this.t_DataSource = new System.Windows.Forms.TextBox();
            this.t_Username = new System.Windows.Forms.TextBox();
            this.c_Authentication = new System.Windows.Forms.ComboBox();
            this.mt_Password = new System.Windows.Forms.MaskedTextBox();
            this.t_Database = new System.Windows.Forms.TextBox();
            this.l_Database = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.l_Database, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.t_Database, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.l_Server, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.t_DataSource, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.b_OK, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.b_Cancel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.l_Password, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.mt_Password, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.t_Username, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.l_Username, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.l_Authentication, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.c_Authentication, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66887F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // l_Server
            // 
            this.l_Server.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_Server.AutoSize = true;
            this.l_Server.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Server.Location = new System.Drawing.Point(34, 12);
            this.l_Server.Name = "l_Server";
            this.l_Server.Size = new System.Drawing.Size(85, 19);
            this.l_Server.TabIndex = 0;
            this.l_Server.Text = "Enter server:";
            this.l_Server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Authentication
            // 
            this.l_Authentication.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_Authentication.AutoSize = true;
            this.l_Authentication.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Authentication.Location = new System.Drawing.Point(27, 98);
            this.l_Authentication.Name = "l_Authentication";
            this.l_Authentication.Size = new System.Drawing.Size(98, 19);
            this.l_Authentication.TabIndex = 1;
            this.l_Authentication.Text = "Authentication:";
            this.l_Authentication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Username
            // 
            this.l_Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_Username.AutoSize = true;
            this.l_Username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Username.Location = new System.Drawing.Point(24, 141);
            this.l_Username.Name = "l_Username";
            this.l_Username.Size = new System.Drawing.Size(105, 19);
            this.l_Username.TabIndex = 2;
            this.l_Username.Text = "Enter username:";
            this.l_Username.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Password
            // 
            this.l_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_Password.AutoSize = true;
            this.l_Password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Password.Location = new System.Drawing.Point(23, 184);
            this.l_Password.Name = "l_Password";
            this.l_Password.Size = new System.Drawing.Size(107, 19);
            this.l_Password.TabIndex = 3;
            this.l_Password.Text = "Enter password:";
            this.l_Password.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_OK
            // 
            this.b_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_OK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_OK.ForeColor = System.Drawing.Color.White;
            this.b_OK.Location = new System.Drawing.Point(3, 228);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(100, 30);
            this.b_OK.TabIndex = 4;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = false;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // b_Cancel
            // 
            this.b_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Cancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_Cancel.ForeColor = System.Drawing.Color.White;
            this.b_Cancel.Location = new System.Drawing.Point(281, 228);
            this.b_Cancel.Name = "b_Cancel";
            this.b_Cancel.Size = new System.Drawing.Size(100, 30);
            this.b_Cancel.TabIndex = 5;
            this.b_Cancel.Text = "Cancel";
            this.b_Cancel.UseVisualStyleBackColor = false;
            this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
            // 
            // t_DataSource
            // 
            this.t_DataSource.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.t_DataSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.t_DataSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.t_DataSource.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_DataSource.Location = new System.Drawing.Point(178, 8);
            this.t_DataSource.Name = "t_DataSource";
            this.t_DataSource.Size = new System.Drawing.Size(180, 26);
            this.t_DataSource.TabIndex = 6;
            this.t_DataSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t_Username
            // 
            this.t_Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.t_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.t_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.t_Username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_Username.Location = new System.Drawing.Point(178, 137);
            this.t_Username.Name = "t_Username";
            this.t_Username.Size = new System.Drawing.Size(180, 26);
            this.t_Username.TabIndex = 7;
            this.t_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // c_Authentication
            // 
            this.c_Authentication.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.c_Authentication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.c_Authentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_Authentication.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.c_Authentication.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.c_Authentication.ForeColor = System.Drawing.Color.Black;
            this.c_Authentication.FormattingEnabled = true;
            this.c_Authentication.Items.AddRange(new object[] {
            "Authentication Windows",
            "Authentication SQL Server"});
            this.c_Authentication.Location = new System.Drawing.Point(178, 94);
            this.c_Authentication.Name = "c_Authentication";
            this.c_Authentication.Size = new System.Drawing.Size(180, 27);
            this.c_Authentication.TabIndex = 11;
            this.c_Authentication.SelectedIndexChanged += new System.EventHandler(this.c_Authentication_SelectedIndexChanged);
            // 
            // mt_Password
            // 
            this.mt_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mt_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.mt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mt_Password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mt_Password.Location = new System.Drawing.Point(178, 180);
            this.mt_Password.Name = "mt_Password";
            this.mt_Password.PasswordChar = '*';
            this.mt_Password.Size = new System.Drawing.Size(180, 26);
            this.mt_Password.TabIndex = 12;
            this.mt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // t_Database
            // 
            this.t_Database.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.t_Database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(236)))), ((int)(((byte)(250)))));
            this.t_Database.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.t_Database.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_Database.Location = new System.Drawing.Point(178, 51);
            this.t_Database.Name = "t_Database";
            this.t_Database.Size = new System.Drawing.Size(180, 26);
            this.t_Database.TabIndex = 7;
            this.t_Database.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_Database
            // 
            this.l_Database.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_Database.AutoSize = true;
            this.l_Database.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Database.Location = new System.Drawing.Point(25, 55);
            this.l_Database.Name = "l_Database";
            this.l_Database.Size = new System.Drawing.Size(102, 19);
            this.l_Database.TabIndex = 2;
            this.l_Database.Text = "Enter database:";
            this.l_Database.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data to connect";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label l_Server;
        private System.Windows.Forms.Label l_Authentication;
        private System.Windows.Forms.Label l_Username;
        private System.Windows.Forms.Label l_Password;
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.Button b_Cancel;
        private System.Windows.Forms.TextBox t_DataSource;
        private System.Windows.Forms.TextBox t_Username;
        private System.Windows.Forms.ComboBox c_Authentication;
        private System.Windows.Forms.MaskedTextBox mt_Password;
        private System.Windows.Forms.Label l_Database;
        private System.Windows.Forms.TextBox t_Database;
    }
}