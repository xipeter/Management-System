namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    partial class ucMonthStoreManager
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
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMonthStoreManager));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpHeadSheet = new FarPoint.Win.Spread.SheetView();
            this.fpDetailSheet = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.txtFilter = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbStoreDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHeadSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetailSheet)).BeginInit();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 月结记录";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 53);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpHeadSheet,
            this.fpDetailSheet});
            this.neuSpread1.Size = new System.Drawing.Size(731, 332);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ActiveSheetChanged += new System.EventHandler(this.neuSpread1_ActiveSheetChanged);
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            // 
            // fpHeadSheet
            // 
            this.fpHeadSheet.Reset();
            this.fpHeadSheet.SheetName = "月结记录";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpHeadSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpHeadSheet.ColumnCount = 10;
            this.fpHeadSheet.RowCount = 0;
            this.fpHeadSheet.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 0).Value = "月结起始时间";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 1).Value = "月结终止时间";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 2).Value = "上期结存";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 3).Value = "上期入库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 4).Value = "上期出库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 5).Value = "特殊入库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 6).Value = "特殊出库";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 7).Value = "盘点盈亏";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 8).Value = "调价盈亏";
            this.fpHeadSheet.ColumnHeader.Cells.Get(0, 9).Value = "本期结存";
            this.fpHeadSheet.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHeadSheet.ColumnHeader.DefaultStyle.Locked = false;
            this.fpHeadSheet.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 4, 17, 13, 47, 45, 0);
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 4, 17, 13, 47, 45, 0);
            this.fpHeadSheet.Columns.Get(0).CellType = dateTimeCellType1;
            this.fpHeadSheet.Columns.Get(0).Label = "月结起始时间";
            this.fpHeadSheet.Columns.Get(0).Width = 123F;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.DateDefault = new System.DateTime(2007, 4, 17, 13, 47, 48, 0);
            dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
            dateTimeCellType2.TimeDefault = new System.DateTime(2007, 4, 17, 13, 47, 48, 0);
            this.fpHeadSheet.Columns.Get(1).CellType = dateTimeCellType2;
            this.fpHeadSheet.Columns.Get(1).Label = "月结终止时间";
            this.fpHeadSheet.Columns.Get(1).Width = 123F;
            this.fpHeadSheet.Columns.Get(2).CellType = numberCellType1;
            this.fpHeadSheet.Columns.Get(2).Label = "上期结存";
            this.fpHeadSheet.Columns.Get(2).Width = 93F;
            this.fpHeadSheet.Columns.Get(3).CellType = numberCellType2;
            this.fpHeadSheet.Columns.Get(3).Label = "上期入库";
            this.fpHeadSheet.Columns.Get(3).Width = 93F;
            this.fpHeadSheet.Columns.Get(4).CellType = numberCellType3;
            this.fpHeadSheet.Columns.Get(4).Label = "上期出库";
            this.fpHeadSheet.Columns.Get(4).Width = 93F;
            this.fpHeadSheet.Columns.Get(5).CellType = numberCellType4;
            this.fpHeadSheet.Columns.Get(5).Label = "特殊入库";
            this.fpHeadSheet.Columns.Get(5).Width = 93F;
            this.fpHeadSheet.Columns.Get(6).CellType = numberCellType5;
            this.fpHeadSheet.Columns.Get(6).Label = "特殊出库";
            this.fpHeadSheet.Columns.Get(6).Width = 93F;
            this.fpHeadSheet.Columns.Get(7).CellType = numberCellType6;
            this.fpHeadSheet.Columns.Get(7).Label = "盘点盈亏";
            this.fpHeadSheet.Columns.Get(7).Width = 93F;
            this.fpHeadSheet.Columns.Get(8).CellType = numberCellType7;
            this.fpHeadSheet.Columns.Get(8).Label = "调价盈亏";
            this.fpHeadSheet.Columns.Get(8).Width = 93F;
            this.fpHeadSheet.Columns.Get(9).CellType = numberCellType8;
            this.fpHeadSheet.Columns.Get(9).Label = "本期结存";
            this.fpHeadSheet.Columns.Get(9).Width = 93F;
            this.fpHeadSheet.DataAutoCellTypes = false;
            this.fpHeadSheet.DataAutoHeadings = false;
            this.fpHeadSheet.DataAutoSizeColumns = false;
            this.fpHeadSheet.DefaultStyle.Locked = true;
            this.fpHeadSheet.DefaultStyle.Parent = "DataAreaDefault";
            this.fpHeadSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpHeadSheet.RowHeader.Columns.Default.Resizable = false;
            this.fpHeadSheet.RowHeader.Columns.Get(0).Width = 37F;
            this.fpHeadSheet.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpHeadSheet.RowHeader.DefaultStyle.Locked = false;
            this.fpHeadSheet.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpHeadSheet.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpHeadSheet.SheetCornerStyle.Locked = false;
            this.fpHeadSheet.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpHeadSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // fpDetailSheet
            // 
            this.fpDetailSheet.Reset();
            this.fpDetailSheet.SheetName = "月结明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpDetailSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpDetailSheet.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin3", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpDetailSheet.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetailSheet.ColumnHeader.DefaultStyle.Locked = false;
            this.fpDetailSheet.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetailSheet.DefaultStyle.Locked = true;
            this.fpDetailSheet.DefaultStyle.Parent = "DataAreaDefault";
            this.fpDetailSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpDetailSheet.RowHeader.Columns.Get(0).Width = 37F;
            this.fpDetailSheet.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDetailSheet.RowHeader.DefaultStyle.Locked = false;
            this.fpDetailSheet.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDetailSheet.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpDetailSheet.SheetCornerStyle.Locked = false;
            this.fpDetailSheet.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpDetailSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.txtFilter);
            this.neuPanel1.Controls.Add(this.neuLabel3);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Controls.Add(this.cmbStoreDept);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(731, 53);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(74, 28);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(200, 21);
            this.txtFilter.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtFilter.TabIndex = 4;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel3.Location = new System.Drawing.Point(5, 33);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(65, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 3;
            this.neuLabel3.Text = "过滤检索：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel2.Location = new System.Drawing.Point(309, 9);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(473, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "提示：月结时将对全院所有库房进行月结；删除月结记录时将取消本次所有库房的月结。";
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(5, 10);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 1;
            this.neuLabel1.Text = "月结库房：";
            // 
            // cmbStoreDept
            // 
            this.cmbStoreDept.FormattingEnabled = true;
            this.cmbStoreDept.IsFlat = true;
            this.cmbStoreDept.IsLike = true;
            this.cmbStoreDept.Location = new System.Drawing.Point(74, 5);
            this.cmbStoreDept.Name = "cmbStoreDept";
            this.cmbStoreDept.PopForm = null;
            this.cmbStoreDept.ShowCustomerList = false;
            this.cmbStoreDept.ShowID = false;
            this.cmbStoreDept.Size = new System.Drawing.Size(200, 20);
            this.cmbStoreDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbStoreDept.TabIndex = 0;
            this.cmbStoreDept.Tag = "";
            this.cmbStoreDept.ToolBarUse = false;
            this.cmbStoreDept.SelectedIndexChanged += new System.EventHandler(this.cmbStoreDept_SelectedIndexChanged);
            // 
            // ucMonthStoreManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucMonthStoreManager";
            this.Size = new System.Drawing.Size(731, 385);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpHeadSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetailSheet)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView fpHeadSheet;
        private FarPoint.Win.Spread.SheetView fpDetailSheet;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbStoreDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtFilter;
    }
}
