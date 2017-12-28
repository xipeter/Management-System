using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// Const<br></br>
    /// [功能描述: 变更字段类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    [System.Serializable]
    public class ShiftProperty : Neusoft.FrameWork.Models.NeuObject
    {
        public ShiftProperty()
        {

        }

        #region 域变量

        /// <summary>
        /// 类全称 命名空间
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject reflectType = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 需记录变更属性
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject property = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 属性描述
        /// </summary>
        private string propertyDescription;

        /// <summary>
        /// 是否记录变更
        /// </summary>
        private bool isRecord = false;

        /// <summary>
        /// 变更原因
        /// </summary>
        private string shiftCause;

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 所属类全称 命名空间
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ReflectClass
        {
            get
            {
                return reflectType;
            }
            set
            {
                reflectType = value;

                if (value != null)
                {
                    base.ID = value.ID;
                    base.Name = value.Name;
                }
            }
        }

        /// <summary>
        /// 需记录变更属性
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Property
        {
            get
            {
                return this.property;
            }
            set
            {
                this.property = value;
            }
        }

        /// <summary>
        /// 属性描述
        /// </summary>
        public string PropertyDescription
        {
            get
            {
                return this.propertyDescription;
            }
            set
            {
                this.propertyDescription = value;
            }
        }

        /// <summary>
        /// 是否记录变更
        /// </summary>
        public bool IsRecord
        {
            get
            {
                return this.isRecord;
            }
            set
            {
                this.isRecord = value;
            }
        }

        /// <summary>
        /// 变更原因
        /// </summary>
        public string ShiftCause
        {
            get
            {
                return this.shiftCause;
            }
            set
            {
                this.shiftCause = value;
            }
        }

        /// <summary>
        /// 操作信息
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
        /// <returns></returns>
        public new ShiftProperty Clone()
        {
            ShiftProperty sf = base.Clone() as ShiftProperty;

            sf.reflectType = reflectType.Clone();

            sf.property = property.Clone();

            sf.oper = oper.Clone();

            return sf;
        }

        #endregion
    }
}
