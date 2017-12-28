using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy.Report
{
    /// <summary>
    /// [功能描述: 药品盘点日志查询控件]
    /// [创 建 者: 孙久海]
    /// [创建时间: 2008-12-21]   
    /// </summary>
    public partial class ucQueryCheckLogs : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public ucQueryCheckLogs()
        {
            InitializeComponent();
        }

        #endregion

        #region 变量

        /// <summary>
        /// 药品本地业务类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.CheckLog checkLogManager = new Neusoft.HISFC.BizLogic.Pharmacy.CheckLog();

        /// <summary>
        /// 当前科室代码
        /// </summary>
        private string deptCode = string.Empty;

        #endregion

        #region 方法

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            Neusoft.HISFC.Models.Base.Employee empl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            this.neuLabel4.Text = "当前科室:" + empl.Dept.Name;
            this.deptCode = empl.Dept.ID;
            this.dtpStartDate.Value = DateTime.Today.Date;
            this.dtpEndDate.Value = DateTime.Today.Date;
        }

        /// <summary>
        ///  查询盘点日志方法
        /// </summary>
        private void QueryLogs()
        {
            if (this.dtpStartDate.Value > this.dtpEndDate.Value)
            {
                MessageBox.Show( "查询起始时间不能大于截止时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }

            ArrayList checkLogs = new ArrayList();

            this.fpCheckLogs.RowCount = 0;
            if (txtCheckNo.Text != "")
            {
                checkLogs = checkLogManager.QueryCheckLogs(deptCode, txtCheckNo.Text, dtpStartDate.Value.Date.ToString(), dtpEndDate.Value.Date.AddDays(1).ToString());
            }
            else
            {
                checkLogs = checkLogManager.QueryCheckLogs(deptCode, "ALL", dtpStartDate.Value.Date.ToString(), dtpEndDate.Value.Date.AddDays(1).ToString());
            }

            if (checkLogs != null)
            {
                this.FillToFp(checkLogs);
            }
            else
            {
                MessageBox.Show("没有符合该条件的查询结果！", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 将查询结果添加到列表显示
        /// </summary>
        /// <param name="checkLogs">盘点日志集合</param>
        private void FillToFp(ArrayList checkLogs)
        {
            Hashtable hsTemp = new Hashtable();
            for (int i = 0; i < checkLogs.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.Check checkObj = new Neusoft.HISFC.Models.Pharmacy.Check();
                checkObj = checkLogs[i] as Neusoft.HISFC.Models.Pharmacy.Check;

                this.fpCheckLogs.RowCount = i + 1;
                this.fpCheckLogs.Cells[i, 0].Text = checkObj.CheckNO;
                this.fpCheckLogs.Cells[i, 1].Text = checkObj.FOper.Dept.ID;//已经转换成名称
                this.fpCheckLogs.Cells[i, 2].Text = checkObj.Item.Name;
                this.fpCheckLogs.Cells[i, 3].Text = checkObj.BatchNO;
                this.fpCheckLogs.Cells[i, 4].Text = checkObj.Item.Specs;
                this.fpCheckLogs.Cells[i, 5].Text = checkObj.Item.PriceCollection.RetailPrice.ToString();
                this.fpCheckLogs.Cells[i, 6].Text = checkObj.Item.PackUnit;
                this.fpCheckLogs.Cells[i, 7].Text = checkObj.Item.PackQty.ToString();
                this.fpCheckLogs.Cells[i, 8].Text = checkObj.AdjustQty.ToString();
                this.fpCheckLogs.Cells[i, 9].Text = checkObj.Item.MinUnit;
                this.fpCheckLogs.Cells[i, 10].Text = checkObj.PlaceNO;
                this.fpCheckLogs.Cells[i, 11].Text = checkObj.Operation.Oper.OperTime.ToString();
                this.fpCheckLogs.Cells[i, 12].Text = checkObj.Operation.Oper.Name;

                if (!hsTemp.ContainsKey(checkObj.Operation.Oper.ID))
                {
                    hsTemp.Add(checkObj.Operation.Oper.ID, checkObj.Operation.Oper.Name);
                }
            }

            this.lbOperCount.Text = "操作员数:" + hsTemp.Count.ToString();
            this.lbRecordCount.Text = "盘点记录数:" + this.fpCheckLogs.RowCount.ToString();
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show( "导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }

            return base.Export( sender, neuObject );
        }

        #endregion

        #region 事件

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryLogs();

            return base.OnQuery(sender, neuObject);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.InitControls();
        }

        #endregion
    }
}
