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
    public partial class frm_18_Toplama_Manual_Nakil_Sip_Onaylama : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_18_Toplama_Manual_Nakil_Sip_Onaylama).Name);
        public frm_18_Toplama_Manual_Nakil_Sip_Onaylama()
        {
            InitializeComponent();
        }

        public WS_Kontrol.ZktWmStNaksip _sip;
        decimal miktar;
        decimal toplamMiktar = 0;
        string _tanum;

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_btn_Geri_Click begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Nakil siparişinin kilidi kaldırılıyor
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsToplamaLockCoz chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsToplamaLockCoz();
                WS_Kontrol.ZKtWmWsToplamaLockCozResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsToplamaLockCozResponse();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsToplamaLockCoz(chk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "HATA");
                logger.error("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_btn_Geri_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            this.DialogResult = DialogResult.Abort;
            this.Close();
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_btn_Geri_Click end");
        }

        private void frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Load(object sender, EventArgs e)
        {
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            if (_sip.Maktx.ToString().Trim() == "")
            {
                MessageBox.Show("Belirtilen sipariş no bulunamadı", "HATA");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                txtKaynakAdres.Text = _sip.Vlpla.ToString();

                if (_sip.Vlenr.ToString() != "")
                {
                    txtPaletNo.Text = Convert.ToInt64(_sip.Vlenr).ToString();
                }
                else
                {
                    txtPaletNo.Text = "";
                }
                txtMalzemeNo.Text = Convert.ToInt64(_sip.Matnr).ToString();
                txtMalzemeTanimi.Text = _sip.Maktx.ToString();
                toplamMiktar = Convert.ToDecimal(_sip.Vsolm.ToString());
                txtMiktar.Text = _sip.Vsolm.ToString();
                txtOlcuBirimi.Text = _sip.Meins.ToString();
                txtHedefDepoTipi.Text = _sip.Nltyp.ToString();
                txtHedefAdres.Text = _sip.Nlpla.ToString();
                _tanum = _sip.Tanum.ToString();

                txtHedefPaletNo.Enabled = true;
                Utility.selectText(txtHedefPaletNo);
            }

            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_Load end");
        }


        private void txtHedefPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_HedefPaletNo, 'b');
            Utility.setBackBolor(p5, lbl_HedefMalzemeNo, 'w');
            Utility.setBackBolor(p4, lbl_HedefMiktar, 'w');
        }

        private void txtHedefMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_HedefPaletNo, 'w');
            Utility.setBackBolor(p5, lbl_HedefMalzemeNo, 'w');
            Utility.setBackBolor(p4, lbl_HedefMiktar, 'b');
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
                    txtHedefMalzemeNo.Enabled = true;
                    Utility.selectText(txtHedefMalzemeNo);
                }
            }

        }

        private void txtHedefMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }

        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_btn_Kaydet_Click begin");
            bool devam = true;

            try
            {
                miktar = Convert.ToDecimal(txtHedefMiktar.Text);
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal bir değer giriniz", "HATA");
                Utility.selectText(txtHedefMiktar);
                return;
            }

            /*
            if (!(miktar > 0))
            {
                return;
            }*/

            if (txtPaletNo.Text.ToString().Trim() != txtHedefPaletNo.Text.ToString().Trim())
            {
                MessageBox.Show("Okutulan palet numarası eşleşmedi.", "HATA");
                Utility.selectText(txtHedefPaletNo);
                return;
            }

            //Girilen malzeme veya ean no matnr ye çeviriliyor
            string hedefMalemeNo = Utility.malzemeNoGetir(txtHedefMalzemeNo.Text.ToString().Trim(), "matnr");
            try
            {
                hedefMalemeNo = Convert.ToInt64(hedefMalemeNo).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

            if (txtMalzemeNo.Text.ToString().Trim() != hedefMalemeNo)
            {
                MessageBox.Show("Okutulan malzeme numarası eşleşmedi.", "HATA");
                Utility.selectText(txtHedefPaletNo);
                return;
            }

            if (miktar > toplamMiktar)
            {
                MessageBox.Show("Miktar nakil sipariş miktarından büyük olamaz", "HATA");
                Utility.selectText(txtHedefMiktar);
                return;
            }
            else if (miktar < toplamMiktar)
            {
                if (MessageBox.Show("Eksik miktar girildi. Fark miktarı fark adresine taşınacak. Onaylıyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    devam = false;
                }
            }

            if (!devam) return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsToplamaNaksipCre chk = new KoctasWM_Project.WS_Islem.ZKtWmWsToplamaNaksipCre();
                WS_Islem.ZKtWmWsToplamaNaksipCreResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsToplamaNaksipCreResponse();

                chk.IvMiktar = miktar;
                chk.IvTanum = _tanum.ToString().Trim().ToUpper();


                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsToplamaNaksipCre(chk);

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
                        this.DialogResult = DialogResult.Abort;
                        this.Close();
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
                logger.error("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_btn_Kaydet_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_18_Toplama_Manual_Nakil_Sip_Onaylama_btn_Kaydet_Click end");
        }

        private void txtHedefMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_HedefPaletNo, 'w');
            Utility.setBackBolor(p5, lbl_HedefMalzemeNo, 'b');
            Utility.setBackBolor(p4, lbl_HedefMiktar, 'w');
        }

        private void txtHedefMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHedefMalzemeNo.Text.Trim() == "")
                {
                    return;
                }
                else
                {
                    txtHedefMiktar.Enabled = true;
                    Utility.selectText(txtHedefMiktar);
                    btn_Kaydet.Enabled = true;
                }
            }
        }
    }
}