using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Pharmacy.In
{
    /// <summary>
    /// [功能描述: 药品入库主程序 实现自定义按钮功能]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    public partial class frmIn : Neusoft.HISFC.Components.Common.Forms.frmIMABaseForm, Neusoft.FrameWork.WinForms.Classes.IPreArrange
    {
        public frmIn()
        {
            InitializeComponent();

            this.Text = "药品入库";
        }

        In.ucPhaIn uc = new ucPhaIn();

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