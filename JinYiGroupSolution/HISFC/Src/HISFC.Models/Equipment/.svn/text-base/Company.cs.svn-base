using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Company<br></br>
    /// [功能描述: 生产厂家、供货公司基类]<br></br>
    /// [创 建 者: 朱庆元]<br></br>
    /// [创建时间: 2007-10-11]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class Company : Spell, IValid
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Company()
        { 
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        /// <summary>
        /// 公司地址
        /// </summary>
        private string address;

        /// <summary>
        /// 联系方式
        /// </summary>
        private string contact;

        /// <summary>
        /// 开户银行

        /// </summary>
        private string bank;

        /// <summary>
        /// 开户账号

        /// </summary>
        private string accounts;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        /// <summary>
        /// 操作信息
        /// </summary>
        private OperEnvironment operInfo = new OperEnvironment();

        /// <summary>
        /// 有效状态

        /// </summary>
        private string state;

        /// <summary>
        /// 公司类型0厂家1供货商

        /// </summary>
        private NeuObject type = new NeuObject();

        /// <summary>
        /// 邮政编码
        /// </summary>
        private string postalcode;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        private string email;

        /// <summary>
        /// 预交金额
        /// </summary>
        private decimal prepayCost;

        #endregion

        #region 属性

        
        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address
        {
            get 
            { 
                return this.address; 
            }
            set 
            { 
                this.address = value; 
            }
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact
        {
            get 
            { 
                return this.contact; 
            }
            set 
            { 
                this.contact = value; 
            }
        }

        /// <summary>
        /// 开户银行

        /// </summary>
        public string Bank
        {
            get
            {
                if (this.bank == null)
                    return "";
                else
                    return this.bank;
            }
            set
            {
                this.bank = value;
            }
        }

        /// <summary>
        /// 开户账号

        /// </summary>
        public string Accounts
        {
            get
            {
                return this.accounts;
            }
            set
            {
                this.accounts = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get 
            { 
                return this.remark; 
            }
            set 
            { 
                this.remark = value; 
            }
        }

        /// <summary>
        /// 状态

        /// </summary>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public OperEnvironment Oper
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
        /// 公司类型0厂家1供货商

        /// </summary>
        public NeuObject Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postalcode
        {
            get { return postalcode; }
            set { postalcode = value; }
        }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// 预交金额
        /// </summary>
        public decimal PrepayCost
        {
            get { return this.prepayCost; }
            set { this.prepayCost = value; }
        }

        #endregion

        #region 方法

        #region 克隆

        public new Company Clone()
        {
            
            Company company = base.Clone() as Company;

            company.operInfo = this.operInfo.Clone();

            company.type = this.type.Clone();

            return company;
        }

        #endregion

        #endregion

        #region 接口实现
        
        /// <summary>
        /// 是否有效 true有效[1] false无效[0]
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (this.state.Equals("active"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
 
            }
            set
            {
                if (value)
                {
                    this.state = "active";
                }
                else
                {
                    this.state = "terminated";
                }
            }
        }

        #endregion

    }
}
