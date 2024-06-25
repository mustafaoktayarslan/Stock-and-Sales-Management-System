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
    public partial class CategoryModule : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Category category;
        public CategoryModule(Category ctgry)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            category = ctgry;
            this.KeyPreview = true;
        }
        private void ClearText()
        {
            txtCategory.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtCategory.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCategory.Text.Equals(""))
                {
                    if (MessageBox.Show("Bu Kategoriyi kaydetmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO tbCategory (category) VALUES (@category)", con);
                        cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarıyla Kaydedildi", "BİLGİ");
                        ClearText();
                        category.LoadCategory();

                    }
                }
                else
                {
                    MessageBox.Show("Kategori boş bırakılamaz!", "BİLGİ");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu Kategoriyi güncellemek istediğinizden emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                cmd = new SqlCommand("UPDATE tbCategory SET category=@category WHERE id LIKE '" + lblid.Text + "'", con);
                cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarıyla Güncellendi", "BİLGİ");
                ClearText();
                this.Close();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void picCLose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
