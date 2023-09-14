using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace BLL
{
    public static class Logger
    {
        public static void writeLog(string Message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];

            using(StreamWriter sw = new StreamWriter(logPath, true)) { 
            
                sw.WriteLine($"{DateTime.Now} : {Message}"); 

            }
        }
    }
}
