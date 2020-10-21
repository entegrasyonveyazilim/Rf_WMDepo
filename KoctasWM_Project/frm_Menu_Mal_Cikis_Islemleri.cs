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
    public partial class frm_Menu_Mal_Cikis_Islemleri : Form
    {
        public frm_Menu_Mal_Cikis_Islemleri()
        {
            InitializeComponent();
        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Menu_Mal_Cikis_Islemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_ToplamaIslemleri_Click(object sender, EventArgs e)
        {
            frm_Menu_Mal_Cikis_Toplama_Islemleri frm = new frm_Menu_Mal_Cikis_Toplama_Islemleri();
            frm.ShowDialog();
        }

        private void btn_SevkiyatIslemleri_Click(object sender, EventArgs e)
        {
            frm_Menu_Mal_Cikis_Sevkiyat_Islemleri frm = new frm_Menu_Mal_Cikis_Sevkiyat_Islemleri();
            frm.ShowDialog();
        }
    }
}