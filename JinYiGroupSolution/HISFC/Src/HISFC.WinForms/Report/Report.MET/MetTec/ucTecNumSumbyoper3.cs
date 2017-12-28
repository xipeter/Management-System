using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.Report.MET.MetTec
{
    public partial class ucTecNumSumbyoper3 :NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucTecNumSumbyoper3()
        {
            InitializeComponent();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            DateTime beginTime = this.dtpBeginTime.Value;
            DateTime endTime = this.dtpEndTime.Value;

            if (beginTime > endTime)
            {
                MessageBox.Show("结束时间不能小于开始时间");
                return -1;
            }
            string deptCode = this.employee.Dept.ID;
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,deptCode);
        }
        /// <summary>
        /// 打印方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {

                this.dwMain.Print();
                return 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错", "提示");
                return -1;
            }

        }
    }
}
