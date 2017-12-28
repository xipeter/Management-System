using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace Neusoft.WinForms.Report.FinSim
{
    /// <summary>
    /// 门诊医保特殊门诊患者费用查询
    /// </summary>
    public partial class ucFinSimIprClinciTbhz : Common.ucQueryBaseForDataWindow
    {
        public ucFinSimIprClinciTbhz()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            //dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, this.txtFilter.Text.ToString());
            return base.OnRetrieve(this.beginTime, this.endTime,this.txtFilter.Text.Trim());
        }

        /// <summary>
        /// 过滤框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            //姓名、诊断过滤码
            string name = this.neuTextBox1.Text.Trim().Replace(@"\", "").ToUpper();
            string diag = this.neuTextBox2.Text.Trim().Replace(@"\", "").ToUpper();
            string doc = this.neuTextBox3.Text.Trim().Replace(@"\", "").ToUpper();

            //为空清除过滤
            if (name.Equals("") && diag.Equals("") && doc.Equals(""))
            {
                this.dwMain.SetFilter("");
                this.dwMain.Filter();
                return;
            }
            else
            {
                //过滤
                string str = string.Format(this.filterString, name, diag,doc);
                this.dwMain.SetFilter(str);
                this.dwMain.Filter();
            }
        }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        private string filterString = "((姓名 like '{0}%') or (name_spell like '{0}%')) and ((诊断名称 like '{1}%') or (diag_spell like '{1}%')) and ((医师 like '{2}%') or (doc_spell like '{2}%'))";

    }
}
