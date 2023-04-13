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
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HU6DH7\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        Thread signup;
        Thread Admin;
        Thread User;
        public Form1()
        {
            InitializeComponent();
        }

        public void gotohome_user(object obj)
        {
            Application.Run(new Home_User());
        }

        public void gotohome_admin(object obj)
        {
            Application.Run(new Home_Admin());
        }

        public void goto_signup(object obj)
        {
            Application.Run(new signup());
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
            Checkifexist.CommandText = "SELECT * FROM NSDAP_user WHERE Username = '" + txtusername.Text + "' and Password = '" + Encrypt(txtpassword.Text) + "'";
            Checkifexist.Parameters.AddWithValue("@Username", txtusername.Text);
            Checkifexist.Parameters.AddWithValue("@Password", Encrypt(txtpassword.Text));

            Checkifexist.Connection = con;
            con.Open();
            SqlDataReader dt = Checkifexist.ExecuteReader();
            if(txtusername.Text == "" && txtpassword.Text == "")
            {
             MessageBox.Show("Username and password must be filled", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(!dt.HasRows)
            {
                MessageBox.Show("Username or password incorrect", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dt.HasRows)
            {
                if (txtusername.Text == "Admin")
                {
                    MessageBox.Show("Welcome, "+ txtusername.Text, "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Admin = new Thread(gotohome_admin);
                    Admin.SetApartmentState(ApartmentState.STA);
                    Admin.Start();
                }
                else
                {
                    MessageBox.Show("Welcome, " + txtusername.Text, "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    User= new Thread(gotohome_user);
                    User.SetApartmentState(ApartmentState.STA);
                    User.Start();
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
    }
}
