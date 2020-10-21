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
    public partial class frm_37_Toplama_Iptal_Alanindan_Transferler : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_37_Toplama_Iptal_Alanindan_Transferler).Name);
        public frm_37_Toplama_Iptal_Alanindan_Transferler()
        {
            InitializeComponent();
        }

        private void frm_37_Toplama_Iptal_Alanindan_Transferler_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Maximized;
            Utility.loginInfo(lbl_LoginInfo);

            Utility.selectText(txtMalzemeNo);
        }

        decimal miktar;
        string malzemeNo;

        private void formAcilisDuzenle()
        {
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtOnerilenAdres.Text = "";
            txtOnerilenPalet.Text = "";
            txtHedefPalet.Text = "";

            btn_OnerilenPaletKopyala.Enabled = false;

            txtMiktar.Enabled = false;
            txtHedefPalet.Enabled = false;

            txtMalzemeNo.Focus();

        }


        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p3, lbl_HedefPalet, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }

        private void lbl_OlcuBirimi_ParentChanged(object sender, EventArgs e)
        {

        }

        private void txtOlcuBirimi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHedefAdres_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_HedefPalet, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHedefPalet_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_HedefPalet, 'b');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_37_Toplama_Iptal_Alanindan_Transferler_txtMalzemeNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsTopIpMlzKontrolu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsTopIpMlzKontrolu();
                    WS_Kontrol.ZKtWmWsTopIpMlzKontroluResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsTopIpMlzKontroluResponse();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();


                    chk.IvEan = txtMalzemeNo.Text.ToString().Trim();
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsTopIpMlzKontrolu(chk);


                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        //İlgili alanlar dolduruluyor
                        stok = resp.EsStok;
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        //txtMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtOnerilenAdres.Text = stok.OnerilenAdres.ToString();
                        txtOnerilenPalet.Text = stok.OnerilenPalet.ToString();


                        btn_OnerilenPaletKopyala.Enabled = true;
                        txtHedefPalet.Enabled = true;
                        txtMiktar.Enabled = true;

                        malzemeNo = stok.Matnr.ToString();

                        Utility.selectText(txtMiktar);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_37_Toplama_Iptal_Alanindan_Transferler_txtMalzemeNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            logger.info("frm_37_Toplama_Iptal_Alanindan_Transferler_txtMalzemeNo_KeyDown end");
        }

        private void btn_OnerilenPaletKopyala_Click(object sender, EventArgs e)
        {
            txtHedefPalet.Text = txtOnerilenPalet.Text.ToString();
            Utility.selectText(txtHedefPalet);
        }


        private void txtHedefPalet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_37_Toplama_Iptal_Alanindan_Transferler_btn_Kaydet_Click begin");

            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                Utility.selectText(txtMiktar);
            }


            if (txtHedefPalet.Text.ToString().Trim() == "")
            {
                return;
            }

            txtHedefPalet.Text = txtHedefPalet.Text.ToUpper();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsTopIpTransfer chk = new KoctasWM_Project.WS_Islem.ZKtWmWsTopIpTransfer();
                WS_Islem.ZKtWmWsTopIpTransferResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsTopIpTransferResponse();

                chk.IvHedefPalet = txtHedefPalet.Text.ToString();
                chk.IvMatnr = malzemeNo;
                chk.IvMiktar = miktar;
                //Hedef adres için input alanı webservisten gelmiyor, eklenecek

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsTopIpTransfer(chk);


                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtHedefPalet);
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
                        Utility.selectText(txtHedefPalet);
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
                logger.error("frm_37_Toplama_Iptal_Alanindan_Transferler_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_37_Toplama_Iptal_Alanindan_Transferler_btn_Kaydet_Click end");
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_HedefPalet, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'b');
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
                    txtHedefPalet.Enabled = true;
                    Utility.selectText(txtHedefPalet);
                }
                catch
                {
                    MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                    Utility.selectText(txtMiktar);
                }
            }
        }

        
    }
}