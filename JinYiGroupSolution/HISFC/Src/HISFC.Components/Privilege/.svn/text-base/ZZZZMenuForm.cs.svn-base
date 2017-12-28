using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Neusoft.WinForms;
//using Neusoft.WinForms.Forms;
using Neusoft.Privilege.ServiceContracts.Model.Impl;
using System.Resources;
using Neusoft.Privilege.ServiceContracts.Contract;
//using Neusoft.Framework;
using System.Transactions;
using Neusoft.Privilege.WinForms.Forms;
namespace Neusoft.Privilege.WinForms
{
    public partial class ZZZZMenuForm : Neusoft.Privilege.WinForms.Forms.PermissionBaseForm
    {
        public ZZZZMenuForm()
        {
            InitializeComponent();

            this.InitToolBar();
            this.LoadMenu();

            this.MainToolStrip.ItemClicked += new ToolStripItemClickedEventHandler(MainToolStrip_ItemClicked);
            this.tvMenu.AfterSelect += new TreeViewEventHandler(tvMenu_AfterSelect);
            this.tvMenu.BeforeLabelEdit += new NodeLabelEditEventHandler(tvMenu_BeforeLabelEdit);
            this.tvMenu.AfterLabelEdit += new NodeLabelEditEventHandler(tvMenu_AfterLabelEdit);
            this.tvMenu.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvMenu_NodeMouseClick);
            this.tvMenu.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvMenu_NodeMouseDoubleClick);
            this.lvMenu.DoubleClick += new EventHandler(lvMenu_DoubleClick);
            this.lvMenu.MouseClick += new MouseEventHandler(lvMenu_MouseClick);

            this.AddTypeItem.Click += new EventHandler(AddTypeItem_Click);
            this.RemoveTypeItem.Click += new EventHandler(RemoveTypeItem_Click);
            this.AddMenuItem.Click += new EventHandler(AddMenuItem_Click);
            this.RemoveMenuItem.Click += new EventHandler(RemoveMenuItem_Click);
            this.ModifyMenuItem.Click += new EventHandler(ModifyMenuItem_Click);
            this.UpItem.Click += new EventHandler(UpItem_Click);
            this.DownItem.Click += new EventHandler(DownItem_Click);
        }               
                
        private IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> _menus;

        private void InitToolBar()
        {
            ToolBarService _toolBarService = new ToolBarService();
            _toolBarService.AddToolButton("增加分类", "", (Image)Resource.增加16, true, false, null);           
            _toolBarService.AddToolButton("删除分类", "", (Image)Resource.删除16, true, false, null);
            _toolBarService.AddToolSeparator();

            _toolBarService.AddToolButton("增加菜单", "", (Image)Resource.修改16, true, false, null);
            _toolBarService.AddToolButton("删除菜单", "", (Image)Resource.召回16, true, false, null);
            _toolBarService.AddToolSeparator();

            _toolBarService.AddToolButton("退出", "", (Image)Resource.退出16, true, false, null);
            this.MainToolStrip.Items.AddRange(_toolBarService.GetToolStripButtons());

            this.MainToolStrip.Items[0].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[1].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[3].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[4].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[6].TextImageRelation = TextImageRelation.ImageAboveText;
        }

        private void LoadMenu()
        {
            IPrivilegeService _proxy = Common.Util.CreateProxy();

            ///解决返回的IList只读问题
            _menus = new List<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem>();
            IList<Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem> _rtn;
            using (_proxy as IDisposable)
            {
                _rtn = _proxy.QueryMenu();
            }

            foreach (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu in _rtn)
            {
                _menus.Add(_menu);
            }

            AddRootNode();
        }

        private void AddRootNode()
        {
            tvMenu.Nodes.Clear();

            //生成根分类
            foreach (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu in _menus)
            {
                if (_menu.ParentId == "ROOT")//第一级为分类
                {
                    TreeNode _node = new TreeNode(_menu.Name);
                    _node.Tag = _menu;
                    _node.ImageIndex = 0;
                    _node.SelectedImageIndex = 0;
                    this.tvMenu.Nodes.Add(_node);

                    //AddSubMenuNode(_menu.ID, _node);
                }
            }
        }               

        void MainToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加分类":
                    AddType();
                    break;
                case "删除分类":
                    RemoveType();
                    break;
                case "增加菜单":
                    AddMenu();
                    break;
                case "删除菜单":
                    RemoveMenu();
                    break;
                case "退出":
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// 增加分类
        /// </summary>
        private void AddType()
        {
            Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = new Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem();
            _menu.ParentId = "ROOT";
            _menu.Type = "Menu";
            _menu.Enabled = true;
            _menu.Layer = "1";
            _menu.UserId = ((Facade.Context.Operator as NeuPrincipal).Identity as NeuIdentity).User.Id;
            _menu.OperDate = Common.Util.GetDateTime();
            _menu.Name = "新分类";

            //保存分类信息
            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _menu = _proxy.SaveMenuItem(_menu);
                }

                if (_menu == null) return;                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            TreeNode _node = new TreeNode(_menu.Name);
            _node.ImageIndex = 0;
            _node.SelectedImageIndex = 0;
            _node.Tag = _menu;
            this.tvMenu.Nodes.Add(_node);
            this.tvMenu.SelectedNode = _node;
            AddMenuToList(_menu);

            _node.BeginEdit();
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        private void RemoveType()
        {
            TreeNode _node = tvMenu.SelectedNode;
            //if (_node.Level > 0)
            //{
            //    MessageBox.Show("该项目不是分类,不能删除!", "提示");
            //    return;
            //}

            if (MessageBox.Show("是否要删除该分类?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            if (lvMenu.Items[0].Items.Count > 0)
            {
                DialogResult dlg = MessageBox.Show("删除该分类,将删除其包含的全部菜单项,是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.No) return;
            }

            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _proxy.RemoveMenuItem((_node.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem).Id);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            RemoveMenuFromList((_node.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem).Id);
            tvMenu.Nodes.Remove(_node);
        }

        private int RemoveMenuFromList(string menuID)
        {
            for (int i = 0; i < _menus.Count; i++)
            {
                Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = _menus[i];
                if (_menu.Id == menuID)
                {
                    _menus.Remove(_menu);
                    return i;
                }
            }

            return -1;
        }

        private void AddMenu()
        {
            if (lvMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择待增加菜单的父级菜单!", "提示");
                return;
            }

            TreeListViewItem _current = lvMenu.SelectedItems[0];
            
            ZZZZAddMenuForm _frmAdd = new ZZZZAddMenuForm(_current.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem);
            _frmAdd.ShowDialog();
            Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = _frmAdd.Current;
            if (_menu != null)
            {
                AddMenuToList(_menu);
                
                this.tvMenu_AfterSelect(null, null);
            }
        }

        private void ModifyMenu()
        {
            if (lvMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择待修改菜单!", "提示");
                return;
            }

            TreeListViewItem _current = lvMenu.SelectedItems[0];

            ///分类不能修改
            if (_current.Level == 0) return;

            ZZZZAddMenuForm _frmAdd = new ZZZZAddMenuForm((_current.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem),
                                                _current.Parent.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem);
            _frmAdd.ShowDialog();

            Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = _frmAdd.Current;
            if (_menu != null)
            {
                AddMenuToList(_menu);
                
                this.tvMenu_AfterSelect(null, null);
            }
        }        

        private void RemoveMenu()
        {
            if (lvMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择待删除菜单!", "提示");
                return;
            }

            TreeListViewItem _current = lvMenu.SelectedItems[0];
            if (_current.Level == 0) return;            

            if (MessageBox.Show("是否要删除该菜单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            if (_current.Items.Count > 0)
            {
                DialogResult dlg = MessageBox.Show("删除该菜单,将删除其包含的全部菜单项,是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.No) return;
            }

            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _proxy.RemoveMenuItem((_current.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem).Id);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            RemoveMenuFromList((_current.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem).Id);
            _current.Parent.Items.Remove(_current);
        }

        private void AddMenuToList(Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem menu)
        {
            //删除先
            int i = RemoveMenuFromList(menu.Id);

            if (i >= 0)
            {
                _menus.Insert(i, menu);
            }
            else
            {
                _menus.Add(menu);
            }
        }
        /// <summary>
        /// 显示相应的子菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode _node = this.tvMenu.SelectedNode;
            if (_node == null) return;

            //显示项下面菜单
            DisplayMenuItem(_node.Tag as Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem);
        }

        private void DisplayMenuItem(Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem parent)
        {
            //清除先
            this.lvMenu.Items.Clear();
            TreeListViewItem _root = new TreeListViewItem(parent.Name + "包含的菜单项", 0);
            _root.Tag = parent;
            _root.Expand();
            this.lvMenu.Items.Add(_root);

            AddSubMenuItem(parent, _root);
        }

        private void AddSubMenuItem(Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem parent, TreeListViewItem parentItem)
        {
            foreach (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu in _menus)
            {
                if (_menu.ParentId == parent.Id)
                {
                    TreeListViewItem _lvItem = new TreeListViewItem(_menu.Name, 1);
                    _lvItem.SubItems.AddRange(new string[] { 
                            _menu.Shortcut,_menu.DllName,_menu.WinName,_menu.ControlType,_menu.ShowType,
                            _menu.Param,(_menu.Enabled?"是":"否")});

                    _lvItem.Tag = _menu;
                    parentItem.Items.Add(_lvItem);

                    AddSubMenuItem(_menu, _lvItem);
                }
            }
        }

        void tvMenu_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //保存编辑信息            
            Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem)e.Node.Tag;

            if (e.Label == null || e.Label.Trim() == "")
            {
                e.CancelEdit = true;
                return;
            }

            if (!Neusoft.Framework.Util.StringHelper.ValidMaxLengh(e.Label, 60))
            {
                e.CancelEdit = true;
                MessageBox.Show("分类的名称不能超过30个汉字!", "提示");
                e.Node.BeginEdit();
                return;
            }

            _menu.Name = e.Label;
            //保存分类信息
            try
            {
                IPrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _menu = _proxy.SaveMenuItem(_menu);
                }

                if (_menu == null) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            AddMenuToList(_menu);
        }

        void tvMenu_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode _node = tvMenu.SelectedNode;
            if (_node == null) return;

            //不是分类,不许编辑
            if (_node.Level > 0) e.CancelEdit = true;
        }

        void tvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvMenu.SelectedNode = e.Node;

                if (e.Node.Level == 0)//分类
                {  
                    RemoveMenuItem.Visible = false;
                    ModifyMenuItem.Visible = false;
                    AddMenuItem.Visible = false;
                    UpItem.Visible = false;
                    DownItem.Visible = false;
                    toolStripMenuItem3.Visible = false;

                    RemoveTypeItem.Visible = true;
                    AddTypeItem.Visible = true;
                    tvMenu.ContextMenuStrip = NContextMenu;
                }
                //else//菜单
                //{
                //    RemoveTypeItem.Enabled = false;

                //    ModifyMenuItem.Enabled = true;
                //    RemoveMenuItem.Enabled = true;
                //    tvMenu.ContextMenuStrip = NContextMenu;
                //}
            }
        }

        void tvMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ModifyMenu();
            //e.Node.
        }

        void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            ModifyMenu();
        }

        void lvMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvMenu.SelectedItems.Count == 0) return;

                if (lvMenu.SelectedItems[0].Level > 0)
                {
                    RemoveMenuItem.Visible = true;
                    ModifyMenuItem.Visible = true;
                    AddMenuItem.Visible = true;
                    UpItem.Visible = true;
                    DownItem.Visible = true;
                    toolStripMenuItem3.Visible = true;

                    RemoveTypeItem.Visible = false;
                    AddTypeItem.Visible = false;
                    lvMenu.ContextMenuStrip = NContextMenu;
                }
                else
                {
                    RemoveMenuItem.Visible = false;
                    ModifyMenuItem.Visible = false;
                    AddMenuItem.Visible = true;
                    UpItem.Visible = false;
                    DownItem.Visible = false;
                    toolStripMenuItem3.Visible = false;

                    RemoveTypeItem.Visible = false;
                    AddTypeItem.Visible = false;
                    lvMenu.ContextMenuStrip = NContextMenu;
                }
            }
        }       

        void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            RemoveMenu();
        }

        void AddMenuItem_Click(object sender, EventArgs e)
        {
            AddMenu();
        }

        void RemoveTypeItem_Click(object sender, EventArgs e)
        {
            RemoveType();
        }

        void AddTypeItem_Click(object sender, EventArgs e)
        {
            AddType();
        }

        void DownItem_Click(object sender, EventArgs e)
        {
            if (lvMenu.SelectedItems.Count == 0) return;
            TreeListViewItem _current = lvMenu.SelectedItems[0];
            TreeListViewItem _next = GetNextItem(_current);
            if (_next == null) return;

            IPrivilegeService _proxy = Common.Util.CreateProxy();
            try
            {
                Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem)_current.Tag;
                Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _nextMenu = (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem)_next.Tag;

                int _order = _menu.Order;
                _menu.Order = _nextMenu.Order;
                _nextMenu.Order = _order;

                //using (TransactionScope _scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    using (_proxy as IDisposable)
                    {
                        _menu = _proxy.SaveMenuItem(_menu);
                        _nextMenu = _proxy.SaveMenuItem(_nextMenu);
                    }
                }

                int _index = GetMenuIndex(_menu);
                RemoveMenuFromList(_nextMenu.Id);
                _menus.Insert(_index, _nextMenu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return;
            }

            tvMenu_AfterSelect(null, null);
        }

        private TreeListViewItem GetNextItem(TreeListViewItem item)
        {
            TreeListViewItem _next = item.NextVisibleItem;

            while (_next != null && _next.Level != item.Level)
            {
                _next = _next.NextVisibleItem;
            }

            return _next;
        }

        private TreeListViewItem GetPrevItem(TreeListViewItem item)
        {
            TreeListViewItem _prev = item.PrevVisibleItem;

            while (_prev != null && _prev.Level != item.Level)
            {
                _prev = _prev.PrevVisibleItem;
            }

            return _prev;
        }

        private int GetMenuIndex(Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem menu)
        {
            for (int i = 0; i < _menus.Count; i++)
            {
                Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = _menus[i];
                if (_menu.Id == menu.Id)
                {                    
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpItem_Click(object sender, EventArgs e)
        {
            if (lvMenu.SelectedItems.Count == 0) return;
            TreeListViewItem _current = lvMenu.SelectedItems[0];
            TreeListViewItem _prev = GetPrevItem(_current);
            if (_prev == null) return;            

            IPrivilegeService _proxy = Common.Util.CreateProxy();
            try
            {
                Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _menu = (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem)_current.Tag;
                Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem _nextMenu = (Neusoft.Privilege.ServiceContracts.Model.Impl.MenuItem)_prev.Tag;

                int _order = _menu.Order;
                _menu.Order = _nextMenu.Order;
                _nextMenu.Order = _order;

                using (_proxy as IDisposable)
                {
                    _menu = _proxy.SaveMenuItem(_menu);
                    _nextMenu = _proxy.SaveMenuItem(_nextMenu);
                }

                int _index = GetMenuIndex(_nextMenu);
                RemoveMenuFromList(_menu.Id);
                _menus.Insert(_index, _menu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return;
            }

            tvMenu_AfterSelect(null, null);
        }

        void ModifyMenuItem_Click(object sender, EventArgs e)
        {
            ModifyMenu();
        }
    }
}

