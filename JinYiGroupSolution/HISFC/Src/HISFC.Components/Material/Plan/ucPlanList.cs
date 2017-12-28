using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Material.Plan
{
    /// <summary>
    /// 需增加入库时间段选择
    /// </summary>
    public partial class ucPlanList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPlanList()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 物品管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Plan planManager = new Neusoft.HISFC.BizLogic.Material.Plan();

        /// <summary>
        /// 物资项目类
        /// {9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operPrivDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 合并后计划信息
        /// </summary>
        private ArrayList alterInPlan = null;

        /// <summary>
        /// 窗口结果
        /// </summary>
        private DialogResult result = DialogResult.Cancel;

        /// <summary>
        /// 单据检索状态
        /// </summary>
        private string state = "0";
        #endregion

        #region 属 性

        /// <summary>
        /// 是否允许进行时间段选择
        /// </summary>
        [Description("是否允许进行时间段选择"), Category("设置"), DefaultValue(false)]
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
                return this.state;

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
                this.state = value;

                switch (value)
                {
                    case "0":
                        this.cmbState.Text = "计划[0]";
                        break;
                    case "1":
                        this.cmbState.Text = "采购[1]";
                        break;
                    case "2":
                        this.cmbState.Text = "审核[2]";
                        break;
                    case "3":
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
        public ArrayList AlterInPlan
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
                return NConvert.ToDateTime(this.dtBegin.Text);
            }
        }

        /// <summary>
        /// 查询截至时间
        /// </summary>
        protected DateTime EndTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtEnd.Text);
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            DateTime sysTime = this.planManager.GetDateTimeFromSysDateTime();
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
            ArrayList alList = this.planManager.QueryInPLanList(deptNO, state);
            if (alList == null)
            {
                MessageBox.Show("获取入库计划单据列表发生错误" + this.planManager.Err);
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
            ArrayList alDetail = this.planManager.QueryInPlanDetail(deptNO, listNO);
            if (alDetail == null)
            {
                MessageBox.Show("获取明细失败" + this.planManager.Err);
                return -1;
            }

            this.neuSpread1_Sheet2.Rows.Count = 0;

            foreach (Neusoft.HISFC.Models.Material.InputPlan objDetail in alDetail)
            {
                //重新获取一下物资基本信息
                //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                objDetail.StoreBase.Item = this.itemManager.GetMetItemByMetID(objDetail.StoreBase.Item.ID);

                this.neuSpread1_Sheet2.Rows.Add(0, 1);
                this.neuSpread1_Sheet2.Cells[0, 0].Text = objDetail.StoreBase.Item.Name;                                         //物品名称
                this.neuSpread1_Sheet2.Cells[0, 1].Text = objDetail.StoreBase.Item.Specs;                                        //规格
                this.neuSpread1_Sheet2.Cells[0, 2].Text = (objDetail.PlanNum / objDetail.StoreBase.Item.PackQty).ToString();     //计划数量
                this.neuSpread1_Sheet2.Cells[0, 3].Text = objDetail.StoreBase.Item.PackUnit;                                     //单位
                this.neuSpread1_Sheet2.Cells[0, 4].Text = (objDetail.StoreSum / objDetail.StoreBase.Item.PackQty).ToString();    //本科室库存量
                this.neuSpread1_Sheet2.Cells[0, 5].Text = (objDetail.StoreTotsum / objDetail.StoreBase.Item.PackQty).ToString(); //全院库存量
                this.neuSpread1_Sheet2.Cells[0, 6].Text = objDetail.Memo;														//备注
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
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, 0].Value))
                {
                    strList[i] = this.neuSpread1_Sheet1.Cells[i, 1].Text;

                    singlePlanNO = strList[i];
                    billNOCount++;
                }
            }
            //未选择计划单
            if (billNOCount == 0)
            {
                MessageBox.Show("请选择计划单");
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.planManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //只选择一个单据 不进行提示
            if (billNOCount == 1)
            {
                this.alterInPlan = this.planManager.MergeInPlan(this.operPrivDept.ID, singlePlanNO);
                if (this.alterInPlan == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("根据单据号获取入库计划信息失败" + this.planManager.Err);
                    return -1;
                }
            }
            else  //选择个多个单据 进行合并
            {
                DialogResult rs = MessageBox.Show("您选择了多个单据 确认对所选择的单据合并为一张计划单吗? 请注意 此操作不可恢复", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }

                this.alterInPlan = this.planManager.MergeInPlan(this.operPrivDept.ID, strList);

                string strBillNO = "";
                //{4FDD0EDB-7352-46ab-A1A4-319E512A8CBF}
                int planNO = 1;
                foreach (Neusoft.HISFC.Models.Material.InputPlan info in this.alterInPlan)
                {
                    //if (this.planManager.CancelInPlan(info.ID) == -1){4FDD0EDB-7352-46ab-A1A4-319E512A8CBF}
                    if (this.planManager.CancelInPlan(info.StorageCode, info.Extend2) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.alterInPlan = new ArrayList();
                        MessageBox.Show("作废原计划单信息失败" + this.planManager.Err);
                        return -1;
                    }

                    #region 单据号处理

                    if (strBillNO == "")
                    {
                        info.PlanListCode = this.planManager.GetPlanNO(info.StorageCode);
                        if (info.PlanListCode == null || info.StorageCode == "")
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.alterInPlan = new ArrayList();
                            MessageBox.Show("获取采购单据号失败" + this.planManager.Err);
                            return -1;
                        }

                        strBillNO = info.PlanListCode;
                        //{4FDD0EDB-7352-46ab-A1A4-319E512A8CBF}
                        info.PlanNo = planNO;
                        planNO++;
                    }
                    else
                    {
                        info.PlanListCode = strBillNO;
                        //{4FDD0EDB-7352-46ab-A1A4-319E512A8CBF}
                        info.PlanNo = planNO;
                        planNO++;
                    }

                    #endregion
                    //{4FDD0EDB-7352-46ab-A1A4-319E512A8CBF}
                    info.Extend2 = info.Extend2.Replace(@"','", "|");

                    if (this.planManager.InsertInputPlan(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.alterInPlan = new ArrayList();
                        MessageBox.Show("保存新生成入库计划信息失败" + this.planManager.Err);
                        return -1;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

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

        private void ucPlanList_Load(object sender, System.EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.QueryList(this.operPrivDept.ID, this.State);
            }            
        }

        private void btnMerge_Click(object sender, System.EventArgs e)
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

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.result = DialogResult.Cancel;

            this.Close();
        }

        private void btnQuery_Click(object sender, System.EventArgs e)
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

            string listNO = this.neuSpread1_Sheet1.Cells[e.Row, 1].Text;
            if (this.QueryDetail(this.operPrivDept.ID, listNO) == -1)
            {
                return;
            }

            this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet2;
        }


    }
}
