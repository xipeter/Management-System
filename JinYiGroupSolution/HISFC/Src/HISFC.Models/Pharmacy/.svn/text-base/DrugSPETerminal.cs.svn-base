using System;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// Copyright (C) 2004 东软股份有限公司
	/// 版权所有
	/// 
	/// 文件名：DrugRecipe.cs
	/// 文件功能描述：门诊特殊终端实体
	/// 
	/// 
	/// 创建标识：梁俊泽 2005-11
	/// 
	/// 
	/// 修改标识：梁俊泽 2006-09
	/// 修改描述：程序整合
	/// </summary>
    [Serializable]
    public class DrugSPETerminal : Neusoft.FrameWork.Models.NeuObject
	{
		
		public enum SPEType 
		{
			药品 = 1,
			专科 = 2,
			结算类别 = 3,
			特定收费窗口 = 4
		}

		public DrugSPETerminal()
		{

		}


		#region 变量

		/// <summary>
		/// 门诊终端实体
		/// </summary>
		private DrugTerminal drugTerminal = new DrugTerminal();	

		/// <summary>
		/// 特殊配药台类别  1 药品 2 专科 3 结算类别 4 特定收费窗口
		/// </summary>
		private string itemType;			

		/// <summary>
		/// 特殊项目
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject item = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 操作环境信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		#endregion

		/// <summary>
		/// 终端实体
		/// </summary>
		public DrugTerminal Terminal 
		{
			get 
			{
				return drugTerminal;
			}
			set 
			{
				drugTerminal = value;
			}
		}


		/// <summary>
		/// 特殊配药台类别 1 药品 2 专科 3 结算类别 4 特定收费窗口
		/// </summary>
		public string ItemType 
		{
			get {return itemType;}
			set {itemType = value;}
		}


		/// <summary>
		/// 特殊项目
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}


		/// <summary>
		/// 操作环境信息
		/// </summary>
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


		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例副本</returns>
		public new DrugSPETerminal Clone()
		{
			DrugSPETerminal drugSpeTerminal = base.Clone() as DrugSPETerminal;

			drugSpeTerminal.Terminal = this.Terminal.Clone();

			drugSpeTerminal.Item = this.Item.Clone();

			drugSpeTerminal.Oper = this.Oper.Clone();

			return drugSpeTerminal;
		}
		#endregion

		#region 无效属性

		private string itemCode;			//项目编码

		private string itemName;			//项目名称

		private string operCode;			//操作员

		private DateTime operDate;			//操作时间

		private string mark;				//备注

		/// <summary>
		/// 特殊项目编码
		/// </summary>
		[System.Obsolete("程序整合 更改为Item属性",true)]
		public string ItemCode 
		{
			get {return itemCode;}
			set {itemCode = value;}
		}


		/// <summary>
		/// 特殊项目名称
		/// </summary>
		[System.Obsolete("程序整合 更改为Item属性",true)]
		public string ItemName 
		{
			get {return itemName;}
			set {itemName = value;}
		}

		
		/// <summary>
		/// 操作员
		/// </summary>
		[System.Obsolete("程序整合 更改为Oper属性",true)]
		public string OperCode 
		{
			get {return operCode;}
			set {operCode = value;}
		}


		/// <summary>
		/// 操作时间
		/// </summary>
		[System.Obsolete("程序整合 更改为Oper属性",true)]
		public DateTime OperDate
		{
			get {return operDate;}
			set {operDate = value;}
		}


		/// <summary>
		/// 备注
		/// </summary>
		[System.Obsolete("程序整合 更改为基类的Memo属性",true)]
		public string Mark
		{
			get {return mark;}
			set {mark = value;}
		}


		#endregion
	}
}
