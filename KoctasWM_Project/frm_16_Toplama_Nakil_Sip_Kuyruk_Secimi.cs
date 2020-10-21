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
    public partial class frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi).Name);
        public frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi()
        {
            InitializeComponent();
        }

        DataTable drKuyruk = new DataTable();
        public string _kuyrukTipi;

        private void frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_Load(object sender, EventArgs e)
        {
            logger.info("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);


            drKuyruk = new DataTable();
            drKuyruk.Columns.Add("kuyrukNo");
            drKuyruk.Columns.Add("kuyrukAciklamasi");
            drKuyruk.Columns.Add("acikSiparisSayisi");

            //Webservice sorgulanıyor
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsKuyruk chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsKuyruk();
                WS_Kontrol.ZKtWmWsKuyrukResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsKuyrukResponse();
                WS_Kontrol.ZktWmStKuyruk stok = new KoctasWM_Project.WS_Kontrol.ZktWmStKuyruk();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsKuyruk(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    stok = resp.EsKuyruk;

                    txtDepoNo.Text = stok.Lgnum.ToString();
                    txtKullaniciAdi.Text = GlobalData.kullaniciAdi.ToString();
                    txtMevcutKuyruk.Text = stok.Queue.ToString();

                    btn_KuyrukDegistir.Enabled = true;
                    grd_List.Enabled = true;
                    
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_Load "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_Load end");

        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_KuyrukDegistir_Click(object sender, EventArgs e)
        {
            logger.info("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_btn_KuyrukDegistir_Click begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsKuyrukListe chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsKuyrukListe();
                WS_Kontrol.ZKtWmWsKuyrukListeResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsKuyrukListeResponse();


                chk.IvType = _kuyrukTipi;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsKuyrukListe(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    int count = resp.EtKuyruk.Length;
                    WS_Kontrol.ZktWmStKuyruk[] stok = new KoctasWM_Project.WS_Kontrol.ZktWmStKuyruk[count];
                    stok = resp.EtKuyruk;

                    for (int i = 0; i < resp.EtKuyruk.Length; i++)
                    {
                        DataRow row = drKuyruk.NewRow();
                        row["kuyrukNo"] = stok[i].Queue.ToString();
                        row["kuyrukAciklamasi"] = stok[i].Qutxt.ToString();
                        row["acikSiparisSayisi"] = stok[i].Naksip.ToString();

                        drKuyruk.Rows.Add(row);
                    }

                    grd_List.DataSource = null;
                    grd_List.DataSource = drKuyruk;

                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_btn_KuyrukDegistir_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_btn_KuyrukDegistir_Click end");
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_btn_Kaydet_Click begin");
            string kuyrukNo = "";

            bool devamEt = false;

            if (grd_List.CurrentRowIndex == -1)
            {
                devamEt = false;
            }
            else if (grd_List.CurrentCell.RowNumber < 0)
            {
                //MessageBox.Show("Değiştirilecek kuyruk seçiniz", "HATA");
                devamEt = false;
            }
            else
            {
                devamEt = true;
            }

            if (devamEt == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    if (drKuyruk.Rows[grd_List.CurrentCell.RowNumber]["kuyrukNo"].ToString().Trim() != "")
                    {


                        kuyrukNo = drKuyruk.Rows[grd_List.CurrentCell.RowNumber]["kuyrukNo"].ToString().Trim();

                        WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                        WS_Islem.ZKtWmWsKuyrukDegistir chk = new KoctasWM_Project.WS_Islem.ZKtWmWsKuyrukDegistir();
                        WS_Islem.ZKtWmWsKuyrukDegistirResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsKuyrukDegistirResponse();


                        chk.IvQueue = kuyrukNo;

                        srv.Credentials = GlobalData.globalCr;
                        srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                        resp = srv.ZKtWmWsKuyrukDegistir(chk);

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
                        MessageBox.Show("Geçerli bir kuyruk no seçiniz", "HATA");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_btn_Kaydet_Click "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            frm_17_Toplama_Nakil_Sip_Onaylama frm = new frm_17_Toplama_Nakil_Sip_Onaylama();
            frm._kuyrukTipi = _kuyrukTipi;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
            logger.info("frm_16_Toplama_Nakil_Sip_Kuyruk_Secimi_btn_Kaydet_Click end");
            
        }



    }
}