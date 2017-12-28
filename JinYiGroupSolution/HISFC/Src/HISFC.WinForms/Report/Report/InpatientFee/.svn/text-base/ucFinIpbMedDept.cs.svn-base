using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    public partial class ucFinIpbMedDept : Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbMedDept()
        {
            InitializeComponent();
            this.neuComboBoxType.SelectedIndex = 0;
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            string deptType = "";
            //科室类型为全部
            if (this.neuComboBoxType.SelectedIndex == 0)
            {
                deptType = "A";
            }
            else
            {
                //科室类型为门诊
                if (this.neuComboBoxType.SelectedIndex == 1)
                {
                    deptType = "M";
                }
                //科室类型为主院
                else
                {
                    deptType = "Z";
                }
            }

            return base.OnRetrieve(beginTime, endTime, deptType);
        }
    }
}
