using System;
using System.Windows.Forms;
using System.Drawing;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuVScrollBar<br></br>
	/// [功能描述: NeuVScrollBar控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[ToolboxBitmap(typeof(VScrollBar))]
	public class NeuVScrollBar : VScrollBar, INeuControl
	{
		public NeuVScrollBar()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private StyleType styleType;

		#region INeuControl 成员

		public Neusoft.FrameWork.WinForms.Controls.StyleType Style
		{
			get
			{				
				return this.styleType;
			}
			set
			{
				this.styleType = value;
			}
		}

		#endregion
	}
}
