using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpr
{
    public partial class ucFinIprInpatientCounts : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        /// <summary>
        /// 全院住院患者统计
        /// </summary>
        public ucFinIprInpatientCounts ()
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候......");
                this.dwMain.Retrieve(new object[] { });
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }
    }
}

