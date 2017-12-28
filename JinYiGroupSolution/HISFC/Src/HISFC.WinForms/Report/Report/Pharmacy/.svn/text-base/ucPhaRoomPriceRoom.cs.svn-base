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
    /// 药品调价汇总，按药房
    /// </summary>
    public partial class ucPhaRoomPriceRoom : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaRoomPriceRoom()
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
            return base.OnRetrieve(this.beginTime,this.endTime);
        }
    }
}
