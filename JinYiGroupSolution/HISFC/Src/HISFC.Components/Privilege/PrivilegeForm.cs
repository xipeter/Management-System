using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


//using Neusoft.WinForms.Forms;

using Neusoft.NFC.Interface.Controls;
using Neusoft.UFC.Privilege.Forms;
using Neusoft.Privilege.BizLogic.Model;
using Neusoft.Privilege.BizLogic.Service;
//using Neusoft.WinForms;
//using Neusoft.WinForms.Controls;

namespace Neusoft.UFC.Privilege
{
    public partial class PrivilegeForm : Neusoft.UFC.Privilege.Forms.PermissionBaseForm
    {
        IList<ResourceType> _resTypes = null;
        Dictionary<string, NeuTreeListView> _resTreeListMap = new Dictionary<string, NeuTreeListView>();
        Dictionary<string, NFC.Interface.Controls.NeuGroupBox> _resGroupBoxMap = new Dictionary<string, NFC.Interface.Controls.NeuGroupBox>();
        //要级联删除的角色
        List<Role> deleteRoleList = new List<Role>();
        //要级联删除的资源
        List<Neusoft.Privilege.BizLogic.Model.Priv> deleteResList = new List<Priv>();

        public PrivilegeForm()
        {
            InitializeComponent();

            this.Init();
        }

        private void Init()
        {
            this.InitToolBar();


            //载入资源类别树
            this.LoadResourceType();
            this.LoadRole();

            this.nTabControl1.Selected += new TabControlEventHandler(nTabControl1_Selected);
            this.tvRole.AfterSelect += new TreeViewEventHandler(tvRole_AfterSelect);
            this.MainToolStrip.ItemClicked += new ToolStripItemClickedEventHandler(MainToolStrip_ItemClicked);

            this.AddResourceItem.Click += new EventHandler(AddResourceItem_Click);
            this.DelResourceItem.Click += new EventHandler(DelResourceItem_Click);
            this.ModifyResourceItem.Click += new EventHandler(ModifyResourceItem_Click);
        }

        #region ContextMenu操作
        void ModifyResourceItem_Click(object sender, EventArgs e)
        {
            ModifyResource();
        }

        void DelResourceItem_Click(object sender, EventArgs e)
        {
            RemoveResource();
        }

        void AddResourceItem_Click(object sender, EventArgs e)
        {
            AddResource();
        }
        #endregion

        #region 工具栏操作
        void MainToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "退出":
                    this.Close();
                    break;
                case "增加资源":
                    AddResource();
                    break;
                case "删除资源":
                    RemoveResource();
                    break;
                case "查找资源":
                    break;
                case "保存权限":
                    SavePermission();
                    break;
            }
        }

        void AddResource()
        {
            if (IsJudgeOperationForOne(nTabControl1.SelectedTab.Name))
            {
                if (tvRole.SelectedNode != null)
                {
                    if ((tvRole.SelectedNode.Tag as Role).Id != "roleadmin" && (tvRole.SelectedNode.Tag as Role).ParentId != "roleadmin")
                    {
                        MessageBox.Show("请在当前角色的跟结点上添加资源!", "提示");
                        return;
                    }
                }
            }

            SelectedTreeListViewItemCollection _collect = _resTreeListMap[nTabControl1.SelectedTab.Name].SelectedItems;
            if (_collect == null || _collect.Count == 0)
            {
                MessageBox.Show("请先选择要添加资源的父级资源!", "提示");
                return;
            }

            AddPrivilegeForm _add = new AddPrivilegeForm(_collect[0].Tag as Priv);
            _add.ShowDialog();

            Neusoft.Privilege.BizLogic.Model.Priv _res = _add.Current;
            if (_add.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (_res != null)
                {
                    TreeListViewItem _item = GetTreeListViewItem((Priv)_res);
                    _collect[0].Items.Add(_item);
                }
                else
                {
                    MessageBox.Show("权限已经存在！");
                    return;
                }
            }
            _add.Dispose();
        }

        void RemoveResource()
        {
            if (IsJudgeOperationForOne(nTabControl1.SelectedTab.Name))
            {
                if (tvRole.SelectedNode != null)
                {
                    if ((tvRole.SelectedNode.Tag as Role).Id != "roleadmin" && (tvRole.SelectedNode.Tag as Role).ParentId != "roleadmin")
                    {
                        MessageBox.Show("请在当前角色的根结点上删除资源!", "提示");
                        return;
                    }
                }
            }

            if (nTabControl1.SelectedTab == null) return;
            TreeListView _current = _resTreeListMap[nTabControl1.SelectedTab.Name];
            if (_current.SelectedItems.Count <= 0 || _current.SelectedItems[0].Level == 0) return;
            TreeListViewItem _item = _current.SelectedItems[0];

            //不可以删除父级节点
            if (_current.SelectedItems[0].Items.Count > 0)
            {
                MessageBox.Show("请先删除子节点！");
                return;
            }

            if (MessageBox.Show("是否要删除:'" + (_item.Tag as Priv).Name + "'资源?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    try
                    {
                        NFC.Management.PublicTrans.BeginTransaction();
                        if (IsJudgeOperationForOne(nTabControl1.SelectedTab.Name))
                        {
                            int rtn = _proxy.RemoveResource(_item.Tag as Priv);

                        }
                        else
                        {
                            int rtn = _proxy.RemoveResource((_item.Tag as Priv).Id);
                        }
                        NFC.Management.PublicTrans.Commit();
                    }
                    catch (Exception e)
                    {
                        NFC.Management.PublicTrans.RollBack();
                        throw e;
                    }
                    //没找到记录
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            if (_item.Level == 0)
            {
                _current.Items.Remove(_item);
            }
            else
            {
                _item.Parent.Items.Remove(_item);
            }

            MessageBox.Show("删除成功!", "提示");
        }

        void ModifyResource()
        {
            SelectedTreeListViewItemCollection _collect = _resTreeListMap[nTabControl1.SelectedTab.Name].SelectedItems;
            if (_collect == null || _collect.Count == 0 || _collect[0].Level == 0)
            {
                MessageBox.Show("请选择要待修改资源!", "提示");
                return;
            }

            AddPrivilegeForm _modify = new AddPrivilegeForm(_collect[0].Parent.Tag as Priv, _collect[0].Tag as Priv);
            _modify.ShowDialog();

            Neusoft.Privilege.BizLogic.Model.Priv _res = _modify.Current;
            if (_res != null && _collect != null)
            {
                _collect[0].SubItems[0].Text = _res.Name;
                _collect[0].SubItems[1].Text = _res.Id;
                _collect[0].SubItems[2].Text = _res.Description;
                _collect[0].Tag = _res;
            }

            _modify.Dispose();

        }

        void SavePermission()
        {
            TreeNode _node = tvRole.SelectedNode;
            if (_node == null || _node.Tag == null)
            {
                MessageBox.Show("请选择待授权角色!", "提示");
                return;
            }
            NeuTreeListView _list = _resTreeListMap[nTabControl1.SelectedTab.Name];

            TreeListViewItem _item = null;
            string _permissionExp = "";

            if (_resTreeListMap[nTabControl1.SelectedTab.Name].CheckBoxes != CheckBoxesTypes.Simple)
            {


                if (_list == null || _list.SelectedItems.Count == 0 || ((_list.SelectedItems[0].Tag as Priv).Id == "root"))
                {
                    MessageBox.Show("请选择待授权资源!", "提示");
                    return;
                }
                _item = _list.SelectedItems[0];

                _permissionExp = GetSelectedPermission();
                if (string.IsNullOrEmpty(_permissionExp))
                {
                    MessageBox.Show("请选择操作权限!", "提示");
                    return;
                }

            }

            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                //全部的Res
                List<Neusoft.Privilege.BizLogic.Model.Priv> allRes = new List<Priv>();
                //选中的Res
                List<Neusoft.Privilege.BizLogic.Model.Priv> res = new List<Priv>();

                NFC.Management.PublicTrans.BeginTransaction();
                    if (_resTreeListMap[nTabControl1.SelectedTab.Name].CheckBoxes == CheckBoxesTypes.Simple)
                    {
                        foreach (TreeListViewItem item in _resTreeListMap[nTabControl1.SelectedTab.Name].CheckedItems)
                        {
                            if ((item.Tag as Priv).Id != "root")
                            {
                                res.Add(item.Tag as Priv);
                            }
                        }

                        foreach (TreeListViewItem item in _resTreeListMap[nTabControl1.SelectedTab.Name].Items)
                        {
                            allRes.Add(item.Tag as Priv);

                            SetAllRes(allRes, item.Items);
                        }

                        GetAllChildRole(tvRole.SelectedNode.Nodes);
                        GetDeleteRes(res);

                        //当角色为系统管理员时，不考虑级联删除
                        if ((_node.Tag as Role).Id == "roleadmin")
                        {
                            deleteResList = new List<Priv>();
                            deleteRoleList = new List<Role>();
                        }

                        int rtn = _proxy.SavePermission((_node.Tag as Role), allRes, res, _permissionExp, deleteResList, deleteRoleList);

                        NFC.Management.PublicTrans.Commit();
                        if (rtn == 0)
                        {
                            NFC.Management.PublicTrans.RollBack();
                            MessageBox.Show("保存失败！");
                            return;
                        }
                    }
                    else
                    {
                       
                            int rtn = _proxy.SavePermission(nTabControl1.SelectedTab.Name, (_node.Tag as Role), (_item.Tag as Priv), _permissionExp);
                            NFC.Management.PublicTrans.Commit();
                            if (rtn == 0)
                            {

                                NFC.Management.PublicTrans.RollBack();
                                MessageBox.Show("保存失败！");
                                return;
                            }
                        //父级处理,太麻烦...有需求再说吧
                    }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            MessageBox.Show("保存成功!", "提示");
        }

        private string GetSelectedPermission()
        {
            string pmsExp = "";

            foreach (Control _c in _resGroupBoxMap[nTabControl1.SelectedTab.Name].Controls)
            {
                if (_c.GetType() == typeof(NeuCheckBox))
                {
                    if ((_c as NeuCheckBox).Checked)
                        pmsExp = pmsExp + _c.Name + "|";
                }
                else if (_c.GetType() == typeof(NeuRadioButton))
                {
                    if ((_c as NeuRadioButton).Checked)
                        pmsExp = pmsExp + _c.Name + "|";
                }
            }

            return pmsExp;
        }

        #endregion

        void tvRole_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_resTreeListMap[nTabControl1.SelectedTab.Name].CheckBoxes == CheckBoxesTypes.Simple)
            {
                _resTreeListMap[nTabControl1.SelectedTab.Name].ItemChecked -= _treeList_ItemChecked;
                SelectOperationForOne();
                _resTreeListMap[nTabControl1.SelectedTab.Name].ItemChecked += _treeList_ItemChecked;
            }
            else
            {
                SelectOperation();
            }
        }

        void ResourceItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_resTreeListMap[nTabControl1.SelectedTab.Name].CheckBoxes == CheckBoxesTypes.Simple)
            {
                return;
            }
            else
            {
                SelectOperation();
            }
        }

        private void SelectOperation()
        {
            ClearSelectedOptions();

            TreeNode _node = tvRole.SelectedNode;
            if (_node == null || _node.Tag == null) return;

            NeuTreeListView _list = _resTreeListMap[nTabControl1.SelectedTab.Name];
            if (_list == null || _list.SelectedItems.Count == 0) return;
            TreeListViewItem _item = _list.SelectedItems[0];
            if ((_item.Tag as Priv).Id == "root") return;

            IDictionary<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> _permissions = null;
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();

                using (_proxy as IDisposable)
                {
                    _permissions = _proxy.GetPermission(nTabControl1.SelectedTab.Name, (_item.Tag as Priv).Id, (_node.Tag as Role));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            if (_permissions == null || _permissions.Count == 0) return;

            foreach (KeyValuePair<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> _pair in _permissions)
            {
                foreach (Neusoft.Privilege.BizLogic.Model.Operation _opera in _pair.Value)
                {
                    Control _c = _resGroupBoxMap[nTabControl1.SelectedTab.Name].Controls[_opera.Id];

                    if (_c != null && _c.GetType() == typeof(NeuCheckBox))
                    {
                        (_c as NeuCheckBox).Checked = true;
                    }
                    else if (_c != null && _c.GetType() == typeof(NeuRadioButton))
                    {
                        (_c as NeuRadioButton).Checked = true;
                    }
                }
                break;
            }
        }

        private void ClearSelectedOptions()
        {
            foreach (Control _c in _resGroupBoxMap[nTabControl1.SelectedTab.Name].Controls)
            {
                if (_c.GetType() == typeof(NeuCheckBox))
                {
                    if ((_c as NeuCheckBox).Checked) (_c as NeuCheckBox).Checked = false;
                }
                else if (_c.GetType() == typeof(NeuRadioButton))
                {
                    if ((_c as NeuRadioButton).Checked) (_c as NeuRadioButton).Checked = false;
                }
            }
        }

        void nTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (this.nTabControl1.SelectedTab.Tag == null)
            {
                GetResource();
            }

            this.nTabControl1.SelectedTab.Tag = "OK";

            if (_resTreeListMap[nTabControl1.SelectedTab.Name].CheckBoxes == CheckBoxesTypes.Simple)
            {
                SelectOperationForOne();
            }
            else
            {
                SelectOperation();
            }
        }

        private void InitToolBar()
        {
            ToolBarService _toolBarService = new ToolBarService();
            _toolBarService.AddToolButton("增加资源", "", NFC.Interface.Classes.Function.GetImage(Neusoft.NFC.Interface.Classes.EnumImageList.A添加), true, false, null);
            _toolBarService.AddToolButton("删除资源", "", NFC.Interface.Classes.Function.GetImage(Neusoft.NFC.Interface.Classes.EnumImageList.A添加), true, false, null);
            _toolBarService.AddToolButton("查找资源", "", NFC.Interface.Classes.Function.GetImage(Neusoft.NFC.Interface.Classes.EnumImageList.A添加), true, false, null);
            _toolBarService.AddToolSeparator();
            _toolBarService.AddToolButton("保存权限", "", NFC.Interface.Classes.Function.GetImage(Neusoft.NFC.Interface.Classes.EnumImageList.A添加), true, false, null);
            _toolBarService.AddToolSeparator();
            _toolBarService.AddToolButton("退出", "", NFC.Interface.Classes.Function.GetImage(Neusoft.NFC.Interface.Classes.EnumImageList.A添加), true, false, null);

            this.MainToolStrip.Items.AddRange(_toolBarService.GetToolStripButtons());
            this.MainToolStrip.Items[0].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[1].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[2].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[4].TextImageRelation = TextImageRelation.ImageAboveText;
            this.MainToolStrip.Items[6].TextImageRelation = TextImageRelation.ImageAboveText;
        }

        private void LoadResourceType()
        {
            IList<Neusoft.Privilege.BizLogic.Model.Operation> _operations = null;
            PrivilegeService _proxy = Common.Util.CreateProxy();

            try
            {
                using (_proxy as IDisposable)
                {
                    _resTypes = _proxy.GetResourceTypes();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            this.nTabControl1.TabPages.Clear();
            foreach (ResourceType _resType in _resTypes)
            {
                if (IsJudgeOperationForOne(_resType.Id))
                {
                    BuildTabPageForOne(_resType);
                }
                else
                {
                    BuildTabPage(_resType);
                }
            }

            if (this.nTabControl1.TabPages.Count > 0)
                this.nTabControl1_Selected(null, null);

        }

        private void BuildTabPage(ResourceType _resType)
        {
            TabPage _page = new TabPage();
            NeuPanel _panel = new NeuPanel();
            NeuSplitter _splitter = new NeuSplitter();
            NeuPanel _panel1 = new NeuPanel();
            NeuGroupBox _groupBox = new NeuGroupBox();

            _page.Controls.Add(_panel1);
            _page.Controls.Add(_splitter);
            _page.Controls.Add(_panel);

            _page.Name = _resType.Id;
            _page.Text = _resType.Name;
            _page.UseVisualStyleBackColor = true;
            _page.ImageIndex = 8;

            _panel.Dock = DockStyle.Bottom;
            _panel.Height = 100;
            _panel.Controls.Add(_groupBox);

            _groupBox.Text = "选择权限";
            _groupBox.Dock = DockStyle.Fill;
            _resGroupBoxMap.Add(_resType.Id, _groupBox);
            _panel.Controls.Add(_groupBox);

            _splitter.Cursor = Cursors.HSplit;
            _splitter.Dock = DockStyle.Bottom;

            _panel1.Dock = DockStyle.Fill;
            NeuTreeListView _treeList = GenTreeListView();
            _treeList.SmallImageList = this.imageList1;

            _resTreeListMap.Add(_resType.Id, _treeList);
            _panel1.Controls.Add(_treeList);
            CreateSelectOptions(_resType.Id, _groupBox);

            this.nTabControl1.TabPages.Add(_page);

        }

        private FarPoint.Win.Spread.FpSpread GenFpSpread(Control parent)
        {
            FarPoint.Win.Spread.FpSpread _spread = new FarPoint.Win.Spread.FpSpread();
            FarPoint.Win.Spread.SheetView _sheet = new FarPoint.Win.Spread.SheetView();

            //_spread.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            _spread.BackColor = System.Drawing.SystemColors.Control;
            _spread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            _spread.Location = new System.Drawing.Point(0, 2);
            _spread.RightToLeft = System.Windows.Forms.RightToLeft.No;
            _spread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] { _sheet });
            _spread.Dock = DockStyle.Fill;

            FarPoint.Win.Spread.TipAppearance _tipAppearance = new FarPoint.Win.Spread.TipAppearance();
            _tipAppearance.BackColor = System.Drawing.SystemColors.Info;
            _tipAppearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            _tipAppearance.ForeColor = System.Drawing.SystemColors.InfoText;
            _spread.TextTipAppearance = _tipAppearance;
            _spread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            _sheet.Reset();
            _sheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            _sheet.ColumnCount = 3;
            _sheet.RowCount = 2;
            _sheet.ColumnHeader.Cells.Get(0, 0).Value = "资源代码";
            _sheet.ColumnHeader.Cells.Get(0, 1).Value = "资源名称";
            _sheet.ColumnHeader.Cells.Get(0, 2).Value = "备注";
            _sheet.Columns.Get(0).Label = "资源代码";
            _sheet.Columns.Get(0).Width = 127F;
            _sheet.Columns.Get(1).Label = "资源名称";
            _sheet.Columns.Get(1).Width = 203F;
            _sheet.Columns.Get(2).Label = "备注";
            _sheet.Columns.Get(2).Width = 212F;
            _sheet.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            _sheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            _sheet.RowHeader.Columns.Default.Resizable = false;
            _sheet.RowHeader.Visible = false;
            _sheet.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            _sheet.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            _sheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;

            return _spread;
        }

        private NeuTreeListView GenTreeListView()
        {
            NeuTreeListView _treeList = new NeuTreeListView();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            ColumnHeader columnHeader1 = new ColumnHeader();
            ColumnHeader columnHeader2 = new ColumnHeader();
            ColumnHeader columnHeader3 = new ColumnHeader();

            _treeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader2, columnHeader1, columnHeader3 });
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            _treeList.Comparer = treeListViewItemCollectionComparer1;
            _treeList.Location = new System.Drawing.Point(-19, 47);
            _treeList.UseCompatibleStateImageBehavior = false;
            _treeList.MultiSelect = false;
            _treeList.HideSelection = false;
            _treeList.SelectedIndexChanged += new EventHandler(ResourceItem_SelectedIndexChanged);

            _treeList.ContextMenuStrip = this.nContextMenuStrip1;
            _treeList.Dock = DockStyle.Fill;

            columnHeader1.Text = "权限代码";
            columnHeader1.Width = 200;

            columnHeader2.Text = "权限名称";
            columnHeader2.Width = 250;

            columnHeader3.Text = "备注";
            columnHeader3.Width = 250;

            return _treeList;
        }

        private void CreateSelectOptions(string resTypeId, NFC.Interface.Controls.NeuGroupBox parent)
        {
            PrivilegeService _proxy = Common.Util.CreateProxy();
            IList<Neusoft.Privilege.BizLogic.Model.Operation> _operations = null;

            try
            {
                using (_proxy as IDisposable)
                {
                    _operations = _proxy.GetOperation(resTypeId);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            int _row = 1, _col = 1;
            ResourceType _resType = getResType(resTypeId);
            foreach (Neusoft.Privilege.BizLogic.Model.Operation _operation in _operations)
            {
                if (_col >= 4)
                {
                    _row++;
                    _col = 1;
                }
                parent.Controls.Add(CreateOption(_operation, _resType.Exclusive, _row, _col));

                _col++;
            }
        }

        private ResourceType getResType(string resTypeId)
        {
            foreach (ResourceType _resType in _resTypes)
            {
                if (_resType.Id == resTypeId) return _resType;
            }

            return null;
        }

        private Control CreateOption(Neusoft.Privilege.BizLogic.Model.Operation operation,
            bool exclusive, int row, int col)
        {
            if (exclusive)
            {
                NeuRadioButton _radio = new NeuRadioButton();
                _radio.Tag = operation;
                _radio.Text = operation.Name;
                _radio.Name = operation.Id;
                _radio.Location = new Point((col - 1) * 130 + 20, row * 22);

                return _radio;
            }
            else
            {
                NeuCheckBox _check = new NeuCheckBox();
                _check.Tag = operation;
                _check.Text = operation.Name;
                _check.Name = operation.Id;
                _check.Location = new Point((col - 1) * 130 + 20, row * 22);

                return _check;
            }
        }

        private void LoadRole()
        {
            IList<Role> _roles = null;

            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();

                using (_proxy as IDisposable)
                {
                    _roles = _proxy.QueryRole();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            TreeNode _root = new TreeNode("角色列表", 0, 0);
            this.tvRole.Nodes.Add(_root);

            this.AddRoleNode(_root, "ROOT", _roles);
            _root.Expand();
        }

        private void AddRoleNode(TreeNode parent, string parentId, IList<Role> roles)
        {
            if (roles != null)
            {
                foreach (Role _item in roles)
                {
                    if (_item.ParentId == parentId)
                    {
                        TreeNode _node = new TreeNode(_item.Name, 1, 1);
                        _node.Tag = _item;
                        parent.Nodes.Add(_node);

                        AddRoleNode(_node, _item.Id, roles);
                    }
                }
            }
        }

        private void GetResource()
        {
            _resTreeListMap[nTabControl1.SelectedTab.Name].Items.Clear();
            string _resTypeId = this.nTabControl1.SelectedTab.Name;
            IList<Priv> _resources = null;
            PrivilegeService _proxy = Common.Util.CreateProxy();

            try
            {
                using (_proxy as IDisposable)
                {
                    _resources = _proxy.GetResource(_resTypeId);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }
            TreeListViewItem _root = new TreeListViewItem(nTabControl1.SelectedTab.Text + "包含的资源", 9);
            Neusoft.Privilege.BizLogic.Model.Resource _res = new Neusoft.Privilege.BizLogic.Model.Resource();
            _res.Id = "root";
            _res.Name = nTabControl1.SelectedTab.Text;
            _res.Type = nTabControl1.SelectedTab.Name;
            _root.Tag = _res;
            _resTreeListMap[nTabControl1.SelectedTab.Name].Items.Add(_root);

            //判断单一节点情况，并且要分级授权
            IDictionary<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> _permissionsParent = null;
            IList<Priv> resources = new List<Priv>();
            if (IsJudgeOperationForOne(_resTypeId))
            {

                if (tvRole.SelectedNode != null && tvRole.SelectedNode.Tag != null)
                {
                    if ((tvRole.SelectedNode.Tag as Role).Id == "roleadmin" || (tvRole.SelectedNode.Tag as Role).ParentId == "roleadmin")
                    {
                        addResource(_root, _resources);
                    }
                    else
                    {
                        try
                        {
                            using (_proxy as IDisposable)
                            {
                                _permissionsParent = _proxy.GetPermission(nTabControl1.SelectedTab.Name, (tvRole.SelectedNode.Parent.Tag as Role));
                            }

                            foreach (KeyValuePair<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> pair in _permissionsParent)
                            {
                                resources.Add(pair.Key);
                            }

                            addResource(_root, resources);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "提示");
                            return;
                        }

                    }
                }
            }
            else
            {
                addResource(_root, _resources);
            }

            _root.ExpandAll();
        }

        private void addResource(TreeListViewItem parent, IList<Priv> resources)
        {
            foreach (Priv _res in resources)
            {
                if (_res.ParentId == (parent.Tag as Priv).Id)
                {
                    TreeListViewItem _child = GetTreeListViewItem(_res);
                    parent.Items.Add(_child);

                    addResource(_child, resources);
                }
            }
        }

        private TreeListViewItem GetTreeListViewItem(Priv _res)
        {
            TreeListViewItem _child = new TreeListViewItem(_res.Name, 5);
            _child.SubItems.AddRange(new string[] { _res.Id, _res.Description });
            _child.Tag = _res;
            return _child;
        }


        //zhangkaijun
        private void BuildTabPageForOne(ResourceType _resType)
        {
            TabPage _page = new TabPage();
            NeuSplitter _splitter = new NeuSplitter();
            NeuPanel _panel1 = new NeuPanel();

            _page.Controls.Add(_panel1);
            _page.Controls.Add(_splitter);

            _page.Name = _resType.Id;
            _page.Text = _resType.Name;
            _page.UseVisualStyleBackColor = true;
            _page.ImageIndex = 8;

            _splitter.Cursor = Cursors.HSplit;
            _splitter.Dock = DockStyle.Bottom;

            _panel1.Dock = DockStyle.Fill;
            NeuTreeListView _treeList = GenTreeListView();
            _treeList.SmallImageList = this.imageList1;
            _treeList.CheckBoxes = CheckBoxesTypes.Simple;
            _treeList.ItemChecked += new ItemCheckedEventHandler(_treeList_ItemChecked);

            _resTreeListMap.Add(_resType.Id, _treeList);
            _panel1.Controls.Add(_treeList);

            this.nTabControl1.TabPages.Add(_page);
        }

        void _treeList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            _resTreeListMap[nTabControl1.SelectedTab.Name].ItemChecked -= _treeList_ItemChecked;
            NodeChecked(e.Item as TreeListViewItem);
            _resTreeListMap[nTabControl1.SelectedTab.Name].ItemChecked += _treeList_ItemChecked;
        }

        private void SelectOperationForOne()
        {
            GetResource();
            TreeNode _node = tvRole.SelectedNode;
            if (_node == null || _node.Tag == null) return;

            IDictionary<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> _permissions = null;
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();

                using (_proxy as IDisposable)
                {
                    _permissions = _proxy.GetPermission(nTabControl1.SelectedTab.Name, (_node.Tag as Role));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                return;
            }

            InitCheckBox(_resTreeListMap[nTabControl1.SelectedTab.Name].Items);

            if (_permissions == null || _permissions.Count == 0) return;

            foreach (Priv res in _permissions.Keys)
            {
                SetCheckBox(_resTreeListMap[nTabControl1.SelectedTab.Name].Items, res);
            }

        }

        private void SetCheckBox(TreeListViewItemCollection currentItemList, Priv res)
        {
            foreach (TreeListViewItem currentItem in currentItemList)
            {
                if ((currentItem.Tag as Priv).Id == res.Id)
                {
                    currentItem.Checked = true;
                }
                if (currentItem != null)
                {
                    SetCheckBox(currentItem.Items, res);
                }
            }
        }

        private void InitCheckBox(TreeListViewItemCollection currentItemList)
        {
            foreach (TreeListViewItem currentItem in currentItemList)
            {
                if (currentItem != null)
                {
                    currentItem.Checked = false;
                    InitCheckBox(currentItem.Items);
                }
            }
        }

        private void SetAllRes(List<Neusoft.Privilege.BizLogic.Model.Priv> allRes, TreeListViewItemCollection itemsList)
        {
            foreach (TreeListViewItem item in itemsList)
            {
                allRes.Add(item.Tag as Priv);

                SetAllRes(allRes, item.Items);
            }
        }

        private bool IsJudgeOperationForOne(string resTypeId)
        {
            IList<Neusoft.Privilege.BizLogic.Model.Operation> _operations = null;
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    _operations = _proxy.GetOperation(resTypeId);
                }
                if (_operations.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        private void NodeChecked(TreeListViewItem currentItem)
        {
            TreeListViewItem parentItem = currentItem.Parent;

            if ((currentItem.Tag as Priv) != null)
            {
                if (currentItem.Checked == true)
                {
                    SetChildNode(true, currentItem.Items);
                    SetParentNode(true, currentItem);

                }
                if (currentItem.Checked == false)
                {
                    SetChildNode(false, currentItem.Items);
                    SetParentNode(false, currentItem);
                }
            }
        }

        private void SetChildNode(Boolean Judge, TreeListViewItemCollection ChildNodes)
        {
            if (ChildNodes == null) return;
            foreach (TreeListViewItem item in ChildNodes)
            {
                item.Checked = Judge;
                SetChildNode(Judge, item.Items);
            }
        }

        private void SetParentNode(Boolean Judge, TreeListViewItem currentNode)
        {
            if (currentNode.Parent == null) return;
            if (Judge == false)
            {
                if (currentNode.Parent != null && JudgeSameLevel(currentNode.Parent))
                {
                    currentNode.Parent.Checked = Judge;
                }
            }
            else
            {
                currentNode.Parent.Checked = Judge;
            }

            SetParentNode(Judge, currentNode.Parent);

        }

        private bool JudgeSameLevel(TreeListViewItem parentNode)
        {
            int count = 0;
            foreach (TreeListViewItem roleNode in parentNode.Items)
            {
                if (roleNode.Checked == true)
                {
                    count++;
                }
            }

            if (count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GetAllChildRole(TreeNodeCollection currentNodes)
        {
            if (currentNodes == null) return;
            foreach (TreeNode newNode in currentNodes)
            {
                deleteRoleList.Add(newNode.Tag as Role);
                GetAllChildRole(newNode.Nodes);
            }
        }

        private void GetDeleteRes(List<Priv> res)
        {
            //当前Role查找数据库中的权限
            IDictionary<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> _permissionsParent = null;
            List<Priv> InitResList = new List<Priv>();
            PrivilegeService _proxy = Common.Util.CreateProxy();
            using (_proxy as IDisposable)
            {
                _permissionsParent = _proxy.GetPermission(nTabControl1.SelectedTab.Name, (tvRole.SelectedNode.Tag as Role));

                foreach (KeyValuePair<Priv, IList<Neusoft.Privilege.BizLogic.Model.Operation>> pair in _permissionsParent)
                {
                    InitResList.Add(pair.Key);
                }
            }

            //查找出初始Res和选择后的Res差别，找到DelResList
            foreach (Priv initRes in InitResList)
            {
                bool judge = true;
                foreach (Priv checkItem in res)
                {
                    if (initRes.Id == checkItem.Id)
                    {
                        judge = false;
                        continue;
                    }
                }

                if (judge)
                {
                    deleteResList.Add(initRes);
                }
            }
        }
    }
}

