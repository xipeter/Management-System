namespace Neusoft.HISFC.Components.Order.Controls
{
    partial class ucOrderShow
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
            this.neuLabel1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.cmbOderStatus = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel2 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.txtQuery = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fpSpread1_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.lblInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReOrderQueryed = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuLabel1
            // 
            this.neuLabel1.AutoSize = true;
            this.neuLabel1.Location = new System.Drawing.Point(5, 17);
            this.neuLabel1.Name = "neuLabel1";
            this.neuLabel1.Size = new System.Drawing.Size(65, 12);
            this.neuLabel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel1.TabIndex = 0;
            this.neuLabel1.Text = "医嘱状态：";
            // 
            // cmbOderStatus
            // 
            this.cmbOderStatus.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbOderStatus.FormattingEnabled = true;
            this.cmbOderStatus.IsEnter2Tab = false;
            this.cmbOderStatus.IsFlat = true;
            this.cmbOderStatus.IsLike = true;
            this.cmbOderStatus.Items.AddRange(new object[] {
            "全部医嘱",
            "有效医嘱",
            "当天医嘱",
            "待审核医嘱",
            "当天作废医嘱",
            "全部作废医嘱",
            "皮试医嘱"});
            this.cmbOderStatus.Location = new System.Drawing.Point(74, 14);
            this.cmbOderStatus.Name = "cmbOderStatus";
            this.cmbOderStatus.PopForm = null;
            this.cmbOderStatus.ShowCustomerList = false;
            this.cmbOderStatus.ShowID = false;
            this.cmbOderStatus.Size = new System.Drawing.Size(108, 20);
            this.cmbOderStatus.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbOderStatus.TabIndex = 1;
            this.cmbOderStatus.Tag = "";
            this.cmbOderStatus.ToolBarUse = false;
            // 
            // neuLabel2
            // 
            this.neuLabel2.AutoSize = true;
            this.neuLabel2.Location = new System.Drawing.Point(294, 17);
            this.neuLabel2.Name = "neuLabel2";
            this.neuLabel2.Size = new System.Drawing.Size(65, 12);
            this.neuLabel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel2.TabIndex = 2;
            this.neuLabel2.Text = "查找医嘱：";
            // 
            // txtQuery
            // 
            this.txtQuery.ArrowBackColor = System.Drawing.Color.Silver;
            this.txtQuery.FormattingEnabled = true;
            this.txtQuery.IsEnter2Tab = false;
            this.txtQuery.IsFlat = true;
            this.txtQuery.IsLike = true;
            this.txtQuery.Location = new System.Drawing.Point(359, 14);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.PopForm = null;
            this.txtQuery.ShowCustomerList = false;
            this.txtQuery.ShowID = false;
            this.txtQuery.Size = new System.Drawing.Size(112, 20);
            this.txtQuery.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtQuery.TabIndex = 3;
            this.txtQuery.Tag = "";
            this.txtQuery.ToolBarUse = false;
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, 临时医嘱(F12切换), Row 0, Column 0, ";
            this.fpSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.ContextMenuStrip = this.contextMenuStrip1;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(2, 45);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1,
            this.fpSpread1_Sheet2});
            this.fpSpread1.Size = new System.Drawing.Size(625, 301);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 4;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(this.fpSpread1_ColumnWidthChanged);
            this.fpSpread1.ActiveSheetIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "长期医嘱(F12切换)";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.RowHeader.Visible = false;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpSpread1_Sheet2
            // 
            this.fpSpread1_Sheet2.Reset();
            this.fpSpread1_Sheet2.SheetName = "临时医嘱(F12切换)";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet2.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet2.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet2.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet2.RowHeader.Visible = false;
            this.fpSpread1_Sheet2.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet2.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetViewportTopRow(1, 0, 105);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(474, 17);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(53, 12);
            this.lblInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "患者信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReOrderQueryed);
            this.groupBox1.Controls.Add(this.neuLabel1);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.cmbOderStatus);
            this.groupBox1.Controls.Add(this.neuLabel2);
            this.groupBox1.Controls.Add(this.txtQuery);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 41);
            this.groupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fpSpread1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 351);
            this.panel1.TabIndex = 7;
            // 
            // btnReOrderQueryed
            // 
            this.btnReOrderQueryed.Location = new System.Drawing.Point(188, 12);
            this.btnReOrderQueryed.Name = "btnReOrderQueryed";
            this.btnReOrderQueryed.Size = new System.Drawing.Size(100, 23);
            this.btnReOrderQueryed.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnReOrderQueryed.TabIndex = 6;
            this.btnReOrderQueryed.Text = "查询已重整医嘱";
            this.btnReOrderQueryed.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.btnReOrderQueryed.UseVisualStyleBackColor = true;
            this.btnReOrderQueryed.Click += new System.EventHandler(this.btnReOrderQueryed_Click);
            // 
            // ucOrderShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Name = "ucOrderShow";
            this.Size = new System.Drawing.Size(631, 351);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbOderStatus;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox txtQuery;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lblInfo;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet2;
        private System.Windows.Forms.Panel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton btnReOrderQueryed;
    }
}
