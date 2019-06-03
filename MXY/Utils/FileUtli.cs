using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharRobot.Utils
{
    class FileUtli
    {
        public static string ReadFile(string filePath)
        {
            string rs = string.Empty;
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath, Encoding.UTF8);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取文件夹内包括子文件夹的指定类型文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extName"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static bool GetFiles(string path, string extName, ref List<FileInfo> lst)
        {
            Console.WriteLine("-------------------"+path+"----------------");
            try
            {
                if (!Directory.Exists(path))
                {
                    return false;
                }
                string[] dir = Directory.GetDirectories(path); //文件夹列表   
                DirectoryInfo fdir = new DirectoryInfo(path);
                FileInfo[] file = fdir.GetFiles();
                if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空                   
                {
                    foreach (FileInfo f in file) //显示当前目录所有文件   
                    {
                        if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                        {
                            lst.Add(f);
                        }
                    }
                    foreach (string d in dir)
                    {
                        GetFiles(d, extName, ref lst);//递归   
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
