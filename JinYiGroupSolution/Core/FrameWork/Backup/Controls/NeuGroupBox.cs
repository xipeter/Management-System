using System;
using System.Drawing;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Controls.General;
using Neusoft.FrameWork.WinForms.Controls.Win32;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuGroupBox µÄÕªÒªËµÃ÷¡£
	/// </summary>
	[ToolboxBitmap(typeof(GroupBox))]
	public class NeuGroupBox : System.Windows.Forms.GroupBox, INeuControl
	{
		public NeuGroupBox()
		{
//			DrawMode = DrawMode.OwnerDrawFixed;
//			SetStyle(ControlStyles.AllPaintingInWmPaint|ControlStyles.UserPaint|ControlStyles.Opaque, true);
		}

		//private DrawState drawState = DrawState.Normal;
		private StyleType styleType;

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			if (this.styleType != StyleType.VS2003) 
			{
				base.OnPaint (e);
				return;
			}
			//
			Graphics g=e.Graphics;
			Rectangle rect = this.ClientRectangle;
			e.Graphics.FillRectangle(SystemBrushes.Control,rect);
			rect.Width -=2;
			rect.Height -= 2;
			if (!this.Enabled) 
			{
				//this.drawState = DrawState.Disable;
			}
			//»­±ß¿ò
			g.DrawRectangle(DrawingUtil.BorderColorPen, rect.Left, rect.Top, rect.Width, rect.Height);
			
			
			SizeF sizeTitleText;
			sizeTitleText = g.MeasureString(this.Text,this.Font);
			
			Rectangle r = new Rectangle(1,1,(int)sizeTitleText.Width+6,(int)sizeTitleText.Height+3);
			//»­Title±³¾°
			using(SolidBrush brush=new SolidBrush(this.BackColor))
			{							
				g.FillRectangle(brush,r);
			}
			//»­Title¿ò
			Rectangle r1=new Rectangle(0,0,r.Width,r.Height);			
			g.DrawRectangle(DrawingUtil.BorderColorPen,r1);
			//»­Title
			e.Graphics.DrawString(this.Text,this.Font,System.Drawing.SystemBrushes.WindowText,4,4);
			
		}

//		protected override void OnEnabledChanged(EventArgs e)
//		{
//			base.OnEnabledChanged (e);
//			this.Invalidate();
//		}


		#region INeuControl ³ÉÔ±


		public StyleType Style 
		{
			get
			{				
				return this.styleType;
			}
			set
			{
				this.styleType=value;
					this.Invalidate();
				foreach(Control control in this.Controls)
				{
					if (control is INeuControl) 
					{
						(control as INeuControl).Style = value;
					}
					
				}
			}
		}

		#endregion

	}
}
