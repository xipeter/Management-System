using System;
using System.Collections;
using System.Drawing;
namespace Neusoft.FrameWork.WinForms.Classes
{
	/// <summary>
	/// IControlPrintable 的摘要说明。
	/// 用户控件打印接口
	/// 有IContainer接口更好
	/// </summary>
	public interface IControlPrintable
	{
		/// <summary>
		/// 控件需要的大小
		/// </summary>
		Size ControlSize{get;} 
		/// <summary>
		/// 是否可以自动扩展大小
		/// </summary>
		bool IsCanExtend{get;set;}
		/// <summary>
		/// 当前控件集合
		/// </summary>
		ArrayList Components{get;set;}
		/// <summary>
		/// 横排数量
		/// </summary>
		int HorizontalNum{get;set;}
		/// <summary>
		/// 竖排数量
		/// </summary>
		int VerticalNum{get;set;}
		/// <summary>
		/// 数值
		/// </summary>
		object ControlValue{set;get;}
		/// <summary>
		/// 是否显示网格
		/// </summary>
		bool IsShowGrid{get;set;}
		/// <summary>
		/// 横排间隔大小
		/// </summary>
		int HorizontalBlankWidth{get;set;}
		/// <summary>
		/// 竖排间隔大小
		/// </summary>
		int VerticalBlankHeight{get;set;}
		int BeginHorizontalBlankWidth{get;set;}
		int BeginVerticalBlankHeight{get;set;}
	}
}
