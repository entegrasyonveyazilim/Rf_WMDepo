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
    public partial class frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi).Name);
        public frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi()
        {
            InitializeComponent();
        }

        DataTable _koliTopla;
        string _koliNo;
        string _kunnr = "";
        

        private bool koliKontrol(string koliNo)
        {
            int count = _koliTopla.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (_koliTopla.Rows[i]["koliNo"].ToString() == koliNo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool koliToplamaKontrol()
        {
            int count = _koliTopla.Rows.Count;
            int toplananSay = 0;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (_koliTopla.Rows[i]["ok"].ToString() == "X")
                    {
                        toplananSay++;
                    }
                }
            }
            if (count == toplananSay)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Sevkiyata ait tüm koliler okutulmadı. Lütfen kontrol ediniz", "HATA");
            }

            return false;
        }

        private bool koliIsaretle(string koliNo)
        {
            int count = _koliTopla.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (_koliTopla.Rows[i]["koliNo"].ToString() == koliNo)
                    {
                        _koliTopla.Rows[i]["ok"] = "X";
                        return true;
                    }
                }
            }

            return false;
        }

        private void frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_Load(object sender, EventArgs e)
        {
            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            _koliTopla = new DataTable();
            _koliTopla.Columns.Add("koliNo");
            _koliTopla.Columns.Add("VbelnVl");
            _koliTopla.Columns.Add("ok");
            

            //Webservice sorgulanıyor
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsGetSevkiyatNo chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsGetSevkiyatNo();
                WS_Kontrol.ZKtWmWsGetSevkiyatNoResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsGetSevkiyatNoResponse();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsGetSevkiyatNo(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    txtSevkiyatNo.Text = resp.EvSevkiyatNo.ToString();
                    txtPaletKargoNo.Enabled = true;
                    btn_Ekle.Enabled = true;
                    Utility.selectText(txtPaletKargoNo);
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_Load " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_Load end");
        }

 
        private void txtPaletKargoNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p2, lbl_PaletKargoNo, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_btn_Ekle_Click begin");
            if (txtPaletKargoNo.Text.Trim() == "")
            {
                return;
            }

            txtPaletKargoNo.Text = txtPaletKargoNo.Text.ToString().Trim().ToUpper();
            _koliNo = txtPaletKargoNo.Text;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsYuklemeMalKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsYuklemeMalKontrol();
                WS_Kontrol.ZKtWmWsYuklemeMalKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsYuklemeMalKontrolResponse();
                

                chk.IvKoliNo = _koliNo;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsYuklemeMalKontrol(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    WS_Kontrol.ZktWmKargo[] kargo = new KoctasWM_Project.WS_Kontrol.ZktWmKargo[resp.EtCargo.Length];
                    kargo = resp.EtCargo;
                    int koliMiktari = kargo.Length;


                    // Okunan koli ve ilişkili diğer koliler listeye ekleniyor ve 
                    // okunan koli işaretleniyor
                    bool ekle = true;
                    bool isaretle = true;
                    

                    //İlk okumada ilk satırın kunnr alanı seçiliyor
                    if ((kargo.Length > 0) && (_kunnr == ""))
                    {
                        _kunnr = kargo[0].Kunnr.ToString();
                    }

                    for (int i = 0; i < kargo.Length; i++)
                    {
                        isaretle = true;
                        
                        //Koli daha önce tabloya eklenmiş mi
                        if (koliKontrol(kargo[i].KoliNo.ToString()))
                        {
                            ekle = false;
                        }
                        else
                        {
                            ekle = true;
                        }

                        //kunnr kontrolü
                        if (_kunnr != kargo[i].Kunnr.ToString())
                        {
                            ekle = false;
                            isaretle = false;
                            MessageBox.Show("Okuttuğunuz palet başka mağazaya ait.", "HATA");
                            break;
                        }

                        //eğer koli daha önce tabloya eklenmemiş ise tabloya ekleniyor
                        if (ekle)
                        {
                            DataRow row = _koliTopla.NewRow();
                            row["VbelnVl"] = kargo[i].VbelnVl.ToString();
                            row["koliNo"] = kargo[i].KoliNo.ToString();
                            row["ok"] = "";
                            _koliTopla.Rows.Add(row);
                        }
                    }

                    //Okunan koli tabloda işaretleniyor
                    if (isaretle)
                    {
                        if (!koliIsaretle(_koliNo))
                        {
                            MessageBox.Show("Okutulan koli numarası teslimatta bulunamadı", "HATA");
                        }
                    }
                    

                    grd_List.DataSource = null;
                    grd_List.DataSource = _koliTopla;
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                }

                txtPaletKargoNo.Text = "";
                Utility.selectText(txtPaletKargoNo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_btn_Ekle_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_btn_Ekle_Click end");

        }

        private void txtPaletKargoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Ekle_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_btn_Kaydet_Click begin");
            //Listedeki tüm koliler toplanmış mı?
            if (koliToplamaKontrol())
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                    WS_Islem.ZKtWmWsYuklemeTeslimat chk = new KoctasWM_Project.WS_Islem.ZKtWmWsYuklemeTeslimat();
                    WS_Islem.ZKtWmWsYuklemeTeslimatResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsYuklemeTeslimatResponse();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    
                    //Toplanan koliler webservice geçiriliyor
                    WS_Islem.ZktWmStKoliHead[] koli = new KoctasWM_Project.WS_Islem.ZktWmStKoliHead[_koliTopla.Rows.Count];
                    for (int i = 0; i < _koliTopla.Rows.Count; i++)
                    {
                        koli[i] = new KoctasWM_Project.WS_Islem.ZktWmStKoliHead();
                        koli[i].KoliNo = _koliTopla.Rows[i]["koliNo"].ToString();
                    }

                    chk.IvSevkiyatNo = txtSevkiyatNo.Text.ToString().Trim();
                    chk.ItKoli = koli;

                    resp = srv.ZKtWmWsYuklemeTeslimat(chk);

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
                            Cursor.Current = Cursors.Default;
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "HATA");
                    logger.error("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_btn_Kaydet_Click " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_btn_Kaydet_Click end");
        }

        private void grd_List_DoubleClick(object sender, EventArgs e)
        {
            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_grd_List_DoubleClick begin");
            try
            {
                //Seçilen satıra ait koliNo çekiliyor
                string secilenKoli = _koliTopla.Rows[grd_List.CurrentCell.RowNumber]["koliNo"].ToString();

                if ((secilenKoli != "") && (MessageBox.Show(secilenKoli + " nolu koli ve ilişkili diğer kolileri listeden çıkartmak istediğinize emin misiniz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsYuklemeMalKontrol chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsYuklemeMalKontrol();
                    WS_Kontrol.ZKtWmWsYuklemeMalKontrolResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsYuklemeMalKontrolResponse();

                    chk.IvKoliNo = secilenKoli;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsYuklemeMalKontrol(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        WS_Kontrol.ZktWmKargo[] kargo = new KoctasWM_Project.WS_Kontrol.ZktWmKargo[resp.EtCargo.Length];
                        kargo = resp.EtCargo;

                        for (int i = 0; i < kargo.Length; i++)
                        {
                            //_koliTopla tablosundaki eşleşen koliNo lar listeden çıkartılıyor
                            for (int j = 0; j < _koliTopla.Rows.Count; j++)
                            {
                                if (_koliTopla.Rows[j]["koliNo"].ToString() == kargo[i].KoliNo.ToString())
                                {
                                    _koliTopla.Rows.RemoveAt(j);
                                }
                            }
                        }

                        grd_List.DataSource = null;
                        grd_List.DataSource = _koliTopla;
                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_grd_List_DoubleClick " + ex.Message);
            }
            logger.info("frm_24_Dagitim_Mag_Sev_Yukleme_Mal_Cikisi_grd_List_DoubleClick end");
        }
    }
}