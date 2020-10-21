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
    public partial class frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim).Name);
        public frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim()
        {
            InitializeComponent();
        }

        public WS_Kontrol.ZktWmVwSayim sayim;
        public WS_Kontrol.ZktWmVwSayim[] sayimMalzeme;
        public string _onerilenDepoAdresi = "";
        public string _depoAdresi = "";
        public string islemTipi = "palet";
        public decimal miktar;
        bool girisYapildi;
        public DataTable _toplaMalzeme;
        public WS_Kontrol.ZktWmVwSayim _tempMalzeme;
        bool sayimTamamlandi = false;

        private void formAcilisDuzenle()
        {
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtOlcuBirimi.Text = "";
            txtMiktar.Text = "";
            txtMiktar.Enabled = false;

            txtPaletMalzemeNo.Text = "";
            Utility.selectText(txtPaletMalzemeNo);
        }

        private void formSifirla()
        {
            formAcilisDuzenle();
            txtDepoAdresi.Text = "";
            txtPaletMalzemeNo.Enabled = false;
            txtDepoAdresi.Enabled = true;

            _onerilenDepoAdresi = "";
            _depoAdresi = "";
            miktar = 0;
            girisYapildi = false;
            sayimTamamlandi = false;

            sayim = new KoctasWM_Project.WS_Kontrol.ZktWmVwSayim();

            Utility.selectText(txtDepoAdresi);


        }


        private void frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            _toplaMalzeme = new DataTable();
            _toplaMalzeme.Columns.Add("Altme");
            _toplaMalzeme.Columns.Add("Anzle");
            _toplaMalzeme.Columns.Add("Charg");
            _toplaMalzeme.Columns.Add("Gesme");
            _toplaMalzeme.Columns.Add("Istat");
            _toplaMalzeme.Columns.Add("Ivnum");
            _toplaMalzeme.Columns.Add("Ivpos");
            _toplaMalzeme.Columns.Add("Lenum");
            _toplaMalzeme.Columns.Add("Letyp");
            _toplaMalzeme.Columns.Add("Lgnum");
            _toplaMalzeme.Columns.Add("Lgpla");
            _toplaMalzeme.Columns.Add("Lgtyp");
            _toplaMalzeme.Columns.Add("LinpIstat");
            _toplaMalzeme.Columns.Add("LinvIstat");
            _toplaMalzeme.Columns.Add("Lqnum");
            _toplaMalzeme.Columns.Add("Mandt");
            _toplaMalzeme.Columns.Add("Maktx");
            _toplaMalzeme.Columns.Add("Matnr");
            _toplaMalzeme.Columns.Add("Meins");
            _toplaMalzeme.Columns.Add("Menga");
            _toplaMalzeme.Columns.Add("Menge");
            _toplaMalzeme.Columns.Add("Nanum");
            _toplaMalzeme.Columns.Add("Tanum");
            _toplaMalzeme.Columns.Add("Tapos");
            _toplaMalzeme.Columns.Add("Werks");
            _toplaMalzeme.Columns.Add("Sonum");
            _toplaMalzeme.Columns.Add("Sobkz");

            Utility.selectText(txtDepoAdresi);

        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            if (girisYapildi)
            {
                if (!sayimTamamlandi)
                {
                    if (MessageBox.Show("Henüz sayımı kaydetmediniz. Sayılmayan malzemeler sıfır sayılacak. Onaylıyor musunuz?", "HATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        sayimTamamla();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void paletTamamla()
        {
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_paletTamamla begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSayimAdresiTamam chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimAdresiTamam();
                WS_Islem.ZKtWmWsSayimAdresiTamamResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimAdresiTamamResponse();

                chk.IvLgpla = _depoAdresi.ToString();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsSayimAdresiTamam(chk);


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
                        sayimTamamlandi = true;
                        formSifirla();
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
                logger.error("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_paletTamamla "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_paletTamamla end");
        }

        private void malzemeTamamla()
        {
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_malzemeTamamla begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                //Malzeme tamamla

                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSayimMlzTamamla chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimMlzTamamla();
                WS_Islem.ZKtWmWsSayimMlzTamamlaResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimMlzTamamlaResponse();
                WS_Islem.ZktWmVwSayim[] _sayimMalzeme = new KoctasWM_Project.WS_Islem.ZktWmVwSayim[_toplaMalzeme.Rows.Count];

                chk.IvLgpla = _depoAdresi.ToString();


                //Malzeme tablosu dolduruluyor
                for (int i = 0; i < _toplaMalzeme.Rows.Count; i++)
                {
                    _sayimMalzeme[i] = new KoctasWM_Project.WS_Islem.ZktWmVwSayim();
                    _sayimMalzeme[i].Altme = _toplaMalzeme.Rows[i]["Altme"].ToString();
                    _sayimMalzeme[i].Anzle = Convert.ToDecimal(_toplaMalzeme.Rows[i]["Anzle"].ToString());
                    _sayimMalzeme[i].Charg = _toplaMalzeme.Rows[i]["Charg"].ToString();
                    _sayimMalzeme[i].Gesme = Convert.ToDecimal(_toplaMalzeme.Rows[i]["Gesme"].ToString());
                    _sayimMalzeme[i].Istat = _toplaMalzeme.Rows[i]["Istat"].ToString();
                    _sayimMalzeme[i].Ivnum = _toplaMalzeme.Rows[i]["Ivnum"].ToString();
                    _sayimMalzeme[i].Ivpos = _toplaMalzeme.Rows[i]["Ivpos"].ToString();
                    _sayimMalzeme[i].Lenum = _toplaMalzeme.Rows[i]["Lenum"].ToString();
                    _sayimMalzeme[i].Letyp = _toplaMalzeme.Rows[i]["Letyp"].ToString();
                    _sayimMalzeme[i].Lgnum = _toplaMalzeme.Rows[i]["Lgnum"].ToString();
                    _sayimMalzeme[i].Lgpla = _toplaMalzeme.Rows[i]["Lgpla"].ToString();
                    _sayimMalzeme[i].Lgtyp = _toplaMalzeme.Rows[i]["Lgtyp"].ToString();
                    _sayimMalzeme[i].LinpIstat = _toplaMalzeme.Rows[i]["LinpIstat"].ToString();
                    _sayimMalzeme[i].LinvIstat = _toplaMalzeme.Rows[i]["LinvIstat"].ToString();
                    _sayimMalzeme[i].Lqnum = _toplaMalzeme.Rows[i]["Lqnum"].ToString();
                    _sayimMalzeme[i].Maktx = _toplaMalzeme.Rows[i]["Maktx"].ToString();
                    _sayimMalzeme[i].Mandt = _toplaMalzeme.Rows[i]["Mandt"].ToString();
                    _sayimMalzeme[i].Matnr = _toplaMalzeme.Rows[i]["Matnr"].ToString();
                    _sayimMalzeme[i].Meins = _toplaMalzeme.Rows[i]["Meins"].ToString();
                    _sayimMalzeme[i].Menga = Convert.ToDecimal(_toplaMalzeme.Rows[i]["Menga"].ToString());
                    _sayimMalzeme[i].Menge = Convert.ToDecimal(_toplaMalzeme.Rows[i]["Menge"].ToString());
                    _sayimMalzeme[i].Nanum = _toplaMalzeme.Rows[i]["Nanum"].ToString();
                    _sayimMalzeme[i].Tanum = _toplaMalzeme.Rows[i]["Tanum"].ToString();
                    _sayimMalzeme[i].Tapos = _toplaMalzeme.Rows[i]["Tapos"].ToString();
                    _sayimMalzeme[i].Werks = _toplaMalzeme.Rows[i]["Werks"].ToString();
                    _sayimMalzeme[i].Sobkz = _toplaMalzeme.Rows[i]["Sobkz"].ToString();
                    _sayimMalzeme[i].Sonum = _toplaMalzeme.Rows[i]["Sonum"].ToString();
                }
                chk.ItLinv = _sayimMalzeme;


                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsSayimMlzTamamla(chk);


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
                        sayimTamamlandi = true;
                        formSifirla();
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
                logger.error("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_malzemeTamamla " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_malzemeTamamla end");
        }

        private void sayimTamamla()
        {
            if (islemTipi == "palet")
            {
                paletTamamla();
            }
            else if (islemTipi == "malzeme")
            {
                malzemeTamamla();
            }
        }

        private void txtDepoAdresi_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DepoAdresi, 'b');
            Utility.setBackBolor(p2, lbl_PaletMalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_Miktar, 'w');

        }

        private void txtPaletMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DepoAdresi, 'w');
            Utility.setBackBolor(p2, lbl_PaletMalzemeNo, 'b');
            Utility.setBackBolor(p3, lbl_Miktar, 'w');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DepoAdresi, 'w');
            Utility.setBackBolor(p2, lbl_PaletMalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_Miktar, 'p');
        }

        private void btn_Onayla_Click(object sender, EventArgs e)
        {
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_btn_Onayla_Click begin");
            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text.ToString().Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                return;
            }


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSayimKaydetIi chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimKaydetIi();
                WS_Islem.ZKtWmWsSayimKaydetIiResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimKaydetIiResponse();
                WS_Islem.ZktWmVwSayim _sayim = new KoctasWM_Project.WS_Islem.ZktWmVwSayim();


                //Sayim içerikleri aktarılıyor
                if (islemTipi == "palet")
                {
                    _sayim.Altme = sayim.Altme.ToString();
                    _sayim.Anzle = Convert.ToDecimal(sayim.Anzle.ToString());
                    _sayim.Charg = sayim.Charg.ToString();
                    _sayim.Gesme = Convert.ToDecimal(sayim.Gesme.ToString());
                    _sayim.Istat = sayim.Istat.ToString();
                    _sayim.Ivnum = sayim.Ivnum.ToString();
                    _sayim.Ivpos = sayim.Ivpos.ToString();
                    _sayim.Lenum = sayim.Lenum.ToString();
                    _sayim.Letyp = sayim.Letyp.ToString();
                    _sayim.Lgnum = sayim.Lgnum.ToString();
                    _sayim.Lgpla = sayim.Lgpla.ToString();
                    _sayim.Lgtyp = sayim.Lgtyp.ToString();
                    _sayim.LinpIstat = sayim.LinpIstat.ToString();
                    _sayim.LinvIstat = sayim.LinvIstat.ToString();
                    _sayim.Lqnum = sayim.Lqnum.ToString();
                    _sayim.Mandt = sayim.Mandt.ToString();
                    _sayim.Maktx = sayim.Maktx.ToString();
                    _sayim.Matnr = sayim.Matnr.ToString();
                    _sayim.Meins = sayim.Meins.ToString();
                    _sayim.Menga = sayim.Menga;
                    _sayim.Menge = sayim.Menge;
                    _sayim.Nanum = sayim.Nanum.ToString();
                    _sayim.Tanum = sayim.Tanum.ToString();
                    _sayim.Tapos = sayim.Tapos.ToString();
                    _sayim.Werks = sayim.Werks.ToString();
                    _sayim.Sonum = sayim.Sonum.ToString();
                    _sayim.Sobkz = sayim.Sobkz.ToString();

                    chk.IsLinv = _sayim;
                    chk.IvMiktar = miktar;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    resp = srv.ZKtWmWsSayimKaydetIi(chk);


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
                            girisYapildi = true;
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
                else if (islemTipi == "malzeme")
                {

                    bool ekle = true;

                    //Girilen ean veya matnr den matnr çekiliyor
                    string malzemeNo = Utility.malzemeNoGetir(txtPaletMalzemeNo.Text.ToString(), "matnr");

                    //Malzeme daha önce toplanmış mı?
                    for (int i = 0; i < _toplaMalzeme.Rows.Count; i++)
                    {
                        if (malzemeNo == _toplaMalzeme.Rows[i]["Matnr"].ToString())
                        {
                            if (MessageBox.Show("Bu malzemeyi daha önce saydınız. Yeni sayımı üzerine yazmak istiyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                _toplaMalzeme.Rows[i]["Menga"] = miktar.ToString();
                                ekle = false;
                            }
                            else
                            {
                                ekle = false;
                            }


                        }
                    }


                    if (ekle)
                    {
                        DataRow row = _toplaMalzeme.NewRow();
                        row["Altme"] = _tempMalzeme.Altme.ToString();
                        row["Anzle"] = _tempMalzeme.Anzle.ToString();
                        row["Charg"] = _tempMalzeme.Charg.ToString();
                        row["Gesme"] = _tempMalzeme.Gesme.ToString();
                        row["Istat"] = _tempMalzeme.Istat.ToString();
                        row["Ivnum"] = _tempMalzeme.Ivnum.ToString();
                        row["Ivpos"] = _tempMalzeme.Ivpos.ToString();
                        row["Lenum"] = _tempMalzeme.Lenum.ToString();
                        row["Letyp"] = _tempMalzeme.Letyp.ToString();
                        row["Lgnum"] = _tempMalzeme.Lgnum.ToString();
                        row["Lgpla"] = _tempMalzeme.Lgpla.ToString();
                        row["Lgtyp"] = _tempMalzeme.Lgtyp.ToString();
                        row["LinpIstat"] = _tempMalzeme.LinpIstat.ToString();
                        row["LinvIstat"] = _tempMalzeme.LinvIstat.ToString();
                        row["Lqnum"] = _tempMalzeme.Lqnum.ToString();
                        row["Mandt"] = _tempMalzeme.Mandt.ToString();
                        row["Maktx"] = _tempMalzeme.Maktx.ToString();
                        row["Matnr"] = _tempMalzeme.Matnr.ToString();
                        row["Meins"] = _tempMalzeme.Meins.ToString();
                        row["Menga"] = miktar.ToString();

                        //miktar ekleniyor
                        row["Menge"] = _tempMalzeme.Menge.ToString();

                        row["Nanum"] = _tempMalzeme.Nanum.ToString();
                        row["Tanum"] = _tempMalzeme.Tanum.ToString();
                        row["Tapos"] = _tempMalzeme.Tapos.ToString();
                        row["Werks"] = _tempMalzeme.Werks.ToString();

                        row["Sonum"] = _tempMalzeme.Sonum.ToString();
                        row["Sobkz"] = _tempMalzeme.Sobkz.ToString();

                        _toplaMalzeme.Rows.Add(row);
                    }
                    girisYapildi = true;
                    formAcilisDuzenle();

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_btn_Onayla_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_btn_Onayla_Click end");
        }

        private void txtDepoAdresi_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_txtDepoAdresi_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {

                txtDepoAdresi.Text = txtDepoAdresi.Text.ToString().Trim().ToUpper();
                _depoAdresi = txtDepoAdresi.Text;

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    //girilen adres sorgulanıyor
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsSayimKullaniciSec chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSayimKullaniciSec();
                    WS_Kontrol.ZKtWmWsSayimKullaniciSecResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSayimKullaniciSecResponse();

                    chk.IvLgpla = _depoAdresi;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsSayimKullaniciSec(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        //Eğer değer X ise palet girişi bekleniyor, değil ise malzeme girişi
                        if (resp.EvLenvw.ToString() == "X")
                        {
                            lbl_PaletMalzemeNo.Text = "Palet No:";
                            //txtPaletMalzemeNo.Enabled = true;
                            islemTipi = "palet";
                        }
                        else
                        {
                            lbl_PaletMalzemeNo.Text = "Malzeme No:";
                            //txtPaletMalzemeNo.Enabled = true;
                            islemTipi = "malzeme";
                        }
                        girisYapildi = false;
                        txtPaletMalzemeNo.Enabled = true;
                        Utility.selectText(txtPaletMalzemeNo);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtDepoAdresi);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_txtDepoAdresi_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                
                
                
                
                
                
                
                
                
                
            }
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_txtDepoAdresi_KeyDown end");
        }


        private void paletKontrol()
        {
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_paletKontrol begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //palet kontrol ediliyor
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmSayimPaletKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmSayimPaletKontrol();
                WS_Kontrol.ZKtWmSayimPaletKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmSayimPaletKontrolResponse();
                sayim = new KoctasWM_Project.WS_Kontrol.ZktWmVwSayim();

                chk.IvLenum = txtPaletMalzemeNo.Text.ToString();
                chk.IvLgpla = _depoAdresi;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmSayimPaletKontrol(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    sayim = resp.EsLinv;

                    //Sayim tablosundan dönen içerik
                    //ekrana yazılıyor
                    txtMalzemeNo.Text = Convert.ToInt64(sayim.Matnr.ToString()).ToString();
                    txtMalzemeTanimi.Text = sayim.Maktx.ToString();
                    txtOlcuBirimi.Text = sayim.Meins.ToString();
                    txtMiktar.Enabled = true;
                    Utility.selectText(txtMiktar);
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    Utility.selectText(txtPaletMalzemeNo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_paletKontrol " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_paletKontrol end");
        }

        private void malzemeKontrol()
        {
            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_malzemeKontrol begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //palet kontrol ediliyor
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmSayimMalzemeKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmSayimMalzemeKontrol();
                WS_Kontrol.ZKtWmSayimMalzemeKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmSayimMalzemeKontrolResponse();

                chk.IvEan = txtPaletMalzemeNo.Text.ToString();
                chk.IvLgpla = _depoAdresi;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmSayimMalzemeKontrol(chk);


                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    sayimMalzeme = new KoctasWM_Project.WS_Kontrol.ZktWmVwSayim[resp.EtLinv.Length];
                    sayimMalzeme = resp.EtLinv;

                    //Girilen ean veya matnr den matnr çekiliyor
                    string malzemeNo = Utility.malzemeNoGetir(txtPaletMalzemeNo.Text.ToString(), "matnr");

                    //Malzeme daha önce eklenmiş ise, eklenen miktar çekiliyor
                    for (int i = 0; i < _toplaMalzeme.Rows.Count; i++)
                    {
                        if (_toplaMalzeme.Rows[i]["Matnr"].ToString() == malzemeNo)
                        {
                            txtMiktar.Text = _toplaMalzeme.Rows[i]["Menga"].ToString();
                        }
                    }

                    //Sayim tablosundan dönen içerik
                    //_tempMalzeme tablosu dolduruluyor
                    _tempMalzeme = new KoctasWM_Project.WS_Kontrol.ZktWmVwSayim();
                    _tempMalzeme = sayimMalzeme[0];

                    //ekrana yazılıyor
                    txtMalzemeNo.Text = Convert.ToInt64(_tempMalzeme.Matnr.ToString()).ToString();
                    txtMalzemeTanimi.Text = _tempMalzeme.Maktx.ToString();
                    txtOlcuBirimi.Text = _tempMalzeme.Meins.ToString();
                    txtMiktar.Enabled = true;
                    Utility.selectText(txtMiktar);
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    Utility.selectText(txtPaletMalzemeNo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_malzemeKontrol " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            logger.info("frm_26_Sayim_Islemleri_Envanter_Sayimi_Kullanici_Secimi_ile_Sayim_malzemeKontrol end");
        }

        private void txtPaletMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtPaletMalzemeNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                if (islemTipi == "palet")
                {
                    paletKontrol();
                }
                else if (islemTipi == "malzeme")
                {
                    malzemeKontrol();
                }

            }
        }

        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Onayla_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            if (girisYapildi)
            {
                sayimTamamla();
            }
            else
            {
                if (MessageBox.Show("Henüz sayımı kaydetmediniz. Sayılmayan malzemeler sıfır sayılacak. Onaylıyor musunuz?", "HATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    sayimTamamla();
                    this.Close();
                }
            }
        }

    }
}