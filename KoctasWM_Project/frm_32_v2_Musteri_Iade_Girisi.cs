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
    public partial class frm_32_v2_Musteri_Iade_Girisi : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_32_v2_Musteri_Iade_Girisi).Name);
        public frm_32_v2_Musteri_Iade_Girisi()
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

        WS_Kontrol.ZktWmStWebsipno2RfcExp[] _webSip;

        string _malzemeNo;

        private void formAcilisDuzenle()
        {
            secilenSatir = -1;
            _siparisKabulMiktar = -1;
            _siparisDegisimMiktar = -1;
            _siparisToplamMiktar = 0;
            _onerilenTutarKontrol = false;
            _onerilenTutarDegeri = 0;

            txtKabulMiktar.Text = "";
            txtMalzemeNo.Text = "";
            txtIadeTuru.Text = "";
            txtDurum.Text = "";

            txtKabulMiktar.Enabled = false;
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

 
        private void txtSiparisNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'b');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
        }


        private void txtKabulMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'b');
        }

        private void txtAciklama_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
        }


        private void txtSiparisNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_32_v2_Musteri_Iade_Girisi_txtSiparisNo_KeyDown begin");

            if (e.KeyCode == Keys.Enter)
            {
                if (txtSiparisId.Text.ToString().Trim() == "")
                {
                    return;
                }

                txtSiparisId.Text = txtSiparisId.Text.ToString().Trim().ToUpper();
                _siparisId = txtSiparisId.Text.ToString().Trim();

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsWebsipno2 chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsWebsipno2();
                    WS_Kontrol.ZKtWmWsWebsipno2Response resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsWebsipno2Response();
                    WS_Kontrol.ZktWmStWebsipno2RfcExp[] webSip = new KoctasWM_Project.WS_Kontrol.ZktWmStWebsipno2RfcExp[0];

                    chk.IvVbeln = _siparisId;
      
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsWebsipno2(chk);



                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        int count = resp.EtTable.Length;
                        _webSip = new KoctasWM_Project.WS_Kontrol.ZktWmStWebsipno2RfcExp[count];
                        _webSip = resp.EtTable;



                        _siparis.Rows.Clear();

                        for (int i = 0; i < count; i++)
                        {

                            if (resp.EtTable[i].Kargo.ToString().ToUpper() != "X")
                            {
                                DataRow row = _siparis.NewRow();
                                row["Matnr"] = Convert.ToInt64(resp.EtTable[i].Matnr.ToString().ToString());
                                row["Meins"] = resp.EtTable[i].Meins.ToString();
                                row["Kwmeng"] = resp.EtTable[i].Kwmeng.ToString();
                                row["Posnr"] = resp.EtTable[i].Posnr.ToString();
                                row["Kargo"] = resp.EtTable[i].Kargo.ToString();
                                row["Vbeln"] = resp.EtTable[i].Vbeln.ToString();
                                row["Iadetip"] = resp.EtTable[i].Iadetip.ToString();
                                row["Durum"] = resp.EtTable[i].Durum.ToString();


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
                    logger.error("frm_32_v2_Musteri_Iade_Girisi_txtSiparisNo_KeyDown " + ex.Message);
                
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            logger.info("frm_32_v2_Musteri_Iade_Girisi_txtSiparisNo_KeyDown end");
        }


        private void txtKabulMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    _siparisKabulMiktar = Convert.ToDecimal(txtKabulMiktar.Text.ToString().Trim());
                    btn_Ekle_Click(new object(), new EventArgs());
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

            
            /*
            if (!(_siparisKabulMiktar > 0))
            {
                return;
            }*/

            if ((_siparisKabulMiktar) > _siparisToplamMiktar)
            {
                MessageBox.Show("Kabul miktar, toplam siparişteki teslimat miktarından büyük olamaz", "HATA");
                Utility.selectText(txtKabulMiktar);
                return;
            }

            try
            {
                //Kabul miktarı _siparis tablosuna işleniyor
                _siparis.Rows[secilenSatir]["kabulMiktar"] = _siparisKabulMiktar.ToString();
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

                                txtKabulMiktar.Text = _siparis.Rows[i]["kabulMiktar"].ToString();
                                _siparisToplamMiktar = Convert.ToDecimal(_siparis.Rows[i]["Kwmeng"].ToString());
                                string iadeTuru = "";
                                string durum = "";
                                iadeTuru = _siparis.Rows[i]["Iadetip"].ToString().Trim();
                                durum = _siparis.Rows[i]["Durum"].ToString().Trim();
                                txtIadeTuru.Text = iadeTuru;
                                txtDurum.Text = durum;

                                btn_Ekle.Enabled = true;
                                txtKabulMiktar.Enabled = true;
                                Utility.selectText(txtKabulMiktar);
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
                        MessageBox.Show("Sipariş tablosu boş. Önce İade Sipariş No okutunuz.", "HATA");
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
            logger.info("frm_32_v2_Musteri_Iade_Girisi_btn_Kaydet_Click begin");

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
                int _siparisSayisi = webSipSayisi();

                //Webservice işlemleri
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsWebiadeKabul2 chk = new KoctasWM_Project.WS_Islem.ZKtWmWsWebiadeKabul2();
                WS_Islem.ZKtWmWsWebiadeKabul2Response resp = new KoctasWM_Project.WS_Islem.ZKtWmWsWebiadeKabul2Response();

                //int islemSayisi = websiparisIslemSayisiGetir();
                int islemSayisi = _webSip.Length;
                WS_Islem.ZktWmStWebsipno2RfcExp[] webSip = new KoctasWM_Project.WS_Islem.ZktWmStWebsipno2RfcExp[islemSayisi];

                int islemSay = 0;
                for (int i = 0; i < _siparis.Rows.Count; i++)
                {
                    if (_siparis.Rows[i]["islemYapildi"].ToString() == "X")
                    {
                        webSip[islemSay] = new KoctasWM_Project.WS_Islem.ZktWmStWebsipno2RfcExp();

            
                        webSip[islemSay].Matnr = Convert.ToInt64(_siparis.Rows[i]["Matnr"].ToString()).ToString();
                        webSip[islemSay].Meins = _siparis.Rows[i]["Meins"].ToString();
                        webSip[islemSay].Kwmeng = Convert.ToDecimal(_siparis.Rows[i]["Kwmeng"].ToString());
                        webSip[islemSay].Kmenge = Convert.ToDecimal(_siparis.Rows[i]["kabulMiktar"].ToString());
                        webSip[islemSay].Vbeln = _siparis.Rows[i]["Vbeln"].ToString();
                        webSip[islemSay].Kargo = _siparis.Rows[i]["Kargo"].ToString();
                        webSip[islemSay].Durum = _siparis.Rows[i]["Durum"].ToString();
                        webSip[islemSay].Iadetip = _siparis.Rows[i]["Iadetip"].ToString();
                        webSip[islemSay].Posnr = _siparis.Rows[i]["Posnr"].ToString();

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
                        webSip[islemSay] = new KoctasWM_Project.WS_Islem.ZktWmStWebsipno2RfcExp();

                        webSip[islemSay].Matnr = Convert.ToInt64(_webSip[i].Matnr.ToString()).ToString();
                        webSip[islemSay].Meins = _webSip[i].Meins.ToString();
                        webSip[islemSay].Kwmeng = _webSip[i].Kwmeng;
                        webSip[islemSay].Kmenge = _webSip[i].Kmenge;
                        webSip[islemSay].Vbeln = _webSip[i].Vbeln.ToString();
                        webSip[islemSay].Iadetip = _webSip[i].Iadetip.ToString();
                        webSip[islemSay].Durum = _webSip[i].Durum.ToString();
                        webSip[islemSay].Posnr = _webSip[i].Posnr.ToString();
                        webSip[islemSay].Kargo = _webSip[i].Kargo.ToString();

                        islemSay++;

                    }
                }
         

                chk.ItWebsid = webSip;
                //chk.LvWebkrgt = _onerilenTutarDegeri;
                WS_Islem.ZktWmStSarf[] _saf = new KoctasWM_Project.WS_Islem.ZktWmStSarf[1];
                chk.EtSarf = _saf;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsWebiadeKabul2(chk);
                



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
                logger.error("frm_32_v2_Musteri_Iade_Girisi_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_32_v2_Musteri_Iade_Girisi_btn_Kaydet_Click end");
        }

        
        private void txtSiparisNo_GotFocus_1(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_WebSiparisId, 'w');
            Utility.setBackBolor(p2, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_KabulMiktar, 'p');
        }

        private void frm_32_v2_Musteri_Iade_Girisi_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Maximized;

            Utility.loginInfo(lbl_LoginInfo);

            _onerilenTutarKontrol = false;

            _siparis = new DataTable();
            _siparis.Columns.Add("Iadetip");
            _siparis.Columns.Add("Kargo");
            _siparis.Columns.Add("KMenge");
            _siparis.Columns.Add("Kwmeng");
            _siparis.Columns.Add("Matnr");
            _siparis.Columns.Add("Meins");
            _siparis.Columns.Add("Posnr");
            _siparis.Columns.Add("Vbeln");
            _siparis.Columns.Add("Durum");

            _siparis.Columns.Add("kabulMiktar");
            _siparis.Columns.Add("islemYapildi");


            Utility.selectText(txtSiparisId);
        }

       


    }
}