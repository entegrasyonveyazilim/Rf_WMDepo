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
    public partial class frm_07_Depo_Adres_Sorgulama : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_07_Depo_Adres_Sorgulama).Name);
        public frm_07_Depo_Adres_Sorgulama()
        {
            InitializeComponent();
        }

        DataTable drAdres = new DataTable();
        
        

        private void frm_07_Depo_Adres_Sorgulama_Load(object sender, EventArgs e)
        {
            logger.info("frm_07_Depo_Adres_Sorgulama_Load begin");
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
            txtAdresNo.Focus();
            logger.info("frm_07_Depo_Adres_Sorgulama_Load end");
        }

        private void txtPaletNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_AdresNo, 'b');
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
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

        private void txtAdresNo_GotFocus(object sender, EventArgs e)
        {
            Utility.setBackBolor(p1, lbl_AdresNo, 'b');
        }

        private void txtAdresNo_KeyDown(object sender, KeyEventArgs e)
        {
            logger.info("frm_07_Depo_Adres_Sorgulama_Load_txtAdresNo_KeyDown begin");
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAdresNo.Text.ToString().Trim() == "")
                {
                    return;
                }

                txtAdresNo.Text = txtAdresNo.Text.ToUpper();

                Cursor.Current = Cursors.WaitCursor;
                try {

                    grd_List.DataSource = null;

                    WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                    WS_Kontrol.ZKtWmWsAdresSorgu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAdresSorgu();
                    WS_Kontrol.ZKtWmWsAdresSorguResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAdresSorguResponse();
                    

                    chk.IvLgpla = txtAdresNo.Text.ToString().ToUpper().Trim();
                    
                    srv.Credentials = GlobalData.globalCr;
                    srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                    resp = srv.ZKtWmWsAdresSorgu(chk);

                    if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                    {
                        int count = resp.EsStok.Length;
                        WS_Kontrol.ZktWmStok[] stok = new KoctasWM_Project.WS_Kontrol.ZktWmStok[count];
                        stok = resp.EsStok;

                        for (int i=0; i < resp.EsStok.Length; i++)
                        {
                            DataRow row = drAdres.NewRow();
                            row["malzemeNo"] = Convert.ToInt64(stok[i].Matnr.ToString()).ToString();
                            row["malzemeTanim"] = stok[i].Maktx.ToString();
                            row["toplamMiktar"] = stok[i].Miktar.ToString();
                            row["olcuBirimi"] = stok[i].Meins.ToString();
                            row["adres"] = stok[i].Lgpla.ToString();
                            row["stokTipi"] = stok[i].Bestq.ToString();
                            row["toplanacakMiktar"] = stok[i].EmirliMiktar.ToString();
                            row["paletNo"] = stok[i].Lenum.ToString();
                            row["ean"] = stok[i].Ean.ToString();

                            drAdres.Rows.Add(row);
                        }

                        grd_List.DataSource = null;
                        grd_List.DataSource = drAdres;

                        Utility.selectText(txtAdresNo);

                    }
                    else
                    {
                        MessageBox.Show(resp.EsResponse[0].Message.ToString(), "HATA");
                        txtAdresNo.Text = "";
                        Utility.selectText(txtAdresNo);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                    logger.error("frm_07_Depo_Adres_Sorgulama_Load_txtAdresNo_KeyDown " + ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }
            logger.info("frm_07_Depo_Adres_Sorgulama_Load_txtAdresNo_KeyDown end");
        }
        
    }
}