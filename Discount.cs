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
    public partial class Discount : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        CashierForm cashier;
        public Discount(CashierForm cshr)
        {
            InitializeComponent();
            cashier = cshr;
            con = new SqlConnection(dbcon.myConnection());

        }

        private void picCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Contains("."))
            {
                txtDiscount.Text = txtDiscount.Text.Replace(".", ",");
                txtDiscount.SelectionStart=txtDiscount.Text.Length;
            }
            
            try
            {
                int _disc = int.Parse(txtDiscount.Text);
                if (_disc <= 100) 
                { 
                double disc=double.Parse(txtTotalPrice.Text) * double.Parse(txtDiscount.Text)* 0.01;
                txtDiscAmount.Text = disc.ToString("#,##0.00");
                }
                else
                {
                    MessageBox.Show("Ürüne %100 den fazla indirim uygulanamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                txtDiscAmount.Text = "0.00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE tbCart SET disc_percent=@disc_percent WHERE id =@id",con);
                cmd.Parameters.AddWithValue("@disc_percent", double.Parse(txtDiscount.Text));
                cmd.Parameters.AddWithValue("@id", int.Parse(lblid.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                cashier.LoadCart();
                this.Close();
            

            }
            catch(Exception ex) 
            { 
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            else if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

     
    }
}
