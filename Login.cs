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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public string _pass = "";
        public bool _isactivate;
        CashierForm cashier;


        public Login()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            txtName.Focus();

        }

        private void picCLose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
               
            }
        }
        private void Cashier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cashier.dgvCashier.Rows.Count == 0)
            {   
                if (MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    this.Show();
                    cashier.Dispose();

                }
                else
                {
                    e.Cancel = true;
                }
            }
            else {

                e.Cancel = true;
                MessageBox.Show("Satış ekranında ürün var satışı tamamlayın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {   
                this.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string _username = "", _name = "", _role = "";
            try
            {
                bool found=false;
                con.Open();
                cmd = new SqlCommand("Select * From tbUser Where username = @username and password = @password", con);
                cmd.Parameters.AddWithValue("@username", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _username = dr["username"].ToString();
                    _name = dr["name"].ToString();
                    _role = dr["role"].ToString();
                    _pass = dr["password"].ToString();
                    _isactivate = bool.Parse(dr["isactive"].ToString());

                }
                else
                {
                    found = false;
                }
                dr.Close();
                con.Close();

                if (found)
                {
                    if (!_isactivate)
                    {
                        MessageBox.Show("Hesap devre dışı giriş yapılamıyor.", "Pasif Hesap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_role == "Kasiyer")
                    {
                        MessageBox.Show("Hoşgeldiniz " + _name , "ERİŞİM İZNİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Clear();
                        txtPass.Clear();
                        this.Hide();
                        cashier = new CashierForm(this);
                        cashier.lblUsername.Text = _username;
                        cashier.lblname.Text = _name + " | " + _role;
                        cashier.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cashier_FormClosing);
                        cashier.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Hoşgeldiniz " + _name , "ERİŞİM İZNİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Clear();
                        txtPass.Clear();
                        this.Hide();
                        MainForm main = new MainForm();
                        main.lblUsername.Text = _username;
                        main.lblName.Text = _name;
                        main._pass = _pass;
                        main.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);

                        main.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz kullanıcı adı ve şifre!", "ERİŞİM REDDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnLogin.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           txtName.Clear();
            txtPass.Clear();
        }

    }
}
