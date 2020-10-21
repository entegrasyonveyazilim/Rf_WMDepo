using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;
namespace KoctasWM_Project
{
    public partial class frm_31_Mal_Giris2 : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_31_Mal_Giris2).Name);
        public frm_31_Mal_Giris2()
        {
            InitializeComponent();
        }

        private Int64 ConvertInt64(string s)
        {
            try
            {
                if (string.IsNullOrEmpty(s))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt64(s);
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }

        DataTable dt_mal = new DataTable();
        public ArrayList materials = new ArrayList();

        public WS_Kontrol.ZkmobilMatlist[] sas_fs = new KoctasWM_Project.WS_Kontrol.ZkmobilMatlist[1000];
        public DateTime belgeTarihi, kayitTarihi;
        public string irsNo;
        public int siparis_sayisi;
        public int sas_lenght;
        public bool Horoz = false;
        const decimal YÜZDEONBEŞ = 1.15M;
        public string sevkiyatNo = "";

        private void frm_31_Mal_Giris2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;

            Utility.loginInfo(lbl_LoginInfo);


            dt_mal = new DataTable();
            dt_mal.Columns.Add("matnr");
            dt_mal.Columns.Add("maktx");
            dt_mal.Columns.Add("S");
            dt_mal.Columns.Add("menge");
            dt_mal.Columns.Add("meins");
            dt_mal.Columns.Add("ebeln");
            dt_mal.Columns.Add("werks");
            dt_mal.Columns.Add("ebelp");
            dt_mal.Columns.Add("lgort");
            dt_mal.Columns.Add("Amenge");

            lbl_SevkiyatNo.Visible = Horoz;
            txtSevkiyatNo.Visible = Horoz;
            txtSevkiyatNo.Text = sevkiyatNo;
            txtSevkiyatNo.ReadOnly = Horoz;

            Utility.selectText(txtMalzemeNo);
        }


        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'b');
            Utility.setBackBolor(p2, lbl_Miktar, 'w');
            Utility.setBackBolor(p3, lbl_SevkiyatNo, 'w');
        }

        private void txtMiktar_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p2, lbl_Miktar, 'b');
            Utility.setBackBolor(p3, lbl_SevkiyatNo, 'w');
        }

        private void txtSevkiyatNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'w');
            Utility.setBackBolor(p2, lbl_Miktar, 'w');
            Utility.setBackBolor(p3, lbl_SevkiyatNo, 'b');
        }

        private void txtMalzemeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Utility.selectText(txtMiktar);
            }
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (Horoz == true)
                {
                    Utility.selectText(txtSevkiyatNo);
                }
                else
                {
                    btn_Ekle_Click(txtMiktar, new EventArgs());
                }

            }
        }

        private void txtSevkiyatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btn_Ekle_Click(txtSevkiyatNo, new EventArgs());
            }
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtMalzemeNo.Text) || String.IsNullOrEmpty(txtMiktar.Text))
                {
                    return;
                }


                if ((Horoz == true) && (String.IsNullOrEmpty(txtSevkiyatNo.Text.ToString().Trim())))
                {
                    MessageBox.Show("Sevkiyat No Alanını Giriniz", "HATA");
                    return;
                }

                //bool miktar_aşımı = false;
                Int64 matnr = Convert.ToInt64(txtMalzemeNo.Text.Trim()); //140509
                
                //malzeme kontrol yap.
                if (materials.Contains(matnr))
                {
                    decimal miktar = decimal.Parse(txtMiktar.Text.Trim());
                    decimal kalan_miktar = miktar;
                    decimal eklenen_miktar = 0;
                    string siparisNo = "";
                    decimal kontrolMiktar = 0;

                    //barkod no ile gelen malzemenin 'malzeme no' su bulunuyor
                    for (int i = 0; i < sas_lenght; i++)
                    {
                        if ((Convert.ToInt64(sas_fs[i].Ean11.Trim()) == matnr && Convert.ToInt64(sas_fs[i].Matnr.Trim()) != matnr))
                        {
                            matnr = Convert.ToInt64(sas_fs[i].Matnr.Trim());
                            break;
                        }
                    }

                    //malzemenin bütün siparişlerdeki toplam miktarı:
                    decimal max_menge = 0;
                    for (int i = 0; i < sas_lenght; i++)
                    {
                        //Eger horoz siparişi ise Amenge miktarı kontrol ediliyor
                        if (Horoz == true)
                        {
                            kontrolMiktar = sas_fs[i].Amenge;
                        }
                        else
                        {
                            kontrolMiktar = sas_fs[i].Menge;
                        }


                        if ((Convert.ToInt64(sas_fs[i].Ean11.Trim()) == matnr || Convert.ToInt64(sas_fs[i].Matnr.Trim()) == matnr) && (siparisNo != sas_fs[i].Ebeln.ToString().Trim()))
                        {
                            max_menge += kontrolMiktar;
                            siparisNo = sas_fs[i].Ebeln.ToString().Trim();

                        }
                    }

                    //Malzeme daha önce eklenmişse eklenen miktarları devral
                    for (int i = 0; i < dt_mal.Rows.Count; i++)
                    {
                        if ((Convert.ToInt64(dt_mal.Rows[i]["matnr"].ToString()) == matnr))
                        {
                            miktar += Convert.ToDecimal(dt_mal.Rows[i]["menge"].ToString());
                        }
                    }

                    if (Horoz == true)
                    {
                        if (miktar > max_menge)
                        {
                            MessageBox.Show("Girmek istediğiniz miktar açık sipariş miktarından fazla olamaz", "HATA");
                            return;
                        }
                    }

                    kalan_miktar = miktar;

                    #region ÇIKARILAN %15 KONTROLÜ
                    //miktar max miktarı aşıyor mu?:
                    //if (miktar > max_menge)
                    //{
                    //    //miktar, max miktarı en fazla yüzde 15 aşabilir :
                    //    if (miktar > max_menge * YÜZDEONBEŞ)
                    //    {
                    //        MessageBox.Show("Miktar " + max_menge.ToString() + "'i yüzde 15den fazla aşamaz.");
                    //        return;
                    //    }
                    //    miktar_aşımı = true;
                    //}

                    ////eklemeden önce, aynı malzeme daha önce eklenmişse sil:
                    //for (int i = 0; i < dt_mal.Rows.Count; i++)
                    //{
                    //    if (Convert.ToInt64(dt_mal.Rows[i]["matnr"].ToString()) == matnr)
                    //    {
                    //        dt_mal.Rows.RemoveAt(i);
                    //        i--;
                    //    }
                    //}

                    ////ekle                    
                    //for (int i = 0; i < sas_lenght; i++)
                    //{
                    //    if (Convert.ToInt64(sas_fs[i].Ean11.Trim()) == matnr || Convert.ToInt64(sas_fs[i].Matnr) == matnr)
                    //    {
                    //        if (kalan_miktar > (sas_fs[i].Menge * YÜZDEONBEŞ))
                    //        {
                    //            if (miktar_aşımı) //miktar aşımı varsa siparişlerdeki miktarların %15 fazlaları kullanılır, yoksa sipparişteki miktar kullanılır.
                    //            {
                    //                miktar = sas_fs[i].Menge * YÜZDEONBEŞ;
                    //            }
                    //            else
                    //            {
                    //                miktar = sas_fs[i].Menge;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            miktar = kalan_miktar;
                    //        }
                    //        kalan_miktar = kalan_miktar - miktar;
                    //        DataRow row = dt_mal.NewRow();
                    //        row["matnr"] = sas_fs[i].Matnr;
                    //        row["maktx"] = sas_fs[i].Maktx;
                    //        row["menge"] = miktar;
                    //        row["meins"] = sas_fs[i].Meins;
                    //        row["ebeln"] = sas_fs[i].Ebeln;
                    //        row["ebelp"] = sas_fs[i].Ebelp;
                    //        row["werks"] = sas_fs[i].Werks;
                    //        row["lgort"] = sas_fs[i].Lgort;
                    //        if (chk_Son.Checked || miktar >= sas_fs[i].Menge)
                    //        {
                    //            row["S"] = "X";
                    //        }
                    //        dt_mal.Rows.Add(row);
                    //        grd_mal.DataSource = null;
                    //        grd_mal.DataSource = dt_mal;

                    //        if (kalan_miktar == 0)
                    //        {
                    //            break;
                    //        }
                    //    }
                    //}
                    //txt_malzemeno.Text = "";
                    //txt_miktar.Text = "";
                    //txt_malzemeno.Focus();
                    //chk_Son.Checked = false;
                    #endregion

                    //eklemeden önce, aynı malzeme daha önce eklenmişse sil:
                    for (int i = 0; i < dt_mal.Rows.Count; i++)
                    {
                        if ((Convert.ToInt64(dt_mal.Rows[i]["matnr"].ToString()) == matnr))
                        {
                            dt_mal.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    //bu malzemeye ait olan siparişlerin alınması
                    WS_Kontrol.ZkmobilMatlist[] sas_mat = new KoctasWM_Project.WS_Kontrol.ZkmobilMatlist[1000];
                    int inx = 0;
                    siparisNo = "";
                    for (int i = 0; i < sas_lenght; i++)
                    {
                        if (ConvertInt64(sas_fs[i].Ean11.Trim()) == matnr || ConvertInt64(sas_fs[i].Ean112.Trim()) == matnr || ConvertInt64(sas_fs[i].Matnr) == matnr)
                        {
                            if (siparisNo != sas_fs[i].Ebeln.ToString().Trim())
                            {
                                sas_mat[inx] = sas_fs[i];
                                inx++;
                                siparisNo = sas_fs[i].Ebeln.ToString().Trim();
                            }
                        }
                    }
                    for (int i = 0; i < inx; i++)
                    {

                        //Eger horoz siparişi ise Amenge miktarı kontrol ediliyor
                        if (Horoz == true)
                        {
                            kontrolMiktar = sas_mat[i].Amenge;
                        }
                        else
                        {
                            kontrolMiktar = sas_mat[i].Menge;
                        }

                        if (kalan_miktar > (kontrolMiktar)) //Son siparişe kadar, sipariş miktarlarını kapatarak git
                        {
                            miktar = kontrolMiktar;
                        }
                        else
                        {
                            miktar = kalan_miktar;
                        }
                        kalan_miktar = kalan_miktar - miktar;
                        DataRow row = dt_mal.NewRow();
                        row["matnr"] = sas_mat[i].Matnr;
                        row["maktx"] = sas_mat[i].Maktx;
                        row["menge"] = miktar;
                        eklenen_miktar += miktar;
                        row["meins"] = sas_mat[i].Meins;
                        row["ebeln"] = sas_mat[i].Ebeln;
                        row["ebelp"] = sas_mat[i].Ebelp;
                        row["werks"] = sas_mat[i].Werks;
                        row["lgort"] = sas_mat[i].Lgort;
                        row["S"] = "";

                        if (chk_Son.Checked || miktar >= kontrolMiktar)
                        {
                            row["S"] = "X";
                            dt_mal.Rows.InsertAt(row, 0);
                        }

                        //Sipariş miktarındaki miktardan fazla miktar eklenmiş ise
                        else if ((Horoz == false) && (eklenen_miktar >= kontrolMiktar))
                        {
                            dt_mal.Rows[dt_mal.Rows.Count - 1]["menge"] = (Convert.ToDecimal(dt_mal.Rows[dt_mal.Rows.Count - 1]["menge"].ToString()) + miktar).ToString();

                        }
                        else
                        {
                            dt_mal.Rows.InsertAt(row, 0);
                        }

                        grd_mal.DataSource = null;
                        grd_mal.DataSource = dt_mal;

                        if (kalan_miktar == 0)
                        {
                            break;
                        }
                    }
                    if (kalan_miktar > 0) //Kalan miktarın tamamını son siparişe ekle.
                    {

                        decimal sonMiktar = Convert.ToDecimal(dt_mal.Rows[0]["menge"].ToString()) + kalan_miktar;
                        dt_mal.Rows[0]["menge"] = sonMiktar.ToString();

                        grd_mal.DataSource = null;
                        grd_mal.DataSource = dt_mal;
                    }
                    txtMalzemeNo.Text = txtMiktar.Text = "";
                    Utility.selectText(txtMalzemeNo);

                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Bu malzeme girilen siparişlerde bulunmuyor.", "HATA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd_mal.CurrentRowIndex < 0)
                {
                    return;
                }
                dt_mal.Rows.RemoveAt(grd_mal.CurrentCell.RowNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_31_Mal_Giris2_btn_Kaydet_Click begin");
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZkmobilMgH mgh = new KoctasWM_Project.WS_Islem.ZkmobilMgH();
                WS_Islem.ZkmobilMgI[] mgi = new KoctasWM_Project.WS_Islem.ZkmobilMgI[dt_mal.Rows.Count];
                WS_Islem.ZkmobilReturn[] ret = new KoctasWM_Project.WS_Islem.ZkmobilReturn[0];
                WS_Islem.ZKtWmWsMgCreate2 cre = new KoctasWM_Project.WS_Islem.ZKtWmWsMgCreate2();
                WS_Islem.ZKtWmWsMgCreate2Response resp = new KoctasWM_Project.WS_Islem.ZKtWmWsMgCreate2Response();
                
                mgh.RefDocNo = irsNo;

                if (Horoz)
                {
                    mgh.Frbnr = txtSevkiyatNo.Text.Trim().ToString();
                }


                for (int i = 0; i < dt_mal.Rows.Count; i++)
                {
                    mgi[i] = new KoctasWM_Project.WS_Islem.ZkmobilMgI();
                    mgi[i].Plant = dt_mal.Rows[i]["werks"].ToString();
                    mgi[i].StgeLoc = dt_mal.Rows[i]["lgort"].ToString();
                    mgi[i].EntryQnt = decimal.Parse(dt_mal.Rows[i]["menge"].ToString());
                    mgi[i].PoNumber = dt_mal.Rows[i]["ebeln"].ToString();
                    mgi[i].PoItem = dt_mal.Rows[i]["ebelp"].ToString();
                    if (dt_mal.Rows[i]["S"].ToString() == "X")
                    {
                        mgi[i].Elikz = "X";
                    }
                }

                cre.IHeader = mgh;
                cre.TeReturn = ret;
                cre.TiItems = mgi;

                cre.IDocDate = belgeTarihi.ToString("yyyy-MM-dd");
                cre.IPstngDate = kayitTarihi.ToString("yyyy-MM-dd");

                resp.TeReturn = ret;
                resp.TiItems = mgi;


                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsMgCreate2(cre);

                Cursor.Current = Cursors.Default;

                if (resp.TeReturn.Length > 0)
                {
                    if (resp.TeReturn[0].RcCode.ToUpper() == "S")
                    {
                        MessageBox.Show(resp.TeReturn[0].RcText, "BİLGİ");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resp.TeReturn[0].RcText, "HATA");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_31_Mal_Giris2_btn_Kaydet_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_31_Mal_Giris2_btn_Kaydet_Click end");
        }


    }
}