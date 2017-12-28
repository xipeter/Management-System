using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// InPlan<br></br>
    /// [功能描述: 设备采购计划实体类]<br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2008-1-7]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class InPlan : Neusoft.FrameWork.Models.NeuObject
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public InPlan()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion 构造函数

        #region 变量

        #region 私有变量

        /// <summary>
        /// 采购计划序号
        /// </summary>
        private int serialCode;

        /// <summary>
        /// 采购计划单据号
        /// </summary>
        private string listCode;

        /// <summary>
        /// 入库实体
        /// </summary>
       // private HISFC.Object.Equipment.Input inputInfo = new Input();

        private Neusoft.HISFC.Models.Equipment.Input inputInfo = new Input();

        /// <summary>
        /// 采购计划部门
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject planDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 计划单类型0手工计划1警戒线2消耗3时间4日消耗
        /// </summary>
        private string planType;

        /// <summary>
        /// 计划单状态0采购计划单1审核2已入库3作废
        /// </summary>
        private string planState;

        /// <summary>
        /// 计划科室库存量
        /// </summary>
        private int planDeptStor;

        /// <summary>
        /// 全院库存量
        /// </summary>
        private int allDeptStor;

        /// <summary>
        /// 合同流水号
        /// </summary>
        private string pactNo;

        /// <summary>
        /// 合同编号
        /// </summary>
        private string pactCode;

        /// <summary>
        /// 计划数量
        /// </summary>
        private int planNum;

        /// <summary>
        /// 计划价格
        /// </summary>
        private decimal planPrice;

        /// <summary>
        /// 计划金额
        /// </summary>
        private decimal planCost;

        /// <summary>
        /// 计划到货时间
        /// </summary>
        private DateTime getDate;

        /// <summary>
        /// 计划采购时间
        /// </summary>
        private DateTime buyDate;

        /// <summary>
        /// 计划采购人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject buyOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 计划录入人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject planOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 计划录入时间
        /// </summary>
        private DateTime planDate;

        /// <summary>
        /// 审批人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject examOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 审批数量
        /// </summary>
        private int examNum;

        /// <summary>
        /// 审批科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject examDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 审批时间
        /// </summary>
        private DateTime examDate;

        /// <summary>
        /// 审批说明
        /// </summary>
        private string examCont;

        /// <summary>
        /// 作废人
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject wasteOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 作废时间
        /// </summary>
        private DateTime wasteDate;

        /// <summary>
        /// 作废说明
        /// </summary>
        private string wasteCont;

        #endregion 私有变量

        #region 保护变量
        #endregion 保护变量

        #region 公开变量
        #endregion 公开变量

        #endregion 变量

        #region 属性

        /// <summary>
        /// 采购计划序号
        /// </summary>
        public int SerialCode
        {
            get { return serialCode; }
            set { serialCode = value; }
        }

        /// <summary>
        /// 采购计划单据号
        /// </summary>
        public string ListCode
        {
            get { return listCode; }
            set { listCode = value; }
        }

        /// <summary>
        /// 入库实体
        /// </summary>
        public Neusoft.HISFC.Models.Equipment.Input InputInfo
        {
            get { return inputInfo; }
            set { inputInfo = value; }
        }

        /// <summary>
        /// 采购计划部门
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PlanDept
        {
            get { return planDept; }
            set { planDept = value; }
        }

        /// <summary>
        /// 计划单类型0手工计划1警戒线2消耗3时间4日消耗
        /// </summary>
        public string PlanType
        {
            get { return planType; }
            set { planType = value; }
        }

        /// <summary>
        /// 计划单状态0采购计划单1审核2已入库3作废
        /// </summary>
        public string PlanState
        {
            get { return planState; }
            set { planState = value; }
        }

        /// <summary>
        /// 计划科室库存量
        /// </summary>
        public int PlanDeptStor
        {
            get { return planDeptStor; }
            set { planDeptStor = value; }
        }

        /// <summary>
        /// 全院库存量
        /// </summary>
        public int AllDeptStor
        {
            get { return allDeptStor; }
            set { allDeptStor = value; }
        }

        /// <summary>
        /// 合同流水号
        /// </summary>
        public string PactNo
        {
            get { return pactNo; }
            set { pactNo = value; }
        }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string PactCode
        {
            get { return pactCode; }
            set { pactCode = value; }
        }

        /// <summary>
        /// 计划数量
        /// </summary>
        public int PlanNum
        {
            get { return planNum; }
            set { planNum = value; }
        }

        /// <summary>
        /// 计划价格
        /// </summary>
        public decimal PlanPrice
        {
            get { return planPrice; }
            set { planPrice = value; }
        }

        /// <summary>
        /// 计划金额
        /// </summary>
        public decimal PlanCost
        {
            get { return planCost; }
            set { planCost = value; }
        }

        /// <summary>
        /// 计划到货时间
        /// </summary>
        public DateTime GetDate
        {
            get { return getDate; }
            set { getDate = value; }
        }

        /// <summary>
        /// 计划采购时间
        /// </summary>
        public DateTime BuyDate
        {
            get { return buyDate; }
            set { buyDate = value; }
        }

        /// <summary>
        /// 计划采购人员
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject BuyOper
        {
            get { return buyOper; }
            set { buyOper = value; }
        }

        /// <summary>
        /// 计划录入人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PlanOper
        {
            get { return planOper; }
            set { planOper = value; }
        }

        /// <summary>
        /// 计划录入时间
        /// </summary>
        public DateTime PlanDate
        {
            get { return planDate; }
            set { planDate = value; }
        }

        /// <summary>
        /// 审批人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ExamOper
        {
            get { return examOper; }
            set { examOper = value; }
        }

        /// <summary>
        /// 审批数量
        /// </summary>
        public int ExamNum
        {
            get { return examNum; }
            set { examNum = value; }
        }

        /// <summary>
        /// 审批科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ExamDept
        {
            get { return examDept; }
            set { examDept = value; }
        }

        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime ExamDate
        {
            get { return examDate; }
            set { examDate = value; }
        }

        /// <summary>
        /// 审批说明
        /// </summary>
        public string ExamCont
        {
            get { return examCont; }
            set { examCont = value; }
        }

        /// <summary>
        /// 作废人
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject WasteOper
        {
            get { return wasteOper; }
            set { wasteOper = value; }
        }

        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime WasteDate
        {
            get { return wasteDate; }
            set { wasteDate = value; }
        }

        /// <summary>
        /// 作废说明
        /// </summary>
        public string WasteCont
        {
            get { return wasteCont; }
            set { wasteCont = value; }
        }

        #endregion 属性

        #region 方法

        #region 资源释放
        #endregion 资源释放

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new InPlan Clone()
        {
            InPlan inPlan = base.Clone() as InPlan;

            inPlan.WasteOper = this.WasteOper.Clone();
            inPlan.ExamDept = this.ExamDept.Clone();
            inPlan.ExamOper = this.ExamOper.Clone();
            inPlan.PlanOper = this.PlanOper.Clone();
            inPlan.BuyOper = this.BuyOper.Clone();
            inPlan.PlanDept = this.PlanDept.Clone();
            inPlan.InputInfo = this.InputInfo.Clone();

            return inPlan;
        }

        #endregion 克隆

        #region 私有方法
        #endregion 私有方法

        #region 保护方法
        #endregion 保护方法

        #region 公开方法
        #endregion 公开方法

        #endregion 方法

        #region 事件
        #endregion 事件

        #region 接口实现
        #endregion 接口实现

    }
}
