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
    public partial class tshirt : Form
    {
        public tshirt()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=ARKI\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        private void loadDatagrid()
        {

            con.Open();
            SqlCommand com = new SqlCommand("Select Image_apparel, Name,Description, Quantity, Price from Products", con);

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();
        }

        private void tshirt_Load(object sender, EventArgs e)
        {
            loadDatagrid();
        }
    }
}
