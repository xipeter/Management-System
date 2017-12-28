namespace Neusoft.HISFC.Components.Privilege
{
    partial class SelectItemForm<T>
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
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtInput = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.nButton1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.nButton2 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.chbSelect = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ContentPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.fpSpread1);
            this.ContentPanel.Location = new System.Drawing.Point(0, 38);
            this.ContentPanel.Size = new System.Drawing.Size(438, 214);
            this.ContentPanel.TabIndex = 1;
            this.ContentPanel.Controls.SetChildIndex(this.fpSpread1, 0);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.chbSelect);
            this.TitlePanel.Controls.Add(this.label1);
            this.TitlePanel.Controls.Add(this.txtInput);
            this.TitlePanel.Size = new System.Drawing.Size(438, 38);
            this.TitlePanel.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.nButton2);
            this.BottomPanel.Controls.Add(this.nButton1);
            this.BottomPanel.Location = new System.Drawing.Point(0, 252);
            this.BottomPanel.Size = new System.Drawing.Size(438, 48);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 300);
            this.statusBar1.Size = new System.Drawing.Size(438, 24);
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(438, 213);
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
            this.fpSpread1_Sheet1.ColumnCount = 4;
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.AllowNoteEdit = false;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "代码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "助记码";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "备注";
            this.fpSpread1_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "代码";
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "名称";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 128F;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "备注";
            this.fpSpread1_Sheet1.Columns.Get(3).Width = 143F;
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.fpSpread1.SetActiveViewport(0, 1, 0);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.IsEnter2Tab = false;
            this.txtInput.Location = new System.Drawing.Point(78, 11);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(208, 21);
            this.txtInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInput.TabIndex = 0;
            // 
            // nButton1
            // 
            this.nButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nButton1.Location = new System.Drawing.Point(228, 6);
            this.nButton1.Name = "nButton1";
            this.nButton1.Size = new System.Drawing.Size(75, 23);
            this.nButton1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nButton1.TabIndex = 0;
            this.nButton1.Text = "确定(&O)";
            this.nButton1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.OK;
            this.nButton1.UseVisualStyleBackColor = true;
            // 
            // nButton2
            // 
            this.nButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.nButton2.Location = new System.Drawing.Point(324, 6);
            this.nButton2.Name = "nButton2";
            this.nButton2.Size = new System.Drawing.Size(75, 23);
            this.nButton2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.nButton2.TabIndex = 1;
            this.nButton2.Text = "取消(&C)";
            this.nButton2.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.Cancel;
            this.nButton2.UseVisualStyleBackColor = true;
            // 
            // chbSelect
            // 
            this.chbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSelect.AutoSize = true;
            this.chbSelect.Checked = true;
            this.chbSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSelect.Location = new System.Drawing.Point(327, 12);
            this.chbSelect.Name = "chbSelect";
            this.chbSelect.Size = new System.Drawing.Size(72, 16);
            this.chbSelect.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chbSelect.TabIndex = 2;
            this.chbSelect.Text = "模糊查询";
            this.chbSelect.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "检索码";
            // 
            // SelectItemForm
            // 
            this.AcceptButton = this.nButton1;
            this.CancelButton = this.nButton2;
            this.ClientSize = new System.Drawing.Size(438, 324);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectItemForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "项目选择";
            this.ContentPanel.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private FrameWork.WinForms.Controls.NeuTextBox txtInput;
        private FrameWork.WinForms.Controls.NeuButton nButton2;
        private FrameWork.WinForms.Controls.NeuButton nButton1;
        private FrameWork.WinForms.Controls.NeuCheckBox chbSelect;
        private System.Windows.Forms.Label label1;
    }
}
