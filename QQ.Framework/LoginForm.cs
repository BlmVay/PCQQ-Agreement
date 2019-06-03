using Base_Plugins;
using QQ.Framework.Domains;
using QQ.Framework.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ.Framework
{
    public partial class LoginForm : Form
    {

        private QQUser qQUser = null;
        _007Robot _007robot = null;
        private SynchronizationContext m_SyncContext = null;
        private SocketServiceImpl socketServer = null;
        private Transponder transponder = null;
        private SendMessageServiceImpl sendService = null;
        private MessageManage manage = null;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_But_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TXB_QQNumber.Text) || string.IsNullOrEmpty(TXB_QQPassword.Text))
            {
                MessageBox.Show("账号密码不能为空!");
                return;
            }
            qQUser = new QQUser(long.Parse(TXB_QQNumber.Text), TXB_QQPassword.Text);
            qQUser.IsUdp = true;
            try
            {
                socketServer = new SocketServiceImpl(qQUser);
                transponder = new Transponder();
                sendService = new SendMessageServiceImpl(socketServer, qQUser);
                manage = new MessageManage(socketServer, qQUser, transponder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("登陆失败!!!\r\n" + ex.Message);
            }
            manage.Init();
            _007robot = new _007Robot(sendService, transponder, qQUser);
            if (manage._user.QQPacket00BaVerifyCode != null)
            {
                Console.WriteLine("需要验证码!");
            }
            MessageBox.Show("登陆成功!!!\r\n");
        }
    }
}
