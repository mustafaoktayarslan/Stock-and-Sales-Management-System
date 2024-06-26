﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketSystem
{
    public partial class CancelOrder : Form
    {
        DailySale dailySale;

        public CancelOrder(DailySale sale)
        {
            InitializeComponent();
            dailySale = sale;   
        }

        private void CancelOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboInventory.Text != string.Empty && udCancelQty.Value > 0 && txtReason.Text != string.Empty)
                {
                    if (int.Parse(txtQty.Text) >= udCancelQty.Value)
                    {
                        Void @void = new Void(this);
                        @void.txtUsername.Focus();
                        @void.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ReloadSoldList()
        {
            dailySale.LoadSold();
        }
    }
}
