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
    public partial class frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama).Name);
        public frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama()
        {
            InitializeComponent();
        }

        decimal toplamMiktar;
        string _tanum;

        private void formAcilisDuzenle()
        {
            txtKaynakAdres.Text = "";
            txtPaletNo.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtHedefDepoTipi.Text = "";
            txtHedefAdres.Text = "";

            txtHedefPaletNo.Text = "";
            txtHedefAdres2.Text = "";
        }

        private void frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_Load(object sender, EventArgs e)
        {
            logger.info("frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            formAcilisDuzenle();

            //Webservice sorgulanıyor
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsIkmalNakilKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsIkmalNakilKontrol();
                WS_Kontrol.ZKtWmWsIkmalNakilKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsIkmalNakilKontrolResponse();
                WS_Kontrol.ZktWmStNaksip sip = new KoctasWM_Project.WS_Kontrol.ZktWmStNaksip();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsIkmalNakilKontrol(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    sip = resp.EsNaksip;


                    txtKaynakAdres.Text = sip.Vlpla.ToString();
                    if (sip.Vlenr.ToString() != "")
                    {
                        txtPaletNo.Text = Convert.ToInt64(sip.Vlenr).ToString();
                    }
                    else
                    {
                        txtPaletNo.Text = "";
                    }
                    txtMalzemeNo.Text = Convert.ToInt64(sip.Matnr).ToString();
                    txtMalzemeTanimi.Text = sip.Maktx.ToString();
                    toplamMiktar = Convert.ToDecimal(sip.Vsolm.ToString());
                    txtMiktar.Text = sip.Vsolm.ToString();
                    txtOlcuBirimi.Text = sip.Meins.ToString();
                    txtHedefDepoTipi.Text = sip.Nltyp.ToString();
                    txtHedefAdres.Text = sip.Nlpla.ToString();
                    _tanum = sip.Tanum.ToString();
                   

                    txtHedefPaletNo.Enabled = true;
                    Utility.selectText(txtHedefPaletNo);

                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_Load "+ ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_Load end");
            
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void txtHedefPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_HedefPaletNo, 'b');
            Utility.setBackBolor(p4, lbl_HedefAdres2, 'w');
        }

        private void txtHedefAdres2_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_HedefPaletNo, 'w');
            Utility.setBackBolor(p4, lbl_HedefAdres2, 'b');
        }

        private void txtHedefPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHedefPaletNo.Text.Trim() == "")
                {
                    return;
                }
                else
                {
                    txtHedefAdres2.Enabled = true;
                    Utility.selectText(txtHedefAdres2);
                    btn_Kaydet.Enabled = true;
                }
            }
        }

        private void txtHedefAdres2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {

            logger.info("frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_btn_Kaydet_Click begin");

            if (txtHedefAdres2.Text.Trim() == "")
            {
                return;
            }

            if (txtPaletNo.Text.ToString().Trim() != Convert.ToInt64(txtHedefPaletNo.Text.ToString().Trim()).ToString())
            {
                MessageBox.Show("Hedef palet numarası farklı olamaz", "HATA");
                return;
            }

            if (txtHedefAdres.Text.ToString().Trim() != txtHedefAdres2.Text.ToString().Trim())
            {
                MessageBox.Show("Hedef adres numarası farklı olamaz", "HATA");
                return;
            }


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsIkmalNaksipOnay chk = new KoctasWM_Project.WS_Islem.ZKtWmWsIkmalNaksipOnay();
                WS_Islem.ZKtWmWsIkmalNaksipOnayResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsIkmalNaksipOnayResponse();

                chk.IvTanum = _tanum.ToString();
                chk.IvMiktar = toplamMiktar;


                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsIkmalNaksipOnay(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtHedefPaletNo);
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        //this.Close();
                        frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_Load(new object(), new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                        Utility.selectText(txtHedefPaletNo);
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
                Utility.selectText(txtHedefPaletNo);
                logger.error("frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_btn_Kaydet_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_11_Toplama_Ikmal_Nakil_Sip_Onaylama_btn_Kaydet_Click end");
        }

        
    }
}