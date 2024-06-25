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
using Microsoft.Reporting.WinForms;



namespace MarketSystem
{
    
    public partial class Recept : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string store;
        string address;
        CashierForm cashier;
        public Recept(CashierForm cash)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cashier = cash;
            LoadStore();
        }

        private void Recept_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public void LoadStore()
        {
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tbStore", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                store = dr["store"].ToString();
                address = dr["address"].ToString();
            }
            dr.Close();
            cn.Close();
        }


        public void LoadRecept(string pcash, string pchange)
        {
            ReportDataSource rptDataSourece;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptRecept.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand("SELECT c.id, c.transno, c.barcode, c.price, c.qty, c.disc, c.total, c.sdate, c.status, p.pdesc FROM tbCart AS c INNER JOIN tblProduct AS p ON p.barcode=c.barcode WHERE c.transno LIKE '" + cashier.lblTranNo.Text + "'", cn);
                da.Fill(ds.Tables["dtRecept"]);
                cn.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", cashier.lblVatable.Text);
                ReportParameter pVat = new ReportParameter("pVat", cashier.lblTax.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", cashier.lblDiscount.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", cashier.txtDisplayTotal.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcash);
                ReportParameter pChange = new ReportParameter("pChange", pchange);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pTransaction = new ReportParameter("pTransaciton", "İşlem No :   " + cashier.lblTranNo.Text);
                ReportParameter pCashier = new ReportParameter("pCashierr",cashier.lblUsername.Text);

                reportViewer1.LocalReport.SetParameters(pVatable);
                reportViewer1.LocalReport.SetParameters(pVat);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pStore);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pTransaction);
                reportViewer1.LocalReport.SetParameters(pCashier);

                rptDataSourece = new ReportDataSource("DataSet1", ds.Tables["dtRecept"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 30;


            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }


        }

    }
}
