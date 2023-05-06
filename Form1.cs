using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace Finals
{
    public partial class Form1 : Form
    {
       
        Thread signup;
        
        Thread User;
        Thread fpass;
        public Form1()
        {
            InitializeComponent();
            txtusername.Enter += new EventHandler(txtusername_Enter);
            txtusername.Leave += new EventHandler(txtusername_Leave);
        }
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        public string Username
        {
            get { return txtusername.Text; }
            set { txtusername.Text = value; }
        }

        public void gotohome_user(object obj)
        {
            decimal balance = 0; // Set a default balance of 0
            HomeUser homeUser = new HomeUser(Username, balance);
            Application.Run(homeUser);
        }

        public void gotohome_admin(object obj)
        {
            Application.Run(new Home_Admin(Username));
        }

        public void goto_signup(object obj)
        {
            Application.Run(new signup());
        }
        public void forgotpassword(object obj)
        {
            Application.Run(new forgotpass());
        }
        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlCommand Checkifexist = new SqlCommand();
            Checkifexist.CommandText = "SELECT * FROM NSDAP_user WHERE Username = @Username";
            Checkifexist.Parameters.AddWithValue("@Username", txtusername.Text);
            Checkifexist.Connection = con;

            con.Open();
            SqlDataReader dt = Checkifexist.ExecuteReader();

            if (txtusername.Text == "" && txtpassword.Text == "")
            {
                MessageBox.Show("Username and password must be filled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else if (!dt.HasRows)
            {
                MessageBox.Show("Username or password incorrect", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else if (dt.HasRows)
            {
                dt.Read();
                string passwordFromDB = dt["Password"].ToString();
                con.Close();

                if (txtusername.Text == "Admin" && Encrypt(txtpassword.Text) == passwordFromDB)
                {
                    MessageBox.Show("Success! Welcome: " + txtusername.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                    Home_Admin home_Admin = new Home_Admin(txtusername.Text); // Pass txtusername.Text to the constructor
                    this.Hide(); // Hide the current form
                    home_Admin.Show(); // Show the Home_Admin form
                }
                else if (Encrypt(txtpassword.Text) == passwordFromDB)
                {
                    con.Close(); // Close the connection before opening a new one

                    SqlCommand getBalance = new SqlCommand();
                    getBalance.CommandText = "SELECT Balance FROM Balance WHERE Username = @Username";
                    getBalance.Parameters.AddWithValue("@Username", txtusername.Text);
                    getBalance.Connection = con;

                    con.Open();
                    SqlDataReader balanceReader = getBalance.ExecuteReader();
                    if (balanceReader.Read())
                    {
                        decimal balance = Convert.ToDecimal(balanceReader[0]);

                        // Show the HomeUser form with the balance value passed to the constructor
                        MessageBox.Show("Success! Welcome user: " + txtusername.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        balanceReader.Close(); // Close the SqlDataReader object before executing the next one

                        HomeUser homeUser = new HomeUser(txtusername.Text, balance);
                        this.Hide();
                        homeUser.Show();
                    }

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
            }
        

    }
    private void btnsingup_Click(object sender, EventArgs e)
        {
            this.Close();
            signup = new Thread(goto_signup);
            signup.SetApartmentState(ApartmentState.STA);
            signup.Start();
        }

        private void lbl_clear_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";

        }

        private void chkshow_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow_pass.Checked == true)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            else
                txtpassword.UseSystemPasswordChar = true;
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = "";
                txtusername.ForeColor = Color.Black; // Set the text color back to black for regular input
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                txtusername.Text = "Username";
                txtusername.ForeColor = Color.Silver; // Set the text color back to black for regular input
            }
        }
        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                txtpassword.UseSystemPasswordChar = false;
                txtpassword.Text = "Password";
                txtpassword.ForeColor = Color.Gray;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Text = "";
                txtpassword.UseSystemPasswordChar = true;
                txtpassword.ForeColor = Color.Black; // Set the text color back to black for regular input
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            fpass = new Thread(forgotpassword);
            fpass.SetApartmentState(ApartmentState.STA);
            fpass.Start();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
