using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        private void loadDatagrid(string category)
        {
            con.Open();
            DateTime fdate = fromdate.Value.Date;
            DateTime tdate = todate.Value.Date;

            SqlCommand com = new SqlCommand("SELECT o.Order_ID as 'Reference ID', p.Product_ID as 'Product ID', p.Image_apparel as Item, p.Name, p.Size, c.Quantity, c.Price, o.Date_Purchased as 'Date Purchased' " +
                "FROM Products p " +
                "INNER JOIN Backup_Cart c ON p.Product_ID = c.Product_ID " +
                "INNER JOIN Orders o ON o.Product_ID = p.Product_ID AND o.Username = c.Username " +
                "WHERE p.Category = @category AND o.Date_Purchased BETWEEN @fromdate AND @todate", con);

            com.Parameters.AddWithValue("@category", category);
            com.Parameters.AddWithValue("@fromdate", fdate);
            com.Parameters.AddWithValue("@todate", tdate.AddDays(1).AddSeconds(-1));

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();
        }
        private void Transactions_Load(object sender, EventArgs e)
        {
            // Set default category and load the data grid
            string defaultCategory = string.Empty;
            loadDatagrid(defaultCategory);
        }

        private void fromdate_ValueChanged(object sender, EventArgs e)
        {
            // Call loadDatagrid() with the selected category
            string selectedCategory = comboBox1.SelectedItem.ToString();
            loadDatagrid(selectedCategory);
        }

        private void todate_ValueChanged(object sender, EventArgs e)
        {
            // Call loadDatagrid() with the selected category
            string selectedCategory = comboBox1.SelectedItem.ToString();
            loadDatagrid(selectedCategory);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call loadDatagrid() with the selected category
            string selectedCategory = comboBox1.SelectedItem.ToString();
            loadDatagrid(selectedCategory);
        } 
        
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("SELECT o.Order_ID, p.Product_ID as 'Product ID', p.Image_apparel as Item, " +
                "p.Name, p.Size, c.Quantity, c.Price, o.Date_Purchased as 'Date Purchased' " +
                "FROM Products p " +
                "INNER JOIN Backup_Cart c ON p.Product_ID = c.Product_ID " +
                "INNER JOIN Orders o ON o.Product_ID = p.Product_ID AND o.Username = c.Username " +
                "WHERE o.Order_ID LIKE @searchText", con);

            com.Parameters.AddWithValue("@searchText", "%" + txtsearch.Text + "%");

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();

        }
    }
}
