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
    public partial class ChangePassword : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        CashierForm cashier;
        public ChangePassword(CashierForm cshr)
        {
            InitializeComponent();
            cashier = cshr;
            lblUsername.Text = cashier.lblUsername.Text;

        }

     

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string oldpass = dbcon.getPassword(lblUsername.Text);
                if (oldpass != txtPass.Text)
                {
                    MessageBox.Show("Yanlış şifre tekrar deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    txtPass.Visible = false;
                    btnNext.Visible = false;

                    txtNewPass.Visible = true;
                    txtComPass.Visible = true;
                    btnSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPass.Text != txtComPass.Text)
                {
                    MessageBox.Show("Şifreler uyuşmuyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Şifre değiştirilsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dbcon.ExecuteQuery("UPDATE tbUser set password = '" + txtNewPass.Text + "' WHERE username = '" + lblUsername.Text + "'");
                        MessageBox.Show("Şifre başarıyla değiştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }

        private void picClose_Click_1(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
