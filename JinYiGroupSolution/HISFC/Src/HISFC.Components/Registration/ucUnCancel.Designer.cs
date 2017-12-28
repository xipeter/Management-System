namespace Neusoft.HISFC.Components.Registration
{
    partial class ucUnCancel
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUnCancel));
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter2 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.panel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.txtRecipeNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.txtCardNo = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.label2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 516);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.fpSpread1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(710, 476);
            this.panel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel3.TabIndex = 6;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(710, 476);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance2;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 8;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "性别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "挂号日期";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "挂号科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "挂号级别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "看诊医生";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "挂号费";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "诊金";
            textCellType8.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(0).CellType = textCellType8;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "姓名";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 79F;
            textCellType9.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(1).CellType = textCellType9;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "性别";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 45F;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.DateDefault = new System.DateTime(2007, 3, 13, 11, 26, 25, 296);
            dateTimeCellType2.TimeDefault = new System.DateTime(2007, 3, 13, 11, 26, 25, 296);
            this.fpSpread1_Sheet1.Columns.Get(2).CellType = dateTimeCellType2;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "挂号日期";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 152F;
            textCellType10.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = textCellType10;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "挂号科室";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 82F;
            textCellType11.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = textCellType11;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "挂号级别";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 74F;
            textCellType12.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = textCellType12;
            this.fpSpread1_Sheet1.Columns.Get(5).Label = "看诊医生";
            this.fpSpread1_Sheet1.Columns.Get(5).Width = 92F;
            textCellType13.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(6).CellType = textCellType13;
            this.fpSpread1_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpSpread1_Sheet1.Columns.Get(6).Label = "挂号费";
            this.fpSpread1_Sheet1.Columns.Get(6).Width = 67F;
            textCellType14.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns.Get(7).CellType = textCellType14;
            this.fpSpread1_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpSpread1_Sheet1.Columns.Get(7).Label = "诊金";
            this.fpSpread1_Sheet1.Columns.Get(7).Width = 71F;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 37);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(710, 3);
            this.splitter2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtRecipeNo);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.txtCardNo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(710, 37);
            this.panel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel4.TabIndex = 4;
            // 
            // txtRecipeNo
            // 
            this.txtRecipeNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRecipeNo.Location = new System.Drawing.Point(266, 8);
            this.txtRecipeNo.Name = "txtRecipeNo";
            this.txtRecipeNo.Size = new System.Drawing.Size(100, 21);
            this.txtRecipeNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtRecipeNo.TabIndex = 0;
            this.txtRecipeNo.TextChanged += new System.EventHandler(this.txtRecipeNo_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(210, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label3.TabIndex = 3;
            this.label3.Text = "处方号";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 2);
            this.groupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtCardNo
            // 
            this.txtCardNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCardNo.Location = new System.Drawing.Point(81, 8);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(100, 21);
            this.txtCardNo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtCardNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 4;
            this.label1.Text = "病历号";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(710, 37);
            this.label2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label2.TabIndex = 2;
            // 
            // ucUnCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.panel1);
            this.Name = "ucUnCancel";
            this.Size = new System.Drawing.Size(710, 516);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtCardNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter splitter2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtRecipeNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label3;        
    }
}
