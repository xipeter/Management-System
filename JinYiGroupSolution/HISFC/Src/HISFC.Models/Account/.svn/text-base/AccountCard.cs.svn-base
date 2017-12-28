using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Account
{
    /// <summary>
    /// Neusoft.HISFC.Models.Account.AccountCard<br></br>
    /// [功能描述: 门诊帐户卡实体]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2007-05-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class AccountCard :Neusoft.FrameWork.Models.NeuObject, Base.IValid
    {
       
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccountCard()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量
        ///// <summary>
        ///// 门诊病历
        ///// </summary>
        //private string cardNO = string.Empty;
        /// <summary>
        /// 患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 身份标识卡号
        /// </summary>
        private string markNO = string.Empty;
        /// <summary>
        /// 卡类型
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject markType = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid =true;

        /// <summary>
        /// 帐户卡操作实体
        /// </summary>
        private List< AccountCardRecord> accountCardRecord = new List<AccountCardRecord>();
        
        #endregion 

        #region 属性
        ///// <summary>
        ///// 门诊病历
        ///// </summary>
        //public string CardNO
        //{
        //    get
        //    {
        //        return this.cardNO;
        //    }
        //    set
        //    {
        //        this.cardNO = value;
        //    }
        //}
        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            set
            {
                patient = value;
            }
            get
            {
                return patient;
            }
        }

        /// <summary>
        /// 身份标识卡号
        /// </summary>
        public string MarkNO
        {
            get
            {
                return this.markNO;
            }
            set
            {
                this.markNO = value;
            }
        }
        /// <summary>
        /// 身份标识卡类别 1磁卡 2IC卡 3保障卡
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject MarkType
        {
            get
            {
                return this.markType;
            }
            set
            {
                this.markType = value;
            }
        }

        /// <summary>
        /// 门诊帐户卡操作实体
        /// </summary>
        public List<AccountCardRecord> AccountCardRecord
        {
            get
            {
                return this.accountCardRecord;
            }
            set
            {
                this.accountCardRecord = value;
            }
        }
       
        #endregion 

        #region 方法
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public new AccountCard Clone()
        {
            AccountCard accountCard = base.Clone() as AccountCard;
            accountCard.MarkType = this.MarkType.Clone() as Neusoft.FrameWork.Models.NeuObject;
            foreach (AccountCardRecord cardRecord in this.AccountCardRecord)
            {
                accountCard.AccountCardRecord.Add(cardRecord);
            }
            return accountCard;
        }
        #endregion

        #region IValid 成员
        /// <summary>
        /// 是否有效 true有效 false作废
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }

        #endregion

               

    }
}
