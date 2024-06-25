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
    public partial class CashierForm : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        private static Stopwatch stopwatch = new Stopwatch();
        private static TimeSpan delayTime = TimeSpan.FromSeconds(1); // Engelleme süresi
        Login login;

        int qty;
        string id, price;
        string sendprice;
        public CashierForm(Login lgn)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            login = lgn;
            GetTransNo();
            stopwatch.Start();
            lblDate.Text=DateTime.Now.ToShortDateString();
        }

        public void slide(Button btn)
        {
            panelSlide.BackColor = Color.White;
            panelSlide.Height = btn.Height;
            panelSlide.Top = btn.Top;
        }

        public void LoadCart()
        {
            try
            {
                Boolean hascart = false;
                int i = 0;
                double total = 0, discount = 0;

                dgvCashier.Rows.Clear();
                con.Open();
                cmd = new SqlCommand("SELECT c.id,c.barcode,p.pdesc,c.price,c.qty,c.disc,c.total FROM tbCart AS c INNER JOIN tblProduct AS p ON c.barcode=p.barcode WHERE c.transno LIKE @transno and c.status LIKE 'Beklemede'", con);
                cmd.Parameters.AddWithValue("@transno", lblTranNo.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    total += Convert.ToDouble(dr["total"].ToString());
                    discount += Convert.ToDouble(dr["disc"].ToString());
                    dgvCashier.Rows.Add(i, dr["id"].ToString(), dr["barcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["price"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    hascart = true;

                }
                dr.Close();
                con.Close();
                txtSalesTotal.Text = total.ToString("#,##0.00");
                lblDiscount.Text = discount.ToString("#,##0.00");
                GetCartTotal();
                if (hascart) { btnClear.Enabled = true; btnSettle.Enabled = true; btnDiscount.Enabled = true; }
                else { btnClear.Enabled = false; btnSettle.Enabled = false; btnDiscount.Enabled = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void GetCartTotal()
        {
            double discount = double.Parse(lblDiscount.Text);
            double sales = double.Parse(txtSalesTotal.Text) - discount;
            double vat = sales * 0.12;
            double vatable = sales - vat;
            lblTax.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
            txtDisplayTotal.Text = sales.ToString("#,##0.00");

        }

        public void GetTransNo()
        {
            string sdate = DateTime.Now.ToString("yyMMddHHmmss");
            lblTranNo.Text = sdate;
            txtBarcode.Focus();

        }

        #region buttons
        private void btnNTran_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            if (stopwatch.Elapsed < delayTime)
            {
                Debug.WriteLine("Ardışık tıklamalar engellendi." + stopwatch.Elapsed);
                return;
            }
            Debug.WriteLine("ENGELLEME YOK." + stopwatch.Elapsed.ToString());

            stopwatch.Reset();
            stopwatch.Start();

            slide(btnTran);

            if (MessageBox.Show("Hızlı satış yapmak istediğinize emin misiniz?", "Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < dgvCashier.Rows.Count; i++)
                {

                    con.Open();
                    cmd = new SqlCommand("UPDATE tblProduct SET qty = qty - " + int.Parse(dgvCashier.Rows[i].Cells[4].Value.ToString()) + "WHERE barcode= '" + dgvCashier.Rows[i].Cells[2].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("UPDATE tbCart SET status = 'Satıldı' WHERE id= '" + dgvCashier.Rows[i].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                GetTransNo();
                LoadCart();
              

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            slide(btnSearch);
            LookUpProduct lookUpProduct = new LookUpProduct(this);
            lookUpProduct.LoadProduct();
            lookUpProduct.ShowDialog();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            slide(btnDiscount);
            Discount discount = new Discount(this);


            discount.lblid.Text = id;
            discount.txtTotalPrice.Text = price;
            discount.ShowDialog();

        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            slide(btnSettle);
            Settle settle = new Settle(this);
            settle.txtSale.Text = txtDisplayTotal.Text;
            settle.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            slide(btnClear);

            con.Open();
            cmd = new SqlCommand("Delete from tbCart where transno like'" + lblTranNo.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            LoadCart();
        }

        private void btnDSales_Click(object sender, EventArgs e)
        {
            slide(btnDSales);

            DailySale dailySale = new DailySale(new MainForm());
            dailySale.solduser = lblUsername.Text;
            dailySale.dtFrom.Enabled = false;
            dailySale.dtTo.Enabled = false;
            dailySale.cboCashier.Enabled = false;
            dailySale.cboCashier.Text = lblUsername.Text;
            dailySale.ShowDialog();

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            slide(btnChange);
            ChangePassword change = new ChangePassword(this);
            change.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (dgvCashier.Rows.Count > 0)
            {
                MessageBox.Show("Satış ekranında ürün var satışı tamamlayın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                slide(btnChange);
                this.Close();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBarcode.Text == string.Empty)
                    {
                        Debug.WriteLine("Keydown empty if");
                        return;
                    }
                    else
                    {
                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM tblProduct WHERE barcode LIKE '" + txtBarcode.Text + "'", con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {

                            qty = int.Parse(dr["qty"].ToString());
                            double _price = double.Parse(dr["price"].ToString());
                            int _qty = int.Parse(txtQty.Text);
                            string _barcode = dr["barcode"].ToString();

                            Debug.WriteLine("ürün adet:" + qty + " barkod:" + _barcode + " fiyat:" + _price);

                            dr.Close();
                            con.Close();
                            AddToCart(_barcode, _price, _qty);
                            //tbCarta ekle Satışı tbCart üzerinden yapıyorum.

                            txtBarcode.Clear();
                            txtQty.Text = 1.ToString();

                        }
                        dr.Close();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSalesTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvCashier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCashier.Columns[e.ColumnIndex].Name;


            if (colName == "Delete")
            {
                if (MessageBox.Show("Ürün silinsin mi?", "Ürünü Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbcon.ExecuteQuery("Delete from tbCart where id like'" + dgvCashier.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    LoadCart();
                }
            }
            else if (colName == "Add")
            {
                int i = 0;
                con.Open();
                cmd = new SqlCommand("SELECT SUM(qty) as qty FROM tblProduct WHERE barcode LIKE'" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", con);
                i = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                if (int.Parse(dgvCashier.Rows[e.RowIndex].Cells[4].Value.ToString()) < i)
                {
                    dbcon.ExecuteQuery("UPDATE tbCart SET qty = qty + " + int.Parse(txtQty.Text) + " WHERE transno LIKE '" + lblTranNo.Text + "'  AND barcode LIKE '" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "'");
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Stoktaki miktar: " + i + " !", "Stok tükendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "Reduce")
            {
                int i = 0;
                con.Open();
                cmd = new SqlCommand("SELECT SUM(qty) as qty FROM tbCart WHERE barcode LIKE'" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "' AND transno LIKE '" + lblTranNo.Text + "'", con);
                i = int.Parse(cmd.ExecuteScalar().ToString());
                Debug.WriteLine(i + "DEGER");
                con.Close();
                if (i > 1)
                {
                    dbcon.ExecuteQuery("UPDATE tbCart SET qty = qty - " + int.Parse(txtQty.Text) + " WHERE transno LIKE '" + lblTranNo.Text + "'  AND barcode LIKE '" + dgvCashier.Rows[e.RowIndex].Cells[2].Value.ToString() + "'");
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Sepetteki ürün: " + i + " !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void txtDisplayTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvCashier_SelectionChanged(object sender, EventArgs e)
        {

            int i = dgvCashier.CurrentRow.Index;
            id = dgvCashier[1, i].Value.ToString();

            double dprice = double.Parse(dgvCashier[6, i].Value.ToString());
            int dqty = int.Parse(dgvCashier[4, i].Value.ToString());
            price = (dqty * dprice).ToString("#,##0.00");

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                e.Handled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("HH:mm:ss");
        }




        #endregion buttons




        public void AddToCart(string _barcode, double _price, int _qty)
        {
            try
            {
                string id = "";
                int cart_qty = 0;
                bool found = false;
                con.Open();
                cmd = new SqlCommand("SELECT * FROM tbCart WHERE transno=@transno and barcode=@barcode", con);
                cmd.Parameters.AddWithValue("@transno", lblTranNo.Text);
                cmd.Parameters.AddWithValue("@barcode", _barcode);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    id = dr["id"].ToString();
                    cart_qty = int.Parse(dr["qty"].ToString());
                    found = true;
                    Debug.WriteLine("ADDTOCARTA GELDİ FOUND TRUE OLDU/ id:" + id + " cart_qty:" + cart_qty);


                }
                else
                {
                    found = false;
                    Debug.WriteLine("FOUND FALSE OLDU");
                }

                dr.Close();
                con.Close();
                if (found)
                {
                    if (qty < (int.Parse(txtQty.Text) + cart_qty))
                    {
                        MessageBox.Show("Stokta bulunandan fazla ürün satılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    con.Open();
                    cmd = new SqlCommand("UPDATE tbCart SET qty=(qty +" + _qty + ") WHERE id='" + id + "'", con);
                    cmd.ExecuteNonQuery();
                    Debug.WriteLine("UPDATE EDİLDİ qty+ **" + _qty + "yapıldı");

                    con.Close();
                    LoadCart();
                }


                else
                {
                    if (qty < (int.Parse(txtQty.Text) + cart_qty))
                    {
                        MessageBox.Show("Stokta bulunandan fazla ürün satılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    con.Open();
                    cmd = new SqlCommand("INSERT INTO tbCart (transno,barcode,price,qty,sdate,cashier) VALUES (@transno,@barcode,@price,@qty,@sdate,@cashier)", con);
                    cmd.Parameters.AddWithValue("@transno", lblTranNo.Text);
                    cmd.Parameters.AddWithValue("@barcode", _barcode);
                    cmd.Parameters.AddWithValue("@price", _price);
                    cmd.Parameters.AddWithValue("@qty", _qty);
                    cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@cashier", lblUsername.Text);
                    Debug.WriteLine("NORMAL ADDTOCARTA GİRDİ");


                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadCart();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CashierForm_Load(object sender, EventArgs e)
        {
            Noti();
        }

        public void Noti()
        {
            con.Open();
            int i = 0;
            cmd = new SqlCommand("SELECT * FROM viewCriticalItems", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                Alert alert = new Alert(new MainForm());
                alert.lblBarcode.Text = dr["barcode"].ToString();
                alert.showAlert(i + ". " + dr["pdesc"].ToString() + " - " + dr["qty"].ToString());
            }
            con.Close();
            dr.Close();

        }
    }


}
