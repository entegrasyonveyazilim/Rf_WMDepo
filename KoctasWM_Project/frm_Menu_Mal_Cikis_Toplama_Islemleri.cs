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
    public partial class frm_Menu_Mal_Cikis_Toplama_Islemleri : Form
    {
        public frm_Menu_Mal_Cikis_Toplama_Islemleri()
        {
            InitializeComponent();
        }

        private void frm_Menu_Mal_Cikis_Toplama_Islemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_KuyrukSecimi_Click(object sender, EventArgs e)
        {
            frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi frm = new frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi();
            frm._kuyrukTipi = "W";
            frm.ShowDialog();
        }

        private void btn_NakilOnaylama_Click(object sender, EventArgs e)
        {
            frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi frm = new frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi();
            frm._kuyrukTipi = "M";
            frm.ShowDialog();
            
            //frm_17_Toplama_Nakil_Sip_Onaylama frm = new frm_17_Toplama_Nakil_Sip_Onaylama();
            //frm.ShowDialog();
        }

        private void btn_ManuelNakilOnaylama_Click(object sender, EventArgs e)
        {
            frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris frm = new frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris();
            frm.ShowDialog();
        }

        private void btn_TopTesDagAyr_Iptal_Islemleri_Click(object sender, EventArgs e)
        {
            frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris frm = new frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris();
            frm.ShowDialog();
        }

        private void btn_TopTesDagAyr_Iptal_MAGAZA_Islemleri_Click(object sender, EventArgs e)
        {
            frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz frm = new frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz();
            frm.ShowDialog();
        }



    }
}