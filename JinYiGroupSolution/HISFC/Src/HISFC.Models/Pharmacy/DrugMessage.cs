using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// [功能描述: 摆药通知类]<br></br>
	/// [创 建 者: 崔鹏]<br></br>
	/// [创建时间: 2004-12]<br></br>
	/// <修改记录
	///		修改人='梁俊泽'
	///		修改时间='2006-09-12'
	///		修改目的='系统重构'
	///		修改描述='命名规范整理'
	///  />
	///  ID		操作人编码
	///  Name	操作人姓名
	/// </summary>
    [Serializable]
    public class DrugMessage : Neusoft.FrameWork.Models.NeuObject 
	{
		public DrugMessage() 
		{

		}


		#region 变量

		/// <summary>
		/// 申请科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject applyDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 库存科室(取药科室)
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject myMedDept  = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 摆药单分类
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject myDrugBillClass = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 通知发送时间  
		/// </summary>
		private DateTime mySendDtime ;

		/// <summary>
		/// 通知发送类型
		/// </summary>
		private int mySendType;

		/// <summary>
		/// 摆药通知标记 0 通知 1 已摆
		/// </summary>
		private int mySendFlag;

		#endregion

		/// <summary>
		/// 申请科室编码 0-全部部门
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
		/// 摆药单分类
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DrugBillClass 
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
		/// 发送类型，1-集中发送，0-临时发送
		/// </summary>
		public int SendType 
		{
			get
			{
				return this.mySendType;
			}
			set
			{
				this.mySendType = value; 
			}
		}


		/// <summary>
		/// 发送通知时间
		/// </summary>
		public System.DateTime SendTime 
		{
			get
			{
				return this.mySendDtime; 
			}
			set
			{
				this.mySendDtime = value; 
			}
		}


		/// <summary>
		/// 摆药标记0-通知1-已摆
		/// </summary>
		public int SendFlag 
		{
			get
			{
				return this.mySendFlag; 
			}
			set
			{
				this.mySendFlag = value;
			}
		}

		
		/// <summary>
		/// 取药科室(库存科室)
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StockDept 
		{
			get
			{ 
				return this.myMedDept;
			}
			set
			{ 
				this.myMedDept = value;
			}
		}


		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例副本</returns>
		public new DrugMessage Clone()
		{
			DrugMessage drugMessage = base.Clone() as DrugMessage;

			drugMessage.ApplyDept = this.ApplyDept.Clone();

			drugMessage.DrugBillClass = this.DrugBillClass.Clone();

			drugMessage.StockDept = this.StockDept.Clone();

			return drugMessage;
		}


		#region 无效属性

		/// <summary>
		/// 申请科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject mySendDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 申请科室编码 0-全部部门
		/// </summary>
		[System.Obsolete("程序整合 更改为ApplyDept属性",true)]
		public Neusoft.FrameWork.Models.NeuObject SendDept 
		{
			get{ return this.mySendDept; }
			set{ this.mySendDept = value; }
		}


		/// <summary>
		/// 取药科室
		/// </summary>
		[System.Obsolete("程序整合 更改为StockDept属性",true)]
		public Neusoft.FrameWork.Models.NeuObject MedDept 
		{
			get{ return this.myMedDept; }
			set{ this.myMedDept = value; }
		}



		/// <summary>
		/// 发送通知时间
		/// </summary>
		[System.Obsolete("程序整合 更改为SendTime属性",true)]
		public System.DateTime SendDtime 
		{
			get
			{
				return this.mySendDtime; 
			}
			set
			{
				this.mySendDtime = value; 
			}
		}


		#endregion

	}
}
