using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucStoMzRecipeNum : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucStoMzRecipeNum()
        {
            InitializeComponent();
        }

        #region ≤È—Ø
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            Neusoft.HISFC.Models.Base.Employee employee = null;
            employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;

            return base.OnRetrieve(this.beginTime,this.endTime,employee.Dept.ID.ToString());
        }
        #endregion
    }
}