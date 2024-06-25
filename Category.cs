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
    public partial class Category : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Category()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            LoadCategory();
        }

        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tbCategory ORDER BY category", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {   
                if(dr["id"].ToString()!="0") 
                { 
                i++;
                dgvCategory.Rows.Add(i, dr["id"].ToString(), dr["category"].ToString());
                }
            }
            dr.Close();
            con.Close();

        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                

                    if (MessageBox.Show("Bu Kategoriyi silmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbCategory WHERE id LIKE '" + dgvCategory[1, e.RowIndex].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla SİLİNDİ", "BİLGİ");
                    LoadCategory();

                }
                
            }
            else if (colName == "Edit")
            {  
                    CategoryModule categoryModule = new CategoryModule(this);
                    categoryModule.lblid.Text = dgvCategory[1, e.RowIndex].Value.ToString();
                    categoryModule.txtCategory.Text = dgvCategory[2, e.RowIndex].Value.ToString();
                    categoryModule.btnSave.Enabled = false;
                    categoryModule.btnUpdate.Enabled = true;
                    categoryModule.ShowDialog();
                    LoadCategory();
         

            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            CategoryModule categoryModule = new CategoryModule(this);
            categoryModule.btnUpdate.Enabled = false;
            categoryModule.ShowDialog();
        }
    }
}
