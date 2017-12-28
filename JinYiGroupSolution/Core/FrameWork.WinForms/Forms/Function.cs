using System;

namespace Neusoft.FrameWork.WinForms.Forms
{
	/// <summary>
	/// 选择到项目事件
	/// </summary>
	public delegate void SelectedItemHandler(Neusoft.FrameWork.Models.NeuObject sender);
	/// <summary>
	/// 控件变化事件
	/// </summary>
	public delegate void ControlChangedHandler(object sender);
	/// <summary>
	/// 确定事件
	/// </summary>
	public delegate void OKHandler(object sender,Neusoft.FrameWork.Models.NeuObject e);
	
	
}
