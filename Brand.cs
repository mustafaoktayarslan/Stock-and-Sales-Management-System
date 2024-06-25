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
    public partial class Brand : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Brand()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            LoadBrand();
          
        }

        public void LoadBrand()
        {
            int i = 0;
            dgvBrand.Rows.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tbBrand ORDER BY brand", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["id"].ToString() != "0") 
                { 
                    i++;
                dgvBrand.Rows.Add(i, dr["id"].ToString(), dr["brand"].ToString());
                }
            }
            dr.Close();
            con.Close();
        }
     
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BrandModule brandModule = new BrandModule(this);
            brandModule.btnUpdate.Enabled = false;
            brandModule.ShowDialog();
        }

        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBrand.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bu markayı silmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbBrand WHERE id LIKE '" + dgvBrand[1, e.RowIndex].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla SİLİNDİ", "BİLGİ");
                    LoadBrand();

                }
            }
            else if (colName == "Edit")
            {
                BrandModule brandModule = new BrandModule(this);
                brandModule.lblid.Text = dgvBrand[1, e.RowIndex].Value.ToString();
                brandModule.txtBrand.Text = dgvBrand[2, e.RowIndex].Value.ToString();
                brandModule.btnSave.Enabled = false;
                brandModule.btnUpdate.Enabled = true;
                brandModule.ShowDialog();
                LoadBrand();

            }
        }
    }
}
