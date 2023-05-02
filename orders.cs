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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Finals
{
    public partial class orders : Form
    {
        private string _username;
        public orders(String username)
        {
               InitializeComponent();
               _username = username; // Set _username to the passed parameter
        }
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");

        private void loadDatagrid()
        {
            con.Open();
            SqlCommand com = new SqlCommand("SELECT p.Product_ID,p.Image_apparel, p.Name, c.Quantity, c.Price\r\nFROM Products p\r\nINNER JOIN Cart c ON p.Product_ID = c.Product_ID where Username = '"+_username+"'",con);
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();
            adap.Fill(tab);
            dataGridView1.DataSource = tab;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Set the font color to black
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orders_Load(object sender, EventArgs e)
        {
            loadDatagrid();
        }
    }
}
