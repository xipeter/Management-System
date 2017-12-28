using System;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.Fee.Inpatient
{
	/// <summary>
	/// Balance<br></br>
	/// [功能描述: 住院结算明细类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-09-06]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    /// 
    [System.Serializable]
	public class BalanceList : BalanceListBase
	{
		public BalanceList()
		{
			this.balanceBase = new Balance();
		}

		#region 方法
		
		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns>返回当前对象实例副本</returns>
		public new BalanceList Clone()
		{
			return base.Clone() as BalanceList;
		}

		#endregion

		#endregion
	}
}
