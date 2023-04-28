using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class forgotpass : Form
    {
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        public forgotpass()
        {
            InitializeComponent();
        }

        private void forgotpass_Load(object sender, EventArgs e)
        {

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
   
        private void chkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow.Checked == true)
            {
                txtnewpass.UseSystemPasswordChar = false;
            }
            else
                txtnewpass.UseSystemPasswordChar = true;
        }

        private void chkshow2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkshow2.Checked == true)
            {
                txtconfirmpass.UseSystemPasswordChar = false;
            }
            else
                txtconfirmpass.UseSystemPasswordChar = true;
        }

        private void btnfpass_Click(object sender, EventArgs e)
        {

            if (txtusername.Text == "" && txtnewpass.Text == "" && txtconfirmpass.Text == "")
            {
                MessageBox.Show("Fields must be filled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var input = txtnewpass.Text;

            if (input == "")
            {
                MessageBox.Show("Password required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hasnumber = new Regex(@"[0-9]+");
            var hasUpper = new Regex(@"[A-Z]+");
            var hasLower = new Regex(@"[a-z]+");
            var hasChar = new Regex(@"[!@#$%^&*()_,?/|+=]+");


            if (!hasnumber.IsMatch(input))
            {
                MessageBox.Show("Password must contain numeric", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!hasUpper.IsMatch(input))
            {
                MessageBox.Show("Password must contain upper case", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!hasLower.IsMatch(input))
            {
                MessageBox.Show("Password must contain lower case", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!hasChar.IsMatch(input))
            {
                MessageBox.Show("Password must contain special character", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtnewpass.Text.Length <= 7)
            {
                MessageBox.Show("Password must 8 character long", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtconfirmpass.Text != txtnewpass.Text)
            {
                MessageBox.Show("Password unmatched", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (txtconfirmpass.Text == txtnewpass.Text)
            {
                SqlConnection con = new SqlConnection("Data Source=DOMINICPC\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
                SqlCommand CheckifExist = new SqlCommand();
                CheckifExist.CommandText = "Select * from [dbo].[NSDAP_user] where Username = @Username";
                CheckifExist.Parameters.AddWithValue("@Username", txtusername.Text);
                CheckifExist.Connection = con;
                con.Open();
                SqlDataReader dt = CheckifExist.ExecuteReader();

                if (txtusername.Text == "" && txtnewpass.Text == "" && txtconfirmpass.Text == "")
                {
                    MessageBox.Show("Fields must be filled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!dt.HasRows)
                {
                    MessageBox.Show("User not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dt.HasRows)
                {
                    dt.Close(); // Close the SqlDataReader before executing the update query
                    SqlCommand changePassword = new SqlCommand("UPDATE [dbo].[NSDAP_user] SET [Password] = @newpassword WHERE [Username] = @Username", con);
                    changePassword.Parameters.AddWithValue("@newpassword", Encrypt(txtnewpass.Text));
                    changePassword.Parameters.AddWithValue("@Username", txtusername.Text);
                    changePassword.ExecuteNonQuery();
                    con.Close();

                    if (txtconfirmpass.Text != txtnewpass.Text)
                    {
                        MessageBox.Show("Password does not match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Password Successfully Changed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
