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
    public partial class frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma).Name);
        public frm_19_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma()
        {
            InitializeComponent();
        }

        public WS_Kontrol.ZktWmStTeslimat _tes;
        public string _dagitimTuru;
        decimal miktar;
        decimal kalanMiktar;

        private void frm_19_Toplama_Ikmal_Siparisleri_Onaylama_Load(object sender, EventArgs e)
        {
            logger.info("frm_19_Toplama_Ikmal_Siparisleri_Onaylama_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            if (_tes.Maktx.ToString().Trim() == "")
            {
                MessageBox.Show("Belirtilen malzeme no bulunamadı", "HATA");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {

                if ((_tes.Lfart.ToString() == "ZLF") || (_tes.Lfart.ToString() == "ZNLF"))
                {
                    txtTeslimatTipi.Text = "Müşteri";
                }
                else if (_tes.Lfart.ToString() == "NL")
                {
                    txtTeslimatTipi.Text = "Mağaza";
                }
                else
                {
                    txtTeslimatTipi.Text = _tes.Lfart.ToString();
                }
                
                
                txtTeslimatNo.Text = _tes.Vbeln.ToString();
                txtMalzemeNo.Text = Convert.ToInt64(_tes.Matnr).ToString();
                txtMalzemeTanimi.Text = _tes.Maktx.ToString();
                kalanMiktar = _tes.Menge;
                txtKalanMiktar.Text = _tes.Menge.ToString();
                txtOlcuBirimi.Text = _tes.Meins.ToString();
                txtDagitimAdresiOnerilen.Text = _tes.DagitimAdresi.ToString();
                txtTeslimatMiktari.Text = _tes.Lfimg.ToString();
                txtAliciAdi.Text = _tes.Name1.ToString();
                   


                Utility.selectText(txtDagitimMiktari);

            }

            logger.info("frm_19_Toplama_Ikmal_Siparisleri_Onaylama_Load end");

        }

        private void txtDagitimMiktari_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p4, lbl_DagitimMiktari, 'b');
            Utility.setBackBolor(p3, lbl_DagitimAdresiOlmasiGereken, 'w');
        }

        private void txtDagitimAdresiOlmasiGereken_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p4, lbl_DagitimMiktari, 'w');
            Utility.setBackBolor(p3, lbl_DagitimAdresiOlmasiGereken, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_19_Toplama_Ikmal_Siparisleri_Onaylama_btn_Kaydet_Click begin");
            if (!(miktar > 0))
            {
                return;
            }
            if (txtDagitimAdresiOlmasiGereken.Text.ToString().Trim() == "")
            {
                return;
            }

            if (_tes.Lfart.ToString() == "NL")
            {
                if (!Utility.baslangicKontrol(txtDagitimAdresiOlmasiGereken.Text, "RAMPA"))
                {
                    MessageBox.Show("Okuttuğunuz adres bu teslimat türüne uygun değil", "HATA");
                    Utility.selectText(txtDagitimAdresiOlmasiGereken);
                    return;
                }
            }
            else if ((_tes.Lfart.ToString() == "ZLF") || (_tes.Lfart.ToString() == "ZNLF"))
            {
                if ((!Utility.baslangicKontrol(txtDagitimAdresiOlmasiGereken.Text, "ARAC")) && (!Utility.baslangicKontrol(txtDagitimAdresiOlmasiGereken.Text, "PALET")))
                {
                    MessageBox.Show("Okuttuğunuz adres bu teslimat türüne uygun değil", "HATA");
                    Utility.selectText(txtDagitimAdresiOlmasiGereken);
                    return;
                }
            }

            txtDagitimAdresiOlmasiGereken.Text = txtDagitimAdresiOlmasiGereken.Text.ToString().Trim().ToUpper();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsTeslimDagitimCre chk = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimDagitimCre();
                WS_Islem.ZKtWmWsTeslimDagitimCreResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimDagitimCreResponse();
                WS_Islem.ZktWmStRampaYukleme[] it = new KoctasWM_Project.WS_Islem.ZktWmStRampaYukleme[1];

                it[0] = new KoctasWM_Project.WS_Islem.ZktWmStRampaYukleme();

                chk.IvType = _dagitimTuru;
                it[0].KoliNo = txtDagitimAdresiOlmasiGereken.Text.ToString().Trim();
                it[0].Matnr = "";
                it[0].Meins = "";
                it[0].Menge = miktar;
                it[0].Posnr = _tes.Posnr.ToString();
                it[0].VbelnVl = _tes.Vbeln.ToString();
                chk.ItRampa = it;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsTeslimDagitimCre(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtDagitimMiktari);
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                        Utility.selectText(txtDagitimAdresiOlmasiGereken);
                    }

                }
                else
                {
                    MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                    Utility.selectText(txtDagitimAdresiOlmasiGereken);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_19_Toplama_Ikmal_Siparisleri_Onaylama_btn_Kaydet_Click " +ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_19_Toplama_Ikmal_Siparisleri_Onaylama_btn_Kaydet_Click end");
        }

        private void txtDagitimMiktari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    miktar = Convert.ToDecimal(txtDagitimMiktari.Text);
                    txtKalanMiktar.Text = (kalanMiktar - miktar).ToString();
                    Utility.selectText(txtDagitimAdresiOlmasiGereken);

                }
                catch
                {
                    MessageBox.Show("Miktar alanına sayısal bir değer girin", "HATA");
                    Utility.selectText(txtDagitimMiktari);
                }
            }
        }

        private void txtDagitimAdresiOlmasiGereken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDagitimAdresiOlmasiGereken.Text = txtDagitimAdresiOlmasiGereken.Text.ToString().Trim().ToUpper();
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

    }
}