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
    public partial class SupplierModule : Form
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        Supplier supplier;
        public SupplierModule(Supplier splr)
        {
            InitializeComponent();
            con=new SqlConnection(dbcon.myConnection());
            supplier=splr;
        }

        private void picCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearText()
        {
            txtAddress.Clear();
            txtConPerson.Clear();
            txtEmail.Clear();
            txtFaxNo.Clear();
            txtPhone.Clear();
            txtSupplier.Clear();

            
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtSupplier.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtSupplier.Text.Equals(""))
                {
                    if (MessageBox.Show("Bu satıcıyı kaydetmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO tbSupplier (supplier,address,contactperson,phone,email,fax) VALUES (@supplier,@address,@contactperson,@phone,@email,@fax)", con);
                        cmd.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@contactperson", txtConPerson.Text);
                        cmd.Parameters.AddWithValue("@phone", txtConPerson.Text);
                        cmd.Parameters.AddWithValue("@email",txtEmail.Text);
                        cmd.Parameters.AddWithValue("@fax", txtFaxNo.Text );

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarıyla Kaydedildi", "BİLGİ");
                        ClearText();
                        supplier.LoadSupplier();

                    }
                }
                else
                {
                    MessageBox.Show("Marka boş bırakılamaz!", "BİLGİ");

                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kişiyi güncellemek istediğinizden emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                cmd = new SqlCommand("UPDATE tbSupplier SET supplier=@supplier,address=@address,contactperson=@contactperson,phone=@phone,email=@email,fax=@fax WHERE id=@id", con);
  
                cmd.Parameters.AddWithValue("@id", lblid.Text);
                cmd.Parameters.AddWithValue("@supplier", txtSupplier.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@contactperson", txtConPerson.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@fax", txtFaxNo.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarıyla Kaydedildi", "BİLGİ");
                ClearText();
                supplier.LoadSupplier();

            }
        }
    }
}
