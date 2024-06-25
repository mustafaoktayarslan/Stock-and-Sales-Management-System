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
    public partial class BrandModule : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Brand brand;
        public BrandModule(Brand br)    
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            brand = br;
            this.KeyPreview = true;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bu markayı güncellemek istediğinizden emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                cmd=new SqlCommand("UPDATE tbBrand SET brand=@brand WHERE id LIKE '"+lblid.Text+"'",con);
                cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarıyla Güncellendi", "BİLGİ");
                ClearText();
                this.Close();

            }

        }

        private void picCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtBrand.Text.Equals("")) 
                { 
                    if(MessageBox.Show("Bu markayı kaydetmek istediğinizden emin misiniz?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                    con.Open();
                    cmd=new SqlCommand("INSERT INTO tbBrand (brand) VALUES (@brand)",con);
                    cmd.Parameters.AddWithValue("@brand",txtBrand.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla Kaydedildi","BİLGİ");
                    ClearText();
                    brand.LoadBrand();

                    }
                }
                else
                {
                    MessageBox.Show("Marka boş bırakılamaz!", "BİLGİ");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        private void ClearText()
        {
            txtBrand.Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtBrand.Focus();

        }

        private void BrandModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
