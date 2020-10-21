namespace KoctasWM_Project
{
    partial class frm_Menu_Mal_Cikis_Islemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Mal_Cikis_Islemleri));
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_SevkiyatIslemleri = new KoctasWM_Project.PictureButton();
            this.btn_ToplamaIslemleri = new KoctasWM_Project.PictureButton();
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
            this.btn_Geri.TabIndex = 16;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_SevkiyatIslemleri
            // 
            this.btn_SevkiyatIslemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_SevkiyatIslemleri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_SevkiyatIslemleri.BackgroundImage")));
            this.btn_SevkiyatIslemleri.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SevkiyatIslemleri.ForeColor = System.Drawing.Color.White;
            this.btn_SevkiyatIslemleri.Location = new System.Drawing.Point(3, 53);
            this.btn_SevkiyatIslemleri.Name = "btn_SevkiyatIslemleri";
            this.btn_SevkiyatIslemleri.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_SevkiyatIslemleri.PressedImage")));
            this.btn_SevkiyatIslemleri.Size = new System.Drawing.Size(312, 47);
            this.btn_SevkiyatIslemleri.TabIndex = 15;
            this.btn_SevkiyatIslemleri.Text = "SEVKİYAT İŞLEMLERİ";
            this.btn_SevkiyatIslemleri.Click += new System.EventHandler(this.btn_SevkiyatIslemleri_Click);
            // 
            // btn_ToplamaIslemleri
            // 
            this.btn_ToplamaIslemleri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_ToplamaIslemleri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ToplamaIslemleri.BackgroundImage")));
            this.btn_ToplamaIslemleri.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ToplamaIslemleri.ForeColor = System.Drawing.Color.White;
            this.btn_ToplamaIslemleri.Location = new System.Drawing.Point(3, 3);
            this.btn_ToplamaIslemleri.Name = "btn_ToplamaIslemleri";
            this.btn_ToplamaIslemleri.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_ToplamaIslemleri.PressedImage")));
            this.btn_ToplamaIslemleri.Size = new System.Drawing.Size(312, 47);
            this.btn_ToplamaIslemleri.TabIndex = 14;
            this.btn_ToplamaIslemleri.Text = "TOPLAMA İŞLEMLERİ";
            this.btn_ToplamaIslemleri.Click += new System.EventHandler(this.btn_ToplamaIslemleri_Click);
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
            // frm_Menu_Mal_Cikis_Islemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_SevkiyatIslemleri);
            this.Controls.Add(this.btn_ToplamaIslemleri);
            this.Name = "frm_Menu_Mal_Cikis_Islemleri";
            this.Text = "Mal Çıkış İşlemleri";
            this.Load += new System.EventHandler(this.frm_Menu_Mal_Cikis_Islemleri_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_SevkiyatIslemleri;
        private PictureButton btn_ToplamaIslemleri;
        private PictureButton btn_Geri;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}