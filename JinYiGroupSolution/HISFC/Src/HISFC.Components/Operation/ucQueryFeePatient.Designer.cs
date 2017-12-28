namespace Neusoft.HISFC.Components.Operation
{
    partial class ucQueryFeePatient
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
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
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
            this.fpSpread1.Size = new System.Drawing.Size(753, 563);
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
            this.fpSpread1_Sheet1.ColumnCount = 11;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "住院号";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "患者姓名";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "性别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "年龄";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "住院科室";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "患者类别";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "入院时间";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "在院状态";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "花费(未结)";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "余额(未结)";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "计费状态";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "住院号";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 85F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "患者姓名";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 88F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "性别";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 44F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "年龄";
            this.fpSpread1_Sheet1.Columns.Get(3).Locked = false;
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 37F;
            this.fpSpread1_Sheet1.Columns.Get(8).Label = "花费(未结)";
            this.fpSpread1_Sheet1.Columns.Get(8).Width = 75F;
            this.fpSpread1_Sheet1.Columns.Get(9).Label = "余额(未结)";
            this.fpSpread1_Sheet1.Columns.Get(9).Width = 69F;
            this.fpSpread1_Sheet1.Columns.Get(10).Label = "计费状态";
            this.fpSpread1_Sheet1.Columns.Get(10).Width = 68F;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(1, 0);
            // 
            // ucQueryFeePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpSpread1);
            this.Name = "ucQueryFeePatient";
            this.Size = new System.Drawing.Size(753, 563);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
    }
}
