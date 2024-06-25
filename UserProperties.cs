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
    public partial class UserProperties : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();

        UserAccount user;
        public string username;
        public UserProperties(UserAccount usr)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            user = usr;  
        }

        private void btnApply_Click(object sender, EventArgs e)
        {   string activate;
            if (cbActivate.Text.Equals("Aktif"))
                activate = "True";
            else
                activate = "False";
            try
            {
                if ((MessageBox.Show("Bu hesabın özelliklerini değiştirmek ister misiniz?", "Özellik Değişikliği", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE tbUser SET name=@name, role=@role, isactive=@isactive WHERE username='" + username + "'", con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@role", cbRole.Text);
                    cmd.Parameters.AddWithValue("@isactive", activate);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Özellikeler başarıyla güncellendi.", "Özellikler Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    user.LoadUser();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
