using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiebaNet.Segmenter;
using QQ.Framework;
using QQ.Framework.Domains;
using QQ.Framework.Sockets;
using QQLoginTest.Robots;
using QQLoginTest.Utils;

namespace QQLoginTest
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var user = new QQUser(517414188, "74264946%");
            var socketServer = new SocketServiceImpl(user);
            var transponder = new Transponder();
            var sendService = new SendMessageServiceImpl(socketServer, user);

            var manage = new MessageManage(socketServer, user, transponder);

            var robot = new TestRobot(sendService, transponder, user);
            Console.WriteLine("开始骂小羊!");
            manage.Init();
            //string[] fs = new string[]
            //{
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\reply.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\官方+网友词库.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\曦雅淑女词库v2.4强化版.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\机器人超级话包子词库（female）.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\歇后语大全整理版.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\网友词库.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\表情回复.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库 Beta 超强版.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库(火星体符号回复).txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库1.2.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库1.8.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库Beta0.1版.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库v2.4强化版.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库整合包机器人优化版.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\酷Q词库优化版.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\酷Q青云.txt",
            //    @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\骂人词库.txt"
            //};
            //ParsingLexicon parsingLexicon = new ParsingLexicon();
            //CDictionary<string, CList<string>> wordDic = parsingLexicon.GetWordDic(fs);
            //IEnumerable<KeyValuePair<string, CList<string>>> v = from d in wordDic where d.Key.Contains("你大爷") select d;
            //foreach (var item in v)
            //{
            //    Console.WriteLine(item.Key+":\n"+item.Value.ToString());
            //}
            //var segmenter = new JiebaSegmenter();
            //var segments = segmenter.Cut("我来到北京清华大学的校门口发呆了五分钟", cutAll: true);
            //Console.WriteLine("【全模式】：{0}", string.Join("/ ", segments));
            Console.ReadKey();
        }
    }
}