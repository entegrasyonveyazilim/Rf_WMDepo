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
    public partial class frm_07_Depo_Palet_Sorgulama : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_07_Depo_Palet_Sorgulama).Name);
        public frm_07_Depo_Palet_Sorgulama()
        {
            InitializeComponent();
        }

        private void formAcilisDuzenle()
        {

            txtAdres.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtToplanacakMiktar.Text = "";
            txtToplamMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtStokTipi.Text = "";
            txtEan.Text = "";

        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'b');
        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_07_Depo_Palet_Sorgulama_Load(object sender, EventArgs e)
        {
            logger.info("frm_07_Depo_Palet_Sorgulama_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false; Utility.loginInfo(lbl_LoginInfo);
            Utility.selectText(txtPaletNo);
            logger.info("frm_07_Depo_Palet_Sorgulama_Load end");
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_07_Depo_Palet_Sorgulama_txtPaletNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPaletNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                txtPaletNo.Text = txtPaletNo.Text.ToUpper();

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    formAcilisDuzenle();

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsPaletSorgu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletSorgu();
                    WS_Kontrol.ZKtWmWsPaletSorguResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletSorguResponse();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvLenum = txtPaletNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsPaletSorgu(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        stok = resp.EsStok;

                        txtAdres.Text = stok.Lgpla.ToString();
                        txtMalzemeNo.Text = Convert.ToInt64(stok.Matnr).ToString();
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtToplanacakMiktar.Text = stok.EmirliMiktar.ToString();
                        txtToplamMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtStokTipi.Text = stok.Bestq.ToString();
                        txtEan.Text = stok.Ean.ToString();

                        Utility.selectText(txtPaletNo);


                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        txtPaletNo.Text = "";
                        Utility.selectText(txtPaletNo);

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_07_Depo_Palet_Sorgulama_txtPaletNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_07_Depo_Palet_Sorgulama_txtPaletNo_KeyDown end");
        }

    }
}