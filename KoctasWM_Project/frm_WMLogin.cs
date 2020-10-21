using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using Microsoft.Win32;

namespace KoctasWM_Project
{
    public partial class frm_WMLogin : Form
    {
        private VMLogger logger = new VMLogger(typeof(frm_WMLogin).Name);
        
        public frm_WMLogin()
        {
            InitializeComponent();
        }

        [DllImport("coredll.dll")]
        private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("coredll.dll")]
        private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("coredll.dll", EntryPoint = "GetTimeZoneInformation")]
        internal static extern UInt32 GetTimeZoneInformation(ref TIME_ZONE_INFORMATION TZI);

        [DllImport("coredll.dll", EntryPoint = "SetTimeZoneInformation")]
        internal static extern UInt32 SetTimeZoneInformation(ref TIME_ZONE_INFORMATION TZI);

        [DllImport("coredll.dll", EntryPoint = "SetLocalTime", SetLastError = true)]
        internal static extern bool WinCESetLocalTime(ref SYSTEMTIME st);



        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        public struct STRING
        {
            public char char0;
            public char char1;
            public char char2;
            public char char3;
            public char char4;
            public char char5;
            public char char6;
            public char char7;
            public char char8;
            public char char9;
            public char char10;
            public char char11;
            public char char12;
            public char char13;
            public char char14;
            public char char15;
            public char char16;
            public char char17;
            public char char18;
            public char char19;
            public char char20;
            public char char21;
            public char char22;
            public char char23;
            public char char24;
            public char char25;
            public char char26;
            public char char27;
            public char char28;
            public char char29;
            public char char30;
            public char char31;

            public override String ToString()
            {
                char[] temp = new char[32];
                temp[0] = char0;
                temp[1] = char1;
                temp[2] = char2;
                temp[3] = char3;
                temp[4] = char4;
                temp[5] = char5;
                temp[6] = char6;
                temp[7] = char7;
                temp[8] = char8;
                temp[9] = char9;
                temp[10] = char10;
                temp[11] = char11;
                temp[12] = char12;
                temp[13] = char13;
                temp[14] = char14;
                temp[15] = char15;
                temp[16] = char16;
                temp[17] = char17;
                temp[18] = char18;
                temp[19] = char19;
                temp[20] = char20;
                temp[21] = char21;
                temp[22] = char22;
                temp[23] = char23;
                temp[24] = char24;
                temp[25] = char25;
                temp[26] = char26;
                temp[27] = char27;
                temp[28] = char28;
                temp[29] = char29;
                temp[30] = char30;
                temp[31] = char31;

                // The string constructor for char[] will create a string of a length of 32 that contains embedded nulls
                // find the first original null (if one exists) and ensure that it doesn't get embedded into the returned string.

                int iLen = 0;
                for (int i = 0; i < 32; i++)
                {
                    if ('\0' == temp[i])
                    {
                        iLen = i;
                        break;
                    }
                }

                String sRetVal = new String(temp, 0, iLen);
                return sRetVal;
            }
        }

        private void SetCurrentDate(DateTime dt)
        {
            SYSTEMTIME sysTime = new SYSTEMTIME();
            sysTime.wYear = Convert.ToUInt16(dt.Year);
            sysTime.wDay = Convert.ToUInt16(dt.Day);
            sysTime.wDayOfWeek = (UInt16)dt.DayOfWeek;
            sysTime.wHour = Convert.ToUInt16(dt.Hour);
            sysTime.wSecond = Convert.ToUInt16(dt.Second);
            sysTime.wMinute = Convert.ToUInt16(dt.Minute);
            sysTime.wMonth = Convert.ToUInt16(dt.Month);
            sysTime.wMilliseconds = Convert.ToUInt16(dt.Millisecond);

            SetSystemTime(ref sysTime);

        }

        public struct TIME_ZONE_INFORMATION
        {
            public int Bias;
            public STRING StandardName;
            public SYSTEMTIME StandardDate;
            public int StandardBias;
            public STRING DaylightName;
            public SYSTEMTIME DaylightDate;
            public int DaylightBias;

            public override Boolean Equals(Object obj)
            {
                if (!(obj is TIME_ZONE_INFORMATION))
                    return false;

                TIME_ZONE_INFORMATION t1 = (TIME_ZONE_INFORMATION)obj;
                if (this.Bias != t1.Bias
                || !this.StandardDate.Equals(t1.StandardDate)
                || this.StandardBias != t1.StandardBias
                || !this.DaylightDate.Equals(t1.DaylightDate)
                || this.DaylightBias != t1.DaylightBias
                )
                    return false;

                return true;

            }

            public override Int32 GetHashCode()
            {
                return Bias;
            }

            public override String ToString()
            {
                String str1 = String.Format("Bias: {0}, StdName: {1}, StdDate: {2}, StdBias: {3}, DayName: {4}, DayDate: {5}, DayBias: {6}", Bias, StandardName, StandardDate, StandardBias, DaylightName, DaylightDate, DaylightBias);
                return str1;
            }

        }



        private void btn_Cikis_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Dispose();
                    this.Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "HATA");
            }
            
            
            
        }

        private void frm_WMLogin_Load(object sender, EventArgs e)
        {
            logger.info("frm_WMLogin_Load begin");

            this.WindowState = FormWindowState.Maximized;
            cmbSunucu.Text = GlobalData.sunucuTip;

            bool versiyonCheck = Utility.checkNewVersion();
            if (versiyonCheck)
            {
                //Update zorunlu
                btn_Giris.Enabled = false;
            }


            //Version bilgisi çekiliyor
            lbl_Version.Text = Utility.GetCurrentApplicationDate()+" - V. " + Utility.GetCurrentApplicationVersion();
            lbl_BaglantiBilgisi.Text = " sisteme bağlanıyorsunuz...";

            logger.info("frm_WMLogin_Load end");
        }

        private void btn_Giris_Click(object sender, EventArgs e)
        {
            logger.info("frm_WMLogin_btn_Giris_Click begin");
            Boolean login = false;

            if (txtKullaniciAdi.Text.Trim() == "")
            {
                return;
            }
            if (txtSifre.Text.Trim() == "")
            {
                return;
            }

            //Eğer güvenli mod girişi var ise
            if ((txtKullaniciAdi.Text.ToString().Trim() == GlobalData.modUser) && (txtSifre.Text.ToString().Trim() == GlobalData.modPass))
            {
                cmbSunucu.Enabled = true;
                MessageBox.Show("Günveli mod aktif edildi", "BİLGİ");
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                Utility.selectText(txtKullaniciAdi);
                return;
            }
            

            Utility.setSunucu(cmbSunucu.Text);
            GlobalData.sunucuTip = cmbSunucu.Text;
            
            
            Cursor.Current = Cursors.WaitCursor;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential(txtKullaniciAdi.Text.Trim(), txtSifre.Text.Trim());

            WS_Login.ZKT_WM_WS_LOGIN srv = new KoctasWM_Project.WS_Login.ZKT_WM_WS_LOGIN();
            WS_Login.ZKT_WM_LOGIN chk = new KoctasWM_Project.WS_Login.ZKT_WM_LOGIN();
            WS_Login.ZKMOBIL_RETURN[] ret = new KoctasWM_Project.WS_Login.ZKMOBIL_RETURN[1];
            WS_Login.ZKT_WM_LOGINResponse resp = new KoctasWM_Project.WS_Login.ZKT_WM_LOGINResponse();

            ret[0] = new KoctasWM_Project.WS_Login.ZKMOBIL_RETURN();

            chk.T_RETURN = ret;
            resp.T_RETURN = ret;
            srv.Credentials = nc;
            srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_login");

            try
            {
                resp = srv.ZKT_WM_LOGIN (chk);
                if (resp.T_RETURN.Length > 0 && resp.T_RETURN[0].RC_CODE.ToUpper() == "S")
                {
                    login = true;
                }
                else
                {
                    login = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "WebException")
                {
                    MessageBox.Show("Kullanıcı adı / Şifre hatalı.", "Giriş Başarısız!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                login = false;
                logger.error("frm_WMLogin_btn_Giris_Click " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


            if (login)
            {

                //Global değişkenler set ediliyor
                GlobalData.globalCr = nc;
                GlobalData.kullaniciAdi = txtKullaniciAdi.Text.Trim();
                frm_Menu frm = new frm_Menu();

                TIME_ZONE_INFORMATION tzI = new TIME_ZONE_INFORMATION();
                GetTimeZoneInformation(ref tzI);
                tzI.Bias = -120;
                SetTimeZoneInformation(ref tzI);

                DateTime to_set = Convert.ToDateTime(resp.E_TARIH + " " + resp.E_SAAT.Hour.ToString() +':'+resp.E_SAAT.Minute.ToString());
                to_set -= new TimeSpan(2, 0, 0);
                SetCurrentDate(to_set);

                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Abort)
                {
                    this.Close();
                    this.Dispose();
                }

            }
            else
            {
                Cursor.Current = Cursors.Default;
            }




            logger.info("frm_WMLogin_btn_Giris_Click end");
            
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtKullaniciAdi.Text.Trim() != ""))
            {
                txtSifre.Focus();
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtSifre.Text.Trim() != ""))
            {
                btn_Giris_Click(new object(), new EventArgs());

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Kargo frm = new frm_Menu_Mal_Cikis_Sevkiyat_Islemleri_Kargo();

            frm.ShowDialog();
        }

    }
}