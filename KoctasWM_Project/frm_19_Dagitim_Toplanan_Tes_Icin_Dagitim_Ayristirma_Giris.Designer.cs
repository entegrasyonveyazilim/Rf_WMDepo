namespace KoctasWM_Project
{
    partial class frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris));
            this.p1 = new System.Windows.Forms.Panel();
            this.lbl_MalzemeNo = new System.Windows.Forms.Label();
            this.txtMalzemeNo = new System.Windows.Forms.TextBox();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_DetayGetir = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.lbl_MalzemeNo);
            this.p1.Controls.Add(this.txtMalzemeNo);
            this.p1.Location = new System.Drawing.Point(3, 50);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 98);
            // 
            // lbl_MalzemeNo
            // 
            this.lbl_MalzemeNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeNo.Location = new System.Drawing.Point(6, 10);
            this.lbl_MalzemeNo.Name = "lbl_MalzemeNo";
            this.lbl_MalzemeNo.Size = new System.Drawing.Size(303, 19);
            this.lbl_MalzemeNo.Text = "Malzeme No:";
            this.lbl_MalzemeNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMalzemeNo
            // 
            this.txtMalzemeNo.BackColor = System.Drawing.Color.White;
            this.txtMalzemeNo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtMalzemeNo.Location = new System.Drawing.Point(52, 42);
            this.txtMalzemeNo.Name = "txtMalzemeNo";
            this.txtMalzemeNo.Size = new System.Drawing.Size(210, 24);
            this.txtMalzemeNo.TabIndex = 3;
            this.txtMalzemeNo.GotFocus += new System.EventHandler(this.txtMalzemeNo_GotFocus);
            this.txtMalzemeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMalzemeNo_KeyDown);
            // 
            // btn_Geri
            // 
            this.btn_Geri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Geri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Geri.BackgroundImage")));
            this.btn_Geri.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Geri.ForeColor = System.Drawing.Color.White;
            this.btn_Geri.Location = new System.Drawing.Point(3, 197);
            this.btn_Geri.Name = "btn_Geri";
            this.btn_Geri.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Geri.PressedImage")));
            this.btn_Geri.Size = new System.Drawing.Size(150, 47);
            this.btn_Geri.TabIndex = 55;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_DetayGetir
            // 
            this.btn_DetayGetir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_DetayGetir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DetayGetir.BackgroundImage")));
            this.btn_DetayGetir.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_DetayGetir.ForeColor = System.Drawing.Color.White;
            this.btn_DetayGetir.Location = new System.Drawing.Point(165, 197);
            this.btn_DetayGetir.Name = "btn_DetayGetir";
            this.btn_DetayGetir.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_DetayGetir.PressedImage")));
            this.btn_DetayGetir.Size = new System.Drawing.Size(150, 47);
            this.btn_DetayGetir.TabIndex = 54;
            this.btn_DetayGetir.Text = "    SORGULA";
            this.btn_DetayGetir.Click += new System.EventHandler(this.btn_DetayGetir_Click);
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
            // frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_DetayGetir);
            this.Name = "frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris";
            this.Text = "Sipariş Dağıtım (Web)";
            this.Load += new System.EventHandler(this.frm_19_Toplama_Ikmal_Siparisleri_Onaylama_Giris_Load);
            this.p1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label lbl_MalzemeNo;
        private System.Windows.Forms.TextBox txtMalzemeNo;
        private PictureButton btn_Geri;
        private PictureButton btn_DetayGetir;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}