
namespace Neusoft.HISFC.Components.HealthRecord.ICD
{
    partial class ucICDMaint
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuItem mAll;
        private System.Windows.Forms.ContextMenu cmQuery;
        private System.Windows.Forms.MenuItem mValid;
        private System.Windows.Forms.MenuItem mStop;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel sbpOper;
        private System.Windows.Forms.StatusBarPanel sbpSelectObj;
        private System.Windows.Forms.GroupBox groupBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuLabel label1;
        private Neusoft.FrameWork.WinForms.Controls.NeuTextBox textBox1;
        private Neusoft.FrameWork.WinForms.Controls.NeuPanel panel1;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
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
            this.cmQuery = new System.Windows.Forms.ContextMenu();
            this.mAll = new System.Windows.Forms.MenuItem();
            this.mValid = new System.Windows.Forms.MenuItem();
            this.mStop = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.sbpOper = new System.Windows.Forms.StatusBarPanel();
            this.sbpSelectObj = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Search = new System.Windows.Forms.Button();
            this.cancerFlag = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.infectFlag = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.cb30dis = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.textBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.label1 = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panel1 = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.sbpOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpSelectObj)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmQuery
            // 
            this.cmQuery.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mAll,
            this.mValid,
            this.mStop});
            // 
            // mAll
            // 
            this.mAll.Index = 0;
            this.mAll.Text = "所有(&A)";
            this.mAll.Click += new System.EventHandler(this.mAll_Click);
            // 
            // mValid
            // 
            this.mValid.Index = 1;
            this.mValid.Text = "有效(V)";
            this.mValid.Click += new System.EventHandler(this.mValid_Click);
            // 
            // mStop
            // 
            this.mStop.Index = 2;
            this.mStop.Text = "无效(S)";
            this.mStop.Click += new System.EventHandler(this.mStop_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 578);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpOper,
            this.sbpSelectObj});
            this.statusBar1.Size = new System.Drawing.Size(800, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 2;
            // 
            // sbpOper
            // 
            this.sbpOper.Name = "sbpOper";
            this.sbpOper.Text = "操作员";
            // 
            // sbpSelectObj
            // 
            this.sbpSelectObj.Name = "sbpSelectObj";
            this.sbpSelectObj.Text = "项目:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.Controls.Add(this.cancerFlag);
            this.groupBox1.Controls.Add(this.infectFlag);
            this.groupBox1.Controls.Add(this.cb30dis);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 39);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(192, 10);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 5;
            this.Search.Text = "星键互查";
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // cancerFlag
            // 
            this.cancerFlag.Location = new System.Drawing.Point(576, 12);
            this.cancerFlag.Name = "cancerFlag";
            this.cancerFlag.Size = new System.Drawing.Size(80, 24);
            this.cancerFlag.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cancerFlag.TabIndex = 4;
            this.cancerFlag.Text = "恶性肿瘤";
            this.cancerFlag.Visible = false;
            this.cancerFlag.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // infectFlag
            // 
            this.infectFlag.Location = new System.Drawing.Point(456, 12);
            this.infectFlag.Name = "infectFlag";
            this.infectFlag.Size = new System.Drawing.Size(104, 24);
            this.infectFlag.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.infectFlag.TabIndex = 3;
            this.infectFlag.Text = "传染病";
            this.infectFlag.Visible = false;
            this.infectFlag.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // cb30dis
            // 
            this.cb30dis.Location = new System.Drawing.Point(352, 12);
            this.cb30dis.Name = "cb30dis";
            this.cb30dis.Size = new System.Drawing.Size(80, 24);
            this.cb30dis.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.cb30dis.TabIndex = 2;
            this.cb30dis.Text = "30种疾病";
            this.cb30dis.Visible = false;
            this.cb30dis.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.label1.TabIndex = 0;
            this.label1.Text = "查询：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fpSpread1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 539);
            this.panel1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panel1.TabIndex = 5;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(800, 539);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            this.fpSpread1.ColumnWidthChanged += new FarPoint.Win.Spread.ColumnWidthChangedEventHandler(this.fpSpread1_ColumnWidthChanged);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 40F;
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ucICDMaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Name = "ucICDMaint";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.ucICDMaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbpOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpSelectObj)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
