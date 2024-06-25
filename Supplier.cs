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
    public partial class Supplier : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        public Supplier()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            LoadSupplier();
        }

        public void LoadSupplier()
        {
            int i = 0;
            dgvSupplier.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbSupplier", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["id"].ToString() != "0") { 
                    i++;
                dgvSupplier.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierModule supplierModule = new SupplierModule(this);
            supplierModule.ShowDialog();

        }


        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSupplier.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {   
                
                if (MessageBox.Show("Bu ürünü silmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbSupplier WHERE id LIKE '" + dgvSupplier[1, e.RowIndex].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla SİLİNDİ", "BİLGİ");
                    LoadSupplier();

                }
            }
            else if (colName == "Edit")
            {
                //if (dgvSupplier[1, e.RowIndex].Value.ToString() == "0") { return; }
                SupplierModule supplierModule= new SupplierModule(this);
                supplierModule.lblid.Text = dgvSupplier[1, e.RowIndex].Value.ToString();
                supplierModule.txtSupplier.Text = dgvSupplier[2, e.RowIndex].Value.ToString();
                supplierModule.txtAddress.Text = dgvSupplier[3, e.RowIndex].Value.ToString();
                supplierModule.txtConPerson.Text = dgvSupplier[4, e.RowIndex].Value.ToString();
                supplierModule.txtPhone.Text = dgvSupplier[5, e.RowIndex].Value.ToString();
                supplierModule.txtEmail.Text = dgvSupplier[6, e.RowIndex].Value.ToString();
                supplierModule.txtFaxNo.Text = dgvSupplier[7, e.RowIndex].Value.ToString();

                supplierModule.btnSave.Enabled = false;
                supplierModule.btnUpdate.Enabled = true;
                supplierModule.ShowDialog();
                LoadSupplier();

            }
        }
    }
}
