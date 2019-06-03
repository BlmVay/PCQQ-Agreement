using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QQ.Framework;
using QQ.Framework.Domains;
using QQ.Framework.Utils;

namespace Base_Plugins
{
    class _007Robot : CustomRobot
    {
        public delegate void VoidStringReceiveFMsg(long number, Richtext msg);
        public VoidStringReceiveFMsg receiveFriendMessage { get; set; }
        public delegate void VoidStringReceiveGMsg(long Groupnumber,long formNumber, Richtext msg);
        public VoidStringReceiveGMsg receiveGroupMessage { get; set; }

        public _007Robot(ISendMessageService service, IServerMessageSubject transponder, QQUser user) : base(service, transponder, user)
        {
            Console.WriteLine(string.Format("机器人:{0}实例创建成功!",user.QQ));
        }

        public override void ReceiveFriendMessage(long friendNumber, Richtext content)
        {
            if (content != null)
            {
                receiveFriendMessage?.Invoke(friendNumber, content);
            }
        }

        public override void ReceiveGroupMessage(long groupNumber, long fromNumber, Richtext content)
        {
            if (content != null)
            {
                receiveGroupMessage?.Invoke(groupNumber,fromNumber, content);
            }
        }
    }
}
