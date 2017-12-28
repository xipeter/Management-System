using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.FinIpb
{
    public partial class ucFinIpbBackFeeDetail : Common.ucQueryBaseForDataWindow
    {
        public ucFinIpbBackFeeDetail()
        {
            InitializeComponent();
        }

        private string queryStr = "((tf_name like '{0}%') or (tf_spell_name like '{0}%') or (tf_wb_name like '{0}%')) and ((hz_name like '{1}%') or (hz_spell_name like '{1}%') or (hz_wb_name like '{1}%')) and ((fee_name like '{2}%') or (fee_spell_name like '{2}%') or (fee_wb_name like '{2}%')) and ((oper_name like '{3}%') or (oper_spell_name like '{3}%') or (oper_wb_name like '{3}%'))";
        private void neuTextBox1_TextChanged(object sender, EventArgs e)
        {
            string tf = this.neuTextBox1.Text.Trim().ToUpper().Replace(@"\", "");
            string hz = this.neuTextBox2.Text.Trim().ToUpper().Replace(@"\", "");
            string fee = this.neuTextBox4.Text.Trim().ToUpper().Replace(@"\", "");
            string oper = this.neuTextBox3.Text.Trim().ToUpper().Replace(@"\", "");

            if (tf.Equals("") && hz.Equals("") && fee.Equals("") && oper.Equals(""))
            {
                this.dwMain.SetFilter("");
                this.dwMain.Filter();
                return;
            }

            string str = string.Format(this.queryStr, tf, hz, fee, oper);
            this.dwMain.SetFilter(str);
            this.dwMain.Filter();
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

                this.dwMain.Modify("time.text='统计时间：" + this.beginTime.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");
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
    }
}
