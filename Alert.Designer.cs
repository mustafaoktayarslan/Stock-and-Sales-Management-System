namespace MarketSystem
{
    partial class Alert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReorder = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReorder);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblBarcode);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 75);
            this.panel1.TabIndex = 19;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(346, 62);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(16, 13);
            this.lblBarcode.TabIndex = 22;
            this.lblBarcode.Text = "br";
            this.lblBarcode.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(84, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(234, 57);
            this.lblMsg.TabIndex = 21;
            this.lblMsg.Text = "Message";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(331, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 31);
            this.btnClose.TabIndex = 24;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_2);
            // 
            // btnReorder
            // 
            this.btnReorder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReorder.BackgroundImage")));
            this.btnReorder.Enabled = false;
            this.btnReorder.FlatAppearance.BorderSize = 0;
            this.btnReorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReorder.ForeColor = System.Drawing.Color.White;
            this.btnReorder.Image = ((System.Drawing.Image)(resources.GetObject("btnReorder.Image")));
            this.btnReorder.Location = new System.Drawing.Point(12, 14);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(50, 50);
            this.btnReorder.TabIndex = 25;
            this.btnReorder.UseVisualStyleBackColor = true;
            this.btnReorder.Click += new System.EventHandler(this.btnReorder_Click);
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(370, 75);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alert";
            this.Text = "Alert";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblMsg;
        public System.Windows.Forms.Label lblBarcode;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.Button btnClose;
    }
}