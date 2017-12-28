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
    public partial class ucQueryBaseForFarPoint : Neusoft.FrameWork.WinForms .Controls.ucBaseControl
    {
        public ucQueryBaseForFarPoint()
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
        /// 分页符所在的行数
        /// </summary>
        private int rowPageBreak = -1;

        /// <summary>
        /// 主表格配置文件的位置
        /// </summary>
        private string mainSheetXmlFileName = string.Empty;
       
        /// <summary>
        /// 详细表格配置文件名
        /// </summary>
        private string detailSheetXmlFileName = string.Empty;
        
        /// <summary>
        /// 数据开始行的索引
        /// </summary>
        private int dataBeginRowIndex = 0;
        /// <summary>
        /// 显示开始列的索引
        /// </summary>
        private int dataBeginColumnIndex = 0;
        /// <summary>
        /// 数据显示列索引
        /// </summary>
        private string[] dataDisplayColumns =new  string[0] ;

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
        public string  HospitalName
        {
            get
            {
                if (DesignMode==false )
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
        /// <summary>
        /// 设置数据集中用于显示的列，
        /// </summary>
        [Category("报表参数"), Description("设置报表需要显示的数据列！")]
        public string DataDisplayColumns
        {
            get
            {
                string rtn = string.Empty;
                if (dataDisplayColumns != null)
                {
                    rtn = string.Join("|", this.dataDisplayColumns);
                }
                return rtn;
            }
            set
            {
                dataDisplayColumns = value.Split('|');

            }
        }
        [Category("报表参数"), Description("设置报表查询出的数据集，显示的起始行的索引！")]
        public int DataBeginRowIndex
        {
            get { return dataBeginRowIndex; }
            set { dataBeginRowIndex = value; }
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
               
            }
        }
        [Category("报表参数"), Description("设置报表主表格配置文件名！")]
        public string MainSheetXml
        {
            get { return mainSheetXmlFileName; }
            set { mainSheetXmlFileName = value; }
        }
        [Category("报表参数"), Description("设置报表详细表格配置文件名！")]
        public string DetailSheetXml
        {
            get { return detailSheetXmlFileName; }
            set { detailSheetXmlFileName = value; }
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
                this.isShowDetail = value;

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
            if (SvMain .RowCount > this.DataBeginRowIndex + 1)
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
        protected void  OpenSpread()
        {
            //SvMain = new FarPoint.Win.Spread.SheetView();
            //this.neuSpread1.Sheets.Add(SvMain);
              #region 读xml设置fp
            if (string.IsNullOrEmpty(this.MainSheetXml) == false)
            {
                this.neuSpread1.Open(Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + "Report\\" + this.MainSheetXml);
            }
            if (string.IsNullOrEmpty(this.DetailSheetXml) == false)
            {
                this.neuSpread2.Open(Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + "Report\\" + this.DetailSheetXml);
            }
              #endregion
            #region 用open方法设置fp格式后必须重新指定sht的临时变量
            if (this.neuSpread1.Sheets.Count>0)
            {
                string f = string.Empty;
                
                SvMain = neuSpread1.Sheets[0];
                SvMain.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            }
            if (neuSpread2.Sheets.Count >0)
            {
                SvDetail = neuSpread2.Sheets[0];   
                SvDetail.OperationMode= FarPoint.Win.Spread.OperationMode.ReadOnly;
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
            //int rtnVal = -1;
            Cursor = Cursors.WaitCursor;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据,请等待....");

            Application.DoEvents();
                    
            #region 清空数据表格
            if (SvMain.RowCount >= this.dataBeginRowIndex + 1)
            {
                SvMain.ClearRange(this.dataBeginRowIndex ,dataBeginColumnIndex,SvMain.Rows.Count-this.dataBeginRowIndex+1, this.dataDisplayColumns.Length ,false); 
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
                    if (Db.QueryDataBySqlId(this.QuerySql, ref dt,this.QueryParams) != 1)
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
            #region 清空排序状态
            if (this.dataBeginColumnIndex>0 ||this.dataBeginRowIndex>0)
            {
                //遍历标题列取原排序条件
                for (int i = dataBeginColumnIndex; i < this.dataDisplayColumns.Length; i++)
                {
                    //没有“↑”号就是升序
                    if (SvMain.Cells[this.dataBeginRowIndex - 1, i].Text.IndexOf("△") >= 0)
                    {
                        //
                        SvMain.Cells[this.dataBeginRowIndex - 1, i].Text = SvMain.Cells[this.dataBeginRowIndex - 1, i].Text.Replace("△", "");
                    }
                    //没有“↑”号就是升序
                    if (SvMain.Cells[this.dataBeginRowIndex - 1, i].Text.IndexOf("▽") >= 0)
                    {
                        //
                        SvMain.Cells[this.dataBeginRowIndex - 1, i].Text = SvMain.Cells[this.dataBeginRowIndex - 1, i].Text.Replace("▽", "");
                    }
                } 
            }
            #endregion
              DataSetHelper dsh = new DataSetHelper();
            DataTable dtValues = dsh.SelectIntoByIndex(string.Empty, dt, dataDisplayColumns, string.Empty, string.Empty);
            this.dataRowCount = dtValues.Rows.Count;
            #region 设置表格列数
            //this.SvMain.ColumnCount = dataDisplayColumns.Length ;
            if (this.SvMain.Rows.Count<DataBeginRowIndex  + dt.Rows.Count)
            {
                this.SvMain.RowCount = DataBeginRowIndex  + dt.Rows.Count; 
            }
          
            #endregion
            #region 逐个单元格填充数据
            Function.DisplayToFp(SvMain, dtValues, DataBeginRowIndex, DataBeginColumnIndex);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    foreach (DataColumn dc in dt.Columns)
            //    {                                       
            //        if (Array.IndexOf(dataDisplayColumns,dt.Columns.IndexOf(dc).ToString())>=0)
            //        {
            //            SvMain.Cells[dt.Rows.IndexOf(dr) + 1 + DataBeginRowIndex, Array.IndexOf(dataDisplayColumns, dt.Columns.IndexOf(dc).ToString())].Text = dr[dt.Columns.IndexOf(dc)].ToString(); 
            //        }
        
            //    }
            //}
            #endregion

            #endregion

            #region 设置分页符
            if (this.rowPageBreak > 0)
            {

                for (int i = 0; i < this.SvMain.Rows.Count; i = ((i+1) * this.rowPageBreak + this.DataBeginRowIndex))
                {
                    this.SvMain.SetRowPageBreak((i * this.rowPageBreak + this.DataBeginRowIndex), true);
                }
            }
            #endregion

            Function.DrawGridLine(SvMain,this.dataBeginRowIndex,this.dataBeginColumnIndex,dtValues.Rows.Count,dtValues.Columns.Count);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            Cursor = Cursors.Arrow;

            return 1;
        }
        protected virtual void OnSort()
        {
            //点的是标题行
            if (this.SvMain.ActiveRowIndex==this.dataBeginRowIndex-1)
            {
                //点的是标题列
                if (this.SvMain.ActiveColumnIndex <=this.dataBeginColumnIndex+ this.dataDisplayColumns.Length - 1 && this.SvMain.ActiveColumnIndex >= this.dataBeginColumnIndex)
                {
                    //新建排序条件
                    FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[1];
                    //遍历标题列取原排序条件
                    for (int i = dataBeginColumnIndex; i < this.dataDisplayColumns.Length; i++)
                    {
                        bool ascending = true;
                        if (i == this.SvMain.ActiveColumnIndex)
                        {
                            //没有“↑”号就是升序
                            if (SvMain.Cells[this.dataBeginRowIndex-1, i].Text.IndexOf("▽") < 0)
                            {
                                //
                                SvMain.Cells[this.dataBeginRowIndex-1, i].Text = SvMain.Cells[this.dataBeginRowIndex-1, i].Text.Replace("△", "");
                                ascending = false;
                                SvMain.Cells[this.dataBeginRowIndex-1, i].Text = SvMain.Cells[this.dataBeginRowIndex-1, i].Text + "▽";
                            }
                            else
                            {
                                //
                                SvMain.Cells[this.dataBeginRowIndex-1, i].Text = SvMain.Cells[this.dataBeginRowIndex-1, i].Text.Replace("▽", "");
                                ascending = true;
                                SvMain.Cells[this.dataBeginRowIndex-1, i].Text = SvMain.Cells[this.dataBeginRowIndex-1, i].Text + "△";
                            }
                            //生成排序信息
                            sort[0] = new FarPoint.Win.Spread.SortInfo(i, ascending, System.Collections.Comparer.Default);
                        }
                        else
                        {
                            //没有“↑”号就是升序
                            if (SvMain.Cells[this.dataBeginRowIndex - 1, i].Text.IndexOf("▽") < 0)
                            {
                                SvMain.Cells[this.dataBeginRowIndex - 1, i].Text = SvMain.Cells[this.dataBeginRowIndex - 1, i].Text.Replace("△", "");
                                //ascending = false;
                                //SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "△";
                            }
                            else
                            {
                                SvMain.Cells[this.dataBeginRowIndex - 1, i].Text = SvMain.Cells[this.dataBeginRowIndex - 1, i].Text.Replace("▽", "");
                                //ascending = true;
                                //SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "▽";
                            }
                        }
                        //生成排序信息
                        //sort[i] = new FarPoint.Win.Spread.SortInfo(i, ascending, System.Collections.Comparer.Default);
                    }
                    ////新建排序条件
                    //FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[this.dataDisplayColumns.Length];
                    ////遍历标题列取原排序条件
                    //for (int i = 0; i < this.dataDisplayColumns.Length; i++)
                    //{
                    //    bool ascending = true;
                    //    if (i == this.SvMain.ActiveColumnIndex )
                    //    {
                    //        //没有“↑”号就是升序
                    //        if (SvMain.Cells[this.dataBeginRowIndex, i].Text.IndexOf("▽") < 0)
                    //        {
                    //            //
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("△", "");
                    //            ascending = false;
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "▽";
                    //        }
                    //        else
                    //        {
                    //            //
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("▽", "");
                    //            ascending = true;
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "△";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        //没有“↑”号就是升序
                    //        if (SvMain.Cells[this.dataBeginRowIndex, i].Text.IndexOf("▽") <0)
                    //        {
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("△", "");
                    //            ascending = false;
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "△";
                    //        }
                    //        else
                    //        {
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text.Replace("▽", "");
                    //            ascending = true;
                    //            SvMain.Cells[this.dataBeginRowIndex, i].Text = SvMain.Cells[this.dataBeginRowIndex, i].Text + "▽";
                    //        } 
                    //    }
                    //    //生成排序信息
                    //    sort[i] = new FarPoint.Win.Spread.SortInfo(i, ascending,System.Collections.Comparer.Default );
                    //}
                    SvMain.SortRange(this.dataBeginRowIndex, this.dataBeginColumnIndex, this.dataRowCount, this.dataDisplayColumns.Length , true, sort);
                    
                    
                }
            }
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
