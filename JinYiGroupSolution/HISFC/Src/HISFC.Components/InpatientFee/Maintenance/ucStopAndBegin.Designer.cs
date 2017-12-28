namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    partial class ucStopAndBegin
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.rbPerson = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.cmbDeptList = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.ucQueryInpatientNo1 = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.rbDept = new Neusoft.FrameWork.WinForms.Controls.NeuRadioButton();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.groupBox1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(688, 80);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.neuLabel1);
            this.groupBox1.Controls.Add(this.rbPerson);
            this.groupBox1.Controls.Add(this.cmbDeptList);
            this.groupBox1.Controls.Add(this.ucQueryInpatientNo1);
            this.groupBox1.Controls.Add(this.rbDept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(391, 52);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(35, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 4;
            this.neuLabel1.Text = "科室:";
            // 
            // rbPerson
            // 
            this.rbPerson.AutoSize = true;
            this.rbPerson.Location = new System.Drawing.Point(87, 20);
            this.rbPerson.Name = "rbPerson";
            this.rbPerson.Size = new System.Drawing.Size(59, 16);
            this.rbPerson.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbPerson.TabIndex = 0;
            this.rbPerson.TabStop = true;
            this.rbPerson.Text = "按单人";
            this.rbPerson.UseVisualStyleBackColor = true;
            this.rbPerson.CheckedChanged += new System.EventHandler(this.rbPerson_CheckedChanged);
            // 
            // cmbDeptList
            // 
            this.cmbDeptList.ArrowBackColor = System.Drawing.SystemColors.Control;
            this.cmbDeptList.FormattingEnabled = true;
            this.cmbDeptList.IsEnter2Tab = false;
            this.cmbDeptList.IsFlat = false;
            this.cmbDeptList.IsLike = true;
            this.cmbDeptList.IsListOnly = false;
            this.cmbDeptList.IsShowCustomerList = false;
            this.cmbDeptList.IsShowID = false;
            this.cmbDeptList.Location = new System.Drawing.Point(439, 49);
            this.cmbDeptList.Name = "cmbDeptList";
            this.cmbDeptList.PopForm = null;
            this.cmbDeptList.ShowCustomerList = false;
            this.cmbDeptList.ShowID = false;
            this.cmbDeptList.Size = new System.Drawing.Size(121, 20);
            this.cmbDeptList.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbDeptList.TabIndex = 3;
            this.cmbDeptList.Tag = "";
            this.cmbDeptList.ToolBarUse = false;
            this.cmbDeptList.SelectedIndexChanged += new System.EventHandler(this.neuComboBox1_SelectedIndexChanged);
            // 
            // ucQueryInpatientNo1
            // 
            this.ucQueryInpatientNo1.InputType = 0;
            this.ucQueryInpatientNo1.Location = new System.Drawing.Point(75, 45);
            this.ucQueryInpatientNo1.Name = "ucQueryInpatientNo1";
            this.ucQueryInpatientNo1.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.All;
            this.ucQueryInpatientNo1.Size = new System.Drawing.Size(198, 27);
            this.ucQueryInpatientNo1.TabIndex = 2;
            // 
            // rbDept
            // 
            this.rbDept.AutoSize = true;
            this.rbDept.Location = new System.Drawing.Point(392, 20);
            this.rbDept.Name = "rbDept";
            this.rbDept.Size = new System.Drawing.Size(59, 16);
            this.rbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.rbDept.TabIndex = 1;
            this.rbDept.TabStop = true;
            this.rbDept.Text = "按科室";
            this.rbDept.UseVisualStyleBackColor = true;
            this.rbDept.CheckedChanged += new System.EventHandler(this.rbDept_CheckedChanged);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuSpread1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(0, 80);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(688, 433);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 1;
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(688, 433);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 11;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "住院号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "住院科室";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "性别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "出生日期";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "预交金";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "住院日期";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "总金额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "余额";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "状态";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "是否封帐";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "住院号";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 113F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "姓名";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "住院科室";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 95F;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "性别";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 49F;
            this.neuSpread1_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "出生日期";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "预交金";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 78F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "住院日期";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 118F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "总金额";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 80F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "余额";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 86F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "状态";
            this.neuSpread1_Sheet1.Columns.Get(9).Width = 152F;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "是否封帐";
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 64F;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.neuSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.neuSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetViewportLeftColumn(0, 0, 3);
            this.neuSpread1.SetActiveViewport(0, 1, 0);
            // 
            // ucStopAndBegin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucStopAndBegin";
            this.Size = new System.Drawing.Size(688, 513);
            this.neuPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuRadioButton rbPerson;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDeptList;
        private Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
