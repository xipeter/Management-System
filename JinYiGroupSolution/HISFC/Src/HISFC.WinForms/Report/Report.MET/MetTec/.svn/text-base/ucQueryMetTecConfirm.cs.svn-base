using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.MET.MetTec
{
    public partial class ucQueryMetTecConfirm :NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucQueryMetTecConfirm()
        {
            InitializeComponent();
        }
        protected override void OnLoad()
        {
            this.Init();

            base.OnLoad();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpBeginTime.Value = dt;
            //加载时执行查询
            //OnRetrieve(null);
        }

        /// <summary>
        /// 检索数据
        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }

            string confirmDept;
            confirmDept = base.employee.Dept.ID;
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, confirmDept);
        }
    }
}
