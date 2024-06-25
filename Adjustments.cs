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
    public partial class Adjustments : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        MainForm main;
        int _qty;
        public Adjustments(MainForm mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            main = mn;
            ReferenceNo();
            LoadStock();
            lblUsername.Text = main.lblUsername.Text;
            

        }
        public void ReferenceNo()
        {
            string sdate = DateTime.Now.ToString("yyfddHHmmssMM");
            lblRefNo.Text = sdate;
        }
        public void LoadStock()
        {
            int i = 0;
            dgvAdjustment.Rows.Clear();
            cm = new SqlCommand("SELECT p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty FROM tblProduct AS p INNER JOIN tbBrand AS b ON b.id = p.bid INNER JOIN tbCategory AS c on c.id = p.cid WHERE CONCAT(p.pdesc, b.brand, c.category) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (!dr["barcode"].ToString().Equals("**silindi**")) { 
                i++;
                dgvAdjustment.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            dr.Close();
            cn.Close();
        }

        private void dgvAdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAdjustment.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                lblBarcode.Text = dgvAdjustment.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblDesc.Text = dgvAdjustment.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dgvAdjustment.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dgvAdjustment.Rows[e.RowIndex].Cells[4].Value.ToString();
                _qty = int.Parse(dgvAdjustment.Rows[e.RowIndex].Cells[6].Value.ToString());
                btnSave.Enabled = true;
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            LoadStock();
        }

        public void Clear()
        {
            lblDesc.Text = "";
            lblBarcode.Text = "";
            txtQty.Clear();
            txtRemark.Clear();
            cbAction.Text = "";
            ReferenceNo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validation for empty field
                if (cbAction.Text == "")
                {
                    MessageBox.Show("Lütfen işlem türünü seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbAction.Focus();
                    return;
                }

                if (txtQty.Text == "")
                {
                    MessageBox.Show("Lütfen miktarı seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQty.Focus();
                    return;
                }

                if (txtRemark.Text == "")
                {
                    MessageBox.Show("Açıklama girin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRemark.Focus();
                    return;
                }

                //update stock
                
                if (cbAction.Text == "Envanterden Kaldır")
                {
                    if (int.Parse(txtQty.Text) > _qty)
                    {
                        MessageBox.Show("Eldeki stok miktarı girdiğinizden fazla olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    dbcon.ExecuteQuery("UPDATE tblProduct SET qty = (qty - " + int.Parse(txtQty.Text) + ") WHERE barcode LIKE '" + lblBarcode.Text + "'");
                }
                else if (cbAction.Text == "Envantere Ekle")
                {
                    dbcon.ExecuteQuery("UPDATE tblProduct SET qty = (qty + " + int.Parse(txtQty.Text) + ") WHERE barcode LIKE '" + lblBarcode.Text + "'");
                }

                try
                {
                    string supplierid = "";
                    try
                    {
                       
                        cn.Open();
                        cm = new SqlCommand("SELECT * FROM tbStockIn WHERE barcode LIKE '" + lblBarcode.Text + "'", cn);
                        dr = cm.ExecuteReader();
                        while (dr.Read())
                        {
                            supplierid = dr["supplierid"].ToString();
                        }
                        dr.Close();
                        cn.Close();
                       
                    }
                    catch { 
                        cn.Close();
                        dr.Close();
                    }
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tbStockIn (refno,barcode,sdate,stockinby,supplierid,qty,status) VALUES (@refno,@barcode,@sdate,@stockinby,@supplierid,@qty,@status)", cn);
                    cm.Parameters.AddWithValue("@refno",lblUsername.Text);
                    cm.Parameters.AddWithValue("@barcode", lblBarcode.Text);
                    cm.Parameters.AddWithValue("@sdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    cm.Parameters.AddWithValue("@stockinby", (main.lblName.Text));
                    cm.Parameters.AddWithValue("@supplierid", supplierid);
                    if (cbAction.Text == "Envanterden Kaldır")
                        cm.Parameters.AddWithValue("@qty",int.Parse("-"+txtQty.Text));
                    else
                        cm.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));

                    cm.Parameters.AddWithValue("@status", "Tamamlandı");

                    cm.ExecuteNonQuery();
                    cn.Close();
                 



                }
                catch (Exception ex)
                {
                    cn.Close();

                    MessageBox.Show(ex.Message);
                }

                dbcon.ExecuteQuery("INSERT INTO tbAdjustment (refno, barcode, qty, action, remarks, sdate, [user]) VALUES ('" + lblRefNo.Text + "','" + lblBarcode.Text + "','" + int.Parse(txtQty.Text) + "', '" + cbAction.Text + "', '" + txtRemark.Text + "', '" + DateTime.Now.ToShortDateString() + "','" + lblUsername.Text + "')");
                MessageBox.Show("Başarıyla Kaydedildi.", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStock();
                Clear();
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStock();
        }

     
    }
}
