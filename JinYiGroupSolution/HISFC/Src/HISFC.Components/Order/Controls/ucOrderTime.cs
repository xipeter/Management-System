using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucOrderTime : UserControl
    {
        public ucOrderTime()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 医嘱时间
        /// </summary>
        public DateTime OrderTime
        {
            get
            {
                if (this.ckbOrdertime.Checked == true)
                    return this.dtpickerOrder.Value;
                else
                    return new DateTime(2001, 1, 1, 00, 00, 00);
            }
            set
            {
                this.dtpickerOrder.Value = new DateTime(2001, 1, 1, 00, 00, 00);
                this.toolTip1.SetToolTip(this.ckbOrdertime, "选中“医嘱时间”，按照医嘱时间查询，\n在右侧时间框选择时间，执行单，巡回\n卡，输液卡会显示医嘱时间大于选择时\n间的记录。");
            }
        }

        private void ckbOrdertime_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpickerOrder.Enabled = ((CheckBox)sender).Checked;
        }
    }
}
