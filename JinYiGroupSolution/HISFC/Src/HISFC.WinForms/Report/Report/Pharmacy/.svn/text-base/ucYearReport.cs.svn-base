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
    public partial class ucYearReport : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucYearReport()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 汇总Sql
        /// </summary>
        private string sqlTotal = "";

        /// <summary>
        /// 明细Sql
        /// </summary>
        private string sqlDetail = "";

        #endregion

        #region 属性

        /// <summary>
        /// 当前操作人员科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject OperDept
        {
            get
            {
                if (this.cmbDept.Tag == null || this.cmbDept.Text == "")
                {
                    MessageBox.Show("请选择查询库房");
                    return new Neusoft.FrameWork.Models.NeuObject();
                }
                Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();
                dept.ID = this.cmbDept.Tag.ToString();
                dept.Name = this.cmbDept.Text;

                return dept;
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        private DateTime BeginTime
        {
            get
            {
                return new DateTime(this.dtYear.Value.Year, 1, 1);
            }
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        private DateTime EndTime
        {
            get
            {
                return new DateTime(this.dtYear.Value.Year, 12, 30);
            }
        }

        #endregion

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryTotal();

            return base.OnQuery(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
            return base.Export(sender, neuObject);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int Init()
        {
            #region Sql初始化

            this.sqlTotal = @"select t.from_date 起始时间,t.to_date 终止时间, sum(t.last_month_cost) as 上期结存, 
            sum(t.in_cost) as 上期入库, 
            sum(t.out_cost) as 上期出库, 
            sum(t.special_in_cost) as 特殊入库, 
            sum(t.special_out_cost) as 特殊出库, 
            sum(t.check_profit_cost + t.check_loss_cost) as 盘点盈亏, 
            sum(t.adjust_profit_cost + t.adjust_loss_cost) as 调价盈亏, 
            sum(t.current_store_cost) as 本期结存 
from   pha_com_ms_dept t
where  t.drug_dept_code = '{0}'
and    t.from_date > to_date('{1}','yyyy-mm-dd hh24:mi:ss')
and    t.to_date < to_date('{2}','yyyy-mm-dd hh24:mi:ss')
group by t.from_date,t.to_date";

            this.sqlDetail = @" select  t.trade_name 商品名称,t.specs 规格,
            t.last_month_cost as 上期结存, 
            t.in_cost as 上期入库, 
            t.out_cost as 上期出库, 
            t.special_in_cost as 特殊入库, 
            t.special_out_cost as 特殊出库, 
            t.check_profit_cost + t.check_loss_cost as 盘点盈亏, 
            t.adjust_profit_cost + t.adjust_loss_cost as 调价盈亏, 
            t.current_store_cost as 本期结存 
    from    pha_com_ms_drug t 
    where   t.parent_code =  fun_get_parentcode  
    and     t.current_code =  fun_get_currentcode  
    and     t.drug_dept_code = '{0}' 
    and     t.from_date >= to_date('{1}','yyyy-mm-dd HH24:mi:ss') 
    and     t.to_date <= to_date('{2}','yyyy-mm-dd HH24:mi:ss') ";

            #endregion

            #region 获取科室

            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList al = deptManager.GetDeptmentAll();

            ArrayList alDept = new ArrayList();
            foreach (Neusoft.HISFC.Models.Base.Department info in al)
            {
                if (info.DeptType.ID.ToString() == "P" || info.DeptType.ID.ToString() == "PI")
                    alDept.Add(info);
            }

            this.cmbDept.AddItems(alDept);

            this.cmbDept.SelectedIndex = 0;

            #endregion

            this.fpHead.DefaultStyle.Locked = true;

            return 1;
        }

        /// <summary>
        /// 清空
        /// </summary>
        protected void Clear()
        {
            this.fpHead.Rows.Count = 0;

            this.fpDetail.Rows.Count = 0;
        }

        /// <summary>
        /// 汇总查询
        /// </summary>
        /// <returns></returns>
        protected int QueryTotal()
        {
            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            if (this.OperDept.ID == "")
                return -1;

            this.Clear();

            DataSet ds = new DataSet();

            this.lbDept.Text = "库存科室:" + this.OperDept.Name;
            this.lbDate.Text = "统计周期:" + this.BeginTime.ToString() + "至" + this.EndTime.ToString();

            string exeTotal = string.Format(this.sqlTotal, this.OperDept.ID,this.BeginTime.ToString(),this.EndTime.ToString());

            if (dataManager.ExecQuery(exeTotal, ref ds) == -1)
            {
                MessageBox.Show(Language.Msg("获取年结汇总记录发生错误"));
                return -1;
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                this.fpHead.DataSource = ds;

                this.Sum();
            }

            return 1;
        }

        /// <summary>
        /// 明细查询
        /// </summary>
        /// <param name="iRowIndex">索引行</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int QueryDetail(int iRowIndex)
        {
            if (this.neuSpread1.ActiveSheet == this.fpDetail)
            {
                return -1;
            }
            if (iRowIndex == this.fpHead.Rows.Count - 1)
            {
                return -1;
            }

            if (this.OperDept.ID == "")
                return -1;

            if (this.fpHead.Rows.Count <= 0)
                return -1;

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            DateTime dtBegin = NConvert.ToDateTime(this.fpHead.Cells[iRowIndex, 0].Text);
            DateTime dtEnd = NConvert.ToDateTime(this.fpHead.Cells[iRowIndex, 1].Text);

            string exeDetail = string.Format(this.sqlDetail, this.OperDept.ID, dtBegin.ToString(), dtEnd.ToString());

            DataSet ds = new DataSet();

            if (dataManager.ExecQuery(exeDetail, ref ds) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结明细发生错误"));
                return -1;
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                this.fpDetail.DataSource = ds;

                this.neuSpread1.ActiveSheet = this.fpDetail;
            }

            return 1;
        }

        /// <summary>
        /// 合计计算
        /// </summary>
        protected void Sum()
        {
            if (this.fpHead.Rows.Count <= 0)
            {
                return;
            }

            int rowCount = this.fpHead.Rows.Count;
            this.fpHead.Rows.Add(rowCount, 1);

            for (int i = 2; i < this.fpHead.Columns.Count; i++)
            {
                this.fpHead.Cells[rowCount, i].Formula = string.Format("SUM({0}1:{0}{1})",((char)(65 + i)).ToString(),rowCount.ToString());
            }

            this.fpHead.Rows[rowCount].Font = new Font("宋体", 9F, FontStyle.Bold);
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();

            base.OnLoad(e);
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.RowHeader || e.ColumnHeader)
            {
                return;
            }

            this.QueryDetail(e.Row); 
        }
    }
}
