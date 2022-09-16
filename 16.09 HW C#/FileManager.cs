using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO; 
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal static class FileManager
    {
        public static void SaveAs(string Save , string Where)
        {
            using (var fs = new FileStream(Where , FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(Save);
                }
            }
        }
        public static string DownoloadAs(string Where)
        {
            using (StreamReader sr = new StreamReader(Where))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
