namespace MarketSystem
{
    partial class Void
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Void));
            this.picCLose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtPass = new MetroFramework.Controls.MetroTextBox();
            this.btnVoid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCLose)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCLose
            // 
            this.picCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCLose.Image = ((System.Drawing.Image)(resources.GetObject("picCLose.Image")));
            this.picCLose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picCLose.Location = new System.Drawing.Point(356, 3);
            this.picCLose.Name = "picCLose";
            this.picCLose.Size = new System.Drawing.Size(30, 30);
            this.picCLose.TabIndex = 1;
            this.picCLose.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.picCLose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 49);
            this.panel1.TabIndex = 15;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitle.Location = new System.Drawing.Point(12, 14);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(107, 19);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Ürün Modülü";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.CustomButton.Image = null;
            this.txtUsername.CustomButton.Location = new System.Drawing.Point(238, 1);
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = 1;
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = false;
            this.txtUsername.DisplayIcon = true;
            this.txtUsername.Icon = ((System.Drawing.Image)(resources.GetObject("txtUsername.Icon")));
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(61, 73);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PromptText = "Username";
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(268, 31);
            this.txtUsername.TabIndex = 17;
            this.txtUsername.UseSelectable = true;
            this.txtUsername.WaterMark = "Username";
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.CustomButton.Image = null;
            this.txtPass.CustomButton.Location = new System.Drawing.Point(238, 1);
            this.txtPass.CustomButton.Name = "";
            this.txtPass.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.txtPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPass.CustomButton.TabIndex = 1;
            this.txtPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPass.CustomButton.UseSelectable = true;
            this.txtPass.CustomButton.Visible = false;
            this.txtPass.DisplayIcon = true;
            this.txtPass.Icon = ((System.Drawing.Image)(resources.GetObject("txtPass.Icon")));
            this.txtPass.Lines = new string[0];
            this.txtPass.Location = new System.Drawing.Point(61, 117);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.PromptText = "Password";
            this.txtPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPass.SelectedText = "";
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.ShortcutsEnabled = true;
            this.txtPass.Size = new System.Drawing.Size(268, 31);
            this.txtPass.TabIndex = 16;
            this.txtPass.UseSelectable = true;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.WaterMark = "Password";
            this.txtPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnVoid
            // 
            this.btnVoid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(80)))));
            this.btnVoid.FlatAppearance.BorderSize = 0;
            this.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoid.ForeColor = System.Drawing.Color.White;
            this.btnVoid.Location = new System.Drawing.Point(61, 170);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(268, 31);
            this.btnVoid.TabIndex = 18;
            this.btnVoid.Text = "Ürünü İptal Et";
            this.btnVoid.UseVisualStyleBackColor = false;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // Void
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 228);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Void";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Void";
            ((System.ComponentModel.ISupportInitialize)(this.picCLose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCLose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        public MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroTextBox txtPass;
        public System.Windows.Forms.Button btnVoid;
    }
}