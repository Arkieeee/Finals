using System.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Finals
{
    public partial class btnload : Form
    {
        public btnload()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");


        private void loadDataGrid()
        {
            con.Open();
            SqlCommand com = new SqlCommand("SELECT o.Order_ID as 'Reference ID', p.Product_ID as 'Product ID', p.Name, p.Size, c.Quantity, c.Price," +
                " o.Date_Purchased as 'Date Purchased' FROM Products p INNER JOIN Backup_Cart c ON p.Product_ID = c.Product_ID INNER JOIN Orders " +
                "o ON o.Product_ID = p.Product_ID", con);

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            dataGridView1.DataSource = tab;

            con.Close();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            DataTable tab = (DataTable)dataGridView1.DataSource;

            // Clear any existing series and chart areas from the chart
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Add a new chart area to the chart
            ChartArea chartArea = chart1.ChartAreas.Add("MainChartArea");

            // Add the series "Number of Products" to the chart
            Series numberOfProductsSeries = chart1.Series.Add("Number of Products");
            numberOfProductsSeries.ChartType = SeriesChartType.Column;
            numberOfProductsSeries.XValueMember = "Reference ID";
            numberOfProductsSeries.YValueMembers = "Product ID";
            numberOfProductsSeries.ChartArea = "MainChartArea";

            // Add the series "Total Profit" to the chart
            Series totalProfitSeries = chart1.Series.Add("Total Profit");
            totalProfitSeries.ChartType = SeriesChartType.Column;
            totalProfitSeries.XValueMember = "Reference ID";
            totalProfitSeries.YValueMembers = "Price";
            totalProfitSeries.ChartArea = "MainChartArea";

            // Calculate total profit by summing the Price column
            decimal totalProfit = tab.AsEnumerable().Sum(row => row.Field<decimal>("Price"));

            // Set the chart title to display the total profit
            chart1.Titles.Clear();
            chart1.Titles.Add("Total Profit: $" + totalProfit.ToString());

            // Bind the chart to the data
            chart1.DataSource = tab;
            chart1.DataBind();
        }



    }
}
