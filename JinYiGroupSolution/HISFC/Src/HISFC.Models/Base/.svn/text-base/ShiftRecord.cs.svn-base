using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Base
{
    /// <summary>
    /// Const<br></br>
    /// [功能描述: 信息变更记录类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// 
    /// <说明 >ID 项目编码</说明>
    /// </summary>
    [System.Serializable]
    public class ShiftRecord : Neusoft.FrameWork.Models.NeuObject
    {
        public ShiftRecord()
        {

        }

        #region 域变量

        /// <summary>
        /// 发生序号
        /// </summary>
        private decimal happenNO;

        /// <summary>
        /// 项目类别 0 药品 1 非药品 2 保留
        /// </summary>
        private string itemType;

        /// <summary>
        /// 原始数据
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject originalData = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 新数据
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject newData = new Neusoft.FrameWork.Models.NeuObject();

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
        /// 发生序号
        /// </summary>
        public decimal HappenNO
        {
            get
            {
                return this.happenNO;
            }
            set
            {
                this.happenNO = value;
            }
        }

        /// <summary>
        /// 项目类别 0 药品 1 非药品 2 保留
        /// </summary>
        public string ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }

        /// <summary>
        /// 原始数据
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject OriginalData
        {
            get
            {
                return this.originalData;
            }
            set
            {
                this.originalData = value;
            }
        }

        /// <summary>
        /// 新数据
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NewData
        {
            get
            {
                return this.newData;
            }
            set
            {
                this.newData = value;
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
        public new ShiftRecord Clone()
        {
            ShiftRecord sfRecord = base.Clone() as ShiftRecord;

            sfRecord.originalData = this.originalData.Clone();

            sfRecord.newData = this.newData.Clone();

            sfRecord.oper = this.oper.Clone();

            return sfRecord;
        }

        #endregion
    }
}
