namespace Neusoft.HISFC.Components.HealthRecord.Case
{
    partial class ucCaseTrack
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
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel3 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.tbCardID = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnOK = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.neuPanel1.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            this.neuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuPanel3);
            this.neuPanel1.Controls.Add(this.neuPanel2);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(868, 515);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.btnOK);
            this.neuPanel2.Controls.Add(this.tbCardID);
            this.neuPanel2.Controls.Add(this.neuLabel1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel2.Location = new System.Drawing.Point(0, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(868, 66);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 0;
            // 
            // neuPanel3
            // 
            this.neuPanel3.Controls.Add(this.neuSpread1);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel3.Location = new System.Drawing.Point(0, 66);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(868, 449);
            this.neuPanel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 1;
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(35, 26);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(41, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "病历号";
            // 
            // tbCardID
            // 
            this.tbCardID.Location = new System.Drawing.Point(82, 21);
            this.tbCardID.Name = "tbCardID";
            this.tbCardID.Size = new System.Drawing.Size(245, 21);
            this.tbCardID.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tbCardID.TabIndex = 1;
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(868, 449);
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
            this.neuSpread1_Sheet1.ColumnCount = 9;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "病历号";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "使用人编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "使用人名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "使用科室编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "使用科室名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "使用时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "使用类型编码";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "使用类型名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "病历号";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 110F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "使用人编码";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 75F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "使用人名称";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 75F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "使用科室编码";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "使用科室名称";
            this.neuSpread1_Sheet1.Columns.Get(5).Width = 138F;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "使用时间";
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 132F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "使用类型编码";
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "使用类型名称";
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 162F;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(357, 22);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 23);
            this.btnOK.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "查询";
            this.btnOK.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucCaseTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel1);
            this.Name = "ucCaseTrack";
            this.Size = new System.Drawing.Size(868, 515);
            this.Load += new System.EventHandler(this.ucCaseTrack_Load);
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            this.neuPanel2.PerformLayout();
            this.neuPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel3;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnOK;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox tbCardID;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
    }
}
