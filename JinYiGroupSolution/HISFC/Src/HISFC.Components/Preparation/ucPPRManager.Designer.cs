namespace Neusoft.HISFC.Components.Preparation
{
    partial class ucPPRManager
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPPRManager));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fsDrug = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fsDrug_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.gbMaterialInfo = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.btnControl = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.gbNotice = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.lbNotice = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.ucExpand1 = new Neusoft.HISFC.Components.Preparation.ucExpand();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug_Sheet1)).BeginInit();
            this.gbMaterialInfo.SuspendLayout();
            this.gbNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fsDrug);
            this.splitContainer1.Panel1.Controls.Add(this.gbMaterialInfo);
            this.splitContainer1.Panel1.Controls.Add(this.gbNotice);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucExpand1);
            this.splitContainer1.Size = new System.Drawing.Size(732, 421);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // fsDrug
            // 
            this.fsDrug.About = "2.5.2007.2005";
            this.fsDrug.AccessibleDescription = "fsDrug, Sheet1";
            this.fsDrug.BackColor = System.Drawing.Color.White;
            this.fsDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsDrug.EditModeReplace = true;
            this.fsDrug.FileName = "";
            this.fsDrug.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsDrug.IsAutoSaveGridStatus = false;
            this.fsDrug.IsCanCustomConfigColumn = false;
            this.fsDrug.Location = new System.Drawing.Point(0, 39);
            this.fsDrug.Name = "fsDrug";
            this.fsDrug.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fsDrug_Sheet1});
            this.fsDrug.Size = new System.Drawing.Size(732, 125);
            this.fsDrug.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fsDrug.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fsDrug.TextTipAppearance = tipAppearance1;
            this.fsDrug.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fsDrug.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fsDrug_CellDoubleClick);
            this.fsDrug.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.fsDrug_SelectionChanged);
            this.fsDrug.EditModeOff += new System.EventHandler(this.fsDrug_EditModeOff);
            // 
            // fsDrug_Sheet1
            // 
            this.fsDrug_Sheet1.Reset();
            this.fsDrug_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fsDrug_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fsDrug_Sheet1.ColumnCount = 14;
            this.fsDrug_Sheet1.RowCount = 0;
            this.fsDrug_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "成品名称";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "规格";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "包装数量";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "包装单位";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "计划生产量";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "单位";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "送检量";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "检验合格";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "批号";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "有效期";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "半成品量";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "实入库量";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "成本价";
            this.fsDrug_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "备注";
            this.fsDrug_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsDrug_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fsDrug_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsDrug_Sheet1.Columns.Get(0).Label = "成品名称";
            this.fsDrug_Sheet1.Columns.Get(0).Locked = true;
            this.fsDrug_Sheet1.Columns.Get(0).Width = 120F;
            this.fsDrug_Sheet1.Columns.Get(1).Label = "规格";
            this.fsDrug_Sheet1.Columns.Get(1).Locked = true;
            this.fsDrug_Sheet1.Columns.Get(1).Width = 80F;
            this.fsDrug_Sheet1.Columns.Get(2).Label = "包装数量";
            this.fsDrug_Sheet1.Columns.Get(2).Locked = true;
            this.fsDrug_Sheet1.Columns.Get(3).Label = "包装单位";
            this.fsDrug_Sheet1.Columns.Get(3).Locked = true;
            this.fsDrug_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(4).CellType = numberCellType1;
            this.fsDrug_Sheet1.Columns.Get(4).Label = "计划生产量";
            this.fsDrug_Sheet1.Columns.Get(4).Locked = false;
            this.fsDrug_Sheet1.Columns.Get(4).Width = 70F;
            this.fsDrug_Sheet1.Columns.Get(5).Label = "单位";
            this.fsDrug_Sheet1.Columns.Get(5).Locked = true;
            this.fsDrug_Sheet1.Columns.Get(5).Width = 40F;
            this.fsDrug_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(6).CellType = numberCellType2;
            this.fsDrug_Sheet1.Columns.Get(6).Label = "送检量";
            this.fsDrug_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(7).CellType = checkBoxCellType1;
            this.fsDrug_Sheet1.Columns.Get(7).Label = "检验合格";
            this.fsDrug_Sheet1.Columns.Get(7).Locked = false;
            this.fsDrug_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(8).CellType = textCellType1;
            this.fsDrug_Sheet1.Columns.Get(8).Label = "批号";
            this.fsDrug_Sheet1.Columns.Get(8).Locked = false;
            this.fsDrug_Sheet1.Columns.Get(8).Width = 80F;
            this.fsDrug_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.SeaShell;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 9, 20, 15, 51, 57, 0);
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 9, 20, 15, 51, 57, 0);
            this.fsDrug_Sheet1.Columns.Get(9).CellType = dateTimeCellType1;
            this.fsDrug_Sheet1.Columns.Get(9).Label = "有效期";
            this.fsDrug_Sheet1.Columns.Get(9).Locked = false;
            this.fsDrug_Sheet1.Columns.Get(9).Width = 85F;
            this.fsDrug_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(10).CellType = numberCellType3;
            this.fsDrug_Sheet1.Columns.Get(10).Label = "半成品量";
            this.fsDrug_Sheet1.Columns.Get(10).Locked = false;
            this.fsDrug_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(11).CellType = numberCellType4;
            this.fsDrug_Sheet1.Columns.Get(11).Label = "实入库量";
            this.fsDrug_Sheet1.Columns.Get(11).Locked = false;
            this.fsDrug_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(12).CellType = numberCellType5;
            this.fsDrug_Sheet1.Columns.Get(12).Label = "成本价";
            this.fsDrug_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.SeaShell;
            this.fsDrug_Sheet1.Columns.Get(13).Label = "备注";
            this.fsDrug_Sheet1.Columns.Get(13).Locked = false;
            this.fsDrug_Sheet1.Columns.Get(13).Width = 165F;
            this.fsDrug_Sheet1.DefaultStyle.Locked = false;
            this.fsDrug_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fsDrug_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fsDrug_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fsDrug_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fsDrug_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fsDrug_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fsDrug_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fsDrug_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fsDrug_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fsDrug_Sheet1.SheetCornerStyle.Locked = false;
            this.fsDrug_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fsDrug_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fsDrug.SetActiveViewport(1, 0);
            // 
            // gbMaterialInfo
            // 
            this.gbMaterialInfo.BackColor = System.Drawing.Color.White;
            this.gbMaterialInfo.Controls.Add(this.btnControl);
            this.gbMaterialInfo.Controls.Add(this.neuLabel1);
            this.gbMaterialInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMaterialInfo.Location = new System.Drawing.Point(0, 164);
            this.gbMaterialInfo.Name = "gbMaterialInfo";
            this.gbMaterialInfo.Size = new System.Drawing.Size(732, 36);
            this.gbMaterialInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbMaterialInfo.TabIndex = 2;
            this.gbMaterialInfo.TabStop = false;
            // 
            // btnControl
            // 
            this.btnControl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnControl.Location = new System.Drawing.Point(582, 11);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(144, 23);
            this.btnControl.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnControl.TabIndex = 1;
            this.btnControl.Text = "隐藏原材料消耗信息";
            this.btnControl.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.neuLabel1.Location = new System.Drawing.Point(6, 15);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(149, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "生产原料、辅料理论消耗量";
            // 
            // gbNotice
            // 
            this.gbNotice.Controls.Add(this.lbNotice);
            this.gbNotice.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNotice.Location = new System.Drawing.Point(0, 0);
            this.gbNotice.Name = "gbNotice";
            this.gbNotice.Size = new System.Drawing.Size(732, 39);
            this.gbNotice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.gbNotice.TabIndex = 3;
            this.gbNotice.TabStop = false;
            this.gbNotice.Visible = false;
            // 
            // lbNotice
            // 
            this.lbNotice.AutoSize = true;
            this.lbNotice.ForeColor = System.Drawing.Color.Blue;
            this.lbNotice.Location = new System.Drawing.Point(6, 17);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(65, 12);
            this.lbNotice.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbNotice.TabIndex = 0;
            this.lbNotice.Text = "提示信息：";
            // 
            // ucExpand1
            // 
            this.ucExpand1.BackColor = System.Drawing.Color.White;
            this.ucExpand1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucExpand1.IsOnlyShowExpand = false;
            this.ucExpand1.IsPrint = false;
            this.ucExpand1.Location = new System.Drawing.Point(0, 0);
            this.ucExpand1.Name = "ucExpand1";
            this.ucExpand1.PlanNO = "";
            this.ucExpand1.Size = new System.Drawing.Size(732, 217);
            this.ucExpand1.StockDept = ((Neusoft.FrameWork.Models.NeuObject)(resources.GetObject( "ucExpand1.StockDept" )));
            this.ucExpand1.TabIndex = 0;
            // 
            // ucPPRManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucPPRManager";
            this.Size = new System.Drawing.Size(732, 421);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDrug_Sheet1)).EndInit();
            this.gbMaterialInfo.ResumeLayout(false);
            this.gbMaterialInfo.PerformLayout();
            this.gbNotice.ResumeLayout(false);
            this.gbNotice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fsDrug;
        protected FarPoint.Win.Spread.SheetView fsDrug_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbMaterialInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnControl;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private ucExpand ucExpand1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox gbNotice;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbNotice;

    }
}
