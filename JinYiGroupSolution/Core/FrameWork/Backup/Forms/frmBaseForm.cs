using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
namespace Neusoft.FrameWork.WinForms.Forms
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
    public class frmBaseForm : Neusoft.FrameWork.WinForms.Forms.BaseStatusBar
    {
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        protected System.Windows.Forms.Panel panelMain;
        protected TabControl tabControl1;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel panelTree;
        protected Neusoft.FrameWork.WinForms.Controls.NeuTextBox neuTextBox1;
        private System.ComponentModel.IContainer components;

        protected string formID = "";
        protected Neusoft.FrameWork.WinForms.Controls.NeuLabel lblSet;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPictureBox btnClose;
        protected Button btnShow;
        protected Neusoft.FrameWork.WinForms.Controls.NeuPanel panelToolBar;
        public ToolStrip toolBar1;
        protected ToolStripButton tbQuery;
        protected ToolStripButton tbSave;
        protected ToolStripSeparator toolStripSeparator3;
        protected ToolStripButton tbPrintSet;
        protected ToolStripButton tbPrintPreview;
        protected ToolStripButton tbPrint;
        protected ToolStripButton tbExport;
        protected ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tbExit;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClose = new Neusoft.FrameWork.WinForms.Controls.NeuPictureBox();
            this.panelTree = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.neuTextBox1 = new Neusoft.FrameWork.WinForms.Controls.NeuTextBox();
            this.lblSet = new Neusoft.FrameWork.WinForms.Controls.NeuLabel();
            this.panelToolBar = new Neusoft.FrameWork.WinForms.Controls.NeuPanel();
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.tbQuery = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbPrintSet = new System.Windows.Forms.ToolStripButton();
            this.tbPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.toolBar2 = new System.Windows.Forms.ToolStrip();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panelToolBar.SuspendLayout();
            this.toolBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 462);
            this.statusBar1.Size = new System.Drawing.Size(603, 24);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 380);
            this.panel1.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Honeydew;
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(209, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(394, 380);
            this.panelMain.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 380);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(206, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 380);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.panelTree);
            this.panel2.Controls.Add(this.neuTextBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 380);
            this.panel2.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(193, 83);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(13, 243);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = ">";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Location = new System.Drawing.Point(192, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(11, 11);
            this.btnClose.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelTree
            // 
            this.panelTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTree.Location = new System.Drawing.Point(3, 32);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(203, 342);
            this.panelTree.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.VS2003;
            this.panelTree.TabIndex = 1;
            // 
            // neuTextBox1
            // 
            this.neuTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.neuTextBox1.IsEnter2Tab = false;
            this.neuTextBox1.Location = new System.Drawing.Point(4, 5);
            this.neuTextBox1.Name = "neuTextBox1";
            this.neuTextBox1.Size = new System.Drawing.Size(199, 21);
            this.neuTextBox1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.neuTextBox1.TabIndex = 0;
            this.neuTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lblSet
            // 
            this.lblSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSet.AutoSize = true;
            this.lblSet.BackColor = System.Drawing.SystemColors.Control;
            this.lblSet.Location = new System.Drawing.Point(562, 468);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(29, 12);
            this.lblSet.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.lblSet.TabIndex = 5;
            this.lblSet.Text = "设置";
            this.lblSet.Click += new System.EventHandler(this.lblSet_Click);
            // 
            // panelToolBar
            // 
            this.panelToolBar.BackColor = System.Drawing.Color.Honeydew;
            this.panelToolBar.Controls.Add(this.toolBar1);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolBar.Location = new System.Drawing.Point(0, 0);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.Size = new System.Drawing.Size(603, 57);
            this.panelToolBar.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.panelToolBar.TabIndex = 6;
            // 
            // toolBar1
            // 
            this.toolBar1.BackColor = System.Drawing.Color.Honeydew;
            this.toolBar1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolBar1.Size = new System.Drawing.Size(603, 55);
            this.toolBar1.Stretch = true;
            this.toolBar1.TabIndex = 5;
            this.toolBar1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tbQuery
            // 
            this.tbQuery.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.查询;
            this.tbQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(40, 52);
            this.tbQuery.Tag = "Default";
            this.tbQuery.Text = "查询";
            this.tbQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbQuery.ToolTipText = "查询";
            // 
            // tbSave
            // 
            this.tbSave.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.保存;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(40, 52);
            this.tbSave.Tag = "Default";
            this.tbSave.Text = "保存";
            this.tbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbSave.ToolTipText = "保存";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator3.Tag = "Default";
            // 
            // tbPrintSet
            // 
            this.tbPrintSet.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.设置;
            this.tbPrintSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrintSet.Name = "tbPrintSet";
            this.tbPrintSet.Size = new System.Drawing.Size(40, 52);
            this.tbPrintSet.Tag = "Default";
            this.tbPrintSet.Text = "设置";
            this.tbPrintSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbPrintSet.ToolTipText = "打印设置";
            // 
            // tbPrintPreview
            // 
            this.tbPrintPreview.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.打印预览;
            this.tbPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrintPreview.Name = "tbPrintPreview";
            this.tbPrintPreview.Size = new System.Drawing.Size(40, 52);
            this.tbPrintPreview.Tag = "Default";
            this.tbPrintPreview.Text = "预览";
            this.tbPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tbPrintPreview.ToolTipText = "打印预览";
            // 
            // tbPrint
            // 
            this.tbPrint.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.打印;
            this.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPrint.Name = "tbPrint";
            this.tbPrint.Size = new System.Drawing.Size(40, 52);
            this.tbPrint.Tag = "Default";
            this.tbPrint.Text = "打印";
            this.tbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tbExport
            // 
            this.tbExport.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.导出;
            this.tbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(40, 52);
            this.tbExport.Tag = "Default";
            this.tbExport.Text = "导出";
            this.tbExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator2.Tag = "Default";
            // 
            // tbExit
            // 
            this.tbExit.Image = global::Neusoft.FrameWork.WinForms.Properties.Resources.退出;
            this.tbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExit.Name = "tbExit";
            this.tbExit.Size = new System.Drawing.Size(40, 52);
            this.tbExit.Tag = "Default";
            this.tbExit.Text = "退出";
            this.tbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolBar2
            // 
            this.toolBar2.BackColor = System.Drawing.Color.Honeydew;
            this.toolBar2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolBar2.Location = new System.Drawing.Point(0, 57);
            this.toolBar2.Name = "toolBar2";
            this.toolBar2.Size = new System.Drawing.Size(603, 25);
            this.toolBar2.Stretch = true;
            this.toolBar2.TabIndex = 7;
            this.toolBar2.Text = "toolStrip1";
            this.toolBar2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // frmBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(603, 486);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar2);
            this.Controls.Add(this.panelToolBar);
            this.Name = "frmBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能窗口";
            this.Load += new System.EventHandler(this.frmBaseForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaseForm_KeyDown);
            this.Controls.SetChildIndex(this.panelToolBar, 0);
            this.Controls.SetChildIndex(this.toolBar2, 0);
            this.Controls.SetChildIndex(this.statusBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblSet, 0);
            this.panel1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panelToolBar.ResumeLayout(false);
            this.panelToolBar.PerformLayout();
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        #region 变量
        protected TreeView tree = null;
        protected IControlable iControlable = null;
        protected IQueryControlable iQueryControlable = null;
        protected ToolTip tooltip = new ToolTip();
        private ArrayList alControls = null;
        protected object[] ControlsToolBars = new object[10];
        ArrayList alNodes = null;
        private Control currentControl = null;

        /// <summary>
        /// 当前控件
        /// </summary>
        public Control CurrentControl
        {
            get { return currentControl; }
            set { currentControl = value; }
        }

        /// <summary>
        /// 控件数组
        /// </summary>
        public ArrayList AlControls
        {
            get
            {
                if (alControls == null)
                    alControls = new ArrayList();
                foreach (TabPage tp in tabControl1.TabPages)
                {
                    alControls.Add(tp.Tag);
                }
                return alControls;
            }
        }

        /// <summary>
        /// 快捷键哈希值
        /// </summary>
        Hashtable keyTable = new Hashtable();
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public frmBaseForm()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            Neusoft.FrameWork.WinForms.Classes.Function.SetTabControlStyle(this.tabControl1);
            this.Icon = null;
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }
      
    
        #region 属性

        private bool isShowToolBar = true;
        private bool isDoubleSelectValue = false;
        private bool isShowStatusBar = true;
        protected ToolBarService toolBarService = null;
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
                this.panel2.Visible = value;
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
                this.statusBar1.Visible = value;
            }
        }
        private bool isUseDefaultBar = true;
        /// <summary>
        /// 是否用默认工具条呀
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
                    this.panelToolBar.Controls.Add(this.toolBar1);
                    this.toolBar1.Visible = true;
                }
                else
                {
                    this.panelToolBar.Controls.Remove(this.toolBar1);
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
                this.neuTextBox1.Visible = value;
                if (value)
                {
                    this.panelTree.Dock = DockStyle.None;
                    this.panelTree.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top| AnchorStyles.Bottom;
                }
                else
                {
                    this.panelTree.Dock = DockStyle.Fill;
                    //this.panelTree.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                }
            }
        }


        #endregion

        #region 初始化

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formid"></param>
        public void SetFormID(string formid)
        {
            this.formID = formid;
            Neusoft.HISFC.BizLogic.Admin.FunSetting manager = new Neusoft.HISFC.BizLogic.Admin.FunSetting();
            Neusoft.HISFC.Models.Admin.FunSetting obj = manager.GetFunSetting(formid);
            if (obj == null)
                return;
            this.SetControl(obj.ControlXML, obj.IsShowToolBar, obj.IsShowTreeView, obj.IsShowStatusBar, obj.IsDoubleClick, obj.TextPosition,obj.IsShowSearch);

        }

        /// <summary>
        /// 
        /// </summary>
        private void SetToolBarProperty()
        {
            for (int i = 0; i < this.toolBar1.Items.Count; i++)
            {
                if (this.toolBar1.Items[i].GetType() == typeof(ToolStripButton))
                    ToolBarButtonService.SetButtonProperty(this.toolBar1.Items[i]);
            }
            for (int i = 0; i < this.toolBar2.Items.Count; i++)
            {
                if (this.toolBar2.Items[i].GetType() == typeof(ToolStripButton))
                    ToolBarButtonService.SetButtonProperty(this.toolBar1.Items[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public frmBaseForm(Control control)
        {
            InitializeComponent();
            this.Icon = null;
            this.AddControl(control, panelMain);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="tv"></param>
        public frmBaseForm(Control control, TreeView tv)
        {
            InitializeComponent();
            this.Icon = null;
            this.SetTree(tv);
            this.AddControl(control, panelMain);


        }

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
                    this.iControlable = control as IControlable;
                    this.iQueryControlable = control as IQueryControlable;
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
                    this.iControlable = control as IControlable;
                    this.iQueryControlable = control as IQueryControlable;

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
                        this.iControlable = control as IControlable;
                        this.iQueryControlable = control as IQueryControlable;
                    }
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
            this.statusBar1.Visible = isShowStatusBar;
            this.toolBar2.Visible = isShowToolBar;
            this.panel2.Visible = isShowTree;
            this.isDoubleSelectValue = isDoubleClick;
            this.IsShowSearchTextBox = isShowSearch;
            ToolBarButtonService.SetButtonProperty(24,textPosition);
            if (this.isOneControl == true)
            {
                this.SetToolBar("default", "default", xml);
                ArrayList al = this.ConvertStringToArrayList(xml, "default", "default");
                if (al != null)
                {
                    try
                    {
                        Control control = this.panelMain.Controls[0];
                        Classes.Function.SetPropertyToControl(control, al);
                    }
                    catch { }
                
               

                }
            }
            this.AddControl(xml);
            
            
        }

        private void SetToolBar(string dllName, string controlName, string xml)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch { return; }
            XmlNodeList nodeToolBars = doc.SelectNodes("//Setting/ToolBar");
            if (nodeToolBars == null || nodeToolBars.Count == 0)
            {
                foreach (ToolStripItem defaultItem in this.toolBar1.Items)
                {
                    if (defaultItem is ToolStripButton)
                    {
                        ToolStripButton defaultTb = defaultItem as ToolStripButton;

                        defaultTb.Text = Neusoft.FrameWork.Management.Language.Msg( defaultTb.Text );
                    }
                }
                return;
            }
            ArrayList al1 = new ArrayList();
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
                    bool reset = true;
                    try
                    {
                        reset = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["Reset"].Value);
                    }
                    catch { }
                    if (reset)
                    {
                      
                        if (this.isOneControl ==false )
                        {
                            ArrayList al = null;
                            try
                            {
                                if (ControlsToolBars[tabControl1.SelectedIndex] == null)
                                {
                                    try
                                    {
                                        if (this.toolBarService != null)//添加按钮
                                        {
                                            al = toolBarService.GetToolButtons();
                                            try
                                            {
                                                ControlsToolBars[this.tabControl1.SelectedIndex] = al;
                                            }
                                            catch { }
                                        }
                                    }
                                    catch { }
                                }
                                al = ControlsToolBars[tabControl1.SelectedIndex] as ArrayList;
                               
                            }
                            catch { }
                            if (al != null)
                            {
                                ToolBarButtonService.ClearButton(toolBar1);
                                ToolBarButtonService.ClearButton(toolBar2);
                                foreach (ToolStripButton tb in al)
                                {
                                    ToolBarButtonService.SetButtonProperty(tb);
                                    this.toolBar2.Items.Add(tb);
                                }
                            }

                        }

                        ToolBarButtonService.ChangeButton(this.toolBar1, this.toolBar2, al1, al2);
                    }
                    break;
                }
            }

            
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="xml"></param>
        public virtual void AddControl(string xml)
        {
            if (xml == "") return;
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
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["DllName"].Value != dllName ||
                       node.Attributes["ControlName"].Value != controlName)
                    {
                        dllName = node.Attributes["DllName"].Value;
                        controlName = node.Attributes["ControlName"].Value;
                        if (dllName == "default" && controlName == "default") break;
                        string name = node.Attributes["Name"].Value;
                        if (name == "") name = "功能";
                        TabPage tp = new TabPage(name);
                        tp.Text = name;
                        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                        obj.ID = dllName;
                        obj.Name = controlName;
                        obj.Memo = xml;
                        tp.Tag = obj;
                        this.tabControl1.TabPages.Add(tp);
                        
                        if (this.tabControl1.SelectedIndex == 0)
                        {
                            this.tabControl1_SelectedIndexChanged(null, null);
                        }
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="xml"></param>
        public virtual void SetControl(string xml)
        {
            if (xml == "") return;
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
                //this.tabControl1.TabPages.Clear();
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["DllName"].Value != dllName ||
                       node.Attributes["ControlName"].Value != controlName)
                    {
                        dllName = node.Attributes["DllName"].Value;
                        controlName = node.Attributes["ControlName"].Value;
                        string name = node.Attributes["Name"].Value;
                        if (name == "") name = "功能";
                        TabPage tp = new TabPage(name);
                        tp.Text = name;
                        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                        obj.ID = dllName;
                        obj.Name = controlName;
                        obj.Memo = xml;
                        tp.Tag = obj;
                        this.tabControl1.TabPages.Add(tp);
                        if (this.tabControl1.SelectedIndex == 0)
                        {
                            this.tabControl1_SelectedIndexChanged(null, null);
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="dllName"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private ArrayList ConvertStringToArrayList(string xml, string dllName, string controlName)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            XmlNodeList nodes = doc.SelectNodes("//Setting/Control");
            ArrayList al = new ArrayList();
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["DllName"].Value == dllName &&
                    node.Attributes["ControlName"].Value == controlName)
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = node.Attributes["PropertyName"].Value;
                    obj.Name = node.Attributes["PropertyValue"].Value;
                    al.Add(obj);
                }
            }
            return al;
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

        protected virtual void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.isDoubleSelectValue) //双击
            {
                try
                {
                    this.iControlable.SetValue(this.tree.SelectedNode.Tag, this.tree.SelectedNode);
                }
                catch { }
                try
                {
                    if (this.MyToolBarService != null)
                        this.MyToolBarService.InfoChanged(this.tree.SelectedNode.Tag);
                }
                catch { }
            }
        }

        /// <summary>
        /// 初始化Control
        /// </summary>
        private void initControl()
        {
            if (this.iControlable != null)
            {
                iControlable.RefreshTree += new EventHandler(iControlable_RefreshTree);
                iControlable.StatusBarInfo += new MessageEventHandle(iControlable_StatusBarInfo);
                iControlable.SendMessage += new MessageEventHandle(iControlable_SendMessage);
                iControlable.SendParamToControl += new SendParamToControlHandle(iControlable_SendParamToControl);
                #region addby xuewj 2010-10-5 增加StatusBarPanel {C0E71DA8-F246-4ff2-98CB-7EC72A767453}
                iControlable.AddStastusBarPanel += new SendIconToStatusBar(iControlable_AddStastusBarPanel); 
                #endregion
                try
                {
                    if (this.tree != null)
                    {
                        if(this.tree.SelectedNode != null)
                            this.toolBarService = this.iControlable.Init(this.tree, this.tree.SelectedNode.Tag, this.Tag);
                        else
                            this.toolBarService = this.iControlable.Init(this.tree, null, this.Tag);
                    }
                    else
                        this.toolBarService = this.iControlable.Init(null,null, this.Tag);

                    
                }
                catch { }
                
                try
                {
                    if (this.toolBarService != null)//添加按钮
                    {
                        // 该变更作废 无法支持多语言版本
                        ////{BA871A23-D5AB-42c8-9C8A-B19339B991FC}   添加默认按钮  
                        //if (this.toolBarService.GetToolButton( "保存" ) == null)       //说明子类并没有增加保存按钮
                        //{
                        //    this.toolBarService.AddToolButton( this.tbSave );
                        //}
                        //if (this.toolBarService.GetToolButton( "查询" ) == null)       //说明子类并没有增加查询按钮
                        //{
                        //    this.toolBarService.AddToolButton( this.tbQuery );
                        //}
                        //if (this.toolBarService.GetToolButton( "打印" ) == null)       //说明子类并没有增加打印按钮
                        //{
                        //    this.toolBarService.AddToolButton( this.tbPrint );
                        //}
                        ////{BA871A23-D5AB-42c8-9C8A-B19339B991FC}


                        ArrayList al = toolBarService.GetToolButtons();
                        try
                        {
                            ControlsToolBars[this.tabControl1.SelectedIndex] = al;
                        }
                        catch
                        {
                        }
                        if (this.isOneControl)
                        {
                            ToolBarButtonService.ClearButton( toolBar1 );
                            ToolBarButtonService.ClearButton( toolBar2 );
                            foreach (ToolStripButton tb in al)
                            {
                                ToolBarButtonService.SetButtonProperty( tb );
                                this.toolBar2.Items.Add( tb );
                            }
                        }
                    }
                }
                catch { }
                
            }
        }

        #region addby xuewj 2010-10-5 增加StatusBarPanel {C0E71DA8-F246-4ff2-98CB-7EC72A767453}
        /// <summary>
        ///  增加StatusBarPanel
        /// </summary>
        /// <param name="icon">图标文件</param>
        /// <param name="msg">消息</param>
        /// <param name="index">插入位置 0,1,2,3</param>
        void iControlable_AddStastusBarPanel(System.Drawing.Icon icon, string msg, int index)
        {
            StatusBarPanel statusBarPanel = new StatusBarPanel();
            statusBarPanel.Icon = icon;
            statusBarPanel.Text = msg;
            statusBarPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            this.statusBar1.Panels.Insert(index, statusBarPanel);
        } 
        #endregion

        protected virtual void iControlable_SendParamToControl(object sender, string dllName, string controlName, object objParams)
        {
            //处理控件间的处理
            try
            {
                if (sender == null)
                {
                    if (dllName == "" || controlName == "") return;

                    for (int i = 0; i < alControls.Count; i++)
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = this.alControls[i] as Neusoft.FrameWork.Models.NeuObject;
                        if (obj != null & obj.ID == dllName && obj.Name == controlName)
                        {
                            this.tabControl1.SelectedIndex = i;
                            sender = this.tabControl1.SelectedTab.Controls[0];
                        }
                    }
                }
            }
            catch { }
            if (sender == null) //没有现成的
            {
                sender = Classes.Function.CreateControl(dllName, controlName);
                if (sender == null) return;
                IControlable ic = sender as IControlable;
                if (ic == null) return;
                ic.SetValue(objParams, null);
                Classes.Function.PopShowControl(sender as Control);
            }
            else
            {
                IControlable ic = sender as IControlable;
                if (ic == null) return;
                ic.SetValue(objParams, null);
            }

        }

        protected virtual void iControlable_SendMessage(object sender, string msg)
        {
            //处理接收到的消息
            
        }

        void iControlable_StatusBarInfo(object sender, string msg)
        {
            this.statusBar1.Panels[1].Text = msg;
        }

        protected virtual void iControlable_RefreshTree(object sender, EventArgs e)
        {
            if(this.tree != null) 
                this.tree.Refresh();
        }

        protected virtual void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.isDoubleSelectValue) return;
            try
            {
                 this.iControlable.SetValue(this.tree.SelectedNode.Tag, e.Node);
            }
            catch { }
            try
            {
                if (this.MyToolBarService != null)
                    this.MyToolBarService.InfoChanged(this.tree.SelectedNode.Tag);
            }
            catch { }
        }


        protected virtual void tree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (this.isDoubleSelectValue) return;
                if (this.iControlable.BeforSetValue(this.tree.SelectedNode.Tag, e) == -1)
                {
                    e.Cancel = true;
                }
            }
            catch { }
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

        private void frmBaseForm_Load(object sender, System.EventArgs e)
        {


            this.WindowState = FormWindowState.Maximized;
            if (FrameWork.Management.Connection.Operator == null || FrameWork.Management.Connection.Operator.ID =="")
            {
                this.lblSet.Visible = true;
                return;
            }
            try
            {
                if (((Neusoft.HISFC.Models.Base.Employee)FrameWork.Management.Connection.Operator).IsManager)
                {
                    this.lblSet.Visible = true;
                }
                else
                {
                    this.lblSet.Visible = false;
                }
            }
            catch { }

            try
            {
                if (this.tabControl1.Visible == false) //单控件
                    this.SetToolBar(this.panelMain.Controls[0].GetType().ToString());//设置单控件ToolBar接口
            }
            catch { }
            //获得快捷键哈希值
            GetKeyHas();

            this.toolBar1.BackColor = Classes.Function.GetSysColor(Classes.EnumSysColor.Blue);
            this.toolBar2.BackColor = Classes.Function.GetSysColor(Classes.EnumSysColor.Blue);
            
        }

        
        /// <summary>
        /// 获得快捷键哈希值
        /// </summary>
        private void GetKeyHas()
        {
            //清除所有快捷键
            keyTable.Clear();
            int index = 0;
            string text = string.Empty;
            KeysConverter kc = new KeysConverter();
            foreach(ToolStripItem tb in toolBar1.Items)
            {
                if(tb.GetType()!=typeof(System.Windows.Forms.ToolStripButton)) continue;
                text = tb.Text.Trim();
                //判断是否含有快捷键
                index = text.IndexOf('(');
                if (index < 0) continue;
                //获得快捷键
                string temptext=text.Substring(index+1,text.IndexOf(')')-index-1);
                index = temptext.IndexOf('+');
                //是否存在组合键
                //index=0代表快捷键为加号,index<0则是单独的快捷键
                if (index <= 0)
                {
                    if (temptext.Trim() == "+")
                    {
                        temptext = "Add";
                    }
                    else if (temptext.Trim() == "-")
                    {
                        temptext = "Subtract";
                    }

                    //获得键的哈希值
                    keyTable.Add(kc.ConvertFrom(temptext.Trim()).GetHashCode(), tb);
                }
                else
                {
                    string[] ss = temptext.Split('+');
                    if (ss == null || ss.Length == 0) continue;
                    int hsValue = 0;
                    foreach (string s in ss)
                    {
                        string ks = string.Empty;
                        if (s == "Ctrl")
                        {
                            ks = "Control";
                        }
                        else
                        {
                            ks = s;
                        }
                        hsValue += kc.ConvertFrom(ks).GetHashCode();
                    }
                    keyTable.Add(hsValue, tb);
                }
            }
        }
        #endregion

        #region toolbarClicked

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
            {
                if (iControlable != null)
                {
                    //*********工具栏快捷键*****************
                    int index=0;
                    string text = e.ClickedItem.Text;
                    
                    //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言处理
                    if (ToolBarButtonService.translateTextDictionary.ContainsKey( text ) == true)     //包含对应区域语言文本
                    {
                        text = ToolBarButtonService.translateTextDictionary[text];
                    }
                    //{1B10BCB7-8133-4282-8479-9C41FE5A23FD}

                    index=text.IndexOf('(');
                    if (index == -1)
                    {
                        //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言处理
                        ToolStripButton tb = new ToolStripButton( text );
                        ToolStripItemClickedEventArgs ee = new ToolStripItemClickedEventArgs( tb );

                        iControlable.ToolStrip_ItemClicked( sender, ee );
                        //{1B10BCB7-8133-4282-8479-9C41FE5A23FD}
                    }
                    else
                    {
                        ToolStripButton tb = new ToolStripButton( text.Substring( 0, index ) );
                        ToolStripItemClickedEventArgs ee = new ToolStripItemClickedEventArgs( tb );
                        iControlable.ToolStrip_ItemClicked( sender, ee );
                    }
                    
                    //iControlable.ToolStrip_ItemClicked(sender, ee);
                }
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
            else
            {

            }

            #endregion

            if (this.MyToolBarService != null)
            {
                try
                {
                    if(this.tree.SelectedNode!=null)
                       this.MyToolBarService.ToolBarClick(e.ClickedItem, this.tree.SelectedNode.Tag);
                    else
                       this.MyToolBarService.ToolBarClick(e.ClickedItem, null);
                }
                catch { }
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        private void Set()
        {
            string text = "没找到当前显示控件";
            if (iQueryControlable != null) text = iQueryControlable.ControlText;
            frmSetButton formSetButton = new frmSetButton(this, this.toolBar1, this.toolBar2, text);
            if (this.isOneControl)
                formSetButton.SetNotAllowAddControl(this.panelMain.Controls[0]);
            formSetButton.InitControl(this.formID);
           
            if (formSetButton.ShowDialog(this) == DialogResult.OK)
            {
                ToolBarButtonService.SetButtonProperty(formSetButton.ImageSize, formSetButton.TextPosition);
                ToolBarButtonService.ChangeButton(this.toolBar1, this.toolBar2, formSetButton.AlTb1, formSetButton.AlTb2);
                GetKeyHas();
            }
            else
            {

            }
        }

        private void printPreview()
        {
            if (this.iQueryControlable != null)
            {
                if (this.tree == null)
                    this.iQueryControlable.PrintPreview(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this.iQueryControlable.PrintPreview(this.tree, null);
                    else
                        this.iQueryControlable.PrintPreview(this.tree, this.tree.SelectedNode.Tag);

                }
            }
        }

        private void export()
        {
            if (this.iQueryControlable != null)
            {
                if (this.tree == null)
                    this.iQueryControlable.Export(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this.iQueryControlable.Export(this.tree, null);
                    else
                        this.iQueryControlable.Export(this.tree, this.tree.SelectedNode.Tag);

                }
            }
        }

        private void printSet()
        {
            if (this.iQueryControlable != null)
            {
                if (this.tree == null)
                    this.iQueryControlable.SetPrint(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this.iQueryControlable.SetPrint(this.tree, null);
                    else
                        this.iQueryControlable.SetPrint(this.tree, this.tree.SelectedNode.Tag);

                }
            }
        }

        private void save()
        {
            if (this.iQueryControlable != null)
            {
                if (this.tree == null)
                    this.iQueryControlable.Save(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this.iQueryControlable.Save(this.tree, null);
                    else
                        this.iQueryControlable.Save(this.tree, this.tree.SelectedNode.Tag);

                }
            }
        }

        private void exit()
        {
            if (this.iQueryControlable != null)
            {
                Neusoft.FrameWork.Models.NeuObject obj = null;
                try
                {
                    obj = this.tree.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                }
                catch { }
                if (this.iQueryControlable.Exit(null, obj) == 0)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void print()
        {
            if (this.iQueryControlable != null)
            {
                if (this.tree == null)
                    this.iQueryControlable.Print(null, null);
                else
                {
                    if (this.tree.SelectedNode == null)
                        this.iQueryControlable.Print(this.tree, null);
                    else
                        this.iQueryControlable.Print(this.tree, this.tree.SelectedNode.Tag);

                }
            }
        }

        private void Query()
        {
            if (this.tree == null)
            {
                if (this.iQueryControlable != null)
                {
                    this.iQueryControlable.Query(null, null);
                }
                if (this.iControlable != null)
                {
                    this.iControlable.SetValue(null, null);
                }
            }
            else
            {
                if (this.tree.CheckBoxes)
                {
                    this.alNodes = new ArrayList();
                    if (this.tree.Nodes.Count > 0)
                        this.GetSelectedNodesTag(this.tree.Nodes[0]);
                    if (this.iQueryControlable != null)
                    {
                        this.iQueryControlable.Query(this.tree, alNodes);
                    }
                    if (this.iControlable != null)
                    {
                        this.iControlable.SetValues(alNodes, this.tree);
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
                    if (this.iQueryControlable != null)
                    {
                        this.iQueryControlable.Query(this.tree, obj);
                    }
                    if (this.iControlable != null)
                    {
                        this.iControlable.SetValue(obj, this.tree.SelectedNode);
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
        /// <summary>
        /// 变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = this.tabControl1.SelectedTab.Tag as Neusoft.FrameWork.Models.NeuObject;
            #region addby xuewj 2010-10-5 修改bug医嘱状态栏不显示医嘱状态 {584FFA1D-4721-4581-8ECF-C24A42B55A7B}            
            if (this.tabControl1.SelectedTab.Controls.Count == 1
                    && this.tabControl1.TabPages.Count == 2//进入此方法时，医嘱主界面已经在动态加载第二个uc
                    && this.tabControl1.TabPages[0].Text == "医嘱")
            {
                iControlable = this.tabControl1.SelectedTab.Controls[0] as IControlable;
                iQueryControlable = this.tabControl1.SelectedTab.Controls[0] as IQueryControlable;
                this.currentControl = this.tabControl1.SelectedTab.Controls[0];
                this.initControl();
            } 
            #endregion
            else if (this.tabControl1.SelectedTab.Controls.Count <= 0)
            {
                if (obj != null)
                {
                    Control c = Classes.Function.CreateControl(obj.ID, obj.Name);
                    if (c == null) return;
                    ArrayList al = this.ConvertStringToArrayList(obj.Memo, obj.ID, obj.Name);
                    if (al != null)
                        Classes.Function.SetPropertyToControl(c, al);
                    c.Dock = DockStyle.Fill;
                    c.Visible = true;

                    this.tabControl1.SelectedTab.Controls.Add(c);
                    this.iniForm();
                    this.iniControlText(c);
                }
                else
                {
                    return;
                }
                iControlable = this.tabControl1.SelectedTab.Controls[0] as IControlable;
                iQueryControlable = this.tabControl1.SelectedTab.Controls[0] as IQueryControlable;
                this.currentControl = this.tabControl1.SelectedTab.Controls[0];
                this.initControl();
            }
            else
            {
                iControlable = this.tabControl1.SelectedTab.Controls[0] as IControlable;
                iQueryControlable = this.tabControl1.SelectedTab.Controls[0] as IQueryControlable;
                this.currentControl = this.tabControl1.SelectedTab.Controls[0];
            }

            //传递数据
            try
            {
                this.iControlable.SetValue(this.tree.SelectedNode.Tag, this.tree.SelectedNode);
            }
            catch { }

            if(obj != null)
                this.SetToolBar(obj.ID, obj.Name, obj.Memo);
        }

        #endregion

        #region 函数
        private void lblSet_Click(object sender, EventArgs e)
        {
            this.Set();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            panelWidth = this.panel2.Width;
            this.panel2.Width = this.btnShow.Width;
            this.panelTree.Visible = false;
            this.neuTextBox1.Visible = false;
            this.btnClose.Visible = false;
            this.splitter1.Visible = false;
            this.btnShow.Visible = true;
        }
        private int panelWidth = 0;
        private void btnShow_Click(object sender, EventArgs e)
        {
            this.panel2.Width = panelWidth;
            this.btnShow.Visible = false;
            this.panelTree.Visible = true;
            this.neuTextBox1.Visible = true;
            this.splitter1.Visible = true;
            this.btnClose.Visible = true;
        }

        #endregion

        #region 树查询操作
        private TreeNode selectedNode = null;
        private void SelectNode(TreeNode parentNode, string text)
        {
            if (selectedNode != null) return;

            if (this.isRight(parentNode,text))
            {
                selectedNode = parentNode;
                return;
            }
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (this.isRight(node, text))
                {
                    selectedNode = node;
                    return;
                }
                if (node.Nodes.Count > 0)
                    this.SelectNode(node, text);
            }

        }

        /// <summary>
        /// 判断是否查询到符合条件的
        /// </summary>
        /// <param name="node"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool isRight(TreeNode node, string text)
        {
            if (node.Text == text) return true;
            if (node.Tag != null)
            {
                Neusoft.FrameWork.Models.NeuObject obj = node.Tag as Neusoft.FrameWork.Models.NeuObject;
                try
                {
                    //{C222138C-F3D0-466d-A2A8-986D9A0C30A4}加入名称拼音码的检索
                    if (obj != null && (obj.ID.Substring(obj.ID.Length - text.Length) == text || obj.Name == text || obj.Memo == text || Neusoft.FrameWork.Public.String.GetSpell(obj.Name) == text.ToUpper()))
                    {
                        return true;
                    }
                }
                catch { }
                try
                {
                    if(node.Tag.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
                    {
                     
                            Neusoft.HISFC.Models.RADT.PatientInfo patient = node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

                            if (patient.PVisit.PatientLocation.Bed.ID.Substring(patient.PVisit.PatientLocation.Bed.ID.Length - text.Length) == text)
                            {
                                return true;
                            }
                       

                    } 
                }
                    catch { }
            }

            return false;
        }
        /// <summary>
        /// 查询显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (this.tree == null) return;
                try
                {
                    if(this.selectedNode !=null)
                        this.selectedNode = null;
                    foreach (TreeNode node in this.tree.Nodes)
                    {
                        this.SelectNode(node, this.neuTextBox1.Text);
                    }
                    this.tree.SelectedNode = selectedNode;
                    this.tree.SelectedNode.Parent.Expand();
                }
                catch { }

            }
        }
        #endregion

        private void frmBaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyTable == null || keyTable.Count == 0) return false;
            IEnumerator ie = keyTable.GetEnumerator();
            DictionaryEntry en;
            while (ie.MoveNext())
            {
                en = (DictionaryEntry)ie.Current;
                if (Convert.ToInt32(en.Key) == keyData.GetHashCode())
                {
                    ToolStripButton toolbt= en.Value as ToolStripButton;
                    ToolStripItemClickedEventArgs ee = new ToolStripItemClickedEventArgs(toolbt);
                    if(!toolbt.Enabled) return true;
                    this.toolStrip1_ItemClicked(this.toolBar1, ee);
                    return true ;
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        
    }

    public class newtrip : ToolStripItem
    {
        public newtrip() : base()
        {
            
        }
        public new string Text
        {
            set
            {
                base.Text=value;
            }
            get 
            {
                int index = base.Text.IndexOf('(');
                if (index < 0)
                {
                    return base.Text;
                }
                else
                {
                    return base.Text.Substring(0, index);
                }
            }
        }
    }
}


namespace Neusoft.HISFC.Models.Admin
{
    public class FunSetting:Neusoft.FrameWork.Models.NeuObject
    {
        private bool isShowToolbar = true;
        private bool isShowStatusBar = true;
        private bool isShowTreeView = true;
        private bool isDoubleClick = false;
        private int textPosition = 0;

        private bool isShowSearch = true;

        public bool IsShowSearch
        {
            get { return isShowSearch; }
            set { isShowSearch = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ControlXML
        {
            get
            {
                return base.Name;
            }
            set
            {
                 base.Name = value;
            }
        }
        /// <summary>
        /// 显示/不显示ToolBar
        /// </summary>
        public bool IsShowToolBar
        {
            get
            {
                return this.isShowToolbar;
            }
            set
            {
                this.isShowToolbar = value;
            }
        }

        /// <summary>
        /// 显示/不显示状态拦
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
            }
        }
        /// <summary>
        /// 显示/不显示TreeView
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
            }
        }
        /// <summary>
        /// 是否用DoubleClick变化树的选择
        /// </summary>
        public bool IsDoubleClick
        {
            get
            {
                return this.isDoubleClick;
            }
            set
            {
                this.isDoubleClick = value;
            }
        }
        /// <summary>
        ///文本方向
        /// </summary>
        public int TextPosition
        {
            get
            {
                return this.textPosition;
            }
            set
            {
                this.textPosition = value;
            }
        }
        /// <summary>
        /// 功能设置
        /// </summary>
        /// <returns></returns>
        public new FunSetting Clone()
        {
            return base.Clone() as FunSetting;
        }
     }
}
namespace Neusoft.HISFC.BizLogic.Admin 
{
    public class FunSetting : Neusoft.FrameWork.Management.Database
    {
        public Neusoft.HISFC.Models.Admin.FunSetting GetFunSetting(string formID)
        {
            //SELECT fun_code,   --功能编码 对应com_fun.fun_code字段
            //isshowtoolbar,   --显示工具栏
            //isshowstatusbar,   --显示状态条
            //isshowtreeview,   --显示树
            //isdoubleclick,   --双击
            //textposition,   --文本位置
            //controlsxml,   --控件XML
            //oper_code,   --操作员
            //oper_date    --操作日期
            //FROM com_fun_controls   --定义功能窗口控件
            //WHERE 
            string sql = "SELECT fun_code, isshowtoolbar,isshowstatusbar,isshowtreeview,isdoubleclick,textposition,controlsxml,isshowsearch,oper_code, oper_date    FROM com_fun_controls  where fun_code ='{0}' ";
            if (this.ExecQuery(sql, formID) == -1) return null;
            Neusoft.HISFC.Models.Admin.FunSetting obj = new Neusoft.HISFC.Models.Admin.FunSetting();
            if (this.Reader.Read())
            {
                obj.ID = formID;
                obj.IsShowToolBar = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[1]);
                obj.IsShowStatusBar = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[2]);
                obj.IsShowTreeView = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3]);
                obj.IsDoubleClick = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[4]);
                obj.TextPosition = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[5]);
                obj.ControlXML = this.Reader[6].ToString();
                if (this.Reader.IsDBNull(7))
                    obj.IsShowSearch = true;
                else
                    obj.IsShowSearch = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[7]);
                this.Reader.Close();
                return obj;

            }
            else
            {
                if(this.Reader.IsClosed == false) this.Reader.Close();
                this.Err = "没有找到记录";
                return null;
            }
            
            
            
        }

        public int InsertFunSetting(Neusoft.HISFC.Models.Admin.FunSetting obj)
        {
            //INSERT INTO com_fun_controls   --定义功能窗口控件
            //          ( fun_code,   --功能编码 对应com_fun.fun_code字段
            //            isshowtoolbar,   --显示工具栏
            //            isshowstatusbar,   --显示状态条
            //            isshowtreeview,   --显示树
            //            isdoubleclick,   --双击
            //            textposition,   --文本位置
            //            controlsxml,   --控件XML
            //            oper_code,   --操作员
            //            oper_date )  --操作日期
            //     VALUES 
            //          ( '{0}',   --功能编码 对应com_fun.fun_code字段
            //            '{1}',   --显示工具栏
            //            '{2}',   --显示状态条
            //            '{3}',   --显示树
            //            '{4}',   --双击
            //            '{5}',   --文本位置
            //            '{6}',   --控件XML
            //            '{7}',   --操作员
            //             sysdate); --操作日期

            string sql = "";


            sql = "INSERT INTO com_fun_controls   ( fun_code,       isshowtoolbar,        isshowstatusbar,        isshowtreeview,   isdoubleclick,         textposition,      controlsxml,        oper_code,      oper_date,isshowsearch ) VALUES    ( '{0}',     '{1}',     '{2}',    '{3}',   '{4}',  '{5}','{6}',  '{7}',to_date('" + System.DateTime.Now.ToString() + "','yyyy-mm-dd hh24:mi:ss'),'{8}')";

            return this.ExecNoQuery(sql, obj.ID, 
                Neusoft.FrameWork.Function.NConvert.ToInt32(obj.IsShowToolBar).ToString(),
                Neusoft.FrameWork.Function.NConvert.ToInt32(obj.IsShowStatusBar).ToString(),
                Neusoft.FrameWork.Function.NConvert.ToInt32(obj.IsShowTreeView).ToString(),
                Neusoft.FrameWork.Function.NConvert.ToInt32(obj.IsDoubleClick).ToString(),
                obj.TextPosition.ToString(),
                obj.ControlXML,
                this.Operator.ID,
               Neusoft.FrameWork.Function.NConvert.ToInt32(obj.IsShowSearch).ToString());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public int DeleteFunSetting(string formID)
        {
            //DELETE 
            //FROM com_fun_controls   --定义功能窗口控件
            //WHERE 
            string sql = "DELETE FROM com_fun_controls  WHERE fun_code = '{0}' ";
            return this.ExecNoQuery(sql,formID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int SetFunSetting(Neusoft.HISFC.Models.Admin.FunSetting obj)
        {
            if (this.DeleteFunSetting(obj.ID) == -1) return -1;
            if (this.InsertFunSetting(obj) <= 0) return -1;
            return 0;
        }

    }
}
