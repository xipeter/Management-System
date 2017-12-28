using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.MetOpd
{
    public partial class ucMetOpdOper : Common .ucQueryBaseForDataWindow 
    {
        public ucMetOpdOper()
        {
            InitializeComponent();
        }
        Neusoft.HISFC.BizLogic.Manager.Department manager = new Neusoft.HISFC.BizLogic.Manager.Department();
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string strPatientNO = string.Empty;

            if (string.IsNullOrEmpty(this.tbPatientNO.Text))
            {
                strPatientNO = "ALL";
            }
            else
            {
                this.tbPatientNO.Text = this.tbPatientNO.Text.PadLeft(10, '0');

                strPatientNO = this.tbPatientNO.Text;
            }

            return base.OnRetrieve(beginTime, endTime, strPatientNO);
        }

        private void ucMetOpdOper_Load(object sender, EventArgs e)
        {
            DateTime nowTime = manager.GetDateTimeFromSysDateTime();

            this.dtpBeginTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 00, 00, 00);
            this.dtpEndTime.Value = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 23, 59, 59);
        }

        private void tbPatientNO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(string.IsNullOrEmpty(this.tbPatientNO.Text))
                {
                    return ;
                }
                this.tbPatientNO.Text = this.tbPatientNO.Text.PadLeft(10,'0');
                this.dwMain.Retrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,this.tbPatientNO.Text);
            }
        }
    }
}
