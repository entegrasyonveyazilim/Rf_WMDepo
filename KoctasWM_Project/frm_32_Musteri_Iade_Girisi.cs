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
    public partial class frm_32_Musteri_Iade_Girisi : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_32_Musteri_Iade_Girisi).Name);
        public frm_32_Musteri_Iade_Girisi()
        {
            InitializeComponent();
        }

        public string _siparisId;
        public string _siparisNo;
        DataTable _siparis;
        decimal _siparisToplamMiktar;
        decimal _siparisKabulMiktar = -1;
        decimal _siparisDegisimMiktar = -1;
        int secilenSatir = -1;
        bool _onerilenTutarKontrol;
        decimal _onerilenTutarDegeri;

        WS_Kontrol.ZktWmWebsid[] _webSip;

        string _malzemeNo;

        private void formAcilisDuzenle()
        {
            secilenSatir = -1;
            _siparisKabulMiktar = -1;
            _siparisDegisimMiktar = -1;
            _siparisToplamMiktar = 0;
            _onerilenTutarKontrol = false;
            _onerilenTutarDegeri = 0;

            txtSAPIadeSiparisNo.Text = "";
            txtKabulMiktar.Text = "";
            txtDegisimMiktar.Text = "";
            txtMalzemeNo.Text = "";

            txtSiparisNo.Enabled = false;
            txtKabulMiktar.Enabled = false;
            txtDegisimMiktar.Enabled = false;
            txtAciklama.Text = "";
            txtAciklama.Enabled = false;
            btn_Ekle.Enabled = false;
        }

        private bool girisKontrol()
        {
            if (_siparis.Rows.Count > 0)
            {
                for (int i = 0; i < _siparis.Rows.Count; i++)
                {
                    if (_siparis.Rows[i]["islemYapildi"].ToString() == "X")
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (_webSip.Length > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool butunListeKontrol()
        {
            int listeSay = 0;
            
            if (_siparis.Rows.Count > 0)
            {
                for (int i = 0; i < _siparis.Rows.Count; i++)
                {
                    if (_siparis.Rows[i]["islemYapildi"].ToString() == "X")
                    {
                        listeSay++;
                    }
                }
            }

            if (listeSay == _siparis.Rows.Count)
            {
                return true;
            }
 

            return false;
        }

        private int websiparisIslemSayisiGetir()
        {
            int siparisSay = 0;
            if (_siparis.Rows.Count > 0)
            {
                for (int i = 0; i < _siparis.Rows.Count; i++)
                {
                    if (_siparis.Rows[i]["islemYapildi"].ToString() == "X")
                    {
                        siparisSay++;
                    }
                }
            }

            return siparisSay;
        }
        
        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_32_Musteri_Iade_Girisi_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Maximized;

            Utility.loginInfo(lbl_LoginInfo);

            _onerilenTutarKontrol = false;

            _siparis = new DataTable();
            _siparis.Columns.Add("Aciklama");
            _siparis.Columns.Add("Matnr");
            _siparis.Columns.Add("Meins");
            _siparis.Columns.Add("Menge");
            _siparis.Columns.Add("Vbelns");
            _siparis.Columns.Add("Webklm");
            _siparis.Columns.Add("Websid");
            _siparis.Columns.Add("Websip");
            _siparis.Columns.Add("Kargo");
            _siparis.Columns.Add("Webuid");
            _siparis.Columns.Add("kabulMiktar");
            _siparis.Columns.Add("degisimMiktar");
            _siparis.Columns.Add("islemYapildi");
            _siparis.Columns.Add("Iadetip");

            Utility.selectText(txtSiparisId);

        }


        private void txtSiparisNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'b');
            Utility.setBackBolor(p5, lbl_WebSiparisNo, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
            Utility.setBackBolor(p3, lbl_DegisimMiktari, 'p');
            Utility.setBackBolor(p4, lb_Aciklama, 'p');
        }


        private void txtKabulMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p5, lbl_WebSiparisNo, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'b');
            Utility.setBackBolor(p3, lbl_DegisimMiktari, 'b');
            Utility.setBackBolor(p4, lb_Aciklama, 'p');
        }

        private void txtAciklama_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p5, lbl_WebSiparisNo, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
            Utility.setBackBolor(p3, lbl_DegisimMiktari, 'p');
            Utility.setBackBolor(p4, lb_Aciklama, 'b');
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p5, lbl_WebSiparisNo, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
            Utility.setBackBolor(p3, lbl_DegisimMiktari, 'p');
            Utility.setBackBolor(p4, lb_Aciklama, 'p');
        }


        private void txtSiparisNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSiparisId.Text.ToString().Trim() == "")
                {
                    return;
                }

                _siparisId = txtSiparisId.Text.ToString().Trim();
                txtSiparisNo.Enabled = true;
                Utility.selectText(txtSiparisNo);
            }
        }


        private void txtKabulMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    _siparisKabulMiktar = Convert.ToDecimal(txtKabulMiktar.Text.ToString().Trim());
                    Utility.selectText(txtDegisimMiktar);
                }
                catch
                {
                    MessageBox.Show("Kabul miktarı olarak yanlızca rakam giriniz", "HATA");
                    Utility.selectText(txtKabulMiktar);
                }
            }
            
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {

            try
            {
                _siparisKabulMiktar = Convert.ToDecimal(txtKabulMiktar.Text.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Kabul miktarı olarak yanlızca rakam giriniz", "HATA");
                Utility.selectText(txtKabulMiktar);
                return;
            }

            try
            {
                _siparisDegisimMiktar = Convert.ToDecimal(txtDegisimMiktar.Text.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Değişim miktarı olarak yanlızca rakam giriniz", "HATA");
                Utility.selectText(txtDegisimMiktar);
                return;
            }

            /*
            if (!(_siparisKabulMiktar > 0))
            {
                return;
            }*/

            if ((_siparisKabulMiktar + _siparisDegisimMiktar) > _siparisToplamMiktar)
            {
                MessageBox.Show("Kabul ve değişim miktarı toplamı, toplam siparişteki teslimat miktarından büyük olamaz", "HATA");
                Utility.selectText(txtKabulMiktar);
                return;
            }
            
            try
            {
                //Kabul miktarı _siparis tablosuna işleniyor
                _siparis.Rows[secilenSatir]["kabulMiktar"] = _siparisKabulMiktar.ToString();
                _siparis.Rows[secilenSatir]["degisimMiktar"] = _siparisDegisimMiktar.ToString();
                _siparis.Rows[secilenSatir]["Aciklama"] = txtAciklama.Text.ToString().Trim();
                _siparis.Rows[secilenSatir]["islemYapildi"] = "X";

                grd_List.DataSource = null;
                grd_List.DataSource = _siparis;
                formAcilisDuzenle();

                Utility.selectText(txtMalzemeNo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        private void txtAciklama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Ekle_Click(new object(), new EventArgs());
            }
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    string _eanMalzemeNo = txtMalzemeNo.Text.ToString().Trim();
                    bool buldum = false;


                    //Malzeme No veya EAN matnr ye çeviriliyor

                    _malzemeNo = Convert.ToInt64(Utility.malzemeNoGetir(_eanMalzemeNo, "matnr")).ToString();

                    //Malzeme No tabloda var mı kontrol ediliyor
                    if (_siparis.Rows.Count > 0)
                    {
                        for (int i = 0; i < _siparis.Rows.Count; i++)
                        {
                            if (_siparis.Rows[i]["Matnr"].ToString() == _malzemeNo)
                            {
                                buldum = true;
                                //Bulunan malzeme detayları ekrana yazılıyor
                                secilenSatir = i;

                                txtSAPIadeSiparisNo.Text = _siparis.Rows[i]["Vbelns"].ToString();
                                txtKabulMiktar.Text = _siparis.Rows[i]["kabulMiktar"].ToString();
                                txtDegisimMiktar.Text = _siparis.Rows[i]["degisimMiktar"].ToString();
                                txtAciklama.Text = _siparis.Rows[i]["Aciklama"].ToString();
                                _siparisToplamMiktar = Convert.ToDecimal(_siparis.Rows[i]["Menge"].ToString());
                                string iadeTuru = "";
                                iadeTuru = _siparis.Rows[i]["Iadetip"].ToString().Trim();
                                txtIadeTuru.Text = iadeTuru;


                                
                                txtAciklama.Enabled = true;
                                btn_Ekle.Enabled = true;

                                if (iadeTuru == "")
                                {
                                    txtKabulMiktar.Enabled = true;
                                    txtDegisimMiktar.Enabled = true;
                                    txtKabulMiktar.Text = "";
                                    txtDegisimMiktar.Text = "";
                                    Utility.selectText(txtKabulMiktar);
                                }
                                else if (iadeTuru == "D")
                                {
                                    txtKabulMiktar.Enabled = false;
                                    txtDegisimMiktar.Enabled = true;
                                    txtKabulMiktar.Text = "0";
                                    Utility.selectText(txtDegisimMiktar);
                                }
                                else if (iadeTuru == "I")
                                {
                                    txtKabulMiktar.Enabled = true;
                                    txtDegisimMiktar.Enabled = false;
                                    txtDegisimMiktar.Text = "0";
                                    Utility.selectText(txtKabulMiktar);
                                }
                                
                                
                                
                            }
                        }

                        if (!buldum)
                        {
                            MessageBox.Show("Okuttuğunuz malzeme sipariş tablosunda bulunamadı.", "HATA");
                            txtMalzemeNo.Text = "";
                            Utility.selectText(txtMalzemeNo);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Sipariş tablosu boş. Önce Web Sipariş No okutunuz.", "HATA");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "HATA");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                
                

            }
        }

        private int webSipSayisi()
        {
            int siparisSayisi = 0;

            for (int i = 0; i < _siparis.Rows.Count; i++)
            {
                //matnr:kabulMiktar|degisimMiktar|iadeMiktar,....
                if ((_siparis.Rows[i]["islemYapildi"].ToString() == "X") && (_siparis.Rows[i]["Kargo"].ToString().ToUpper() != "X"))
                {
                    siparisSayisi++;
                }
            }

            return siparisSayisi;
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {

            logger.info("frm_32_Musteri_Iade_Girisi_btn_Kaydet_Click begin");
            
            try
            {

                if (!girisKontrol())
                {
                    MessageBox.Show("Henüz herhangi bir iade girişi yapmadınız", "HATA");
                    return;
                }

                if (!butunListeKontrol())
                {
                    MessageBox.Show("Siparişteki tüm malzemeleri okutmadınız.", "HATA");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                
                //Pozisitif webPost işlemi yapılıyor
                //.......
                string products = "";
                string[] _arrProducts = new string[5];
                int _siparisSayisi = webSipSayisi();
                int _siparisIndeks = 0;
                string[] _siparisProducts = new string[_siparisSayisi];

                //products stringi hazırlanıyor
                for (int i = 0; i < _siparis.Rows.Count; i++)
                {
                    //matnr:kabulMiktar|degisimMiktar|iadeMiktar,....
                    if ((_siparis.Rows[i]["islemYapildi"].ToString() == "X") && (_siparis.Rows[i]["Kargo"].ToString().ToUpper() != "X"))
                    {
                        decimal toplamMiktar = Convert.ToDecimal(_siparis.Rows[i]["Menge"].ToString());
                        decimal kabulMiktar = Convert.ToDecimal(_siparis.Rows[i]["kabulMiktar"].ToString());
                        decimal degisimMiktar = Convert.ToDecimal(_siparis.Rows[i]["degisimMiktar"].ToString());
                        decimal iadeRedMiktari = toplamMiktar - (kabulMiktar + degisimMiktar);

                        _siparisProducts[_siparisIndeks] = _siparis.Rows[i]["Webuid"].ToString() + ":" + kabulMiktar.ToString() + "|" + degisimMiktar.ToString() + "|" + iadeRedMiktari.ToString();
                        _siparisIndeks++;
                    }
                }
               products = String.Join(",", _siparisProducts);

                
                
                _arrProducts = Utility.kargoOnerilenTutarGetir(_siparisId, _siparisNo, products);

                if (_arrProducts[3].ToString().Trim() != "")
                {
                    _onerilenTutarKontrol = true;
                    _onerilenTutarDegeri = Convert.ToDecimal(_arrProducts[3].ToString());
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    return;
                }

                /*
                _onerilenTutarKontrol = true;
                _onerilenTutarDegeri = 1;
                */
                
                //Webservice işlemleri
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsWebiadeKabul chk = new KoctasWM_Project.WS_Islem.ZKtWmWsWebiadeKabul();
                WS_Islem.ZKtWmWsWebiadeKabulResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsWebiadeKabulResponse();

                //int islemSayisi = websiparisIslemSayisiGetir();
                int islemSayisi = _webSip.Length;
                WS_Islem.ZktWmWebsid[] webSip = new KoctasWM_Project.WS_Islem.ZktWmWebsid[islemSayisi];

                int islemSay = 0;
                for (int i = 0; i < _siparis.Rows.Count; i++)
                {
                    if (_siparis.Rows[i]["islemYapildi"].ToString() == "X")
                    {
                        webSip[islemSay] = new KoctasWM_Project.WS_Islem.ZktWmWebsid();
                        
                        webSip[islemSay].Aciklama = _siparis.Rows[i]["Aciklama"].ToString();
                        webSip[islemSay].Matnr = Convert.ToInt64(_siparis.Rows[i]["Matnr"].ToString()).ToString();
                        webSip[islemSay].Meins = _siparis.Rows[i]["Meins"].ToString();
                        webSip[islemSay].Menge = Convert.ToDecimal(_siparis.Rows[i]["Menge"].ToString());
                        webSip[islemSay].Kmenge = Convert.ToDecimal(_siparis.Rows[i]["kabulMiktar"].ToString());
                        webSip[islemSay].Dmenge = Convert.ToDecimal(_siparis.Rows[i]["degisimMiktar"].ToString());
                        webSip[islemSay].Vbelns = _siparis.Rows[i]["Vbelns"].ToString();
                        webSip[islemSay].Webklm = _siparis.Rows[i]["Webklm"].ToString();
                        webSip[islemSay].Websid = _siparis.Rows[i]["Websid"].ToString();
                        webSip[islemSay].Websip = _siparis.Rows[i]["Websip"].ToString();
                        webSip[islemSay].Kargo = _siparis.Rows[i]["Kargo"].ToString();
                        webSip[islemSay].Webuid = _siparis.Rows[i]["Webuid"].ToString();
                        webSip[islemSay].Webkrgt = 0;

                        islemSay++;
                    }
                }


                //_webSip ile gelen Kargo=X satırları işleniyor
                for (int i = 0; i < _webSip.Length; i++)
                {
                    string _matnr = Convert.ToInt64(_webSip[i].Matnr.ToString()).ToString();
                    bool buldum = false;
                    for (int j = 0; j < _siparis.Rows.Count; j++)
                    {
                        if (_matnr == _siparis.Rows[j]["Matnr"].ToString())
                        {
                            //Eğer ilgili kayıt _siparis tablosunda işlenmiş ise
                            buldum = true;
                            break;
                        }
                    }

                    //ilgili kayıt _siparis tablosunda bulunamaışsa
                    if (!buldum)
                    {
                        //Gönderilecek siparişlere ekleniyor, kabul miktarı gelen miktar ile eşleştiriliyor
                        webSip[islemSay] = new KoctasWM_Project.WS_Islem.ZktWmWebsid();

                        webSip[islemSay].Aciklama = _webSip[i].Aciklama.ToString();
                        webSip[islemSay].Matnr = Convert.ToInt64(_webSip[i].Matnr.ToString()).ToString();
                        webSip[islemSay].Meins = _webSip[i].Meins.ToString();
                        webSip[islemSay].Menge = _webSip[i].Menge;
                        webSip[islemSay].Kmenge = _webSip[i].Menge;
                        webSip[islemSay].Dmenge = 0;
                        webSip[islemSay].Vbelns = _webSip[i].Vbelns.ToString();
                        webSip[islemSay].Webklm = _webSip[i].Webklm.ToString();
                        webSip[islemSay].Websid = _webSip[i].Websid.ToString();
                        webSip[islemSay].Websip = _webSip[i].Websip.ToString();
                        webSip[islemSay].Kargo = _webSip[i].Kargo.ToString();
                        webSip[islemSay].Webuid = _webSip[i].Webuid.ToString();
                        webSip[islemSay].Webkrgt = _onerilenTutarDegeri;

                        islemSay++;

                    }
                }

                chk.ItWebsid = webSip;
                //chk.LvWebkrgt = _onerilenTutarDegeri;
                WS_Islem.ZktWmStSarf[] _saf = new KoctasWM_Project.WS_Islem.ZktWmStSarf[1];
                chk.EtSarf = _saf;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsWebiadeKabul(chk);

                


                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);

                        //İade sonrası, Sarfa Gidecek Ürünler formu
                        Cursor.Current = Cursors.Default;
                        frm_32_1_Sarfa_Gonderilecek_Urunler frm = new frm_32_1_Sarfa_Gonderilecek_Urunler();
                        frm._stk = resp.EtSarf;
                        frm._stokAdedi = resp.EtSarf.Length;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                        Cursor.Current = Cursors.Default;
                        return;
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
                logger.error("frm_32_Musteri_Iade_Girisi_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_32_Musteri_Iade_Girisi_btn_Kaydet_Click end");
        }

        private void txtDegisimMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    _siparisDegisimMiktar = Convert.ToDecimal(txtDegisimMiktar.Text.ToString().Trim());
                    Utility.selectText(txtAciklama);
                }
                catch
                {
                    MessageBox.Show("Değişim miktarı olarak yanlızca rakam giriniz", "HATA");
                    Utility.selectText(txtDegisimMiktar);
                }
            }
        }

        private void txtSiparisNo_GotFocus_1(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p5, lbl_WebSiparisNo, 'b');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
            Utility.setBackBolor(p3, lbl_DegisimMiktari, 'p');
            Utility.setBackBolor(p4, lb_Aciklama, 'p');
        }

        private void txtSiparisNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            logger.info("frm_32_Musteri_Iade_Girisi_txtSiparisNo_KeyDown_1 begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSiparisNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                txtSiparisNo.Text = txtSiparisNo.Text.ToString().Trim().ToUpper();
                _siparisNo = txtSiparisNo.Text;

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsWebsipno chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsWebsipno();
                    WS_Kontrol.ZKtWmWsWebsipnoResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsWebsipnoResponse();
                    WS_Kontrol.ZktWmWebsid[] webSip = new KoctasWM_Project.WS_Kontrol.ZktWmWebsid[0];

                    chk.ItWebsid = webSip;
                    chk.LvWebsid = _siparisId;
                    chk.LvWebsip = _siparisNo;


                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsWebsipno(chk);

                    

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        int count = resp.ItWebsid.Length;
                        _webSip = new KoctasWM_Project.WS_Kontrol.ZktWmWebsid[count];
                        _webSip = resp.ItWebsid;

                        _siparis.Rows.Clear();

                        for (int i = 0; i < count; i++)
                        {

                            if (resp.ItWebsid[i].Kargo.ToString().ToUpper() != "X")
                            {
                                DataRow row = _siparis.NewRow();
                                row["Aciklama"] = resp.ItWebsid[i].Aciklama.ToString();
                                row["Matnr"] = Convert.ToInt64(resp.ItWebsid[i].Matnr.ToString().ToString());
                                row["Meins"] = resp.ItWebsid[i].Meins.ToString();
                                row["Menge"] = resp.ItWebsid[i].Menge.ToString();
                                row["Vbelns"] = resp.ItWebsid[i].Vbelns.ToString();
                                row["Webklm"] = resp.ItWebsid[i].Webklm.ToString();
                                row["Websid"] = resp.ItWebsid[i].Websid.ToString();
                                row["Websip"] = resp.ItWebsid[i].Websip.ToString();
                                row["Kargo"] = resp.ItWebsid[i].Kargo.ToString();
                                row["Webuid"] = resp.ItWebsid[i].Webuid.ToString();
                                row["Iadetip"] = resp.ItWebsid[i].Iadetip.ToString();

                                row["kabulMiktar"] = "0";

                                _siparis.Rows.Add(row);
                            }
                        }

                        grd_List.DataSource = null;
                        grd_List.DataSource = _siparis;

                        txtMalzemeNo.Enabled = true;
                        Utility.selectText(txtMalzemeNo);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtSiparisId);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_32_Musteri_Iade_Girisi_txtSiparisNo_KeyDown_1 " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_32_Musteri_Iade_Girisi_txtSiparisNo_KeyDown_1 end");
        }


        
    }
}