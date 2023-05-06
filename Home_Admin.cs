using System;
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
    public partial class Home_Admin : Form
    {
        private string _username;
        public Home_Admin(string username)
        {
            InitializeComponent();
            customizeDesign();
            _username = username; // Set _username to the passed parameter
            lblUser.Text = _username; // Set lblUser.Text to _username
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private void customizeDesign()
        { 
            panel1.Visible = false;
            panel2.Visible = false;
        
        }

        private void hideSubMenu()
        { 
            if(panel1.Visible == true)
                panel1.Visible=false;
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
        private Form addItemsForm = null;
        private void add_item_Click(object sender, EventArgs e)
        {
            if (addItemsForm == null || addItemsForm.IsDisposed)
            {
                addItemsForm = new addItems();
                addItemsForm.FormClosed += (s, args) => addItemsForm = null;
                openChildForm(addItemsForm);
            }
            else
            {
                addItemsForm.Close();
                addItemsForm = null;
            }

        }

        private void addPolo_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void addJacket_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private Form Transactions= null;
        private void transac_Click(object sender, EventArgs e)
        {
            if (Transactions == null || Transactions.IsDisposed)
            {
                Transactions = new Transactions();
                Transactions.FormClosed += (s, args) => Transactions = null;
                openChildForm(Transactions);
            }
            else
            {
                Transactions.Close();
                Transactions = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_about_Click(object sender, EventArgs e)
        {

        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
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
