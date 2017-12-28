namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucInpatientCharge_new
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpDetail = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpDetail_Sheet = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnItemTree = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuSplitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail_Sheet)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpDetail
            // 
            this.fpDetail.About = "3.0.2004.2005";
            this.fpDetail.AccessibleDescription = "fpDetail, Sheet, Row 0, Column 0, ";
            this.fpDetail.BackColor = System.Drawing.SystemColors.Control;
            this.fpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpDetail.EditModePermanent = true;
            this.fpDetail.EditModeReplace = true;
            this.fpDetail.FileName = "";
            this.fpDetail.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpDetail.IsAutoSaveGridStatus = false;
            this.fpDetail.IsCanCustomConfigColumn = false;
            this.fpDetail.Location = new System.Drawing.Point(203, 0);
            this.fpDetail.Name = "fpDetail";
            this.fpDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpDetail.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpDetail_Sheet});
            this.fpDetail.Size = new System.Drawing.Size(609, 343);
            this.fpDetail.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpDetail.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpDetail.TextTipAppearance = tipAppearance1;
            this.fpDetail.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpDetail.EditModeOn += new System.EventHandler(this.fpDetail_EditModeOn);
            this.fpDetail.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpDetail_EditChange);
            this.fpDetail.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpDetail_CellDoubleClick);
            this.fpDetail.DragDrop += new System.Windows.Forms.DragEventHandler(this.fpDetail_DragDrop);
            this.fpDetail.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpDetail_ComboSelChange);
            this.fpDetail.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpDetail_Change);
            // 
            // fpDetail_Sheet
            // 
            this.fpDetail_Sheet.Reset();
            this.fpDetail_Sheet.SheetName = "Sheet";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpDetail_Sheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpDetail_Sheet.ColumnCount = 15;
            this.fpDetail_Sheet.RowCount = 2;
            this.fpDetail_Sheet.Cells.Get(1, 6).Value = "合计:";
            this.fpDetail_Sheet.Cells.Get(1, 7).Value = 0;
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 0).Value = "住院号";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 1).Value = "姓名";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 2).Value = "项目名称";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 3).Value = "价格";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 4).Value = "数量";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 5).Value = "付数";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 6).Value = "单位";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 7).Value = "合计金额";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 8).Value = "执行科室";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 9).Value = "ItemObject";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 10).Value = "IsNew";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 11).Value = "IsDeptChange";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 12).Value = "IsDrug";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 13).Value = "组合号";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 14).Value = "上次收费日期";
            this.fpDetail_Sheet.Columns.Get(0).CellType = textCellType1;
            this.fpDetail_Sheet.Columns.Get(0).Label = "住院号";
            this.fpDetail_Sheet.Columns.Get(0).Locked = true;
            this.fpDetail_Sheet.Columns.Get(0).Width = 126F;
            this.fpDetail_Sheet.Columns.Get(1).CellType = textCellType2;
            this.fpDetail_Sheet.Columns.Get(1).Label = "姓名";
            this.fpDetail_Sheet.Columns.Get(1).Locked = true;
            this.fpDetail_Sheet.Columns.Get(1).Width = 77F;
            this.fpDetail_Sheet.Columns.Get(2).CellType = textCellType3;
            this.fpDetail_Sheet.Columns.Get(2).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(2).Label = "项目名称";
            this.fpDetail_Sheet.Columns.Get(2).Width = 280F;
            numberCellType1.DecimalPlaces = 4;
            this.fpDetail_Sheet.Columns.Get(3).CellType = numberCellType1;
            this.fpDetail_Sheet.Columns.Get(3).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(3).Label = "价格";
            this.fpDetail_Sheet.Columns.Get(3).Width = 77F;
            numberCellType2.MaximumValue = 99999.99;
            numberCellType2.MinimumValue = -9999.99;
            this.fpDetail_Sheet.Columns.Get(4).CellType = numberCellType2;
            this.fpDetail_Sheet.Columns.Get(4).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(4).Label = "数量";
            this.fpDetail_Sheet.Columns.Get(4).Width = 63F;
            this.fpDetail_Sheet.Columns.Get(5).CellType = numberCellType3;
            this.fpDetail_Sheet.Columns.Get(5).Label = "付数";
            this.fpDetail_Sheet.Columns.Get(5).Width = 33F;
            this.fpDetail_Sheet.Columns.Get(6).CellType = textCellType4;
            this.fpDetail_Sheet.Columns.Get(6).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(6).Label = "单位";
            this.fpDetail_Sheet.Columns.Get(6).Width = 50F;
            numberCellType4.ReadOnly = true;
            this.fpDetail_Sheet.Columns.Get(7).CellType = numberCellType4;
            this.fpDetail_Sheet.Columns.Get(7).Font = new System.Drawing.Font("宋体", 12F);
            this.fpDetail_Sheet.Columns.Get(7).Label = "合计金额";
            this.fpDetail_Sheet.Columns.Get(7).Locked = true;
            this.fpDetail_Sheet.Columns.Get(7).Width = 83F;
            this.fpDetail_Sheet.Columns.Get(8).CellType = textCellType5;
            this.fpDetail_Sheet.Columns.Get(8).Label = "执行科室";
            this.fpDetail_Sheet.Columns.Get(8).Width = 110F;
            this.fpDetail_Sheet.Columns.Get(9).Label = "ItemObject";
            this.fpDetail_Sheet.Columns.Get(9).Width = 87F;
            this.fpDetail_Sheet.Columns.Get(11).Label = "IsDeptChange";
            this.fpDetail_Sheet.Columns.Get(11).Width = 85F;
            this.fpDetail_Sheet.Columns.Get(13).CellType = textCellType6;
            this.fpDetail_Sheet.Columns.Get(13).Label = "组合号";
            this.fpDetail_Sheet.Columns.Get(14).CellType = textCellType7;
            this.fpDetail_Sheet.Columns.Get(14).Label = "上次收费日期";
            this.fpDetail_Sheet.Columns.Get(14).Width = 82F;
            this.fpDetail_Sheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpDetail_Sheet.RowHeader.Columns.Default.Resizable = true;
            this.fpDetail_Sheet.Rows.Get(0).Height = 23F;
            this.fpDetail_Sheet.Rows.Get(1).Height = 23F;
            this.fpDetail_Sheet.Rows.Get(1).Locked = true;
            this.fpDetail_Sheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.neuSpread1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuGroupBox1.Location = new System.Drawing.Point(203, 346);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(609, 249);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            this.neuGroupBox1.Text = "【临时】记账明细";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(3, 17);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(603, 229);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance2;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 13;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 72F;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 161F;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 62F;
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 74F;
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 75F;
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 75F;
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 67F;
            this.neuSpread1_Sheet1.Columns.Get(12).CellType = textCellType8;
            this.neuSpread1_Sheet1.Columns.Get(12).Width = 123F;
            this.neuSpread1_Sheet1.DataAutoCellTypes = false;
            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(0, 1, 0);
            // 
            // pnItemTree
            // 
            this.pnItemTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnItemTree.Location = new System.Drawing.Point(0, 0);
            this.pnItemTree.Name = "pnItemTree";
            this.pnItemTree.Size = new System.Drawing.Size(200, 595);
            this.pnItemTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnItemTree.TabIndex = 3;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(200, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 595);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 4;
            this.neuSplitter1.TabStop = false;
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuSplitter2.Location = new System.Drawing.Point(203, 343);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(609, 3);
            this.neuSplitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 5;
            this.neuSplitter2.TabStop = false;
            // 
            // ucInpatientCharge_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpDetail);
            this.Controls.Add(this.neuSplitter2);
            this.Controls.Add(this.neuGroupBox1);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.pnItemTree);
            this.Name = "ucInpatientCharge_new";
            this.Size = new System.Drawing.Size(812, 595);
            this.Load += new System.EventHandler(this.ucInpatientChargeNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail_Sheet)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpDetail;
        private FarPoint.Win.Spread.SheetView fpDetail_Sheet;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnItemTree;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter2;
    }
}
