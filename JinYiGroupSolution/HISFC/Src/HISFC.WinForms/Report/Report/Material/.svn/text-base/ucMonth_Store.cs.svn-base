using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Material
{
    public partial class ucMonth_Store : Report.Common.ucQueryBaseForDataWindow
    {
        public ucMonth_Store()
        {
            InitializeComponent();
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
            return base.OnRetrieve(this.employee.Dept.ID,this.endTime);
        }
    }
}

