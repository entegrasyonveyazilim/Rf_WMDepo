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
    public partial class frm_03_Depo_Adresler_Arasi_Palet_Transferi : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_03_Depo_Adresler_Arasi_Palet_Transferi).Name);

        public frm_03_Depo_Adresler_Arasi_Palet_Transferi()
        {
            InitializeComponent();
        }

        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = ""; 
            txtAdres.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtStokTipi.Text = "";
            txtHedefAdres.Text = "";

            txtHedefAdres.Enabled = false;
            txtPaletNo.Focus();

        }

        private void txtHedefAdres_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'w');
            Utility.setBackBolor(p2, lbl_HedefAdres, 'b');
        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'b');
            Utility.setBackBolor(p2, lbl_HedefAdres, 'w');
        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_03_Depo_Adresler_Arasi_Palet_Transferi_Load(object sender, EventArgs e)
        {
            logger.info("frm_03_Depo_Adresler_Arasi_Palet_Transferi_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            txtPaletNo.Focus();
            logger.info("frm_03_Depo_Adresler_Arasi_Palet_Transferi_Load end");
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_03_Depo_Adresler_Arasi_Palet_Transferi_txtMalzemeNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPaletNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsPaletKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrol();
                    WS_Kontrol.ZKtWmWsPaletKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrolResponse();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsPaletKontrol(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        stok = resp.EsStok;

                        
                        txtAdres.Text = stok.Lgpla.ToString();
                        txtMalzemeNo.Text = Convert.ToInt64(stok.Matnr).ToString();
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtStokTipi.Text = stok.Bestq.ToString(); 

                        txtHedefAdres.Enabled = true;
                        txtHedefAdres.Focus();
                        
                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_03_Depo_Adresler_Arasi_Palet_Transferi_txtMalzemeNo_KeyDown "+ex.Message );

                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_03_Depo_Adresler_Arasi_Palet_Transferi_txtMalzemeNo_KeyDown end");
        }

        private void txtHedefAdres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_03_Depo_Adresler_Arasi_Palet_Transferi_btn_Kaydet_Click begin");
            if (txtHedefAdres.Text.ToString().Trim() == "")
            {
                return;
            }

            txtHedefAdres.Text = txtHedefAdres.Text.ToUpper();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsPaletTransfer chk = new KoctasWM_Project.WS_Islem.ZKtWmWsPaletTransfer();
                WS_Islem.ZKtWmWsPaletTransferResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsPaletTransferResponse();

                chk.IvHedefAdres = txtHedefAdres.Text.ToString().ToUpper().Trim();
                chk.IvLenum = txtPaletNo.Text.ToString().Trim();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsPaletTransfer(chk);


                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtHedefAdres);
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        formAcilisDuzenle();
                    }
                    else
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                        Utility.selectText(txtHedefAdres);
                    }

                }
                else
                {
                    MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_03_Depo_Adresler_Arasi_Palet_Transferi_btn_Kaydet_Click " + ex.Message);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_03_Depo_Adresler_Arasi_Palet_Transferi_btn_Kaydet_Click end");
        }
    }
}