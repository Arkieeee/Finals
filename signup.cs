using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace Finals
{
    public partial class signup : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DOMINICPC\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        Thread tologin;
        public signup()
        {
            InitializeComponent();
        }
        public void gotologin(object obj)
        {
            Application.Run(new Form1());
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


        private void btnsignup_Click(object sender, EventArgs e)
        {
            var input = txtpassword.Text;


            if (input == "")
            {
                MessageBox.Show("Fields must filled.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtconfirm_password.Text == "")
            {
                MessageBox.Show("Must confirm password");
                return;
            }

            var hasnumber = new Regex(@"[0-9]+");
            var hasUpper = new Regex(@"[A-Z]+");
            var hasLower = new Regex(@"[a-z]+");
            var hasChar = new Regex(@"[!@#$%^&*()_,?/|+=]+");


            if (!hasnumber.IsMatch(input))
            {
                MessageBox.Show("Password must contain numeric!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!hasUpper.IsMatch(input))
            {
                MessageBox.Show("Password must contain one upper case", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!hasLower.IsMatch(input))
            {
                MessageBox.Show("Password must contain one lower case", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!hasChar.IsMatch(input))
            {
                MessageBox.Show("Password must contain one special character", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtpassword.Text.Length <= 7)
            {
                MessageBox.Show("Password must be 8 character or more long", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtconfirm_password.Text != txtpassword.Text)
            {
                MessageBox.Show("Password unmatched.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtconfirm_password.Text == txtpassword.Text)
            {
                SqlCommand CheckifExist = new SqlCommand();
                CheckifExist.CommandText = "Select * from [dbo].[NSDAP_user] where Username = '" + txtusername.Text + "'";
                CheckifExist.Parameters.AddWithValue("@username", txtusername.Text);
                CheckifExist.Connection = con;
                con.Open();
                SqlDataReader dt = CheckifExist.ExecuteReader();
                if (dt.HasRows)
                {
                    MessageBox.Show("Userame already existed!");

                }
                else if (txtusername.Text != "" && txtpassword.Text != "" && txtconfirm_password.Text != "")  //validating the fields whether the fields or empty or not  
                {
                    if (txtpassword.Text.ToString().Trim().ToLower() == txtconfirm_password.Text.ToString().Trim().ToLower()) //validating Password textbox and confirm password textbox is match or unmatch    
                    {

                        string Password = Encrypt(txtpassword.Text.ToString());   // Passing the Password to Encrypt method and the method will return encrypted string and stored in Password variable.  
                        con.Close();
                        con.Open();
                     
                        SqlCommand insert = new SqlCommand("insert into NSDAP_user(Name,Email,Username, Contact_Number, Address, Password)values('" +txtname.Text + "','" + txtemail.Text + "','" + txtusername.Text + "','" + txtcontact_number.Text + "','" + txtaddress.Text + "','" + Password + "')", con);
                        insert.ExecuteNonQuery();
                        con.Close();   
                        MessageBox.Show("Registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Please fill all the fields!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);  //showing the error message if any fields is empty  
                }


            }

        }

        private void chk_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_showpass.Checked == true)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            else
                txtpassword.UseSystemPasswordChar = true;
        }

        private void chk_showpass2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_showpass2.Checked == true)
            {
                txtconfirm_password.UseSystemPasswordChar = false;
            }
            else
                txtconfirm_password.UseSystemPasswordChar = true;
        }

        private void link_alreadyhaveanacc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Close();
            tologin = new Thread(gotologin);
            tologin.SetApartmentState(ApartmentState.STA);
            tologin.Start();
        }

    }
    }

