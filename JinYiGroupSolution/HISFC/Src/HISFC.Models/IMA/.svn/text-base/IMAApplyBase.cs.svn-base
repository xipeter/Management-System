using System;

namespace Neusoft.HISFC.Models.IMA
{
	/// <summary>
	/// [功能描述: 药品、物资库存申请基类 出、入库申请 皆由此继承]<br></br>
	/// [创 建 者: 梁俊泽]<br></br>
	/// [创建时间: 2006-09-12]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// 
	/// </summary>
    [Serializable]
    public class IMAApplyBase : IMABase,Base.IValidState
	{
		public IMAApplyBase()
		{
			
		}


		#region 变量

		/// <summary>
		/// 申请科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject applyDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 申请单号
		/// </summary>
		private string billCode;

        /// <summary>
        /// 有效性状态
        /// </summary>
        private Base.EnumValidState validState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;

		#endregion

		/// <summary>
		/// 申请科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject ApplyDept
		{
			get
			{
				return this.applyDept;
			}
			set
			{
				this.applyDept = value;
			}
		}

		/// <summary>
		/// 申请单号
		/// </summary>
		public string BillNO
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

        #region IValidState 成员

        /// <summary>
        /// 有效性状态  Valid 有效 Invalid 无效 Ignore 忽略不处理
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumValidState ValidState
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

        #region 方法

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns>返回当前实例的副本</returns>
        public new IMAApplyBase Clone()
        {
            IMAApplyBase imaApplyBase = base.Clone() as IMAApplyBase;

            imaApplyBase.ApplyDept = this.ApplyDept.Clone();

            return imaApplyBase;

        }


        #endregion		

        #region 无效属性

        /// <summary>
        /// 申请操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment applyOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 申请数量
        /// </summary>
        private decimal applyQty;

        /// <summary>
        /// 审批信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment examOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 核准数量
        /// </summary>
        private decimal approveQty;

        /// <summary>
        /// 核准操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment approveOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 操作信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 申请操作信息
        /// </summary>
        [System.Obsolete("程序整合 更改为Operation属性", true)]
        public Neusoft.HISFC.Models.Base.OperEnvironment ApplyOper
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
        /// 申请数量
        /// </summary>
        [System.Obsolete("程序整合 更改为Operation属性", true)]
        public decimal ApplyQty
        {
            get
            {
                return this.applyQty;
            }
            set
            {
                this.applyQty = value;
            }
        }


        /// <summary>
        /// 审批操作信息
        /// </summary>
        [System.Obsolete("程序整合 更改为Operation属性", true)]
        public Neusoft.HISFC.Models.Base.OperEnvironment ExamOper
        {
            get
            {
                return this.examOper;
            }
            set
            {
                this.examOper = value;
            }
        }


        /// <summary>
        /// 核准数量
        /// </summary>
        [System.Obsolete("程序整合 更改为Operation属性", true)]
        public decimal ApproveQty
        {
            get
            {
                return this.approveQty;
            }
            set
            {
                this.approveQty = value;
            }
        }


        /// <summary>
        /// 核准操作信息
        /// </summary>
        [System.Obsolete("程序整合 更改为Operation属性", true)]
        public Neusoft.HISFC.Models.Base.OperEnvironment ApproveOper
        {
            get
            {
                return this.approveOper;
            }
            set
            {
                this.approveOper = value;
            }
        }


        /// <summary>
        /// 操作信息
        /// </summary>
        [System.Obsolete("程序整合 更改为Operation属性", true)]
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
    }
}
