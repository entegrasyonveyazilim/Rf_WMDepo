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
    public partial class frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim).Name);
        public frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim()
        {
            InitializeComponent();
        }

        decimal miktar;
        string malzemeNo;
        DataTable _topla;
        string _depoAdresi;
        WS_Yardim.ZktWmSayimCnl[] _sayim;

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = "";

            txtMalzemeNo.Text = "";
            txtMalzemeNo.Enabled = false;

            txtMalzemeTanimi.Text = "";
            txtOlcuBirimi.Text = "";

            txtMiktar.Text = "";
            txtMiktar.Enabled = false;

            miktar = 0;
            
            Utility.selectText(txtPaletNo);
        }

        private void formBitir()
        {
            formAcilisDuzenle();

            txtPaletNo.Enabled = false;
            txtDepoAdresi.Enabled = true;
            txtDepoAdresi.Text = "";
            Utility.selectText(txtDepoAdresi);
            _depoAdresi = "";
            _topla.Rows.Clear();
            malzemeNo = "";

        }

        private void frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            _topla = new DataTable();
            _topla.Columns.Add("Lgpla");
            _topla.Columns.Add("Lenum");
            _topla.Columns.Add("Matnr");
            _topla.Columns.Add("Menge");

            Utility.selectText(txtDepoAdresi);


        }

        private void txtDepoAdresi_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DepoAdresi, 'b');
            Utility.setBackBolor(p2, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_Miktar, 'p');

        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DepoAdresi, 'w');
            Utility.setBackBolor(p2, lbl_PaletNo, 'b');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_Miktar, 'p');
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DepoAdresi, 'w');
            Utility.setBackBolor(p2, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p3, lbl_Miktar, 'p');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DepoAdresi, 'w');
            Utility.setBackBolor(p2, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_Miktar, 'b');
        }

        private void txtDepoAdresi_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_txtDepoAdresi_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDepoAdresi.Text.ToString().Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsSayimAdresOner chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSayimAdresOner();
                    WS_Kontrol.ZKtWmWsSayimAdresOnerResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSayimAdresOnerResponse();

                    txtDepoAdresi.Text = _depoAdresi = txtDepoAdresi.Text.ToString().ToUpper().Trim();
                    chk.IvLgpla = _depoAdresi;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsSayimAdresOner(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        //Ilk sorgu başarılı ise; detay tablosu çekiliyor
                        WS_Yardim.ZKT_WM_WS_YARDIMService srv1 = new KoctasWM_Project.WS_Yardim.ZKT_WM_WS_YARDIMService();
                        WS_Yardim.ZKtWmWsSayimKytOnceKont chk1 = new KoctasWM_Project.WS_Yardim.ZKtWmWsSayimKytOnceKont();
                        WS_Yardim.ZKtWmWsSayimKytOnceKontResponse resp1 = new KoctasWM_Project.WS_Yardim.ZKtWmWsSayimKytOnceKontResponse();

                        chk1.IvLgpla = _depoAdresi;
                        srv1.Credentials = GlobalData.globalCr;
                        srv1.Url = Utility.getWsUrlForWM("zkt_wm_ws_yardim");
                        resp1 = srv1.ZKtWmWsSayimKytOnceKont(chk1);

                        if (resp1.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                        {
                            if (resp1.EtCnliSym.Length > 0)
                            {
                                if (MessageBox.Show("Bu adres daha önce sayılmış. Sayımın detayını görmek istiyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    Cursor.Current = Cursors.Default;
                                    _sayim = new KoctasWM_Project.WS_Yardim.ZktWmSayimCnl[resp1.EtCnliSym.Length];
                                    _sayim = resp1.EtCnliSym;

                                    frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay frm = new frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay();
                                    frm._sayim = _sayim;
                                    if (frm.ShowDialog() == DialogResult.Abort)
                                    {
                                        this.Close();
                                    } 
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }

                        txtPaletNo.Enabled = true;
                        txtDepoAdresi.Enabled = false;
                        Utility.selectText(txtPaletNo);
                        
                        
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
                    logger.error("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_txtDepoAdresi_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            logger.info("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_txtDepoAdresi_KeyDown end");
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    if (txtPaletNo.Text.ToString().Trim() == "")
                    {
                        return;
                    }
                    else if (!((Convert.ToInt64(txtPaletNo.Text) > 1000000000) && (Convert.ToInt64(txtPaletNo.Text) < 3000000000)))
                    {
                        return;
                    }


                    txtPaletNo.Text = txtPaletNo.Text.Trim().ToString().ToUpper();
                    txtMalzemeNo.Enabled = true;
                    Utility.selectText(txtMalzemeNo);
                }
                catch
                {
                    MessageBox.Show("Palet no olarak yalnızca rakam giriniz", "HATA");
                    Utility.selectText(txtPaletNo);
                    return;
                }
                
            }
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_txtMalzemeNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                    WS_Islem.ZKtWmWmMalzemeInfo chk = new KoctasWM_Project.WS_Islem.ZKtWmWmMalzemeInfo();
                    WS_Islem.ZKtWmWmMalzemeInfoResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWmMalzemeInfoResponse();


                    chk.IvEan = txtMalzemeNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    resp = srv.ZKtWmWmMalzemeInfo(chk);
                    

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        malzemeNo = resp.EsMalzeme.Matnr.ToString();
                        txtMalzemeNo.Text = Convert.ToInt64(malzemeNo.ToString()).ToString();
                        txtMalzemeTanimi.Text = resp.EsMalzeme.Maktx.ToString();
                        txtOlcuBirimi.Text = resp.EsMalzeme.Meins.ToString();
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
                    logger.error("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_txtMalzemeNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_txtMalzemeNo_KeyDown end");
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            /*
            if (!(_topla.Rows.Count > 0))
            {
                MessageBox.Show("Paletlenecek malzeme girişi yapmadınız.", "HATA");
                return;
            }*/

            logger.info("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_btn_Kaydet_Click begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv2 = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSayimKaydet chk2 = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimKaydet();
                WS_Islem.ZKtWmWsSayimKaydetResponse resp2 = new KoctasWM_Project.WS_Islem.ZKtWmWsSayimKaydetResponse();
                WS_Islem.ZktWmSayimCnl[] sayim;
                

  
                //Tablo ayriştırılıyor
                //WS_Islem.ZktWmSayimCnl[] sayim = new KoctasWM_Project.WS_Islem.ZktWmSayimCnl[_sayim.Length];
                if (_topla.Rows.Count > 0)
                {
                    sayim = new KoctasWM_Project.WS_Islem.ZktWmSayimCnl[_topla.Rows.Count];
                    for (int i = 0; i < _topla.Rows.Count; i++)
                    {
                        sayim[i] = new KoctasWM_Project.WS_Islem.ZktWmSayimCnl();
                        sayim[i].Ean11 = "";
                        sayim[i].Lenum = _topla.Rows[i]["Lenum"].ToString();
                        sayim[i].Lgnum = "";
                        sayim[i].Lgpla = _topla.Rows[i]["Lgpla"].ToString();
                        sayim[i].Lgtyp = "";
                        sayim[i].Mandt = "";
                        sayim[i].Matnr = _topla.Rows[i]["Matnr"].ToString();
                        sayim[i].Meins = "";
                        sayim[i].Menge = Convert.ToDecimal(_topla.Rows[i]["Menge"].ToString());
                        sayim[i].Udate = "";
                        sayim[i].Uname = "";
                        sayim[i].Uzeit = DateTime.Now.ToString();
                    }
                }
                else
                {
                    sayim = new KoctasWM_Project.WS_Islem.ZktWmSayimCnl[1];

                    sayim[0] = new KoctasWM_Project.WS_Islem.ZktWmSayimCnl();
                    sayim[0].Ean11 = "";
                    sayim[0].Lenum = "";
                    sayim[0].Lgnum = "";
                    sayim[0].Lgpla = txtDepoAdresi.Text.ToString().Trim();
                    sayim[0].Lgtyp = "";
                    sayim[0].Mandt = "";
                    sayim[0].Matnr = "";
                    sayim[0].Meins = "";
                    sayim[0].Menge = 0;
                    sayim[0].Udate = "";
                    sayim[0].Uname = "";
                    sayim[0].Uzeit = DateTime.Now.ToString();
                }
                
                

                /*
                int sayimIndeks = _topla.Rows.Count;
                bool buldum;
                //Topla haricinde kalan malzemeler de ekleniyor ve 0 sayılıyor
                for (int i = 0; i < _sayim.Length; i++)
                {
                    buldum = false;
                    for (int j = 0; j < _topla.Rows.Count; j++)
                    {
                        if (_sayim[i].Matnr.ToString() == _topla.Rows[j]["Matnr"].ToString())
                        {
                            buldum = true;
                        }
                    }

                    //Eğer _topla tablosunda malzeme yok ise 0 olarak sayılıyor
                    if (!buldum)
                    {
                        sayim[sayimIndeks] = new KoctasWM_Project.WS_Islem.ZktWmSayimCnl();
                        sayim[sayimIndeks].Ean11 = "";
                        sayim[sayimIndeks].Lenum = _sayim[i].Matnr.ToString();
                        sayim[sayimIndeks].Lgnum = "";
                        sayim[sayimIndeks].Lgpla = _sayim[i].Lgpla.ToString();
                        sayim[sayimIndeks].Lgtyp = "";
                        sayim[sayimIndeks].Mandt = "";
                        sayim[sayimIndeks].Matnr = _sayim[i].Matnr.ToString();
                        sayim[sayimIndeks].Meins = "";
                        sayim[sayimIndeks].Menge = 0;
                        sayim[sayimIndeks].Udate = "";
                        sayim[sayimIndeks].Uname = "";
                        sayim[sayimIndeks].Uzeit = "";
                        sayimIndeks++;
                    }

                }*/

                chk2.ItCnliSym = sayim;

                srv2.Credentials = GlobalData.globalCr;
                srv2.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp2 = srv2.ZKtWmWsSayimKaydet(chk2);


                if (resp2.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp2.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp2.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtMiktar);
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        formBitir();
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
                Utility.selectText(txtMiktar);
                logger.error("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_btn_Kaydet_Click end");
        }

        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Onayla_Click(new object(), new EventArgs());
            }
        }

        private void btn_Onayla_Click(object sender, EventArgs e)
        {

            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text);
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal bir değer giriniz", "HATA");
                Utility.selectText(txtMiktar);
                return;
            }

            string msg = "";

            /*
            if (!(miktar > 0))
            {
                return;
            }*/
            
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Girilen malzeme ve değerler toplanıyor
                bool ekle = true;

                for (int i = 0; i < _topla.Rows.Count; i++)
                {
                    //Eğer malzeme daha önce eklenmiş ise
                    if ((_topla.Rows[i]["Matnr"].ToString() == malzemeNo.ToString().Trim()) && (_topla.Rows[i]["Lenum"].ToString() == txtPaletNo.Text.ToString().Trim()))
                    {
                        ekle = false;
                        msg = "Bu malzeme daha önce eklenmiştir.";
                    }
                    else if ((_topla.Rows[i]["Matnr"].ToString() != malzemeNo.ToString().Trim()) && (_topla.Rows[i]["Lenum"].ToString() == txtPaletNo.Text.ToString().Trim()))
                    {
                        ekle = false;
                        msg = "Bu palete farklı bir malzeme daha önce eklenmiştir.";
                    }
                }

                if (ekle)
                {
                    DataRow row = _topla.NewRow();
                    row["Lgpla"] = _depoAdresi;
                    row["Lenum"] = txtPaletNo.Text.ToString().Trim();
                    row["Matnr"] = malzemeNo.ToString().Trim();
                    row["Menge"] = miktar.ToString();

                    _topla.Rows.Add(row);
                    formAcilisDuzenle();
                }
                else
                {
                    MessageBox.Show(msg, "HATA");
                    formAcilisDuzenle();
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
}