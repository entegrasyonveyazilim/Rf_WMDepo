namespace KoctasWM_Project
{
    partial class frm_31_Mal_Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_31_Mal_Giris));
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_MalzemeGirisi = new KoctasWM_Project.PictureButton();
            this.p1 = new System.Windows.Forms.Panel();
            this.dtp_belge = new System.Windows.Forms.DateTimePicker();
            this.lbl_BelgeTarihi = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Panel();
            this.dtp_kayit = new System.Windows.Forms.DateTimePicker();
            this.lbl_KayitTarihi = new System.Windows.Forms.Label();
            this.p3 = new System.Windows.Forms.Panel();
            this.chk_horoz = new System.Windows.Forms.CheckBox();
            this.lbl_IrsaliyeNo = new System.Windows.Forms.Label();
            this.txtIrsaliyeNo = new System.Windows.Forms.TextBox();
            this.p4 = new System.Windows.Forms.Panel();
            this.btn_KontrolEt = new KoctasWM_Project.PictureButton();
            this.lbl_SevkiyatNo = new System.Windows.Forms.Label();
            this.txtSevkiyatNo = new System.Windows.Forms.TextBox();
            this.p5 = new System.Windows.Forms.Panel();
            this.btn_Ekle = new KoctasWM_Project.PictureButton();
            this.lbl_SiparisNo = new System.Windows.Forms.Label();
            this.txtSiparisNo = new System.Windows.Forms.TextBox();
            this.lst_Siparis = new System.Windows.Forms.ListBox();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.p2.SuspendLayout();
            this.p3.SuspendLayout();
            this.p4.SuspendLayout();
            this.p5.SuspendLayout();
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
            this.btn_Geri.Size = new System.Drawing.Size(150, 47);
            this.btn_Geri.TabIndex = 60;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_MalzemeGirisi
            // 
            this.btn_MalzemeGirisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_MalzemeGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_MalzemeGirisi.BackgroundImage")));
            this.btn_MalzemeGirisi.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_MalzemeGirisi.ForeColor = System.Drawing.Color.White;
            this.btn_MalzemeGirisi.Location = new System.Drawing.Point(165, 209);
            this.btn_MalzemeGirisi.Name = "btn_MalzemeGirisi";
            this.btn_MalzemeGirisi.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_MalzemeGirisi.PressedImage")));
            this.btn_MalzemeGirisi.Size = new System.Drawing.Size(150, 47);
            this.btn_MalzemeGirisi.TabIndex = 59;
            this.btn_MalzemeGirisi.Text = "      MALZEME GİRİŞİ";
            this.btn_MalzemeGirisi.Click += new System.EventHandler(this.btn_MalzemeGirisi_Click);
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.dtp_belge);
            this.p1.Controls.Add(this.lbl_BelgeTarihi);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 29);
            // 
            // dtp_belge
            // 
            this.dtp_belge.CalendarFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.dtp_belge.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.dtp_belge.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_belge.Location = new System.Drawing.Point(108, 3);
            this.dtp_belge.Name = "dtp_belge";
            this.dtp_belge.Size = new System.Drawing.Size(201, 22);
            this.dtp_belge.TabIndex = 64;
            this.dtp_belge.ValueChanged += new System.EventHandler(this.dtp_belge_ValueChanged);
            this.dtp_belge.GotFocus += new System.EventHandler(this.dtp_belge_GotFocus);
            // 
            // lbl_BelgeTarihi
            // 
            this.lbl_BelgeTarihi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_BelgeTarihi.Location = new System.Drawing.Point(3, 6);
            this.lbl_BelgeTarihi.Name = "lbl_BelgeTarihi";
            this.lbl_BelgeTarihi.Size = new System.Drawing.Size(122, 20);
            this.lbl_BelgeTarihi.Text = "Belge Tarihi:";
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.Controls.Add(this.dtp_kayit);
            this.p2.Controls.Add(this.lbl_KayitTarihi);
            this.p2.Location = new System.Drawing.Point(3, 34);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(312, 29);
            // 
            // dtp_kayit
            // 
            this.dtp_kayit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.dtp_kayit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_kayit.Location = new System.Drawing.Point(108, 4);
            this.dtp_kayit.Name = "dtp_kayit";
            this.dtp_kayit.Size = new System.Drawing.Size(201, 22);
            this.dtp_kayit.TabIndex = 64;
            this.dtp_kayit.GotFocus += new System.EventHandler(this.dtp_kayit_GotFocus);
            // 
            // lbl_KayitTarihi
            // 
            this.lbl_KayitTarihi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_KayitTarihi.Location = new System.Drawing.Point(3, 6);
            this.lbl_KayitTarihi.Name = "lbl_KayitTarihi";
            this.lbl_KayitTarihi.Size = new System.Drawing.Size(122, 20);
            this.lbl_KayitTarihi.Text = "Kayıt Tarihi:";
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.White;
            this.p3.Controls.Add(this.chk_horoz);
            this.p3.Controls.Add(this.lbl_IrsaliyeNo);
            this.p3.Controls.Add(this.txtIrsaliyeNo);
            this.p3.Location = new System.Drawing.Point(3, 65);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(312, 27);
            // 
            // chk_horoz
            // 
            this.chk_horoz.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.chk_horoz.Location = new System.Drawing.Point(204, 3);
            this.chk_horoz.Name = "chk_horoz";
            this.chk_horoz.Size = new System.Drawing.Size(105, 20);
            this.chk_horoz.TabIndex = 68;
            this.chk_horoz.Text = "Horoz Lojistik";
            this.chk_horoz.Click += new System.EventHandler(this.chk_horoz_Click);
            // 
            // lbl_IrsaliyeNo
            // 
            this.lbl_IrsaliyeNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_IrsaliyeNo.Location = new System.Drawing.Point(3, 4);
            this.lbl_IrsaliyeNo.Name = "lbl_IrsaliyeNo";
            this.lbl_IrsaliyeNo.Size = new System.Drawing.Size(101, 20);
            this.lbl_IrsaliyeNo.Text = "İrsaliye No:";
            // 
            // txtIrsaliyeNo
            // 
            this.txtIrsaliyeNo.BackColor = System.Drawing.Color.White;
            this.txtIrsaliyeNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtIrsaliyeNo.Location = new System.Drawing.Point(110, 3);
            this.txtIrsaliyeNo.Name = "txtIrsaliyeNo";
            this.txtIrsaliyeNo.Size = new System.Drawing.Size(88, 21);
            this.txtIrsaliyeNo.TabIndex = 3;
            this.txtIrsaliyeNo.GotFocus += new System.EventHandler(this.txtIrsaliyeNo_GotFocus);
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.Color.White;
            this.p4.Controls.Add(this.btn_KontrolEt);
            this.p4.Controls.Add(this.lbl_SevkiyatNo);
            this.p4.Controls.Add(this.txtSevkiyatNo);
            this.p4.Location = new System.Drawing.Point(3, 96);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(312, 27);
            // 
            // btn_KontrolEt
            // 
            this.btn_KontrolEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_KontrolEt.BackgroundImage = null;
            this.btn_KontrolEt.Enabled = false;
            this.btn_KontrolEt.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_KontrolEt.ForeColor = System.Drawing.Color.White;
            this.btn_KontrolEt.Location = new System.Drawing.Point(234, 3);
            this.btn_KontrolEt.Name = "btn_KontrolEt";
            this.btn_KontrolEt.Size = new System.Drawing.Size(75, 22);
            this.btn_KontrolEt.TabIndex = 80;
            this.btn_KontrolEt.Text = "Kontrol Et";
            this.btn_KontrolEt.Click += new System.EventHandler(this.btn_KontrolEt_Click);
            // 
            // lbl_SevkiyatNo
            // 
            this.lbl_SevkiyatNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_SevkiyatNo.Location = new System.Drawing.Point(3, 4);
            this.lbl_SevkiyatNo.Name = "lbl_SevkiyatNo";
            this.lbl_SevkiyatNo.Size = new System.Drawing.Size(101, 20);
            this.lbl_SevkiyatNo.Text = "Sevkiyat No:";
            // 
            // txtSevkiyatNo
            // 
            this.txtSevkiyatNo.BackColor = System.Drawing.Color.White;
            this.txtSevkiyatNo.Enabled = false;
            this.txtSevkiyatNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtSevkiyatNo.Location = new System.Drawing.Point(110, 3);
            this.txtSevkiyatNo.Name = "txtSevkiyatNo";
            this.txtSevkiyatNo.Size = new System.Drawing.Size(118, 21);
            this.txtSevkiyatNo.TabIndex = 3;
            this.txtSevkiyatNo.GotFocus += new System.EventHandler(this.txtSevkiyatNo_GotFocus);
            this.txtSevkiyatNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSevkiyatNo_KeyPress);
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.White;
            this.p5.Controls.Add(this.btn_Ekle);
            this.p5.Controls.Add(this.lbl_SiparisNo);
            this.p5.Controls.Add(this.txtSiparisNo);
            this.p5.Location = new System.Drawing.Point(3, 126);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(312, 28);
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Ekle.BackgroundImage = null;
            this.btn_Ekle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Ekle.ForeColor = System.Drawing.Color.White;
            this.btn_Ekle.Location = new System.Drawing.Point(234, 3);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(75, 22);
            this.btn_Ekle.TabIndex = 80;
            this.btn_Ekle.Text = "Ekle";
            this.btn_Ekle.Click += new System.EventHandler(this.btn_Ekle_Click);
            // 
            // lbl_SiparisNo
            // 
            this.lbl_SiparisNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_SiparisNo.Location = new System.Drawing.Point(3, 4);
            this.lbl_SiparisNo.Name = "lbl_SiparisNo";
            this.lbl_SiparisNo.Size = new System.Drawing.Size(101, 17);
            this.lbl_SiparisNo.Text = "Sipariş No:";
            // 
            // txtSiparisNo
            // 
            this.txtSiparisNo.BackColor = System.Drawing.Color.White;
            this.txtSiparisNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txtSiparisNo.Location = new System.Drawing.Point(110, 3);
            this.txtSiparisNo.Name = "txtSiparisNo";
            this.txtSiparisNo.Size = new System.Drawing.Size(118, 21);
            this.txtSiparisNo.TabIndex = 3;
            this.txtSiparisNo.GotFocus += new System.EventHandler(this.txtSiparisNo_GotFocus);
            this.txtSiparisNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSiparisNo_KeyPress);
            // 
            // lst_Siparis
            // 
            this.lst_Siparis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.lst_Siparis.Location = new System.Drawing.Point(113, 156);
            this.lst_Siparis.Name = "lst_Siparis";
            this.lst_Siparis.Size = new System.Drawing.Size(202, 50);
            this.lst_Siparis.TabIndex = 90;
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
            // frm_31_Mal_Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.lst_Siparis);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_MalzemeGirisi);
            this.Name = "frm_31_Mal_Giris";
            this.Text = "Mal Girişi";
            this.Load += new System.EventHandler(this.frm_31_Mal_Giris_Load);
            this.p1.ResumeLayout(false);
            this.p2.ResumeLayout(false);
            this.p3.ResumeLayout(false);
            this.p4.ResumeLayout(false);
            this.p5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_Geri;
        private PictureButton btn_MalzemeGirisi;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label lbl_BelgeTarihi;
        private System.Windows.Forms.DateTimePicker dtp_belge;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.DateTimePicker dtp_kayit;
        private System.Windows.Forms.Label lbl_KayitTarihi;
        private System.Windows.Forms.Panel p3;
        private System.Windows.Forms.Label lbl_IrsaliyeNo;
        private System.Windows.Forms.TextBox txtIrsaliyeNo;
        private System.Windows.Forms.Panel p4;
        private PictureButton btn_KontrolEt;
        private System.Windows.Forms.Label lbl_SevkiyatNo;
        private System.Windows.Forms.TextBox txtSevkiyatNo;
        private System.Windows.Forms.Panel p5;
        private PictureButton btn_Ekle;
        private System.Windows.Forms.Label lbl_SiparisNo;
        private System.Windows.Forms.TextBox txtSiparisNo;
        private System.Windows.Forms.CheckBox chk_horoz;
        private System.Windows.Forms.ListBox lst_Siparis;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}