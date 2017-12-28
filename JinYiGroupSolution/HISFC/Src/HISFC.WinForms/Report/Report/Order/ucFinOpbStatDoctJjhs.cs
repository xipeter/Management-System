using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Order
{
    public partial class ucFinOpbStatDoctJjhs : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinOpbStatDoctJjhs()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 住院收费业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();


        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
        }
    }
}
