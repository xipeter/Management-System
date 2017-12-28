namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucInpatientCharge
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.fpDetail = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpDetail_Sheet = new FarPoint.Win.Spread.SheetView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnItemTree = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail_Sheet)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.fpDetail.Location = new System.Drawing.Point(0, 0);
            this.fpDetail.Name = "fpDetail";
            this.fpDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpDetail.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpDetail_Sheet});
            this.fpDetail.Size = new System.Drawing.Size(674, 595);
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
            this.fpDetail_Sheet.ColumnCount = 12;
            this.fpDetail_Sheet.RowCount = 2;
            this.fpDetail_Sheet.Cells.Get(1, 4).Value = "合计:";
            this.fpDetail_Sheet.Cells.Get(1, 5).Value = 0;
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 0).Value = "项目名称";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 1).Value = "价格";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 2).Value = "数量";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 3).Value = "付数";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 4).Value = "单位";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 5).Value = "合计金额";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 6).Value = "执行科室";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 7).Value = "ItemObject";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 8).Value = "IsNew";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 9).Value = "IsDeptChange";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 10).Value = "IsDrug";
            this.fpDetail_Sheet.ColumnHeader.Cells.Get(0, 11).Value = "收费比例";
            this.fpDetail_Sheet.Columns.Get(0).CellType = textCellType1;
            this.fpDetail_Sheet.Columns.Get(0).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(0).Label = "项目名称";
            this.fpDetail_Sheet.Columns.Get(0).Width = 280F;
            numberCellType1.DecimalPlaces = 4;
            this.fpDetail_Sheet.Columns.Get(1).CellType = numberCellType1;
            this.fpDetail_Sheet.Columns.Get(1).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(1).Label = "价格";
            this.fpDetail_Sheet.Columns.Get(1).Width = 77F;
            numberCellType2.MaximumValue = 99999.99;
            numberCellType2.MinimumValue = -9999.99;
            this.fpDetail_Sheet.Columns.Get(2).CellType = numberCellType2;
            this.fpDetail_Sheet.Columns.Get(2).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(2).Label = "数量";
            this.fpDetail_Sheet.Columns.Get(2).Width = 63F;
            this.fpDetail_Sheet.Columns.Get(3).CellType = numberCellType3;
            this.fpDetail_Sheet.Columns.Get(3).Label = "付数";
            this.fpDetail_Sheet.Columns.Get(3).Width = 33F;
            this.fpDetail_Sheet.Columns.Get(4).CellType = textCellType2;
            this.fpDetail_Sheet.Columns.Get(4).Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fpDetail_Sheet.Columns.Get(4).Label = "单位";
            this.fpDetail_Sheet.Columns.Get(4).Width = 50F;
            numberCellType4.ReadOnly = true;
            this.fpDetail_Sheet.Columns.Get(5).CellType = numberCellType4;
            this.fpDetail_Sheet.Columns.Get(5).Font = new System.Drawing.Font("宋体", 12F);
            this.fpDetail_Sheet.Columns.Get(5).Label = "合计金额";
            this.fpDetail_Sheet.Columns.Get(5).Locked = true;
            this.fpDetail_Sheet.Columns.Get(5).Width = 83F;
            this.fpDetail_Sheet.Columns.Get(6).CellType = textCellType3;
            this.fpDetail_Sheet.Columns.Get(6).Label = "执行科室";
            this.fpDetail_Sheet.Columns.Get(6).Width = 110F;
            this.fpDetail_Sheet.Columns.Get(7).Label = "ItemObject";
            this.fpDetail_Sheet.Columns.Get(7).Width = 87F;
            this.fpDetail_Sheet.Columns.Get(9).Label = "IsDeptChange";
            this.fpDetail_Sheet.Columns.Get(9).Width = 85F;
            numberCellType5.MaximumValue = 1;
            numberCellType5.MinimumValue = 0;
            this.fpDetail_Sheet.Columns.Get(11).CellType = numberCellType5;
            this.fpDetail_Sheet.Columns.Get(11).Label = "收费比例";
            this.fpDetail_Sheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpDetail_Sheet.RowHeader.Columns.Default.Resizable = false;
            this.fpDetail_Sheet.Rows.Get(0).Height = 23F;
            this.fpDetail_Sheet.Rows.Get(1).Height = 23F;
            this.fpDetail_Sheet.Rows.Get(1).Locked = true;
            this.fpDetail_Sheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnItemTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fpDetail);
            this.splitContainer1.Size = new System.Drawing.Size(913, 595);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 1;
            // 
            // pnItemTree
            // 
            this.pnItemTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnItemTree.Location = new System.Drawing.Point(0, 0);
            this.pnItemTree.Name = "pnItemTree";
            this.pnItemTree.Size = new System.Drawing.Size(235, 595);
            this.pnItemTree.TabIndex = 0;
            // 
            // ucInpatientCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucInpatientCharge";
            this.Size = new System.Drawing.Size(913, 595);
            this.Load += new System.EventHandler(this.ucInpatientCharge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDetail_Sheet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpDetail;
        private FarPoint.Win.Spread.SheetView fpDetail_Sheet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnItemTree;
    }
}
