using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 患者库存管理实体]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11－22]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    [Serializable]
    public class PatientStore : Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PatientStore( )
        {

        }

        #region 变量

        /// <summary>
        /// 类型:0患者取整库存 1科室取整库存2病区取整库存;
        /// </summary>
        private string type = "";
        /// <summary>
        /// 库存数量
        /// </summary>
        private decimal storeQty;
        /// <summary>
        /// 药品信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item( );
        /// <summary>
        /// 有效期
        /// </summary>
        private DateTime validTime = new DateTime( );
        /// <summary>
        /// 患者基本信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject patientInfo = new Neusoft.FrameWork.Models.NeuObject( );
        /// <summary>
        /// 患者科室信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject inDept = new Neusoft.FrameWork.Models.NeuObject( );
        /// <summary>
        /// 是否记费
        /// </summary>
        private bool isCharge = false;
        /// <summary>
        /// 收费人员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment feeOper = new Neusoft.HISFC.Models.Base.OperEnvironment( );
        /// <summary>
        /// 操作人员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment( );
        /// <summary>
        /// 扩展字段
        /// </summary>
        private string extend = "";
        #endregion


        #region  属性

        /// <summary>
        /// 类型:0患者取整库存 1科室取整库存2病区取整库存;
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal StoreQty
        {
            get
            {
                return storeQty;
            }
            set
            {
                storeQty = value;
            }
        }

        /// <summary>
        /// 药品信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidTime
        {
            get
            {
                return validTime;
            }
            set
            {
                validTime = value;
            }
        }
        /// <summary>
        /// 患者基本信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject PatientInfo
        {
            get
            {
                return this.patientInfo;
            }
            set
            {
                this.patientInfo = value;
            }
        }
        /// <summary>
        /// 患者科室信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject InDept
        {
            get
            {
                return inDept;
            }
            set
            {
                inDept = value;
            }
        }
        /// <summary>
        /// 是否记费
        /// </summary>
        public bool IsCharge
        {
            get
            {
                return isCharge;
            }
            set
            {
                isCharge = value;
            }
        }
        /// <summary>
        /// 收费人信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment FeeOper
        {
            get
            {
                return feeOper;
            }
            set
            {
                feeOper = value;
            }
        }
        /// <summary>
        /// 操作员信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment Oper
        {
            get
            {
                return oper;
            }
            set
            {
                oper = value;
            }
        }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extend
        {
            get
            {
                return extend;
            }
            set
            {
                extend = value;
            }
        }
        #endregion


        #region 克隆

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns>成功返回克隆后的PatientStoreManager实体 失败返回null</returns>
        public new PatientStore Clone( )
        {
            PatientStore store = base.Clone( ) as PatientStore;
            store.feeOper = this.feeOper.Clone( );
            store.oper = this.oper.Clone( );
            store.inDept = this.inDept.Clone( );
            store.item = this.item.Clone( );
            store.patientInfo = this.patientInfo.Clone( );

            return store;
        }

        #endregion
    }
}
