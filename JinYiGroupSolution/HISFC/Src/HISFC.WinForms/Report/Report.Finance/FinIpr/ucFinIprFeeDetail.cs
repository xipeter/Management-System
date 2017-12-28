using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Finance.FinIpr
{
    public partial class ucFinIprFeeDetail : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIprFeeDetail()
        {
            InitializeComponent();
        }
        //private Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
        private Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
        private Neusoft.HISFC.Models.Base.Employee emp = new Neusoft.HISFC.Models.Base.Employee();
        
        protected override int OnRetrieve(params object[] objects)
        {
            emp = (Neusoft.HISFC.Models.Base.Employee)dept.Operator;
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            

            return base.OnRetrieve(base.beginTime, base.endTime,emp.Dept.ID);
        }
    }
}
