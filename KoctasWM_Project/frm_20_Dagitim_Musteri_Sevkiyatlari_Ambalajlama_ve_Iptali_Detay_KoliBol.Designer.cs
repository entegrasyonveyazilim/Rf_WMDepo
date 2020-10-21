namespace KoctasWM_Project
{
    partial class frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol));
            this.p1 = new System.Windows.Forms.Panel();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.txtKargoKoliNo = new System.Windows.Forms.TextBox();
            this.lbl_KargoKoliNo = new System.Windows.Forms.Label();
            this.lblAdet = new System.Windows.Forms.Label();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.grd_List = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.txtDesiBilgisi = new System.Windows.Forms.TextBox();
            this.lbl_DesiBilgisi = new System.Windows.Forms.Label();
            this.cmbKoliTipi = new System.Windows.Forms.ComboBox();
            this.lbl_KoliTipi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKargoKoliNo2 = new System.Windows.Forms.TextBox();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btn_Guncelle = new KoctasWM_Project.PictureButton();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Devam = new KoctasWM_Project.PictureButton();
            this.btn_Temizle = new KoctasWM_Project.PictureButton();
            this.btn_Bol = new KoctasWM_Project.PictureButton();
            this.p1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.btn_Temizle);
            this.p1.Controls.Add(this.btn_Bol);
            this.p1.Controls.Add(this.txtAdet);
            this.p1.Controls.Add(this.txtKargoKoliNo);
            this.p1.Controls.Add(this.lbl_KargoKoliNo);
            this.p1.Controls.Add(this.lblAdet);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 44);
            // 
            // txtAdet
            // 
            this.txtAdet.BackColor = System.Drawing.Color.White;
            this.txtAdet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtAdet.Location = new System.Drawing.Point(117, 20);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(33, 21);
            this.txtAdet.TabIndex = 5;
            this.txtAdet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdet_KeyDown);
            // 
            // txtKargoKoliNo
            // 
            this.txtKargoKoliNo.BackColor = System.Drawing.Color.White;
            this.txtKargoKoliNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtKargoKoliNo.Location = new System.Drawing.Point(3, 20);
            this.txtKargoKoliNo.Name = "txtKargoKoliNo";
            this.txtKargoKoliNo.Size = new System.Drawing.Size(108, 21);
            this.txtKargoKoliNo.TabIndex = 3;
            this.txtKargoKoliNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKargoKoliNo_KeyDown);
            // 
            // lbl_KargoKoliNo
            // 
            this.lbl_KargoKoliNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_KargoKoliNo.Location = new System.Drawing.Point(3, 6);
            this.lbl_KargoKoliNo.Name = "lbl_KargoKoliNo";
            this.lbl_KargoKoliNo.Size = new System.Drawing.Size(108, 20);
            this.lbl_KargoKoliNo.Text = "Kargo Koli No";
            this.lbl_KargoKoliNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAdet
            // 
            this.lblAdet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblAdet.Location = new System.Drawing.Point(118, 5);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(34, 20);
            this.lblAdet.Text = "Adet";
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
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.Enabled = false;
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(2, 48);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(313, 108);
            this.grd_List.TabIndex = 74;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle1);
            this.grd_List.DoubleClick += new System.EventHandler(this.grd_List_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Bölünmüş Koli No";
            this.dataGridTextBoxColumn1.MappingName = "koliNo";
            this.dataGridTextBoxColumn1.Width = 100;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Koli Tipi";
            this.dataGridTextBoxColumn2.MappingName = "koliTipi";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Desi";
            this.dataGridTextBoxColumn3.MappingName = "desi";
            this.dataGridTextBoxColumn3.Width = 30;
            // 
            // txtDesiBilgisi
            // 
            this.txtDesiBilgisi.BackColor = System.Drawing.Color.White;
            this.txtDesiBilgisi.Enabled = false;
            this.txtDesiBilgisi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtDesiBilgisi.Location = new System.Drawing.Point(195, 182);
            this.txtDesiBilgisi.Name = "txtDesiBilgisi";
            this.txtDesiBilgisi.Size = new System.Drawing.Size(45, 21);
            this.txtDesiBilgisi.TabIndex = 78;
            this.txtDesiBilgisi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesiBilgisi_KeyDown);
            // 
            // lbl_DesiBilgisi
            // 
            this.lbl_DesiBilgisi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_DesiBilgisi.Location = new System.Drawing.Point(197, 159);
            this.lbl_DesiBilgisi.Name = "lbl_DesiBilgisi";
            this.lbl_DesiBilgisi.Size = new System.Drawing.Size(43, 20);
            this.lbl_DesiBilgisi.Text = "Desi";
            this.lbl_DesiBilgisi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbKoliTipi
            // 
            this.cmbKoliTipi.Enabled = false;
            this.cmbKoliTipi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.cmbKoliTipi.Items.Add("Koli Tipi 1");
            this.cmbKoliTipi.Items.Add("Koli Tipi 2");
            this.cmbKoliTipi.Location = new System.Drawing.Point(105, 182);
            this.cmbKoliTipi.Name = "cmbKoliTipi";
            this.cmbKoliTipi.Size = new System.Drawing.Size(86, 21);
            this.cmbKoliTipi.TabIndex = 77;
            this.cmbKoliTipi.SelectedIndexChanged += new System.EventHandler(this.cmbKoliTipi_SelectedIndexChanged);
            // 
            // lbl_KoliTipi
            // 
            this.lbl_KoliTipi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_KoliTipi.Location = new System.Drawing.Point(108, 159);
            this.lbl_KoliTipi.Name = "lbl_KoliTipi";
            this.lbl_KoliTipi.Size = new System.Drawing.Size(83, 20);
            this.lbl_KoliTipi.Text = "Koli Tipi";
            this.lbl_KoliTipi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.Text = "Kargo Koli No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtKargoKoliNo2
            // 
            this.txtKargoKoliNo2.BackColor = System.Drawing.Color.White;
            this.txtKargoKoliNo2.Enabled = false;
            this.txtKargoKoliNo2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtKargoKoliNo2.Location = new System.Drawing.Point(6, 182);
            this.txtKargoKoliNo2.Name = "txtKargoKoliNo2";
            this.txtKargoKoliNo2.Size = new System.Drawing.Size(93, 21);
            this.txtKargoKoliNo2.TabIndex = 85;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Mesaj";
            this.dataGridTextBoxColumn4.MappingName = "mesaj";
            this.dataGridTextBoxColumn4.Width = 100;
            // 
            // btn_Guncelle
            // 
            this.btn_Guncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Guncelle.BackgroundImage = null;
            this.btn_Guncelle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Guncelle.ForeColor = System.Drawing.Color.White;
            this.btn_Guncelle.Location = new System.Drawing.Point(246, 181);
            this.btn_Guncelle.Name = "btn_Guncelle";
            this.btn_Guncelle.Size = new System.Drawing.Size(62, 22);
            this.btn_Guncelle.TabIndex = 82;
            this.btn_Guncelle.Text = "Güncelle";
            this.btn_Guncelle.Click += new System.EventHandler(this.btn_Guncelle_Click);
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
            this.btn_Geri.TabIndex = 69;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click_1);
            // 
            // btn_Devam
            // 
            this.btn_Devam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Devam.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Devam.BackgroundImage")));
            this.btn_Devam.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Devam.ForeColor = System.Drawing.Color.White;
            this.btn_Devam.Location = new System.Drawing.Point(165, 209);
            this.btn_Devam.Name = "btn_Devam";
            this.btn_Devam.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Devam.PressedImage")));
            this.btn_Devam.Size = new System.Drawing.Size(150, 47);
            this.btn_Devam.TabIndex = 68;
            this.btn_Devam.Text = "   DEVAM";
            this.btn_Devam.Click += new System.EventHandler(this.btn_Devam_Click);
            // 
            // btn_Temizle
            // 
            this.btn_Temizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Temizle.BackgroundImage = null;
            this.btn_Temizle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Temizle.ForeColor = System.Drawing.Color.White;
            this.btn_Temizle.Location = new System.Drawing.Point(213, 19);
            this.btn_Temizle.Name = "btn_Temizle";
            this.btn_Temizle.Size = new System.Drawing.Size(51, 22);
            this.btn_Temizle.TabIndex = 84;
            this.btn_Temizle.Text = "Temizle";
            this.btn_Temizle.Click += new System.EventHandler(this.btn_Temizle_Click);
            // 
            // btn_Bol
            // 
            this.btn_Bol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Bol.BackgroundImage = null;
            this.btn_Bol.Enabled = false;
            this.btn_Bol.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Bol.ForeColor = System.Drawing.Color.White;
            this.btn_Bol.Location = new System.Drawing.Point(156, 19);
            this.btn_Bol.Name = "btn_Bol";
            this.btn_Bol.Size = new System.Drawing.Size(51, 22);
            this.btn_Bol.TabIndex = 81;
            this.btn_Bol.Text = "Böl";
            this.btn_Bol.Click += new System.EventHandler(this.btn_Bol_Click);
            // 
            // frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.txtKargoKoliNo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Guncelle);
            this.Controls.Add(this.txtDesiBilgisi);
            this.Controls.Add(this.lbl_DesiBilgisi);
            this.Controls.Add(this.cmbKoliTipi);
            this.Controls.Add(this.lbl_KoliTipi);
            this.Controls.Add(this.grd_List);
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_Devam);
            this.Controls.Add(this.p1);
            this.Name = "frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol";
            this.Text = "Koli Böl";
            this.Load += new System.EventHandler(this.frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_Load);
            this.p1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label lbl_KargoKoliNo;
        private System.Windows.Forms.TextBox txtKargoKoliNo;
        private System.Windows.Forms.Label lbl_LoginInfo;
        private PictureButton btn_Geri;
        private PictureButton btn_Devam;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.DataGrid grd_List;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private PictureButton btn_Bol;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.TextBox txtDesiBilgisi;
        private System.Windows.Forms.Label lbl_DesiBilgisi;
        private System.Windows.Forms.ComboBox cmbKoliTipi;
        private System.Windows.Forms.Label lbl_KoliTipi;
        private PictureButton btn_Guncelle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKargoKoliNo2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private PictureButton btn_Temizle;
    }
}