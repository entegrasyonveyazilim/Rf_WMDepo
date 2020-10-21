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
    public partial class frm_09_Depo_Set_Alanina_Tasima : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_09_Depo_Set_Alanina_Tasima).Name);
        public frm_09_Depo_Set_Alanina_Tasima()
        {
            InitializeComponent();
        }

        decimal miktar;
        string malzemeNo;

        private void formAcilisDuzenle()
        {
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtToplamStok.Text = "";

            txtMiktar.Enabled = false;
            txtMalzemeNo.Focus();

        }

        private void txtPaletNo_GotFocus_1(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }

        private void txtHedefAdres_GotFocus(object sender, EventArgs e)
        {

        }

        private void btn_Geri_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_09_Depo_Set_Alanina_Tasima_Load(object sender, EventArgs e)
        {
            logger.info("frm_09_Depo_Set_Alanina_Tasima_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
            txtMalzemeNo.Focus();
            logger.info("frm_09_Depo_Set_Alanina_Tasima_Load end");
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_09_Depo_Set_Alanina_Tasima_txtPaletNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsSetUrunuKontrolu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSetUrunuKontrolu();
                    WS_Kontrol.ZKtWmWsSetUrunuKontroluResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSetUrunuKontroluResponse();

                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvEan = txtMalzemeNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsSetUrunuKontrolu(chk);

                    
                    
                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        stok = resp.EsStok;
                                               
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtHedefAdres.Text = stok.HedefAdres.ToString();
                        malzemeNo = stok.Matnr.ToString();
                        txtToplamStok.Text = stok.Miktar.ToString();
                        

                        txtMiktar.Enabled = true;
                        Utility.selectText(txtMiktar);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_09_Depo_Set_Alanina_Tasima_txtPaletNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_09_Depo_Set_Alanina_Tasima_txtPaletNo_KeyDown end");
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'b');
        }


        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMiktar.Text.Trim() == "")
                {
                    return;
                }
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_09_Depo_Set_Alanina_Tasima_btn_Kaydet_Click begin");
            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text.Trim());

            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                Utility.selectText(txtMiktar);
                return;
            }

            if (!(miktar > 0))
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSetUrunuTasima chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSetUrunuTasima();
                WS_Islem.ZKtWmWsSetUrunuTasimaResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSetUrunuTasimaResponse();

               
                
                chk.IvMatnr = malzemeNo;
                chk.IvMiktar = miktar;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsSetUrunuTasima(chk);


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
                logger.error("frm_09_Depo_Set_Alanina_Tasima_btn_Kaydet_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_09_Depo_Set_Alanina_Tasima_btn_Kaydet_Click end");
        }

    }
}