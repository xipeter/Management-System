using System;
using System.Windows.Forms;
namespace Neusoft.FrameWork.WinForms.Classes
{
	/// <summary>
	/// PreviewPrintControl 的摘要说明。
	/// </summary>
	public class PreviewPrintControl: System.Drawing.Printing.PreviewPrintController
	{
		public PreviewPrintControl(Control panel)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			this.panel = panel;
		}
		private Control panel = null;
        //public override void OnStartPrint(System.Drawing.Printing.PrintDocument document, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    Control c = this.IsCanContinuePrint();
        //    object tag = null;
        //    if (c != null)
        //    {
        //        tag = c.Tag;
        //        c.Tag = "";
        //        ((RichTextBox)c).Select(0, 0);
        //        ((RichTextBox)c).ScrollToCaret();
        //    }
        //    base.OnStartPrint(document, e);
        //}

        //public override void OnEndPrint(System.Drawing.Printing.PrintDocument document, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    Control c = this.IsCanContinuePrint();
        //    if (c != null)
        //    {
        //        c.Tag = c.Text.Length;
        //    }
        //    base.OnEndPrint(document, e);
        //}

		/// <summary>
		/// 分页的都能续打吗
		/// </summary>
		/// <returns></returns>
        //private Control IsCanContinuePrint()
        //{
        //    if(panel == null) return null;			
        //    try
        //    {
        //        foreach(Control c  in ((Neusoft.EPRControl.emrPanel)panel).Controls)
        //        {	
        //            if(c.GetType() == typeof(Neusoft.EPRControl.ucDiseaseRecord))
        //            {
        //                return ((Neusoft.EPRControl.ucDiseaseRecord)c).FocedControl;
        //            }
        //        }
        //    }
        //    catch{return null;}
        //    return null;
        //}

	}
}
