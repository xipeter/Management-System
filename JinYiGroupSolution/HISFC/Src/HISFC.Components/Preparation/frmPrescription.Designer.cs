namespace UFC.Preparation
{
    partial class frmPrescription
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrescription));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            this.neuToolBar1 = new Neusoft.NFC.Interface.Controls.NeuToolBar();
            this.tbQuery = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbAdd = new System.Windows.Forms.ToolBarButton();
            this.tbDel = new System.Windows.Forms.ToolBarButton();
            this.tbSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.tbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.neuPanel1 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuSpread1 = new Neusoft.NFC.Interface.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel3 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.ucQueryItem1 = new UFC.Preparation.ucQueryItem();
            this.neuStatusBar1 = new Neusoft.NFC.Interface.Controls.NeuStatusBar();
            this.neuPanel2 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.neuSpread2 = new Neusoft.NFC.Interface.Controls.NeuSpread();
            this.neuSpread2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.neuPanel4 = new Neusoft.NFC.Interface.Controls.NeuPanel();
            this.lbPrescription = new Neusoft.NFC.Interface.Controls.NeuLabel();
            this.ucQueryItem2 = new UFC.Preparation.ucQueryItem();
            this.neuSplitter1 = new Neusoft.NFC.Interface.Controls.NeuSplitter();
            this.neuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.neuPanel3.SuspendLayout();
            this.neuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).BeginInit();
            this.neuPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // neuToolBar1
            // 
            this.neuToolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbQuery,
            this.toolBarButton1,
            this.tbAdd,
            this.tbDel,
            this.tbSave,
            this.toolBarButton3,
            this.tbExit});
            this.neuToolBar1.DropDownArrows = true;
            this.neuToolBar1.ImageList = this.imageList1;
            this.neuToolBar1.Location = new System.Drawing.Point(0, 0);
            this.neuToolBar1.Name = "neuToolBar1";
            this.neuToolBar1.ShowToolTips = true;
            this.neuToolBar1.Size = new System.Drawing.Size(687, 41);
            this.neuToolBar1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuToolBar1.TabIndex = 0;
            this.neuToolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.neuToolBar1_ButtonClick);
            // 
            // tbQuery
            // 
            this.tbQuery.ImageIndex = 0;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Text = "查询";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbAdd
            // 
            this.tbAdd.ImageIndex = 1;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Text = "增加";
            this.tbAdd.Visible = false;
            // 
            // tbDel
            // 
            this.tbDel.ImageIndex = 2;
            this.tbDel.Name = "tbDel";
            this.tbDel.Text = "删除";
            // 
            // tbSave
            // 
            this.tbSave.ImageIndex = 3;
            this.tbSave.Name = "tbSave";
            this.tbSave.Text = "保存";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbExit
            // 
            this.tbExit.ImageIndex = 4;
            this.tbExit.Name = "tbExit";
            this.tbExit.Text = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "查询.GIF");
            this.imageList1.Images.SetKeyName(1, "增加.GIF");
            this.imageList1.Images.SetKeyName(2, "删除.GIF");
            this.imageList1.Images.SetKeyName(3, "保存.GIF");
            this.imageList1.Images.SetKeyName(4, "退出.GIF");
            // 
            // neuPanel1
            // 
            this.neuPanel1.Controls.Add(this.neuSpread1);
            this.neuPanel1.Controls.Add(this.neuPanel3);
            this.neuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel1.Location = new System.Drawing.Point(0, 41);
            this.neuPanel1.Name = "neuPanel1";
            this.neuPanel1.Size = new System.Drawing.Size(687, 226);
            this.neuPanel1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel1.TabIndex = 1;
            // 
            // neuSpread1
            // 
            this.neuSpread1.About = "2.5.2007.2005";
            this.neuSpread1.AccessibleDescription = "neuSpread1, Sheet1, Row 0, Column 0, ";
            this.neuSpread1.BackColor = System.Drawing.Color.White;
            this.neuSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread1.FileName = "";
            this.neuSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.IsAutoSaveGridStatus = false;
            this.neuSpread1.IsCanCustomConfigColumn = false;
            this.neuSpread1.Location = new System.Drawing.Point(0, 39);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(687, 187);
            this.neuSpread1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 2;
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
            this.neuSpread1_Sheet1.ColumnCount = 5;
            this.neuSpread1_Sheet1.RowCount = 1;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "成品名";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "规格";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "包装数量";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "包装单位";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "最小单位";
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "成品名";
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 187F;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "规格";
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 110F;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "包装数量";
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 87F;
            this.neuSpread1_Sheet1.Columns.Get(3).Label = "包装单位";
            this.neuSpread1_Sheet1.Columns.Get(3).Width = 82F;
            this.neuSpread1_Sheet1.Columns.Get(4).Label = "最小单位";
            this.neuSpread1_Sheet1.Columns.Get(4).Width = 86F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // neuPanel3
            // 
            this.neuPanel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.neuPanel3.Controls.Add(this.ucQueryItem1);
            this.neuPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel3.Location = new System.Drawing.Point(0, 0);
            this.neuPanel3.Name = "neuPanel3";
            this.neuPanel3.Size = new System.Drawing.Size(687, 39);
            this.neuPanel3.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel3.TabIndex = 1;
            // 
            // ucQueryItem1
            // 
            this.ucQueryItem1.Location = new System.Drawing.Point(0, 3);
            this.ucQueryItem1.Name = "ucQueryItem1";
            this.ucQueryItem1.Size = new System.Drawing.Size(306, 32);
            this.ucQueryItem1.TabIndex = 0;
            // 
            // neuStatusBar1
            // 
            this.neuStatusBar1.Location = new System.Drawing.Point(0, 393);
            this.neuStatusBar1.Name = "neuStatusBar1";
            this.neuStatusBar1.Size = new System.Drawing.Size(687, 22);
            this.neuStatusBar1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuStatusBar1.TabIndex = 3;
            this.neuStatusBar1.Text = "neuStatusBar1";
            // 
            // neuPanel2
            // 
            this.neuPanel2.Controls.Add(this.neuSpread2);
            this.neuPanel2.Controls.Add(this.neuPanel4);
            this.neuPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuPanel2.Location = new System.Drawing.Point(0, 272);
            this.neuPanel2.Name = "neuPanel2";
            this.neuPanel2.Size = new System.Drawing.Size(687, 121);
            this.neuPanel2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel2.TabIndex = 4;
            // 
            // neuSpread2
            // 
            this.neuSpread2.About = "2.5.2007.2005";
            this.neuSpread2.AccessibleDescription = "neuSpread2, Sheet1, Row 0, Column 0, ";
            this.neuSpread2.BackColor = System.Drawing.Color.White;
            this.neuSpread2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.neuSpread2.FileName = "";
            this.neuSpread2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread2.IsAutoSaveGridStatus = false;
            this.neuSpread2.IsCanCustomConfigColumn = false;
            this.neuSpread2.Location = new System.Drawing.Point(0, 32);
            this.neuSpread2.Name = "neuSpread2";
            this.neuSpread2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread2_Sheet1});
            this.neuSpread2.Size = new System.Drawing.Size(687, 89);
            this.neuSpread2.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSpread2.TabIndex = 1;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread2.TextTipAppearance = tipAppearance2;
            this.neuSpread2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // neuSpread2_Sheet1
            // 
            this.neuSpread2_Sheet1.Reset();
            this.neuSpread2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread2_Sheet1.ColumnCount = 4;
            this.neuSpread2_Sheet1.RowCount = 0;
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "原料名称";
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "规格";
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "标准处方量";
            this.neuSpread2_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "单位";
            this.neuSpread2_Sheet1.Columns.Get(0).Label = "原料名称";
            this.neuSpread2_Sheet1.Columns.Get(0).Width = 180F;
            this.neuSpread2_Sheet1.Columns.Get(1).Label = "规格";
            this.neuSpread2_Sheet1.Columns.Get(1).Width = 123F;
            this.neuSpread2_Sheet1.Columns.Get(2).Label = "标准处方量";
            this.neuSpread2_Sheet1.Columns.Get(2).Width = 123F;
            this.neuSpread2_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.neuSpread2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread2_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.neuSpread2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread2.SetActiveViewport(1, 0);
            // 
            // neuPanel4
            // 
            this.neuPanel4.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.neuPanel4.Controls.Add(this.lbPrescription);
            this.neuPanel4.Controls.Add(this.ucQueryItem2);
            this.neuPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuPanel4.Location = new System.Drawing.Point(0, 0);
            this.neuPanel4.Name = "neuPanel4";
            this.neuPanel4.Size = new System.Drawing.Size(687, 32);
            this.neuPanel4.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuPanel4.TabIndex = 0;
            // 
            // lbPrescription
            // 
            this.lbPrescription.AutoSize = true;
            this.lbPrescription.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPrescription.Location = new System.Drawing.Point(322, 9);
            this.lbPrescription.Name = "lbPrescription";
            this.lbPrescription.Size = new System.Drawing.Size(80, 16);
            this.lbPrescription.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.lbPrescription.TabIndex = 1;
            this.lbPrescription.Text = "neuLabel1";
            // 
            // ucQueryItem2
            // 
            this.ucQueryItem2.Location = new System.Drawing.Point(0, 0);
            this.ucQueryItem2.Name = "ucQueryItem2";
            this.ucQueryItem2.Size = new System.Drawing.Size(248, 30);
            this.ucQueryItem2.TabIndex = 0;
            // 
            // neuSplitter1
            // 
            this.neuSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.neuSplitter1.Location = new System.Drawing.Point(0, 267);
            this.neuSplitter1.Name = "neuSplitter1";
            this.neuSplitter1.Size = new System.Drawing.Size(687, 5);
            this.neuSplitter1.Style = Neusoft.NFC.Interface.Controls.StyleType.Fixed3D;
            this.neuSplitter1.TabIndex = 5;
            this.neuSplitter1.TabStop = false;
            // 
            // frmPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 415);
            this.Controls.Add(this.neuPanel2);
            this.Controls.Add(this.neuSplitter1);
            this.Controls.Add(this.neuStatusBar1);
            this.Controls.Add(this.neuPanel1);
            this.Controls.Add(this.neuToolBar1);
            this.Name = "frmPrescription";
            this.Text = "frmPPRManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPPRManager_Load);
            this.neuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.neuPanel3.ResumeLayout(false);
            this.neuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread2_Sheet1)).EndInit();
            this.neuPanel4.ResumeLayout(false);
            this.neuPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Neusoft.NFC.Interface.Controls.NeuToolBar neuToolBar1;
        private System.Windows.Forms.ToolBarButton tbQuery;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton tbAdd;
        private System.Windows.Forms.ToolBarButton tbDel;
        private System.Windows.Forms.ToolBarButton tbSave;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton tbExit;
        private System.Windows.Forms.ImageList imageList1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel1;
        private Neusoft.NFC.Interface.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel3;
        private ucQueryItem ucQueryItem1;
        private Neusoft.NFC.Interface.Controls.NeuStatusBar neuStatusBar1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel2;
        private Neusoft.NFC.Interface.Controls.NeuSplitter neuSplitter1;
        private Neusoft.NFC.Interface.Controls.NeuSpread neuSpread2;
        private FarPoint.Win.Spread.SheetView neuSpread2_Sheet1;
        private Neusoft.NFC.Interface.Controls.NeuPanel neuPanel4;
        private ucQueryItem ucQueryItem2;
        private Neusoft.NFC.Interface.Controls.NeuLabel lbPrescription;
    }
}