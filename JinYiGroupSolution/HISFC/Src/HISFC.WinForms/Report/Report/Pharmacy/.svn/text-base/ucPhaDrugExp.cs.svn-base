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
    /// 药品消耗统计(药房发药减退药减特殊出库)
    /// </summary>
    public partial class ucPhaDrugExp : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaDrugExp()
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
