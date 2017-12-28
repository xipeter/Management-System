using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Account
{
    
    /// <summary>
    /// Neusoft.HISFC.Models.Account.AccountRecord<br></br>
    /// [功能描述: 门诊帐户卡操作实体]<br></br>
    /// [创 建 者: 路志鹏]<br></br>
    /// [创建时间: 2007-05-22]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class AccountCardRecord : Neusoft.FrameWork.Models.NeuObject
    {
        #region 变量
        /// <summary>
        /// 身份标识卡号
        /// </summary>
        private string markNO = string.Empty;
        /// <summary>
        /// 身份标识卡类别 1磁卡 2IC卡 3保障卡
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject markType = new Neusoft.FrameWork.Models.NeuObject();
        /// <summary>
        /// 门诊卡号
        /// </summary>
        private string cardNO = string.Empty;
        /// <summary>
        /// 卡操作类型
        /// </summary>
        private EnumMarkOperateTypesService operateTypes = new EnumMarkOperateTypesService();
        /// <summary>
        /// 操作环境实体
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 卡成本费
        /// </summary>
        private decimal cardMoney = 0m;
        #endregion

        #region 属性
        /// <summary>
        /// 身份标识卡号
        /// </summary>
        public string MarkNO
        {
            get
            {
                return markNO;
            }
            set
            {
                markNO = value;
            }
        }
        /// <summary>
        /// 身份标识卡类别 1磁卡 2IC卡 3保障卡
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject MarkType
        {
            get
            {
                return markType;
            }
            set
            {
                markType = value;
            }
        }
        /// <summary>
        /// 门诊卡号
        /// </summary>
        public string CardNO
        {
            get
            {
                return cardNO;
            }
            set
            {
                cardNO = value;
            }
        }

        /// <summary>
        /// 卡操作类型
        /// </summary>
        public EnumMarkOperateTypesService OperateTypes
        {
            get
            {
                return operateTypes;
            }
            set
            {
                operateTypes = value;
            }
        }

        /// <summary>
        /// 操作环境实体
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }

        /// <summary>
        /// 卡成本费
        /// </summary>
        public decimal CardMoney
        {
            get
            {
                return cardMoney;
            }
            set
            {
                cardMoney = value;
            }
        }
        #endregion

        #region 方法
        public new AccountCardRecord Clone()
        {
            AccountCardRecord obj = base.Clone() as AccountCardRecord;
            //obj.operateTypes = this.operateTypes.Clone() as EnumMarkOperateTypesService;
            //obj.markType = this.markType.Clone() as EnumMarkTypesService;
            obj.oper = this.oper.Clone();
            return obj;
        }
        #endregion
    }
}
