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
    public partial class Settle : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        CashierForm cashier;
        int iter=0;
        public Settle(CashierForm cash)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            this.KeyPreview = true;
            cashier = cash;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnOne.Text;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnTwo.Text;

        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnThree.Text;

        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnFour.Text;

        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnFive.Text;

        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnSix.Text;
                
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnSeven.Text;

        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnEight.Text;

        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnNine.Text;

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnZero.Text;

        }

        private void btnDZero_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnDZero.Text;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCash.Clear();
            txtCash.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtCash.Text.Equals("")))
                {
                    MessageBox.Show("Ödeme miktarı yetersiz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if ((double.Parse(txtChange.Text) < 0))
                    {
                    MessageBox.Show("Ödeme miktarı yetersiz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int i = 0; i < cashier.dgvCashier.Rows.Count; i++)
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE tblProduct SET qty = qty - " + int.Parse(cashier.dgvCashier.Rows[i].Cells[4].Value.ToString()) + "WHERE barcode= '" + cashier.dgvCashier.Rows[i].Cells[2].Value.ToString() + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        cmd = new SqlCommand("UPDATE tbCart SET status = 'Satıldı' WHERE id= '" + cashier.dgvCashier.Rows[i].Cells[1].Value.ToString() + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    Recept recept = new Recept(cashier);
                    recept.LoadRecept(txtCash.Text, txtChange.Text);
                    recept.ShowDialog();

                    //     MessageBox.Show("Ödeme başarıyla kaydedildi", "Ödeme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cashier.GetTransNo();
                    cashier.LoadCart();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                this.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {   
          
            if (txtCash .Text.Contains("."))
            {
                iter++;
                txtCash.Text = txtCash.Text.Replace(".", ",");
                txtCash.SelectionStart = txtCash.Text.Length;
            }
            try
            {
                double sale = double.Parse(txtSale.Text);
                double cash = double.Parse(txtCash.Text);
                double charge = cash - sale;
                txtChange.Text = charge.ToString("#,##0.00");
            }
            catch (Exception)
            {
                txtChange.Text = "0.00";
            }
        }

        private void Settle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            else if (e.KeyCode == Keys.Enter)
            {
                btnEnter.PerformClick();
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && txtCash.Text.Contains(",") || txtCash.Text.Contains("."))
            {
                e.Handled = true; // İşlenmemiş olarak işaretle, karakteri engelle
            }

        }
    }
}
