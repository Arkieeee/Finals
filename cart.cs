using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//LAST NAKO GE USAB
namespace Finals
{
    public partial class cart : Form
    {
        private string _username;
        
        private int ProductId;
        byte[] imageBytes;

        public cart(String username)
        {
            InitializeComponent();
            _username = username; // Set _username to the passed parameter
            lblDate.Text = DateTime.Now.ToString();
        }
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        public void loadDatagrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT p.Product_ID,p.Image_apparel, p.Name, c.Quantity, c.Price FROM Products p INNER JOIN Cart c ON p.Product_ID = c.Product_ID", con);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adap.Fill(tab);
            dataGridView1.DataSource = tab;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Set the font color to black
            con.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Product_ID"].Value.ToString());
            lblName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            imageBytes = (byte[])dataGridView1.Rows[e.RowIndex].Cells["Image_apparel"].Value;

            lblQuantity.Text = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            lblPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                pictureBox1.Image = image;
            }
        }

        private void cart_Load(object sender, EventArgs e)
        {
            loadDatagrid();
        }

        private void btnConfirm_Order_Click(object sender, EventArgs e)
        {
            try
            {
                decimal price = decimal.Parse(lblPrice.Text);
                decimal balance = 0;

                // Check user's balance
                using (SqlCommand com = new SqlCommand("SELECT Balance FROM Balance WHERE Username = @username", con))
                {
                    com.Parameters.AddWithValue("@username", _username);
                    con.Open();

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            balance = reader.GetDecimal(0);
                        }
                    }
                }

                if (balance < price)
                {
                    MessageBox.Show("Insufficient balance. Please add funds to your account.");
                    return;
                }

                // Update user's balance
                using (SqlCommand updateBalance = new SqlCommand("UPDATE Balance SET Balance = Balance - @price WHERE Username = @username", con))
                {
                    updateBalance.Parameters.AddWithValue("@price", price);
                    updateBalance.Parameters.AddWithValue("@username", _username);
                    updateBalance.ExecuteNonQuery();
                }

                // Insert order into Orders table
                using (SqlCommand insertToOrder = new SqlCommand("INSERT INTO Orders(Username, product_ID, Date_Purchased) VALUES(@username, @prodcut_id, @datepurchased)", con))
                {
                    insertToOrder.Parameters.AddWithValue("@username", _username);
                    insertToOrder.Parameters.AddWithValue("@prodcut_id", ProductId);
                    insertToOrder.Parameters.AddWithValue("@datepurchased", lblDate.Text);

                    insertToOrder.ExecuteNonQuery();
                }

                // Delete items from user's cart
                using (SqlCommand deleteFromCart = new SqlCommand("DELETE FROM Cart WHERE Username = @username", con))
                {
                    deleteFromCart.Parameters.AddWithValue("@username", _username);
                    deleteFromCart.ExecuteNonQuery();
                }

                // Close the connection
                con.Close();

                MessageBox.Show("Success!", "Order confirmed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDatagrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }//mayta oaky na
        }

    }
}

