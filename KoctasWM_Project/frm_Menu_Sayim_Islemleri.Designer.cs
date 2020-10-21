namespace KoctasWM_Project
{
    partial class frm_Menu_Sayim_Islemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Sayim_Islemleri));
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_EnvanterSayim = new KoctasWM_Project.PictureButton();
            this.btn_CanliOncesiSayim = new KoctasWM_Project.PictureButton();
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
            this.btn_Geri.TabIndex = 19;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_EnvanterSayim
            // 
            this.btn_EnvanterSayim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_EnvanterSayim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_EnvanterSayim.BackgroundImage")));
            this.btn_EnvanterSayim.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_EnvanterSayim.ForeColor = System.Drawing.Color.White;
            this.btn_EnvanterSayim.Location = new System.Drawing.Point(3, 53);
            this.btn_EnvanterSayim.Name = "btn_EnvanterSayim";
            this.btn_EnvanterSayim.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_EnvanterSayim.PressedImage")));
            this.btn_EnvanterSayim.Size = new System.Drawing.Size(312, 47);
            this.btn_EnvanterSayim.TabIndex = 18;
            this.btn_EnvanterSayim.Text = "ENVANTER SAYIM";
            this.btn_EnvanterSayim.Click += new System.EventHandler(this.btn_EnvanterSayim_Click);
            // 
            // btn_CanliOncesiSayim
            // 
            this.btn_CanliOncesiSayim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_CanliOncesiSayim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CanliOncesiSayim.BackgroundImage")));
            this.btn_CanliOncesiSayim.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_CanliOncesiSayim.ForeColor = System.Drawing.Color.White;
            this.btn_CanliOncesiSayim.Location = new System.Drawing.Point(3, 3);
            this.btn_CanliOncesiSayim.Name = "btn_CanliOncesiSayim";
            this.btn_CanliOncesiSayim.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_CanliOncesiSayim.PressedImage")));
            this.btn_CanliOncesiSayim.Size = new System.Drawing.Size(312, 47);
            this.btn_CanliOncesiSayim.TabIndex = 17;
            this.btn_CanliOncesiSayim.Text = "CANLI ÖNCESİ SAYIM";
            this.btn_CanliOncesiSayim.Click += new System.EventHandler(this.btn_CanliOncesiSayim_Click);
            // 
            // lbl_LoginInfo
            // 
            this.lbl_LoginInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbl_LoginInfo.ForeColor = System.Drawing.Color.Black;
            this.lbl_LoginInfo.Location = new System.Drawing.Point(98, 259);
            this.lbl_LoginInfo.Name = "lbl_LoginInfo";
            this.lbl_LoginInfo.Size = new System.Drawing.Size(217, 16);
            this.lbl_LoginInfo.Text = "Bağlı Kullanıcı: ";
            this.lbl_LoginInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frm_Menu_Sayim_Islemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_EnvanterSayim);
            this.Controls.Add(this.btn_CanliOncesiSayim);
            this.Name = "frm_Menu_Sayim_Islemleri";
            this.Text = "Sayım İşlemleri";
            this.Load += new System.EventHandler(this.frm_Menu_Sayim_Islemleri_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_Geri;
        private PictureButton btn_EnvanterSayim;
        private PictureButton btn_CanliOncesiSayim;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}