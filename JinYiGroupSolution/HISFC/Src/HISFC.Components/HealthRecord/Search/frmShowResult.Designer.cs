namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    partial class frmShowResult
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.ucChooseList treeView1;
        protected System.Windows.Forms.ImageList ilTreeView;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbPrint;
        private System.Windows.Forms.ToolBarButton tbExist;
        private System.Windows.Forms.ImageList ilMenu;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel2;
        private System.Windows.Forms.ToolBarButton tbList;
        public Neusoft.FrameWork.WinForms.Controls.NeuLabel LBSeacheInfo;

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
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.treeView1 = new Neusoft.FrameWork.WinForms.Controls.ucChooseList();
            this.ilTreeView = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbPrint = new System.Windows.Forms.ToolBarButton();
            this.tbList = new System.Windows.Forms.ToolBarButton();
            this.tbExist = new System.Windows.Forms.ToolBarButton();
            this.ilMenu = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.LBSeacheInfo = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel2 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuPanel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.neuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "3.0.2004.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(568, 459);
            this.fpSpread1.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance2;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic2;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.fpSpread1_Sheet1.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 40F;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(105)))), ((int)(((byte)(107)))));
            this.fpSpread1_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // treeView1
            // 
            this.treeView1.Caption = "选择项目";
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.IsShowCloseButton = true;
            this.treeView1.IsShowTreeView = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(208, 459);
            this.treeView1.TabIndex = 2;
            // 
            // ilTreeView
            // 
            this.ilTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ilTreeView.ImageSize = new System.Drawing.Size(16, 16);
            this.ilTreeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbPrint,
            this.tbList,
            this.tbExist});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.ilMenu;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(776, 57);
            this.toolBar1.TabIndex = 3;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbPrint
            // 
            this.tbPrint.ImageIndex = 12;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Text = "打印";
            // 
            // tbList
            // 
            this.tbList.ImageIndex = 7;
            this.tbList.Name = "tbList";
            this.tbList.Text = "列表";
            // 
            // tbExist
            // 
            this.tbExist.ImageIndex = 14;
            this.tbExist.Name = "tbExist";
            this.tbExist.Text = "退出";
            // 
            // ilMenu
            // 
            this.ilMenu.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilMenu.ImageSize = new System.Drawing.Size(32, 32);
            this.ilMenu.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.LBSeacheInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 49);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 4;
            // 
            // LBSeacheInfo
            // 
            this.LBSeacheInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBSeacheInfo.Location = new System.Drawing.Point(0, 0);
            this.LBSeacheInfo.Name = "LBSeacheInfo";
            this.LBSeacheInfo.Size = new System.Drawing.Size(776, 49);
            this.LBSeacheInfo.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.LBSeacheInfo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.neuPanel1);
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 459);
            this.panel2.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel2.TabIndex = 5;
            // 
            // neuPanel1
            // 
            this.neuPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.neuPanel1.Controls.Add(this.fpSpread1);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel1.Location = new System.Drawing.Point(208, 0);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(568, 459);
            this.neuPanel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 3;
            // 
            // frmShowResult
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(776, 565);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmShowResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询结果显示";
            this.Load += new System.EventHandler(this.frmShowResult_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmShowResult_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.neuPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.FrameWork.WinForms.Controls.NeuPanel neuPanel1;
    }
}
