using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 申请借用基类]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanApplyMain : Neusoft.NFC.Object.NeuObject, Neusoft.HISFC.Object.Base.IValidState
    {
        public SanApplyMain()
        {

        }

        #region 变量
        /// <summary>
        /// 申请流水号
        /// </summary>
        private string applyCode = string.Empty;

        /// <summary>
        /// 申请记录顺序号
        /// </summary>
        private decimal sortCode = 0;

        /// <summary>
        /// 申请单据号
        /// </summary>
        private string billCode = string.Empty;

        /// <summary>
        /// 申请标记1申请2审批3借用申请4借用审批5归还
        /// </summary>
        private Neusoft.HISFC.Object.Sanitize.QCApplyState applyState = QCApplyState.APPLY;

        /// <summary>
        /// 物品信息
        /// </summary>
        private HISFC.Object.Material.StoreBase storeBase = new Neusoft.HISFC.Object.Material.StoreBase();

        /// <summary>
        /// 借用期
        /// </summary>
        private decimal useDays = 0;

        /// <summary>
        /// 发放价格
        /// </summary>
        private decimal outPrice = 0;

        /// <summary>
        /// 申请人信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment applyOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 申请数量
        /// </summary>
        private decimal applyNum = 0;

        /// <summary>
        /// 审批人信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment appoveOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 审批数量
        /// </summary>
        private decimal appoveNum = 0;

        /// <summary>
        /// 归还人信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment returnOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 归还审批人信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment returnAPPOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 归还数量
        /// </summary>
        private decimal returnNum = 0;

        /// <summary>
        /// 是否有效1有效0停用
        /// </summary>
        private Neusoft.HISFC.Object.Base.EnumValidState validState = Neusoft.HISFC.Object.Base.EnumValidState.Valid;

        /// <summary>
        /// 停用人信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment stopOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 归还数量
        /// </summary>
        public decimal ReturnNum
        {
            get
            {
                return this.returnNum;
            }
            set
            {
                this.returnNum = value;
            }
        }

        /// <summary>
        /// 审批数量
        /// </summary>
        public decimal AppoveNum
        {
            get
            {
                return this.appoveNum;
            }
            set
            {
                this.appoveNum = value;
            }
        }

        /// <summary>
        /// 申请数量
        /// </summary>
        public decimal ApplyNum
        {
            get
            {
                return this.applyNum;
            }
            set
            {
                this.applyNum = value;
            }
        }

        /// <summary>
        /// 申请流水号
        /// </summary>
        public string ApplyCode
        {
            get
            {
                return this.applyCode;
            }
            set
            {
                this.applyCode = value;
            }
        }

        /// <summary>
        /// 申请记录顺序号
        /// </summary>
        public decimal SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        /// <summary>
        /// 申请单据号
        /// </summary>
        public string BillCode
        {
            get
            {
                return this.billCode;
            }
            set
            {
                this.billCode = value;
            }
        }

        /// <summary>
        /// 申请标记1申请2审批3借用申请4借用审批5归还
        /// </summary>
        public Neusoft.HISFC.Object.Sanitize.QCApplyState ApplyState
        {
            get
            {
                return this.applyState;
            }
            set
            {
                this.applyState = value;
            }
        }

        /// <summary>
        /// 物品信息
        /// </summary>
        public HISFC.Object.Material.StoreBase StoreBase
        {
            get
            {
                return this.storeBase;
            }
            set
            {
                this.storeBase = value;
            }
        }

        /// <summary>
        /// 借用期
        /// </summary>
        public decimal UseDays
        {
            get
            {
                return this.useDays;
            }
            set
            {
                this.useDays = value;
            }
        }

        /// <summary>
        /// 发放价格
        /// </summary>
        public decimal OutPrice
        {
            get
            {
                return this.outPrice;
            }
            set
            {
                this.outPrice = value;
            }
        }

        /// <summary>
        /// 申请人信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment ApplyOper
        {
            get
            {
                return this.applyOper;
            }
            set
            {
                this.applyOper = value;
            }
        }

        /// <summary>
        /// 审批人信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment AppoveOper
        {
            get
            {
                return this.appoveOper;
            }
            set
            {
                this.appoveOper = value;
            }
        }

        /// <summary>
        /// 归还人信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment ReturnOper
        {
            get
            {
                return this.returnOper;
            }
            set
            {
                this.returnOper = value;
            }
        }


        /// <summary>
        /// 停用人信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment StopOper
        {
            get
            {
                return this.stopOper;
            }
            set
            {
                this.stopOper = value;
            }
        }

        /// <summary>
        /// 归还审批人信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment ReturnAPPOper
        {
            get
            {
                return this.returnAPPOper;
            }
            set
            {
                this.returnAPPOper = value;
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
        /// 克隆函数实现
        /// </summary>
        /// <returns></returns>
        public new SanApplyMain Clone()
        {
            SanApplyMain sanApplyMain = base.Clone() as SanApplyMain;

            sanApplyMain.StoreBase = StoreBase.Clone();

            sanApplyMain.ApplyOper = ApplyOper.Clone();

            sanApplyMain.AppoveOper = AppoveOper.Clone();

            sanApplyMain.ReturnOper = ReturnOper.Clone();

            sanApplyMain.ReturnAPPOper = ReturnAPPOper.Clone();

            sanApplyMain.StopOper = StopOper.Clone();

            return sanApplyMain;
        }

        #endregion
    }
}
