using System;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;

namespace Neusoft.FrameWork.WinForms.Controls
{
	/// <summary>
	/// NeuPrintPreviewDialog<br></br>
	/// [功能描述: NeuPrintPreviewDialog控件]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-18]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>	
	[ToolboxBitmap(typeof(PrintPreviewDialog))]
	public class NeuPrintPreviewDialog : PrintPreviewDialog
	{
		ToolBarButton printButton;

		/// <summary>
		/// 点击打印按钮事件
		/// </summary>
		public event EventHandler PrintButtonClick;

		public NeuPrintPreviewDialog() : base()
		{
			// we use reflection to e able to intercept the print button click on the dialog and do owe own fast printing
			Type t = typeof(PrintPreviewDialog);

			// first get the tool bar
			FieldInfo fi = t.GetField("toolBar1", BindingFlags.Instance | BindingFlags.NonPublic);
			// then get the button
			FieldInfo fi2 = t.GetField("printButton", BindingFlags.Instance | BindingFlags.NonPublic);

			// set owr class varialbe
			ToolBar toolBar1 = (ToolBar)fi.GetValue(this);
			this.printButton = (ToolBarButton)fi2.GetValue(this);

			toolBar1.ButtonClick +=	new ToolBarButtonClickEventHandler(toolBar1_Click);	
		}

		private void InitializeComponent()
		{
			// 
			// NeuPrintPreviewDialog
			// 
			this.ClientSize = new System.Drawing.Size(512, 446);
			this.Name = "NeuPrintPreviewDialog";

		}

		private void toolBar1_Click(object sender, ToolBarButtonClickEventArgs eventargs)
		{
			// if ower print button is pressed
			if (eventargs.Button == printButton)
			{
				//innerPrintDocument.Print();  // then start owr own printing
				//MessageBox.Show("The printing has finished with succes!");
				if (this.PrintButtonClick!=null) 
				{
					this.PrintButtonClick(this,null);
				}
			}
		}
	}
}
