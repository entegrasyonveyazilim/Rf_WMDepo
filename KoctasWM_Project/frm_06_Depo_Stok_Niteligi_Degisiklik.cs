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
    public partial class frm_06_Depo_Stok_Niteligi_Degisiklik : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_06_Depo_Stok_Niteligi_Degisiklik).Name);
        public frm_06_Depo_Stok_Niteligi_Degisiklik()
        {
            InitializeComponent();
        }

        public static string stokTipiDegistir;

        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtStokTipi.Text = "";

            Utility.selectText(txtPaletNo);

            btn_KaydetBloke.Visible = false;
            btn_KaydetTahditsiz.Visible = false;

        }

        private void frm_06_Depo_Stok_Niteligi_Degisiklik_Load(object sender, EventArgs e)
        {
            logger.info("frm_06_Depo_Stok_Niteligi_Degisiklik_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
            formAcilisDuzenle();
            logger.info("frm_06_Depo_Stok_Niteligi_Degisiklik_Load end");
        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_06_Depo_Stok_Niteligi_Degisiklik_txtMalzemeNo_KeyDown begin");
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

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsPaletKontrol06 chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrol06();
                    WS_Kontrol.ZKtWmWsPaletKontrol06Response resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrol06Response();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    

                    chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsPaletKontrol06(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        stok = resp.EsStok;

                        txtMalzemeNo.Text = Convert.ToInt64(stok.Matnr).ToString();
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtStokTipi.Text = stok.Bestq.ToString();


                        //Stok tipine göre işlem türü belirleniyor
                        if (stok.Bestq.ToString().ToUpper() == "")
                        {
                            //Stok tipi boş gelirse blokeye al aktif olacak
                            btn_KaydetBloke.Visible = true;
                            btn_KaydetTahditsiz.Visible = false;
                            stokTipiDegistir = "S";
                        }
                        else if (stok.Bestq.ToString().ToUpper() == "S")
                        {
                            //Stok tipi S gelirse tahditsize al aktif olacak
                            btn_KaydetBloke.Visible = false;
                            btn_KaydetTahditsiz.Visible = true;
                            stokTipiDegistir = "";
                        }
                        else
                        {
                            btn_KaydetBloke.Visible = false;
                            btn_KaydetTahditsiz.Visible = false;
                            Utility.selectText(txtPaletNo);
                        }

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_06_Depo_Stok_Niteligi_Degisiklik_txtMalzemeNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_06_Depo_Stok_Niteligi_Degisiklik_txtMalzemeNo_KeyDown end");
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_06_Depo_Stok_Niteligi_Degisiklik_btn_Kaydet_Click begin");
            if (txtPaletNo.Text.ToString().Trim() == "")
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsStkNitelikDegis chk = new KoctasWM_Project.WS_Islem.ZKtWmWsStkNitelikDegis();
                WS_Islem.ZKtWmWsStkNitelikDegisResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsStkNitelikDegisResponse();

                chk.IvBestq = stokTipiDegistir.ToString();
                chk.IvLenum = txtPaletNo.Text.ToString().Trim();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsStkNitelikDegis(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtPaletNo);
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
                        Utility.selectText(txtPaletNo);
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
                Utility.selectText(txtPaletNo);
                logger.error("frm_06_Depo_Stok_Niteligi_Degisiklik_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_06_Depo_Stok_Niteligi_Degisiklik_btn_Kaydet_Click end");
        }
    }
}