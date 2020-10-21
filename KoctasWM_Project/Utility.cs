using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Drawing;
using System.IO;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;

namespace KoctasWM_Project
{
    
    class Utility
    {
        internal class AcceptAllCertificatePolicy : ICertificatePolicy
        {
            public AcceptAllCertificatePolicy()
            {
            }

            public bool CheckValidationResult(ServicePoint sPoint, X509Certificate cert, WebRequest wRequest, int certProb)
            {
                return true;
            }
        }
        
        public static void setSunucu(string sunucu)
        {
            switch (sunucu)
            {
                case "DEV Test" : GlobalData.sunucuIp = "10.160.160.80:8000"; break;
                case "QA Test": GlobalData.sunucuIp = "10.160.160.81:8000"; break;
                case "PROD": GlobalData.sunucuIp = "10.160.160.51:8000"; break;

                default: GlobalData.sunucuIp = "10.160.160.51:8000"; break;

            }
        }

        public static string getWsUrl(string servicename)
        {
           return "http://" + GlobalData.sunucuIp + "/sap/bc/srt/rfc/sap/" + servicename + "/500/service/service";
        }

        public static string getWsUrlForWM(string servicename)
        {
            string servicenameService = "";
            switch (servicename) {
                case "zkt_wm_ws_yardim" : { servicenameService = "zkt_wm_ws_yardimservice"; break; }
                case "zkt_wm_ws_kontrol": { servicenameService = "zkt_wm_ws_kontrolservice"; break; }
                case "zkt_wm_ws_islem": { servicenameService = "ZKT_WM_WS_ISLEMSERVICE"; break; }
                case "zkt_wm_ws_login": { servicenameService = "zkt_wm_ws_login"; break; }
                case "z_kt_wm_koli_detay": { servicenameService = "z_kt_wm_koli_detay"; break; }
                default: break;

            }
            
            //return "http://" + GlobalData.sunucuIp + "/sap/bc/srt/rfc/sap/" + servicename + "/500/service/service";
            //return "http://" + GlobalData.sunucuIp + "/sap/bc/srt/rfc/sap/" + servicename + "/500/" + servicename + "/" + servicename + "";
            return "http://" + GlobalData.sunucuIp + "/sap/bc/srt/rfc/sap/" + servicename + "/500/" + servicenameService + "/" + servicename + "";
            


            /*
            if (Program.canli)
            {
                return "http://10.160.160.51:8000/sap/bc/srt/rfc/sap/" + servicename + "/500/" + servicename + "/" + servicename + "";
            }
            else
            {
                return "http://10.160.160.80:8000/sap/bc/srt/rfc/sap/" + servicename + "/500/" + servicename + "/" + servicename + "";
            }*/
            
        }

        public static void moreMsgCheck(WS_Islem.ZktWmReturn[] _msg) {

            int count = _msg.Length;
            if (count > 1)
            {
                Cursor.Current = Cursors.Default;
                if (MessageBox.Show("Yapılan işleme ait daha farklı bilgi mesajları da bulunmaktadır. Diğer mesajları da görmek istiyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    frm_Msg frm = new frm_Msg();
                    frm._return = _msg;
                    if (frm.ShowDialog() == DialogResult.Cancel)
                    {
                        MessageBox.Show("Diğer hata mesajları gösterilemiyor");
                    }
                }
                
            }

        }

        public static void loginInfo(Label lbl) 
        {
            lbl.Text += ' ' + GlobalData.kullaniciAdi.ToString();
        }

        public static string malzemeNoGetir(string ean, string donusDegeri)
        {
            string matnrEan = "0";

            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWmMalzemeInfo chk = new KoctasWM_Project.WS_Islem.ZKtWmWmMalzemeInfo();
                WS_Islem.ZKtWmWmMalzemeInfoResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWmMalzemeInfoResponse();

                chk.IvEan = ean.ToString().Trim();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWmMalzemeInfo(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    if (donusDegeri == "ean")
                    {
                        matnrEan = resp.EsMalzeme.Ean.ToString();
                    }
                    else if (donusDegeri == "matnr")
                    {
                        matnrEan = resp.EsMalzeme.Matnr.ToString();
                    }
                    else
                    {
                        matnrEan = resp.EsMalzeme.Matnr.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message, "HATA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

            return matnrEan;

        }


        public static WS_Islem.ZktWmReturn[] mesajDuzenle(WS_Islem.ZktWmReturn[] _msg)
        {
            int count = _msg.Length;
            string[] _msgType = new string[] { "E", "W", "S", "I" };

            
            WS_Islem.ZktWmReturn[] _newMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[count];
            if (count > 0)
            {
                int say = 0;

                foreach (string _type in _msgType)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (_type == _msg[i].Msgty.ToString())
                        {
                            _newMsg[say] = _msg[i];
                            say++;
                        }
                    }
                }
            }

            return _newMsg;
        }
         

        public static void setBackBolor(Panel p1, Label l1, char color)
        {
            if (color == 'b')
            {
                p1.BackColor = Color.FromArgb(237, 246, 251);
                l1.BackColor = Color.FromArgb(237, 246, 251);
            }
            else if (color == 'w')
            {
                p1.BackColor = Color.White;
                l1.BackColor = Color.White;
            }
            else if (color == 'p')
            {
                p1.BackColor = Color.FromArgb(254, 242, 228);
                l1.BackColor = Color.FromArgb(254, 242, 228);
            }
        }

        public static void selectText(TextBox t1)
        {
            t1.Focus();
            t1.SelectionStart = 0;
            t1.SelectionLength = t1.Text.Length;
        }

        

        public static string StartupPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            }
        }

        public static double ConvertToTimestamp(DateTime value)
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (double)span.TotalSeconds;
        }



        public class ProcessInfo
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public Int32 ProcessId;
            public Int32 ThreadId;
        }

        public static string GetCurrentApplicationVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static string GetCurrentApplicationDate()
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string fileName = System.AppDomain.CurrentDomain.FriendlyName.ToString();
            return File.GetCreationTime(path + "/" + fileName).ToString();
        }

        public static bool yetkiKontrol(string formIsmi)
        {
            bool yetki = false;
            
            if (formIsmi.ToString().Trim() == "")
            {
                return yetki;
            }

            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsYetkiKontrolu chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsYetkiKontrolu();
                WS_Kontrol.ZKtWmWsYetkiKontroluResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsYetkiKontroluResponse();

                chk.IvForm = formIsmi.ToString().Trim();

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsYetkiKontrolu(chk);

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    yetki = true;
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message, "HATA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

            return yetki;
        }


        public static bool atfGenel(string _koliNo)
        {

            WS_Islem.ZktWmStAtfHeader atfHeader = new KoctasWM_Project.WS_Islem.ZktWmStAtfHeader();

            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsAtfGenel chk = new KoctasWM_Project.WS_Islem.ZKtWmWsAtfGenel();
                WS_Islem.ZKtWmWsAtfGenelResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsAtfGenelResponse();



                chk.IvKoliNo = _koliNo;
                //Birden fazla koliNo gecirilmeli

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsAtfGenel(chk);

                atfHeader = resp.EsAtfHeader;

                if (resp.EtResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    //return atfHeader;
                    return true;
                }
                else
                {
                    MessageBox.Show(resp.EtResponse[0].Message, "HATA");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

            //return atfHeader;
            return false;
        }


        public static bool atfInfo(string _koliNo)
        {

            WS_Kontrol.ZktWmStAtfHeader atfHeader =  new KoctasWM_Project.WS_Kontrol.ZktWmStAtfHeader();

            try
            {
                WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE srv = new KoctasWM_Project.WS_Kontrol.ZKT_WM_WS_KONTROLSERVICE();
                WS_Kontrol.ZKtWmWsAtfInfo chk = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAtfInfo();
                WS_Kontrol.ZKtWmWsAtfInfoResponse resp = new KoctasWM_Project.WS_Kontrol.ZKtWmWsAtfInfoResponse();

              
                chk.IvKoliNo = _koliNo;
                //Birden fazla koliNo gecirilmeli

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_kontrol");
                resp = srv.ZKtWmWsAtfInfo(chk);

                atfHeader = resp.EsAtfHeader;

                if (resp.EsResponse[0].Msgty.ToString().ToUpper() == "S")
                {
                    //return atfHeader;
                    return true;
                }
                else
                {
                    MessageBox.Show(resp.EsResponse[0].Message, "HATA");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

            //return atfHeader;
            return false;
        }

        public static bool atfKaydet(string _koliNo, string _atfNo)
        {
            bool basarili = false;
            try
            {
                WS_Islem.ZKT_WM_WS_ISLEMSERVICE srv = new KoctasWM_Project.WS_Islem.ZKT_WM_WS_ISLEMSERVICE();
                WS_Islem.ZKtWmWsAtfKaydet chk = new KoctasWM_Project.WS_Islem.ZKtWmWsAtfKaydet();
                WS_Islem.ZKtWmWsAtfKaydetResponse resp = new KoctasWM_Project.WS_Islem.ZKtWmWsAtfKaydetResponse();

                chk.IvKoliNo = _koliNo;
                chk.IvAtfNo = _atfNo;

                srv.Credentials = GlobalData.globalCr;
                srv.Url = Utility.getWsUrlForWM("zkt_wm_ws_islem");
                resp = srv.ZKtWmWsAtfKaydet(chk);

                if (resp.EsResponse.Length > 0)
                {
                    //Mesajlar düzenleniyor
                    GlobalData.rMsg = new KoctasWM_Project.WS_Islem.ZktWmReturn[resp.EsResponse.Length];
                    GlobalData.rMsg = Utility.mesajDuzenle(resp.EsResponse);

                    if (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "E")
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "HATA");
                    }
                    else if ((GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "S") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "W") || (GlobalData.rMsg[0].Msgty.ToString().ToUpper() == "I"))
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLGİ");
                        Utility.moreMsgCheck(GlobalData.rMsg);
                        basarili = true;
                    }
                    else
                    {
                        MessageBox.Show(GlobalData.rMsg[0].Message.ToString(), "BİLİNMEYEN DURUM");
                    }
                }
                else
                {
                    MessageBox.Show("EsResponse dönüş değeri hatalı", "HATA");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

            return basarili;


        }

        public static bool baslangicKontrol(string str, string baslangic)
        {
            int say = baslangic.Length;
            str = str.ToString().Trim();

            if (str.StartsWith(baslangic))
            {
                return true;
            }

            return false;
        }

        public static bool checkNewVersion()
        {
            bool zorunlu = false;

            string currentVersiyon = "";
            string mustUpdate = "";

            
            
            try
            {
                WebRequest request = HttpWebRequest.Create(GlobalData.versionUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string strCurrent = reader.ReadToEnd();
                string msg = "";

                string[] arr = strCurrent.Split('|');
                if (arr.Length > 0)
                {
                    currentVersiyon = arr[0].ToString().Trim();
                    mustUpdate = arr[1].ToString().Trim();

                    string deviceVersiyon = Utility.GetCurrentApplicationVersion();
                    
                    int currentVersiyonSayisal = Convert.ToInt32(currentVersiyon.Replace(".",""));
                    int deviceVersiyonSayisal = Convert.ToInt32(deviceVersiyon.Replace(".", ""));

                    if (currentVersiyonSayisal > deviceVersiyonSayisal)
                    {
                        if (mustUpdate == "1")
                        {
                            msg = "Yazılımın kritik güncellemeler içeren yeni bir sürümü mevcut. Devam etmeden önce lütfen güncel versiyonu yükleyiniz. Güncel versiyon: " + currentVersiyon;
                            zorunlu = true;
                        }
                        else
                        {
                            msg = "Yazılımın yeni bir sürümü bulunmaktadır. Güncel versiyon: " + currentVersiyon;
                        }
                        MessageBox.Show(msg.ToString(), "BİLGİ");
                    }
                       
                }

            }
            catch
            {
                return false;
            }

            return zorunlu;
        }

        public static string pozitifUrlGetir(string operation)
        {
            string postUrl = "";

            switch (GlobalData.sunucuTip)
            {
                case "DEV Test": postUrl = GlobalData.atfDevSunucu + "/service/sap.php?operation="+operation+"&"; break;
                case "QA Test": postUrl = GlobalData.atfDevSunucu + "/service/sap.php?operation="+operation+"&"; break;
                case "PROD": postUrl = GlobalData.atfProdSunucu + "/service/sap.php?operation=" + operation + "&"; break;
            }

            return postUrl;
        }


        public static String[]  atfAl(string saleid, string sale_code, decimal total_desi, string cargoid)
        {

            string[] _ret = new string[6];
            string postUrl = "";
            string postVar = "";

            _ret[0] = "";
            _ret[1] = "";
            _ret[2] = "";
            _ret[3] = "";
            _ret[4] = "";
            _ret[5] = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cargoid.ToString().Trim() == "")
                {
                    MessageBox.Show("Kargo Id değeri boş.", "HATA");
                    return _ret;
                }

                postUrl = Utility.pozitifUrlGetir("insertSaleCargo");

                //Değişkenler dolduruluyor
                postVar = "saleid=" + saleid.ToString().Trim() + "&sale_code=" + sale_code.ToString().Trim() + "&total_deci=" + total_desi.ToString().Trim() + "&cargoid=" + Convert.ToInt64(cargoid.ToString().Trim()).ToString();
                postUrl += postVar;

                ServicePointManager.CertificatePolicy = new AcceptAllCertificatePolicy();

                WebRequest request = HttpWebRequest.Create(postUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string xmlTxt = reader.ReadToEnd();

                XDocument doc = XDocument.Parse(xmlTxt);

                if (doc.Root.Element("status").Value.ToString() == "OK")
                {
                    //Sonuc basarılı bilgiler yazılıyor
                    _ret[0] = doc.Root.Element("operation").Value.ToString();
                    _ret[1] = doc.Root.Element("status").Value.ToString();
                    _ret[2] = doc.Root.Element("message").Value.ToString();
                    _ret[3] = doc.Root.Element("cargo_cost").Value.ToString();
                    _ret[4] = doc.Root.Element("total_deci").Value.ToString();
                    _ret[5] = doc.Root.Element("tracking_number").Value.ToString();
                }
                else
                {
                    MessageBox.Show(atfHataCevir(doc.Root.Element("message").Value.ToString()), "HATA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return _ret;
        }

        public static String[] kargoOnerilenTutarGetir(string saleid, string sale_code, string products)
        {

            string[] _ret = new string[5];
            string postUrl = "";
            string postVar = "";
            try
            {
                postUrl = Utility.pozitifUrlGetir("informWebForReturnStatus");

                //Değişkenler dolduruluyor
                postVar = "saleid=" + saleid.ToString().Trim() + "&sale_code=" + sale_code.ToString().Trim() + "&products=" + products.ToString().Trim();
                postUrl += postVar;

                ServicePointManager.CertificatePolicy = new AcceptAllCertificatePolicy();
                WebRequest request = HttpWebRequest.Create(postUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string xmlTxt = reader.ReadToEnd();

                XDocument doc = XDocument.Parse(xmlTxt);

                if (doc.Root.Element("status").Value.ToString() == "OK")
                {
                    //Sonuc basarılı bilgiler yazılıyor
                    _ret[0] = doc.Root.Element("operation").Value.ToString();
                    _ret[1] = doc.Root.Element("status").Value.ToString();
                    _ret[2] = doc.Root.Element("message").Value.ToString();
                    _ret[3] = doc.Root.Element("recommended_cargo_return").Value.ToString();
                    _ret[4] = doc.Root.Element("return_total_deci").Value.ToString();
                }
                else
                {
                    _ret[0] = "";
                    _ret[1] = "";
                    _ret[2] = "";
                    _ret[3] = "";
                    _ret[4] = "";
                    MessageBox.Show(atfHataCevir(doc.Root.Element("message").Value.ToString()), "HATA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

            return _ret;
        }



        public static string atfHataCevir(string errorMsg)
        {
            string _hata = "";

            switch (errorMsg) {
                case "CHECK_SALE_ID"    : _hata = "Geçersiz sale_id girişi. Kontrol ediniz."; break;
                case "CHECK_SALE_CODE"  : _hata = "Geçersiz sale_code girişi. Kontrol ediniz."; break;
                case "CHECK_SALE_PRODUCTS_SELECTED_AT_LEAST_ONE": _hata = "Geçersiz ürün girişi. Kontrol ediniz."; break;
                case "CHECK_SALE_CARGO_ID": _hata = "Geçersiz kargo firması girişi. Kontrol ediniz."; break;
                case "SALE_CARGO_INFO_NOT_UPDATED": _hata = "Bilinmeyen hata. Kontrol ediniz."; break;

                case "CHECK_RETURN_SALE_PRODUCTS": _hata = "Geçersiz products girişi. Kontrol ediniz."; break;
                case "RETURN_SALE_STATUS_NOT_UPDATED": _hata = "Siparişin ürün durumları kayıt edilemedi."; break;
                default: _hata = errorMsg; break;
            }

            return _hata;
        }

        [DllImport("CoreDll.DLL", SetLastError = true)]
        public extern static
            int CreateProcess(String imageName,
            String cmdLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            Int32 boolInheritHandles,
            Int32 dwCreationFlags,
            IntPtr lpEnvironment,
            IntPtr lpszCurrentDir,
            byte[] si,
            ProcessInfo pi);

        [DllImport("CoreDll.dll")]
        public extern static
            Int32 WaitForSingleObject(IntPtr Handle,
            Int32 Wait);

        #region show/hide taskbar
        static int SWP_SHOWWINDOW = 0x40;
        static int SM_CXSCREEN = 0;
        static int SM_CYSCREEN = 1;
        static int HWND_TOPMOST = -1;
        static int SW_HIDE = 0;
        static int SW_SHOW = 5;

        [DllImport("CoreDll.dll")]
        private static extern int FindWindow(string lpClassName,
            string lpWindowName);
        [DllImport("CoreDll.dll")]
        private static extern int EnableWindow(int hwnd,
            bool bEnable);

        public static void HideTaskbar()
        {
            int hwnd, lret;
            hwnd = FindWindow("HHTaskBar", "");
            //lret = ShowWindow(hwnd, SW_HIDE);
            lret = EnableWindow(hwnd, false);

            /*IntPtr HWND2 = GetForegroundWindow();

            lret = SetWindowPos(HWND2, HWND_TOPMOST, 0, 0,
                GetSystemMetrics(SM_CXSCREEN) , GetSystemMetrics(SM_CYSCREEN),
                SWP_SHOWWINDOW);*/
        }

        public static void ShowTaskbar()
        {
            int hwnd;
            int lret;
            hwnd = FindWindow("HHTaskBar", "");
            //lret = ShowWindow(hwnd, SW_SHOW);
            lret = EnableWindow(hwnd, true);

            /*IntPtr HWND2 = GetForegroundWindow();

            lret = SetWindowPos(HWND2, HWND_TOPMOST, 0, 0,
                GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN)-24,
                SWP_SHOWWINDOW);*/
        }
        #endregion

    }
}
