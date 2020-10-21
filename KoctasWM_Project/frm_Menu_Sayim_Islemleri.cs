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
    public partial class frm_Menu_Sayim_Islemleri : Form
    {
        public frm_Menu_Sayim_Islemleri()
        {
            InitializeComponent();
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CanliOncesiSayim_Click(object sender, EventArgs e)
        {
            frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim frm = new frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim();
            frm.ShowDialog();
        }

        private void frm_Menu_Sayim_Islemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_EnvanterSayim_Click(object sender, EventArgs e)
        {
            frm_Menu_Sayim_Islemleri_Envanter_Sayim frm = new frm_Menu_Sayim_Islemleri_Envanter_Sayim();
            frm.ShowDialog();
        }

    }
}