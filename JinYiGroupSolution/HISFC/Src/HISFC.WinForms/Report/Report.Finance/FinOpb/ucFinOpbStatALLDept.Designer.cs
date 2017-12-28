namespace Neusoft.WinForms.Report.Finance.FinOpb
{
    partial class ucFinOpbStatALLDept
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbReportCode = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel3 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.comDept = new Neusoft.FrameWork.WinForms.Controls.NeuComboBox(this.components);
            this.neuLabel4 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.plLeft.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plQueryCondition.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plTop.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.plRightTop.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            this.gbMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // plLeft
            // 
            this.plLeft.Visible = false;
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.comDept);
            this.plTop.Controls.Add(this.neuLabel4);
            this.plTop.Controls.Add(this.cmbReportCode);
            this.plTop.Controls.Add(this.neuLabel3);
            this.plTop.Controls.SetChildIndex(this.neuLabel3, 0);
            this.plTop.Controls.SetChildIndex(this.cmbReportCode, 0);
            this.plTop.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel1, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel2, 0);
            this.plTop.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.plTop.Controls.SetChildIndex(this.neuLabel4, 0);
            this.plTop.Controls.SetChildIndex(this.comDept, 0);
            // 
            // plRightBottom
            // 
            this.plRightBottom.Visible = false;
            // 
            // neuSpread1
            // 
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, 科室收费汇总查询";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread2.ActiveSheetIndex = -1;
            // 
            // cmbReportCode
            // 
            this.cmbReportCode.ArrowBackColor = System.Drawing.Color.Silver;
            this.cmbReportCode.FormattingEnabled = true;
            this.cmbReportCode.IsEnter2Tab = false;
            this.cmbReportCode.IsFlat = false;
            this.cmbReportCode.IsLike = true;
            this.cmbReportCode.IsListOnly = false;
            this.cmbReportCode.IsShowCustomerList = false;
            this.cmbReportCode.IsShowID = false;
            this.cmbReportCode.Location = new System.Drawing.Point(513, 10);
            this.cmbReportCode.Name = "cmbReportCode";
            this.cmbReportCode.PopForm = null;
            this.cmbReportCode.ShowCustomerList = false;
            this.cmbReportCode.ShowID = false;
            this.cmbReportCode.Size = new System.Drawing.Size(100, 20);
            this.cmbReportCode.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.cmbReportCode.TabIndex = 14;
            this.cmbReportCode.Tag = "";
            this.cmbReportCode.ToolBarUse = false;
            this.cmbReportCode.SelectedIndexChanged += new System.EventHandler(this.cmbReportCode_SelectecIndex);
            // 
            // neuLabel3
            // 
            this.neuLabel3.AutoSize = true;
            this.neuLabel3.Location = new System.Drawing.Point(454, 14);
            this.neuLabel3.Name = "neuLabel3";
            this.neuLabel3.Size = new System.Drawing.Size(59, 12);
            this.neuLabel3.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel3.TabIndex = 13;
            this.neuLabel3.Text = "统计分类:";
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.SystemColors.Control, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Transparent, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, false, false);
            this.neuSpread1_Sheet1.Cells.Get(0, 0).ColumnSpan = 10;
            this.neuSpread1_Sheet1.Cells.Get(0, 0).Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.neuSpread1_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Cells.Get(0, 0).Value = "科室收费汇总查询";
            this.neuSpread1_Sheet1.Cells.Get(1, 0).ColumnSpan = 3;
            this.neuSpread1_Sheet1.Cells.Get(1, 0).Value = "统计科室：";
            this.neuSpread1_Sheet1.Cells.Get(1, 4).ColumnSpan = 6;
            this.neuSpread1_Sheet1.Cells.Get(1, 4).Locked = false;
            this.neuSpread1_Sheet1.Cells.Get(1, 4).Tag = "";
            this.neuSpread1_Sheet1.Cells.Get(2, 0).ColumnSpan = 5;
            this.neuSpread1_Sheet1.Cells.Get(2, 0).Note = "时间范围：{0}-{1}";
            this.neuSpread1_Sheet1.Cells.Get(2, 0).Tag = "{QueryParams}";
            this.neuSpread1_Sheet1.Cells.Get(2, 0).Value = "时间范围：";
            this.neuSpread1_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 158F;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.Rows.Get(0).Height = 54F;
            this.neuSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // comDept
            // 
            this.comDept.ArrowBackColor = System.Drawing.Color.Silver;
            this.comDept.FormattingEnabled = true;
            this.comDept.IsEnter2Tab = false;
            this.comDept.IsFlat = false;
            this.comDept.IsLike = true;
            this.comDept.IsListOnly = false;
            this.comDept.IsShowCustomerList = false;
            this.comDept.IsShowID = false;
            this.comDept.Location = new System.Drawing.Point(687, 10);
            this.comDept.Name = "comDept";
            this.comDept.PopForm = null;
            this.comDept.ShowCustomerList = false;
            this.comDept.ShowID = false;
            this.comDept.Size = new System.Drawing.Size(146, 20);
            this.comDept.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Flat;
            this.comDept.TabIndex = 16;
            this.comDept.Tag = "";
            this.comDept.ToolBarUse = false;
            // 
            // neuLabel4
            // 
            this.neuLabel4.AutoSize = true;
            this.neuLabel4.Location = new System.Drawing.Point(628, 14);
            this.neuLabel4.Name = "neuLabel4";
            this.neuLabel4.Size = new System.Drawing.Size(59, 12);
            this.neuLabel4.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuLabel4.TabIndex = 15;
            this.neuLabel4.Text = "查询条件:";
            // 
            // ucFinOpbStatALLDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DataBeginRowIndex = 3;
            this.Name = "ucFinOpbStatALLDept";
            this.SvMain = this.neuSpread1_Sheet1;
            this.UseParamCellsCount = 1;
            this.plLeft.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plQueryCondition.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plRightTop.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.gbMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox cmbReportCode;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel3;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox comDept;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel neuLabel4;
    }
}