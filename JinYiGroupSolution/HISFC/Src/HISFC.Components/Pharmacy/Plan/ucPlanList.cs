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

namespace Neusoft.HISFC.Components.Pharmacy.Plan
{
    /// <summary>
    /// [功能描述: 药品计划单据选择(入库计划合并)]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucPlanList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPlanList()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 药品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operPrivDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 合并后计划信息
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.InPlan> alterInPlan = null;

        /// <summary>
        /// 窗口结果
        /// </summary>
        private DialogResult result = DialogResult.Cancel;
        #endregion

        #region 属 性

        /// <summary>
        /// 是否允许进行时间段选择
        /// </summary>
        [Description("是否允许进行时间段选择"),Category("设置"),DefaultValue(false)]
        public bool IsShowTimeSelect
        {
            get
            {
                return this.neuPanel1.Visible;
            }
            set
            {
                this.neuPanel1.Visible = value;
            }
        }

        /// <summary>
        /// 当前操作权限科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OperPrivDept
        {
            get
            {
                return this.operPrivDept;
            }
            set
            {
                this.operPrivDept = value;
            }
        }

        /// <summary>
        /// 当前操作单据状态
        /// </summary>
        public string State
        {
            get
            {
                if (this.cmbState.Text == "" || this.cmbState.Text.IndexOf("[") == -1)
                {
                    return "0";
                }
                else
                {
                    return this.cmbState.Text.Substring(this.cmbState.Text.IndexOf("[") + 1, 1);
                }
            }
            set
            {
                switch (value)
                {
                    case "0":
                        this.cmbState.Text = "计划[0]";
                        break;
                    case "1":
                        this.cmbState.Text = "采购[1]";
                        break;
                    case"2":
                        this.cmbState.Text = "审核[2]";
                        break;
                    case"3":
                        this.cmbState.Text = "入库[3]";
                        break;
                    case "4":
                        this.cmbState.Text = "作废[4]";
                        break;
                }
            }
        }

        /// <summary>
        /// 合并后计划信息
        /// </summary>
        public List<Neusoft.HISFC.Models.Pharmacy.InPlan> AlterInPlan
        {
            get
            {
                return alterInPlan;
            }
            set
            {
                alterInPlan = value;
            }
        }

        /// <summary>
        /// 结果
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }

        /// <summary>
        ///  查询开始时间
        /// </summary>
        protected DateTime BeginTime
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtBegin.Text);
            }
        }

        /// <summary>
        /// 查询截至时间
        /// </summary>
        protected DateTime EndTime
        {
            get
            {
                return Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtEnd.Text);
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();
            this.dtBegin.Value = sysTime.Date.AddDays(-7);
            this.dtEnd.Value = sysTime;

            this.neuSpread1_Sheet2.DefaultStyle.Locked = true;
            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
            this.neuSpread1_Sheet1.Columns[0].Locked = false;

            return 1;
        }

        /// <summary>
        /// 单据列表检索
        /// </summary>
        /// <param name="deptNO"></param>
        /// <param name="state"></param>
        /// <param name="queryBeginTime"></param>
        /// <param name="queryEndTime"></param>
        /// <returns></returns>
        public int QueryList(string deptNO, string state)
        {
            ArrayList alList = this.itemManager.QueryInPLanList(deptNO, state);
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("获取入库计划单据列表发生错误" + this.itemManager.Err));
                return -1;
            }

            this.neuSpread1_Sheet1.Rows.Count = 0;

            foreach (Neusoft.FrameWork.Models.NeuObject objList in alList)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);
                this.neuSpread1_Sheet1.Cells[0, 0].Value = false;           //是否选中 默认不选中
                this.neuSpread1_Sheet1.Cells[0, 1].Text = objList.ID;       //计划单号
                this.neuSpread1_Sheet1.Cells[0, 2].Text = objList.Name;     //计划人
            }
            return 1;
        }

        /// <summary>
        /// 单据明细查询
        /// </summary>
        /// <param name="deptNO">库存科室</param>
        /// <param name="listNO">单据号</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int QueryDetail(string deptNO, string listNO)
        {
            List<Neusoft.HISFC.Models.Pharmacy.InPlan> alDetail = this.itemManager.QueryInPlanDetail(deptNO, listNO);
            if (alDetail == null)
            {
                MessageBox.Show(Language.Msg("获取明细失败" + this.itemManager.Err));
                return -1;
            }

            this.neuSpread1_Sheet2.Rows.Count = 0;

            foreach (Neusoft.HISFC.Models.Pharmacy.InPlan objDetail in alDetail)
            {
                this.neuSpread1_Sheet2.Rows.Add(0, 1);
                this.neuSpread1_Sheet2.Cells[0, 0].Text = objDetail.Item.Name;                                          //药品名称
                this.neuSpread1_Sheet2.Cells[0, 1].Text = objDetail.Item.Specs;                                         //规格
                this.neuSpread1_Sheet2.Cells[0, 2].Text = (objDetail.PlanQty / objDetail.Item.PackQty).ToString();      //计划数量
                this.neuSpread1_Sheet2.Cells[0, 3].Text = objDetail.Item.PackUnit;                                      //单位
                this.neuSpread1_Sheet2.Cells[0, 4].Text = (objDetail.StoreQty / objDetail.Item.PackQty).ToString();     //本科室库存量
                this.neuSpread1_Sheet2.Cells[0, 5].Text = (objDetail.StoreTotQty / objDetail.Item.PackQty).ToString();     //全院库存量
                this.neuSpread1_Sheet2.Cells[0, 6].Text = objDetail.Memo;                                               //备注
            }

            return 1;
        }

        /// <summary>
        /// 单据合并
        /// </summary>
        /// <returns></returns>
        public int MergeInPlan()
        {
            int billNOCount = 0;
            string singlePlanNO = "";
            string[] strList = new string[this.neuSpread1_Sheet1.Rows.Count];
            for(int i = 0;i < this.neuSpread1_Sheet1.Rows.Count;i++)
            {
                if (NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i,0].Value))
                {
                    strList[i] = this.neuSpread1_Sheet1.Cells[i, 1].Text;

                    singlePlanNO = strList[i];
                    billNOCount++;
                }
            }
            //未选择计划单
            if (billNOCount == 0)
            {
                MessageBox.Show(Language.Msg("请选择计划单"));
                return -1;
            }

            //只选择一个单据 不进行提示
            if (billNOCount == 1)
            {
                this.alterInPlan = this.itemManager.MergeInPlan(this.operPrivDept.ID, singlePlanNO);
                if (this.alterInPlan == null)
                {
                    MessageBox.Show(Language.Msg("根据单据号获取入库计划信息失败") + this.itemManager.Err);
                    return -1;
                }
            }
            else  //选择个多个单据 进行合并
            {
                DialogResult rs = MessageBox.Show(Language.Msg("您选择了多个单据 确认对所选择的单据合并为一张计划单吗? 请注意 此操作不可恢复"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return -1;
                }

                this.alterInPlan = this.itemManager.MergeInPlan(this.operPrivDept.ID, strList);

                string strBillNO = "";

                foreach (Neusoft.HISFC.Models.Pharmacy.InPlan info in this.alterInPlan)
                {
                    #region 单据号处理

                    if (strBillNO == "")
                    {
                        info.BillNO = this.itemManager.GetPlanBillNO(info.Dept.ID);
                        if (info.BillNO == null || info.BillNO == "")
                        {
                            this.alterInPlan = new List<Neusoft.HISFC.Models.Pharmacy.InPlan>();
                            MessageBox.Show(Language.Msg("获取采购单据号失败" + this.itemManager.Err));
                            return -1;
                        }

                        strBillNO = info.BillNO;
                    }
                    else
                    {
                        info.BillNO = strBillNO;
                    }

                    #endregion

                    if (this.itemManager.InsertInPlan(info) == -1)
                    {
                        this.alterInPlan = new List<Neusoft.HISFC.Models.Pharmacy.InPlan>();
                        MessageBox.Show(Language.Msg("保存新生成入库计划信息失败" + this.itemManager.Err));
                        return -1;
                    }

                    if (info.ReplacePlanNO.IndexOf("|") == -1)
                    {
                        if (this.itemManager.CancelInPlan(info.ID, info.ReplacePlanNO) == -1)
                        {
                            this.alterInPlan = new List<Neusoft.HISFC.Models.Pharmacy.InPlan>();
                            MessageBox.Show(Language.Msg("作废原计划单信息失败" + this.itemManager.Err));
                            return -1;
                        }
                    }
                    else
                    {
                        if (this.itemManager.CancelInPlan(info.ID, info.ReplacePlanNO.Split('|')) == -1)
                        {
                            this.alterInPlan = new List<Neusoft.HISFC.Models.Pharmacy.InPlan>();
                            MessageBox.Show(Language.Msg("作废原计划单信息失败" + this.itemManager.Err));
                            return -1;
                        }
                    }
                }
            }

            return 1;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.QueryList(this.operPrivDept.ID, this.State);
            }

            base.OnLoad(e);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (this.MergeInPlan() == -1)
            {
                this.result = DialogResult.Cancel;
            }
            else
            {
                this.result = DialogResult.OK;

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.Cancel;

            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.QueryList(this.operPrivDept.ID, this.State);
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
                return;

            if (this.neuSpread1.ActiveSheet == this.neuSpread1_Sheet2)
            {
                this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet1;
                return;
            }

            string listNO = this.neuSpread1_Sheet1.Cells[e.Row,1].Text;
            if (this.QueryDetail(this.operPrivDept.ID, listNO) == -1)
            {
                return;
            }

            this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet2;
        }
    }
}
