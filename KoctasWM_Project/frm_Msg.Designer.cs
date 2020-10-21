namespace KoctasWM_Project
{
    partial class frm_Msg
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
            this.btn_Tamam = new System.Windows.Forms.Button();
            this.grd_Hata = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SuspendLayout();
            // 
            // btn_Tamam
            // 
            this.btn_Tamam.Location = new System.Drawing.Point(102, 139);
            this.btn_Tamam.Name = "btn_Tamam";
            this.btn_Tamam.Size = new System.Drawing.Size(112, 33);
            this.btn_Tamam.TabIndex = 0;
            this.btn_Tamam.Text = "TAMAM";
            this.btn_Tamam.Click += new System.EventHandler(this.btn_Tamam_Click);
            // 
            // grd_Hata
            // 
            this.grd_Hata.BackColor = System.Drawing.Color.White;
            this.grd_Hata.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(228)))));
            this.grd_Hata.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(188)))), ((int)(((byte)(138)))));
            this.grd_Hata.Location = new System.Drawing.Point(3, 3);
            this.grd_Hata.Name = "grd_Hata";
            this.grd_Hata.Size = new System.Drawing.Size(312, 130);
            this.grd_Hata.TabIndex = 1;
            this.grd_Hata.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Mesaj Tipi";
            this.dataGridTextBoxColumn1.MappingName = "msgTip";
            this.dataGridTextBoxColumn1.Width = 62;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Mesaj";
            this.dataGridTextBoxColumn2.MappingName = "msg";
            this.dataGridTextBoxColumn2.Width = 250;
            // 
            // frm_Msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 175);
            this.ControlBox = false;
            this.Controls.Add(this.grd_Hata);
            this.Controls.Add(this.btn_Tamam);
            this.Name = "frm_Msg";
            this.Text = "MESAJ DETAYLARI";
            this.Load += new System.EventHandler(this.frm_Msg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Tamam;
        private System.Windows.Forms.DataGrid grd_Hata;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    }
}