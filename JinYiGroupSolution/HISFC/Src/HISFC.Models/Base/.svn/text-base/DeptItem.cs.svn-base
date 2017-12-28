using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// DeptItem <br></br>
    /// [功能描述: 科室常用项目]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006-12-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [System.Serializable]
    public class DeptItem :  Spell, IValid
    {
        /// <summary>
        /// 构构函数
        /// </summary>
        public DeptItem()
        {
        }

        #region 私有成员

        /// <summary>
        /// 项目基类
        /// </summary>
        private Neusoft.HISFC.Models.Base.Item itemProperty = new Item();

        /// <summary>
        /// 科室信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.Department deptCode = new Department();


        /// <summary>
        /// 单位标识(1.明细   2.组套)
        /// </summary>
        private string unitFlag;

        /// <summary>
        /// 预约地
        /// </summary>
        private string bookLocate;

        /// <summary>
        /// 预约固定时间
        /// </summary>
        private string bookTime;

        /// <summary>
        /// 执行地点
        /// </summary>
        private string executeLocate;

        /// <summary>
        /// 取报告时间
        /// </summary>
        private string reportDate;

        /// <summary>
        /// 有创/无创  （0 有，1无）
        /// </summary>
        private string hurtFlag;

        /// <summary>
        /// 是否科内预约（ 0是，1否）
        /// </summary>
        private string selfBookFlag;

        /// <summary>
        /// 知情同意书  （0需要，1不需要）
        /// </summary>
        private string reasonableFlag;

        /// <summary>
        /// 所属专业
        /// </summary>
        private string speciality;

        /// <summary>
        /// 临床意义
        /// </summary>
        private string clinicMeaning;

        /// <summary>
        /// 标本
        /// </summary>
        private string sampleKind;

        /// <summary>
        /// 采样方法
        /// </summary>
        private string sampleWay;

        /// <summary>
        /// 标本单位
        /// </summary>
        private string sampleUnit;

        /// <summary>
        /// 标本量
        /// </summary>
        private decimal sampleQty;

        /// <summary>
        /// 容器
        /// </summary>
        private string sampleContainer;

        /// <summary>
        /// 正常值范围
        /// </summary>
        private string scope;

        /// <summary>
        /// 是否需要统计, 0-需要, 1-不需要
        /// </summary>
        private string ynStat;
        
        /// <summary>
        /// 是否自动预约, 0-需要, 1-不需要
        /// </summary>
        private string ynAutoBook;

        /// <summary>
        /// 一次项目执行所属时间
        /// </summary>
        private string itemTime;

        /// <summary>
        /// 操作员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new OperEnvironment();

        /// <summary>
        /// 项目是否有效
        /// </summary>
        private bool isValid;

    	/// <summary>
    	/// 科室自定义项目名称
    	/// </summary>
		private string customName = "";

        #endregion

        #region 属性

        /// <summary>
        /// 操作员信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment OperEnv
        {
            get
            {
                return this.operEnv;
            }
            set
            {
                this.operEnv = value;
            }
        }

        /// <summary>
        /// 项目属性
        /// </summary>
        public Neusoft.HISFC.Models.Base.Item ItemProperty
        {
            get
            {
                return this.itemProperty;
            }
            set
            {
                this.itemProperty = value;
            }
        }

        /// <summary>
        /// 科室信息,现在要用科室代码
        /// </summary>
        [Obsolete("已经过时，更改为Dept", true)]
        public Neusoft.HISFC.Models.Base.Department DeptCode
        {
            get
            {
                return this.deptCode;
            }
            set
            {
                this.deptCode = value;
            }
        }

    	/// <summary>
		/// 科室信息
    	/// </summary>
    	public Neusoft.HISFC.Models.Base.Department Dept
    	{
    		get
    		{
				return this.deptCode;
    		}
    		set
    		{
				this.deptCode = value;
    		}
    	}
    	
        /// <summary>
        /// 单位标识(1.明细   2.组套)
        /// </summary>
        public string UnitFlag
        {
            get
            {
                return this.unitFlag;
            }
            set
            {
                this.unitFlag = value;
            }
        }

        /// <summary>
        /// 预约地
        /// </summary>
        public string BookLocate
        {
            get
            {
                return this.bookLocate;
            }
            set
            {
                this.bookLocate = value;
            }
        }

        /// <summary>
        /// 预约固定时间
        /// </summary>
        public string BookTime
        {
            get
            {
                return this.bookTime;
            }
            set
            {
                this.bookTime = value;
            }
        }

        /// <summary>
        /// 执行地点
        /// </summary>
        public string ExecuteLocate
        {
            get
            {
                return this.executeLocate;
            }
            set
            {
                this.executeLocate = value;
            }
        }

        /// <summary>
        /// 取报告时间
        /// </summary>
        public string ReportDate
        {
            get
            {
                return this.reportDate;
            }
            set
            {
                this.reportDate = value;
            }
        }

        /// <summary>
        /// 有创/无创(0有,  1无)
        /// </summary>
        public string HurtFlag
        {
            get
            {
                return this.hurtFlag;
            }
            set
            {
                this.hurtFlag = value;
            }
        }

        /// <summary>
        /// 是否科内预约(0是,  1否)
        /// </summary>
        public string SelfBookFlag
        {
            get
            {
                return this.selfBookFlag;
            }
            set
            {
                this.selfBookFlag = value;
            }
        }

        /// <summary>
        /// 知情同意书(0需要, 1不需要)
        /// </summary>
        public string ReasonableFlag
        {
            get
            {
                return this.reasonableFlag;
            }
            set
            {
                this.reasonableFlag = value;
            }
        }

        /// <summary>
        /// 所属专业
        /// </summary>
        public string Speciality
        {
            get
            {
                return this.speciality;
            }
            set
            {
                this.speciality = value;
            }
        }

        /// <summary>
        /// 临床意义
        /// </summary>
        public string ClinicMeaning
        {
            get
            {
                return this.clinicMeaning;
            }
            set
            {
                this.clinicMeaning = value;
            }
        }

        /// <summary>
        /// 标本
        /// </summary>
        public string SampleKind
        {
            get
            {
                return this.sampleKind;
            }
            set
            {
                this.sampleKind = value;
            }
        }

        /// <summary>
        /// 采样方法
        /// </summary>
        public string SampleWay
        {
            get
            {
                return this.sampleWay;
            }
            set
            {
                this.sampleWay = value;
            }
        }

        /// <summary>
        /// 标本单位
        /// </summary>
        public string SampleUnit
        {
            get
            {
                return this.sampleUnit;
            }
            set
            {
                this.sampleUnit = value;
            }
        }

        /// <summary>
        /// 标本量
        /// </summary>
        public decimal SampleQty
        {
            get
            {
                return this.sampleQty;
            }
            set
            {
                this.sampleQty = value;
            }
        }

        /// <summary>
        /// 标本容器
        /// </summary>
        public string SampleContainer
        {
            get
            {
                return this.sampleContainer;
            }
            set
            {
                this.sampleContainer = value;
            }
        }

        /// <summary>
        /// 正常值范围
        /// </summary>
        public string Scope
        {
            get
            {
                return this.scope;
            }
            set
            {
                this.scope = value;
            }
        }
        
        /// <summary>
        /// 一次项目执行所属时间
        /// </summary>
        public string ItemTime
        {
            get
            {
                return this.itemTime;
            }
            set
            {
                this.itemTime = value;
            }
        }

        /// <summary>
        /// 是否自动预约, 0-需要, 1-不需要
        /// </summary>
        public string IsAutoBook
        {
            get
            {
                return this.ynAutoBook;
            }
            set
            {
                this.ynAutoBook = value;
            }
        }

        /// <summary>
        /// 是否需要统计, 0-需要, 1-不需要
        /// </summary>
        public string IsStat
        {
            get
            {
                return this.ynStat;
            }
            set
            {
                this.ynStat = value;
            }
        }
        
    	/// <summary>
		/// 科室自定义项目名称
    	/// </summary>
    	public string CustomName
    	{
    		get
    		{
				return this.customName;
    		}
    		set
    		{
				this.customName = value;
    		}
    	}

        #endregion

        #region 克隆对象

        public new DeptItem Clone()
        {
            DeptItem di = base.Clone() as DeptItem;
            di.itemProperty = this.itemProperty.Clone();
            return di;
        }

        #endregion

        #region IValid 成员

        public bool IsValid
        {
            get
            {
                return this.isValid;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                this.isValid = value;
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}