using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Controls
{
    public partial class ucQueryHaveFeeInfo : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        Neusoft.HISFC.BizLogic.Fee.InPatient inpatientNOLogic = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        public ucQueryHaveFeeInfo()
        {
            InitializeComponent();
        }
        protected override void OnLoad()
        {
            this.FindForm().Text = "病区长期记账情况查询";
            DateTime currentDate = this.inpatientNOLogic.GetDateTimeFromSysDateTime();
            this.dtpBeginTime.Value = currentDate;


            this.RetrieveMain(currentDate.Date,  (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID);
            dwMain.CalculateGroups();

             base.OnLoad();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
