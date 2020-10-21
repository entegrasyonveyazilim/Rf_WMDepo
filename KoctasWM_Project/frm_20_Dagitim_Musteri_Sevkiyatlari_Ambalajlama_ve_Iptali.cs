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
    public partial class frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali).Name);
       
        public frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali()
        {
            InitializeComponent();
        }

        DataTable drAdres = new DataTable();
        DataTable drAdres2 = new DataTable();

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalaj_Iptali_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;

            Utility.loginInfo(lbl_LoginInfo);

            drAdres = new DataTable();
            drAdres.Columns.Add("dagitimAdresi");
            drAdres.Columns.Add("matnr");
            drAdres.Columns.Add("maktx");
            drAdres.Columns.Add("meins");
            drAdres.Columns.Add("kostk");
            drAdres.Columns.Add("posnr");
            drAdres.Columns.Add("vbeln");
            drAdres.Columns.Add("lfimg");

            drAdres2 = new DataTable();
            drAdres2.Columns.Add("dagitimAdresi");
            drAdres2.Columns.Add("matnr");
            drAdres2.Columns.Add("maktx");
            drAdres2.Columns.Add("meins");
            drAdres2.Columns.Add("kostk");
            drAdres2.Columns.Add("posnr");
            drAdres2.Columns.Add("vbeln");
            drAdres2.Columns.Add("lfimg");
            

            Utility.selectText(txtDagitimAraci);
        }

        private void txtDagitimAraci_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DagitimAraci, 'b');
            Utility.setBackBolor(p2, lbl_DagitimAdresi, 'w');
        }

        private void txtDagitimAdresi_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_DagitimAraci, 'w');
            Utility.setBackBolor(p2, lbl_DagitimAdresi, 'b');
        }

        private void grd_List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string dagitimAdresi = drAdres.Rows[grd_List.CurrentCell.RowNumber]["dagitimAdresi"].ToString();
                if (dagitimAdresi == "")
                {
                    return;
                }
                txtDagitimAdresi.Text = dagitimAdresi;
                Utility.selectText(txtDagitimAdresi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        private bool itemControl(DataTable _table, string _dagitimAdresi, string _vbeln)
        {
            if (_table.Rows.Count > 0)
            {
                //_table.Reset();
                for (int i = 0; i < _table.Rows.Count; i++)
                {
                    if ((_table.Rows[i]["dagitimAdresi"].ToString() == _dagitimAdresi) && (_table.Rows[i]["vbeln"].ToString() == _vbeln))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void txtDagitimAraci_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_txtDagitimAraci_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDagitimAraci.Text.ToString().Trim() == "")
                {
                    return;
                }

                txtDagitimAraci.Text = txtDagitimAraci.Text.ToString().Trim().ToUpper();

                if ((!Utility.baslangicKontrol(txtDagitimAraci.Text, "ARAC")) && (!Utility.baslangicKontrol(txtDagitimAraci.Text, "PALET")))
                {
                    MessageBox.Show("Dağıtım aracı mevcut değil", "HATA");
                    Utility.selectText(txtDagitimAraci);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    

                    //Tablolar temizleniyor
                    drAdres.Clear();
                    drAdres2.Clear();
                    
                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsAmbalajKontArac chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontArac();
                    WS_Kontrol.ZKtWmWsAmbalajKontAracResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontAracResponse();
                    

                    chk.IvDagarac = txtDagitimAraci.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsAmbalajKontArac(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        int count = resp.EtAmbalaj.Length;

                        if (count <= 0)
                        {
                            MessageBox.Show("Dağıtım aracı ile ilişkili dağıtım listesi bulunamadı");
                            Utility.selectText(txtDagitimAraci);
                            return;
                        }
                        WS_Kontrol.ZktWmStAmbalaj[] amb = new KoctasWM_Project.WS_Kontrol.ZktWmStAmbalaj[count];
                        amb = resp.EtAmbalaj;

                        for (int i = 0; i < amb.Length; i++)
                        {

                            if (amb[i].Kostk.ToString().ToUpper() == "C")
                            {
                                DataRow row = drAdres.NewRow();
                                
                                row["dagitimAdresi"] = amb[i].DagitimAdresi.ToString();
                                row["lfimg"] = amb[i].Lfimg.ToString();
                                row["kostk"] = amb[i].Kostk.ToString();
                                row["maktx"] = amb[i].Maktx.ToString();
                                row["matnr"] = amb[i].Matnr.ToString();
                                row["meins"] = amb[i].Meins.ToString();
                                row["posnr"] = amb[i].Posnr.ToString();
                                row["vbeln"] = amb[i].Vbeln.ToString();
                                
                                if (!itemControl(drAdres, amb[i].DagitimAdresi.ToString(), amb[i].Vbeln.ToString()))
                                {
                                    drAdres.Rows.Add(row);
                                }
                                
                            }
                            else
                            {
                                DataRow row2 = drAdres2.NewRow();
                                row2["dagitimAdresi"] = amb[i].DagitimAdresi.ToString();
                                row2["lfimg"] = amb[i].Lfimg.ToString();
                                row2["kostk"] = amb[i].Kostk.ToString();
                                row2["maktx"] = amb[i].Maktx.ToString();
                                row2["matnr"] = amb[i].Matnr.ToString();
                                row2["meins"] = amb[i].Meins.ToString();
                                row2["posnr"] = amb[i].Posnr.ToString();
                                row2["vbeln"] = amb[i].Vbeln.ToString();

                                if (!itemControl(drAdres2, amb[i].DagitimAdresi.ToString(), amb[i].Vbeln.ToString()))
                                {
                                    drAdres2.Rows.Add(row2);
                                }
                                

                                
                            }
                        }

                        
                        
                        grd_List.DataSource = null;
                        grd_List.DataSource = drAdres;

                        grd_ListT.DataSource = null;
                        grd_ListT.DataSource = drAdres2;

                        Utility.selectText(txtDagitimAdresi);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_txtDagitimAraci_KeyDown "+ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            } 
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_txtDagitimAraci_KeyDown end");
        }

        private void txtDagitimAdresi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Kaydet_Click(new object(), new EventArgs());

            }
        }

        private string belgeNoBul(string _dagitimAdresi)
        {
            string _vbeln = "";

            for (int i = 0; i < drAdres.Rows.Count; i++)
            {
                if (drAdres.Rows[i]["dagitimAdresi"].ToString() == _dagitimAdresi)
                {
                    _vbeln = drAdres.Rows[i]["vbeln"].ToString();
                }
            }

            return _vbeln;
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_btn_Kaydet_Click begin");
            if (txtDagitimAdresi.Text.Trim() == "")
            {
                return;
            }

            txtDagitimAraci.Text = txtDagitimAraci.Text.ToString().Trim().ToUpper();
            txtDagitimAdresi.Text = txtDagitimAdresi.Text.ToString().Trim().ToUpper();

            if ((!Utility.baslangicKontrol(txtDagitimAdresi.Text, "ARAC")) && (!Utility.baslangicKontrol(txtDagitimAdresi.Text, "PALET")))
            {
                MessageBox.Show("Bu adres ile işlem yapılamaz.", "HATA");
                Utility.selectText(txtDagitimAdresi);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsAmbalajKontAdres chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontAdres();
                WS_Kontrol.ZKtWmWsAmbalajKontAdresResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAmbalajKontAdresResponse();


                chk.IvDagadres = txtDagitimAdresi.Text.Trim().ToString();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsAmbalajKontAdres(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {

                    Cursor.Current = Cursors.Default;
                    frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay frm = new frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay();

                    //Dağıtım adresinden dönen Vbeln e bağlı malzeme listesi sonraki forma aktarılıyor
                    int count = resp.EtAmbalaj.Length;
                    frm._dagitimListesi = new KoctasWM_Project.WS_Kontrol.ZktWmStAmbalaj[count];
                    frm._dagitimListesi = resp.EtAmbalaj;
                    
                    //string __Vbeln = belgeNoBul(txtDagitimAdresi.Text.Trim().ToString());
                    string __Vbeln = "";
                    __Vbeln = resp.EtAmbalaj[0].Vbeln.ToString();
                    frm._Vbeln = __Vbeln;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.Close();
                    }

                    /*
                    if (resp.EtAmbalaj[0].Kostk.ToString().ToUpper() == "C")
                    {
                        frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay frm = new frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_Detay();

                        //Dağıtım adresinden dönen Vbeln e bağlı malzeme listesi sonraki forma aktarılıyor
                        int count = resp.EtAmbalaj.Length;
                        frm._dagitimListesi = new KoctasWM_Project.WS_Kontrol.ZktWmStAmbalaj[count];
                        frm._dagitimListesi = resp.EtAmbalaj;
                        frm._Vbeln = txtDagitimAdresi.Text.Trim().ToString();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Teslimat için dağıtım işlemleri tamamlanmadı.", "HATA");
                        Utility.selectText(txtDagitimAdresi);
                    }*/

                }
                else if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "E")
                {
                    if (resp.EsResponse[0].Msgno.ToString() == "091")
                    {
                        if (MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv1 = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                            WS_Islem.ZKtWmWsTeslimatTopGerAl chk1 = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimatTopGerAl();
                            WS_Islem.ZKtWmWsTeslimatTopGerAlResponse resp1 = new KoctasWM_Project.WS_Islem.ZKtWmWsTeslimatTopGerAlResponse();

                            chk1.IvLgnum = "";
                            chk1.IvLgpla = belgeNoBul(txtDagitimAdresi.Text.Trim().ToString());

                            srv1.Credentials = GlobalData.globalCr;
                            srv1.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                            resp1 = srv1.ZKtWmWsTeslimatTopGerAl(chk1);

                            if (resp1.EsResponse.Length > 0)
                            {
                                //Mesajlar düzenleniyor
                                GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                                GlobalData.rMsg = Utility.mesajDuzenle(resp1.EsResponse);

                                if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                                {
                                    MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                                    txtDagitimAdresi.Text = "";
                                    Utility.selectText(txtDagitimAdresi);
                                }
                                else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                                {
                                    MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                                    Utility.moreMsgCheck(GlobalData.rMsg);
                                    txtDagitimAdresi.Text = "";
                                    Utility.selectText(txtDagitimAdresi);
                                }
                                else
                                {
                                    MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                                    txtDagitimAdresi.Text = "";
                                    Utility.selectText(txtDagitimAdresi);
                                }

                            }
                            else
                            {
                                MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                            }

                        }
                        else
                        {
                            txtDagitimAdresi.Text = "";
                            Utility.selectText(txtDagitimAdresi);
                        }
                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        Utility.selectText(txtDagitimAdresi);
                    }

                    txtDagitimAraci_KeyDown(new object(), new KeyEventArgs(Keys.Enter));
                    
                } 
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                    Utility.selectText(txtDagitimAdresi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                logger.error("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_btn_Kaydet_Click "+ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            logger.info("frm_20_Dagitim_Musteri_Sevkiyatlari_Ambalajlama_ve_Iptali_btn_Kaydet_Click end");
        }
      
    }
}