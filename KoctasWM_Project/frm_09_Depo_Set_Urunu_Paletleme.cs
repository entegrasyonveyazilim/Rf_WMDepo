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
    public partial class frm_09_Depo_Set_Urunu_Paletleme : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_09_Depo_Set_Urunu_Paletleme).Name);
        public frm_09_Depo_Set_Urunu_Paletleme()
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
            txtPaletNo.Text = "";

            txtPaletNo.Enabled = false;
            txtMiktar.Enabled = false;
            txtMalzemeNo.Focus();

        }

        private void frm_09_Depo_Set_Urunu_Paletleme_Load(object sender, EventArgs e)
        {
            logger.info("frm_09_Depo_Set_Urunu_Paletleme_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
            txtMalzemeNo.Focus();
            logger.info("frm_09_Depo_Set_Urunu_Paletleme_Load end");
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p3, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'b');
        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p3, lbl_PaletNo, 'b');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_09_Depo_Set_Urunu_Paletleme_txtPaletNo_KeyDown begin");
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
                    WS_Kontrol.ZKtWmWsSetTasimaKontrolu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSetTasimaKontrolu();
                    WS_Kontrol.ZKtWmWsSetTasimaKontroluResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsSetTasimaKontroluResponse();

                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvEan = txtMalzemeNo.Text.ToString().Trim();
                    
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsSetTasimaKontrolu(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        stok = resp.EsStok;


                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();

                        malzemeNo = stok.Matnr.ToString();

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
                    logger.error("frm_09_Depo_Set_Urunu_Paletleme_txtPaletNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_09_Depo_Set_Urunu_Paletleme_txtPaletNo_KeyDown end");
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_09_Depo_Set_Urunu_Paletleme_btn_Kaydet_Click begin");
            if (txtPaletNo.Text.ToString().Trim() == "")
            {
                return;
            }

            txtPaletNo.Text = txtPaletNo.Text.ToUpper();

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSetUrunuPaletleme chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSetUrunuPaletleme();
                WS_Islem.ZKtWmWsSetUrunuPaletlemeResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSetUrunuPaletlemeResponse();

                chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                chk.IvMatnr = malzemeNo;
                chk.IvMiktar = miktar;
                
                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsSetUrunuPaletleme(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtPaletNo);
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
                        Utility.selectText(txtPaletNo);
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
                logger.error("frm_09_Depo_Set_Urunu_Paletleme_btn_Kaydet_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            logger.info("frm_09_Depo_Set_Urunu_Paletleme_btn_Kaydet_Click end");
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }


        private void txtMiktar_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMiktar.Text.Trim() == "")
                {
                    return;
                }

                try
                {
                    miktar = Convert.ToDecimal(txtMiktar.Text.Trim());
                    txtPaletNo.Enabled = true;
                    Utility.selectText(txtPaletNo);
                }
                catch
                {
                    MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                    Utility.selectText(txtMiktar);
                }
            }


            
        }
    }
}