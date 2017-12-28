using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// 自定义控件属性类
	/// </summary>
	[DefaultProperty("Size")]
	internal class OwnControl
	{
		private Control control;
		private bool IsUseDefaultText;
		private ControlText controlText;

		public OwnControl(bool IsUseDefaultText)
		{
			this.IsUseDefaultText = IsUseDefaultText;
		}

		[Description("控件"),Browsable(false)]
		public Control Control
		{
			get
			{
				return this.control;
			}
			set
			{
				this.control = value;
			}
		}

		[Description("控件的大小（以像素为单位）。"),Category("Layout")]
		public Size Size
		{
			get
			{
				return this.control.Size;
			}
			set
			{
				this.control.Size = value;
			}
		}

		[Description("控件左上角相对于其容器的位置。"),Category("Layout")]
		public Point Location
		{
			get
			{
				return this.control.Location;
			}
			set
			{
				this.control.Location = value;
			}
		}

		[Description("用于显示控件文本和图形的背景色。"),Category("Appearance")]
		public Color BackColor
		{
			get
			{
				return this.control.BackColor;
			}
			set
			{
				this.control.BackColor = value;
			}
		}

		[Description("用于显示控件中文本的字体。"),Category("Appearance")]
		public Font Font
		{
			get
			{
				return this.control.Font;
			}
			set
			{
				this.control.Font = value;
			}
		}

		[Description("用于显示控件文本和图形的前景色。"),Category("Appearance")]
		public Color ForeColor
		{
			get
			{
				return this.control.ForeColor;
			}
			set
			{
				this.control.ForeColor = value;
			}
		}

		[Description("指示是否使用该控件。"),Category("Behavior")]
		public bool Enabled
		{
			get
			{
				return this.control.Enabled;
			}
			set
			{
				this.control.Enabled = value;
			}
		}

		[Description("按TAB键顺序确定该控件将占用的索引。"),Category("Behavior")]
		public int TabIndex
		{
			get
			{
				return this.control.TabIndex;
			}
			set
			{
				this.control.TabIndex = value;
			}
		}

		[Description("确定该控件是可见还是隐藏。"),Category("Behavior")]
		public bool Visible
		{
			get
			{
				return this.control.Visible;
			}
			set
			{
				this.control.Visible = value;
			}
		}

		[Category("Behavior")]
		public ControlText ControlText
		{
			get
			{
				if(this.controlText == null)
				{
					this.controlText = new ControlText(this.control.Text, this.IsUseDefaultText);
					controlText.Text = this.control.Text;
				}
//				controlText.IsUseDefaultText = this.IsUseDefaultText;
				return controlText;
			}
			set
			{
				this.controlText = value;
				this.control.Text = value.Text;
				this.IsUseDefaultText = value.IsUseDefaultText;
			}
		}
	}
}
