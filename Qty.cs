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
    public partial class Qty : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        private string barcode;
        private double price;
        private string transno;
        private int qty;
        CashierForm cashier;
        public Qty(CashierForm cashier)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            this.cashier = cashier;
        }


        public void ProductDetails(string barcode, double price, string transno, int qty)
        {
            this.barcode = barcode;
            this.price = price;
            this.transno = transno;
            this.qty = qty;

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)27)//esc
             {
                e.Handled = true;
                this.Close();

            }
            if (e.KeyChar == 13 && (txtQty.Text != string.Empty))//enter
            {
                e.Handled = true;
                try
                {
                    string id = "";
                    int cart_qty = 0;
                    bool found = false;
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM tbCart WHERE transno=@transno and barcode=@barcode", con);
                    cmd.Parameters.AddWithValue("@transno", transno);
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        id = dr["id"].ToString();
                        cart_qty = int.Parse(dr["qty"].ToString());
                        found = true;
                    }
                    else found = false;
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
                        cmd = new SqlCommand("UPDATE tbCart SET qty=(qty +" + int.Parse(txtQty.Text) + ") WHERE id='" + id + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cashier.txtBarcode.Clear();
                        cashier.txtBarcode.Focus(); 
                        cashier.LoadCart();
                        this.Close();
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
                        cmd.Parameters.AddWithValue("@transno", transno);
                        cmd.Parameters.AddWithValue("@barcode", barcode);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                        cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@cashier", cashier.lblUsername.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        cashier.txtBarcode.Clear();
                        cashier.txtBarcode.Focus();
                        cashier.LoadCart();
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
