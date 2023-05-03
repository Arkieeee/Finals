namespace Finals
{
    partial class CashIn
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
            this.lblcashin = new System.Windows.Forms.Label();
            this.txtcashin = new System.Windows.Forms.TextBox();
            this.btncashin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblcashin
            // 
            this.lblcashin.AutoSize = true;
            this.lblcashin.Location = new System.Drawing.Point(12, 73);
            this.lblcashin.Name = "lblcashin";
            this.lblcashin.Size = new System.Drawing.Size(187, 20);
            this.lblcashin.TabIndex = 0;
            this.lblcashin.Text = "Enter amount to Top Up";
            // 
            // txtcashin
            // 
            this.txtcashin.Location = new System.Drawing.Point(217, 70);
            this.txtcashin.Name = "txtcashin";
            this.txtcashin.Size = new System.Drawing.Size(248, 26);
            this.txtcashin.TabIndex = 1;
            // 
            // btncashin
            // 
            this.btncashin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncashin.Location = new System.Drawing.Point(190, 197);
            this.btncashin.Name = "btncashin";
            this.btncashin.Size = new System.Drawing.Size(140, 34);
            this.btncashin.TabIndex = 2;
            this.btncashin.Text = "Cash In";
            this.btncashin.UseVisualStyleBackColor = true;
            this.btncashin.Click += new System.EventHandler(this.btncashin_Click);
            // 
            // CashIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(508, 441);
            this.Controls.Add(this.btncashin);
            this.Controls.Add(this.txtcashin);
            this.Controls.Add(this.lblcashin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CashIn";
            this.Text = "CashIn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcashin;
        private System.Windows.Forms.TextBox txtcashin;
        private System.Windows.Forms.Button btncashin;
    }
}