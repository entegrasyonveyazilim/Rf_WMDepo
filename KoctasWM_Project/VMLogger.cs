using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KoctasWM_Project
{
    class VMLogger
    {
        private const String logFileName = "KoctasWM.txt";
        private String className;
        public VMLogger(String className)
        {
            this.className = className;
        }

        public void error(String log)
        {
            using (StreamWriter writetext = File.AppendText(logFileName))
            {
                writetext.WriteLine(getCurrentDateTime() + " - " + "ERROR" + " - " + className + " - " + log);
            }
        }

        public void warn(String log)
        {
            using (StreamWriter writetext = File.AppendText(logFileName))
            {
                writetext.WriteLine(getCurrentDateTime() + " - " + "WARN" + " - " + className + " - " + log);
            }
        }

        public void info(String log)
        {
            using (StreamWriter writetext = File.AppendText(logFileName))
            {
                writetext.WriteLine(getCurrentDateTime() + " - " + "INFO" + " - " + className + " - " + log);
            }
        }

        public void trace(String log)
        {
            using (StreamWriter writetext = File.AppendText(logFileName))
            {
                writetext.WriteLine(getCurrentDateTime() + " - " + "TRACE" + " - " + className + " - " + log);
            }
        }

        //private String getCurrentDate()
        //{
        //    var time = DateTime.Now;
        //    String formattedTime = time.ToString("yyyyMMdd");
        //    return formattedTime;
        //}

        private String getCurrentDateTime()
        {
            String time = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            return time;
        }
    }
}
