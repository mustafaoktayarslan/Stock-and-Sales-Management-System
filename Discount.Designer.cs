namespace MarketSystem
{
    partial class Discount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Discount));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.picCLose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtDiscAmount = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCLose)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(674, 62);
            this.panel1.TabIndex = 15;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitle.Location = new System.Drawing.Point(12, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(63, 19);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "İndirim";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCLose
            // 
            this.picCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCLose.Image = ((System.Drawing.Image)(resources.GetObject("picCLose.Image")));
            this.picCLose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picCLose.Location = new System.Drawing.Point(641, 3);
            this.picCLose.Name = "picCLose";
            this.picCLose.Size = new System.Drawing.Size(30, 30);
            this.picCLose.TabIndex = 1;
            this.picCLose.TabStop = false;
            this.picCLose.Click += new System.EventHandler(this.picCLose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Toplam Fiyat :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "İndirim (%) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "İndirim Tutarı :";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPrice.Enabled = false;
            this.txtTotalPrice.Location = new System.Drawing.Point(146, 91);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(488, 26);
            this.txtTotalPrice.TabIndex = 19;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Location = new System.Drawing.Point(146, 125);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(488, 26);
            this.txtDiscount.TabIndex = 20;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            // 
            // txtDiscAmount
            // 
            this.txtDiscAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscAmount.Enabled = false;
            this.txtDiscAmount.Location = new System.Drawing.Point(146, 159);
            this.txtDiscAmount.Name = "txtDiscAmount";
            this.txtDiscAmount.Size = new System.Drawing.Size(488, 26);
            this.txtDiscAmount.TabIndex = 21;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(12, 215);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(22, 20);
            this.lblid.TabIndex = 22;
            this.lblid.Text = "id";
            this.lblid.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(536, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 38);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Onayla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Discount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(674, 255);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.txtDiscAmount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "İNDİRİM";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCLose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox picCLose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtTotalPrice;
        public System.Windows.Forms.TextBox txtDiscount;
        public System.Windows.Forms.TextBox txtDiscAmount;
        public System.Windows.Forms.Label lblid;
    }
}