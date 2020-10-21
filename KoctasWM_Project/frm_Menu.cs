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
    public partial class frm_Menu : Form
    {
        public frm_Menu()
        {
            InitializeComponent();
        }


        private void frm_Menu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

        }

        private void btn_MalGirisiPaletleme_Click(object sender, EventArgs e)
        {
            frm_Menu_MalGirisiPaletleme frm = new frm_Menu_MalGirisiPaletleme();
            frm.ShowDialog();
        }

        private void btn_DepoIciIslemler_Click(object sender, EventArgs e)
        {
            frm_Menu_Depo_Ici_Islemleri frm = new frm_Menu_Depo_Ici_Islemleri();
            frm.ShowDialog();
        }

        private void btn_MalCikisIslemleri_Click(object sender, EventArgs e)
        {
            frm_Menu_Mal_Cikis_Islemleri frm = new frm_Menu_Mal_Cikis_Islemleri();
            frm.ShowDialog();
        }

        private void btn_sayimIslemleri_Click(object sender, EventArgs e)
        {
            frm_Menu_Sayim_Islemleri frm = new frm_Menu_Sayim_Islemleri();
            frm.ShowDialog();
        }

        private void frm_Menu_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                e.Cancel = true;
            }
                
        }

        private void btn_EnvanterIslemleri_Click(object sender, EventArgs e)
        {
            frm_Menu_Envanter_Islemleri frm = new frm_Menu_Envanter_Islemleri();
            frm.ShowDialog();
        }



    }
}