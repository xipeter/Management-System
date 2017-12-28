using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Neusoft.FrameWork.WinForms.Forms
{
    /// <summary>
    /// frmSetButton 的摘要说明。
    /// </summary>
    internal class frmSetButton : BaseForm
    {
        protected Label label1;
        protected DragAndDropListView listView1;
        protected DragAndDropListView listView2;
        protected Label lblControlName;
        protected Button button1;
        protected ToolTip toolTip = new ToolTip();
        protected TabControl tabControl1;
        protected TabPage tabPage1;
        protected TabPage tabPage2;
        protected CheckBox checkBox1;
        protected CheckBox checkBox2;
        protected CheckBox checkBox3;
        protected CheckBox checkBox4;
        private IContainer components;
        protected TabPage tabPage3;
        protected ComboBox comboBox1;
        protected Label label2;
        protected ComboBox comboBox2;
        protected Label label3;
        protected FarPoint.Win.Spread.FpSpread fpSpread1;
        protected FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem tbVisible;
        protected ToolStripMenuItem mnuAddSplit;
        protected ToolStripMenuItem mnuDelteSplit;
        protected Button button2;
        private Splitter splitter1;
        protected ListView lsvProperty;
        protected ColumnHeader columnName;
        protected ColumnHeader columnValue;
        private ColumnHeader columnHeader1;
        private Neusoft.FrameWork.WinForms.Controls.NeuButton neuButton1;
        private ToolStripMenuItem mnuDelete;
        private Button btnProperty;
        private Neusoft.FrameWork.WinForms.Controls.NeuCheckBox chkReset;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem upToolStripMenuItem;
        private ToolStripMenuItem downToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        protected CheckBox chkShowSearch;
        private TabPage tabPage4;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread neuSpread1;
        private FarPoint.Win.Spread.SheetView neuSpread1_Sheet1;

        private frmBaseForm form = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="tb1"></param>
        /// <param name="tb2"></param>
        /// <param name="controlText"></param>
        public frmSetButton(frmBaseForm sender, ToolStrip tb1, ToolStrip tb2, string controlText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.SetTabControlStyle(tabControl1);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(this.fpSpread1);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(this.neuSpread1);
            Neusoft.FrameWork.WinForms.Classes.Function.SetListViewStyle(this.lsvProperty as ListView);

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            this.init(tb1, tb2, controlText);//初始化ToolBar
            this.form = sender;//窗口了，没用事件，比较懒

            ImageList imagelist = new ImageList();

            int max = Enum.GetValues(typeof(Neusoft.FrameWork.WinForms.Classes.EnumImageList)).Length;
            int index = 0;
            string[] icons = new string[max];
            for (index = 0; index < icons.Length; index++)
            {
                imagelist.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage((Neusoft.FrameWork.WinForms.Classes.EnumImageList)index));
            }
            this.listView1.SmallImageList = imagelist;
            this.listView2.SmallImageList = imagelist;
            this.listView1.LargeImageList = imagelist;
            this.listView2.LargeImageList = imagelist;
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.label1 = new System.Windows.Forms.Label();
            this.lblControlName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkShowSearch = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnProperty = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lsvProperty = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnValue = new System.Windows.Forms.ColumnHeader();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkReset = new Neusoft.FrameWork.WinForms.Controls.NeuCheckBox();
            this.listView1 = new Neusoft.FrameWork.WinForms.Forms.DragAndDropListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelteSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.listView2 = new Neusoft.FrameWork.WinForms.Forms.DragAndDropListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.neuSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.neuSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.button2 = new System.Windows.Forms.Button();
            this.neuButton1 = new Neusoft.FrameWork.WinForms.Controls.NeuButton();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前控件：";
            // 
            // lblControlName
            // 
            this.lblControlName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblControlName.Location = new System.Drawing.Point(80, 8);
            this.lblControlName.Name = "lblControlName";
            this.lblControlName.Size = new System.Drawing.Size(333, 24);
            this.lblControlName.TabIndex = 3;
            this.lblControlName.Text = "无控件加载";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(271, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定(&O)";
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
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(8, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 408);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkShowSearch);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.checkBox4);
            this.tabPage2.Controls.Add(this.checkBox3);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(425, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "显示";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkShowSearch
            // 
            this.chkShowSearch.Checked = true;
            this.chkShowSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowSearch.Location = new System.Drawing.Point(80, 168);
            this.chkShowSearch.Name = "chkShowSearch";
            this.chkShowSearch.Size = new System.Drawing.Size(168, 24);
            this.chkShowSearch.TabIndex = 8;
            this.chkShowSearch.Text = "显示树查询";
            this.chkShowSearch.CheckedChanged += new System.EventHandler(this.chkShowSearch_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "在下",
            "在右"});
            this.comboBox2.Location = new System.Drawing.Point(165, 142);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 20);
            this.comboBox2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "文字位置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "图象大小：";
            this.label2.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "16",
            "24",
            "36"});
            this.comboBox1.Location = new System.Drawing.Point(165, 345);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(53, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Visible = false;
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
            this.tabPage3.Size = new System.Drawing.Size(425, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "系统控件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnProperty
            // 
            this.btnProperty.Location = new System.Drawing.Point(350, 357);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new System.Drawing.Size(75, 23);
            this.btnProperty.TabIndex = 3;
            this.btnProperty.Text = "属性";
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
            this.lsvProperty.Size = new System.Drawing.Size(425, 157);
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
            this.fpSpread1.About = "3.0.2004.2005";
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
            this.contextMenuStrip2.Size = new System.Drawing.Size(107, 70);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.upToolStripMenuItem.Text = "Up";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.downToolStripMenuItem.Text = "Down";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
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
            this.fpSpread1_Sheet1.RowCount = 20;
            this.fpSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "DLL名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "控件名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "名称";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "属性";
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "DLL名称";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 93F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "控件名称";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 168F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "属性...";
            this.fpSpread1_Sheet1.Columns.Get(3).CellType = buttonCellType1;
            this.fpSpread1_Sheet1.Columns.Get(3).Label = "属性";
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.White;
            this.fpSpread1_Sheet1.SheetCornerStyle.Locked = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.fpSpread1_Sheet1_CellChanged);
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkReset);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.listView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(425, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工具栏";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkReset
            // 
            this.chkReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReset.AutoSize = true;
            this.chkReset.Checked = true;
            this.chkReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReset.Location = new System.Drawing.Point(329, 364);
            this.chkReset.Name = "chkReset";
            this.chkReset.Size = new System.Drawing.Size(72, 16);
            this.chkReset.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.chkReset.TabIndex = 3;
            this.chkReset.Text = "应用切换";
            this.chkReset.UseVisualStyleBackColor = true;
            this.chkReset.CheckedChanged += new System.EventHandler(this.chkReset_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.AllowReorder = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.HideSelection = false;
            this.listView1.LineColor = System.Drawing.Color.Red;
            this.listView1.Location = new System.Drawing.Point(8, 8);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(189, 352);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbVisible,
            this.mnuAddSplit,
            this.mnuDelteSplit,
            this.mnuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tbVisible
            // 
            this.tbVisible.Name = "tbVisible";
            this.tbVisible.Size = new System.Drawing.Size(136, 22);
            this.tbVisible.Text = "显示/不显示";
            this.tbVisible.Click += new System.EventHandler(this.tbVisible_Click);
            // 
            // mnuAddSplit
            // 
            this.mnuAddSplit.Name = "mnuAddSplit";
            this.mnuAddSplit.Size = new System.Drawing.Size(136, 22);
            this.mnuAddSplit.Text = "添加分隔符";
            this.mnuAddSplit.Click += new System.EventHandler(this.mnuAddSplit_Click);
            // 
            // mnuDelteSplit
            // 
            this.mnuDelteSplit.Name = "mnuDelteSplit";
            this.mnuDelteSplit.Size = new System.Drawing.Size(136, 22);
            this.mnuDelteSplit.Text = "删除分割符";
            this.mnuDelteSplit.Click += new System.EventHandler(this.mnuDelteSplit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(136, 22);
            this.mnuDelete.Text = "删除";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelteClick);
            // 
            // listView2
            // 
            this.listView2.AllowDrop = true;
            this.listView2.AllowReorder = true;
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.LineColor = System.Drawing.Color.Red;
            this.listView2.Location = new System.Drawing.Point(214, 8);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(187, 352);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.neuSpread1);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(425, 383);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "快捷键";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.neuSpread1.Location = new System.Drawing.Point(0, 0);
            this.neuSpread1.Name = "neuSpread1";
            this.neuSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.neuSpread1_Sheet1});
            this.neuSpread1.Size = new System.Drawing.Size(425, 383);
            this.neuSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuSpread1.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.neuSpread1.TextTipAppearance = tipAppearance2;
            this.neuSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.neuSpread1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.neuSpread1_KeyDown);
            // 
            // neuSpread1_Sheet1
            // 
            this.neuSpread1_Sheet1.Reset();
            this.neuSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.neuSpread1_Sheet1.ColumnCount = 3;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "菜单名称";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "组合键";
            this.neuSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "快捷键";
            this.neuSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Label = "菜单名称";
            this.neuSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(0).Width = 177F;
            this.neuSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.neuSpread1_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(1).Label = "组合键";
            this.neuSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(1).Width = 90F;
            this.neuSpread1_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.neuSpread1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(2).Label = "快捷键";
            this.neuSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Columns.Get(2).Width = 90F;
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.neuSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.neuSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.neuSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.neuSpread1.SetActiveViewport(0, 1, 0);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(368, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消(&C)";
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // neuButton1
            // 
            this.neuButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.neuButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuButton1.Location = new System.Drawing.Point(12, 446);
            this.neuButton1.Name = "neuButton1";
            this.neuButton1.Size = new System.Drawing.Size(75, 23);
            this.neuButton1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuButton1.TabIndex = 8;
            this.neuButton1.Text = "重置工具栏";
            this.neuButton1.Type = Neusoft.FrameWork.WinForms.Controls.General.ButtonType.None;
            this.neuButton1.UseVisualStyleBackColor = true;
            this.neuButton1.Click += new System.EventHandler(this.neuButton1_Click);
            // 
            // frmSetButton
            // 
            this.ClientSize = new System.Drawing.Size(453, 488);
            this.Controls.Add(this.neuButton1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblControlName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmSetButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置工具栏";
            this.Load += new System.EventHandler(this.frmSetButton_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private string formID = "";
        public Control currentDefaultControl = null;

        #region 初始化
        /// <summary>
        /// 初始化窗口拥有的控件
        /// </summary>
        /// <param name="formID"></param>
        public virtual void InitControl(string formID)
        {
            
            this.formID = formID;
            if (formID == "") return;
            Neusoft.HISFC.BizLogic.Admin.FunSetting manager = new Neusoft.HISFC.BizLogic.Admin.FunSetting();
            Neusoft.HISFC.Models.Admin.FunSetting obj = manager.GetFunSetting(formID);
            if (obj == null)
                return;
            this.SetControl(obj.ControlXML, obj.IsShowToolBar, obj.IsShowTreeView, obj.IsShowStatusBar, obj.IsDoubleClick, obj.TextPosition,obj.IsShowSearch);
        }

        /// <summary>
        /// 初始化farpoint,屏蔽一些热键
        /// </summary>
        private void InitFp()
        {
            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
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
        /// 设置控件
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="isShowToolBar"></param>
        /// <param name="isShowTree"></param>
        /// <param name="isShowStatusBar"></param>
        /// <param name="isDoubleClick"></param>
        /// <param name="textPosition"></param>
        public virtual void SetControl(string xml, bool isShowToolBar, bool isShowTree, bool isShowStatusBar, bool isDoubleClick, int textPosition,bool isShowSearch)
        {
            this.IsShowStatusBar = isShowStatusBar;
            this.IsShowToolBar = isShowToolBar;
            this.IsShowTreeView = isShowTree;
            this.IsDoubleSelectValue = isDoubleClick;
            this.TextPosition = textPosition;
            this.IsShowSearch = isShowSearch;
            this.SetControl(xml);
        }
        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="xml"></param>
        public virtual void SetControl(string xml)
        {
            if(xml == "") return;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch { }
            try
            {
                XmlNodeList nodes = doc.SelectNodes("//Setting/ToolBar");
                string dllName = "", controlName = "";
                int i = 0;
                this.fpSpread1_Sheet1.RowCount = 0;
                this.fpSpread1_Sheet1.RowCount = 20;
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["DllName"].Value != dllName ||
                       node.Attributes["ControlName"].Value != controlName)
                    {
                        dllName = node.Attributes["DllName"].Value;
                        controlName = node.Attributes["ControlName"].Value;

                        if (dllName == "default" && controlName == "default")//默认控件
                        {
                           
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.Cells[i, 0].Text = dllName;
                            this.fpSpread1_Sheet1.Cells[i, 1].Text = controlName;
                            this.fpSpread1_Sheet1.Cells[i, 2].Text = node.Attributes["Name"].Value;
                            this.fpSpread1_Sheet1.Rows[i].Tag = xml;
                        }
                        if (i == 0)
                        {
                            if (xml == "") return;
                            this.lblControlName.Text = controlName;
                            ChangeControl(xml, dllName, controlName);
                            
                        }
                        i++;

                    }
                }
            }
            catch { }
           
        }

        /// <summary>
        /// 获得当前Control XMLString
        /// </summary>
        /// <returns></returns>
        public virtual string GetXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement node = doc.CreateElement("Setting");
            if (this.isOneControl== false)//多控件
            {
                for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                {
                    if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim() != "" || fpSpread1_Sheet1.Cells[i, 1].Text.Trim() != "")
                    {
                        string xml = "";
                        if (fpSpread1_Sheet1.Rows[i].Tag == null)
                            xml = "";
                        else
                            xml = fpSpread1_Sheet1.Rows[i].Tag.ToString();
                        ChangeControl(xml, fpSpread1_Sheet1.Cells[i, 0].Text, fpSpread1_Sheet1.Cells[i, 1].Text);
                        XmlElement element1 = SaveControlXMLString(fpSpread1_Sheet1.Cells[i, 0].Text, fpSpread1_Sheet1.Cells[i, 1].Text,
                            fpSpread1_Sheet1.Cells[i, 2].Text, this.GetArrayListProperty(), this.GetToolBar1String(), this.GetToolBar2String(), doc, node);
                        node.AppendChild(element1);
                    }
                }
            }
            else//单控件
            {
                XmlElement element1 = SaveControlXMLString("default", "default","",
                           this.GetArrayListProperty(), this.GetToolBar1String(), this.GetToolBar2String(), doc, node);
                node.AppendChild(element1);
            }
            doc.AppendChild(node);
            return doc.OuterXml;
        }

        /// <summary>
        /// 获得XML
        /// </summary>
        /// <returns></returns>
        public virtual string GetXMLWithOutXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement node = doc.CreateElement("Setting");
            if (this.tabControl1.TabPages.Count == 4)
            {
                for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                {
                    if (fpSpread1_Sheet1.Cells[i, 0].Text.Trim() != "" || fpSpread1_Sheet1.Cells[i, 1].Text.Trim() != "")
                    {
                        string xml = "";
                        if (fpSpread1_Sheet1.Rows[i].Tag == null)
                            xml = "";
                        else
                            xml = fpSpread1_Sheet1.Rows[i].Tag.ToString();
                        ChangeControl(xml, fpSpread1_Sheet1.Cells[i, 0].Text, fpSpread1_Sheet1.Cells[i, 1].Text);
                        SaveControlXMLStringWithOutToolBar(fpSpread1_Sheet1.Cells[i, 0].Text, fpSpread1_Sheet1.Cells[i, 1].Text,
                            fpSpread1_Sheet1.Cells[i, 2].Text, this.GetArrayListProperty(), doc, node);
                        
                    }
                }
            }
            else
            {
                SaveControlXMLStringWithOutToolBar("default", "default", "",
                           this.GetArrayListProperty(), doc, node);
            }
            doc.AppendChild(node);
            return doc.OuterXml;
        }

        private ToolStrip toolbar = null;
        private void init(ToolStrip tb1, ToolStrip tb2, string controlText)
        {
            this.listView1.Clear();
            this.listView2.Clear();
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView2.View = System.Windows.Forms.View.List;

            this.listView1.MultiSelect = false;
            this.listView2.MultiSelect = false;

            this.listView1.SmallImageList = tb1.ImageList;
            this.listView2.SmallImageList = tb2.ImageList;

            toolbar = tb1;
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

        #endregion

        #region 函数

        protected virtual void AddToolBarButton(ListView listView, string text, int imageIndex)
        {
            if (text == "") text = "-";
            ListViewItem lstItem = new ListViewItem(text.PadRight(15, ' '), imageIndex);
            
            listView.Items.Add(lstItem);
        }

        private void frmSetButton_Load(object sender, System.EventArgs e)
        {
            this.checkBox1.Checked = form.IsShowToolBar;
            this.checkBox2.Checked = form.IsShowTreeView;
            this.checkBox3.Checked = form.IsShowStatusBar;
            this.checkBox4.Checked = form.IsDoubleSelectValue;
            this.chkShowSearch.Checked = form.IsShowSearchTextBox;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox1.SelectedIndex = 0;
            InitFp();
        }


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

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.OnSave();
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

                //快捷键
                string tempText = string.Empty;
                string controlKey = string.Empty;
                string zhKey = string.Empty;
                string text = string.Empty;
                for (int k = 0; k < al1.Count; k++)
                {
                    text = al1[k].ToString().Trim();
                    for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                    {
                        tempText = this.neuSpread1_Sheet1.Cells[i, 0].Text.Trim();
                        if (text == tempText)
                        {
                            zhKey = this.neuSpread1_Sheet1.Cells[i, 1].Text.Trim();
                            controlKey = this.neuSpread1_Sheet1.Cells[i, 2].Text.Trim();
                            if (zhKey == string.Empty && controlKey != string.Empty)
                            {
                                al1[k] = tempText + "(" + controlKey + ")";
                            }
                            else if (zhKey != string.Empty && controlKey != string.Empty)
                            {
                                al1[k] = tempText + "(" + zhKey + "+" + controlKey + ")";
                            }
                            break;
                        }
                    }
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
                return int.Parse(this.comboBox1.Text);
            }
        }

        /// <summary>
        /// 文本位置
        /// </summary>
        public int TextPosition
        {
            get
            {
                return (this.comboBox2.SelectedIndex);
            }
            set
            {
                this.comboBox2.SelectedIndex = value;
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
        private void tbVisible_Click(object sender, EventArgs e)
        {
            if (this.listView1.Focused)
            {
                this.SetVisible(this.listView1);
            }
            else if (this.listView2.Focused)
            {
                this.SetVisible(this.listView2);
            }
        }

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

        private void SetVisible(ListView ls)
        {
            if (ls.SelectedItems.Count <= 0) return;
            if (ls.SelectedItems[0].ForeColor == Color.Red)
            {
                ls.SelectedItems[0].ForeColor = Color.Black;
            }
            else
            {
                ls.SelectedItems[0].ForeColor = Color.Red;
            }
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
        #endregion

        #region 函数
        /// <summary>
        /// 保存
        /// </summary>
        protected virtual void OnSave()
        {
            if (this.formID == "") return;
            if (!IsValid())
            {
                MessageBox.Show("快捷键不能重复！");
                return;
            }
            Neusoft.HISFC.Models.Admin.FunSetting obj = new Neusoft.HISFC.Models.Admin.FunSetting();
            obj.ID = this.formID;
            obj.IsDoubleClick = this.IsDoubleSelectValue;
            obj.IsShowStatusBar = this.IsShowStatusBar;
            obj.IsShowToolBar = this.IsShowToolBar;
            obj.IsShowTreeView = this.IsShowTreeView;
            obj.TextPosition = this.TextPosition;
            obj.IsShowSearch = this.IsShowSearch;
            this.AddTag();
            obj.ControlXML = this.GetXML();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Admin.FunSetting manager = new Neusoft.HISFC.BizLogic.Admin.FunSetting();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //manager.SetTrans(t.Trans);
            if (manager.SetFunSetting(obj) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(manager.Err);
                return;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region 事件
        private void fpSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 3) //属性
            {
                string dllName = this.fpSpread1_Sheet1.Cells[e.Row, 0].Text;
                string controlName = this.fpSpread1_Sheet1.Cells[e.Row, 1].Text;
                if (dllName == "" || controlName == "") return;
                Control c = Classes.Function.CreateControl(dllName, controlName);
                Classes.Function.SetPropertyToControl(c, this.GetArrayListProperty());
                if (c == null) return;
                PropertyGrid property = new PropertyGrid();
                property.SelectedObject = c;
                property.Size = new Size(200, 400);
                property.PropertyValueChanged += new PropertyValueChangedEventHandler(property_PropertyValueChanged);
                Classes.Function.PopShowControl(property);
                
            }
        }

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
            ArrayList al = GetArrayListProperty();
            string toolBar1 = GetToolBar1String();
            string toolBar2 = GetToolBar2String();
            string dllname = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 0].Text;
            string controlname = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 1].Text;
            string name = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 2].Text;
            string xml = this.ConvertToSysControlString(dllname,controlname,name,al,toolBar1,toolBar2);
            this.fpSpread1_Sheet1.ActiveRow.Tag = xml;
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
            string text = string.Empty;
            string tempText=string.Empty;
            string zhKey = string.Empty;
            string controlKey = string.Empty;
            foreach (ListViewItem item in listView1.Items)
            {
                //===============快捷键
                text = item.Text;
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    tempText = this.neuSpread1_Sheet1.Cells[i, 0].Text.Trim();
                    if (text == tempText)
                    {
                        zhKey = this.neuSpread1_Sheet1.Cells[i, 1].Text.Trim();
                        controlKey = this.neuSpread1_Sheet1.Cells[i, 2].Text.Trim();
                        if (zhKey == string.Empty && controlKey!=string.Empty)
                        {
                            text += "(" + controlKey + ")";
                        }
                        if (zhKey != string.Empty && controlKey != string.Empty)
                        {
                            text += "(" + zhKey + "+" + controlKey + ")";
                        }
                        break;
                    }
                }
                toolBar1 = toolBar1 + ";" + text;
                //==================

                //toolBar1 = toolBar1 + ";" + item.Text;
            }
            return toolBar1;
        }

        private ArrayList GetArrayListProperty()
        {
            ArrayList al = new ArrayList();
            foreach (ListViewItem item in lsvProperty.Items)
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = item.SubItems[1].Text;
                obj.Name = item.SubItems[2].Text;
                al.Add(obj);
            }
            return al;
        }

        /// <summary>
        /// 生成属性字符串
        /// </summary>
        /// <param name="propertys"></param>
        /// <returns></returns>
        public string ConvertToSysControlString(string dllName,string controlName,string name,ArrayList propertys,string toolbar1,string toolbar2)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement node = doc.CreateElement("Setting");
            XmlElement element1 = SaveControlXMLString(dllName, controlName,name, propertys, toolbar1, toolbar2, doc, node);
            node.AppendChild(element1);
            doc.AppendChild(node);
            return doc.OuterXml;
        }

        private  XmlElement SaveControlXMLString(string dllName, string controlName,string Name, ArrayList propertys, string toolbar1, string toolbar2, XmlDocument doc, XmlElement node)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in propertys)
            {
                XmlElement element = doc.CreateElement("Control");
                element.SetAttribute("DllName", dllName);
                element.SetAttribute("ControlName", controlName);
                element.SetAttribute("Name", Name);
                element.SetAttribute("PropertyName", obj.ID);
                element.SetAttribute("PropertyValue", obj.Name);
                node.AppendChild(element);
            }
            XmlElement element1 = doc.CreateElement("ToolBar");
            element1.SetAttribute("DllName", dllName);
            element1.SetAttribute("ControlName", controlName);
            element1.SetAttribute("Name", Name);
            element1.SetAttribute("ToolBar1", toolbar1);
            element1.SetAttribute("ToolBar2", toolbar2);
            element1.SetAttribute("Reset",chkReset.Checked.ToString());
            return element1;
        }

        private  void SaveControlXMLStringWithOutToolBar(string dllName, string controlName, string Name, ArrayList propertys, XmlDocument doc, XmlElement node)
        {
            if (propertys.Count == 0)
            {
                XmlElement element = doc.CreateElement("ToolBar");
                element.SetAttribute("DllName", dllName);
                element.SetAttribute("ControlName", controlName);
                element.SetAttribute("Name", Name);
                element.SetAttribute("ToolBar1", "");
                element.SetAttribute("ToolBar2", "");
                element.SetAttribute("Reset", chkReset.Checked.ToString());
                node.AppendChild(element);
            }
            foreach (Neusoft.FrameWork.Models.NeuObject obj in propertys)
            {
                XmlElement element = doc.CreateElement("Control");
                element.SetAttribute("DllName", dllName);
                element.SetAttribute("ControlName", controlName);
                element.SetAttribute("Name", Name);
                element.SetAttribute("PropertyName", obj.ID);
                element.SetAttribute("PropertyValue", obj.Name);
                node.AppendChild(element);
            }
     
            return ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="controlName"></param>
        /// <param name="propXML"></param>
        /// <returns></returns>
        public ArrayList ConvertToSysControlList(string dllName,string controlName,string propXML)
        {
            if (propXML.Trim() == "") return null;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(propXML);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            XmlNodeList nodes =  doc.SelectNodes("//Setting/Control");
            ArrayList al = new ArrayList();
            foreach(XmlNode node in nodes)
            {
                if(node.Attributes["DllName"].Value == dllName &&
                    node.Attributes["ControlName"].Value == controlName)
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = node.Attributes["PropertyName"].Value;
                    obj.Name = node.Attributes["PropertyValue"].Value;
                    al.Add(obj);
                }
            }
            SetToolBar(dllName, controlName, doc);
           
            
            return al;
        }

        /// <summary>
        /// 根据菜单名称将组合键和快捷键分开
        /// </summary>
        /// <param name="menuName">菜单名称</param>
        /// <returns>Neuobj:ID菜单名称,Name组合键 Memo快键键</returns>
        private Neusoft.FrameWork.Models.NeuObject GetMenuKey(string menuName)
        {
            int index = 0;
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            index = menuName.IndexOf('(');
            if (index < 0)
            {
                obj.ID = menuName;
            }
            else
            {
                obj.ID = menuName.Substring(0, index);

                string text = menuName.Substring(index + 1, menuName.IndexOf(')')-index-1);
                if (text == "+")
                {
                    //快键键
                    obj.Memo = text;
                    return obj;
                }
                int pos = menuName.IndexOf('+');
                //是否含有组合键
                if (pos > 0)
                {
                    string[] ss = text.Split('+');
                    //组合键
                    obj.Name = ss[0];
                    //快键键
                    obj.Memo = ss[1];
                }
                else
                {
                    //快键键
                    obj.Memo = text;
                }
            }
            return obj;
        }

        private void SetToolBar(string dllName, string controlName, XmlDocument doc)
        {
            XmlNodeList nodeToolBars = doc.SelectNodes("//Setting/ToolBar");
            Neusoft.FrameWork.Models.NeuObject obj = null; 
            foreach (XmlNode node in nodeToolBars)
            {
                if (node.Attributes["DllName"].Value == dllName &&
                    node.Attributes["ControlName"].Value == controlName)
                {
                    this.listView1.Items.Clear();
                    this.listView2.Items.Clear();
                    this.neuSpread1_Sheet1.Rows.Remove(0, this.neuSpread1_Sheet1.Rows.Count);
                    string[] ss = node.Attributes["ToolBar1"].Value.Split(';');
                    for (int i = 1; i < ss.Length; i++)
                    {
                        //====================显示菜单快捷键
                        this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);
                        obj = GetMenuKey(ss[i].Trim());
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 0].Text = obj.ID;
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 0].Tag = dllName;
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 1].Text = obj.Name;
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 1].Tag = controlName;
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 2].Text = obj.Memo;
                        this.listView1.Items.Add(obj.ID);
                        //=====================
                        //this.listView1.Items.Add(ss[i]);
                    }



                    ss = node.Attributes["ToolBar2"].Value.Split(';');
                    for (int i = 1; i < ss.Length; i++)
                    {
                        this.listView2.Items.Add(ss[i]);
                    }
                    try
                    {
                        this.chkReset.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["Reset"].Value);
                    }
                    catch { }
                }
            }
            try
            {
                if (dllName == "default" && controlName == "default") return;
                Control c = Classes.Function.CreateControl(dllName, controlName);
                IControlable ic = c as IControlable;
                if (ic == null) return;
                //toolbar变化
                ToolBarService toolBarService = ic.Init(null, null, "");
                
                foreach (ToolStripItem button in this.toolbar.Items)
                {
                    if (button.Tag.ToString() == "Default")
                    {
                        obj = GetMenuKey(button.Text.Trim());
                        //if(IsHaveToolBar(button.Text) == false)
                        if (IsHaveToolBar(obj.ID) == false)
                        {
                            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);
                            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 0].Text = obj.ID;
                            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 0].Tag = dllName;
                            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 1].Text = obj.Name;
                            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 1].Tag = controlName;
                            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.Rows.Count - 1, 2].Text = obj.Memo;
                            this.listView1.Items.Add(obj.ID, button.ImageIndex);
                            //this.listView1.Items.Add(button.Text, button.ImageIndex);
                        }
                    }
                }
                ArrayList al = toolBarService.GetToolButtons();
                foreach (ToolStripButton button in al)
                {
                    
                    if (IsHaveToolBar(button.Text) == false)
                    {
                        this.listView2.Items.Add(button.Text, button.ImageIndex);
                    }
                }
            }
            catch { }
        }
       
        /// <summary>
        /// 设置Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string dllname = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 0].Text;
            string controlname = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 1].Text;
            Control c = Classes.Function.CreateControl(dllname, controlname);
            if (c == null) return;
            
            ArrayList al = new ArrayList();
            foreach (ListViewItem item in lsvProperty.Items)
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = item.SubItems[1].Text;
                obj.Name = item.SubItems[2].Text;
                al.Add(obj);
            }
            Classes.Function.SetPropertyToControl(c, al);
            if (c == null) return;
            PropertyGrid property = new PropertyGrid();
            property.SelectedObject = c;
            property.Size = new Size(200, 400);
            Classes.Function.PopShowControl(property);


        }

        private void lsvProperty_DoubleClick(object sender, EventArgs e)
        {
            if (lsvProperty.SelectedItems.Count <= 0) return;
            lsvProperty.Items.Remove(lsvProperty.SelectedItems[0]);
            this.AddTag();
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (this.fpSpread1_Sheet1.ActiveRow == null) return;
                this.lblControlName.Text = this.fpSpread1_Sheet1.Cells[e.Row, 1].Text;
                if (this.fpSpread1_Sheet1.ActiveRow.Tag == null)
                {
                    lsvProperty.Items.Clear();
                    return;
                }
                string xml = this.fpSpread1_Sheet1.ActiveRow.Tag.ToString();
                if (xml == "") return;
                string dllname = this.fpSpread1_Sheet1.Cells[e.Row, 0].Text;
                string controlname = this.fpSpread1_Sheet1.Cells[e.Row, 1].Text;
                ChangeControl(xml, dllname, controlname);
          
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                if (doc == null) return;
                this.SetToolBar(dllname, controlname, doc);
            }
            catch { }

        }

        private void ChangeControl(string xml, string dllname, string controlname)
        {
            ArrayList al = this.ConvertToSysControlList(dllname, controlname, xml);
            lsvProperty.Items.Clear();
            if (al == null) return;
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                ListViewItem item = new ListViewItem(obj.ID);
                item.SubItems.Clear();
                item.SubItems.Add(obj.ID);
                item.SubItems.Add(obj.Name);
                lsvProperty.Items.Add(item);
            }

            
            
        }

        private bool IsHaveToolBar(string text)
        {
            if (text.Trim() == "") return true;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == text) return true;
            }
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.Text == text) return true;
            }
            return false;
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
        /// 验证录入是否合法
        /// </summary>
        /// <param name="beginRow">开始验证的行数</param>
        /// <returns>false不合法 true合法</returns>
        public bool IsValid()
        {
            string zhKey = string.Empty;
            string controlKey = string.Empty;
            Hashtable hsTable = new Hashtable();
            KeysConverter kc = new KeysConverter();
            int hasValue = 0, controlValue = 0, finValue = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                hasValue = 0;
                controlValue = 0;
                finValue = 0;
                zhKey = this.neuSpread1_Sheet1.Cells[i, 1].Text;
                controlKey = this.neuSpread1_Sheet1.Cells[i, 2].Text;
                if (zhKey == string.Empty && controlKey != string.Empty)
                {
                    if (controlKey == "+")
                    {
                        controlKey = "Add";
                    }
                    if (controlKey == "-")
                    {
                        controlKey = "Subtract";
                    }
                    controlValue = kc.ConvertFrom(controlKey).GetHashCode();
                }
                if (zhKey != string.Empty && controlKey != string.Empty)
                {
                    if (zhKey == "Ctrl") zhKey = "Control";
                    hasValue = kc.ConvertFrom(zhKey).GetHashCode();
                    controlValue = kc.ConvertFrom(controlKey).GetHashCode();
                }
                finValue = hasValue + controlValue;
                if (finValue == 0) continue;
                if (hsTable.ContainsKey(finValue)) return false;
                hsTable.Add(finValue, null);
            }
            return true;
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            if (this.formID == "") return;
            Neusoft.HISFC.Models.Admin.FunSetting obj = new Neusoft.HISFC.Models.Admin.FunSetting();
            obj.ID = this.formID;
            obj.IsDoubleClick = this.IsDoubleSelectValue;
            obj.IsShowStatusBar = this.IsShowStatusBar;
            obj.IsShowToolBar = this.IsShowToolBar;
            obj.IsShowTreeView = this.IsShowTreeView;
            obj.TextPosition = this.TextPosition;
            obj.IsShowSearch = this.IsShowSearch;
            this.AddTag();
            obj.ControlXML = this.GetXMLWithOutXML();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Admin.FunSetting manager = new Neusoft.HISFC.BizLogic.Admin.FunSetting();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //manager.SetTrans(t.Trans);
            if (manager.SetFunSetting(obj) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(manager.Err);
                return;
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
              
            }
            this.Close();
           
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

        /// <summary>
        /// 单控件的属性添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProperty_Click(object sender, EventArgs e)
        {

            if (this.currentDefaultControl == null) return;
            Control c = this.currentDefaultControl;
            Classes.Function.SetPropertyToControl(c, this.GetArrayListProperty());
            if (c == null) return;
            PropertyGrid property = new PropertyGrid();
            property.SelectedObject = c;
            property.Size = new Size(200, 400);
            property.PropertyValueChanged += new PropertyValueChangedEventHandler(property_PropertyValueChanged);
            Classes.Function.PopShowControl(property);
                
        }
        #endregion

        private void chkReset_CheckedChanged(object sender, EventArgs e)
        {
            this.listView1.Enabled = this.chkReset.Checked;
            this.listView2.Enabled = this.chkReset.Checked;
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex <= 0) return;
            //old info
            int curRow = this.fpSpread1_Sheet1.ActiveRowIndex;
            string s1 = this.fpSpread1_Sheet1.Cells[curRow, 0].Text;
            string s2 = this.fpSpread1_Sheet1.Cells[curRow, 1].Text;
            string s3 = this.fpSpread1_Sheet1.Cells[curRow, 2].Text;
            object s4 = this.fpSpread1_Sheet1.Rows[curRow].Tag;

           
            this.fpSpread1_Sheet1.Cells[curRow, 0].Text = this.fpSpread1_Sheet1.Cells[curRow -1, 0].Text;
            this.fpSpread1_Sheet1.Cells[curRow, 1].Text = this.fpSpread1_Sheet1.Cells[curRow - 1, 1].Text;
            this.fpSpread1_Sheet1.Cells[curRow, 2].Text = this.fpSpread1_Sheet1.Cells[curRow - 1, 2].Text;
            this.fpSpread1_Sheet1.Rows[curRow].Tag = this.fpSpread1_Sheet1.Rows[curRow - 1].Tag;;

             this.fpSpread1_Sheet1.Cells[curRow -1, 0].Text = s1;
            this.fpSpread1_Sheet1.Cells[curRow -1, 1].Text = s2;
            this.fpSpread1_Sheet1.Cells[curRow -1, 2].Text = s3;
            this.fpSpread1_Sheet1.Rows[curRow -1].Tag = s4;
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex >=this.fpSpread1_Sheet1.RowCount -1) return;
            //old info
            int curRow = this.fpSpread1_Sheet1.ActiveRowIndex;
            string s1 = this.fpSpread1_Sheet1.Cells[curRow, 0].Text;
            string s2 = this.fpSpread1_Sheet1.Cells[curRow, 1].Text;
            string s3 = this.fpSpread1_Sheet1.Cells[curRow, 2].Text;
            object s4 = this.fpSpread1_Sheet1.Rows[curRow].Tag;


            this.fpSpread1_Sheet1.Cells[curRow, 0].Text = this.fpSpread1_Sheet1.Cells[curRow +1, 0].Text;
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
            if (this.fpSpread1_Sheet1.ActiveRowIndex < 0) return;
            this.fpSpread1_Sheet1.Rows.Remove(this.fpSpread1_Sheet1.ActiveRowIndex, 1);
        }

        private void chkShowSearch_CheckedChanged(object sender, EventArgs e)
        {
            form.IsShowSearchTextBox = this.chkShowSearch.Checked;
        }

        private void neuSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            int row = this.neuSpread1_Sheet1.ActiveRowIndex;
            int col = this.neuSpread1_Sheet1.ActiveColumnIndex;
            if (this.neuSpread1_Sheet1.RowCount <= 0)
            {
                return;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (col == 0)
                {
                    return;
                }
                this.neuSpread1_Sheet1.SetValue(row, col, string.Empty);
                return;

            }
            if (e.KeyCode != Keys.LButton)
            {
                if (col == 0)
                {
                    return;
                }
                if (col == 1)
                {
                    if (e.KeyCode == Keys.ControlKey)
                    {
                        this.neuSpread1_Sheet1.SetValue(row, col, "Ctrl");
                    }
                    if (e.KeyCode == Keys.ShiftKey)
                    {
                        this.neuSpread1_Sheet1.SetValue(row, col, Keys.Shift.ToString());
                    }
                    if (e.KeyCode == Keys.Alt)
                    {
                        this.neuSpread1_Sheet1.SetValue(row, col, Keys.Alt.ToString());
                    }
                }
                else
                {
                    string controlKey = string.Empty;
                    if (e.KeyCode == Keys.Add)
                    {
                        controlKey = "+";
                    }
                    else if (e.KeyCode == Keys.Subtract)
                    {
                        controlKey = "-";
                    }
                    else
                    { 
                        controlKey=e.KeyCode.ToString();
                    }
                    this.neuSpread1_Sheet1.SetValue(row, col, controlKey);
                }
            }
        }

       

    }
}
