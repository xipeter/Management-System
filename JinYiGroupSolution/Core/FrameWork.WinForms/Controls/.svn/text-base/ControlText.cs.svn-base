using System;
using System.ComponentModel;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// 控件文本属性类，保存控件文本与是否使用缺省文本
	/// </summary>
	[TypeConverter(typeof(ControlTextTransfer)),Description("展开以察看是否可以修改文本")]
	internal class ControlText
	{
		private string text;
		private bool isUseDefault = false;

		[Description("控件中包含的文本。")]
		public string Text
		{
			get
			{
				return text;
			}
			set
			{
				text = value;
			}
		}

		[DefaultValue(false),Description("控件文本是否使用默认值")]
		public bool IsUseDefaultText
		{
			get
			{
				return isUseDefault;
			}
			set
			{
				isUseDefault = value;
			}
		}

		public ControlText()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public ControlText(string Text, bool IsUseDefaultText)
		{
			this.text = Text;
			this.isUseDefault = IsUseDefaultText;
		}
	}
}
