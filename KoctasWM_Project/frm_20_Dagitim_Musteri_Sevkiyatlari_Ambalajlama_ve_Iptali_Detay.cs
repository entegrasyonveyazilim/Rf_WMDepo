using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoctasWM_Project
{
    public partial class frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay).Name);
        public frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay()
        {
            InitializeComponent();
        }

        DataTable _topla = new DataTable();
        DataTable _toplaSecondScreen = new DataTable();
        private int secondScreenDateGridIndex = 0;
        public DataTable _koliTipiTablo = new DataTable();
        public WS_Kontrol.ZktWmStAmbalaj[] _dagitimListesi;
        public string _Vbeln;
        decimal _Lfimg;
        string _Matnr;
        string _Meins;
        string _Posnr;
        string _koliTipi;
        string _koliTipiDesi;
        string _koliNo;


        decimal miktar;
        decimal kolilenenMiktar = 0;
        decimal toplamMiktar;

        bool koliDesiKontrol = false;

        private void formAcilisDuzenle()
        {

            txtMalzemeTanimi.Text = "";
            txtToplamMiktar.Text = "";
            txtKolilenenMiktar.Text = "";
            txtKolilenecekMiktar.Text = "";
            txtMalzemeNo.Text = "";
            txtKargoKoliNo.Text = "";
            txtDesiBilgisi.Text = "";

            kolilenenMiktar = 0;
            toplamMiktar = 0;

            txtKolilenecekMiktar.Enabled = false;
            cmbKoliTipi.Enabled = false;
            txtDesiBilgisi.Enabled = false;
            txtMalzemeNo.Enabled = false;
            btn_Onayla.Enabled = false;
            cmbKoliTipi.Text = "Seçiniz";

            Utility.selectText(txtKargoKoliNo);

        }

       
        private void koliTipiCek()
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_koliTipiCek begin");
            //Koli Tipleri Çekiliyor
            WS_Yardim.ZKT_WM_WS_YARDIMService srv = new KoctasWM_Project.WS_Yardim.ZKT_WM_WS_YARDIMService();
            WS_Yardim.ZKtWmWsKoliTipleri chk = new KoctasWM_Project.WS_Yardim.ZKtWmWsKoliTipleri();
            WS_Yardim.ZKtWmWsKoliTipleriResponse resp = new KoctasWM_Project.WS_Yardim.ZKtWmWsKoliTipleriResponse();

            srv.Credentials = GlobalData.globalCr;
            srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_yardim");
            resp = srv.ZKtWmWsKoliTipleri(chk);

            if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
            {
                int count = resp.EtKoliTipi.Length;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = _koliTipiTablo.NewRow();
                        row["desi"] = resp.EtKoliTipi[i].Desi;
                        row["koliTipi"] = resp.EtKoliTipi[i].KoliTipi.ToString();
                        row["tanim"] = resp.EtKoliTipi[i].Tanim.ToString();
                        _koliTipiTablo.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("Koli tipleri tablosu webservice üzerinden boş geldi.", "HATA");
                }

            }
            else
            {
                MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
            }
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_koliTipiCek end");
        }

        private void koliTipiDoldur()
        {
            //_koliTipiTablo.Reset();
            cmbKoliTipi.Items.Clear();
            if (_koliTipiTablo.Rows.Count > 0)
            {
                cmbKoliTipi.Items.Add("Seçiniz");
                for (int i = 0; i < _koliTipiTablo.Rows.Count; i++)
                {
                    cmbKoliTipi.Items.Add(_koliTipiTablo.Rows[i]["tanim"].ToString());
                }
            } 
        }

        private string koliTipiVer(string koliTanimi)
        {
            string koliTipi = "";
            if (koliTanimi != "")
            {
                //_koliTipiTablo.Reset();
                for (int i = 0; i < _koliTipiTablo.Rows.Count; i++)
                {
                    if (_koliTipiTablo.Rows[i]["tanim"].ToString() == koliTanimi.Trim().ToString())
                    {
                        koliTipi = _koliTipiTablo.Rows[i]["koliTipi"].ToString();
                    }
                }
            }
            return koliTipi;
        }

        private string koliTanimiVer(string koliTipi)
        {
            string koliTanimi = "";
            if (koliTipi != "")
            {
                for (int i = 0; i < _koliTipiTablo.Rows.Count; i++)
                {
                    if (_koliTipiTablo.Rows[i]["koliTipi"].ToString() == koliTipi.Trim().ToString())
                    {
                        koliTanimi = _koliTipiTablo.Rows[i]["tanim"].ToString();
                    }
                }
            }
            return koliTanimi;
        }

        private bool toplamMiktarKarsilastir()
        {
            decimal _toplam1 = 0;
            decimal _toplam2 = 0;
            
            //Dagitim listesindeki miktarlar toplaniyor
            for (int i = 0; i < _dagitimListesi.Length; i++)
            {
                _toplam1 += _dagitimListesi[i].Lfimg;
            }

            //Dagitim listesindeki miktarlar toplaniyor
            for (int i = 0; i < _topla.Rows.Count; i++)
            {
                _toplam2 += Convert.ToDecimal(_topla.Rows[i]["Menge"]);
            }

            if (_toplam1 == _toplam2)
            {
                return true;
            }
            
            return false;
        }

        private string koliTipiDesiVer(string koliTanimi)
        {
            string koliDesi = "";
            if (koliTanimi != "")
            {
                //_koliTipiTablo.Reset();
                for (int i = 0; i < _koliTipiTablo.Rows.Count; i++)
                {
                    if (_koliTipiTablo.Rows[i]["tanim"].ToString() == koliTanimi.Trim().ToString())
                    {
                        koliDesi = _koliTipiTablo.Rows[i]["desi"].ToString();
                    }
                }
            }
            return koliDesi;
        }

        private void frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_Load(object sender, EventArgs e)
        {

            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            _topla = new DataTable();
            _topla.Columns.Add("Desi");
            _topla.Columns.Add("KoliNo");
            _topla.Columns.Add("KoliTipi");
            _topla.Columns.Add("Lfimg");
            _topla.Columns.Add("Matnr");
            _topla.Columns.Add("Meins");
            _topla.Columns.Add("Menge");
            _topla.Columns.Add("Posnr");
            _topla.Columns.Add("VbelnVI");

            _koliTipiTablo = new DataTable();
            _koliTipiTablo.Columns.Add("desi");
            _koliTipiTablo.Columns.Add("koliTipi");
            _koliTipiTablo.Columns.Add("tanim");

            koliTipiCek();
            koliTipiDoldur();

            //cmbKoliTipi.Focus();

            Utility.selectText(txtKargoKoliNo);

        }


        private void txtKargoKoliNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoKoliNo, 'b');
            Utility.setBackBolor(p2, lbl_KoliTipi, 'w');
            Utility.setBackBolor(p2, lbl_DesiBilgisi, 'w');
            Utility.setBackBolor(p3, lbl_KolilenecekMiktar, 'p');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');

        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoKoliNo, 'w');
            Utility.setBackBolor(p2, lbl_KoliTipi, 'b');
            Utility.setBackBolor(p2, lbl_DesiBilgisi, 'b');
            Utility.setBackBolor(p3, lbl_KolilenecekMiktar, 'p');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoKoliNo, 'w');
            Utility.setBackBolor(p2, lbl_KoliTipi, 'b');
            Utility.setBackBolor(p2, lbl_DesiBilgisi, 'b');
            Utility.setBackBolor(p3, lbl_KolilenecekMiktar, 'p');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
        }

        private void txtKolilenecekMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoKoliNo, 'w');
            Utility.setBackBolor(p2, lbl_KoliTipi, 'w');
            Utility.setBackBolor(p2, lbl_DesiBilgisi, 'w');
            Utility.setBackBolor(p3, lbl_KolilenecekMiktar, 'b');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoKoliNo, 'w');
            Utility.setBackBolor(p2, lbl_KoliTipi, 'w');
            Utility.setBackBolor(p2, lbl_DesiBilgisi, 'w');
            Utility.setBackBolor(p3, lbl_KolilenecekMiktar, 'p');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'b');
        }

        private void kargoTipDesiBul(string kargoKoliNo)
        {
            bool buldum = false;
            if (_topla.Rows.Count > 0)
            {
                for (int i = 0; i < _topla.Rows.Count; i++)
                {
                    if (_topla.Rows[i]["KoliNo"].ToString() == kargoKoliNo)
                    {
                        _koliTipi = _topla.Rows[i]["KoliTipi"].ToString();
                        
                        //Koli tipi, tek koli ise girişe izin verme
                        if (_koliTipi == "26")
                        {
                            MessageBox.Show("Tek koliye birden fazla malzeme konulamaz. Lütfen farklı bir koli numarası giriniz.", "HATA");
                            Utility.selectText(txtKargoKoliNo);
                            return;
                        }
                        else
                        {
                            cmbKoliTipi.Text = koliTanimiVer(_koliTipi);
                            _koliTipiDesi = _topla.Rows[i]["Desi"].ToString();
                            txtDesiBilgisi.Text = _koliTipiDesi;
                            buldum = true;
                            Utility.selectText(txtMalzemeNo);
                        }
                    }
                }
            }
            //if (!buldum) cmbKoliTipi.Focus();
        }

        private void txtKargoKoliNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_txtKargoKoliNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtKargoKoliNo.Text.Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsAmbalajKontMlz chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontMlz();
                    WS_Kontrol.ZKtWmWsAmbalajKontMlzResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontMlzResponse();


                    chk.IvKoliNo = txtKargoKoliNo.Text.Trim().ToString();
                    chk.IvVbeln = _Vbeln;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsAmbalajKontMlz(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        cmbKoliTipi.Enabled = true;
                        _koliNo = txtKargoKoliNo.Text.Trim().ToString();
                        
                        kargoTipDesiBul(_koliNo);

                    }
                    else
                    {
                        txtKargoKoliNo.Text = "";
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtMalzemeNo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_txtKargoKoliNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    Utility.selectText(txtMalzemeNo);
                    txtMalzemeNo.Enabled = true;
                }
            }
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_txtKargoKoliNo_KeyDown end");
        }

        private void cmbKoliTipi_SelectedIndexChanged(object sender, EventArgs e)   //*
        {
            if (cmbKoliTipi.SelectedIndex == 0)
            {
                txtDesiBilgisi.Text = "";
                txtDesiBilgisi.Enabled = false;
                return;
            }

            string koliTanimi = cmbKoliTipi.Text.ToString();
            _koliTipi = koliTipiVer(koliTanimi);
            _koliTipiDesi = koliTipiDesiVer(koliTanimi);
            txtDesiBilgisi.Text = _koliTipiDesi.ToString();
            
            if (_koliTipi == "26")
            {
                // Tek Koli seçimi yapılmış demektir
                // desi bilgisi önce malzemeden sonra manual girişten alınacak.

                txtDesiBilgisi.Text = "Desi bilgisi için malzeme okutunuz.";
                txtDesiBilgisi.Enabled = false;
                txtKargoKoliNo.Enabled = true;
                txtMalzemeNo.Enabled = true;
                koliDesiKontrol = true;
                Utility.selectText(txtMalzemeNo);

            } 
            else if ((_koliTipiDesi != "") && (Convert.ToDecimal(_koliTipiDesi) != 0))
            {
                //Desi bilgisi dolu ise desi bilgisi yazılıyor
                txtDesiBilgisi.Text = _koliTipiDesi.ToString();
                txtDesiBilgisi.Enabled = false;
                txtKargoKoliNo.Enabled = true;
                txtMalzemeNo.Enabled = true;
                koliDesiKontrol = false;
                Utility.selectText(txtMalzemeNo);
            }
            else
            {
                //Mix koli seçimi yapılmış demektir.
                txtDesiBilgisi.Text = _koliTipiDesi.ToString();
                txtDesiBilgisi.Enabled = true;
                txtMalzemeNo.Enabled = false;
                koliDesiKontrol = false;
                Utility.selectText(txtDesiBilgisi);
            }
            
            
        }

        private void txtDesiBilgisi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDesiBilgisi.Text.Trim().ToString() == "")
                {
                    return;
                }

                _koliTipiDesi = txtDesiBilgisi.Text.ToString().Trim();
                if (!(Convert.ToDecimal(_koliTipiDesi) > 0))
                {
                    MessageBox.Show("Desi bilgisi sıfırdan büyük olmalı", "HATA");
                    Utility.selectText(txtDesiBilgisi);
                    return;
                }


                txtMalzemeNo.Enabled = true;
                Utility.selectText(txtMalzemeNo);

            }
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    if (koliDesiKontrol)
                    {
                        WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv1 = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                        WS_Islem.ZKtWmWmMalzemeInfo chk1 = new KoctasWM_Project.WS_Islem.ZKtWmWmMalzemeInfo();
                        WS_Islem.ZKtWmWmMalzemeInfoResponse resp1 = new KoctasWM_Project.WS_Islem.ZKtWmWmMalzemeInfoResponse();


                        chk1.IvEan = txtMalzemeNo.Text.ToString().Trim();

                        srv1.Credentials = GlobalData.globalCr;
                        srv1.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                        resp1 = srv1.ZKtWmWmMalzemeInfo(chk1);


                        if (resp1.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                        {
                            if (resp1.EsMalzeme.Desi > 0)
                            {
                                txtDesiBilgisi.Text = resp1.EsMalzeme.Desi.ToString();
                            }
                            else
                            {
                                txtDesiBilgisi.Enabled = true;
                                MessageBox.Show("Desi bilgisi giriniz", "HATA");
                                txtDesiBilgisi.Text = "";
                                Utility.selectText(txtKolilenecekMiktar);
                            }
                        }
                        else
                        {
                            txtDesiBilgisi.Enabled = true;
                            MessageBox.Show("Desi bilgisi giriniz", "HATA");
                            Utility.selectText(txtKolilenecekMiktar);
                        }
                    }
                    
                    
                  
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsAmbalajKontKoli chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontKoli();
                    WS_Kontrol.ZKtWmWsAmbalajKontKoliResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontKoliResponse();


                    chk.IvEan = txtMalzemeNo.Text.ToString().Trim();
                    chk.IvVbeln = _Vbeln;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsAmbalajKontKoli(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        // eğer malzeme kontrolü sağlanmış ise
                        // _dagitimListesi tablosundan ilgili malzeme çekiliyor

                        //Okutulan değer matnr ye çeviriliyor.
                        string malzemeNo = Utility.malzemeNoGetir(txtMalzemeNo.Text.ToString().Trim(), "matnr");

                        bool buldum = false;
                        for (int i = 0; i < _dagitimListesi.Length; i++)
                        {
                            if (_dagitimListesi[i].Matnr.ToString().Trim() == malzemeNo)
                            {
                                
                                
                                toplamMiktar = _dagitimListesi[i].Lfimg;
                                kolilenenMiktar = eklenenMalzemeSayisiVer(malzemeNo.ToString().Trim(), _dagitimListesi[i].Posnr.ToString()); //daha önce kolilenen miktar çekiliyor

                                if (kolilenenMiktar != toplamMiktar)
                                {
                                    txtMalzemeTanimi.Text = _dagitimListesi[i].Maktx.ToString();
                                    
                                    txtToplamMiktar.Text = toplamMiktar.ToString();
                                    txtKolilenenMiktar.Text = kolilenenMiktar.ToString();

                                    _Lfimg = Convert.ToDecimal(_dagitimListesi[i].Lfimg);
                                    _Matnr = _dagitimListesi[i].Matnr;
                                    _Meins = _dagitimListesi[i].Meins;
                                    _Posnr = _dagitimListesi[i].Posnr;
                                    //_Vbeln = _dagitimListesi[i].Vbeln;

                                    buldum = true;
                                }

                                if (buldum) break;
                                
                            }
                        }

                        if (buldum)
                        {
                            txtKolilenecekMiktar.Enabled = true;
                            btn_Onayla.Enabled = true;
                            btn_next.Enabled = true;
                            Utility.selectText(txtKolilenecekMiktar);
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen malzeme, dağıtım adresi tablosunda bulunamadı", "HATA");
                            Utility.selectText(txtMalzemeNo);
                        }

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
                    logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_txtMalzemeNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_txtMalzemeNo_KeyDown end");
        }

        private void btn_Onayla_Click(object sender, EventArgs e)
        {
            try
            {
                miktar = Convert.ToDecimal(txtKolilenecekMiktar.Text);
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal bir değer giriniz", "HATA");
                Utility.selectText(txtKolilenecekMiktar);
                return;
            }

            //try
            //{
            //    _koliTipiDesi = txtDesiBilgisi.Text.ToString().Trim();
            //    if (!(Convert.ToDecimal(_koliTipiDesi) > 0))
            //    {
            //        MessageBox.Show("Desi bilgisi sıfırdan büyük olmalı", "HATA");
            //        Utility.selectText(txtDesiBilgisi);
            //        return;
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Desi bilgisi alanı sayısal bir değer olmalıdır", "HATA");
            //    Utility.selectText(txtDesiBilgisi);
            //    return;
            //}

            if (!(miktar > 0))
            {
                MessageBox.Show("Miktar alanı sıfırdan büyük olmalı", "HATA");
                return;
            }


            if ((kolilenenMiktar + miktar) > toplamMiktar)
            {
                MessageBox.Show("Kolilemek istediğiniz toplam miktar, dağıtım adresindeki toplam miktardan fazla olamaz", "HATA");
                Utility.selectText(txtKolilenecekMiktar);
                return;
            }

            //Malzeme _topla sepetine ekleniyor
            //Malzeme _topla sepetine daha önce eklenmiş mi?
            bool yeni = true;
            //_topla.Reset();
            for (int i = 0; i < _topla.Rows.Count; i++)
            {
                //Daha once _topla tablosuna eklendiyse, miktar değiştiriliyor
                if ((_topla.Rows[i]["Matnr"].ToString() == _Matnr) && (_topla.Rows[i]["KoliNo"].ToString() == _koliNo) && (_topla.Rows[i]["Posnr"].ToString() == _Posnr))
                {
                    yeni = false;
                    if (_koliTipi == "26")
                    {
                        MessageBox.Show("Tek koliye birden fazla malzeme konulamaz.", "HATA");
                        return;
                    }
                    else
                    {
                        _topla.Rows[i]["Menge"] = Convert.ToDecimal(_topla.Rows[i]["Menge"]) + miktar;
                    }
                    
                }
            }

            //Eğer _topla tablosunda daha önce eklenmemiş ise, yeni satır oluşturuluyor
            if (yeni)
            {
                DataRow row = _topla.NewRow();
                row["Desi"] = txtDesiBilgisi.Text;
                row["KoliNo"] = txtKargoKoliNo.Text.ToString().Trim();
                row["KoliTipi"] = _koliTipi;
                row["Lfimg"] = toplamMiktar;
                row["Matnr"] = _Matnr;
                row["Meins"] = _Meins;
                row["Menge"] = miktar;
                row["Posnr"] = _Posnr;
                row["VbelnVI"] = _Vbeln;

                _topla.Rows.Add(row);
            }
            
            
            //Son kolilenen miktar ekrana yazılıyor
            txtKolilenenMiktar.Text = kolilenenMiktar.ToString();
            formAcilisDuzenle();

        }

        public decimal eklenenMalzemeSayisiVer(string malzNo, string kalemNo)
        {
            decimal eklenenMalzemeSayisi = 0;

            malzNo = malzNo.ToString().Trim();
            if (malzNo != "")
            {
                //_topla.Reset();
                for (int i = 0; i < _topla.Rows.Count; i++)
                {
                    //Daha önce eklenen miktar bulunuyor
                    if ((_topla.Rows[i]["Matnr"].ToString() == malzNo.PadLeft(18, '0')) && (_topla.Rows[i]["Posnr"].ToString() == kalemNo))
                    {
                        eklenenMalzemeSayisi += Convert.ToDecimal(_topla.Rows[i]["Menge"]);

                    }
                }
            }

            return eklenenMalzemeSayisi;
        }

        private void txtKolilenecekMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Onayla_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Mal çıkışını onaylıyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                    WS_Islem.ZKtWmWsAmbalajlama chk = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlama();
                    WS_Islem.ZKtWmWsAmbalajlamaResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlamaResponse();
                    WS_Islem.ZktWmStKoli[] koli = new KoctasWM_Project.WS_Islem.ZktWmStKoli[_topla.Rows.Count];

                    //Koli içeriği dolduruluyor
                    for (int i = 0; i < _topla.Rows.Count; i++)
                    {
                        koli[i] = new KoctasWM_Project.WS_Islem.ZktWmStKoli();
                        koli[i].Desi = Convert.ToDecimal(_topla.Rows[i]["Desi"].ToString());
                        koli[i].KoliNo = _topla.Rows[i]["KoliNo"].ToString();
                        koli[i].KoliTipi = _topla.Rows[i]["KoliTipi"].ToString();
                        koli[i].Lfimg = Convert.ToDecimal(_topla.Rows[i]["Lfimg"].ToString());
                        koli[i].Matnr = _topla.Rows[i]["Matnr"].ToString();
                        koli[i].Meins = _topla.Rows[i]["Meins"].ToString();
                        koli[i].Menge = Convert.ToDecimal(_topla.Rows[i]["Menge"].ToString());
                        koli[i].Posnr = _topla.Rows[i]["Posnr"].ToString();
                        koli[i].VbelnVl = _topla.Rows[i]["VbelnVI"].ToString();

                        _koliNo = _topla.Rows[i]["KoliNo"].ToString();
                    }

                    chk.ItKoli = koli;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    resp = srv.ZKtWmWsAmbalajlama(chk);


                    if (resp.EsResponse.Length > 0)
                    {
                        //Mesajlar düzenleniyor
                        GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                        GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                        if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        }
                        else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                            Utility.moreMsgCheck(GlobalData.rMsg);


                            //İşlem başarılı ise koli bölme işlemi yapılıyor
                            //Kargo koli bölme ekranı çağırılıyor - 24.07.2017 by Gökhan
                            frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol frmBol = new frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol();
                            bool devam = false;
                            Cursor.Current = Cursors.Default;
                            if (frmBol.ShowDialog() == DialogResult.OK)
                            {
                                devam = true;
                            }

                            if (devam)
                            {
                                //İşlem başarılı ise, eşleme servisleri çağırılıyor
                                Cursor.Current = Cursors.Default;
                                frm_20_v2_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D frm = new frm_20_v2_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D();
                                //frm._faturaNo = faturaNo;
                                frm._belgeNo = _Vbeln;
                                frm._koliNo = _koliNo;
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                            }




                            //TAŞINDI - frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D ekranı sonrasına.
                            //İşlem başarılı ise, faturalandırma ve eşleme servisleri çağırılıyor
                            /*
                            WS_Islem.ZKtWmWsAmbalajlamaFatura chk1 = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlamaFatura();
                            WS_Islem.ZKtWmWsAmbalajlamaFaturaResponse resp1 = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlamaFaturaResponse();
                            srv.Credentials = GlobalData.globalCr;
                            srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");

                            chk1.IvVbeln = _Vbeln;
                            resp1 = srv.ZKtWmWsAmbalajlamaFatura(chk1);

                            if (resp1.EsResponse.Length > 0)
                            {
                                //Mesajlar düzenleniyor
                                GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp1.EsResponse.Length];
                                GlobalData.rMsg = Utility.mesajDuzenle(resp1.EsResponse);

                                if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                                {
                                    MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                                }
                                else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                                {
                                    string faturaNo = resp1.EvVbelnVf.ToString();
                                    string teslimatNo = resp1.EvMblnr.ToString();


                                    MessageBox.Show(GlobalData.rMsg[0].Message.ToString() + " Fatura No: " + faturaNo + " Malzeme Belgesi: " + teslimatNo, "BİLGİ");

                                    
                                    

                                }
                                else
                                {
                                    MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                                }

                            }
                            else
                            {
                                MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                            }*/
                            
    
                        }
                        else
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                        }

                    }
                    else
                    {
                        MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "HATA");
                    logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_btn_Kaydet_Click "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_btn_Kaydet_Click end");
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (!toplamMiktarKarsilastir())
            {
                MessageBox.Show("Dağıtım adresindeki tüm ürünler koliye aktarılmadı. Kontrol ediniz.", "HATA");
                return;
            }

            panel1.Left = 337;
            panel2.Left = 0;
            setupSecondScreen();
        }

        private void setupSecondScreen()
        {
            _toplaSecondScreen.Columns.Add("Koli_No");
            _toplaSecondScreen.Columns.Add("Koli_Tipi");
            _toplaSecondScreen.Columns.Add("Desi_Bilgisi");

            List<String> discinctList = new List<String>();

            for (int i = 0; i < _topla.Rows.Count; i++)
            {
                if (discinctList.Contains(_topla.Rows[i]["KoliNo"].ToString()))
                    continue;

                DataRow dataRow = _toplaSecondScreen.NewRow();
                dataRow["Koli_No"] = _topla.Rows[i]["KoliNo"].ToString();
                dataRow["Koli_Tipi"] = "";
                dataRow["Desi_Bilgisi"] = "";
                _toplaSecondScreen.Rows.Add(dataRow);
                discinctList.Add(_topla.Rows[i]["KoliNo"].ToString());
            }
            dataGridView1.DataSource = _toplaSecondScreen;

            //try
            //{
            //    if (dataGridView1.Rows.Count > 0)
            //    {
            //        dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.Yellow;
            //        dataGridView1.Rows[0].Selected = false;
            //    }

            //    if (dataGridView1.Rows[0].Cells.Count > 0)
            //        txt_newKoliNo.Text = dataGridView1.Rows[0].Cells["Koli_No"].Value.ToString();
            //}
            //catch (Exception e)
            //{ }
        }

        private void btn_approveKoliDesi_Click(object sender, EventArgs e)
        {
            if (txt_newKoliNo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Kargo No Giriniz");
                return;
            }

            if (cmbKoliTipi.SelectedIndex <= 0 || txtDesiBilgisi.Equals(""))
            {
                MessageBox.Show("Lütfen Koli Tipi Seçiniz");
                return;
            }

            if (secondScreenDateGridIndex < dataGridView1.VisibleRowCount && secondScreenDateGridIndex != -1)
            {
                dataGridView1[secondScreenDateGridIndex,1] = cmbKoliTipi.SelectedItem.ToString();
                dataGridView1[secondScreenDateGridIndex,2] = txtDesiBilgisi.Text;
                //dataGridView1.Rows[secondScreenDateGridIndex].DefaultCellStyle.BackColor = Color.LightGreen;

                for (int i = 0; i < _topla.Rows.Count; i++)
                {
                    if (_topla.Rows[i]["KoliNo"].ToString().Equals(txt_newKoliNo.Text))
                    {
                        _topla.Rows[i]["KoliTipi"] = _koliTipi;
                        _topla.Rows[i]["Desi"] = txtDesiBilgisi.Text;
                    }
                }

                //dataGridView1.Rows[secondScreenDateGridIndex].Selected = true;
                txt_newKoliNo.Text = dataGridView1[secondScreenDateGridIndex,0].ToString();
                //dataGridView1.Rows[secondScreenDateGridIndex].DefaultCellStyle.BackColor = Color.LightGreen;

                txt_newKoliNo.Text = "";
                cmbKoliTipi.SelectedIndex = 0;
                txtDesiBilgisi.Text = "";
            }
        }

        private void txt_newKoliNo_TextChanged(object sender, EventArgs e)
        {
            cmbKoliTipi.Enabled = true;
            secondScreenDateGridIndex = -1;
            for (int i = 0; i < dataGridView1.VisibleRowCount; i++)
            {
                if (dataGridView1[i,0].ToString().Equals(txt_newKoliNo.Text))
                {
                    secondScreenDateGridIndex = i;
                    //dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }
    }
}