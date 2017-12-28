using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// [功能描述: 设备购买申请实体类]<br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2007-11-26]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class BuyApply : Neusoft.HISFC.Models.Base.Spell
    {
        #region 构造函数
	    /// <summary>
	    /// 构造函数
	    /// </summary>
        public BuyApply()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
	    #endregion 构造函数

	    #region 变量

	    #region 私有变量

        /// <summary>
        /// 申请单据号
        /// </summary>
        private string applyListCode;

        /// <summary>
        /// 设备科室
        /// </summary>
        private NeuObject dept = new NeuObject();

        /// <summary>
        /// 项目名称
        /// </summary>
        private string itemName;

        /// <summary>
        /// 项目描述
        /// </summary>
        private string itemCont;

        /// <summary>
        /// 数量
        /// </summary>
        private int itemNum;

        /// <summary>
        /// 预算金额
        /// </summary>
        private decimal itemCost;

        /// <summary>
        /// 收费标准
        /// </summary>
        private string feeRule;

        /// <summary>
        /// 费用收回开始时间
        /// </summary>
        private DateTime fromDate;

        /// <summary>
        /// 费用收回结束时间
        /// </summary>
        private DateTime toDate;

        /// <summary>
        /// 申请状态0申请1审批中2审批完3作废
        /// </summary>
        private string applyState;

        /// <summary>
        /// 申请人
        /// </summary>
        private NeuObject applyOper = new NeuObject();

        /// <summary>
        /// 申请科室
        /// </summary>
        private NeuObject applyDept = new NeuObject();

        /// <summary>
        /// 申请时间
        /// </summary>
        private DateTime applyDate;

        /// <summary>
        /// 作废人
        /// </summary>
        private NeuObject wasteOper = new NeuObject();

        /// <summary>
        /// 作废科室
        /// </summary>
        private NeuObject wasteDept = new NeuObject();

        /// <summary>
        /// 作废时间
        /// </summary>
        private DateTime wasteDate;

        /// <summary>
        /// 作废原因
        /// </summary>
        private string wasteCause;

        /// <summary>
        /// 审批信息
        /// </summary>
        private BuyExam buyExams = new BuyExam();

        /// <summary>
        /// 上级审批科室
        /// </summary>
        private NeuObject nextDept = new NeuObject();

	    #endregion 私有变量

	    #region 保护变量
	    #endregion 保护变量

	    #region 公开变量
	    #endregion 公开变量

	    #endregion 变量

	    #region 属性

        /// <summary>
        /// 申请单据号
        /// </summary>
        public string ApplyListCode
        {
            get { return applyListCode; }
            set { applyListCode = value; }
        }

        /// <summary>
        /// 设备科室
        /// </summary>
        public NeuObject Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string ItemCont
        {
            get { return itemCont; }
            set { itemCont = value; }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int ItemNum
        {
            get { return itemNum; }
            set { itemNum = value; }
        }

        /// <summary>
        /// 预算金额
        /// </summary>
        public decimal ItemCost
        {
            get { return itemCost; }
            set { itemCost = value; }
        }

        /// <summary>
        /// 收费标准
        /// </summary>
        public string FeeRule
        {
            get { return feeRule; }
            set { feeRule = value; }
        }

        /// <summary>
        /// 费用收回开始时间
        /// </summary>
        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }

        /// <summary>
        /// 费用收回结束时间
        /// </summary>
        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        /// <summary>
        /// 申请状态0申请1审批中2审批完3作废
        /// </summary>
        public string ApplyState
        {
            get { return applyState; }
            set { applyState = value; }
        }

        /// <summary>
        /// 申请人
        /// </summary>
        public NeuObject ApplyOper
        {
            get { return applyOper; }
            set { applyOper = value; }
        }

        /// <summary>
        /// 申请科室
        /// </summary>
        public NeuObject ApplyDept
        {
            get { return applyDept; }
            set { applyDept = value; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate
        {
            get { return applyDate; }
            set { applyDate = value; }
        }

        /// <summary>
        /// 作废人
        /// </summary>
        public NeuObject WasteOper
        {
            get { return wasteOper; }
            set { wasteOper = value; }
        }

        /// <summary>
        /// 作废科室
        /// </summary>
        public NeuObject WasteDept
        {
            get { return wasteDept; }
            set { wasteDept = value; }
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
        /// 作废原因
        /// </summary>
        public string WasteCause
        {
            get { return wasteCause; }
            set { wasteCause = value; }
        }

        /// <summary>
        /// 审批信息
        /// </summary>
        public BuyExam BuyExams
        {
            get { return buyExams; }
            set { buyExams = value; }
        }

        /// <summary>
        /// 是否结束
        /// </summary>
        public bool IsEnd
        {
            set
            {
                for (int i = 0; i < buyExams.Count; i++)
                {
                    buyExams[i].IsEnd = value;
                    buyExams.ExamState = "2";
                }
            }
        }

        /// <summary>
        /// 上级审批科室
        /// </summary>
        public NeuObject NextDept
        {
            get { return nextDept; }
            set { nextDept = value; }
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
        public new BuyApply Clone()
        {
            BuyApply buyApply = base.Clone() as BuyApply;

            buyApply.Dept = this.dept.Clone();
            buyApply.ApplyOper = this.applyOper.Clone();
            buyApply.ApplyDept = this.applyDept.Clone();
            buyApply.WasteOper = this.wasteOper.Clone();
            buyApply.WasteDept = this.wasteDept.Clone();
            buyApply.BuyExams = this.buyExams.Clone();
            buyExams.NextDept = this.nextDept.Clone();

            return buyApply;
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
