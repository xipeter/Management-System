using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Common
{
    public partial class ucQueryBaseForDataWindow : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucQueryBaseForDataWindow()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 交叉报表标志{40E52092-F854-464f-8A23-874BE7D4A543}
        /// </summary>
        protected bool isAcross = false;

        /// <summary>
        /// 左侧控件初始宽度
        /// </summary>
        protected const int LEFT_CONTROL_WIDTH = 200;

        /// <summary>
        /// 细节显示部分高度
        /// </summary>
        protected const int DETAIL_CONTROL_HEIGHT = 300;

        /// <summary>
        /// 左侧显示树控件是否可见
        /// </summary>
        protected bool isLeftVisible = true;

        /// <summary>
        /// 是否显示细节部分
        /// </summary>
        protected bool isShowDetail = false;

        /// <summary>
        /// 左侧控件,默认为其他控件
        /// </summary>
        protected QueryControls leftControl = QueryControls.Other;

        /// <summary>
        /// 左侧树控件
        /// </summary>
        protected TreeView tvLeft = null;

        /// <summary>
        /// 是否选择树节点后,调用Retrieve();
        /// </summary>
        protected bool isAfterSelectRetrieve = false;

        /// <summary>
        /// 主数据窗pbl路径
        /// </summary>
        protected string mainDWLabrary = string.Empty;

        /// <summary>
        /// 主数据窗DataObject
        /// </summary>
        protected string mainDWDataObject = string.Empty;

        /// <summary>
        /// 主查询默认控件
        /// </summary>
        protected QueryControls mainQueryControl = QueryControls.DataWindow;

        /// <summary>
        /// 是否查询条件只有开始时间,结束时间
        /// </summary>
        protected bool isRetrieveArgsOnlyTime = false;

        /// <summary>
        /// 开始时间
        /// </summary>
        protected DateTime beginTime = DateTime.MinValue;

        /// <summary>
        /// 结束时间
        /// </summary>
        protected DateTime endTime = DateTime.MinValue;

        /// <summary>
        /// 
        /// </summary>
        protected Neusoft.FrameWork.Management.DataBaseManger dataBaseManager = new Neusoft.FrameWork.Management.DataBaseManger();

        /// <summary>
        /// 登录人员信息
        /// </summary>
        protected Neusoft.HISFC.Models.Base.Employee employee = null;

        /// <summary>
        /// 数据窗报表Title
        /// </summary>
        protected string reportTitle = string.Empty;

        /// <summary>
        /// 数据窗报表Title的Text控件名称
        /// </summary>
        protected string reportTitleObjectName = string.Empty;

        /// <summary>
        /// 最后一次排序列名 {A652EF19-B5B2-4148-AAB1-774C2D3AE1B2}
        /// </summary>
        protected string lastSortedColumnName = string.Empty; 
        #endregion

        #region 属性

        /// <summary>
        /// 数据窗报表Title的Text控件名称
        /// </summary>
        [Category("控件设置"), Description("数据窗报表Title的Text控件名称")]
        public string ReportTitleObjectName 
        {
            get 
            {
                return this.reportTitleObjectName;
            }
            set 
            {
                this.reportTitleObjectName = value;
            }
        }

        /// <summary>
        /// 数据窗报表Title
        /// </summary>
        [Category("控件设置"), Description("数据窗报表Title")]
        public string ReportTitle 
        {
            get 
            {
                return this.reportTitle;
            }
            set 
            {
                this.reportTitle = value;
            }
        }

        /// <summary>
        /// 主查询默认控件
        /// </summary>
        [Category("控件设置"), Description("主数据窗pbl路径")]
        public QueryControls MainQueryControl 
        {
            get 
            {
                return this.mainQueryControl;
            }
            set 
            {
                this.mainQueryControl = value;

                this.SetMainQueryControl();
            }
        }

        /// <summary>
        /// 主数据窗pbl路径
        /// </summary>
        [Category("控件设置"), Description("主数据窗pbl路径")]
        public string MainDWLabrary 
        {
            get 
            {
                return this.mainDWLabrary;
            }
            set 
            {
                this.mainDWLabrary = value;
            }
        }

        /// <summary>
        /// 主数据窗DataObject
        /// </summary>
        [Category("控件设置"), Description("主数据窗DataObject")]
        public string MainDWDataObject 
        {
            get 
            {
                return this.mainDWDataObject;
            }
            set 
            {
                this.mainDWDataObject = value;
            }
        }

        /// <summary>
        /// 左侧显示树控件是否可见
        /// </summary>
        [Category("控件设置"), Description("左侧容器是否可见(树)")]
        public bool IsLeftVisible 
        {
            get 
            {
                return this.isLeftVisible;
            }
            set 
            {
                this.isLeftVisible = value;

                //设置左侧控件是否可见
                this.SetLeftControlVisible();
            }
        }

        /// <summary>
        /// 是否选择树节点后,调用Retrieve();
        /// </summary>
        [Category("控件设置"), Description("是否选择树节点后,调用Retrieve")]
        public bool IsAfterSelectRetrieve 
        {
            get 
            {
                return this.isAfterSelectRetrieve;
            }
            set 
            {
                this.isAfterSelectRetrieve = value;
            }
        }

        /// <summary>
        /// 左侧控件,默认为其他控件
        /// </summary>
        [Category("控件设置"), Description("左侧控件,默认为其他控件")]
        public QueryControls LeftControl 
        {
            get 
            {
                return this.leftControl;
            }
            set 
            {
                this.leftControl = value;

                this.SetLeftControl();
            }
        }

        /// <summary>
        /// 是否显示细节部分
        /// </summary>
        [Category("控件设置"), Description("是否显示细节部分")]
        public bool IsShowDetail 
        {
            get 
            {
                return this.isShowDetail;
            }
            set 
            {
                this.isShowDetail = value;

                this.SetDetailVisible();
            }
        }

        /// <summary>
        /// 是否查询条件只有开始时间,结束时间
        /// </summary>
        [Category("控件设置"), Description("是否查询条件只有开始时间,结束时间")]
        public bool IsRetrieveArgsOnlyTime
        {
            get
            {
                return this.isRetrieveArgsOnlyTime;
            }
            set
            {
                this.isRetrieveArgsOnlyTime = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置数据窗口Title名称
        /// </summary>
        protected virtual void SetTitle() 
        {
            if (this.dwMain != null) 
            {
                if (this.reportTitleObjectName != string.Empty)
                {
                    try
                    {
                        this.dwMain.Modify(this.reportTitleObjectName + ".Text = " + "'" + this.reportTitle + "'");
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// TreeView节点查询
        /// </summary>
        /// <returns></returns>
        protected virtual int OnQueryTree() 
        {
            if (this.tvLeft == null) 
            {
                return -1;
            }

            string queryText = this.cmbQuery.Text;

            if (queryText == string.Empty) 
            {
                return -1;
            }

            if (this.tvLeft.Nodes.Count <= 0) 
            {
                return -1;
            }

            TreeNode queryNode = this.tvLeft.Nodes[0];

            this.QueryTree(queryNode, queryText);

            return 1;
        }

        private void QueryTree(TreeNode nowNode, string queryText) 
        {
            if (nowNode == null) 
            {
                return;
            }
       
            if (nowNode.Tag != null && nowNode.Tag.ToString() == queryText)
            {
                this.tvLeft.Select();
                this.tvLeft.SelectedNode = nowNode;

                if (this.cmbQuery.Items.IndexOf(queryText) < 0)
                {
                    this.cmbQuery.Items.Add(queryText);
                }
                
                return;
            }
            if (nowNode.Text == queryText) 
            {
                this.tvLeft.Select();
                this.tvLeft.SelectedNode = nowNode;

                if (this.cmbQuery.Items.IndexOf(queryText) < 0)
                {
                    this.cmbQuery.Items.Add(queryText);
                }

                return;
            }
     
            foreach (TreeNode node in nowNode.Nodes) 
            {
                QueryTree(node, queryText);
            }

            return;
        }


        /// <summary>
        /// 画树方法.
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int OnDrawTree() 
        {
            if (this.tvLeft == null) 
            {
                return -1;
            }

            this.tvLeft.ImageList = new ImageList();
            this.tvLeft.ImageList.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息));
            this.tvLeft.ImageList.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.B摆药单));

            return 1;
        }

        /// <summary>
        /// 获得查询时间
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int GetQueryTime() 
        {
            if (this.dtpEndTime.Value < this.dtpBeginTime.Value) 
            {
                MessageBox.Show("结束时间不能小于开始时间");

                return -1;
            }

            this.beginTime = this.dtpBeginTime.Value;
            this.endTime = this.dtpEndTime.Value;

            return 1;
        }

        /// <summary>
        /// 设置主查询控件类型
        /// </summary>
        protected virtual void SetMainQueryControl() 
        {
            this.plRightTop.Controls.Clear();

            switch (this.mainQueryControl) 
            {
                case QueryControls.DataWindow:

                    this.dwMain = new NeuDataWindow.Controls.NeuDataWindow();

                    this.plRightTop.Controls.Add(this.dwMain);

                    this.dwMain.LiveScroll = true;
                    this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
                    this.dwMain.Dock = DockStyle.Fill;
                    this.dwMain.BringToFront();

                    break;
            }
        }

        /// <summary>
        /// 设置细节部分是否可见
        /// </summary>
        protected virtual void SetDetailVisible() 
        {
            this.plRightBottom.Visible = this.isShowDetail;

            this.plRightBottom.Height = this.isShowDetail ? DETAIL_CONTROL_HEIGHT : 0;

            this.slTop.Enabled = this.isShowDetail;

            this.slTop.Visible = this.isShowDetail;


        }

        /// <summary>
        /// 设置左侧控件
        /// </summary>
        protected virtual void SetLeftControl() 
        {
            //如果左侧控件已经不可见,以下代码不发生作用.
            if (!this.isLeftVisible) 
            {
                return;
            }

            //清除左侧控件容器已经加载的控件
            this.plLeftControl.Controls.Clear();

            switch (this.leftControl) 
            {
                case QueryControls.Tree:

                    this.tvLeft = new TreeView();
                    
                    this.plLeftControl.Controls.Add(tvLeft);

                    this.tvLeft.Dock = DockStyle.Fill;

                    this.tvLeft.AfterSelect += new TreeViewEventHandler(tvLeft_AfterSelect);

                    break;
            }
        }

        /// <summary>
        /// 如果有树的话,树的AfterSelect事件触发后,执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.isAfterSelectRetrieve) 
            {
                return;
            }
        }

        void tvLeft_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tv == null) 
            {
                return;
            }

            this.OnTreeViewAfterSelect(sender, e);
        }

        /// <summary>
        /// 设置左侧控件是否可见
        /// </summary>
        protected virtual void SetLeftControlVisible()
        {
            this.plLeft.Visible = this.isLeftVisible;

            this.plLeft.Width = this.isLeftVisible ? LEFT_CONTROL_WIDTH : 0;

            this.slLeft.Enabled = this.isLeftVisible;

            this.slLeft.Visible = this.isLeftVisible;
        }

        /// <summary>
        /// 按照开始时间和结束时间查询dw
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int RetrieveMainOnlyByTime() 
        {
            if (this.dwMain == null) 
            {
                return -1;
            }

            if (this.GetQueryTime() == -1) 
            {
                return -1;
            }

            return this.dwMain.Retrieve(beginTime, endTime);
        }
        
        /// <summary>
        /// 主数据窗Retrieve方法
        /// </summary>
        /// <param name="args">Retrieve参数列表</param>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int RetrieveMain(params object[] args) 
        {
            if (this.dwMain != null) 
            {
                try
                {
                    return this.dwMain.Retrieve(args);
                }
                catch { }
            }
            
            return 1;
        }
        /// <summary>
        /// 是否支持排序
        /// </summary>
        protected bool isSort = true;

        protected string sortColumn = string.Empty;

        /// <summary>
        /// 升序排序
        /// </summary>
        protected string sortType = "A";

        /// <summary>
        /// 排序 成功 1 失败 -1
        /// </summary>
        /// <returns></returns>
        protected int OnSort() 
        {
            try
            {
                if (this.isSort)
                {
                    string ls_CurObj = "";

                    int ll_CurRowNumber = 0;
                    ls_CurObj = this.dwMain.ObjectUnderMouse.Gob.Name; //得出objectName
                    ll_CurRowNumber = this.dwMain.ObjectUnderMouse.RowNumber; //得出当前Row

                    if (this.dwMain.Describe(ls_CurObj + ".Band") == "header")
                    {
                        if (ll_CurRowNumber == 0 & this.dwMain.Describe(ls_CurObj + ".Text") != "!")
                        {
                            sortColumn = ls_CurObj.Substring(0, ls_CurObj.Length - 2);

                            //{A652EF19-B5B2-4148-AAB1-774C2D3AE1B2}
                            if (sortType == "A")
                            {
                                if (DataWindowSort(this.dwMain, sortColumn, sortType))
                                {
                                    sortType = "D";
                                }
                                else
                                {
                                    return -1;
                                }
                            }
                            else
                            {
                                if (DataWindowSort(this.dwMain, sortColumn, sortType))
                                {
                                    sortType = "A";
                                }
                                else
                                {
                                    return -1;
                                }
                            }
                            //{A652EF19-B5B2-4148-AAB1-774C2D3AE1B2}
                            this.lastSortedColumnName = ls_CurObj;
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            finally
            {

            }

            return 1;
        }

        /// <summary>
        /// 取消掉其他列的排序符号
        /// </summary>
        /// <param name="dwControl">当前数据窗口</param>
        private void DeleleSortFlag(Sybase.DataWindow.DataWindowControl dwControl) 
        {
            string columnName = string.Empty;

            try
            {
                for (int i = 1; i < dwControl.ColumnCount + 1; i++)
                {
                    columnName = dwControl.Describe('#' + i.ToString() + ".name") + "_t";

                    //dwControl.Modify(columnName + ".text = '" + this.dwMain.Describe(columnName + ".text").Replace("↑", string.Empty) + "'");
                    //dwControl.Modify(columnName + ".text = '" + this.dwMain.Describe(columnName + ".text").Replace("↓", string.Empty) + "'");
                }
            }
            catch { }
        }

        /// <summary>
        /// 排序的方法
        /// </summary>
        /// <param name="dwControl">当前数据窗</param>
        /// <param name="currColumn">当前列</param>
        /// <param name="sortType">排序类型</param>
        /// <returns>成功 true 失败 false</returns>
        private bool DataWindowSort(Sybase.DataWindow.DataWindowControl dwControl, string currColumn, string sortType) 
        {
            try
            {
                //排序  
                dwControl.SetSort(currColumn + " " + sortType);
                dwControl.Sort();

                //创建升序的箭头图形

                DeleleSortFlag(dwControl);

                switch (sortType)
                {
                    case "A":

                        dwControl.Modify(currColumn + "_t" + ".text = '" + this.dwMain.Describe(currColumn + "_t" + ".text") + "↑'");

                        break;
                    case "D":
                        dwControl.Modify(currColumn + "_t" + ".text = '" + this.dwMain.Describe(currColumn + "_t" + ".text") + "↓'");

                        break;
                }

                return true;
            }
            catch
            {
                return false;
            }

            finally
            {

            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected int Init() 
        {
            if (this.dwMain != null)
            {
                this.dwMain.LibraryList = Application.StartupPath + "\\" + this.mainDWLabrary;

                this.dwMain.DataWindowObject = this.mainDWDataObject;
            }

            this.dtpBeginTime.Value = this.dataBaseManager.GetDateTimeFromSysDateTime();
            this.dtpEndTime.Value = this.dataBaseManager.GetDateTimeFromSysDateTime();

            this.OnDrawTree();

            if (this.tvLeft != null) 
            {
                if (this.tvLeft.Nodes.Count > 0) 
                {
                    this.tvLeft.Select();
                    this.tvLeft.SelectedNode = this.tvLeft.Nodes[0];
                }
            }

            this.SetTitle();

            return 1;
        }

        /// <summary>
        /// Load事件
        /// </summary>
        protected virtual void OnLoad() 
        {
            this.employee = (Neusoft.HISFC.Models.Base.Employee)this.dataBaseManager.Operator;
        }

        /// <summary>
        /// 自行设计查询条件的查询,继承用
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int OnRetrieve(params object[] objects) 
        {
            #region 交叉报表重新初始化，防止查询错误{40E52092-F854-464f-8A23-874BE7D4A543}
            if (this.isAcross)
            {
                this.dwMain.Dispose();
                this.dwMain = new NeuDataWindow.Controls.NeuDataWindow();
                this.plRightTop.Controls.Add(this.dwMain);
                this.dwMain.DataWindowObject = "";
                this.dwMain.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dwMain.LibraryList = "";
                this.dwMain.Location = new System.Drawing.Point(0, 0);
                this.dwMain.Name = "dwMain";
                this.dwMain.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
                this.dwMain.Size = new System.Drawing.Size(544, 276);
                this.dwMain.TabIndex = 0;
                this.dwMain.Text = "neuDataWindow1";
                this.dwMain.Click += new System.EventHandler(this.dwMain_Click);
                if (this.dwMain != null)
                {
                    this.dwMain.LibraryList = Application.StartupPath + "\\" + this.mainDWLabrary;

                    this.dwMain.DataWindowObject = this.mainDWDataObject;
                }
            }
            #endregion


            if (dwMain != null)
            {
                dwMain.Retrieve(objects);
            }

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Export(object sender, object neuObject)
        {
            OnExport();
            return base.Export(sender, neuObject);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int OnExport()
        {
            if (dwMain == null)
            {
                return -1;
            }    

            this.DeleleSortFlag(dwMain);

            System.Windows.Forms.SaveFileDialog dd = new SaveFileDialog();
            dd.Filter = "txt files (*.xls)|*.xls";
            if (dd.ShowDialog() == DialogResult.Cancel)
            {
                return 1;
            }
            dwMain.SaveAs(dd.FileName, Sybase.DataWindow.FileSaveAsType.Excel, true);

            return 1;
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrintPreview(object sender, object neuObject)
        {
            if (this.dwMain != null)
            {
                frmPreviewDataWindow frmPreview = new frmPreviewDataWindow();

                frmPreview.PreviewDataWindow = dwMain;

                if (frmPreview.ShowDialog() == DialogResult.OK)
                    this.dwMain.PrintProperties.Preview = false;
            }

            return base.OnPrintPreview(sender, neuObject);

            
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.dwMain != null) 
            {
                try
                {
                    this.DeleleSortFlag(dwMain);
                    this.dwMain.PrintProperties.Preview = false;
                    this.dwMain.Print(true, true);
                }
                catch { }
            }
            
            return base.OnPrint(sender, neuObject);
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 左侧容器装载控件
        /// </summary>
        public enum QueryControls 
        {
            /// <summary>
            /// TreeView控件
            /// </summary>
            Tree = 0,

            /// <summary>
            /// DataWindow控件
            /// </summary>
            DataWindow,

            /// <summary>
            /// 文本控件
            /// </summary>
            Text,

            /// <summary>
            /// 其他控件
            /// </summary>
            Other
        }

        #endregion

        #region 事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            Cursor = Cursors.WaitCursor;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据,请等待....");

            Application.DoEvents();
            
            if (this.isRetrieveArgsOnlyTime)
            {
                this.RetrieveMainOnlyByTime();
            }
            else 
            {
                this.OnRetrieve();
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            Cursor = Cursors.Arrow;

            return 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.IsShowDetail = false;
        }

        private void ucQueryBaseForDataWindow_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.OnLoad();

            this.Init();
        }

        private void cmbQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.OnQueryTree();
            }
        }

        private void btnQueryTree_Click(object sender, EventArgs e)
        {
            this.OnQueryTree();
        }

        private void dwMain_Click(object sender, EventArgs e)
        {
            if (this.dwMain != null)
            {
                this.OnSort();
            }
        }




        #endregion

       
    }
}
