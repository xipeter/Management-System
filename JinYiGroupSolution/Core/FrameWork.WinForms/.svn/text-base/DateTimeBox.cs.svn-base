using System;
using System.Windows.Forms;
namespace neusoft.neuFC.Interface.Controls
{
	/// <summary>
	/// DateTimeBox 的摘要说明。
	/// </summary>
	public class DateTimeBox:System.Windows.Forms.DateTimePicker
	{
		public DateTimeBox()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			base.MouseDown+=new MouseEventHandler(DateTimeBox_MouseDown);
			base.ShowCheckBox = true;
			base.Checked = false;
			this.ShowTextBox();
			base.KeyDown+=new KeyEventHandler(DateTimeBox_KeyDown);
			base.KeyUp+=new KeyEventHandler(DateTimeBox_KeyUp);
			base.SizeChanged+=new EventHandler(DateTimeBox_SizeChanged);
			base.CloseUp+=new EventHandler(DateTimeBox_CloseUp);
		}

		/// <summary>
		/// 设置日期
		/// </summary>
		public new DateTime Value
		{
			get
			{
				if(base.Checked ==false)
				{
					return System.DateTime.MinValue;
				}
				else
				{
					return base.Value;
				}
			}
			set
			{
				if(DateTime.Parse(this.Value.ToString()) ==DateTime.MinValue)
				{
					base.Checked = false;
				}
				else
				{
					base.Value = value;
					base.Checked = true;
				}
				this.refresh();
			}
		}
		//		private DateTime dt;
		//		public new  DateTime MinDate
		//		{
		//			get
		//			{
		//				return dt;
		//			}
		//			set
		//			{
		//				this.dt = value;
		//			}
		//		}
		protected Label txtBox = new Label();
		protected void ShowTextBox()
		{
			txtBox.BackColor = System.Drawing.Color.White;
			txtBox.Text ="0000-00-00";
			txtBox.Location = new System.Drawing.Point(15,0);
			this.Controls.Add(txtBox);
		}
		protected void refresh()
		{

			System.Drawing.Size s = base.Size;
			s.Width =s.Width -35;
			txtBox.Size = s;
			txtBox.Font = base.Font;
			
		}
		public new System.Drawing.Color BackColor
		{
			get
			{
				
				return this.txtBox.BackColor;
			}
			set
			{
				txtBox.BackColor = value;
			}
		}
		public new bool Checked
		{
			get
			{
				
				return base.Checked ;
			}
			set
			{
				base.Checked  = value;
				txtBox.Visible = !value;
			}
		}
		public   System.Drawing.Image Image
		{
			get
			{
				
				return this.txtBox.Image;
			}
			set
			{
				txtBox.Image = value;
			}
		}
		public  new System.Drawing.Font Font
		{
			get
			{
				
				return base.Font;
			}
			set
			{
				txtBox.Font  = value;
				base.Font = value;
			}
		}
		private void DateTimeBox_MouseDown(object sender, MouseEventArgs e)
		{
			txtBox.Visible = !base.Checked;
		}

		private void DateTimeBox_CloseUp(object sender, EventArgs e)
		{
			txtBox.Visible = !base.Checked;
		}

		private void DateTimeBox_SizeChanged(object sender, EventArgs e)
		{
			this.refresh();
		}
		
		private void DateTimeBox_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Space)
			{
				txtBox.Visible = this.Checked;
			}
			else
			{
				base.Checked = true;
				txtBox.Visible = false;
			}
		}

		private void DateTimeBox_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Space)
			{
				txtBox.Visible = !this.Checked;
			}
		}
	}
}
