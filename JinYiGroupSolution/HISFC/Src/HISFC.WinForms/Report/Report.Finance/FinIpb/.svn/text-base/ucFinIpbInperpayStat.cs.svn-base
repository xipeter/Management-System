using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbInperpayStat : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        
        public ucFinIpbInperpayStat()
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

