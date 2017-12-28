using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuNumericTextBox<br></br>
	/// [功能描述: NeuNumericTextBox控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	[System.ComponentModel.DefaultEvent("NumericValueChanged"),
	System.ComponentModel.DefaultProperty("NumericValue"),
	ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
	public class NeuNumericTextBox : NeuTextBox, INeuControl 
	{
		//		private int minimum = -1;
		//		private int maximum = -1;
		//		private bool useRange = false;
		//		private string lastChar;


		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NeuNumericTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            this.TextAlign = HorizontalAlignment.Right;
			this.Text =	"0";
            this.LostFocus += new EventHandler(NumericTextBox_LostFocus);
            this.GotFocus += new EventHandler(NumericTextBox_GotFocus);
            //this.TextChanged += new EventHandler(NumericTextBox_TextChanged);
			this.KeyDown += new KeyEventHandler(NumericTextBox_KeyDown);
			this.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
            this.Validating += new CancelEventHandler(NumericTextBox_Validating);

            //this.precision = 6;
            //this.ii_ScaleOnFocus = 2;
            //this.FormatNumber();
		}

		/// <summary> 
		/// Clean up any resources being used.
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


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region "变量"
		private int ii_ScaleOnLostFocus = 0;
		private Decimal idec_InternalValue = 0;
		private Decimal idec_NumericValue = 0;
		private int ii_ScaleOnFocus = 0;
		private int precision = 1;
		private bool ib_AllowNegative = false;
		private bool ib_NoChangeEvent = false;
		private bool ib_ZeroNotValid = false;
		private bool useGroupSeperator = true;		//是否用分隔","
        private bool isAutoDecimalZero = false;

		#endregion

		public event EventHandler NumericValueChanged;

		#region "属性"

		/// <summary>
		/// Indicates if the value zero (0) valid.
		/// </summary>
		[System.ComponentModel.Category("Numeric settings")]
		public bool ZeroIsValid
		{
			get {return ib_ZeroNotValid;}
			set {ib_ZeroNotValid = value;}
		}

		/// <summary>
		/// 最大位数
		/// </summary>
		[System.ComponentModel.Category("Numeric settings"),System.ComponentModel.Description("最大位数，包括小数位数")]
		public int NumericPrecision
		{
			get{return precision;}
			set
			{
				//Precision cannot be negative
				if ( value < 0 ) 
				{
					MessageBox.Show("Precision cannot be negative!","Numeric TextBox",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				if ( value < this.NumericScaleOnFocus ) 
				{
					this.NumericScaleOnFocus = value;
				}

				precision = value;
			}
		}

		/// <summary>
		/// 获得焦点时小数位数
		/// </summary>
		[System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All),
		System.ComponentModel.Category("Numeric settings"),System.ComponentModel.Description("获得焦点时小数位数")]
		public int NumericScaleOnFocus  
		{
			get{return ii_ScaleOnFocus;}
			set
			{
				//Scale cannot be negative
				if ( value < 0 ) 
				{
					MessageBox.Show("Scale cannot be negative!","Numeric TextBox",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				//Scale cannot be larger than precision
				if ( value >= this.NumericPrecision ) 
				{
					MessageBox.Show("Scale cannot be larger than precission!","Numeric TextBox",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				this.ii_ScaleOnFocus = value;
                this.ii_ScaleOnLostFocus = value;
				
                if ( ii_ScaleOnFocus > 0 ) 
				{
					this.Text = "0" + DecimalSeperator + new string (Convert.ToChar("0"), ii_ScaleOnFocus);
				} 
				else 
				{
					this.Text = "0";
				}
			}
		}

		
		/// <summary>
		/// 获得焦点时小数位数 
		/// </summary>
		[System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All),
		System.ComponentModel.Category("Numeric settings"),System.ComponentModel.Description("失去焦点时小数位数"),
        Browsable(false)]
		public int NumericScaleOnLostFocus  
		{
			get{return ii_ScaleOnFocus;}
			set
			{
                ////Scale cannot be negative
                //if ( value < 0 ) 
                //{
                //    MessageBox.Show("Scale cannot be negative!","Numeric TextBox",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //    return;
                //}

                ////Scale cannot be larger than precision
                //if ( value >= this.NumericPrecision ) 
                //{
                //    MessageBox.Show("Scale cannot be larger than precesion!","Numeric TextBox",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //    return;
                //}

                //ii_ScaleOnFocus = value;
			}
		}

		private string  DecimalSeperator  
		{
			get
			{
                //if (this.useGroupSeperator)
                //{

                return System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                //}
                //else
                //{
                //    return string.Empty;
                //}
			}
		}

		private string  GroupSeperator  
		{
			get 
			{
				if (this.useGroupSeperator) 
				{
				
					return System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
				}
				else
				{
					return string.Empty;
				}
			}

		}
		/// <summary>
		/// Indicates if negative numbers are allowed?
		/// </summary>
		[System.ComponentModel.Category("Numeric settings")]
		public bool AllowNegative  
		{
			get{return ib_AllowNegative;}
			set{ib_AllowNegative = value;}
		}

        /// <summary>
        /// 在失去焦点时，是否自动去掉显示小数点后面没有用0
        /// </summary>
        [System.ComponentModel.Category("Numeric settings"),
            Description("在失去焦点时，是否自动去掉显示小数点后面没有用0")]
        public bool IsAutoRemoveDecimalZero
        {
            get
            {
                return this.isAutoDecimalZero;
            }
            set
            {
                this.isAutoDecimalZero = value;
            }
        }
		/// <summary>
		/// The current numeric value displayed in the textbox
		/// </summary>
		[System.ComponentModel.Bindable(true),
		System.ComponentModel.Category("Numeric settings")]
		public object NumericValue  
		{
			get{return idec_NumericValue;}
			set
			{
				if (value.Equals(DBNull.Value))
				{
					if (value.Equals(0))
					{
						this.Text = Convert.ToString(0);
						idec_NumericValue = Convert.ToDecimal(0);
                        //OnNumericValueChanged(new System.EventArgs());
						return;
					}
				}
                
				if (!value.Equals(idec_NumericValue)) 
				{
					this.Text = Convert.ToString(value);
					idec_NumericValue = Convert.ToDecimal(value);
                    //OnNumericValueChanged(new System.EventArgs());
				}
			}
		}


		/// <summary>
		/// 是否用分隔符","
		/// </summary>
		[System.ComponentModel.Category("Numeric settings"),Description("是否用分隔符")]
		public bool UseGroupSeperator
		{
			get
			{
				return this.useGroupSeperator;
			}
			set
			{
				this.useGroupSeperator = value;
				this.Text = this.FormatNumber();
			}
		}
		/// <summary>
		/// 没用
		/// </summary>
		public Size SetRange
		{
			get
			{
				//				if ( useRange )
				//					return new Size(minimum, maximum);
				//				else 
				return new Size(-1, -1);

			}
			set 
			{
				//				minimum = value.Width;
				//				maximum = value.Height;
				//				useRange = true;
			}
			
		}

		#endregion

		#region "方法"
		

		private void NumericTextBox_LostFocus(object sender, EventArgs e)
		{
			ib_NoChangeEvent = true;

            string text = this.Text;

			idec_InternalValue = Convert.ToDecimal(text);

			//set { the text to the new format
			//if (! li_Precision = 0 ) {
			if (!(ii_ScaleOnLostFocus == 0)) 
			{
				//text = Strings.FormatNumber(text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
				text = this.FormatNumber();
				
			} 
			else 
			{
				if ( text.IndexOf('-') < 0 ) 
				{
					//text = Strings.FormatNumber(text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
					text = this.FormatNumber();
				} 
				else 
				{
					if ( text == "-" ) 
					{
						text = "";
					} 
					else 
					{
						//text = CStr(System.Math.Abs(CDbl(text)));
						//text = Strings.FormatNumber(text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
						text = this.FormatNumber();
					}
				}
			}
            if (this.Text != text)
            {
                try { this.Text = text; }
                finally { }
            }
			ib_NoChangeEvent = false;
		}

        private void NumericTextBox_GotFocus(object sender, EventArgs e)
        {
            ib_NoChangeEvent = true;
            string text = this.Text;

            text = Convert.ToString(idec_InternalValue);

            //set { the text to the new format
            //if (! li_Precision = 0 ) {
            if (!( ii_ScaleOnFocus == 0) ) 
            {
                //text = Strings.FormatNumber(text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                text = this.FormatNumber();
            } 
            else 
            {
                if ( text.IndexOf('-') < 0 ) 
                {
                    //text = Strings.FormatNumber(text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                    text = this.FormatNumber();
                } 
                else 
                {
                    if ( text == "-" ) 
                    {
                        text = "";
                    } 
                    else 
                    {
                        //text = Convert.ToString(System.Math.Abs(Convert.ToDouble(text)));
                        //text = Strings.FormatNumber(text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                        text = this.FormatNumber();
                    }
                }
            }
            if (this.Text != text)
            {
                try { this.Text = text; }
                finally { }
            }
            ib_NoChangeEvent = false;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if(!this.DesignMode)
            {


                int li_SelStart = 0;
                bool lb_PositionCursorBeforeComma = false;
                string text = this.Text;
                //Robin Add
                //防止只有负号错误
                if (this.Text == "-")
                {
                    this.Text = "0";
                }
                //Indicates that no change event should happen
                //Prevent event from firing on changing the text in the change
                //event
                if (ib_NoChangeEvent || (this.SelectionStart == -1))
                {
                    return;
                }

                //No Change event
                ib_NoChangeEvent = true;

                if (string.Empty.Equals(text.Trim()))
                {
                    text = "0";
                }

                if (text.Substring(0, 1) == GroupSeperator)
                {
                    text = text.Substring(1);
                }

                //Robin Add
                //防止只有负号逗号错误
                if (text.Length > 2 && text.Substring(0, 2) == "-" + GroupSeperator)
                {
                    text = "-" + text.Substring(2);
                }

                //if (! ii_Precision = 0 ) {
                if (!(ii_ScaleOnFocus == 0))
                {
                    //if ( the current position is just before the comma
                    if (this.SelectionStart == (text.IndexOf(DecimalSeperator)))
                    {
                        lb_PositionCursorBeforeComma = true;
                    }
                    else
                    {
                        li_SelStart = this.SelectionStart;
                    }
                }
                else
                {
                    li_SelStart = this.SelectionStart;
                }

                idec_InternalValue = Neusoft.FrameWork.Function.NConvert.ToDecimal(text);
                this.NumericValue = idec_InternalValue;
                


                if (this.Focused)
                {
                    //set { the text to the new format
                    //if (! ii_Precision = 0 ) {
                    if (!(ii_ScaleOnFocus == 0))
                    {
                        //text = Strings.FormatNumber(text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                        text = this.FormatNumber();
                    }
                    else
                    {
                        if (text.IndexOf('-') < 0)
                        {
                            //text = Strings.FormatNumber(text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                            text = this.FormatNumber();
                        }
                        else
                        {
                            if (text.Equals('-'))
                            {
                                text = "";
                            }
                            else
                            {
                                //text = Convert.ToString(System.Math.Abs(Convert.ToDouble(text)));
                                //text = Strings.FormatNumber(text, this.NumericScaleOnFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                                text = this.FormatNumber();
                            }
                        }
                    }
                }
                else
                {
                    //set { the text to the new format
                    //if (! ii_Precision = 0 ) {
                    if (!(ii_ScaleOnLostFocus == 0))
                    {
                        //text = Strings.FormatNumber(text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                        text = this.FormatNumber();
                    }
                    else
                    {
                        if (text.IndexOf('-') < 0)
                        {
                            //text = Strings.FormatNumber(text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                            text = this.FormatNumber();
                        }
                        else
                        {
                            if (text.Equals('-'))
                            {
                                text = "";
                            }
                            else
                            {
                                //text = Convert.ToString(System.Math.Abs(Convert.ToDouble(text)));
                                //text = Strings.FormatNumber(text, this.NumericScaleOnLostFocus, Microsoft.VisualBasic.TriState.True, Microsoft.VisualBasic.TriState.False, Microsoft.VisualBasic.TriState.True);
                                text = this.FormatNumber();
                            }
                        }
                    }

                }
                
                if (this.Text != text)
                {
                    try
                    {
                        this.Text = text;
                    }
                    finally
                    {

                    }

                }

                //if ( the position was before the comma
                //then put again before the comma
                if (!(ii_ScaleOnFocus == 0))
                {
                    if (lb_PositionCursorBeforeComma)
                    {
                        this.SelectionStart = (text.IndexOf(DecimalSeperator));
                    }
                    else
                    {
                        this.SelectionStart = li_SelStart;
                    }
                }
                else
                {
                    this.SelectionStart = li_SelStart;
                }


                ib_NoChangeEvent = false;

                base.OnTextChanged(e);
            }
        }

		private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			bool lb_PositionCursorJustBeforeComma = false;
			
			if (!(ii_ScaleOnFocus == 0) ) 
			{
				//Is the position of the cursor just before the comma
				lb_PositionCursorJustBeforeComma = (this.SelectionStart == (this.Text.IndexOf(DecimalSeperator)));
			}

			switch(e.KeyCode) 
			{
				case System.Windows.Forms.Keys.Delete:
					//Otherwise strange effect
					if ( lb_PositionCursorJustBeforeComma ) 
					{
						this.SelectionStart = this.Text.IndexOf(DecimalSeperator) + 1;
						e.Handled = true;
						break;
					}
					//if ( all selected on delete pressed

					if ( this.Text.IndexOf('-') < 0 ) 
					{
						if ( this.SelectionLength == this.Text.Length) 
						{
							this.Text = "0";
							this.SelectionStart = 1;
							e.Handled = true;
							break;
						}
					} 
					else 
					{

						if ( this.SelectionLength == this.Text.Length) 
						{
							this.Text = "0";
							this.SelectionStart = 1;
							e.Handled = true;
							break;
						}

						if ( this.SelectionLength > 0 ) 
						{
							if ( this.SelectedText != "-" ) 
							{
								if ( Convert.ToDouble(this.SelectedText) == System.Math.Abs(Convert.ToDouble(this.Text)) ) 
								{
									this.Text = "0";
									this.SelectionStart = 1;
									e.Handled = true;
									break;
								}
							}
						}
					}
					break;
				default:
					break;
			}
			return;
		}

		private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool lb_PositionCursorBeforeComma = false;
			bool lb_InputBeforeCommaValid = false;
			bool lb_PositionCursorJustAfterComma = false;
			int li_SelStart = 0;

			lb_InputBeforeCommaValid = true;

            //////////////////////////////////////////////////////////////////////////            
            //  小数点为替换，而不是插入
            //  Robin   2006-11-17
            //////////////////////////////////////////////////////////////////////////            
            if (e.KeyChar != '\b')
            {

                int l = this.Text.IndexOf(".");
                if (l > 0)
                {
                    if (this.SelectionStart > l)
                        this.SelectionLength = 1;
                }
            }
            //////////////////////////////////////////////////////////////////////////            



			//Minus pressed
			if ( e.KeyChar.Equals('-') ) 
			{
				if ( this.AllowNegative ) 
				{
					if ( this.Text.IndexOf('-') < 0 ) 
					{

						li_SelStart = this.SelectionStart;

						if (!(Convert.ToDecimal(this.Text) == 0))
						{
							this.Text = "-" + this.Text;
						
							this.SelectionStart = li_SelStart + 1;
						}
						e.Handled = true;
						return;
					} 
					else 
					{
						
						switch (this.SelectionLength) 
						{
							
							case 0:
								li_SelStart = this.SelectionStart;

								this.Text = Convert.ToString(Convert.ToDouble(this.Text) * -1);

								this.SelectionStart = li_SelStart - 1;

								e.Handled = true;
								break;
							default:
								//Is everything selected
								if(this.SelectionLength == this.TextLength)
									this.Text = "-0";
								e.Handled = true;
								break;
						}
					}
					e.Handled = true;
					return;
				}
			}

			//The + key
			if ( e.KeyChar.Equals('+')) 
			{
				if (!(this.Text.IndexOf('-') < 0) ) 
				{
					//Is everything selected
					switch (this.SelectionLength) 
					{	
						case 0:
							li_SelStart = this.SelectionStart;

							this.Text = Convert.ToString(Convert.ToDouble(this.Text) * -1);

							this.SelectionStart = li_SelStart - 1;

							e.Handled = true;
							break;
						default:
							if (this.TextLength == this.SelectionLength)
							{
								this.Text = "0";
								e.Handled = true;
							}
							break;
					}
				}
				e.Handled = true;
				return;
			}

			if (!(ii_ScaleOnFocus == 0)) 
			{
				//Is the position of the cursor just after the comma
                lb_PositionCursorJustAfterComma = (this.SelectionStart == this.Text.IndexOf(DecimalSeperator) + 1);
			}

			if ( e.KeyChar == '\b') 
			{
				//Backspace
				if ( lb_PositionCursorJustAfterComma ) 
				{
					this.SelectionStart = this.Text.IndexOf(DecimalSeperator);
					e.Handled = true;
				}

				//if ( all selected on delete pressed)
				if ( this.SelectionLength == this.Text.Length) 
				{
					this.Text = "0";
					this.SelectionStart = 1;
					e.Handled = true;
					
				}

				if (e.KeyChar.Equals(null))
				{
					e.Handled = true;
				}
				return;
			}

			//Prevent other keys than numeric and ,
			string ls_AllowedKeyChars = "1234567890" + DecimalSeperator;
			
			if (ls_AllowedKeyChars.IndexOf(e.KeyChar) < 0)  
			{
				e.Handled = true;
				return;
			}

			if (!(ii_ScaleOnFocus == 0)) 
			{
				//position of cursor is before comma?
                lb_PositionCursorBeforeComma =  !(this.SelectionStart >= this.Text.IndexOf(DecimalSeperator) + 1);
			}

			//Comma pressed
			if ( e.KeyChar.ToString() == DecimalSeperator ) 
			{
				if ( lb_PositionCursorBeforeComma ) 
				{
					this.SelectionStart = this.Text.IndexOf(DecimalSeperator) + 1 ;
					this.SelectionLength = 0;
				}

				e.Handled = true;
				return;
			}

			//Prevent more than the precission numbers entered
			if (!(ii_ScaleOnFocus == 0)) 
			{
				if ( this.SelectionStart == this.Text.Length ) 
				{
					e.Handled = true;
					return;
				}
			}

			if (!(ii_ScaleOnFocus == 0)) 
			{
				//if ( the character entered would violate the numbers before the comma
				if ( this.Text.IndexOf('-') < 0 ) 
				{
					lb_InputBeforeCommaValid = !(this.Text.Substring(0,this.Text.IndexOf(DecimalSeperator)).Length >= (precision - ii_ScaleOnFocus));
				} 
				else 
				{
					lb_InputBeforeCommaValid = !(this.Text.Substring(0,this.Text.IndexOf(DecimalSeperator)).Length >= (precision - ii_ScaleOnFocus + 1));
				}
			} 
			else 
			{
				if ( this.Text.IndexOf('-') < 0 ) 
				{
					lb_InputBeforeCommaValid = ! ((this.Text.Length) >= precision);
				} 
				else 
				{
					lb_InputBeforeCommaValid = ! ((this.Text.Length) >= precision + 1);
				}
			}

			//if first char is 0 another may be entered
			if (!(ii_ScaleOnFocus == 0)) 
			{
				if ( (this.Text.Substring(0,1) == "0") && !(this.SelectionStart == 0)) 
				{
					lb_InputBeforeCommaValid = true;
				}
				if ( this.SelectionLength > 0 ) 
				{
					lb_InputBeforeCommaValid = true;
				}
			} 
			else 
			{
				if ( (this.Text.Substring(0,1) == "0") && ((this.SelectionStart == this.Text.Length) || (this.SelectionLength == 1)) ) 
				{
					lb_InputBeforeCommaValid = true;
				}
				if ( this.SelectionLength > 0 ) 
				{
					lb_InputBeforeCommaValid = true;
				}
			}

			if (!(ii_ScaleOnFocus == 0)) 
			{
				if ( lb_PositionCursorBeforeComma && !(lb_InputBeforeCommaValid) ) 
				{
					e.Handled = true;
					return;
				}
			} 
			else 
			{
				if (! (lb_InputBeforeCommaValid) ) 
				{
					e.Handled = true;
					return;
				}
			}

            //在输入光标处于最前时，格式化数字后光标位置计算错误，导致应输入1,234.0 实际显示1,243
            //{EB737F92-16A5-4797-A41A-0D87BD0D7829}
            if (Neusoft.FrameWork.Function.NConvert.ToDecimal( this.Text ) == 0)
            {
                int flag = this.Text.IndexOf( '.' );
                if (this.SelectionStart < flag)
                {
                    this.SelectAll();
                }
            }

		}

		/// <summary>
		/// Raises the NumericValueChanged event
		/// </summary>
		/// <param name="e">The eventargs</param>
        protected void OnNumericValueChanged(System.EventArgs e)
        {
            if (NumericValueChanged != null)
            {
                NumericValueChanged(this, e);
            }
        }

		/// <summary>
		/// Formats a the text inf the textbox (which represents a number) according to
		/// the scale,precision and the enviroment settings.
		/// </summary>
		protected string FormatNumber()
		{
			StringBuilder lsb_Format = new StringBuilder();
			int li_Counter = 1;
			long ll_Remainder = 0;

			if (this.Focused)
			{
				while(li_Counter <= precision - ii_ScaleOnFocus)
				{
					if (li_Counter == 1)
					{
						lsb_Format.Insert(0,'0');
					}
					else
					{
						lsb_Format.Insert(0,'#');
					}

					System.Math.DivRem(li_Counter,3,out ll_Remainder); 
					if ((ll_Remainder == 0) && (li_Counter + 1 <= precision - ii_ScaleOnFocus))
					{
						if (this.useGroupSeperator) 
						{
							lsb_Format.Insert(0,',');
						}
					}

					li_Counter++;
				}
	
				li_Counter = 1;

				if (ii_ScaleOnFocus > 0)
				{
					lsb_Format.Append(".");

					while(li_Counter <= ii_ScaleOnFocus)
					{
						lsb_Format.Append('0');
						li_Counter++;
					}
				}
			
			}
			else
			{
				while(li_Counter <= precision - ii_ScaleOnLostFocus)
				{
					if (li_Counter == 1)
					{
						lsb_Format.Insert(0,'0');
					}
					else
					{
						lsb_Format.Insert(0,'#');
					}
					System.Math.DivRem(li_Counter,3, out ll_Remainder); 
					if ((ll_Remainder == 0) && (li_Counter + 1 <= precision - ii_ScaleOnLostFocus))
					{
						if (this.useGroupSeperator) 
						{
							lsb_Format.Insert(0,',');
						}
					}
					li_Counter++;
				}

				li_Counter = 1;

				if (ii_ScaleOnLostFocus > 0)
				{

                    
                    lsb_Format.Append(".");

					while(li_Counter <= ii_ScaleOnLostFocus)
					{
						lsb_Format.Append('0');
						li_Counter++;
					}

                    //去掉没有用的小数点后面的0及小数点
                    if (this.isAutoDecimalZero)
                    {                        
                        if (this.Text.IndexOf(".") > 0)
                        {
                            int i;
                            for (i = this.Text.Length - 1; i > this.Text.IndexOf(".");i-- )
                            {
                                if (this.Text.Substring(i, 1) == "0")
                                {
                                    lsb_Format.Remove(lsb_Format.Length - 1, 1);
                                }
                                else
                                    break;
                            }
                            //去掉小数点
                            if(i==this.Text.IndexOf("."))
                            {
                                lsb_Format.Remove(lsb_Format.Length - 1, 1);
                            }
                        }
                    }
				}
			}

            //不四舍五入
            //string t = decimal.Round((decimal)(decimal.Parse(this.Text) - (decimal)(5*Math.Pow(0.1,this.ii_ScaleOnFocus+1))), this.ii_ScaleOnFocus).ToString();            
            return Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Text).ToString(lsb_Format.ToString());

		}

        private void NumericTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((this.Text.Equals(string.Empty) || Convert.ToDecimal(this.NumericValue).Equals(Convert.ToDecimal(0))) && !this.ZeroIsValid)
            {
                e.Cancel = true;
            }
        }

		#endregion

		
	}
}

