namespace Neusoft.HISFC.Models.PhysicalExamination.Management 
{
	/// <summary>
	/// PEUser <br></br>
	/// [功能描述: 体检用户]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-11-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [System.Serializable]
    public class PEUser : Neusoft.HISFC.Models.PhysicalExamination.Base.PE 
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public PEUser()
		{

		}

		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>体检用户</returns>
		public new PEUser Clone()
		{
			return base.Clone() as PEUser;
		}
		#endregion
	}
}
