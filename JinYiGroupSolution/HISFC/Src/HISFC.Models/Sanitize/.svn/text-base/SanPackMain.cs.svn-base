using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Object.Sanitize
{
    /// <summary>
    /// [功能描述: 打包管理Base]<br></br>
    /// [创 建 者: shizj]<br></br>
    /// [创建时间: 2008-08]<br></br>
    /// </summary>
    public class SanPackMain : Neusoft.NFC.Object.NeuObject
    {
        public SanPackMain()
        {

        }

        #region 变量

        /// <summary>
        /// 包主表流水号
        /// </summary>
        private string packCode = string.Empty;

        /// <summary>
        /// 打包批号(年月日+4位数字)
        /// </summary>
        private string batchNo = string.Empty;

        /// <summary>
        /// 顺序号
        /// </summary>
        private int sortNum = 0;

        /// <summary>
        /// 单据号(默认年月日+4位数字)
        /// </summary>
        private string billCode = string.Empty;

        /// <summary>
        /// 物品信息
        /// </summary>
        private Neusoft.HISFC.Object.Material.StoreBase storeBase = new Neusoft.HISFC.Object.Material.StoreBase();

        /// <summary>
        /// 入库数量
        /// </summary>
        private decimal inNum = 0;

        /// <summary>
        /// 入库科室
        /// </summary>
        private string inDept = string.Empty;

        /// <summary>
        /// 有效日期(截止日期)
        /// </summary>
        private System.DateTime validDate;

        /// <summary>
        /// 是否管理消毒1是0否
        /// </summary>
        private bool sterFlag = false;

        /// <summary>
        /// 操作人信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment oper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        /// <summary>
        /// 是否拆包
        /// </summary>
        private bool unPackFlag = false;

        /// <summary>
        /// 入库表主键
        /// </summary>
        private string inNo = string.Empty;

        /// <summary>
        /// 拆包人信息
        /// </summary>
        private Neusoft.HISFC.Object.Base.OperEnvironment unPackOper = new Neusoft.HISFC.Object.Base.OperEnvironment();

        #endregion

        #region 属性

        /// <summary>
        /// 包主表流水号
        /// </summary>
        public string PackCode
        {
            get
            {
                return this.packCode;
            }
            set
            {
                this.packCode = value;
            }
        }

        /// <summary>
        /// 打包批号(年月日+4位数字)
        /// </summary>
        public string BatchNo
        {
            get
            {
                return this.batchNo;
            }
            set
            {
                this.batchNo = value;
            }
        }

        /// <summary>
        /// 顺序号
        /// </summary>
        public int SortNum
        {
            get
            {
                return this.sortNum;
            }
            set
            {
                this.sortNum = value;
            }
        }

        /// <summary>
        /// 单据号(默认年月日+4位数字)
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
        /// 物品信息
        /// </summary>
        public Neusoft.HISFC.Object.Material.StoreBase StoreBase
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
        /// 入库数量
        /// </summary>
        public decimal InNum
        {
            get
            {
                return this.inNum;
            }
            set
            {
                this.inNum = value;
            }
        }

        /// <summary>
        /// 入库科室
        /// </summary>
        public string InDept
        {
            get
            {
                return this.inDept;
            }
            set
            {
                this.inDept = value;
            }
        }

        /// <summary>
        /// 有效日期(截止日期)
        /// </summary>
        public System.DateTime ValidDate
        {
            get
            {
                return this.validDate;
            }
            set
            {
                this.validDate = value;
            }
        }

        /// <summary>
        /// 是否管理消毒1是0否
        /// </summary>
        public bool SterFlag
        {
            get
            {
                return this.sterFlag;
            }
            set
            {
                this.sterFlag = value;
            }
        }

        /// <summary>
        /// 操作人信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment Oper
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
        /// 是否拆包
        /// </summary>
        public bool UnPackFlag
        {
            get
            {
                return this.unPackFlag;
            }
            set
            {
                this.unPackFlag = value;
            }
        }

        /// <summary>
        /// 拆包人信息
        /// </summary>
        public Neusoft.HISFC.Object.Base.OperEnvironment UnPackOper
        {
            get
            {
                return this.unPackOper;
            }
            set
            {
                this.unPackOper = value;
            }
        }


        /// <summary>
        /// 入库表主键
        /// </summary>
        public string InNo
        {
            get
            {
                return this.inNo;
            }
            set
            {
                this.inNo = value;
            }
        }

        #endregion

        #region 方法
        #region 克隆
        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public new SanPackMain Clone()
        {
            SanPackMain sanPackMain = base.Clone() as SanPackMain;

            sanPackMain.StoreBase = StoreBase.Clone();
            sanPackMain.Oper = Oper.Clone();

            return sanPackMain;
        }
        #endregion
        #endregion

    }
}
