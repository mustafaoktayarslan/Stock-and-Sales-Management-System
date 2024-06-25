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
    public partial class ResetPassword : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        UserAccount user;
        public ResetPassword(UserAccount usr)
        {
           
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            user = usr;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (txtNpass.Text != txtResPass.Text)
            {
                MessageBox.Show("Şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Parolayı Sıfırla", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbcon.ExecuteQuery("UPDATE tbUser SET password = '" + txtNpass.Text + "'WHERE username = '" + user.username + "'");
                    MessageBox.Show("Parola başarıyla sıfırlandı", "Paraola Sıfırlama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void ResetPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
