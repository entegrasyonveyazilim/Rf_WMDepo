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
    public partial class frm_Waiting : Form
    {
        public frm_Waiting()
        {
            InitializeComponent();
        }

        public string _koliNo;
        public bool _atfKontrol = false;
        public bool _kontrolEttim = false;

        public void atfKontrol()
        {
            if (_kontrolEttim == false)
            {
                _kontrolEttim = true;
                try
                {
                    if (Utility.atfGenel(_koliNo) == true)
                    {
                        _atfKontrol = true;
                        timer2.Enabled = false;
                    }
                    else
                    {
                        _atfKontrol = false;
                        timer2.Enabled = false;
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    timer2.Enabled = false;
                    MessageBox.Show("ATF numarası alınırken hata oluştu: " + ex.Message, "HATA");
                    _atfKontrol = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        
        private void frm_Waiting_Load(object sender, EventArgs e)
        {
            //atfKontrol();
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void frm_Waiting_GotFocus(object sender, EventArgs e)
        {
            //atfKontrol();
           
        }

        private void frm_Waiting_Activated(object sender, EventArgs e)
        {
            //atfKontrol();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            atfKontrol();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            MessageBox.Show("ATF numarası alma fonksiyonu uzun süre değer dönmedi. Lütfen tekrar deneyiniz.");
            _atfKontrol = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}