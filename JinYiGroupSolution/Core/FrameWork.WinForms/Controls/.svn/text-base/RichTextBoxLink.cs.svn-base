using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// 可添加链接的RichTextBox
	/// </summary>
    public class RichTextBox : Neusoft.FrameWork.EPRControl.emrMultiLineTextBox//System.Windows.Forms.RichTextBox
	{
		#region Interop-Defines
		[ StructLayout( LayoutKind.Sequential )]
			private struct CHARFORMAT2_STRUCT
		{
			public UInt32	cbSize; 
			public UInt32   dwMask; 
			public UInt32   dwEffects; 
			public Int32    yHeight; 
			public Int32    yOffset; 
			public Int32	crTextColor; 
			public byte     bCharSet; 
			public byte     bPitchAndFamily; 
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
			public char[]   szFaceName; 
			public UInt16	wWeight;
			public UInt16	sSpacing;
			public int		crBackColor; // Color.ToArgb() -> int
			public int		lcid;
			public int		dwReserved;
			public Int16	sStyle;
			public Int16	wKerning;
			public byte		bUnderlineType;
			public byte		bAnimation;
			public byte		bRevAuthor;
			public byte		bReserved1;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		private const int WM_USER			 = 0x0400;
		private const int EM_GETCHARFORMAT	 = WM_USER+58;
		private const int EM_SETCHARFORMAT	 = WM_USER+68;

		private const int SCF_SELECTION	= 0x0001;
		private const int SCF_WORD		= 0x0002;
		private const int SCF_ALL		= 0x0004;

		#region CHARFORMAT2 Flags
		private const UInt32 CFE_BOLD		= 0x0001;
		private const UInt32 CFE_ITALIC		= 0x0002;
		private const UInt32 CFE_UNDERLINE	= 0x0004;
		private const UInt32 CFE_STRIKEOUT	= 0x0008;
		private const UInt32 CFE_PROTECTED	= 0x0010;
		private const UInt32 CFE_LINK		= 0x0020;
		private const UInt32 CFE_AUTOCOLOR	= 0x40000000;
		private const UInt32 CFE_SUBSCRIPT	= 0x00010000;		/* Superscript and subscript are */
		private const UInt32 CFE_SUPERSCRIPT= 0x00020000;		/*  mutually exclusive			 */

		private const int CFM_SMALLCAPS		= 0x0040;			/* (*)	*/
		private const int CFM_ALLCAPS		= 0x0080;			/* Displayed by 3.0	*/
		private const int CFM_HIDDEN		= 0x0100;			/* Hidden by 3.0 */
		private const int CFM_OUTLINE		= 0x0200;			/* (*)	*/
		private const int CFM_SHADOW		= 0x0400;			/* (*)	*/
		private const int CFM_EMBOSS		= 0x0800;			/* (*)	*/
		private const int CFM_IMPRINT		= 0x1000;			/* (*)	*/
		private const int CFM_DISABLED		= 0x2000;
		private const int CFM_REVISED		= 0x4000;

		private const int CFM_BACKCOLOR		= 0x04000000;
		private const int CFM_LCID			= 0x02000000;
		private const int CFM_UNDERLINETYPE	= 0x00800000;		/* Many displayed by 3.0 */
		private const int CFM_WEIGHT		= 0x00400000;
		private const int CFM_SPACING		= 0x00200000;		/* Displayed by 3.0	*/
		private const int CFM_KERNING		= 0x00100000;		/* (*)	*/
		private const int CFM_STYLE			= 0x00080000;		/* (*)	*/
		private const int CFM_ANIMATION		= 0x00040000;		/* (*)	*/
		private const int CFM_REVAUTHOR		= 0x00008000;


		private const UInt32 CFM_BOLD		= 0x00000001;
		private const UInt32 CFM_ITALIC		= 0x00000002;
		private const UInt32 CFM_UNDERLINE	= 0x00000004;
		private const UInt32 CFM_STRIKEOUT	= 0x00000008;
		private const UInt32 CFM_PROTECTED	= 0x00000010;
		private const UInt32 CFM_LINK		= 0x00000020;
		private const UInt32 CFM_SIZE		= 0x80000000;
		private const UInt32 CFM_COLOR		= 0x40000000;
		private const UInt32 CFM_FACE		= 0x20000000;
		private const UInt32 CFM_OFFSET		= 0x10000000;
		private const UInt32 CFM_CHARSET	= 0x08000000;
		private const UInt32 CFM_SUBSCRIPT	= CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
		private const UInt32 CFM_SUPERSCRIPT= CFM_SUBSCRIPT;

		private const byte CFU_UNDERLINENONE		= 0x00000000;
		private const byte CFU_UNDERLINE			= 0x00000001;
		private const byte CFU_UNDERLINEWORD		= 0x00000002; /* (*) displayed as ordinary underline	*/
		private const byte CFU_UNDERLINEDOUBLE		= 0x00000003; /* (*) displayed as ordinary underline	*/
		private const byte CFU_UNDERLINEDOTTED		= 0x00000004;
		private const byte CFU_UNDERLINEDASH		= 0x00000005;
		private const byte CFU_UNDERLINEDASHDOT		= 0x00000006;
		private const byte CFU_UNDERLINEDASHDOTDOT	= 0x00000007;
		private const byte CFU_UNDERLINEWAVE		= 0x00000008;
		private const byte CFU_UNDERLINETHICK		= 0x00000009;
		private const byte CFU_UNDERLINEHAIRLINE	= 0x0000000A; /* (*) displayed as ordinary underline	*/

		#endregion

		#endregion

		public RichTextBox()
		{
			
			this.DetectUrls = false;
			
		}

		[DefaultValue(false)]
		public new bool DetectUrls
		{
			get { return base.DetectUrls; }
			set { base.DetectUrls = value; }
		}
		string myText = "";

		/// <summary>
		/// 获得
		/// </summary>
		public new string Text
		{
			get
			{
				this.myText = this.GetTrueText() ;
				return this.myText;
			}
			set
			{
				myText = value;
			}
		}
		protected override void WndProc(ref Message m)
		{
			if( m.Msg == 15)
			{
				if(bPaint)
				{
				}
				else
				{
					base.WndProc (ref m);
				}
			}
			else
			{
				base.WndProc (ref m);
			}
		}

	

		/// <summary>
		/// Insert a given text at a given position as a link. 
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="position">Insert position</param>
		public void InsertLink(string text, int position)
		{
			if (position < 0 || position > base.Text.Length)
				throw new ArgumentOutOfRangeException("position");

			this.SelectionStart = position;
			this.SelectedText = text;
			this.Select(position, text.Length);
			this.SetSelectionLink(true);
			this.Select(position + text.Length, 0);
		}
		
		/// <summary>
		/// Insert a given text at at the current input position as a link.
		/// The link text is followed by a hash (#) and the given hyperlink text, both of
		/// them invisible.
		/// When clicked on, the whole link text and hyperlink string are given in the
		/// LinkClickedEventArgs.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
		public void InsertLink(string text, string hyperlink)
		{
			InsertLink(text, hyperlink, this.SelectionStart);
		}

		/// <summary>
		/// Insert a given text at a given position as a link. The link text is followed by
		/// a hash (#) and the given hyperlink text, both of them invisible.
		/// When clicked on, the whole link text and hyperlink string are given in the
		/// LinkClickedEventArgs.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
		/// <param name="position">Insert position</param>
		public void InsertLink(string text, string hyperlink, int position)
		{
			if (position < 0 || position > base.Text.Length)
				throw new ArgumentOutOfRangeException("position");

			this.SelectionStart = position;
			this.SelectedRtf = @"{\rtf1\ansi\ansicpg936 "+text+@"\v #"+hyperlink+@"\v0}"; //@"{\rtf1\ansi\ansicpg936 "+text+@"\v #"+hyperlink+@"\v0}";
			this.Select(position, text.Length + hyperlink.Length + 1);//((Byte[])System.Text.Encoding.Default.GetBytes(text)).Length + hyperlink.Length + 1);
			this.SetSelectionLink(true);
			this.Select(position + text.Length + hyperlink.Length + 1, 0);
		}

		/// <summary>
		/// Set the current selection's link style
		/// </summary>
		/// <param name="link">true: set link style, false: clear link style</param>
		public void SetSelectionLink(bool link)
		{
			SetSelectionStyle(CFM_LINK, link ? CFE_LINK : 0);
		}
		/// <summary>
		/// Get the link style for the current selection
		/// </summary>
		/// <returns>0: link style not set, 1: link style set, -1: mixed</returns>
		public int GetSelectionLink()
		{
			return GetSelectionStyle(CFM_LINK, CFE_LINK);
		}


		private void SetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.dwMask = mask;
			cf.dwEffects = effect;

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = Marshal.AllocCoTaskMem( Marshal.SizeOf( cf ) ); 
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

			Marshal.FreeCoTaskMem(lpar);
		}

		private int GetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.szFaceName = new char[32];

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = 	Marshal.AllocCoTaskMem( Marshal.SizeOf( cf ) ); 
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);

			cf = (CHARFORMAT2_STRUCT)Marshal.PtrToStructure(lpar, typeof(CHARFORMAT2_STRUCT));

			int state;
			// dwMask holds the information which properties are consistent throughout the selection:
			if ((cf.dwMask & mask) == mask) 
			{
				if ((cf.dwEffects & effect) == effect)
					state = 1;
				else
					state = 0;
			}
			else
			{
				state = -1;
			}
			
			Marshal.FreeCoTaskMem(lpar);
			return state;
		}

		public void InsertLink(string TextAndHyperlink)
		{
			if(TextAndHyperlink.Length < 7) return;
			TextAndHyperlink = TextAndHyperlink.Substring(2);
			//			TextAndHyperlink = TextAndHyperlink.Substring(0, TextAndHyperlink.Length - 2);
			int seperaterPos = TextAndHyperlink.IndexOf("#");
			if(seperaterPos == -1) return;
			string text = TextAndHyperlink.Substring(0, seperaterPos);
			string hyperlink = TextAndHyperlink.Substring(seperaterPos + 1);
			InsertLink(text,hyperlink);
		}

		public void InsertText(string Text)
		{
			this.SelectedText = (Text);
			//this.Select(this.SelectionStart + Text.Length, 0);
		}

		private void InsertTextAndHyperlink(string text)
		{
			int curPos = 0;
			int startPos = 0;
			int endPos = 0;
			try
			{
				while(true)
				{
					startPos =text.IndexOf("^@", curPos);
					if(startPos == -1) break;
					endPos = text.IndexOf("@^", startPos);
					if(endPos == -1) break;
					if(curPos != startPos)
					{
						string str = @text.Substring(curPos, startPos - curPos);
						InsertText(str);
					}
					InsertLink(@text.Substring(startPos, endPos - startPos + 2));
					curPos = endPos + 2;
				}
				if(curPos != text.Length)
				{
					string str = text.Substring(curPos);
					InsertText(str);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		/// <summary>
		/// 超级文本
		/// </summary>
		public string SuperText
		{
			get
			{
				return this.GetText();
			}
			set
			{
				if(value == null) return;
				base.Text ="";
				this.InsertTextAndHyperlink(value);
			}
		}
		private string GetTrueText()
		{
			string s = base.Text;
			if(s==null) return "";
			try
			{
				while(true)
				{
					int start,end;
					start = s.IndexOf("#");
					end = s.IndexOf("@^");
					if(start>=0 && end >start)
					{
						s = s.Substring(0,start)+s.Substring(end+2);
					}
					else
					{
						break;
					}
				}
			}
			catch{}
			return s;
		}
		/// <summary>
		/// 获得文本
		/// </summary>
		/// <returns></returns>
		public static string GetTureText(string text)
		{
			string s = text;
			if(s==null) return "";
			try
			{
				while(true)
				{
					int start,end;
					start = s.IndexOf("#");
					end = s.IndexOf("@^");
					if(start>=0 && end >start)
					{
						s = s.Substring(0,start)+s.Substring(end+2);
					}
					else
					{
						break;
					}
				}
			}
			catch{}
			return s;
		}
		private bool bPaint = false;
		private string GetText()
		{
			string result = base.Text;
			if(result==null) return "";
			bool b = false;
			int k = 0;
			int start = this.SelectionStart ;
			int selectedLength = this.SelectionLength;
			
//			RichTextBoxEx tmp = new RichTextBoxEx();
//			tmp.Rtf  = this.Rtf ;
			bPaint  = true;
			for(int i=0;i<base.Text.Length;i++)
			{
				this.Select(i, 1);
				if(this.GetSelectionLink().ToString()=="1" )
				{
					if(b==false) 
					{
						result = result.Insert(i+k,"^@");
						k = k + 2;
					}
					b = true;
				}
//				else if(this.GetSelectionLink().ToString()=="0"
//					&& b)
//				{
//					//b = true;
//				}
				else
				{
					b = false;
				}
			}
			if(start >=0 && selectedLength>=0)
				this.Select(start,selectedLength);
//			this.ResumeLayout(false);
			//this.Invalidate();
			//bInvalide = true;
			bPaint = false;
			return result;
			
		}


		//bool bInvalide = true;
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
            //Comment and Added by Liuzhc
            //2007-5-26
            //For Com_Text from nvarchar2 to long
            ////base.OnDragDrop (drgevent);
            string s = drgevent.Data.GetData("Text", false).ToString();// drgevent.Data.GetData(DataFormats.StringFormat, true).ToString();
            if (s == "") return;
            this.InsertTextAndHyperlink(s);
            drgevent.Data.SetData("");

            //string rtf = drgevent.Data.GetData("Rtf", false).ToString();
            //if (rtf != "")
            //{
            //    base.OnDragDrop(drgevent);
            //}
            //else
            //{
                //string s = drgevent.Data.GetData("Text", false).ToString();
                //if (s == "") return;

                //this.InsertTextAndHyperlink(s);
                //drgevent.Data.SetData("");
            //}

		}
//		protected override void OnInvalidated(InvalidateEventArgs e)
//		{
//			if(bInvalide)
//				base.OnInvalidated (e);
//		}


		protected override void OnKeyDown(KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown)
				{
					if(this.SelectionLength == 0 && this.SelectionStart>0 && this.SelectionStart <base.Text.Length)
					{
						if(base.Text.Substring(this.SelectionStart, 1) == "#")
						{
							this.Select(this.SelectionStart - 1, 1);
							if(this.GetSelectionLink() == 1)
							{
								int index = base.Text.IndexOf("@^", this.SelectionStart + 1);
								if(index != -1)
								{
									this.Select(index + 2, 0);
								}
							}
							else
							{
								this.Select(this.SelectionStart + 1, 0);
							}
						}
					}
					else
					{

					}
				}
			}
			catch{}
			base.OnKeyDown (e);
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RichTextBox
            // 
            this.EnableAutoDragDrop = true;
            this.ResumeLayout(false);

        }
		

	}
}


