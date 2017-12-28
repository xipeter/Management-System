namespace Neusoft.HISFC.Components.Material.Base
{
    partial class ucApplyLists
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.btOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btCancel = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.btSelectAll = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.cmbStatus = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(264, 19);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btOK.TabIndex = 1;
            this.btOK.Text = "确认";
            this.btOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(452, 19);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.cmbStatus);
            this.neuPanel1.Controls.Add(this.neuLabel3);
            this.neuPanel1.Controls.Add(this.neuLabel2);
            this.neuPanel1.Controls.Add(this.dtpEndTime);
            this.neuPanel1.Controls.Add(this.neuLabel1);
            this.neuPanel1.Controls.Add(this.dtpBeginTime);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(607, 38);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 3;
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(76, 19);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btSelectAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btSelectAll.TabIndex = 3;
            this.btSelectAll.Text = "全选";
            this.btSelectAll.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.IsEnter2Tab = false;
            this.cmbStatus.IsFlat = true;
            this.cmbStatus.IsLike = true;
            this.cmbStatus.Location = new System.Drawing.Point(526, 10);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.PopForm = null;
            this.cmbStatus.ShowCustomerList = false;
            this.cmbStatus.ShowID = false;
            this.cmbStatus.Size = new System.Drawing.Size(72, 20);
            this.cmbStatus.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbStatus.TabIndex = 10;
            this.cmbStatus.Tag = "";
            this.cmbStatus.ToolBarUse = false;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(443, 15);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(77, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 9;
            this.neuLabel3.Text = "申请单状态：";
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(224, 15);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 8;
            this.neuLabel2.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(295, 11);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(142, 21);
            this.dtpEndTime.TabIndex = 7;
            this.dtpEndTime.Value = new System.DateTime(2008, 7, 28, 0, 0, 0, 0);
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(5, 15);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 6;
            this.neuLabel1.Text = "开始时间：";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(76, 11);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(142, 21);
            this.dtpBeginTime.TabIndex = 0;
            this.dtpBeginTime.Value = new System.DateTime(2008, 7, 21, 0, 0, 0, 0);
            this.dtpBeginTime.ValueChanged += new System.EventHandler(this.dtpBeginTime_ValueChanged);
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.btSelectAll);
            this.neuPanel2.Controls.Add(this.btOK);
            this.neuPanel2.Controls.Add(this.btCancel);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.neuPanel2.Location = new System.Drawing.Point(0, 393);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(607, 58);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 4;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 38);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(607, 355);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 5;
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
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "选择";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "B";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "选择";
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.neuSpread1_Sheet1.Columns.Get(5).CellType = textCellType4;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucApplyLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucApplyLists";
            this.Size = new System.Drawing.Size(607, 451);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuButton btOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btCancel;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbStatus;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btSelectAll;
    }
}
