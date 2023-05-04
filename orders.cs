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
            SqlCommand com = new SqlCommand("SELECT o.Order_ID, p.Product_ID, p.Image_apparel, p.Name, p.Size, c.Quantity, c.Price, o.Date_Purchased \r\nFROM Products p INNER JOIN Backup_Cart c ON p.Product_ID = c.Product_ID INNER JOIN Orders o ON o.Product_ID = p.Product_ID \r\nAND o.Username = c.Username where c.Username ='" + _username+"'",con);
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
