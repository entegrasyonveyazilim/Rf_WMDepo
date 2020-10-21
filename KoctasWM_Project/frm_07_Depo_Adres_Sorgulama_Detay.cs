using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace KoctasWM_Project
{
    public partial class frm_07_Depo_Adres_Sorgulama_Detay : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_07_Depo_Adres_Sorgulama_Detay).Name);
        public frm_07_Depo_Adres_Sorgulama_Detay()
        {
            InitializeComponent();
        }

        public string _malzemeNo;
        public string _malzemeTanim;
        public string _toplamMiktar;
        public string _olcuBirimi;
        public string _adres;
        public string _stokTipi;
        public string _toplanacakMiktar;
        public string _paletNo;
        public string _ean;

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_07_Depo_Adres_Sorgulama_Detay_Load(object sender, EventArgs e)
        {
            logger.info("frm_07_Depo_Adres_Sorgulama_Detay_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);


            txtMalzemeNo.Text = Convert.ToInt64(_malzemeNo).ToString();
            if (_paletNo != "")
            {
                txtPaletNo.Text = Convert.ToInt64(_paletNo).ToString();
            }
            else
            {
                txtPaletNo.Text = _paletNo;
            }
            
            txtMalzemeTanimi.Text = _malzemeTanim;
            txtAdres.Text = _adres;
            txtToplamMiktar.Text = _toplamMiktar;
            txtToplanacakMiktar.Text = _toplanacakMiktar;
            txtOlcuBirimi.Text = _olcuBirimi;
            txtStokTipi.Text = _stokTipi;
            txtEan.Text = _ean;
            logger.info("frm_07_Depo_Adres_Sorgulama_Detay_Load end");
        }
    }
}