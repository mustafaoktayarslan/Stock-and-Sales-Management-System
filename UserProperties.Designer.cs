namespace MarketSystem
{
    partial class UserProperties
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.cbActivate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(97)))), ((int)(((byte)(107)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(372, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 45);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(272, 156);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(94, 45);
            this.btnApply.TabIndex = 33;
            this.btnApply.Text = "Kaydet";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(342, 26);
            this.txtName.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Activate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Role:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Full name:";
            // 
            // cbRole
            // 
            this.cbRole.BackColor = System.Drawing.Color.White;
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Kasiyer",
            "Yönetici"});
            this.cbRole.Location = new System.Drawing.Point(120, 79);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(342, 28);
            this.cbRole.TabIndex = 35;
            // 
            // cbActivate
            // 
            this.cbActivate.BackColor = System.Drawing.Color.White;
            this.cbActivate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActivate.FormattingEnabled = true;
            this.cbActivate.Items.AddRange(new object[] {
            "Aktif",
            "Pasif"});
            this.cbActivate.Location = new System.Drawing.Point(120, 121);
            this.cbActivate.Name = "cbActivate";
            this.cbActivate.Size = new System.Drawing.Size(342, 28);
            this.cbActivate.TabIndex = 36;
            // 
            // UserProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 213);
            this.Controls.Add(this.cbActivate);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kullanıcı Özellikleri";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnApply;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbRole;
        public System.Windows.Forms.ComboBox cbActivate;
    }
}