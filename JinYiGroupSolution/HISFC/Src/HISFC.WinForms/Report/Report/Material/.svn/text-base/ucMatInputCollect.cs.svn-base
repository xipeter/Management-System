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
    public partial class ucMatInputCollect : Report.Common.ucQueryBaseForDataWindow
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucMatInputCollect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 检索数据
        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.beginTime,this.endTime,this.employee.Dept.ID);
        }
    }
}

