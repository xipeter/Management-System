using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Pharmacy
{
    /// <summary>
    /// 药品集中招标采购调查表
    /// <br>查询药库入库的药品中招标药和采购药的数量及金额</br>
    /// </summary>
    public partial class ucPhatotByynzb :Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhatotByynzb()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.beginTime, this.endTime);
        }
    }
}
