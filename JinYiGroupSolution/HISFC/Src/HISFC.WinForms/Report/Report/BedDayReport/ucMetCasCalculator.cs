using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Neusoft.WinForms.Report.BedDayReport
{
    public partial class ucMetCasCalculator : Component
    {
        public ucMetCasCalculator()
        {
            InitializeComponent();
          System.Diagnostics.Process.Start("calc");
        }

        public ucMetCasCalculator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
           
        }

         //System.Diagnostics.Process.Start("calc");

    }
}
