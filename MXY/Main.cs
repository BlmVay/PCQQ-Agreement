using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IPlugin;
using CharRobot.Utils;
using System.Windows;
using JiebaNet.Segmenter;

namespace CharRobot
{
    public class Main : UServer
    {
        CDictionary<string, CList<string>> wordDic;
        public readonly string[] fs = null;

        public Main()
        {
            PluginName = "固定式聊天机器人";//插件名
            PluginDescribe = "基于本地词库的小机器人";//插件描述
            List<FileInfo> fileInfos = new List<FileInfo>();
            if (!FileUtli.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"Plugins\words", ".txt",ref fileInfos))
            {
                Console.WriteLine("加载词库失败!");
            }
            else
            {
                Console.WriteLine("--------------------词库加载成功!----------------------");
                fs = new string[fileInfos.Count];
                for (int i = 0; i < fs.Length; i++)
                {
                    fs[i] = fileInfos[i].FullName;
                }
                wordDic = ParsingLexicon.GetWordDic(fs);
            }
        }


        /// <summary>
        /// 收到好友消息
        /// </summary>
        /// <param name="formNumber">好友QQ号</param>
        /// <param name="msg">消息内容</param>
        public override void ReceiveFriendMessage(long formNumber, string msg)
        {

        }

        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="groupNumber">群号</param>
        /// <param name="formNumber">发信息的人的QQ号</param>
        /// <param name="msg">消息内容</param>
        public override void ReceiveGroupMessage(long groupNumber, long formNumber, string content)
        {
            if (content != null && formNumber != 517414188)
            {
                if (content != null && content != "")
                {
                    if (wordDic.ContainsKey(content.Trim()))
                    {
                        Console.WriteLine("字典存在此关键字>" + content.ToString());
                        SendMsgToQQGroup(groupNumber, wordDic[content.ToString().Trim()].GetRandomReply());
                        return;
                    }
                    else
                    {
                        var segmenter = new JiebaSegmenter();
                        var segments = segmenter.Cut(content.ToString().Trim(), cutAll: true);
                        Console.WriteLine("分词结果：{0}", string.Join("/ ", segments));
                        int maxl = 0;
                        string tword = string.Empty;
                        foreach (var item in segments)
                        {
                            if (item.Length > maxl)
                            {
                                maxl = item.Length;
                                tword = item;
                            }
                        }
                        Console.WriteLine("权重最大的词为：" + tword);
                        IEnumerable<KeyValuePair<string, CList<string>>> v = from d in wordDic where d.Key.Contains(tword) select d;
                        string reply = string.Empty;
                        int minl = 999999;
                        int c = 0;
                        foreach (var item in v)
                        {
                            c++;
                            if (item.Key.Length < minl)
                            {
                                minl = item.Key.Length;
                                reply = item.Value.GetRandomReply();
                            }
                        }
                        Console.WriteLine(string.Format("关于{0}的词库有{1}条!\n本次随机回复内容为{2}", tword, c, reply));
                        SendMsgToQQGroup(groupNumber, reply);
                    }
                }
            }
        }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="groupNumber"></param>
        /// <param name="msg"></param>
        private void SendMsgToQQGroup(long groupNumber, string msg)
        {
            SendToGroupMessage(groupNumber, msg);
        }

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="FriendNumber"></param>
        /// <param name="msg"></param>
        private void SendMsgToFriend(long FriendNumber, string msg)
        {
            SendToFriendMessage(FriendNumber, msg);
        }
    }
}
