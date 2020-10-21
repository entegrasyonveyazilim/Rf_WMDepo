namespace KoctasWM_Project
{
    partial class frm_WMLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WMLogin));
            this.pbBg = new System.Windows.Forms.PictureBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lbl_KullaniciAdi = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.lbl_Sire = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lbl_BaglantiBilgisi = new System.Windows.Forms.Label();
            this.cmbSunucu = new System.Windows.Forms.ComboBox();
            this.btn_Cikis = new KoctasWM_Project.PictureButton();
            this.btn_Giris = new KoctasWM_Project.PictureButton();
            this.SuspendLayout();
            // 
            // pbBg
            // 
            this.pbBg.Image = ((System.Drawing.Image)(resources.GetObject("pbBg.Image")));
            this.pbBg.Location = new System.Drawing.Point(3, 0);
            this.pbBg.Name = "pbBg";
            this.pbBg.Size = new System.Drawing.Size(312, 150);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(137, 151);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(178, 23);
            this.txtKullaniciAdi.TabIndex = 1;
            this.txtKullaniciAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKullaniciAdi_KeyDown);
            // 
            // lbl_KullaniciAdi
            // 
            this.lbl_KullaniciAdi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_KullaniciAdi.Location = new System.Drawing.Point(3, 154);
            this.lbl_KullaniciAdi.Name = "lbl_KullaniciAdi";
            this.lbl_KullaniciAdi.Size = new System.Drawing.Size(128, 20);
            this.lbl_KullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lbl_Version
            // 
            this.lbl_Version.Location = new System.Drawing.Point(87, 122);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(228, 20);
            this.lbl_Version.Text = "V. ";
            this.lbl_Version.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Sire
            // 
            this.lbl_Sire.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Sire.Location = new System.Drawing.Point(3, 183);
            this.lbl_Sire.Name = "lbl_Sire";
            this.lbl_Sire.Size = new System.Drawing.Size(78, 20);
            this.lbl_Sire.Text = "Şifre:";
            // 
            // txtSifre
            // 
            this.txtSifre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.txtSifre.Location = new System.Drawing.Point(137, 180);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(178, 23);
            this.txtSifre.TabIndex = 5;
            this.txtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSifre_KeyDown);
            // 
            // lbl_BaglantiBilgisi
            // 
            this.lbl_BaglantiBilgisi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_BaglantiBilgisi.ForeColor = System.Drawing.Color.Red;
            this.lbl_BaglantiBilgisi.Location = new System.Drawing.Point(98, 247);
            this.lbl_BaglantiBilgisi.Name = "lbl_BaglantiBilgisi";
            this.lbl_BaglantiBilgisi.Size = new System.Drawing.Size(217, 20);
            this.lbl_BaglantiBilgisi.Text = "...";
            this.lbl_BaglantiBilgisi.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbSunucu
            // 
            this.cmbSunucu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.cmbSunucu.Enabled = false;
            this.cmbSunucu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.cmbSunucu.Items.Add("DEV Test");
            this.cmbSunucu.Items.Add("QA Test");
            this.cmbSunucu.Items.Add("PROD");
            this.cmbSunucu.Location = new System.Drawing.Point(3, 246);
            this.cmbSunucu.Name = "cmbSunucu";
            this.cmbSunucu.Size = new System.Drawing.Size(128, 21);
            this.cmbSunucu.TabIndex = 13;
            // 
            // btn_Cikis
            // 
            this.btn_Cikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Cikis.BackgroundImage = null;
            this.btn_Cikis.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Cikis.ForeColor = System.Drawing.Color.White;
            this.btn_Cikis.Location = new System.Drawing.Point(3, 209);
            this.btn_Cikis.Name = "btn_Cikis";
            this.btn_Cikis.Size = new System.Drawing.Size(150, 35);
            this.btn_Cikis.TabIndex = 8;
            this.btn_Cikis.Text = "ÇIKIŞ";
            this.btn_Cikis.Click += new System.EventHandler(this.btn_Cikis_Click);
            // 
            // btn_Giris
            // 
            this.btn_Giris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Giris.BackgroundImage = null;
            this.btn_Giris.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Giris.ForeColor = System.Drawing.Color.White;
            this.btn_Giris.Location = new System.Drawing.Point(165, 209);
            this.btn_Giris.Name = "btn_Giris";
            this.btn_Giris.Size = new System.Drawing.Size(150, 35);
            this.btn_Giris.TabIndex = 7;
            this.btn_Giris.Text = "GİRİŞ";
            this.btn_Giris.Click += new System.EventHandler(this.btn_Giris_Click);
            // 
            // frm_WMLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.cmbSunucu);
            this.Controls.Add(this.lbl_BaglantiBilgisi);
            this.Controls.Add(this.btn_Cikis);
            this.Controls.Add(this.btn_Giris);
            this.Controls.Add(this.lbl_Sire);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.lbl_KullaniciAdi);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.pbBg);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "frm_WMLogin";
            this.Text = "Koçtaş WM ";
            this.Load += new System.EventHandler(this.frm_WMLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBg;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label lbl_KullaniciAdi;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label lbl_Sire;
        private System.Windows.Forms.TextBox txtSifre;
        private PictureButton btn_Giris;
        private PictureButton btn_Cikis;
        private System.Windows.Forms.Label lbl_BaglantiBilgisi;
        private System.Windows.Forms.ComboBox cmbSunucu;
    }
}

