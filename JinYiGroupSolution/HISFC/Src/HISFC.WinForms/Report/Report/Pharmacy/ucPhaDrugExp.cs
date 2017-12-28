using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Pharmacy
{
    /// <summary>
    /// ҩƷ����ͳ��(ҩ����ҩ����ҩ���������)
    /// </summary>
    public partial class ucPhaDrugExp : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaDrugExp()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.beginTime, this.endTime);
        }
    }
}