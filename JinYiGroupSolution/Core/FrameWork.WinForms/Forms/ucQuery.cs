using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.NFC.Interface.Forms
{
    /// <summary>
    /// [功能描述: 查询控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucQuery : UserControl, IQueryControl
    {

        #region 构造函数

        private ucQuery()
        {
            InitializeComponent();
        }

        public ucQuery(string sql)
            : this()
        {
            this.sql = sql;

            //隐藏TreeView和过滤条件控件
            this.HideTreeView();
            this.HideFilter();
        }

        public ucQuery(string sql, int filterIndex)
            : this()
        {
            this.sql = sql;
            this.filterIndex = filterIndex;

            this.HideTreeView();
        }

        public ucQuery(string sql, int filterIndex, TreeView treeView)
            : this()
        {
            this.sql = sql;
            this.filterIndex = filterIndex;

            this.treeView = treeView;
            this.treeView.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
        }

        public ucQuery(string sql, int filterIndex, TreeView treeView, IQueryModifyControl queryModifyControl)
            : this(sql, filterIndex, treeView)
        {
            this.queryModifyControl = queryModifyControl;
        }

        #endregion

        #region 字段

        private TreeView treeView;
        private IQueryForm queryForm;
        private IQueryModifyControl queryModifyControl;
        private bool isDirty;
        private int filterIndex = -1;                        //过滤所在列Index
        private string sql;                                 //SQL语句
        private Form modifyControlForm;

        #endregion

        #region 属性
        private Form ModifyControlForm
        {
            get
            {
                if (this.modifyControlForm == null)
                {
                    this.modifyControlForm = new Form();
                }
                return this.modifyControlForm;
            }
        }
        #endregion
        #region 方法
        /// <summary>
        /// 隐藏过滤条件
        /// </summary>
        private void HideFilter()
        {
            this.panel1.Visible = false;
        }

        /// <summary>
        /// 隐藏TreeView
        /// </summary>
        private void HideTreeView()
        {
            this.splitContainer1.SplitterDistance = 0;

            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.IsSplitterFixed = true;
        }
        #endregion

        #region IQueryControl 成员

        public IQueryForm QueryForm
        {
            get
            {
                return this.queryForm;
            }
            set
            {
                this.queryForm = value;
            }
        }

        public int Init()
        {            
            return 0;
        }
        public int Query()
        {
            return 0;
        }

        public int Add()
        {
            return 0;
        }

        public int Delete()
        {
            return 0;
        }

        public int Save()
        {
            return 0;
        }

        public int Export()
        {
            return 0;
        }

        public int Print()
        {
            return 0;
        }

        public bool IsDirty
        {
            get
            {
                return this.isDirty;
            }
            set
            {
                this.isDirty = value;
            }
        }

        #endregion
        #region 事件

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.queryModifyControl != null)
            {
                if (this.modifyControlForm == null)
                {
                    this.modifyControlForm = new Form();

                    Control c = this.queryModifyControl as Control;
                    c.Dock = DockStyle.Fill;
                    this.modifyControlForm.Controls.Add(c);
                }

                this.modifyControlForm.ShowDialog();
            }
        }
        #endregion
    }

}

