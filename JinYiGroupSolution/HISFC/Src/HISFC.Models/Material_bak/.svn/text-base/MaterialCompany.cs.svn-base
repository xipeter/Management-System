using System;

namespace Neusoft.HISFC.Object.Material
{
    /// <summary>
    /// [功能描述: 供货公司、生产厂家实体]
    /// [创 建 者: 李志涛]
    /// [创建时间: 2007-11-26].
    /// </summary>
    public class MaterialCompany : Neusoft.HISFC.Object.Base.Spell
    {
        public MaterialCompany()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region 变量

        /// <summary>
        /// 公司类别
        /// </summary>
        private string kind = string.Empty;

        /// <summary>
        /// 法人信息
        /// </summary>
        private string coporation = string.Empty;

        /// <summary>
        /// 公司地址
        /// </summary>
        private string address = string.Empty;

        /// <summary>
        /// 公司电话
        /// </summary>
        private string telCode = string.Empty;

        /// <summary>
        /// 传真
        /// </summary>
        private string faxCode = string.Empty;

        /// <summary>
        /// 网址
        /// </summary>
        private string netAddress = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        private string eMail = string.Empty;

        /// <summary>
        /// 联系人
        /// </summary>
        private string linkMan = string.Empty;

        /// <summary>
        /// 联系人邮箱
        /// </summary>
        private string linkMail = string.Empty;

        /// <summary>
        /// 联系人电话
        /// </summary>
        private string linkTel = string.Empty;

        /// <summary>
        /// Gmp信息
        /// </summary>
        private string gMPInfo = string.Empty;

        /// <summary>
        /// Gsp信息
        /// </summary>
        private string gSPInfo = string.Empty;

        /// <summary>
        /// ISO信息
        /// </summary>
        private string iSOInfo = string.Empty;

        /// <summary>
        /// 公司类型
        /// </summary>
        private string type = string.Empty;

        /// <summary>
        /// 开户银行
        /// </summary>
        private string openBank = string.Empty;

        /// <summary>
        /// 开户帐号
        /// </summary>
        private string openAccounts = string.Empty;

        /// <summary>
        /// 政策扣率
        /// </summary>
        private System.Decimal actualRate;

        /// <summary>
        /// 是否有效
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Neusoft.NFC.Object.NeuObject oper = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operTime;

        /// <summary>
        /// 扩展字段1
        /// </summary>
        private string extend1 = string.Empty;

        /// <summary>
        /// 扩展字段2
        /// </summary>
        private string extend2 = string.Empty;

        /// <summary>
        /// 营业执照到期时间
        /// </summary>
        private DateTime businessDate;
        /// <summary>
        /// 经营许可证有效期
        /// </summary>
        private DateTime manageDate;
        /// <summary>
        /// 税务登记证有效期
        /// </summary>
        private DateTime dutyDate;
        /// <summary>
        /// 组织机构代码证有效期
        /// </summary>
        private DateTime orgDate;


        #endregion

        #region 属性

        /// <summary>
        /// 公司类别：0-药库使用，1-物资程序使用
        /// </summary>
        public new string Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }

        public new string ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }


        /// <summary>
        /// 覆写Name
        /// </summary>
        public new string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }


        /// <summary>
        /// 企业法人
        /// </summary>
        public string Coporation
        {
            get
            {
                return this.coporation;
            }
            set
            {
                this.coporation = value;
            }
        }

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
        /// 公司电话
        /// </summary>
        public string TelCode
        {
            get
            {
                return this.telCode;
            }
            set
            {
                this.telCode = value;
            }
        }

        /// <summary>
        /// 传真
        /// </summary>
        public string FaxCode
        {
            get
            {
                return this.faxCode;
            }
            set
            {
                this.faxCode = value;
            }
        }

        /// <summary>
        /// 公司网址
        /// </summary>
        public string NetAddress
        {
            get
            {
                return this.netAddress;
            }
            set
            {
                this.netAddress = value;
            }
        }

        /// <summary>
        /// 公司邮箱
        /// </summary>
        public string EMail
        {
            get
            {
                return this.eMail;
            }
            set
            {
                this.eMail = value;
            }
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            get
            {
                return this.linkMan;
            }
            set
            {
                this.linkMan = value;
            }
        }

        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string LinkMail
        {
            get
            {
                return this.linkMail;
            }
            set
            {
                this.linkMail = value;
            }
        }

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LinkTel
        {
            get
            {
                return this.linkTel;
            }
            set
            {
                this.linkTel = value;
            }
        }

        /// <summary>
        /// GMP信息
        /// </summary>
        public string GMPInfo
        {
            get
            {
                return this.gMPInfo;
            }
            set
            {
                this.gMPInfo = value;
            }
        }

        /// <summary>
        /// GSP信息
        /// </summary>
        public string GSPInfo
        {
            get
            {
                return this.gSPInfo;
            }
            set
            {
                this.gSPInfo = value;
            }
        }

        /// <summary>
        /// ISO信息
        /// </summary>
        public string ISOInfo
        {
            get
            {
                return this.iSOInfo;
            }
            set
            {
                this.iSOInfo = value;
            }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string SpCode
        {
            get
            {
                return base.SpellCode;
            }
            set
            {
                base.SpellCode = value;
            }
        }

        /// <summary>
        /// 五笔码
        /// </summary>
        public string WbCode
        {
            get
            {
                return base.WBCode;
            }
            set
            {
                base.WBCode = value;
            }
        }

        /// <summary>
        /// 自定义码
        /// </summary>
        public string CustCode
        {
            get
            {
                return base.UserCode;
            }
            set
            {
                base.UserCode = value;
            }
        }

        /// <summary>
        /// 公司类别：0－生产厂家，1－供销商
        /// </summary>
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// 开户银行
        /// </summary>
        public string OpenBank
        {
            get
            {
                return this.openBank;
            }
            set
            {
                this.openBank = value;
            }
        }

        /// <summary>
        /// 开户账号
        /// </summary>
        public string OpenAccounts
        {
            get
            {
                return this.openAccounts;
            }
            set
            {
                this.openAccounts = value;
            }
        }

        /// <summary>
        /// 政策扣率
        /// </summary>
        public System.Decimal ActualRate
        {
            get
            {
                return this.actualRate;
            }
            set
            {
                this.actualRate = value;
            }
        }

        /// <summary>
        /// 是否有效
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

        /// <summary>
        /// 操作员信息
        /// </summary>
        public Neusoft.NFC.Object.NeuObject Oper
        {
            get
            {
                return this.oper;
            }
            set
            {
                this.oper = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public System.DateTime OperTime
        {
            get
            {
                return this.operTime;
            }
            set
            {
                this.operTime = value;
            }
        }


        /// <summary>
        /// 预留字段1
        /// </summary>
        public string Extend1
        {
            get
            {
                return this.extend1;
            }
            set
            {
                this.extend1 = value;
            }
        }

        /// <summary>
        /// 预留字段2
        /// </summary>
        public string Extend2
        {
            get
            {
                return this.extend2;
            }
            set
            {
                this.extend2 = value;
            }
        }

        /// <summary>
        /// 营业执照到期时间
        /// </summary>
        public DateTime BusinessDate
        {
            get
            {
                return this.businessDate;
            }
            set
            {
                this.businessDate = value;
            }
        }

        /// <summary>
        /// 经营许可证到期时间
        /// </summary>
        public DateTime ManageDate
        {
            get
            {
                return this.manageDate;
            }
            set
            {
                this.manageDate = value;
            }
        }

        /// <summary>
        /// 税务登记证到期时间
        /// </summary>
        public DateTime DutyDate
        {
            get
            {
                return this.dutyDate;
            }
            set
            {
                this.dutyDate = value;
            }
        }

        /// <summary>
        /// 组织机构代码证到期时间
        /// </summary>
        public DateTime OrgDate
        {
            get
            {
                return this.orgDate;
            }
            set
            {
                this.orgDate = value;
            }
        }

        #endregion


        #region 方法

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>成功返回当前实例的克隆实体</returns>
        public new MaterialCompany Clone()
        {
            MaterialCompany company = base.Clone() as MaterialCompany;

            company.Oper = this.Oper.Clone();

            return company;
        }


        #endregion

        #region 接口实现

        ///// <summary>
        ///// 是否有效 true有效[1] false无效[0]
        ///// </summary>
        //public bool IsValid
        //{
        //    get
        //    {
        //        if (this.state.Equals("active"))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    set
        //    {
        //        if (value)
        //        {
        //            this.state = "active";
        //        }
        //        else
        //        {
        //            this.state = "terminated";
        //        }
        //    }
        //}

        #endregion
    }
}
