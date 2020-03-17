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
            this.b_OK = new System.Windows.Forms.Button();
            this.t_Message = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // b_OK
            // 
            this.b_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(209)))));
            this.b_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_OK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_OK.ForeColor = System.Drawing.Color.White;
            this.b_OK.Location = new System.Drawing.Point(154, 219);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(75, 30);
            this.b_OK.TabIndex = 1;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = false;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // t_Message
            // 
            this.t_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.t_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t_Message.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.t_Message.Location = new System.Drawing.Point(12, 12);
            this.t_Message.Multiline = true;
            this.t_Message.Name = "t_Message";
            this.t_Message.ReadOnly = true;
            this.t_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.t_Message.Size = new System.Drawing.Size(360, 201);
            this.t_Message.TabIndex = 2;
            this.t_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(241)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.ControlBox = false;
            this.Controls.Add(this.t_Message);
            this.Controls.Add(this.b_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_OK;
        private System.Windows.Forms.TextBox t_Message;
    }
}