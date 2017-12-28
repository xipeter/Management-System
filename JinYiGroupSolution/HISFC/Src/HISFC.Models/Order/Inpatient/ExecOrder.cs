using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC;
namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.ExecOrder<br></br>
	/// [功能描述: 医嘱执行资料实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class ExecOrder:Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValid
	{
		public ExecOrder()
		{
			
		}

		#region 变量

		#region 私有

		/// <summary>
		/// 医嘱信息
		/// </summary>
        private Models.Order.Inpatient.Order order = new Neusoft.HISFC.Models.Order.Inpatient.Order();

		/// <summary>
		/// 开始使用时间
		/// </summary>
		private DateTime dateUse;

		/// <summary>
		/// 分解时间
		/// </summary>
		private DateTime dateDeco;

		/// <summary>
		/// 0不需发送/1集中发送/2分散发送/3已配药
		/// </summary>
		private int drugFlag = 0;

		/// <summary>
		/// 是否有效（1、有效 0、作废 ）
		/// </summary>
		private bool isValid = true;

		/// <summary>
		/// 作废者
		/// </summary>
		private Base.OperEnvironment dcExecOper = new OperEnvironment();

		/// <summary>
		/// 是否执行（1、已执行 0、未执行 ）
		/// </summary>
		private bool isExec = false;

		/// <summary>
		/// 执行者
		/// </summary>
		private Base.OperEnvironment execOper = new OperEnvironment();

		/// <summary>
		/// 是否收费（1、已收费 0、未收费 ）
		/// </summary>
		private bool isCharge = false;

		/// <summary>
		/// 收费者
		/// </summary>
		private Base.OperEnvironment chargeOper = new OperEnvironment();

		/// <summary>
		/// 摆药时间
		/// </summary>
		private DateTime drugedTime;

        /// <summary>
        /// 是否确认
        /// {DA77B01B-63DF-4559-B264-798E54F24ABB}
        /// </summary>
        private bool isConfirm = false;

		#endregion

		#endregion 变量

		#region 属性
		/// <summary>
		/// 医嘱信息
		/// </summary>
        public Models.Order.Inpatient.Order Order
		{
			get
			{
				return this.order;
			}
			set
			{
				this.order = value;
			}
		}

		/// <summary>
		/// 开始使用时间
		/// </summary>
		public DateTime DateUse
		{
			get
			{
				return this.dateUse;
			}
			set
			{
				this.dateUse = value;
			}
		}

		/// <summary>
		/// 分解时间
		/// </summary>
		public DateTime DateDeco
		{
			get
			{
				return this.dateDeco;
			}
			set
			{
				this.dateDeco = value;
			}
		}

		/// <summary>
		/// 0不需发送/1集中发送/2分散发送/3已配药
		/// </summary>
		public int DrugFlag
		{
			get
			{
				return this.drugFlag;
			}
			set
			{
				this.drugFlag = value;
			}
		}

		/// <summary>
		/// 作废者
		/// </summary>
		public Base.OperEnvironment DCExecOper
		{
			get
			{
				return this.dcExecOper;
			}
			set
			{
				this.dcExecOper = value;
			}
		}

		/// <summary>
		/// 是否执行（1、已执行 0、未执行 ）
		/// </summary>
		public bool IsExec
		{
			get
			{
				return this.isExec;
			}
			set
			{
				this.isExec = value;
			}
		}

		/// <summary>
		/// 执行者
		/// </summary>
		public Base.OperEnvironment ExecOper
		{
			get
			{
				return this.execOper;
			}
			set
			{
				this.execOper = value;
			}
		}

		/// <summary>
		/// 是否收费（1、已收费 0、未收费 ）
		/// </summary>
		public bool IsCharge 
		{
			get
			{
				return this.isCharge;
			}
			set
			{
				this.isCharge = value;
			}
		}

		/// <summary>
		/// 收费者
		/// </summary>
		public Base.OperEnvironment ChargeOper
		{
			get
			{
				return this.chargeOper;
			}
			set
			{
				this.chargeOper = value;
			}
		}

		/// <summary>
		/// 摆药时间
		/// </summary>
		public DateTime DrugedTime
		{
			get
			{
				return this.drugedTime;
			}set
			 {
				 this.drugedTime = value;
			 }
		}

        /// <summary>
        /// 是否确认
        /// {DA77B01B-63DF-4559-B264-798E54F24ABB}
        /// </summary>
        public bool IsConfirm
        {
            get { return isConfirm; }
            set { isConfirm = value; }
        }

		#endregion 属性

		#region 作废的
		/// <summary>
		/// 作废者
		/// </summary>
		[Obsolete("作废者DCExecOper.Oper.ID",true)]
		public Base.Employee DcExecUser = new Employee();

		/// <summary>
		/// 作废时间
		/// </summary>
		[Obsolete("作废时间DCExecOper.Oper.OperTime",true)]
		public DateTime DcExecTime;

		/// <summary>
		/// 执行者
		/// </summary>
		[Obsolete("ExecOper.Oper.OperID",true)]
		public NeuObject ExecUser=new NeuObject();

		/// <summary>
		/// 执行时间
		/// </summary>
		[Obsolete("ExecOper.Oper.OperTime",true)]
		public DateTime ExecTime;

		/// <summary>
		/// 收费者
		/// </summary>
		[Obsolete("ChargeOper.Oper.Oper",true)]
		public NeuObject ChargeUser=new NeuObject();

		/// <summary>
		/// 收费科室
		/// </summary>
		[Obsolete("ChargeOper.Oper.Dept",true)]
		public NeuObject ChargeDept=new NeuObject();

		/// <summary>
		/// 收费时间
		/// </summary>
		[Obsolete("ChargeOper.Oper.OperTime",true)]
		public DateTime ChargeTime;

		#endregion 作废的

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new ExecOrder Clone()
		{
			// TODO:  添加 Order.Clone 实现
			ExecOrder obj=base.Clone() as ExecOrder;

			try{obj.Order =this.Order.Clone();}
			catch{};
			
			obj.execOper = this.execOper.Clone();
			obj.dcExecOper = this.dcExecOper.Clone();
			obj.chargeOper = this.chargeOper.Clone();

			return obj;
		}

		#endregion

		#endregion

		#region 接口实现

		#region IValid 接口实现

		/// <summary>
		/// 是否有效（1、有效 0、作废 ）
		/// </summary>
		public bool IsValid
		{
			get
			{
				// TODO:  添加 ExecOrder.IsInvalid getter 实现
				return this.isValid;
			}
			set
			{
				// TODO:  添加 ExecOrder.IsInvalid setter 实现
				this.isValid =value;
			}
		}

		#endregion

		#endregion
	}
}
