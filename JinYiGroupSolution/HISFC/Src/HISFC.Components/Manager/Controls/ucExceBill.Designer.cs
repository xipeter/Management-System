namespace Neusoft.HISFC.Components.Manager
{
    partial class ucExceBill
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
            FarPoint.Win.Spread.TipAppearance tipAppearance5 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance6 = new FarPoint.Win.Spread.TipAppearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.comboBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpDept = new FarPoint.Win.Spread.SheetView();
            this.neuGroupBox2 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.checkAll = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.neuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDept)).BeginInit();
            this.neuGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fpSpread1);
            this.splitContainer1.Panel1.Controls.Add(this.neuGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuSpread1);
            this.splitContainer1.Panel2.Controls.Add(this.neuGroupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(756, 536);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 0;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 50);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(252, 486);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance5.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance5;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 2;
            this.fpSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.SystemColors.AppWorkspace, System.Drawing.Color.White, System.Drawing.Color.Black, System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(223)))), ((int)(((byte)(222))))), FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107))))), System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(93)))), ((int)(((byte)(90))))), System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(222))))), System.Drawing.Color.White, true, true, true, true, true);
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "编码";
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "名称";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 136F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "编码";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 113F;
            this.fpSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 40F;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuGroupBox1
            // 
            this.neuGroupBox1.Controls.Add(this.comboBox1);
            this.neuGroupBox1.Controls.Add(this.neuLabel1);
            this.neuGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox1.Name = "neuGroupBox1";
            this.neuGroupBox1.Size = new System.Drawing.Size(252, 50);
            this.neuGroupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox1.TabIndex = 1;
            this.neuGroupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.ArrowBackColor = System.Drawing.Color.Silver;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IsFlat = true;
            this.comboBox1.IsLike = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.PopForm = null;
            this.comboBox1.ShowCustomerList = false;
            this.comboBox1.ShowID = false;
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "";
            this.comboBox1.ToolBarUse = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.ForeColor = System.Drawing.Color.Blue;
            this.neuLabel1.Location = new System.Drawing.Point(16, 23);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(59, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "源 病  区";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 50);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpDept});
            this.neuSpread1.Size = new System.Drawing.Size(500, 486);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance6.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance6;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpDept
            // 
            this.fpDept.Reset();
            this.fpDept.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpDept.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpDept.ColumnCount = 4;
            this.fpDept.RowCount = 0;
            this.fpDept.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic2;
            this.fpDept.ColumnHeader.Cells.Get(0, 0).Value = "选中";
            this.fpDept.ColumnHeader.Cells.Get(0, 1).Value = "护理站";
            this.fpDept.ColumnHeader.Cells.Get(0, 2).Value = "编码";
            this.fpDept.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpDept.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpDept.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpDept.ColumnHeader.DefaultStyle.Locked = false;
            this.fpDept.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDept.Columns.Get(0).Label = "选中";
            this.fpDept.Columns.Get(0).Width = 89F;
            this.fpDept.Columns.Get(1).Label = "护理站";
            this.fpDept.Columns.Get(1).Width = 225F;
            this.fpDept.Columns.Get(2).Label = "编码";
            this.fpDept.Columns.Get(2).Width = 137F;
            this.fpDept.Columns.Get(3).Width = 84F;
            this.fpDept.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpDept.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpDept.DefaultStyle.Locked = false;
            this.fpDept.DefaultStyle.Parent = "DataAreaDefault";
            this.fpDept.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpDept.RowHeader.Columns.Default.Resizable = false;
            this.fpDept.RowHeader.Columns.Get(0).Width = 37F;
            this.fpDept.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpDept.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpDept.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpDept.RowHeader.DefaultStyle.Locked = false;
            this.fpDept.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpDept.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpDept.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpDept.SheetCornerStyle.Locked = false;
            this.fpDept.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpDept.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // neuGroupBox2
            // 
            this.neuGroupBox2.Controls.Add(this.checkAll);
            this.neuGroupBox2.Controls.Add(this.neuLabel2);
            this.neuGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuGroupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.neuGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.neuGroupBox2.Name = "neuGroupBox2";
            this.neuGroupBox2.Size = new System.Drawing.Size(500, 50);
            this.neuGroupBox2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuGroupBox2.TabIndex = 0;
            this.neuGroupBox2.TabStop = false;
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkAll.Location = new System.Drawing.Point(120, 18);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(48, 16);
            this.checkAll.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.checkAll.TabIndex = 1;
            this.checkAll.Text = "全选";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(26, 20);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(77, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 0;
            this.neuLabel2.Text = "目 标 病  区";
            // 
            // ucExceBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucExceBill";
            this.Size = new System.Drawing.Size(756, 536);
            this.Load += new System.EventHandler(this.frmExecBill_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.neuGroupBox1.ResumeLayout(false);
            this.neuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpDept)).EndInit();
            this.neuGroupBox2.ResumeLayout(false);
            this.neuGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comboBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox neuGroupBox2;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox checkAll;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView fpDept;
    }
}
