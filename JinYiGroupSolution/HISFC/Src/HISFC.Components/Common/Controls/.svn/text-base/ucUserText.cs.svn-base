using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: 用户文本控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucUserText : UserControl
    {
        public ucUserText()
        {
            InitializeComponent();
        }

        #region 变量
        Neusoft.HISFC.BizLogic.Manager.UserText manager = new Neusoft.HISFC.BizLogic.Manager.UserText();
        //Group信息
        private Neusoft.FrameWork.Models.NeuObject groupInfo;

        #region 在增加修改时传出的事件 路志鹏 2007-5-9
        public event EventHandler OnChange;
        protected virtual void OnChanged()
        {
            if (this.OnChange != null)
                this.OnChange(this, new EventArgs());
        }
        #endregion

        #endregion
        
        #region 函数
        /// <summary>
        /// 用Memo进行分组
        /// </summary>
        private void ShowGroup()
        {
            for (int i = this.treeView1.Nodes[0].Nodes.Count - 1; i >= 0; i--)//个人的
            {
                TreeNode node = this.treeView1.Nodes[0].Nodes[i];
                Neusoft.FrameWork.Models.NeuObject obj = node.Tag as Neusoft.FrameWork.Models.NeuObject;
                if (obj.Memo != "")//可以分组
                {
                    //遍历查找树的组
                    bool b = false;
                    foreach (TreeNode mynode in this.treeView1.Nodes[0].Nodes)
                    {
                        if (mynode.Text == obj.Memo && mynode != node)
                        {
                            b = true;
                            node.Parent.Nodes.Remove(node);
                            mynode.Nodes.Add(node);
                        }
                    }
                    if (b == false)
                    {
                        TreeNode newNode = new TreeNode(obj.Memo);
                        this.treeView1.Nodes[0].Nodes.Add(newNode);
                        node.Parent.Nodes.Remove(node);
                        newNode.Nodes.Add(node);
                    }
                }
            }
            for (int i = this.treeView1.Nodes[1].Nodes.Count - 1; i >= 0; i--)//科室的
            {
                TreeNode node = this.treeView1.Nodes[1].Nodes[i];
                Neusoft.FrameWork.Models.NeuObject obj = node.Tag as Neusoft.FrameWork.Models.NeuObject;
                if (obj.Memo != "")//可以分组
                {
                    //遍历查找树的组
                    bool b = false;
                    foreach (TreeNode mynode in this.treeView1.Nodes[1].Nodes)
                    {
                        if (mynode.Text == obj.Memo && mynode != node)
                        {
                            b = true;
                            node.Parent.Nodes.Remove(node);
                            mynode.Nodes.Add(node);
                        }
                    }
                    if (b == false)
                    {
                        TreeNode newNode = new TreeNode(obj.Memo);
                        this.treeView1.Nodes[1].Nodes.Add(newNode);
                        node.Parent.Nodes.Remove(node);
                        newNode.Nodes.Add(node);
                    }
                }
            }
        }


        protected Neusoft.HISFC.Models.Base.UserText GetSelectedObject(TreeNode node)
        {
            if (node.Tag == null) return null;
            return node.Tag as Neusoft.HISFC.Models.Base.UserText;
        }
      
       

        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.RefreshList();
                this.treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
                this.treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
                this.treeView1.MouseMove += new MouseEventHandler(treeView1_MouseMove);
                this.toolTip1.InitialDelay = 0;
                this.toolTip1.ReshowDelay = 0;
                this.toolTip1.AutomaticDelay = 0;
            }
            catch { }
            base.OnLoad(e);
        }

        private void menuItem1_Click_1(object sender, System.EventArgs e)
        {

            try
            {
                Neusoft.HISFC.Models.Base.UserText obj = this.GetSelectedObject(this.treeView1.SelectedNode);
                if (obj == null) return;
                ucUserSnomedTextControl u = new ucUserSnomedTextControl() ;
                u.UserText = obj;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(u);
                this.RefreshList();
            }
            catch { }
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {

            Neusoft.HISFC.Models.Base.UserText obj = this.GetSelectedObject(this.treeView1.SelectedNode);
            if (obj == null) return;
            if (MessageBox.Show("是否确认删除？", "警告", MessageBoxButtons.YesNo) == DialogResult.No) return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.Manager.UserText m = new Neusoft.HISFC.BizLogic.Manager.UserText();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(m.Connection);
            //t.BeginTransaction();
            //m.SetTrans(t.Trans);
            int i = 0;
            i = m.Delete(obj.ID);
            if (i == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(m.Err);
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("删除成功！");
                this.RefreshList();
            }
        }


        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ucUserText_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void ucUserText_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                Neusoft.HISFC.Models.Base.UserText obj = new Neusoft.HISFC.Models.Base.UserText();
                string s = e.Data.GetData(DataFormats.StringFormat, true).ToString();
                if (s == "") return;
                obj.Text = s;
                try
                {
                    if (sender.GetType().ToString().IndexOf("RichTextBox") > 0)
                    {
                        ((RichTextBox)sender).SelectedText = obj.Text;
                    }
                    else if (sender.GetType().ToString().IndexOf("MultiLine") > 0)
                    {
                        ((RichTextBox)sender).SelectedText = obj.Text;
                    }
                    else if (sender.GetType() == typeof(System.Windows.Forms.TextBox))
                    {
                        ((TextBox)sender).SelectedText = obj.Text;
                    }
                    else if (sender.GetType().ToString().IndexOf("ComboBox") > 0)
                    {
                        ((ComboBox)sender).SelectedText = obj.Text;
                    }
                    else
                    {
                        try
                        {
                            ((TextBox)sender).SelectedText = obj.Text;
                        }
                        catch
                        {
                            ((Control)sender).Text = obj.Text;
                        }
                    }
                }
                catch { }
                e.Data.SetData("");

            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Neusoft.HISFC.Models.Base.UserText obj = this.GetSelectedObject(e.Item as TreeNode);
            if (obj == null) return;
            DoDragDrop(obj.Text, DragDropEffects.Copy);
            TreeNode node = e.Item as TreeNode;
            try
            {
                manager.UpdateFrequency((node.Tag as Neusoft.HISFC.Models.Base.UserText).ID, manager.Operator.ID);
            }//更新不到无所谓的
            catch { }

        }

        private void ucUserText_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.PopMenu(sender, e);
            }
        }

        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = this.treeView1.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            TreeNode node = this.treeView1.GetNodeAt(p);
            if (node == null || node.Tag == null)
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
                this.toolTip1.Active = true;
            }
            else
            {
                if (selectedNode != node)
                {
                    this.toolTip1.SetToolTip(this.treeView1, this.GetSelectedObject(node).Text);
                    this.toolTip1.Active = true;
                }
                selectedNode = node;

            }
        }
        private TreeNode selectedNode = null;
        private void treeView1_MouseDown_1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TreeView)sender).SelectedNode = ((TreeView)sender).GetNodeAt(e.X, e.Y);
            }
        }
      
        #endregion


        #region 公共属性函数
        /// <summary>
        /// 组信息
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject GroupInfo
        {
            get { return this.groupInfo; }
            set { this.groupInfo = value; }
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        public void RefreshList()
        {
            this.treeView1.Nodes[0].Nodes.Clear();
            this.treeView1.Nodes[1].Nodes.Clear();
            Neusoft.HISFC.Models.Base.Employee p = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            if (p == null) return;
            ArrayList al;
            if (this.groupInfo == null || this.groupInfo.ID == "")
                al = manager.GetList(p.Dept.ID, 1);//获得科室
            else
                al = manager.GetList(this.groupInfo.ID, p.Dept.ID, 1);

            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }

            foreach (Neusoft.HISFC.Models.Base.UserText obj in al)
            {
                TreeNode node = new TreeNode(obj.Name);//+"【"+obj.Text+"】");
                try
                {
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 3;
                }
                catch { }
                node.Tag = obj;
                this.treeView1.Nodes[1].Nodes.Add(node);//科室
            }

            if (this.groupInfo == null || this.groupInfo.ID == "")
                al = manager.GetList(p.ID, 0);//获得个人
            else
                al = manager.GetList(this.groupInfo.ID, p.ID, 0);

            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }

            foreach (Neusoft.HISFC.Models.Base.UserText obj in al)
            {
                TreeNode node = new TreeNode(obj.Name);
                try
                {
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 3;
                }
                catch { }
                node.Tag = obj;
                this.treeView1.Nodes[0].Nodes.Add(node);//个人
            }
            try
            {
                ShowGroup();
            }
            catch { }

            this.treeView1.Nodes[0].Expand();
            this.treeView1.Nodes[1].Expand();
            //在刷新树的时候同时刷新外部数据 路志鹏 2007-5-9
            this.OnChanged();
        }

        /// <summary>
        /// 新建立
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="RichText"></param>
        /// <returns></returns>
        public int Add(string Text, string RichText)
        {
            Neusoft.HISFC.Models.Base.UserText obj = new Neusoft.HISFC.Models.Base.UserText();
            obj.Text = Text;
            obj.RichText = RichText;
            if (this.groupInfo != null && this.groupInfo.ID != "")
            {
                obj.Group.ID = this.groupInfo.ID;
                obj.Group.Name = this.groupInfo.Name;
            }
            ucUserSnomedTextControl u = new ucUserSnomedTextControl();
            u.UserText = obj;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(u);
            this.RefreshList();
            return 0;
        }

        /// <summary>
        /// 循环设置控件绑定
        /// </summary>
        /// <param name="c"></param>
        public void SetControl(IContainer c)
        {
            if (c == null) return;
            foreach (Component p in c.Components)
            {
                try
                {
                    ((Control)p).AllowDrop = true;
                    try
                    {
                        ((Control)p).MouseUp -= new MouseEventHandler(ucUserText_MouseUp);
                        ((Control)p).DragEnter -= new DragEventHandler(ucUserText_DragEnter);
                        ((Control)p).DragDrop -= new DragEventHandler(ucUserText_DragDrop);
                    }
                    catch { }
                    ((Control)p).MouseUp += new MouseEventHandler(ucUserText_MouseUp);
                    ((Control)p).DragEnter += new DragEventHandler(ucUserText_DragEnter);
                    ((Control)p).DragDrop += new DragEventHandler(ucUserText_DragDrop);
                }
                catch { }

            }
        }
        private void PopMenu(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ToolStripMenuItem addMenu = new ToolStripMenuItem();

            addMenu.Text = "添加到用户文本";
            addMenu.Tag = sender;
            ContextMenuStrip pMenu = new ContextMenuStrip();


            #region 新加复制，粘贴功能
            if (sender.GetType().ToString().IndexOf("RichTextBox") > 0
                || sender.GetType().ToString().IndexOf("MultiLine") > 0
                  || sender.GetType() == typeof(System.Windows.Forms.TextBox)
                || sender.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)))
            {
                ToolStripMenuItem copyMenu = new ToolStripMenuItem();
                copyMenu.Text = "复制";
                copyMenu.Tag = sender;

                copyMenu.Click += new EventHandler(copyMenu_Click);
                ToolStripMenuItem pasteMenu = new ToolStripMenuItem();
                pasteMenu.Text = "粘贴";
                pasteMenu.Tag = sender;
                pasteMenu.Click += new EventHandler(pasteMenu_Click);

                pMenu.Items.Add(copyMenu);
                pMenu.Items.Add(pasteMenu);

            }
            
            
            #endregion

            pMenu.Items.Add(addMenu);
            addMenu.Click += new EventHandler(addMenu_Click);
            
            ((Control)sender).ContextMenuStrip = pMenu;

        }

        void pasteMenu_Click(object sender, EventArgs e)
        {
            sender = ((ToolStripItem)sender).Tag;
            if (sender.GetType().ToString().IndexOf("RichTextBox") > 0)
            {
                ((RichTextBox)sender).Paste();
            }
            else if (sender.GetType().ToString().IndexOf("MultiLine") > 0)
            {
                ((RichTextBox)sender).Paste();
            }
            else if (sender.GetType() == typeof(System.Windows.Forms.TextBox) || sender.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)))
            {
                ((TextBox)sender).Paste();
            }
            else if (sender.GetType().ToString().IndexOf("ComboBox") > 0)
            {
                
            }

            
        }

        void copyMenu_Click(object sender, EventArgs e)
        {
            sender = ((ToolStripItem)sender).Tag;
            if (sender.GetType().ToString().IndexOf("RichTextBox") > 0)
            {
                ((RichTextBox)sender).Copy();
            }
            else if (sender.GetType().ToString().IndexOf("MultiLine") > 0)
            {
                ((RichTextBox)sender).Copy();
            }
            else if (sender.GetType() == typeof(System.Windows.Forms.TextBox)
           || sender.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)))
            {
                ((TextBox)sender).Copy();
            }
            else if (sender.GetType().ToString().IndexOf("ComboBox") > 0)
            {
            }

        }

        void addMenu_Click(object sender, EventArgs e)
        {
            sender = ((ToolStripItem)sender).Tag;
            try
            {
                if (sender.GetType().ToString().IndexOf("RichTextBox") > 0)
                {
                    Add(((RichTextBox)sender).SelectedText, ((RichTextBox)sender).SelectedRtf);
                }
                else if (sender.GetType().ToString().IndexOf("MultiLine") > 0)
                {
                    Add(((RichTextBox)sender).SelectedText, ((RichTextBox)sender).SelectedRtf);
                }
                else if (sender.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    Add(((TextBox)sender).SelectedText, "");
                }
                else if (sender.GetType().ToString().IndexOf("ComboBox") > 0)
                {
                    Add(((ComboBox)sender).SelectedText, "");
                }
                else
                {
                    try
                    {
                        Add(((TextBox)sender).SelectedText, "");
                    }
                    catch { Add(((Control)sender).Text, ""); }
                }
            }
            catch { }
        }
        #endregion

        //.
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem tsmMenu = new ToolStripMenuItem();
            tsmMenu.Text = "修改";
            tsmMenu.Tag = sender;

            ToolStripMenuItem tsdMenu = new ToolStripMenuItem();
            tsdMenu.Text = "删除";
            tsdMenu.Tag = sender;

            ContextMenuStrip cmsmMenu = new ContextMenuStrip();

            cmsmMenu.Items.Add(tsmMenu);
            cmsmMenu.Items.Add(tsdMenu);

            tsmMenu.Click += new EventHandler(menuItem1_Click_1);
            tsdMenu.Click += new EventHandler(menuItem2_Click);

            ((Control)sender).ContextMenuStrip = cmsmMenu;
        }
        //.
        
      
       
      
    }
}
