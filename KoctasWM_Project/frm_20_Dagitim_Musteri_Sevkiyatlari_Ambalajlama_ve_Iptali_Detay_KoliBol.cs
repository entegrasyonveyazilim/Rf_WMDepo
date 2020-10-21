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
    public partial class frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol).Name);
        string _koliTipi;
        string _koliTipiDesi;
        public DataTable _koliTipiTablo = new DataTable();
        DataTable drKoli = new DataTable();
        
        public frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol()
        {
            InitializeComponent();
        }

        private void frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            drKoli = new DataTable();
            drKoli.Columns.Add("koliNo");
            drKoli.Columns.Add("koliTipi");
            drKoli.Columns.Add("desi");
            drKoli.Columns.Add("mesaj");

            _koliTipiTablo = new DataTable();
            _koliTipiTablo.Columns.Add("desi");
            _koliTipiTablo.Columns.Add("koliTipi");
            _koliTipiTablo.Columns.Add("tanim");

            txtKargoKoliNo.Focus();
        }

        private void koliTipiCek()
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_koliTipiCek begin");
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
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_koliTipiCek end");
        
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

      
        private void cmbKoliTipi_SelectedIndexChanged(object sender, EventArgs e)
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


            if ((_koliTipiDesi != "") && (Convert.ToDecimal(_koliTipiDesi) != 0))
            {
                //Desi bilgisi dolu ise desi bilgisi yazılıyor
                txtDesiBilgisi.Text = _koliTipiDesi.ToString();
                txtDesiBilgisi.Enabled = false;
                txtKargoKoliNo.Enabled = true;
                //txtMalzemeNo.Enabled = true;
                //koliDesiKontrol = false;
                //Utility.selectText(txtMalzemeNo);
            }
            else
            {
                //Mix koli seçimi yapılmış demektir.
                txtDesiBilgisi.Text = _koliTipiDesi.ToString();
                txtDesiBilgisi.Enabled = true;
                //txtMalzemeNo.Enabled = false;
                //koliDesiKontrol = false;
                //Utility.selectText(txtDesiBilgisi);
            }
        }

        private void comboBox1_GotFocus(object sender, EventArgs e)
        {

        }

        private void btn_Geri_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKargoKoliNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtKargoKoliNo.Text.Trim() == "")
                {
                    return;
                }
                txtAdet.Enabled = true;
                txtAdet.Focus();
                btn_Bol.Enabled = true;
            }

        }

        private void txtAdet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Bol_Click (new object(), new EventArgs());
            }
        }

        private void btn_Bol_Click(object sender, EventArgs e)
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_btn_Bol_Click begin");
            decimal bolmeMiktari = 0;
            try
            {
                bolmeMiktari = Convert.ToDecimal(txtAdet.Text);
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal bir değer giriniz", "HATA");
                Utility.selectText(txtAdet);
                return;
            }

            if (bolmeMiktari <= 1 )
            {
                MessageBox.Show("Miktar alanına 1'den büyük bir değer giriniz", "HATA");
                Utility.selectText(txtAdet);
                return;
            }


            if (MessageBox.Show("Koli bölünmesini onaylıyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {


                grd_List.Enabled = false;

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    drKoli.Clear();
                    WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                    WS_Islem.ZKtWmWsKoliBol chk = new KoctasWM_Project.WS_Islem.ZKtWmWsKoliBol();
                    WS_Islem.ZKtWmWsKoliBolResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsKoliBolResponse();

                    chk.IvKoliNo = txtKargoKoliNo.Text.Trim();
                    chk.IvBolmeAdedi = bolmeMiktari.ToString();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    resp = srv.ZKtWmWsKoliBol(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        //Donen değerleri tabloya ekle
                        for (int i = 0; i < resp.EtOut.Length; i++)
                        {
                            DataRow row = drKoli.NewRow();
                            row["koliNo"] = resp.EtOut[i].KoliNo.ToString();
                            row["koliTipi"] = "";
                            row["desi"] = "";
                            row["mesaj"] = resp.EtOut[i].ReturnMessage.ToString();


                            drKoli.Rows.Add(row);
                        }

                        grd_List.DataSource = null;
                        grd_List.DataSource = drKoli;
                        grd_List.Enabled = true;
                        cmbKoliTipi.Enabled = true;
                        btn_Guncelle.Enabled = true;
                        

                        koliTipiCek();
                        koliTipiDoldur();
                        txtKargoKoliNo.Enabled = false;
                        txtAdet.Enabled = false;
                        btn_Bol.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtKargoKoliNo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_btn_Bol_Click "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_btn_Bol_Click end");
        }

        private void grd_List_DoubleClick(object sender, EventArgs e)
        {
            txtKargoKoliNo2.Text = drKoli.Rows[grd_List.CurrentCell.RowNumber]["koliNo"].ToString();
            cmbKoliTipi.Focus();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {

            try
            {
                _koliTipiDesi = txtDesiBilgisi.Text.ToString().Trim();
                if (!(Convert.ToDecimal(_koliTipiDesi) > 0))
                {
                    MessageBox.Show("Desi bilgisi sıfırdan büyük olmalı", "HATA");
                    Utility.selectText(txtDesiBilgisi);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Desi bilgisi alanı sayısal bir değer olmalıdır", "HATA");
                Utility.selectText(txtDesiBilgisi);
                return;
            }
            
            
            if (drKoli.Rows.Count > 0)
            {
                string koliNo = txtKargoKoliNo2.Text.Trim();
                string koliTanimi = cmbKoliTipi.Text.ToString();
                string koliTipi = koliTipiVer(koliTanimi);

                
                for (int i = 0; i < drKoli.Rows.Count; i++)
                {
                    string bulunanKoliNo = drKoli.Rows[i]["koliNo"].ToString().Trim();
                    if (bulunanKoliNo == koliNo)
                    {
                        drKoli.Rows[i]["koliTipi"] = koliTipi;
                        drKoli.Rows[i]["desi"] = _koliTipiDesi;

                    }
                }
                grd_List.DataSource = drKoli;
                txtKargoKoliNo2.Text = "";
            }
        }

        private void txtDesiBilgisi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Guncelle_Click (new object(), new EventArgs());
            }
        }

        private void btn_Devam_Click(object sender, EventArgs e)
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_btn_Devam_Click begin");
            bool devam = true;
            if (txtKargoKoliNo.Text.Trim() != "")
            {
                //Buraya geldiyse bölme işlemi var demektir.
                if (drKoli.Rows.Count == 0)
                {
                    MessageBox.Show("Koli bölme işlemi yapmadınız.", "HATA");
                    return;
                }
                
                
                if (drKoliKontrol() == false)
                {
                    MessageBox.Show("Böldüğünüz koliler için koli tipi ve desi bilgisi belirtiniz.", "HATA");
                    return;
                }

                if (MessageBox.Show("Böldüğünüz kolileri kaydetmek istediğinize emin misiniz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //SAP'ye kayıt işlemi burada yapılıyor.

                    devam = false;
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {

                        WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                        WS_Islem.ZKtWmWsNewKoliUpdate chk = new KoctasWM_Project.WS_Islem.ZKtWmWsNewKoliUpdate();
                        WS_Islem.ZKtWmWsNewKoliUpdateResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsNewKoliUpdateResponse();
                        WS_Islem.ZktWmStKoliUpdate[] itKoli = new KoctasWM_Project.WS_Islem.ZktWmStKoliUpdate[drKoli.Rows.Count];

                        if (drKoli.Rows.Count > 0) {
                            for(int i=0; i < drKoli.Rows.Count; i++) {
                                itKoli[i] = new KoctasWM_Project.WS_Islem.ZktWmStKoliUpdate();
                                itKoli[i].KoliNo = drKoli.Rows[i]["koliNo"].ToString();
                                itKoli[i].KoliTipi = drKoli.Rows[i]["koliTipi"].ToString();
                                itKoli[i].Desi = Convert.ToDecimal(drKoli.Rows[i]["desi"].ToString());
                            }
                        } 


                        chk.ItTable = itKoli;
                        srv.Credentials = GlobalData.globalCr;
                        srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                        resp = srv.ZKtWmWsNewKoliUpdate(chk);


                        //Hata yönetimi değiştirilecek...
                        if (resp.EsResponse[0].Msgty.ToString() == "S")
                        {
                            //Hata yoksa devam ediyor
                            devam = true;

                        }
                        else
                        {
                            MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                            devam = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "HATA");
                        devam = false;
                        logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_btn_Devam_Click "+ex.Message);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }


                    
                }
                logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol_btn_Devam_Click end");
            }

            //Buraya geldiyse diğer ekran açılıyor
            if (devam)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
            
            
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Böldüğünüz kolileri temizlemek istediğinize emin misiniz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                txtKargoKoliNo.Enabled = true;
                txtKargoKoliNo.Text = "";
                txtAdet.Enabled = false;
                txtAdet.Text = "";
                grd_List.DataSource = null;
                txtKargoKoliNo2.Text = "";
                btn_Guncelle.Enabled = false;
                cmbKoliTipi.Enabled = false;
                txtDesiBilgisi.Enabled = false;
                btn_Bol.Enabled = true;

                txtKargoKoliNo.Focus();
            }
        }

        private bool drKoliKontrol()
        {
            if (drKoli.Rows.Count > 0)
            {
                for (int i = 0; i < drKoli.Rows.Count; i++)
                {
                    string koliTipi = drKoli.Rows[i]["koliNo"].ToString().Trim();
                    string desi = drKoli.Rows[i]["desi"].ToString().Trim();
                    if ((koliTipi == "") || (desi == ""))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}