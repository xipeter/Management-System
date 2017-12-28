using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Equipment
{
    /// <summary>
    /// Equipment<br></br>
    /// [功能描述: 设备帐目实体]<br></br>
    /// [创 建 者: 周全]<br></br>
    /// [创建时间: 2007-09-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class EquipAccount : Neusoft.NFC.Object.NeuObject
    {
        /// <summary>
        /// 设备帐目类
        /// </summary>
        public EquipAccount()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }

        #region 变量

        /// <summary>
        /// 设备帐目
        /// </summary>
        private Neusoft.NFC.Object.NeuObject item = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 科目分类
        /// </summary>
        private string kindCode;

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
        /// 规格
        /// </summary>
        private string specs;

        /// <summary>
        /// 单位
        /// </summary>
        private string unit;

        /// <summary>
        /// 购入价
        /// </summary>
        private float price;

        /// <summary>
        /// 状态
        /// </summary>
        private string state;

        /// <summary>
        /// 折旧方式
        /// </summary>
        private string deType;

        /// <summary>
        /// 折旧期限(月)
        /// </summary>
        private int deTeam;

        /// <summary>
        /// 是否需要计量
        /// </summary>
        private string measureFlag;

        /// <summary>
        /// 库存上限
        /// </summary>
        private float upLimit;

        /// <summary>
        /// 库存下限
        /// </summary>
        private float downLimit;

        /// <summary>
        /// 商标
        /// </summary>
        private string brand;

        /// <summary>
        /// 库房编码
        /// </summary>
        private string storageCode;

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
        /// 设备帐目
        /// </summary>
        public Neusoft.NFC.Object.NeuObject Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        /// <summary>
        /// 科目分类
        /// </summary>
        public string KindCode
        {
            get
            {
                return this.kindCode;
            }
            set
            {
                this.kindCode = value;
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
        /// 规格
        /// </summary>
        public string Specs
        {
            get
            {
                return this.specs;
            }
            set
            {
                this.specs = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        /// <summary>
        /// 购入价
        /// </summary>
        public float Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
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
        /// 折旧方式
        /// </summary>
        public string DeType
        {
            get
            {
                return this.deType;
            }
            set
            {
                this.deType = value; 
            }
        }

        /// <summary>
        /// 折旧期限(月)
        /// </summary>
        public int DeTeam
        {
            get
            {
                return this.deTeam;
            }
            set
            {
                this.deTeam = value;
            }
        }

        /// <summary>
        /// 是否需要计量
        /// </summary>
        public string MeasureFlag
        {
            get
            {
                return this.measureFlag;
            }
            set
            {
                this.measureFlag = value;
            }
        }

        /// <summary>
        /// 库存上限
        /// </summary>
        public float UpLimit
        {
            get
            {
                return this.upLimit;
            }
            set
            {
                this.upLimit = value;
            }
        }

        /// <summary>
        /// 库存下限
        /// </summary>
        public float DownLimit
        {
            get
            {
                return this.downLimit;
            }
            set
            {
                this.downLimit = value;
            }
        }

        /// <summary>
        /// 商标
        /// </summary>
        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                this.brand = value;
            }
        }

        /// <summary>
        /// 库房编码
        /// </summary>
        public string StorageCode
        {
            get
            {
                return this.storageCode;
            }
            set
            {
                this.storageCode = value;
            }
        }

        /// <summary>
        /// 操作员编码
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
        public new EquipAccount Clone()
        {
            EquipAccount equipAccount = base.Clone() as EquipAccount;

            equipAccount.Item = this.Item.Clone();
            equipAccount.Oper = this.Oper.Clone();

            return equipAccount;
        }

        #endregion
    }
}
