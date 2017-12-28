using System;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// INeuControl 的摘要说明。
	/// </summary>
	public interface INeuControl
	{

		StyleType Style {
			get;
			set;
		}
	}


	public enum StyleType 
    {
        Fixed3D,
		VS2003,
		Flat		
	}
}
