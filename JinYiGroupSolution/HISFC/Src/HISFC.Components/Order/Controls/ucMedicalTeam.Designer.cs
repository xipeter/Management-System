namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucMedicalTeam
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
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance4 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType7 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType8 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.tvDept = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTabControl1 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSplitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTabControl2 = new Neusoft.FrameWork.WinForms.Controls.NeuTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.neuSpread2 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel3.SuspendLayout();
            this.neuTabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.tvDept);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(203, 502);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // tvDept
            // 
            this.tvDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDept.HideSelection = false;
            this.tvDept.Location = new System.Drawing.Point(0, 0);
            this.tvDept.Name = "tvDept";
            this.tvDept.Size = new System.Drawing.Size(203, 502);
            this.tvDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDept.TabIndex = 0;
            this.tvDept.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDept_AfterSelect);
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(203, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(3, 502);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuTabControl1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(206, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(476, 236);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // neuTabControl1
            // 
            this.neuTabControl1.Controls.Add(this.tabPage1);
            this.neuTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl1.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl1.Name = "neuTabControl1";
            this.neuTabControl1.SelectedIndex = 0;
            this.neuTabControl1.Size = new System.Drawing.Size(476, 236);
            this.neuTabControl1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.neuSpread1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(468, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(3, 3);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(462, 205);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance3;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 5;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选择";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "医疗组编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "医疗组名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "是否有效";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "所属科室";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType5;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "选择";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 44F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType5;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "医疗组编码";
            this.neuSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 104F;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType6;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "医疗组名称";
            this.neuSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 126F;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = checkBoxCellType6;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "是否有效";
            this.neuSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = textCellType7;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "所属科室";
            this.neuSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 122F;
            this.neuSpread1_Sheet1.DataAutoCellTypes = false;
            this.neuSpread1_Sheet1.DataAutoHeadings = false;
            this.neuSpread1_Sheet1.DataAutoSizeColumns = false;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(0, 1, 0);
            // 
            // neuSplitter2
            // 
            this.neuSplitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.neuSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter2.Location = new System.Drawing.Point(206, 236);
            this.neuSplitter2.Name = "neuSplitter2";
            this.neuSplitter2.Size = new System.Drawing.Size(476, 3);
            this.neuSplitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter2.TabIndex = 3;
            this.neuSplitter2.TabStop = false;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.neuTabControl2);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel3.Location = new System.Drawing.Point(206, 239);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(476, 263);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 4;
            // 
            // neuTabControl2
            // 
            this.neuTabControl2.Controls.Add(this.tabPage2);
            this.neuTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuTabControl2.Location = new System.Drawing.Point(0, 0);
            this.neuTabControl2.Name = "neuTabControl2";
            this.neuTabControl2.SelectedIndex = 0;
            this.neuTabControl2.Size = new System.Drawing.Size(476, 263);
            this.neuTabControl2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTabControl2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.neuSpread2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(468, 238);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // neuSpread2
            // 
            this.neuSpread2.About = "3.0.2004.2005";
            this.neuSpread2.AccessibleDescription = "neuSpread2, Sheet1";
            this.neuSpread2.BackColor = System.Drawing.Color.White;
            this.neuSpread2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread2.FileName = "";
            this.neuSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread2.IsAutoSaveGridStatus = false;
            this.neuSpread2.IsCanCustomConfigColumn = false;
            this.neuSpread2.Location = new System.Drawing.Point(3, 3);
            this.neuSpread2.Name = "neuSpread2";
            this.neuSpread2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread2_Sheet1});
            this.neuSpread2.Size = new System.Drawing.Size(462, 232);
            this.neuSpread2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread2.TabIndex = 0;
            tipAppearance4.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread2.TextTipAppearance = tipAppearance4;
            this.neuSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread2_Sheet1
            // 
            this.neuSpread2_Sheet1.Reset();
            this.neuSpread2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread2_Sheet1.ColumnCount = 3;
            this.neuSpread2_Sheet1.RowCount = 0;
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选择";
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "医生姓名";
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "是否有效";
            this.neuSpread2_Sheet1.Columns.Get(0).CellType = checkBoxCellType7;
            this.neuSpread2_Sheet1.Columns.Get(0).Label = "选择";
            this.neuSpread2_Sheet1.Columns.Get(0).Width = 67F;
            this.neuSpread2_Sheet1.Columns.Get(1).CellType = textCellType8;
            this.neuSpread2_Sheet1.Columns.Get(1).Label = "医生姓名";
            this.neuSpread2_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread2_Sheet1.Columns.Get(1).Width = 137F;
            this.neuSpread2_Sheet1.Columns.Get(2).CellType = checkBoxCellType8;
            this.neuSpread2_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread2_Sheet1.Columns.Get(2).Label = "是否有效";
            this.neuSpread2_Sheet1.Columns.Get(2).Locked = true;
            this.neuSpread2_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.neuSpread2_Sheet1.Columns.Get(2).Width = 90F;
            this.neuSpread2_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread2.SetActiveViewport(0, 1, 0);
            // 
            // ucMedicalTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel3);
            this.Controls.Add(this.neuSplitter2);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucMedicalTeam";
            this.Size = new System.Drawing.Size(682, 502);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel3.ResumeLayout(false);
            this.neuTabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.HISFC.Components.Common.Controls.baseTreeView tvDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTabControl neuTabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread2;
        private FarPoint.Win.Spread.SheetView neuSpread2_Sheet1;
    }
}
