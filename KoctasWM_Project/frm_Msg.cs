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
    public partial class frm_Msg : Form
    {
        public frm_Msg()
        {
            InitializeComponent();
        }

        DataTable _msg;
        public WS_Islem.ZktWmReturn[] _return;

        private void frm_Msg_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            _msg = new DataTable();

            _msg.Columns.Add("msg");
            _msg.Columns.Add("msgTip");

            //Eğer hiç mesaj yok ise form açılmadan kapatılıyor
            if (_return.Length == 0)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            try
            {
                //Mesaj içerikleri tabloya dolduruluyor
                for (int i = 0; i < _return.Length; i++)
                {
                    DataRow row = _msg.NewRow();
                    row["msgTip"] = _return[i].Msgty.ToString();
                    row["msg"] = _return[i].Message.ToString();
                    _msg.Rows.Add(row);
                }

                grd_Hata.DataSource = null;
                grd_Hata.DataSource = _msg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "HATA");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            
        }

        private void btn_Tamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}