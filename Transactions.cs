using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Finals
{
    public partial class Transactions : Form
    {
        Thread chart;
        public Transactions()
        {
            InitializeComponent();
            
        }
        SqlConnection con = new SqlConnection("Data Source=IVERSONKOBE\\SQLEXPRESS;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");

        public void GoToChart(object obj)
        {
            Application.Run(new btnload());
        }
        private void btnchart_Click(object sender, EventArgs e)
        {
            this.Close();
            chart = new Thread(GoToChart);
            chart.SetApartmentState(ApartmentState.STA);
            chart.Start();
        }
        private void loadDatagrid(string category)
        {
            con.Open();
            DateTime fdate = fromdate.Value.Date;
            DateTime tdate = todate.Value.Date;

            SqlCommand com = new SqlCommand("SELECT o.Order_ID as 'Reference ID', p.Product_ID as 'Product ID', p.Name, p.Size, c.Quantity, c.Price, o.Date_Purchased as 'Date Purchased' " +
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
            try
            {
                // Set default category and load the data grid
                string defaultCategory = string.Empty;
                loadDatagrid(defaultCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fromdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Call loadDatagrid() with the selected category
                string selectedCategory = comboBox1.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    loadDatagrid(selectedCategory);
                    todate.Enabled = true; // Enable the todate picker
                }
                else
                {
                    todate.Enabled = false; // Disable the todate picker
                    MessageBox.Show("Please select an item first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void todate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Call loadDatagrid() with the selected category
                string selectedCategory = comboBox1.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    loadDatagrid(selectedCategory);
                }
                else
                {
                    MessageBox.Show("Please select an item first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Call loadDatagrid() with the selected category
                string selectedCategory = comboBox1.SelectedItem.ToString();
                loadDatagrid(selectedCategory);
            }
            catch (Exception exeeee)
            {
                MessageBox.Show(exeeee.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("SELECT o.Order_ID, p.Product_ID as 'Product ID', " +
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string title = "Reports";
                Font titleFont = new Font("Arial", 18, FontStyle.Bold);
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                RectangleF titleRect = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, titleSize.Height);
                e.Graphics.DrawString(title, titleFont, Brushes.Black, titleRect, new StringFormat() { Alignment = StringAlignment.Center });

                string countTitle = "Total Orders: " + (dataGridView1.RowCount - 1).ToString();
                Font countTitleFont = new Font("Arial", 12, FontStyle.Regular);
                SizeF countTitleSize = e.Graphics.MeasureString(countTitle, countTitleFont);
                RectangleF countTitleRect = new RectangleF(e.MarginBounds.Left, titleRect.Bottom + 10, e.MarginBounds.Width, countTitleSize.Height);
                e.Graphics.DrawString(countTitle, countTitleFont, Brushes.Black, countTitleRect, new StringFormat() { Alignment = StringAlignment.Near });


                Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
                this.dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));



                Rectangle printArea = e.MarginBounds;
                float scale = Math.Min((float)printArea.Width / bm.Width, (float)printArea.Height / bm.Height);
                int scaledWidth = (int)(bm.Width * scale);
                int scaledHeight = (int)(bm.Height * scale);

                printArea.X = (int)((e.PageBounds.Width - scaledWidth) / 2);
                printArea.Y = (int)((e.PageBounds.Height - scaledHeight) / 2);
                printArea.Width = scaledWidth;
                printArea.Height = scaledHeight;

                int headerHeight = (int)(this.dataGridView1.ColumnHeadersHeight * scale);
                int headerWidth = (int)(printArea.Width / this.dataGridView1.Columns.Count);
                int x = printArea.X;
                int y = printArea.Y - headerHeight;

                foreach (DataGridViewColumn col in this.dataGridView1.Columns)
                {
                    Rectangle headerRect = new Rectangle(x, y, headerWidth, headerHeight);
                    e.Graphics.FillRectangle(Brushes.White, headerRect);
                    e.Graphics.DrawString(col.HeaderText, new Font(this.dataGridView1.Font, FontStyle.Bold), Brushes.Black, headerRect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    e.Graphics.DrawLine(Pens.Black, headerRect.Left, headerRect.Bottom, headerRect.Right, headerRect.Bottom);
                    e.Graphics.DrawLine(Pens.Black, headerRect.Left, headerRect.Top, headerRect.Right, headerRect.Top); // Add line border at top of header
                    x += headerWidth;
                }
                int cellHeight = (int)(this.dataGridView1.RowTemplate.Height * scale);
                int cellWidth;
                x = printArea.X;
                y += headerHeight;
                for (int i = this.dataGridView1.FirstDisplayedScrollingRowIndex; i < this.dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[i];
                    cellWidth = (int)(printArea.Width / row.Cells.Count);
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        Rectangle cellRect = new Rectangle(x, y, cellWidth, cellHeight);
                        e.Graphics.DrawString(row.Cells[j].FormattedValue.ToString(), this.dataGridView1.Font, Brushes.Black, cellRect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                        x += cellWidth;
                    }
                    x = printArea.X;
                    y += cellHeight;
                    if (y + cellHeight > printArea.Bottom)
                    {
                        e.HasMorePages = true;
                        this.dataGridView1.FirstDisplayedScrollingRowIndex = i + 1;
                        return;
                    }
                }
                int footerHeight = (int)(this.dataGridView1.ColumnHeadersHeight * scale);
                int footerWidth = (int)(printArea.Width);
                int x1 = printArea.X + printArea.Width - footerWidth;
                int y1 = printArea.Y + printArea.Height;
                Rectangle footerRect = new Rectangle(x1, y1, footerWidth, footerHeight);
                e.Graphics.FillRectangle(Brushes.White, footerRect);
                e.Graphics.DrawString("By: Admin", this.dataGridView1.Font, Brushes.Black, footerRect, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
    }
     
    }



