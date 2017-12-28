using Neusoft.FrameWork.WinForms.Controls;

namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucBookingTemplet <br></br>
	/// [功能描述: 医技项目排班模板的项目UC]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	partial class ucBookingTemplet
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBookingTemplet));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.EditModePermanent = true;
            this.neuSpread1.EditModeReplace = true;
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.SelectNone = false;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.ShowListWhenOfFocus = false;
            this.neuSpread1.Size = new System.Drawing.Size(804, 442);
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_ComboCloseUp);
            this.neuSpread1.KeyEnter += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.keyDown(this.neuSpread1_KeyEnter);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 12;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "项目代码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "项目名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "单位标识";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "预约限额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "特诊预约限额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "午别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "有效标识";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "注意事项";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "旧午别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "开始时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "结束时间";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "项目代码";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "项目名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 100F;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "单位标识";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "特诊预约限额";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 100F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "有效",
        "无效"};
            this.neuSpread1_Sheet1.Columns.Get(6).CellType = comboBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "有效标识";
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "注意事项";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 300F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "旧午别";
            this.neuSpread1_Sheet1.Columns.Get(8).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get(9).Visible = false;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2008, 7, 15, 0, 0, 0, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
            dateTimeCellType1.TimeDefault = new System.DateTime(2008, 7, 15, 0, 0, 0, 0);
            this.neuSpread1_Sheet1.Columns.Get(10).CellType = dateTimeCellType1;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "开始时间";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 112F;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.DateDefault = new System.DateTime(2008, 7, 15, 14, 37, 35, 0);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
            dateTimeCellType2.TimeDefault = new System.DateTime(2008, 7, 15, 14, 37, 35, 0);
            this.neuSpread1_Sheet1.Columns.Get(11).CellType = dateTimeCellType2;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "结束时间";
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 104F;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // ucBookingTemplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Name = "ucBookingTemplet";
            this.Size = new System.Drawing.Size(804, 442);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// FarPoint
		/// </summary>
		private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter neuSpread1;
		/// <summary>
		/// FarPoint
		/// </summary>
		private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
	}
}
