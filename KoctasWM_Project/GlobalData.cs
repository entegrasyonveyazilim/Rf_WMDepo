using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace KoctasWM_Project
{
    class GlobalData
    {
        public static System.Net.NetworkCredential globalCr;
        public static string kullaniciAdi;
        public static string sunucuIp;
        public static string sunucuTip = "PROD";

        public static string modUser = "mod";
        public static string modPass = "9123";

        public static string atfDevSunucu = "http://admin.koctas.pstv.co";
        public static string atfProdSunucu = "https://headman.koctas.com.tr";

        public static string hesapNo = "8181203001";

        public static string versionUrl = "http://www.koctas.net/dwn/files/wm/current.txt";

        public static WS_Islem.ZktWmReturn[] rMsg;
    }
}
