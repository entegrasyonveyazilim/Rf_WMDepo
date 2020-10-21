namespace KoctasWM_Project
{
    partial class frm_07_Depo_Urun_Sorgulama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_07_Depo_Urun_Sorgulama));
            this.p1 = new System.Windows.Forms.Panel();
            this.lbl_MalzemeNo = new System.Windows.Forms.Label();
            this.txtMalzemeNo = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMalzemeNo2 = new System.Windows.Forms.TextBox();
            this.lbl_MalzemeNo2 = new System.Windows.Forms.Label();
            this.txtBlokeStokOlcuBirimi = new System.Windows.Forms.TextBox();
            this.txtBlokeStok = new System.Windows.Forms.TextBox();
            this.txtKullanilabilirStokOlcuBirimi = new System.Windows.Forms.TextBox();
            this.txtKullanilabilirStok = new System.Windows.Forms.TextBox();
            this.txtToplamStokOlcuBirimi = new System.Windows.Forms.TextBox();
            this.txtToplamStok = new System.Windows.Forms.TextBox();
            this.lbl_ToplamStok = new System.Windows.Forms.Label();
            this.txtMalGrubuTanimi = new System.Windows.Forms.TextBox();
            this.lbl_MalGrubuTanimi = new System.Windows.Forms.Label();
            this.txtSaticiKoduAdi = new System.Windows.Forms.TextBox();
            this.lbl_SatisiKoduAdi = new System.Windows.Forms.Label();
            this.txtMalzemeTanimi = new System.Windows.Forms.TextBox();
            this.lbl_MalzemeTanimi = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btn_Geri = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.p1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.White;
            this.p1.Controls.Add(this.lbl_MalzemeNo);
            this.p1.Controls.Add(this.txtMalzemeNo);
            this.p1.Location = new System.Drawing.Point(3, 3);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(312, 33);
            // 
            // lbl_MalzemeNo
            // 
            this.lbl_MalzemeNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeNo.Location = new System.Drawing.Point(3, 6);
            this.lbl_MalzemeNo.Name = "lbl_MalzemeNo";
            this.lbl_MalzemeNo.Size = new System.Drawing.Size(122, 20);
            this.lbl_MalzemeNo.Text = "Malzeme No:";
            // 
            // txtMalzemeNo
            // 
            this.txtMalzemeNo.BackColor = System.Drawing.Color.White;
            this.txtMalzemeNo.Location = new System.Drawing.Point(131, 3);
            this.txtMalzemeNo.Name = "txtMalzemeNo";
            this.txtMalzemeNo.Size = new System.Drawing.Size(178, 23);
            this.txtMalzemeNo.TabIndex = 3;
            this.txtMalzemeNo.GotFocus += new System.EventHandler(this.txtMalzemeNo_GotFocus);
            this.txtMalzemeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMalzemeNo_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(309, 164);
            this.tabControl1.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.txtMalzemeNo2);
            this.tabPage1.Controls.Add(this.lbl_MalzemeNo2);
            this.tabPage1.Controls.Add(this.txtBlokeStokOlcuBirimi);
            this.tabPage1.Controls.Add(this.txtBlokeStok);
            this.tabPage1.Controls.Add(this.txtKullanilabilirStokOlcuBirimi);
            this.tabPage1.Controls.Add(this.txtKullanilabilirStok);
            this.tabPage1.Controls.Add(this.txtToplamStokOlcuBirimi);
            this.tabPage1.Controls.Add(this.txtToplamStok);
            this.tabPage1.Controls.Add(this.lbl_ToplamStok);
            this.tabPage1.Controls.Add(this.txtMalGrubuTanimi);
            this.tabPage1.Controls.Add(this.lbl_MalGrubuTanimi);
            this.tabPage1.Controls.Add(this.txtSaticiKoduAdi);
            this.tabPage1.Controls.Add(this.lbl_SatisiKoduAdi);
            this.tabPage1.Controls.Add(this.txtMalzemeTanimi);
            this.tabPage1.Controls.Add(this.lbl_MalzemeTanimi);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(301, 135);
            this.tabPage1.Text = "Ana Veri  ";
            // 
            // txtMalzemeNo2
            // 
            this.txtMalzemeNo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtMalzemeNo2.Enabled = false;
            this.txtMalzemeNo2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMalzemeNo2.Location = new System.Drawing.Point(120, 2);
            this.txtMalzemeNo2.Name = "txtMalzemeNo2";
            this.txtMalzemeNo2.Size = new System.Drawing.Size(178, 19);
            this.txtMalzemeNo2.TabIndex = 86;
            // 
            // lbl_MalzemeNo2
            // 
            this.lbl_MalzemeNo2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeNo2.Location = new System.Drawing.Point(0, 4);
            this.lbl_MalzemeNo2.Name = "lbl_MalzemeNo2";
            this.lbl_MalzemeNo2.Size = new System.Drawing.Size(114, 17);
            this.lbl_MalzemeNo2.Text = "Malzeme No:";
            // 
            // txtBlokeStokOlcuBirimi
            // 
            this.txtBlokeStokOlcuBirimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtBlokeStokOlcuBirimi.Enabled = false;
            this.txtBlokeStokOlcuBirimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBlokeStokOlcuBirimi.Location = new System.Drawing.Point(193, 109);
            this.txtBlokeStokOlcuBirimi.Name = "txtBlokeStokOlcuBirimi";
            this.txtBlokeStokOlcuBirimi.Size = new System.Drawing.Size(43, 19);
            this.txtBlokeStokOlcuBirimi.TabIndex = 76;
            // 
            // txtBlokeStok
            // 
            this.txtBlokeStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtBlokeStok.Enabled = false;
            this.txtBlokeStok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBlokeStok.Location = new System.Drawing.Point(243, 87);
            this.txtBlokeStok.Name = "txtBlokeStok";
            this.txtBlokeStok.Size = new System.Drawing.Size(55, 19);
            this.txtBlokeStok.TabIndex = 75;
            // 
            // txtKullanilabilirStokOlcuBirimi
            // 
            this.txtKullanilabilirStokOlcuBirimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtKullanilabilirStokOlcuBirimi.Enabled = false;
            this.txtKullanilabilirStokOlcuBirimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtKullanilabilirStokOlcuBirimi.Location = new System.Drawing.Point(132, 109);
            this.txtKullanilabilirStokOlcuBirimi.Name = "txtKullanilabilirStokOlcuBirimi";
            this.txtKullanilabilirStokOlcuBirimi.Size = new System.Drawing.Size(43, 19);
            this.txtKullanilabilirStokOlcuBirimi.TabIndex = 72;
            this.txtKullanilabilirStokOlcuBirimi.TextChanged += new System.EventHandler(this.txtKullanilabilirStokOlcuBirimi_TextChanged);
            // 
            // txtKullanilabilirStok
            // 
            this.txtKullanilabilirStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtKullanilabilirStok.Enabled = false;
            this.txtKullanilabilirStok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtKullanilabilirStok.Location = new System.Drawing.Point(181, 87);
            this.txtKullanilabilirStok.Name = "txtKullanilabilirStok";
            this.txtKullanilabilirStok.Size = new System.Drawing.Size(55, 19);
            this.txtKullanilabilirStok.TabIndex = 71;
            // 
            // txtToplamStokOlcuBirimi
            // 
            this.txtToplamStokOlcuBirimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtToplamStokOlcuBirimi.Enabled = false;
            this.txtToplamStokOlcuBirimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtToplamStokOlcuBirimi.Location = new System.Drawing.Point(255, 109);
            this.txtToplamStokOlcuBirimi.Name = "txtToplamStokOlcuBirimi";
            this.txtToplamStokOlcuBirimi.Size = new System.Drawing.Size(43, 19);
            this.txtToplamStokOlcuBirimi.TabIndex = 69;
            // 
            // txtToplamStok
            // 
            this.txtToplamStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtToplamStok.Enabled = false;
            this.txtToplamStok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtToplamStok.Location = new System.Drawing.Point(120, 87);
            this.txtToplamStok.Name = "txtToplamStok";
            this.txtToplamStok.Size = new System.Drawing.Size(55, 19);
            this.txtToplamStok.TabIndex = 67;
            // 
            // lbl_ToplamStok
            // 
            this.lbl_ToplamStok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_ToplamStok.Location = new System.Drawing.Point(0, 89);
            this.lbl_ToplamStok.Name = "lbl_ToplamStok";
            this.lbl_ToplamStok.Size = new System.Drawing.Size(121, 17);
            this.lbl_ToplamStok.Text = "Top./Kull./Blok:";
            // 
            // txtMalGrubuTanimi
            // 
            this.txtMalGrubuTanimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtMalGrubuTanimi.Enabled = false;
            this.txtMalGrubuTanimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMalGrubuTanimi.Location = new System.Drawing.Point(120, 65);
            this.txtMalGrubuTanimi.Name = "txtMalGrubuTanimi";
            this.txtMalGrubuTanimi.Size = new System.Drawing.Size(178, 19);
            this.txtMalGrubuTanimi.TabIndex = 64;
            // 
            // lbl_MalGrubuTanimi
            // 
            this.lbl_MalGrubuTanimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_MalGrubuTanimi.Location = new System.Drawing.Point(0, 67);
            this.lbl_MalGrubuTanimi.Name = "lbl_MalGrubuTanimi";
            this.lbl_MalGrubuTanimi.Size = new System.Drawing.Size(114, 17);
            this.lbl_MalGrubuTanimi.Text = "Mal Grubu/Tanımı:";
            // 
            // txtSaticiKoduAdi
            // 
            this.txtSaticiKoduAdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtSaticiKoduAdi.Enabled = false;
            this.txtSaticiKoduAdi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSaticiKoduAdi.Location = new System.Drawing.Point(120, 44);
            this.txtSaticiKoduAdi.Name = "txtSaticiKoduAdi";
            this.txtSaticiKoduAdi.Size = new System.Drawing.Size(178, 19);
            this.txtSaticiKoduAdi.TabIndex = 61;
            // 
            // lbl_SatisiKoduAdi
            // 
            this.lbl_SatisiKoduAdi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_SatisiKoduAdi.Location = new System.Drawing.Point(0, 46);
            this.lbl_SatisiKoduAdi.Name = "lbl_SatisiKoduAdi";
            this.lbl_SatisiKoduAdi.Size = new System.Drawing.Size(114, 17);
            this.lbl_SatisiKoduAdi.Text = "Satıcı Kodu/Adı:";
            // 
            // txtMalzemeTanimi
            // 
            this.txtMalzemeTanimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.txtMalzemeTanimi.Enabled = false;
            this.txtMalzemeTanimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMalzemeTanimi.Location = new System.Drawing.Point(120, 23);
            this.txtMalzemeTanimi.Name = "txtMalzemeTanimi";
            this.txtMalzemeTanimi.Size = new System.Drawing.Size(178, 19);
            this.txtMalzemeTanimi.TabIndex = 58;
            // 
            // lbl_MalzemeTanimi
            // 
            this.lbl_MalzemeTanimi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_MalzemeTanimi.Location = new System.Drawing.Point(0, 25);
            this.lbl_MalzemeTanimi.Name = "lbl_MalzemeTanimi";
            this.lbl_MalzemeTanimi.Size = new System.Drawing.Size(114, 17);
            this.lbl_MalzemeTanimi.Text = "Malzeme Tanımı:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.lbl_Bilgi);
            this.tabPage2.Controls.Add(this.grd_List);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(301, 135);
            this.tabPage2.Text = "Adres Stokları  ";
            // 
            // lbl_Bilgi
            // 
            this.lbl_Bilgi.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lbl_Bilgi.ForeColor = System.Drawing.Color.Red;
            this.lbl_Bilgi.Location = new System.Drawing.Point(3, 123);
            this.lbl_Bilgi.Name = "lbl_Bilgi";
            this.lbl_Bilgi.Size = new System.Drawing.Size(298, 18);
            this.lbl_Bilgi.Text = "Detayını görmek istediğiniz kaydın üzerinde çift tıklayın";
            // 
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(0, 3);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(301, 118);
            this.grd_List.TabIndex = 50;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle1);
            this.grd_List.CurrentCellChanged += new System.EventHandler(this.grd_List_DoubleClick);
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
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn10);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Adres";
            this.dataGridTextBoxColumn1.MappingName = "adres";
            this.dataGridTextBoxColumn1.Width = 155;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Miktar";
            this.dataGridTextBoxColumn2.MappingName = "toplamMiktar";
            this.dataGridTextBoxColumn2.Width = 100;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Malzeme No";
            this.dataGridTextBoxColumn3.MappingName = "malzemeNo";
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Malzeme Tanım";
            this.dataGridTextBoxColumn4.MappingName = "malzemeTanim";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Toplanacak Miktar";
            this.dataGridTextBoxColumn5.MappingName = "toplanacakMiktar";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Ölçü Birimi";
            this.dataGridTextBoxColumn6.MappingName = "olcuBirimi";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Stok Tipi";
            this.dataGridTextBoxColumn7.MappingName = "stokTipi";
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Palet No";
            this.dataGridTextBoxColumn8.MappingName = "paletNo";
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
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Depo Tipi";
            this.dataGridTextBoxColumn10.MappingName = "depoTipi";
            this.dataGridTextBoxColumn10.Width = 0;
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
            this.btn_Geri.TabIndex = 51;
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
            // frm_07_Depo_Urun_Sorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Geri);
            this.Controls.Add(this.p1);
            this.Name = "frm_07_Depo_Urun_Sorgulama";
            this.Text = "Ürün Sorgulama";
            this.Load += new System.EventHandler(this.frm_07_Depo_Urun_Sorgulama_Load);
            this.p1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label lbl_MalzemeNo;
        private System.Windows.Forms.TextBox txtMalzemeNo;
        private PictureButton btn_Geri;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbl_Bilgi;
        private System.Windows.Forms.DataGrid grd_List;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.TextBox txtMalzemeTanimi;
        private System.Windows.Forms.Label lbl_MalzemeTanimi;
        private System.Windows.Forms.TextBox txtMalGrubuTanimi;
        private System.Windows.Forms.Label lbl_MalGrubuTanimi;
        private System.Windows.Forms.TextBox txtSaticiKoduAdi;
        private System.Windows.Forms.Label lbl_SatisiKoduAdi;
        private System.Windows.Forms.TextBox txtToplamStok;
        private System.Windows.Forms.Label lbl_ToplamStok;
        private System.Windows.Forms.TextBox txtBlokeStokOlcuBirimi;
        private System.Windows.Forms.TextBox txtBlokeStok;
        private System.Windows.Forms.TextBox txtKullanilabilirStokOlcuBirimi;
        private System.Windows.Forms.TextBox txtKullanilabilirStok;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.TextBox txtToplamStokOlcuBirimi;
        private System.Windows.Forms.TextBox txtMalzemeNo2;
        private System.Windows.Forms.Label lbl_MalzemeNo2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}