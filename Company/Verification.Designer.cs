namespace Company
{
    partial class Verification
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
            this.b_Yes = new System.Windows.Forms.Button();
            this.b_No = new System.Windows.Forms.Button();
            this.l_Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_Yes
            // 
            this.b_Yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Yes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_Yes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Yes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_Yes.ForeColor = System.Drawing.Color.White;
            this.b_Yes.Location = new System.Drawing.Point(12, 219);
            this.b_Yes.Name = "b_Yes";
            this.b_Yes.Size = new System.Drawing.Size(100, 30);
            this.b_Yes.TabIndex = 5;
            this.b_Yes.Text = "Yes";
            this.b_Yes.UseVisualStyleBackColor = false;
            this.b_Yes.Click += new System.EventHandler(this.b_Yes_Click);
            // 
            // b_No
            // 
            this.b_No.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_No.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_No.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_No.ForeColor = System.Drawing.Color.White;
            this.b_No.Location = new System.Drawing.Point(272, 219);
            this.b_No.Name = "b_No";
            this.b_No.Size = new System.Drawing.Size(100, 30);
            this.b_No.TabIndex = 6;
            this.b_No.Text = "No";
            this.b_No.UseVisualStyleBackColor = false;
            this.b_No.Click += new System.EventHandler(this.b_No_Click);
            // 
            // l_Message
            // 
            this.l_Message.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_Message.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Message.Location = new System.Drawing.Point(12, 9);
            this.l_Message.Name = "l_Message";
            this.l_Message.Size = new System.Drawing.Size(360, 207);
            this.l_Message.TabIndex = 7;
            this.l_Message.Text = "Enter database:";
            this.l_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Verification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.l_Message);
            this.Controls.Add(this.b_No);
            this.Controls.Add(this.b_Yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Verification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verification";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_Yes;
        private System.Windows.Forms.Button b_No;
        private System.Windows.Forms.Label l_Message;
    }
}