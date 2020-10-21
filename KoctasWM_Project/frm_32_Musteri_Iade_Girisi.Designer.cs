namespace KoctasWM_Project
{
    partial class frm_32_Musteri_Iade_Girisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_32_Musteri_Iade_Girisi));
            this.p1 = new System.Windows.Forms.Panel();
            this.txtSiparisId = new System.Windows.Forms.TextBox();
            this.lbl_WebSiparisId = new System.Windows.Forms.Label();
            this.lbl_SAPIadeSiparisNo = new System.Windows.Forms.Label();
            this.txtSAPIadeSiparisNo = new System.Windows.Forms.TextBox();
            this.p3 = new System.Windows.Forms.Panel();
            this.txtDegisimMiktar = new System.Windows.Forms.TextBox();
            this.lbl_DegisimMiktari = new System.Windows.Forms.Label();
            this.txtKabulMiktar = new System.Windows.Forms.TextBox();
            this.lbl_KabulMiktar = new System.Windows.Forms.Label();
            this.p4 = new System.Windows.Forms.Panel();
            this.btn_Ekle = new KoctasWM_Project.PictureButton();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.lb_Aciklama = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Panel();
            this.txtMalzemeNo = new System.Windows.Forms.TextBox();
            this.lbl_MalzemeNo = new System.Windows.Forms.Label();
            this.grd_List = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.p5 = new System.Windows.Forms.Panel();
            this.txtSiparisNo = new System.Windows.Forms.TextBox();
            this.lbl_WebSiparisNo = new System.Windows.Forms.Label();
            this.btn_Kaydet = new KoctasWM_Project.PictureButton();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.txtIadeTuru = new System.Windows.Forms.TextBox();
            this.p1.SuspendLayout();
            this.p3.SuspendLayout();
            this.p4.SuspendLayout();
            this.p2.SuspendLayout();
            this.p5.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.txtSiparisId);
            this.p1.Controls.Add(this.lbl_WebSiparisId);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(150, 40);
            // 
            // txtSiparisId
            // 
            this.txtSiparisId.BackColor = System.Drawing.Color.White;
            this.txtSiparisId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSiparisId.Location = new System.Drawing.Point(4, 19);
            this.txtSiparisId.Name = "txtSiparisId";
            this.txtSiparisId.Size = new System.Drawing.Size(143, 19);
            this.txtSiparisId.TabIndex = 5;
            this.txtSiparisId.GotFocus += new System.EventHandler(this.txtSiparisNo_GotFocus);
            this.txtSiparisId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSiparisNo_KeyDown);
            // 
            // lbl_WebSiparisId
            // 
            this.lbl_WebSiparisId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_WebSiparisId.Location = new System.Drawing.Point(3, 4);
            this.lbl_WebSiparisId.Name = "lbl_WebSiparisId";
            this.lbl_WebSiparisId.Size = new System.Drawing.Size(144, 17);
            this.lbl_WebSiparisId.Text = "Web Sip. Id:";
            this.lbl_WebSiparisId.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_SAPIadeSiparisNo
            // 
            this.lbl_SAPIadeSiparisNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_SAPIadeSiparisNo.Location = new System.Drawing.Point(3, 79);
            this.lbl_SAPIadeSiparisNo.Name = "lbl_SAPIadeSiparisNo";
            this.lbl_SAPIadeSiparisNo.Size = new System.Drawing.Size(115, 21);
            this.lbl_SAPIadeSiparisNo.Text = "SAP İ. Sip. No:";
            // 
            // txtSAPIadeSiparisNo
            // 
            this.txtSAPIadeSiparisNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtSAPIadeSiparisNo.Enabled = false;
            this.txtSAPIadeSiparisNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSAPIadeSiparisNo.Location = new System.Drawing.Point(3, 95);
            this.txtSAPIadeSiparisNo.Name = "txtSAPIadeSiparisNo";
            this.txtSAPIadeSiparisNo.Size = new System.Drawing.Size(128, 19);
            this.txtSAPIadeSiparisNo.TabIndex = 83;
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p3.Controls.Add(this.txtDegisimMiktar);
            this.p3.Controls.Add(this.lbl_DegisimMiktari);
            this.p3.Controls.Add(this.txtKabulMiktar);
            this.p3.Controls.Add(this.lbl_KabulMiktar);
            this.p3.Location = new System.Drawing.Point(3, 117);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(128, 46);
            // 
            // txtDegisimMiktar
            // 
            this.txtDegisimMiktar.BackColor = System.Drawing.Color.White;
            this.txtDegisimMiktar.Enabled = false;
            this.txtDegisimMiktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDegisimMiktar.Location = new System.Drawing.Point(66, 22);
            this.txtDegisimMiktar.Name = "txtDegisimMiktar";
            this.txtDegisimMiktar.Size = new System.Drawing.Size(54, 19);
            this.txtDegisimMiktar.TabIndex = 63;
            this.txtDegisimMiktar.GotFocus += new System.EventHandler(this.txtKabulMiktar_GotFocus);
            this.txtDegisimMiktar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDegisimMiktar_KeyDown);
            // 
            // lbl_DegisimMiktari
            // 
            this.lbl_DegisimMiktari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.lbl_DegisimMiktari.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_DegisimMiktari.Location = new System.Drawing.Point(66, 4);
            this.lbl_DegisimMiktari.Name = "lbl_DegisimMiktari";
            this.lbl_DegisimMiktari.Size = new System.Drawing.Size(58, 15);
            this.lbl_DegisimMiktari.Text = "Değ. Mik:";
            // 
            // txtKabulMiktar
            // 
            this.txtKabulMiktar.BackColor = System.Drawing.Color.White;
            this.txtKabulMiktar.Enabled = false;
            this.txtKabulMiktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtKabulMiktar.Location = new System.Drawing.Point(5, 22);
            this.txtKabulMiktar.Name = "txtKabulMiktar";
            this.txtKabulMiktar.Size = new System.Drawing.Size(55, 19);
            this.txtKabulMiktar.TabIndex = 60;
            this.txtKabulMiktar.GotFocus += new System.EventHandler(this.txtKabulMiktar_GotFocus);
            this.txtKabulMiktar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKabulMiktar_KeyDown);
            // 
            // lbl_KabulMiktar
            // 
            this.lbl_KabulMiktar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.lbl_KabulMiktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_KabulMiktar.Location = new System.Drawing.Point(4, 6);
            this.lbl_KabulMiktar.Name = "lbl_KabulMiktar";
            this.lbl_KabulMiktar.Size = new System.Drawing.Size(58, 15);
            this.lbl_KabulMiktar.Text = "Kbl. Mik:";
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p4.Controls.Add(this.btn_Ekle);
            this.p4.Controls.Add(this.txtAciklama);
            this.p4.Controls.Add(this.lb_Aciklama);
            this.p4.Location = new System.Drawing.Point(3, 166);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(312, 42);
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Ekle.BackgroundImage = null;
            this.btn_Ekle.Enabled = false;
            this.btn_Ekle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Ekle.ForeColor = System.Drawing.Color.White;
            this.btn_Ekle.Location = new System.Drawing.Point(228, 16);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(81, 22);
            this.btn_Ekle.TabIndex = 81;
            this.btn_Ekle.Text = "Değiştir";
            this.btn_Ekle.Click += new System.EventHandler(this.btn_Ekle_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.BackColor = System.Drawing.Color.White;
            this.txtAciklama.Enabled = false;
            this.txtAciklama.Location = new System.Drawing.Point(5, 16);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(217, 23);
            this.txtAciklama.TabIndex = 60;
            this.txtAciklama.GotFocus += new System.EventHandler(this.txtAciklama_GotFocus);
            this.txtAciklama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAciklama_KeyDown);
            // 
            // lb_Aciklama
            // 
            this.lb_Aciklama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.lb_Aciklama.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lb_Aciklama.Location = new System.Drawing.Point(2, 1);
            this.lb_Aciklama.Name = "lb_Aciklama";
            this.lb_Aciklama.Size = new System.Drawing.Size(60, 20);
            this.lb_Aciklama.Text = "Açıklama:";
            this.lb_Aciklama.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.Controls.Add(this.txtIadeTuru);
            this.p2.Controls.Add(this.txtMalzemeNo);
            this.p2.Controls.Add(this.lbl_MalzemeNo);
            this.p2.Location = new System.Drawing.Point(3, 47);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(312, 30);
            // 
            // txtMalzemeNo
            // 
            this.txtMalzemeNo.BackColor = System.Drawing.Color.White;
            this.txtMalzemeNo.Enabled = false;
            this.txtMalzemeNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMalzemeNo.Location = new System.Drawing.Point(131, 5);
            this.txtMalzemeNo.Name = "txtMalzemeNo";
            this.txtMalzemeNo.Size = new System.Drawing.Size(153, 19);
            this.txtMalzemeNo.TabIndex = 5;
            this.txtMalzemeNo.GotFocus += new System.EventHandler(this.txtMalzemeNo_GotFocus);
            this.txtMalzemeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMalzemeNo_KeyDown);
            // 
            // lbl_MalzemeNo
            // 
            this.lbl_MalzemeNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeNo.Location = new System.Drawing.Point(3, 6);
            this.lbl_MalzemeNo.Name = "lbl_MalzemeNo";
            this.lbl_MalzemeNo.Size = new System.Drawing.Size(122, 17);
            this.lbl_MalzemeNo.Text = "Malzeme No:";
            // 
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.White;
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(137, 82);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(178, 81);
            this.grd_List.TabIndex = 88;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle2);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn8);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Açıklama";
            this.dataGridTextBoxColumn1.MappingName = "Aciklama";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Malz. No";
            this.dataGridTextBoxColumn2.MappingName = "Matnr";
            this.dataGridTextBoxColumn2.Width = 65;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Miktar";
            this.dataGridTextBoxColumn4.MappingName = "Menge";
            this.dataGridTextBoxColumn4.Width = 35;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Kbl. Mik.";
            this.dataGridTextBoxColumn8.MappingName = "kabulMiktar";
            this.dataGridTextBoxColumn8.Width = 35;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Ö.Br.";
            this.dataGridTextBoxColumn3.MappingName = "Meins";
            this.dataGridTextBoxColumn3.Width = 25;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "Vbelns";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.MappingName = "Webklm";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.MappingName = "Websid";
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.White;
            this.p5.Controls.Add(this.txtSiparisNo);
            this.p5.Controls.Add(this.lbl_WebSiparisNo);
            this.p5.Location = new System.Drawing.Point(165, 3);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(150, 40);
            // 
            // txtSiparisNo
            // 
            this.txtSiparisNo.BackColor = System.Drawing.Color.White;
            this.txtSiparisNo.Enabled = false;
            this.txtSiparisNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSiparisNo.Location = new System.Drawing.Point(4, 19);
            this.txtSiparisNo.Name = "txtSiparisNo";
            this.txtSiparisNo.Size = new System.Drawing.Size(143, 19);
            this.txtSiparisNo.TabIndex = 5;
            this.txtSiparisNo.GotFocus += new System.EventHandler(this.txtSiparisNo_GotFocus_1);
            this.txtSiparisNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSiparisNo_KeyDown_1);
            // 
            // lbl_WebSiparisNo
            // 
            this.lbl_WebSiparisNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_WebSiparisNo.Location = new System.Drawing.Point(3, 4);
            this.lbl_WebSiparisNo.Name = "lbl_WebSiparisNo";
            this.lbl_WebSiparisNo.Size = new System.Drawing.Size(144, 17);
            this.lbl_WebSiparisNo.Text = "Web Sip. No:";
            this.lbl_WebSiparisNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.btn_Kaydet.TabIndex = 79;
            this.btn_Kaydet.Text = "    TAMAMLA";
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
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
            this.btn_Geri.TabIndex = 78;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
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
            // txtIadeTuru
            // 
            this.txtIadeTuru.BackColor = System.Drawing.Color.White;
            this.txtIadeTuru.Enabled = false;
            this.txtIadeTuru.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtIadeTuru.Location = new System.Drawing.Point(290, 5);
            this.txtIadeTuru.Name = "txtIadeTuru";
            this.txtIadeTuru.Size = new System.Drawing.Size(19, 19);
            this.txtIadeTuru.TabIndex = 7;
            // 
            // frm_32_Musteri_Iade_Girisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.grd_List);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.txtSAPIadeSiparisNo);
            this.Controls.Add(this.lbl_SAPIadeSiparisNo);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.btn_Geri);
            this.Name = "frm_32_Musteri_Iade_Girisi";
            this.Text = "Müşteri İade Girişi";
            this.Load += new System.EventHandler(this.frm_32_Musteri_Iade_Girisi_Load);
            this.p1.ResumeLayout(false);
            this.p3.ResumeLayout(false);
            this.p4.ResumeLayout(false);
            this.p2.ResumeLayout(false);
            this.p5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_Kaydet;
        private PictureButton btn_Geri;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.TextBox txtSiparisId;
        private System.Windows.Forms.Label lbl_WebSiparisId;
        private System.Windows.Forms.Label lbl_SAPIadeSiparisNo;
        private System.Windows.Forms.TextBox txtSAPIadeSiparisNo;
        private System.Windows.Forms.Panel p3;
        private System.Windows.Forms.TextBox txtKabulMiktar;
        private System.Windows.Forms.Label lbl_KabulMiktar;
        private System.Windows.Forms.Panel p4;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label lb_Aciklama;
        private PictureButton btn_Ekle;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.TextBox txtMalzemeNo;
        private System.Windows.Forms.Label lbl_MalzemeNo;
        private System.Windows.Forms.DataGrid grd_List;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.TextBox txtDegisimMiktar;
        private System.Windows.Forms.Label lbl_DegisimMiktari;
        private System.Windows.Forms.Panel p5;
        private System.Windows.Forms.TextBox txtSiparisNo;
        private System.Windows.Forms.Label lbl_WebSiparisNo;
        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.TextBox txtIadeTuru;
    }
}