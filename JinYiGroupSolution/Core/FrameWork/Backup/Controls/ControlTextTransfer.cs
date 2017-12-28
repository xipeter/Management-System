using System;
using System.ComponentModel;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// 控件文本属性转换类
	/// </summary>
	internal class ControlTextTransfer:System.ComponentModel.ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if(destinationType == typeof(ControlText)) return true;
			return base.CanConvertTo (context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if(destinationType == typeof(System.String) && value is ControlText)
			{
				ControlText ct = (ControlText)value;
				string str = ct.Text + "," + ct.IsUseDefaultText.ToString();
				return str;
			}

			return base.ConvertTo (context, culture, value, destinationType);
		}
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
//			return true;
			if(sourceType == typeof(string)) return true;
			return base.CanConvertFrom (context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if(value is string)
			{
				try
				{
					string str = (string)value;
					int i = str.LastIndexOf(",");
					if(i != -1)
					{
						ControlText ct = new ControlText();
						ct.IsUseDefaultText = bool.Parse(str.Substring(i + 1).Trim());
						ct.Text = str.Substring(0, i);
						return ct;
					}
				}
				catch
				{
					throw new ArgumentException("无法将\"" + (string)value + "\"转换为ControlText类型");
				}
			}

			return base.ConvertFrom (context, culture, value);
		}

		public ControlTextTransfer()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}
}
