namespace Neusoft.HISFC.Components.Manager.Items
{
	partial class ucFinanceGroup
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            this.fpGroup_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpGroup = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpGroupEmployee_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpGroupEmployee = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpEmployee_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpEmployee = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.palMain = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.palRightDown = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.palRightTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.palLeft = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.palLeftTop = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.cbDepartment = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroup_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroupEmployee_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroupEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpEmployee_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpEmployee)).BeginInit();
            this.palMain.SuspendLayout();
            this.palRightDown.SuspendLayout();
            this.palRightTop.SuspendLayout();
            this.palLeft.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.palLeftTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpGroup_Sheet1
            // 
            this.fpGroup_Sheet1.Reset();
            this.fpGroup_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpGroup_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpGroup_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "财务组编码";
            this.fpGroup_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "财务组名称";
            this.fpGroup_Sheet1.Columns.Get(0).Label = "财务组编码";
            this.fpGroup_Sheet1.Columns.Get(0).Locked = true;
            this.fpGroup_Sheet1.Columns.Get(0).Width = 90F;
            this.fpGroup_Sheet1.Columns.Get(1).Label = "财务组名称";
            this.fpGroup_Sheet1.Columns.Get(1).Width = 90F;
            this.fpGroup_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpGroup_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpGroup_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpGroup_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpGroup
            // 
            this.fpGroup.About = "2.5.2007.2005";
            this.fpGroup.AccessibleDescription = "fpGroup, Sheet1, Row 0, Column 0, ";
            this.fpGroup.BackColor = System.Drawing.Color.White;
            this.fpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpGroup.FileName = "";
            this.fpGroup.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpGroup.IsAutoSaveGridStatus = false;
            this.fpGroup.IsCanCustomConfigColumn = false;
            this.fpGroup.Location = new System.Drawing.Point(0, 0);
            this.fpGroup.Name = "fpGroup";
            this.fpGroup.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpGroup_Sheet1});
            this.fpGroup.Size = new System.Drawing.Size(566, 162);
            this.fpGroup.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpGroup.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpGroup.TextTipAppearance = tipAppearance1;
            this.fpGroup.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpGroup.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fpGroup_SelectionChanged);
            this.fpGroup.EditModeOff += new System.EventHandler(this.fpGroup_EditModeOff);
            // 
            // fpGroupEmployee_Sheet1
            // 
            this.fpGroupEmployee_Sheet1.Reset();
            this.fpGroupEmployee_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpGroupEmployee_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpGroupEmployee_Sheet1.Cells.Get(0, 0).Locked = true;
            this.fpGroupEmployee_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "财务组编码";
            this.fpGroupEmployee_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "财务组名称";
            this.fpGroupEmployee_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "人员编码";
            this.fpGroupEmployee_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "人员姓名";
            this.fpGroupEmployee_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "有效性状态";
            this.fpGroupEmployee_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "顺序号";
            this.fpGroupEmployee_Sheet1.Columns.Get(0).Label = "财务组编码";
            this.fpGroupEmployee_Sheet1.Columns.Get(0).Width = 90F;
            this.fpGroupEmployee_Sheet1.Columns.Get(1).Label = "财务组名称";
            this.fpGroupEmployee_Sheet1.Columns.Get(1).Locked = true;
            this.fpGroupEmployee_Sheet1.Columns.Get(1).Width = 90F;
            this.fpGroupEmployee_Sheet1.Columns.Get(2).Label = "人员编码";
            this.fpGroupEmployee_Sheet1.Columns.Get(2).Locked = true;
            this.fpGroupEmployee_Sheet1.Columns.Get(3).Label = "人员姓名";
            this.fpGroupEmployee_Sheet1.Columns.Get(3).Locked = true;
            this.fpGroupEmployee_Sheet1.Columns.Get(4).Label = "有效性状态";
            this.fpGroupEmployee_Sheet1.Columns.Get(4).Width = 90F;
            this.fpGroupEmployee_Sheet1.Columns.Get(6).Locked = true;
            this.fpGroupEmployee_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpGroupEmployee_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpGroupEmployee_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpGroupEmployee_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpGroupEmployee
            // 
            this.fpGroupEmployee.About = "2.5.2007.2005";
            this.fpGroupEmployee.AccessibleDescription = "fpGroupEmployee, Sheet1, Row 0, Column 0, ";
            this.fpGroupEmployee.BackColor = System.Drawing.Color.White;
            this.fpGroupEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpGroupEmployee.FileName = "";
            this.fpGroupEmployee.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpGroupEmployee.IsAutoSaveGridStatus = false;
            this.fpGroupEmployee.IsCanCustomConfigColumn = false;
            this.fpGroupEmployee.Location = new System.Drawing.Point(0, 0);
            this.fpGroupEmployee.Name = "fpGroupEmployee";
            this.fpGroupEmployee.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpGroupEmployee_Sheet1});
            this.fpGroupEmployee.Size = new System.Drawing.Size(566, 310);
            this.fpGroupEmployee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpGroupEmployee.TabIndex = 2;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpGroupEmployee.TextTipAppearance = tipAppearance2;
            this.fpGroupEmployee.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpEmployee_Sheet1
            // 
            this.fpEmployee_Sheet1.Reset();
            this.fpEmployee_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpEmployee_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpEmployee_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "人员编码";
            this.fpEmployee_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "人员姓名";
            this.fpEmployee_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "科室代码";
            this.fpEmployee_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpEmployee_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpEmployee_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpEmployee_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpEmployee_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpEmployee_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpEmployee
            // 
            this.fpEmployee.About = "2.5.2007.2005";
            this.fpEmployee.AccessibleDescription = "fpEmployee, Sheet1, Row 0, Column 0, ";
            this.fpEmployee.BackColor = System.Drawing.Color.White;
            this.fpEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpEmployee.FileName = "";
            this.fpEmployee.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpEmployee.IsAutoSaveGridStatus = false;
            this.fpEmployee.IsCanCustomConfigColumn = false;
            this.fpEmployee.Location = new System.Drawing.Point(0, 0);
            this.fpEmployee.Name = "fpEmployee";
            this.fpEmployee.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpEmployee_Sheet1});
            this.fpEmployee.Size = new System.Drawing.Size(235, 409);
            this.fpEmployee.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpEmployee.TabIndex = 0;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpEmployee.TextTipAppearance = tipAppearance3;
            this.fpEmployee.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpEmployee.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpEmployee_CellDoubleClick);
            // 
            // palMain
            // 
            this.palMain.Controls.Add(this.palRightDown);
            this.palMain.Controls.Add(this.palRightTop);
            this.palMain.Controls.Add(this.palLeft);
            this.palMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palMain.Location = new System.Drawing.Point(0, 0);
            this.palMain.Name = "palMain";
            this.palMain.Size = new System.Drawing.Size(801, 472);
            this.palMain.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.palMain.TabIndex = 5;
            // 
            // palRightDown
            // 
            this.palRightDown.Controls.Add(this.fpGroupEmployee);
            this.palRightDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palRightDown.Location = new System.Drawing.Point(235, 162);
            this.palRightDown.Name = "palRightDown";
            this.palRightDown.Size = new System.Drawing.Size(566, 310);
            this.palRightDown.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.palRightDown.TabIndex = 2;
            // 
            // palRightTop
            // 
            this.palRightTop.Controls.Add(this.fpGroup);
            this.palRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.palRightTop.Location = new System.Drawing.Point(235, 0);
            this.palRightTop.Name = "palRightTop";
            this.palRightTop.Size = new System.Drawing.Size(566, 162);
            this.palRightTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.palRightTop.TabIndex = 1;
            // 
            // palLeft
            // 
            this.palLeft.Controls.Add(this.neuPanel1);
            this.palLeft.Controls.Add(this.palLeftTop);
            this.palLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.palLeft.Location = new System.Drawing.Point(0, 0);
            this.palLeft.Name = "palLeft";
            this.palLeft.Size = new System.Drawing.Size(235, 472);
            this.palLeft.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.palLeft.TabIndex = 0;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.fpEmployee);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 63);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(235, 409);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // palLeftTop
            // 
            this.palLeftTop.Controls.Add(this.cbDepartment);
            this.palLeftTop.Controls.Add(this.neuLabel1);
            this.palLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.palLeftTop.Location = new System.Drawing.Point(0, 0);
            this.palLeftTop.Name = "palLeftTop";
            this.palLeftTop.Size = new System.Drawing.Size(235, 63);
            this.palLeftTop.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.palLeftTop.TabIndex = 0;
            // 
            // cbDepartment
            // 
            this.cbDepartment.ArrowBackColor = System.Drawing.Color.Silver;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.IsFlat = true;
            this.cbDepartment.IsLike = true;
            this.cbDepartment.Location = new System.Drawing.Point(78, 20);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.PopForm = null;
            this.cbDepartment.ShowCustomerList = false;
            this.cbDepartment.ShowID = false;
            this.cbDepartment.Size = new System.Drawing.Size(142, 20);
            this.cbDepartment.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cbDepartment.TabIndex = 0;
            this.cbDepartment.Tag = "";
            this.cbDepartment.ToolBarUse = false;
            this.cbDepartment.SelectedIndexChanged += new System.EventHandler(this.cbDepartment_SelectedIndexChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(15, 25);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "选择科室：";
            // 
            // ucFinanceGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.palMain);
            this.Name = "ucFinanceGroup";
            this.Size = new System.Drawing.Size(801, 472);
            this.Load += new System.EventHandler(this.ucFinanceGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpGroup_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroupEmployee_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpGroupEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpEmployee_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpEmployee)).EndInit();
            this.palMain.ResumeLayout(false);
            this.palRightDown.ResumeLayout(false);
            this.palRightTop.ResumeLayout(false);
            this.palLeft.ResumeLayout(false);
            this.neuPanel1.ResumeLayout(false);
            this.palLeftTop.ResumeLayout(false);
            this.palLeftTop.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private FarPoint.Win.Spread.SheetView fpGroup_Sheet1;
        //private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpGrou;
        private FarPoint.Win.Spread.SheetView fpGroupEmployee_Sheet1;
        private FarPoint.Win.Spread.SheetView fpEmployee_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpEmployee;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel palMain;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel palLeft;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel palRightDown;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel palRightTop;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel palLeftTop;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cbDepartment;
        public Neusoft.FrameWork.WinForms.Controls.NeuSpread fpGroupEmployee;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpGroup;
	}
}
