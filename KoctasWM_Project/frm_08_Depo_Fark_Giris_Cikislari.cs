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
    public partial class frm_08_Depo_Fark_Giris_Cikislari : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_08_Depo_Fark_Giris_Cikislari).Name);
        public frm_08_Depo_Fark_Giris_Cikislari()
        {
            InitializeComponent();
        }

        decimal miktar;
        bool malzemeKontrol = false;

        private void formAcilisDuzenle()
        {

            txtPaletNo.Text = "";
            txtMalzemeNo.Text = "";
            txtMalzemeTanimi.Text = "";
            txtMiktar.Text = "";
            txtToplamMiktar.Text = "";
            txtOlcuBirimi.Text = "";
            txtStokTipi.Text = "";

            txtMalzemeNo.Enabled = false;
            txtMalzemeNo.BackColor = Color.FromArgb(238, 188, 138);
            malzemeKontrol = false;

            txtMiktar.Enabled = false;
            Utility.selectText(txtPaletNo);

        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'b');
            Utility.setBackBolor(p5, lbl_Miktar, 'p');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_PaletNo, 'w');
            Utility.setBackBolor(p5, lbl_Miktar, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_08_Depo_Fark_Giris_Cikislari_Load(object sender, EventArgs e)
        {
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);
            txtPaletNo.Focus();
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_Load end");
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_txtPaletNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPaletNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                txtPaletNo.Text = txtPaletNo.Text.ToUpper();

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    
                     WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsPaletKontrolAll chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrolAll();
                    WS_Kontrol.ZKtWmWsPaletKontrolAllResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsPaletKontrolAllResponse();
                    WS_Kontrol.ZktWmStok stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok();

                    chk.IvLenum = txtPaletNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsPaletKontrolAll(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        stok = resp.EsStok;

                        txtMalzemeNo.Text = Convert.ToInt64(stok.Matnr).ToString();
                        txtMalzemeTanimi.Text = stok.Maktx.ToString();
                        txtToplamMiktar.Text = stok.Miktar.ToString();
                        txtOlcuBirimi.Text = stok.Meins.ToString();
                        txtStokTipi.Text = stok.Bestq.ToString();

                        txtMiktar.Enabled = true;
                        Utility.selectText(txtMiktar);

                    }
                    else
                    {
                        //Eğer palet yok ise, yeni oluşturmak için yönlendiriliyor
                        if (resp.EsResponse[0].Msgno.ToString() == "007")
                        {
                            if (MessageBox.Show("Palet numarası bulunamadı. Yeni bir palet oluşturmak istiyor musunuz?", "HATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                //Malzeme numarası giriş için enable ediliyor
                                txtMalzemeNo.Enabled = true;
                                txtMalzemeNo.BackColor = Color.White;
                                Utility.selectText(txtMalzemeNo);
                                malzemeKontrol = true;
                            }
                            else
                            {
                                //Malzeme numarası girişi disable ediliyor
                                txtMalzemeNo.Enabled = false;
                                txtMalzemeNo.BackColor = Color.FromArgb(238, 188, 138);
                                Utility.selectText(txtPaletNo);
                                malzemeKontrol = false;
                                Utility.selectText(txtPaletNo);
                            }

                        }
                        else
                        {
                            MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                            Utility.selectText(txtPaletNo);
                        }
                        
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    Utility.selectText(txtPaletNo);
                    logger.error("frm_08_Depo_Fark_Giris_Cikislari_txtPaletNo_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_txtPaletNo_KeyDown end");
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
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_btn_Kaydet_Click begin");
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
            
            /*
            if (!(miktar > 0))
            {
                return;
            }*/


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsDepoIciFark chk = new KoctasWM_Project.WS_Islem.ZKtWmWsDepoIciFark();
                WS_Islem.ZKtWmWsDepoIciFarkResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsDepoIciFarkResponse();

                chk.IvLenum = txtPaletNo.Text.ToString().Trim();
                chk.IvMiktar = miktar;


                if (txtMalzemeNo.Enabled == true)
                {
                    chk.IvEan = txtMalzemeNo.Text.ToString();
                }

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsDepoIciFark(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        if (txtMalzemeNo.Enabled == true)
                        {
                            Utility.selectText(txtMalzemeNo);
                        }
                        else
                        {
                            Utility.selectText(txtPaletNo);
                        }
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);

                        //Eğer malzemeNo dolu geldiyse, Ürün Yerleştirme Adresleme ekranı çağırılıyor
                        if (malzemeKontrol) {
                            frm_02_SA_Trans_Girisi_Adresleme frm = new frm_02_SA_Trans_Girisi_Adresleme();
                            frm._paletNo = txtPaletNo.Text.ToString().Trim();
                            frm.ShowDialog();
                        }
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
                logger.error("frm_08_Depo_Fark_Giris_Cikislari_btn_Kaydet_Click "+ ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_btn_Kaydet_Click end");
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_txtMalzemeNo_KeyDown begin");
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
                        txtMalzemeTanimi.Text = resp.EsMalzeme.Maktx.ToString();
                        txtOlcuBirimi.Text = resp.EsMalzeme.Meins.ToString();
                        txtStokTipi.Text = "-";
                        txtToplamMiktar.Text = "-";
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
                    logger.error("frm_08_Depo_Fark_Giris_Cikislari_txtMalzemeNo_KeyDown "+ ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            logger.info("frm_08_Depo_Fark_Giris_Cikislari_txtMalzemeNo_KeyDown end");
        }
    }
}