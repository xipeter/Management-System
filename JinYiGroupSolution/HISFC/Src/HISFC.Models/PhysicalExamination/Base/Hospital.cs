namespace Neusoft.HISFC.Object.PhysicalExamination.Base
{
	/// <summary>
	/// Hospital <br></br>
	/// [功能描述: 医院实体]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Hospital : Neusoft.HISFC.Object.Base.Spell 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Hospital( ) 
		{
		}

		#region 方法

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>医院类</returns>
		public new Hospital Clone()
		{
			Hospital hospital = base.Clone() as Hospital;

			return hospital;
		}
		#endregion
	}
}
