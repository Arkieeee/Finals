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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        private void loadDatagrid()
        {

            con.Open();
            SqlCommand com = new SqlCommand("SELECT o.Order_ID as 'Reference ID', p.Product_ID as 'Product ID', p.Image_apparel as Item, p.Name, p.Size, c.Quantity, c.Price, o.Date_Purchased as 'Date Purchased' FROM Products p INNER JOIN Backup_Cart c ON p.Product_ID = c.Product_ID INNER JOIN Orders o ON o.Product_ID = p.Product_ID AND o.Username = c.Username ", con);

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();
        }
        private void loadDatagridTShirt()
        {

            con.Open();
            SqlCommand com = new SqlCommand("SELECT Product_ID, Image_apparel, Name, Category, Quantity, Size, Price FROM Products WHERE Category = 'T-Shirt'", con);

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();
        }

        private void loadDatagridPoloShirt()
        {

            con.Open();
            SqlCommand com = new SqlCommand("SELECT Product_ID, Image_apparel, Name, Category, Quantity, Size, Price FROM Products WHERE Category = 'Polo Shirt'", con);

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();
        }


        private void loadDatagridJacket()
        {

            con.Open();
            SqlCommand com = new SqlCommand("SELECT Product_ID, Image_apparel, Name, Category, Quantity, Size, Price FROM Products WHERE Category = 'Jacket'", con);

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "T-Shirt":
                    loadDatagridTShirt();
                    break;
                case "Polo Shirt":
                    loadDatagridPoloShirt();
                    break;
                case "Jacket":
                    loadDatagridJacket();
                    break;
                default:
                    loadDatagrid();
                    break;
            }
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            loadDatagrid();
        }
    }
}
