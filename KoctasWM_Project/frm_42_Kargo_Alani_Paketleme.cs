using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoctasWM_Project
{
    public partial class frm_42_Kargo_Alani_Paketleme : Form
    {
        public frm_42_Kargo_Alani_Paketleme()
        {
            InitializeComponent();
        }

        DataTable _koliler;

        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = "";
            txtKoliNo.Text = "";

            _koliler.Clear();

            txtPaletNo.Focus();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            KoliEkle();
        }

        private void KoliEkle()
        {
            DataRow row = _koliler.NewRow();

            row["koliNo"] = txtKoliNo.Text.Trim();

            _koliler.Rows.Add(row);

            txtKoliNo.Text = "";

            grdKoliler.Refresh();
        }

        private void btn_Tamamla_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                List<string> koliler = new List<string>();

                foreach (DataRow row in _koliler.Rows)
                {
                    koliler.Add(row["koliNo"].ToString());
                }

                WS_Islem.ZKtWmWsKargoAlaniPaletle request = new KoctasWM_Project.WS_Islem.ZKtWmWsKargoAlaniPaletle();
                WS_Islem.ZKtWmWsKargoAlaniPaletleResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsKargoAlaniPaletleResponse();
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");

                request.ItKoliNo = koliler.ToArray();
                request.IvPaletNo = txtPaletNo.Text.Trim();

                resp = srv.ZKtWmWsKargoAlaniPaletle(request);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                        formAcilisDuzenle();

                        Utility.selectText(txtPaletNo);
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        txtKoliNo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                        Utility.selectText(txtPaletNo);
                        formAcilisDuzenle();
                    }
                }
                else
                {
                    MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                    formAcilisDuzenle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
                formAcilisDuzenle();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void frm_42_Kargo_Alani_Paketleme_Load(object sender, EventArgs e)
        {
            _koliler = new DataTable();

            _koliler.Columns.Add("koliNo");

            formAcilisDuzenle();

            grdKoliler.DataSource = _koliler;

            grdKoliler.TableStyles.Clear();
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = _koliler.TableName;

            foreach (DataColumn item in _koliler.Columns)
            {
                DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
                tbcName.Width = 200;
                tbcName.MappingName = item.ColumnName;
                tbcName.HeaderText = item.ColumnName;
                tableStyle.GridColumnStyles.Add(tbcName);
            }

            grdKoliler.TableStyles.Add(tableStyle);
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Secili_Satiri_Sil_Click(object sender, EventArgs e)
        {
            int selectedRowNumber = grdKoliler.CurrentCell.RowNumber;

            if (_koliler.Rows.Count > 0)
            {
                _koliler.Rows.RemoveAt(selectedRowNumber);
                grdKoliler.Refresh();
            }
        }

        private void txtPaletNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKoliNo.Focus();
            }
        }

        private void txtKoliNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KoliEkle();
            }         
        }

    }
}