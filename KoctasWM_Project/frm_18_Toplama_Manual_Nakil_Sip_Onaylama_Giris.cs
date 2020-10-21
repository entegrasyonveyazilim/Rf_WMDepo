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
    public partial class frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris).Name);
        public frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris()
        {
            InitializeComponent();
        }

        private void frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris_Load(object sender, EventArgs e)
        {
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
            txtNakilSiparisNo.Focus();
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris_Load end");
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_DetayGetir_Click(object sender, EventArgs e)
        {
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris_btn_DetayGetir_Click begin");
            if (txtNakilSiparisNo.Text.Trim() == "")
            {
                return;
            }

            //Webservice sorgulanıyor
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsManToplamaNaksip chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsManToplamaNaksip();
                WS_Kontrol.ZKtWmWsManToplamaNaksipResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsManToplamaNaksipResponse();
                WS_Kontrol.ZktWmStNaksip sip = new KoctasWM_Project.WS_Kontrol.ZktWmStNaksip();

                chk.IvTanum = txtNakilSiparisNo.Text.ToString().Trim().ToUpper();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsManToplamaNaksip(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    sip = resp.IsNaksip;
                    Cursor.Current = Cursors.Default;
                    frm_18_Toplama_Manual_Nakil_Sip_Onaylama frm = new frm_18_Toplama_Manual_Nakil_Sip_Onaylama();
                    frm._sip = sip;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Abort)
                    {
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    Utility.selectText(txtNakilSiparisNo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                Utility.selectText(txtNakilSiparisNo);
                logger.error("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris_btn_DetayGetir_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Giris_btn_DetayGetir_Click end");
            
            
        }

        private void txtNakilSiparisNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_NakilSiparisNo, 'b');
        }

        private void txtNakilSiparisNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_DetayGetir_Click(new object(), new EventArgs());
            }
        }

    }
}