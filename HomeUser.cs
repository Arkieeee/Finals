﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class HomeUser : Form
    {
        public HomeUser()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void HomeUser_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void transac_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }
        private void customizeDesign()
        {

            panel2.Visible = false;

        }

        private void hideSubMenu()
        {

            if (panel2.Visible == true)
                panel2.Visible = false;
        }

        private void showSubMenu(Panel panel1)
        {
            if (panel1.Visible == false)
            {
                hideSubMenu();
                panel1.Visible = true;
            }
            else
                panel1.Visible = false;
        }
        private Form addtshirt = null;
        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            if (addtshirt == null || addtshirt.IsDisposed)
            {
                addtshirt = new tshirt();
                addtshirt.FormClosed += (s, args) => addtshirt = null;
                openChildForm(addtshirt);
            }
            else
            {
                addtshirt.Close();
                addtshirt = null;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            if (addtshirt == null || addtshirt.IsDisposed)
            {
                addtshirt = new poloshirt();
                addtshirt.FormClosed += (s, args) => addtshirt = null;
                openChildForm(addtshirt);
            }
            else
            {
                addtshirt.Close();
                addtshirt = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            if (addtshirt == null || addtshirt.IsDisposed)
            {
                addtshirt = new jacket();
                addtshirt.FormClosed += (s, args) => addtshirt = null;
                openChildForm(addtshirt);
            }
            else
            {
                addtshirt.Close();
                addtshirt = null;
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm == childForm)
            {
                // The child form is already open, so bring it to the front
                childForm.BringToFront();
            }
            else
            {
                // The child form is not open yet, so add it to the panel
                if (activeForm != null)
                {
                    activeForm.Close();
                }
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelMain.Controls.Add(childForm);
                panelMain.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }


    }
}
