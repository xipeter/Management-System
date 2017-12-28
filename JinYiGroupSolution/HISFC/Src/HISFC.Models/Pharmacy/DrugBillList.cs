using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 摆药单明细实体]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理 '
	///  />
	/// </summary>
    [Serializable]
    public class DrugBillList :  Neusoft.FrameWork.Models.NeuObject
	{
		/// <summary>
		/// 摆药单分类明细实体
		/// </summary>
		public DrugBillList() 
		{
			
		}


		#region 变量

		/// <summary>
		/// 摆药单分类
		/// </summary>
		private Neusoft.HISFC.Models.Pharmacy.DrugBillClass myDrugBillClass = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();

		/// <summary>
		/// 医嘱类别
		/// </summary>
		private Neusoft.HISFC.Models.Order.OrderType orderType = new Neusoft.HISFC.Models.Order.OrderType();
	
		/// <summary>
		/// 用法
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject usage = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 药品类别
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject drugType = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 药品性质
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject drugQuality = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 剂型
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject dosageForm = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 医嘱状态 1长期/2临时/3全部
		/// </summary>
		private string orderState;

		#endregion

		/// <summary>
		/// 摆药单分类
		/// </summary>
		public Neusoft.HISFC.Models.Pharmacy.DrugBillClass DrugBillClass
		{
			get
			{ 
				return this.myDrugBillClass;
			}
			set
			{
				this.myDrugBillClass = value;
			}
		}


		/// <summary>
		/// 医嘱类别
		/// </summary>
		public Neusoft.HISFC.Models.Order.OrderType OrderType
		{
			get
			{
				return this.orderType;
			}
			set
			{
				this.orderType = value;
			}
		}


		/// <summary>
		/// 用法
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Usage
		{
			get
			{
				return this.usage;
			}
			set
			{
				this.usage = value;
			}
		}


		/// <summary>
		/// 药品类别
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DrugType
		{
			get
			{
				return this.drugType;
			}
			set
			{
				this.drugType = value;
			}
		}


		/// <summary>
		/// 药品性质
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DrugQuality
		{
			get
			{
				return this.drugQuality;
			}
			set
			{
				this.drugQuality = value;
			}
		}


		/// <summary>
		/// 剂型
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DosageForm
		{
			get
			{
				return this.dosageForm;
			}
			set
			{
				this.dosageForm = value;
			}
		}


		/// <summary>
		/// 医嘱状态 1长期/2临时/3全部
		/// </summary>
		public string OrderState
		{
			get
			{
				return this.orderState;
			}
			set
			{
				this.orderState = value;
			}
		}


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new DrugBillList Clone()
		{
			DrugBillList drugBillList = base.Clone() as DrugBillList;

			drugBillList.DrugBillClass = this.DrugBillClass.Clone();
			drugBillList.OrderType = this.OrderType.Clone();
			drugBillList.Usage = this.Usage.Clone();
			drugBillList.DrugType = this.DrugType.Clone();
			drugBillList.DrugQuality = this.DrugQuality.Clone();
			drugBillList.DosageForm = this.DosageForm.Clone();

			return drugBillList;

		}


		#endregion

		#region 无效属性

		private System.String myTypeCode ;
		private System.String myUsageCode ;
		private System.String myDoseModelCode ;
		private System.String myDoseModelName ;
		private System.String myIpmState ;

		/// <summary>
		/// 医嘱类别
		/// </summary>
		[System.Obsolete("程序整合 更改为OrderType类型的OrderType属性",true)]
		public System.String TypeCode
		{
			get{ return this.myTypeCode; }
			set{ this.myTypeCode = value; }
		}


		/// <summary>
		/// 用法代码
		/// </summary>
		[System.Obsolete("程序整合 更改为Neuobject类型的Usage属性",true)]
		public System.String UsageCode
		{
			get{ return this.myUsageCode; }
			set{ this.myUsageCode = value; }
		}


		/// <summary>
		/// 剂型代码
		/// </summary>
		[System.Obsolete("程序整合 更改为Neuobject类型的DosageForm属性",true)]
		public System.String DosageFormCode
		{
			get{ return this.myDoseModelCode; }
			set{ this.myDoseModelCode = value; }
		}


		/// <summary>
		/// 剂型名称
		/// </summary>
		[System.Obsolete("程序整合 更改为Neuobject类型的DosageForm属性",true)]
		public System.String DoseModelName
		{
			get{ return this.myDoseModelName; }
			set{ this.myDoseModelName = value; }
		}


		/// <summary>
		/// 医嘱状态1长期/2临时/3全部
		/// </summary>
		[System.Obsolete("程序整合 更改为orderState属性",true)]
		public System.String IpmState
		{
			get{ return this.myIpmState; }
			set{ this.myIpmState = value; }
		}


		#endregion

	}
}
