using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketSystem
{
    public partial class Product : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;


        public Product()
        {
            InitializeComponent();
            con= new SqlConnection(dbcon.myConnection());
            LoadProduct();
        }
       

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cmd = new SqlCommand("SELECT p.barcode, p.pdesc , b.brand ,c.category,p.price,p.reorder FROM tblProduct AS p INNER JOIN tbBrand AS b  ON b.id =p.bid INNER JOIN tbCategory AS c ON c.id = p.cid WHERE CONCAT(p.pdesc, b.brand, c.category) LIKE '%"+txtSearch.Text+"%'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr["barcode"].ToString().Equals("**silindi**")) 
                { 
                    i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule productmodule= new ProductModule(this);
            productmodule.btnUpdate.Enabled = false;
            productmodule.ShowDialog();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bu ürünü silmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    dbcon.ExecuteQuery("UPDATE tbCart SET barcode = '**Silindi**'  where barcode= '" + dgvProduct[1, e.RowIndex].Value.ToString() + "'");
                    dbcon.ExecuteQuery("UPDATE tbStockIn SET barcode = '**Silindi**'  where barcode= '" + dgvProduct[1, e.RowIndex].Value.ToString() + "'");

                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tblProduct WHERE barcode LIKE '" + dgvProduct[1, e.RowIndex].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla SİLİNDİ", "BİLGİ");
                    LoadProduct();


                }
            }
            else if (colName == "Edit")
            {
                ProductModule productModule = new ProductModule(this);
                productModule.txtBarcode.Text = dgvProduct[1, e.RowIndex].Value.ToString();
                productModule.txtPdesc.Text = dgvProduct[2, e.RowIndex].Value.ToString();
                productModule.comboBrand.Text = dgvProduct[3, e.RowIndex].Value.ToString();
                productModule.comboCategory.Text = dgvProduct[4, e.RowIndex].Value.ToString();
                productModule.txtPrice.Text = dgvProduct[5, e.RowIndex].Value.ToString();
                productModule.UDReorder.Value = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString());

                productModule.txtBarcode.Enabled =false;
                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;
                productModule.ShowDialog();
                LoadProduct(); 
               


            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();  
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Enter tuşunun işlenmesini engeller
            }
        }
    }
}
