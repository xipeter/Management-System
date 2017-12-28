using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.WinForms.Controls;

namespace Neusoft.Shell.WinForms.Forms
{
    public partial class SystemErrorForm : InputBaseForm
    {
        public SystemErrorForm(string msgInfo, Exception e)
        {
            InitializeComponent();

            _e = e;

            this.txtObject.Text = _e.Source;
            this.txtMethod.Text = _e.TargetSite.ToString();
            if (msgInfo != null && _e.InnerException != null)
            {
                this.txtMessage.Text = msgInfo + "\n" + _e.Message + "\n" + _e.InnerException.Message;
            }
            else if (msgInfo == null && _e.InnerException != null)
            {
                this.txtMessage.Text = _e.Message + "\n" + _e.InnerException.Message;
            }
            else if (msgInfo != null && _e.InnerException == null)
            {
                this.txtMessage.Text = msgInfo + "\n" + _e.Message;
            }
            else
            {
                this.txtMessage.Text = _e.Message;
            }
            //this.txtDetail.Text = _e.ToString();
            this.btnContinue.Click += new EventHandler(btnContinue_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnDetail.Click += new EventHandler(btnDetail_Click);
            this.BottomPanel.Visible = false;
            this.Height = 412 - 96;
            SetTreeList(e);
        }
        public SystemErrorForm(Exception e)
            : this(null, e)
        {
        }
        void btnDetail_Click(object sender, EventArgs e)
        {
            if (this.BottomPanel.Visible)
            {
                this.BottomPanel.Visible = false;
                this.Height = 412 - 96;
                this.btnDetail.Text = "ÏêÏ¸ÐÅÏ¢>>";
            }
            else
            {
                this.BottomPanel.Visible = true;
                this.Height = 412;
                this.btnDetail.Text = "<<ÏêÏ¸ÐÅÏ¢";
            }
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        NTreeListView _treeList = new NTreeListView();
        private void SetTreeList(Exception ex)
        {
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();

            _treeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader2, columnHeader1 });
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            _treeList.Comparer = treeListViewItemCollectionComparer1;
            _treeList.Location = new System.Drawing.Point(-19, 47);
            _treeList.UseCompatibleStateImageBehavior = false;
            _treeList.MultiSelect = false;
            _treeList.HideSelection = false;
            _treeList.Dock = DockStyle.Fill;
            _treeList.ShowItemToolTips = false;
            _treeList.LabelEdit = false;
            _treeList.LabelWrap = false;
            _treeList.FullRowSelect = true;
            _treeList.ContextMenuStrip = contextMenuStrip1;

            columnHeader2.Text = "´íÎóÐÅÏ¢";
            columnHeader2.Width = 200;

            columnHeader1.Text = "´íÎóÁÐ±í";
            columnHeader1.Width = 800;

            TreeListViewItem root = new TreeListViewItem("´íÎóÐÅÏ¢", 3);
            root.SubItems.Add(ex.ToString());
            _treeList.Items.Add(root);

            TreeListViewItem rootParent = root;
            Exception exClone = ex;

            do
            {
                #region µü´úÓï¾ä
                TreeListViewItem itemHelpLink = new TreeListViewItem("HelpLink", 1);
                TreeListViewItem itemInnerException = new TreeListViewItem("InnerException", 1);
                TreeListViewItem itemMessage = new TreeListViewItem("Message", 1);
                TreeListViewItem itemSource = new TreeListViewItem("Source", 1);
                TreeListViewItem itemStackTrace = new TreeListViewItem("StackTrace", 1);

                if (exClone.HelpLink != null)
                {
                    itemHelpLink.SubItems.Add(exClone.HelpLink.ToString());
                }
                else
                {
                    itemHelpLink.SubItems.AddRange(new string[] { "" });

                }
                if (exClone.Message != null)
                {
                    itemMessage.SubItems.Add(exClone.Message.ToString());

                }
                else
                {
                    itemMessage.SubItems.AddRange(new string[] { "" });

                }
                if (exClone.Source != null)
                {
                    itemSource.SubItems.AddRange(new string[] { exClone.Source.ToString() });

                }
                else
                {
                    itemSource.SubItems.AddRange(new string[] { "" });

                }
                if (exClone.StackTrace != null)
                {
                    itemStackTrace.SubItems.Add(exClone.StackTrace.Replace("\r\n", "\r\n "));
                }
                else
                {
                    itemStackTrace.SubItems.AddRange(new string[] { "" });

                }
                if (exClone.InnerException != null)
                {

                    itemInnerException.SubItems.Add(exClone.InnerException.ToString());

                }
                else
                {
                    itemInnerException.SubItems.Add(String.Empty);

                }

                rootParent.Items.Add(itemHelpLink);
                rootParent.Items.Add(itemInnerException);
                rootParent.Items.Add(itemMessage);
                rootParent.Items.Add(itemSource);
                rootParent.Items.Add(itemStackTrace);

                rootParent = itemInnerException;
                exClone = exClone.InnerException;
                #endregion
            }
            while (exClone != null);

            _treeList.SmallImageList = new ImageList();

            Control C = _treeList as Control;
            BottomPanel.Controls.Add(C);
        }

        private Exception _e;

        private void ÏêÏ¸ÐÅÏ¢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form showInfo = new Form();
            showInfo.Text = "´íÎóÏêÏ¸ÐÅÏ¢";
            if (_treeList.SelectedItems.Count > 0)
            {
                showInfo.Height = 600;
                showInfo.Width = 800;
                RichTextBox rtbshow = new RichTextBox();
                rtbshow.ReadOnly = true;
                rtbshow.BorderStyle = BorderStyle.None;
                rtbshow.Dock = DockStyle.Fill;
                rtbshow.BackColor = Color.White;
                rtbshow.Text = (_treeList.SelectedItems[0] as TreeListViewItem).SubItems[1].Text;
                showInfo.Controls.Add(rtbshow);
                showInfo.ShowDialog();
            }
        }
    }
}