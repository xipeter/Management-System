using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Equipment
{
    /// <summary>
    /// Equipment<br></br>
    /// [功能描述: 科目分类实体]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007-09-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    /// 
    [System.Serializable]
    public class Kind : Neusoft.HISFC.Models.Base.Spell
    {
        /// <summary>
        /// 设备类
        /// </summary>
        public Kind()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region 变量

        /// <summary>
        /// 分类当前层号
        /// </summary>
        private string kindLevel;

        ///// <summary>
        ///// 科目分类信息
        ///// </summary>
        //private Neusoft.FrameWork.Models.NeuObject kindInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 上级编码(根的上级编码为0)
        /// </summary>
        private string preCode;

        /// <summary>
        /// 设备科室
        /// </summary>
        private NeuObject dept = new NeuObject();

        /// <summary>
        /// 国标码
        /// </summary>
        private string nationCode;

        /// <summary>
        /// 是否需要登记1是0否
        /// </summary>
        private string regFlag;

        /// <summary>
        /// 是否折旧1是0否
        /// </summary>
        private string deFlag;

        /// <summary>
        /// 是否末级1是0否
        /// </summary>
        private string leafFlag;

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private string validFlag;

        /// <summary>
        /// 顺序号
        /// </summary>
        private int orderNO;

        /// <summary>
        /// 财务科目
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject account = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 对应成本核算项目类别
        /// </summary>
        private string statCode;

        /// <summary>
        /// 备注
        /// </summary>
        private string mark;

        /// <summary>
        /// 操作环境信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 分类当前层号
        /// </summary>
        public string KindLevel
        {
            get
            {
                return this.kindLevel;
            }
            set
            {
                this.kindLevel = value;
            }
        }

        ///// <summary>
        ///// 科目分类信息
        ///// </summary>
        //public Neusoft.FrameWork.Models.NeuObject KindInfo
        //{
        //    get
        //    {
        //        return this.kindInfo;
        //    }
        //    set
        //    {
        //        this.kindInfo = value;
        //    }
        //}

        /// <summary>
        /// 上级编码(根的上级编码为0)
        /// </summary>
        public string PreCode
        {
            get
            {
                return this.preCode;
            }
            set
            {
                this.preCode = value;
            }
        }

        /// <summary>
        /// 设备科室
        /// </summary>
        public NeuObject Dept
        {
            get
            {
                return dept;
            }
            set
            {
                dept = value;
            }
        }

        /// <summary>
        /// 国标码
        /// </summary>
        public string NationCode
        {
            get
            {
                return this.nationCode;
            }
            set
            {
                this.nationCode = value;
            }
        }

        /// <summary>
        /// 是否需要登记1是0否
        /// </summary>
        public string RegFlag
        {
            get
            {
                return this.regFlag;
            }
            set
            {
                this.regFlag = value;
            }
        }

        /// <summary>
        /// 是否折旧1是0否
        /// </summary>
        public string DeFlag
        {
            get
            {
                return this.deFlag;
            }
            set
            {
                this.deFlag = value;
            }
        }

        /// <summary>
        /// 是否末级1是0否
        /// </summary>
        public string LeafFlag
        {
            get
            {
                return this.leafFlag;
            }
            set
            {
                this.leafFlag = value;
            }
        }

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        public string ValidFlag
        {
            get
            {
                return this.validFlag;
            }
            set
            {
                this.validFlag = value;
            }
        }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int OrderNO
        {
            get
            {
                return this.orderNO;
            }
            set
            {
                this.orderNO = value;
            }
        }

        /// <summary>
        /// 财务科目
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Account
        {
            get
            {
                return this.account;
            }
            set
            {
                this.account = value;
            }
        }

        /// <summary>
        /// 对应成本核算项目类别
        /// </summary>
        public string StatCode
        {
            get
            {
                return this.statCode;
            }
            set
            {
                this.statCode = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark
        {
            get
            {
                return this.mark;
            }
            set
            {
                this.mark = value;
            }
        }

        /// <summary>
        /// 操作环境信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
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

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new Kind Clone()
        {
            Kind kind = base.Clone() as Kind;

            //kind.KindInfo = this.KindInfo.Clone();
            kind.Account = this.Account.Clone();
            kind.Oper = this.Oper.Clone();

            return kind;
        }

        #endregion

    }
}
