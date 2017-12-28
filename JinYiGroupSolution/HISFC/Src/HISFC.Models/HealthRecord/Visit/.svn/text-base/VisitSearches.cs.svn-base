using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.HealthRecord.Visit
{
    /// <summary>
    /// VisitSearches <br></br>
    /// [功能描述: 随访检索申请实体]<br></br>
    /// [创 建 者: 王立]<br></br>
    /// [创建时间: 2007-09-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class VisitSearches : Case.CaseInfo
    {
        #region 变量

        /// <summary>
        /// 申请环境(申请医生,申请时间)
        /// </summary>
        private HISFC.Models.Base.OperEnvironment doctorOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 医生导师,导师的电话存在字段User01中
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject teacher = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 检索内容（病种、年限、具体项目）
        /// </summary>
        private string searchesContent = "";

        /// <summary>
        /// 预约检索时间
        /// </summary>
        private DateTime bookingTime = DateTime.MinValue;
        
        /// <summary>
        /// 是否收费
        /// </summary>
        private bool isCharge = false;

        /// <summary>
        /// 收费金额
        /// </summary>
        private decimal chargeCost = 0m;

        /// <summary>
        /// 病种
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject illType = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 年限
        /// </summary>
        private decimal years = 0m;

        /// <summary>
        /// 项目
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject items = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 拷贝
        /// </summary>
        private string copy = "";

        /// <summary>
        /// 附加
        /// </summary>
        private string append = "";

        /// <summary>
        /// 申请状态
        /// </summary>
        private EnumSearchesState searchesState = new EnumSearchesState();

        /// <summary>
        /// 审核环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment auditingOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// 检索环境
        /// </summary>
        private HISFC.Models.Base.OperEnvironment searchesOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 信息科长意见环境,意见存到User01中
        /// </summary>
        private HISFC.Models.Base.OperEnvironment notionOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 申请环境(申请医生,申请时间)
        /// </summary>
        public HISFC.Models.Base.OperEnvironment DoctorOper
        {
            get 
            {
                return this.doctorOper; 
            }
            set
            { 
                this.doctorOper = value; 
            }
        }

        /// <summary>
        /// 医生导师,导师的电话存在字段User01中
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Teacher
        {
            get 
            {
                return this.teacher; 
            }
            set
            {
                this.teacher = value; 
            }
        }

        /// <summary>
        /// 检索内容（病种、年限、具体项目）
        /// </summary>
        public string SearchesContent
        {
            get 
            {
                return this.searchesContent; 
            }
            set
            {
                this.searchesContent = value; 
            }
        }

        /// <summary>
        /// 预约检索时间
        /// </summary>
        public DateTime BookingTime
        {
            get 
            {
                return this.bookingTime; 
            }
            set
            {
                this.bookingTime = value; 
            }
        }

        /// <summary>
        /// 是否收费
        /// </summary>
        public bool IsCharge
        {
            get 
            { 
                return this.isCharge; 
            }
            set 
            {
                this.isCharge = value; 
            }
        }

        /// <summary>
        /// 收费金额
        /// </summary>
        public decimal ChargeCost
        {
            get 
            { 
                return this.chargeCost; 
            }
            set 
            { 
                this.chargeCost = value; 
            }
        }

        /// <summary>
        /// 病种
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject IllType
        {
            get 
            { 
                return this.illType; 
            }
            set 
            { 
                this.illType = value; 
            }
        }


        /// <summary>
        /// 年限
        /// </summary>
        public decimal Years
        {
            get 
            { 
                return this.years; 
            }
            set 
            { 
                this.years = value; 
            }
        }


        /// <summary>
        /// 项目
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Items
        {
            get 
            { 
                return this.items; 
            }
            set 
            { 
                this.items = value; 
            }
        }

        /// <summary>
        /// 拷贝
        /// </summary>
        public string Copy
        {
            get 
            { 
                return this.copy; 
            }
            set 
            { 
                this.copy = value;
            }
        }

        /// <summary>
        /// 附加
        /// </summary>
        public string Append
        {
            get 
            { 
                return this.append; 
            }
            set 
            { 
                this.append = value;
            }
        }

        /// <summary>
        /// 申请状态
        /// </summary>
        public EnumSearchesState SearchesState
        {
            get 
            { 
                return this.searchesState; 
            }
            set 
            {
                this.searchesState = value; 
            }
        }

        /// <summary>
        /// 审核环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment AuditingOper
        {
            get 
            { 
                return this.auditingOper; 
            }
            set 
            { 
                this.auditingOper = value; 
            }
        }

        /// <summary>
        /// 检索环境
        /// </summary>
        public HISFC.Models.Base.OperEnvironment SearchesOper
        {
            get 
            { 
                return this.searchesOper; 
            }
            set 
            { 
                this.searchesOper = value; 
            }
        }

        /// <summary>
        /// 信息科长意见环境,意见存到User01中
        /// </summary>
        public HISFC.Models.Base.OperEnvironment NotionOper
        {
            get 
            { 
                return this.notionOper; 
            }
            set 
            { 
                this.notionOper = value; 
            }
        }

        #endregion

        #region 方法

        #region 克隆

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>随访检索申请实体</returns>
        public new VisitSearches Clone()
        {
            VisitSearches visitSearches = base.Clone() as VisitSearches;

            visitSearches.doctorOper = this.DoctorOper.Clone();
            visitSearches.teacher = this.Teacher.Clone();
            visitSearches.auditingOper = this.AuditingOper.Clone();
            visitSearches.searchesOper = this.SearchesOper.Clone();
            visitSearches.notionOper = this.NotionOper.Clone();

            return visitSearches;
        }

        #endregion

        #endregion
    }
}
