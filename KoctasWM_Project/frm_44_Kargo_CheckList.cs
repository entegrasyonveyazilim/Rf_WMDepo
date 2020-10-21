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
    public partial class frm_44_Kargo_CheckList : Form
    {
        public frm_44_Kargo_CheckList()
        {
            InitializeComponent();
        }

        private void formAcilisDuzenle()
        {
            txtPaletNo.Text = "";

            txtPaletNo.Focus();
        }

        private void frm_44_Kargo_CheckList_Load(object sender, EventArgs e)
        {
            formAcilisDuzenle();
        }

        private void btn_Yazdir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                WS_Islem.ZKtWmWsCheckListYazdirma request = new KoctasWM_Project.WS_Islem.ZKtWmWsCheckListYazdirma();
                WS_Islem.ZKtWmWsCheckListYazdirmaResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsCheckListYazdirmaResponse();
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");

                request.IvPaletNo = txtPaletNo.Text.Trim();

                resp = srv.ZKtWmWsCheckListYazdirma(request);

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
                        formAcilisDuzenle();
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

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}