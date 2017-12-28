using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Models.Nurse
{
    /// <summary>
    /// [功能描述: 注射信息主表]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2007/08/17]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// ID注射流水号     
    /// </summary>
    /// 
    [System.Serializable]
    public class InjectInfo : Neusoft.FrameWork.Models.NeuObject
    {
        public InjectInfo()
        {
        }

        #region private

        /// <summary>
        /// 医嘱信息        
        /// </summary>
        private Neusoft.HISFC.Models.Order.OutPatient.Order order = new Neusoft.HISFC.Models.Order.OutPatient.Order();

        private DateTime precontractDate;

        private string precontractOrder;

        private string injectType;

        private string injectTypeNumber;

        private EnumInjectSateService injectState;

        private Neusoft.HISFC.Models.Base.OperEnvironment operEnv = new Neusoft.HISFC.Models.Base.OperEnvironment();

        private Neusoft.FrameWork.Models.NeuObject quality = new Neusoft.FrameWork.Models.NeuObject();

        private Neusoft.FrameWork.Models.NeuObject dosage = new Neusoft.FrameWork.Models.NeuObject();

        private decimal baseDose;

        private bool isMainDrug;

        private int glassNumber;

        private string extend1;
        private string extend2;
        private string extend3;

        #endregion

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

        public string Extend3
        {
            get
            {
                return this.extend3;
            }
            set
            {
                this.extend3 = value;
            }
        }

        /// <summary>
        /// 分瓶数量
        /// </summary>
        public int GlassNum
        {
            get
            {
                return this.glassNumber;
            }
            set
            {
                this.glassNumber = value;
            }
        }

        /// <summary>
        /// 是否主药
        /// </summary>
        public bool IsMainDrug
        {
            get
            {
                return this.isMainDrug;
            }
            set
            {
                this.isMainDrug = value;
            }
        }

        /// <summary>
        /// 基本剂量
        /// </summary>
        public decimal BaseDose
        {
            get
            {
                return this.baseDose;
            }
            set
            {
                this.baseDose = value;
            }
        }

        /// <summary>
        /// 基本剂型
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dosage
        {
            get
            {
                return this.dosage;
            }
            set
            {
                this.dosage = value;
            }
        }

        /// <summary>
        /// 药品性质
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Quality
        {
            get
            {
                return this.quality;
            }
            set
            {
                this.quality = value;
            }
        }

        /// <summary>
        /// 医嘱信息
        /// </summary>
        public Neusoft.HISFC.Models.Order.OutPatient.Order Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }

        /// <summary>
        /// 预约注射日期
        /// </summary>
        public DateTime PrecontractDate
        {
            get
            {
                return this.precontractDate;
            }
            set
            {
                this.precontractDate = value;
            }
        }

        /// <summary>
        /// 预约注射序号
        /// </summary>
        public string PrecontractOrder
        {
            get
            {
                return this.precontractOrder;
            }
            set
            {
                this.precontractOrder = value;
            }
        }

        /// <summary>
        /// 注射类型
        /// </summary>
        public string InjectType
        {
            get
            {
                return this.injectType;
            }
            set
            {
                this.injectType = value;
            }
        }

        /// <summary>
        /// 注射类型序号
        /// </summary>
        public string InjectTypeNumber
        {
            get
            {
                return this.injectTypeNumber;
            }
            set
            {
                this.injectTypeNumber = value;
            }
        }

        /// <summary>
        /// 注射状态         
        /// </summary>
        public EnumInjectSateService InjectState
        {
            get
            {
                return this.injectState;
            }
            set
            {
                this.injectState = value;
            }
        }


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
        /// 复制对象
        /// </summary>
        /// <returns>注射信息实体</returns>
        public new InjectInfo Clone()
        {
            InjectInfo ii = base.Clone() as InjectInfo;
            ii.order = this.order.Clone();
            ii.operEnv = this.operEnv.Clone();
            ii.quality = this.quality.Clone();
            ii.dosage = this.dosage.Clone();

            return ii;
        }
    }

    /// <summary>
    /// 枚举服务
    /// </summary>
    public class EnumInjectSateService : Neusoft.HISFC.Models.Base.EnumServiceBase
    {
        static EnumInjectSateService()
        {
            itemCollection[EnumInjectState.PRECONTRACT] = "0";
            itemCollection[EnumInjectState.DOSAGE] = "1";
            itemCollection[EnumInjectState.INJECT] = "2";
            itemCollection[EnumInjectState.CANCEL] = "3";
        }

        EnumInjectState injectState = EnumInjectState.PRECONTRACT;

        /// <summary>
        /// 存贮枚举ID
        /// </summary>
        protected static Hashtable itemCollection = new Hashtable();

        protected override System.Enum EnumItem
        {
            get
            {
                return this.injectState;
            }
        }

        protected override System.Collections.Hashtable Items
        {
            get
            {
                return itemCollection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new static ArrayList List()
        {
            return (new ArrayList(GetObjectItems(itemCollection)));
        }

        /// <summary>
        /// 根据ID获取对应枚举类         
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public static EnumInjectState GetEnumFromID(string typeID)
        {
            return (EnumInjectState)(Enum.Parse(typeof(EnumInjectState), typeID));
        }

        /// <summary>
        /// 根据Name获取对应枚举类         
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static EnumInjectState GetEnumFromName(string typeName)
        {
            foreach (EnumInjectState inType in itemCollection.Keys)
            {
                if (itemCollection[inType].ToString() == typeName)
                {
                    return inType;
                }
            }

            return EnumInjectState.PRECONTRACT;
        }

        /// <summary>
        /// 根据枚举获取 
        /// </summary>
        /// <param name="inType"></param>
        /// <returns></returns>
        public static string GetNameFromEnum(EnumInjectState inType)
        {
            return itemCollection[inType].ToString();
        }
    }

    /// <summary>
    /// 患者注射状态     
    /// </summary>
    public enum EnumInjectState
    {
        /// <summary>
        /// 预约
        /// </summary>
        PRECONTRACT,
        /// <summary>
        /// 配药
        /// </summary>
        DOSAGE,
        /// <summary>
        /// 注射
        /// </summary>
        INJECT,
        /// <summary>
        /// 取消
        /// </summary>
        CANCEL
    }
}
