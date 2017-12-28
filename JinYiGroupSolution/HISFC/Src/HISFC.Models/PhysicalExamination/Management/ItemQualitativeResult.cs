namespace Neusoft.HISFC.Object.PhysicalExamination.Management 
{
	/// <summary>
	/// ItemQualitativeResult <br></br>
	/// [功能描述: 体检项目定性结果]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class ItemQualitativeResult : Neusoft.HISFC.Object.PhysicalExamination.Base.PE
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public ItemQualitativeResult()
		{

		}

		#region 私有变量
		
		/// <summary>
		/// 体检项目
		/// </summary>
		private Item item;

		/// <summary>
		/// 定性结果
		/// </summary>
		private string qualitativeResult;

		#endregion

		#region 属性

		/// <summary>
		/// 体检项目
		/// </summary>
		public Item Item 
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
		/// 定性结果
		/// </summary>
		public string QualitativeResult
		{
			get
			{
				return this.qualitativeResult;
			}
			set
			{
				this.qualitativeResult = value;
			}
		}

		#endregion

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>项目定性结果</returns>
		public new ItemQualitativeResult Clone()
		{
			ItemQualitativeResult itemQualitativeResult = base.Clone() as ItemQualitativeResult;

			itemQualitativeResult.Item = this.Item.Clone();

			return itemQualitativeResult;
		}

		#endregion
	}
}
