using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Finals
{
    //DKO KBAW MO GIT
    public partial class HomeUser : Form
    {
        private string _username;
        private decimal _balance;
    
        Thread th;

        public HomeUser(string username, decimal balance) // Accept username parameter in constructor
        {
            InitializeComponent();
            customizeDesign();
            _username = username; // Set _username to the passed parameter
            lblUser.Text = _username; // Set lblUser.Text to _username
            _balance = balance;
            lblBalance.Text = balance.ToString();

        }
        public void UpdateBalance(decimal newBalance)
        {
            _balance = newBalance;
            lblBalance.Text = _balance.ToString();
        }

        public void goToHome(Object obj)
        {
            Application.Run(new HomeUser(_username, _balance));
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
        private Form addpoloshirt = null;
        private Form addjacket = null;
        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            if (addtshirt == null || addtshirt.IsDisposed)
            {
                addtshirt = new tshirt(_username);
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
            if (addpoloshirt == null || addpoloshirt.IsDisposed)
            {
                addpoloshirt = new poloshirt(_username);
                addpoloshirt.FormClosed += (s, args) => addpoloshirt = null;
                openChildForm(addpoloshirt);
            }
            else
            {
                addpoloshirt.Close();
                addpoloshirt = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            if (addjacket == null || addjacket.IsDisposed)
            {
                addjacket = new jacket(_username);
                addjacket.FormClosed += (s, args) => addjacket = null;
                openChildForm(addjacket);
            }
            else
            {
                addjacket.Close();
                addjacket = null;
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

        private void sideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(goToHome);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private Form addtoCartForm = null;
        private void btn_cart_Click(object sender, EventArgs e)
        {
            if (addtoCartForm == null || addtoCartForm.IsDisposed)
            {
                addtoCartForm = new cart(_username, _balance, this);
                addtoCartForm.FormClosed += (s, args) => addtoCartForm = null;
                openChildForm(addtoCartForm);
            }
            else
            {
                addtoCartForm.Close();
                addtoCartForm = null;
            }
        }
        private Form ordersForm = null;
        private void button4_Click(object sender, EventArgs e)
        {
            if (ordersForm == null || ordersForm.IsDisposed)
            {
                ordersForm = new orders(_username);
                ordersForm.FormClosed += (s, args) => ordersForm = null;
                openChildForm(ordersForm);
            }
            else
            {
                ordersForm.Close();
                ordersForm = null;
            }
        }
        private CashIn cashinform = null;
        private void btncashin_Click(object sender, EventArgs e)
        {
            if (cashinform == null || cashinform.IsDisposed)
            {
                cashinform = new CashIn(_username, _balance, this);
                cashinform.FormClosed += (s, args) => cashinform = null;
                openChildForm(cashinform);
            }
            else
            {
                cashinform.Close();
                cashinform = null;
            }
        }
    }
}