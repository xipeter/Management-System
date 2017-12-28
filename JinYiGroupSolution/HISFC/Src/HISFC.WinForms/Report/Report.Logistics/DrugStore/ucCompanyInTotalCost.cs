using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    public partial class ucCompanyInTotalCost : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucCompanyInTotalCost()
        {
            InitializeComponent();

        }


        
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1 )
            {
                return -1;
            }
            return base.OnRetrieve(base.beginTime,base.endTime);
        }
       
    }
}

