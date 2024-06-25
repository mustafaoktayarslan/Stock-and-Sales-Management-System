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
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection();
        DBConnect dbcon = new DBConnect();
        public Dashboard()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.myConnection());

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {   
            string sdate = DateTime.Now.ToString("yyyy-MM-dd");
            lblDalySale.Text = dbcon.ExtractData("SELECT ISNULL(SUM(total),0) AS total FROM tbCart WHERE status LIKE 'Satıldı' AND sdate BETWEEN '" + sdate + "' AND '" + sdate + "'").ToString("#,##0.00");
            lblTotalProduct.Text = dbcon.ExtractData("SELECT COUNT(*) FROM tblProduct").ToString("#,##0");
            lblStockOnHand.Text = dbcon.ExtractData("SELECT ISNULL(SUM(qty), 0) AS qty FROM tblProduct").ToString("#,##0");
            lblCriticalItems.Text = dbcon.ExtractData("SELECT COUNT(*) FROM viewCriticalItems").ToString("#,##0");

        }
    
    }
}
