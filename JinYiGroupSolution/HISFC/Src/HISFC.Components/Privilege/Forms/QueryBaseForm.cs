using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.UFC.Privilege.Forms
{
    /// <summary>
    /// [功能描述: 基本查询窗体]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-10-31]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class QueryBaseForm : BaseForm, IQueryHost
    {
        protected QueryBaseForm()
        {
            InitializeComponent();
        }

        public QueryBaseForm(IQueryOperation queryOperation)
        {
            InitializeComponent();

            this._queryOperation = queryOperation;
            this._queryOperation.QueryForm = this;

            Control control = this._queryOperation as Control;
            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(control);
            }
            else
            {
                if (!this.DesignMode)
                    throw new ApplicationException("所传入的_queryOperation不是控件类型!");
            }
        }

        #region 字段
        /// <summary>
        /// 查询控件
        /// </summary>
        private IQueryOperation _queryOperation;

        private bool maxWindow = true;
        #endregion

        #region 属性

        /// <summary>
        /// 用于继承窗体传入维护控件
        /// </summary>
        protected IQueryOperation QueryOperation
        {
            set
            {
                this._queryOperation = value;
                this._queryOperation.QueryForm = this;

                Control control = this._queryOperation as Control;
                if (control != null)
                {
                    control.Dock = DockStyle.Fill;
                    this.panel1.Controls.Add(control);
                }
                else
                {
                    if (!this.DesignMode)
                        throw new ApplicationException("所传入的QueryOperation不是控件类型!");
                }
            }
        }

        #endregion

        #region 方法
        private void ShowSeperator()
        {
            if (this.tbAdd.Visible == false && this.tbDelete.Visible == false && this.tbModify.Visible == false)
                this.toolStripSeparator1.Visible = false;
            else
                this.toolStripSeparator1.Visible = true;

            if (this.tbRefresh.Visible == false && this.tbSave.Visible == false)
                this.toolStripSeparator2.Visible = false;
            else
                this.toolStripSeparator2.Visible = true;

            if (this.tbImport.Visible == false && this.tbExport.Visible == false)
                this.toolStripSeparator3.Visible = false;
            else
                this.toolStripSeparator3.Visible = true;

            if (this.tbPrint.Visible == false && this.tbPrintPreview.Visible == false && this.tbPrintConfig.Visible == false)
                this.toolStripSeparator4.Visible = false;
            else
                this.toolStripSeparator4.Visible = true;

            if (this.tbCut.Visible == false && this.tbCopy.Visible == false && this.tbPaste.Visible == false)
                this.toolStripSeparator5.Visible = false;
            else
                this.toolStripSeparator5.Visible = true;

            if (this.tbPre.Visible == false && this.tbNext.Visible == false)
                this.toolStripSeparator6.Visible = false;
            else
                this.toolStripSeparator6.Visible = true;
        }

        /// <summary>
        /// 设置维护控件的Tag
        /// </summary>
        /// <param name="tag"></param>
        public void SetQueryOperationTag(object tag)
        {
            (this._queryOperation as Control).Tag = tag;
        }

        /// <summary>
        /// 显示查询按钮
        /// </summary>
        public bool ShowQueryButton
        {
            get
            {
                return this.tbRefresh.Visible;
            }
            set
            {
                this.tbRefresh.Visible = value;
            }
        }
        #endregion

        #region IQueryOperation 成员

        public bool ShowAddButton
        {
            get
            {
                return this.tbAdd.Visible;
            }
            set
            {
                this.tbAdd.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowSaveButton
        {
            get
            {
                return this.tbSave.Visible;
            }
            set
            {
                this.tbSave.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowPrintButton
        {
            get
            {
                return this.tbPrint.Visible;
            }
            set
            {
                this.tbPrint.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowExportButton
        {
            get
            {
                return this.tbExport.Visible;
            }
            set
            {
                this.tbExport.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowDeleteButton
        {
            get
            {
                return this.tbDelete.Visible;
            }
            set
            {
                this.tbDelete.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowModifyButton
        {
            get
            {
                return this.tbModify.Visible;
            }
            set
            {
                this.tbModify.Visible = value;
                this.ShowSeperator();
            }
        }


        public bool ShowPrintPreviewButton
        {
            get
            {
                return this.tbPrintPreview.Visible;
            }
            set
            {
                this.tbPrintPreview.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowPrintConfigButton
        {
            get
            {
                return this.tbPrintConfig.Visible;
            }
            set
            {
                this.tbPrintConfig.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowImportButton
        {
            get
            {
                return this.tbImport.Visible;
            }
            set
            {
                this.tbImport.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowCutButton
        {
            get
            {
                return this.tbCut.Visible;
            }
            set
            {
                this.tbCut.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowCopyButton
        {
            get
            {
                return this.tbCopy.Visible;
            }
            set
            {
                this.tbCopy.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowPasteButton
        {
            get
            {
                return this.tbPaste.Visible;
            }
            set
            {
                this.tbPaste.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowPreRowButton
        {
            get
            {
                return this.tbPre.Visible;
            }
            set
            {
                this.tbPre.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool ShowNextRowButton
        {
            get
            {
                return this.tbNext.Visible;
            }
            set
            {
                this.tbNext.Visible = value;
                this.ShowSeperator();
            }
        }

        public bool IsFormMaximized
        {
            get
            {
                return this.maxWindow;
            }
            set
            {
                this.maxWindow = value;
            }
        }


        public bool ShowStatusBar
        {
            get
            {
                return this.MainStatusStrip.Visible;
            }
            set
            {
                this.MainStatusStrip.Visible = value;
            }
        }

        #endregion

        #region "事件"
        protected override void OnLoad(EventArgs e)
        {

            if (this.maxWindow)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            if (this._queryOperation != null)
            {
                this._queryOperation.Init();
                this._queryOperation.Query();
            }
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this._queryOperation.IsDirty)
            {
                DialogResult dr = MessageBox.Show("是否保存更改？", "提示", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    this._queryOperation.Save();
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            base.OnClosing(e);
        }

        private void tbRefresh_Click(object sender, EventArgs e)
        {
            if (this._queryOperation.IsDirty)
            {
                DialogResult dr = MessageBox.Show("是否保存更改？", "提示", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    this._queryOperation.Save();
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }
            this._queryOperation.Query();
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            this._queryOperation.Add();
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            this._queryOperation.Save();            
        }

        private void tbExport_Click(object sender, EventArgs e)
        {
            this._queryOperation.Export();
        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            this._queryOperation.Print();
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            this._queryOperation.Delete();
        }

        private void tbModify_Click(object sender, EventArgs e)
        {
            this._queryOperation.Modify();
        }

        private void tbImport_Click(object sender, EventArgs e)
        {
            this._queryOperation.Import();
        }

        private void tbPrintPreview_Click(object sender, EventArgs e)
        {
            this._queryOperation.PrintPreview();
        }

        private void tbPrintConfig_Click(object sender, EventArgs e)
        {
            this._queryOperation.PrintConfig();
        }

        private void tbCut_Click(object sender, EventArgs e)
        {
            this._queryOperation.Cut();
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            this._queryOperation.Copy();
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            this._queryOperation.Paste();
        }

        private void tbPre_Click(object sender, EventArgs e)
        {
            this._queryOperation.PreRow();
        }

        private void tbNext_Click(object sender, EventArgs e)
        {
            this._queryOperation.NextRow();
        }
        #endregion
    }
}