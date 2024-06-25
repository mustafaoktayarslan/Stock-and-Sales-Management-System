namespace MarketSystem
{
    partial class ResetPassword
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
            this.btnOk = new System.Windows.Forms.Button();
            this.txtNpass = new System.Windows.Forms.TextBox();
            this.txtResPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(97)))), ((int)(((byte)(107)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(356, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 40);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(85)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(256, 121);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 40);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "Tamam";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNpass
            // 
            this.txtNpass.Location = new System.Drawing.Point(150, 42);
            this.txtNpass.Name = "txtNpass";
            this.txtNpass.Size = new System.Drawing.Size(295, 26);
            this.txtNpass.TabIndex = 27;
            this.txtNpass.UseSystemPasswordChar = true;
            // 
            // txtResPass
            // 
            this.txtResPass.Location = new System.Drawing.Point(150, 75);
            this.txtResPass.Name = "txtResPass";
            this.txtResPass.Size = new System.Drawing.Size(295, 26);
            this.txtResPass.TabIndex = 28;
            this.txtResPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Yeni Şifre Tekrarı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Yeni Şifre :";
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 173);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNpass);
            this.Controls.Add(this.txtResPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parola Sıfırla";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResetPassword_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtNpass;
        private System.Windows.Forms.TextBox txtResPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}