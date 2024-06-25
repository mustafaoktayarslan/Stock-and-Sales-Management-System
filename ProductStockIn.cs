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

namespace MarketSystem
{
    public partial class ProductStockIn : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        StockIn stockIn;
        public ProductStockIn(StockIn stck)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            stockIn = stck;
            LoadProduct();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cmd = new SqlCommand("SELECT barcode, pdesc ,qty FROM tblProduct  WHERE pdesc LIKE '%" + txtSearch.Text + "%'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr["barcode"].ToString().Equals("**silindi**")) { 
                    i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
            }
            dr.Close();
            con.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
           if(colName=="Select") 
            { 
                if (stockIn.txtStockInBy.Text ==String.Empty)
                {
                    MessageBox.Show("Lütfen stoğu giren kişi ismini doldurun!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    stockIn.txtStockInBy.Focus();
                    return;
                }
                if (MessageBox.Show("Bu öğeyi eklemek ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    addStockIn(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString());
                    MessageBox.Show("Başarıryla Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void addStockIn(string barcode)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO tbStockIn (refno,barcode,sdate,stockinby,supplierid) VALUES (@refno,@barcode,@sdate,@stockinby,@supplierid)", con);
                cmd.Parameters.AddWithValue("@refno", stockIn.txtRefNo.Text);
                cmd.Parameters.AddWithValue("@barcode", barcode);
                cmd.Parameters.AddWithValue("@sdate", stockIn.dtpStockIn.Value);
                cmd.Parameters.AddWithValue("@stockinby", stockIn.txtStockInBy.Text);
                cmd.Parameters.AddWithValue("@supplierid", stockIn.lblid.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                stockIn.LoadStockIn();



            }
            catch (Exception ex)
            {
                con.Close();

                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
