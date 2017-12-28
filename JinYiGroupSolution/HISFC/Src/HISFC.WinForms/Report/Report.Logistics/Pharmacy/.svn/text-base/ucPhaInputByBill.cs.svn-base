using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.Logistics.Pharmacy
{
    /// <summary>
    /// 药品出库汇总表
    /// </summary>
    public partial class ucPhaInputByBill : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaInputByBill()
        {
            InitializeComponent();
        }
        //protected override void OnLoad()
        //{
        //    this.Init();
        //    base.OnLoad();
        //}
        protected override int OnRetrieve(params object[] objects)
        {
            //dwMain.Retrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value);
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);
        }

        /// <summary>
        /// 过滤事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = this.neuTextBox1.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();
            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }
            
            if (str.Equals(""))
            {
                //this.dwMain.SetFilter("");
                //this.dwMain.Filter();
                //return;

                dv.RowFilter = "";
                return;

            }
            else
            {
                str = string.Format(this.queryStr,str);
                //this.dwMain.SetFilter(str);
                //this.dwMain.Filter();
                dv.RowFilter = str;

            }
        }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        //private string queryStr = "(pha_com_company_fac_name like '{0}%') or (fac_spell like '{0}%')";
        private string queryStr = "(FAC_NAME like '{0}%') or (FAC_SPELL like '{0}%')";
    }
}
