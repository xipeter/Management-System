using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.WinForms.Report.MetOpd
{
    public partial class ucMetOpdNumNurse : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucMetOpdNumNurse()
        {
            InitializeComponent();
         }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string nurseType = "";
            switch( cmbNurseType.SelectedIndex)
            {
                case 0: nurseType = "WashingHandNurse";  break;
                case 1: nurseType = "ItinerantNurse";    break;
                default: MessageBox.Show(Language.Msg("请选择护士类型")); return -1; break;
            }
            return base.OnRetrieve(beginTime, endTime,nurseType);
        }
    }
}
