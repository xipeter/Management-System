using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.MET.MetTec
{
    public partial class ucMetTecSuperCheckUp : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetTecSuperCheckUp()
        {
            InitializeComponent();
        }

        private string feecode=string.Empty;
        private string dept=string.Empty;
        private string title=string.Empty;

        [Description("统计的为某一最小费用的所有费用"),Category("设置"),DefaultValue("001")]
        public string Feecode
        {
            get
            {
                return this.feecode;
            }
            set
            {
                this.feecode=value;
            }
        }

        [Description("设置统计类型，’MZ‘ 统计的为门诊费用，’ZY‘为住院，’ALL‘为住院和门诊的合计"),Category("设置"),DefaultValue("ALL")]
        public string Dept
        {
            get
            {
                return this.dept;
            }
            set
            {
                this.dept=value;
            }

        }
        [Description("设置报表显示名称"),Category("设置"),DefaultValue("多层螺旋CT")]
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title=value;
            }
        }

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,this.feecode,this.dept,this.title);

        }


        }
    
}
