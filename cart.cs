using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Finals
{
    public partial class cart : Form
    {
        private string _username;
        private int ProductId;

        public cart(String username)
        {
            InitializeComponent();
            _username = username; // Set _username to the passed parameter
            lblDate.Text = DateTime.Now.ToString();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QI6H2EA\\SQLEXPRESS01;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        public void loadDatagrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Product_ID, Name, Quantity, Price from Cart", con);
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
            lblQuantity.Text = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            lblPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();


        }

        private void cart_Load(object sender, EventArgs e)
        {
            loadDatagrid();
        }

        private void btnConfirm_Order_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand insertToOrder = new SqlCommand("INSERT INTO Orders(Username, Name, Quantity, Price, Date_Purchased) VALUES(@username, @name, @quantity, @price, @datepurchased)", con);
                {
                    insertToOrder.Parameters.AddWithValue("@username", _username);
                    insertToOrder.Parameters.AddWithValue("@name", lblName.Text);
                    insertToOrder.Parameters.AddWithValue("@quantity", lblQuantity.Text);
                    insertToOrder.Parameters.AddWithValue("@price", lblPrice.Text);
                    insertToOrder.Parameters.AddWithValue("@datepurchased", lblDate.Text);

                    insertToOrder.ExecuteNonQuery();

                    SqlCommand deleteFromCart = new SqlCommand("DELETE FROM Cart WHERE Username = @username", con);
                    {
                        deleteFromCart.Parameters.AddWithValue("@username", _username);
                        deleteFromCart.ExecuteNonQuery();
                    }
                }
                con.Close();
                MessageBox.Show("Success!", "Order confirmed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}

