namespace Neusoft.HISFC.Components.Registration
{
    partial class frmQueryPatientByName
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

        #region Windows 窗体设计器生成的代码

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
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.panel4 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.button2 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.button1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 382);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.fpSpread1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 278);
            this.panel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel4.TabIndex = 0;
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
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(544, 278);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 5;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "病历号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "患者姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "性别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "联系电话";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "地址";
            this.fpSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "病历号";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 102F;
            this.fpSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "患者姓名";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 76F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "性别";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 42F;
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "联系电话";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 102F;
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.fpSpread1_Sheet1.Columns.Get(4).Label = "地址";
            this.fpSpread1_Sheet1.Columns.Get(4).Width = 179F;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 64);
            this.panel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel3.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(424, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.button2.TabIndex = 1;
            this.button2.Text = "退出(&X)";
            this.button2.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(296, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.button1.TabIndex = 0;
            this.button1.Text = "确定(&O)";
            this.button1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 40);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 2);
            this.groupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 23);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            this.label1.Text = "患者挂号信息,通过上下键选择项目";
            // 
            // frmQueryPatientByName
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(544, 382);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryPatientByName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "患者查询";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel4;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton button1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton button2;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
    }
}