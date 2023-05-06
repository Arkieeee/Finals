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
    }
}
