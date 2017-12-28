using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// This is the main class for the NumberPicker control
	/// </summary>
	[ToolboxBitmap(typeof(TextBox))]
	public class NeuNumberPicker : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TextBox textBoxNumber;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// The default constructor for the NumberPicker control
		/// </summary>
		public NeuNumberPicker()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumber.Location = new System.Drawing.Point(0, 0);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.TabIndex = 1;
			this.textBoxNumber.Text = "";
			this.textBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxNumber.DoubleClick += new System.EventHandler(this.textBoxNumber_DoubleClick);
			this.textBoxNumber.CausesValidation = true;
			this.textBoxNumber.Validating += new CancelEventHandler(this.textBoxNumber_Validation);
			// 
			// NumberPicker
			// 
			this.Controls.Add(this.textBoxNumber);
			this.Name = "NumberPicker";
			this.Size = new System.Drawing.Size(100, 20);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the value of the control using a string
		/// </summary>
		public override string Text 
		{
			get 
			{
				return this.textBoxNumber.Text;
			}
			set 
			{
				this.textBoxNumber.Text = value;
			}
		}

		/// <summary>
		/// Gets of sets the value of the control using a double 
		/// </summary>
		public double Value 
		{
			get 
			{
				return Convert.ToDouble(this.textBoxNumber.Text);
			}
			set 
			{
				this.textBoxNumber.Text = value.ToString();
			}
		}

		/// <summary>
		/// Gets or Sets the fact that the control has been modified since it was last created or set
		/// </summary>
		public bool Modified 
		{
			get 
			{
				return this.textBoxNumber.Modified;
			}
			set 
			{
				this.textBoxNumber.Modified = value;
			}	
		}

		/// <summary>
		/// Gets or Sets the maximum amount of characters which can be entered into the control
		/// </summary>
		public int MaxLength 
		{
			get 
			{
				return this.textBoxNumber.MaxLength;
			}
			set 
			{
				this.textBoxNumber.MaxLength = value;
			}
		}

		#endregion
		
		#region EventHandlers
		/// <summary>
		/// This method is invoked when the user double clicks the textbox in the control.
		/// It displays the calculator window which allows to insert the numbers.
		/// </summary>
		/// <param name="sender">The original sender object of the event</param>
		/// <param name="e">The parameters given.</param>
		private void textBoxNumber_DoubleClick(object sender, System.EventArgs e)
		{
			// Create a new instance of the calculator window
			NumberPickerInput input = new NumberPickerInput(this.textBoxNumber);
			// Calculate the position of the input form
			System.Drawing.Point location = this.PointToScreen(this.textBoxNumber.Location);
			int x = location.X + this.textBoxNumber.Width;
			int y = location.Y;
			// Set the location of the window
			input.Location = new System.Drawing.Point(x,y);
			// Validate it before showing the numeric pad
			CancelEventArgs args = new CancelEventArgs(false);
			this.textBoxNumber_Validation(this, args);
			if(args.Cancel == false) 
			{
				input.Show();
			}
		}


		private void textBoxNumber_Validation(object sender,CancelEventArgs ce)
		{
			try
			{
				if(this.textBoxNumber.Text.Length != 0) 
				{
					double value = Double.Parse(this.textBoxNumber.Text);
				}
			}
			catch(Exception)
			{
				ce.Cancel=true;
				MessageBox.Show("Please Enter Numeric Value");
			}
		}

		#endregion
	}
}
