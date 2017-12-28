using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.MET.MetTec
{
    public partial class ucMetTecWorkload : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        //bool isAllDept = false;

        //[Category("控件设置"), Description("是否仅显示本科执行的项目")]
        //public bool IsAllDept
        //{
        //    get { return isAllDept; }
        //    set { isAllDept = value; }
        //}

        Neusoft.FrameWork.Models.NeuObject dept = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept;

        public ucMetTecWorkload()
        {
            InitializeComponent();

        }

        protected override int OnRetrieve(params object[] objects)
        {
         
            if (base.GetQueryTime() == -1)
                return -1;

            this.dwMain.SetRedrawOff();
            base.OnRetrieve(base.beginTime, base.endTime, dept.ID.ToString());
            
            //if (!isAllDept)
            //{  
            //    this.dwMain.Dv.RowFilter = "dept_name ='" + dept.Name + "'";
            //}
            this.dwMain.SetRedrawOn();

             return this.dwMain.RowCount;
        }

        private void ucMetTecWorkload_Load(object sender, EventArgs e)
        {
            this.dtpBeginTime.Value = Convert.ToDateTime(this.dtpBeginTime.Value.ToShortDateString());
            this.dtpEndTime.Value = this.dtpBeginTime.Value.AddDays(1).AddSeconds(-1);
        }
    }
}
