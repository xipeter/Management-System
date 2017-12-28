using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.FinIpb
{
    public partial class ucFinIpbInperpayStat : Common.ucQueryBaseForDataWindow
    {
        
        public ucFinIpbInperpayStat()
        {
            InitializeComponent();
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            return this.dwMain.Retrieve(this.beginTime,this.endTime);
        }
        

        protected override int OnPrint(object sender, object neuObject)
        {
            try

            {
                this.dwMain.Print();
            }

            catch (Exception d)
            { }
            return 1;
        }
    }
}

