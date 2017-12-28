using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// [功能描述: 设备够买审批实体类]<br></br>
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
    public class BuyExam : Neusoft.HISFC.Models.Base.Spell
    {
        #region 构造函数
	    /// <summary>
	    /// 构造函数
	    /// </summary>
        public BuyExam()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
	    #endregion 构造函数

	    #region 变量

	    #region 私有变量

        /// <summary>
        /// 前级审批流水号(空为'NONE')
        /// </summary>
        private string lastExamNo;

        /// <summary>
        /// 后级审批流水号(空为'NONE')
        /// </summary>
        private string nextExamNo;

        /// <summary>
        /// 申请单流水号
        /// </summary>
        private string applyNo;

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
        /// 收件时间
        /// </summary>
        private DateTime getDate;

        /// <summary>
        /// 审批人
        /// </summary>
        private NeuObject examOper = new NeuObject();

        /// <summary>
        /// 审批科室
        /// </summary>
        private NeuObject examDept = new NeuObject();

        /// <summary>
        /// 审批时间
        /// </summary>
        private DateTime examDate;

        /// <summary>
        /// 审批说明
        /// </summary>
        private string examCont;

        /// <summary>
        /// 审批是否通过
        /// </summary>
        private bool isPass;

        /// <summary>
        /// 审批是否结束
        /// </summary>
        private bool isEnd;

        /// <summary>
        /// 审批阶段(主管批、院长批等)
        /// </summary>
        private string examPhase;

        /// <summary>
        /// 上级审批科室
        /// </summary>
        private NeuObject nextDept = new NeuObject();

        /// <summary>
        /// 审批集合
        /// </summary>
        private List<BuyExam> buyExam = new List<BuyExam>();

        /// <summary>
        /// 审批状态:"0"无变化,"1"增加,"2"修改
        /// </summary>
        private string examState = "0";

        /// <summary>
        /// 申请状态
        /// </summary>
        private string applyState;

	    #endregion 私有变量

	    #region 保护变量
	    #endregion 保护变量

	    #region 公开变量
	    #endregion 公开变量

	    #endregion 变量

	    #region 属性

        /// <summary>
        /// 前级审批流水号(空为'NONE')
        /// </summary>
        public string LastExamNo
        {
            get { return lastExamNo; }
            set { lastExamNo = value; }
        }

        /// <summary>
        /// 后级审批流水号(空为'NONE')
        /// </summary>
        public string NextExamNo
        {
            get { return nextExamNo; }
            set { nextExamNo = value; }
        }

        /// <summary>
        /// 申请单流水号
        /// </summary>
        public string ApplyNo
        {
            get { return applyNo; }
            set { applyNo = value; }
        }

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
        /// 收件时间
        /// </summary>
        public DateTime GetDate
        {
            get { return getDate; }
            set { getDate = value; }
        }

        /// <summary>
        /// 审批人
        /// </summary>
        public NeuObject ExamOper
        {
            get { return examOper; }
            set { examOper = value; }
        }

        /// <summary>
        /// 审批科室
        /// </summary>
        public NeuObject ExamDept
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
        /// 审批是否通过
        /// </summary>
        public bool IsPass
        {
            get { return isPass; }
            set { isPass = value; }
        }

        /// <summary>
        /// 审批是否结束
        /// </summary>
        public bool IsEnd
        {
            get { return isEnd; }
            set { isEnd = value; }
        }

        /// <summary>
        /// 审批阶段(主管批、院长批等)
        /// </summary>
        public string ExamPhase
        {
            get { return examPhase; }
            set { examPhase = value; }
        }

        /// <summary>
        /// 上级审批科室
        /// </summary>
        public NeuObject NextDept
        {
            get { return nextDept; }
            set { nextDept = value; }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public BuyExam this[int pos]
        {
            get
            {
                return this.buyExam[pos] as BuyExam;
            }
            set
            {
                this.buyExam[pos] = value;
            }
        }

        public BuyExam this[string dept]
        {
            get
            {
                foreach (BuyExam tempExam in this.buyExam)
                {
                    if (tempExam.examDept.ID == dept)
                    {
                        return tempExam;
                    }
                }
                return null;
            }
            set
            {
                for (int i = 0; i < buyExam.Count; i++)
                {
                    if (buyExam[i].examDept.ID == dept)
                    {
                        buyExam[i] = value;
                    }
                }
            }
        }

        /// <summary>
        /// 索引器数组个数
        /// </summary>
        public int Count
        {
            get
            {
                return this.buyExam.Count;
            }
        }

        /// <summary>
        /// 审批状态:"0"无变化,"1"增加,"2"修改
        /// </summary>
        public string ExamState
        {
            get { return examState; }
            set { examState = value; }
        }

        /// <summary>
        /// 申请状态
        /// </summary>
        public string ApplyState
        {
            get { return applyState; }
            set { applyState = value; }
        }

	    #endregion 属性

	    #region 方法

	    #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new BuyExam Clone()
        {
            BuyExam buyExam = base.Clone() as BuyExam;

            buyExam.Dept = this.dept.Clone();
            buyExam.ApplyOper = this.applyOper.Clone();
            buyExam.ApplyDept = this.applyDept.Clone();
            buyExam.ExamOper = this.examOper.Clone();
            buyExam.ExamDept = this.examDept.Clone();
            buyExam.NextDept = this.nextDept.Clone();

            return buyExam;
        }

	    #endregion 克隆

	    #region 私有方法
	    #endregion 私有方法

	    #region 保护方法
	    #endregion 保护方法

	    #region 公开方法

        /// <summary>
        /// 增加一个审批信息
        /// </summary>
        /// <param name="buyExam">审批实体</param>
        public void Add(BuyExam newBuyExam)
        {
            this.buyExam.Add(newBuyExam);
        }

	    #endregion 公开方法

	    #endregion 方法

    }
}
