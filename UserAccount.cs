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
    public partial class UserAccount : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        MainForm main;
        public string username;
        string name;
        string role;
        string accstatus;
        public UserAccount(MainForm mn)
        {
            InitializeComponent();
            con=new SqlConnection(dbcon.myConnection());
            main = mn;
            LoadUser();
        }
        private void ClearText()
        {
            txtName.Clear();
            txtPass.Clear();
            txtRePass.Clear();
            txtUsername.Clear();
            comboRole.SelectedIndex=-1;
            txtUsername.Focus();

        }
        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                if(dr[4].Equals("True"))
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[3].ToString(), "Aktif", dr[2].ToString());
                else dgvUser.Rows.Add(i, dr[0].ToString(), dr[3].ToString(), "Pasif", dr[2].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAccSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text!=txtRePass.Text) 
                {
                    MessageBox.Show("Şifreler eşleşmiyor!", "Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                
                    if (MessageBox.Show("Bu satıcıyı kaydetmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO tbUser (username,password,role,name) VALUES (@username,@password,@role,@name)", con);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPass.Text);
                        cmd.Parameters.AddWithValue("@role", comboRole.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarıyla Kaydedildi", "BİLGİ");
                        ClearText();
                    LoadUser();

                    }
                
               
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnPassSave_Click(object sender, EventArgs e)
        {
              try
                {
                    if (txtCurPass.Text != main._pass)
                    {
                        MessageBox.Show("Mevcut parola doğru değil!", "Geçersiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtNPass.Text != txtRePass2.Text)
                    {
                        MessageBox.Show("Yeni parolalar eşleşmiyor!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dbcon.ExecuteQuery("UPDATE tbUser SET password= '" + txtNPass.Text + "' WHERE username='" + lblUsername.Text + "'");
                    MessageBox.Show("Parola başarıyla kaydedildi!", "Şifre Değiştirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = main.lblUsername.Text;
        }

        public void ClearCP()
        {
            txtCurPass.Clear();
            txtNPass.Clear();
            txtRePass2.Clear();
        }

        private void btnPassCancel_Click(object sender, EventArgs e)
        {
            ClearCP(); 
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvUser.CurrentRow.Index;
            username = dgvUser[1, i].Value.ToString();
            name = dgvUser[2, i].Value.ToString();
            role = dgvUser[4, i].Value.ToString();
            accstatus = dgvUser[3, i].Value.ToString();
            if (lblUsername.Text == username)
            {
                btnRemove.Enabled = false;
                btnResetPass.Enabled = false;
                lblAccNote.Text = "Parolayı değiştirmek için \"Şifre Değiştir\" bölümüne gidin.";

            }
            else
            {
                btnRemove.Enabled = true;
                btnResetPass.Enabled = true;
                lblAccNote.Text = username + " kullanıcısının şifresini sıfırlamak için \"Parolayı Sıfırla\" butonuna tıklayın.";
            }
            gbUser.Text =  username+" için Şifre Sıfırlama";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Bu hesabı satış sisteminizden kaldırmayı seçtiniz. \n\n  '" + username + "' \\ '" + role + "' hesabını silmek istediğinizden emin misiniz?", "Kullanıcı Hesabı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                dbcon.ExecuteQuery("DELETE FROM tbUser WHERE username = '" + username + "'");
                MessageBox.Show("Hesap başarıyla silindi.");
                LoadUser();
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword(this);
            resetPassword.ShowDialog();
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            UserProperties properties = new UserProperties(this);
            properties.Text = name +"\\"+ username +" Properties";
            properties.txtName.Text = name;
            properties.cbRole.Text = role;
            properties.username = username;
            if(accstatus.Equals("True"))
            properties.cbActivate.Text = "Aktif";
            else 
            properties.cbActivate.Text = "Pasif";


            properties.ShowDialog();
        }

       
    }
}
