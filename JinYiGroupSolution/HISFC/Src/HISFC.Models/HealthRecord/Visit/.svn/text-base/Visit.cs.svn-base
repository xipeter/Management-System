using System;
using System.Collections.Generic;
using System.Text;


namespace Neusoft.HISFC.Models.HealthRecord.Visit
{
    /// <summary>
    /// Visit <br></br>
    /// [功能描述: 随访主记录]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-08-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class Visit : Case.CaseInfo
    {
        #region 变量

        /// <summary>
        /// 末次随访时间
        /// </summary>
        private DateTime lastVisitTime = DateTime.MinValue;
        
        
        
        /// <summary>
        /// 随访状态


        /// </summary>
        private EnumVisitState visitState = new EnumVisitState();

        /// <summary>
        /// 末次随访是否是被动随访

        /// </summary>
        private bool lastIsPassive = true;

        /// <summary>
        /// 末次随访使用的联系方式

        /// </summary>
        private Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkway = new LinkWay();

        

        #endregion

        #region 属性



        /// <summary>
        /// 末次随访时间
        /// </summary>
        public DateTime LastVisitTime
        {
            get
            {
                return this.lastVisitTime;
            }
            set
            {
                this.lastVisitTime = value;
            }
        }

        /// <summary>
        /// 末次随访使用的联系方式

        /// </summary>
        public Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay Linkway
        {
            get
            {
                return this.linkway;
            }
            set
            {
                this.linkway = value;
            }
        }

        /// <summary>
        /// 末次随访的邮政编码


        
        /// <summary>
        /// 随访状态


        /// </summary>
        public EnumVisitState VisitState
        {
            get
            {
                return this.visitState;
            }
            set
            {
                this.visitState = value;
            }
        }

        /// <summary>
        /// 末次随访是否是被动随访

        /// </summary>
        public bool LastIsPassive
        {
            get
            {
                return this.lastIsPassive;
            }
            set
            {
                this.lastIsPassive = value;
            }
        }

        #endregion

        #region 方法

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>随访主记录</returns>
        public new Visit Clone()
        {
            Visit visit = base.Clone() as Visit;

            //visit.LastVisitType = this.LastVisitType.Clone();
            visit.Linkway = this.Linkway.Clone();

            return visit;
        }

        #endregion

        #endregion


        #region 过时的


        /// <summary>
        /// 末次随访的邮政编码



        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        private string lastVisitZIP = "";

        /// <summary>
        /// 末次随访联系地址
        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        private string lastVisitAddress = "";

        /// <summary>
        /// 末次随访的联系电话


        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        private string lastVisitPhone = "";

        /// <summary>
        /// 末次随访的电子邮件


        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        private string lastVisitEMail = "";

        /// <summary>
        /// 末次随访其它联系方式
        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        private string lastOther = "";

        /// <summary>
        /// 末次随访的随访方式



        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        private Neusoft.HISFC.Models.Base.Const lastVisitType = new Neusoft.HISFC.Models.Base.Const();


        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        public string LastVisitZIP
        {
            get
            {
                return this.lastVisitZIP;
            }
            set
            {
                this.lastVisitZIP = value;
            }
        }

        /// <summary>
        /// 末次随访联系地址
        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        public string LastVisitAddress
        {
            get
            {
                return this.lastVisitAddress;
            }
            set
            {
                this.lastVisitAddress = value;
            }
        }

        /// <summary>
        /// 末次随访的联系电话



        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        public string LastVisitPhone
        {
            get
            {
                return this.lastVisitPhone;
            }
            set
            {
                this.lastVisitPhone = value;
            }
        }

        /// <summary>
        /// 末次随访的电子邮件



        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        public string LastVisitEMail
        {
            get
            {
                return this.lastVisitEMail;
            }
            set
            {
                this.lastVisitEMail = value;
            }
        }

        /// <summary>
        /// 末次随访其它联系方式
        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        public string LastOther
        {
            get
            {
                return this.lastOther;
            }
            set
            {
                this.lastOther = value;
            }
        }

        /// <summary>
        /// 末次随访的随访方式



        /// </summary>
        [Obsolete("使用Linkway相应的字段存！", true)]
        public Neusoft.HISFC.Models.Base.Const LastVisitType
        {
            get
            {
                return this.lastVisitType;
            }
            set
            {
                this.lastVisitType = value;
            }
        }


        #endregion
    }
}
