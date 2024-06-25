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
    public partial class ProductModule : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        Product product;
        public ProductModule(Product prdct)
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());
            product= prdct;
            LoadCategory();
            LoadBrand();
            this.KeyPreview = true;
       
            
        }
        public void LoadCategory()
        {
            comboCategory.Items.Clear();
            comboCategory.DataSource = dbcon.getTable("SELECT * FROM tbCategory");
            comboCategory.DisplayMember = "category";
            comboCategory.ValueMember = "id";
        }
        public void LoadBrand()
        {
            comboBrand.Items.Clear();
            comboBrand.DataSource = dbcon.getTable("SELECT * FROM tbBrand");
            comboBrand.DisplayMember = "brand";
            comboBrand.ValueMember = "id";
        }

        private void picCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtPrice.Text.Equals("") && !txtPdesc.Text.Equals(""))
            {
                if (MessageBox.Show("Bu ürünü güncellemek istediğinizden emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tblProduct SET pdesc=@pdesc,bid=@bid,cid=@cid,price=@price,reorder=@reorder WHERE barcode LIKE '" + txtBarcode.Text + "'", con);
                    cmd.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cmd.Parameters.AddWithValue("@bid", comboBrand.SelectedValue);
                    cmd.Parameters.AddWithValue("@cid", comboCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@reorder", UDReorder.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla Güncellendi", "BİLGİ");
                    ClearText();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Boş alanları doldurun", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtPrice.Text.Equals("") && !txtPdesc.Text.Equals(""))
                {
                    if (MessageBox.Show("Bu ürünü kaydetmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO tblProduct (barcode,pdesc,bid,cid,price,reorder) VALUES (@barcode,@pdesc,@bid,@cid,@price,@reorder)", con);
                        cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.ToString());
                        cmd.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                        cmd.Parameters.AddWithValue("@bid", comboBrand.SelectedValue);
                        cmd.Parameters.AddWithValue("@cid", comboCategory.SelectedValue);
                        cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@reorder",UDReorder.Value);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarıyla Kaydedildi", "BİLGİ");
                        ClearText();
                        product.LoadProduct();

                    }
                }
                else
                {
                    MessageBox.Show("Boş bırakmayın!!", "BİLGİ");

                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearText()
        {
            txtBarcode.Clear();
            txtPrice.Clear();
            txtPdesc.Clear();
            comboBrand.SelectedIndex = 0;
            comboCategory.SelectedIndex =0; 
            UDReorder.Value = 1;

            txtBarcode.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtBarcode.Focus();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ProductModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        
        }


        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT p.barcode, p.pdesc , b.brand ,c.category,p.price,p.reorder FROM tblProduct AS p INNER JOIN tbBrand AS b  ON b.id =p.bid INNER JOIN tbCategory AS c ON c.id = p.cid WHERE barcode= '" + txtBarcode.Text + "'", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    txtPdesc.Text = dr["pdesc"].ToString();
                    comboBrand.Text = dr["brand"].ToString();
                    comboBrand.Text = dr["category"].ToString();
                    txtPrice.Text = dr["price"].ToString();
                    UDReorder.Value = int.Parse(dr["reorder"].ToString());
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    txtPrice.Clear();   
                    txtPdesc.Clear();
                    comboBrand.SelectedIndex = 0;
                    comboCategory.SelectedIndex = 0;
                    UDReorder.Value = 1;
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                }
                dr.Close();
                con.Close();
                
            }
            catch 
            {
                dr.Close();
                con.Close();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPdesc.Focus();
        }
    }
}
