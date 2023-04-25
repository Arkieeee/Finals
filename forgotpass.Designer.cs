namespace Finals
{
    partial class forgotpass
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.txtconfirmpass = new System.Windows.Forms.TextBox();
            this.chkshow = new System.Windows.Forms.CheckBox();
            this.chkshow2 = new System.Windows.Forms.CheckBox();
            this.btnfpass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forgot Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm Password";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(133, 85);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(149, 20);
            this.txtusername.TabIndex = 4;
            // 
            // txtnewpass
            // 
            this.txtnewpass.Location = new System.Drawing.Point(133, 126);
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.Size = new System.Drawing.Size(149, 20);
            this.txtnewpass.TabIndex = 5;
            // 
            // txtconfirmpass
            // 
            this.txtconfirmpass.Location = new System.Drawing.Point(133, 170);
            this.txtconfirmpass.Name = "txtconfirmpass";
            this.txtconfirmpass.Size = new System.Drawing.Size(149, 20);
            this.txtconfirmpass.TabIndex = 6;
            // 
            // chkshow
            // 
            this.chkshow.AutoSize = true;
            this.chkshow.Location = new System.Drawing.Point(229, 153);
            this.chkshow.Name = "chkshow";
            this.chkshow.Size = new System.Drawing.Size(53, 17);
            this.chkshow.TabIndex = 7;
            this.chkshow.Text = "Show";
            this.chkshow.UseVisualStyleBackColor = true;
            this.chkshow.CheckedChanged += new System.EventHandler(this.chkshow_CheckedChanged);
            // 
            // chkshow2
            // 
            this.chkshow2.AutoSize = true;
            this.chkshow2.Location = new System.Drawing.Point(229, 196);
            this.chkshow2.Name = "chkshow2";
            this.chkshow2.Size = new System.Drawing.Size(53, 17);
            this.chkshow2.TabIndex = 8;
            this.chkshow2.Text = "Show";
            this.chkshow2.UseVisualStyleBackColor = true;
            this.chkshow2.CheckedChanged += new System.EventHandler(this.chkshow2_CheckedChanged);
            // 
            // btnfpass
            // 
            this.btnfpass.Location = new System.Drawing.Point(213, 239);
            this.btnfpass.Name = "btnfpass";
            this.btnfpass.Size = new System.Drawing.Size(75, 23);
            this.btnfpass.TabIndex = 9;
            this.btnfpass.Text = "Reset";
            this.btnfpass.UseVisualStyleBackColor = true;
            this.btnfpass.Click += new System.EventHandler(this.btnfpass_Click);
            // 
            // forgotpass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnfpass);
            this.Controls.Add(this.chkshow2);
            this.Controls.Add(this.chkshow);
            this.Controls.Add(this.txtconfirmpass);
            this.Controls.Add(this.txtnewpass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "forgotpass";
            this.Text = "forgotpass";
            this.Load += new System.EventHandler(this.forgotpass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtnewpass;
        private System.Windows.Forms.TextBox txtconfirmpass;
        private System.Windows.Forms.CheckBox chkshow;
        private System.Windows.Forms.CheckBox chkshow2;
        private System.Windows.Forms.Button btnfpass;
    }
}