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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forgotpass));
            this.label1 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.txtconfirmpass = new System.Windows.Forms.TextBox();
            this.chkshow = new System.Windows.Forms.CheckBox();
            this.chkshow2 = new System.Windows.Forms.CheckBox();
            this.btnfpass = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Return = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forgot Password";
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("SF Compact Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.ForeColor = System.Drawing.Color.Gray;
            this.txtusername.Location = new System.Drawing.Point(71, 80);
            this.txtusername.Multiline = true;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(169, 25);
            this.txtusername.TabIndex = 4;
            this.txtusername.Text = "Username";
            this.txtusername.Enter += new System.EventHandler(this.txtusername_Enter);
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // txtnewpass
            // 
            this.txtnewpass.Font = new System.Drawing.Font("SF Compact Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewpass.ForeColor = System.Drawing.Color.Gray;
            this.txtnewpass.Location = new System.Drawing.Point(71, 126);
            this.txtnewpass.Multiline = true;
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.Size = new System.Drawing.Size(169, 25);
            this.txtnewpass.TabIndex = 5;
            this.txtnewpass.Text = "Password";
            this.txtnewpass.Enter += new System.EventHandler(this.txtnewpass_Enter);
            this.txtnewpass.Leave += new System.EventHandler(this.txtnewpass_Leave);
            // 
            // txtconfirmpass
            // 
            this.txtconfirmpass.Font = new System.Drawing.Font("SF Compact Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconfirmpass.ForeColor = System.Drawing.Color.Gray;
            this.txtconfirmpass.Location = new System.Drawing.Point(71, 170);
            this.txtconfirmpass.Multiline = true;
            this.txtconfirmpass.Name = "txtconfirmpass";
            this.txtconfirmpass.Size = new System.Drawing.Size(169, 25);
            this.txtconfirmpass.TabIndex = 6;
            this.txtconfirmpass.Text = "Confirm Password";
            this.txtconfirmpass.Enter += new System.EventHandler(this.txtconfirmpass_Enter);
            this.txtconfirmpass.Leave += new System.EventHandler(this.txtconfirmpass_Leave);
            // 
            // chkshow
            // 
            this.chkshow.AutoSize = true;
            this.chkshow.Location = new System.Drawing.Point(255, 134);
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
            this.chkshow2.Location = new System.Drawing.Point(255, 178);
            this.chkshow2.Name = "chkshow2";
            this.chkshow2.Size = new System.Drawing.Size(53, 17);
            this.chkshow2.TabIndex = 8;
            this.chkshow2.Text = "Show";
            this.chkshow2.UseVisualStyleBackColor = true;
            this.chkshow2.CheckedChanged += new System.EventHandler(this.chkshow2_CheckedChanged);
            // 
            // btnfpass
            // 
            this.btnfpass.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnfpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfpass.Location = new System.Drawing.Point(71, 239);
            this.btnfpass.Name = "btnfpass";
            this.btnfpass.Size = new System.Drawing.Size(169, 28);
            this.btnfpass.TabIndex = 9;
            this.btnfpass.Text = "Reset";
            this.btnfpass.UseVisualStyleBackColor = false;
            this.btnfpass.Click += new System.EventHandler(this.btnfpass_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(40, 170);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 25);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 24;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Finals.Properties.Resources.security_symbol_icon_icons_com_71572;
            this.pictureBox4.Location = new System.Drawing.Point(40, 126);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Finals.Properties.Resources.pngwing_com__1_;
            this.pictureBox3.Location = new System.Drawing.Point(40, 80);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // Return
            // 
            this.Return.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Return.Location = new System.Drawing.Point(71, 301);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(169, 28);
            this.Return.TabIndex = 25;
            this.Return.Text = "Return";
            this.Return.UseVisualStyleBackColor = false;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // forgotpass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 450);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnfpass);
            this.Controls.Add(this.chkshow2);
            this.Controls.Add(this.chkshow);
            this.Controls.Add(this.txtconfirmpass);
            this.Controls.Add(this.txtnewpass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "forgotpass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgotpass";
            this.Load += new System.EventHandler(this.forgotpass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtnewpass;
        private System.Windows.Forms.TextBox txtconfirmpass;
        private System.Windows.Forms.CheckBox chkshow;
        private System.Windows.Forms.CheckBox chkshow2;
        private System.Windows.Forms.Button btnfpass;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button Return;
    }
}