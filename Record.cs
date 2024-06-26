﻿using System;
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
    public partial class Record : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Record()
        {
            InitializeComponent();
            cn=new SqlConnection(dbcon.myConnection());
            cbTopSell.SelectedIndex = 0;
            LoadCriticalItems();
            LoadInventoryList();

        }
        
        public void LoadTopSelling()
        {
            string fromDate = dtFromTopSell.Value.ToString("yyyy-MM-dd");
            string toDate = dtToTopSell.Value.ToString("yyyy-MM-dd");
            int i = 0;
            dgvTopSelling.Rows.Clear();
            cn.Open();

            //Sort By Total Amount
            if (cbTopSell.Text == "Adete göre sırala")
            {
                cm = new SqlCommand("SELECT TOP 10 barcode, pdesc, isnull(sum(qty),0) AS qty, ISNULL(SUM(total),0) AS total FROM viewTopSelling WHERE sdate BETWEEN '" + fromDate + "' AND '" + toDate + "' AND status LIKE 'Satıldı' GROUP BY barcode, pdesc ORDER BY qty DESC", cn);
            }
            else if (cbTopSell.Text == "Toplam tutara göre sırala")
            {
                cm = new SqlCommand("SELECT TOP 10 barcode, pdesc, isnull(sum(qty),0) AS qty, ISNULL(SUM(total),0) AS total FROM viewTopSelling WHERE sdate BETWEEN '" + fromDate + "' AND '" + toDate + "' AND status LIKE 'Satıldı' GROUP BY barcode, pdesc ORDER BY total DESC", cn);
            }
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (!dr["barcode"].ToString().Equals("**Silindi**"))
                { 
                    i++;
                dgvTopSelling.Rows.Add(i, dr["barcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                }
            }
            dr.Close();
            cn.Close();
        }

        public void LoadSoldItems()
        {
            string fromDate = dtFromSoldItems.Value.ToString("yyyy-MM-dd");
            string toDate = dtToSoldItems.Value.ToString("yyyy-MM-dd");
            try
            {
                dgvSoldItems.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("SELECT c.barcode, p.pdesc, c.price, sum(c.qty) as qty, SUM(c.disc) AS disc, SUM(c.total) AS total FROM tbCart AS c INNER JOIN tblProduct AS p ON c.barcode=p.barcode WHERE status LIKE 'Satıldı' AND sdate BETWEEN '" + fromDate + "' AND '" + toDate + "' GROUP BY c.barcode, p.pdesc, c.price", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                        i++;
                    dgvSoldItems.Rows.Add(i, dr["barcode"].ToString(), dr["pdesc"].ToString(), double.Parse(dr["price"].ToString()).ToString("#,##0.00"), dr["qty"].ToString(), dr["disc"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    
                }
                dr.Close();
                cn.Close();

                cn.Open();
                cm = new SqlCommand("SELECT ISNULL(SUM(total),0) FROM tbCart WHERE status LIKE 'Satıldı' AND sdate BETWEEN '" +  dtFromSoldItems.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToSoldItems.Value.ToString("yyyy-MM-dd") + "'", cn);
                lblTotal.Text = double.Parse(cm.ExecuteScalar().ToString()).ToString("#,##0.00");
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadCriticalItems()
        {
            try
            {
                dgvCriticalItems.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("SELECT * FROM viewCriticalItems", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (!dr["barcode"].ToString().Equals("**silindi**"))
                    { 
                        i++;
                    dgvCriticalItems.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void LoadInventoryList()
        {
            try
            {
                dgvInventoryList.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("SELECT * FROM viewInventoryList", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (!dr["barcode"].ToString().Equals("**silindi**"))
                    { 
                        i++;
                    dgvInventoryList.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void LoadCancelItems()
        {
            string fromDate = dtFromCancel.Value.ToString("yyyy-MM-dd");
            string toDate = dtToCancel.Value.ToString("yyyy-MM-dd");
            int i = 0;
            dgvCancel.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM viewCancelItem WHERE sdate BETWEEN '" + fromDate + "' AND '" + toDate + "'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                    i++;
                    dgvCancel.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), DateTime.Parse(dr[6].ToString()).ToShortDateString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
              
             }
            dr.Close();
            cn.Close();
        }

        public void LoadStockInHist()
        {

            string fromDate = dtFromStockIn.Value.ToString("yyyy-MM-dd");
            string toDate = dtToStockIn.Value.ToString("yyyy-MM-dd");
            int i = 0;
            dgvStockIn.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM viewStockIn WHERE cast(sdate AS date) BETWEEN '" + fromDate + "' AND '" + toDate + "' AND status LIKE 'Tamamlandı'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                    i++;
                dgvStockIn.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }
      
            dr.Close();
            cn.Close();
        }


        private void btnLoadTopSell_Click(object sender, EventArgs e)
        {
            LoadTopSelling();
        }

        private void btnLoadSoldItems_Click(object sender, EventArgs e)
        {
            LoadSoldItems();
        }

        private void btnLoadCancel_Click(object sender, EventArgs e)
        {
            LoadCancelItems();  
        }

        private void btnLoadStockIn_Click(object sender, EventArgs e)
        {
            LoadStockInHist();
        }

        private void btnPrintTopSell_Click(object sender, EventArgs e)
        {
            string fromDate = dtFromTopSell.Value.ToString("yyyy-MM-dd");
            string toDate = dtToTopSell.Value.ToString("yyyy-MM-dd");
            POSReport report = new POSReport();
            string param = "Tarihleri arasında : " + dtFromTopSell.Value.ToString("yyyy/MM/dd") + " ile : " + dtToTopSell.Value.ToString("yyyy/MM/dd");
           
            if (cbTopSell.SelectedIndex == 0)
            {
                report.LoadTopSelling("SELECT TOP 10 barcode, pdesc, isnull(sum(qty),0) AS qty, ISNULL(SUM(total),0) AS total FROM viewTopSelling WHERE sdate BETWEEN '" + fromDate + "' AND '" + toDate + "' AND  barcode <> '**Silindi**' AND status LIKE 'Satıldı' GROUP BY barcode, pdesc ORDER BY qty DESC ", param, "ADETE GÖRE SIRALANMIŞ EN ÇOK SATAN ÜRÜNLER");
            }
            else if (cbTopSell.SelectedIndex == 1)
            {
                report.LoadTopSelling("SELECT TOP 10 barcode, pdesc, isnull(sum(qty),0) AS qty, ISNULL(SUM(total),0) AS total FROM viewTopSelling WHERE sdate BETWEEN '" + fromDate + "' AND '" + toDate + "' AND  barcode <> '**Silindi**' AND status LIKE 'Satıldı' GROUP BY barcode, pdesc ORDER BY total DESC", param, "FİYATA GÖRE SIRALANMIŞ EN ÇOK SATAN ÜRÜNLER");
            }
            report.ShowDialog();
        }

        private void btnPrintSoldItems_Click(object sender, EventArgs e)
        {   

            string fromDate = dtFromSoldItems.Value.ToString("yyyy-MM-dd");
            string toDate = dtToSoldItems.Value.ToString("yyyy-MM-dd");
            POSReport report = new POSReport();
            string param = "Tarihleri Arasında : " + dtFromSoldItems.Value.ToString("yyyy-MM-dd") + " ile " + dtToSoldItems.Value.ToString("yyyy-MM-dd");
            report.LoadSoldItems("SELECT c.barcode, p.pdesc, c.price, sum(c.qty) as qty, SUM(c.disc) AS disc, SUM(c.total) AS total FROM tbCart AS c INNER JOIN tblProduct AS p ON c.barcode=p.barcode WHERE  status LIKE 'Satıldı' AND sdate BETWEEN '" + fromDate + "' AND '" + toDate  + "' GROUP BY c.barcode, p.pdesc, c.price",param);
            report.ShowDialog();
        }

        private void btnPrintInventoryList_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            report.LoadInventory("SELECT * FROM viewInventoryList WHERE barcode <> '**Silindi**'");
            report.ShowDialog();
        }

        private void btnPrintCancel_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            string param = "Tarihleri Arasında : " + dtFromCancel.Value.ToString("yyyy/MM/dd") + " ile " + dtToCancel.Value.ToString("yyyy/MM/dd");
            report.LoadCancelledOrder("SELECT * FROM viewCancelItem WHERE sdate BETWEEN '" + dtFromCancel.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToCancel.Value.ToString("yyyy-MM-dd") + "'", param);
            report.ShowDialog();
        }

        

        private void btnPrintStockIn_Click(object sender, EventArgs e)
        {
            POSReport report = new POSReport();
            string param = "Tarihleri Arasında : " + dtFromStockIn.Value.ToString("yyyy/MM/dd") + " ile " + dtToStockIn.Value.ToString("yyyy/MM/dd");
            report.LoadStockInHist("SELECT * FROM viewStockIn WHERE cast(sdate AS date) BETWEEN '" + dtFromStockIn.Value.ToString("yyyy-MM-dd") + "' AND '" + dtToStockIn.Value.ToString("yyyy-MM-dd") + "' AND status LIKE 'Tamamlandı'", param);
            report.ShowDialog();
        }

     
    }
}
