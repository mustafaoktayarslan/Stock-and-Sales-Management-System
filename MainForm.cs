using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarketSystem
{
    public partial class MainForm : Form
    {
        SqlConnection con=new SqlConnection();
        SqlCommand cmd=new SqlCommand(); 
        DBConnect dbcon= new DBConnect();
        SqlDataReader dr;
        public string _pass;
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
            con=new SqlConnection(dbcon.myConnection());
        }
        #region PanelSlide
        private void customizeDesign()
        {
            panelSubProduct.Visible = false;
            panelSubRecord.Visible = false;
            panelSubSettings.Visible = false;   
            panelSubStock.Visible = false;  
        }
       private void hideSubMenu()
        {
            if(panelSubProduct.Visible==true)
               panelSubProduct.Visible=false;
            if (panelSubRecord.Visible == true)
                panelSubRecord.Visible = false;
            if (panelSubSettings.Visible == true)
                panelSubSettings.Visible = false;
            if (panelSubStock.Visible == true)
                panelSubStock.Visible = false;
        }

        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        #endregion PanelSlide

        private Form activeForm =null;
        private Form temp=null; 

        public void openChildForm(Form childForm)
        {
            temp = activeForm;
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag=childForm;
            labelTitle.Text = childForm.Text;
            childForm.Show();
            childForm.BringToFront();

            if (temp != null)
            {
                temp.Dispose();
            }
        }

        public void Noti()
        {
            con.Open();
            int i = 0;
            cmd = new SqlCommand("SELECT * FROM viewCriticalItems", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                Alert alert = new Alert(this);
                alert.lblBarcode.Text = dr["barcode"].ToString();
                alert.btnReorder.Enabled = true;
                alert.showAlert(i + ". " + dr["pdesc"].ToString() + " - " + dr["qty"].ToString());
            }
            con.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        { openChildForm(new Dashboard());
            hideSubMenu();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubProduct);
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            openChildForm(new Product());
            hideSubMenu();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new Category());
            hideSubMenu();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            openChildForm(new Brand());
            hideSubMenu();
        }

        private void btnInStock_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubStock);
        }

        private void btnStockEntry_Click(object sender, EventArgs e)
        {
            openChildForm(new StockIn(this)); 
            hideSubMenu();
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Adjustments(this));
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new Supplier());  
            hideSubMenu();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubRecord);    
        }

        private void btnSaleHistory_Click(object sender, EventArgs e)
        {   
            hideSubMenu();
            DailySale dailySale = new DailySale(this);
            dailySale.panel1.Visible = false;
            openChildForm(dailySale);
        }

        private void btnPosRecord_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new Record());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubSettings);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserAccount(this));
            hideSubMenu();
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Store store = new Store();
            store.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
            Noti();
        }

     
    }
}
