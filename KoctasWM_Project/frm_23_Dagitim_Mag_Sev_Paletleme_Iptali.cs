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
    public partial class frm_23_Dagitim_Mag_Sev_Paletleme_Iptali : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_23_Dagitim_Mag_Sev_Paletleme_Iptali).Name);
        public frm_23_Dagitim_Mag_Sev_Paletleme_Iptali()
        {
            InitializeComponent();
        }

        DataTable _rampa;
        DataTable _yukle;

        WS_Kontrol.ZktWmStRampa gecerliRampa;
        int gecerliRampaIndex;
        string kontrolMalzemeNo = "";
        decimal miktar;
        bool kaydedildi;
        bool girisKontrol;
        string gecerliKoliNo = "";



        private void formAcilisDuzenle()
        {
            txtKargoPaletNo.Text = "";
            txtMagaza.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtTeslimatNo.Text = "";
            txtTeslimatMiktari.Text = "";
            txtPaletlenenMiktar.Text = "";
            txtPaletlenecekMiktar.Text = "";
            gecerliRampaIndex = -1;
            kontrolMalzemeNo = "";
            gecerliKoliNo = "";

            txtPaletlenecekMiktar.Enabled = false;
            txtMalzemeNo.Enabled = false;

            Utility.selectText(txtKargoPaletNo);

        }

        private int gecerliRampaGetir(string malzemeNo)
        {
            int index = -1;

            if (malzemeNo != "")
            {
                for (int i = 0; i < _rampa.Rows.Count; i++)
                {
                    decimal yuklenenMiktar = Convert.ToDecimal(_rampa.Rows[i]["yuklenenMiktar"].ToString());
                    decimal teslimatMiktari = Convert.ToDecimal(_rampa.Rows[i]["LfimgTeslimat"].ToString());
                    if ((_rampa.Rows[i]["Matnr"].ToString() == malzemeNo) && (yuklenenMiktar < teslimatMiktari))
                    {
                        if (_rampa.Rows[i]["Kostk"].ToString() == "C")
                        {
                            index = i;
                            return index;
                        }
                        
                        
                    }
                }
            }

            return index;
        }

        private void frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;

            Utility.loginInfo(lbl_LoginInfo);


            _rampa = new DataTable();
            _rampa.Columns.Add("DagitimAdresi");
            _rampa.Columns.Add("KoliNo");
            _rampa.Columns.Add("Kostk");
            _rampa.Columns.Add("Kunnr");
            _rampa.Columns.Add("Lfart");
            _rampa.Columns.Add("LfimgTeslimat");
            _rampa.Columns.Add("Maktx");
            _rampa.Columns.Add("Matnr");
            _rampa.Columns.Add("Meins");
            _rampa.Columns.Add("Menge");
            _rampa.Columns.Add("Vbeln");
            _rampa.Columns.Add("Posnr");
            _rampa.Columns.Add("Kosta");
            _rampa.Columns.Add("Magaza");
            _rampa.Columns.Add("yuklenenMiktar");
            


            _yukle = new DataTable();
            _yukle.Columns.Add("KoliNo");
            _yukle.Columns.Add("Matnr");
            _yukle.Columns.Add("Meins");
            _yukle.Columns.Add("Menge");
            _yukle.Columns.Add("Posnr");
            _yukle.Columns.Add("VbelnVI");

            girisKontrol = false;

            Utility.selectText(txtSevkiyatRampasi);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            if (!kaydedildi)
            {
                if (MessageBox.Show("Paleti henüz kaydetmediniz. Bu ekrandan çıkmak istediğinizden emin misiniz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }


        private void txtSevkiyatRampasi_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_SevkiyatRampasi, 'b');
            Utility.setBackBolor(p2, lbl_KargoPaletNo, 'w');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_PaletlenecekMiktar, 'p');
        }

        private void textBox1_GotFocus_1(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_SevkiyatRampasi, 'w');
            Utility.setBackBolor(p2, lbl_KargoPaletNo, 'b');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_PaletlenecekMiktar, 'p');
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_SevkiyatRampasi, 'w');
            Utility.setBackBolor(p2, lbl_KargoPaletNo, 'w');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p3, lbl_PaletlenecekMiktar, 'p');
        }

        private void txtPaletlenecekMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_SevkiyatRampasi, 'w');
            Utility.setBackBolor(p2, lbl_KargoPaletNo, 'w');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_PaletlenecekMiktar, 'b');
        }

        private decimal rampaBelgeToplamYuklenenMiktarBul(string vbeln)
        {
            decimal miktar = 0;
            vbeln = vbeln.ToString().Trim();
            for (int i = 0; i < _rampa.Rows.Count; i++)
            {
                if (_rampa.Rows[i]["Vbeln"].ToString() == vbeln)
                {
                    miktar += Convert.ToDecimal(_rampa.Rows[i]["yuklenenMiktar"]);
                }
            }

            return miktar;
        }

        private decimal rampaBelgeToplamTeslimatMiktarBul(string vbeln)
        {
            decimal miktar = 0;
            vbeln = vbeln.ToString().Trim();
            for (int i = 0; i < _rampa.Rows.Count; i++)
            {
                if (_rampa.Rows[i]["Vbeln"].ToString() == vbeln)
                {
                    miktar += Convert.ToDecimal(_rampa.Rows[i]["LfimgTeslimat"]);
                }
            }

            return miktar;
        }

        private bool paletlemeKontrol()
        {
            bool kontrol = true;

            if (_rampa.Rows.Count == 0)
            {
                kontrol = false;
            }

            for (int j = 0; j < _yukle.Rows.Count; j++)
            {
                if ((rampaBelgeToplamTeslimatMiktarBul(_yukle.Rows[j]["VbelnVI"].ToString())) != (rampaBelgeToplamYuklenenMiktarBul(_yukle.Rows[j]["VbelnVI"].ToString())))
                {
                    kontrol = false;
                    //Miktarı okutulmayan malzeme numarası bulunuyor.

                    for (int i = 0; i < _rampa.Rows.Count; i++)
                    {
                        if (_rampa.Rows[i]["Vbeln"].ToString() == _yukle.Rows[j]["VbelnVI"].ToString())
                        {
                            //malzeme numarasının paletlenen miktarı ile teslimat miktarı karşılaştırılıyor
                            if ((Convert.ToDecimal(_rampa.Rows[i]["LfimgTeslimat"].ToString()) != Convert.ToDecimal(_rampa.Rows[i]["yuklenenMiktar"].ToString())) && (_rampa.Rows[i]["Kostk"].ToString() == "C") )
                            {
                                try
                                {
                                    kontrolMalzemeNo = Convert.ToInt64(_rampa.Rows[i]["Matnr"].ToString()).ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "HATA");
                                }
                                
                                return kontrol;
                            }
                           

                            /*
                            
                            if ((Convert.ToDecimal(_rampa.Rows[i]["LfimgTeslimat"].ToString()) != Convert.ToDecimal(_rampa.Rows[i]["yuklenenMiktar"].ToString())) && (_rampa.Rows[i]["Kostk"].ToString() == "C") && (_rampa.Rows[i]["Matnr"].ToString() == _yukle.Rows[j]["Matnr"].ToString()))
                            {
                                kontrolMalzemeNo = _yukle.Rows[j]["Matnr"].ToString();
                                return kontrol;
                            }
                            else if ((Convert.ToDecimal(_rampa.Rows[i]["LfimgTeslimat"].ToString()) != Convert.ToDecimal(_rampa.Rows[i]["yuklenenMiktar"].ToString())) && (_rampa.Rows[i]["Kostk"].ToString() == "C") && (_rampa.Rows[i]["Matnr"].ToString() != _yukle.Rows[j]["Matnr"].ToString()))
                            {
                                kontrolMalzemeNo = _yukle.Rows[j]["Matnr"].ToString();
                                return kontrol;
                            }*/
                            
                            //) && (_rampa.Rows[i]["Matnr"].ToString() == _yukle.Rows[j]["Matnr"].ToString()) && (_rampa.Rows[i]["Kostk"].ToString() == "C") )
                            
                        }
                    }
                }
            }
            
            /*
            for (int i = 0; i < _rampa.Rows.Count; i++)
            {
                //_rampa daki belge no bazındaki teslimatlar ile, yukle tablosundaki belge no toplamları eşit olmalı

                for (int j = 0; j < _yukle.Rows.Count; j++)
                {
                    if (_rampa.Rows[i]["Vbeln"].ToString()
                }
                
                
                if ((Convert.ToDecimal(_rampa.Rows[i]["yuklenenMiktar"]) != 0) && (Convert.ToDecimal(_rampa.Rows[i]["LfimgTeslimat"].ToString()) != Convert.ToDecimal(_rampa.Rows[i]["yuklenenMiktar"].ToString())) && (_rampa.Rows[i]["Kostk"].ToString() == "C"))
                {
                    kontrol = false;
                    kontrolMalzemeNo = _rampa.Rows[i]["Matnr"].ToString();
                    return kontrol;
                }
            }*/

            return kontrol;
        }

        private void btn_Onayla_Click(object sender, EventArgs e)
        {
            try
            {
                miktar = Convert.ToDecimal(txtPaletlenecekMiktar.Text.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                Utility.selectText(txtPaletlenecekMiktar);
                return;
            }

            if (gecerliKoliNo == "") {
                MessageBox.Show("Geçerli bir kargo palet no okutunuz.", "HATA");
                return;
            }

            if (!(miktar > 0))
            {
                return;
            }


            decimal teslimatMiktari = Convert.ToDecimal(_rampa.Rows[gecerliRampaIndex]["LfimgTeslimat"].ToString());
            decimal paletlenenMiktar = Convert.ToDecimal(_rampa.Rows[gecerliRampaIndex]["yuklenenMiktar"].ToString());

            try
            {
                
                if ((miktar + paletlenenMiktar) > teslimatMiktari)
                {
                    MessageBox.Show("Paletlenecek miktar ile paletlenen miktar toplamı, bu belgedeki teslimat miktarından fazla olamaz", "HATA");
                    Utility.selectText(txtPaletlenecekMiktar);
                    return;
                }

                if (gecerliRampaIndex >= 0)
                {
                    _rampa.Rows[gecerliRampaIndex]["yuklenenMiktar"] = Convert.ToDecimal(_rampa.Rows[gecerliRampaIndex]["yuklenenMiktar"]) + miktar;

                    //_yukle tablosuna malzeme ekleniyor
                    bool ekle = true;

                    // MalzemeNo ve koliNo eşleşmesi daha önce _yukle tablosuna eklenmiş mi
                    // eklenmiş ise miktar revize ediliyor
                    for (int i = 0; i < _yukle.Rows.Count; i++)
                    {
                        if ((_yukle.Rows[i]["KoliNo"].ToString() == gecerliKoliNo) && (_yukle.Rows[i]["Matnr"].ToString() == _rampa.Rows[gecerliRampaIndex]["Matnr"].ToString()) && (_yukle.Rows[i]["VbelnVI"].ToString() == _rampa.Rows[gecerliRampaIndex]["Vbeln"].ToString()) && (_yukle.Rows[i]["Posnr"].ToString() == _rampa.Rows[gecerliRampaIndex]["Posnr"].ToString()))
                        {
                            ekle = false;
                            _yukle.Rows[i]["Menge"] = Convert.ToDecimal(_yukle.Rows[i]["Menge"]) + miktar;
                        }
                    }


                    if (ekle)
                    {
                        DataRow _row = _yukle.NewRow();
                        _row["KoliNo"] = gecerliKoliNo;
                        _row["Matnr"] = _rampa.Rows[gecerliRampaIndex]["Matnr"];
                        _row["Meins"] = _rampa.Rows[gecerliRampaIndex]["Meins"];
                        _row["Menge"] = miktar.ToString();
                        _row["Posnr"] = _rampa.Rows[gecerliRampaIndex]["Posnr"];
                        _row["VbelnVI"] = _rampa.Rows[gecerliRampaIndex]["Vbeln"];

                        _yukle.Rows.Add(_row);

                    }
                    
                    formAcilisDuzenle();
                    MessageBox.Show("Paletlenecek miktar eklendi", "BİLGİ");

                    if (paletlemeKontrol())
                    {
                        MessageBox.Show("Paletleme işlemi tamamlandı. Mal çıkışı ve yükleme yapılabilir.", "BİLGİ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "HATA");
            }
            



        }

        private void txtSevkiyatRampasi_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_txtSevkiyatRampasi_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSevkiyatRampasi.Text.ToString().Trim() == "")
                {
                    return;
                }

                txtSevkiyatRampasi.Text = txtSevkiyatRampasi.Text.ToString().ToUpper().Trim();

                if (!Utility.baslangicKontrol(txtSevkiyatRampasi.Text, "RAMPA"))
                {
                    MessageBox.Show("Bu adreste bu işlem yapılamaz", "HATA");
                    Utility.selectText(txtSevkiyatRampasi);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsRampaKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsRampaKontrol();
                    WS_Kontrol.ZKtWmWsRampaKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsRampaKontrolResponse();

                    chk.IvDagadres = txtSevkiyatRampasi.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsRampaKontrol(chk);



                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        WS_Kontrol.ZktWmStRampa[] rampa = new KoctasWM_Project.WS_Kontrol.ZktWmStRampa[resp.EtRampa.Length];

                        rampa = resp.EtRampa;

                        //Rampa içeriği tabloya alınıyor
                        _rampa.Rows.Clear();
                        for (int i = 0; i < rampa.Length; i++)
                        {
                            DataRow row = _rampa.NewRow();
                            
                            row["DagitimAdresi"] = rampa[i].DagitimAdresi.ToString();
                            row["KoliNo"] = rampa[i].KoliNo.ToString();
                            row["Kostk"] = rampa[i].Kostk.ToString();
                            row["Kunnr"] = rampa[i].Kunnr.ToString();
                            row["Lfart"] = rampa[i].Lfart.ToString();
                            row["LfimgTeslimat"] = rampa[i].LfimgTeslimat;
                            row["Maktx"] = rampa[i].Maktx.ToString();
                            row["Matnr"] = rampa[i].Matnr.ToString();
                            row["Meins"] = rampa[i].Meins.ToString();
                            row["Menge"] = rampa[i].Menge;
                            row["Vbeln"] = rampa[i].Vbeln.ToString();
                            row["Posnr"] = rampa[i].Posnr.ToString();
                            row["Kosta"] = rampa[i].Kosta.ToString();
                            row["yuklenenMiktar"] = rampa[i].Menge.ToString();
                            row["Magaza"] = rampa[i].Name1.ToString();

                            _rampa.Rows.Add(row);
                        }

                        kaydedildi = false;
                        btn_Kaydet.Enabled = true;
                        txtKargoPaletNo.Enabled = true;
                        Utility.selectText(txtKargoPaletNo);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_txtSevkiyatRampasi_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_txtSevkiyatRampasi_KeyDown end");
        }

        private void txtKargoPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_txtKargoPaletNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtKargoPaletNo.Text.Trim().ToString() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsRampaOnay chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsRampaOnay();
                    WS_Kontrol.ZKtWmWsRampaOnayResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsRampaOnayResponse();


                    chk.IvKoliNo = txtKargoPaletNo.Text.ToString().Trim();
                    chk.IvDagAdres = txtSevkiyatRampasi.Text;
                    

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsRampaOnay(chk);

                    Cursor.Current = Cursors.Default;
                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        txtMalzemeNo.Enabled = true;
                        gecerliKoliNo = txtKargoPaletNo.Text.ToString().Trim();
                        Utility.selectText(txtMalzemeNo);
                    }
                    else
                    {
                        txtMalzemeNo.Enabled = false;
                        gecerliKoliNo = "";
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtKargoPaletNo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_txtKargoPaletNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            logger.info("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_txtKargoPaletNo_KeyDown end");
            
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.Trim().ToString() == "")
                {
                    return;
                }

                try
                {
                    txtMalzemeNo.Text = Convert.ToInt64(txtMalzemeNo.Text.ToString()).ToString();
                }
                catch
                {
                    MessageBox.Show("Geçerli bir malzeme no giriniz", "HATA");
                    Utility.selectText(txtMalzemeNo);
                    return;
                }

                //Okutulan malzemeno değeri matnr ye çeviriliyor
                string malzemeNo = Utility.malzemeNoGetir(txtMalzemeNo.Text.ToString(), "matnr");

                //Geçerli malzemenin rampa indexi getiriliyor
                gecerliRampaIndex = gecerliRampaGetir(malzemeNo);

                if (gecerliRampaIndex == -1)
                {
                    MessageBox.Show("Girdiğiniz malzeme numarası sevkiyat rampasındaki malzemelerle eşleşmedi. Lütfen kontrol ediniz.", "HATA");
                    txtKargoPaletNo.Text = "";
                    txtMalzemeNo.Text = "";
                    txtMalzemeNo.Enabled = false;
                    Utility.selectText(txtKargoPaletNo);
                    return;
                }
                else
                {
                    if (_rampa.Rows[gecerliRampaIndex]["Kostk"].ToString() == "C")
                    {
                        txtMalzemeTanimi.Text = _rampa.Rows[gecerliRampaIndex]["Maktx"].ToString();
                        txtTeslimatNo.Text = _rampa.Rows[gecerliRampaIndex]["Vbeln"].ToString();
                        txtTeslimatMiktari.Text = _rampa.Rows[gecerliRampaIndex]["LfimgTeslimat"].ToString();
                        txtPaletlenenMiktar.Text = _rampa.Rows[gecerliRampaIndex]["yuklenenMiktar"].ToString();
                        txtMagaza.Text = _rampa.Rows[gecerliRampaIndex]["Magaza"].ToString();

                        txtPaletlenecekMiktar.Enabled = true;
                        Utility.selectText(txtPaletlenecekMiktar);
                    }
                    else
                    {
                        MessageBox.Show("Girdiğiniz malzemenin dağıtımı tamamlanmamış. Lütfen kontrol ediniz.", "HATA");
                        Utility.selectText(txtMalzemeNo);
                    }
                    
                }


            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_btn_Kaydet_Click begin");
            if (MessageBox.Show("Paleti tamamlamak istediğinizden emin misiniz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (!paletlemeKontrol())
                {
                    MessageBox.Show(kontrolMalzemeNo + "nolu malzemeyi henüz tamamlamadınız.", "HATA");
                    girisKontrol = false;
                }
                else
                {
                    girisKontrol = true;
                }
                
                if (girisKontrol)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                        WS_Islem.ZKtWmWsRampaSevkiyat chk = new KoctasWM_Project.WS_Islem.ZKtWmWsRampaSevkiyat();
                        WS_Islem.ZKtWmWsRampaSevkiyatResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsRampaSevkiyatResponse();
                        WS_Islem.ZktWmStRampaYukleme[] ry = new KoctasWM_Project.WS_Islem.ZktWmStRampaYukleme[_yukle.Rows.Count];

                        for (int i = 0; i < _yukle.Rows.Count; i++)
                        {

                            ry[i] = new KoctasWM_Project.WS_Islem.ZktWmStRampaYukleme();
                            ry[i].KoliNo = _yukle.Rows[i]["KoliNo"].ToString();
                            ry[i].Matnr = _yukle.Rows[i]["Matnr"].ToString();
                            ry[i].Meins = _yukle.Rows[i]["Meins"].ToString();
                            ry[i].Menge = Convert.ToDecimal(_yukle.Rows[i]["Menge"].ToString());
                            ry[i].Meins = _yukle.Rows[i]["Meins"].ToString();
                            ry[i].Posnr = _yukle.Rows[i]["Posnr"].ToString();
                            ry[i].VbelnVl = _yukle.Rows[i]["VbelnVI"].ToString();
                        }

                        chk.ItRampa = ry;


                        srv.Credentials = GlobalData.globalCr;
                        srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                        resp = srv.ZKtWmWsRampaSevkiyat(chk);

                        if (resp.EsResponse.Length > 0)
                        {
                            //Mesajlar düzenleniyor
                            GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                            GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                            if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                            {
                                MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                                return;
                            }
                            else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                            {
                                MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                                Utility.moreMsgCheck(GlobalData.rMsg);
                                kaydedildi = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
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
                        MessageBox.Show(ex.Message.ToString(), "HATA");
                        logger.error("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_btn_Kaydet_Click " + ex.Message);
                        return;
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_23_Dagitim_Mag_Sev_Paletleme_Iptali_btn_Kaydet_Click end");
        }

        private void txtPaletlenecekMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Onayla_Click(new object(), new EventArgs());
            }
        }

    }
}