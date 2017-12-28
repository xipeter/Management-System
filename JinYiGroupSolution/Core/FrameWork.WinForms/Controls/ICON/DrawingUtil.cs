using System;
using System.Drawing;

namespace Neusoft.FrameWork.WinForms.Controls.General
{


	/// <summary>
	/// DrawingUtil 的摘要说明。
	/// 常用颜色及Pen
	/// </summary>
	/// Robin	2006-08-23
	public class DrawingUtil
	{

		public DrawingUtil( ) 
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public readonly static Color BorderColor = Color.FromArgb(172,168,153);
		public readonly static Color BorderHotColor = Color.FromArgb(49,106,197);
		public readonly static Color HotColor = Color.FromArgb(198,214,239);
		public readonly static Color SelectColor = Color.FromArgb(157,184,227);

		public static Pen BorderColorPen = new Pen(BorderColor);
		public static Pen BorderHotColorPen =new Pen(BorderHotColor);
		public static Pen HotColorPen = new Pen(HotColor);
		public static Pen SelectColorPen = new Pen(SelectColor);

		
		

		public static StyleType StyleType = StyleType.VS2003;

		public static void Dispose()
		{
			BorderColorPen.Dispose();
			BorderHotColorPen.Dispose();
			HotColorPen.Dispose();
			SelectColorPen.Dispose();
		}
	}
}
