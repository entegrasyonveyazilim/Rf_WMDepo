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
    public partial class frm_07_Depo_Urun_Sorgulama : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_07_Depo_Urun_Sorgulama).Name);
        public frm_07_Depo_Urun_Sorgulama()
        {
            InitializeComponent();
        }

        DataTable drAdres = new DataTable();


        private void txtMalzemeNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_MalzemeNo, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMalzemeNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_07_Depo_Urun_Sorgulama_txtMalzemeNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMalzemeNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    grd_List.DataSource = null;

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsUrunSorgu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsUrunSorgu();
                    WS_Kontrol.ZKtWmWsUrunSorguResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsUrunSorguResponse();
                    WS_Kontrol.ZktWmStUrunAyrinti urunAyrinti = new KoctasWM_Project.WS_Kontrol.ZktWmStUrunAyrinti();

                    chk.IvEan = txtMalzemeNo.Text.ToString().Trim();

                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsUrunSorgu(chk);

                    drAdres.Rows.Clear();

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        int count = resp.EtStok.Length;
                        WS_Kontrol.ZktWmStok[] stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok[count];
                        stok = resp.EtStok;
                        urunAyrinti = resp.EsUrunAyrinti;

                        txtMalzemeNo2.Text = Convert.ToInt64(urunAyrinti.Matnr.ToString()).ToString();
                        txtMalzemeTanimi.Text = urunAyrinti.Maktx.ToString();
                        txtSaticiKoduAdi.Text = urunAyrinti.Lifnr.ToString() + " / " + urunAyrinti.Name1.ToString();
                        txtMalGrubuTanimi.Text = urunAyrinti.Matkl.ToString() + " / " + urunAyrinti.Wgbez.ToString();
                        txtToplamStokOlcuBirimi.Text = txtBlokeStokOlcuBirimi.Text = txtKullanilabilirStokOlcuBirimi.Text = urunAyrinti.Meins.ToString();
                        txtToplamStok.Text = urunAyrinti.Gesme.ToString();
                        txtKullanilabilirStok.Text = urunAyrinti.Verme.ToString();
                        txtBlokeStok.Text = urunAyrinti.Bloke.ToString();
                        

                        for (int i = 0; i < count; i++)
                        {
                            DataRow row = drAdres.NewRow();
                            row["malzemeNo"] = stok[i].Matnr.ToString();
                            row["malzemeTanim"] = stok[i].Maktx.ToString();
                            row["toplamMiktar"] = stok[i].Miktar.ToString();
                            row["olcuBirimi"] = stok[i].Meins.ToString();
                            row["adres"] = stok[i].Lgpla.ToString();
                            row["stokTipi"] = stok[i].Bestq.ToString();
                            row["toplanacakMiktar"] = stok[i].EmirliMiktar.ToString();
                            row["paletNo"] = stok[i].Lenum.ToString();
                            row["ean"] = stok[i].Ean.ToString();
                            row["depoTipi"] = stok[i].Lgtyp.ToString();

                            drAdres.Rows.Add(row);
                        }

                        //drAdres.DefaultView.Sort = "depoTipi, adres Asc";
                        //drAdres.DefaultView.Sort = drAdres.Columns["adres"].ColumnName;
                        //drAdres.AcceptChanges();

                        grd_List.DataSource = null;
                        grd_List.DataSource = drAdres;

                        Utility.selectText(txtMalzemeNo);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        txtMalzemeNo.Text = "";
                        Utility.selectText(txtMalzemeNo);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_07_Depo_Urun_Sorgulama_txtMalzemeNo_KeyDown "+ ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            logger.info("frm_07_Depo_Urun_Sorgulama_txtMalzemeNo_KeyDown end");
        }

        private void frm_07_Depo_Urun_Sorgulama_Load(object sender, EventArgs e)
        {
            logger.info("frm_07_Depo_Urun_Sorgulama_Load begin");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;

            Utility.loginInfo(lbl_LoginInfo);

            drAdres = new DataTable();
            drAdres.Columns.Add("malzemeNo");
            drAdres.Columns.Add("malzemeTanim");
            drAdres.Columns.Add("toplamMiktar");
            drAdres.Columns.Add("olcuBirimi");
            drAdres.Columns.Add("adres");
            drAdres.Columns.Add("stokTipi");
            drAdres.Columns.Add("toplanacakMiktar");
            drAdres.Columns.Add("paletNo");
            drAdres.Columns.Add("ean");
            drAdres.Columns.Add("depoTipi");


            txtMalzemeNo.Focus();
            logger.info("frm_07_Depo_Urun_Sorgulama_Load end");
        }

        private void grd_List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frm_07_Depo_Adres_Sorgulama_Detay frm = new frm_07_Depo_Adres_Sorgulama_Detay();


                frm._malzemeNo = drAdres.Rows[grd_List.CurrentCell.RowNumber]["malzemeNo"].ToString();
                frm._adres = drAdres.Rows[grd_List.CurrentCell.RowNumber]["adres"].ToString(); ;
                frm._paletNo = drAdres.Rows[grd_List.CurrentCell.RowNumber]["paletNo"].ToString();
                frm._malzemeTanim = drAdres.Rows[grd_List.CurrentCell.RowNumber]["malzemeTanim"].ToString();
                frm._toplamMiktar = drAdres.Rows[grd_List.CurrentCell.RowNumber]["toplamMiktar"].ToString();
                frm._olcuBirimi = drAdres.Rows[grd_List.CurrentCell.RowNumber]["olcuBirimi"].ToString();
                frm._stokTipi = drAdres.Rows[grd_List.CurrentCell.RowNumber]["stokTipi"].ToString();
                frm._toplanacakMiktar = drAdres.Rows[grd_List.CurrentCell.RowNumber]["toplanacakMiktar"].ToString();
                frm._ean = drAdres.Rows[grd_List.CurrentCell.RowNumber]["ean"].ToString();

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        private void txtKullanilabilirStokOlcuBirimi_TextChanged(object sender, EventArgs e)
        {

        }

    }
}