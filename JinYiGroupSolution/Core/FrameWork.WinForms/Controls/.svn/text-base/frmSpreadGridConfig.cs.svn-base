using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Neusoft.NFC.Interface.Controls
{
	/// <summary>
	/// frmSpreadGridConfig<br></br>
	/// [功能描述: frmSpreadGridConfig窗体]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-14]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	internal class frmSpreadGridConfig : System.Windows.Forms.Form
	{
		private Neusoft.NFC.Interface.Controls.NeuToolBar neuToolBar1;
		private FarPoint.Win.Spread.FpSpread fpSpread1;
		private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbSave;
		private System.ComponentModel.IContainer components;

		private FarPoint.Win.Spread.FpSpread spread;
		private bool	isDirty;

		private frmSpreadGridConfig()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public frmSpreadGridConfig(FarPoint.Win.Spread.FpSpread spread) : this()
		{
			this.spread = spread;

			this.Init();
		}
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSpreadGridConfig));
			this.neuToolBar1 = new Neusoft.NFC.Interface.Controls.NeuToolBar();
			this.tbSave = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
			this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// neuToolBar1
			// 
			this.neuToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.neuToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.tbSave});
			this.neuToolBar1.DropDownArrows = true;
			this.neuToolBar1.ImageList = this.imageList1;
			this.neuToolBar1.Location = new System.Drawing.Point(0, 0);
			this.neuToolBar1.Name = "neuToolBar1";
			this.neuToolBar1.ShowToolTips = true;
			this.neuToolBar1.Size = new System.Drawing.Size(680, 49);
			this.neuToolBar1.Style = Neusoft.NFC.Interface.Controls.StyleType.VS2003;
			this.neuToolBar1.TabIndex = 1;
			this.neuToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.neuToolBar1_ButtonClick);
			// 
			// tbSave
			// 
			this.tbSave.ImageIndex = 0;
			this.tbSave.Text = "设置";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// fpSpread1
			// 
			this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fpSpread1.Location = new System.Drawing.Point(0, 49);
			this.fpSpread1.Name = "fpSpread1";
			this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpSpread1_Sheet1});
			this.fpSpread1.Size = new System.Drawing.Size(680, 621);
			this.fpSpread1.TabIndex = 2;
			// 
			// fpSpread1_Sheet1
			// 
			this.fpSpread1_Sheet1.Reset();
			this.fpSpread1_Sheet1.SheetName = "Sheet1";
			this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.fpSpread1_Sheet1_CellChanged);
			// 
			// frmSpreadGridConfig
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(680, 670);
			this.Controls.Add(this.fpSpread1);
			this.Controls.Add(this.neuToolBar1);
			this.Name = "frmSpreadGridConfig";
			this.Text = "设置";
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
#region 方法
		private void Init()
		{
			this.fpSpread1_Sheet1.RowCount = 0;
			this.fpSpread1_Sheet1.ColumnCount = 2;
			this.fpSpread1_Sheet1.Columns[0].Label = "显示";
			this.fpSpread1_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			
			this.fpSpread1_Sheet1.Columns[1].Label = "列名";
			this.fpSpread1_Sheet1.Columns[1].Width = 400;

			foreach (Column column in this.spread.Sheets[0].Columns)
			{
				this.fpSpread1_Sheet1.RowCount += 1;
				this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.RowCount - 1,0].Value = column.Visible;
				this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.RowCount - 1,1].Text = column.Label;
			
			}

			this.isDirty = false;
		}


		private void Setup()
		{
			for(int i=0;i<this.fpSpread1_Sheet1.RowCount;++i)
			{
				this.spread.Sheets[0].Columns[i].Visible = (bool)this.fpSpread1_Sheet1.Cells[i,0].Value;
			}

			this.isDirty = false;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing (e);
			if (this.isDirty) 
			{
				DialogResult result;
				result = MessageBox.Show("是否进行设置更改？","",MessageBoxButtons.YesNoCancel);
				if(result == DialogResult.Yes)
				{
					this.Setup();
					e.Cancel = false;
					return;
				}
				else if (result == DialogResult.Cancel) 
				{
					e.Cancel = true;
					return;
				}
				else
				{
					e.Cancel=false;
				}
			}
		}


#endregion

#region 事件
		private void neuToolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			this.fpSpread1.EditMode=false;
			this.Setup();
		}

		private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
		{
			this.isDirty = true;
		
		}
#endregion

	}
}
