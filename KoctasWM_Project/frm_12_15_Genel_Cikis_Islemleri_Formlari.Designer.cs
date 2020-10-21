namespace KoctasWM_Project
{
    partial class frm_12_15_Genel_Cikis_Islemleri_Formlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_12_15_Genel_Cikis_Islemleri_Formlari));
            this.p1 = new System.Windows.Forms.Panel();
            this.lbl_AdresNo = new System.Windows.Forms.Label();
            this.txtAdresNo = new System.Windows.Forms.TextBox();
            this.p2 = new System.Windows.Forms.Panel();
            this.lbl_PaletMalzemeNo = new System.Windows.Forms.Label();
            this.txtPaletMalzemeNo = new System.Windows.Forms.TextBox();
            this.p4 = new System.Windows.Forms.Panel();
            this.p5 = new System.Windows.Forms.Panel();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lbl_Miktar = new System.Windows.Forms.Label();
            this.txtToplamMiktar = new System.Windows.Forms.TextBox();
            this.lbl_ToplamMiktar = new System.Windows.Forms.Label();
            this.txtOlcuBirimi = new System.Windows.Forms.TextBox();
            this.txtStokTipi = new System.Windows.Forms.TextBox();
            this.txtMalzemeNo = new System.Windows.Forms.TextBox();
            this.lbl_MalzemeNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaletNo = new System.Windows.Forms.TextBox();
            this.lbl_PaletNo = new System.Windows.Forms.Label();
            this.lbl_OlcuBirimi = new System.Windows.Forms.Label();
            this.txtMalzemeTanimi = new System.Windows.Forms.TextBox();
            this.lbl_MalzemeTanimi = new System.Windows.Forms.Label();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Kaydet = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.p2.SuspendLayout();
            this.p4.SuspendLayout();
            this.p5.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.lbl_AdresNo);
            this.p1.Controls.Add(this.txtAdresNo);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 28);
            // 
            // lbl_AdresNo
            // 
            this.lbl_AdresNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_AdresNo.Location = new System.Drawing.Point(3, 5);
            this.lbl_AdresNo.Name = "lbl_AdresNo";
            this.lbl_AdresNo.Size = new System.Drawing.Size(101, 20);
            this.lbl_AdresNo.Text = "Adres:";
            // 
            // txtAdresNo
            // 
            this.txtAdresNo.BackColor = System.Drawing.Color.White;
            this.txtAdresNo.Location = new System.Drawing.Point(110, 2);
            this.txtAdresNo.Name = "txtAdresNo";
            this.txtAdresNo.Size = new System.Drawing.Size(199, 23);
            this.txtAdresNo.TabIndex = 3;
            this.txtAdresNo.GotFocus += new System.EventHandler(this.txtMalzemeNo_GotFocus);
            this.txtAdresNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMalzemeNo_KeyDown);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.Controls.Add(this.lbl_PaletMalzemeNo);
            this.p2.Controls.Add(this.txtPaletMalzemeNo);
            this.p2.Location = new System.Drawing.Point(3, 34);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(312, 28);
            // 
            // lbl_PaletMalzemeNo
            // 
            this.lbl_PaletMalzemeNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_PaletMalzemeNo.Location = new System.Drawing.Point(3, 8);
            this.lbl_PaletMalzemeNo.Name = "lbl_PaletMalzemeNo";
            this.lbl_PaletMalzemeNo.Size = new System.Drawing.Size(101, 18);
            this.lbl_PaletMalzemeNo.Text = "Malzeme No:";
            // 
            // txtPaletMalzemeNo
            // 
            this.txtPaletMalzemeNo.BackColor = System.Drawing.Color.White;
            this.txtPaletMalzemeNo.Enabled = false;
            this.txtPaletMalzemeNo.Location = new System.Drawing.Point(110, 3);
            this.txtPaletMalzemeNo.Name = "txtPaletMalzemeNo";
            this.txtPaletMalzemeNo.Size = new System.Drawing.Size(199, 23);
            this.txtPaletMalzemeNo.TabIndex = 3;
            this.txtPaletMalzemeNo.GotFocus += new System.EventHandler(this.txtPaletMalzemeNo_GotFocus);
            this.txtPaletMalzemeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaletMalzemeNo_KeyDown);
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p4.Controls.Add(this.p5);
            this.p4.Controls.Add(this.txtToplamMiktar);
            this.p4.Controls.Add(this.lbl_ToplamMiktar);
            this.p4.Controls.Add(this.txtOlcuBirimi);
            this.p4.Controls.Add(this.txtStokTipi);
            this.p4.Controls.Add(this.txtMalzemeNo);
            this.p4.Controls.Add(this.lbl_MalzemeNo);
            this.p4.Controls.Add(this.label1);
            this.p4.Controls.Add(this.txtPaletNo);
            this.p4.Controls.Add(this.lbl_PaletNo);
            this.p4.Controls.Add(this.lbl_OlcuBirimi);
            this.p4.Controls.Add(this.txtMalzemeTanimi);
            this.p4.Controls.Add(this.lbl_MalzemeTanimi);
            this.p4.Location = new System.Drawing.Point(3, 67);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(312, 120);
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p5.Controls.Add(this.txtMiktar);
            this.p5.Controls.Add(this.lbl_Miktar);
            this.p5.Location = new System.Drawing.Point(0, 67);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(78, 42);
            // 
            // txtMiktar
            // 
            this.txtMiktar.BackColor = System.Drawing.Color.White;
            this.txtMiktar.Enabled = false;
            this.txtMiktar.Location = new System.Drawing.Point(3, 17);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(72, 23);
            this.txtMiktar.TabIndex = 60;
            this.txtMiktar.GotFocus += new System.EventHandler(this.txtMiktar_GotFocus);
            this.txtMiktar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMiktar_KeyDown);
            // 
            // lbl_Miktar
            // 
            this.lbl_Miktar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.lbl_Miktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_Miktar.Location = new System.Drawing.Point(1, 2);
            this.lbl_Miktar.Name = "lbl_Miktar";
            this.lbl_Miktar.Size = new System.Drawing.Size(72, 20);
            this.lbl_Miktar.Text = "Çıkış Miktarı";
            this.lbl_Miktar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtToplamMiktar
            // 
            this.txtToplamMiktar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtToplamMiktar.Enabled = false;
            this.txtToplamMiktar.Location = new System.Drawing.Point(81, 85);
            this.txtToplamMiktar.Name = "txtToplamMiktar";
            this.txtToplamMiktar.Size = new System.Drawing.Size(72, 23);
            this.txtToplamMiktar.TabIndex = 69;
            // 
            // lbl_ToplamMiktar
            // 
            this.lbl_ToplamMiktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_ToplamMiktar.Location = new System.Drawing.Point(81, 69);
            this.lbl_ToplamMiktar.Name = "lbl_ToplamMiktar";
            this.lbl_ToplamMiktar.Size = new System.Drawing.Size(72, 20);
            this.lbl_ToplamMiktar.Text = "Top.Miktar";
            this.lbl_ToplamMiktar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtOlcuBirimi
            // 
            this.txtOlcuBirimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtOlcuBirimi.Enabled = false;
            this.txtOlcuBirimi.Location = new System.Drawing.Point(159, 85);
            this.txtOlcuBirimi.Name = "txtOlcuBirimi";
            this.txtOlcuBirimi.Size = new System.Drawing.Size(72, 23);
            this.txtOlcuBirimi.TabIndex = 57;
            // 
            // txtStokTipi
            // 
            this.txtStokTipi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtStokTipi.Enabled = false;
            this.txtStokTipi.Location = new System.Drawing.Point(237, 85);
            this.txtStokTipi.Name = "txtStokTipi";
            this.txtStokTipi.Size = new System.Drawing.Size(72, 23);
            this.txtStokTipi.TabIndex = 60;
            // 
            // txtMalzemeNo
            // 
            this.txtMalzemeNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtMalzemeNo.Enabled = false;
            this.txtMalzemeNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtMalzemeNo.Location = new System.Drawing.Point(131, 23);
            this.txtMalzemeNo.Name = "txtMalzemeNo";
            this.txtMalzemeNo.Size = new System.Drawing.Size(178, 21);
            this.txtMalzemeNo.TabIndex = 61;
            // 
            // lbl_MalzemeNo
            // 
            this.lbl_MalzemeNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeNo.Location = new System.Drawing.Point(3, 26);
            this.lbl_MalzemeNo.Name = "lbl_MalzemeNo";
            this.lbl_MalzemeNo.Size = new System.Drawing.Size(109, 18);
            this.lbl_MalzemeNo.Text = "Malzeme No:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(237, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.Text = "Stok Tipi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPaletNo
            // 
            this.txtPaletNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtPaletNo.Enabled = false;
            this.txtPaletNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtPaletNo.Location = new System.Drawing.Point(131, 1);
            this.txtPaletNo.Name = "txtPaletNo";
            this.txtPaletNo.Size = new System.Drawing.Size(178, 21);
            this.txtPaletNo.TabIndex = 59;
            // 
            // lbl_PaletNo
            // 
            this.lbl_PaletNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_PaletNo.Location = new System.Drawing.Point(3, 4);
            this.lbl_PaletNo.Name = "lbl_PaletNo";
            this.lbl_PaletNo.Size = new System.Drawing.Size(109, 18);
            this.lbl_PaletNo.Text = "Palet No:";
            // 
            // lbl_OlcuBirimi
            // 
            this.lbl_OlcuBirimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_OlcuBirimi.Location = new System.Drawing.Point(159, 69);
            this.lbl_OlcuBirimi.Name = "lbl_OlcuBirimi";
            this.lbl_OlcuBirimi.Size = new System.Drawing.Size(72, 20);
            this.lbl_OlcuBirimi.Text = "Ölçü Birimi";
            this.lbl_OlcuBirimi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMalzemeTanimi
            // 
            this.txtMalzemeTanimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtMalzemeTanimi.Enabled = false;
            this.txtMalzemeTanimi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtMalzemeTanimi.Location = new System.Drawing.Point(131, 45);
            this.txtMalzemeTanimi.Name = "txtMalzemeTanimi";
            this.txtMalzemeTanimi.Size = new System.Drawing.Size(178, 21);
            this.txtMalzemeTanimi.TabIndex = 56;
            // 
            // lbl_MalzemeTanimi
            // 
            this.lbl_MalzemeTanimi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeTanimi.Location = new System.Drawing.Point(3, 48);
            this.lbl_MalzemeTanimi.Name = "lbl_MalzemeTanimi";
            this.lbl_MalzemeTanimi.Size = new System.Drawing.Size(122, 18);
            this.lbl_MalzemeTanimi.Text = "Malzeme Tanımı:";
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
            this.btn_Geri.TabIndex = 64;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Kaydet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Kaydet.BackgroundImage")));
            this.btn_Kaydet.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Kaydet.ForeColor = System.Drawing.Color.White;
            this.btn_Kaydet.Location = new System.Drawing.Point(165, 209);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Kaydet.PressedImage")));
            this.btn_Kaydet.Size = new System.Drawing.Size(150, 47);
            this.btn_Kaydet.TabIndex = 63;
            this.btn_Kaydet.Text = "KAYDET";
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
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
            // frm_12_15_Genel_Cikis_Islemleri_Formlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Name = "frm_12_15_Genel_Cikis_Islemleri_Formlari";
            this.Text = "Genel Çıkış İşlemleri - ";
            this.Load += new System.EventHandler(this.frm_12_15_Genel_Cikis_Islemleri_Formlari_Load);
            this.p1.ResumeLayout(false);
            this.p2.ResumeLayout(false);
            this.p4.ResumeLayout(false);
            this.p5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label lbl_AdresNo;
        private System.Windows.Forms.TextBox txtAdresNo;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.Label lbl_PaletMalzemeNo;
        private System.Windows.Forms.TextBox txtPaletMalzemeNo;
        private System.Windows.Forms.Panel p4;
        private System.Windows.Forms.Panel p5;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lbl_Miktar;
        private System.Windows.Forms.TextBox txtToplamMiktar;
        private System.Windows.Forms.Label lbl_ToplamMiktar;
        private System.Windows.Forms.TextBox txtOlcuBirimi;
        private System.Windows.Forms.TextBox txtStokTipi;
        private System.Windows.Forms.TextBox txtMalzemeNo;
        private System.Windows.Forms.Label lbl_MalzemeNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaletNo;
        private System.Windows.Forms.Label lbl_PaletNo;
        private System.Windows.Forms.Label lbl_OlcuBirimi;
        private System.Windows.Forms.TextBox txtMalzemeTanimi;
        private System.Windows.Forms.Label lbl_MalzemeTanimi;
        private PictureButton btn_Geri;
        private PictureButton btn_Kaydet;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}