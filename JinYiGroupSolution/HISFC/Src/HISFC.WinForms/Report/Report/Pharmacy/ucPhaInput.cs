using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Pharmacy
{
    public partial class ucPhaInput : Report.Common.ucQueryBaseForDataWindow
    {
        public ucPhaInput()
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

            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value);
        }
    }
}

