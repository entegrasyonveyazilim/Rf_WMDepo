namespace KoctasWM_Project
{
    partial class frm_32_1_Sarfa_Gonderilecek_Urunler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_32_1_Sarfa_Gonderilecek_Urunler));
            this.btn_Kaydet = new KoctasWM_Project.PictureButton();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.grd_List = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.p3 = new System.Windows.Forms.Panel();
            this.btn_MiktarDegistir = new KoctasWM_Project.PictureButton();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lbl_KabulMiktar = new System.Windows.Forms.Label();
            this.p3.SuspendLayout();
            this.SuspendLayout();
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
            this.btn_Kaydet.TabIndex = 81;
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
            this.btn_Geri.TabIndex = 80;
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
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.White;
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(3, 3);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(312, 164);
            this.grd_List.TabIndex = 84;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle1);
            this.grd_List.DoubleClick += new System.EventHandler(this.grd_List_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Seç";
            this.dataGridTextBoxColumn7.MappingName = "Secim";
            this.dataGridTextBoxColumn7.Width = 30;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Satıcı";
            this.dataGridTextBoxColumn1.MappingName = "Lifnr";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Malzeme Tanımı";
            this.dataGridTextBoxColumn2.MappingName = "Maktx";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Malzeme No";
            this.dataGridTextBoxColumn3.MappingName = "Matnr";
            this.dataGridTextBoxColumn3.Width = 120;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Ölçü Birimi";
            this.dataGridTextBoxColumn4.MappingName = "Meins";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Miktar";
            this.dataGridTextBoxColumn5.MappingName = "Menge";
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Stok Niteliği";
            this.dataGridTextBoxColumn6.MappingName = "Sobkz";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.p3.Controls.Add(this.btn_MiktarDegistir);
            this.p3.Controls.Add(this.txtMiktar);
            this.p3.Controls.Add(this.lbl_KabulMiktar);
            this.p3.Location = new System.Drawing.Point(95, 173);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(220, 30);
            // 
            // btn_MiktarDegistir
            // 
            this.btn_MiktarDegistir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_MiktarDegistir.BackgroundImage = null;
            this.btn_MiktarDegistir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btn_MiktarDegistir.ForeColor = System.Drawing.Color.White;
            this.btn_MiktarDegistir.Location = new System.Drawing.Point(136, 4);
            this.btn_MiktarDegistir.Name = "btn_MiktarDegistir";
            this.btn_MiktarDegistir.Size = new System.Drawing.Size(81, 22);
            this.btn_MiktarDegistir.TabIndex = 82;
            this.btn_MiktarDegistir.Text = "Değiştir";
            this.btn_MiktarDegistir.Click += new System.EventHandler(this.btn_MiktarDegistir_Click);
            // 
            // txtMiktar
            // 
            this.txtMiktar.BackColor = System.Drawing.Color.White;
            this.txtMiktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMiktar.Location = new System.Drawing.Point(75, 5);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(55, 19);
            this.txtMiktar.TabIndex = 60;
            // 
            // lbl_KabulMiktar
            // 
            this.lbl_KabulMiktar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.lbl_KabulMiktar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_KabulMiktar.Location = new System.Drawing.Point(3, 8);
            this.lbl_KabulMiktar.Name = "lbl_KabulMiktar";
            this.lbl_KabulMiktar.Size = new System.Drawing.Size(58, 15);
            this.lbl_KabulMiktar.Text = "Miktar:";
            // 
            // frm_32_1_Sarfa_Gonderilecek_Urunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.p3);
            this.Controls.Add(this.grd_List);
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.btn_Geri);
            this.Name = "frm_32_1_Sarfa_Gonderilecek_Urunler";
            this.Text = "Sarf\'a Gönderilecek Ürünler";
            this.Load += new System.EventHandler(this.frm_32_1_Sarfa_Gonderilecek_Urunler_Load);
            this.p3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureButton btn_Kaydet;
        private PictureButton btn_Geri;
        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.DataGrid grd_List;
        private System.Windows.Forms.Panel p3;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lbl_KabulMiktar;
        private PictureButton btn_MiktarDegistir;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
    }
}