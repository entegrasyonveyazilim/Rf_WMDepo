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
    public partial class frm_01_SA_Trans_Girisi_Paletleme : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_01_SA_Trans_Girisi_Paletleme).Name);

        public frm_01_SA_Trans_Girisi_Paletleme()
        {
            InitializeComponent();
        }

        decimal miktar;
        string malzemeNo;

        private void frm_01_SA_Trans_Girisi_Adresleme_Load(object sender, EventArgs e)
        {
            logger.info("frm_01_SA_Trans_Girisi_Adresleme_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
            txtMalzemeNo.Focus();
            logger.info("frm_01_SA_Trans_Girisi_Adresleme_Load end");
        }

        private void formAcilisDuzenle()
        {
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtPaletNo.Text = "";
            txtToplamMiktar.Text = "";

            txtMiktar.Enabled = false;
            txtPaletNo.Enabled = false;

            txtMalzemeNo.Focus();
            
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p2, lbl_Miktar, 'w');
            Utility.setBackBolor(p3, lbl_PaletNo, 'w');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p2, lbl_Miktar, 'b');
            Utility.setBackBolor(p3, lbl_PaletNo, 'w');
        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p2, lbl_Miktar, 'w');
            Utility.setBackBolor(p3, lbl_PaletNo, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_01_SA_Trans_Girisi_Adresleme_txtMalzemeNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    txtMiktar.Enabled = false;
                    txtPaletNo.Enabled = false;
                    
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsMalzemeKontrolu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMalzemeKontrolu();
                    WS_Kontrol.ZKtWmWsMalzemeKontroluResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMalzemeKontroluResponse();

                    chk.IvEan = txtMalzemeNo.Text.Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsMalzemeKontrolu(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {

                        //İlgili alanlar dolduruluyor ve giriş alanları aktif ediliyor
                        txtMalzemeTanimi.Text = resp.EsStok.Maktx.ToString();
                        txtOlcuBirimi.Text = resp.EsStok.Meins.ToString();
                        malzemeNo = resp.EsStok.Matnr.ToString();
                        txtToplamMiktar.Text = resp.EsStok.Miktar.ToString();

                        txtMiktar.Enabled = true;
                        Utility.selectText(txtMiktar);
                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        txtMalzemeNo.Text = "";
                        Utility.selectText(txtMalzemeNo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error( "frm_01_SA_Trans_Girisi_Adresleme_txtMalzemeNo_KeyDown "+ ex.Message );
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                    


            }
            logger.info("frm_01_SA_Trans_Girisi_Adresleme_txtMalzemeNo_KeyDown end");
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_01_SA_Trans_Girisi_Adresleme_btn_Kaydet_Click begin");
            if (txtPaletNo.Text.Trim() == "")
            {
                return;
            }

            txtPaletNo.Text = txtPaletNo.Text.ToUpper();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Palet no geçerli ise yazma işlemi yapılıyor

                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSatinalmaGiris chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSatinalmaGiris();
                WS_Islem.ZKtWmWsSatinalmaGirisResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSatinalmaGirisResponse();

                chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                chk.IvMatnr = malzemeNo;
                chk.IvMiktar = miktar;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsSatinalmaGiris(chk);


                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        if (GlobalData.rMsg[0].Message.ToString().Contains("miktar"))
                        {
                            Utility.selectText(txtMiktar);
                        }
                        else if (GlobalData.rMsg[0].Message.ToString().Contains("adres"))
                        {
                            Utility.selectText(txtPaletNo);
                        }
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
                        if (GlobalData.rMsg[0].Message.ToString().Contains("miktar"))
                        {
                            Utility.selectText(txtMiktar);
                        }
                        else if (GlobalData.rMsg[0].Message.ToString().Contains("adres"))
                        {
                            Utility.selectText(txtPaletNo);
                        }
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
                logger.error("frm_01_SA_Trans_Girisi_Adresleme_btn_Kaydet_Click "+ex.Message );
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_01_SA_Trans_Girisi_Adresleme_btn_Kaydet_Click end");
        }

        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMiktar.Text.Trim() == "")
                {
                    return;
                }


                try
                {
                    miktar = Convert.ToDecimal(txtMiktar.Text.Trim());
                    txtPaletNo.Enabled = true;
                    txtPaletNo.Focus();
                }
                catch
                {
                    MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                    txtMiktar.Text = "";
                    txtMiktar.Focus();
                }
            }
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }


    }
}