namespace KoctasWM_Project
{
    partial class frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay));
            this.grd_List = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btn_Iptal = new KoctasWM_Project.PictureButton();
            this.btn_Degistir = new KoctasWM_Project.PictureButton();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grd_List
            // 
            this.grd_List.BackColor = System.Drawing.Color.White;
            this.grd_List.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_List.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_List.Location = new System.Drawing.Point(3, 3);
            this.grd_List.Name = "grd_List";
            this.grd_List.Size = new System.Drawing.Size(312, 200);
            this.grd_List.TabIndex = 0;
            this.grd_List.TableStyles.Add(this.dataGridTableStyle1);
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
            this.dataGridTextBoxColumn1.HeaderText = "Adres";
            this.dataGridTextBoxColumn1.MappingName = "Lgpla";
            this.dataGridTextBoxColumn1.Width = 100;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Palet No";
            this.dataGridTextBoxColumn2.MappingName = "Lenum";
            this.dataGridTextBoxColumn2.Width = 80;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Malzeme No";
            this.dataGridTextBoxColumn3.MappingName = "Matnr";
            this.dataGridTextBoxColumn3.Width = 70;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Miktar";
            this.dataGridTextBoxColumn4.MappingName = "Menge";
            // 
            // btn_Iptal
            // 
            this.btn_Iptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Iptal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Iptal.BackgroundImage")));
            this.btn_Iptal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Iptal.ForeColor = System.Drawing.Color.White;
            this.btn_Iptal.Location = new System.Drawing.Point(3, 209);
            this.btn_Iptal.Name = "btn_Iptal";
            this.btn_Iptal.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Iptal.PressedImage")));
            this.btn_Iptal.Size = new System.Drawing.Size(150, 47);
            this.btn_Iptal.TabIndex = 75;
            this.btn_Iptal.Text = "İPTAL";
            this.btn_Iptal.Click += new System.EventHandler(this.btn_Iptal_Click);
            // 
            // btn_Degistir
            // 
            this.btn_Degistir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(117)))), ((int)(((byte)(30)))));
            this.btn_Degistir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Degistir.BackgroundImage")));
            this.btn_Degistir.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Degistir.ForeColor = System.Drawing.Color.White;
            this.btn_Degistir.Location = new System.Drawing.Point(165, 209);
            this.btn_Degistir.Name = "btn_Degistir";
            this.btn_Degistir.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_Degistir.PressedImage")));
            this.btn_Degistir.Size = new System.Drawing.Size(150, 47);
            this.btn_Degistir.TabIndex = 74;
            this.btn_Degistir.Text = "   DEĞİŞTİR";
            this.btn_Degistir.Click += new System.EventHandler(this.btn_Degistir_Click);
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
            // frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_LoginInfo);
            this.Controls.Add(this.btn_Iptal);
            this.Controls.Add(this.btn_Degistir);
            this.Controls.Add(this.grd_List);
            this.Name = "frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay";
            this.Text = "Önceki Sayım";
            this.Load += new System.EventHandler(this.frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid grd_List;
        private PictureButton btn_Iptal;
        private PictureButton btn_Degistir;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.Label lbl_LoginInfo;
    }
}