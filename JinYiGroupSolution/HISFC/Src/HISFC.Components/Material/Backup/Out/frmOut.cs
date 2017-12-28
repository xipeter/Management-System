using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Components.Common.Forms;

namespace Neusoft.HISFC.Components.Material.Out
{
    public partial class frmOut : frmIMABaseForm, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public frmOut()
        {
            InitializeComponent();

            this.Text = "物资出库";
        }
        Out.ucMatOut uc = new ucMatOut();
        protected override void OnLoad(EventArgs e)
        {
            //不加此处处理 窗口无法自动最大化
            this.WindowState = FormWindowState.Maximized;

            try
            {
                

                this.AddIMABaseCompoent(uc);
            }
            catch
            {
            }

            base.OnLoad(e);
        }

        #region IPreArrange 成员

        public int PreArrange()
        {
            if (this.uc != null)
            {
                if (this.uc is Neusoft.FrameWork.WinForms.Classes.IPreArrange)
                {
                    return (this.uc as Neusoft.FrameWork.WinForms.Classes.IPreArrange).PreArrange();
                }
            }

            return 1;
        }

        #endregion
    }
}