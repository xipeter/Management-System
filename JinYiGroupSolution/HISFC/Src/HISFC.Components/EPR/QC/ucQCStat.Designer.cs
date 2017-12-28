namespace Neusoft.HISFC.Components.EPR.QC
{
    partial class ucQCStat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtInpatientNo = new System.Windows.Forms.TextBox();
            this.lblInpatientNo = new System.Windows.Forms.Label();
            this.grbInDate = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.grbDept = new System.Windows.Forms.GroupBox();
            this.cmbState = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.cmbDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.lblState = new System.Windows.Forms.Label();
            this.radInpatientNo = new System.Windows.Forms.RadioButton();
            this.radInDate = new System.Windows.Forms.RadioButton();
            this.radDept = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSheetView = new FarPoint.Win.Spread.SheetView();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbInDate.SuspendLayout();
            this.grbDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSheetView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 554);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtInpatientNo);
            this.splitContainer1.Panel1.Controls.Add(this.lblInpatientNo);
            this.splitContainer1.Panel1.Controls.Add(this.grbInDate);
            this.splitContainer1.Panel1.Controls.Add(this.grbDept);
            this.splitContainer1.Panel1.Controls.Add(this.radInpatientNo);
            this.splitContainer1.Panel1.Controls.Add(this.radInDate);
            this.splitContainer1.Panel1.Controls.Add(this.radDept);
            this.splitContainer1.Panel1.Controls.Add(this.radAll);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fpSpread1);
            this.splitContainer1.Size = new System.Drawing.Size(770, 554);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtInpatientNo
            // 
            this.txtInpatientNo.Location = new System.Drawing.Point(90, 310);
            this.txtInpatientNo.Name = "txtInpatientNo";
            this.txtInpatientNo.Size = new System.Drawing.Size(121, 21);
            this.txtInpatientNo.TabIndex = 5;
            // 
            // lblInpatientNo
            // 
            this.lblInpatientNo.AutoSize = true;
            this.lblInpatientNo.Location = new System.Drawing.Point(43, 314);
            this.lblInpatientNo.Name = "lblInpatientNo";
            this.lblInpatientNo.Size = new System.Drawing.Size(41, 12);
            this.lblInpatientNo.TabIndex = 0;
            this.lblInpatientNo.Text = "住院号";
            // 
            // grbInDate
            // 
            this.grbInDate.Controls.Add(this.dtpEnd);
            this.grbInDate.Controls.Add(this.dtpBegin);
            this.grbInDate.Location = new System.Drawing.Point(43, 194);
            this.grbInDate.Name = "grbInDate";
            this.grbInDate.Size = new System.Drawing.Size(168, 79);
            this.grbInDate.TabIndex = 0;
            this.grbInDate.TabStop = false;
            this.grbInDate.Text = "入院时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(29, 52);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(133, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(29, 20);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(133, 21);
            this.dtpBegin.TabIndex = 0;
            // 
            // grbDept
            // 
            this.grbDept.Controls.Add(this.cmbState);
            this.grbDept.Controls.Add(this.cmbDept);
            this.grbDept.Controls.Add(this.lblState);
            this.grbDept.Location = new System.Drawing.Point(43, 75);
            this.grbDept.Name = "grbDept";
            this.grbDept.Size = new System.Drawing.Size(168, 94);
            this.grbDept.TabIndex = 4;
            this.grbDept.TabStop = false;
            this.grbDept.Text = "科室";
            // 
            // cmbState
            // 
            this.cmbState.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.IsEnter2Tab = false;
            this.cmbState.IsFlat = true;
            this.cmbState.IsLike = true;
            this.cmbState.Location = new System.Drawing.Point(71, 62);
            this.cmbState.Name = "cmbState";
            this.cmbState.PopForm = null;
            this.cmbState.ShowCustomerList = false;
            this.cmbState.ShowID = false;
            this.cmbState.Size = new System.Drawing.Size(91, 20);
            this.cmbState.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbState.TabIndex = 0;
            this.cmbState.Tag = "";
            this.cmbState.ToolBarUse = false;
            // 
            // cmbDept
            // 
            this.cmbDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IsEnter2Tab = false;
            this.cmbDept.IsFlat = true;
            this.cmbDept.IsLike = true;
            this.cmbDept.Location = new System.Drawing.Point(41, 20);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.PopForm = null;
            this.cmbDept.ShowCustomerList = false;
            this.cmbDept.ShowID = false;
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cmbDept.TabIndex = 6;
            this.cmbDept.Tag = "";
            this.cmbDept.ToolBarUse = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(27, 65);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(41, 12);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "状态：";
            // 
            // radInpatientNo
            // 
            this.radInpatientNo.AutoSize = true;
            this.radInpatientNo.Location = new System.Drawing.Point(23, 313);
            this.radInpatientNo.Name = "radInpatientNo";
            this.radInpatientNo.Size = new System.Drawing.Size(14, 13);
            this.radInpatientNo.TabIndex = 3;
            this.radInpatientNo.UseVisualStyleBackColor = true;
            // 
            // radInDate
            // 
            this.radInDate.AutoSize = true;
            this.radInDate.Location = new System.Drawing.Point(23, 203);
            this.radInDate.Name = "radInDate";
            this.radInDate.Size = new System.Drawing.Size(14, 13);
            this.radInDate.TabIndex = 2;
            this.radInDate.UseVisualStyleBackColor = true;
            // 
            // radDept
            // 
            this.radDept.AutoSize = true;
            this.radDept.Checked = true;
            this.radDept.Location = new System.Drawing.Point(23, 85);
            this.radDept.Name = "radDept";
            this.radDept.Size = new System.Drawing.Size(14, 13);
            this.radDept.TabIndex = 1;
            this.radDept.TabStop = true;
            this.radDept.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(23, 29);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(95, 16);
            this.radAll.TabIndex = 0;
            this.radAll.Text = "所有在院科室";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.Visible = false;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSheetView});
            this.fpSpread1.Size = new System.Drawing.Size(528, 554);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            // 
            // fpSheetView
            // 
            this.fpSheetView.Reset();
            this.fpSheetView.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSheetView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSheetView.DataAutoCellTypes = false;
            this.fpSheetView.DataAutoHeadings = false;
            this.fpSheetView.DataAutoSizeColumns = false;
            this.fpSheetView.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSheetView.RowHeader.Columns.Default.Resizable = false;
            this.fpSheetView.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSheetView.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucQCStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucQCStat";
            this.Size = new System.Drawing.Size(770, 554);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grbInDate.ResumeLayout(false);
            this.grbDept.ResumeLayout(false);
            this.grbDept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSheetView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton radInpatientNo;
        private System.Windows.Forms.RadioButton radInDate;
        private System.Windows.Forms.RadioButton radDept;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.GroupBox grbInDate;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.GroupBox grbDept;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtInpatientNo;
        private System.Windows.Forms.Label lblInpatientNo;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbState;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbDept;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSheetView;
    }
}
