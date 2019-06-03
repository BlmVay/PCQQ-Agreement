using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQLoginTest.Utils
{
    public class FileUtli
    {
        public static string ReadFile(string filePath)
        {
            string rs = string.Empty;
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath,Encoding.UTF8);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
