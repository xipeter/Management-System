using System;

namespace neusoft.neuFC.Interface.Classes
{
	/// <summary>
	/// IEMRControl 的摘要说明。
	/// 电子病历控件控制接口
	/// </summary>
	public interface IEMRControl
	{
		/// <summary>
		/// 初始化控件事件
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		int Init(params object[] param);
		/// <summary>
		/// 控件变化事件
		/// </summary>
		event neusoft.neuFC.Interface.Forms.ControlChangedHandler ControlChanged;
		/// <summary>
		/// 确定，保存事件
		/// </summary>
		event neusoft.neuFC.Interface.Forms.OKHandler OK;
		/// <summary>
		/// 保存函数
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		int Save(neusoft.neuFC.Management.Transaction t);
		
	}
}
