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
    public partial class frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay : Form
    {
        public frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay()
        {
            InitializeComponent();
        }

        public WS_Yardim.ZktWmSayimCnl[] _sayim = new KoctasWM_Project.WS_Yardim.ZktWmSayimCnl[100];
        DataTable _detay;

        private void frm_25_Sayim_Islemleri_Canli_Oncesi_Sayim_Detay_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            Utility.loginInfo(lbl_LoginInfo);

            _detay = new DataTable();
            _detay.Columns.Add("Lgpla");
            _detay.Columns.Add("Lenum");
            _detay.Columns.Add("Matnr");
            _detay.Columns.Add("Menge");

            //_sayim tabloya aktariliyor
            for (int i = 0; i < _sayim.Length; i++)
            {
                if (_sayim[i].Lgpla.ToString() != "")
                {
                    DataRow row = _detay.NewRow();
                    row["Lgpla"] = _sayim[i].Lgpla.ToString();
                    if (_sayim[i].Lenum.ToString() == "")
                    {
                        row["Lenum"] = "";
                    }
                    else
                    {
                        row["Lenum"] = Convert.ToInt64(_sayim[i].Lenum.ToString()).ToString();
                    }

                    if (_sayim[i].Matnr.ToString() == "")
                    {
                        row["Matnr"] = "";
                    }
                    else
                    {
                        row["Matnr"] = Convert.ToInt64(_sayim[i].Matnr.ToString()).ToString();
                    }
                    
                    
                    row["Menge"] = _sayim[i].Menge.ToString();
                    _detay.Rows.Add(row);
                }
            }

            grd_List.DataSource = null;
            grd_List.DataSource = _detay;
        }

        private void btn_Iptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btn_Degistir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}