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
    public partial class frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi).Name);

        public frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi()
        {
            InitializeComponent();
        }

        DataTable _kargoFirmalariTablo = new DataTable();
        string _kargoFirmaKodu;

        private void kargoFirmasiCek()
        {
            logger.info("frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi_kargoFirmasiCek begin");
            //Koli Tipleri Çekiliyor
            WS_Yardim.ZKT_WM_WS_YARDIMService srv = new KoctasWM_Project.WS_Yardim.ZKT_WM_WS_YARDIMService();
            WS_Yardim.ZKtWmWsKargoFirmalari chk = new KoctasWM_Project.WS_Yardim.ZKtWmWsKargoFirmalari();
            WS_Yardim.ZKtWmWsKargoFirmalariResponse resp = new KoctasWM_Project.WS_Yardim.ZKtWmWsKargoFirmalariResponse();

            
            srv.Credentials = GlobalData.globalCr;
            srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_yardim");
            resp = srv.ZKtWmWsKargoFirmalari(chk);
            
            if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
            {
                int count = resp.EtKargoFirmasi.Length;
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        
                        DataRow row = _kargoFirmalariTablo.NewRow();
                        row["Lifnr"] = resp.EtKargoFirmasi[i].Lifnr.ToString();
                        row["Mandt"] = resp.EtKargoFirmasi[i].Mandt.ToString();
                        row["Name1"] = resp.EtKargoFirmasi[i].Name1.ToString();
                        row["Name2"] = resp.EtKargoFirmasi[i].Name2.ToString();
                        _kargoFirmalariTablo.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("Kargo firmaları tablosu webservice üzerinden boş geldi.", "HATA");
                }

            }
            else
            {
                MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
            }
            logger.info("frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi_kargoFirmasiCek end");
        }

        private void kargoFirmasiDoldur()
        {
            
            if (_kargoFirmalariTablo.Rows.Count > 0)
            {
                cmbKargoFirmasi.Items.Add("Seçiniz");
                for (int i = 0; i < _kargoFirmalariTablo.Rows.Count; i++)
                {
                    cmbKargoFirmasi.Items.Add(_kargoFirmalariTablo.Rows[i]["Name1"].ToString());
                }
            }
        }

        private string kargoFirmasiKoduVer(string kargoFirmasi)
        {
            string kargoFirmasiKodu = "";
            if (kargoFirmasi != "")
            {
                
                for (int i = 0; i < _kargoFirmalariTablo.Rows.Count; i++)
                {
                    if ((_kargoFirmalariTablo.Rows[i]["Name1"].ToString() == kargoFirmasi.Trim().ToString()) || (_kargoFirmalariTablo.Rows[i]["Name2"].ToString() == kargoFirmasi.Trim().ToString()))
                    {
                        kargoFirmasiKodu = _kargoFirmalariTablo.Rows[i]["Lifnr"].ToString();
                    }
                }
            }
            return kargoFirmasiKodu;
        }

        private void frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false; 
            Utility.loginInfo(lbl_LoginInfo);

            _kargoFirmalariTablo = new DataTable();
            _kargoFirmalariTablo.Columns.Add("Lifnr");
            _kargoFirmalariTablo.Columns.Add("Mandt");
            _kargoFirmalariTablo.Columns.Add("Name1");
            _kargoFirmalariTablo.Columns.Add("Name2");

            kargoFirmasiCek();
            kargoFirmasiDoldur();

            cmbKargoFirmasi.Focus();
        }

        private void formAcilisDuzenle()
        {
            txtKargoKoliNo.Text = "";
            Utility.selectText(txtKargoKoliNo);
        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void cmbKargoFirmasi_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoFirmasi, 'b');
            Utility.setBackBolor(p2, lbl_KargoKoliNo, 'w');
        }

        private void txtKargoKoliNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_KargoFirmasi, 'w');
            Utility.setBackBolor(p2, lbl_KargoKoliNo, 'b');
        }

        private void cmbKargoFirmasi_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbKargoFirmasi.SelectedIndex == 0)
            {
                return;
            }
            
            if (cmbKargoFirmasi.Text.ToString() != "")
            {
                string kargoFirmasi = cmbKargoFirmasi.Text.ToString();
                _kargoFirmaKodu = kargoFirmasiKoduVer(kargoFirmasi);
                Utility.selectText(txtKargoKoliNo);
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi_btn_Kaydet_Click begin");
            if (_kargoFirmaKodu == "")
            {
                MessageBox.Show("Kargo firması seçiniz", "HATA");
                return;
            }
            
            if (txtKargoKoliNo.Text.ToString().Trim() == "")
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsKargoyaTeslim2 chk = new KoctasWM_Project.WS_Islem.ZKtWmWsKargoyaTeslim2();
                WS_Islem.ZKtWmWsKargoyaTeslim2Response resp = new KoctasWM_Project.WS_Islem.ZKtWmWsKargoyaTeslim2Response();

                chk.IvKargoFirmasi = _kargoFirmaKodu.ToString();
                chk.IvKoliNo = txtKargoKoliNo.Text.Trim().ToString();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsKargoyaTeslim2(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtKargoKoliNo);
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        /*
                        if (resp.EtKalanKoli.Length > 0)
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString() + ": Sevkiyata " + resp.EtKalanKoli[0].KoliNo.ToString() + " koli numarası ile devam edebilirsiniz", "BİLGİ");
                        }
                        else
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString() + "Bu kargo firmasına ait tüm koliler teslim edildi", "BİLGİ");
                        }*/

                        
                        
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        formAcilisDuzenle();
                    }
                    else
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                        Utility.selectText(txtKargoKoliNo);
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
                logger.error("frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_22_Dagitim_Mus_Sev_Kolilerin_Kargoya_Verilmesi_btn_Kaydet_Click end");
        }

        private void txtKargoKoliNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }


    }
}