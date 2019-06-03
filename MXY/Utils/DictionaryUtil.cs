using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharRobot.Utils
{

    /// <summary>
    /// 自定义字典
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="Tval"></typeparam>
    public class CDictionary<Tkey, Tval> : Dictionary<Tkey, Tval>
    {
        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Console.WriteLine("ToStringing...");
            string rs = string.Empty;
            foreach (var item in this)
            {
                string va = string.Empty;
                for (int i = 0; i < (item.Value as List<string>).Count; i++)
                {
                    va += (item.Value as List<string>)[i] + "\n";
                }
                rs += item.Key + ":\n" + va + "\n\n";
            }
            return rs;
        }
        /// <summary>
        /// 追加内容
        /// </summary>
        /// <param name="content"></param>
        public bool Superaddition(Tkey key, string content)
        {
            if (ContainsKey(key))
            {
                try
                {
                    if (!(this[key] as List<string>).Contains(content))
                    {
                        (this[key] as List<string>).Add(content);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    throw new Exception("数据类型错误!");
                }
            }
            else
            {
                Console.WriteLine("不存在该键值！" + key);
                return false;
            }
        }

    }

    public class CList<T> : List<T>
    {
        public override string ToString()
        {
            string rt = string.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                rt += this[i] + "\n";
            }
            return rt;
        }

        public string GetRandomReply()
        {
            if (this.Count == 1)
            {
                return this[0].ToString();
            }
            Random random = new Random();
            return this[random.Next(0, this.Count)].ToString();
        }
    }

    /// <summary>
    /// 自定义哈希表
    /// </summary>
    public class CHashtable : Hashtable
    {

    }

    /// <summary>
    /// 解析字典
    /// </summary>
    public class ParsingLexicon
    {
        public static CDictionary<string, CList<string>> GetWordDic(string[] filePaths)
        {
            CDictionary<string, CList<string>> wordDic = new CDictionary<string, CList<string>>();
            string words = string.Empty;
            CList<string> tempList = new CList<string>();
            string tkey = string.Empty;
            bool IsNewKey = true;
            int Count = 0, ErrorCount = 0, Total = 0, TotalError = 0;
            for (int n = 0; n < filePaths.Length; n++)
            {
                Count = 0;
                ErrorCount = 0;
                words = FileUtli.ReadFile(filePaths[n]);
                if (words != string.Empty)
                {
                    string[] ls = words.Split('\n');
                    if (ls.Length < 2)
                    {
                        throw new Exception("词库格式不对");
                    }
                    Console.WriteLine("开始从文件:" + filePaths[n] + " 添加词库。。。");
                    for (int i = 0; i < ls.Length; i++)
                    {
                        if (ls[i].Trim() == string.Empty || ls[i].Trim() == "" || ls[i] == null)//分割词条
                        {
                            if (!wordDic.ContainsKey(tkey))
                            {
                                if (tempList.Count != 0)//过滤不合法组合与空行
                                {
                                    wordDic.Add(tkey, tempList);
                                    Count++;
                                    //Console.WriteLine("添加完成第"+Count+"条词库\t" + "词库关键字为："+tkey + "对应的回复有"+tempList.Count+"条");
                                }
                                else
                                {
                                    ErrorCount++;
                                }
                            }
                            tempList = new CList<string>();//分配新的对应回复列表
                            IsNewKey = true;
                        }
                        else
                        {
                            if (IsNewKey && ls[i].Trim() != "")//获取下个关键字 过滤空行
                            {
                                tkey = ls[i].Trim();
                                IsNewKey = false;
                                continue;
                            }
                            if (wordDic.ContainsKey(tkey))
                            {
                                if (wordDic.Superaddition(tkey, content: ls[i]))
                                {
                                    //Count++;
                                }
                            }
                            else
                            {
                                tempList.Add(ls[i].TrimEnd());
                            }
                        }
                    }
                    Total += Count;
                    TotalError += ErrorCount;
                    Console.WriteLine("解析完成！添加了" + Count + " 条词库\n存在 " + ErrorCount + " 条非法字符");
                }
                else
                {
                    throw new Exception("文件为空或者文件路径不存在！");
                }
            }
            Console.WriteLine("\n\n全部文件解析完成！一个添加了" + Total + " 条词库\n一共存在 " + TotalError + " 条非法字符");
            return wordDic;
        }
    }
}
