using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.MET.MetOpd
{
    public partial class ucMetOpdScaleClass :NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetOpdScaleClass()
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            this.Init();
            base.OnLoad();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (this.GetQueryTime() == -1)
                return -1;
            return base.OnRetrieve(this.beginTime ,this.endTime );
        }
    }
}
