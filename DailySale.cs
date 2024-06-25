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
    public partial class DailySale : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string solduser;
        MainForm main;
        public DailySale(MainForm mn)
        {   
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            LoadCashier();
            main = mn;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("Tüm Kasiyerler");
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tbUser WHERE role LIKE 'Kasiyer'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboCashier.Items.Add(dr["username"].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadSold()
        {
            try {
            int i = 0;
            double total = 0;
            dgvSold.Rows.Clear();
            con.Open();
                string fromDate = dtFrom.Value.ToString("yyyy-MM-dd");
                string toDate = dtTo.Value.ToString("yyyy-MM-dd");
                if (cboCashier.Text == "Tüm Kasiyerler")
            {
                cmd = new SqlCommand("select c.id, c.transno, c.barcode, p.pdesc, c.price, c.qty, c.disc, c.total from tbCart as c inner join tblProduct as p on c.barcode = p.barcode where status like 'Satıldı' and sdate between '" + fromDate + "' and '" + toDate + "'", con);
            }
            else
            {
                cmd = new SqlCommand("select c.id, c.transno, c.barcode, p.pdesc, c.price, c.qty, c.disc, c.total from tbCart as c inner join tblProduct as p on c.barcode = p.barcode where status like 'Satıldı' and sdate between '" + fromDate + "' and '" + toDate + "' and cashier like '" + cboCashier.Text + "'", con);
            }
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                total += double.Parse(dr["total"].ToString());
                dgvSold.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["barcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
            }
            dr.Close();
            con.Close();
            lblTotal.Text = total.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();

        }

        private void DailySale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgvSold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSold.Columns[e.ColumnIndex].Name;
            if (colName == "Cancel")
            {
                CancelOrder cancel = new CancelOrder(this);
                cancel.txtId.Text = dgvSold.Rows[e.RowIndex].Cells[1].Value.ToString();
                cancel.txtTransno.Text = dgvSold.Rows[e.RowIndex].Cells[2].Value.ToString();
                cancel.txtPcode.Text = dgvSold.Rows[e.RowIndex].Cells[3].Value.ToString();
                cancel.txtDesc.Text = dgvSold.Rows[e.RowIndex].Cells[4].Value.ToString();
                cancel.txtPrice.Text = dgvSold.Rows[e.RowIndex].Cells[5].Value.ToString();
                cancel.txtQty.Text = dgvSold.Rows[e.RowIndex].Cells[6].Value.ToString();
                cancel.txtDisc.Text = dgvSold.Rows[e.RowIndex].Cells[7].Value.ToString();
                cancel.txtTotal.Text = dgvSold.Rows[e.RowIndex].Cells[8].Value.ToString();

                if (panel1.Visible == false)
                    cancel.txtCancelBy.Text = "*"+main.lblUsername.Text;
                else
                    cancel.txtCancelBy.Text = solduser;
                cancel.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            POSReport posreport=new POSReport();
            string fromDate = dtFrom.Value.ToString("yyyy-MM-dd");
            string toDate = dtTo.Value.ToString("yyyy-MM-dd");
            string param = "Başlangıç: " + fromDate + " Bitiş: " + toDate;

            if (cboCashier.Text.Equals("Tüm Kasiyerler"))
            {
                posreport.LoadDailyReport("select c.id, c.transno, c.barcode, p.pdesc, c.price, c.qty, c.disc as discount, c.total from tbCart as c inner join tblProduct as p on c.barcode = p.barcode where status like 'Satıldı' and sdate between '" + fromDate + "' and '" + toDate + "'", param, cboCashier.Text);
            }
            else
            {
                posreport.LoadDailyReport("select c.id, c.transno, c.barcode, p.pdesc, c.price, c.qty, c.disc as discount, c.total from tbCart as c inner join tblProduct as p on c.barcode = p.barcode where status like 'Satıldı' and sdate between '" + fromDate + "' and '" + toDate + "' and cashier like '" + cboCashier.Text + "'", param, cboCashier.Text);
            }
            posreport.ShowDialog();
        }
    }
}
