namespace KoctasWM_Project
{
    partial class frm_Menu_Adres_Palet_Sorgulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Adres_Palet_Sorgulama));
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_AdresSorgulama = new KoctasWM_Project.PictureButton();
            this.btn_PaletSorgulama = new KoctasWM_Project.PictureButton();
            this.btn_UrunSorgulama = new KoctasWM_Project.PictureButton();
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
            this.btn_Geri.TabIndex = 18;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_AdresSorgulama
            // 
            this.btn_AdresSorgulama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_AdresSorgulama.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AdresSorgulama.BackgroundImage")));
            this.btn_AdresSorgulama.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_AdresSorgulama.ForeColor = System.Drawing.Color.White;
            this.btn_AdresSorgulama.Location = new System.Drawing.Point(3, 102);
            this.btn_AdresSorgulama.Name = "btn_AdresSorgulama";
            this.btn_AdresSorgulama.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_AdresSorgulama.PressedImage")));
            this.btn_AdresSorgulama.Size = new System.Drawing.Size(312, 47);
            this.btn_AdresSorgulama.TabIndex = 17;
            this.btn_AdresSorgulama.Text = "ADRES SORGULAMA";
            this.btn_AdresSorgulama.Click += new System.EventHandler(this.btn_AdresSorgulama_Click);
            // 
            // btn_PaletSorgulama
            // 
            this.btn_PaletSorgulama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_PaletSorgulama.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PaletSorgulama.BackgroundImage")));
            this.btn_PaletSorgulama.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_PaletSorgulama.ForeColor = System.Drawing.Color.White;
            this.btn_PaletSorgulama.Location = new System.Drawing.Point(3, 52);
            this.btn_PaletSorgulama.Name = "btn_PaletSorgulama";
            this.btn_PaletSorgulama.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_PaletSorgulama.PressedImage")));
            this.btn_PaletSorgulama.Size = new System.Drawing.Size(312, 47);
            this.btn_PaletSorgulama.TabIndex = 16;
            this.btn_PaletSorgulama.Text = "PALET SORGULAMA";
            this.btn_PaletSorgulama.Click += new System.EventHandler(this.btn_PaletSorgulama_Click);
            // 
            // btn_UrunSorgulama
            // 
            this.btn_UrunSorgulama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_UrunSorgulama.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_UrunSorgulama.BackgroundImage")));
            this.btn_UrunSorgulama.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_UrunSorgulama.ForeColor = System.Drawing.Color.White;
            this.btn_UrunSorgulama.Location = new System.Drawing.Point(3, 3);
            this.btn_UrunSorgulama.Name = "btn_UrunSorgulama";
            this.btn_UrunSorgulama.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_UrunSorgulama.PressedImage")));
            this.btn_UrunSorgulama.Size = new System.Drawing.Size(312, 47);
            this.btn_UrunSorgulama.TabIndex = 19;
            this.btn_UrunSorgulama.Text = "ÜRÜN SORGULAMA";
            this.btn_UrunSorgulama.Click += new System.EventHandler(this.btn_UrunSorgulama_Click);
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
            // frm_Menu_Adres_Palet_Sorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_UrunSorgulama);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_AdresSorgulama);
            this.Controls.Add(this.btn_PaletSorgulama);
            this.Name = "frm_Menu_Adres_Palet_Sorgulama";
            this.Text = "Sorgulama";
            this.Load += new System.EventHandler(this.frm_Menu_Adres_Palet_Sorgulama_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_Geri;
        private PictureButton btn_AdresSorgulama;
        private PictureButton btn_PaletSorgulama;
        private PictureButton btn_UrunSorgulama;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}