using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// This represents the input form for the NumberPicker control. Using
	/// the class allows to better specify the values and do calculations at
	/// the same time
	/// </summary>
	internal class NumberPickerInput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonBackspace;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Button buttonDecimalSeparator;
		private System.Windows.Forms.Button button0;
		private System.Windows.Forms.Button buttonPlusMinus;
		private System.Windows.Forms.Button buttonPlus;
		private System.Windows.Forms.Button buttonMinus;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonTimes;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button buttonDivide;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button buttonEquals;

		/// <summary>
		/// A delegate for an arithmetic function taking two double arguments
		/// </summary>
		private delegate double Function(double a, double b);

		/// <summary>
		/// Specifies whether the field should be cleared or not 
		/// </summary>
		private bool clear;

		/// <summary>
		/// A temporary value to be remembered when calculating the arithmetic functions 
		/// </summary>
		private double temporary;

		/// <summary>
		/// A pointer to the actual textbox used for updating
		/// </summary>
		private System.Windows.Forms.TextBox result;

		/// <summary>
		/// A function pointer holding the last function which has been pressed in the calculator window
		/// </summary>
		private Function f;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		/// <summary>
		/// The default constructor for the input form to be used in the
		/// NumberPicker control
		/// </summary>
		public NumberPickerInput(System.Windows.Forms.TextBox result)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.buttonDecimalSeparator.Text = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

			this.result = result;
			this.temporary = 0;
			this.clear = false;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonBackspace = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.button0 = new System.Windows.Forms.Button();
			this.buttonDecimalSeparator = new System.Windows.Forms.Button();
			this.buttonPlusMinus = new System.Windows.Forms.Button();
			this.buttonPlus = new System.Windows.Forms.Button();
			this.buttonMinus = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonTimes = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.buttonDivide = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.buttonEquals = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonBackspace
			// 
			this.buttonBackspace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonBackspace.Location = new System.Drawing.Point(29, 103);
			this.buttonBackspace.Name = "buttonBackspace";
			this.buttonBackspace.Size = new System.Drawing.Size(38, 25);
			this.buttonBackspace.TabIndex = 56;
			this.buttonBackspace.Text = "<-";
			this.buttonBackspace.Click += new System.EventHandler(this.buttonBackspace_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonClear.Location = new System.Drawing.Point(0, 103);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(28, 25);
			this.buttonClear.TabIndex = 55;
			this.buttonClear.Text = "C";
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// button0
			// 
			this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button0.Location = new System.Drawing.Point(0, 78);
			this.button0.Name = "button0";
			this.button0.Size = new System.Drawing.Size(28, 24);
			this.button0.TabIndex = 54;
			this.button0.Text = "0";
			this.button0.Click += new System.EventHandler(this.button0_Click);
			// 
			// buttonDecimalSeparator
			// 
			this.buttonDecimalSeparator.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonDecimalSeparator.Location = new System.Drawing.Point(29, 78);
			this.buttonDecimalSeparator.Name = "buttonDecimalSeparator";
			this.buttonDecimalSeparator.Size = new System.Drawing.Size(27, 24);
			this.buttonDecimalSeparator.TabIndex = 53;
			this.buttonDecimalSeparator.Click += new System.EventHandler(this.buttonDecimalSeparator_Click);
			// 
			// buttonPlusMinus
			// 
			this.buttonPlusMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonPlusMinus.Location = new System.Drawing.Point(58, 78);
			this.buttonPlusMinus.Name = "buttonPlusMinus";
			this.buttonPlusMinus.Size = new System.Drawing.Size(27, 24);
			this.buttonPlusMinus.TabIndex = 52;
			this.buttonPlusMinus.Text = "+-";
			this.buttonPlusMinus.Click += new System.EventHandler(this.buttonPlusMinus_Click);
			// 
			// buttonPlus
			// 
			this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonPlus.Location = new System.Drawing.Point(86, 78);
			this.buttonPlus.Name = "buttonPlus";
			this.buttonPlus.Size = new System.Drawing.Size(28, 24);
			this.buttonPlus.TabIndex = 51;
			this.buttonPlus.Text = "+";
			this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
			// 
			// buttonMinus
			// 
			this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonMinus.Location = new System.Drawing.Point(86, 52);
			this.buttonMinus.Name = "buttonMinus";
			this.buttonMinus.Size = new System.Drawing.Size(28, 24);
			this.buttonMinus.TabIndex = 50;
			this.buttonMinus.Text = "-";
			this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Location = new System.Drawing.Point(58, 52);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(27, 24);
			this.button3.TabIndex = 49;
			this.button3.Text = "3";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(29, 52);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(27, 24);
			this.button2.TabIndex = 48;
			this.button2.Text = "2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(0, 52);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(28, 24);
			this.button1.TabIndex = 47;
			this.button1.Text = "1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonTimes
			// 
			this.buttonTimes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonTimes.Location = new System.Drawing.Point(86, 26);
			this.buttonTimes.Name = "buttonTimes";
			this.buttonTimes.Size = new System.Drawing.Size(28, 25);
			this.buttonTimes.TabIndex = 46;
			this.buttonTimes.Text = "*";
			this.buttonTimes.Click += new System.EventHandler(this.buttonTimes_Click);
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button6.Location = new System.Drawing.Point(58, 26);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(27, 25);
			this.button6.TabIndex = 45;
			this.button6.Text = "6";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button5.Location = new System.Drawing.Point(29, 26);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(27, 25);
			this.button5.TabIndex = 44;
			this.button5.Text = "5";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button4.Location = new System.Drawing.Point(0, 26);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(28, 25);
			this.button4.TabIndex = 43;
			this.button4.Text = "4";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// buttonDivide
			// 
			this.buttonDivide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonDivide.Location = new System.Drawing.Point(86, 0);
			this.buttonDivide.Name = "buttonDivide";
			this.buttonDivide.Size = new System.Drawing.Size(28, 25);
			this.buttonDivide.TabIndex = 42;
			this.buttonDivide.Text = "/";
			this.buttonDivide.Click += new System.EventHandler(this.buttonDivide_Click);
			// 
			// button9
			// 
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button9.Location = new System.Drawing.Point(58, 0);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(27, 25);
			this.button9.TabIndex = 41;
			this.button9.Text = "9";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// button8
			// 
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button8.Location = new System.Drawing.Point(29, 0);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(27, 25);
			this.button8.TabIndex = 40;
			this.button8.Text = "8";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button7.Location = new System.Drawing.Point(0, 0);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(28, 25);
			this.button7.TabIndex = 39;
			this.button7.Text = "7";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// buttonEquals
			// 
			this.buttonEquals.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonEquals.Location = new System.Drawing.Point(67, 103);
			this.buttonEquals.Name = "buttonEquals";
			this.buttonEquals.Size = new System.Drawing.Size(47, 25);
			this.buttonEquals.TabIndex = 38;
			this.buttonEquals.Text = "=";
			this.buttonEquals.Click += new System.EventHandler(this.buttonEquals_Click);
			// 
			// NumberPickerInput
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(112, 129);
			this.Controls.Add(this.buttonBackspace);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.button0);
			this.Controls.Add(this.buttonDecimalSeparator);
			this.Controls.Add(this.buttonPlusMinus);
			this.Controls.Add(this.buttonPlus);
			this.Controls.Add(this.buttonMinus);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonTimes);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.buttonDivide);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.buttonEquals);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "NumberPickerInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Êý×Ö";
			this.ResumeLayout(false);

		}
		#endregion

		#region EventHandlers
		/// <summary>
		/// Method to be performed when clicking the 7 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button7_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('7');
		}

		/// <summary>
		/// Method to be performed when clicking the 8 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button8_Click(object sender, System.EventArgs e)
		{ 
			this.AddCharacter('8');
		}

		/// <summary>
		/// Method to be performed when clicking the 9 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button9_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('9');
		}

		/// <summary>
		/// Method to be performed when clicking the 4 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button4_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('4');
		}

		/// <summary>
		/// Method to be performed when clicking the 5 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button5_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('5');
		}

		/// <summary>
		/// Method to be performed when clicking the 6 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button6_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('6');
		}

		/// <summary>
		/// Method to be performed when clicking the 1 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('1');
		}

		/// <summary>
		/// Method to be performed when clicking the 2 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('2');
		}

		/// <summary>
		/// Method to be performed when clicking the 3 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button3_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('3');
		}

		/// <summary>
		/// Method to be performed when clicking the 0 button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void button0_Click(object sender, System.EventArgs e)
		{
			this.AddCharacter('0');
		}

		/// <summary>
		/// Method to be performed when clicking the decimal separator button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonDecimalSeparator_Click(object sender, System.EventArgs e)
		{
			if (this.result.Text.IndexOf(".")>=0) 
			{
				return;
			}

			for (int i = 0; i < System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.Length; i++)
			{
				this.AddCharacter(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[i]);
			}
		}

		/// <summary>
		/// Method to be performed when clicking the minus button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonPlusMinus_Click(object sender, System.EventArgs e)
		{
			if(this.result.Text.Length >= 1) 
			{
				if(this.result.Text[0].Equals("-")) 
					this.result.Text = this.result.Text.Substring(1, this.result.Text.Length - 1);
				else
					this.result.Text = this.result.Text.Insert(0, "-");
			}
		}

		/// <summary>
		/// Method to be performed when clicking the clear button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonClear_Click(object sender, System.EventArgs e)
		{
			this.result.Text = "";
			this.temporary = 0;
			this.f = null;
			this.clear = false;
		}

		/// <summary>
		/// Method to be performed when clicking the backspace button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonBackspace_Click(object sender, System.EventArgs e)
		{
			this.result.Text = this.result.Text.Substring(0, this.result.Text.Length - 1);
		}

		/// <summary>
		/// Method to be performed when clicking the equals button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonEquals_Click(object sender, System.EventArgs e)
		{
			this.Calculate();
			this.Close();
		}

		/// <summary>
		/// Method to be performed when clicking the divide button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonDivide_Click(object sender, System.EventArgs e)
		{
			this.Calculate();
			this.temporary = Convert.ToDouble(this.result.Text);		
			this.f = new Function(Utilities.Divide);
			this.clear = true;
		}

		/// <summary>
		/// Method to be performed when clicking the times button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonTimes_Click(object sender, System.EventArgs e)
		{
			this.Calculate();
			this.temporary = Convert.ToDouble(this.result.Text);
			this.f = new Function(Utilities.Multiply);
			this.clear = true;
		}

		/// <summary>
		/// Method to be performed when clicking the minus button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonMinus_Click(object sender, System.EventArgs e)
		{
			this.Calculate();
			this.temporary = Convert.ToDouble(this.result.Text);
			this.f = new Function(Utilities.Substract);
			this.clear = true;
		}

		/// <summary>
		/// Method to be performed when clicking the plus button
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The arguments which have been given</param>
		private void buttonPlus_Click(object sender, System.EventArgs e)
		{
			this.Calculate();
			this.temporary = Convert.ToDouble(this.result.Text);
			this.f = new Function(Utilities.Add);
			this.clear = true;
		}

		#endregion
		
		#region Manipulators
		/// <summary>
		/// Method which is used for calculating the result of the function which has been pressed 
		/// with the temporary argument together with the last argument entered
		/// </summary>
		private void Calculate() 
		{
			if(this.f != null) 
			{
				// Calculate the new result based on the function
				this.temporary = f(this.temporary, Convert.ToDouble(this.result.Text));
				// Set the value of the textbox to the new result
				this.result.Text = this.temporary.ToString();
			}
			this.f = null;
		}

		/// <summary>
		/// Method that is used for adding a particular character to the textbox but first
		/// checking if the textbox does not need to be cleared first
		/// </summary>
		/// <param name="c">The new character to add</param>
		private void AddCharacter(char c) 
		{
			if(this.clear) 
			{
				this.result.Text = "";
				this.clear = false;
			}
			this.result.Text += c;
		}

		#endregion

		/// <summary>
		/// This class provides some basic functionality needed in the controls
		/// </summary>
		private class Utilities
		{
			/// <summary>
			/// Default constructor
			/// </summary>
			public Utilities()
			{
				// No initialization needed
			}

			/// <summary>
			/// Add method (standard mathematical operation, used in NumberPicker)
			/// </summary>
			/// <param name="x">First parameter</param>
			/// <param name="y">Second parameter</param>
			/// <returns>The result of adding the first parameter to the second one</returns>
			public static double Add(double x, double y) 
			{
				return x+y;
			}
		
			/// <summary>
			/// Substract method (standard mathematical operation, used in 
			/// NumberPicker)
			/// </summary>
			/// <param name="x">First parameter</param>
			/// <param name="y">Second parameter</param>
			/// <returns>The result of substracting the second parameter from the first one</returns>
			public static double Substract(double x, double y) 
			{
				return x-y;
			}
		
			/// <summary>
			/// Divide method (standard mathematical operation, used in
			/// NumberPicker)
			/// </summary>
			/// <param name="x">First parameter</param>
			/// <param name="y">Second parameter</param>
			/// <returns>The result of dividing the first parameter by the second one</returns>
			public static double Divide(double x, double y) 
			{
				return x/y;
			}
		
			/// <summary>
			/// Multiply method (standard mathematical operation, used in
			/// NumberPicker)
			/// </summary>
			/// <param name="x">First parameter</param>
			/// <param name="y">Second parameter</param>
			/// <returns>The result of multiplying the first parameter to the second one</returns>
			public static double Multiply(double x, double y) 
			{
				return x*y;
			}
		}
	}
}
