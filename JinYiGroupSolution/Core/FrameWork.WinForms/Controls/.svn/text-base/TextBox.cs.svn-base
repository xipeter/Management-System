using System;
using System.Windows.Forms;
using System.Drawing;
using UtilityLibrary.Win32;
using UtilityLibrary.General;

namespace Neusoft.NFC.Interface.Controls
{
	/// <summary>
	/// TextBox 的摘要说明。
	/// </summary>
	public class TextBox:System.Windows.Forms.TextBox
	{		
		public TextBox()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.BackColor=Color.WhiteSmoke;
			base.Invalidate();
			//this.draw();
		}

		public new BorderStyle BorderStyle 
		{
			// Don't let the user change this property
			// because we are counting on the extra pixels
			// than the 3D look adds to the edit control size
			// to do our painting
			get { return base.BorderStyle; } 
			set 
			{
				if ( value != BorderStyle.Fixed3D )
				{
					// Throw an exception to tell the user
					// that this property needs to be Fixe3D if 
					// he is to use this class
					string message = "BorderStyle can only be Fixed3D for this class";
					ArgumentException argumentException = new ArgumentException("BorderStyle", message);
					throw(argumentException);
				}
				else 
					base.BorderStyle = value;
			}
		}
		
		protected override void OnMouseEnter(EventArgs e)
		{
			// Set state to hot
			base.OnMouseEnter(e);
			this.BackColor=Color.White;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			// Set state to Normal
			base.OnMouseLeave(e);
			if(this.Focused==false)this.BackColor=Color.WhiteSmoke;
		}
      
		protected override void OnGotFocus(EventArgs e)
		{
			// Set state to Hot
			base.OnGotFocus(e);
			this.BackColor=Color.White;
		}
        
		protected override void OnLostFocus(EventArgs e)
		{
			// Set state to Normal
			base.OnLostFocus(e);
			this.BackColor=Color.WhiteSmoke;
		}

		private void draw()
		{
			// Get window area
			RECT rc = new RECT();
			WindowsAPI.GetWindowRect(Handle, ref rc);
			// Convert to Rectangle
			Rectangle rect = new Rectangle(0, 0, rc.right - rc.left, rc.bottom - rc.top);

			// Create DC for the whole edit window instead of just for the client area
			IntPtr hDC = WindowsAPI.GetWindowDC(Handle);

			using (Graphics g = Graphics.FromHdc(hDC))
			{
				// This rectangle is always drawn for any state
				using ( Pen windowPen = new Pen(SystemBrushes.Window) )
				{
					g.DrawRectangle(windowPen, rect.Left+1, rect.Top+1, rect.Width-3, rect.Height-3);
				}

				g.DrawRectangle(SystemPens.ControlDark, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
			}
			// Release DC
			WindowsAPI.ReleaseDC(Handle, hDC);
		}

		protected override  void WndProc(ref Message m)
		{
			bool callBase = true;
						
			switch(m.Msg)
			{
				case ((int)Msg.WM_PAINT):
				{
					// Let the edit control do its painting
					base.WndProc(ref m);
					// Now do our custom painting
					this.draw();
					callBase = false;
				}
					break;
				default:
					break;
			}

			if ( callBase )
				base.WndProc(ref m);
		
		}		
	}	
}
