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
    public partial class frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz).Name);
        public frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz()
        {
            InitializeComponent();
        }

        public WS_Kontrol.ZktWmStTeslimat _tes;
        public string _dagitimTuru;
        decimal miktar;
        decimal kalanMiktar;

        DataTable _yukle;

        private Boolean isReadMaterial = false;
        

        private void frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            _yukle = new DataTable();
            _yukle.Columns.Add("KoliNo");
            _yukle.Columns.Add("Matnr");
            _yukle.Columns.Add("Meins");
            _yukle.Columns.Add("Menge");
            _yukle.Columns.Add("Posnr");
            _yukle.Columns.Add("VbelnVI");

            
            if (_tes.Maktx.ToString().Trim() == "")
            {
                MessageBox.Show("Belirtilen malzeme no bulunamadı", "HATA");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {

                if ((_tes.Lfart.ToString() == "ZLF") || (_tes.Lfart.ToString() == "ZNLF"))
                {
                    txtTeslimatTipi.Text = "Müşteri";
                }
                else if (_tes.Lfart.ToString() == "NL")
                {
                    txtTeslimatTipi.Text = "Mağaza";
                }
                else
                {
                    txtTeslimatTipi.Text = _tes.Lfart.ToString();
                }


                txtTeslimatNo.Text = _tes.Vbeln.ToString();
                txtMalzemeNo.Text = Convert.ToInt64(_tes.Matnr).ToString();
                txtMalzemeTanimi.Text = _tes.Maktx.ToString();
                kalanMiktar = _tes.Menge;
                txtKalanMiktar.Text = _tes.Menge.ToString();
                txtOlcuBirimi.Text = _tes.Meins.ToString();
                txtTeslimAlanMagaza.Text = _tes.Kunnr.ToString().TrimStart('0');
                txtTeslimatMiktari.Text = _tes.Lfimg.ToString();
                txtAliciAdi.Text = _tes.Name1.ToString();

            

                Utility.selectText(txtDagitimMiktari);

            }
        }



        private void txtDagitimMiktari_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p4, lbl_DagitimMiktari, 'b');
            Utility.setBackBolor(p3, lbl_DagitimAdresiOlmasiGereken, 'w');
        }

        private void txtDagitimMiktari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    miktar = Convert.ToDecimal(txtDagitimMiktari.Text);
                    
                    Utility.selectText(txtPaletNo);

                }
                catch
                {
                    MessageBox.Show("Miktar alanına sayısal bir değer girin", "HATA");
                    Utility.selectText(txtDagitimMiktari);
                }
            }
        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p4, lbl_DagitimMiktari, 'w');
            Utility.setBackBolor(p3, lbl_DagitimAdresiOlmasiGereken, 'b');
        }

        private void txtPaletNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPaletNo.Text = txtPaletNo.Text.ToString().Trim().ToUpper();
                btn_Onayla_Click(new object(), new EventArgs());
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {

            if (txtTeslimatMiktari.Text.Equals(txtKalanMiktar.Text))
            {
                MessageBox.Show("Önce malzeme okutunuz..","Hata!");
                return;
            }

            if (!isReadMaterial)
            {
                MessageBox.Show("Önce malzeme okutunuz..", "Hata!");
                return;
            }
            else
            {
                isReadMaterial = false;
            }

            logger.info("frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz_btn_Kaydet_Click begin");
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsTeslimDagitimCre chk = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimDagitimCre();
                WS_Islem.ZKtWmWsTeslimDagitimCreResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimDagitimCreResponse();
                WS_Islem.ZktWmStRampaYukleme[] ret = new KoctasWM_Project.WS_Islem.ZktWmStRampaYukleme[_yukle.Rows.Count];

                for (int i = 0; i < _yukle.Rows.Count; i++)
                {
                    ret[i] = new KoctasWM_Project.WS_Islem.ZktWmStRampaYukleme();
                    
                    ret[i].KoliNo = _yukle.Rows[i]["KoliNo"].ToString();
                    ret[i].Matnr = _yukle.Rows[i]["Matnr"].ToString();
                    ret[i].Meins = _yukle.Rows[i]["Meins"].ToString();
                    ret[i].Menge = Convert.ToDecimal(_yukle.Rows[i]["Menge"].ToString());
                    ret[i].Posnr = _yukle.Rows[i]["Posnr"].ToString();
                    ret[i].VbelnVl = _yukle.Rows[i]["VbelnVI"].ToString();
                }

                chk.ItRampa = ret;
                chk.IvType = _dagitimTuru;

                /*
                chk.IvDagadres = txtPaletNo.Text.ToString().Trim();
                chk.IvMiktar = miktar;
                chk.IvPosnr = _tes.Posnr.ToString();
                chk.IvVbeln = _tes.Vbeln.ToString();
                */


                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsTeslimDagitimCre(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        Utility.selectText(txtDagitimMiktari);
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        this.Close();
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
                    Utility.selectText(txtPaletNo);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_41_Dagitim_Toplanan_Tes_Icin_Dagitim_Ayristirma_Mgz_btn_Kaydet_Click end");
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Onayla_Click(object sender, EventArgs e)
        {
            try
            {
                isReadMaterial = true;
                miktar = Convert.ToDecimal(txtDagitimMiktari.Text.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal değer giriniz", "HATA");
                Utility.selectText(txtDagitimMiktari);
                return;
            }

            string gecerliPaletNo = txtPaletNo.Text.ToString().Trim().ToUpper();

            if (gecerliPaletNo == "")
            {
                MessageBox.Show("Geçerli bir palet no okutunuz.", "HATA");
                return;
            }

            if (!(miktar > 0))
            {
                return;
            }


            // Gökhan Kayatürk talebi ile 24.11.2014 tarihinde yağmurlu bir İstanbul gününde 
            // umarsızca ve düşüncesizce kaldırılmıştır. 
            /*
            if (_tes.Lfart.ToString() == "NL")
            {
                if (!Utility.baslangicKontrol(gecerliPaletNo, "RAMPA"))
                {
                    MessageBox.Show("Okuttuğunuz adres bu teslimat türüne uygun değil", "HATA");
                    Utility.selectText(txtPaletNo);
                    return;
                }
            }
            else if ((_tes.Lfart.ToString() == "ZLF") || (_tes.Lfart.ToString() == "ZNLF"))
            {
                if ((!Utility.baslangicKontrol(gecerliPaletNo, "ARAC")) && (!Utility.baslangicKontrol(gecerliPaletNo, "PALET")))
                {
                    MessageBox.Show("Okuttuğunuz adres bu teslimat türüne uygun değil", "HATA");
                    Utility.selectText(txtPaletNo);
                    return;
                }
            }*/ 




            decimal teslimatMiktari = Convert.ToDecimal(txtTeslimatMiktari.Text.ToString());
            kalanMiktar = Convert.ToDecimal(txtKalanMiktar.Text.ToString());

            try
            {

                if (miktar > kalanMiktar)
                {
                    MessageBox.Show("Paletlenecek miktar ile paletlenen miktar toplamı, bu belgedeki teslimat miktarından fazla olamaz", "HATA");
                    Utility.selectText(txtDagitimMiktari);
                    return;
                }

                //_yukle tablosuna malzeme ekleniyor
                bool ekle = true;

                // MalzemeNo ve koliNo eşleşmesi daha önce _yukle tablosuna eklenmiş mi
                // eklenmiş ise miktar revize ediliyor
                for (int i = 0; i < _yukle.Rows.Count; i++)
                {
                    if ((_yukle.Rows[i]["KoliNo"].ToString() == gecerliPaletNo) && (_yukle.Rows[i]["Matnr"].ToString() == txtMalzemeNo.Text.ToString()) && (_yukle.Rows[i]["VbelnVI"].ToString() == txtTeslimatNo.Text.ToString()) )
                    {
                        ekle = false;
                        _yukle.Rows[i]["Menge"] = Convert.ToDecimal(_yukle.Rows[i]["Menge"]) + miktar;
                    }
                }


                if (ekle)
                {
                    DataRow _row = _yukle.NewRow();
                    _row["KoliNo"] = gecerliPaletNo;
                    _row["Matnr"] = txtMalzemeNo.Text.ToString();
                    _row["Meins"] = txtOlcuBirimi.Text.ToString();
                    _row["Menge"] = miktar.ToString();
                    _row["Posnr"] = _tes.Posnr.ToString();
                    _row["VbelnVI"] = txtTeslimatNo.Text.ToString();

                    _yukle.Rows.Add(_row);

                }

                formAcilisDuzenle();
                kalanMiktar = kalanMiktar - miktar;
                txtKalanMiktar.Text = kalanMiktar.ToString();

                MessageBox.Show("Paletlenecek miktar eklendi", "BİLGİ");

                if (kalanMiktar == 0)
                {
                    MessageBox.Show("Paletleme işlemi tamamlandı. Mal çıkışı ve yükleme yapılabilir.", "BİLGİ");
                    btn_Kaydet.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "HATA");
            }
        }

        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = "";
            txtDagitimMiktari.Text = "";
            
            Utility.selectText(txtDagitimMiktari);

        }


    }
}