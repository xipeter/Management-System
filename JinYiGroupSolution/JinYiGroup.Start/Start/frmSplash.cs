using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置进度
        /// </summary>
        public int Progress
        {
            set
            {
                this.neuProgressBar1.Value = value;
                this.neuProgressBar1.Refresh();
            }
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        public string Msg
        {
            set
            {
                this.lblMsg.Text = value;
                this.lblMsg.Refresh();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            //{57CC110D-2CF8-4704-93F3-3BFA247FB41C}
            if (System.Configuration.ConfigurationSettings.AppSettings["Theme"] == "1")         //东软蓝
            {
                this.BackgroundImage = HIS.Properties.Resources.东软蓝_登启界面;
                this.lblMsg.ForeColor = System.Drawing.Color.White;
                this.lbVersion.ForeColor = System.Drawing.Color.White;
            }
            else if (System.Configuration.ConfigurationSettings.AppSettings["Theme"] == "2")    //东软青
            {
                this.BackgroundImage = HIS.Properties.Resources.东软青_启动;
                this.lblMsg.ForeColor = System.Drawing.Color.White;
                this.lbVersion.ForeColor = System.Drawing.Color.White;
            }

            base.OnLoad( e );
        }

    }
}