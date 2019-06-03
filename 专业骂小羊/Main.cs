using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPlugin;
namespace 专业骂小羊
{
    public class Main :UServer
    {

        public Main()
        {
            PluginName = "骂小羊";//插件名
            PluginDescribe = "专业骂小羊";//插件描述
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

        public override void ReceiveFriendMessage(long formNumber, string msg)
        {
            throw new NotImplementedException();
        }

        public override void ReceiveGroupMessage(long groupNumber, long formNumber, string msg)
        {
            if (groupNumber == 691038312 && formNumber == 1078926974)
            {
                Random a = new Random(DateTime.Now.Millisecond); // use System.DateTime.Now.Millisecond as seed
                int RandKey = a.Next(0,mxy.Length);
                SendMsgToQQGroup(groupNumber, mxy[RandKey] + "\n~咩~给小羊的");
                return;
            }
            if (groupNumber == 691038312 && msg.Contains("骂小羊") && !msg.Contains("不要骂小羊"))
            {
                Random a = new Random(DateTime.Now.Millisecond); // use System.DateTime.Now.Millisecond as seed
                int RandKey = a.Next(0, mxy.Length);
                SendMsgToQQGroup(groupNumber, mxy[RandKey] + "\n~咩~给小羊的");
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
