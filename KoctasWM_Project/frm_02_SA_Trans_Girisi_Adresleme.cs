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
    public partial class frm_02_SA_Trans_Girisi_Adresleme : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_02_SA_Trans_Girisi_Adresleme).Name);

        public frm_02_SA_Trans_Girisi_Adresleme()
        {
            InitializeComponent();
        }

        public string _paletNo = "";


        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtOnerilenAdres.Text = "";
            txtHedefAdres.Text = "";

            txtHedefAdres.Enabled = false;
            btn_Kopyala.Enabled = false;

            Utility.selectText(txtPaletNo);

        }

        private void frm_02_SA_Trans_Girisi_Adresleme_Load(object sender, EventArgs e)
        {
            logger.info("frm_02_SA_Trans_Girisi_Adresleme_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            if (_paletNo.ToString() != "")
            {
                txtPaletNo.Text = _paletNo;
            }
            Utility.selectText(txtPaletNo);
            logger.info("frm_02_SA_Trans_Girisi_Adresleme_Load end");
        }


        private void txtPaletNo_GotFocus_1(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'b');
            Utility.setBackBolor(p2, lbl_HedefAdres, 'w');
        }

        private void txtHedefAdres_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'w');
            Utility.setBackBolor(p2, lbl_HedefAdres, 'b');
        }

        private void btn_Geri_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_02_SA_Trans_Girisi_Adresleme_txtMalzemeNo_KeyDown begin");

            if (e.KeyCode == Keys.Enter)
            {
                if (txtPaletNo.Text.Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsPaletKontrolGiris chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrolGiris();
                    WS_Kontrol.ZKtWmWsPaletKontrolGirisResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrolGirisResponse();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvLenum = txtPaletNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsPaletKontrolGiris(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {

                        stok = resp.EsStok;
                        
                        //İlgili alanlar dolduruluyor ve giriş alanları aktif ediliyor
                        txtMalzemeNo.Text = Convert.ToInt64(stok.Matnr).ToString();
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtOnerilenAdres.Text = stok.OnerilenAdres.ToString();

                        

                        txtHedefAdres.Enabled = true;
                        btn_Kopyala.Enabled = true;
                        txtHedefAdres.Focus();
                        
                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtPaletNo);
                            
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("in frm_02_SA_Trans_Girisi_Adresleme_txtMalzemeNo_KeyDown "+ ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }


            }
            logger.info("frm_02_SA_Trans_Girisi_Adresleme_txtMalzemeNo_KeyDown end");
        }

        private void txtHedefAdres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kopyala_Click(object sender, EventArgs e)
        {
            txtHedefAdres.Text = txtOnerilenAdres.Text;
            Utility.selectText(txtHedefAdres);
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_02_SA_Trans_Girisi_Adresleme_btn_Kaydet_Click begin");

            if (txtHedefAdres.Text.Trim() == "")
            {
                return;
            }
            
            txtHedefAdres.Text = txtHedefAdres.Text.ToString();

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsSatinalmaAdres chk = new KoctasWM_Project.WS_Islem.ZKtWmWsSatinalmaAdres();
                WS_Islem.ZKtWmWsSatinalmaAdresResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsSatinalmaAdresResponse();

                chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                chk.IvHedefAdres = txtHedefAdres.Text.ToString().ToUpper().Trim();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsSatinalmaAdres(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtHedefAdres);
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
                        Utility.selectText(txtHedefAdres);
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
                logger.error("frm_02_SA_Trans_Girisi_Adresleme_btn_Kaydet_Click "+ ex.Message);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_02_SA_Trans_Girisi_Adresleme_btn_Kaydet_Click end");
        }
            


    }
}