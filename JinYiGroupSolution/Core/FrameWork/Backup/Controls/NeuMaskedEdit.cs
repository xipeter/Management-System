using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuMaskedEdit<br></br>
	/// [功能描述: NeuMaskedEdit控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-18]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[ToolboxBitmap(typeof(TextBox)),Obsolete("VS2005应该使用 NeuMaskedTextBox控件",false)]
	public class NeuMaskedEdit : NeuTextBox
	{
		public NeuMaskedEdit()
		{
			this.m_maskType = InputMaskType.None;
			this.m_inpChar = '_';
			this.m_mask = "";
			this.m_format = "";
			this.m_caret = 0;
			this.m_errInvalid = false;
			base.Multiline = false;
		}


		// Fields
		private int m_caret;
		private bool m_errInvalid;
		private string m_format;
		private char m_inpChar;
		private string m_mask;
		private bool m_maskChg;
		private InputMaskType m_maskType;
		private int m_optCnt;
		private Hashtable m_posNdx;
		private Hashtable m_regexps;
		private int m_reqdCnt;
		private bool m_stdmaskChg;
		private const char MASK_KEY = '@';
		private const string PHONE = "000-00000000";
		private const string SSN = "000-00-0000";
		private const string ZIP = "00000-9999";



#region 属性

		[Description("Throw Error On Invalid Text/Value Property"), Category("Behavior")]
		public bool ErrorInvalid
		{
			get
			{
				return this.m_errInvalid;
			}
			set
			{
				this.m_errInvalid = value;
			}
		}
 

		[Category("Behavior"), RefreshProperties(RefreshProperties.All), Description("Sets the Input Char default '_'")]
		public char InputChar
		{
			get
			{
				return this.m_inpChar;
			}
			set
			{
				this.m_inpChar = value;
				this.InputMask = this.m_mask;
			}
		}
 

		/// <summary>
		/// Mask格式，例如"0000-9999"
		/// </summary>
		[Category("Behavior"), RefreshProperties(RefreshProperties.All), Description("Sets the Input Mask")]
		public string InputMask
		{
			get
			{
				return this.m_mask;
			}
			set
			{
				this.m_maskChg = true;
				this.m_mask = value;
				if (!this.m_stdmaskChg)
				{
					switch (value)
					{
						case "":
							this.StdInputMask = InputMaskType.None;
							goto Label_0087;

						case "000-00-0000":
							this.StdInputMask = InputMaskType.SSN;
							goto Label_0087;

						case "(999) 000-0000":
							this.StdInputMask = InputMaskType.Phone;
							goto Label_0087;

						case "00000-9999":
							this.StdInputMask = InputMaskType.Zip;
							goto Label_0087;
					}
					this.StdInputMask = InputMaskType.Custom;
				}

				Label_0087:
					this.SetupMask();
				if ((base.DesignMode || (base.Text.Length == 0)) || !this.IsValidString(base.Text))
				{
					base.Text = this.m_format;
				}
				else
				{
					this.Value = this.Value;
				}
				base.MaxLength = this.m_format.Length;
				this.m_maskChg = false;
			}
		}
 

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsValid
		{
			get
			{
				return this.IsValidString(base.Text);
			}
		}
 

		public override int MaxLength
		{
			get
			{
				return base.MaxLength;
			}
			set
			{
				if ((this.m_maskChg || this.m_stdmaskChg) || (this.StdInputMask == InputMaskType.None))
				{
					base.MaxLength = value;
				}
			}
		}
 

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override bool Multiline
		{
			get
			{
				return base.Multiline;
			}
		}
 

		private Hashtable RegExps
		{
			get
			{
				if (this.m_regexps == null)
				{
					this.m_regexps = new Hashtable();
					this.m_regexps.Add('0', "[0-9]");
					this.m_regexps.Add('9', "[0-9 ]");
					this.m_regexps.Add('L', "[a-z]");
					this.m_regexps.Add('l', "[a-z ]");
					this.m_regexps.Add('U', "[A-Z]");
					this.m_regexps.Add('u', "[A-Z ]");
					this.m_regexps.Add('A', "[a-zA-Z]");
					this.m_regexps.Add('a', "[a-zA-Z ]");
					this.m_regexps.Add('D', "[a-zA-Z0-9]");
					this.m_regexps.Add('d', "[a-zA-Z0-9 ]");
					this.m_regexps.Add('C', ".");
					this.m_regexps.Add('@', "[09LlUuAaDdC]");
				}
				return this.m_regexps;
			}
		}
 

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override int SelectionLength
		{
			get
			{
				return base.SelectionLength;
			}
		}
 

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new int SelectionStart
		{
			get
			{
				return base.SelectionStart;
			}
		}
 

		[Category("Behavior"), Description("Sets Predefined Input Mask"), RefreshProperties(RefreshProperties.All)]
		public InputMaskType StdInputMask
		{
			get
			{
				return this.m_maskType;
			}
			set
			{
				this.m_stdmaskChg = true;
				this.m_maskType = value;
				if (!this.m_maskChg)
				{
					switch (value)
					{
						case InputMaskType.None:
							this.InputMask = "";
							goto Label_0075;

						case InputMaskType.SSN:
							this.InputMask = "000-00-0000";
							goto Label_0075;

						case InputMaskType.Phone:
							this.InputMask = "(999) 000-0000";
							goto Label_0075;

						case InputMaskType.Zip:
							this.InputMask = "00000-9999";
							goto Label_0075;

						case InputMaskType.Custom:
							goto Label_0075;
					}
					throw new ApplicationException("Invalid InputMaskType");
				}
				Label_0075:
					this.m_stdmaskChg = false;
			}
		}
 

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				if (this.m_maskType == InputMaskType.None)
				{
					base.Text = value;
				}
				else if (value == "")
				{
					base.Text = this.m_format;
				}
				else if (this.IsValidString(value) && (value.Length == this.m_format.Length))
				{
					bool flag1 = true;
					for (int num1 = 0; flag1 && (num1 < this.m_format.Length); num1++)
					{
						if ((this.m_format[num1] == this.m_inpChar) && !this.IsValidChar(value[num1], (int) this.m_posNdx[num1]))
						{
							flag1 &= value[num1] == this.m_inpChar;
						}
					}
					if (flag1)
					{
						base.Text = value;
					}
				}
				else if (this.m_errInvalid)
				{
					throw new ApplicationException("Input String Does Not Match Input Mask");
				}
			}
		}


		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public string Value
		{
			get
			{
				if (this.m_maskType == InputMaskType.None)
				{
					return base.Text;
				}
				string text1 = "";
				string text2 = this.InputMask;
				string text3 = base.Text;
				if (this.IsValidString(text3))
				{
					int num1 = 0;
					for (int num2 = 0; num2 < text2.Length; num2++)
					{
						if ((this.IsMaskChar(text2[num2]) && (text3[num1] != ' ')) && (text3[num1] != this.m_inpChar))
						{
							text1 = text1 + text3[num1];
						}
						else if (text2[num2] == '\\')
						{
							num2++;
						}
						num1++;
					}
				}
				return text1;
			}
			set
			{
				if (this.m_maskType == InputMaskType.None)
				{
					base.Text = value;
				}
				else
				{
					string text1 = "";
					int num1 = 0;
					int num2 = value.Length - this.m_reqdCnt;
					if (value == "")
					{
						base.Text = this.m_format;
					}
					else if ((value.Length >= this.m_reqdCnt) && (value.Length <= (this.m_reqdCnt + this.m_optCnt)))
					{
						for (int num3 = 0; num3 < this.m_format.Length; num3++)
						{
							if ((num1 < value.Length) && (this.m_format[num3] == this.m_inpChar))
							{
								if (((string) this.RegExps[this.InputMask[(int) this.m_posNdx[num3]]]).IndexOf(' ') != -1)
								{
									if (num2 > 0)
									{
										text1 = text1 + value[num1++];
										num2--;
									}
									else
									{
										text1 = text1 + this.m_format[num3];
									}
								}
								else
								{
									text1 = text1 + value[num1++];
								}
							}
							else
							{
								text1 = text1 + this.m_format[num3];
							}
						}
					}
					else if (this.m_errInvalid)
					{
						throw new ApplicationException("Input String Does Not Match Input Mask");
					}
					if (this.IsValidString(text1))
					{
						base.Text = text1;
					}
					else if (this.m_errInvalid)
					{
						throw new ApplicationException("Input String Does Not Match Input Mask");
					}
				}
			}
		}
 


#endregion

		#region 方法

		private bool IsMaskChar(char input)
		{
			return Regex.IsMatch(input.ToString(), (string) this.RegExps['@']);
		}


		private bool IsValidChar(char input, int pos)
		{
			return Regex.IsMatch(input.ToString(), (string) this.RegExps[this.InputMask[pos]]);
		}

 
		private bool IsValidString(string s)
		{
			bool flag1 = true;
			for (int num1 = 0; flag1 && (num1 < this.m_format.Length); num1++)
			{
				if (this.m_format[num1] == this.m_inpChar)
				{
					if (num1 >= s.Length)
					{
						flag1 = ((string) this.RegExps[this.InputMask[(int) this.m_posNdx[num1]]]).IndexOf(' ') != -1;
					}
					else
					{
						flag1 = this.IsValidChar(s[num1], (int) this.m_posNdx[num1]);
						if (!flag1)
						{
							flag1 |= (((string) this.RegExps[this.InputMask[(int) this.m_posNdx[num1]]]).IndexOf(' ') != -1) && ((s[num1] == ' ') || (s[num1] == this.m_inpChar));
						}
					}
				}
				else if (num1 < s.Length)
				{
					flag1 = s[num1] == this.m_format[num1];
				}
			}
			return flag1;
		}


		private int Next(int startPos)
		{
			int num1 = startPos;
			int num2 = num1;
			while (num1 < (base.MaxLength - 1))
			{
				num1++;
				if (this.m_format[num1] == this.m_inpChar)
				{
					return num1;
				}
			}
			return num2;
		}

 
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (this.StdInputMask == InputMaskType.None)
			{
				base.OnKeyPress(e);
			}
			else
			{
				int num1 = base.SelectionStart;
				int num2 = base.SelectionLength;
				if (e.KeyChar == '\b')
				{
					string text1 = base.Text;
					int num3 = this.Prev(num1);
					if (num3 != num1)
					{
						base.Text = text1.Substring(0, num3) + this.m_inpChar.ToString() + text1.Substring(num3 + 1);
						base.SelectionStart = num3;
						base.SelectionLength = 1;
					}
					this.m_caret = num3;
					e.Handled = true;
				}
				else
				{
					if (this.m_format[num1] != this.m_inpChar)
					{
						num1 = this.Next(-1);
						num2 = 1;
					}
					if (this.IsValidChar(e.KeyChar, (int) this.m_posNdx[num1]))
					{
						string text2 = "";
						text2 = base.Text.Substring(0, num1);
						text2 = text2 + e.KeyChar.ToString();
						if ((num1 + num2) != base.MaxLength)
						{
							text2 = text2 + this.m_format.Substring(num1 + 1, num2 - 1);
							text2 = text2 + base.Text.Substring(num1 + num2);
						}
						else
						{
							text2 = text2 + this.m_format.Substring(num1 + 1);
						}
						base.Text = text2;
						num1 = this.Next(num1);
						base.SelectionStart = num1;
						this.m_caret = num1;
						base.SelectionLength = 1;
					}
					e.Handled = true;
				}
			}
		}

 
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (this.StdInputMask == InputMaskType.None)
			{
				base.OnMouseUp(e);
			}
			else
			{
				int num1 = base.SelectionStart;
				int num2 = num1;
				int num3 = base.SelectionLength;
				if ((num1 == base.MaxLength) || (this.m_format[num1] != this.m_inpChar))
				{
					if (this.Next(num1) == num1)
					{
						num1 = this.Prev(num1);
					}
					else
					{
						num1 = this.Next(num1);
					}
					base.SelectionStart = num1;
				}
				if (num3 < 1)
				{
					base.SelectionLength = 1;
				}
				else if (this.m_format[(num2 + num3) - 1] != this.m_inpChar)
				{
					num3 += this.Next(num1 + num3) - (num1 + num3);
					base.SelectionLength = num3;
				}
				this.m_caret = num1;
				base.OnMouseUp(e);
			}
		}


		private int Prev(int startPos)
		{
			int num1 = startPos;
			int num2 = num1;
			while (num1 > 0)
			{
				num1--;
				if (this.m_format[num1] == this.m_inpChar)
				{
					return num1;
				}
			}
			return num2;
		}

 
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			int num4;
			if (this.StdInputMask == InputMaskType.None)
			{
				return base.ProcessCmdKey(ref msg, keyData);
			}
			int num1 = base.SelectionStart;
			int num2 = base.SelectionLength;
			int num3 = (num1 + base.SelectionLength) - 1;
			string text1 = base.Text;
			if (this.m_format[num1] != this.m_inpChar)
			{
				num1 = this.Next(-1);
				num2 = 1;
			}
			switch (keyData)
			{
				case Keys.End:
					base.SelectionStart = this.Prev(base.MaxLength);
					base.SelectionLength = 1;
					this.m_caret = base.SelectionStart;
					return true;

				case Keys.Home:
					base.SelectionStart = this.Next(-1);
					base.SelectionLength = 1;
					this.m_caret = base.SelectionStart;
					return true;

				case Keys.Left:
				case Keys.Up:
					num4 = this.Prev(num1);
					if (num4 != num1)
					{
						base.SelectionStart = num4;
						base.SelectionLength = 1;
					}
					this.m_caret = num4;
					return true;

				case Keys.Right:
				case Keys.Down:
					num4 = this.Next(num1);
					if (num4 != num1)
					{
						base.SelectionStart = num4;
						base.SelectionLength = 1;
					}
					this.m_caret = num4;
					return true;

				case Keys.Select:
				case Keys.Print:
				case Keys.Execute:
				case Keys.Snapshot:
				case Keys.Insert:
				case (Keys.Shift | Keys.Select):
				case (Keys.Shift | Keys.Print):
				case (Keys.Shift | Keys.Execute):
				case (Keys.Shift | Keys.Snapshot):
					goto Label_0398;

				case Keys.Delete:
					base.Text = text1.Substring(0, num1) + this.m_format.Substring(num1, num2) + text1.Substring(num1 + num2);
					base.SelectionStart = num1;
					base.SelectionLength = 1;
					this.m_caret = num1;
					return true;

				case (Keys.Shift | Keys.End):
					if (num1 >= this.m_caret)
					{
						if (num1 == this.m_caret)
						{
							num4 = this.Prev(base.MaxLength);
							base.SelectionLength = num2 + (num4 - num3);
						}
						goto Label_0337;
					}
					num4 = this.Prev(base.MaxLength);
					base.SelectionStart = this.m_caret;
					base.SelectionLength = (num4 - this.m_caret) + 1;
					goto Label_0337;

				case (Keys.Shift | Keys.Home):
					if ((num1 > this.m_caret) || (num2 > 1))
					{
						num4 = this.Next(-1);
						base.SelectionStart = num4;
						base.SelectionLength = (this.m_caret - num4) + 1;
						goto Label_02A9;
					}
					num4 = this.Next(-1);
					base.SelectionStart -= num1 - num4;
					base.SelectionLength = num2 + (num1 - num4);
					goto Label_02A9;

				case (Keys.Shift | Keys.Left):
				case (Keys.Shift | Keys.Up):
					if ((num1 >= this.m_caret) && ((num1 != this.m_caret) || (num2 > 1)))
					{
						base.SelectionLength = num2 - (num3 - this.Prev(num3));
						break;
					}
					num4 = this.Prev(num1);
					base.SelectionStart -= num1 - num4;
					base.SelectionLength = num2 + (num1 - num4);
					break;

				case (Keys.Shift | Keys.Right):
				case (Keys.Shift | Keys.Down):
					if (num1 >= this.m_caret)
					{
						if (num1 == this.m_caret)
						{
							num4 = this.Next(num3);
							base.SelectionLength = num2 + (num4 - num3);
						}
						goto Label_01DC;
					}
					num4 = this.Next(num1);
					base.SelectionStart += num4 - num1;
					base.SelectionLength = num2 - (num4 - num1);
					goto Label_01DC;

				case (Keys.Shift | Keys.Insert):
				case (Keys.Control | Keys.V):
				{
					IDataObject obj1 = Clipboard.GetDataObject();
					string text2 = text1.Substring(0, num1) + ((string) obj1.GetData(DataFormats.Text)) + text1.Substring(num1 + num2);
					if (this.IsValidString(text2))
					{
						base.Text = text2;
					}
					else if (this.m_errInvalid)
					{
						throw new ApplicationException("Input String Does Not Match Input Mask");
					}
					return true;
				}
				default:
					goto Label_0398;
			}
			return true;
			Label_01DC:
				return true;
			Label_02A9:
				return true;
			Label_0337:
				return true;
			Label_0398:
				return base.ProcessCmdKey(ref msg, keyData);
		}

 
		private void SetupMask()
		{
			string text1 = this.InputMask;
			this.m_format = "";
			if (this.m_posNdx == null)
			{
				this.m_posNdx = new Hashtable();
			}
			else
			{
				this.m_posNdx.Clear();
			}
			int num1 = 0;
			this.m_reqdCnt = 0;
			this.m_optCnt = 0;
			for (int num2 = 0; num2 < text1.Length; num2++)
			{
				if (this.IsMaskChar(text1[num2]))
				{
					this.m_posNdx.Add(num1, num2);
					this.m_format = this.m_format + this.m_inpChar;
					if (((string) this.RegExps[this.InputMask[num2]]).IndexOf(' ') != -1)
					{
						this.m_optCnt++;
					}
					else
					{
						this.m_reqdCnt++;
					}
				}
				else if (text1[num2] == '\\')
				{
					num2++;
					this.m_format = this.m_format + text1[num2].ToString();
				}
				else
				{
					this.m_format = this.m_format + text1[num2].ToString();
				}
				num1++;
			}
		}

 

		#endregion
		// Nested Types
		public enum InputMaskType
		{
			None,
			SSN,
			Phone,
			Zip,
			Custom
		}
	}

}
