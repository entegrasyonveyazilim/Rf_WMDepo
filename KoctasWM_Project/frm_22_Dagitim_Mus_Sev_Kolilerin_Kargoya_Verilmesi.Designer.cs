namespace KoctasWM_Project
{
    partial class frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi));
            this.p1 = new System.Windows.Forms.Panel();
            this.cmbKargoFirmasi = new System.Windows.Forms.ComboBox();
            this.lbl_KargoFirmasi = new System.Windows.Forms.Label();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Kaydet = new KoctasWM_Project.PictureButton();
            this.p2 = new System.Windows.Forms.Panel();
            this.lbl_KargoKoliNo = new System.Windows.Forms.Label();
            this.txtKargoKoliNo = new System.Windows.Forms.TextBox();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.p2.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.cmbKargoFirmasi);
            this.p1.Controls.Add(this.lbl_KargoFirmasi);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 34);
            // 
            // cmbKargoFirmasi
            // 
            this.cmbKargoFirmasi.Location = new System.Drawing.Point(131, 6);
            this.cmbKargoFirmasi.Name = "cmbKargoFirmasi";
            this.cmbKargoFirmasi.Size = new System.Drawing.Size(178, 23);
            this.cmbKargoFirmasi.TabIndex = 1;
            this.cmbKargoFirmasi.SelectedIndexChanged += new System.EventHandler(this.cmbKargoFirmasi_SelectedIndexChanged);
            this.cmbKargoFirmasi.GotFocus += new System.EventHandler(this.cmbKargoFirmasi_GotFocus);
            // 
            // lbl_KargoFirmasi
            // 
            this.lbl_KargoFirmasi.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_KargoFirmasi.Location = new System.Drawing.Point(3, 6);
            this.lbl_KargoFirmasi.Name = "lbl_KargoFirmasi";
            this.lbl_KargoFirmasi.Size = new System.Drawing.Size(122, 20);
            this.lbl_KargoFirmasi.Text = "Kargo Firması:";
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
            this.btn_Geri.TabIndex = 68;
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
            this.btn_Kaydet.TabIndex = 67;
            this.btn_Kaydet.Text = "   TESLİM ET";
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.Controls.Add(this.lbl_KargoKoliNo);
            this.p2.Controls.Add(this.txtKargoKoliNo);
            this.p2.Location = new System.Drawing.Point(3, 43);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(312, 33);
            // 
            // lbl_KargoKoliNo
            // 
            this.lbl_KargoKoliNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_KargoKoliNo.Location = new System.Drawing.Point(3, 6);
            this.lbl_KargoKoliNo.Name = "lbl_KargoKoliNo";
            this.lbl_KargoKoliNo.Size = new System.Drawing.Size(122, 20);
            this.lbl_KargoKoliNo.Text = "Kargo Koli No:";
            // 
            // txtKargoKoliNo
            // 
            this.txtKargoKoliNo.BackColor = System.Drawing.Color.White;
            this.txtKargoKoliNo.Location = new System.Drawing.Point(131, 6);
            this.txtKargoKoliNo.Name = "txtKargoKoliNo";
            this.txtKargoKoliNo.Size = new System.Drawing.Size(178, 23);
            this.txtKargoKoliNo.TabIndex = 3;
            this.txtKargoKoliNo.GotFocus += new System.EventHandler(this.txtKargoKoliNo_GotFocus);
            this.txtKargoKoliNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKargoKoliNo_KeyDown);
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
            // frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.p1);
            this.Name = "frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi";
            this.Text = "Müşteri Sev. Kolilerin Kargoya Tes.ve İptali";
            this.Load += new System.EventHandler(this.frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi_Load);
            this.p1.ResumeLayout(false);
            this.p2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.ComboBox cmbKargoFirmasi;
        private System.Windows.Forms.Label lbl_KargoFirmasi;
        private PictureButton btn_Geri;
        private PictureButton btn_Kaydet;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.Label lbl_KargoKoliNo;
        private System.Windows.Forms.TextBox txtKargoKoliNo;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}