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
    public partial class frm_32_1_Sarfa_Gonderilecek_Urunler : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_32_1_Sarfa_Gonderilecek_Urunler).Name);
        public frm_32_1_Sarfa_Gonderilecek_Urunler()
        {
            InitializeComponent();
        }

        public WS_Islem.ZktWmStSarf[] _stk = new KoctasWM_Project.WS_Islem.ZktWmStSarf[50];
        public int _stokAdedi;
        DataTable _stok;
        string _secilenMalzemeNo = "";
        decimal _secilenMiktar = 0;


        

        private void frm_32_1_Sarfa_Gonderilecek_Urunler_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.WindowState = FormWindowState.Maximized;

            Utility.loginInfo(lbl_LoginInfo);

            _stok = new DataTable();
            _stok.Columns.Add("Secim");
            _stok.Columns.Add("Lifnr");
            _stok.Columns.Add("Maktx");
            _stok.Columns.Add("Matnr");
            _stok.Columns.Add("Meins");
            _stok.Columns.Add("Menge");
            _stok.Columns.Add("Sobkz");

            //_stk içeriği tabloya dolduruluyor
            for (int i = 0; i < _stokAdedi; i++)
            {
                DataRow row = _stok.NewRow();

                row["Secim"] = "";
                row["Lifnr"] = _stk[i].Lifnr.ToString();
                row["Maktx"] = _stk[i].Maktx.ToString();
                row["Matnr"] = _stk[i].Matnr.ToString();
                row["Meins"] = _stk[i].Meins.ToString();
                row["Menge"] = _stk[i].Menge.ToString();
                row["Sobkz"] = _stk[i].Sobkz.ToString();

                _stok.Rows.Add(row);
            }

            grd_List.DataSource = null;
            grd_List.DataSource = _stok;


        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_32_1_Sarfa_Gonderilecek_Urunler_btn_Kaydet_Click begin");
            //seçilen satırlar kontrol ediliyor
            int secilenSatirSayisi = 0;

            for (int i = 0; i < _stok.Rows.Count; i++)
            {
                if (_stok.Rows[i]["Secim"].ToString() == "X")
                {
                    secilenSatirSayisi++;
                }
            }

            if (secilenSatirSayisi == 0)
            {
                MessageBox.Show("Sarfa gönderilecek malzeme seçimi yapmadınız", "HATA");
                return;
            }




            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsIadeHurdaCikisi chk = new KoctasWM_Project.WS_Islem.ZKtWmWsIadeHurdaCikisi();
                WS_Islem.ZKtWmWsIadeHurdaCikisiResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsIadeHurdaCikisiResponse();
                WS_Islem.ZktWmStSarf[] yeniSarf = new KoctasWM_Project.WS_Islem.ZktWmStSarf[secilenSatirSayisi];

                int j = 0;
                for (int i = 0; i < _stok.Rows.Count; i++)
                {
                    if (_stok.Rows[i]["Secim"].ToString() == "X")
                    {
                        yeniSarf[j] = new KoctasWM_Project.WS_Islem.ZktWmStSarf();
                        
                        yeniSarf[j].Lifnr = _stok.Rows[i]["Lifnr"].ToString();
                        yeniSarf[j].Maktx = _stok.Rows[i]["Maktx"].ToString();
                        yeniSarf[j].Matnr = _stok.Rows[i]["Matnr"].ToString();
                        yeniSarf[j].Meins = _stok.Rows[i]["Meins"].ToString();
                        yeniSarf[j].Menge = Convert.ToDecimal(_stok.Rows[i]["Menge"].ToString());
                        yeniSarf[j].Sobkz = _stok.Rows[i]["Sobkz"].ToString();
                        j++;
                    }
                }
                chk.ItSarf = yeniSarf;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsIadeHurdaCikisi(chk);

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
                        this.DialogResult = DialogResult.OK;
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
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_32_1_Sarfa_Gonderilecek_Urunler_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_32_1_Sarfa_Gonderilecek_Urunler_btn_Kaydet_Click end");
        }

        private void grd_List_DoubleClick(object sender, EventArgs e)
        {
            logger.info("frm_32_1_Sarfa_Gonderilecek_Urunler_grd_List_DoubleClick begin");

            _secilenMalzemeNo = _stok.Rows[grd_List.CurrentCell.RowNumber]["Matnr"].ToString();
            _secilenMiktar = Convert.ToDecimal(_stok.Rows[grd_List.CurrentCell.RowNumber]["Menge"].ToString());
            

            //Stok tablosu satırı seçili hale getiriliyor
            if (stokTablosundanSatirSec(_secilenMalzemeNo))
            {
                txtMiktar.Text = _secilenMiktar.ToString();
                //Miktar alanı değişikliği için yönlendiriliyor.
                Utility.selectText(txtMiktar);
            }
            else
            {
                _secilenMalzemeNo = "";
                _secilenMiktar = 0;
            }


            logger.info("frm_32_1_Sarfa_Gonderilecek_Urunler_grd_List_DoubleClick end");
            
        }

        public decimal stokTablosundanToplamMiktarBul(string malzemeNo)
        {
            decimal toplamAdet = 0;

            for (int i = 0; i < _stokAdedi; i++)
            {
                if (_stk[i].Matnr.ToString() == malzemeNo)
                {
                    toplamAdet = _stk[i].Menge;
                }
            }

            return toplamAdet;
        }

        public bool stokTablosundanSatirSec(string malzemeNo)
        {
            bool secilmis = false;

            for (int i = 0; i < _stok.Rows.Count; i++)
            {
                if (_stok.Rows[i]["Matnr"].ToString() == malzemeNo.ToString().Trim())
                {
                    string secim = _stok.Rows[i]["Secim"].ToString();
                    if (secim == "X")
                    {
                        _stok.Rows[i]["Secim"] = "";
                        secilmis = false;
                    }
                    else
                    {
                        _stok.Rows[i]["Secim"] = "X";
                        secilmis = true;
                    }
                }
            }

            grd_List.DataSource = null;
            grd_List.DataSource = _stok;

            return secilmis;
        }

        public bool stokTablosundanMiktarDegistir(string malzemeNo, decimal miktar)
        {
            bool buldum = false;
            for (int i = 0; i < _stok.Rows.Count; i++)
            {
                if (_stok.Rows[i]["Matnr"].ToString() == malzemeNo.ToString().Trim())
                {
                    _stok.Rows[i]["Menge"] = miktar.ToString();
                    buldum = true;
                }
            }

            if (buldum) {
                grd_List.DataSource = null;
                grd_List.DataSource = _stok;
            }

            return buldum;
        }

        private void btn_MiktarDegistir_Click(object sender, EventArgs e)
        {
            if (txtMiktar.Text.Trim() == "")
            {
                return;
            }

            if (_secilenMalzemeNo == "")
            {
                MessageBox.Show("Miktar değişikliği için tablodan malzeme satırı seçiniz", "HATA");
                return;
            }

            decimal miktar = 0;

            try
            {
                miktar = Convert.ToDecimal(txtMiktar.Text.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("Miktar alanına sayısal bir değer giriniz");
                return;
            }

            if (miktar > stokTablosundanToplamMiktarBul(_secilenMalzemeNo))
            {
                MessageBox.Show("Sarfa gönderilecek ürün toplam miktardan fazla olamaz", "HATA");
                return; 
            }

            if (stokTablosundanMiktarDegistir(_secilenMalzemeNo, miktar) == false)
            {
                MessageBox.Show("Belirttiğiniz malzeme tabloda bulunamadı", "HATA");
            }

            _secilenMiktar = 0;
            _secilenMalzemeNo = "";
            txtMiktar.Text = "";
            
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }




    }
}