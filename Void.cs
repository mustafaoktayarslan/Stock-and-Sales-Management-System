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
    public partial class Void : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        CancelOrder cancelOrder;
        public Void(CancelOrder cancel)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cancelOrder = cancel;
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.ToLower() == cancelOrder.txtCancelBy.Text.ToLower())
                {
                    MessageBox.Show("Ürünü aynı kişi iptal edemez. Başka kullanıcı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string user;
                cn.Open();
                cm = new SqlCommand("Select * From tbUser Where username = @username and password = @password", cn);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    user = dr["username"].ToString();
                    dr.Close();
                    cn.Close();
                    SaveCancelOrder(user);
                    if (cancelOrder.cboInventory.Text == "Evet")
                    {
                        dbcon.ExecuteQuery("UPDATE tblProduct SET qty = qty + " + cancelOrder.udCancelQty.Value + " where barcode= '" + cancelOrder.txtPcode.Text + "'");
                    }
                    dbcon.ExecuteQuery("UPDATE tbCart SET qty = qty-" + cancelOrder.udCancelQty.Value + " where id LIKE '" + cancelOrder.txtId.Text + "'");
                    MessageBox.Show("Başarıyla iptal edildi.", "Ürün İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    cancelOrder.ReloadSoldList();
                    cancelOrder.Close();

                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public void SaveCancelOrder(string user)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into tbCancel (transno, barcode, price, qty, total, sdate, voidby, cancelledby, reason, action) values (@transno, @barcode, @price, @qty, @total, @sdate, @voidby, @cancelledby, @reason, @action)", cn);
                cm.Parameters.AddWithValue("@transno", cancelOrder.txtTransno.Text);
                cm.Parameters.AddWithValue("@barcode", cancelOrder.txtPcode.Text);
                cm.Parameters.AddWithValue("@price", double.Parse(cancelOrder.txtPrice.Text));
                cm.Parameters.AddWithValue("@qty", int.Parse(cancelOrder.txtQty.Text));
                cm.Parameters.AddWithValue("@total", double.Parse(cancelOrder.txtTotal.Text));
                cm.Parameters.AddWithValue("@sdate", DateTime.Now);
                cm.Parameters.AddWithValue("@voidby", user);
                cm.Parameters.AddWithValue("@cancelledby", cancelOrder.txtCancelBy.Text);
                cm.Parameters.AddWithValue("@reason", cancelOrder.txtReason.Text);
                cm.Parameters.AddWithValue("@action", cancelOrder.cboInventory.Text);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
