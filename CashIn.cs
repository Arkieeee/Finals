using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Finals
{
    public partial class CashIn : Form
    {
        private string _username;
        private decimal _balance;
        private HomeUser _homeUserForm;
        public CashIn(string username, decimal balance, HomeUser homeUserForm)
        {
            InitializeComponent();
            _username = username;
            _balance = balance; // Set _balance to the passed parameter
            _homeUserForm = homeUserForm; // Set _homeUserForm to the passed parameter
        }
        SqlConnection con = new SqlConnection("Data Source=ARKI\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");

        private void btncashin_Click(object sender, EventArgs e)
        {
            // Show a message box to confirm cash in
            DialogResult result = MessageBox.Show("Are you sure to Cash In?", "Confirm Cash In", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Proceed with cash in only if the user clicked "Yes" on the message box
            if (result == DialogResult.Yes)
            {
                Decimal cashInAmount = Convert.ToDecimal(txtcashin.Text);

                // Update the balance in the database
                SqlCommand Checkifexist = new SqlCommand();
                Checkifexist.CommandText = "INSERT into Balance (Username, Balance) values (@username, @balance)";
                Checkifexist.Parameters.AddWithValue("@username", _username);
                Checkifexist.Parameters.AddWithValue("@balance", cashInAmount);
                Checkifexist.Connection = con;
                con.Open();
                Checkifexist.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Successfully Cashed In", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SqlCommand UpdateBalance = new SqlCommand("Update Balance Set Balance = Balance + '"+cashInAmount+"' WHERE username = '"+_username+"'",con);
                con.Open();
                UpdateBalance.ExecuteNonQuery();
                con.Close();

                // Update the balance in the HomeUser form
                _balance += cashInAmount;
                _homeUserForm.UpdateBalance(_balance);
            }
            
        }


    }
}
