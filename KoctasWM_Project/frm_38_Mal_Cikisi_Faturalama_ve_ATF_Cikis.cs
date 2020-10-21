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
    public partial class frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis).Name);
        public frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis()
        {
            InitializeComponent();
        }

        string _kargoKoliNo;
        string _faturaNo;
        public WS_Kontrol.ZktWmStTeslimat teslimat;

        private void frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;

            Utility.loginInfo(lbl_LoginInfo);

            _kargoKoliNo = "";
            Utility.selectText(txtKargoKoliNo);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis_btn_Kaydet_Click begin");
            try
            {
                //Kontrollere göre işlem yapılıyor
                if (teslimat.Augru.ToString() != "")
                {
                    if (MessageBox.Show("İlgili satış iptal edilmiş. Toplamayı geri almak istiyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        //Z_KT_WM_WS_TESLIMAT_TOP_GER_AL fonk. çalıştırılıyor
                        Cursor.Current = Cursors.WaitCursor;
                        WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                        WS_Islem.ZKtWmWsTeslimatTopGerAl chk = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimatTopGerAl();
                        WS_Islem.ZKtWmWsTeslimatTopGerAlResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimatTopGerAlResponse();

                        chk.IvLgpla = teslimat.Vbeln.ToString();

                        srv.Credentials = GlobalData.globalCr;
                        srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                        resp = srv.ZKtWmWsTeslimatTopGerAl(chk);

                        Cursor.Current = Cursors.Default;
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
                                this.Close();
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
                    else
                    {
                        Utility.selectText(txtKargoKoliNo);
                        return;
                    }
                }
                else
                {
                    
                    //WBSTK alanı kontrol ediliyor
                    if (teslimat.Wbstk.ToString() != "C")
                    {
                        if (MessageBox.Show("Mal çıkışını onaylıyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            //Z_KT_WM_WS_AMBALAJLAMA_FATURA fonk. çalışacak
                            Cursor.Current = Cursors.WaitCursor;
                            WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                            WS_Islem.ZKtWmWsAmbalajlamaFatura chk = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlamaFatura();
                            WS_Islem.ZKtWmWsAmbalajlamaFaturaResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlamaFaturaResponse();

                            chk.IvVbeln = teslimat.Vbeln.ToString();

                            srv.Credentials = GlobalData.globalCr;
                            srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                            resp = srv.ZKtWmWsAmbalajlamaFatura(chk);

                            Cursor.Current = Cursors.Default;
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

                                    _faturaNo = resp.EvVbelnVf.ToString();


                                    //Kargo koli bölme ekranı çağırılıyor - 24.07.2017 by Gökhan
                                    frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol frmBol = new frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol();
                                    bool devam = false;
                                    if (frmBol.ShowDialog() == DialogResult.OK)
                                    {
                                        devam = true;
                                    }

                                    if (devam)
                                    {
                                        //Fatura teyit ekranı
                                        frm_20_v2_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D frm = new frm_20_v2_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D();
                                        //frm._faturaNo = _faturaNo;
                                        frm._belgeNo = teslimat.Vbeln.ToString();
                                        frm._koliNo = txtKargoKoliNo.Text.ToString().Trim();
                                        if (frm.ShowDialog() == DialogResult.OK)
                                        {
                                            this.Close();
                                        }
                                    }
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
                        else
                        {
                            Utility.selectText(txtKargoKoliNo);
                            return;
                        }
                    }
                    else
                    {

                        //Kargo koli bölme ekranı çağırılıyor - 24.07.2017 by Gökhan
                        frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol frmBol = new frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_KoliBol();
                        bool devam = false;
                        if (frmBol.ShowDialog() == DialogResult.OK)
                        {
                            devam = true;
                        }

                        if (devam)
                        {

                            //Fatura teyit ekranı
                            //frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D frm = new frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D();
                            frm_20_v2_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D frm = new frm_20_v2_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D();
                            //frm._faturaNo = _faturaNo;
                            frm._koliNo = txtKargoKoliNo.Text.ToString().Trim();
                            frm._belgeNo = teslimat.Vbeln.ToString();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }


                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis_btn_Kaydet_Click " + ex.Message);
            }
            logger.info("frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis_btn_Kaydet_Click end");
        }

        private void txtKargoKoliNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoKoliNo, 'b');
        }


        private void txtKargoKoliNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis_txtKargoKoliNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtKargoKoliNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                _kargoKoliNo = txtKargoKoliNo.Text.ToString().Trim();

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsMalFatAtfKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMalFatAtfKontrol();
                    WS_Kontrol.ZKtWmWsMalFatAtfKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMalFatAtfKontrolResponse();
                    teslimat = new KoctasWM_Project.WS_Kontrol.ZktWmStTeslimat();
                    

                    chk.IvKoliNo = _kargoKoliNo;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsMalFatAtfKontrol(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        teslimat = resp.EsTeslimat;


                        if ((teslimat.Lfart.ToString() != "ZLF") && (teslimat.Lfart.ToString() != "ZNLF")) 
                        {
                            MessageBox.Show("Bu koli müşteri sevkiyatına ait değil.", "HATA");
                            Utility.selectText(txtKargoKoliNo);
                            return;

                        }

                        //Alanlar dolduruluyor
                        txtMalzemeNo.Text = Convert.ToInt64(teslimat.Matnr.ToString()).ToString();
                        txtMalzemeTanimi.Text = teslimat.Maktx.ToString();
                        txtTeslimatNo.Text = teslimat.Vbeln.ToString();
                        if ((teslimat.Lfart.ToString() == "ZLF") || (teslimat.Lfart.ToString() == "ZNLF"))
                        {
                            txtTeslimatTipi.Text = "Müşteri";
                        }
                        else if (teslimat.Lfart.ToString() == "NL")
                        {
                            txtTeslimatTipi.Text = "Mağaza";
                        }
                        else
                        {
                            txtTeslimatTipi.Text = teslimat.Lfart.ToString();
                        }

                        txtOlcuBirimi.Text = teslimat.Meins.ToString();
                        txtMiktar.Text = teslimat.Menge.ToString();

                        _faturaNo = teslimat.VbelnVf2.ToString();

                        btn_Kaydet.Enabled = true;
                 

                        

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis_txtKargoKoliNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            logger.info("frm_38_Mal_Cikisi_Faturalama_ve_ATF_Cikis_txtKargoKoliNo_KeyDown end");
            
        }


    }
}