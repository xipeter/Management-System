using System;
using Neusoft.HISFC.Object.Base;
using Neusoft.NFC.Object;
using Neusoft.HISFC;
namespace Neusoft.HISFC.Object.Order
{
	/// <summary>
	/// 医嘱执行资料实体written by caiy
	/// 2004-6
	/// </summary>
	public class ExecOrder:Neusoft.NFC.Object.NeuObject,Neusoft.HISFC.Object.Base.IValid
		,Neusoft.HISFC.Object.Base.IDept
	{
		/// <summary>
		/// 医嘱资料实体
		/// ID 医嘱流水号
		/// </summary>
		public ExecOrder()
		{
			
		}
		/// <summary>
		/// 医嘱信息
		/// </summary>
		public Object.Order.Order  Order = new Order();
		/// <summary>
		/// 开始使用时间
		/// </summary>
		public DateTime DateUse;
		/// <summary>
		/// 分解时间
		/// </summary>
		public DateTime DateDeco;
		/// <summary>
		/// 0不需发送/1集中发送/2分散发送/3已配药
		/// </summary>
		public int DrugFlag = 0;
		/// <summary>
		/// 是否有效（1、有效 0、作废 ）
		/// </summary>
		protected bool isValid = true;
		/// <summary>
		/// 作废者
		/// </summary>
		public Base.Employee DcExecUser = new Employee();
		/// <summary>
		/// 作废时间
		/// </summary>
		public DateTime DcExecTime;

		/// <summary>
		/// 是否执行（1、已执行 0、未执行 ）
		/// </summary>
		public bool IsExec =false;
		/// <summary>
		/// 执行者
		/// </summary>
		public NeuObject ExecUser=new NeuObject();
		/// <summary>
		/// 执行时间
		/// </summary>
		public DateTime ExecTime;
		/// <summary>
		/// 是否收费（1、已收费 0、未收费 ）
		/// </summary>
		public bool IsCharge = false;
		/// <summary>
		/// 收费者
		/// </summary>
		public NeuObject ChargeUser=new NeuObject();
		/// <summary>
		/// 收费科室
		/// </summary>
		public NeuObject ChargeDept=new NeuObject();
		/// <summary>
		/// 收费时间
		/// </summary>
		public DateTime ChargeTime;
		/// <summary>
		/// 摆药时间
		/// </summary>
		public DateTime DrugedTime;

		#region IsValid 成员

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

		#region IDept 成员

		public NeuObject InDept
		{
			get
			{
				// TODO:  添加 ExecOrder.InDept getter 实现
				return this.Order.InDept;
			}
			set
			{
				this.Order.InDept = value;
				// TODO:  添加 ExecOrder.InDept setter 实现
			}
		}

		public NeuObject ExeDept
		{
			get
			{
				// TODO:  添加 ExecOrder.ExeDept getter 实现
				return this.Order.ExeDept;
			}
			set
			{
				this.Order.ExeDept=value;
				// TODO:  添加 ExecOrder.ExeDept setter 实现
			}
		}

		public NeuObject ReciptDept
		{
			get
			{
				// TODO:  添加 ExecOrder.ReciptDept getter 实现
				return ChargeDept;
			}
			set
			{
				// TODO:  添加 ExecOrder.ReciptDept setter 实现
				ChargeDept =value;
			}
		}

		public NeuObject NurseStation
		{
			get
			{
				// TODO:  添加 ExecOrder.NurseStation getter 实现
				return this.Order.Patient.PVisit.PatientLocation.NurseCell;
			}
			set
			{
				this.Order.Patient.PVisit.PatientLocation.NurseCell=value;
				// TODO:  添加 ExecOrder.NurseStation setter 实现
			}
		}

		public NeuObject StockDept
		{
			get
			{
				// TODO:  添加 ExecOrder.StockDept getter 实现
				return this.Order.StockDept;
			}
			set
			{
				this.Order.StockDept=value;
				// TODO:  添加 ExecOrder.StockDept setter 实现
			}
		}

		public NeuObject DoctorDept
		{
			get
			{
				// TODO:  添加 ExecOrder.ReciptDoct getter 实现
				return this.Order.DoctorDept;
			}
			set
			{
				// TODO:  添加 ExecOrder.ReciptDoct setter 实现
				this.Order.DoctorDept =value;
			}
		}

		#endregion

		#region ICloneable 成员

		public new ExecOrder Clone()
		{
			// TODO:  添加 Order.Clone 实现
			ExecOrder obj=base.Clone() as ExecOrder;

			try{obj.Order =this.Order.Clone();}
			catch{};
			obj.DcExecUser=this.DcExecUser.Clone();
			obj.ExecUser=this.ExecUser.Clone();
			obj.ChargeUser=this.ChargeUser.Clone();
			obj.ChargeDept=this.ChargeDept.Clone();

			try{obj.InDept=this.InDept.Clone();}
			catch{};
			try{obj.ExeDept=this.ExeDept.Clone();}
			catch{};
			try{obj.NurseStation=this.NurseStation.Clone();}
			catch{};
			try{obj.ReciptDept=this.ReciptDept.Clone();}
			catch{};
			try{obj.DoctorDept=this.DoctorDept.Clone();}
			catch{};
			try{obj.StockDept=this.StockDept.Clone();}
			catch{};

			return obj;
		}

		#endregion
	}
}
