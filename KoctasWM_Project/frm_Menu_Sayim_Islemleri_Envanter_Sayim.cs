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
    public partial class frm_Menu_Sayim_Islemleri_Envanter_Sayim : Form
    {
        public frm_Menu_Sayim_Islemleri_Envanter_Sayim()
        {
            InitializeComponent();
        }

        private void frm_Menu_Sayim_Islemleri_Envanter_Sayim_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Maximized;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SistemOnerisiSayim_Click(object sender, EventArgs e)
        {
            frm_26_Sayim_Islemleri_Envanter_Sayimi_Sistem_Onerisi_Sayim frm = new frm_26_Sayim_Islemleri_Envanter_Sayimi_Sistem_Onerisi_Sayim();
            frm.ShowDialog();
        }

        private void btn_KullaniciSecimiSayim_Click(object sender, EventArgs e)
        {
            frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim frm = new frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim();
            frm.ShowDialog();
        }

       
    }
}