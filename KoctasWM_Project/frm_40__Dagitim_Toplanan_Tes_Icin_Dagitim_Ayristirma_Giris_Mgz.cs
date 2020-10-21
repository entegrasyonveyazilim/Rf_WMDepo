using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace KoctasWM_Project
{
    public partial class frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz).Name);
        public frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz()
        {
            InitializeComponent();
        }

        private void frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'b');
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_DetayGetir_Click(new object(), new EventArgs());
            }
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_DetayGetir_Click(object sender, EventArgs e)
        {
            logger.info("frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz_btn_DetayGetir_Click begin");
            if (txtMalzemeNo.Text.Trim() == "")
            {
                return;
            }

            //Webservice sorgulanıyor
            Cursor.Current = Cursors.WaitCursor;
            try
            {
              
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsTeslimatDagitim chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsTeslimatDagitim();
                WS_Kontrol.ZKtWmWsTeslimatDagitimResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsTeslimatDagitimResponse();
                WS_Kontrol.ZktWmStTeslimat tes = new KoctasWM_Project.WS_Kontrol.ZktWmStTeslimat();

                chk.IvEan = txtMalzemeNo.Text.ToString().Trim().ToUpper();
                chk.IvType = "M";
                
                

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsTeslimatDagitim(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    tes = resp.EsTeslimat;

                    Cursor.Current = Cursors.Default;
                    frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz frm = new frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz();
                    frm._tes = tes;
                    frm._dagitimTuru = "M";
                    frm.ShowDialog();
                    txtMalzemeNo.Text = "";
                    Utility.selectText(txtMalzemeNo);

                    //this.Close();
                    /*
                    if (frm.DialogResult == DialogResult.Abort)
                    {
                        
                    }*/
        
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    Utility.selectText(txtMalzemeNo);
                }
          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                Utility.selectText(txtMalzemeNo);
                logger.error("frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz_btn_DetayGetir_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_40__Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Giris_Mgz_btn_DetayGetir_Click end");
        }

        
    }
}