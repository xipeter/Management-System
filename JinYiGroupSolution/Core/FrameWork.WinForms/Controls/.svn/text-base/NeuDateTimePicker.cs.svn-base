using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using Neusoft.FrameWork.WinForms.Controls.Win32;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuDateTimePicker<br></br>
	/// [功能描述: NeuDateTimePicker控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[ToolboxBitmap(typeof(DateTimePicker))]
	public class NeuDateTimePicker : DateTimePicker ,INeuControl
	{

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
				//刷新控件
				this.Width+=1;
				this.Width-=1;
			}
		}

		#endregion

		#region ComboInfoHelper
		internal class ComboInfoHelper
		{
			[DllImport("user32")] 
			private static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);

			#region RECT struct
			[StructLayout(LayoutKind.Sequential)]
				private struct RECT 
			{
				public int Left;
				public int Top;
				public int Right;
				public int Bottom;
			}
			#endregion

			#region ComboBoxInfo Struct
			[StructLayout(LayoutKind.Sequential)]
				private struct ComboBoxInfo 
			{
				public int cbSize;
				public RECT rcItem;
				public RECT rcButton;
				public IntPtr stateButton;
				public IntPtr hwndCombo;
				public IntPtr hwndEdit;
				public IntPtr hwndList;
			}
			#endregion

			public static int GetComboDropDownWidth()
			{
				ComboBox cb = new ComboBox();
				int width = GetComboDropDownWidth(cb.Handle);
				cb.Dispose();
				return width;
			}
			public static int GetComboDropDownWidth(IntPtr handle)
			{
				ComboBoxInfo cbi = new ComboBoxInfo();
				cbi.cbSize = Marshal.SizeOf(cbi);
				GetComboBoxInfo(handle, ref cbi);
				int width = cbi.rcButton.Right - cbi.rcButton.Left;
				return width;
			}
		}
		#endregion

		const int WM_ERASEBKGND = 0x14;
		const int WM_PAINT = 0xF;
		const int WM_NC_HITTEST = 0x84;
		const int WM_NC_PAINT = 0x85;
		const int WM_PRINTCLIENT = 0x318;
		const int WM_SETCURSOR = 0x20;


		private Pen BorderPen  = new Pen(Color.Black, 2);
		private Pen BorderPenControl  = new Pen(SystemColors.ControlDark, 2);
		internal bool droppedDown = false;
        private IntPtr hEditControl;					//Robin Add		
        private DateTimePickerUpDownHook upDownHook = null;
		//private int InvalidateSince = 0;
		private static int DropDownButtonWidth = 17;
		//private DateTime backupValue;

		static NeuDateTimePicker()
		{
			// 2 pixel extra is for the 3D border around the pulldown button on the left and right
			DropDownButtonWidth = ComboInfoHelper.GetComboDropDownWidth() + 2;	
		}

		public NeuDateTimePicker()
			: base()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

        private bool isEnter2Tab = false;

        /// <summary>
        /// 是否将Enter输入转成Tab输入
        /// </summary>
        [System.ComponentModel.Description("是否将Enter输入转成Tab输入")]
        public bool IsEnter2Tab
        {
            get { return isEnter2Tab; }
            set { isEnter2Tab = value; }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // Hook the upDown control
            if (this.ShowUpDown)
            {
                hEditControl = WindowsAPI.GetDlgItem(Handle, 0x3E8);
                //Debug.Assert(hEditControl != IntPtr.Zero, "Fail to get DateTimePicker's UpDown Control Handle...");
                upDownHook = new DateTimePickerUpDownHook(this);
                upDownHook.AssignHandle(hEditControl);
            }
        }
		protected override void OnValueChanged(EventArgs eventargs)
		{

            System.Diagnostics.Debug.WriteLine("ValueChanged");
            if (!this.droppedDown)
                WindowsAPI.SendMessage(this.Handle,WM_KEYDOWN,VK_RIGHT,0);

            base.OnValueChanged(eventargs);
            this.Invalidate();

		}

		protected override void OnNotifyMessage(Message m)
		{
			base.OnNotifyMessage (m);
		}


    //protected override void WndProc(ref Message m)
    //    {	
    //        if (this.styleType == StyleType.Fixed3D) 
    //        {
    //            base.WndProc(ref m);
    //            return;
    //        }

    //        IntPtr hDC = IntPtr.Zero;
    //        Graphics gdc = null;
    //        switch (m.Msg)
    //        {
    //            case WM_NC_PAINT:	
    //                hDC = WindowsAPI.GetWindowDC(m.HWnd);
    //                gdc = Graphics.FromHdc(hDC);
    //                SendMessage(this.Handle, WM_ERASEBKGND, hDC, 0);
    //                SendPrintClientMsg();
    //                SendMessage(this.Handle, WM_PAINT, IntPtr.Zero, 0);
    //                OverrideControlBorder(gdc);
    //                m.Result = (IntPtr) 1;	// indicate msg has been processed
    //                WindowsAPI.ReleaseDC(m.HWnd, hDC);
    //                gdc.Dispose();				
    //                break;
    //            case WM_PAINT:	
    //                base.WndProc(ref m);
    //                hDC = WindowsAPI.GetWindowDC(m.HWnd);
    //                gdc = Graphics.FromHdc(hDC);
    //                OverrideDropDown(gdc);
    //                OverrideControlBorder(gdc);
    //                WindowsAPI.ReleaseDC(m.HWnd, hDC);
    //                gdc.Dispose();				
    //                break;
    //                /*
    //                            // We don't need this anymore, handle by WM_SETCURSOR
    //                            case WM_NC_HITTEST: 
    //                                base.WndProc(ref m);
    //                                if (DroppedDown)
    //                                {
    //                                    OverrideDropDown(gdc);
    //                                    OverrideControlBorder(gdc);
    //                                }
    //                                break;
    //                            */
    //            case WM_SETCURSOR:
    //                base.WndProc(ref m);
    //                // The value 3 is discovered by trial on error, and cover all kinds of scenarios
    //                // InvalidateSince < 2 wil have problem if the control is not in focus and dropdown is clicked
    //                if (DroppedDown && InvalidateSince < 3)
    //                {
    //                    Invalidate();
    //                    InvalidateSince++;
    //                }
    //                break;
    //            default:
    //                base.WndProc(ref m);
    //                break;
    //        }
    //    }

		private void SendPrintClientMsg()
		{
			// We send this message for the control to redraw the client area
			Graphics gClient = this.CreateGraphics();
			IntPtr ptrClientDC = gClient.GetHdc();
			SendMessage(this.Handle, WM_PRINTCLIENT, ptrClientDC, 0);
			gClient.ReleaseHdc(ptrClientDC);
			gClient.Dispose();
		}

		private void OverrideDropDown(Graphics g)
		{
			if (!this.ShowUpDown)
			{
				Rectangle rect = new Rectangle(this.Width-DropDownButtonWidth, 0, DropDownButtonWidth, this.Height);
				ControlPaint.DrawComboButton(g, rect, ButtonState.Flat);	
			}
		}


        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.droppedDown = true;
            System.Diagnostics.Debug.WriteLine("mouseDown");
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("mouseUp");
            this.droppedDown = false;
            base.OnMouseUp(e);
        }
        
		private void OverrideControlBorder(Graphics g)
		{
			if (this.Focused == false || this.Enabled == false )
				g.DrawRectangle(BorderPenControl, new Rectangle(0, 0, this.Width, this.Height));
			else
				g.DrawRectangle(BorderPen, new Rectangle(0, 0, this.Width, this.Height));
		}

		protected override void OnDropDown(EventArgs eventargs)
		{
			//InvalidateSince = 0;
			droppedDown = true;
			base.OnDropDown (eventargs);
		}
		protected override void OnCloseUp(EventArgs eventargs)
		{
			droppedDown = false;
			base.OnCloseUp (eventargs);
		}
	
		protected override void OnLostFocus(System.EventArgs e)
		{
            //  为了使焦点回到最前面
            //  Robin   2007-04-09
            if (!this.droppedDown)
            {
                DateTimePickerFormat fmt;
                fmt = this.Format;
                if (fmt == DateTimePickerFormat.Short)
                    this.Format = DateTimePickerFormat.Long;
                else
                    this.Format = DateTimePickerFormat.Short;
                this.Format = fmt;
            }
            /////////////////////////////////////

			base.OnLostFocus(e);
			this.Invalidate();
		}

		protected override void OnGotFocus(System.EventArgs e)
		{
			base.OnGotFocus(e);
			this.Invalidate();
		}		
		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);
			this.Invalidate();
		}

        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                this.droppedDown = true;
            }
            else
            {
                this.droppedDown = false;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == (char)13 && this.isEnter2Tab)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
            }
        }

		[DllImport("user32.dll", EntryPoint="SendMessageA")]
		private static extern int SendMessage (IntPtr hwnd, int wMsg, IntPtr wParam, object lParam);

		[DllImport("user32.dll")]
		private static extern int GetFocus();
		const int WM_KEYDOWN=0x100;
		const int VK_RIGHT=0x27;
		const int VK_LEFT=0x25;

	}

    internal class DateTimePickerUpDownHook : System.Windows.Forms.NativeWindow
    {

        NeuDateTimePicker datetimepicker = null;

        public DateTimePickerUpDownHook(NeuDateTimePicker cb)
        {
            datetimepicker = cb;
        }

        protected override void WndProc(ref Message m)
        {
            Msg currentMessage = (Msg)m.Msg;

            switch (m.Msg)
            {
                case ((int)Msg.WM_LBUTTONDOWN):
                    this.datetimepicker.droppedDown = true;

                    break;
                case ((int)Msg.WM_LBUTTONUP):
                    this.datetimepicker.droppedDown = false;
                    break;

                default:
                    break;
            }

            base.WndProc(ref m);

        }

    }
}
