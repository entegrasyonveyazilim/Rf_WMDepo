namespace KoctasWM_Project
{
    partial class frm_Menu_Set_Urun_Islemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Set_Urun_Islemleri));
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_SetAlaninaTasima = new KoctasWM_Project.PictureButton();
            this.btn_SetUrunPaletleme = new KoctasWM_Project.PictureButton();
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
            this.btn_Geri.TabIndex = 21;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_SetAlaninaTasima
            // 
            this.btn_SetAlaninaTasima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_SetAlaninaTasima.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_SetAlaninaTasima.BackgroundImage")));
            this.btn_SetAlaninaTasima.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SetAlaninaTasima.ForeColor = System.Drawing.Color.White;
            this.btn_SetAlaninaTasima.Location = new System.Drawing.Point(3, 3);
            this.btn_SetAlaninaTasima.Name = "btn_SetAlaninaTasima";
            this.btn_SetAlaninaTasima.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_SetAlaninaTasima.PressedImage")));
            this.btn_SetAlaninaTasima.Size = new System.Drawing.Size(312, 47);
            this.btn_SetAlaninaTasima.TabIndex = 20;
            this.btn_SetAlaninaTasima.Text = "SET ALANINA TAŞIMA";
            this.btn_SetAlaninaTasima.Click += new System.EventHandler(this.btn_SetAlaninaTasima_Click);
            // 
            // btn_SetUrunPaletleme
            // 
            this.btn_SetUrunPaletleme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_SetUrunPaletleme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_SetUrunPaletleme.BackgroundImage")));
            this.btn_SetUrunPaletleme.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SetUrunPaletleme.ForeColor = System.Drawing.Color.White;
            this.btn_SetUrunPaletleme.Location = new System.Drawing.Point(3, 56);
            this.btn_SetUrunPaletleme.Name = "btn_SetUrunPaletleme";
            this.btn_SetUrunPaletleme.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_SetUrunPaletleme.PressedImage")));
            this.btn_SetUrunPaletleme.Size = new System.Drawing.Size(312, 47);
            this.btn_SetUrunPaletleme.TabIndex = 19;
            this.btn_SetUrunPaletleme.Text = "SET ÜRÜNÜ PALETLEME";
            this.btn_SetUrunPaletleme.Click += new System.EventHandler(this.btn_SetUrunPaletleme_Click);
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
            // frm_Menu_Set_Urun_Islemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_SetAlaninaTasima);
            this.Controls.Add(this.btn_SetUrunPaletleme);
            this.Name = "frm_Menu_Set_Urun_Islemleri";
            this.Text = "Set Ürünü İşlemleri";
            this.Load += new System.EventHandler(this.frm_Menu_Set_Urun_Islemleri_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_Geri;
        private PictureButton btn_SetAlaninaTasima;
        private PictureButton btn_SetUrunPaletleme;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}