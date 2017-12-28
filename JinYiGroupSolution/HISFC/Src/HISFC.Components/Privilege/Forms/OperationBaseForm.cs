using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using Neusoft.NFC.Interface.Forms;
using Neusoft.NFC.Interface.Controls;
using Neusoft.NFC.Object;
using Neusoft.NFC.Management;
using Neusoft.NFC.Function;



namespace Neusoft.UFC.Privilege.Forms
{
    /// <summary>
    /// [功能描述: 基类窗口，实现可以添加控件到窗口里,控件需实现IControlable接口等]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class OperationBaseForm : BaseForm
    {
        protected NFC.Interface.Controls.NeuPanel panel1;
        protected NFC.Interface.Controls.NeuPanel panel2;
        private NFC.Interface.Controls.NeuSplitter splitter1;
        protected NFC.Interface.Controls.NeuPanel panelMain;
        protected NFC.Interface.Controls.NeuTabControl tabControl1;
        protected NFC.Interface.Controls.NeuPanel panelTree;
        protected NFC.Interface.Controls.NeuTextBox txtSearch;
        private System.ComponentModel.IContainer components;

        protected string formID = "";
        protected string formType = "FormSetting";
        protected NFC.Interface.Controls.NeuLabel lblSet;
        protected NFC.Interface.Controls.NeuPictureBox btnClose;
        protected ToolStrip toolBar1;
        protected ToolStripButton tbQuery;
        protected ToolStripButton tbSave;
        protected ToolStripSeparator toolStripSeparator3;
        protected ToolStripButton tbPrintSet;
        protected ToolStripButton tbPrintPreview;
        protected ToolStripButton tbPrint;
        protected ToolStripButton tbExport;
        protected ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tbExit;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private NeuLinkLabel lkSearch;
        private ToolStripButton tbNavigation;
        private GroupBox groupBox2;
        protected ToolStrip toolBar2;          

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationBaseForm));
            this.panel1 = new NFC.Interface.Controls.NeuPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelMain = new NFC.Interface.Controls.NeuPanel();
            this.tabControl1 = new NFC.Interface.Controls.NeuTabControl();
            this.splitter1 = new NFC.Interface.Controls.NeuSplitter();
            this.panel2 = new NFC.Interface.Controls.NeuPanel();
            this.lkSearch = new NFC.Interface.Controls.NeuLinkLabel();
            this.btnClose = new NFC.Interface.Controls.NeuPictureBox();
            this.txtSearch = new NFC.Interface.Controls.NeuTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTree = new NFC.Interface.Controls.NeuPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSet = new NFC.Interface.Controls.NeuLabel();
            this.toolBar1 = new ToolStrip();
            this.tbNavigation = new System.Windows.Forms.ToolStripButton();
            this.tbQuery = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbPrintSet = new System.Windows.Forms.ToolStripButton();
            this.tbPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.toolBar2 = new ToolStrip();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 404);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(217, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1, 404);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(217, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(386, 404);
            this.panelMain.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(386, 404);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(214, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 404);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lkSearch);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panelTree);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 404);
            this.panel2.TabIndex = 0;
            // 
            // lkSearch
            // 
            this.lkSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkSearch.AutoSize = true;
            this.lkSearch.Location = new System.Drawing.Point(166, 30);
            this.lkSearch.Name = "lkSearch";
            this.lkSearch.Size = new System.Drawing.Size(29, 12);
            this.lkSearch.TabIndex = 9;
            this.lkSearch.TabStop = true;
            this.lkSearch.Text = "查询";
            this.lkSearch.Click += new System.EventHandler(this.lkSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Location = new System.Drawing.Point(197, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(12, 12);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.IsEnter2Tab = false;
            this.txtSearch.Location = new System.Drawing.Point(12, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(148, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 21);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panelTree
            // 
            this.panelTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTree.Location = new System.Drawing.Point(0, 54);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(214, 349);
            this.panelTree.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(213, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1, 404);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // lblSet
            // 
            this.lblSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSet.AutoSize = true;
            this.lblSet.BackColor = System.Drawing.Color.Transparent;
            this.lblSet.Location = new System.Drawing.Point(562, 469);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(29, 12);
            this.lblSet.TabIndex = 5;
            this.lblSet.Text = "设置";
            this.lblSet.Click += new System.EventHandler(this.lblSet_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNavigation,
            this.tbQuery,
            this.tbSave,
            this.toolStripSeparator3,
            this.tbPrintSet,
            this.tbPrintPreview,
            this.tbPrint,
            this.tbExport,
            this.toolStripSeparator2,
            this.tbExit});
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(603, 35);
            this.toolBar1.TabIndex = 5;
            this.toolBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tbNavigation
            // 
            this.tbNavigation.Checked = true;
            this.tbNavigation.CheckOnClick = true;
            this.tbNavigation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbNavigation.Image = ((System.Drawing.Image)(resources.GetObject("tbNavigation.Image")));
            this.tbNavigation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNavigation.Name = "tbNavigation";
            this.tbNavigation.Size = new System.Drawing.Size(33, 32);
            this.tbNavigation.Tag = "Default";
            this.tbNavigation.Text = "导航";
            this.tbNavigation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbQuery
            // 
            this.tbQuery.Image = ((System.Drawing.Image)(resources.GetObject("tbQuery.Image")));
            this.tbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(33, 32);
            this.tbQuery.Tag = "Default";
            this.tbQuery.Text = "查询";
            this.tbQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbQuery.ToolTipText = "查询";
            // 
            // tbSave
            // 
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(33, 32);
            this.tbSave.Tag = "Default";
            this.tbSave.Text = "保存";
            this.tbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbSave.ToolTipText = "保存";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            this.toolStripSeparator3.Tag = "Default";
            // 
            // tbPrintSet
            // 
            this.tbPrintSet.Image = ((System.Drawing.Image)(resources.GetObject("tbPrintSet.Image")));
            this.tbPrintSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrintSet.Name = "tbPrintSet";
            this.tbPrintSet.Size = new System.Drawing.Size(33, 32);
            this.tbPrintSet.Tag = "Default";
            this.tbPrintSet.Text = "设置";
            this.tbPrintSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbPrintSet.ToolTipText = "打印设置";
            // 
            // tbPrintPreview
            // 
            this.tbPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tbPrintPreview.Image")));
            this.tbPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrintPreview.Name = "tbPrintPreview";
            this.tbPrintPreview.Size = new System.Drawing.Size(33, 32);
            this.tbPrintPreview.Tag = "Default";
            this.tbPrintPreview.Text = "预览";
            this.tbPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbPrintPreview.ToolTipText = "打印预览";
            // 
            // tbPrint
            // 
            this.tbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbPrint.Image")));
            this.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(33, 32);
            this.tbPrint.Tag = "Default";
            this.tbPrint.Text = "打印";
            this.tbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbExport
            // 
            this.tbExport.Image = ((System.Drawing.Image)(resources.GetObject("tbExport.Image")));
            this.tbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(33, 32);
            this.tbExport.Tag = "Default";
            this.tbExport.Text = "导出";
            this.tbExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            this.toolStripSeparator2.Tag = "Default";
            // 
            // tbExit
            // 
            this.tbExit.Image = ((System.Drawing.Image)(resources.GetObject("tbExit.Image")));
            this.tbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExit.Name = "tbExit";
            this.tbExit.Size = new System.Drawing.Size(33, 32);
            this.tbExit.Tag = "Default";
            this.tbExit.Text = "退出";
            this.tbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolBar2
            // 
            this.toolBar2.Location = new System.Drawing.Point(0, 35);
            this.toolBar2.Name = "toolBar2";
            this.toolBar2.Size = new System.Drawing.Size(603, 25);
            this.toolBar2.TabIndex = 7;
            this.toolBar2.Text = "toolStrip1";
            this.toolBar2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // OperationBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(603, 486);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar2);
            this.Controls.Add(this.toolBar1);
            this.KeyPreview = true;
            this.Name = "OperationBaseForm";
            this.Text = "功能窗口";
            this.Load += new System.EventHandler(this.frmBaseForm_Load);
            this.Controls.SetChildIndex(this.toolBar1, 0);
            this.Controls.SetChildIndex(this.toolBar2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblSet, 0);
            this.panel1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
                 
        #endregion

        #region 变量
        protected TreeView tree = null;
        protected IOperation _Operation = null;
        protected IQueryHandler _QueryOperation = null;        
        ArrayList alNodes = null;
        private Control currentControl = null;

        /// <summary>
        /// 一级工具栏最初按钮,防止删除按钮后,无法获取
        /// </summary>
        private ToolStripItem[] _originalItems = null;
        /// <summary>
        /// 窗体属性
        /// </summary>
        protected NeuConfiguration formProperty = null;

        /// <summary>
        /// 当前控件
        /// </summary>
        public Control CurrentControl
        {
            get { return currentControl; }
            set { currentControl = value; }
        }

        #endregion            
    
        #region 属性

        private bool isShowToolBar = true;
        private bool isDoubleSelectValue = false;
        private bool isShowStatusBar = true;
        protected NFC.Interface.Forms.ToolBarService toolBarService = null;
        private bool isShowTreeView = true;
        protected bool isOneControl = false;
        /// <summary>
        /// 是否用双击选择数值，默认是单击
        /// </summary>
        public bool IsDoubleSelectValue
        {
            get
            {
                return this.isDoubleSelectValue;
            }
            set
            {
                this.isDoubleSelectValue = value;
            }
        }
        
        /// <summary>
        /// 是否显示树
        /// </summary>
        public bool IsShowTreeView
        {
            get
            {
                return this.isShowTreeView;
            }
            set
            {
                this.isShowTreeView = value;

                setTreeVisible(value);
                tbNavigation.Checked = value;
            }
        }

        /// <summary>
        /// 是否显示ToolBar
        /// </summary>
        public bool IsShowToolBar
        {
            get
            {
                return this.isShowToolBar;
            }
            set
            {
                this.isShowToolBar = value;
                this.toolBar2.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示StatusBar
        /// </summary>
        public bool IsShowStatusBar
        {
            get
            {
                return this.isShowStatusBar;
            }
            set
            {
                this.isShowStatusBar = value;
                this.MainStatusStrip.Visible = value;
            }
        }
        private bool isUseDefaultBar = true;
        /// <summary>
        /// 是否使用默认工具条
        /// </summary>
        [DefaultValue(true)]
        public bool IsUseDefaultBar
        {
            get
            {
                return isUseDefaultBar;
            }
            set
            {
                if (value)
                {
                    this.Controls.Add(this.toolBar1);
                    this.toolBar1.Visible = true;
                }
                else
                {
                    this.Controls.Remove(this.toolBar1);
                    this.toolBar1.Visible = false;
                }
                isUseDefaultBar = value;
            }
        }

        private bool bIsShowSearchTextBox = true;
        /// <summary>
        /// 是否显示查询文本框
        /// </summary>
        [Description("是否显示查询文本框"),DefaultValue(true)]
        public bool IsShowSearchTextBox
        {
            get
            {
                return bIsShowSearchTextBox;
            }
            set
            {
                bIsShowSearchTextBox = value;

                this.txtSearch.Visible = value;
                this.lkSearch.Visible = value;

                if (!value)
                {
                    this.panelTree.Location = new Point(0, 20);
                    this.panelTree.Height = panel2.Height - 20;
                }
                else
                {
                    this.panelTree.Location = new Point(0,54);
                    this.panelTree.Height = panel2.Height - 54;
                }
            }
        }


        #endregion

        #region 初始化

        /// <summary>
        /// 
        /// </summary>
        public OperationBaseForm()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            this.Icon = null;
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            this.GetOriginalDefaultButtons();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public OperationBaseForm(Control control)
        {
            InitializeComponent();
            this.Icon = null;

            this.GetOriginalDefaultButtons();

            this.AddControl(control, panelMain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="tv"></param>
        public OperationBaseForm(Control control, TreeView tv)
        {
            InitializeComponent();
            this.Icon = null;

            this.GetOriginalDefaultButtons();

            this.SetTree(tv);
            this.AddControl(control, panelMain);
        }

        /// <summary>
        /// 获取一级工具栏最初按钮
        /// </summary>
        private void GetOriginalDefaultButtons()
        {
            if (this.toolBar1.Items.Count > 0)
            {
                _originalItems = new ToolStripItem[this.toolBar1.Items.Count];
                this.toolBar1.Items.CopyTo(this._originalItems, 0);
            }
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="container"></param>
        public void AddControl(Control control, Control container)
        {
            try
            {
                if (control.Text == "") control.Text = "功能";
                control.Dock = DockStyle.Fill;
                if (container == this.panelMain)//添加到Panel
                {
                    //单控件，无窗口
                    this.tabControl1.Visible = false;
                    this.isOneControl = true;
                    this.panelMain.Controls.Clear();
                    this.panelMain.Controls.Add(control);                    
                    this.currentControl = control;
                    this._Operation = control as IOperation;
                    this._QueryOperation = control as IQueryHandler;
                }
                else
                {
                    //有窗口，无控件
                    this.tabControl1.Visible = true;                    
                    this.isOneControl = false;
                    TabPage tp = new TabPage(control.Text);
                    tp.Text = control.Text;
                    tp.Controls.Add(control);
                    this.tabControl1.TabPages.Add(tp);
                    this.tabControl1.SelectedTab = tp;
                    if (this.tabControl1.SelectedIndex == 0)//第一个
                    {
                        this.currentControl = control;
                        this._Operation = control as IOperation;
                        this._QueryOperation = control as IQueryHandler;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.initControl();
        }//ok

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="control"></param>
        public void AddControl(Control control)
        {
            try
            {
                if (control.Text == "") control.Text = "功能";
                TabPage tp = new TabPage(control.Text);
                tp.Text = control.Text;
                tp.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                this.tabControl1.TabPages.Add(tp);
                this.tabControl1.SelectedTab = tp;
                if (this.tabControl1.SelectedIndex == 0)//第一个
                {
                    this.currentControl = control;
                    this._Operation = control as IOperation;
                    this._QueryOperation = control as IQueryHandler;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.initControl();
        }

        /// <summary>
        /// 初始化Control
        /// </summary>
        private void initControl()
        {
            if (this._Operation != null)
            {
                _Operation.RefreshTree += new EventHandler(Operation_RefreshTree);
                _Operation.StatusBarInfo += new MessageEventHandle(Operation_StatusBarInfo);
                _Operation.SendMessage += new MessageEventHandle(Operation_SendMessage);
                _Operation.SendParamToControl += new SendParamToControlHandle(Operation_SendParamToControl);

                ResetToolbarService();               
                ResetToolbarButton();
            }
        }

        private void ResetToolbarService()
        {
            if (_Operation != null)
            {
                if (this.tree != null)
                {
                    if (this.tree.SelectedNode != null)
                        this.toolBarService = this._Operation.Init(this.tree, this.tree.SelectedNode.Tag, this.Tag);
                    else
                        this.toolBarService = this._Operation.Init(this.tree, null, this.Tag);
                }
                else
                    this.toolBarService = this._Operation.Init(null, null, this.Tag);
            }
        }

        /// <summary>
        /// 恢复工具栏到初始状态
        /// </summary>
        private void ResetToolbarButton()
        {
            ArrayList al = null;

            if (this.toolBarService != null)//获得运行时生成的按钮
            {
                al = toolBarService.GetToolButtons();
            }

            //恢复到只有default按钮状态
            toolBar1.Items.Clear();
            foreach (ToolStripItem _item in _originalItems)
            {
                toolBar1.Items.Add(_item);
            }

            ToolBarButtonService.ClearButton(toolBar2);

            if (al != null)
            {
                foreach (ToolStripButton tb in al)//增加运行时按钮
                {
                    ToolBarButtonService.SetButtonProperty(tb);
                    this.toolBar2.Items.Add(tb);
                }
            }
        }

        protected virtual void Operation_SendParamToControl(object sender, string dllName, string controlName, object objParams)
        {
            //处理控件间的处理
            try
            {
                if (sender == null)
                {
                    if (dllName == "" && controlName == "") return;

                    if (isOneControl)
                    {
                        string _dllName = currentControl.GetType().Module.Name;
                        _dllName = _dllName.Remove(dllName.LastIndexOf('.'));

                        if (dllName == _dllName && controlName == currentControl.GetType().FullName)
                        {
                            sender = currentControl;
                        }
                    }
                    else
                    {
                        foreach (TabPage _page in tabControl1.TabPages)
                        {
                            Control _c = _page.Controls[0];
                            string _dllName = _c.GetType().Module.Name;
                            _dllName = _dllName.Remove(dllName.LastIndexOf('.'));

                            if (dllName == _dllName && controlName == _c.GetType().FullName)
                            {
                                this.tabControl1.SelectedTab = _page;
                                sender = _c;
                                break;
                            }
                        }
                    }                    
                }
            }
            catch { }

            if (sender == null) //没有现成的
            {
                sender = Util.CreateControl(dllName, controlName);
                if (sender == null) return;

                IOperation ic = sender as IOperation;
                if (ic == null) return;
                ic.SetValue(objParams, null);
                Util.PopShowControl(sender as Control);
            }
            else
            {
                IOperation ic = sender as IOperation;
                if (ic == null) return;
                ic.SetValue(objParams, null);
            }
        }

        protected virtual void Operation_SendMessage(object sender, string msg)
        {
            //处理接收到的消息
        }

        void Operation_StatusBarInfo(object sender, string msg)
        {
            this.SetStatusMsg(msg);
        }

        protected virtual void Operation_RefreshTree(object sender, EventArgs e)
        {
            if (this.tree != null)
                this.tree.Refresh();
        }             

        /// <summary>
        /// 设置树
        /// </summary>
        /// <param name="tv"></param>
        public void SetTree(TreeView tv)
        {
            this.tree = tv;
            this.tree.Dock = DockStyle.Fill;
            this.panelTree.Controls.Add(tv);
            this.initTree();
        }

        /// <summary>
        /// 初始化Tree
        /// </summary>
        protected void initTree()
        {
            if (this.tree == null) return;
            this.tree.AfterSelect += new TreeViewEventHandler(tree_AfterSelect);
            this.tree.BeforeSelect += new TreeViewCancelEventHandler(tree_BeforeSelect);
            this.tree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tree_NodeMouseDoubleClick);
          
        }

        protected virtual void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.isDoubleSelectValue) return;
            try
            {
                this._Operation.SetValue(this.tree.SelectedNode.Tag, e.Node);
            }
            catch { }
            
             if (this.MyToolBarService != null)
                this.MyToolBarService.InfoChanged(this.tree.SelectedNode.Tag);
           
        }

        protected virtual void tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (this.isDoubleSelectValue) return;
                if (this._Operation.BeforSetValue(this.tree.SelectedNode.Tag, e) == -1)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

        protected virtual void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.isDoubleSelectValue) //双击
            {
                try
                {
                    this._Operation.SetValue(this.tree.SelectedNode.Tag, this.tree.SelectedNode);
                }
                catch { }
                
                if (this.MyToolBarService != null)
                    this.MyToolBarService.InfoChanged(this.tree.SelectedNode.Tag);
            }
        }

        /// <summary>
        /// 设置界面显示控件
        /// </summary>
        /// <param name="formid"></param>
        public void SetFormStyle(string formid)
        {
            this.formID = formid;

            //IConfigurationManager _proxy = Util.CreateProxy();
            //using (_proxy as IDisposable)
            //{
            //    formProperty = _proxy.Get(this.formID,this.formType);
            //    if (formProperty == null || string.IsNullOrEmpty(formProperty.Id)) return;

            //    this.SetControl(formProperty.ConfigXml);
            //}


            //A9D33964-33F0-4bfd-B28E-EBC425F97C99
            ConfigurationManager _proxy = Util.CreateProxy();
            using (_proxy as IDisposable)
            {
                XmlDocument xml = new XmlDocument();
                formProperty = _proxy.GetConfiguration(formID, formType);
                xml.LoadXml(formProperty.ConfigString);


                if (formProperty != null && !string.IsNullOrEmpty(formProperty.ID))
                {

                    this.SetControl(xml);
                }
                else
                {
                    string ResourceId = _proxy.GetResourceId(formID);
                    if (!String.IsNullOrEmpty(ResourceId))
                    {
                        formProperty = _proxy.GetConfiguration(ResourceId, "FormSettingDefault");
                        if (formProperty != null)
                        {
                            this.SetControl(xml);
                        }

                    }
                    else
                    {
                        return;

                    }

                }
            }
        }

        /// <summary>
        /// 设置控件
        /// </summary>
        public virtual void SetControl(XmlDocument configXml)
        {
            string a = configXml.DocumentElement.Attributes["IsShowStatusbar"].Value;
            this.MainStatusStrip.Visible = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowStatusbar"].Value);
            this.toolBar2.Visible = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowToolbar"].Value);
            this.panel2.Visible = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowTree"].Value);
            this.isDoubleSelectValue = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsTreeDoubleClick"].Value);
            this.IsShowSearchTextBox = NConvert.ToBoolean(configXml.DocumentElement.Attributes["IsShowSearch"].Value); 

            if (this.currentControl != null)
            {
                string dllName = currentControl.GetType().Module.Name;
                dllName = dllName.Remove(dllName.LastIndexOf('.'));

                this.SetToolBar(dllName, currentControl.GetType().FullName, configXml);
                //属性列表
                Dictionary<string, string> _keyvalues = this.ConvertStringToArrayList(configXml, dllName, currentControl.GetType().FullName);
                              
                Util.SetPropertyToControl(currentControl, _keyvalues);
            }

            ///增加其他tab页控件
            this.AddControl(configXml);
        }
              

        /// <summary>
        /// 设置工具兰按钮
        /// </summary>
        private void SetToolBar(string dllName, string controlName, XmlDocument configXml)
        {

            XmlNodeList nodeToolBars = configXml.SelectNodes("//Setting/ToolBar");
            if (nodeToolBars == null || nodeToolBars.Count == 0) return;

            ArrayList al1 = new ArrayList();//配置的按钮
            ArrayList al2 = new ArrayList();

            foreach (XmlNode node in nodeToolBars)
            {
                if (node.Attributes["DllName"].Value == dllName &&
                    node.Attributes["ControlName"].Value == controlName)
                {
                    string[] ss = node.Attributes["ToolBar1"].Value.Split(';');
                    for (int i = 1; i < ss.Length; i++)
                    {
                        al1.Add(ss[i]);
                    }

                    ss = node.Attributes["ToolBar2"].Value.Split(';');
                    for (int i = 1; i < ss.Length; i++)
                    {
                        al2.Add(ss[i]);
                    }

                    ToolBarButtonService.ChangeButton(this.toolBar1, this.toolBar2, al1, al2);

                    break;
                }
            }
        }
                
        /// <summary>
        /// 获取属性值列表
        /// </summary>
        private Dictionary<string, string> ConvertStringToArrayList(XmlDocument configXml, string dllName, string controlName)
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

        /// <summary>
        /// 添加控件
        /// </summary>
        public virtual void AddControl(XmlDocument configXml)
        {
            XmlNodeList nodes = configXml.SelectNodes("//Setting/ToolBar");
            
            foreach (XmlNode node in nodes)
            {
                string _title = node.Attributes["Name"].Value;
                if (_title == "") _title = "功能";

                ///没有创建控件
                if (!isCreated(_title))
                {
                    TabPage _page = new TabPage(_title);
                    _page.Tag = node.Attributes["DllName"].Value + "|" + node.Attributes["ControlName"].Value;
                    tabControl1.TabPages.Add(_page);                    
                }                
            }            
        }

        private bool isCreated(string title)
        {
            bool _isCreated = false;

            foreach (TabPage _page in tabControl1.TabPages)
            {
                if (_page.Text == title) return true;
            }

            return _isCreated;
        }

        /// <summary>
        /// 判断设置按钮是否显示
        /// </summary>
        private bool isSetVisible = false;
        public bool IsSetVisible
        {
            // {F7467559-85A4-4ca9-B228-3782943DCB05}修改设置功能键，通过属性判断
            get
            {
                return isSetVisible;
            }
            set
            {
                this.isSetVisible = value;
            }
        }
        private void frmBaseForm_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            //系统管理员可进行设置
            this.lblSet.Visible = IsSetVisible;

            try
            {
                if (this.tabControl1.Visible == false) //单控件
                    this.SetToolBar(this.panelMain.Controls[0].GetType().ToString());//设置单控件ToolBar接口
            }
            catch { }
        }

        #endregion

        /// <summary>
        /// tab页面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(formProperty.ConfigString);
            //动态加载,第一次切换时加载
            if (this.tabControl1.SelectedTab.Controls.Count <= 0)
            {
                string _key = this.tabControl1.SelectedTab.Tag.ToString();

                Control c = Util.CreateControl(_key.Substring(0, _key.IndexOf('|')), _key.Substring(_key.IndexOf('|') + 1));
                if (c == null) return;

                ///设置控件属性
                Dictionary<string, string> _keyvalues = this.ConvertStringToArrayList(xml, _key.Substring(0, _key.IndexOf('|')), _key.Substring(_key.IndexOf('|') + 1));
                if (_keyvalues != null)
                    Util.SetPropertyToControl(c, _keyvalues);

                c.Dock = DockStyle.Fill;
                c.Visible = true;

                this.tabControl1.SelectedTab.Controls.Add(c);
                //this.iniForm();
                this.ChangeControlLanguage(c);
                
                _Operation = this.tabControl1.SelectedTab.Controls[0] as IOperation;
                _QueryOperation = this.tabControl1.SelectedTab.Controls[0] as IQueryHandler;
                this.currentControl = this.tabControl1.SelectedTab.Controls[0];
                this.initControl();

                this.SetToolBar(_key.Substring(0, _key.IndexOf('|')), _key.Substring(_key.IndexOf('|') + 1), xml);
            }
            else
            {
                _Operation = this.tabControl1.SelectedTab.Controls[0] as IOperation;
                _QueryOperation = this.tabControl1.SelectedTab.Controls[0] as IQueryHandler;
                this.currentControl = this.tabControl1.SelectedTab.Controls[0];
                this.ResetToolbarService();
                this.ResetToolbarButton();

                string dllName = currentControl.GetType().Module.Name;
                dllName = dllName.Remove(dllName.LastIndexOf('.'));

                if (formProperty == null)
                {
                    this.SetToolBar(dllName, currentControl.GetType().FullName, null);

                }
                else
                {
                    this.SetToolBar(dllName, currentControl.GetType().FullName, xml);
               
                }

            }

            //传递数据
            if (_Operation != null && tree != null && tree.SelectedNode != null)
                this._Operation.SetValue(this.tree.SelectedNode.Tag, this.tree.SelectedNode);
        }

        #region toolbarClicked

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
            {
                if(_Operation !=null)
                    _Operation.ToolStrip_ItemClicked(sender, e);
            }
            else
            {
                if (e.ClickedItem.Tag.GetType() == typeof(System.EventHandler))
                {
                    try
                    {
                        ((System.EventHandler)e.ClickedItem.Tag)(e.ClickedItem, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return;
                }
            }

            #region 设置
            
            if (e.ClickedItem == this.tbQuery)
            {
                Query();

            }
            else if (e.ClickedItem == this.tbNavigation)
            {
                if (this.IsShowTreeView)
                {
                    if (tbNavigation.Checked)
                        setTreeVisible(false);
                    else
                        setTreeVisible(true);
                }
            }
            else if (e.ClickedItem == this.tbSave)
            {
                save();
            }
            else if (e.ClickedItem == this.tbPrint)
            {
                print();
            }
            else if (e.ClickedItem == this.tbExit)
            {

                exit();
            }
            else if (e.ClickedItem == this.tbPrintPreview)
            {
                printPreview();
            }
            else if (e.ClickedItem == this.tbPrintSet)
            {
                printSet();
            }
            else if (e.ClickedItem == this.tbExport)
            {
                export();
            }
            
            #endregion

            if (this.MyToolBarService != null)
            {
                try
                {
                    if (this.tree.SelectedNode != null)
                        this.MyToolBarService.ToolBarClick(e.ClickedItem, this.tree.SelectedNode.Tag);
                    else
                        this.MyToolBarService.ToolBarClick(e.ClickedItem, null);
                }
                catch { }
            }
        }

        private void printPreview()
        {
            if (this._QueryOperation != null)
            {
                if (this.tree == null)
                    this._QueryOperation.PrintPreview(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this._QueryOperation.PrintPreview(this.tree, null);
                    else
                        this._QueryOperation.PrintPreview(this.tree, this.tree.SelectedNode.Tag);
                }
            }
        }

        private void export()
        {
            if (this._QueryOperation != null)
            {
                if (this.tree == null)
                    this._QueryOperation.Export(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this._QueryOperation.Export(this.tree, null);
                    else
                        this._QueryOperation.Export(this.tree, this.tree.SelectedNode.Tag);
                }
            }
        }

        private void printSet()
        {
            if (this._QueryOperation != null)
            {
                if (this.tree == null)
                    this._QueryOperation.SetPrint(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this._QueryOperation.SetPrint(this.tree, null);
                    else
                        this._QueryOperation.SetPrint(this.tree, this.tree.SelectedNode.Tag);
                }
            }
        }

        private void save()
        {
            if (this._QueryOperation != null)
            {
                if (this.tree == null)
                    this._QueryOperation.Save(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this._QueryOperation.Save(this.tree, null);
                    else
                        this._QueryOperation.Save(this.tree, this.tree.SelectedNode.Tag);

                }
            }
        }

        private void exit()
        {
            if (this._QueryOperation != null)
            {
                int returnValue;
                if (this.tree == null)
                    returnValue = this._QueryOperation.Exit(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                    {
                        returnValue = this._QueryOperation.Exit(this.tree, null);
                    }
                    else
                        returnValue = this._QueryOperation.Exit(this.tree, this.tree.SelectedNode.Tag);

                }
                if (returnValue == -1)
                {
                    return;
                }
                this.Close();                        
            }
        }

        //private void exit()
        //{
        //    if (this._QueryOperation != null && this.tree != null)
        //    {
        //         object obj = this.tree.SelectedNode.Tag;

        //         if (this._QueryOperation.Exit(null, obj) == 0)
        //             this.Close();
        //    }
        //    else
        //    {
        //        this.Close();
        //    }
        //}

        private void print()
        {
            if (this._QueryOperation != null)
            {
                if (this.tree == null)
                    this._QueryOperation.Print(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this._QueryOperation.Print(this.tree, null);
                    else
                        this._QueryOperation.Print(this.tree, this.tree.SelectedNode.Tag);

                }
            }
        }

        private void Query()
        {
            if (this.tree == null)
            {
                if (this._QueryOperation != null)
                {
                    this._QueryOperation.Query(null, null);
                }
                if (this._Operation != null)
                {
                    this._Operation.SetValue(null, null);
                }
            }
            else
            {
                if (this.tree.CheckBoxes)
                {
                    this.alNodes = new ArrayList();

                    if (this.tree.Nodes.Count > 0)
                        this.GetSelectedNodesTag(this.tree.Nodes[0]);

                    if (this._QueryOperation != null)
                    {
                        this._QueryOperation.Query(this.tree, alNodes);
                    }
                    if (this._Operation != null)
                    {
                        this._Operation.SetValues(alNodes, this.tree);
                    }
                }
                else
                {
                    object obj = null;
                    try
                    {
                        obj = this.tree.SelectedNode.Tag;
                    }
                    catch { }
                    if (this._QueryOperation != null)
                    {
                        this._QueryOperation.Query(this.tree, obj);
                    }
                    if (this._Operation != null)
                    {
                        this._Operation.SetValue(obj, this.tree.SelectedNode);
                    }

                }
            }
        }

        private void GetSelectedNodesTag(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Checked)
                    alNodes.Add(node.Tag);
                if (node.Nodes.Count > 0)
                    this.GetSelectedNodesTag(node);
            }
        }

        #endregion

        #region 函数
        private void lblSet_Click(object sender, EventArgs e)
        {
            this.Set();
        }

        /// <summary>
        /// 窗口设置
        /// </summary>
        private void Set()
        {
            string text = "没找到当前显示控件";

            if (_QueryOperation != null) text = _QueryOperation.ControlText;

            PropertySetForm _property = new PropertySetForm(this, this.toolBar1, this._originalItems, this.toolBar2, text);

            if (this.isOneControl)
                _property.SetNotAllowAddControl(this.panelMain.Controls[0]);

            _property.InitControl(this.formID);

            if (_property.ShowDialog(this) == DialogResult.OK)
            {
                //ToolBarButtonService.SetButtonProperty(_property.ImageSize, _property.TextPosition);
                ToolBarButtonService.ChangeButton(this.toolBar1, this.toolBar2, _property.AlTb1, _property.AlTb2);
            }

            _property.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            setTreeVisible(false);
            tbNavigation.Checked = false;
        }


        private void setTreeVisible(bool isVisible)
        {
            this.panel2.Visible = isVisible;
            groupBox2.Visible = isVisible;
        }
        #endregion

        #region 树查询操作
        /// <summary>
        /// 查找树控件匹配项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lkSearch_Click(null, null);
            }            
        }

        private void lkSearch_Click(object sender, EventArgs e)
        {
            if (this.tree == null) return;
            if (string.IsNullOrEmpty(this.txtSearch.Text)) return;

            ITreeSearch _search = (ITreeSearch)this.tree;

            foreach (TreeNode _node in this.tree.Nodes)
            {
                //查找匹配项
                if (_search != null)//实现接口,使用接口查找算法
                {
                    TreeNode _matchNode = _search.GetMatchedNode(_node, this.txtSearch.Text.Trim());
                    if (_matchNode != null)
                    {
                        this.tree.SelectedNode = _matchNode;
                        if (_matchNode.Parent != null)
                            _matchNode.Parent.Expand();
                        return;
                    }
                }
                else
                {
                    TreeNode _matchNode = GetMatchedNode(_node, this.txtSearch.Text.Trim());
                    if (_matchNode != null)
                    {
                        this.tree.SelectedNode = _matchNode;
                        if (_matchNode.Parent != null)
                            _matchNode.Parent.Expand();
                        return;
                    }
                }
            }

            MessageBox.Show("没有符合条件的项目!", "提示");
            this.txtSearch.Focus();
        }       

        private TreeNode GetMatchedNode(TreeNode parentNode, string searchExp)
        {            
            if (this.isMatch(parentNode, searchExp))
            {
                return parentNode;
            }

            foreach (TreeNode node in parentNode.Nodes)
            {
                TreeNode _match = GetMatchedNode(node, searchExp);
                if (_match != null) return _match;
            }

            return null;
        }

        /// <summary>
        /// 判断节点是否匹配条件
        /// </summary>
        /// <param name="node"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool isMatch(TreeNode node, string text)
        {
            if (node.Text == text) return true;

            if (node.Tag != null)
            {
                object _obj = node.Tag;
                Type _type = _obj.GetType();
                string _value;

                if (_type.IsClass)
                {
                    System.Reflection.PropertyInfo _id = _type.GetProperty("ID", System.Reflection.BindingFlags.IgnoreCase);
                    if (_id != null)
                    {
                        _value = toString(_id.GetValue(_obj, null));
                        if (_value.EndsWith(text, StringComparison.CurrentCultureIgnoreCase)) return true;
                    }

                    System.Reflection.PropertyInfo _name = _type.GetProperty("Name", System.Reflection.BindingFlags.IgnoreCase);
                    if (_name != null)
                    {
                        _value = toString(_name.GetValue(_obj, null));
                        if (_value == text) return true;
                    }
                }
                else
                {
                    //右匹配
                    if (_obj.ToString().EndsWith(text, StringComparison.CurrentCultureIgnoreCase))
                        return true;
                }             
            }
                        
            return false;
        }

        private string toString(object obj)
        {
            if (obj == null) return "";

            return obj.ToString();
        }
        #endregion        
    }

    /// <summary>
    /// 树形控件查找匹配项接口
    /// </summary>
    public interface ITreeSearch
    {
        TreeNode GetMatchedNode(TreeNode parentNode, string searchExp);
    }
   
}
