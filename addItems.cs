using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class addItems : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9HU6DH7\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        string imgLoc = "";
        public addItems()
        {
            InitializeComponent();
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|ALL Files (*.*)|*.*";
                dlg.Title = "Select an Image";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picEmp.ImageLocation = imgLoc;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {


                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                int quantity = Convert.ToInt32(txtquantity.Text);

                SqlCommand insertToProducts = new SqlCommand("INSERT INTO Products (Name, Quantity, Description, Size, Price, Image_apparel) VALUES (@name, @quantity, @description, @size, @price, @img)", con);

                insertToProducts.Parameters.AddWithValue("@name", txtname.Text);
                insertToProducts.Parameters.AddWithValue("@quantity", quantity);
                insertToProducts.Parameters.AddWithValue("@description", lbldescription.Text);
                insertToProducts.Parameters.AddWithValue("@size", txtsize.Text);
                insertToProducts.Parameters.AddWithValue("@price", Double.Parse(txtprice.Text));
                insertToProducts.Parameters.AddWithValue("@img", img);

                con.Open();
                insertToProducts.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Product successfully inserted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
            }


        }
    }
  

