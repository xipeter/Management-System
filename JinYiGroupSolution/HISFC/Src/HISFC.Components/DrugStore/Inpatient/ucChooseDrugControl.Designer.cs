namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    partial class ucChooseDrugControl
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
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.panelTree = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tvDeptTree1 = new Neusoft.HISFC.Components.DrugStore.Base.tvDeptTree(this.components);
            this.panelTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTree
            // 
            this.panelTree.Controls.Add(this.tvDeptTree1);
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTree.Location = new System.Drawing.Point(0, 0);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(187, 381);
            this.panelTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelTree.TabIndex = 0;
            this.panelTree.Visible = false;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(187, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(474, 381);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance1;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.neuSpread1_ButtonClicked);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 3;
            this.neuSpread1_Sheet1.RowCount = 3;
            this.neuSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247))))), System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(217)))), ((int)(((byte)(217))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, false);
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "摆药台";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "发送类型";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "显示等级";
            this.neuSpread1_Sheet1.ColumnHeader.Columns.Default.Visible = true;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 40F;
            this.neuSpread1_Sheet1.Columns.Default.Visible = true;
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = buttonCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "摆药台";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 183F;
            this.neuSpread1_Sheet1.Columns.Get(1).BackColor = System.Drawing.SystemColors.ControlLight;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "发送类型";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 144F;
            this.neuSpread1_Sheet1.Columns.Get(2).BackColor = System.Drawing.SystemColors.ControlLight;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "显示等级";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 179F;
            this.neuSpread1_Sheet1.DefaultStyle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.neuSpread1_Sheet1.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.neuSpread1_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.neuSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.RowHeader.Visible = false;
            this.neuSpread1_Sheet1.Rows.Default.Height = 40F;
            this.neuSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.neuSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.neuSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tvDeptTree1
            // 
            this.tvDeptTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDeptTree1.HideSelection = false;
            this.tvDeptTree1.Location = new System.Drawing.Point(0, 0);
            this.tvDeptTree1.Name = "tvDeptTree1";
            this.tvDeptTree1.Size = new System.Drawing.Size(187, 381);
            this.tvDeptTree1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.tvDeptTree1.TabIndex = 0;
            this.tvDeptTree1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDeptTree1_AfterSelect);
            // 
            // ucChooseDrugControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neuSpread1);
            this.Controls.Add(this.panelTree);
            this.Name = "ucChooseDrugControl";
            this.Size = new System.Drawing.Size(661, 381);
            this.panelTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panelTree;
        private Neusoft.HISFC.Components.DrugStore.Base.tvDeptTree tvDeptTree1;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
