using System;

namespace NFC.Interface.Controls
{
	/// <summary>
	/// FormEx 的摘要说明。
	/// </summary>
	public class FormEx : System.Windows.Forms.Form
	{
		protected System.Windows.Forms.ImageList imageList1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private System.ComponentModel.IContainer components;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			// 
			// fpSpread1
			// 
			this.fpSpread1.Location = new System.Drawing.Point(64, 72);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(152, 128);
			this.fpSpread1.TabIndex = 0;
			// 
			// FormEx
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.fpSpread1);
			this.Name = "FormEx";
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			this.ResumeLayout(false);

		}
		public FormEx()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			vbWindowsUI.VSNetMenuProvider.Hook(this);

		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed (e);
			vbWindowsUI.VSNetMenuProvider.Unhook();
		}


	}
}
