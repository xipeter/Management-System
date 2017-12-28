using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// 层级形式开立医嘱 yangw 20101024
    /// {1EB2DEC4-C309-441f-BCCE-516DB219FD0E} 
    /// </summary>
    public partial class tvItemLevel : Neusoft.FrameWork.WinForms.Controls.NeuTreeView
    {
        public tvItemLevel()
        {
            InitializeComponent();
            this.ImageList = imageList1;
        }

        public tvItemLevel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #region 属性
        Neusoft.HISFC.BizLogic.Manager.ItemLevel itemLevelManager = new Neusoft.HISFC.BizLogic.Manager.ItemLevel();

        /// <summary>
        /// 修改前组套名称
        /// </summary>
        string labelName = "";
        
        /// <summary>
        /// 0 全部，1门诊，2住院
        /// </summary>
        private int inOutType = 0;

        public int InOutType
        {
            get 
            { 
                return inOutType; 
            }
            set 
            { 
                inOutType = value; 
            }
        }

        private bool isEdit = false;

        public bool IsEdit
        {
            set
            {
                this.isEdit = value;
            }
            get
            {
                return isEdit;
            }
        }
        

        /// <summary>
        /// 分层的大类
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject levelClass = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 分层的大类
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject LevelClass
        {
            get { return levelClass; }
            set { levelClass = value; }
        }

        #endregion

        #region 函数
        public void RefreshGroupByClass()
        {
            if (string.IsNullOrEmpty(levelClass.ID))
            {
                return;
            }
            this.Nodes.Clear();
            TreeNode rootNode = new TreeNode(levelClass.Name);
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 1;
            Neusoft.HISFC.Models.Fee.Item.ItemLevel rootLevel = new Neusoft.HISFC.Models.Fee.Item.ItemLevel();
            rootLevel.ID = "ROOT";
            rootLevel.LevelClass = this.levelClass;
            rootLevel.UserCode = "F";
            rootNode.Tag = rootLevel;
            this.Nodes.Add(rootNode);

            #region "获得组套 获取当前科室的科室组套 当前操作员的个人组套  全院组套"
            ArrayList alFolder = this.itemLevelManager.GetAllFirstLVFolder(this.inOutType, levelClass.ID);

            if (alFolder == null)
            {
                return;
            }

            #endregion

            try
            {
                TreeNode node;

                Neusoft.HISFC.Models.Fee.Item.ItemLevel info;
                for (int i = 0; i < alFolder.Count; i++)
                {
                    info = alFolder[i] as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                    if (info == null)
                    {
                        continue;
                    }
                    node = new TreeNode(info.Name);
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 3;
                    node.Tag = info;
					
                    this.Nodes[0].Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.Nodes[0].ExpandAll();
            this.Nodes[0].Expand();
        }     
        #endregion

        #region 事件
        protected override void OnMouseUp(MouseEventArgs e)
        {

            //base.OnMouseUp(e);

            //if (!this.isEdit)
            //{
            //    return;
            //}

            //this.SelectedNode = this.GetNodeAt(e.X, e.Y);

            //if (this.SelectedNode == null || this.SelectedNode.Tag == null)
            //    this.LabelEdit = false;
            //else
            //    this.LabelEdit = true;

            //try
            //{
            //    if (e.Button == MouseButtons.Right)
            //    {
            //        if (this.SelectedNode.Tag == null)
            //        {
            //            ContextMenu m = new ContextMenu();
            //            MenuItem AddItem = new MenuItem("增加文件夹");
            //            AddItem.Click += new EventHandler(AddItem_Click);
            //            m.MenuItems.Add(AddItem);

            //            if (this.SelectedNode != this.Nodes[0])
            //            {

            //                MenuItem deleteItem = new MenuItem("删除");
            //                deleteItem.Click += new EventHandler(deleteItem_Click);
            //                m.MenuItems.Add(deleteItem);
            //            }

            //            this.ContextMenu = m;
            //            this.ContextMenu.Show(this, new Point(e.X, e.Y));
            //        }
            //        else
            //        {
            //            if (this.SelectedNode.Tag.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.ItemLevel))
            //            {
            //                //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
            //                Neusoft.HISFC.Models.Fee.Item.ItemLevel ilTmp = this.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
            //                if (ilTmp.UserCode == "F")
            //                {
            //                    if (this.SelectedNode.Nodes.Count > 0)
            //                    {
            //                        ContextMenu m = new ContextMenu();

            //                        MenuItem AddItem = new MenuItem("增加文件夹");
            //                        AddItem.Click += new EventHandler(AddItem_Click);
            //                        m.MenuItems.Add(AddItem);

            //                        this.ContextMenu = m;
            //                        this.ContextMenu.Show(this, new Point(e.X, e.Y));
            //                    }
            //                    else
            //                    {
            //                        ContextMenu m = new ContextMenu();
            //                        MenuItem AddItem = new MenuItem("增加文件夹");
            //                        AddItem.Click += new EventHandler(AddItem_Click);
            //                        m.MenuItems.Add(AddItem);

            //                        MenuItem deleteItem = new MenuItem("删除");
            //                        deleteItem.Click += new EventHandler(deleteItem_Click);
            //                        m.MenuItems.Add(deleteItem);

            //                        this.ContextMenu = m;
            //                        this.ContextMenu.Show(this, new Point(e.X, e.Y));
            //                    }
            //                }
            //                else
            //                {
            //                    ContextMenu m = new ContextMenu();

            //                    MenuItem deleteItem = new MenuItem("删除");
            //                    deleteItem.Click += new EventHandler(deleteItem_Click);
            //                    m.MenuItems.Add(deleteItem);
            //                    this.ContextMenu = m;
            //                    this.ContextMenu.Show(this, new Point(e.X, e.Y));
            //                }
            //            }
            //            else
            //            {
            //                this.ContextMenu = null;
            //            }
            //        }
            //    }
            //}
            //catch { }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.ContextMenu != null)
            {
                if (this.ContextMenu.MenuItems.Count > 0)
                {
                    this.ContextMenu.MenuItems.Clear();
                }
            }
        }

        void AddItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.ImageIndex = 2;
            node.SelectedImageIndex = 3;
            Neusoft.HISFC.Models.Fee.Item.ItemLevel itemLevel = new Neusoft.HISFC.Models.Fee.Item.ItemLevel();
            itemLevel.ID = this.itemLevelManager.GetNewFolderID();
            itemLevel.Name = "新建文件夹";
            itemLevel.InOutType = this.inOutType;
            if (this.SelectedNode == this.Nodes[0])
            {
                itemLevel.Dept.ID = (this.itemLevelManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                itemLevel.Owner = this.itemLevelManager.Operator;
                itemLevel.ParentID = "ROOT";                //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
                itemLevel.LevelClass = this.levelClass;
            }
            else
            {//{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
                Neusoft.HISFC.Models.Fee.Item.ItemLevel itemLevelSelected = this.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;

                itemLevel.Dept = itemLevelSelected.Dept;

                itemLevel.Owner = this.itemLevelManager.Operator;
                itemLevel.ParentID = itemLevelSelected.ID;
                itemLevel.LevelClass = this.levelClass;
            }
            itemLevel.UserCode = "F";
            if (this.itemLevelManager.SetNewFolder(itemLevel) < 0)
            {
                MessageBox.Show("增加文件夹失败！");
                return;
            }
            node.Text = itemLevel.Name;
            node.Tag = itemLevel;
            this.SelectedNode.Nodes.Add(node);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                Neusoft.HISFC.Models.Fee.Item.ItemLevel info = this.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                if (info.UserCode == "F")//文件夹
                {
                    if (MessageBox.Show("是否删除文件夹" + info.Name, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (this.itemLevelManager.deleteFolder(info) < 0)
                        {
                            MessageBox.Show(this.itemLevelManager.Err);
                        }
                        this.RefreshGroupByClass();
                    }
                }
                //else
                //{
                //    if (MessageBox.Show("是否删除组套" + info.Name, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //    {
                //        if (this.itemLevelManager.DeleteGroup(info) == -1)
                //        {
                //            MessageBox.Show(this.groupManager.Err);
                //        }
                //        this.RefreshGroupByClass();
                //    }
                //}
            }
            catch { }
        }

        //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            object o = this.SelectedNode.Tag;
            if (o != null)
            {
                if (o.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.ItemLevel))
                {
                    this.SelectedNode.Nodes.Clear();
                    Neusoft.HISFC.Models.Fee.Item.ItemLevel info = o as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                    if (info.UserCode == "F")
                    {

                        #region 加载此文件夹下面的咚咚

                        ArrayList alFolder = new ArrayList();

                        if (info.ID == "ROOT")
                        {
                            alFolder = this.itemLevelManager.GetAllFolderByFolderAndLevelClass(info.ID, info.LevelClass.ID);
                        }
                        else
                        {
                            alFolder = this.itemLevelManager.GetAllFolderByFolderID(info.ID);
                        }
                        if (alFolder == null)
                        {
                            return;
                        }

                        try
                        {
                            TreeNode node;

                            Neusoft.HISFC.Models.Fee.Item.ItemLevel myGroup;
                            for (int i = 0; i < alFolder.Count; i++)
                            {
                                myGroup = alFolder[i] as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                                if (info == null)
                                {
                                    continue;
                                }
                                node = new TreeNode(myGroup.Name);
                                node.ImageIndex = 2;
                                node.SelectedImageIndex = 3;
                                node.Tag = myGroup;

						
                                this.SelectedNode.Nodes.Add(node);
                                
                            }
                            //ArrayList alGroup = this.groupManager.GetGroupByFolderID(info.ID);
                            //if (alGroup != null && alGroup.Count > 0)
                            //{
                            //    for (int j = 0; j < alGroup.Count; j++)
                            //    {
                            //        Neusoft.HISFC.Models.Fee.Item.ItemLevel group = alGroup[j] as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                            //        if (group == null)
                            //        {
                            //            continue;
                            //        }
                            //        TreeNode temNode = new TreeNode(group.Name);
                            //        temNode.ImageIndex = 10;
                            //        temNode.SelectedImageIndex = 11;
                            //        temNode.Tag = group;
                            //        this.SelectedNode.Nodes.Add(temNode);
                            //    }
                            //}

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }

                        this.SelectedNode.Expand();

                        #endregion

                    }
                }
            }
            base.OnAfterSelect(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
        {
            if (this.SelectedNode == null)
            {
                this.labelName = "";
            }

            this.labelName = this.SelectedNode.Text;

            base.OnBeforeLabelEdit(e);
        }

        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            if (!isEdit)
            {
                return;
            }

            if (e.Label == null)
            {
                this.LabelEdit = false;
                return;
            }

            #region 更改组套名称权限控制 --2007-11-21 zhangqi

            Neusoft.HISFC.Models.Fee.Item.ItemLevel itemLevel = this.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;

                DialogResult r = MessageBox.Show("节点名称已经修改，是否保存？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel)
                {
                    this.LabelEdit = false;
                    //{3E29ADED-FB2D-4243-B525-BBDD79D85C2B} 
                    this.SelectedNode.Text = this.labelName;
                    this.RefreshGroupByClass();
                    return;
                }

                if ((this.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel).UserCode == "F")
                {
                    Neusoft.HISFC.Models.Fee.Item.ItemLevel tem = this.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
                    tem.Name = e.Label;
                    tem.LevelClass = this.levelClass;
                    if (this.itemLevelManager.updateFolder(tem) <= 0)
                    {
                        MessageBox.Show("文件夹名称更新失败·", "提示");
                    }
                    else
                    {
                        MessageBox.Show("文件夹名称更新成功！", "提示");
                    }
                }
                //else
                //{
                //    string GroupId = (this.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel).ID;
                //    if (groupManager.UpdateGroupName(GroupId, e.Label) > 0)
                //        MessageBox.Show("组套名称更新成功", "提示");
                //    else
                //    {
                //        MessageBox.Show("更新失败", "提示");
                //    }
                //}
            #endregion

            this.LabelEdit = false;
          
        }

        //protected override void OnDoubleClick(EventArgs e)
        //{
            
        //    object o = this.SelectedNode.Tag;
        //    if (o != null)
        //    {
        //        //if (o.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.ItemLevel))
        //        //{
        //        //    Neusoft.HISFC.Models.Fee.Item.ItemLevel info = o as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
        //        //    Forms.frmSelectGroup fSelect = new Neusoft.HISFC.Components.Common.Forms.frmSelectGroup(info);

        //        //    fSelect.InpatientType = this.inpatientType;
        //        //    if (fSelect.ShowDialog() == DialogResult.OK)
        //        //    {
        //        //        try
        //        //        {
        //        //            if (SelectOrder != null)
        //        //                SelectOrder(fSelect.Orders);
        //        //        }
        //        //        catch { }
        //        //    }
        //        //}
        //    }
        //}

        #region 代改
        //private void tvDoctorGroup_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        //{
        //    e.Effect = System.Windows.Forms.DragDropEffects.Move;
        //}

        //private void tvDoctorGroup_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        //{
        //    System.Drawing.Point position = new Point(0, 0);
        //    position.X = e.X;
        //    position.Y = e.Y;
        //    position = this.PointToClient(position);
        //    TreeNode dropNode = this.GetNodeAt(position);
        //    this.SelectedNode = dropNode;
        //    this.Focus();
        //}

        //private void tvDoctorGroup_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        //开始进行"Drag"操作
        //        DoDragDrop((TreeNode)e.Item, DragDropEffects.Move);
        //    }
        //}

        //private void tvDoctorGroup_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        //{
        //    TreeNode temp = new TreeNode();
        //    //得到要移动的节点
        //    TreeNode moveNode = (TreeNode)e.Data.GetData(temp.GetType());
        //    //转换坐标为控件treeview的坐标
        //    Point position = new Point(0, 0);
        //    position.X = e.X;
        //    position.Y = e.Y;
        //    position = this.PointToClient(position);

        //    //得到移动的目的地的节点
        //    TreeNode aimNode = this.GetNodeAt(position);
        //    if (aimNode == null)//超出区域 返回
        //    {
        //        return;
        //    }
        //    //			if(aimNode.Parent != moveNode.Parent) //不是同一级别 返回
        //    //			{
        //    //				if(aimNode.Parent.Parent!= moveNode.Parent.Parent)
        //    //				{
        //    //					return;
        //    //				}
        //    //			}
        //    if (moveNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel == null) //是组套父节点 返回
        //    {
        //        return;
        //    }
        //    if ((moveNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel).UserCode == "F")//是文件夹节点 返回
        //    {
        //        return;
        //    }
        //    if (aimNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel == null)//目标节点 是父节点
        //    {
        //        return;
        //    }
        //    if ((aimNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel).UserCode != "F")//目标节点不是文件夹
        //    {
        //        return;
        //    }
        //    Neusoft.HISFC.Models.Fee.Item.ItemLevel g1 = moveNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
        //    Neusoft.HISFC.Models.Fee.Item.ItemLevel g2 = aimNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;

        //    if (IsDragEnable(aimNode, moveNode) == true)
        //    {
        //        if (aimNode != moveNode)
        //        {
        //            Neusoft.HISFC.Models.Fee.Item.ItemLevel temGroup = aimNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;
        //            Neusoft.HISFC.Models.Fee.Item.ItemLevel tempGroup = moveNode.Tag as Neusoft.HISFC.Models.Fee.Item.ItemLevel;

        //            if (temGroup == null || tempGroup == null)
        //            {
        //                return;
        //            }
        //            //try
        //            //{
        //            //    if (this.groupManager.UpdateGroupFolderID(tempGroup.ID, temGroup.ID) < 0)
        //            //    {
        //            //        MessageBox.Show("拖动组套到文件夹失败·");
        //            //        return;
        //            //    }
        //            //}
        //            //catch (Exception ex)
        //            //{
        //            //    MessageBox.Show("拖动组套到文件夹失败·" + ex.Message);
        //            //    return;
        //            //}
        //            this.Nodes.Remove(moveNode);
        //            aimNode.Nodes.Add(moveNode);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 判断是否可以拖动动目标节点，如果可以则返回true，否则为false;
        ///// 判断根据是：目标节点不能是被拖动的节点的父亲节点！
        ///// </summary>
        //private bool IsDragEnable(TreeNode aimNode, TreeNode oriNode)
        //{
        //    while (aimNode != null)
        //    {
        //        if (aimNode.Parent != oriNode)
        //        {
        //            aimNode = aimNode.Parent;
        //            IsDragEnable(aimNode, oriNode);
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        #endregion
        #endregion
    }
}
