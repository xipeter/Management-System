namespace Neusoft.HISFC.Components.Common.Controls
{
    partial class ucItemList
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
            this.checkBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.lbInput = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lbCount = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBottom = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(307, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "模糊查找";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.ForeColor = System.Drawing.Color.Blue;
            this.lbInput.Location = new System.Drawing.Point(23, 7);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(41, 12);
            this.lbInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbInput.TabIndex = 1;
            this.lbInput.Text = "输入法";
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            this.fpSpread1.Location = new System.Drawing.Point(0, 23);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(583, 204);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance2;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.fpSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellClick);
            this.fpSpread1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread1_KeyDown);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.RowCount = 10;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(0, 0).Value = "F1";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(1, 0).Value = "F2";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(2, 0).Value = "F3";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(3, 0).Value = "F4";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(4, 0).Value = "F5";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(5, 0).Value = "F6";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(6, 0).Value = "F7";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(7, 0).Value = "F8";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(8, 0).Value = "F9";
            this.fpSpread1_Sheet1.RowHeader.Cells.Get(9, 0).Value = "F10";
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyleName = "F";
            this.fpSpread1_Sheet1.Rows.Get(0).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(0).Label = "F1";
            this.fpSpread1_Sheet1.Rows.Get(1).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(1).Label = "F2";
            this.fpSpread1_Sheet1.Rows.Get(2).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(2).Label = "F3";
            this.fpSpread1_Sheet1.Rows.Get(3).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(3).Label = "F4";
            this.fpSpread1_Sheet1.Rows.Get(4).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(4).Label = "F5";
            this.fpSpread1_Sheet1.Rows.Get(5).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(5).Label = "F6";
            this.fpSpread1_Sheet1.Rows.Get(6).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(6).Label = "F7";
            this.fpSpread1_Sheet1.Rows.Get(7).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(7).Label = "F8";
            this.fpSpread1_Sheet1.Rows.Get(8).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(8).Label = "F9";
            this.fpSpread1_Sheet1.Rows.Get(9).Height = 18F;
            this.fpSpread1_Sheet1.Rows.Get(9).Label = "F10";
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(427, 10);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(0, 12);
            this.lbCount.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lbCount.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.lbInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 23);
            this.panel1.TabIndex = 4;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 227);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(583, 30);
            this.pnlBottom.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlBottom.TabIndex = 5;
            // 
            // ucItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbCount);
            this.Name = "ucItemList";
            this.Size = new System.Drawing.Size(583, 257);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbInput;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox checkBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel lbCount;
        private System.Windows.Forms.Panel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlBottom;
    }
}
