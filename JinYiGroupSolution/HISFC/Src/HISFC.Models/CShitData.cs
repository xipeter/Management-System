using System;

namespace neusoft.HISFC.Object
{
	/// <summary>
	/// CShitData 的摘要说明。
	/// 变更的实体
	/// adjust by zhouxs
	/// 2005-6-3
	/// </summary>
	public class CShitData :neusoft.neuFC.Object.neuObject
	{
		public CShitData()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 域
		#endregion
		private string clincNo;
		private string shiftType;
		private UInt32 happenNo;
		private string oldDataCode;
		private string oldDataName;
		private string newDataCode;
		private string newDataName;
		private string shiftCause;
		private string mark;
		private string operCode;
		/// <summary>
		/// 流水号
		/// </summary>
		public string ClinicNo
		{
			get 
			{
				return clincNo;
			}
			set
			{
				clincNo = value;
			}
		}
		/// <summary>
		/// 发生序号
		/// </summary>
		public UInt32 HappenNo
		{
			get
			{
				return happenNo;
			}
			set
			{
				happenNo = value;
			}
		}
		/// <summary>
		/// 变更类型
		/// </summary>
		public string ShitType
		{
			get 
			{
				return shiftType;
			}
			set
			{
				shiftType = value;
			}
		}
		/// <summary>
		/// 原资料代码
		/// </summary>
		public string OldDataCode
		{
			get
			{
				return oldDataCode;
			}
			set
			{
				oldDataCode = value;
			}
		}
		/// <summary>
		/// 原资料代码
		/// </summary>
		public string OldDataName
		{
			get
			{
				return oldDataName;
			}
			set
			{
				oldDataName = value;
			}
		}
		/// <summary>
		/// 新资料代码
		/// </summary>
		public string NewDataCode
		{
			get
			{
				return newDataCode;
			}
			set
			{
				newDataCode = value;
			}
		}
		/// <summary>
		/// 新资料名称
		/// </summary>
		public string NewDataName
		{
			get
			{
				return newDataName;
			}
			set
			{
				newDataName = value;
			}
		}
		/// <summary>
		/// 变更原因
		/// </summary>
		public string ShitCause
		{
			get
			{
				return shiftCause;
			}
			set
			{
				shiftCause = value;
			}

		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Mark
		{
			get
			{
				return mark;
			}
			set
			{
				mark = value;
			}
		}
		/// <summary>
		/// 操作员代码
		/// </summary>
		public string OperCode
		{
			get
			{
				return operCode;
			}
			set
			{
				operCode = value;
			}
		}
		///<summary>
		///克隆函数
		///</summary>
		public new CShitData  Clone()
		{
			return this.MemberwiseClone() as CShitData;
		}

	}
}
