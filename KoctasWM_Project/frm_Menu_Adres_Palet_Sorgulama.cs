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
    public partial class frm_Menu_Adres_Palet_Sorgulama : Form
    {
        public frm_Menu_Adres_Palet_Sorgulama()
        {
            InitializeComponent();
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Adresleme_Click(object sender, EventArgs e)
        {

        }

        private void btn_Paletleme_Click(object sender, EventArgs e)
        {

        }

        private void frm_Menu_Adres_Palet_Sorgulama_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_PaletSorgulama_Click(object sender, EventArgs e)
        {
            frm_07_Depo_Palet_Sorgulama frm = new frm_07_Depo_Palet_Sorgulama();
            frm.ShowDialog();
        }

        private void btn_AdresSorgulama_Click(object sender, EventArgs e)
        {
            frm_07_Depo_Adres_Sorgulama frm = new frm_07_Depo_Adres_Sorgulama();
            frm.ShowDialog();
        }

        private void btn_UrunSorgulama_Click(object sender, EventArgs e)
        {
            frm_07_Depo_Urun_Sorgulama frm = new frm_07_Depo_Urun_Sorgulama();
            frm.ShowDialog();
        }

    }
}