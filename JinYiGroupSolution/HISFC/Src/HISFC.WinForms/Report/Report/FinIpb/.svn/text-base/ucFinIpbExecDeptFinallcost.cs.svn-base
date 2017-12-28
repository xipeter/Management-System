using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.FinIpb
{
    /// <summary>
    /// 执行科室收入汇总
    /// </summary>
    public partial class ucFinIpbExecDeptFinallcost : Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbExecDeptFinallcost()
        {
            InitializeComponent();
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            this.dwMain.Modify("time.text='" + this.beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            return base.OnRetrieve(this.employee.Dept.ID, this.beginTime, this.endTime, this.employee.Dept.Name);
        }
        private void neuLabelTextBox1_TextChanged(object sender, EventArgs e)
        {
            string filterStr = this.neuTextBox1.Text.Trim();
            string feeStr = this.txtfeetype.Text.Trim();
            if (filterStr.Equals("") && feeStr.Equals(""))
            {
                this.dwMain.SetFilter("");
                this.dwMain.Filter();
                return;
            }

            filterStr = filterStr.Replace(@"\","").ToUpper();
            feeStr = feeStr.Replace(@"\", "").ToUpper();
            filterStr = string.Format(this.FilterStr, filterStr,feeStr);
            this.dwMain.SetFilter(filterStr);
            this.dwMain.Filter();
            
        }
        
        /// <summary>
        /// 过滤字符串
        /// </summary>
        string FilterStr = "((item_name like '{0}%') or (item_spell_code like '{0}%') or (item_wb_code like '{0}%')) and ((fee_name like '{1}%') or (fee_spell_code like '{1}%') or (fee_wb_code like '{1}%'))";

    }
}
