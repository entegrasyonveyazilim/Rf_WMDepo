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
    public partial class frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis).Name);
        public frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis()
        {
            InitializeComponent();
        }

        public decimal miktar;
        public string malzemeNo;

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formAcilisDuzenle()
        {

            txtPaletNo.Text = "";
            txtPaletNo.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtAdres.Text = "";
            txtMiktar.Text = "";
            txtToplamMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtStokTipi.Text = "";
            txtKarMerkezi.Text = "";

            txtMiktar.Enabled = false;
            Utility.selectText(txtPaletNo);

        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_btn_Kaydet_Click begin");
            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                Utility.selectText(txtMiktar);
                return;
            }

            if (!(miktar > 0))
            {
                return;
            }


            Cursor.Current = Cursors.WaitCursor;
           
            
            try
            {

                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSigortaCikisi chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSigortaCikisi();
                WS_Islem.ZKtWmWsSigortaCikisiResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSigortaCikisiResponse();

                chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                chk.IvMatnr = malzemeNo;
                chk.IvMiktar = miktar;
                chk.IvLgpla = txtAdres.Text.ToString();
                chk.IvPrctr = txtKarMerkezi.Text.ToString();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsSigortaCikisi(chk);


                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtMiktar);
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
                        Utility.selectText(txtMiktar);
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
                logger.error("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_btn_Kaydet_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_btn_Kaydet_Click end");
        }

        private void frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_Load(object sender, EventArgs e)
        {
            logger.info("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            Utility.selectText(txtPaletNo);

            //Form izin kontrolü yapılıyor
            if (!Utility.yetkiKontrol("frm_15"))
            {
                this.Close();
            }
            logger.info("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_Load end");
        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_PaletNo, 'b');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_txtPaletNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPaletNo.Text.Trim() == "")
                {
                    return;
                }
                txtPaletNo.Text = txtPaletNo.Text.ToUpper();

                Cursor.Current = Cursors.WaitCursor;

                try
                {

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();
                    WS_Kontrol.ZKtWmWsCikisPaletKont2 chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisPaletKont2();
                    WS_Kontrol.ZKtWmWsCikisPaletKont2Response resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisPaletKont2Response();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");

                    chk.IvLenum = txtPaletNo.Text.ToString().Trim();

                    resp = srv.ZKtWmWsCikisPaletKont2(chk);
                    stok = resp.EsStok;

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {

                        txtMalzemeNo.Text = malzemeNo = Convert.ToInt64(stok.Matnr.ToString()).ToString();
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtToplamMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtStokTipi.Text = stok.Bestq.ToString();
                        txtAdres.Text = stok.Lgpla.ToString();

                        txtKarMerkezi.Text = resp.EvPrctr.ToString();
                        txtKarMerkezi.ReadOnly = true;
                        txtMiktar.Enabled = true;
                        Utility.selectText(txtMiktar);


                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtPaletNo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_txtPaletNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }


            }
            logger.info("frm_15_Genel_Cikis_Isl_Sigorta_Ara_Hesabina_Cikis_txtPaletNo_KeyDown end");
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'b');
        }

        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void txtKarMerkezi_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_KarMerkezi_ParentChanged(object sender, EventArgs e)
        {

        }

        private void p5_GotFocus(object sender, EventArgs e)
        {

        }

        private void txtToplamMiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_ToplamMiktar_ParentChanged(object sender, EventArgs e)
        {

        }

        private void txtOlcuBirimi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStokTipi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void lbl_OlcuBirimi_ParentChanged(object sender, EventArgs e)
        {

        }

        private void lbl_MalzemeTanimi_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}