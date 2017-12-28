using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.FinSim
{
    /// <summary>
    /// 医保患者费用分项查询
    /// </summary>
    public partial class ucFinSimIpbFeeDetail : Common.ucQueryBaseForDataWindow
    {
        public ucFinSimIpbFeeDetail()
        {
            InitializeComponent();
        }
        //protected override void OnLoad()
        //{
        //    this.Init();
        //    base.OnLoad();
        //}

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            //dwMain.Retrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value);
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            return base.OnRetrieve(this.beginTime, this.endTime,"ALL");
        }

        /// <summary>
        /// 过滤事件,支持姓名过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string str = this.neuTextBox1.Text.Trim().Replace(@"\", "").ToUpper();
            if (str.Equals(""))
            {
                this.dwMain.SetFilter("");
                this.dwMain.Filter();
            }
            else
            {
                str = string.Format(this.queryStr, str);
                this.dwMain.SetFilter(str);
                this.dwMain.Filter();
            }
        }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        private string queryStr = "(name like '{0}%') or (name_spell_code like '{0}%')";

        /// <summary>
        /// 住院患者信息检索事件
        /// </summary>
        private void ucQueryInpatientNo1_myEvent_1()
        {
            if (this.ucQueryInpatientNo1.InpatientNo.Equals(""))
            {
                MessageBox.Show("根据输入的患者相关信息未能检索出患者！","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (this.GetQueryTime() == -1)
                {
                    return;
                }

                this.dwMain.Retrieve(this.beginTime, this.endTime, this.ucQueryInpatientNo1.InpatientNo);
            }
        }

    }
}
