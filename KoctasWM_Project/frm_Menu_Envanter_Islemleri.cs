using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoctasWM_Project
{
    public partial class frm_Menu_Envanter_Islemleri : Form
    {
        public frm_Menu_Envanter_Islemleri()
        {
            InitializeComponent();
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Menu_Envanter_Islemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_FarkGirisCikislari_Click(object sender, EventArgs e)
        {
            frm_08_Depo_Fark_Giris_Cikislari frm = new frm_08_Depo_Fark_Giris_Cikislari();
            frm.ShowDialog();
        }

        private void btn_StokNiteligiDegisiklik_Click(object sender, EventArgs e)
        {
            frm_06_Depo_Stok_Niteligi_Degisiklik frm = new frm_06_Depo_Stok_Niteligi_Degisiklik();
            frm.ShowDialog();
        }

        private void btn_HurdaCikisi_Click(object sender, EventArgs e)
        {
            frm_12_15_Genel_Cikis_Islemleri_Formlari frm = new frm_12_15_Genel_Cikis_Islemleri_Formlari();
            frm.islemTuru = "hurdaCikisi";
            frm.ShowDialog();
        }

        private void btn_MasrafYerineCikis_Click(object sender, EventArgs e)
        {
            frm_14_Genel_Cikis_Isl_Masraf_Yerine_Cikis frm = new frm_14_Genel_Cikis_Isl_Masraf_Yerine_Cikis();
            frm.ShowDialog();
        }

        private void btn_SigortaAraHesabinaCikis_Click(object sender, EventArgs e)
        {
            frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis frm = new frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis();
            frm.ShowDialog();
        }
    }
}