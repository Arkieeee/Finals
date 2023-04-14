namespace Finals
{
    partial class Home_Admin
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
            this.sideMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.add_item = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addShirt = new System.Windows.Forms.Button();
            this.addPolo = new System.Windows.Forms.Button();
            this.addJacket = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.transac = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sideMenu
            // 
            this.sideMenu.BackColor = System.Drawing.Color.Black;
            this.sideMenu.Controls.Add(this.btn_about);
            this.sideMenu.Controls.Add(this.panel2);
            this.sideMenu.Controls.Add(this.transac);
            this.sideMenu.Controls.Add(this.panel1);
            this.sideMenu.Controls.Add(this.add_item);
            this.sideMenu.Controls.Add(this.panelLogo);
            this.sideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.sideMenu.Location = new System.Drawing.Point(0, 0);
            this.sideMenu.Name = "sideMenu";
            this.sideMenu.Size = new System.Drawing.Size(189, 401);
            this.sideMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(189, 70);
            this.panelLogo.TabIndex = 0;
            // 
            // add_item
            // 
            this.add_item.Dock = System.Windows.Forms.DockStyle.Top;
            this.add_item.FlatAppearance.BorderSize = 0;
            this.add_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_item.ForeColor = System.Drawing.Color.Gainsboro;
            this.add_item.Location = new System.Drawing.Point(0, 70);
            this.add_item.Name = "add_item";
            this.add_item.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.add_item.Size = new System.Drawing.Size(189, 25);
            this.add_item.TabIndex = 1;
            this.add_item.Text = "Add Items";
            this.add_item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_item.UseVisualStyleBackColor = true;
            this.add_item.Click += new System.EventHandler(this.add_item_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.addJacket);
            this.panel1.Controls.Add(this.addPolo);
            this.panel1.Controls.Add(this.addShirt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 82);
            this.panel1.TabIndex = 2;
            // 
            // addShirt
            // 
            this.addShirt.Dock = System.Windows.Forms.DockStyle.Top;
            this.addShirt.FlatAppearance.BorderSize = 0;
            this.addShirt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.addShirt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addShirt.ForeColor = System.Drawing.Color.LightGray;
            this.addShirt.Location = new System.Drawing.Point(0, 0);
            this.addShirt.Name = "addShirt";
            this.addShirt.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.addShirt.Size = new System.Drawing.Size(189, 25);
            this.addShirt.TabIndex = 0;
            this.addShirt.Text = "T-Shirt";
            this.addShirt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addShirt.UseVisualStyleBackColor = true;
            this.addShirt.Click += new System.EventHandler(this.button2_Click);
            // 
            // addPolo
            // 
            this.addPolo.Dock = System.Windows.Forms.DockStyle.Top;
            this.addPolo.FlatAppearance.BorderSize = 0;
            this.addPolo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.addPolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPolo.ForeColor = System.Drawing.Color.LightGray;
            this.addPolo.Location = new System.Drawing.Point(0, 25);
            this.addPolo.Name = "addPolo";
            this.addPolo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.addPolo.Size = new System.Drawing.Size(189, 25);
            this.addPolo.TabIndex = 1;
            this.addPolo.Text = "Polo-Shirt";
            this.addPolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addPolo.UseVisualStyleBackColor = true;
            this.addPolo.Click += new System.EventHandler(this.addPolo_Click);
            // 
            // addJacket
            // 
            this.addJacket.Dock = System.Windows.Forms.DockStyle.Top;
            this.addJacket.FlatAppearance.BorderSize = 0;
            this.addJacket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.addJacket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addJacket.ForeColor = System.Drawing.Color.LightGray;
            this.addJacket.Location = new System.Drawing.Point(0, 50);
            this.addJacket.Name = "addJacket";
            this.addJacket.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.addJacket.Size = new System.Drawing.Size(189, 29);
            this.addJacket.TabIndex = 2;
            this.addJacket.Text = "Jacket";
            this.addJacket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addJacket.UseVisualStyleBackColor = true;
            this.addJacket.Click += new System.EventHandler(this.addJacket_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(0, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 82);
            this.panel2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(0, 50);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(189, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Jacket";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(0, 25);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(189, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "Polo-Shirt";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.LightGray;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(189, 25);
            this.button3.TabIndex = 0;
            this.button3.Text = "T-Shirt";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // transac
            // 
            this.transac.Dock = System.Windows.Forms.DockStyle.Top;
            this.transac.FlatAppearance.BorderSize = 0;
            this.transac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transac.ForeColor = System.Drawing.Color.Gainsboro;
            this.transac.Location = new System.Drawing.Point(0, 177);
            this.transac.Name = "transac";
            this.transac.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.transac.Size = new System.Drawing.Size(189, 25);
            this.transac.TabIndex = 4;
            this.transac.Text = "Transactions";
            this.transac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.transac.UseVisualStyleBackColor = true;
            this.transac.Click += new System.EventHandler(this.transac_Click);
            // 
            // btn_about
            // 
            this.btn_about.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_about.FlatAppearance.BorderSize = 0;
            this.btn_about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_about.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_about.Location = new System.Drawing.Point(0, 284);
            this.btn_about.Name = "btn_about";
            this.btn_about.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_about.Size = new System.Drawing.Size(189, 25);
            this.btn_about.TabIndex = 7;
            this.btn_about.Text = "About";
            this.btn_about.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_about.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Finals.Properties.Resources.my_profile_icon_png_15;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(68, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ni ari";
            // 
            // Home_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 401);
            this.Controls.Add(this.sideMenu);
            this.Font = new System.Drawing.Font("SF Compact Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "Home_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home_Admin";
            this.sideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addJacket;
        private System.Windows.Forms.Button addPolo;
        private System.Windows.Forms.Button addShirt;
        private System.Windows.Forms.Button add_item;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button transac;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}