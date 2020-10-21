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
    public partial class frm_Menu_Set_Urun_Islemleri : Form
    {
        public frm_Menu_Set_Urun_Islemleri()
        {
            InitializeComponent();
        }

        private void frm_Menu_Set_Urun_Islemleri_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btn_SetUrunPaletleme_Click(object sender, EventArgs e)
        {
            frm_09_Depo_Set_Urunu_Paletleme frm = new frm_09_Depo_Set_Urunu_Paletleme();
            frm.ShowDialog();
        }

        private void btn_SetAlaninaTasima_Click(object sender, EventArgs e)
        {
            frm_09_Depo_Set_Alanina_Tasima frm = new frm_09_Depo_Set_Alanina_Tasima();
            frm.ShowDialog();
        }
    }
}