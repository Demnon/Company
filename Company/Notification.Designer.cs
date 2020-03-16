namespace Company
{
    partial class Notification
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
            this.l_Message = new System.Windows.Forms.Label();
            this.b_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_Message
            // 
            this.l_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Message.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_Message.Location = new System.Drawing.Point(0, 0);
            this.l_Message.Name = "l_Message";
            this.l_Message.Size = new System.Drawing.Size(284, 116);
            this.l_Message.TabIndex = 0;
            this.l_Message.Text = "label1";
            this.l_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // b_OK
            // 
            this.b_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_OK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_OK.ForeColor = System.Drawing.Color.White;
            this.b_OK.Location = new System.Drawing.Point(105, 119);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 30);
            this.b_OK.TabIndex = 1;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = false;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // OK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.ControlBox = false;
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.l_Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notification";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l_Message;
        private System.Windows.Forms.Button b_OK;
    }
}