using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Models.MedTech.Terminal
{
    /// <summary>
    /// [功能描述: 终端确认信息]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-12-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    /// 
    [System.Serializable]
	public class TerminalConfirm : TerminalApplyInfo
	{
		#region 变量

		/// <summary>
		/// 确认数量
		/// </summary>
		private int confirmAmount;

		/// <summary>
		/// 确认操作员

		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment confirmOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		#endregion

		#region 属性



		public int ConfirmAmount
		{
			get
			{
				return confirmAmount;
			}
			set
			{
				confirmAmount = value;
			}
		}

		public Neusoft.HISFC.Models.Base.OperEnvironment ConfirmOper
		{
			get
			{
				return confirmOper;
			}
			set
			{
				confirmOper = value;
			}
		}

		#endregion

		#region 方法
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new TerminalConfirm Clone()
		{
			TerminalConfirm terminalConfirm = base.Clone() as TerminalConfirm;

			return terminalConfirm;
		}

		#endregion

	}
}
