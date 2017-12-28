using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class frmWaitingAnswer : Form
    {
        public frmWaitingAnswer()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmWaitingAnswer_Load);
            this.timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void frmWaitingAnswer_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.button1.Click += new EventHandler(button1_Click);
            this.button2.Click += new EventHandler(button2_Click);
        }

        /// <summary>
        /// 3妙后自动关闭窗口
        /// </summary>
        private int Time = 3;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Time == 0)
            {
                this.timer1.Enabled = false;
                this.DialogResult = DialogResult.No;
                this.Close();
                return;
            }

            this.lbTip.Text = "剩余时间：" + Time.ToString() + "秒";
            Time--;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}