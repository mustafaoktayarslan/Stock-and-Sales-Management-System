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
    public partial class LookUpProduct : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        CashierForm cashier;
        public LookUpProduct(CashierForm cashier)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            this.cashier = cashier;
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
            cmd = new SqlCommand("SELECT p.barcode, p.pdesc , b.brand ,c.category,p.price,p.qty FROM tblProduct AS p INNER JOIN tbBrand AS b  ON b.id =p.bid INNER JOIN tbCategory AS c ON c.id = p.cid WHERE CONCAT(p.pdesc, b.brand, c.category) LIKE '%" + txtSearch.Text + "%'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr["barcode"].ToString().Equals("**silindi**")) { 
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            dr.Close();
            con.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                Qty qty = new Qty(cashier);
                qty.ProductDetails(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() , double.Parse(dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString()), cashier.lblTranNo.Text, int.Parse(dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString()));
                qty.ShowDialog();
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

        private void LookUpProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();   
        }
    }
}
