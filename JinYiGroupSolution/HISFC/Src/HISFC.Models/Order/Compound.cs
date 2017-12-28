using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.Order
{
    /// <summary>
    /// [功能描述: 配液信息类 医嘱聚合]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>   
    /// </summary>
    [Serializable]
    public class Compound : Neusoft.FrameWork.Models.NeuObject
    {
        public Compound()
        {

        }

        #region 域变量

        /// <summary>
        /// 是否需要配液
        /// </summary>
        private bool isNeedCompound = false;

        /// <summary>
        /// 是否已执行
        /// </summary>
        private bool isExec = false;

        /// <summary>
        /// 操作人信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment compoundOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
        
        #endregion

        /// <summary>
        /// 是否需要配液
        /// </summary>
        public bool IsNeedCompound
        {
            get
            {
                return isNeedCompound;
            }
            set
            {
                isNeedCompound = value;
            }
        }

        /// <summary>
        /// 是否已执行
        /// </summary>
        public bool IsExec
        {
            get
            {
                return isExec;
            }
            set
            {
                isExec = value;
            }
        }

        /// <summary>
        /// 操作人信息
        /// </summary>
        public Neusoft.HISFC.Models.Base.OperEnvironment CompoundOper
        {
            get
            {
                return compoundOper;
            }
            set
            {
                compoundOper = value;
            }
        }

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>返回深克隆实体</returns>
        public new Compound Clone()
        {
            Compound compound = base.Clone() as Compound;

            compound.compoundOper = this.compoundOper.Clone();

            return compound;
        }
      

    }
}
