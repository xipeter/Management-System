using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Neusoft.FrameWork.WinForms.Controls.Win32;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuListBox<br></br>
	/// [功能描述: NeuListBox控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[ToolboxBitmap(typeof(ListBox))]
	public class NeuListBox : ListBox, INeuControl
	{
		public NeuListBox()
		{

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
				if (value == StyleType.Flat)
				{
					this.BorderStyle = BorderStyle.Fixed3D;
					this.BorderStyle = BorderStyle.FixedSingle;
				}
				else if(value == StyleType.Fixed3D)
				{
					this.BorderStyle = BorderStyle.FixedSingle;
					this.BorderStyle = BorderStyle.Fixed3D;
				}
				else
					this.Invalidate();
			}
		}

		#endregion

		private bool mblnHighlight = true;
		private Color mclrHighlight = SystemColors.Highlight;
		private Color mclrBorder = SystemColors.ControlDark;
		protected override void OnMouseEnter(System.EventArgs e)
		{
			base.OnMouseEnter(e);
			if (mblnHighlight) Invalidate(); 
		}
		protected override void OnMouseLeave(System.EventArgs e)
		{
			base.OnMouseLeave(e);
			if (mblnHighlight) Invalidate(); 
		}
		protected override void OnLostFocus(System.EventArgs e)
		{
			base.OnLostFocus(e);
			if (mblnHighlight) Invalidate(); 
		}
		protected override void OnGotFocus(System.EventArgs e)
		{
			base.OnGotFocus(e);
			if (mblnHighlight) Invalidate(); 
		}
		
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg != (int)Msg.WM_PAINT) 
				return;

			if (this.styleType!=StyleType.VS2003) 
			{
				return;
			}

			Win32.RECT wrec=new RECT();
			WindowsAPI.GetWindowRect(this.Handle,ref wrec);
			Rectangle rec = new Rectangle(0, 0, wrec.right - wrec.left, wrec.bottom - wrec.top);
			Pen pen= new Pen(SystemBrushes.Window);
			IntPtr hDc = WindowsAPI.GetWindowDC(Handle);
			Graphics g = Graphics.FromHdc(hDc);
			
			g.DrawRectangle(pen, 1, 1, rec.Width - 3, rec.Height - 3);
			pen.Dispose();

			if (!DesignMode && mblnHighlight && Enabled && (Focused || ClientRectangle.Contains(PointToClient(MousePosition))))
			{
				pen = new Pen(mclrHighlight);
			}
			else
			{
				pen = new Pen(mclrBorder);
			}

			
			
			g.DrawRectangle(pen, 0, 0, rec.Width - 1, rec.Height - 1);
			g.Dispose();

			pen.Dispose();
			WindowsAPI.ReleaseDC(Handle, hDc);
		}


		[DefaultValue(true), Category("Behavior"), Description("Indicates whether the control will have its border highlighted " + "when it receives focus or the mouse pointer enters its client rectangle.  The default value is True.")]
		public bool HighlightBorder 
		{
			get 
			{
				return mblnHighlight;
			}
			set 
			{
				if (value == mblnHighlight) 
					return; 
				mblnHighlight = value;
				if (!DesignMode) 
					Invalidate(); 
			}
		}
		

		[Category("Appearance"), Description("The color of the control's border when it receives focus or the mouse pointer enters its client rectangle.")]
		public Color HighlightColor 
		{
			get 
			{
				return mclrHighlight;
			}
			set 
			{
				if (value.Equals(mclrHighlight)) 
					return; 
				mclrHighlight = value;
				if (!DesignMode && mblnHighlight) 
					Invalidate(); 
			}
		}
		

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeHighlightColor()
		{
			return !mclrHighlight.Equals(SystemColors.Highlight);
		}

		
		[Category("Appearance"), Description("The color of the control's border.")]
		public Color BorderColor 
		{
			get 
			{
				return mclrBorder;
			}
			set 
			{
				if (value.Equals(mclrBorder)) 
					return; 
				mclrBorder = value;
				Invalidate();
			}
		}

		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeBorderColor()
		{
			return !mclrBorder.Equals(SystemColors.ControlDark);
		}

		
	}
}
