using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.UFC.Common.Controls;

namespace UFC.Pharmacy
{
    /// <summary>
    /// [功能描述: 入出库管理基类窗口 实现自定义窗口功能]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// <说明>
    ///     1 每次设置按钮显示前 会重置按钮 
    /// </说明>
    /// </summary>
    public partial class frmIMABaseForm : Neusoft.NFC.Interface.Forms.BaseStatusBar
    {
        public frmIMABaseForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.ProgressRun(true);
        }

        private Neusoft.UFC.Common.Controls.ucIMAInOutBase ucBaseCompoent = null;

        /// <summary>
        /// 增加按钮
        /// </summary>
        private System.Collections.Hashtable hsAddButton = null;

        /// <summary>
        /// 添加功能组件
        /// </summary>
        /// <param name="ucBaseCompoent"></param>
        /// <returns></returns>
        protected int AddIMABaseCompoent(Neusoft.UFC.Common.Controls.ucIMAInOutBase ucBaseCompoent)
        {
            try
            {
                this.ucBaseCompoent = ucBaseCompoent;

                this.ctrlPanel.Controls.Clear();                

                ucBaseCompoent.Dock = DockStyle.Fill;

                ucBaseCompoent.BackColor = System.Drawing.Color.MintCream;

                ucBaseCompoent.SetToolButtonVisibleEvent += new ucIMAInOutBase.SetToolButtonVisibleHandler(ucBaseCompoent_SetToolButtonVisibleEvent);

                ucBaseCompoent.AddToolButtonEvent += new ucIMAInOutBase.AddToolButtonHandler(ucBaseCompoent_AddToolButtonEvent);

                this.ctrlPanel.Controls.Add(ucBaseCompoent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Neusoft.NFC.Management.Language.Msg(ex.Message));
                return -1;
            }
            return 1;
        }
       
        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="buttonText"></param>
        /// <param name="trsipDescription"></param>
        /// <param name="image"></param>
        /// <param name="locationIndex"></param>
        /// <param name="isAddSeparator"></param>
        /// <param name="e"></param>
        protected virtual void AddToolButton(string buttonText, string trsipDescription, System.Drawing.Image image, int locationIndex, bool isAddSeparator, System.EventHandler e)
        {
            if (isAddSeparator)                 //增加分割线
            {
                System.Windows.Forms.ToolStripSeparator separtor = new ToolStripSeparator();
                this.toolStrip1.Items.Insert(locationIndex, separtor);

                if (this.hsAddButton == null)
                {
                    this.hsAddButton = new System.Collections.Hashtable();
                }
                this.hsAddButton.Add(this.hsAddButton.Count, separtor);
                locationIndex = locationIndex + 1;
            }

            System.Windows.Forms.ToolStripButton trisButton = new ToolStripButton();

            trisButton.Text = buttonText;                   //按钮名称
            trisButton.ToolTipText = trsipDescription;      //按钮提示
            trisButton.TextImageRelation = TextImageRelation.ImageAboveText;
            trisButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            trisButton.Image = image;

            trisButton.Tag = e;

            this.toolStrip1.Items.Insert(locationIndex, trisButton);

            if (this.hsAddButton == null)
            {
                this.hsAddButton = new System.Collections.Hashtable();
            }
            this.hsAddButton.Add(this.hsAddButton.Count, trisButton);
            //image.Dispose();
        }

        /// <summary>
        /// 工具栏重置
        /// </summary>
        protected virtual void ResetToolBar()
        {
            if (this.hsAddButton != null)
            {
                foreach (ToolStripItem stripItem in this.hsAddButton.Values)
                {
                    this.toolStrip1.Items.Remove(stripItem);
                }

                this.hsAddButton.Clear();
                this.hsAddButton = null;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        protected virtual int OnDel()
        {
            this.ucBaseCompoent.OnDelete();

            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        protected virtual int OnSave()
        {
            this.ucBaseCompoent.Save(null, null);

            return 1;
        }

        /// <summary>
        /// 申请单
        /// </summary>
        /// <returns></returns>
        protected virtual int OnApplyList()
        {
            this.ucBaseCompoent.OnApplyList();

            return 1;
        }

        /// <summary>
        /// 入库单
        /// </summary>
        /// <returns></returns>
        protected virtual int OnInList()
        {
            this.ucBaseCompoent.OnInList();

            return 1;
        }

        /// <summary>
        /// 出库单
        /// </summary>
        /// <returns></returns>
        protected virtual int OnOutList()
        {
            this.ucBaseCompoent.OnOutList();

            return 1;
        }

        /// <summary>
        /// 采购单
        /// </summary>
        /// <returns></returns>
        protected virtual int OnStockList()
        {
            this.ucBaseCompoent.OnStockList();

            return 1;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        protected virtual int OnExport()
        {
            this.ucBaseCompoent.OnExport();

            return 1;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        protected virtual int OnImport()
        {
            this.ucBaseCompoent.OnImport();

            return 1;
        }

        /// <summary>
        /// 设置工具栏按钮显示情况
        /// </summary>
        /// <param name="isShowApplyButton"></param>
        /// <param name="isShowInButton"></param>
        /// <param name="isShowOutButton"></param>
        /// <param name="isShowStockButton"></param>
        /// <param name="isShowDelButton"></param>
        /// <param name="isShowExport"></param>
        /// <param name="isShowImport"></param>
        protected virtual void SetToolBarButtonVisible(bool isShowApplyButton, bool isShowInButton, bool isShowOutButton, bool isShowStockButton, bool isShowDelButton, bool isShowExport, bool isShowImport)
        {
            this.ResetToolBar();

            this.tsbApplyList.Visible = isShowApplyButton;
            this.tsbInList.Visible = isShowInButton;
            this.tsbOutList.Visible = isShowOutButton;
            this.tsbStockList.Visible = isShowStockButton;
            this.tsbDel.Visible = isShowDelButton;
            this.tsbExport.Visible = isShowExport;
            this.tsbImport.Visible = isShowImport;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.tsbExit)      //退出
            {
                this.Close();
            }
            if (e.ClickedItem == this.tsbDel)       //删除
            {
                this.OnDel();
            }
            if (e.ClickedItem == this.tsbSave)      //保存
            {
                this.OnSave();
            }
            if (e.ClickedItem == this.tsbApplyList) //申请单
            {
                this.OnApplyList();
            }
            if (e.ClickedItem == this.tsbInList)    //入库单
            {
                this.OnInList();
            }
            if (e.ClickedItem == this.tsbOutList)   //出库单
            {
                this.OnOutList();
            }
            if (e.ClickedItem == this.tsbStockList)//采购单
            {
                this.OnStockList();
            }
            if (e.ClickedItem == this.tsbExport)    //导出
            {
                this.OnExport();
            }
            if (e.ClickedItem == this.tsbImport)    //导入
            {
                this.OnImport();
            }
            if (e.ClickedItem.Tag == null)
            {
                return;
            }

            System.EventHandler eHandler = e.ClickedItem.Tag as System.EventHandler;
            if (eHandler != null)
            {
                eHandler(null, System.EventArgs.Empty);
            }
        }

        private void ucBaseCompoent_AddToolButtonEvent(string text, string toolstrip, Image image, int location, bool isAddSeparator, EventHandler e)
        {
            this.AddToolButton(text, toolstrip, image, location, isAddSeparator, e);
        }

        private void ucBaseCompoent_SetToolButtonVisibleEvent(bool isShowApply, bool isShowIn, bool isShowOut, bool isShowStock, bool isShowDel, bool isShowExport, bool isShowImport)
        {
            this.SetToolBarButtonVisible(isShowApply, isShowIn, isShowOut, isShowStock, isShowDel, isShowExport, isShowImport);
        }

    }
}