using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Order
{
    public partial class ucFinOpbExecdeptItemDetail : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinOpbExecdeptItemDetail()
        {
            InitializeComponent();
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            if (this.GetQueryTime() == -1)
            {
                return -1;
            }

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索数据请稍候......");

                //Application.DoEvents();

                //this.dwMain.Modify("time.text='统计时间：" + this.beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                return this.dwMain.Retrieve(this.beginTime, this.endTime);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                this.dwMain.Print();
            }
            catch (Exception ex)
            {
                return 1;
            }

            return 1;
        }

        private string queryStr = "((dept_name like '{0}%') or (dept_spell_code like '{0}%') or (dept_spell_code_1 like '{0}%')) and ((item_name like '{1}%') or (item_spell_code like '{1}%') or (item_spell_code_1 like '{1}%')) and ((fee_name like '{2}%') or (fee_spell_code like '{2}%') or (fee_spell_code_1 like '{2}%'))";

        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string dept = this.neuTextBox1.Text.Trim().ToUpper().Replace(@"\", "");
            string item = this.neuTextBox2.Text.Trim().ToUpper().Replace(@"\", "");
            string fee = this.neuTextBox3.Text.Trim().ToUpper().Replace(@"\", "");

            if (dept.Equals("") && item.Equals("") && fee.Equals(""))
            {
                this.dwMain.SetFilter("");
                this.dwMain.Filter();
                return;
            }

            string str = string.Format(this.queryStr, dept, item, fee);
            this.dwMain.SetFilter(str);
            this.dwMain.Filter();
        }

    }
}
