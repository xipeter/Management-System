namespace Neusoft.HISFC.Components.Common.Maintenance
{
    partial class ucDeptDiagMaintenance
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.pnlTree = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSplitter1 = new Neusoft.FrameWork.WinForms.Controls.NeuSplitter();
            this.neuPanel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuFpEnter1 = new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.txtInput = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.ucDiagnose1 = new Neusoft.HISFC.Components.Common.Controls.ucDiagnose();
            this.neuFpEnter1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).BeginInit();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTree
            // 
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTree.Location = new System.Drawing.Point(0, 0);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(134, 386);
            this.pnlTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.pnlTree.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Location = new System.Drawing.Point(134, 0);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(1, 386);
            this.neuSplitter1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 1;
            this.neuSplitter1.TabStop = false;
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.ucDiagnose1);
            this.neuPanel2.Controls.Add(this.neuFpEnter1);
            this.neuPanel2.Controls.Add(this.neuPanel1);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(135, 0);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(462, 386);
            this.neuPanel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 2;
            // 
            // neuFpEnter1
            // 
            this.neuFpEnter1.About = "2.5.2007.2005";
            this.neuFpEnter1.AccessibleDescription = "neuFpEnter1";
            this.neuFpEnter1.BackColor = System.Drawing.SystemColors.Control;
            this.neuFpEnter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuFpEnter1.EditModePermanent = true;
            this.neuFpEnter1.EditModeReplace = true;
            this.neuFpEnter1.Location = new System.Drawing.Point(0, 45);
            this.neuFpEnter1.Name = "neuFpEnter1";
            this.neuFpEnter1.SelectNone = false;
            this.neuFpEnter1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuFpEnter1_Sheet1});
            this.neuFpEnter1.ShowListWhenOfFocus = false;
            this.neuFpEnter1.Size = new System.Drawing.Size(462, 341);
            this.neuFpEnter1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuFpEnter1.TextTipAppearance = tipAppearance1;
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.txtInput);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(462, 45);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 0;
            // 
            // txtInput
            // 
            this.txtInput.IsEnter2Tab = false;
            this.txtInput.Location = new System.Drawing.Point(23, 13);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(132, 21);
            this.txtInput.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.txtInput.TabIndex = 0;
            this.txtInput.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // ucDiagnose1
            // 
            this.ucDiagnose1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ucDiagnose1.Location = new System.Drawing.Point(23, 51);
            this.ucDiagnose1.Name = "ucDiagnose1";
            this.ucDiagnose1.Size = new System.Drawing.Size(392, 312);
            this.ucDiagnose1.TabIndex = 2;
            // 
            // neuFpEnter1_Sheet1
            // 
            this.neuFpEnter1_Sheet1.Reset();
            this.neuFpEnter1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuFpEnter1_Sheet1.ColumnCount = 7;
            this.neuFpEnter1_Sheet1.RowCount = 0;
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "索引";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ICD编码";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "诊断名称";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "操作员";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "操作时间";
            this.neuFpEnter1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "有效标记";
            this.neuFpEnter1_Sheet1.Columns.Get(1).Label = "ICD编码";
            this.neuFpEnter1_Sheet1.Columns.Get(1).Width = 100F;
            this.neuFpEnter1_Sheet1.Columns.Get(2).Label = "诊断名称";
            this.neuFpEnter1_Sheet1.Columns.Get(2).Width = 160F;
            this.neuFpEnter1_Sheet1.Columns.Get(4).Label = "操作时间";
            this.neuFpEnter1_Sheet1.Columns.Get(4).Width = 120F;
            this.neuFpEnter1_Sheet1.Columns.Get(5).CellType = checkBoxCellType1;
            this.neuFpEnter1_Sheet1.Columns.Get(5).Label = "有效标记";
            this.neuFpEnter1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.neuFpEnter1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuFpEnter1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuFpEnter1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.neuFpEnter1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.neuFpEnter1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuFpEnter1.SetActiveViewport(1, 0);
            // 
            // ucDeptDiagMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.pnlTree);
            this.Name = "ucDeptDiagMaintenance";
            this.Size = new System.Drawing.Size(597, 386);
            this.Load += new System.EventHandler(this.ucDeptDiagMaintenance_Load);
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1)).EndInit();
            this.neuPanel1.ResumeLayout(false);
            this.neuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuFpEnter1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel pnlTree;
        private Neusoft.FrameWork.WinForms.Controls.NeuSplitter neuSplitter1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel2;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox txtInput;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
        private Neusoft.HISFC.Components.Common.Controls.ucDiagnose ucDiagnose1;
        private Neusoft.FrameWork.WinForms.Controls.NeuFpEnter neuFpEnter1;
        private FarPoint.Win.Spread.SheetView neuFpEnter1_Sheet1;
    }
}
