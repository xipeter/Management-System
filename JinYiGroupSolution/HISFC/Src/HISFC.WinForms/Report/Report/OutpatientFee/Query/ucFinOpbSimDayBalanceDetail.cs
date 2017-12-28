using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.OutpatientFee.DayBalance
{
    public partial class ucFinOpbSimDayBalanceDetail : Neusoft.Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinOpbSimDayBalanceDetail()
        {
            InitializeComponent();
        }
        //protected override void OnLoad()
        //{
        //    this.Init();
        //    base.OnLoad();
        //    DateTime now = DateTime.Now;
        //    DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
        //    this.dtpBeginTime.Value = dt;
        //}


        /// <summary>
        /// ¼ìË÷Êý¾Ý
        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            string opcode = this.employee.ID;
            dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, opcode);
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, opcode);

        }
    }
}
