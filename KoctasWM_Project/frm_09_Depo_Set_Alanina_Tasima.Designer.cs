namespace KoctasWM_Project
{
    partial class frm_09_Depo_Set_Alanina_Tasima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_09_Depo_Set_Alanina_Tasima));
            this.p1 = new System.Windows.Forms.Panel();
            this.lbl_MalzemeNo = new System.Windows.Forms.Label();
            this.txtMalzemeNo = new System.Windows.Forms.TextBox();
            this.p3 = new System.Windows.Forms.Panel();
            this.lbl_ToplamStok = new System.Windows.Forms.Label();
            this.txtToplamStok = new System.Windows.Forms.TextBox();
            this.p5 = new System.Windows.Forms.Panel();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lbl_Miktar = new System.Windows.Forms.Label();
            this.txtHedefAdres = new System.Windows.Forms.TextBox();
            this.lbl_HedefAdres = new System.Windows.Forms.Label();
            this.lbl_OlcuBirimi = new System.Windows.Forms.Label();
            this.txtOlcuBirimi = new System.Windows.Forms.TextBox();
            this.txtMalzemeTanimi = new System.Windows.Forms.TextBox();
            this.lbl_MalzemeTanimi = new System.Windows.Forms.Label();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Kaydet = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.p3.SuspendLayout();
            this.p5.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.lbl_MalzemeNo);
            this.p1.Controls.Add(this.txtMalzemeNo);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 39);
            // 
            // lbl_MalzemeNo
            // 
            this.lbl_MalzemeNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeNo.Location = new System.Drawing.Point(3, 9);
            this.lbl_MalzemeNo.Name = "lbl_MalzemeNo";
            this.lbl_MalzemeNo.Size = new System.Drawing.Size(120, 20);
            this.lbl_MalzemeNo.Text = "Malzeme No:";
            // 
            // txtMalzemeNo
            // 
            this.txtMalzemeNo.BackColor = System.Drawing.Color.White;
            this.txtMalzemeNo.Location = new System.Drawing.Point(129, 6);
            this.txtMalzemeNo.Name = "txtMalzemeNo";
            this.txtMalzemeNo.Size = new System.Drawing.Size(180, 23);
            this.txtMalzemeNo.TabIndex = 3;
            this.txtMalzemeNo.GotFocus += new System.EventHandler(this.txtPaletNo_GotFocus_1);
            this.txtMalzemeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaletNo_KeyDown);
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p3.Controls.Add(this.lbl_ToplamStok);
            this.p3.Controls.Add(this.txtToplamStok);
            this.p3.Controls.Add(this.p5);
            this.p3.Controls.Add(this.txtHedefAdres);
            this.p3.Controls.Add(this.lbl_HedefAdres);
            this.p3.Controls.Add(this.lbl_OlcuBirimi);
            this.p3.Controls.Add(this.txtOlcuBirimi);
            this.p3.Controls.Add(this.txtMalzemeTanimi);
            this.p3.Controls.Add(this.lbl_MalzemeTanimi);
            this.p3.Location = new System.Drawing.Point(3, 48);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(312, 140);
            // 
            // lbl_ToplamStok
            // 
            this.lbl_ToplamStok.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_ToplamStok.Location = new System.Drawing.Point(140, 85);
            this.lbl_ToplamStok.Name = "lbl_ToplamStok";
            this.lbl_ToplamStok.Size = new System.Drawing.Size(90, 20);
            this.lbl_ToplamStok.Text = "Top. Stok:";
            // 
            // txtToplamStok
            // 
            this.txtToplamStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtToplamStok.Enabled = false;
            this.txtToplamStok.Location = new System.Drawing.Point(237, 82);
            this.txtToplamStok.Name = "txtToplamStok";
            this.txtToplamStok.Size = new System.Drawing.Size(72, 23);
            this.txtToplamStok.TabIndex = 48;
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p5.Controls.Add(this.txtMiktar);
            this.p5.Controls.Add(this.lbl_Miktar);
            this.p5.Location = new System.Drawing.Point(0, 48);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(137, 35);
            // 
            // txtMiktar
            // 
            this.txtMiktar.BackColor = System.Drawing.Color.White;
            this.txtMiktar.Enabled = false;
            this.txtMiktar.Location = new System.Drawing.Point(60, 6);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(69, 23);
            this.txtMiktar.TabIndex = 60;
            this.txtMiktar.GotFocus += new System.EventHandler(this.txtMiktar_GotFocus);
            this.txtMiktar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMiktar_KeyDown);
            // 
            // lbl_Miktar
            // 
            this.lbl_Miktar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.lbl_Miktar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_Miktar.Location = new System.Drawing.Point(5, 9);
            this.lbl_Miktar.Name = "lbl_Miktar";
            this.lbl_Miktar.Size = new System.Drawing.Size(66, 20);
            this.lbl_Miktar.Text = "Miktar:";
            // 
            // txtHedefAdres
            // 
            this.txtHedefAdres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtHedefAdres.Enabled = false;
            this.txtHedefAdres.Location = new System.Drawing.Point(129, 111);
            this.txtHedefAdres.Name = "txtHedefAdres";
            this.txtHedefAdres.Size = new System.Drawing.Size(180, 23);
            this.txtHedefAdres.TabIndex = 43;
            // 
            // lbl_HedefAdres
            // 
            this.lbl_HedefAdres.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_HedefAdres.Location = new System.Drawing.Point(3, 114);
            this.lbl_HedefAdres.Name = "lbl_HedefAdres";
            this.lbl_HedefAdres.Size = new System.Drawing.Size(120, 20);
            this.lbl_HedefAdres.Text = "Hedef Adres:";
            // 
            // lbl_OlcuBirimi
            // 
            this.lbl_OlcuBirimi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_OlcuBirimi.Location = new System.Drawing.Point(140, 57);
            this.lbl_OlcuBirimi.Name = "lbl_OlcuBirimi";
            this.lbl_OlcuBirimi.Size = new System.Drawing.Size(90, 20);
            this.lbl_OlcuBirimi.Text = "Ölçü Birimi:";
            // 
            // txtOlcuBirimi
            // 
            this.txtOlcuBirimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtOlcuBirimi.Enabled = false;
            this.txtOlcuBirimi.Location = new System.Drawing.Point(237, 54);
            this.txtOlcuBirimi.Name = "txtOlcuBirimi";
            this.txtOlcuBirimi.Size = new System.Drawing.Size(72, 23);
            this.txtOlcuBirimi.TabIndex = 41;
            // 
            // txtMalzemeTanimi
            // 
            this.txtMalzemeTanimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtMalzemeTanimi.Enabled = false;
            this.txtMalzemeTanimi.Location = new System.Drawing.Point(5, 23);
            this.txtMalzemeTanimi.Name = "txtMalzemeTanimi";
            this.txtMalzemeTanimi.Size = new System.Drawing.Size(304, 23);
            this.txtMalzemeTanimi.TabIndex = 40;
            // 
            // lbl_MalzemeTanimi
            // 
            this.lbl_MalzemeTanimi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeTanimi.Location = new System.Drawing.Point(3, 2);
            this.lbl_MalzemeTanimi.Name = "lbl_MalzemeTanimi";
            this.lbl_MalzemeTanimi.Size = new System.Drawing.Size(179, 20);
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
            this.btn_Geri.TabIndex = 17;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click_1);
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
            this.btn_Kaydet.TabIndex = 16;
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
            // frm_09_Depo_Set_Alanina_Tasima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p1);
            this.Name = "frm_09_Depo_Set_Alanina_Tasima";
            this.Text = "Set Alanına Taşıma";
            this.Load += new System.EventHandler(this.frm_09_Depo_Set_Alanina_Tasima_Load);
            this.p1.ResumeLayout(false);
            this.p3.ResumeLayout(false);
            this.p5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label lbl_MalzemeNo;
        private System.Windows.Forms.TextBox txtMalzemeNo;
        private System.Windows.Forms.Panel p3;
        private System.Windows.Forms.TextBox txtHedefAdres;
        private System.Windows.Forms.Label lbl_HedefAdres;
        private System.Windows.Forms.Label lbl_OlcuBirimi;
        private System.Windows.Forms.TextBox txtOlcuBirimi;
        private System.Windows.Forms.TextBox txtMalzemeTanimi;
        private System.Windows.Forms.Label lbl_MalzemeTanimi;
        private PictureButton btn_Geri;
        private PictureButton btn_Kaydet;
        private System.Windows.Forms.Panel p5;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lbl_Miktar;
        private System.Windows.Forms.Label lbl_ToplamStok;
        private System.Windows.Forms.TextBox txtToplamStok;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}