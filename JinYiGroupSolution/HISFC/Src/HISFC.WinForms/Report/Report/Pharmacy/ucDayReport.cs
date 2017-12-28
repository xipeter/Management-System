using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.Pharmacy
{
    /// <summary>
    /// [功能描述: 日结查询]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    public partial class ucDayReport : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucDayReport()
        {
            InitializeComponent();
        }



        #region 属性

        /// <summary>
        /// 查询起始时间
        /// </summary>
        public DateTime BeginTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtpBeginTime.Text);
            }
        }

        /// <summary>
        /// 查询终止时间
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtpEndTime.Text);
            }
        }

        #endregion

        #region 工具栏

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList alDept = deptManager.GetDeptmentAll();

            ArrayList alStockDept = new ArrayList();
            foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
            {
                if (dept.DeptType.ID.ToString() == "P" || dept.DeptType.ID.ToString() == "PI")
                {
                    alStockDept.Add(dept);
                }
            }

            this.cmbStockDept.AddItems(alStockDept);

            this.dtpBeginTime.Value = deptManager.GetDateTimeFromSysDateTime().AddDays(-1);
            this.dtpEndTime.Value = deptManager.GetDateTimeFromSysDateTime();
            return 1;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        protected int Query()
        {
            if (this.cmbStockDept.Tag == null || this.cmbStockDept.Tag.ToString() == "")
            {
                MessageBox.Show(Language.Msg("请选择查询药房"));
                return -1;
            }

            System.Data.DataSet ds = new DataSet();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();
            if (dataManager.ExecQuery("Pharmacy.DayStore.DayReport", ref ds, this.cmbStockDept.Tag.ToString(), this.BeginTime.ToString(), this.EndTime.ToString()) == -1)
            {
                MessageBox.Show(Language.Msg("查询发生错误") + dataManager.Err);
                return -1;
            }

            if (ds == null || ds.Tables.Count <= 0)
            {
                return 0;
            }

            this.fpHead.DataSource = ds;

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();

            base.OnLoad(e);
        }
    }
}
