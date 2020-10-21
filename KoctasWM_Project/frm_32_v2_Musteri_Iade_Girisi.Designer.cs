namespace KoctasWM_Project
{
    partial class frm_32_v2_Musteri_Iade_Girisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_32_v2_Musteri_Iade_Girisi));
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.p1 = new System.Windows.Forms.Panel();
            this.txtSiparisId = new System.Windows.Forms.TextBox();
            this.lbl_WebSiparisId = new System.Windows.Forms.Label();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.txtIadeTuru = new System.Windows.Forms.TextBox();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.grd_List = new System.Windows.Forms.DataGrid();
            this.p3 = new System.Windows.Forms.Panel();
            this.txtKabulMiktar = new System.Windows.Forms.TextBox();
            this.lbl_KabulMiktar = new System.Windows.Forms.Label();
            this.lbl_MalzemeNo = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Panel();
            this.txtDurum = new System.Windows.Forms.TextBox();
            this.txtMalzemeNo = new System.Windows.Forms.TextBox();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Kaydet = new KoctasWM_Project.PictureButton();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Ekle = new KoctasWM_Project.PictureButton();
            this.p1.SuspendLayout();
            this.p3.SuspendLayout();
            this.p2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Miktar";
            this.dataGridTextBoxColumn4.MappingName = "Kwmeng";
            this.dataGridTextBoxColumn4.Width = 35;
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.txtSiparisId);
            this.p1.Controls.Add(this.lbl_WebSiparisId);
            this.p1.Location = new System.Drawing.Point(3, 7);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 28);
            // 
            // txtSiparisId
            // 
            this.txtSiparisId.BackColor = System.Drawing.Color.White;
            this.txtSiparisId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSiparisId.Location = new System.Drawing.Point(84, 5);
            this.txtSiparisId.Name = "txtSiparisId";
            this.txtSiparisId.Size = new System.Drawing.Size(175, 19);
            this.txtSiparisId.TabIndex = 5;
            this.txtSiparisId.GotFocus += new System.EventHandler(this.txtSiparisNo_GotFocus);
            this.txtSiparisId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSiparisNo_KeyDown);
            // 
            // lbl_WebSiparisId
            // 
            this.lbl_WebSiparisId.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_WebSiparisId.Location = new System.Drawing.Point(3, 5);
            this.lbl_WebSiparisId.Name = "lbl_WebSiparisId";
            this.lbl_WebSiparisId.Size = new System.Drawing.Size(93, 19);
            this.lbl_WebSiparisId.Text = "İade Sip. No:";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Malz. No";
            this.dataGridTextBoxColumn2.MappingName = "Matnr";
            this.dataGridTextBoxColumn2.Width = 65;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Kbl. Mik.";
            this.dataGridTextBoxColumn8.MappingName = "kabulMiktar";
            this.dataGridTextBoxColumn8.Width = 35;
            // 
            // txtIadeTuru
            // 
            this.txtIadeTuru.BackColor = System.Drawing.Color.White;
            this.txtIadeTuru.Enabled = false;
            this.txtIadeTuru.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtIadeTuru.Location = new System.Drawing.Point(273, 20);
            this.txtIadeTuru.Name = "txtIadeTuru";
            this.txtIadeTuru.Size = new System.Drawing.Size(33, 19);
            this.txtIadeTuru.TabIndex = 7;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Ö.Br.";
            this.dataGridTextBoxColumn3.MappingName = "Meins";
            this.dataGridTextBoxColumn3.Width = 25;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn8);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "Vbeln";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.MappingName = "Posnr";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.White;
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(137, 86);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(178, 121);
            this.grd_List.TabIndex = 99;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle2);
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p3.Controls.Add(this.btn_Ekle);
            this.p3.Controls.Add(this.txtKabulMiktar);
            this.p3.Controls.Add(this.lbl_KabulMiktar);
            this.p3.Location = new System.Drawing.Point(3, 89);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(128, 46);
            // 
            // txtKabulMiktar
            // 
            this.txtKabulMiktar.BackColor = System.Drawing.Color.White;
            this.txtKabulMiktar.Enabled = false;
            this.txtKabulMiktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtKabulMiktar.Location = new System.Drawing.Point(5, 17);
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
            this.lbl_KabulMiktar.Location = new System.Drawing.Point(4, 1);
            this.lbl_KabulMiktar.Name = "lbl_KabulMiktar";
            this.lbl_KabulMiktar.Size = new System.Drawing.Size(58, 15);
            this.lbl_KabulMiktar.Text = "Kbl. Mik:";
            // 
            // lbl_MalzemeNo
            // 
            this.lbl_MalzemeNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeNo.Location = new System.Drawing.Point(3, 21);
            this.lbl_MalzemeNo.Name = "lbl_MalzemeNo";
            this.lbl_MalzemeNo.Size = new System.Drawing.Size(122, 17);
            this.lbl_MalzemeNo.Text = "Malzeme No:";
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.Controls.Add(this.txtIadeTuru);
            this.p2.Controls.Add(this.txtDurum);
            this.p2.Controls.Add(this.label2);
            this.p2.Controls.Add(this.label1);
            this.p2.Controls.Add(this.txtMalzemeNo);
            this.p2.Controls.Add(this.lbl_MalzemeNo);
            this.p2.Location = new System.Drawing.Point(3, 38);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(312, 42);
            // 
            // txtDurum
            // 
            this.txtDurum.BackColor = System.Drawing.Color.White;
            this.txtDurum.Enabled = false;
            this.txtDurum.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDurum.Location = new System.Drawing.Point(227, 20);
            this.txtDurum.Name = "txtDurum";
            this.txtDurum.Size = new System.Drawing.Size(40, 19);
            this.txtDurum.TabIndex = 9;
            // 
            // txtMalzemeNo
            // 
            this.txtMalzemeNo.BackColor = System.Drawing.Color.White;
            this.txtMalzemeNo.Enabled = false;
            this.txtMalzemeNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMalzemeNo.Location = new System.Drawing.Point(84, 19);
            this.txtMalzemeNo.Name = "txtMalzemeNo";
            this.txtMalzemeNo.Size = new System.Drawing.Size(137, 19);
            this.txtMalzemeNo.TabIndex = 5;
            this.txtMalzemeNo.GotFocus += new System.EventHandler(this.txtMalzemeNo_GotFocus);
            this.txtMalzemeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMalzemeNo_KeyDown);
            // 
            // lbl_LoginInfo
            // 
            this.lbl_LoginInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbl_LoginInfo.ForeColor = System.Drawing.Color.Black;
            this.lbl_LoginInfo.Location = new System.Drawing.Point(98, 261);
            this.lbl_LoginInfo.Name = "lbl_LoginInfo";
            this.lbl_LoginInfo.Size = new System.Drawing.Size(217, 16);
            this.lbl_LoginInfo.Text = "Bağlı Kullanıcı: ";
            this.lbl_LoginInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(227, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.Text = "Durum";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(273, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.Text = "Tip";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Kaydet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Kaydet.BackgroundImage")));
            this.btn_Kaydet.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Kaydet.ForeColor = System.Drawing.Color.White;
            this.btn_Kaydet.Location = new System.Drawing.Point(165, 213);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Kaydet.PressedImage")));
            this.btn_Kaydet.Size = new System.Drawing.Size(150, 47);
            this.btn_Kaydet.TabIndex = 96;
            this.btn_Kaydet.Text = "    TAMAMLA";
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            // 
            // btn_Geri
            // 
            this.btn_Geri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Geri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Geri.BackgroundImage")));
            this.btn_Geri.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Geri.ForeColor = System.Drawing.Color.White;
            this.btn_Geri.Location = new System.Drawing.Point(3, 213);
            this.btn_Geri.Name = "btn_Geri";
            this.btn_Geri.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Geri.PressedImage")));
            this.btn_Geri.Size = new System.Drawing.Size(150, 47);
            this.btn_Geri.TabIndex = 95;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Ekle.BackgroundImage = null;
            this.btn_Ekle.Enabled = false;
            this.btn_Ekle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Ekle.ForeColor = System.Drawing.Color.White;
            this.btn_Ekle.Location = new System.Drawing.Point(66, 14);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(59, 22);
            this.btn_Ekle.TabIndex = 81;
            this.btn_Ekle.Text = "Değiştir";
            this.btn_Ekle.Click += new System.EventHandler(this.btn_Ekle_Click);
            // 
            // frm_32_v2_Musteri_Iade_Girisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.p1);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.grd_List);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.lbl_LoginInfo);
            this.Name = "frm_32_v2_Musteri_Iade_Girisi";
            this.Text = "Müşteri İade Girişi - v2";
            this.Load += new System.EventHandler(this.frm_32_v2_Musteri_Iade_Girisi_Load);
            this.p1.ResumeLayout(false);
            this.p3.ResumeLayout(false);
            this.p2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.TextBox txtSiparisId;
        private System.Windows.Forms.Label lbl_WebSiparisId;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.TextBox txtIadeTuru;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private PictureButton btn_Kaydet;
        private PictureButton btn_Geri;
        private System.Windows.Forms.DataGrid grd_List;
        private System.Windows.Forms.Panel p3;
        private System.Windows.Forms.TextBox txtKabulMiktar;
        private System.Windows.Forms.Label lbl_KabulMiktar;
        private System.Windows.Forms.Label lbl_MalzemeNo;
        private PictureButton btn_Ekle;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.TextBox txtMalzemeNo;
        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.TextBox txtDurum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}