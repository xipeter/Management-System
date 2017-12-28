using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.Report.Logistics.DrugStore
{
    /// <summary>
    /// 药品月结 屏蔽 盘点相关的盈亏数据
    /// </summary>
    public partial class ucMonthReport : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMonthReport()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取月结间隔Sql
        /// </summary>
        private string sqlInterval = "";

        /// <summary>
        /// 获取月结汇总Sql
        /// </summary>
        private string sqlTotal = "";

        /// <summary>
        /// 获取月结明细Sql
        /// </summary>
        private string sqlDetail = "";

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
        /// 初始化
        /// </summary>
        private void Init()
        {
            #region 执行Sql

            this.sqlInterval = @"select t.from_date,t.to_date
from   pha_com_ms_dept t
where  t.drug_dept_code = '{0}'   
order by t.oper_date desc  ";

            this.sqlTotal = @" select  decode(t.drug_type,'P','西药','Z','中成药','C','中草药') as 科目, 
            sum(t.last_month_cost) as 上期结存, 
            sum(t.in_cost + t.special_in_cost) as 上期入库, 
            sum(t.out_cost + t.special_out_cost) as 上期出库, 
            --sum(t.special_in_cost) as 特殊入库, 
            --sum(t.special_out_cost) as 特殊出库, 
            --sum(t.check_profit_cost + t.check_loss_cost) as 盘点盈亏, 
            sum(t.adjust_profit_cost + t.adjust_loss_cost) as 调价盈亏, 
            sum(t.current_store_cost) as 本期结存 
    from    pha_com_ms_drug t 
    where   t.drug_dept_code = '{0}' 
    and     t.from_date >= to_date('{1}','yyyy-mm-dd HH24:mi:ss') 
    and     t.to_date <= to_date('{2}','yyyy-mm-dd HH24:mi:ss') 
    group by decode(t.drug_type,'P','西药','Z','中成药','C','中草药') ";

            this.sqlDetail = @" select  t.trade_name 商品名称,t.specs 规格,
            t.last_month_cost as 上期结存, 
            t.in_cost + t.special_in_cost as 上期入库, 
            t.out_cost + t.special_out_cost as 上期出库, 
            --t.special_in_cost as 特殊入库, 
            --t.special_out_cost as 特殊出库, 
            --t.check_profit_cost + t.check_loss_cost as 盘点盈亏, 
            t.adjust_profit_cost + t.adjust_loss_cost as 调价盈亏, 
            t.current_store_cost as 本期结存 
    from    pha_com_ms_drug t 
    where   t.drug_dept_code = '{0}' 
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

            this.QueryStoreInterval();
        }

        /// <summary>
        /// 获取月结记录
        /// </summary>
        private void QueryStoreInterval()
        {
            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            if (this.OperDept.ID == "")
                return;

            DataSet ds = new DataSet();

            string exeInterval = string.Format(this.sqlInterval, this.OperDept.ID);

            if (dataManager.ExecQuery(exeInterval, ref ds) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结记录发生错误"));
                return;
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                this.cmbMonthStoreInterval.Items.Clear();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string strInterval = NConvert.ToDateTime(dr[0]).ToString() + "--" + NConvert.ToDateTime(dr[1]).ToString();

                    this.cmbMonthStoreInterval.Items.Add(strInterval);
                }
            }
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        private void QueryData()
        {
            if (this.cmbMonthStoreInterval.Text == "")
                return;

            if (this.OperDept.ID == "")
                return;

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            string strInterval = this.cmbMonthStoreInterval.Text;

            string strBegin = strInterval.Substring(0, strInterval.IndexOf("--"));
            string strEnd = strInterval.Substring(strInterval.IndexOf("--") + 2);

            string exeDetail = string.Format(this.sqlTotal, this.OperDept.ID, strBegin, strEnd);

            DataSet ds = new DataSet();

            this.lbDept.Text = "库存科室:" + this.OperDept.Name;
            this.lbDate.Text = "统计区间:" + this.cmbMonthStoreInterval.Text;

            if (dataManager.ExecQuery(exeDetail, ref ds) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结明细发生错误"));
                return;
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                this.fpDetail.Rows.Count = 0;

                this.fpHead.DataSource = ds;

                int iTotIndex = this.fpHead.Rows.Count;
                this.fpHead.Rows.Add(iTotIndex, 1);
                this.fpHead.Cells[iTotIndex, 0].Text = "合计:";
                if (iTotIndex == 0)
                {
                    for (int i = 1; i < this.fpHead.Columns.Count; i++)
                    {
                        this.fpHead.Cells[iTotIndex, i].Text = "0";
                    }
                }
                else
                {
                    for (int i = 1; i < this.fpHead.Columns.Count; i++)
                    {
                        this.fpHead.Cells[iTotIndex, i].Formula = "SUM(" + (char)(65 + i) + "1:" + (char)(65 + i) + iTotIndex.ToString() + ")";
                    }
                }
                this.fpHead.Rows[iTotIndex].Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            }
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryData();

            return base.OnQuery(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.Init();
            }
            catch { }

            base.OnLoad(e);
        }

        private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.cmbMonthStoreInterval.Text = "";
            this.QueryStoreInterval();
        }
        //打印预览
        public override int PrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print printview = new Neusoft.FrameWork.WinForms.Classes.Print();

            //printview.PrintPreview(0, 0, this.neuTabControl1.SelectedTab);
            printview.PrintPreview(this.neuPanel2);
            return base.OnPrintPreview(sender, neuObject);
        }

        //打印
        protected override int OnPrint(object sender, object neuObject)
        {
            this.neuSpread1.PrintSheet(0);
            return base.OnPrint(sender, neuObject);
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.cmbMonthStoreInterval.Text == "")
                return;

            if (this.OperDept.ID == "")
                return;

            if (this.fpHead.Rows.Count <= 0)
                return;

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            string strInterval = this.cmbMonthStoreInterval.Text;

            string strBegin = strInterval.Substring(0, strInterval.IndexOf("--"));
            string strEnd = strInterval.Substring(strInterval.IndexOf("--") + 2);

            string exeDetail = string.Format(this.sqlDetail, this.OperDept.ID, strBegin, strEnd);

            DataSet ds = new DataSet();

            if (dataManager.ExecQuery(exeDetail, ref ds) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结明细发生错误"));
                return;
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                this.fpDetail.DataSource = ds;

                this.neuSpread1.ActiveSheet = this.fpDetail;
            }
        }
    }
}
