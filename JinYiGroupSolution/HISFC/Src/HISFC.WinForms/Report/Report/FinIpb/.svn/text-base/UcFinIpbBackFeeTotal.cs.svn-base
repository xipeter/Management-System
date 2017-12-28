using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.FinIpb
{
    public partial class UcFinIpbBackFeeTotal : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public UcFinIpbBackFeeTotal()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            dwMain.Modify("t_date.text = '时间范围：" + this.dtpBeginTime.Value.ToString() + "－" + this.dtpEndTime.Value.ToString() + "'");
            dwMain.Modify("t_5.text='制表人：" + this.employee.Name.ToString() + "'");
            return base.OnRetrieve(base.beginTime, base.endTime);
        }
        protected override int OnPrint(object sender, object neuObject)
        {
            return base.OnPrint(sender, neuObject);
        }
    }

}
