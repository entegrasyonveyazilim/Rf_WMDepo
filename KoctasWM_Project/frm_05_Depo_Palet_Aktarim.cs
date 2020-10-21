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
    public partial class frm_05_Depo_Palet_Aktarim : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_05_Depo_Palet_Aktarim).Name);
        public frm_05_Depo_Palet_Aktarim()
        {
            InitializeComponent();
        }

        decimal miktar;

        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = "";
            txtAdres.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtToplamMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtStokTipi.Text = "";
            txtHedefPalet.Text = "";
            txtKullanilabilirMiktar.Text = "";

            txtMiktar.Enabled = false;

            txtHedefPalet.Enabled = false;

            txtPaletNo.Focus();

        }
        
        private void txtHedefPalet_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
            Utility.setBackBolor(p3, lbl_HedefPalet, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'b');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
            Utility.setBackBolor(p3, lbl_HedefPalet, 'w');
        }


        private void frm_05_Depo_Palet_Aktarim_Load(object sender, EventArgs e)
        {
            logger.info("frm_05_Depo_Palet_Aktarim_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
            txtPaletNo.Focus();
            logger.info("frm_05_Depo_Palet_Aktarim_Load end");
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'b');
            Utility.setBackBolor(p3, lbl_HedefPalet, 'w');
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_05_Depo_Palet_Aktarim_txtMalzemeNo_KeyDown begin");
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
                    WS_Kontrol.ZKtWmWsPaletKontrol05 chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrol05();
                    WS_Kontrol.ZKtWmWsPaletKontrol05Response resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrol05Response();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsPaletKontrol05(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        stok = resp.EsStok;

                        txtAdres.Text = stok.Lgpla.ToString();
                        txtMalzemeNo.Text = Convert.ToInt64(stok.Matnr).ToString();
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtToplamMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtStokTipi.Text = stok.Bestq.ToString();
                        txtKullanilabilirMiktar.Text = (stok.Miktar - stok.EmirliMiktar).ToString();

                        txtMiktar.Enabled = true;
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
                    logger.error("frm_05_Depo_Palet_Aktarim_txtMalzemeNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_05_Depo_Palet_Aktarim_txtMalzemeNo_KeyDown end");
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

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_05_Depo_Palet_Aktarim_btn_Kaydet_Click begin");
            if (!(miktar > 0))
            {
                return;
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
                WS_Islem.ZKtWmWsPltToPltTransfer chk = new KoctasWM_Project.WS_Islem.ZKtWmWsPltToPltTransfer();
                WS_Islem.ZKtWmWsPltToPltTransferResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsPltToPltTransferResponse();

                chk.IvHedefPalet = txtHedefPalet.Text.ToString().Trim();
                chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                chk.IvMiktar = miktar;
                //Hedef adres için input alanı webservisten gelmiyor, eklenecek

                

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsPltToPltTransfer(chk);

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
                logger.error("frm_05_Depo_Palet_Aktarim_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_05_Depo_Palet_Aktarim_btn_Kaydet_Click begin");
        }

        private void txtHedefPalet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}