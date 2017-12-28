 using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace UFC.EPR.Query
{
	/// <summary>
	/// frmSearchPatient 的摘要说明。
	/// </summary>
	public partial class frmSearchPatient :Neusoft.UFC.Common.Forms.frmSearchPatient
	{

		private void frmSearchPatient_Load(object sender, System.EventArgs e)
		{
			this.SaveInfo+=new Neusoft.UFC.Common.Forms.frmSearchPatient.SaveHandel(frmSearchPatient_SaveInfo);
		}
		
		/// <summary>
		/// 双击弹出对话框
		/// </summary>
		/// <param name="pa"></param>
		private void frmSearchPatient_SaveInfo(Neusoft.HISFC.Object.RADT.PatientInfo pa)
		{
			//UFC.EPR.Query.Function.EditEMR(pa,this);
		}

	}
}
