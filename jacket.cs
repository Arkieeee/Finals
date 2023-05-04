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

namespace Finals
{
    public partial class jacket : Form
    {
        private string _username;
        private int ProductId; // declare as class-level variable
        public jacket(string username)
        {

            InitializeComponent();
            _username = username; // Set _username to the passed parameter
        }

        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        private void loadDatagrid()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select Image_apparel, Name, Quantity, Price, Product_ID from Products where Category ='Jacket'", con);
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();
            adap.Fill(tab);
            dataGridView1.DataSource = tab;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Set the font color to black
            con.Close();
        }


        private void jacket_Load(object sender, EventArgs e)
        {

            loadDatagrid();
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            lblName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            Label_Price.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            ProductId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Product_ID"].Value.ToString());
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            int quantity = 0;

            try
            {
                // Use parameterized queries to avoid SQL injection attacks
                using (SqlCommand com = new SqlCommand("SELECT Quantity FROM Products WHERE Product_ID = @productId", con))
                {
                    com.Parameters.AddWithValue("@productId", ProductId);
                    con.Open();

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            quantity = reader.GetInt32(0);
                        }
                    }
                }

                if (quantity <= 0)
                {
                    MessageBox.Show("Item is out of stock.");
                    return;
                }

                // Use parameterized queries to avoid SQL injection attacks
                using (SqlCommand insertToCart = new SqlCommand("INSERT INTO Cart(Username, Product_ID, Quantity, Price) VALUES(@username, @productId, @quantity, @price)", con))
                {
                    insertToCart.Parameters.AddWithValue("@username", _username);
                    insertToCart.Parameters.AddWithValue("@productId", ProductId);
                    insertToCart.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    insertToCart.Parameters.AddWithValue("@price", Label_Price.Text);

                    insertToCart.ExecuteNonQuery();

                    using (SqlCommand updateQuantity = new SqlCommand("UPDATE Products SET Quantity = Quantity - '" + txtQuantity.Text + "' WHERE Product_ID = @productId", con))
                    {
                        updateQuantity.Parameters.AddWithValue("@productId", ProductId);
                        updateQuantity.ExecuteNonQuery();
                    }
                    con.Close();
                }
                // Use parameterized queries to avoid SQL injection attacks
                using (SqlCommand insertToBackup_Cart = new SqlCommand("INSERT INTO Backup_Cart(Username, Product_ID, Quantity, Price) VALUES(@username, @productId, @quantity, @price)", con))
                {
                    con.Open();
                    insertToBackup_Cart.Parameters.AddWithValue("@username", _username);
                    insertToBackup_Cart.Parameters.AddWithValue("@productId", ProductId);
                    insertToBackup_Cart.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    insertToBackup_Cart.Parameters.AddWithValue("@price", Label_Price.Text);

                    insertToBackup_Cart.ExecuteNonQuery();

                    con.Close();
                }



                MessageBox.Show("Success!", "Items confirmed.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadDatagrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void txtQuantity_TextChanged_1(object sender, EventArgs e)
        {
            decimal price;
            decimal quantity;

            try
            {
                // Try to parse the price as a decimal
                if (!decimal.TryParse(Label_Price.Text, out price))
                {
                    // Show an error message and return if the price cannot be parsed
                    MessageBox.Show("Invalid price value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                // Try to parse the quantity as a decimal
                if (!decimal.TryParse(txtQuantity.Text, out quantity))
                {
                    // Show an error message and return if the quantity cannot be parsed
                    MessageBox.Show("Invalid quantity value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                // If txtQuantity is empty, set Label_Price to 0
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    Label_Price.Text = string.Empty;
                    lblName.Text = string.Empty;
                }
                else
                {
                    // Calculate the total price
                    decimal totalPrice = price * quantity;

                    // Update the Label_Price field with the total price
                    Label_Price.Text = totalPrice.ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

  
    }
    }
    





