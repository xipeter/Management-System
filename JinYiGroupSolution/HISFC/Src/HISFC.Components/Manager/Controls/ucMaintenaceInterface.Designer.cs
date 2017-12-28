namespace Neusoft.HISFC.Components.Manager.Controls
{
    partial class ucMaintenaceInterface
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
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvContainType = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.InterfaceInfo = new System.Windows.Forms.TabPage();
            this.tvInterface = new System.Windows.Forms.TreeListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ParamInfo = new System.Windows.Forms.TabPage();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.TestInfo = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.InterfaceInfo.SuspendLayout();
            this.ParamInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tvContainType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 476);
            this.panel1.TabIndex = 0;
            // 
            // tvContainType
            // 
            this.tvContainType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvContainType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvContainType.ItemHeight = 17;
            this.tvContainType.LabelEdit = true;
            this.tvContainType.Location = new System.Drawing.Point(0, 0);
            this.tvContainType.Name = "tvContainType";
            this.tvContainType.Size = new System.Drawing.Size(169, 476);
            this.tvContainType.TabIndex = 0;
            this.tvContainType.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvContainType_AfterLabelEdit);
            this.tvContainType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvContainType_AfterSelect);
            this.tvContainType.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvContainType_BeforeLabelEdit);
            this.tvContainType.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvContainType_BeforeSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(169, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 476);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tbControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(171, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 476);
            this.panel2.TabIndex = 2;
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.InterfaceInfo);
            this.tbControl.Controls.Add(this.ParamInfo);
            this.tbControl.Controls.Add(this.TestInfo);
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(0, 0);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(456, 476);
            this.tbControl.TabIndex = 1;
            this.tbControl.SelectedIndexChanged += new System.EventHandler(this.tbControl_SelectedIndexChanged);
            // 
            // InterfaceInfo
            // 
            this.InterfaceInfo.Controls.Add(this.tvInterface);
            this.InterfaceInfo.Location = new System.Drawing.Point(4, 21);
            this.InterfaceInfo.Name = "InterfaceInfo";
            this.InterfaceInfo.Padding = new System.Windows.Forms.Padding(3);
            this.InterfaceInfo.Size = new System.Drawing.Size(448, 451);
            this.InterfaceInfo.TabIndex = 0;
            this.InterfaceInfo.Text = "接口维护";
            this.InterfaceInfo.UseVisualStyleBackColor = true;
            // 
            // tvInterface
            // 
            this.tvInterface.BackColor = System.Drawing.Color.White;
            this.tvInterface.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.tvInterface.Comparer = treeListViewItemCollectionComparer2;
            this.tvInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvInterface.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvInterface.Location = new System.Drawing.Point(3, 3);
            this.tvInterface.Name = "tvInterface";
            this.tvInterface.PlusMinusLineColor = System.Drawing.Color.Gray;
            this.tvInterface.Size = new System.Drawing.Size(442, 445);
            this.tvInterface.TabIndex = 0;
            this.tvInterface.UseCompatibleStateImageBehavior = false;
            this.tvInterface.DoubleClick += new System.EventHandler(this.tvInterface_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "组件的DLL";
            this.columnHeader1.Width = 237;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "组件类";
            this.columnHeader2.Width = 334;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "组件类型";
            this.columnHeader3.Width = 112;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "组件名称";
            this.columnHeader4.Width = 124;
            // 
            // ParamInfo
            // 
            this.ParamInfo.Controls.Add(this.neuSpread1);
            this.ParamInfo.Location = new System.Drawing.Point(4, 21);
            this.ParamInfo.Name = "ParamInfo";
            this.ParamInfo.Padding = new System.Windows.Forms.Padding(3);
            this.ParamInfo.Size = new System.Drawing.Size(448, 451);
            this.ParamInfo.TabIndex = 1;
            this.ParamInfo.Text = "控制参数维护";
            this.ParamInfo.UseVisualStyleBackColor = true;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "3.0.2004.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(3, 3);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(442, 445);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            this.neuSpread1.TabStrip.BackColor = System.Drawing.Color.White;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance2;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.neuSpread1_CellDoubleClick);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 4;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "参数ID";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "参数名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "参数值";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "是否启用？";
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "参数ID";
            this.neuSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 78F;
            this.neuSpread1_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "参数名称";
            this.neuSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 252F;
            this.neuSpread1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "参数值";
            this.neuSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 252F;
            this.neuSpread1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "是否启用？";
            this.neuSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 116F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // TestInfo
            // 
            this.TestInfo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestInfo.Location = new System.Drawing.Point(4, 21);
            this.TestInfo.Name = "TestInfo";
            this.TestInfo.Size = new System.Drawing.Size(448, 451);
            this.TestInfo.TabIndex = 2;
            this.TestInfo.Text = "模块环境测试报告";
            this.TestInfo.UseVisualStyleBackColor = true;
            // 
            // ucMaintenaceInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "ucMaintenaceInterface";
            this.Size = new System.Drawing.Size(627, 476);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tbControl.ResumeLayout(false);
            this.InterfaceInfo.ResumeLayout(false);
            this.ParamInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvContainType;
        private System.Windows.Forms.TreeListView tvInterface;
        public System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage InterfaceInfo;
        private System.Windows.Forms.TabPage ParamInfo;
        private System.Windows.Forms.TabPage TestInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
    }
}
