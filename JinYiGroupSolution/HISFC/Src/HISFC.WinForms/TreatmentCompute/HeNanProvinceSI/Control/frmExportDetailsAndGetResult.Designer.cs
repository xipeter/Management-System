namespace HeNanProvinceSI.Control
{
    partial class frmExportDetailsAndGetResult
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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbOperations = new System.Windows.Forms.GroupBox();
            this.btnGetResult = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.btnUpload = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.grbPatientInfo = new System.Windows.Forms.GroupBox();
            this.ucQueryInpatientNo = new Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo();
            this.lblPatientInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.neuSpread1_Sheet3 = new FarPoint.Win.Spread.SheetView();
            this.btnQuery = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbOperations.SuspendLayout();
            this.grbPatientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbOperations);
            this.splitContainer1.Panel1.Controls.Add(this.grbPatientInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.neuSpread1);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 547);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 0;
            // 
            // grbOperations
            // 
            this.grbOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOperations.Controls.Add(this.btnQuery);
            this.grbOperations.Controls.Add(this.btnGetResult);
            this.grbOperations.Controls.Add(this.btnUpload);
            this.grbOperations.Location = new System.Drawing.Point(665, 12);
            this.grbOperations.Name = "grbOperations";
            this.grbOperations.Size = new System.Drawing.Size(331, 69);
            this.grbOperations.TabIndex = 5;
            this.grbOperations.TabStop = false;
            this.grbOperations.Text = "功能操作";
            // 
            // btnGetResult
            // 
            this.btnGetResult.Location = new System.Drawing.Point(174, 24);
            this.btnGetResult.Name = "btnGetResult";
            this.btnGetResult.Size = new System.Drawing.Size(75, 23);
            this.btnGetResult.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnGetResult.TabIndex = 1;
            this.btnGetResult.Text = "获取结果";
            this.btnGetResult.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnGetResult.UseVisualStyleBackColor = true;
            this.btnGetResult.Click += new System.EventHandler(this.btnGetResult_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(93, 24);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "上传明细";
            this.btnUpload.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // grbPatientInfo
            // 
            this.grbPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grbPatientInfo.Controls.Add(this.ucQueryInpatientNo);
            this.grbPatientInfo.Controls.Add(this.lblPatientInfo);
            this.grbPatientInfo.Location = new System.Drawing.Point(12, 12);
            this.grbPatientInfo.Name = "grbPatientInfo";
            this.grbPatientInfo.Size = new System.Drawing.Size(647, 69);
            this.grbPatientInfo.TabIndex = 4;
            this.grbPatientInfo.TabStop = false;
            this.grbPatientInfo.Text = "患者信息";
            // 
            // ucQueryInpatientNo
            // 
            this.ucQueryInpatientNo.InputType = 0;
            this.ucQueryInpatientNo.Location = new System.Drawing.Point(16, 20);
            this.ucQueryInpatientNo.Name = "ucQueryInpatientNo";
            this.ucQueryInpatientNo.ShowState = Neusoft.HISFC.Components.Common.Controls.enuShowState.InhosBeforBalanced;
            this.ucQueryInpatientNo.Size = new System.Drawing.Size(197, 27);
            this.ucQueryInpatientNo.TabIndex = 2;
            this.ucQueryInpatientNo.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(this.ucQueryInpatientNo_myEvent);
            // 
            // lblPatientInfo
            // 
            this.lblPatientInfo.AutoEllipsis = true;
            this.lblPatientInfo.Location = new System.Drawing.Point(231, 29);
            this.lblPatientInfo.Name = "lblPatientInfo";
            this.lblPatientInfo.Size = new System.Drawing.Size(410, 37);
            this.lblPatientInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblPatientInfo.TabIndex = 3;
            this.lblPatientInfo.Text = "患者信息：";
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, 使用说明, Row 0, Column 0, 说  明";
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
            this.neuSpread1_Sheet1,
            this.neuSpread1_Sheet2,
            this.neuSpread1_Sheet3});
            this.neuSpread1.Size = new System.Drawing.Size(1008, 459);
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
            this.neuSpread1_Sheet1.SheetName = "使用说明";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 12;
            this.neuSpread1_Sheet1.RowCount = 12;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.White, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, false, false);
            this.neuSpread1_Sheet1.Cells.Get(0, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(0, 0).Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.neuSpread1_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Cells.Get(0, 0).Value = "说  明";
            this.neuSpread1_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Cells.Get(1, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(1, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(1, 0).Value = "1、本界面用作上传患者明细费用到省保，在患者确定出院后结算前使用。";
            this.neuSpread1_Sheet1.Cells.Get(2, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(2, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(2, 0).Value = "2、省保患者出院流程：护士站出院登记-->用本界面上传患者费用明细-->费用正常-->用省保程序做结算-->到HIS";
            this.neuSpread1_Sheet1.Cells.Get(3, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(3, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(3, 0).Value = "   出院结算界面做出院结算。";
            this.neuSpread1_Sheet1.Cells.Get(4, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(4, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(4, 0).Value = "3、操作：输入患者住院号-->回车-->自动检索患者在院期间费用明细-->点 上传明细按钮-->等待上传完毕-->点";
            this.neuSpread1_Sheet1.Cells.Get(5, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(5, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(5, 0).Value = "   查看结果按钮查看省医保结算信息。";
            this.neuSpread1_Sheet1.Cells.Get(6, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(6, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(7, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(7, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(8, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(8, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(8, 0).Value = "注意事项：";
            this.neuSpread1_Sheet1.Cells.Get(9, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(9, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(9, 0).Value = "1、上传明细每个患者仅能传一次，在结算前传。";
            this.neuSpread1_Sheet1.Cells.Get(10, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(10, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.Cells.Get(11, 0).ColumnSpan = 12;
            this.neuSpread1_Sheet1.Cells.Get(11, 0).Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.Rows.Get(0).Height = 48F;
            this.neuSpread1_Sheet1.Rows.Get(1).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(2).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(3).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(4).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(5).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(6).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(7).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(8).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(9).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(10).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows.Get(11).Height = 25F;
            this.neuSpread1_Sheet1.Rows.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Rows.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSpread1_Sheet2
            // 
            this.neuSpread1_Sheet2.Reset();
            this.neuSpread1_Sheet2.SheetName = "费用明细";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet2.GrayAreaBackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet2.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuSpread1_Sheet3
            // 
            this.neuSpread1_Sheet3.Reset();
            this.neuSpread1_Sheet3.SheetName = "报销结果";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet3.GrayAreaBackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet3.RowHeader.Columns.Default.Resizable = true;
            this.neuSpread1_Sheet3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(12, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询明细";
            this.btnQuery.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // frmExportDetailsAndGetResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 547);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmExportDetailsAndGetResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "省保费用上传";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grbOperations.ResumeLayout(false);
            this.grbPatientInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        protected Neusoft.HISFC.Components.Common.Controls.ucQueryInpatientNo ucQueryInpatientNo;
        private System.Windows.Forms.GroupBox grbOperations;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnUpload;
        private System.Windows.Forms.GroupBox grbPatientInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblPatientInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnGetResult;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet2;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet3;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnQuery;
    }
}