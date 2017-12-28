using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Logistics.Pharmacy
{
    public partial class ucPhaDrugstoresStat : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        #region 变量
        /// <summary>
        /// 获得当前操作员的实例
        /// </summary>
        Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        #endregion

        public ucPhaDrugstoresStat()
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;
            this.Init();
            base.OnLoad();
        }

        #region 方法

        protected override int OnRetrieve(params object[] objects)
        {
            if (this.dtpBeginTime.Value > this.dtpEndTime.Value)
            {
                MessageBox.Show("查询开始时间不能大于查询结束时间！");
                return -1;
            }
            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,empl.Dept.Name,empl.Dept.ID);
        }
        #endregion 
    }
}
