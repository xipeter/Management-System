using System;

namespace Neusoft.FrameWork.WinForms.Classes
{
	/// <summary>
	/// PrintControlCompare 的摘要说明。
	/// 打印控件对照
	/// </summary>
	public class PrintControlCompare
	{
		/// <summary>
		/// 默认NeusoftControl
		/// </summary>
		public PrintControlCompare()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.SetNeusoftControl();

		}

		/// <summary>
		/// 控件对照类
		/// </summary>
		public System.Collections.Hashtable Controls = null;

		/// <summary>
		/// 设置EPRControl对照表
		/// </summary>
		public void SetEPRControl()
		{
			this.Controls = new System.Collections.Hashtable();
			this.Controls.Add("emrCaculateControl","TextBox");
			this.Controls.Add("emrCheckBox","CheckBox");
			this.Controls.Add("emrComboBox","TextBox");
			this.Controls.Add("emrDateTime","DateTimePicker");
			this.Controls.Add("emrGroupBox","GroupBox");
			this.Controls.Add("emrImage","PictureBox");
			this.Controls.Add("emrLabel","Lable");
			this.Controls.Add("emrRealLabel","Lable");
			this.Controls.Add("emrLine","Panel");
			this.Controls.Add("emrListBox","ListBox");
			this.Controls.Add("emrMultiLineTextBox","RichTextBox");
			this.Controls.Add("emrPanel","Panel");
			this.Controls.Add("emrRadioButton","RadioButton");
			this.Controls.Add("emrTextBox","TextBox");
			this.Controls.Add("ucGrid","Grid");
			this.Controls.Add("ucPage","Page");
			this.Controls.Add("ucDiseaseRecord","Form");
            this.Controls.Add("emrDataTable", "FpSpread");
		}

		/// <summary>
		/// 设置东软控件对照
		/// </summary>
		public void SetNeusoftControl()
		{
			this.Controls = new System.Collections.Hashtable();
			this.Controls.Add("NeuCheckBox","CheckBox");
			this.Controls.Add("NeuComboBox","TextBox");
			this.Controls.Add("NeuDateTimePicker","DateTimePicker");
			this.Controls.Add("NeuGroupBox","GroupBox");
			this.Controls.Add("NeuPictureBox","PictureBox");
			this.Controls.Add("NeuLabel","Label");
			this.Controls.Add("NeuPanel","Panel");
            this.Controls.Add("NeuSpread", "FpSpread");
            //{165AC0FA-EFDB-4c5a-BF45-C7668FC6D88B}
            this.Controls.Add("NeuEnter", "FpSpread");//新加一行
			this.Controls.Add("NeuListBox","ListBox");
			this.Controls.Add("NeuRichTextBox","RichTextBox");
			this.Controls.Add("NeuRadioButton","RadioButton");
			this.Controls.Add("NeuTextBox","TextBox");
			
		}

	}
}
