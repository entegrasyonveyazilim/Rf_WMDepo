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
    public partial class KoliNoPopUp : Form
    {
        public KoliNoPopUp()
        {
            InitializeComponent();
            // Eklendi
        }

        private void checkListYazdir_Click_1(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            KoctasWM_Project.WS_Koli.Z_KT_WM_KOLI_DETAY service = new KoctasWM_Project.WS_Koli.Z_KT_WM_KOLI_DETAY();
            KoctasWM_Project.WS_Koli.ZKtWmKoliDetay koli = new KoctasWM_Project.WS_Koli.ZKtWmKoliDetay();
            KoctasWM_Project.WS_Koli.ZktWmReturn[] ret = new KoctasWM_Project.WS_Koli.ZktWmReturn[1];
            KoctasWM_Project.WS_Koli.ZKtWmKoliDetayResponse resp = new KoctasWM_Project.WS_Koli.ZKtWmKoliDetayResponse();
            koli.IvKoliNo = koliNoText.Text.ToString();
            ret[0] = new KoctasWM_Project.WS_Koli.ZktWmReturn();
            resp.EsResponse = ret;
            service.Url = Utility.getWsUrlForWM("z_kt_wm_koli_detay");
            try
            {
                resp = service.ZKtWmKoliDetay(koli);
                if (resp.EsResponse.Length > 0)
                {
                    MessageBox.Show(resp.EsResponse[0].Message);
                    return;
                }
                else
                {
                    MessageBox.Show("İşlem Tamamlanmıştır");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATAAAA.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                return;
            }
        }
    }
}