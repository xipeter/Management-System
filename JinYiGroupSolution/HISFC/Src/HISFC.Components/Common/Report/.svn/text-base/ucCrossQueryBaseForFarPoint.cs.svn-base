using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Common.Report
{
    public partial class ucCrossQueryBaseForFarPoint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCrossQueryBaseForFarPoint()
        {
            InitializeComponent();

        }

        #region 变量

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
        protected bool isLeftVisible = false;

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
        /// 查询用的语句
        /// </summary>
        private string querySql = string.Empty;

        /// <summary>
        /// 分页符所在的行数10
        /// </summary>
        private int rowPageBreak = -1;

        /// <summary>
        /// 主表格配置文件的位置
        /// </summary>
        private string mainSheetXmlFileName = string.Empty;

        ///// <summary>
        ///// 详细表格配置文件名
        ///// </summary>
        //private string detailSheetXmlFileName = string.Empty;

        /// <summary>
        /// 显示开始行的索引
        /// </summary>
        private int dataBeginRowIndex = 0;
        /// <summary>
        /// 显示开始列的索引
        /// </summary>
        private int dataBeginColumnIndex = 0;
        /// <summary>
        /// 行标题开始行的索引
        /// </summary>
        private int rowsHeaderBeginRowIndex = 0;
        /// <summary>
        /// 行标题开始列的索引 
        /// </summary>
        private int rowsHeaderBeginColumnIndex = 0;
        /// <summary>
        /// 列标题开始行的索引
        /// </summary>
        private int columnsHeaderBeginRowIndex = 0;
        /// <summary>
        /// 列标题开始列的索引
        /// </summary>
        private int columnsHeaderBeginColumnIndex = 0;
        #region {9F609C45-B357-4807-A1E1-3741F08D471A}
        /// <summary>
        /// 列总计级别
        /// </summary>
        private string[] columnsTotalLevel = new string[0];
        /// <summary>
        /// 列总计级别
        /// </summary>
        [Category("报表参数"), Description("设置数据集中列总计级别！")]
        public string ColumnsTotalLevel
        {
            get
            {
                string rtn = string.Empty;
                if (columnsTotalLevel != null)
                {
                    //Array.Reverse(dataCrossColumns);
                    rtn = string.Join("|", this.columnsTotalLevel);
                }
                return rtn;
            }
            set
            {
                columnsTotalLevel = value.Split('|');

            }
        }
        /// <summary>
        /// 行总计级别
        /// </summary>
        private string[] rowsTotalLevel = new string[0];
        /// <summary>
        /// 行总计级别
        /// </summary>
        [Category("报表参数"), Description("设置数据集中行总计级别！")]
        public string RowsTotalLevel
        {
            get
            {
                string rtn = string.Empty;
                if (rowsTotalLevel != null)
                {
                    //Array.Reverse(dataCrossColumns);
                    rtn = string.Join("|", this.rowsTotalLevel);
                }
                return rtn;
            }
            set
            {
                rowsTotalLevel = value.Split('|');
            }
        } 
        #endregion
        /// <summary>
        /// 数据显示列索引
        /// </summary>
        // private string[] dataDisplayColumns = new string[0];
        /// <summary>
        /// 数据交叉行
        /// </summary>
        private string[] dataCrossColumns = new string[0];
        /// <summary>
        /// 设置数据集中用于形成数据交叉行的列，
        /// </summary>
        [Category("报表参数"), Description("设置数据集中用于形成数据交叉行的列！")]
        public string DataCrossColumns
        {
            get
            {
                string rtn = string.Empty;
                if (dataCrossColumns != null)
                {
                    //Array.Reverse(dataCrossColumns);
                    rtn = string.Join("|", this.dataCrossColumns);
                }
                return rtn;
            }
            set
            {
                dataCrossColumns = value.Split('|');
                ComputeIndex();
            }
        }
        /// <summary>
        /// 数据交叉列
        /// </summary>
        private string[] dataCrossRows = new string[0];
        /// <summary>
        /// 设置数据集中用于形成数据交叉列的列，
        /// </summary>
        [Category("报表参数"), Description("设置数据集中用于形成数据交叉列的列！")]
        public string DataCrossRows
        {
            get
            {
                string rtn = string.Empty;
                if (dataCrossRows != null)
                {
                    rtn = string.Join("|", this.dataCrossRows);
                }
                return rtn;
            }
            set
            {
                dataCrossRows = value.Split('|');
                ComputeIndex();
            }
        }
        /// <summary>
        /// 数据交叉值
        /// </summary>
        private string[] dataCrossValues = new string[0];
        /// <summary>
        /// 设置数据集中用于形成数据交叉值的列，
        /// </summary>
        [Category("报表参数"), Description("设置数据集中用于形成数据交叉值的列！")]
        public string DataCrossValues
        {
            get
            {
                string rtn = string.Empty;
                if (dataCrossValues != null)
                {
                    rtn = string.Join("|", this.dataCrossValues);
                }
                return rtn;
            }
            set
            {
                dataCrossValues = value.Split('|');
                ComputeIndex();
            }
        }
        /// <summary>
        /// 查询参数
        /// </summary>
        private System.Collections.Generic.List<Neusoft.FrameWork.Models.NeuObject> queryParams = new List<Neusoft.FrameWork.Models.NeuObject>();
        /// <summary>
        /// 数据行数
        /// </summary>
        protected int dataRowCount = 0;
        /// <summary>
        /// 查询类型
        /// </summary>
        private QuerySqlType querySqlTypeValue = QuerySqlType.id;
        DB db = new DB();
        private Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();
        private string hospitalName = string.Empty;
        private int useParamCellsCount = 0;

        #endregion

        #region 属性
        [Category("报表参数"), Description("设置报表查询时需要用参数替换的单元格数量！")]
        public int UseParamCellsCount
        {
            get { return useParamCellsCount; }
            set { useParamCellsCount = value; }
        }
        public string HospitalName
        {
            get
            {
                if (DesignMode == false)
                {
                    if (string.IsNullOrEmpty(hospitalName) == true)
                    {
                        hospitalName = con.GetHospitalName();
                    }
                }
                return hospitalName;
            }
            set { hospitalName = value; }
        }
        public DB Db
        {
            get { return db; }
            set { db = value; }
        }
        public FarPoint.Win.Spread.SheetView SvMain
        {
            get
            {
                if (this.neuSpread1.Sheets.Count > 0)
                {
                    return this.neuSpread1.Sheets[0];
                }
                return null;
            }
            set
            {
                //FarPoint.Win.Spread.SheetView v = null;
                if (this.neuSpread1.Sheets.Count > 0)
                {
                    this.neuSpread1.Sheets[0] = value;
                }
                //v = value ;
            }
        }

        public FarPoint.Win.Spread.SheetView SvDetail
        {
            get
            {
                if (this.neuSpread2.Sheets.Count > 0)
                {
                    return this.neuSpread2.Sheets[0];
                }
                return null;
            }
            set
            {
                //FarPoint.Win.Spread.SheetView v = null;
                if (this.neuSpread2.Sheets.Count > 0)
                {
                    this.neuSpread2.Sheets[0] = value;
                }
                //v = value;
            }
        }
        [Category("报表参数"), Description("设置报表查询时的参数！")]
        public System.Collections.Generic.List<Neusoft.FrameWork.Models.NeuObject> QueryParams
        {
            get { return queryParams; }
            set { queryParams = value; }
        }
        [Category("报表参数"), Description("设置报表查询时使用的sql类型！")]
        public QuerySqlType QuerySqlTypeValue
        {
            get { return querySqlTypeValue; }
            set { querySqlTypeValue = value; }
        }
        ///// <summary>
        ///// 设置数据集中用于显示的列，
        ///// </summary>
        //[Category("报表参数"), Description("设置报表需要显示的数据列！")]
        //public string DataDisplayColumns
        //{
        //    get
        //    {
        //        string rtn = string.Empty;
        //        if (dataDisplayColumns != null)
        //        {
        //            rtn = string.Join("|", this.dataDisplayColumns);
        //        }
        //        return rtn;
        //    }
        //    set
        //    {
        //        dataDisplayColumns = value.Split('|');
        //        rowsHeaderBeginColumnIndex = dataBeginRowIndex;
        //        if (this.dataCrossValues.Length > 1)
        //        {
        //            rowsHeaderBeginRowIndex = dataBeginColumnIndex + dataCrossRows.Length + 1;
        //        }
        //        else
        //        {
        //            rowsHeaderBeginRowIndex = dataBeginColumnIndex + dataCrossRows.Length;
        //        }
        //        columnsHeaderBeginColumnIndex = dataBeginRowIndex + dataCrossColumns.Length; ;
        //        columnsHeaderBeginRowIndex = dataBeginRowIndex;
        //    }
        //}
        [Category("报表参数"), Description("设置报表查询出的数据集，显示的起始行的索引！")]
        public int DataBeginRowIndex
        {
            get
            {
                return dataBeginRowIndex;
            }
            set
            {
                dataBeginRowIndex = value;
                ComputeIndex();
            }
        }
        [Category("报表参数"), Description("设置报表查询出的数据集，显示的起始列的索引！")]
        public int DataBeginColumnIndex
        {
            get
            {
                return dataBeginColumnIndex;
            }
            set
            {
                dataBeginColumnIndex = value;
                ComputeIndex();
            }
        }
        [Category("报表参数"), Description("设置报表主表格配置文件名！")]
        public string MainSheetXml
        {
            get { return mainSheetXmlFileName; }
            set { mainSheetXmlFileName = value; }
        }

        [EditorAttribute(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), Category("报表参数"), Description("设置报表查询时使用的sql！")]
        public string QuerySql
        {
            get { return querySql; }
            set { querySql = value; }
        }
        /// <summary>
        /// 数据窗报表Title的Text控件名称
        /// </summary>
        [Category("报表参数"), Description("每页显示的数据行")]
        public int PageRowCount
        {
            get { return rowPageBreak; }
            set { rowPageBreak = value; }
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
                this.isShowDetail = false;

                this.SetDetailVisible();
            }
        }



        #endregion

        #region 方法




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
        /// 设置数据窗口Title名称
        /// </summary>
        protected virtual void SetTitle()
        {
            if (this.SvMain != null)
            {
                if (this.HospitalName != string.Empty)
                {
                    try
                    {
                        // SvMain.Cells["{title}"].Text = HospitalName + SvMain.Cells["{title}"].Text;
                        FarPoint.Win.Spread.Cell c = null;
                        string CellText = string.Empty;
                        c = SvMain.GetCellFromTag(c, "{hospitalName}");
                        if (c != null)
                        {
                            CellText = c.Note;
                            CellText = CellText.Replace("{hospitalName}", HospitalName);
                            c.Text = CellText;
                        }
                    }
                    catch { }
                }
            }
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
                this.OnQuery(sender, e);
            }
            return;
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
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected int Init()
        {
            #region 加载XML配置
            OpenSpread();
            #endregion
            #region 默认时间设置成当前时间到当前时间前一个月的时间
            this.dtpBeginTime.Value = this.dataBaseManager.GetDateTimeFromSysDateTime().AddMonths(-1);
            this.dtpEndTime.Value = this.dataBaseManager.GetDateTimeFromSysDateTime();
            #endregion

            #region 清空数据表格
            if (SvMain.RowCount > this.DataBeginRowIndex + 1)
            {
                SvMain.ClearRange(this.DataBeginRowIndex + 1, 0, SvMain.Rows.Count - 1, SvMain.Columns.Count - 1, false);
            }
            #endregion

            this.OnDrawTree();

            if (this.tvLeft != null)
            {
                if (this.tvLeft.Nodes.Count > 0)
                {
                    this.tvLeft.Select();
                    this.tvLeft.SelectedNode = this.tvLeft.Nodes[0];
                }
            }
            //this.neuSpread1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(neuSpread1_CellClick);
            this.neuSpread1.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(neuSpread1_SelectionChanged);
            this.SetTitle();
            return 1;
        }

        void neuSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            OnSort();
        }

        void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OnSort();
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
            if (SvMain != null)
            {
                //SvMain.Retrieve(objects);
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
            if (SvMain == null)
            {
                return -1;
            }

            //this.DeleleSortFlag(SvMain);

            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return 1;
            }
            //SvMain.SaveAs(dd.FileName, Sybase.DataWindow.FileSaveAsType.Excel, true);
            neuSpread1.SaveExcel(sfd.FileName, FarPoint.Excel.ExcelSaveFlags.NoFlagsSet);
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
            if (this.SvMain != null)
            {
                //frmPreviewDataWindow frmPreview = new frmPreviewDataWindow();

                ////frmPreview.PreviewDataWindow = SvMain;

                //if (frmPreview.ShowDialog() == DialogResult.OK)
                //{ }
                //    //this.SvMain.PrintProperties.Preview = false;
                //this.neuSpread1.OwnerPrintDraw(
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
            if (this.SvMain != null)
            {
                try
                {
                    this.neuSpread1.PrintSheet(SvMain);
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
        public enum QuerySqlType
        {
            /// <summary>
            /// id
            /// </summary>
            id,
            /// <summary>
            /// 
            /// </summary>
            text,
        }

        #endregion

        #region 事件
        protected void OpenSpread()
        {
            //SvMain = new FarPoint.Win.Spread.SheetView();
            //this.neuSpread1.Sheets.Add(SvMain);
            #region 读xml设置fp
            if (string.IsNullOrEmpty(this.MainSheetXml) == false)
            {
                this.neuSpread1.Open(Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + "Report\\" + this.MainSheetXml);
            }
            //if (string.IsNullOrEmpty(this.DetailSheetXml) == false)
            //{
            //    this.neuSpread2.Open(Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + "Report\\" + this.DetailSheetXml);
            //}
            #endregion
            #region 用open方法设置fp格式后必须重新指定sht的临时变量
            if (this.neuSpread1.Sheets.Count > 0)
            {
                string f = string.Empty;

                SvMain = neuSpread1.Sheets[0];
                SvMain.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            }
            if (neuSpread2.Sheets.Count > 0)
            {
                SvDetail = neuSpread2.Sheets[0];
                SvDetail.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            }
            #endregion
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            Cursor = Cursors.WaitCursor;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据,请等待....");

            Application.DoEvents();

            #region 清空数据表格
            if (SvMain.RowCount >= this.dataBeginRowIndex + 1)
            {
                SvMain.ClearRange(this.dataBeginRowIndex, dataBeginColumnIndex, SvMain.Rows.Count, SvMain.Columns.Count, false);
            }
            #endregion
            #region 参数替换
            FarPoint.Win.Spread.Cell c = null;
            for (int j = 0; j < this.useParamCellsCount; j++)
            {
                string CellText = string.Empty;
                c = SvMain.GetCellFromTag(c, "{QueryParams}");
                if (c != null)
                {
                    CellText = c.Note;
                    for (int i = 0; i < this.QueryParams.Count; i++)
                    {
                        CellText = CellText.Replace("{" + i + "}", this.QueryParams[i].ToString());
                    }
                    c.Text = CellText;
                }
            }
            #endregion
            #region 显示到表格

            DataTable dt = new DataTable();
            dataRowCount = 0;
            switch (this.QuerySqlTypeValue)
            {
                case QuerySqlType.id:
                    if (Db.QueryDataBySqlId(this.QuerySql, ref dt, this.QueryParams) != 1)
                    {
                        Cursor = Cursors.Arrow;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        return -1;
                    }
                    break;
                case QuerySqlType.text:
                    if (Db.QueryDataBySql(this.QuerySql, ref dt, this.QueryParams) != 1)
                    {
                        Cursor = Cursors.Arrow;
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        return -1;
                    }
                    break;
                default:
                    break;
            }
            ///数据集dt
            //******************
            //┌	─	─	─	─	─	─	─	─	─	─	─	┐
            //│	A	│	C	│	G	│	I	│	1	│	0	│
            //│	A	│	C	│	G	│	J	│	1	│	0	│
            //│	A	│	C	│	H	│	K	│	1	│	0	│
            //│	A	│	C	│	H	│	L	│	1	│	0	│
            //│	A	│	D	│	G	│	I	│	1	│	0	│
            //│	A	│	D	│	G	│	J	│	1	│	0	│
            //│	A	│	D	│	H	│	K	│	1	│	0	│
            //│	A	│	D	│	H	│	L	│	1	│	0	│
            //│	B	│	E	│	G	│	I	│	1	│	0	│
            //│	B	│	E	│	G	│	J	│	1	│	0	│
            //│	B	│	E	│	H	│	K	│	1	│	0	│
            //│	B	│	E	│	H	│	L	│	1	│	0	│
            //│	B	│	F	│	G	│	I	│	1	│	0	│
            //│	B	│	F	│	G	│	J	│	1	│	0	│
            //│	B	│	F	│	H	│	K	│	1	│	0	│
            //│	B	│	F	│	H	│	L	│	1	│	0	│
            //└	─	─	─	─	─	─	─	─	─	─	─	┘
            //******************
            #region 分别交叉行与列
            DataTable dtCrossRows = null;
            DataTable dtCrossColumns = null;
            DataTable dtCrossValues = null;


            #region 先求值后交叉
            DataSetHelper dsh = new DataSetHelper();

            ///生成行数据集，不包括合计行
            dtCrossRows = dsh.SelectDistinctByIndexs("", dt, dataCrossRows);
            ///数据集dtCrossRows
            //******************
            //┌	─	┬	─	┐
            //│	G	│	I	│
            //│	G	│	J	│
            //│	H	│	K	│
            //│	H	│	L	│
            //└	─	┴	─	┘       
            //******************
            ///生成列数据集，不包括合计列
            dtCrossColumns = dsh.SelectDistinctByIndexs("", dt, dataCrossColumns);
            ///数据集dtCrossColumns
            //******************
            //┌	─	┬	─	┐
            //│	A	│	C	│
            //│	A	│	D	│
            //│	B	│	E	│
            //│	B	│	F	│
            //└	─	┴	─	┘          
            //******************
            //SvMain.DataSource = dtCrossColumns;
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //return 1;
            #region 遍历列数据集，向值数据集添加列,并求计算值
            ///值数据集

            dtCrossValues = new DataTable();
            foreach (DataRow dr in dtCrossColumns.Rows)
            {
                #region 向值数据集添加列
                //string columnsName = string.Empty;
                //foreach (object o in dr.ItemArray)
                //{
                //    columnsName = columnsName + o.ToString() + "|";
                //}
                foreach (string s in dataCrossValues)
                {
                    //值数据集，添加一列
                    dtCrossValues.Columns.Add(new DataColumn("", dt.Columns[int.Parse(s)].DataType));

                }
                #endregion
            }
            ///数据集dtCrossValues
            //********  
            //┌	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┐
            //│		│		│		│		│		│		│		│		│
            //└	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┘
            //********
            #region 遍历行数据集每一行
            ///当前行数据集，行索引
            int currRowIdx = 0;
            //遍历行数据集
            foreach (DataRow drRow in dtCrossRows.Rows)
            {
                ///值数据集，添加一行
                dtCrossValues.Rows.Add(dtCrossValues.NewRow());
                //计算当前行数据集，行索引
                currRowIdx = dtCrossRows.Rows.IndexOf(drRow);
                #region 遍历列数据集每一行
                //当前列数据集，行索引
                int currColIdx = 0;
                foreach (DataRow drColumn in dtCrossColumns.Rows)
                {
                    //计算当前列数据集，行索引
                    currColIdx = dtCrossColumns.Rows.IndexOf(drColumn);

                    //当前值数据集，列数量
                    int valColCnt = 0;
                    //计算当前值数据集，列数量
                    valColCnt = this.dataCrossValues.Length;
                    #region 计算当前单元格的数据值
                    ///当前单元格的数据值表达式
                    string currExp = string.Empty;
                    #region 遍历行集，计算当前单元格值的行表达式部分
                    //当前行集，值索引
                    int expRowsIdx = 0;
                    //string currRowHeader = string.Empty;
                    foreach (string sDataCrossRows in this.dataCrossRows)
                    {
                        //计算当前行集，值索引（因为没有重复值所以可以这么取）
                        expRowsIdx = Array.IndexOf(this.dataCrossRows, sDataCrossRows);
                        //根据原始数据集对应值列的类型计算表达式，详见msdn“ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.NETDEVFX.v20.chs/cpref4/html/P_System_Data_DataColumn_Expression.htm”
                        switch (dt.Columns[int.Parse(sDataCrossRows)].DataType.ToString())
                        {
                            case "System.Decimal":
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossRows)].Caption + " = " + dtCrossRows.Rows[currRowIdx][expRowsIdx].ToString() + " AND ";
                                    break;
                                }
                            case "System.DateTime":
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossRows)].Caption + " = #" + dtCrossRows.Rows[currRowIdx][expRowsIdx] + "# AND ";
                                    break;
                                }
                            case "System.String":
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossRows)].Caption + " = '" + dtCrossRows.Rows[currRowIdx][expRowsIdx] + "' AND ";
                                    break;
                                }
                            default:
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossRows)].Caption + " = '" + dtCrossRows.Rows[currRowIdx][expRowsIdx] + "' AND ";
                                    break;
                                }
                        }
                    }
                    #endregion
                    #region 遍历列集，计算当前单元格的,数据值的，列表达式部分
                    //当前列集，值索引
                    int expColumnsIdx = 0;
                    foreach (string sDataCrossColumns in this.dataCrossColumns)
                    {
                        //计算当前列集，值索引（因为没有重复值所以可以这么取）
                        expColumnsIdx = Array.IndexOf(this.dataCrossColumns, sDataCrossColumns);
                        //根据原始数据集对应值列的类型计算表达式，详见msdn“ms-help://MS.VSCC.v80/MS.MSDN.v80/MS.NETDEVFX.v20.chs/cpref4/html/P_System_Data_DataColumn_Expression.htm”
                        switch (dt.Columns[int.Parse(sDataCrossColumns)].DataType.ToString())
                        {
                            case "System.Decimal":
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossColumns)].Caption + " = " + dtCrossColumns.Rows[currColIdx][expColumnsIdx].ToString() + " AND ";
                                    break;
                                }
                            case "System.DateTime":
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossColumns)].Caption + " = #" + dtCrossColumns.Rows[currColIdx][expColumnsIdx] + "# AND ";
                                    break;
                                }
                            case "System.String":
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossColumns)].Caption + " = '" + dtCrossColumns.Rows[currColIdx][expColumnsIdx] + "' AND ";
                                    break;
                                }
                            default:
                                {
                                    currExp = currExp + dt.Columns[int.Parse(sDataCrossColumns)].Caption + " = '" + dtCrossColumns.Rows[currColIdx][expColumnsIdx] + "' AND ";
                                    break;
                                }
                        }
                    }
                    #endregion
                    #region 去尾部的“AND”
                    currExp = currExp.Remove(currExp.Length - 4);
                    #endregion
                    #region 遍历值数据集每一行
                    //当前单元格的数据值
                    string[] currVal = new string[this.dataCrossValues.Length];
                    //当前值集，值索引
                    int currValIdx = 0;
                    DataRow[] arryDr;
                    arryDr = dt.Select(currExp);
                    foreach (string s in this.dataCrossValues)
                    {
                        //计算当前值集，值索引（因为没有重复值所以可以这么取）
                        currValIdx = Array.IndexOf(this.dataCrossValues, s);
                        currVal[currValIdx] = "0";
                        #region 遍历取查询出来的行，计算对应位置的值
                        if (arryDr.Length > 0)
                        {
                            //有可能有多行，遍历取值
                            foreach (DataRow drCurrExp in arryDr)
                            {
                                //TODO:需要添加各种计算方式,现在仅支持sum运算
                                // currVal[currValIdx] = (int.Parse(currVal[currValIdx]) + int.Parse(drCurrExp[int.Parse(s)].ToString())).ToString();
                                switch (drCurrExp.Table.Columns[int.Parse(s)].DataType.ToString())
                                {
                                    case "System.Decimal":
                                        {
                                            currVal[currValIdx] = (decimal.Parse(currVal[currValIdx]) + decimal.Parse(drCurrExp[int.Parse(s)].ToString())).ToString();
                                            break;
                                        }
                                    case "System.DateTime":
                                        {
                                            currVal[currValIdx] = DateTime.Parse(drCurrExp[int.Parse(s)].ToString()).ToString();
                                            break;
                                        }
                                    case "System.String":
                                        {
                                            currVal[currValIdx] = drCurrExp[int.Parse(s)].ToString();
                                            break;
                                        }
                                    default:
                                        {
                                            currVal[currValIdx] = (int.Parse(currVal[currValIdx]) + int.Parse(drCurrExp[int.Parse(s)].ToString())).ToString();
                                            break;
                                        }
                                }
                            }
                        }
                        #endregion
                        dtCrossValues.Rows[currRowIdx][currColIdx * valColCnt + currValIdx] = currVal[currValIdx];
                    }
                    #endregion
                    #endregion
                }
                #endregion
            }
            #endregion
            #endregion
            ///数据集dtCrossValues
            //********  
            //┌	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┐
            //│	1	│	0	│	1	│	0	│	1	│	0	│	1	│	0	│
            //│	1	│	0	│	1	│	0	│	1	│	0	│	1	│	0	│
            //│	1	│	0	│	1	│	0	│	1	│	0	│	1	│	0	│
            //│	1	│	0	│	1	│	0	│	1	│	0	│	1	│	0	│
            //└	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┘          
            //********  
            #region 添加列合计值
            DataTable dtCrossViewColumns = this.TotalCrossDataTableColumns(dtCrossValues, dt, this.dataCrossColumns, this.dataCrossValues);


            //SvMain.DataSource = dtCrossViewColumns;
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //return 1;
            #endregion
            #region 添加行合计值
            DataTable dtCrossViewRows = this.TotalCrossDataTableRows(dtCrossViewColumns, dt, this.dataCrossRows);
            //SvMain.DataSource = dtCrossViewRows;
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //return 1;
            #endregion
            #region 计算行列标题，显示行列标题
            #region 添加列标题，列合计标题
             DataTable dtCrossViewColumnsTitle = this.CrossDataTable(dt, this.dataCrossColumns,this.columnsTotalLevel);
        
            //SvMain.DataSource = dtCrossViewColumnsTitle;
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //return 1;
            #endregion
            #region 添加行标题，行合计标题
             DataTable dtCrossViewRowsTitle = this.CrossDataTable(dt, this.dataCrossRows, this.rowsTotalLevel);
            #endregion

            #region 合并
            #region 显示合并列
            DataTable dtCrossViewColumnsTitleIncludValues = dtCrossViewColumnsTitle.Clone();
            //如果值列大于一列,就需要加一个值列名显示用的行
            if (this.dataCrossValues.Length > 1)
            {
                int dataCrossValuesIdx = 0;
                dtCrossViewColumnsTitleIncludValues.Columns.Add(
                    new DataColumn("", typeof(string)));
                dataCrossValuesIdx = this.dataCrossColumns.Length;
                int dtCrossViewColumnsTitleRowIdx = 0;
                while (dtCrossViewColumnsTitleRowIdx < dtCrossViewColumnsTitle.Rows.Count)
                {
                    int dataCrossValuesItemIdx = 0;
                    foreach (string s in this.dataCrossValues)
                    {
                        dtCrossViewColumnsTitleIncludValues.Rows.Add(dtCrossViewColumnsTitle.Rows[dtCrossViewColumnsTitleRowIdx].ItemArray);
                        dataCrossValuesItemIdx = Array.IndexOf(dataCrossValues, s);
                        dtCrossViewColumnsTitleIncludValues.Rows
                            [dtCrossViewColumnsTitleRowIdx * dataCrossValues.Length + dataCrossValuesItemIdx]
                            [dataCrossValuesIdx]
                            = dt.Columns[int.Parse(s)].Caption;
                    }
                    dtCrossViewColumnsTitleRowIdx++;
                }
                //SvMain.DataSource = dtCrossViewColumnsTitleIncludValues;
                //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //return 1;
                Function.DisplayToFpReverse(SvMain, dtCrossViewColumnsTitleIncludValues, columnsHeaderBeginRowIndex, columnsHeaderBeginColumnIndex);
                SpanDisplayedFpReverse(SvMain, dtCrossViewColumnsTitleIncludValues, columnsHeaderBeginRowIndex, columnsHeaderBeginColumnIndex);
                SpanDisplayedFpReverseRows(SvMain, dtCrossViewColumnsTitleIncludValues, columnsHeaderBeginRowIndex, columnsHeaderBeginColumnIndex);
            }
            else
            {
                int dataCrossValuesIdx = 0;
                dataCrossValuesIdx = this.dataCrossColumns.Length;
                int dtCrossViewColumnsTitleRowIdx = 0;
                while (dtCrossViewColumnsTitleRowIdx < dtCrossViewColumnsTitle.Rows.Count)
                {
                    foreach (string s in this.dataCrossValues)
                    {
                        dtCrossViewColumnsTitleIncludValues.Rows.Add(dtCrossViewColumnsTitle.Rows[dtCrossViewColumnsTitleRowIdx].ItemArray);
                    }
                    dtCrossViewColumnsTitleRowIdx++;
                }
                //SvMain.DataSource = dtCrossViewColumnsTitleIncludValues;
                //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //return 1;
                Function.DisplayToFpReverse(SvMain, dtCrossViewColumnsTitleIncludValues, columnsHeaderBeginRowIndex, columnsHeaderBeginColumnIndex);
                SpanDisplayedFpReverseOneValue(SvMain, dtCrossViewColumnsTitleIncludValues, columnsHeaderBeginRowIndex, columnsHeaderBeginColumnIndex);
                SpanDisplayedFpReverseRowsOneValue(SvMain, dtCrossViewColumnsTitleIncludValues, columnsHeaderBeginRowIndex, columnsHeaderBeginColumnIndex);
            }

            #endregion
            #region 显示合并行
            Function.DisplayToFp(SvMain, dtCrossViewRowsTitle, rowsHeaderBeginRowIndex, rowsHeaderBeginColumnIndex);
            SpanDisplayedFp(SvMain, dtCrossViewRowsTitle, rowsHeaderBeginRowIndex, rowsHeaderBeginColumnIndex);
            SpanDisplayedFpRows(SvMain, dtCrossViewRowsTitle, rowsHeaderBeginRowIndex, rowsHeaderBeginColumnIndex);
            int colIdx = 0;
            foreach (string s in dataCrossRows)
            {

                SvMain.Cells[rowsHeaderBeginRowIndex - 1, rowsHeaderBeginColumnIndex + colIdx].Text = dt.Columns[int.Parse(s)].Caption;
                colIdx++;
            }
            #endregion
            #endregion
            #endregion
            #endregion
            //SvMain.DataSource = dtCrossViewRowsTitle;
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //return 1;
            #endregion
            this.dataRowCount = dtCrossViewRows.Rows.Count;
            #region 设置表格行数
            if (this.SvMain.Rows.Count < DataBeginRowIndex + 1 + dtCrossViewRows.Rows.Count)
            {
                this.SvMain.RowCount = DataBeginRowIndex + 1 + dtCrossViewRows.Rows.Count;
            }
            #endregion

            #region 逐个单元格填充交叉后的数据数据
            Function.DisplayToFp(SvMain, dtCrossViewRows, rowsHeaderBeginRowIndex, columnsHeaderBeginColumnIndex);
            #endregion

            #endregion
          
            #region 设置分页符
            if (this.rowPageBreak > 0)
            {
                for (int i = 1; (i * this.rowPageBreak + this.DataBeginRowIndex) + 1 < this.SvMain.Rows.Count; i++)
                {
                    this.SvMain.SetRowPageBreak((i * this.rowPageBreak + this.DataBeginRowIndex) + 1, true);
                }
            }
            #endregion

            Function.DrawGridLine(SvMain, this.dataBeginRowIndex, this.dataBeginColumnIndex, dtCrossViewRows.Rows.Count + dtCrossViewColumnsTitleIncludValues.Columns.Count, dtCrossViewRows.Columns.Count + dtCrossViewRowsTitle.Columns.Count);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            #region 合并相同项

            #endregion
            Cursor = Cursors.Arrow;

            return 1;
        }
        protected virtual int SpanDisplayedFp(FarPoint.Win.Spread.SheetView sv, DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int ColumnSpan = 0;
            int dtRowIdx = 0;
            string tempVal = string.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                dtRowIdx = dt.Rows.IndexOf(dr);
                int dtColumnIdx = 0;
                ColumnSpan = 1;
                tempVal = string.Empty;
                foreach (DataColumn dc in dt.Columns)
                {
                    dtColumnIdx = (dt.Columns.Count - 1) - dt.Columns.IndexOf(dc);
                    tempVal = dr[dtColumnIdx].ToString();
                    if (string.IsNullOrEmpty(tempVal) == false)
                    {
                        break;
                    }
                    else
                    {
                        ColumnSpan++;
                    }
                }
                sv.Cells[dtRowIdx + beginRowIdx, dtColumnIdx + beginColumnIdx].ColumnSpan = ColumnSpan;
                sv.Cells[dtRowIdx + beginRowIdx, dtColumnIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                sv.Cells[dtRowIdx + beginRowIdx, dtColumnIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            return 1;
        }
        protected virtual int SpanDisplayedFpReverseOneValue(FarPoint.Win.Spread.SheetView sv, DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int RowSpan = 0;
            int dtRowIdx = 0;
            string tempVal = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                dtRowIdx = dt.Rows.IndexOf(dr);
                int dtColumnIdx = 0;
                RowSpan = 1;
                tempVal = string.Empty;
                foreach (DataColumn dc in dt.Columns)
                {
                    dtColumnIdx = (dt.Columns.Count - 1) - dt.Columns.IndexOf(dc);
                    tempVal = dr[dtColumnIdx].ToString();
                    if (string.IsNullOrEmpty(tempVal) == false)
                    {
                        break;
                    }
                    else
                    {
                        RowSpan++;
                    }
                }
                sv.Cells[dtColumnIdx + beginRowIdx, dtRowIdx + beginColumnIdx].RowSpan = RowSpan;
                sv.Cells[dtColumnIdx + beginRowIdx, dtRowIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                sv.Cells[dtColumnIdx + beginRowIdx, dtRowIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="dt"></param>
        /// <param name="beginRowIdx"></param>
        /// <param name="beginColumnIdx"></param>
        /// <returns></returns>
        protected virtual int SpanDisplayedFpReverse(FarPoint.Win.Spread.SheetView sv, DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int RowSpan = 0;
            int dtRowIdx = 0;
            string tempVal = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                dtRowIdx = dt.Rows.IndexOf(dr);
                int dtColumnIdx = 0;
                RowSpan = 1;
                tempVal = string.Empty;
                foreach (DataColumn dc in dt.Columns)
                {
                    dtColumnIdx = (dt.Columns.Count - 1) - dt.Columns.IndexOf(dc);
                    if (dtColumnIdx < dt.Columns.Count - 1)
                    {
                        tempVal = dr[dtColumnIdx].ToString();
                        if (string.IsNullOrEmpty(tempVal) == false)
                        {
                            break;
                        }
                        else
                        {
                            RowSpan++;
                        }
                    }
                }
                sv.Cells[dtColumnIdx + beginRowIdx, dtRowIdx + beginColumnIdx].RowSpan = RowSpan;
                sv.Cells[dtColumnIdx + beginRowIdx, dtRowIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                sv.Cells[dtColumnIdx + beginRowIdx, dtRowIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="dt"></param>
        /// <param name="beginRowIdx"></param>
        /// <param name="beginColumnIdx"></param>
        /// <returns></returns>
        protected virtual int SpanDisplayedFpReverseRowsOneValue(FarPoint.Win.Spread.SheetView sv, DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int ColumnSpan = 0;
            string tempVal = string.Empty;
            int dtColumnIdx = 0;
            int spanRowIdx = 0;
            int spanColumnIdx = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                dtColumnIdx = dt.Columns.IndexOf(dc);
                if (dtColumnIdx < dt.Columns.Count)
                {
                    ColumnSpan = 1;
                    tempVal = string.Empty;
                    int dtRowIdx = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtRowIdx = dt.Rows.IndexOf(dr);

                        //tempVal = dr[dtColumnIdx].ToString();
                        if (string.IsNullOrEmpty(tempVal) == false)
                        {
                            if (tempVal == dr[dtColumnIdx].ToString())
                            {
                                ColumnSpan++;
                                if (dtRowIdx == dt.Rows.Count - 1)
                                {
                                    //tempVal = dr[dtColumnIdx].ToString();
                                    //spanRowIdx = dtRowIdx;
                                    //spanColumnIdx = dtColumnIdx;
                                    sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].ColumnSpan = ColumnSpan;
                                    sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                    sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                }
                            }
                            else
                            {
                                sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].ColumnSpan = ColumnSpan;
                                sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                tempVal = dr[dtColumnIdx].ToString();
                                spanRowIdx = dtRowIdx;
                                spanColumnIdx = dtColumnIdx;
                                ColumnSpan = 1;
                                // break;

                            }
                        }
                        else
                        {
                            tempVal = dr[dtColumnIdx].ToString();
                            spanRowIdx = dtRowIdx;
                            spanColumnIdx = dtColumnIdx;
                            ColumnSpan = 1;
                            //ColumnSpan++;
                        }

                    }

                }
            }
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="dt"></param>
        /// <param name="beginRowIdx"></param>
        /// <param name="beginColumnIdx"></param>
        /// <returns></returns>
        protected virtual int SpanDisplayedFpReverseRows(FarPoint.Win.Spread.SheetView sv, DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int ColumnSpan = 0;
            string tempVal = string.Empty;
            int dtColumnIdx = 0;
            int spanRowIdx = 0;
            int spanColumnIdx = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                dtColumnIdx = dt.Columns.IndexOf(dc);
                if (dtColumnIdx < dt.Columns.Count - 1)
                {
                    int dtRowIdx = 0;
                    ColumnSpan = 1;
                    tempVal = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtRowIdx = dt.Rows.IndexOf(dr);


                        //tempVal = dr[dtColumnIdx].ToString();
                        if (string.IsNullOrEmpty(tempVal) == false)
                        {
                            if (tempVal == dr[dtColumnIdx].ToString())
                            {
                                ColumnSpan++;
                                //if (dtRowIdx==dt.Rows.Count -1 && dtColumnIdx==0)
                                if (dtRowIdx == dt.Rows.Count - 1)
                                {
                                    //tempVal = dr[dtColumnIdx].ToString();
                                    //spanRowIdx = dtRowIdx;
                                    //spanColumnIdx = dtColumnIdx;
                                    sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].ColumnSpan = ColumnSpan;
                                    sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                    sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                }
                            }
                            else
                            {
                                sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].ColumnSpan = ColumnSpan;
                                sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                sv.Cells[spanColumnIdx + beginRowIdx, spanRowIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                tempVal = dr[dtColumnIdx].ToString();
                                spanRowIdx = dtRowIdx;
                                spanColumnIdx = dtColumnIdx;
                                ColumnSpan = 1;
                                //break;

                            }
                        }
                        else
                        {
                            tempVal = dr[dtColumnIdx].ToString();
                            spanRowIdx = dtRowIdx;
                            spanColumnIdx = dtColumnIdx;
                            ColumnSpan = 1;
                            //ColumnSpan++;
                        }

                    }

                }
            }
            return 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="dt"></param>
        /// <param name="beginRowIdx"></param>
        /// <param name="beginColumnIdx"></param>
        /// <returns></returns>
        protected virtual int SpanDisplayedFpRows(FarPoint.Win.Spread.SheetView sv, DataTable dt, int beginRowIdx, int beginColumnIdx)
        {
            int RowsSpan = 0;
            string tempVal = string.Empty;
            int dtColumnIdx = 0;
            int spanRowIdx = 0;
            int spanColumnIdx = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                dtColumnIdx = dt.Columns.IndexOf(dc);
                //最后一列不合并
                if (dtColumnIdx < dt.Columns.Count - 1)
                {
                    int dtRowIdx = 0;
                    RowsSpan = 1;
                    tempVal = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dtRowIdx = dt.Rows.IndexOf(dr);
                        //不为空
                        if (string.IsNullOrEmpty(tempVal) == false)
                        {
                            //相等
                            if (tempVal == dr[dtColumnIdx].ToString())
                            {
                                //tempVal = dr[dtColumnIdx].ToString();
                                RowsSpan++;
                                if (dtRowIdx == dt.Rows.Count - 1)
                                {
                                    //tempVal = dr[dtColumnIdx].ToString();
                                    //spanRowIdx = dtRowIdx;
                                    //spanColumnIdx = dtColumnIdx;
                                    //合并行
                                    sv.Cells[spanRowIdx + beginRowIdx, spanColumnIdx + beginColumnIdx].RowSpan = RowsSpan;
                                    sv.Cells[spanRowIdx + beginRowIdx, spanColumnIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                    sv.Cells[spanRowIdx + beginRowIdx, spanColumnIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                }
                            }
                            //不想等
                            else
                            {
                                //合并行
                                sv.Cells[spanRowIdx + beginRowIdx, spanColumnIdx + beginColumnIdx].RowSpan = RowsSpan;
                                sv.Cells[spanRowIdx + beginRowIdx, spanColumnIdx + beginColumnIdx].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                sv.Cells[spanRowIdx + beginRowIdx, spanColumnIdx + beginColumnIdx].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                                //存新参数
                                tempVal = dr[dtColumnIdx].ToString();
                                spanRowIdx = dtRowIdx;
                                spanColumnIdx = dtColumnIdx;
                                RowsSpan = 1;
                                //break;
                            }
                        }
                        //为空
                        else
                        {
                            tempVal = dr[dtColumnIdx].ToString();
                            spanRowIdx = dtRowIdx;
                            spanColumnIdx = dtColumnIdx;
                            RowsSpan = 1;
                            //RowsSpan++;
                        }
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 合计交叉数据表列
        /// </summary>
        /// <param name="dtCrossValues"></param>
        /// <param name="dtCrossColumns"></param>
        /// <param name="fieldIndexsColumns"></param>
        /// <param name="fieldIndexsValues"></param>
        /// <returns></returns>
        protected virtual DataTable TotalCrossDataTableColumns(DataTable dtCrossValues, DataTable dt, string[] fieldIndexsColumns, string[] fieldIndexsValues)
        {
            DataSetHelper dsh = new DataSetHelper();
            #region 交叉数据，用最直观的算法实现
            DataTable dtCrossValuesColumns = dsh.SelectDistinctByIndexs("", dt, fieldIndexsColumns);
            //交叉列数据集的行值数组；
            object[] tempRowsValue;
            //当前计算的行索引
            int computedIdx;

            #region 交叉列数据集的行值数组,的长度为交叉列的长度
            //tempRowsValue[2]
            //─	─	2	─	─
            //┌	─	┬	─	┐
            //│		│		│
            //└	─	┴	─	┘
            tempRowsValue = new object[fieldIndexsColumns.Length];
            computedIdx = 0;

            ///暂存合计值，第一维的长度是，列字段索引的长度
            ///第二维的长度是，值表的行数
            object[,] tempTotalValues;
            //tempTotalValues[2*2,4]          
            //─	─	2	─	×	─	2	─	┼	─	2	─	×	─	2	─	┼	─	2	─	×	─	2	─	┼	─	2	─	×	─	2	─	─
            //┌	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┐
            //│		│		│		│		│		│		│		│		│		│		│		│		│		│		│		│		│
            //└	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┘
            //tempTotalValues[2*2,4]          
            //─	─	2	─	×	─	2	─	─	┐
            //┌	─	┬	─	┬	─	┬	─	┐	│
            //│		│		│		│		│	│
            //│		│		│		│		│	4
            //│		│		│		│		│	│
            //│		│		│		│		│	│
            //└	─	┴	─	┴	─	┴	─	┘	│

            tempTotalValues = new object[fieldIndexsColumns.Length * fieldIndexsValues.Length, dtCrossValues.Rows.Count];
            #region 合计值初始化为0
            int valueRowIdxDefault = 0;
            ///合计后的值表
            DataTable dtCrossValuesTotalCross = new DataTable();
            //遍历所有行
            //初始化为“0”
            //─	─	2	─	×	─	2	─	┼	─	2	─	×	─	2	─	┼	─	2	─	×	─	2	─	┼	─	2	─	×	─	2	─	─
            //┌	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┐
            //│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│	0	│
            //└	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┘
            //─	─	2	─	×	─	2	─	─	┐
            //┌	─	┬	─	┬	─	┬	─	┐	│
            //│	0	│	0	│	0	│	0	│	│
            //│	0	│	0	│	0	│	0	│	4
            //│	0	│	0	│	0	│	0	│	│
            //│	0	│	0	│	0	│	0	│	│
            //└	─	┴	─	┴	─	┴	─	┘	│

            foreach (DataRow dr in dtCrossValues.Rows)
            {
                valueRowIdxDefault = dtCrossValues.Rows.IndexOf(dr);
                //遍历所有列
                for (int i = 0; i < dtCrossValuesColumns.Columns.Count; i++)
                {
                    //遍历所有值
                    for (int j = 0; j < fieldIndexsValues.Length; j++)
                    {
                        //初始化为“0”
                        tempTotalValues[i * fieldIndexsValues.Length + j * (fieldIndexsValues.Length - 1), valueRowIdxDefault] = "0";
                    }
                }
                //添加空白行在交叉数据集上
                dtCrossValuesTotalCross.Rows.Add(dtCrossValuesTotalCross.NewRow());
            }
            //dtCrossValuesTotalCross
            //─	─	┐
            //┌	┐	│
            //│	│	│
            //│	│	4
            //│	│	│
            //│	│	│
            //└	┘	│


            #endregion
            //循环所有交叉列数据集的行
            while (computedIdx < dtCrossValuesColumns.Rows.Count)
            {
                //取交叉列数据集当前行值
                //─	─	2	─	─
                //┌	─	┬	─	┐
                //│	A	│	C	│
                //└	─	┴	─	┘
                tempRowsValue = dtCrossValuesColumns.Rows[computedIdx].ItemArray;
                #region 计算每一级别的合计值
                //遍历所有值
                for (int j = 0; j < fieldIndexsValues.Length; j++)
                {
                    //因为是列模式添加，所以要每次新建列
                    //dtCrossValuesTotalCross
                    //┌	─	┬	─	┐+……
                    //└	─	┴	─	┘
                    dtCrossValuesTotalCross.Columns.Add(
                        new DataColumn("", dt.Columns[int.Parse(fieldIndexsValues[j].ToString())].DataType));
                }
                //dtCrossValuesTotalCross while循环完以后的样子
                //─	─	2	─	┼	─	2	─	┼	─	2	─	┼	─	2	─	─	┐
                //┌	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┬	─	┐	┼
                //│		│		│		│		│		│		│		│		│	│
                //│		│		│		│		│		│		│		│		│	4
                //│		│		│		│		│		│		│		│		│	│
                //│		│		│		│		│		│		│		│		│	│
                //└	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┴	─	┘	┼
                int valueRowIdx = 0;
                //遍历交叉值表累加

                foreach (DataRow dr in dtCrossValues.Rows)
                {
                    //计算值索引(0-3)
                    valueRowIdx = dtCrossValues.Rows.IndexOf(dr);
                    //遍历交叉行数据集每一列，暂存值到累加数组
                    //i(0-1)
                    for (int i = 0; i < dtCrossValuesColumns.Columns.Count; i++)
                    {
                        //遍历所有值
                        //j(0-1)
                        for (int j = 0; j < fieldIndexsValues.Length; j++)
                        {
                            //tempTotalValues[i * (fieldIndexsValues.Length) + j * (fieldIndexsValues.Length - 1), valueRowIdx] = (int.Parse(tempTotalValues[i * (fieldIndexsValues.Length) + j * (fieldIndexsValues.Length - 1), valueRowIdx].ToString()) + int.Parse(dr[computedIdx * fieldIndexsValues.Length + j].ToString())).ToString();
                            switch (dr.Table.Columns[computedIdx * fieldIndexsValues.Length + j].DataType.ToString())
                            {
                                case "System.Decimal":
                                    {
                                        tempTotalValues[i * (fieldIndexsValues.Length)
                                            + j * (fieldIndexsValues.Length - 1), valueRowIdx]
                                            = (Decimal.Parse(tempTotalValues[i * (fieldIndexsValues.Length)
                                            + j * (fieldIndexsValues.Length - 1), valueRowIdx].ToString())
                                            + Decimal.Parse(dr[computedIdx * fieldIndexsValues.Length + j].ToString())).ToString();
                                        break;
                                    }
                                case "System.DateTime":
                                    {
                                        tempTotalValues[i * (fieldIndexsValues.Length) + j * (fieldIndexsValues.Length - 1), valueRowIdx]
                                            = dr[computedIdx * fieldIndexsValues.Length + j].ToString();
                                        break;
                                    }
                                case "System.String":
                                    {
                                        tempTotalValues[i * (fieldIndexsValues.Length) + j * (fieldIndexsValues.Length - 1), valueRowIdx]
                                            = dr[computedIdx * fieldIndexsValues.Length + j].ToString();
                                        break;
                                    }
                                default:
                                    {
                                        tempTotalValues[i * (fieldIndexsValues.Length)
                                            + j * (fieldIndexsValues.Length - 1), valueRowIdx]
                                            = (int.Parse(tempTotalValues[i * (fieldIndexsValues.Length)
                                            + j * (fieldIndexsValues.Length - 1), valueRowIdx].ToString())
                                            + int.Parse(dr[computedIdx * fieldIndexsValues.Length + j].ToString())).ToString();
                                        break;
                                    }
                            }
                        }
                        //tempTotalValues[2*2,4]          
                        //─	─	2	─	×	─	2	─	─	┐
                        //┌	─	┬	─	┬	─	┬	─	┐	│
                        //│	1	│	0	│	0	│	0	│	│
                        //│	1	│	0	│	0	│	0	│	4
                        //│	1	│	0	│	0	│	0	│	│
                        //│	1	│	0	│	0	│	0	│	│
                        //└	─	┴	─	┴	─	┴	─	┘	│
                    }
                    //tempTotalValues[2*2,4]          
                    //─	─	2	─	×	─	2	─	─	┐
                    //┌	─	┬	─	┬	─	┬	─	┐	│
                    //│	1	│	0	│	1	│	0	│	│
                    //│	1	│	0	│	1	│	0	│	4
                    //│	1	│	0	│	1	│	0	│	│
                    //│	1	│	0	│	1	│	0	│	│
                    //└	─	┴	─	┴	─	┴	─	┘	│
                    //遍历所有值，复制原值
                    for (int j = 0; j < fieldIndexsValues.Length; j++)
                    {
                        ///因为结果是空的数据列，且行数相等所以需要复制，交叉值结果集的当前列的每一个值
                        //dtCrossValuesTotalCross.Rows[valueRowIdx][dtCrossValuesTotalCross.Columns.Count - 1 - (fieldIndexsValues.Length - 1 - j)] = (int.Parse(dr[computedIdx * fieldIndexsValues.Length + j].ToString())).ToString();
                        switch (dr.Table.Columns[computedIdx * fieldIndexsValues.Length + j].DataType.ToString())
                        {
                            case "System.Decimal":
                                {
                                    dtCrossValuesTotalCross.Rows[valueRowIdx]
                                        [dtCrossValuesTotalCross.Columns.Count - 1 - (fieldIndexsValues.Length - 1 - j)]
                                        = (Decimal.Parse(dr[computedIdx * fieldIndexsValues.Length + j].ToString()));
                                    break;
                                }
                            case "System.DateTime":
                                {
                                    dtCrossValuesTotalCross.Rows[valueRowIdx]
                                        [dtCrossValuesTotalCross.Columns.Count - 1 - (fieldIndexsValues.Length - 1 - j)]
                                        = dr[computedIdx * fieldIndexsValues.Length + j];
                                    break;
                                }
                            case "System.String":
                                {
                                    dtCrossValuesTotalCross.Rows[valueRowIdx]
                                        [dtCrossValuesTotalCross.Columns.Count - 1 - (fieldIndexsValues.Length - 1 - j)]
                                        = dr[computedIdx * fieldIndexsValues.Length + j];
                                    break;
                                }
                            default:
                                {
                                    dtCrossValuesTotalCross.Rows[valueRowIdx]
                                        [dtCrossValuesTotalCross.Columns.Count - 1 - (fieldIndexsValues.Length - 1 - j)]
                                        = (int.Parse(dr[computedIdx * fieldIndexsValues.Length + j].ToString()));
                                    break;
                                }
                        }
                    }
                }
                #endregion
                #region 遍历所有交叉列集
                    for (int i = dtCrossValuesColumns.Columns.Count - 2; i >= 0; i--)
                    {
                        //tempTitle = tempTitle + "|" + dtCrossValuesColumns.Rows[computedIdx][i] + "|";
                        //循环所有列，如果已到达最后列或值不同（判断顺序不能颠倒），插入一个合计列              
                        if ((computedIdx < dtCrossValuesColumns.Rows.Count - 1)
                            && (tempRowsValue[i].ToString()
                            == dtCrossValuesColumns.Rows[computedIdx + 1][i].ToString()))
                        {
                            //继续检查下一列
                            continue;
                        }
                        //如果列值不同
                        else
                        {

                            #region {9F609C45-B357-4807-A1E1-3741F08D471A}
                            bool isTotal = false;
                            if (columnsTotalLevel.Length < dtCrossValuesColumns.Columns.Count - 2 - i ||
                            (columnsTotalLevel.Length >= dtCrossValuesColumns.Columns.Count - 2 - i
                            && columnsTotalLevel[dtCrossValuesColumns.Columns.Count - 2 - i] != "0"))
                            {
                                //遍历所有值
                                for (int j = 0; j < fieldIndexsValues.Length; j++)
                                {
                                    ///加一个合计列（列名为空）
                                    dtCrossValuesTotalCross.Columns.Add(
                                        new DataColumn(
                                            "", dt.Columns[int.Parse(fieldIndexsValues[j].ToString())].DataType));
                                }
                                isTotal = true;
                            } 
                            #endregion
                            int valueRowIdxSum = 0;
                            foreach (DataRow dr in dtCrossValues.Rows)
                            {
                                valueRowIdxSum = dtCrossValues.Rows.IndexOf(dr);
                                //遍历所有值
                                for (int j = 0; j < fieldIndexsValues.Length; j++)
                                {
                                    #region {9F609C45-B357-4807-A1E1-3741F08D471A}
                                    if (isTotal == true)
                                    {
                                        ///根据当前列索引写入对应合计值
                                        dtCrossValuesTotalCross.Rows[valueRowIdxSum]
                                            [dtCrossValuesTotalCross.Columns.Count - 1 - (fieldIndexsValues.Length - 1 - j)]
                                            = tempTotalValues[i * (fieldIndexsValues.Length) + j * (fieldIndexsValues.Length - 1), valueRowIdxSum];
                                    } 
                                    #endregion
                                    //写入一个清空一个
                                    tempTotalValues[i * (fieldIndexsValues.Length) + j * (fieldIndexsValues.Length - 1), valueRowIdxSum] = "0";
                                }
                            }

                        }
                    }
                
                #endregion
                //当前列下移一位
                computedIdx++;
            }
            #region 最后加一组总计
            #region {9F609C45-B357-4807-A1E1-3741F08D471A}
            if (columnsTotalLevel.Length < dataCrossColumns.Length ||
                 (this.columnsTotalLevel.Length >= this.dataCrossColumns.Length
                 && this.columnsTotalLevel[this.dataCrossColumns.Length - 1] != "0")) 
            #endregion
            {

                //遍历所有值
                for (int j = 0; j < fieldIndexsValues.Length; j++)
                {
                    ///加一个合计列（列名为空）
                    dtCrossValuesTotalCross.Columns.Add(
                        new DataColumn("", dt.Columns[int.Parse(fieldIndexsValues[j].ToString())].DataType));
                }
                int valueRowIdxGrandTotal = 0;
                foreach (DataRow dr in dtCrossValues.Rows)
                {
                    valueRowIdxGrandTotal = dtCrossValues.Rows.IndexOf(dr);
                    //遍历所有值
                    for (int j = 0; j < fieldIndexsValues.Length; j++)
                    {
                        ///根据当前列索引写入对应合计值
                        dtCrossValuesTotalCross.Rows[valueRowIdxGrandTotal]
                            [dtCrossValuesTotalCross.Columns.Count - 1 - (fieldIndexsValues.Length - 1 - j)]
                            = tempTotalValues[(fieldIndexsValues.Length) * (dtCrossValuesColumns.Columns.Count - 1)
                            + j * (fieldIndexsValues.Length - 1), valueRowIdxGrandTotal];
                        //写入一个清空一个
                        tempTotalValues[(fieldIndexsValues.Length) * (dtCrossValuesColumns.Columns.Count - 1)
                            + j * (fieldIndexsValues.Length - 1), valueRowIdxGrandTotal] = "0";
                    }
                } 
            }
            
            #endregion
            #endregion
            return dtCrossValuesTotalCross;
            #endregion
        }
        /// <summary>
        /// 合计交叉数据表行
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fieldIndexs"></param>
        /// <returns></returns>
        protected virtual DataTable TotalCrossDataTableRows(DataTable dtCrossValues, DataTable dtCrossRows, string[] fieldIndexs)
        {
            DataSetHelper dsh = new DataSetHelper();

            #region 交叉数据，用最直观的算法实现

            DataTable dtCrossValuesRows = dsh.SelectDistinctByIndexs("", dtCrossRows, fieldIndexs);
            object[] tempRowsValue;
            int computedIdx;

            #region 交叉行集
            tempRowsValue = new object[fieldIndexs.Length];
            computedIdx = 0;

            ///暂存合计值，第一维的长度是，行字段索引的长度
            ///第二维的长度是，值表的列数
            object[,] tempTotalValues;
            tempTotalValues = new object[fieldIndexs.Length, dtCrossValues.Columns.Count];
            #region 合计值初始化为0
            ///合计后的值表
            DataTable dtCrossValuesTotalCross = dtCrossValues.Clone();
            for (int i = 0; i < dtCrossValuesRows.Columns.Count; i++)
            {
                int valueColumnIdxDefault = 0;
                foreach (DataColumn dc in dtCrossValues.Columns)
                {
                    valueColumnIdxDefault = dtCrossValues.Columns.IndexOf(dc);
                    tempTotalValues[i, valueColumnIdxDefault] = "0";
                }
            }
            #endregion
            //循环所有行
            while (computedIdx < dtCrossValuesRows.Rows.Count)
            {
                //取当前行值
                tempRowsValue = dtCrossValuesRows.Rows[computedIdx].ItemArray;
                #region 暂存
                dtCrossValuesTotalCross.Rows.Add(dtCrossValues.Rows[computedIdx].ItemArray);

                for (int i = 0; i < dtCrossValuesRows.Columns.Count; i++)
                {
                    ///遍历所有列，
                    int valueColumnIdx;
                    valueColumnIdx = 0;
                    foreach (DataColumn dc in dtCrossValues.Columns)
                    {
                        valueColumnIdx = dtCrossValues.Columns.IndexOf(dc);
                        //tempTotalValues[i, valueColumnIdx] = (int.Parse(tempTotalValues[i, valueColumnIdx].ToString()) + int.Parse(dtCrossValues.Rows[computedIdx][valueColumnIdx].ToString())).ToString();
                        switch (dtCrossValues.Columns[valueColumnIdx].DataType.ToString())
                        {
                            case "System.Decimal":
                                {
                                    tempTotalValues[i, valueColumnIdx] = (Decimal.Parse(tempTotalValues[i, valueColumnIdx].ToString()) + Decimal.Parse(dtCrossValues.Rows[computedIdx][valueColumnIdx].ToString())).ToString();
                                    break;
                                }
                            case "System.DateTime":
                                {
                                    tempTotalValues[i, valueColumnIdx] = dtCrossValues.Rows[computedIdx][valueColumnIdx].ToString();
                                    break;
                                }
                            case "System.String":
                                {
                                    tempTotalValues[i, valueColumnIdx] = dtCrossValues.Rows[computedIdx][valueColumnIdx].ToString();
                                    break;
                                }
                            default:
                                {
                                    tempTotalValues[i, valueColumnIdx] = (int.Parse(tempTotalValues[i, valueColumnIdx].ToString()) + int.Parse(dtCrossValues.Rows[computedIdx][valueColumnIdx].ToString())).ToString();
                                    break;
                                }
                        }
                    }
                }

                #endregion
                //循环所有列，如果值不同插入一个计算列
                for (int i = dtCrossValuesRows.Columns.Count - 2; i >= 0; i--)
                {
                    //如果不是最后一行且列值相同
                    if ((computedIdx < dtCrossValuesRows.Rows.Count - 1) && (tempRowsValue[i].ToString() == dtCrossValuesRows.Rows[computedIdx + 1][i].ToString()))
                    {
                        //继续检查下一列
                        continue;
                    }
                    //如果列值不同
                    else
                    {
                        #region {9F609C45-B357-4807-A1E1-3741F08D471A}
                        bool isTotal = false;
                        if (rowsTotalLevel.Length < dtCrossValuesRows.Columns.Count - 2 - i ||
                            (rowsTotalLevel.Length >= dtCrossValuesRows.Columns.Count - 2 - i
                            && rowsTotalLevel[dtCrossValuesRows.Columns.Count - 2 - i] != "0"))
                        {
                            ///加一个合计列
                            dtCrossValuesTotalCross.Rows.Add(dtCrossValuesTotalCross.NewRow());
                            isTotal = true;
                        } 
                        #endregion
                        int valueColumnIdxSum = 0;
                        foreach (DataColumn dc in dtCrossValues.Columns)
                        {
                            valueColumnIdxSum = dtCrossValues.Columns.IndexOf(dc);
                            #region {9F609C45-B357-4807-A1E1-3741F08D471A}
                            ///根据当前列索引写入对应合计值
                            if (isTotal == true)
                            {
                                dtCrossValuesTotalCross.Rows[dtCrossValuesTotalCross.Rows.Count - 1][valueColumnIdxSum] = tempTotalValues[i, valueColumnIdxSum];
                            }  
                            #endregion
                            tempTotalValues[i, valueColumnIdxSum] = "0";
                        }
                    }
                }
                //当前列下移一位
                computedIdx++;
            }
            #region 加总计
            #region {9F609C45-B357-4807-A1E1-3741F08D471A}
            if (rowsTotalLevel.Length < dataCrossRows.Length ||
                (this.rowsTotalLevel.Length >= this.dataCrossRows.Length
                && this.rowsTotalLevel[this.dataCrossRows.Length - 1] != "0"))
            {
                ///加一个合计列
                dtCrossValuesTotalCross.Rows.Add(dtCrossValuesTotalCross.NewRow());
                int valueColumnIdxGrandTotal = 0;
                foreach (DataColumn dc in dtCrossValues.Columns)
                {
                    valueColumnIdxGrandTotal = dtCrossValues.Columns.IndexOf(dc);
                    ///根据当前列索引写入对应合计值
                    dtCrossValuesTotalCross.Rows[dtCrossValuesTotalCross.Rows.Count - 1][valueColumnIdxGrandTotal] = tempTotalValues[dtCrossValuesRows.Columns.Count - 1, valueColumnIdxGrandTotal];
                    tempTotalValues[dtCrossValuesRows.Columns.Count - 1, valueColumnIdxGrandTotal] = "0";
                }
            } 
            #endregion
            #endregion
            #endregion

            return dtCrossValuesTotalCross;
            #endregion
        }
        /// <summary>
        /// 交叉数据表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fieldIndexs"></param>
        /// <returns></returns>
        protected virtual DataTable CrossDataTable(DataTable dt, string[] fieldIndexs, string[] fieldIndexsTotleLevel)
        {
            DataSetHelper dsh = new DataSetHelper();

            #region 交叉数据，用最直观的算法实现

            DataTable dtRows = dsh.SelectDistinctByIndexs("", dt, fieldIndexs);
            // DataTable dtColumns = dsh.SelectDistinctByIndexs("", dt, dataCrossColumns);
            object[] tempRowsValue;
            int computedIdx;
            int insertRowIdx;
            #region 交叉行集
            tempRowsValue = new object[fieldIndexs.Length];
            computedIdx = 0;
            insertRowIdx = 0;
            //循环所有行
            while (computedIdx < dtRows.Rows.Count - 1)
            {
                //取当前行值
                tempRowsValue = dtRows.Rows[computedIdx].ItemArray;
                string tempTitle = string.Empty;
                //循环所有列，如果值不同插入一个计算列
                for (int i = dtRows.Columns.Count - 2; i >= 0; i--)
                {
                    //tempTitle = tempTitle + "|" + tempRowsValue[i].ToString();
                    //if (computedIdx < dtRows.Rows.Count-1)
                    //{
                    //如果列值相同
                    if (tempRowsValue[i].ToString() == dtRows.Rows[insertRowIdx + 1][i].ToString())
                    {
                        //继续检查下一列
                        continue;
                    }
                    //如果列值不同
                    else
                    {
                        #region {9F609C45-B357-4807-A1E1-3741F08D471A}
                        if (fieldIndexsTotleLevel.Length < dtRows.Columns.Count - 2 - i ||
                                         (fieldIndexsTotleLevel.Length >= dtRows.Columns.Count - 2 - i
                                         && fieldIndexsTotleLevel[dtRows.Columns.Count - 2 - i] != "0"))
                        {
                            //新建一个行
                            DataRow drNew = dtRows.NewRow();
                            for (int j = i; j >= 0; j--)
                            {
                                drNew[j] = tempRowsValue[j].ToString();
                            }
                            //将新建行的列值不同的列赋值为当前行的对应列值
                            drNew[i + 1] = tempTitle + "小计";
                            //计算行加入位置下移一行
                            insertRowIdx++;
                            ////判断当前插入行的位置是否是小于最大行索引
                            //if (insertRowIdx <= dtRows.Rows.Count - 1)
                            //{
                            //    //插入新行在插入列
                            dtRows.Rows.InsertAt(drNew, insertRowIdx);
                            //}
                            //else
                            //{
                            //    //追加新行在最后
                            //    dtRows.Rows.Add(drNew);
                            //} 
                        } 
                        #endregion
                    }
                    //}
                    //else
                    //{

                    //}
                }
                //当前列下移一位
                computedIdx = insertRowIdx + 1;
                insertRowIdx = computedIdx;
            }
            //计算最后一行数据
            if (dtRows.Rows.Count > 0)
            {
                //取当前行值
                tempRowsValue = dtRows.Rows[dtRows.Rows.Count - 1].ItemArray;
                string tempTitle = string.Empty;
                //循环所有列，如果值不同插入一个计算列
                for (int i = dtRows.Columns.Count - 2; i >= 0; i--)
                {

                    #region {9F609C45-B357-4807-A1E1-3741F08D471A}
                    if (fieldIndexsTotleLevel.Length < dtRows.Columns.Count - 2 - i ||
                                      (fieldIndexsTotleLevel.Length >= dtRows.Columns.Count - 2 - i
                                      && fieldIndexsTotleLevel[dtRows.Columns.Count - 2 - i] != "0"))
                    {
                        //tempTitle = tempTitle + "|" + tempRowsValue[i].ToString();
                        //新建一个行
                        DataRow drNew = dtRows.NewRow();
                        for (int j = i; j >= 0; j--)
                        {
                            drNew[j] = tempRowsValue[j].ToString();
                        }
                        //将新建行的列值不同的列赋值为当前行的对应列值
                        drNew[i + 1] = "小计";

                        //追加新行在最后
                        dtRows.Rows.Add(drNew);
                    }

                    #endregion
                }
                #region {9F609C45-B357-4807-A1E1-3741F08D471A}
                if (fieldIndexsTotleLevel.Length < fieldIndexs.Length ||
                          (fieldIndexsTotleLevel.Length >= fieldIndexs.Length
                          && fieldIndexsTotleLevel[fieldIndexs.Length - 1] != "0"))
                {
                    //新建一个行
                    DataRow drNewGrandTotal = dtRows.NewRow();
                    drNewGrandTotal[0] = "总计";
                    dtRows.Rows.Add(drNewGrandTotal);
                } 
                #endregion
            }
            #endregion

            return dtRows;
            #endregion
        }
        protected virtual int CrossDataTable(DataTable dt, string[] fieldIndexs, ref DataTable dtRows, ref int[] totalAndGrand)
        {
            DataSetHelper dsh = new DataSetHelper();

            #region 交叉数据，用最直观的算法实现
            string totalAndGrandString = string.Empty;
            //DataTable dtRows = dsh.SelectDistinctByIndexs("", dt, fieldIndexs);
            dtRows = dsh.SelectDistinctByIndexs("", dt, fieldIndexs);
            // DataTable dtColumns = dsh.SelectDistinctByIndexs("", dt, dataCrossColumns);
            object[] tempRowsValue;
            int computedIdx;
            int insertRowIdx;
            #region 交叉行集
            tempRowsValue = new object[fieldIndexs.Length];
            computedIdx = 0;
            insertRowIdx = 0;
            //循环所有行
            while (computedIdx < dtRows.Rows.Count - 1)
            {
                //取当前行值
                tempRowsValue = dtRows.Rows[computedIdx].ItemArray;
                string tempTitle = string.Empty;
                //循环所有列，如果值不同插入一个计算列
                for (int i = dtRows.Columns.Count - 2; i >= 0; i--)
                {
                    //tempTitle = tempTitle + "|" + tempRowsValue[i].ToString();
                    //if (computedIdx < dtRows.Rows.Count-1)
                    //{
                    //如果列值相同
                    if (tempRowsValue[i].ToString() == dtRows.Rows[insertRowIdx + 1][i].ToString())
                    {
                        //继续检查下一列
                        continue;
                    }
                    //如果列值不同
                    else
                    {
                        //新建一个行
                        DataRow drNew = dtRows.NewRow();
                        for (int j = i; j >= 0; j--)
                        {
                            drNew[j] = tempRowsValue[j].ToString();
                        }
                        //将新建行的列值不同的列赋值为当前行的对应列值
                        drNew[i + 1] = tempTitle + "小计";
                        //计算行加入位置下移一行
                        insertRowIdx++;
                        ////判断当前插入行的位置是否是小于最大行索引
                        //if (insertRowIdx <= dtRows.Rows.Count - 1)
                        //{
                        //    //插入新行在插入列
                        dtRows.Rows.InsertAt(drNew, insertRowIdx);
                        totalAndGrandString = totalAndGrandString + insertRowIdx.ToString() + ",";
                        //}
                        //else
                        //{
                        //    //追加新行在最后
                        //    dtRows.Rows.Add(drNew);
                        //}
                    }
                    //}
                    //else
                    //{

                    //}
                }
                //当前列下移一位
                computedIdx = insertRowIdx + 1;
                insertRowIdx = computedIdx;
            }
            //计算最后一行数据
            if (dtRows.Rows.Count > 0)
            {
                //取当前行值
                tempRowsValue = dtRows.Rows[dtRows.Rows.Count - 1].ItemArray;
                string tempTitle = string.Empty;
                //循环所有列，如果值不同插入一个计算列
                for (int i = dtRows.Columns.Count - 2; i >= 0; i--)
                {

                    //tempTitle = tempTitle + "|" + tempRowsValue[i].ToString();
                    //新建一个行
                    DataRow drNew = dtRows.NewRow();
                    for (int j = i; j >= 0; j--)
                    {
                        drNew[j] = tempRowsValue[j].ToString();
                    }
                    //将新建行的列值不同的列赋值为当前行的对应列值
                    drNew[i + 1] = "小计";

                    //追加新行在最后
                    dtRows.Rows.Add(drNew);
                    totalAndGrandString = totalAndGrandString + (dt.Rows.Count - 1).ToString() + ",";
                }
                //新建一个行
                DataRow drNewGrandTotal = dtRows.NewRow();
                totalAndGrandString = totalAndGrandString + (dt.Rows.Count - 1).ToString();
                drNewGrandTotal[0] = "总计";
                dtRows.Rows.Add(drNewGrandTotal);
            }
            #endregion
            string[] totalAndGrandStringArr = totalAndGrandString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            totalAndGrand = new int[totalAndGrandStringArr.Length];
            for (int i = 0; i < totalAndGrandStringArr.Length; i++)
            {
                totalAndGrand[i] = int.Parse(totalAndGrandStringArr[i]);
            }
            return 0;
            #endregion
        }
        protected virtual void OnSort()
        {

            ////点的是标题行
            //if (this.SvMain.ActiveRowIndex == this.dataBeginRowIndex)
            //{
            //    //点的是标题列
            //    if (this.SvMain.ActiveColumnIndex <= this.dataDisplayColumns.Length - 1)
            //    {
            //        //新建排序条件
            //        FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[1];
            //        //遍历标题列取原排序条件
            //        for (int i = 0; i < this.dataDisplayColumns.Length; i++)
            //        {
            //            bool ascending = true;
            //            if (i == this.SvMain.ActiveColumnIndex)
            //            {
            //                //没有“↑”号就是升序
            //                if (SvMain.Cells[this.dataBeginRowIndex, i].Text.IndexOf("△") < 0)
            //                {
            //                    //
            //                    SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("▽", "");
            //                    ascending = false;
            //                    SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "△";
            //                }
            //                else
            //                {
            //                    //
            //                    SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("△", "");
            //                    ascending = true;
            //                    SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "▽";
            //                }
            //                //生成排序信息
            //                sort[0] = new FarPoint.Win.Spread.SortInfo(i, ascending, System.Collections.Comparer.Default);
            //            }
            //            else
            //            {
            //                //没有“↑”号就是升序
            //                if (SvMain.Cells[this.dataBeginRowIndex, i].Text.IndexOf("△") < 0)
            //                {
            //                    SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("▽", "");
            //                    //ascending = false;
            //                    //SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "▽";
            //                }
            //                else
            //                {
            //                    SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("△", "");
            //                    //ascending = true;
            //                    //SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "△";
            //                }
            //            }
            //            //生成排序信息
            //            //sort[i] = new FarPoint.Win.Spread.SortInfo(i, ascending, System.Collections.Comparer.Default);
            //        }
            //        ////新建排序条件
            //        //FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[this.dataDisplayColumns.Length];
            //        ////遍历标题列取原排序条件
            //        //for (int i = 0; i < this.dataDisplayColumns.Length; i++)
            //        //{
            //        //    bool ascending = true;
            //        //    if (i == this.SvMain.ActiveColumnIndex )
            //        //    {
            //        //        //没有“↑”号就是升序
            //        //        if (SvMain.Cells[this.dataBeginRowIndex, i].Text.IndexOf("△") < 0)
            //        //        {
            //        //            //
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("▽", "");
            //        //            ascending = false;
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "△";
            //        //        }
            //        //        else
            //        //        {
            //        //            //
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("△", "");
            //        //            ascending = true;
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "▽";
            //        //        }
            //        //    }
            //        //    else
            //        //    {
            //        //        //没有“↑”号就是升序
            //        //        if (SvMain.Cells[this.dataBeginRowIndex, i].Text.IndexOf("△") <0)
            //        //        {
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("▽", "");
            //        //            ascending = false;
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "▽";
            //        //        }
            //        //        else
            //        //        {
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("△", "");
            //        //            ascending = true;
            //        //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "△";
            //        //        } 
            //        //    }
            //        //    //生成排序信息
            //        //    sort[i] = new FarPoint.Win.Spread.SortInfo(i, ascending,System.Collections.Comparer.Default );
            //        //}
            //        SvMain.SortRange(this.dataBeginRowIndex + 1, 0, this.dataRowCount, this.dataDisplayColumns.Length - 1, true, sort);


            //    }
            //}
        }

        private void ComputeIndex()
        {
            rowsHeaderBeginColumnIndex = dataBeginColumnIndex;
            if (this.dataCrossValues.Length > 1)
            {
                rowsHeaderBeginRowIndex = dataBeginRowIndex + dataCrossColumns.Length + 1;
            }
            else
            {
                rowsHeaderBeginRowIndex = dataBeginRowIndex + dataCrossColumns.Length;
            }
            columnsHeaderBeginColumnIndex = dataBeginColumnIndex + dataCrossRows.Length; ;
            columnsHeaderBeginRowIndex = dataBeginRowIndex;
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

        #endregion


    }
}
