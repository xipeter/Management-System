using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	/// <summary>
	/// frmPatientName <br></br>
	/// [功能描述: 患者姓名输入窗口]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-03-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class frmPatientName : Form
	{
		public frmPatientName()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 患者姓名
		/// </summary>
		public string patientName = "";

		/// <summary>
		/// 命令按钮单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonOk_Click(object sender, EventArgs e)
		{
			this.patientName = this.textBoxPatient.Text;
			this.Hide();
		}

		/// <summary>
		/// 姓名按键事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBoxPatient_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Enter))
			{
				this.patientName = this.textBoxPatient.Text;
				this.DialogResult = DialogResult.OK;
				this.Hide();
			}
		}
	}
}