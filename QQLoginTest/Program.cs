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
            Console.WriteLine("��ʼ��С��!");
            manage.Init();
            //string[] fs = new string[]
            //{
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\reply.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ٷ�+���Ѵʿ�.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\������Ů�ʿ�v2.4ǿ����.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�����˳��������Ӵʿ⣨female��.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\Ъ�����ȫ�����.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\���Ѵʿ�.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\����ظ�.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ʿ� Beta ��ǿ��.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ʿ�(��������Żظ�).txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ʿ�1.2.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ʿ�1.8.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ʿ�Beta0.1��.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ʿ�v2.4ǿ����.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\�ʿ����ϰ��������Ż���.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\��Q�ʿ��Ż���.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\��Q����.txt",
            //    @"D:\ChromeCoreDownloads\�ʿ��ȫ\��q�ʿ��ȫ\���˴ʿ�.txt"
            //};
            //ParsingLexicon parsingLexicon = new ParsingLexicon();
            //CDictionary<string, CList<string>> wordDic = parsingLexicon.GetWordDic(fs);
            //IEnumerable<KeyValuePair<string, CList<string>>> v = from d in wordDic where d.Key.Contains("���ү") select d;
            //foreach (var item in v)
            //{
            //    Console.WriteLine(item.Key+":\n"+item.Value.ToString());
            //}
            //var segmenter = new JiebaSegmenter();
            //var segments = segmenter.Cut("�����������廪��ѧ��У�ſڷ����������", cutAll: true);
            //Console.WriteLine("��ȫģʽ����{0}", string.Join("/ ", segments));
            Console.ReadKey();
        }
    }
}