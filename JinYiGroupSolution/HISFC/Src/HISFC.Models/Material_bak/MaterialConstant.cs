using System;

namespace Neusoft.HISFC.Object.Material
{
	/// <summary>
	/// [功能描述: 物资常数]
	/// [创 建 者: 李超]
	/// [创建时间: 2007-03-12]
	/// </summary>
	public class MaterialConstant:Neusoft.HISFC.Object.Base.Spell
	{
		public MaterialConstant()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
#region 域

		/// <summary>
		/// 常数表序号
		/// </summary>
		private string tableCode;

		/// <summary>
		/// 操作员
		/// </summary>
		private Neusoft.NFC.Object.NeuObject oper = new Neusoft.NFC.Object.NeuObject();
		
		/// <summary>
		/// 操作时间
		/// </summary>
		private DateTime operTime;

		/// <summary>
		/// 上级编码
		/// </summary>
		private string parentCode;

#endregion

#region 属性

		/// <summary>
		/// 常数表序号
		/// </summary>
		public string TableCode
		{
			get
			{
				return this.tableCode;
			}
			set
			{
				this.tableCode = value;
			}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Oper 
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
		/// 操作时间
		/// </summary>
		public DateTime OperTime
		{
			get
			{
				return this.operTime;
			}
			set
			{
				this.operTime = value;
			}
		}

		/// <summary>
		/// 上级编码
		/// </summary>
		public string ParentCode 
		{
			get
			{
				return this.parentCode;
			}
			set
			{
				this.parentCode = value;
			}
		}

#endregion

#region 方法
		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回克隆后的MaterialConstant实体 失败返回null</returns>
		public new MaterialConstant Clone()
		{

			MaterialConstant materialConstant = base.Clone() as MaterialConstant;

			materialConstant.Oper = this.Oper.Clone();

			return materialConstant;
		}
#endregion
	}
}
