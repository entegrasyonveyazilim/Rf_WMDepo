namespace KoctasWM_Project
{
    partial class frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi));
            this.p2 = new System.Windows.Forms.Panel();
            this.btn_Ekle = new KoctasWM_Project.PictureButton();
            this.lbl_PaletKargoNo = new System.Windows.Forms.Label();
            this.txtPaletKargoNo = new System.Windows.Forms.TextBox();
            this.grd_List = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.p1 = new System.Windows.Forms.Panel();
            this.txtSevkiyatNo = new System.Windows.Forms.TextBox();
            this.lbl_SevkiyatNo = new System.Windows.Forms.Label();
            this.lbl_Bilgi = new System.Windows.Forms.Label();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.btn_Kaydet = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p2.SuspendLayout();
            this.p1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.White;
            this.p2.Controls.Add(this.btn_Ekle);
            this.p2.Controls.Add(this.lbl_PaletKargoNo);
            this.p2.Controls.Add(this.txtPaletKargoNo);
            this.p2.Location = new System.Drawing.Point(3, 43);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(312, 33);
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Ekle.BackgroundImage = null;
            this.btn_Ekle.Enabled = false;
            this.btn_Ekle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Ekle.ForeColor = System.Drawing.Color.White;
            this.btn_Ekle.Location = new System.Drawing.Point(249, 6);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(60, 23);
            this.btn_Ekle.TabIndex = 75;
            this.btn_Ekle.Text = "Ekle";
            this.btn_Ekle.Click += new System.EventHandler(this.btn_Ekle_Click);
            // 
            // lbl_PaletKargoNo
            // 
            this.lbl_PaletKargoNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_PaletKargoNo.Location = new System.Drawing.Point(3, 6);
            this.lbl_PaletKargoNo.Name = "lbl_PaletKargoNo";
            this.lbl_PaletKargoNo.Size = new System.Drawing.Size(122, 20);
            this.lbl_PaletKargoNo.Text = "Palet Kargo No:";
            // 
            // txtPaletKargoNo
            // 
            this.txtPaletKargoNo.BackColor = System.Drawing.Color.White;
            this.txtPaletKargoNo.Enabled = false;
            this.txtPaletKargoNo.Location = new System.Drawing.Point(131, 6);
            this.txtPaletKargoNo.Name = "txtPaletKargoNo";
            this.txtPaletKargoNo.Size = new System.Drawing.Size(112, 23);
            this.txtPaletKargoNo.TabIndex = 3;
            this.txtPaletKargoNo.GotFocus += new System.EventHandler(this.txtPaletKargoNo_GotFocus);
            this.txtPaletKargoNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaletKargoNo_KeyDown);
            // 
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(3, 82);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(312, 108);
            this.grd_List.TabIndex = 75;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle1);
            this.grd_List.DoubleClick += new System.EventHandler(this.grd_List_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Koli No";
            this.dataGridTextBoxColumn1.MappingName = "koliNo";
            this.dataGridTextBoxColumn1.Width = 100;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "OK";
            this.dataGridTextBoxColumn3.MappingName = "ok";
            this.dataGridTextBoxColumn3.Width = 20;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Belge No";
            this.dataGridTextBoxColumn2.MappingName = "VbelnVl";
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p1.Controls.Add(this.txtSevkiyatNo);
            this.p1.Controls.Add(this.lbl_SevkiyatNo);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 34);
            // 
            // txtSevkiyatNo
            // 
            this.txtSevkiyatNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtSevkiyatNo.Enabled = false;
            this.txtSevkiyatNo.Location = new System.Drawing.Point(131, 6);
            this.txtSevkiyatNo.Name = "txtSevkiyatNo";
            this.txtSevkiyatNo.Size = new System.Drawing.Size(178, 23);
            this.txtSevkiyatNo.TabIndex = 4;
            // 
            // lbl_SevkiyatNo
            // 
            this.lbl_SevkiyatNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_SevkiyatNo.Location = new System.Drawing.Point(3, 6);
            this.lbl_SevkiyatNo.Name = "lbl_SevkiyatNo";
            this.lbl_SevkiyatNo.Size = new System.Drawing.Size(122, 20);
            this.lbl_SevkiyatNo.Text = "Sevkiyat No:";
            // 
            // lbl_Bilgi
            // 
            this.lbl_Bilgi.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lbl_Bilgi.ForeColor = System.Drawing.Color.Red;
            this.lbl_Bilgi.Location = new System.Drawing.Point(3, 193);
            this.lbl_Bilgi.Name = "lbl_Bilgi";
            this.lbl_Bilgi.Size = new System.Drawing.Size(318, 13);
            this.lbl_Bilgi.Text = "Listeden çıkartmak istediğiniz koli no üzerine çift tıklayın";
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
            this.btn_Geri.TabIndex = 74;
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
            this.btn_Kaydet.TabIndex = 73;
            this.btn_Kaydet.Text = "   TESLİM ET";
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
            // frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.lbl_Bilgi);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.grd_List);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.p1);
            this.Name = "frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi";
            this.Text = "Mağaza Sevkiyatları Yükleme ve Mal Çıkışı";
            this.Load += new System.EventHandler(this.frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_Load);
            this.p2.ResumeLayout(false);
            this.p1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p2;
        private PictureButton btn_Ekle;
        private System.Windows.Forms.Label lbl_PaletKargoNo;
        private System.Windows.Forms.TextBox txtPaletKargoNo;
        private System.Windows.Forms.DataGrid grd_List;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private PictureButton btn_Geri;
        private PictureButton btn_Kaydet;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.TextBox txtSevkiyatNo;
        private System.Windows.Forms.Label lbl_SevkiyatNo;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.Label lbl_Bilgi;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}