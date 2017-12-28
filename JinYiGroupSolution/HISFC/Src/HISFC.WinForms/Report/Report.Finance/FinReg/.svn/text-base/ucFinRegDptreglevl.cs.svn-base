using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using Common = Report.Common;
//using Manager = Report.Manager;
using System.Collections;

namespace Neusoft.Report.Finance.FinReg
{
    public partial class ucFinRegDptreglevl : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinRegDptreglevl()
        {
            InitializeComponent();
        }
        protected override void OnLoad()
        {
            this.Init();

            base.OnLoad();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpBeginTime.Value = dt;
        }


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

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);

        }

        private void dwMain_Click(object sender, EventArgs e)
        {

        }
    }
}
