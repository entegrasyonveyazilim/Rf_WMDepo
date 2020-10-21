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
    public partial class frm_12_15_Genel_Cikis_Islemleri_Formlari : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_12_15_Genel_Cikis_Islemleri_Formlari).Name);
        public frm_12_15_Genel_Cikis_Islemleri_Formlari()
        {
            InitializeComponent();
        }

        public string islemTuru;
        public string ekranTipi;
        public string malzemeNo;
        public decimal miktar;
        bool miktarKontrol = false;
        

        private void frm_12_15_Genel_Cikis_Islemleri_Formlari_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            switch (islemTuru)
            {
                case "iadeCikisi":
                    {
                        lbl_Miktar.Text = "İade Miktarı";
                        this.Text = "Depo İşlemleri - Firma İade Alanına Çıkış";
                        miktarKontrol = true;
                        break;
                    }

                case "hurdaCikisi":
                    {
                        lbl_Miktar.Text = "Sarf Miktarı";
                        this.Text += "Sarf (Hurda) Çıkışı";
                        miktarKontrol = false;
                        break;
                    }
            }

            txtAdresNo.Focus();
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formAcilisDuzenle()
        {

            txtAdresNo.Text = "";
            txtPaletMalzemeNo.Text = "";
            txtPaletNo.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtToplamMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtStokTipi.Text = "";

            txtPaletMalzemeNo.Enabled = false;
            txtMiktar.Enabled = false;
            Utility.selectText(txtAdresNo);

        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_AdresNo, 'b');
            Utility.setBackBolor(p2, lbl_PaletMalzemeNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
            //Utility.setBackBolor(p3, lbl_HedefAdres, 'w');
        }

        private void txtPaletMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_AdresNo, 'w');
            Utility.setBackBolor(p2, lbl_PaletMalzemeNo, 'b');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
            //Utility.setBackBolor(p3, lbl_HedefAdres, 'w');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_AdresNo, 'w');
            Utility.setBackBolor(p2, lbl_PaletMalzemeNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'b');
            //Utility.setBackBolor(p3, lbl_HedefAdres, 'w');
        }

        private void txtHedefAdres_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_AdresNo, 'w');
            Utility.setBackBolor(p2, lbl_PaletMalzemeNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
            //Utility.setBackBolor(p3, lbl_HedefAdres, 'b');
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_12_15_Genel_Cikis_Islemleri_Formlari_txtMalzemeNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAdresNo.Text.Trim() == "")
                {
                    return;
                }

                txtAdresNo.Text = txtAdresNo.Text.ToUpper();

                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsCikisAdresKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisAdresKontrol();
                    WS_Kontrol.ZKtWmWsCikisAdresKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisAdresKontrolResponse();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvLgpla = txtAdresNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsCikisAdresKontrol(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        if (resp.EvLenvw.ToString().ToUpper() == "X")
                        {
                            lbl_PaletMalzemeNo.Text = "Palet No:";
                            txtPaletMalzemeNo.Enabled = true;
                            Utility.selectText(txtPaletMalzemeNo);
                            ekranTipi = "palet";
                            
                        }
                        else if (resp.EvLenvw.ToString().ToUpper() == "")
                        {
                            lbl_PaletMalzemeNo.Text = "Malzeme No:";
                            txtPaletMalzemeNo.Enabled = true;
                            Utility.selectText(txtPaletMalzemeNo);
                            ekranTipi = "malzeme";
                        }
                        else
                        {
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtAdresNo);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_12_15_Genel_Cikis_Islemleri_Formlari_txtMalzemeNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            logger.info("frm_12_15_Genel_Cikis_Islemleri_Formlari_txtMalzemeNo_KeyDown end");
        }

        private void txtPaletMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_12_15_Genel_Cikis_Islemleri_Formlari_txtPaletMalzemeNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPaletMalzemeNo.Text.Trim() == "")
                {
                    return;
                }
                txtPaletMalzemeNo.Text = txtPaletMalzemeNo.Text.ToUpper();

                Cursor.Current = Cursors.WaitCursor;

                try
                {

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();


                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");

                    if (ekranTipi == "palet")
                    {
                        WS_Kontrol.ZKtWmWsCikisPaletKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisPaletKontrol();
                        WS_Kontrol.ZKtWmWsCikisPaletKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisPaletKontrolResponse();
                        
                        chk.IvLenum = txtPaletMalzemeNo.Text.ToString().Trim();
                        chk.IvLgpla = txtAdresNo.Text.ToString().Trim();

                        resp = srv.ZKtWmWsCikisPaletKontrol(chk);
                        stok = resp.EsStok;

                        if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                        {
                            
                            txtPaletNo.Text = txtPaletMalzemeNo.Text.ToString().Trim();
                            malzemeNo = Convert.ToInt64(stok.Matnr.ToString()).ToString();
                            txtMalzemeNo.Text = malzemeNo;
                            txtMalzemeTanimi.Text = stok.Maktx.ToString();
                            txtToplamMiktar.Text = stok.Miktar.ToString();
                            txtOlcuBirimi.Text = stok.Meins.ToString();
                            txtStokTipi.Text = stok.Bestq.ToString();

                            txtMiktar.Enabled = true;
                            if (miktarKontrol)
                            {
                                txtMiktar.Text = stok.Miktar.ToString();
                                txtMiktar.ReadOnly = true;
                                txtMiktar.BackColor = Color.FromArgb(238, 188, 138);
                            }
                            else
                            {
                                Utility.selectText(txtMiktar);
                            }
                            

                            
                        }
                        else
                        {
                            MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                            Utility.selectText(txtPaletMalzemeNo);
                        }

                        


                    } 
                    else if (ekranTipi == "malzeme") {
                        WS_Kontrol.ZKtWmWsCikisMatnrKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisMatnrKontrol();
                        WS_Kontrol.ZKtWmWsCikisMatnrKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsCikisMatnrKontrolResponse();

                        chk.IvEan = txtPaletMalzemeNo.Text.ToString().Trim();
                        chk.IvLgpla = txtAdresNo.Text.ToString().Trim();

                        resp = srv.ZKtWmWsCikisMatnrKontrol(chk);
                        stok = resp.EsStok;


                        if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                        {
                            txtPaletNo.Text = "";
                            txtMalzemeNo.Text = malzemeNo = Convert.ToInt64(stok.Matnr.ToString()).ToString();
                            txtMalzemeTanimi.Text = stok.Maktx.ToString();
                            txtToplamMiktar.Text = stok.Miktar.ToString();
                            txtOlcuBirimi.Text = stok.Meins.ToString();
                            txtStokTipi.Text = stok.Bestq.ToString();

                            txtMiktar.Enabled = true;
                            txtMiktar.BackColor = Color.White;
                            Utility.selectText(txtMiktar);
                        }
                        else
                        {
                            MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                            Utility.selectText(txtPaletMalzemeNo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_12_15_Genel_Cikis_Islemleri_Formlari_txtPaletMalzemeNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }


            }
            logger.info("frm_12_15_Genel_Cikis_Islemleri_Formlari_txtPaletMalzemeNo_KeyDown end");
        }


        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_12_15_Genel_Cikis_Islemleri_Formlari_btn_Kaydet_Click begin");
            if (txtMiktar.Text.Trim() == "")
            {
                return;
            }

            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                Utility.selectText(txtMiktar);
            }
            
            
            if (!(miktar > 0))
            {
                return;
            }


            Cursor.Current = Cursors.WaitCursor;
            try
            {

                if (islemTuru == "iadeCikisi")
                {
                    WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                    WS_Islem.ZKtWmWsSatIadeCikisi chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSatIadeCikisi();
                    WS_Islem.ZKtWmWsSatIadeCikisiResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSatIadeCikisiResponse();
                    

                    if (ekranTipi == "palet")
                    {
                        chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                    }
                    else
                    {
                        chk.IvLenum = "";
                    }
                    chk.IvMatnr = malzemeNo;
                    chk.IvMiktar = miktar;
                    chk.IvLgpla = txtAdresNo.Text.ToString().Trim();

                    

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    resp = srv.ZKtWmWsSatIadeCikisi(chk);

                    if (resp.EsResponse.Length > 0)
                    {
                        //Mesajlar düzenleniyor
                        GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                        GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                        if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                            Utility.selectText(txtAdresNo);
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
                            Utility.selectText(txtAdresNo);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                    }



                    
                }
                else if (islemTuru == "hurdaCikisi")
                {
                    WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                    WS_Islem.ZKtWmWsHurdaCikisi chk = new KoctasWM_Project.WS_Islem.ZKtWmWsHurdaCikisi();
                    WS_Islem.ZKtWmWsHurdaCikisiResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsHurdaCikisiResponse();

                    if (ekranTipi == "palet")
                    {
                        chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                    }
                    else
                    {
                        chk.IvLenum = "";
                    }
                    chk.IvMatnr = malzemeNo;
                    chk.IvMiktar = miktar;
                    chk.IvLgpla = txtAdresNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    resp = srv.ZKtWmWsHurdaCikisi(chk);

                    if (resp.EsResponse.Length > 0)
                    {
                        //Mesajlar düzenleniyor
                        GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                        GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                        if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                            Utility.selectText(txtAdresNo);
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
                            Utility.selectText(txtAdresNo);
                        }

                    }
                    else
                    {
                        MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                    }
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_12_15_Genel_Cikis_Islemleri_Formlari_btn_Kaydet_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_12_15_Genel_Cikis_Islemleri_Formlari_btn_Kaydet_Click end");
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