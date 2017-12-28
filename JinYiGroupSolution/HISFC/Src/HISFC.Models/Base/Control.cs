using System;

namespace neusoft.HISFC.Object.Base
{
	/// <summary>
	/// Control 的摘要说明。控制类 Id 控制参数代码 name控制参数名称
	/// </summary>
	public class Control:neusoft.neuFC.Object.neuObject
	{
		public Control()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 控制参数的值
		/// </summary>
		public string ControlValue;
		/// <summary>
		/// 是否显示 0 显示 1 不显示
		/// </summary>
		public string VisibleFlag;
	
	}
}
