namespace KoctasWM_Project
{
    partial class frm_43_Kargo_Alani_Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_43_Kargo_Alani_Transfer));
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.txtPaletNo = new System.Windows.Forms.TextBox();
            this.lbl_DagitimAdresiOlmasiGereken = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Transfer = new KoctasWM_Project.PictureButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_LoginInfo
            // 
            this.lbl_LoginInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbl_LoginInfo.ForeColor = System.Drawing.Color.Black;
            this.lbl_LoginInfo.Location = new System.Drawing.Point(98, 257);
            this.lbl_LoginInfo.Name = "lbl_LoginInfo";
            this.lbl_LoginInfo.Size = new System.Drawing.Size(217, 16);
            this.lbl_LoginInfo.Text = "Bağlı Kullanıcı: ";
            this.lbl_LoginInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPaletNo
            // 
            this.txtPaletNo.BackColor = System.Drawing.Color.White;
            this.txtPaletNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPaletNo.Location = new System.Drawing.Point(122, 4);
            this.txtPaletNo.Name = "txtPaletNo";
            this.txtPaletNo.Size = new System.Drawing.Size(187, 19);
            this.txtPaletNo.TabIndex = 3;
            // 
            // lbl_DagitimAdresiOlmasiGereken
            // 
            this.lbl_DagitimAdresiOlmasiGereken.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_DagitimAdresiOlmasiGereken.Location = new System.Drawing.Point(3, 3);
            this.lbl_DagitimAdresiOlmasiGereken.Name = "lbl_DagitimAdresiOlmasiGereken";
            this.lbl_DagitimAdresiOlmasiGereken.Size = new System.Drawing.Size(103, 20);
            this.lbl_DagitimAdresiOlmasiGereken.Text = "Palet Numarası";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.panel1.Controls.Add(this.lbl_DagitimAdresiOlmasiGereken);
            this.panel1.Controls.Add(this.txtPaletNo);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 39);
            // 
            // btn_Geri
            // 
            this.btn_Geri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Geri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Geri.BackgroundImage")));
            this.btn_Geri.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Geri.ForeColor = System.Drawing.Color.White;
            this.btn_Geri.Location = new System.Drawing.Point(3, 209);
            this.btn_Geri.Name = "btn_Geri";
            this.btn_Geri.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Geri.PressedImage")));
            this.btn_Geri.Size = new System.Drawing.Size(150, 47);
            this.btn_Geri.TabIndex = 63;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_Transfer
            // 
            this.btn_Transfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Transfer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Transfer.BackgroundImage")));
            this.btn_Transfer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Transfer.ForeColor = System.Drawing.Color.White;
            this.btn_Transfer.Location = new System.Drawing.Point(3, 48);
            this.btn_Transfer.Name = "btn_Transfer";
            this.btn_Transfer.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Transfer.PressedImage")));
            this.btn_Transfer.Size = new System.Drawing.Size(312, 47);
            this.btn_Transfer.TabIndex = 62;
            this.btn_Transfer.Text = "Kargo Alanına Transfer Onayı";
            this.btn_Transfer.Click += new System.EventHandler(this.btn_Transfer_Click);
            // 
            // frm_43_Kargo_Alani_Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_Transfer);
            this.Name = "frm_43_Kargo_Alani_Transfer";
            this.Text = "Kargo Alanı Transfer";
            this.Load += new System.EventHandler(this.frm_43_Kargo_Alani_Transfer_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.TextBox txtPaletNo;
        private System.Windows.Forms.Label lbl_DagitimAdresiOlmasiGereken;
        private System.Windows.Forms.Panel panel1;
        private PictureButton btn_Geri;
        private PictureButton btn_Transfer;
    }
}