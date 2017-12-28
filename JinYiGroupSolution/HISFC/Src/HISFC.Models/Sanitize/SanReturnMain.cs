using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 物品回收类]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    /// 
    public class SanReturnMain : Neusoft.NFC.Object.NeuObject, Neusoft.HISFC.Object.Base.IValidState
    {
        public SanReturnMain()
        {

        }

        #region 变量
        /// <summary>
        /// 回收流水号
        /// </summary>
        private string returnCode = string.Empty;

        /// <summary>
        /// 回收记录顺序号
        /// </summary>
        private int sortNumber = 0;

        /// <summary>
        /// 回收单据号
        /// </summary>
        private string billCode = string.Empty;

        /// <summary>
        /// 回收状态1申请2收污确认3清洁确认4打包确认5领取确认
        /// </summary>
        private QCReturnState returnState = QCReturnState.APPLY;

        /// <summary>
        /// 物品信息
        /// </summary>
        private HISFC.Object.Material.StoreBase storeBase = new Neusoft.HISFC.Object.Material.StoreBase();

        /// <summary>
        /// 申请人员信息
        /// </summary>
        private HISFC.Object.Base.OperEnvironment applyOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 申请回收数量
        /// </summary>
        private decimal applyNum = 0;

        /// <summary>
        /// 收污人员信息
        /// </summary>
        private HISFC.Object.Base.OperEnvironment inOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 收污数量(实际收到数量)
        /// </summary>
        private decimal inNum = 0;

        /// <summary>
        /// 消毒人员信息
        /// </summary>
        private HISFC.Object.Base.OperEnvironment sterOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 是否消毒1是0否
        /// </summary>
        private bool sterFlag = false;

        /// <summary>
        /// 打包人员信息
        /// </summary>
        private HISFC.Object.Base.OperEnvironment packOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 打包数量
        /// </summary>
        private decimal packNum = 0;

        /// <summary>
        /// 领用人员信息
        /// </summary>
        private HISFC.Object.Base.OperEnvironment getOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 领用数量
        /// </summary>
        private decimal getNum = 0;

        /// <summary>
        /// 停用人员信息
        /// </summary>
        private HISFC.Object.Base.OperEnvironment stopOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private HISFC.Object.Base.EnumValidState validState = Neusoft.HISFC.Object.Base.EnumValidState.Valid; 
        #endregion

        #region 实例
        /// <summary>
        /// 回收流水号
        /// </summary>
        public string ReturnCode
        {
            get
            {
                return returnCode;
            }
            set
            {
                returnCode = value;
            }
        }

        /// <summary>
        /// 回收记录顺序号
        /// </summary>
        public int SortNumber
        {
            get
            {
                return sortNumber;
            }
            set
            {
                sortNumber = value;
            }
        }

        /// <summary>
        /// 回收单据号
        /// </summary>
        public string BillCode
        {
            get
            {
                return billCode;
            }
            set
            {
                billCode = value;
            }
        }

        /// <summary>
        /// 回收状态1申请2收污确认3清洁确认4打包确认5领取确认
        /// </summary>
        public QCReturnState ReturnState
        {
            get
            {
                return returnState;
            }
            set
            {
                returnState = value;
            }
        }

        /// <summary>
        /// 物品信息
        /// </summary>
        public HISFC.Object.Material.StoreBase StoreBase
        {
            get
            {
                return storeBase;
            }
            set
            {
                storeBase = value;
            }
        }

        /// <summary>
        /// 申请人员信息
        /// </summary>
        public HISFC.Object.Base.OperEnvironment ApplyOper
        {
            get
            {
                return applyOper;
            }
            set
            {
                applyOper = value;
            }
        }

        /// <summary>
        /// 申请数量
        /// </summary>
        public decimal ApplyNum
        {
            get
            {
                return applyNum;
            }
            set
            {
                applyNum = value;
            }
        }

        /// <summary>
        /// 收污人员信息
        /// </summary>
        public HISFC.Object.Base.OperEnvironment InOper
        {
            get
            {
                return inOper;
            }
            set
            {
                inOper = value;
            }
        }

        /// <summary>
        /// 收污数量(实际收到数量)
        /// </summary>
        public decimal InNum
        {
            get
            {
                return inNum;
            }
            set
            {
                inNum = value;
            }
        }

        /// <summary>
        ///清洁人员信息
        /// </summary>
        public HISFC.Object.Base.OperEnvironment SterOper
        {
            get
            {
                return sterOper;
            }
            set
            {
                sterOper = value;
            }
        }

        /// <summary>
        /// 是否消毒1是0否
        /// </summary>
        public bool SterFlag
        {
            get
            {
                return sterFlag;
            }
            set
            {
                sterFlag = value;
            }
        }

        /// <summary>
        /// 打包人员信息
        /// </summary>
        public HISFC.Object.Base.OperEnvironment PackOper
        {
            get
            {
                return packOper;
            }
            set
            {
                packOper = value;
            }
        }

        /// <summary>
        /// 打包数量
        /// </summary>
        public decimal PackNum
        {
            get
            {
                return packNum;
            }
            set
            {
                packNum = value;
            }
        }

        /// <summary>
        /// 领用人员信息
        /// </summary>
        public HISFC.Object.Base.OperEnvironment GetOper
        {
            get
            {
                return getOper;
            }
            set
            {
                getOper = value;
            }
        }

        /// <summary>
        /// 领用数量
        /// </summary>
        public decimal GetNum
        {
            get
            {
                return getNum;
            }
            set
            {
                getNum = value;
            }
        }

        /// <summary>
        /// 停用人员信息
        /// </summary>
        public HISFC.Object.Base.OperEnvironment StopOper
        {
            get
            {
                return stopOper;
            }
            set
            {
                stopOper = value;
            }
        }

        #region IValidState 成员
        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        public Neusoft.HISFC.Object.Base.EnumValidState ValidState
        {
            get
            {
                return this.validState;
            }
            set
            {
                this.validState = value;
            }
        }

        #endregion 
        #endregion

        #region 方法
        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public new SanReturnMain Clone()
        {
            SanReturnMain sanReturnMain = base.Clone() as SanReturnMain;

            sanReturnMain.StoreBase = this.StoreBase.Clone();

            sanReturnMain.ApplyOper = this.ApplyOper.Clone();

            sanReturnMain.InOper = this.InOper.Clone();

            sanReturnMain.ApplyOper = this.ApplyOper.Clone();

            sanReturnMain.SterOper = this.SterOper.Clone();

            sanReturnMain.PackOper = this.PackOper.Clone();

            sanReturnMain.GetOper = this.GetOper.Clone();

            sanReturnMain.StopOper = this.StopOper.Clone();

            return sanReturnMain;
        }

        #endregion
    }
}
