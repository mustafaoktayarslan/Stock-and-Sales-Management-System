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
    public partial class StockIn : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        MainForm main;
        public StockIn(MainForm mn)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            main = mn;  
            LoadSupplier();
            LoadStockIn();
            comboSupplier.SelectedIndex = 0;
           

        }
        public void LoadStockIn()
        {
            int i = 0;
            dgvStockIn.Rows.Clear();
            con.Open();
            cmd=new SqlCommand("SELECT * FROM viewStockIn WHERE refno LIKE '"+txtRefNo.Text+"' AND status LIKE 'Beklemede'",con);   
            dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                 dgvStockIn.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr["supplier"].ToString());
            }
            dr.Close();
            con.Close();

        }
        public void GetRefNo()
        {
            // string sdate =  DateTime.Now.ToString("yyfddHHmmssMM");
            txtRefNo.Text = main.lblUsername.Text;

        }
        public void LoadSupplier()
        {
            
            comboSupplier.Items.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tbSupplier", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.Rows.RemoveAt(0);
            comboSupplier.DataSource = table;
            comboSupplier.DisplayMember = "supplier";
            comboSupplier.ValueMember = "id";
            con.Close();




        }

        private void comboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            con.Open();
            cmd=new SqlCommand("SELECT * FROM tbSupplier WHERE id LIKE '"+ comboSupplier.SelectedValue+"'",con);   

            dr= cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {   
                lblid.Text = dr["id"].ToString();
                txtConPerson.Text=dr["contactperson"].ToString();
                txtAddress.Text = dr["address"].ToString();

            }
            dr.Close();
            con.Close();
            }
            catch { }

        }

        private void comboSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;   
        }

        private void linkGenerate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetRefNo();
        }

        private void linkProduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductStockIn productStockIn = new ProductStockIn(this);
            productStockIn.ShowDialog();
             
        }
        public void ClearText()
        {
            txtRefNo.Clear();
            txtStockInBy.Clear();
            dtpStockIn.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Stoklara bu şekilde ekleme yapmak istiyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                   if(dgvStockIn.Rows.Count > 0 )
                    {
                        for (int i = 0; i < dgvStockIn.Rows.Count; i++)
                        {
                            con.Open();
                            cmd = new SqlCommand("UPDATE tblProduct SET qty=qty+"+ int.Parse(dgvStockIn.Rows[i].Cells[5].Value.ToString()) +"WHERE barcode LIKE '"+dgvStockIn.Rows[i].Cells[3].Value.ToString()+"'",con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            con.Open();
                            cmd = new SqlCommand("UPDATE tbStockIn SET qty=qty+" + int.Parse(dgvStockIn.Rows[i].Cells[5].Value.ToString()) + ", status='Tamamlandı'  WHERE id LIKE '" + dgvStockIn.Rows[i].Cells[1].Value.ToString() + "'", con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                        ClearText();
                        LoadStockIn();
                    }
                  

                }
                catch (Exception ex)
                {
                    con.Close();

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvStockIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStockIn.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Bu ürünü silmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbStockIn WHERE id LIKE '" + dgvStockIn.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla SİLİNDİ", "BİLGİ");
                    LoadStockIn();


                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string fromDate = dtFrom.Value.ToString("yyyy-MM-dd");
            string toDate = dtTo.Value.ToString("yyyy-MM-dd");

            try
            {
                int i = 0;
                dgvInStockHistory.Rows.Clear();
                con.Open();
                cmd = new SqlCommand("SELECT * FROM viewStockIn WHERE CAST(sdate as date) BETWEEN '" + fromDate + "' AND '" + toDate + "' AND status LIKE 'Tamamlandı'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvInStockHistory.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString(), dr["supplier"].ToString());

                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ProductForSupplier(string barcode,string name)
        {
            try { 
            string supplier = "";
            con.Open();
            cmd = new SqlCommand("SELECT * FROM viewStockIn WHERE barcode LIKE '" + barcode + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                supplier = dr["supplier"].ToString();
            }
            dr.Close();
            con.Close();
            comboSupplier.Text = supplier;
                txtStockInBy.Text = name;
            }
            catch { }
        }

        private void StockIn_Load(object sender, EventArgs e)
        {
            txtRefNo.Text = main.lblUsername.Text;
            txtStockInBy.Text=main.lblName.Text;

            try { 
            con.Open();
            cmd=new SqlCommand("SELECT * FROM tbSupplier WHERE id LIKE '"+ comboSupplier.SelectedValue+"'",con);   

            dr= cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {   
                lblid.Text = dr["id"].ToString();
                txtConPerson.Text=dr["contactperson"].ToString();
                txtAddress.Text = dr["address"].ToString();

            }
            dr.Close();
            con.Close();
            }
            catch { }
        }

     
    }
}
