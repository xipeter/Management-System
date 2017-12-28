using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.WinForms.Report.DrugStore
{
    public partial class ucSalesState : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucSalesState()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 常数管理类－取常数列表

        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(base.beginTime, base.endTime, base.employee.Dept.ID);
        }
        
    }
}  

