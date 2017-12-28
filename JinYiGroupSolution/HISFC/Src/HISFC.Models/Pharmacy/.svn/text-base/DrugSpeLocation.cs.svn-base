using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品特定位置类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-11]<br></br>
    /// <说明>
    ///     1、  ID 取药药房 Name 取药药房名称
    /// </说明>
    /// </summary>
    [Serializable]
    public class DrugSpeLocation : Neusoft.FrameWork.Models.NeuObject
    {
        public DrugSpeLocation()
        {

        }

        #region 域变量

        /// <summary>
        /// 特定药品
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item item = new Item();

        /// <summary>
        /// 取药病区
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject roomDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 特定药品
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.Item Item
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
        /// 取药病区
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject RoomDept
        {
            get
            {
                return this.roomDept;
            }
            set
            {
                this.roomDept = value;
            }
        }

        /// <summary>
        /// 操作员
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
        public new DrugSpeLocation Clone()
        {
            DrugSpeLocation dr = base.Clone() as DrugSpeLocation;

            dr.item = this.item.Clone();
            dr.roomDept = this.roomDept.Clone();
            dr.oper = this.oper.Clone();

            return dr;
        }

        #endregion
    }
}
