using System;

namespace Neusoft.HISFC.Object.Equipment
{
    /// <summary>
    /// Equipment<br></br>
    /// [功能描述: 设备实体]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007-09-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Equipment : Neusoft.NFC.Object.NeuObject
    {
        /// <summary>
        /// 设备类
        /// </summary>
        public Equipment()
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

        /// <summary>
        /// 设备分类
        /// </summary>
        private Neusoft.NFC.Object.NeuObject kind = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 上级编码(根的上级编码为0)
        /// </summary>
        private string preCode;

        /// <summary>
        /// 国标码
        /// </summary>
        private string nationCode;

        /// <summary>
        /// 拼音码
        /// </summary>
        private string spellCode;
        
        /// <summary>
        /// 五笔码
        /// </summary>
        private string wbCode;

        /// <summary>
        /// 自定义码
        /// </summary>
        private string userCode;

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
        private Neusoft.NFC.Object.NeuObject account = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 对应成本核算项目类别
        /// </summary>
        private string statCode;

        /// <summary>
        /// 备注
        /// </summary>
        private string mark;

        /// <summary>
        /// 操作员编码
        /// </summary>
        private Neusoft.NFC.Object.NeuObject oper = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime operDate;

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

        /// <summary>
        /// 设备分类
        /// </summary>
        public Neusoft.NFC.Object.NeuObject Kind
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
        /// 拼音码
        /// </summary>
        public string SpellCode
        {
            get
            {
                return this.spellCode;
            }
            set
            {
                this.spellCode = value;
            }
        }

        /// <summary>
        /// 五笔码
        /// </summary>
        public string WbCode
        {
            get
            {
                return this.wbCode;
            }
            set
            {
                this.wbCode = value;
            }
        }

        /// <summary>
        /// 自定义码
        /// </summary>
        public string UserCode
        {
            get
            {
                return this.userCode;
            }
            set
            {
                this.userCode = value;
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
        public Neusoft.NFC.Object.NeuObject Account
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
        /// 操作员
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
        public DateTime OperDate
        {
            get
            {
                return this.operDate;
            }
            set
            {
                this.operDate = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns>返回当前对象的实例副本</returns>
        public new Equipment Clone()
        {
            Equipment equipment = base.Clone() as Equipment;

            equipment.Kind = this.Kind.Clone();
            equipment.Account = this.Account.Clone();
            equipment.Oper = this.Oper.Clone();

            return equipment;
        }

        #endregion

    }
}
