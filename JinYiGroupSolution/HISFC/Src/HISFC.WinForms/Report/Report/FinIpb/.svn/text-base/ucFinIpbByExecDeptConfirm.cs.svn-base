using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.WinForms.Report.FinIpb
{
    public partial class ucFinIpbByExecDeptConfirm : ucCrossReportBase
    {
        public ucFinIpbByExecDeptConfirm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 取sql的ID方法
        /// </summary>
        protected override void GetSql()
        {
            this.htSQL.Add(1, "JNHIS.LOCAL.Recalled.finIpbExecDeptQuery.Detail.1");
            this.htSQL.Add(2, "JNHIS.LOCAL.Recalled.finIpbExecDeptQuery.Detail.2");
            this.htSQL.Add(3, "JNHIS.LOCAL.Recalled.finIpbExecDeptQuery.Detail.3");
        }

        /// <summary>
        /// 增加第三条件人员类别
        /// </summary>
        protected override void InitComboBox()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager interMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alPact = interMgr.GetConstantList("PACTUNIT");
            Neusoft.HISFC.Models.Base.Const c = new Neusoft.HISFC.Models.Base.Const();
            c.ID = "ALL";
            c.Name = "全部";
            c.IsValid = true;
            c.SortID = 0;
            alPact.Insert(0, c);
            base.cmbDept.AddItems(alPact);
            base.cmbDept.SelectedIndex = 0;
        }
    }

}
