namespace Neusoft.HISFC.Components.Nurse
{
    partial class ucWork
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
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.groupBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.SystemColors.Window;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.EditModePermanent = true;
            this.neuSpread1.EditModeReplace = true;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(659, 492);
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
            this.neuSpread1_Sheet1.ColumnCount = 15;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "DeptID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "排班科室";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "EMPLID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "人员姓名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "NoonID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "午别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "开始时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "结束时间";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "EmplTypeID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "人员类别";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "是否有效";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "备注";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "StopReasonID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "离岗原因";
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "ID";
            this.neuSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "DeptID";
            this.neuSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "排班科室";
            this.neuSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 94F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "EMPLID";
            this.neuSpread1_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "人员姓名";
            this.neuSpread1_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 77F;
            this.neuSpread1_Sheet1.Columns.Get(5).Label = "NoonID";
            this.neuSpread1_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(6).Label = "午别";
            this.neuSpread1_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(6).Width = 63F;
            this.neuSpread1_Sheet1.Columns.Get(7).Label = "开始时间";
            this.neuSpread1_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(7).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(8).Label = "结束时间";
            this.neuSpread1_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(8).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(9).Label = "EmplTypeID";
            this.neuSpread1_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(10).Label = "人员类别";
            this.neuSpread1_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(10).Width = 95F;
            this.neuSpread1_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(11).Label = "是否有效";
            this.neuSpread1_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(11).Width = 103F;
            this.neuSpread1_Sheet1.Columns.Get(12).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(13).Label = "StopReasonID";
            this.neuSpread1_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(14).Label = "离岗原因";
            this.neuSpread1_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(14).Width = 100F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetViewportLeftColumn(0, 10);
            this.neuSpread1.SetActiveViewport(1, 0);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 197);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.groupBox1.Location = new System.Drawing.Point(134, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 224);
            this.groupBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // ucWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.neuSpread1);
            this.Name = "ucWork";
            this.Size = new System.Drawing.Size(659, 492);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuGroupBox groupBox1;
    }
}
