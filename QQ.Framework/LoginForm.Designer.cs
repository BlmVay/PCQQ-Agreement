namespace QQ.Framework
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXB_QQPassword = new System.Windows.Forms.TextBox();
            this.TXB_QQNumber = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TXB_QQPassword);
            this.groupBox1.Controls.Add(this.TXB_QQNumber);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 240);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登陆";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(220, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 40);
            this.button3.TabIndex = 8;
            this.button3.Text = "登陆";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Login_But_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(72, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(72, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码";
            // 
            // TXB_QQPassword
            // 
            this.TXB_QQPassword.Font = new System.Drawing.Font("宋体", 21.75F);
            this.TXB_QQPassword.Location = new System.Drawing.Point(169, 100);
            this.TXB_QQPassword.Multiline = true;
            this.TXB_QQPassword.Name = "TXB_QQPassword";
            this.TXB_QQPassword.PasswordChar = '*';
            this.TXB_QQPassword.Size = new System.Drawing.Size(242, 44);
            this.TXB_QQPassword.TabIndex = 4;
            this.TXB_QQPassword.Text = "2242365588";
            // 
            // TXB_QQNumber
            // 
            this.TXB_QQNumber.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TXB_QQNumber.Location = new System.Drawing.Point(169, 32);
            this.TXB_QQNumber.Multiline = true;
            this.TXB_QQNumber.Name = "TXB_QQNumber";
            this.TXB_QQNumber.Size = new System.Drawing.Size(242, 44);
            this.TXB_QQNumber.TabIndex = 3;
            this.TXB_QQNumber.Text = "2242365588";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 243);
            this.Controls.Add(this.groupBox1);
            this.IsMdiContainer = true;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加QQ机器人";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXB_QQPassword;
        private System.Windows.Forms.TextBox TXB_QQNumber;
    }
}