using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Blood
{
    [System.Serializable]
    public class StoreBase : Neusoft.FrameWork.Models.NeuObject 
    {
        public StoreBase()
        {

        }

        #region 变量

        /// <summary>
        /// 储血科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject storeDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 目标科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject targetDept = new Neusoft.FrameWork.Models.NeuObject();

        #endregion

        #region 属性

        /// <summary>
        /// 储血科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject StoreDept
        {
            get
            {
                return this.storeDept;
            }
            set
            {
                this.storeDept = value;
            }
        }

        /// <summary>
        /// 目标科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject TargetDept
        {
            get
            {
                return this.targetDept;
            }
            set
            {
                this.targetDept = value;
            }
        }


        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public StoreBase Clone()
        {
            StoreBase cloneStoreBase = base.Clone() as StoreBase;

            cloneStoreBase.StoreDept = this.storeDept.Clone();

            cloneStoreBase.TargetDept = this.targetDept.Clone();

            return cloneStoreBase;
        }

        #endregion
    }
}
