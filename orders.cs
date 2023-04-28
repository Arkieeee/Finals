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
            SqlCommand com = new SqlCommand("SELECT NSDAP_user.Username, NSDAP_user.Name, Order_ID, Orders.Image_apparel As Item, Orders.Name as Description, Orders.Date_Purchased as 'Date Purchased' FROM NSDAP_user INNER JOIN Orders ON NSDAP_user.Username = Orders.Username WHERE NSDAP_user.Username = '"+_username+"'", con);
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
