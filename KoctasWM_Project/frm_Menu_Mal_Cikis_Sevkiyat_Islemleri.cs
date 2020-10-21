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
    public partial class frm_Menu_Mal_Cikis_Sevkiyat_Islemleri : Form
    {
        public frm_Menu_Mal_Cikis_Sevkiyat_Islemleri()
        {
            InitializeComponent();
        }

        private void frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btn_MusSevAmb_AmbIptali_Click(object sender, EventArgs e)
        {
            frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali frm = new frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali();
            frm.ShowDialog();
        }

        /*
        private void btn_MusSevKoli_KargoTes_Iptal_Click(object sender, EventArgs e)
        {
            frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi frm = new frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi();
            frm.ShowDialog();
        }
        */

        private void btn_MagSevPaletleme_Iptal_Click(object sender, EventArgs e)
        {
            frm_23_Dagitim_Mag_Sev_Paletleme_Iptali frm = new frm_23_Dagitim_Mag_Sev_Paletleme_Iptali();
            frm.ShowDialog();
        }

        private void btn_MagSevYuklemeMalCikisi_Click(object sender, EventArgs e)
        {
            frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi frm = new frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi();
            frm.ShowDialog();
        }

        private void btn_MalCikisi_Click(object sender, EventArgs e)
        {
            frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis frm = new frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis();
            frm.ShowDialog();
        }

        private void btn_KargoSurecleri_Click(object sender, EventArgs e)
        {
            frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Kargo frm = new frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Kargo();
            frm.ShowDialog();
        }

        private void checkListBttn_Click(object sender, EventArgs e)
        {
            KoliNoPopUp form= new KoliNoPopUp();
            form.ShowDialog();
        }
        /*
        private void checkListBttn_Click(object sender, EventArgs e)
        {
            KoliPopUp frm = new KoliPopUp();
            frm.ShowDialog();
        }*/

    }
}