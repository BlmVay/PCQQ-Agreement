using System;
using System.Collections.Generic;
using System.Linq;
using JiebaNet.Segmenter;
using QQ.Framework;
using QQ.Framework.Domains;
using QQ.Framework.Utils;
using QQLoginTest.Utils;

namespace QQLoginTest.Robots
{
    public class TestRobot : CustomRobot
    {
        CDictionary<string, CList<string>> wordDic;
        public readonly string[] fs = new string[]
{
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\reply.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\官方+网友词库.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\曦雅淑女词库v2.4强化版.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\机器人超级话包子词库（female）.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\歇后语大全整理版.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\网友词库.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\表情回复.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库 Beta 超强版.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库(火星体符号回复).txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库1.2.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库1.8.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库Beta0.1版.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库v2.4强化版.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\词库整合包机器人优化版.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\酷Q词库优化版.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\酷Q青云.txt",
                @"D:\ChromeCoreDownloads\词库大全\酷q词库大全\骂人词库.txt"
};
        public TestRobot(ISendMessageService service, IServerMessageSubject transponder, QQUser user) : base(service, transponder, user)
        {
            Console.WriteLine(user.TXProtocol.DwClientVer);
            ParsingLexicon parsingLexicon = new ParsingLexicon();
            wordDic = parsingLexicon.GetWordDic(fs);
        }

        public override void ReceiveFriendMessage(long friendNumber, Richtext content)
        {
            Console.WriteLine($"机器人收到来自{friendNumber}的消息{content}");
            if (content.ToString().StartsWith("~"))
            {
                _service.SendToFriend(friendNumber, content);
            }
        }

        public string[] mxy = new string[]{
            "你就像根苦瓜，穿得这么清凉，长得这么败火。",
            "你别和我说话，因为我听不懂，在别人的眼中看来，我和一条猪在吵架是一件很愚蠢的事。",
            "对你，我实在想不出有什么语言和不同人类的你沟通！",
            "当你拿起镜子，看着自己...你以为是多余的，其实吧……你还真是多余的。",
            "蚊子应该很难订到你吧蚊子奋斗了一晚上都没劲了。",
            "如果你能主动让科学家研究，这样对世界了解外星生物的事业作出了很大的贡献！",
            "我就不明白绳子太长就会打结，而你的舌头却不能？",
            "你没有猪的形象，但是你有猪的气质。",
            "我想问问你,这是哪个坟圈子爆炸把你崩出来了?",
            "既然你想演给我看,那就给你足够的时间表演。",
            "遛累了,他坐这,狗坐这,一边高,谁过来都纳闷:这是谁家双胞胎啊?",
            "我感觉你像两头猪,因为一头猪已经不能形容你的蠢。",
            "别做点错事就把什么脏水都往自己身上泼,我还要留着冲厕所呢。",
            "白痴可以当你的老师,智障都可以教你说人话。",
            "如果多吃鱼可以补脑让人变聪明的话,那么你至少得吃一对儿鲸鱼。"
        };

        public override void ReceiveGroupMessage(long groupNumber, long fromNumber, Richtext content)
        {
            if (content.ToString().StartsWith("~"))
            {
                _service.SendToGroup(691038312, "基础词库加载完成！\n本地词库一共有 " + wordDic.Count + "条");
            }


            if (content != null && fromNumber != _user.QQ)
            {
                if (content.ToString() != null && content.ToString() != "")
                {
                    if (wordDic.ContainsKey(content.ToString().Trim()))
                    {
                        Console.WriteLine("字典存在此关键字>" + content.ToString());
                        _service.SendToGroup(groupNumber, wordDic[content.ToString().Trim()].GetRandomReply());
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
                        Console.WriteLine("权重最大的词为："+tword);
                        IEnumerable<KeyValuePair<string, CList<string>>> v = from d in wordDic where d.Key.Contains(tword) select d;
                        string reply = string.Empty;
                        int minl = 999;
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
                        Console.WriteLine(string.Format("关于{0}的词库有{1}条!\n本次随机回复内容为{2}",tword, c,reply));
                        _service.SendToGroup(groupNumber, reply);
                    }
                }
            }

            //if (groupNumber == 691038312 && fromNumber == 1078926974)
            //{
            //    Random a = new Random(DateTime.Now.Millisecond); // use System.DateTime.Now.Millisecond as seed
            //    int RandKey = a.Next(0,mxy.Length);
            //    _service.SendToGroup(groupNumber, mxy[RandKey] + "\n~咩~给小羊的");
            //    return;
            //}
            if (groupNumber == 691038312 && content.ToString().Contains("骂小羊") && !content.ToString().Contains("不要骂小羊"))
            {
                Random a = new Random(DateTime.Now.Millisecond); // use System.DateTime.Now.Millisecond as seed
                int RandKey = a.Next(0, mxy.Length);
                _service.SendToGroup(groupNumber, mxy[RandKey] + "\n~咩~给小羊的");
            }
        }
    }
}
