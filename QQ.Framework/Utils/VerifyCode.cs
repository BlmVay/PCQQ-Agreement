using QQ.Framework;
using QQ.Framework.Domains;
using QQ.Framework.Packets.Send.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base_Plugins
{
    public partial class VerifyCode : Form
    {

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private SocketServiceImpl socketServiceImpl = null;
        private QQUser qQUser = null;
        public VerifyCode(SocketServiceImpl socketServiceImpl,QQUser qQUser)
        {
            this.socketServiceImpl = socketServiceImpl;
            this.qQUser = qQUser;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            socketServiceImpl.Send(new Send_0X00Ba(qQUser, textBox1.Text));
            Console.WriteLine("验证码发送成功!"+ textBox1.Text);
            Close();
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(52, 40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 58);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VerifyCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 137);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.IsMdiContainer = true;
            this.Name = "VerifyCode";
            this.Text = "VerifyCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
