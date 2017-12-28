using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.FinIpb
{
    public partial class ucFinIpbBackDrug : Common.ucQueryBaseForDataWindow
    {
        /// <summary>
        /// 科室退药统计查询
        /// </summary>
        public ucFinIpbBackDrug()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(base.beginTime, base.endTime);
        }

    }
}
