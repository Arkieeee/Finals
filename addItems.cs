using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    public partial class addItems : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QI6H2EA\\SQLEXPRESS01;Initial Catalog=NSDAP_APPAREL_dB;Integrated Security=True");
        string imgLoc = "";
        public addItems()
        {
            InitializeComponent();
            txtname.Enter += new EventHandler(txtname_Enter);
            txtname.Leave += new EventHandler(txtname_Leave);
            this.MouseDown += Form1_MouseDown;
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (.jpg)|.jpg|GIF Files (.gif)|.gif|ALL Files (.)|*.*";
                dlg.Title = "Select an Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picEmp.ImageLocation = imgLoc;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {

            //otwen
            byte[] img = null;
            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            int quantity = Convert.ToInt32(txtquantity.Text);

            SqlCommand insertToProducts = new SqlCommand("INSERT INTO Products (Name, Quantity, Category, Size, Price, Image_apparel) VALUES (@name, @quantity, @category, @size, @price, @img)", con);

            insertToProducts.Parameters.AddWithValue("@name", txtname.Text);
            insertToProducts.Parameters.AddWithValue("@quantity", quantity);
            insertToProducts.Parameters.AddWithValue("@category", txtCategory.Text);
            insertToProducts.Parameters.AddWithValue("@size", txtsize.Text);
            insertToProducts.Parameters.AddWithValue("@price", Double.Parse(txtprice.Text));
            insertToProducts.Parameters.AddWithValue("@img", img);

            con.Open();
            insertToProducts.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Product successfully inserted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void loadDatagrid()
        {

            con.Open();
            SqlCommand com = new SqlCommand("Select Product_ID, Image_apparel, Name, Category, Quantity, Size, Price from Products", con);

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
        private void addItems_Load(object sender, EventArgs e)
        {
    
            loadDatagrid();
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Name")
            {
                txtname.Text = "";
                txtname.ForeColor = Color.Black; // Set the text color back to black for regular input
            }
        }


        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Name";
                txtname.ForeColor = Color.Silver; // Set the text color back to black for regular input
            }
        }

        private void txtquantity_Enter(object sender, EventArgs e)
        {
            if (txtquantity.Text == "Quantity")
            {
                txtquantity.Text = "";
                txtquantity.ForeColor = Color.Black; // Set the text color back to black for regular input
            }
        }

        private void txtquantity_Leave(object sender, EventArgs e)
        {
            if (txtquantity.Text == "")
            {
                txtquantity.Text = "Quantity";
                txtquantity.ForeColor = Color.Silver; // Set the text color back to black for regular input
            }
        }

        private void txtdescription_Enter(object sender, EventArgs e)
        {
            if (txtCategory.Text == "Description")
            {
                txtCategory.Text = "";
                txtCategory.ForeColor = Color.Black; // Set the text color back to black for regular input
            }
        }

        private void txtdescription_Leave(object sender, EventArgs e)
        {
            if (txtCategory.Text == "")
            {
                txtCategory.Text = "Description";
                txtCategory.ForeColor = Color.Silver; // Set the text color back to black for regular input
            }
        }

        private void txtsize_Enter(object sender, EventArgs e)
        {
            if (txtsize.Text == "Size")
            {
                txtsize.Text = "";
                txtsize.ForeColor = Color.Black; // Set the text color back to black for regular input
            }
        }

        private void txtsize_Leave(object sender, EventArgs e)
        {
            if (txtsize.Text == "")
            {
                txtsize.Text = "Size";
                txtsize.ForeColor = Color.Silver; // Set the text color back to black for regular input
            }
        }

        private void txtprice_Enter(object sender, EventArgs e)
        {
            if (txtprice.Text == "Price")
            {
                txtprice.Text = "";
                txtprice.ForeColor = Color.Black; // Set the text color back to black for regular input
            }
        }

        private void txtprice_Leave(object sender, EventArgs e)
        {
            if (txtprice.Text == "")
            {
                txtprice.Text = "Price";
                txtprice.ForeColor = Color.Silver; // Set the text color back to black for regular input
            }
        }

        private void txtname_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtname.Text == "Name")
            {
                // If the current text is the placeholder text, clear it and set the text color to black for regular input
                txtname.Text = "";
                txtname.ForeColor = Color.Black;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!txtname.Bounds.Contains(e.Location))
            {
                // If the user clicked outside the textbox, and the textbox is empty, set the text to the placeholder text and the color to silver
                if (!txtname.Bounds.Contains(e.Location))
                {
                    if (txtname.Text == "")
                    {
                        txtname.Text = "Name";
                        txtname.ForeColor = Color.Silver;
                    }
                }

                if (!txtquantity.Bounds.Contains(e.Location))
                {
                    if (txtquantity.Text == "")
                    {
                        txtquantity.Text = "Quantity";
                        txtquantity.ForeColor = Color.Silver;
                    }
                }

                if (!txtCategory.Bounds.Contains(e.Location))
                {
                    if (txtCategory.Text == "")
                    {
                        txtCategory.Text = "Description";
                        txtCategory.ForeColor = Color.Silver;
                    }
                }

                if (!txtsize.Bounds.Contains(e.Location))
                {
                    if (txtsize.Text == "")
                    {
                        txtsize.Text = "Size";
                        txtsize.ForeColor = Color.Silver;
                    }
                }

                if (!txtprice.Bounds.Contains(e.Location))
                {
                    if (txtprice.Text == "")
                    {
                        txtprice.Text = "Price";
                        txtprice.ForeColor = Color.Silver;
                    }
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            int no;
            no = int.Parse(lblProduct_ID.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Products SET Name= '" + txtname.Text + "', Quantity ='" + txtquantity.Text + "', Category = '" + txtCategory.Text + "', Size ='" + txtsize.Text + "', Price ='"+txtprice.Text+"'  where Product_ID= '" + no + "'", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Successfully Updated! ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            con.Close();
            loadDatagrid();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblProduct_ID.Text = dataGridView1.Rows[e.RowIndex].Cells["Product_ID"].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtquantity.Text = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            txtCategory.Text = dataGridView1.Rows[e.RowIndex].Cells["Category"].Value.ToString();
            txtsize.Text = dataGridView1.Rows[e.RowIndex].Cells["Size"].Value.ToString();
            txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int no;
            no = int.Parse(lblProduct_ID.Text);
            con.Open();

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                SqlCommand com = new SqlCommand("Delete from Products where Product_ID = '" + no + "'", con);
                com.ExecuteNonQuery();

                MessageBox.Show("Successfully DELETED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("CANCELLED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            loadDatagrid();
        
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
    }
}





