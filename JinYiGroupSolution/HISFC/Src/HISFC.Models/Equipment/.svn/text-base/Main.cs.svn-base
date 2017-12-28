using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Company<br></br>
    /// [功能描述: 卡片基类]<br></br>
    /// [创 建 者: 朱庆元]<br></br>
    /// [创建时间: 2007-10-22]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class Main:Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Main() {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 卡片编号
        /// </summary>
        private string cardNo;

        /// <summary>
        /// 资产原值

        /// </summary>
        private decimal sourcePrice;

        /// <summary>
        /// 资产净值

        /// </summary>
        private decimal netPrice;
        
        /// <summary>
        ///资产残值 
        /// </summary>
        private decimal leavePrice;

        /// <summary>
        /// 已折旧月份

        /// </summary>
        private long lessMonth;

        /// <summary>
        /// 维修次数
        /// </summary>
        private long repairNum;

        /// <summary>
        /// 维修费用
        /// </summary>
        private decimal repairCost;

        /// <summary>
        /// 当前状态

        /// </summary>
        private string currState;

        /// <summary>
        /// 当前状态涵义代码

        /// </summary>
        private string class3MeaningCode;

        /// <summary>
        /// 预计净残值

        /// </summary>
        private decimal preNetPrice;

        /// <summary>
        /// 下次计量时间
        /// </summary>
        private DateTime nextGaugeDate;

        /// <summary>
        /// 保修截止日期
        /// </summary>
        private DateTime repairEndDate;

        /// <summary>
        /// 维修联系方式
        /// </summary>
        private string repairContact;

        /// <summary>
        /// 卡片备注信息
        /// </summary>
        private string remark;

        /// <summary>
        /// 保管科室
        /// </summary>
        private string storDept;

        /// <summary>
        /// 领用日期
        /// </summary>
        private DateTime getDate;

        /// <summary>
        /// 保管人

        /// </summary>
        private string storOper;

        /// <summary>
        /// 启用日期
        /// </summary>
        private DateTime startDate;

        /// <summary>
        /// 设备条码
        /// </summary>
        private string barCode;

        /// <summary>
        /// 设备条码
        /// </summary>      
        /// <summary>
        /// 是否有附件

        /// </summary>
        private bool isAnnexFlag;

        /// <summary>
        /// 附件信息说明
        /// </summary>
        private string annexNote;

        /// <summary>
        /// 是否进口
        /// </summary>
        private bool isImportFlag;

        /// <summary>
        /// 进口信息说明
        /// </summary>
        private string importNote;

        /// <summary>
        /// 是否是设备附件

        /// </summary>
        private bool isPartFlag;

        /// <summary>
        /// 设备附件对应的主设备(根节点'AAAA')
        /// </summary>
        private string parentSeqNO;

        /// <summary>
        /// 录入类型0入库录入1卡片登记录入
        /// </summary>
        private string enterFlag;

        /// <summary>
        /// 批次号

        /// </summary>
        private string groupNo;

        /// <summary>
        /// 帐页信息
        /// </summary>
        private EquipBase itemInfo = new EquipBase();

        /// <summary>
        /// 入库信息
        /// </summary>
        private Input inputInfo = new Input();

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性


        /// <summary>
        /// 卡片编号
        /// </summary>
        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        /// <summary>
        /// 资产原值

        /// </summary>
        public decimal SourcePrice
        {
            get { return sourcePrice; }
            set { sourcePrice = value; }
        }

        /// <summary>
        /// 资产净值

        /// </summary>
        public decimal NetPrice
        {
            get { return netPrice; }
            set { netPrice = value; }
        }

        /// <summary>
        /// 资产残值

        /// </summary>
        public decimal LeavePrice
        {
            get { return leavePrice; }
            set { leavePrice = value; }
        }

        /// <summary>
        /// 已折旧月份

        /// </summary>
        public long LessMonth
        {
            get { return lessMonth; }
            set { lessMonth = value; }
        }

        /// <summary>
        /// 维修次数
        /// </summary>
        public long RepairNum
        {
            get { return repairNum; }
            set { repairNum = value; }
        }

        /// <summary>
        /// 维修费用
        /// </summary>
        public decimal RepairCost
        {
            get { return repairCost; }
            set { repairCost = value; }
        }

        /// <summary>
        /// 当前状态

        /// </summary>
        public string CurrState
        {
            get { return currState; }
            set { currState = value; }
        }

        /// <summary>
        /// 当前状态涵义代码

        /// </summary>
        public string Class3MeaningCode
        {
            get { return class3MeaningCode; }
            set { class3MeaningCode = value; }
        }

        /// <summary>
        /// 预计净残值

        /// </summary>
        public decimal PreNetPrice
        {
            get { return preNetPrice; }
            set { preNetPrice = value; }
        }

        /// <summary>
        /// 下次计量时间
        /// </summary>
        public DateTime NextGaugeDate
        {
            get { return nextGaugeDate; }
            set { nextGaugeDate = value; }
        }

        /// <summary>
        /// 保修截止日期
        /// </summary>
        public DateTime RepairEndDate
        {
            get { return repairEndDate; }
            set { repairEndDate = value; }
        }

        /// <summary>
        /// 维修联系方式
        /// </summary>
        public string RepairContact
        {
            get { return repairContact; }
            set { repairContact = value; }
        }

        /// <summary>
        /// 卡片备注信息
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 保管科室
        /// </summary>
        public string StorDept
        {
            get { return storDept; }
            set { storDept = value; }
        }

        /// <summary>
        /// 领用日期
        /// </summary>
        public DateTime GetDate
        {
            get { return getDate; }
            set { getDate = value; }
        }

        /// <summary>
        /// 保管人

        /// </summary>
        public string StorOper
        {
            get { return storOper; }
            set { storOper = value; }
        }

        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        /// <summary>
        /// 设备条码
        /// </summary>
        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }

        /// <summary>
        /// 是否有附件

        /// </summary>
        public bool IsAnnexFlag
        {
            get { return isAnnexFlag; }
            set { isAnnexFlag = value; }
        }

        /// <summary>
        /// 附件信息说明
        /// </summary>
        public string AnnexNote
        {
            get { return annexNote; }
            set { annexNote = value; }
        }

        /// <summary>
        /// 是否进口
        /// </summary>
        public bool IsImportFlag
        {
            get { return isImportFlag; }
            set { isImportFlag = value; }
        }

        /// <summary>
        /// 进口信息说明
        /// </summary>
        public string ImportNote
        {
            get { return importNote; }
            set { importNote = value; }
        }

        /// <summary>
        /// 是否是设备附件

        /// </summary>
        public bool IsPartFlag
        {
            get { return isPartFlag; }
            set { isPartFlag = value; }
        }

        /// <summary>
        /// 设备附件对应的主设备(根节点'AAAA')
        /// </summary>
        public string ParentSeqNO
        {
            get { return parentSeqNO; }
            set { parentSeqNO = value; }
        }

        /// <summary>
        /// 录入类型0入库录入1卡片登记录入
        /// </summary>
        public string EnterFlag
        {
            get { return enterFlag; }
            set { enterFlag = value; }
        }

        /// <summary>
        /// 批次号

        /// </summary>
        public string GroupNo
        {
            get { return groupNo; }
            set { groupNo = value; }
        }

        /// <summary>
        /// 帐页信息
        /// </summary>
        public EquipBase ItemInfo
        {
            get
            {
                return this.itemInfo;
            }
            set
            {
                this.itemInfo = value;
            }
        }

        /// <summary>
        /// 入库信息
        /// </summary>
        public Input InputInfo
        {
            get
            {
                return this.inputInfo;
            }
            set
            {
                this.inputInfo = value;
            }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return this.operInfo;
            }
            set
            {
                this.operInfo = value;
            }
        }

        /// <summary>
        /// 资产原值是否可以为零

        /// </summary>
        public bool IsZeroSourcePrice 
        {
            get 
            {
                if (isPartFlag)
                {
                    return false;
                }
                else 
                {
                    return true;
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new Main Clone()
        {
            Main card = base.Clone() as Main;

            card.ItemInfo = this.ItemInfo.Clone();
            card.InputInfo = this.InputInfo.Clone();
            card.Oper = this.Oper.Clone();

            return card;
        }

        #endregion
    }
}
