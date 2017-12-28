using System;
using System.Collections.Generic;
using System.Text;


namespace Neusoft.HISFC.Models.HealthRecord.Case
{
    /// <summary>
    /// [功能描述: 病历借阅查询登记]<br></br>
    /// [创 建 者: 蒋飞]<br></br>
    /// [创建时间: 2007/08/24]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class CaseLend : CaseInfo
    {
        public CaseLend()
        {
        }

        #region 变量

        /// <summary>
        /// 业务类型
        /// </summary>
        private EnumLendType lendType;

        /// <summary>
        /// 借阅查阅人
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee lendEmpl = new Neusoft.HISFC.Models.Base.Employee();

        /// <summary>
        /// 借阅起始时间  
        /// </summary>
        private DateTime startingTime;

        /// <summary>
        /// 借阅截止时间  
        /// </summary>
        private DateTime endTime;

        /// <summary>
        /// 是否借阅审核
        /// </summary>
        private bool isAuditing;

        /// <summary>
        /// 借阅审核信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment auditingOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 是否已经归还
        /// </summary>
        private bool isReturn;

        /// <summary>
        /// 借阅查阅人归还操作环境
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment returnOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 借阅归还确认
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment returnConfirmOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 业务类型
        /// </summary>   
        public EnumLendType LendType
        {
            get
            {
                return lendType;
            }
            set
            {
                lendType = value;
            }
        }

        /// <summary>
        /// 借阅查阅人
        /// </summary>
        public Neusoft.HISFC.Models.Base.Employee LendEmpl
        {
            get
            {
                return lendEmpl;
            }
            set
            {
                lendEmpl = value;
            }
        }

        /// <summary>
        /// 借阅起始时间  
        /// </summary>     
        public DateTime StartingTime
        {
            get
            {
                return startingTime;
            }
            set
            {
                startingTime = value;
            }
        }

        /// <summary>
        /// 借阅截止时间  
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        /// <summary>
        /// 是否出库审核
        /// </summary>
        public bool IsAuditing
        {
            get
            {
                return isAuditing;
            }
            set
            {
                isAuditing = value;
            }
        }

        /// <summary>
        /// 出库审核信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment AuditingOper
        {
            get
            {
                return auditingOper;
            }
            set
            {
                auditingOper = value;
            }
        }
             
        /// <summary>
        /// 是否已经归还
        /// </summary>
        public bool IsReturn
        {
            get
            {
                return isReturn;
            }
            set
            {
                isReturn = value;
            }
        }

        /// <summary>
        /// 借阅查阅人归还操作环境
        /// </summary>   
        public Neusoft.HISFC.Models.Base.OperEnvironment ReturnOper
        {
            get
            {
                return returnOper;
            }
            set
            {
                returnOper = value;
            }
        }

        /// <summary>
        /// 借阅归还确认操作环境
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment ReturnConfirmOper
        {
            get
            {
                return returnConfirmOper;
            }
            set
            {
                returnConfirmOper = value;
            }
        }

        #endregion

        #region 方法

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>病历查询借阅主记录</returns>
        public new CaseLend Clone()
        {
            CaseLend caseLend = base.Clone() as CaseLend;

            caseLend.AuditingOper = this.AuditingOper.Clone();
            caseLend.LendEmpl = this.LendEmpl.Clone();
            caseLend.ReturnConfirmOper = this.ReturnConfirmOper.Clone();
            caseLend.ReturnOper = this.ReturnOper.Clone();

            return caseLend;
        }

        #endregion

        #endregion
    }



}
