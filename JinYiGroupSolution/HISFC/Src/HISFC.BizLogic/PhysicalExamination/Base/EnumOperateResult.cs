using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination
{
	/// <summary>
	/// 操作结果类型
	/// </summary>
	public enum OperateResult
	{
		/// <summary>
		/// 成功
		/// </summary>
		Success,
		/// <summary>
		/// 成功，但是返回空记录
		/// </summary>
		NoneRecord,
		/// <summary>
		/// 失败
		/// </summary>
		Failing,
	}
}
