using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Company<br></br>
    /// [功能描述: 进口信息基类]<br></br>
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
    public class ImportInfo : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public ImportInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 卡片流水号

        /// </summary>
        private string seqNo;

        /// <summary>
        /// 序号
        /// </summary>
        private int importSerialCode;
        
        /// <summary>
        /// 设备信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject equInfo = new Neusoft.FrameWork.Models.NeuObject();
        
        /// <summary>
        /// 英文名称
        /// </summary>
        private string englishName;
        
        /// <summary>
        /// 设备科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo = new Neusoft.FrameWork.Models.NeuObject();
        
        /// <summary>
        /// 购入公司编码
        /// </summary>
        private string companyCode;
        
        /// <summary>
        /// 贸易国别
        /// </summary>
        private string country;
        
        /// <summary>
        /// 购买货币类型
        /// </summary>
        private string moneyType;
        
        /// <summary>
        /// 购入金额
        /// </summary>
        private decimal buyCost;
        
        /// <summary>
        /// 外汇汇率
        /// </summary>
        private decimal exchangeRate;
        
        /// <summary>
        /// 外汇来源
        /// </summary>
        private string foreignSource;
        
        /// <summary>
        /// 批准文号
        /// </summary>
        private string approveInfo;
        
        /// <summary>
        /// 免税号

        /// </summary>
        private string dutyCode;
        
        /// <summary>
        /// 关税
        /// </summary>
        private decimal dutyCost;
        
        /// <summary>
        /// 是否有效1是0否

        /// </summary>
        private bool isValidFlag;
        
        /// <summary>
        /// 备注
        /// </summary>
        private string remark;
        
        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operInfo = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
        #endregion

        #region 属性


        /// <summary>
        /// 卡片流水号

        /// </summary>
        public string SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int ImportSerialCode
        {
            get { return importSerialCode; }
            set { importSerialCode = value; }
        }

        /// <summary>
        /// 设备信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject EquInfo
        {
            get { return equInfo; }
            set { equInfo = value; }
        }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName
        {
            get { return englishName; }
            set { englishName = value; }
        }

        /// <summary>
        /// 设备科室信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DeptInfo
        {
            get { return deptInfo; }
            set { deptInfo = value; }
        }

        /// <summary>
        /// 购入公司编码
        /// </summary>
        public string CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }

        /// <summary>
        /// 贸易国别
        /// </summary>
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        /// <summary>
        /// 购买货币类型
        /// </summary>
        public string MoneyType
        {
            get { return moneyType; }
            set { moneyType = value; }
        }

        /// <summary>
        /// 购入金额
        /// </summary>
        public decimal BuyCost
        {
            get { return buyCost; }
            set { buyCost = value; }
        }

        /// <summary>
        /// 外汇汇率
        /// </summary>
        public decimal ExchangeRate
        {
            get { return exchangeRate; }
            set { exchangeRate = value; }
        }

        /// <summary>
        /// 外汇来源
        /// </summary>
        public string ForeignSource
        {
            get { return foreignSource; }
            set { foreignSource = value; }
        }

        /// <summary>
        /// 批准文号
        /// </summary>
        public string ApproveInfo
        {
            get { return approveInfo; }
            set { approveInfo = value; }
        }

        /// <summary>
        /// 免税号

        /// </summary>
        public string DutyCode
        {
            get { return dutyCode; }
            set { dutyCode = value; }
        }

        /// <summary>
        /// 关税
        /// </summary>
        public decimal DutyCost
        {
            get { return dutyCost; }
            set { dutyCost = value; }
        }

        /// <summary>
        /// 是否有效1是0否

        /// </summary>
        public bool IsValidFlag
        {
            get { return isValidFlag; }
            set { isValidFlag = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperInfo
        {
            get { return operInfo; }
            set { operInfo = value; }
        } 

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new ImportInfo Clone()
        {
            ImportInfo importInfo = base.Clone() as ImportInfo;

            importInfo.equInfo = this.equInfo.Clone();
            importInfo.deptInfo = this.deptInfo.Clone();
            importInfo.operInfo = this.operInfo.Clone();

            return importInfo;
        }

        #endregion
    }
}

