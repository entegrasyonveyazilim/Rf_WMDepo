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
    public partial class frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Kargo : Form
    {
        public frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Kargo()
        {
            InitializeComponent();
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Kargo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_Kargo_Alani_Paketleme_Click(object sender, EventArgs e)
        {
            frm_42_Kargo_Alani_Paketleme frm = new frm_42_Kargo_Alani_Paketleme();
            frm.ShowDialog();
        }

        private void btn_Kargo_Alanina_Transfer_Click(object sender, EventArgs e)
        {
            frm_43_Kargo_Alani_Transfer frm = new frm_43_Kargo_Alani_Transfer();
            frm.ShowDialog();
        }

        private void btn_Kargo_Checklist_Click(object sender, EventArgs e)
        {
            frm_44_Kargo_CheckList frm = new frm_44_Kargo_CheckList();
            frm.ShowDialog();
        }

        private void btn_Kargo_Etiketi_Yazdir_Click(object sender, EventArgs e)
        {
            frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi frm = new frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi();
            frm.ShowDialog();
        }

        private void btn_Geri_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}