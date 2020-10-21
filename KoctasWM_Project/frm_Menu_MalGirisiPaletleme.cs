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
    public partial class frm_Menu_MalGirisiPaletleme : Form
    {
        public frm_Menu_MalGirisiPaletleme()
        {
            InitializeComponent();
        }

        private void btn_Cikis_Click(object sender, EventArgs e)
        {

        }

        private void frm_Menu_MalGirisiPaletleme_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Paletleme_Click(object sender, EventArgs e)
        {
            frm_01_SA_Trans_Girisi_Paletleme frm = new frm_01_SA_Trans_Girisi_Paletleme();
            frm.ShowDialog();
        }

        private void btn_Adresleme_Click(object sender, EventArgs e)
        {
            frm_02_SA_Trans_Girisi_Adresleme frm = new frm_02_SA_Trans_Girisi_Adresleme();
            frm.ShowDialog();
        }

        private void btn_SetUrunuIslemleri_Click(object sender, EventArgs e)
        {
            frm_Menu_Set_Urun_Islemleri frm = new frm_Menu_Set_Urun_Islemleri();
            frm.ShowDialog();
        }

        private void btn_MalGirisi_Click(object sender, EventArgs e)
        {
            frm_31_Mal_Giris frm = new frm_31_Mal_Giris();
            frm.ShowDialog();
        }

        private void btn_MusteriIadeGirisi_Click(object sender, EventArgs e)
        {
            frm_32_v2_Musteri_Iade_Girisi frm = new frm_32_v2_Musteri_Iade_Girisi();
            frm.ShowDialog();
        }

     }
}