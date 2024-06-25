namespace MarketSystem
{
    partial class ProductModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductModule));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.picCLose = new System.Windows.Forms.PictureBox();
            this.lblid = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPdesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBrand = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.UDReorder = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCLose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDReorder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.picCLose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 62);
            this.panel1.TabIndex = 14;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitle.Location = new System.Drawing.Point(12, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(107, 19);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Ürün Modülü";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCLose
            // 
            this.picCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCLose.Image = ((System.Drawing.Image)(resources.GetObject("picCLose.Image")));
            this.picCLose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picCLose.Location = new System.Drawing.Point(697, 3);
            this.picCLose.Name = "picCLose";
            this.picCLose.Size = new System.Drawing.Size(30, 30);
            this.picCLose.TabIndex = 1;
            this.picCLose.TabStop = false;
            this.picCLose.Click += new System.EventHandler(this.picCLose_Click);
            // 
            // lblid
            // 
            this.lblid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblid.AutoSize = true;
            this.lblid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblid.Location = new System.Drawing.Point(12, 342);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(22, 20);
            this.lblid.TabIndex = 20;
            this.lblid.Text = "id";
            this.lblid.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(97)))), ((int)(((byte)(107)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(455, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 38);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(145)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(342, 324);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 38);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(229, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 38);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(29, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Barkod :";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Location = new System.Drawing.Point(128, 92);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(242, 26);
            this.txtBarcode.TabIndex = 21;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(29, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tanım :";
            // 
            // txtPdesc
            // 
            this.txtPdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPdesc.Location = new System.Drawing.Point(128, 134);
            this.txtPdesc.Name = "txtPdesc";
            this.txtPdesc.Size = new System.Drawing.Size(567, 26);
            this.txtPdesc.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(26, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Marka :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(26, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Kategori :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(26, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fiyat :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(355, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Kritik Seviye :";
            // 
            // comboBrand
            // 
            this.comboBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrand.FormattingEnabled = true;
            this.comboBrand.Location = new System.Drawing.Point(128, 177);
            this.comboBrand.Name = "comboBrand";
            this.comboBrand.Size = new System.Drawing.Size(567, 28);
            this.comboBrand.TabIndex = 33;
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(128, 264);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(219, 26);
            this.txtPrice.TabIndex = 34;
            // 
            // comboCategory
            // 
            this.comboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(128, 220);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(567, 28);
            this.comboCategory.TabIndex = 35;
            // 
            // UDReorder
            // 
            this.UDReorder.Location = new System.Drawing.Point(475, 264);
            this.UDReorder.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.UDReorder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UDReorder.Name = "UDReorder";
            this.UDReorder.Size = new System.Drawing.Size(220, 26);
            this.UDReorder.TabIndex = 36;
            this.UDReorder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UDReorder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProductModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 385);
            this.Controls.Add(this.UDReorder);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.comboBrand);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPdesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductModule_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCLose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UDReorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox picCLose;
        public System.Windows.Forms.Label lblid;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPdesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.ComboBox comboBrand;
        public System.Windows.Forms.ComboBox comboCategory;
        public System.Windows.Forms.NumericUpDown UDReorder;
    }
}