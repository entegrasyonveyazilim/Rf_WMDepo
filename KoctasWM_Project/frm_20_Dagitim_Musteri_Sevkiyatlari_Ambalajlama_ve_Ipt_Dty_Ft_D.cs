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
    public partial class frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D).Name);
        public frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D()
        {
            InitializeComponent();
        }

        public string _faturaNo;
        public string _belgeNo;
        public string _koliNo;
        public string _atfNo;
        public bool _atfKontrol;
        public WS_Kontrol.ZktWmStAtfHeader _atfInfo;

        private void frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay_FaturaDogrula_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            txtFaturaNo.Text = _faturaNo;
            _atfKontrol = false;
            Utility.selectText(txtOkutulanFaturaNo);
            
            _atfKontrol = false;
            

                
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D_btn_Kaydet_Click begin");
            if (txtFaturaNo.Text.ToString().Trim() == txtOkutulanFaturaNo.Text.ToString().Trim())
            {


                if (!_atfKontrol)
                {
                    MessageBox.Show("İşlemi tamamlamak için öncelikle ATF No almanız gerekmektedir.", "HATA");
                    return;
                }

                try
                {
                    //ZKT_WM_WS_AMBALAJLAMA_ESLEME
                    Cursor.Current = Cursors.WaitCursor;
                    WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                    WS_Islem.ZKtWmWsAmbalajlamaEsleme chk = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlamaEsleme();
                    WS_Islem.ZKtWmWsAmbalajlamaEslemeResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsAmbalajlamaEslemeResponse();

                    chk.IvVbelnVf = _faturaNo;
                    chk.IvVbelnVl = _belgeNo;

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                    resp = srv.ZKtWmWsAmbalajlamaEsleme(chk);

                    Cursor.Current = Cursors.Default;
                    if (resp.EsResponse.Length > 0)
                    {
                        //Mesajlar düzenleniyor
                        GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                        GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                        if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                            Utility.selectText(txtFaturaNo);
                        }
                        else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                            Utility.moreMsgCheck(GlobalData.rMsg);

                            this.DialogResult = DialogResult.OK;
                            this.Close();

                            /*if (Utility.atfKaydet(_koliNo, _atfNo))
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                return;
                            }*/
                        }
                        else
                        {
                            MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                            Utility.selectText(txtFaturaNo);
                        }
                    }
                    else
                    {
                        MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "HATA");
                    Utility.selectText(txtFaturaNo);
                    logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D_btn_Kaydet_Click "+ex.Message);
                }



                
            }
            else
            {
                MessageBox.Show("Fatura eşleşmesi doğru değil. Kontrol ediniz.", "HATA");
            }
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Ipt_Dty_Ft_D_btn_Kaydet_Click end");
        }

        private void txtOkutulanFaturaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());
            }
        }

        private void btn_AtfAl_Click(object sender, EventArgs e)
        {

            if (Utility.atfInfo(_koliNo) == true)
            {
                _atfKontrol = true;
                txtAtfNo.Text = "ATF Alındı";
            }
            else
            {
                _atfKontrol = false;
                txtAtfNo.Text = "";
            }

            /*
            string[] _arrAtf = new string[6];
            _arrAtf = Utility.atfAl(_atfInfo.BstkdE, _atfInfo.Bstkd, _atfInfo.Desi, _atfInfo.Kargocu);
            if (_arrAtf[5].ToString() != "")
            {
                _atfKontrol = true;
                txtAtfNo.Text = _atfNo = _arrAtf[5].ToString().Trim();
            }
            else
            {
                MessageBox.Show("ATF No alınamadı. Tekrar deneyiniz", "HATA");
            }*/
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Fatura eşleşmesi yapmadan kargoya teslim edemezsiniz.", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }



    }
}