using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Pharmacy
{
    public partial class ucPhaMonthAllMed : Common.ucQueryBaseForDataWindow
    {
        public ucPhaMonthAllMed()
        {
            InitializeComponent();
        }
        protected override void OnLoad()
        {
            this.Init();

            base.OnLoad();
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
    }
}


