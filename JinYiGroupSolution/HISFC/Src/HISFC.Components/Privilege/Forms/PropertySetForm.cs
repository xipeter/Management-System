using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
using System.Collections.Generic;
using Neusoft.NFC.Object;
using Neusoft.NFC.Management;
using Neusoft.NFC.Function;
//using Neusoft.WinForms.Controls;


namespace Neusoft.UFC.Privilege.Forms
{
    /// <summary>
    /// 属性设置窗口
    /// </summary>
    internal class PropertySetForm : BaseForm
    {
        protected Label label1;
        protected Neusoft.NFC.Interface.Forms.DragAndDropListView listView1;
        protected Neusoft.NFC.Interface.Forms.DragAndDropListView listView2;
        protected Neusoft.NFC.Interface.Controls.NeuLabel lblControlName;
        protected Neusoft.NFC.Interface.Controls.NeuButton button1;
        protected ToolTip toolTip = new ToolTip();
        protected Neusoft.NFC.Interface.Controls.NeuTabControl tabControl1;
        protected TabPage tabPage1;
        protected TabPage tabPage2;
        protected Neusoft.NFC.Interface.Controls.NeuCheckBox checkBox1;
        protected Neusoft.NFC.Interface.Controls.NeuCheckBox checkBox2;
        protected Neusoft.NFC.Interface.Controls.NeuCheckBox checkBox3;
        protected Neusoft.NFC.Interface.Controls.NeuCheckBox checkBox4;
        private IContainer components;
        protected TabPage tabPage3;
        protected FarPoint.Win.Spread.FpSpread fpSpread1;
        protected FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        protected Neusoft.NFC.Interface.Controls.NeuContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem mnuAddSplit;
        protected ToolStripMenuItem mnuDelteSplit;
        protected Neusoft.NFC.Interface.Controls.NeuButton button2;
        private Neusoft.NFC.Interface.Controls.NeuSplitter splitter1;
        protected Neusoft.NFC.Interface.Controls.NeuListView lsvProperty;
        protected ColumnHeader columnName;
        protected ColumnHeader columnValue;
        private ColumnHeader columnHeader1;
        private Neusoft.NFC.Interface.Controls.NeuButton neuButton1;
        private ToolStripMenuItem mnuDelete;
        private Neusoft.NFC.Interface.Controls.NeuButton btnProperty;
        private Neusoft.NFC.Interface.Controls.NeuContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem upToolStripMenuItem;
        private ToolStripMenuItem downToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        protected Neusoft.NFC.Interface.Controls.NeuCheckBox chkShowSearch;
        protected Label label5;
        protected Label label4;
        private Button button3;

        private OperationBaseForm form = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tb1"></param>
        /// <param name="tb2"></param>
        /// <param name="controlText"></param>
        public PropertySetForm(OperationBaseForm sender, ToolStrip tb1, ToolStripItem[] original, ToolStrip tb2, string controlText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            
            this.form = sender;//窗口了，没用事件，比较懒
            this.checkBox1.Checked = form.IsShowToolBar;
            this.checkBox2.Checked = form.IsShowTreeView;
            this.checkBox3.Checked = form.IsShowStatusBar;
            this.checkBox4.Checked = form.IsDoubleSelectValue;
            this.chkShowSearch.Checked = form.IsShowSearchTextBox;
            this._originalButtons = original;

            this.init(tb1, tb2, controlText);//初始化ToolBar                      

            this.SetOperAndDateInvisible();
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.label1 = new System.Windows.Forms.Label();
            this.lblControlName = new NFC.Interface.Controls.NeuLabel();
            this.button1 = new NFC.Interface.Controls.NeuButton();
            this.tabControl1 = new NFC.Interface.Controls.NeuTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkShowSearch = new NFC.Interface.Controls.NeuCheckBox();
            this.checkBox4 = new NFC.Interface.Controls.NeuCheckBox();
            this.checkBox3 = new NFC.Interface.Controls.NeuCheckBox();
            this.checkBox2 = new NFC.Interface.Controls.NeuCheckBox();
            this.checkBox1 = new NFC.Interface.Controls.NeuCheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnProperty = new NFC.Interface.Controls.NeuButton();
            this.splitter1 = new NFC.Interface.Controls.NeuSplitter();
            this.lsvProperty = new NFC.Interface.Controls.NeuListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnValue = new System.Windows.Forms.ColumnHeader();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.contextMenuStrip2 = new NFC.Interface.Controls.NeuContextMenuStrip();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.neuButton1 = new NFC.Interface.Controls.NeuButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new Neusoft.NFC.Interface.Forms.DragAndDropListView();
            this.contextMenuStrip1 = new NFC.Interface.Controls.NeuContextMenuStrip();
            this.mnuAddSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelteSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.listView2 = new Neusoft.NFC.Interface.Forms.DragAndDropListView();
            this.button2 = new NFC.Interface.Controls.NeuButton();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前控件：";
            // 
            // lblControlName
            // 
            this.lblControlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblControlName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblControlName.Location = new System.Drawing.Point(82, 8);
            this.lblControlName.Name = "lblControlName";
            this.lblControlName.Size = new System.Drawing.Size(333, 16);
            this.lblControlName.TabIndex = 3;
            this.lblControlName.Text = "无控件加载";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(285, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定(&O)";
            this.button1.Type = NFC.Interface.Controls.General.ButtonType.None;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 394);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkShowSearch);
            this.tabPage2.Controls.Add(this.checkBox4);
            this.tabPage2.Controls.Add(this.checkBox3);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(425, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "显示";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkShowSearch
            // 
            this.chkShowSearch.Checked = true;
            this.chkShowSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowSearch.Location = new System.Drawing.Point(80, 142);
            this.chkShowSearch.Name = "chkShowSearch";
            this.chkShowSearch.Size = new System.Drawing.Size(168, 24);
            this.chkShowSearch.TabIndex = 8;
            this.chkShowSearch.Text = "显示树查询";
            this.chkShowSearch.CheckedChanged += new System.EventHandler(this.chkShowSearch_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.Location = new System.Drawing.Point(80, 112);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(168, 24);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "树的操作用双击来操作";
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Location = new System.Drawing.Point(80, 80);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(168, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "显示状态条";
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Location = new System.Drawing.Point(80, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(168, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "显示树";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(80, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "显示功能工具栏";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnProperty);
            this.tabPage3.Controls.Add(this.splitter1);
            this.tabPage3.Controls.Add(this.lsvProperty);
            this.tabPage3.Controls.Add(this.fpSpread1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(425, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "系统控件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnProperty
            // 
            this.btnProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProperty.Location = new System.Drawing.Point(347, 343);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new System.Drawing.Size(75, 23);
            this.btnProperty.TabIndex = 3;
            this.btnProperty.Text = "属性";
            this.btnProperty.Type = NFC.Interface.Controls.General.ButtonType.None;
            this.btnProperty.UseVisualStyleBackColor = true;
            this.btnProperty.Visible = false;
            this.btnProperty.Click += new System.EventHandler(this.btnProperty_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 226);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(425, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // lsvProperty
            // 
            this.lsvProperty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnName,
            this.columnValue});
            this.lsvProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvProperty.FullRowSelect = true;
            this.lsvProperty.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvProperty.Location = new System.Drawing.Point(0, 226);
            this.lsvProperty.MultiSelect = false;
            this.lsvProperty.Name = "lsvProperty";
            this.lsvProperty.Size = new System.Drawing.Size(425, 143);
            this.lsvProperty.TabIndex = 1;
            this.lsvProperty.UseCompatibleStateImageBehavior = false;
            this.lsvProperty.View = System.Windows.Forms.View.Details;
            this.lsvProperty.DoubleClick += new System.EventHandler(this.lsvProperty_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 23;
            // 
            // columnName
            // 
            this.columnName.Text = "  属  性";
            this.columnName.Width = 100;
            // 
            // columnValue
            // 
            this.columnValue.Text = "数  值";
            this.columnValue.Width = 200;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.fpSpread1.BackColor = System.Drawing.Color.Transparent;
            this.fpSpread1.ContextMenuStrip = this.contextMenuStrip2;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(425, 226);
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_ButtonClicked);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(106, 70);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.upToolStripMenuItem.Text = "Up";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.downToolStripMenuItem.Text = "Down";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 4;
            this.fpSpread1_Sheet1.RowCount = 10;
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "DLL名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "控件名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "属性";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "DLL名称";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 93F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "控件名称";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 168F;
            buttonCellType3.Text = "属性...";
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = buttonCellType3;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "属性";
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.fpSpread1_Sheet1_CellChanged);
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.neuButton1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.listView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(425, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工具栏";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // neuButton1
            // 
            this.neuButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neuButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuButton1.Location = new System.Drawing.Point(342, 313);
            this.neuButton1.Name = "neuButton1";
            this.neuButton1.Size = new System.Drawing.Size(75, 23);
            this.neuButton1.TabIndex = 8;
            this.neuButton1.Text = "重置工具栏";
            this.neuButton1.Type = NFC.Interface.Controls.General.ButtonType.None;
            this.neuButton1.UseVisualStyleBackColor = true;
            this.neuButton1.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(221, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "二级工具栏";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "一级工具栏";
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.AllowReorder = true;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.HideSelection = false;
            this.listView1.LineColor = System.Drawing.Color.Red;
            this.listView1.Location = new System.Drawing.Point(7, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(189, 268);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSplit,
            this.mnuDelteSplit,
            this.mnuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuAddSplit
            // 
            this.mnuAddSplit.Name = "mnuAddSplit";
            this.mnuAddSplit.Size = new System.Drawing.Size(134, 22);
            this.mnuAddSplit.Text = "添加分隔符";
            this.mnuAddSplit.Click += new System.EventHandler(this.mnuAddSplit_Click);
            // 
            // mnuDelteSplit
            // 
            this.mnuDelteSplit.Name = "mnuDelteSplit";
            this.mnuDelteSplit.Size = new System.Drawing.Size(134, 22);
            this.mnuDelteSplit.Text = "删除分割符";
            this.mnuDelteSplit.Click += new System.EventHandler(this.mnuDelteSplit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(134, 22);
            this.mnuDelete.Text = "删除";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelteClick);
            // 
            // listView2
            // 
            this.listView2.AllowDrop = true;
            this.listView2.AllowReorder = true;
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.LineColor = System.Drawing.Color.Red;
            this.listView2.Location = new System.Drawing.Point(202, 39);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(215, 268);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(366, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消(&C)";
            this.button2.Type = NFC.Interface.Controls.General.ButtonType.None;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 424);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "设置默认值";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PropertySetForm
            // 
            this.ClientSize = new System.Drawing.Size(453, 475);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblControlName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsStatusStripVisible = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertySetForm";
            this.ShowInTaskbar = false;
            this.Text = "设置工具栏";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.lblControlName, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private string formID = "";
        private string formType = "FormSetting";
        public Control currentDefaultControl = null;

        #region 初始化

        private ToolStripItem[] _originalButtons = null;
        private NeuConfiguration formProperty = null;

        private void init(ToolStrip tb1, ToolStrip tb2, string controlText)
        {
            this.lsvProperty.Items.Clear();
            this.listView1.Clear();
            this.listView2.Clear();
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView2.View = System.Windows.Forms.View.List;

            this.listView1.MultiSelect = false;
            this.listView2.MultiSelect = false;

            this.listView1.SmallImageList = tb1.ImageList;
            this.listView2.SmallImageList = tb2.ImageList;
                        
            foreach (ToolStripItem tbButton in tb1.Items)
            {
                this.AddToolBarButton(this.listView1, tbButton.Text, tbButton.ImageIndex);
            }

            foreach (ToolStripItem tbButton in tb2.Items)
            {
                this.AddToolBarButton(this.listView2, tbButton.Text, tbButton.ImageIndex);
            }

            this.lblControlName.Text = controlText;//控件名称
        }

        protected virtual void AddToolBarButton(ListView listView, string text, int imageIndex)
        {
            if (text == "") text = "-";
            ListViewItem lstItem = new ListViewItem(text.PadRight(15, ' '), imageIndex);

            listView.Items.Add(lstItem);
        }
        
        private bool isOneControl = false;
        /// <summary>
        /// 设置只有默认控件的窗口
        /// </summary>
        /// <param name="defaultcontrol"></param>
        public virtual void SetNotAllowAddControl(Control defaultcontrol)
        {
            this.isOneControl = true;
            this.fpSpread1.Visible = false;
            this.btnProperty.Visible = true;
            currentDefaultControl = defaultcontrol;
        }

        /// <summary>
        /// 初始化窗口拥有的控件
        /// </summary>
        /// <param name="formID"></param>
        public virtual void InitControl(string formID)
        {
            this.formID = formID;
            if (formID == "") return;
            //A9D33964-33F0-4bfd-B28E-EBC425F97C99
            ConfigurationManager _proxy = Util.CreateProxy();
            using (_proxy as IDisposable)
            {
                XmlDocument xml=new XmlDocument();
                formProperty = _proxy.GetConfiguration(formID, formType);

                if (formProperty!=null && !string.IsNullOrEmpty(formProperty.ID))
                {
                    xml.LoadXml(formProperty.ConfigString);
                    this.SetControl(xml);
                }
                else
                {
                    string ResourceId = _proxy.GetResourceId(formID);
                    if (!String.IsNullOrEmpty(ResourceId))
                    {
                        formProperty = _proxy.GetConfiguration(ResourceId, "FormSettingDefault");
                        xml.LoadXml(formProperty.ConfigString);
                        if (formProperty != null)
                        {
                            xml.LoadXml(formProperty.ConfigString);
                            this.SetControl(xml);
                        }

                    }
                    else
                    {
                        //没有配置过,
                        string dllName = form.CurrentControl.GetType().Module.Name;
                        dllName = dllName.Remove(dllName.LastIndexOf('.'));

                        this.fpSpread1_Sheet1.Cells[0, 0].Text = dllName;
                        this.fpSpread1_Sheet1.Cells[0, 1].Text = form.CurrentControl.GetType().FullName;
                        this.fpSpread1_Sheet1.Cells[0, 2].Text = "默认控件";
                        this.fpSpread1_Sheet1.Rows[0].Tag = null;

                    }
                
                }



                //if (formProperty == null || string.IsNullOrEmpty(formProperty.Id))
                //{

                //    //没有配置过,
                //    string dllName = form.CurrentControl.GetType().Module.Name;
                //    dllName = dllName.Remove(dllName.LastIndexOf('.'));

                //    this.fpSpread1_Sheet1.Cells[0, 0].Text = dllName;
                //    this.fpSpread1_Sheet1.Cells[0, 1].Text = form.CurrentControl.GetType().FullName;
                //    this.fpSpread1_Sheet1.Cells[0, 2].Text = "默认控件";
                //    this.fpSpread1_Sheet1.Rows[0].Tag = null;
                //}
                //else
                //{
                //    this.SetControl(formProperty.ConfigXml);
                //}
            }
        }
        
        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="isShowToolBar"></param>
        /// <param name="isShowTree"></param>
        /// <param name="isShowStatusBar"></param>
        /// <param name="isDoubleClick"></param>
        /// <param name="textPosition"></param>
        //public virtual void SetControl(XmlDocument configXml)
        //{
        //    this.IsShowStatusBar = NConvert.ToBoolean(configXml.DocumentElement.Attributes["isShowStatusBar"].Value);
        //    this.IsShowToolBar = NConvert.ToBoolean(configXml.DocumentElement.Attributes["isShowToolBar"].Value); 
        //    this.IsShowTreeView = NConvert.ToBoolean(configXml.DocumentElement.Attributes["isShowTree"].Value); 
        //    this.IsDoubleSelectValue = NConvert.ToBoolean(configXml.DocumentElement.Attributes["isDoubleClick"].Value);
        //    this.TextPosition = Convert.ToInt16(configXml.DocumentElement.Attributes["ButtonTextPosition"].Value);
        //    this.IsShowSearch = NConvert.ToBoolean(configXml.DocumentElement.Attributes["isShowSearch"].Value);

        //    this.SetControl(configXml);
        //}

        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="xml"></param>
        public virtual void SetControl(XmlDocument configXml)
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.RowCount = 10;//?
            this.IsShowStatusBar = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowStatusbar"].Value);
            this.IsShowToolBar = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowToolbar"].Value);
            this.IsShowTreeView = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowTree"].Value);
            this.IsDoubleSelectValue = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsTreeDoubleClick"].Value);
            this.TextPosition = Convert.ToInt16(configXml.DocumentElement.Attributes["ButtonTextPosition"].Value);
            this.IsShowSearch = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowSearch"].Value);

            XmlNodeList nodes = configXml.SelectNodes("//Setting/ToolBar");
            string dllName = "", controlName = "";
            int i = 0;

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["DllName"].Value != dllName ||
                   node.Attributes["ControlName"].Value != controlName)
                {
                    dllName = node.Attributes["DllName"].Value;
                    controlName = node.Attributes["ControlName"].Value;
                    
                    {
                        this.fpSpread1_Sheet1.Cells[i, 0].Text = dllName;
                        this.fpSpread1_Sheet1.Cells[i, 1].Text = controlName;
                        this.fpSpread1_Sheet1.Cells[i, 2].Text = node.Attributes["Name"].Value;
                        this.fpSpread1_Sheet1.Rows[i].Tag = configXml;
                    }

                    if (i == 0)
                    {
                        this.lblControlName.Text = controlName;
                        ChangeControl(configXml, dllName, controlName);
                        SetToolBar(dllName, controlName, configXml);
                    }

                    i++;
                }
            }
        }

        private void ChangeControl(XmlDocument configXml, string dllname, string controlname)
        {
            Dictionary<string, string> _keyValues = this.ConvertToSysControlList(dllname, controlname, configXml);

            lsvProperty.Items.Clear();

            if (_keyValues != null)
            {
                foreach (KeyValuePair<string, string> _pair in _keyValues)
                {
                    ListViewItem item = new ListViewItem(_pair.Key);
                    item.SubItems.Clear();
                    item.SubItems.Add(_pair.Key);
                    item.SubItems.Add(_pair.Value);
                    lsvProperty.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 获取控件属性列表
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="controlName"></param>
        /// <param name="propXML"></param>
        /// <returns></returns>
        public Dictionary<string, string> ConvertToSysControlList(string dllName, string controlName, XmlDocument configXml)
        {
            XmlNodeList nodes = configXml.SelectNodes("//Setting/Control");
            Dictionary<string, string> _keyvalues = new Dictionary<string, string>();

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["DllName"].Value == dllName &&
                    node.Attributes["ControlName"].Value == controlName)
                {
                    _keyvalues.Add(node.Attributes["PropertyName"].Value, node.Attributes["PropertyValue"].Value);
                }
            }
            
            return _keyvalues;
        }

        private void SetToolBar(string dllName, string controlName, XmlDocument configXml)
        {

            XmlNodeList nodeToolBars = configXml.SelectNodes("//Setting/ToolBar");
            foreach (XmlNode node in nodeToolBars)
            {
                if (node.Attributes["DllName"].Value == dllName &&
                    node.Attributes["ControlName"].Value == controlName)
                {
                    this.listView1.Items.Clear();
                    this.listView2.Items.Clear();

                    string[] ss = node.Attributes["ToolBar1"].Value.Split(';');
                    for (int i = 1; i < ss.Length; i++)
                    {
                        this.listView1.Items.Add(ss[i]);
                    }

                    ss = node.Attributes["ToolBar2"].Value.Split(';');
                    for (int i = 1; i < ss.Length; i++)
                    {
                        this.listView2.Items.Add(ss[i]);
                    }
                }
            }
        }
             

        /// <summary>
        /// 获得当前Control XMLString
        /// </summary>
        /// <returns></returns>
        public virtual XmlDocument GetXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement node = doc.CreateElement("Setting");
            if (this.isOneControl== false)//多控件
            {
                for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                {
                    if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim() != "" || fpSpread1_Sheet1.Cells[i, 1].Text.Trim() != "")
                    {
                        XmlDocument configXml = new XmlDocument();
                        if (fpSpread1_Sheet1.Rows[i].Tag == null)
                            configXml = null;
                        else
                            configXml.LoadXml((fpSpread1_Sheet1.Rows[i].Tag as NeuConfiguration).ConfigString);

                        ChangeControl(configXml, fpSpread1_Sheet1.Cells[i, 0].Text, fpSpread1_Sheet1.Cells[i, 1].Text);
                        SetToolBar(fpSpread1_Sheet1.Cells[i, 0].Text, fpSpread1_Sheet1.Cells[i, 1].Text, configXml);

                        XmlElement element1 = SaveControlXMLString(fpSpread1_Sheet1.Cells[i, 0].Text, fpSpread1_Sheet1.Cells[i, 1].Text,
                            fpSpread1_Sheet1.Cells[i, 2].Text, this.GetArrayListProperty(), this.GetToolBar1String(), this.GetToolBar2String(), doc, node);
                        node.AppendChild(element1);
                    }
                }
            }
            else//单控件
            {
                XmlElement element1 = SaveControlXMLString(fpSpread1_Sheet1.Cells[0, 0].Text, fpSpread1_Sheet1.Cells[0, 1].Text, fpSpread1_Sheet1.Cells[0, 2].Text,
                           this.GetArrayListProperty(), this.GetToolBar1String(), this.GetToolBar2String(), doc, node);
                node.AppendChild(element1);
            }

            doc.AppendChild(node);
            return doc;
        }       

        #endregion

        #region 函数

        

        /// <summary>
        /// 显示工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            form.IsShowToolBar = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// 显示树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            form.IsShowTreeView = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// 显示状态条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
        {
            form.IsShowStatusBar = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// 用双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
        {
            form.IsDoubleSelectValue = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// 显示查找文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShowSearch_CheckedChanged(object sender, EventArgs e)
        {
            form.IsShowSearchTextBox = this.chkShowSearch.Checked;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.OnSave();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region 属性
        /// <summary>
        /// toolbar1
        /// </summary>
        public ArrayList AlTb1
        {
            get
            {
                ArrayList al1 = new ArrayList();
                foreach (ListViewItem lvItem in listView1.Items)
                {
                    al1.Add(lvItem.Text);
                }
                return al1;
            }
        }

        /// <summary>
        /// toolbar2
        /// </summary>
        public ArrayList AlTb2
        {
            get
            {
                ArrayList al2 = new ArrayList();
                foreach (ListViewItem lvItem in listView2.Items)
                {
                    al2.Add(lvItem.Text);
                }
                return al2;
            }
        }

        /// <summary>
        /// 图象大小
        /// </summary>
        public int ImageSize
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// 文本位置
        /// </summary>
        public int TextPosition
        {
            get
            {
                return 0;
            }
            set
            {
                
            }
        }

        /// <summary>
        /// 显示功能ToolBar
        /// </summary>
        public bool IsShowToolBar
        {
            get
            {
                return this.checkBox1.Checked;
            }
            set
            {
                this.checkBox1.Checked = value;
            }
        }
        /// <summary>
        /// 显示树
        /// </summary>
        public bool IsShowTreeView
        {
            get
            {
                return this.checkBox2.Checked;
            }
            set
            {
                this.checkBox2.Checked = value;
            }
        }
        /// <summary>
        /// 显示状态拦
        /// </summary>
        public bool IsShowStatusBar
        {
            get
            {
                return this.checkBox3.Checked;
            }
            set
            {
                this.checkBox3.Checked = value;
            }
        }
        /// <summary>
        /// 是否双击
        /// </summary>
        public bool IsDoubleSelectValue
        {
            get
            {
                return this.checkBox4.Checked;
            }
            set
            {
                this.checkBox4.Checked = value;
            }
        }
        /// <summary>
        /// 是否显示树查询
        /// </summary>
        public bool IsShowSearch
        {
            get
            {
                return this.chkShowSearch.Checked;
            }
            set
            {
                this.chkShowSearch.Checked = value;
            }
        }
        
        #endregion

        #region 菜单

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAddSplit_Click(object sender, EventArgs e)
        {
            if (this.listView1.Focused)
            {
                this.listView1.Items.Add("-".PadRight(15, ' '));
            }
            else if (this.listView2.Focused)
            {
                this.listView2.Items.Add("-".PadRight(15, ' '));
            }
        }

        private void mnuDelteSplit_Click(object sender, EventArgs e)
        {
            ListView ls = null;
            if (this.listView1.Focused)
            {
                ls = this.listView1;
            }
            else if (this.listView2.Focused)
            {
                ls = this.listView2;
            }
            if (ls.SelectedItems.Count <= 0) return;
            if (ls.SelectedItems[0].Text.Trim() == "-")
                ls.Items.Remove(ls.SelectedItems[0]);

        }

        private void mnuDelteClick(object sender, EventArgs e)
        {
            ListView ls = null;
            if (this.listView1.Focused)
            {
                ls = this.listView1;
            }
            else if (this.listView2.Focused)
            {
                ls = this.listView2;
            }
            if (ls.SelectedItems.Count <= 0) return;

            ls.Items.Remove(ls.SelectedItems[0]);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ListView ls = null;
            if (this.listView1.Focused)
            {
                ls = this.listView1;
            }
            else if (this.listView2.Focused)
            {
                ls = this.listView2;
            }
            if (ls.SelectedItems.Count <= 0) return;
            if (ls.SelectedItems[0].Text.Trim() == "-")
                this.mnuDelteSplit.Enabled = true;
            else
                this.mnuDelteSplit.Enabled = false;
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //第一个默认，不允许移动，删除
            if (this.fpSpread1_Sheet1.ActiveRowIndex <= 1) return;
            //old info
            int curRow = this.fpSpread1_Sheet1.ActiveRowIndex;
            string s1 = this.fpSpread1_Sheet1.Cells[curRow, 0].Text;
            string s2 = this.fpSpread1_Sheet1.Cells[curRow, 1].Text;
            string s3 = this.fpSpread1_Sheet1.Cells[curRow, 2].Text;
            object s4 = this.fpSpread1_Sheet1.Rows[curRow].Tag;


            this.fpSpread1_Sheet1.Cells[curRow, 0].Text = this.fpSpread1_Sheet1.Cells[curRow - 1, 0].Text;
            this.fpSpread1_Sheet1.Cells[curRow, 1].Text = this.fpSpread1_Sheet1.Cells[curRow - 1, 1].Text;
            this.fpSpread1_Sheet1.Cells[curRow, 2].Text = this.fpSpread1_Sheet1.Cells[curRow - 1, 2].Text;
            this.fpSpread1_Sheet1.Rows[curRow].Tag = this.fpSpread1_Sheet1.Rows[curRow - 1].Tag; ;

            this.fpSpread1_Sheet1.Cells[curRow - 1, 0].Text = s1;
            this.fpSpread1_Sheet1.Cells[curRow - 1, 1].Text = s2;
            this.fpSpread1_Sheet1.Cells[curRow - 1, 2].Text = s3;
            this.fpSpread1_Sheet1.Rows[curRow - 1].Tag = s4;
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //第一个默认，不允许移动，删除
            if (this.fpSpread1_Sheet1.ActiveRowIndex >= this.fpSpread1_Sheet1.RowCount - 1) return;
            if (this.fpSpread1_Sheet1.ActiveRowIndex == 0) return;

            //old info
            int curRow = this.fpSpread1_Sheet1.ActiveRowIndex;
            string s1 = this.fpSpread1_Sheet1.Cells[curRow, 0].Text;
            string s2 = this.fpSpread1_Sheet1.Cells[curRow, 1].Text;
            string s3 = this.fpSpread1_Sheet1.Cells[curRow, 2].Text;
            object s4 = this.fpSpread1_Sheet1.Rows[curRow].Tag;


            this.fpSpread1_Sheet1.Cells[curRow, 0].Text = this.fpSpread1_Sheet1.Cells[curRow + 1, 0].Text;
            this.fpSpread1_Sheet1.Cells[curRow, 1].Text = this.fpSpread1_Sheet1.Cells[curRow + 1, 1].Text;
            this.fpSpread1_Sheet1.Cells[curRow, 2].Text = this.fpSpread1_Sheet1.Cells[curRow + 1, 2].Text;
            this.fpSpread1_Sheet1.Rows[curRow].Tag = this.fpSpread1_Sheet1.Rows[curRow + 1].Tag; ;

            this.fpSpread1_Sheet1.Cells[curRow + 1, 0].Text = s1;
            this.fpSpread1_Sheet1.Cells[curRow + 1, 1].Text = s2;
            this.fpSpread1_Sheet1.Cells[curRow + 1, 2].Text = s3;
            this.fpSpread1_Sheet1.Rows[curRow + 1].Tag = s4;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //第一个默认，不允许移动，删除

            if (this.fpSpread1_Sheet1.ActiveRowIndex <= 0) return;

            this.fpSpread1_Sheet1.Rows.Remove(this.fpSpread1_Sheet1.ActiveRowIndex, 1);
        }       
        #endregion

        #region 函数
        /// <summary>
        /// 保存
        /// </summary>
        protected virtual void OnSave()
        {
            if (this.formID == "") return;

            //FormProperty obj = new FormProperty();
            //obj.Id = this.formID;
            //obj.IsTreeDoubleClick = this.IsDoubleSelectValue;
            //obj.IsShowStatusbar = this.IsShowStatusBar;
            //obj.IsShowToolbar = this.IsShowToolBar;
            //obj.IsShowTree = this.IsShowTreeView;
            //obj.ButtonTextPosition = this.TextPosition;
            //obj.IsShowSearch = this.IsShowSearch;

            NeuConfiguration configurationManagerEntity = new NeuConfiguration();
            configurationManagerEntity.Type=this.formType;
            configurationManagerEntity.ID=this.formID;
            configurationManagerEntity.IsValidState=true;
            //configurationManagerEntity.OperCode
            //configurationManagerEntity.OperDate

            this.AddTag();
            XmlDocument configXml=new XmlDocument();
            configXml= GetXML();
            configXml.DocumentElement.SetAttribute("IsTreeDoubleClick",NConvert.ToInt32(this.IsDoubleSelectValue).ToString());
            configXml.DocumentElement.SetAttribute("IsShowStatusbar",NConvert.ToInt32(this.IsShowStatusBar).ToString());
            configXml.DocumentElement.SetAttribute("IsShowToolbar",NConvert.ToInt32(this.IsShowToolBar).ToString());
            configXml.DocumentElement.SetAttribute("IsShowTree",NConvert.ToInt32(this.IsShowTreeView).ToString());
            configXml.DocumentElement.SetAttribute("ButtonTextPosition",this.TextPosition.ToString());
            configXml.DocumentElement.SetAttribute("IsShowSearch",NConvert.ToInt32(this.IsShowSearch).ToString());
            configurationManagerEntity.ConfigString = configXml.OuterXml;

            ConfigurationManager _proxy = Util.CreateProxy();
            using (_proxy as IDisposable)
            {
                try
                {
                    _proxy.Save(configurationManagerEntity);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "提示");
                    return;
                }
            }           

        }
        #endregion

        #region 事件
        /// <summary>
        /// 显示控件属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 3) //属性
            {
                string dllName = this.fpSpread1_Sheet1.Cells[e.Row, 0].Text;
                string controlName = this.fpSpread1_Sheet1.Cells[e.Row, 1].Text;

                if (dllName == "" || controlName == "") return;

                Control c = Util.CreateControl(dllName, controlName);
                if (c == null) return;

                Util.SetPropertyToControl(c, this.GetArrayListProperty());
                
                PropertyGrid property = new PropertyGrid();
                property.Text = "属性";
                property.SelectedObject = c;
                property.Size = new Size(200, 400);
                property.PropertyValueChanged += new PropertyValueChangedEventHandler(property_PropertyValueChanged);
                Util.PopShowControl(property);                
            }
        }

        /// <summary>
        /// 属性变动
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        void property_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            ListViewItem item = null;
            foreach (ListViewItem im in lsvProperty.Items)
            {
                if (im.SubItems[1].Text == e.ChangedItem.Label)
                {
                    item = im;
                    break;
                }
            }

            if (item ==null)
            {
                item = lsvProperty.Items.Add(e.ChangedItem.Label, e.ChangedItem.Label, 0);
            }
            item.SubItems.Clear();
            item.SubItems.Add(e.ChangedItem.Label);
            item.SubItems.Add(e.ChangedItem.Value.ToString());

            AddTag();
        }

        private void AddTag()
        {
            //ADD TO FPRowTag
            Dictionary<string,string> _keyPropertys = GetArrayListProperty();
            string toolBar1 = GetToolBar1String();
            string toolBar2 = GetToolBar2String();

            string dllname = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 0].Text;
            string controlname = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 1].Text;

            string name = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 2].Text;
            XmlDocument configXml = this.ConvertToSysControlString(dllname, controlname, name, _keyPropertys, toolBar1, toolBar2);

            this.fpSpread1_Sheet1.ActiveRow.Tag = configXml;
        }

        private string GetToolBar2String()
        {
            string toolBar2 = "";
            foreach (ListViewItem item in listView2.Items)
            {
                toolBar2 = toolBar2 + ";" + item.Text;
            }
            return toolBar2;
        }

        private string GetToolBar1String()
        {
            string toolBar1 = "";
            foreach (ListViewItem item in listView1.Items)
            {
                toolBar1 = toolBar1 + ";" + item.Text;
            }
            return toolBar1;
        }

        /// <summary>
        /// 获取控件属性
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetArrayListProperty()
        {
            Dictionary<string, string> _keyPropertys = new Dictionary<string, string>();
            foreach (ListViewItem item in lsvProperty.Items)
            {
                _keyPropertys.Add(item.SubItems[1].Text, item.SubItems[2].Text);                
            }
            return _keyPropertys;
        }

        /// <summary>
        /// 生成属性字符串
        /// </summary>
        /// <param name="propertys"></param>
        /// <returns></returns>
        public XmlDocument ConvertToSysControlString(string dllName,string controlName,string name,Dictionary<string,string> propertys,string toolbar1,string toolbar2)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement node = doc.CreateElement("Setting");
            XmlElement element1 = SaveControlXMLString(dllName, controlName,name, propertys, toolbar1, toolbar2, doc, node);
            node.AppendChild(element1);
            doc.AppendChild(node);
            return doc;
        }

        private  XmlElement SaveControlXMLString(string dllName, string controlName,string Name, Dictionary<string,string> propertys, string toolbar1, string toolbar2, XmlDocument doc, XmlElement node)
        {
            foreach (KeyValuePair<string,string> obj in propertys)
            {
                XmlElement element = doc.CreateElement("Control");
                element.SetAttribute("DllName", dllName);
                element.SetAttribute("ControlName", controlName);
                element.SetAttribute("Name", Name);
                element.SetAttribute("PropertyName", obj.Key);
                element.SetAttribute("PropertyValue", obj.Value);
                node.AppendChild(element);
            }

            XmlElement element1 = doc.CreateElement("ToolBar");
            element1.SetAttribute("DllName", dllName);
            element1.SetAttribute("ControlName", controlName);
            element1.SetAttribute("Name", Name);
            element1.SetAttribute("ToolBar1", toolbar1);
            element1.SetAttribute("ToolBar2", toolbar2);

            return element1;
        }
               

        /// <summary>
        /// 删除控件属性设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsvProperty_DoubleClick(object sender, EventArgs e)
        {
            if (lsvProperty.SelectedItems.Count <= 0) return;

            if (MessageBox.Show("是否要删除该属性?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            lsvProperty.Items.Remove(lsvProperty.SelectedItems[0]);
            this.AddTag();
        }

        private int _currentRowDoubleClicked = 0;

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (this.fpSpread1_Sheet1.ActiveRow == null) return;
                lsvProperty.Items.Clear();
                listView1.Items.Clear();
                listView2.Items.Clear();

                _currentRowDoubleClicked = e.Row;

                this.lblControlName.Text = this.fpSpread1_Sheet1.Cells[e.Row, 1].Text;

                XmlDocument xml = new XmlDocument();

                if (this.fpSpread1_Sheet1.ActiveRow.Tag != null)
                {
                    xml = this.fpSpread1_Sheet1.ActiveRow.Tag as XmlDocument;
                }
                 
                if (xml==null) return;

                string dllname = this.fpSpread1_Sheet1.Cells[e.Row, 0].Text;
                string controlname = this.fpSpread1_Sheet1.Cells[e.Row, 1].Text;

                ChangeControl(xml, dllname, controlname);          
                
                this.SetToolBar(dllname, controlname, xml);
            }
            catch { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AddTag();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == 0)
            {
                string dllname = this.fpSpread1_Sheet1.Cells[e.Row, 0].Text;

                if (dllname == "") return;
                try
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllname + ".dll");
                    Type[] type = assembly.GetTypes();
                    FarPoint.Win.Spread.CellType.ComboBoxCellType funCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    funCellType.Editable = false;

                    string[] ss = new string[type.Length+1];
                    
                    int i = 0;
                    foreach (Type mytype in type)
                    {
                        if (mytype.IsPublic && mytype.IsClass)
                        {
                            ss[i] = mytype.ToString();
                            i++;
                        }
                    }
                    ss[i] = "";
                    funCellType.Editable = true;
                    funCellType.Items = ss;
                    this.fpSpread1_Sheet1.Cells[e.Row,1].CellType = funCellType;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 重置工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.listView2.Items.Clear();

            foreach (ToolStripItem _item in _originalButtons)
            {
                this.AddToolBarButton(listView1, _item.Text, _item.ImageIndex);
            }

            try
            {
                Control _c = Util.CreateControl(this.fpSpread1_Sheet1.GetText(_currentRowDoubleClicked, 0), this.fpSpread1_Sheet1.GetText(_currentRowDoubleClicked, 1));
                if (_c == null) return;

                IOperation _operation = _c as IOperation;
                if (_operation == null) return;

                Neusoft.NFC.Interface.Forms.ToolBarService _service = _operation.Init(null, null, null);

                ArrayList _buttons = _service.GetToolButtons();
                foreach (ToolStripButton _button in _buttons)
                {
                    this.AddToolBarButton(listView2, _button.Text, _button.ImageIndex);
                }
            }
            catch { }
        }

        /// <summary>
        /// 单控件的属性添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProperty_Click(object sender, EventArgs e)
        {
            if (this.currentDefaultControl == null) return;
            Control c = this.currentDefaultControl;

            Util.SetPropertyToControl(c, this.GetArrayListProperty());
            if (c == null) return;

            PropertyGrid property = new PropertyGrid();
            property.SelectedObject = c;
            property.Text = "属性";
            property.Size = new Size(200, 400);
            property.PropertyValueChanged += new PropertyValueChangedEventHandler(property_PropertyValueChanged);
            Util.PopShowControl(property);                
        }
        #endregion

        /// <summary>
        /// 为当前的窗体设置默认值
        /// A9D33964-33F0-4bfd-B28E-EBC425F97C99
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.formID == "") return;

            ConfigurationManager _proxy = Util.CreateProxy();
            NeuConfiguration configurationManagerEntity = new NeuConfiguration();

            using (_proxy as IDisposable)
            {
                configurationManagerEntity.ID = _proxy.GetResourceId(this.formID);
                if (String.IsNullOrEmpty(configurationManagerEntity.ID))
                {
                    return;
                }
            }     

            configurationManagerEntity.Type = "FormSettingDefault";
            configurationManagerEntity.IsValidState = true;

            this.AddTag();
            XmlDocument configXml = new XmlDocument();
            configXml = GetXML();
            configXml.DocumentElement.SetAttribute("IsTreeDoubleClick", NConvert.ToInt32(this.IsDoubleSelectValue).ToString());
            configXml.DocumentElement.SetAttribute("IsShowStatusbar", NConvert.ToInt32(this.IsShowStatusBar).ToString());
            configXml.DocumentElement.SetAttribute("IsShowToolbar", NConvert.ToInt32(this.IsShowToolBar).ToString());
            configXml.DocumentElement.SetAttribute("IsShowTree", NConvert.ToInt32(this.IsShowTreeView).ToString());
            configXml.DocumentElement.SetAttribute("ButtonTextPosition", this.TextPosition.ToString());
            configXml.DocumentElement.SetAttribute("IsShowSearch", NConvert.ToInt32(this.IsShowSearch).ToString());
            configurationManagerEntity.ConfigString = configXml.OuterXml;

            using (_proxy as IDisposable)
            {
                try
                {
                    _proxy.Save(configurationManagerEntity);
                    MessageBox.Show("保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                    return;
                }
            }           
        }
    }
}
