namespace KoctasWM_Project
{
    partial class frm_Menu_Sayim_Islemleri_Envanter_Sayim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Sayim_Islemleri_Envanter_Sayim));
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_KullaniciSecimiSayim = new KoctasWM_Project.PictureButton();
            this.btn_SistemOnerisiSayim = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btn_Geri.Size = new System.Drawing.Size(312, 47);
            this.btn_Geri.TabIndex = 22;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_KullaniciSecimiSayim
            // 
            this.btn_KullaniciSecimiSayim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_KullaniciSecimiSayim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_KullaniciSecimiSayim.BackgroundImage")));
            this.btn_KullaniciSecimiSayim.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_KullaniciSecimiSayim.ForeColor = System.Drawing.Color.White;
            this.btn_KullaniciSecimiSayim.Location = new System.Drawing.Point(3, 53);
            this.btn_KullaniciSecimiSayim.Name = "btn_KullaniciSecimiSayim";
            this.btn_KullaniciSecimiSayim.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_KullaniciSecimiSayim.PressedImage")));
            this.btn_KullaniciSecimiSayim.Size = new System.Drawing.Size(312, 47);
            this.btn_KullaniciSecimiSayim.TabIndex = 21;
            this.btn_KullaniciSecimiSayim.Text = "KULLANICI SEÇİMİ İLE SAYIM";
            this.btn_KullaniciSecimiSayim.Click += new System.EventHandler(this.btn_KullaniciSecimiSayim_Click);
            // 
            // btn_SistemOnerisiSayim
            // 
            this.btn_SistemOnerisiSayim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_SistemOnerisiSayim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_SistemOnerisiSayim.BackgroundImage")));
            this.btn_SistemOnerisiSayim.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SistemOnerisiSayim.ForeColor = System.Drawing.Color.White;
            this.btn_SistemOnerisiSayim.Location = new System.Drawing.Point(3, 3);
            this.btn_SistemOnerisiSayim.Name = "btn_SistemOnerisiSayim";
            this.btn_SistemOnerisiSayim.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_SistemOnerisiSayim.PressedImage")));
            this.btn_SistemOnerisiSayim.Size = new System.Drawing.Size(312, 47);
            this.btn_SistemOnerisiSayim.TabIndex = 20;
            this.btn_SistemOnerisiSayim.Text = "SİSTEM ÖNERİSİ İLE SAYIM";
            this.btn_SistemOnerisiSayim.Click += new System.EventHandler(this.btn_SistemOnerisiSayim_Click);
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
            // frm_Menu_Sayim_Islemleri_Envanter_Sayim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_KullaniciSecimiSayim);
            this.Controls.Add(this.btn_SistemOnerisiSayim);
            this.Name = "frm_Menu_Sayim_Islemleri_Envanter_Sayim";
            this.Text = "Envanter Sayım";
            this.Load += new System.EventHandler(this.frm_Menu_Sayim_Islemleri_Envanter_Sayim_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_Geri;
        private PictureButton btn_KullaniciSecimiSayim;
        private PictureButton btn_SistemOnerisiSayim;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}