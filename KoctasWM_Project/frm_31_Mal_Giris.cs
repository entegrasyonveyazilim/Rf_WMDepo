using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Web.Services.Protocols;
using Microsoft.Win32;
namespace KoctasWM_Project
{
    public partial class frm_31_Mal_Giris : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_31_Mal_Giris).Name);
        public frm_31_Mal_Giris()
        {
            InitializeComponent();
        }

        ArrayList materials = new ArrayList();
        WS_Kontrol.ZkmobilMatlist[] sas_fs = new KoctasWM_Project.WS_Kontrol.ZkmobilMatlist[1000];
        int lenght = 0;

        private void frm_31_Mal_Giris_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);


        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btn_MalzemeGirisi_Click(object sender, EventArgs e)
        {
            


            if (lst_Siparis.Items.Count == 0 || txtIrsaliyeNo.Text.Trim() == "")
            {
                return;
            }
            try
            {

                frm_31_Mal_Giris2 frm = new frm_31_Mal_Giris2();
                frm.belgeTarihi = dtp_belge.Value;
                frm.kayitTarihi = dtp_kayit.Value;
                frm.materials = materials;
                frm.irsNo = txtIrsaliyeNo.Text.Trim();
                frm.sas_fs = sas_fs;
                frm.sas_lenght = lenght;
                frm.sevkiyatNo = txtSevkiyatNo.Text.Trim().ToUpper();

                frm.siparis_sayisi = lst_Siparis.Items.Count;
                frm.Horoz = chk_horoz.Checked;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                lst_Siparis.Items.Clear();
                sas_fs = new KoctasWM_Project.WS_Kontrol.ZkmobilMatlist[1000];
                materials.Clear();
                lenght = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekran yenilenemedi: " + ex.Message, "HATA!");
                this.Close();
            }


        }

        private void dtp_belge_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_BelgeTarihi, 'b');
            Utility.setBackBolor(p2, lbl_KayitTarihi, 'w');
            Utility.setBackBolor(p3, lbl_IrsaliyeNo, 'w');
            Utility.setBackBolor(p4, lbl_SevkiyatNo, 'w');
            Utility.setBackBolor(p5, lbl_SiparisNo, 'w');
        }

        private void dtp_kayit_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_BelgeTarihi, 'w');
            Utility.setBackBolor(p2, lbl_KayitTarihi, 'b');
            Utility.setBackBolor(p3, lbl_IrsaliyeNo, 'w');
            Utility.setBackBolor(p4, lbl_SevkiyatNo, 'w');
            Utility.setBackBolor(p5, lbl_SiparisNo, 'w');
        }

        private void txtIrsaliyeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_BelgeTarihi, 'w');
            Utility.setBackBolor(p2, lbl_KayitTarihi, 'w');
            Utility.setBackBolor(p3, lbl_IrsaliyeNo, 'b');
            Utility.setBackBolor(p4, lbl_SevkiyatNo, 'w');
            Utility.setBackBolor(p5, lbl_SiparisNo, 'w');
        }

        private void txtSevkiyatNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_BelgeTarihi, 'w');
            Utility.setBackBolor(p2, lbl_KayitTarihi, 'w');
            Utility.setBackBolor(p3, lbl_IrsaliyeNo, 'w');
            Utility.setBackBolor(p4, lbl_SevkiyatNo, 'b');
            Utility.setBackBolor(p5, lbl_SiparisNo, 'w');
        }

        private void txtSiparisNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_BelgeTarihi, 'w');
            Utility.setBackBolor(p2, lbl_KayitTarihi, 'w');
            Utility.setBackBolor(p3, lbl_IrsaliyeNo, 'w');
            Utility.setBackBolor(p4, lbl_SevkiyatNo, 'w');
            Utility.setBackBolor(p5, lbl_SiparisNo, 'b');
        }


        private void chk_horoz_Click(object sender, EventArgs e)
        {
            if (chk_horoz.Checked == true)
            {
                txtSevkiyatNo.Enabled = true;
                btn_KontrolEt.Enabled = true;
                txtSiparisNo.Enabled = false;
                btn_Ekle.Enabled = false;
                txtSevkiyatNo.Focus();
            }
            else
            {
                txtSevkiyatNo.Enabled = false;
                btn_KontrolEt.Enabled = false;
                txtSiparisNo.Enabled = true;
                btn_Ekle.Enabled = true;
            }
        }

        private void txtSevkiyatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_KontrolEt_Click(new object(), new EventArgs());
            }
        }

        private void btn_KontrolEt_Click(object sender, EventArgs e)
        {
            logger.info("frm_31_Mal_Giris_btn_KontrolEt_Click begin");
            if (txtSevkiyatNo.Text.Trim() == "")
            {
                MessageBox.Show("Sevkiyat No giriniz", "HATA");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZmbSevkiyatHrzDty[] itDetay = new KoctasWM_Project.WS_Kontrol.ZmbSevkiyatHrzDty[0];
                WS_Kontrol.ZmbSevkiyatHrz[] itSevkiyat = new KoctasWM_Project.WS_Kontrol.ZmbSevkiyatHrz[0];
                WS_Kontrol.ZKtWmWsSevkiyatSiparis chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSevkiyatSiparis();
                WS_Kontrol.ZKtWmWsSevkiyatSiparisResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSevkiyatSiparisResponse();

                chk.ItDetay = itDetay;
                chk.ItSevkiyat = itSevkiyat;
                chk.ImSevkno = txtSevkiyatNo.Text.Trim().ToUpper();
                chk.ImDetay = "X";

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsSevkiyatSiparis(chk);

                // Eger kontrol sonras?nda hiçbir sipari? dönmüyorsa 
                // uyar? veriliyor
                if (resp.ItSevkiyat.Length == 0)
                {
                    MessageBox.Show("Belirtilen sevkiyat numaras?na ait sipari? listesi bulunamad?", "HATA");
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else if (resp.ItSevkiyat.Length > 0)
                {
                    //lst_Siparis.Items.Clear();
                    for (int i = 0; i < resp.ItSevkiyat.Length; i++)
                    {
                        string sipNo = resp.ItSevkiyat[i].Ebeln.ToString().Trim();

                        //Herbir siparis detayi cekiliyor
                        WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv2 = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                        WS_Kontrol.ZkmobilMatlist[] matlist = new KoctasWM_Project.WS_Kontrol.ZkmobilMatlist[0];
                        WS_Kontrol.ZkmobilReturn[] ret = new KoctasWM_Project.WS_Kontrol.ZkmobilReturn[0];
                        WS_Kontrol.ZKtWmWsMgCheckSas sas = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMgCheckSas();
                        WS_Kontrol.ZKtWmWsMgCheckSasResponse resp2 = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMgCheckSasResponse();

                        sas.TeMatlist = matlist;
                        sas.TeReturn = ret;
                        sas.IEbeln = sipNo;

                        srv2.Credentials = GlobalData.globalCr;
                        srv2.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                        resp2 = srv2.ZKtWmWsMgCheckSas(sas);

                        // Eger SAS kontrolu sonras?nda siparis kaydi HOROZ'a ait bir 
                        // kay?t ise, checkbox ?n seçilmesi isteniyor.
                        if ((resp2.ExType1 == "1") && (!chk_horoz.Checked))
                        {
                            MessageBox.Show("Bu sipari? için 'Horoz Lojistik' kutusunu i?aretleyiniz.", "HATA");
                        }
                        else if (resp2.TeReturn.Length > 0)
                        {
                            if (resp2.TeReturn[0].RcCode.ToUpper() == "S" && resp2.TeMatlist.Length > 0)
                            {
                                lst_Siparis.Items.Insert(0, sipNo);
                                for (int j = 0; j < resp2.TeMatlist.Length; j++)
                                {
                                    try
                                    {
                                        materials.Add(Convert.ToInt64(resp2.TeMatlist[j].Ean11));
                                    }
                                    catch { }

                                    sas_fs[lenght] = resp2.TeMatlist[j];
                                    sas_fs[lenght].Ebeln = sipNo;


                                    //ilgili siparis ve malzeme numaras?na göre Amenge degeri bulunuyor
                                    if (resp.ItDetay.Length > 0)
                                    {
                                        for (int ii = 0; ii < resp.ItDetay.Length; ii++)
                                        {
                                            if ((resp.ItDetay[ii].Ebeln.ToString().Trim() == sipNo) && (resp.ItDetay[ii].Matnr.TrimStart('0').ToString() == sas_fs[lenght].Matnr))
                                            {
                                                //Acik siparis miktarlari Matlist tablosuna ataniyor
                                                sas_fs[lenght].Amenge = Convert.ToDecimal(resp.ItDetay[ii].Amenge.ToString());
                                                break;
                                            }
                                        }
                                    }


                                    lenght++;
                                }
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_31_Mal_Giris_btn_KontrolEt_Click " + ex.Message);
            }

            if (lenght == 0)
            {
                MessageBox.Show("Girilen sevkiyat numaras?na ait mal kabulu yap?lacak sipari? listesi bulunmamaktad?r.", "B?LG?");
            }
            logger.info("frm_31_Mal_Giris_btn_KontrolEt_Click end");
        }

        private void txtSiparisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_Ekle_Click(new object(), new EventArgs());
            }
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            logger.info("frm_31_Mal_Giris_btn_Ekle_Click begin");
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZkmobilMatlist[] matlist = new KoctasWM_Project.WS_Kontrol.ZkmobilMatlist[0];
                WS_Kontrol.ZkmobilReturn[] ret = new KoctasWM_Project.WS_Kontrol.ZkmobilReturn[0];
                WS_Kontrol.ZKtWmWsMgCheckSas sas = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMgCheckSas();
                WS_Kontrol.ZKtWmWsMgCheckSasResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsMgCheckSasResponse();


                sas.TeMatlist = matlist;
                sas.TeReturn = ret;
                sas.IEbeln = txtSiparisNo.Text.Trim();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsMgCheckSas(sas);


                // Eger SAS kontrolu sonras?nda siparis kaydi HOROZ'a ait bir 
                // kay?t ise, checkbox ?n seçilmesi isteniyor.
                if ((resp.ExType1 == "1") && (!chk_horoz.Checked))
                {
                    MessageBox.Show("Bu sipari? için 'Horoz Lojistik' kutusunu i?aretleyiniz.", "HATA");
                }
                else if (resp.TeReturn.Length > 0)
                {
                    if (resp.TeReturn[0].RcCode.ToUpper() == "S" && resp.TeMatlist.Length > 0)
                    {
                        //lst_Siparis.Items.Add(txt_sas.Text.Trim());
                        lst_Siparis.Items.Insert(0, txtSiparisNo.Text.Trim());
                        for (int i = 0; i < resp.TeMatlist.Length; i++)
                        {
                            //try { materials.Add(Convert.ToInt64(resp.TeMatlist[i].Matnr)); }
                            //catch { }
                            try
                            {
                                materials.Add(Convert.ToInt64(resp.TeMatlist[i].Ean11));
                            }
                            catch { }
                            //try { materials.Add(Convert.ToInt64(resp.TeMatlist[i].Ean112)); }
                            //catch { }                        
                            sas_fs[lenght] = resp.TeMatlist[i];
                            sas_fs[lenght].Ebeln = txtSiparisNo.Text.Trim();
                            lenght++;
                        }
                        txtSiparisNo.Text = "";
                    }
                    else
                    {
                        txtSiparisNo.Text = "";
                        MessageBox.Show(resp.TeReturn[0].RcText, "HATA");
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_31_Mal_Giris_btn_Ekle_Click " + ex.Message);
            }
            logger.info("frm_31_Mal_Giris_btn_Ekle_Click end");
        }

        private void dtp_belge_ValueChanged(object sender, EventArgs e)
        {
            this.Activate();
        }



    }
}