namespace KoctasWM_Project
{
    partial class frm_42_Kargo_Alani_Paketleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_42_Kargo_Alani_Paketleme));
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.txtPaletNo = new System.Windows.Forms.TextBox();
            this.lbl_DagitimAdresiOlmasiGereken = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKoliNo = new System.Windows.Forms.TextBox();
            this.grdKoliler = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.btn_Secili_Satiri_Sil = new KoctasWM_Project.PictureButton();
            this.btn_Ekle = new KoctasWM_Project.PictureButton();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Tamamla = new KoctasWM_Project.PictureButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // txtPaletNo
            // 
            this.txtPaletNo.BackColor = System.Drawing.Color.White;
            this.txtPaletNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPaletNo.Location = new System.Drawing.Point(122, 4);
            this.txtPaletNo.Name = "txtPaletNo";
            this.txtPaletNo.Size = new System.Drawing.Size(187, 19);
            this.txtPaletNo.TabIndex = 3;
            this.txtPaletNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPaletNo_KeyUp);
            // 
            // lbl_DagitimAdresiOlmasiGereken
            // 
            this.lbl_DagitimAdresiOlmasiGereken.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_DagitimAdresiOlmasiGereken.Location = new System.Drawing.Point(3, 3);
            this.lbl_DagitimAdresiOlmasiGereken.Name = "lbl_DagitimAdresiOlmasiGereken";
            this.lbl_DagitimAdresiOlmasiGereken.Size = new System.Drawing.Size(103, 20);
            this.lbl_DagitimAdresiOlmasiGereken.Text = "Palet Numarası";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtKoliNo);
            this.panel1.Controls.Add(this.lbl_DagitimAdresiOlmasiGereken);
            this.panel1.Controls.Add(this.txtPaletNo);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 58);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.Text = "Koli Numarası";
            // 
            // txtKoliNo
            // 
            this.txtKoliNo.BackColor = System.Drawing.Color.White;
            this.txtKoliNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtKoliNo.Location = new System.Drawing.Point(122, 29);
            this.txtKoliNo.Name = "txtKoliNo";
            this.txtKoliNo.Size = new System.Drawing.Size(187, 19);
            this.txtKoliNo.TabIndex = 5;
            this.txtKoliNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKoliNo_KeyDown);
            // 
            // grdKoliler
            // 
            this.grdKoliler.BackColor = System.Drawing.Color.White;
            this.grdKoliler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grdKoliler.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grdKoliler.Location = new System.Drawing.Point(3, 92);
            this.grdKoliler.Name = "grdKoliler";
            this.grdKoliler.Size = new System.Drawing.Size(312, 97);
            this.grdKoliler.TabIndex = 100;
            this.grdKoliler.TableStyles.Add(this.dataGridTableStyle2);
            // 
            // btn_Secili_Satiri_Sil
            // 
            this.btn_Secili_Satiri_Sil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Secili_Satiri_Sil.BackgroundImage = null;
            this.btn_Secili_Satiri_Sil.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Secili_Satiri_Sil.ForeColor = System.Drawing.Color.White;
            this.btn_Secili_Satiri_Sil.Location = new System.Drawing.Point(76, 67);
            this.btn_Secili_Satiri_Sil.Name = "btn_Secili_Satiri_Sil";
            this.btn_Secili_Satiri_Sil.Size = new System.Drawing.Size(109, 19);
            this.btn_Secili_Satiri_Sil.TabIndex = 103;
            this.btn_Secili_Satiri_Sil.Text = "Seçili Satırı Sil";
            this.btn_Secili_Satiri_Sil.Click += new System.EventHandler(this.btn_Secili_Satiri_Sil_Click);
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Ekle.BackgroundImage = null;
            this.btn_Ekle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Ekle.ForeColor = System.Drawing.Color.White;
            this.btn_Ekle.Location = new System.Drawing.Point(3, 67);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(67, 19);
            this.btn_Ekle.TabIndex = 75;
            this.btn_Ekle.Text = "Ekle";
            this.btn_Ekle.Click += new System.EventHandler(this.btn_Ekle_Click);
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
            this.btn_Geri.TabIndex = 63;
            this.btn_Geri.Text = "GERİ";
            this.btn_Geri.Click += new System.EventHandler(this.btn_Geri_Click);
            // 
            // btn_Tamamla
            // 
            this.btn_Tamamla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Tamamla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Tamamla.BackgroundImage")));
            this.btn_Tamamla.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Tamamla.ForeColor = System.Drawing.Color.White;
            this.btn_Tamamla.Location = new System.Drawing.Point(165, 209);
            this.btn_Tamamla.Name = "btn_Tamamla";
            this.btn_Tamamla.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Tamamla.PressedImage")));
            this.btn_Tamamla.Size = new System.Drawing.Size(150, 47);
            this.btn_Tamamla.TabIndex = 62;
            this.btn_Tamamla.Text = "    TAMAMLA";
            this.btn_Tamamla.Click += new System.EventHandler(this.btn_Tamamla_Click);
            // 
            // frm_42_Kargo_Alani_Paketleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Secili_Satiri_Sil);
            this.Controls.Add(this.grdKoliler);
            this.Controls.Add(this.btn_Ekle);
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_Tamamla);
            this.Name = "frm_42_Kargo_Alani_Paketleme";
            this.Text = "Kargo Alanı Paketleme";
            this.Load += new System.EventHandler(this.frm_42_Kargo_Alani_Paketleme_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.TextBox txtPaletNo;
        private System.Windows.Forms.Label lbl_DagitimAdresiOlmasiGereken;
        private System.Windows.Forms.Panel panel1;
        private PictureButton btn_Geri;
        private PictureButton btn_Tamamla;
        private PictureButton btn_Ekle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKoliNo;
        private System.Windows.Forms.DataGrid grdKoliler;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private PictureButton btn_Secili_Satiri_Sil;
    }
}