using System;

namespace neusoft.HISFC.Object.Case
{
	/// <summary>
	/// Operation 的摘要说明：病案患者手术基本信息
	/// </summary>
	public class Operation : neusoft.neuFC.Object.neuObject, neusoft.HISFC.Object.Base.ISpellCode
	{
		public Operation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		#region 私有变量

		private neusoft.neuFC.Object.neuObject myOperationInfo = new neusoft.neuFC.Object.neuObject();
		private string operationEnName;
		
		#endregion

		#region 属性

		/// <summary>
		/// 手术项目信息 ID 手术编码 Name 手术中文名称
		/// </summary>
		public neusoft.neuFC.Object.neuObject OperationInfo
		{
			get{ return myOperationInfo; }
			set{ myOperationInfo = value; }
		}
		/// <summary>
		/// 手术英文名称
		/// </summary>
		public string OperationEnName
		{
			get{ return operationEnName; }
			set{ operationEnName = value; }
		}

		#endregion

		#region 公有函数

		public new Operation Clone()
		{
			Operation OpClone = base.MemberwiseClone() as Operation;

			OpClone.OperationInfo = this.OperationInfo.Clone();

			return OpClone;
		}

		#endregion
		
		#region ISpellCode 成员
		
		private string spellCode;
		public string Spell_Code
		{
			get
			{
				return spellCode;
			}
			set
			{
				spellCode = value;
			}
		}
		private string wbCode;
		public string WB_Code
		{
			get
			{
				return wbCode;
			}
			set
			{
				wbCode = value;
			}
		}
		private string userCode;
		public string User_Code
		{
			get
			{
				return userCode;
			}
			set
			{
				userCode = value;
			}
		}

		#endregion
	}		
}
