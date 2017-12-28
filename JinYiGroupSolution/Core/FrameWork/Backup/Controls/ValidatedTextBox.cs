
	
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Text.RegularExpressions;
	using System.Globalization;

namespace Neusoft.FrameWork.WinForms.Controls
	{

	/// <summary>
	///
	/// 日期：2004.10.12
	/// 功能：验证控件TextBox:	选择输入的格式，并进行验证。
	/// 
	///	修改描述：(对此修改的描述)
	///	修改者：
	///	修改日期：(模块修改日期，格式：YYYY-MM-DD)
	/// </summary>


	public class ValidatedTextBox : BaseValidatingTextBox
	{

		[Description("小数的位数")]
		public int MaxDigits
		{
			get
			{
				return DecimalBehavior.MaxDigits;
			}
			set
			{
				DecimalBehavior.MaxDigits = value;
				if(MaxDigits == 0)
				{
					this.DecimalBehavior.DecimalPoint = (char)0;
				}
			}
		}

		[Description("是否允许为负值")]
		public bool AllowNegative
		{
			get
			{
				return DecimalBehavior.AllowNegative;
			}
			set
			{
				DecimalBehavior.AllowNegative = value;
			}
		}

		[Description("末位是否自动补零")]  		
		public bool AutoPadRightZero
		{
			get
			{
				return DecimalBehavior.AutoPadRightZero;
			}
			set
			{
				DecimalBehavior.AutoPadRightZero = value;
			}
		}

		[Browsable(false)]
		public DecimalType DecimalBehavior
		{
			get
			{
				return (DecimalType)dataInputBehavior;
			}
		}

		public ValidatedTextBox()
		{
			dataInputBehavior = new DecimalType(this);

			this.Validated += new EventHandler(ValidatedTextBox_Validated);
		}

		private void ValidatedTextBox_Validated(object sender, EventArgs e)
		{
			dataInputBehavior.Validating(this.Text);
		}
	}



	public interface IDataInputBehavior
	{
		bool WillShowError
		{
			get; set;
		}
		string ErrorMessage
		{ get; }

		void HandleKeyPress(object sender, KeyPressEventArgs e);
		void HandleKeyDown(object sender, KeyEventArgs e);
		bool Validating(string val);
		void ShowErrorMessageBox(string message);
		void ShowErrorIcon(string message);

	}

	public class Selection
	{
		private TextBoxBase textBox;


		public event EventHandler TextChanging;

		public Selection(TextBoxBase textbox)
		{
			textBox = textbox;
		}

		public void Get(out int start, out int end)
		{
			start = textBox.SelectionStart;
			end = start + textBox.SelectionLength;
			
			if (start < 0)
				start = 0;
			if (end < start)
				end = start;
		}

		public void SetAndReplace(int start, int end, string text)
		{
			Set(start, end);
			Replace(text);
		}

		public void Set(int start, int end)
		{
			textBox.SelectionStart = start;
			textBox.SelectionLength = end - start;
		}

		public void Replace(string text)
		{
			if (TextChanging != null)
				TextChanging(this, null);

			textBox.SelectedText = text;
		}


	}


	public abstract class AbstractDataBehavior : IDataInputBehavior
	{
		private bool willShowError = false;
		#region IDataInputType 成员
		protected string errorMsg ;
		protected TextBoxBase   textBox;
		protected Selection selection;
		protected ErrorProvider errorProvider;
		 

		protected AbstractDataBehavior(TextBoxBase textbox)
		{
			errorMsg = "DataType Error.";
			textBox = textbox;
			selection = new Selection(textbox);

			AddHandleEvent();
		}

		public virtual void AddHandleEvent()
		{
			textBox.KeyDown += new KeyEventHandler(HandleKeyDown);
			textBox.KeyPress += new KeyPressEventHandler(HandleKeyPress);
			textBox.Validating += new CancelEventHandler(ValueValidating);
		}

		public virtual string RegexString
		{
			get
			{
				return ".";
			}
		
		}

		public virtual object Value
		{
			get
			{
				return string.Empty;
			}
		}

		public string ErrorMessage
		{
			get
			{
				// TODO:  添加 DataType.ErrorMsg getter 实现
				return errorMsg;
			}
		}

		public abstract void HandleKeyPress(object sender, KeyPressEventArgs e);
		public abstract void HandleKeyDown(object sender, KeyEventArgs e);     
		public abstract bool Validating(string val)   ;
		public	void ShowErrorMessageBox(string message)
		{
			
		}

		public virtual void ShowErrorIcon(string message)
		{
            if (willShowError)
            {
                if (errorProvider == null)
                {
                    if (message == "")
                        return;
                    errorProvider = new ErrorProvider();
                }
                errorProvider.SetError(this.textBox, message);
            }
		}


		#endregion
							 

		public bool WillShowError
		{
			get
			{
				return willShowError;
			}
			set
			{
				willShowError = value;
			}
		}


		private void ValueValidating(object sender, CancelEventArgs e)
		{
			ShowErrorIcon("");

			if(RegexValidate(this.Value.ToString()) == false)
			{
				ShowErrorIcon(this.ErrorMessage); 	
				this.textBox.Text="0.00";
			}

		}

		private bool RegexValidate(string text)
		{
			System.Text.RegularExpressions.Regex  match = new Regex(this.RegexString);
			
			try
			{
				if(match.Match(text).Success)
					return true;        				 
			}
			catch    
			{   			
			}
			return false;
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		protected static extern bool MessageBeep(MessageBoxIcon mbi);
	}


	 

	/// <summary>
	/// 整数类型
	/// </summary>
	public class IntegerType : AbstractDataBehavior
	{
		public IntegerType(TextBoxBase textbox) : base(textbox)
		{
		
		}

		public override void HandleKeyPress(object sender, KeyPressEventArgs e)
		{
		}
		
		public override void HandleKeyDown(object sender, KeyEventArgs e)
		{
		}

		public override bool Validating(string val)   
		{
			return true;
		}

	}

	/// <summary>
	/// 小数类型
	/// </summary>
	public class DecimalType : AbstractDataBehavior
	{
		protected string Prefix = "";
		private char GroupSeparator = NumberFormatInfo.CurrentInfo.NumberGroupSeparator[0];
		private char decimalPoint = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0];
		private char NegativeSign = NumberFormatInfo.CurrentInfo.NegativeSign[0];
		private string numericText = "";
		private bool allowNegative = true;
		private bool autoPadRightZero = false;
		
		private string regexString = "";
		//小数的位数
		private int maxDigits = 4;




		public DecimalType(TextBoxBase textbox) : base(textbox)
		{
		
			textbox.TextChanged += new EventHandler(textbox_TextChanged);
			numericText = textbox.Text;
		}


		public char DecimalPoint
		{
			get
			{
				return this.decimalPoint;
			}
			set
			{
				this.decimalPoint = value;
			}
		}


		[Category("Customer")]
		[Description("小数的位数")]
		public int MaxDigits
		{
			get{ return this.maxDigits; }
			set
			{
				this.maxDigits = value; 
				regexString = @"^((-?\d+)|)[\.]" + @"?[0-9]{0,"+value.ToString() +@"}$";
			}
		}


		/// <summary>
		/// 整数的位数
		/// </summary>
		public int MaxIntegerDigits
		{
			get
			{
				return 0;
			}
		}


		/// <summary>
		/// 是否允许为负数
		/// </summary>
		public bool AllowNegative
		{
			get
			{
				return allowNegative;
			}
			set
			{
				allowNegative = value;
			}
		}

		/// <summary>
		/// 是否自动补齐右边的0.
		/// </summary>		
		public bool AutoPadRightZero
		{
			get{ return autoPadRightZero; }
			set{ autoPadRightZero = value; }
		}


		public override object Value
		{
			get
			{
				return this.numericText;
			}
		}

		public override string RegexString
		{
			get
			{
				if(regexString == "")
					regexString = @"^((-?\d+)|)[\.]" + @"?[0-9]{0,"+MaxDigits.ToString() +@"}$";

				return regexString ;
			}
		}



		
		
		
		public override void HandleKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Delete)
			{
				int start, end;
				selection.Get(out start,out end);

				string text = textBox.Text;
				int prefixLength = Prefix.Length; 				
				int length = text.Length;
				if(start < prefixLength && length > prefixLength)
				{
					if(end != length)
						e.Handled = true;
					return;
				}

				if(start < length && text[start] == GroupSeparator && start == end)
				{
					SendKeys.Send("{RIGHT}");
				}

				if (end == length)
					SendKeys.Send("{RIGHT}");
			}
		}


		public override void HandleKeyPress(object sender, KeyPressEventArgs e)
		{
			if(textBox.ReadOnly)
				return;
			string text = textBox.Text;

			int start, end;
			selection.Get(out start,out end);

			int decimalPos = textBox.Text.IndexOf(DecimalPoint);
			int length = text.Length;
			int prefixLength = Prefix.Length;

			char c = e.KeyChar;

			//如果有prefix,检测在prefix前输入字符时
			if(start < prefixLength && !Char.IsControl(c))
			{
				char cprefix = Prefix[start];

				//输入的是prefix
				if(cprefix == c)
				{
					
				}

			}

			//输入负值符号
			if(c == NegativeSign  )
			{
				if(	AllowNegative)
				{
					if(start == prefixLength)
					{
						if(numericText != "" && numericText[0] == NegativeSign)
						{
							end = (end == length ? end : (start + 1));
							selection.SetAndReplace(start,end,NegativeSign.ToString());	
						
						}
					}
					else
					{
						if(numericText[0] == NegativeSign)
						{
							//selection.SetAndReplace(prefixLength,prefixLength + 1, "");
							selection.Set(prefixLength,prefixLength + 1);

							//selection.Set(start - 1, end - 1);
						}
						else
						{
							//selection.SetAndReplace(prefixLength, prefixLength, NegativeSign.ToString());
							selection.Set(prefixLength, prefixLength);

							//selection.Set(start + 1, end + 1);
						}
						//e.Handled = true;
				
					
					}
					return;
				}
				else
				{
					e.Handled = true;
				}
			}
				//检测是否是".",并且只允许有一个
			else if(c == DecimalPoint )
			{
				if(decimalPos >= 0)
				{
					//					if(decimalPos >= start && decimalPos < end)
					//					{
					//						
					//					}
					selection.Set(decimalPos, decimalPos + 1);
				}
				else
				{
					if(start <= prefixLength && start == end )
					{
						if(numericText[0] == NegativeSign)
						{  
							selection.Set(prefixLength+1,prefixLength + 1);//prefixLength + 1); 
						}
						else
						{   
							selection.Set(prefixLength, prefixLength); 
						}
					}
					int s,en;
					selection.Get(out s,out en);
					if(length - en > MaxDigits)
						this.textBox.Text = this.textBox.Text.Remove(en + MaxDigits,length - en - MaxDigits);
					selection.Set(s,en);  
					return;
				}
			}
			else if(Char.IsDigit(c))
			{
				if(decimalPos >= 0 && decimalPos < start)
				{
					if(this.textBox.Text.Substring(decimalPos + 1).Length >= MaxDigits)
					{
						if(start > decimalPos + MaxDigits)
						{
							e.Handled = true;
						}
						else
						{
							end = (start == end ? (end + 1) : end);
							selection.Set(start,end);
						}
					}
				}
				else
				{
					bool isNegative = (numericText.Length != 0 && numericText[0] == NegativeSign);

					if(start <= prefixLength && start == end)
					{
						if(isNegative)
						{
							selection.Set(start + 1, end + 1);
						}
					}
					
					return;
					
				}
				
			}
			else if(Char.IsControl(c))
			{
				//e.Handled = true;
				return;
			}
			else
			{
				e.Handled = true;
			
			}

			 

		}


		public override bool Validating(string val)   
		{
			if(this.AutoPadRightZero)
			{
				if(this.numericText.IndexOf('.') >= 0)
				{
					string text = this.numericText;
					string[] split = text.Split('.');
					if(split.Length == 2 && split[1].Length < this.MaxDigits)
					{						 
						textBox.Text = split[0] + "." + split[1].PadRight(this.MaxDigits,'0');;
					}  
				} 
				else if(this.MaxDigits > 0)
				{
					textBox.Text = textBox.Text + "." + string.Empty.PadRight(this.MaxDigits,'0');

				}

			}

			return true;
		}

		private void textbox_TextChanged(object sender, EventArgs e)
		{
			numericText = textBox.Text.Trim();
		}
	}


	public class CurrencyType : DecimalType
	{
		public CurrencyType(TextBoxBase textbox) : base(textbox)
		{
		
			Prefix = "￥";
		}

	}

	[Browsable(false)]
	//[Designer(typeof(BaseValidatingTextBox.Designer))]
	public abstract class BaseValidatingTextBox : System.Windows.Forms.TextBox
	{
		protected IDataInputBehavior dataInputBehavior	;

		public BaseValidatingTextBox()
		{
			//this.ContextMenu = new ContextMenu();
		}

		public bool WillShowError
		{
			get
			{
				return dataInputBehavior.WillShowError;
			}
			set
			{
				dataInputBehavior.WillShowError = value;
			}
		
		}

		[Browsable(false)]
		public string ErrorMessage
		{
			get
			{
				return dataInputBehavior.ErrorMessage;
			}
		}

		public void ShowErrorMessageBox(string message)
		{
			dataInputBehavior.ShowErrorMessageBox(message);
		}

//		internal class Designer : System.Windows.Forms.Design.ControlDesigner 
//		{
//			/// <summary>
//			///   This typically sets the control's Text property.  
//			///   Here it does nothing so the Text is left blank. </summary>
//			public override void OnSetComponentDefaults()
//			{
//			}
//		}
	}



		public class ValidatedTextBox1 : System.Windows.Forms.TextBox
		{

			IDataInputBehavior datatype;
		

			private		  string errorMsg = ""; 
			private const string defaultErrorMsg = "自定义";
			private const string IntegerErrorMsg = "整数";
			private const string DecimalErrorMsg = "小数";
			private const string DataTimeErrorMsg = "日期";
			private const string DollarErrorMsg = "";
			private const string RMBErrorMsg = "";
			private const string IPAddressErrorMsg = "IP地址";
			private const string EMailErrorMsg = "Email";
       
			private const string IntegerRegex = @"^\d*$";
			private const string decimalRegex = @"^((-?\d+)|)[\.]";	  //^([1-9]+[0-9]*|0)[\.]?[0-9]{0,4}$
       
			private const string DataTimeRegex = @"^((((31\/(0?[13578]|1[02]))|((29|30)\/(0?[1,3-9]|1[0-2])))\/"+
				@"(1[6-9]|[2-9]\d)?\d{2})|(29\/0?2\/(((1[6-9]|[2-9]\d)?(0[48]|"+
				@"[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))|"+
				@"(0?[1-9]|1\d|2[0-8])\/((0?[1-9])|(1[0-2]))\/((1[6-9]|[2-9]\d)?\d{2}))$";
			private const string DollarRegex = "";
			private const string RMBRegex = "";
			private const string IPAddressRegex = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
			private const string EMailRegex =	@"^\+?[a-z0-9](([-+.]|[_]+)?[a-z0-9]+)*@([a-z0-9]+(\.|\-))+[a-z]{2,6}$";
		
			/// <summary>
			/// 小数正则表达式
			/// </summary>
			private string DecimalRegex
			{
				get
				{
					return decimalRegex + DecimalDigitsRegex;
				}
			}

			/// <summary>
			/// 小数位的正则表达式
			/// </summary>
			private string DecimalDigitsRegex
			{
				get
				{
				 
				{
					string regex = @"?[0-9]{0,"+decimalDigits.ToString() +@"}$" ;

					return regex;
				}
				}
			}


			public enum TextFormatTypes
			{
				/// <summary>
				/// 
				/// </summary>
				Default,


				/// <summary>
				/// 
				/// </summary>
				Integer,


				/// <summary>
				/// 
				/// </summary>
				Decimal,


				/// <summary>
				/// 
				/// </summary>
				DataTime,


				Dollar,
				RMB,

				/// <summary>
				/// 
				/// </summary>
				IPAddress,


				EMail
			}


			private TextFormatTypes textFormatType = TextFormatTypes.Default;

			/// <summary>
			/// 小数位数
			/// </summary>
			private int	decimalDigits = 1;

			//private static ErrorProvider errorProvider;
			public ValidatedTextBox1()
			{
				datatype = new DecimalType(this); 
			}
			#region Auto
			/// <summary> 
			/// 必需的设计器变量。
			/// </summary>    
			private System.ComponentModel.Container components = null;

		


			/// <summary> 
			/// 清理所有正在使用的资源。
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}

	 

			#endregion

			private bool isDefaultValidate = true ;

			/// <summary>
			/// 是否进行验证处理。默认为true,如果自己想处理验证事件而不想出发控件已经定义的处理事件，可设为false,
			/// 调用RegexValidate()可得到验证结果。
			/// 此属性不影响CausesValidation。
			/// </summary>
			[DefaultValue(true)]
			public bool IsDefaultValidate
			{
				get
				{
					return this.isDefaultValidate;
				}
				set
				{
					this.isDefaultValidate = value;
				}
			}

			private bool isShowErrMsg = true;		

			/// <summary>
			/// 验证出错时，是否显示出错信息？
			/// </summary>
			/// 
			public bool IsShowErrorMessage
			{
				get
				{
					return this.isShowErrMsg;
				}
				set
				{
					this.isShowErrMsg = value;   	
				
				}
			}
		

			/// <summary>
			/// 文本格式类型
			/// </summary>
			[Description("文本格式类型")]
			public TextFormatTypes TextFormatType
			{
				get
				{
					return this.textFormatType;
				}
				set
				{
					this.textFormatType = value;

					string fMsg = "请输入正确的";
					string bMsg = "格式!";
					switch(textFormatType)
					{
						case TextFormatTypes.Default:
							this.errorMsg = fMsg + defaultErrorMsg + bMsg;
							break;
						case TextFormatTypes.Integer:
							this.ErrorMessage = fMsg + IntegerErrorMsg + bMsg;
							break;

						case TextFormatTypes.Decimal:
							this.ErrorMessage = fMsg + DecimalErrorMsg + bMsg ;
						
							break;

						case TextFormatTypes.DataTime:
							this.ErrorMessage = fMsg +DataTimeErrorMsg+ bMsg;

							break;
						case TextFormatTypes.Dollar:
							this.ErrorMessage = fMsg +DollarErrorMsg + bMsg ;

							break;
						case TextFormatTypes.RMB:
							this.ErrorMessage = fMsg +RMBErrorMsg + bMsg;

							break;
						case TextFormatTypes.IPAddress:
							this.ErrorMessage = fMsg +IPAddressErrorMsg + bMsg;
											 
							break;
						case TextFormatTypes.EMail:
							this.ErrorMessage = fMsg +EMailErrorMsg + bMsg;
											 
							break;
						default :
							break;

					}
				}
			}
		
			/// <summary>
			/// 验证错误时的提示消息
			/// </summary>
			/// 
			[DefaultValue("")]
			[Browsable(false)]

			private string ErrorMessage
			{
				get
				{
					return this.errorMsg   ;
				}
				set
				{
					this.errorMsg = value;
				}
			}

		
			/// <summary>
			/// 小数的个数
			/// </summary>
			/// 
			[Description("小数的位数")]
			[Browsable(true)]
			public int DecimalDigits
			{
				get
				{
					return this.decimalDigits;
				}
				set
				{
					if(value < 1)
						value = 1;
					this.decimalDigits = value;
				}
			}


			private string formatRegex;
			/// <summary>
			/// 匹配的正则表达式，(只有TextFormatType==TextFormatTypes.Default的时候才起作用)
			/// </summary>
			/// 
			[Browsable(false)]

			[DefaultValue("")]
			public string FormatRegex
			{
				get
				{
					return this.formatRegex ;
				}
				set
				{
					this.formatRegex = value;
				}
			}

			protected override void OnKeyDown(KeyEventArgs e)
			{	
				//base.OnKeyDown (e);
				datatype.HandleKeyDown(this,e);
			
			
			}


			protected override   void OnKeyPress(KeyPressEventArgs e)
			{

				switch(textFormatType)
				{
					case TextFormatTypes.Default:

						break;
					case TextFormatTypes.Integer:
						CheckIntegerInput(e);
						break;
								   
					case TextFormatTypes.Decimal:
							  
						//CheckDecimalInput(e);
						//datatype.HandleKeyPress(this,e);
						break;

					case TextFormatTypes.DataTime:

						break;
					case TextFormatTypes.Dollar:

						break;
					case TextFormatTypes.RMB:

						break;
					case TextFormatTypes.IPAddress:

						CheckIPInput(e);
				 
						break;
					case TextFormatTypes.EMail:
											 
						break;
					default :
						break;

				}
				base.OnKeyPress(e);

			}
			protected override void OnValidating(CancelEventArgs e)
			{
				//
				//			if(IsDefaultValidate)
				//			{
				//				if(RegexValidate(this.Text))
				//				{
				//					e.Cancel = false;
				//				}
				//				else
				//				{
				//					e.Cancel = true; 			 
				//					if(IsShowErrorMessage)
				//						MessageBox.Show(this.ErrorMessage);
				//					datatype.ShowErrorIcon(this.ErrorMessage);
				//				}
				//			}
			

				base.OnValidating (e);
			}
           


			public bool RegexValidate(string str)
			{
			 
				if(str == "") return true;

				System.Text.RegularExpressions.Regex  match = null;
				switch(textFormatType)
				{
					case TextFormatTypes.Default:
						if(this.formatRegex == "")
							return true;      					 
						else
						{
							try
							{
								match = new Regex(this.formatRegex);
							}
							catch
							{
								return false;
							}   
						
						}
						break;					
							
					case TextFormatTypes.Integer:
						match = new Regex(IntegerRegex);
						break;

					case TextFormatTypes.Decimal:
						match = new Regex(this.DecimalRegex);
					 
						break;

					case TextFormatTypes.DataTime:
						match = new Regex(DataTimeRegex);

						break;
					case TextFormatTypes.Dollar:
						match = new Regex(DollarRegex);

						break;
					case TextFormatTypes.RMB:
						match = new Regex(RMBRegex);

						break;
					case TextFormatTypes.IPAddress:
						match = new Regex(IPAddressRegex);
							 
						break;
					case TextFormatTypes.EMail:
						match = new Regex(EMailRegex,RegexOptions.IgnoreCase);											 
						break;
				 
					     					 
				}
			
				try
				{
					if(match.Match(str).Success)
						return true;        				 
			 
				}
				catch
				{
			
				}
				return false;
			
			}
  
	                                                 
			protected virtual void SetValidateError(ErrorProvider provider)
			{
				provider.SetError(this,this.ErrorMessage); 
		
			}

		 

			private void CheckIntegerInput(KeyPressEventArgs e)
			{
 
				if((e.KeyChar>='0'&&e.KeyChar<='9')||e.KeyChar == (int)Keys.Back)
					e.Handled=false;
				else
					e.Handled=true;
			}

			/// <summary>
			/// 输入小数
			/// </summary>
			/// <param name="e"></param>
			private void CheckDecimalInput(KeyPressEventArgs e)
			{
			
				if( e.KeyChar == (int)Keys.Back)
					return;
				if(( e.KeyChar>='0'&&e.KeyChar<='9') || e.KeyChar == (int)Keys.Delete)
				{
					if(CheckDecimalValue(e.KeyChar) == false)
						e.Handled = true;
				}
				else
					e.Handled = true;
			}


			private bool CheckDecimalValue(char c)
			{
				if(this.SelectionLength != 0)
				{
					int start = this.SelectionStart;
					this.Text = this.Text.Remove(start,this.SelectionLength);
					this.SelectionStart = start;
				}
				int dotIndex = this.Text.IndexOf('.');
				if(dotIndex < 0)
				{
					if(this.SelectionStart < this.Text.Trim().Length - this.DecimalDigits)
						return false;
				
				}
				else
				{     
					if(c == '.')
					{  				
						return false;
					}

					if(this.SelectionStart < dotIndex)
						return true;
					string[] chars = this.Text.Split('.');
					if(chars.Length < 2)
						return true;
					else
					{
						if(chars[1].Length < this.DecimalDigits && (this.SelectionStart > dotIndex))
							return true;
						if(this.SelectionStart <= dotIndex)
							return true;
						else
							return false;
					 
					}
				}
				return true;
			}


			private void CheckIPInput(KeyPressEventArgs e)
			{
			 
				if((e.KeyChar>='0'&&e.KeyChar<='9')||e.KeyChar =='.'||e.KeyChar == (int)(Keys.Back))
					e.Handled = false;
				else
					e.Handled = true;

			}

		

		}
	}
