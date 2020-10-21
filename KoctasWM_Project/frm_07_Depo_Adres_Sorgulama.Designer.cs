namespace KoctasWM_Project
{
    partial class frm_07_Depo_Adres_Sorgulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_07_Depo_Adres_Sorgulama));
            this.lbl_AdresNo = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.Panel();
            this.txtAdresNo = new System.Windows.Forms.TextBox();
            this.lbl_Bilgi = new System.Windows.Forms.Label();
            this.grd_List = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_AdresNo
            // 
            this.lbl_AdresNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_AdresNo.Location = new System.Drawing.Point(3, 6);
            this.lbl_AdresNo.Name = "lbl_AdresNo";
            this.lbl_AdresNo.Size = new System.Drawing.Size(122, 20);
            this.lbl_AdresNo.Text = "Adres No:";
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.lbl_AdresNo);
            this.p1.Controls.Add(this.txtAdresNo);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 33);
            // 
            // txtAdresNo
            // 
            this.txtAdresNo.BackColor = System.Drawing.Color.White;
            this.txtAdresNo.Location = new System.Drawing.Point(131, 3);
            this.txtAdresNo.Name = "txtAdresNo";
            this.txtAdresNo.Size = new System.Drawing.Size(178, 23);
            this.txtAdresNo.TabIndex = 3;
            this.txtAdresNo.GotFocus += new System.EventHandler(this.txtAdresNo_GotFocus);
            this.txtAdresNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdresNo_KeyDown);
            // 
            // lbl_Bilgi
            // 
            this.lbl_Bilgi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_Bilgi.ForeColor = System.Drawing.Color.Red;
            this.lbl_Bilgi.Location = new System.Drawing.Point(0, 188);
            this.lbl_Bilgi.Name = "lbl_Bilgi";
            this.lbl_Bilgi.Size = new System.Drawing.Size(318, 25);
            this.lbl_Bilgi.Text = "Detayını görmek istediğiniz kaydın üzerinde çift tıklayın";
            // 
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.White;
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(3, 40);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(312, 143);
            this.grd_List.TabIndex = 50;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle1);
            this.grd_List.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn8);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn9);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Malzeme No";
            this.dataGridTextBoxColumn1.MappingName = "malzemeNo";
            this.dataGridTextBoxColumn1.Width = 100;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Tanım";
            this.dataGridTextBoxColumn2.MappingName = "malzemeTanim";
            this.dataGridTextBoxColumn2.Width = 100;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Toplam Miktar";
            this.dataGridTextBoxColumn3.MappingName = "toplamMiktar";
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Palet No";
            this.dataGridTextBoxColumn4.MappingName = "paletNo";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Ölçü Birimi";
            this.dataGridTextBoxColumn5.MappingName = "olcuBirimi";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Stok Tipi";
            this.dataGridTextBoxColumn6.MappingName = "stokTipi";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Toplanacak Miktar";
            this.dataGridTextBoxColumn7.MappingName = "toplanacakMiktar";
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Adres";
            this.dataGridTextBoxColumn8.MappingName = "adres";
            this.dataGridTextBoxColumn8.Width = 0;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Barkod";
            this.dataGridTextBoxColumn9.MappingName = "ean";
            this.dataGridTextBoxColumn9.Width = 0;
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
            this.btn_Geri.TabIndex = 48;
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
            // frm_07_Depo_Adres_Sorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.grd_List);
            this.Controls.Add(this.lbl_Bilgi);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.p1);
            this.Name = "frm_07_Depo_Adres_Sorgulama";
            this.Text = "Adres Sorgulama";
            this.Load += new System.EventHandler(this.frm_07_Depo_Adres_Sorgulama_Load);
            this.p1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_AdresNo;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.TextBox txtAdresNo;
        private PictureButton btn_Geri;
        private System.Windows.Forms.Label lbl_Bilgi;
        private System.Windows.Forms.DataGrid grd_List;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.Label lbl_LoginInfo;

    }
}