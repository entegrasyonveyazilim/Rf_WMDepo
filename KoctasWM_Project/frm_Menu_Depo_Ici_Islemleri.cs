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
    public partial class frm_Menu_Depo_Ici_Islemleri : Form
    {
        public frm_Menu_Depo_Ici_Islemleri()
        {
            InitializeComponent();
        }

        private void btn_Cikis_Click(object sender, EventArgs e)
        {

        }

        private void btn_MalGirisiPaletleme_Click(object sender, EventArgs e)
        {

        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Menu_Depo_Ici_Islemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_PaletTransferi_Click(object sender, EventArgs e)
        {
            frm_03_Depo_Adresler_Arasi_Palet_Transferi frm = new frm_03_Depo_Adresler_Arasi_Palet_Transferi();
            frm.ShowDialog();
        }

        private void btn_MusteriIadeAlaniTransfer_Click(object sender, EventArgs e)
        {
            frm_04_Depo_Musteri_Iade_Alani_Transfer frm = new frm_04_Depo_Musteri_Iade_Alani_Transfer();
            frm.ShowDialog();
        }

        private void btn_PaletAktarim_Click(object sender, EventArgs e)
        {
            frm_05_Depo_Palet_Aktarim frm = new frm_05_Depo_Palet_Aktarim();
            frm.ShowDialog();
        }

        private void btn_AdresPaletSorgulama_Click(object sender, EventArgs e)
        {
            frm_Menu_Adres_Palet_Sorgulama frm = new frm_Menu_Adres_Palet_Sorgulama();
            frm.ShowDialog();
        }

        private void btn_IadeCikisi_Click(object sender, EventArgs e)
        {
            frm_12_15_Genel_Cikis_Islemleri_Formlari frm = new frm_12_15_Genel_Cikis_Islemleri_Formlari();
            frm.islemTuru = "iadeCikisi";
            frm.ShowDialog();
        }

        private void btn_ikmalNakilOnaylama_Click(object sender, EventArgs e)
        {
            frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama frm = new frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama();
            frm.ShowDialog();
        }

        private void btn_ToplamaIptalAlaniTransfer_Click(object sender, EventArgs e)
        {
            frm_37_Toplama_Iptal_Alanindan_Transferler frm = new frm_37_Toplama_Iptal_Alanindan_Transferler();
            frm.ShowDialog();
        }

        private void btn_DepoYerleriArasiTransfer_Click(object sender, EventArgs e)
        {
            frm_39_Depo_Yerleri_Arasi_Transfer frm = new frm_39_Depo_Yerleri_Arasi_Transfer();
            frm.ShowDialog();
        }




    }
}