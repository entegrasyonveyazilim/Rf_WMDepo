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
    public partial class frm_39_Depo_Yerleri_Arasi_Transfer : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_39_Depo_Yerleri_Arasi_Transfer).Name);
        public frm_39_Depo_Yerleri_Arasi_Transfer()
        {
            InitializeComponent();
        }

        string _malzemeAdresi;
        decimal _miktar;

        private void formAcilisDuzenle()
        {
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
           
            txtMiktar.Enabled = false;
            txtMalzemeNo.Enabled = false;

            _malzemeAdresi = "";
            _miktar = 0;

            cmbMalzemeAdresi.Text = "";
            cmbMalzemeAdresi.Focus();


        }

        private void frm_39_Depo_Yerleri_Arasi_Transfer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
        }

        private void cmbMalzemeAdresi_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeAdresi, 'b');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p4, lbl_Miktar, 'p');
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeAdresi, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p4, lbl_Miktar, 'p');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeAdresi, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p4, lbl_Miktar, 'b');
        }

        private void cmbMalzemeAdresi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMalzemeAdresi.SelectedIndex == 0)
            {
                txtMalzemeNo.Text = "";
                txtMalzemeNo.Enabled = false;
                _malzemeAdresi = "";
                return;
            }
            else
            {
                _malzemeAdresi = cmbMalzemeAdresi.Text.ToString();
                txtMalzemeNo.Enabled = true;
                Utility.selectText(txtMalzemeNo);
            }

            
            
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_39_Depo_Yerleri_Arasi_Transfer_txtMalzemeNo_KeyDown begin");
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
                    WS_Kontrol.ZKtWmWsCikisMatnrKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisMatnrKontrol();
                    WS_Kontrol.ZKtWmWsCikisMatnrKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisMatnrKontrolResponse();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvEan = txtMalzemeNo.Text.ToString().Trim();
                    chk.IvLgpla = _malzemeAdresi;
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsCikisMatnrKontrol(chk);


                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        //İlgili alanlar dolduruluyor
                        stok = resp.EsStok;
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        _miktar = stok.Miktar;
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtMiktar.Enabled = true;
                        Utility.selectText(txtMiktar);
                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtMalzemeNo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_39_Depo_Yerleri_Arasi_Transfer_txtMalzemeNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            logger.info("frm_39_Depo_Yerleri_Arasi_Transfer_txtMalzemeNo_KeyDown end");
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_39_Depo_Yerleri_Arasi_Transfer_btn_Kaydet_Click begin");
            decimal miktar;

            if (_malzemeAdresi == "")
            {
                MessageBox.Show("Malzeme adresi seçin", "HATA");
                return;
            }
            if (txtMiktar.Text.ToString().Trim() == "") {
                return;
            }

            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal bir değer girin", "HATA");
                return;
            }

            if (miktar > _miktar)
            {
                MessageBox.Show("Girdiğiniz miktar toplam miktardan daha fazla olamaz. Toplam miktar:" + _miktar.ToString(), "HATA");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsDepoArasiTransfer chk = new KoctasWM_Project.WS_Islem.ZKtWmWsDepoArasiTransfer();
                WS_Islem.ZKtWmWsDepoArasiTransferResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsDepoArasiTransferResponse();

                chk.IvLgpla = _malzemeAdresi;
                chk.IvMatnr = txtMalzemeNo.Text.Trim();
                chk.IvMiktar = miktar;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsDepoArasiTransfer(chk);


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
                logger.error("frm_39_Depo_Yerleri_Arasi_Transfer_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_39_Depo_Yerleri_Arasi_Transfer_btn_Kaydet_Click end");
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        
    }
}