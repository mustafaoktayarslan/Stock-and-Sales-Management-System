namespace MarketSystem
{
    partial class StockIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockIn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvStockIn = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboSupplier = new System.Windows.Forms.ComboBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConPerson = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkProduct = new System.Windows.Forms.LinkLabel();
            this.dtpStockIn = new System.Windows.Forms.DateTimePicker();
            this.linkGenerate = new System.Windows.Forms.LinkLabel();
            this.txtStockInBy = new System.Windows.Forms.TextBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.dgvInStockHistory = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).BeginInit();
            this.panel2.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStockHistory)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 61);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stok Giriş";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(984, 500);
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.btnSave);
            this.metroTabPage2.Controls.Add(this.dgvStockIn);
            this.metroTabPage2.Controls.Add(this.panel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 1;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(976, 458);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Stok Ekle";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(878, 419);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 36);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Stok Gir";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvStockIn
            // 
            this.dgvStockIn.AllowUserToAddRows = false;
            this.dgvStockIn.AllowUserToResizeColumns = false;
            this.dgvStockIn.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockIn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockIn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockIn.ColumnHeadersHeight = 35;
            this.dgvStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStockIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column9,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Delete});
            this.dgvStockIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvStockIn.EnableHeadersVisualStyles = false;
            this.dgvStockIn.Location = new System.Drawing.Point(0, 145);
            this.dgvStockIn.Name = "dgvStockIn";
            this.dgvStockIn.RowHeadersVisible = false;
            this.dgvStockIn.RowTemplate.Height = 30;
            this.dgvStockIn.Size = new System.Drawing.Size(976, 257);
            this.dgvStockIn.TabIndex = 4;
            this.dgvStockIn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockIn_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 34;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Id";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 49;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "Referans No";
            this.Column9.Name = "Column9";
            this.Column9.Width = 121;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Barkod";
            this.Column3.Name = "Column3";
            this.Column3.Width = 84;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "İsim";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Adet";
            this.Column5.Name = "Column5";
            this.Column5.Width = 68;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Stok Tarihi";
            this.Column6.Name = "Column6";
            this.Column6.Width = 101;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Stoğu Giren";
            this.Column7.Name = "Column7";
            this.Column7.Width = 117;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Satıcı";
            this.Column8.Name = "Column8";
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column8.Width = 70;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.comboSupplier);
            this.panel2.Controls.Add(this.lblid);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtConPerson);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.linkProduct);
            this.panel2.Controls.Add(this.dtpStockIn);
            this.panel2.Controls.Add(this.linkGenerate);
            this.panel2.Controls.Add(this.txtStockInBy);
            this.panel2.Controls.Add(this.txtRefNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 145);
            this.panel2.TabIndex = 2;
            // 
            // comboSupplier
            // 
            this.comboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSupplier.FormattingEnabled = true;
            this.comboSupplier.Location = new System.Drawing.Point(602, 13);
            this.comboSupplier.Name = "comboSupplier";
            this.comboSupplier.Size = new System.Drawing.Size(308, 28);
            this.comboSupplier.TabIndex = 15;
            this.comboSupplier.SelectedIndexChanged += new System.EventHandler(this.comboSupplier_SelectedIndexChanged);
            this.comboSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboSupplier_KeyPress);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(916, 115);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(22, 20);
            this.lblid.TabIndex = 14;
            this.lblid.Text = "id";
            this.lblid.Visible = false;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(602, 86);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(308, 26);
            this.txtAddress.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(476, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Adres :";
            // 
            // txtConPerson
            // 
            this.txtConPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConPerson.Location = new System.Drawing.Point(602, 49);
            this.txtConPerson.Name = "txtConPerson";
            this.txtConPerson.Size = new System.Drawing.Size(308, 26);
            this.txtConPerson.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "İlgili Kişi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Satıcı :";
            // 
            // linkProduct
            // 
            this.linkProduct.AutoSize = true;
            this.linkProduct.DisabledLinkColor = System.Drawing.Color.Gray;
            this.linkProduct.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkProduct.Location = new System.Drawing.Point(146, 115);
            this.linkProduct.Name = "linkProduct";
            this.linkProduct.Size = new System.Drawing.Size(223, 20);
            this.linkProduct.TabIndex = 7;
            this.linkProduct.TabStop = true;
            this.linkProduct.Text = "[Buraya Tıkla ve Ürüne Gözat]";
            this.linkProduct.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProduct_LinkClicked);
            // 
            // dtpStockIn
            // 
            this.dtpStockIn.Enabled = false;
            this.dtpStockIn.Location = new System.Drawing.Point(150, 86);
            this.dtpStockIn.Name = "dtpStockIn";
            this.dtpStockIn.Size = new System.Drawing.Size(268, 26);
            this.dtpStockIn.TabIndex = 6;
            // 
            // linkGenerate
            // 
            this.linkGenerate.AutoSize = true;
            this.linkGenerate.DisabledLinkColor = System.Drawing.Color.Gray;
            this.linkGenerate.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkGenerate.Location = new System.Drawing.Point(368, 16);
            this.linkGenerate.Name = "linkGenerate";
            this.linkGenerate.Size = new System.Drawing.Size(50, 20);
            this.linkGenerate.TabIndex = 5;
            this.linkGenerate.TabStop = true;
            this.linkGenerate.Text = "[Üret]";
            this.linkGenerate.Visible = false;
            this.linkGenerate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGenerate_LinkClicked);
            // 
            // txtStockInBy
            // 
            this.txtStockInBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockInBy.Location = new System.Drawing.Point(149, 49);
            this.txtStockInBy.Name = "txtStockInBy";
            this.txtStockInBy.Size = new System.Drawing.Size(269, 26);
            this.txtStockInBy.TabIndex = 4;
            // 
            // txtRefNo
            // 
            this.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefNo.Enabled = false;
            this.txtRefNo.Location = new System.Drawing.Point(149, 14);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(213, 26);
            this.txtRefNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Stok Tarihi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Stoğu Giren :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Referance No :";
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.dgvInStockHistory);
            this.metroTabPage1.Controls.Add(this.panel3);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 1;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(976, 458);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Stok Giriş Kayıtları";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 1;
            // 
            // dgvInStockHistory
            // 
            this.dgvInStockHistory.AllowUserToAddRows = false;
            this.dgvInStockHistory.AllowUserToResizeColumns = false;
            this.dgvInStockHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInStockHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInStockHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInStockHistory.ColumnHeadersHeight = 35;
            this.dgvInStockHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInStockHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dgvInStockHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInStockHistory.EnableHeadersVisualStyles = false;
            this.dgvInStockHistory.Location = new System.Drawing.Point(0, 100);
            this.dgvInStockHistory.Name = "dgvInStockHistory";
            this.dgvInStockHistory.RowHeadersVisible = false;
            this.dgvInStockHistory.RowTemplate.Height = 30;
            this.dgvInStockHistory.Size = new System.Drawing.Size(976, 358);
            this.dgvInStockHistory.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 34;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 49;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Referans No";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 121;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "Barkod";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 84;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "İsim";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "Adet";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 68;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "Stok Tarihi";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 101;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "Stoğu Giren";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 117;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "Satıcı";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 100);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnLoad);
            this.panel4.Controls.Add(this.dtFrom);
            this.panel4.Controls.Add(this.dtTo);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(976, 72);
            this.panel4.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoad.Location = new System.Drawing.Point(493, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(98, 36);
            this.btnLoad.TabIndex = 40;
            this.btnLoad.Text = "Getir";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(164, 30);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(125, 26);
            this.dtFrom.TabIndex = 12;
            // 
            // dtTo
            // 
            this.dtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(327, 30);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(125, 26);
            this.dtTo.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tarihe Göre Filtrele :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "ile";
            // 
            // StockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.ControlBox = false;
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StockIn";
            this.Text = "STOK GİRİŞ";
            this.Load += new System.EventHandler(this.StockIn_Load);
            this.panel1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.metroTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStockHistory)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvStockIn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkProduct;
        private System.Windows.Forms.LinkLabel linkGenerate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.ComboBox comboSupplier;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.TextBox txtConPerson;
        public System.Windows.Forms.DateTimePicker dtpStockIn;
        public System.Windows.Forms.TextBox txtStockInBy;
        public System.Windows.Forms.TextBox txtRefNo;
        public System.Windows.Forms.Label lblid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridView dgvInStockHistory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.DateTimePicker dtFrom;
        public System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}