using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizLogic.Privilege;
using Neusoft.HISFC.BizLogic.Privilege.Service;
using Neusoft.HISFC.BizLogic.Privilege.Model;

//using Neusoft.Framework;


namespace Neusoft.HISFC.Components.Privilege
{
    /// <summary>
    /// [功能描述: 资源管理]<br></br>
    /// [创建者:   张凯钧]<br></br>
    /// [创建时间: 2008.6.23]<br></br>
    /// <说明>
    ///     资源显示控件
    /// </说明>
    /// </summary>
    public partial class ResourceControl : UserControl
    {

        #region 私有变量
        private List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> treeRes = null;
        List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> currentResourcesLists = null;

        #region 自定义Tabel
        DataTable resTabel = new DataTable("ResTable");
        DataColumn[] resColumns =
        {
        new DataColumn("ID"),
        new DataColumn("Name"),
        new DataColumn("ParentID"),
        new DataColumn("Layer"),
        new DataColumn("DllName"),
        new DataColumn("WinName"),
        new DataColumn("ControlType"),
        new DataColumn("ShowType"),
        new DataColumn("Shortcut"),
        new DataColumn("Icon"),
        new DataColumn("Tooltip"),
        new DataColumn("Param"),
        new DataColumn("Enabled"),
        new DataColumn("UserID"),
        new DataColumn("OperDate"),
        new DataColumn("Order"),
        new DataColumn("TreeDllName"),
        new DataColumn("TreeName")
        };
        #endregion
        #endregion

        #region 公共方法
        public ResourceControl(List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> _menus)
        {
            resTabel.Columns.AddRange(resColumns);
            treeRes = _menus;
            InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Blue);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(fpSpread1);
            InitTree();
            //初始化Web资源的显示列。
            if (_menus.Count != 0)
            {
                if (_menus[0].ControlType == "WebRes")
                {
                    fpSpread1_Sheet1.Columns[4].Visible = false;
                    fpSpread1_Sheet1.Columns[7].Visible = false;
                    fpSpread1_Sheet1.Columns[8].Visible = false;
                    fpSpread1_Sheet1.Columns[11].Visible = false;
                    fpSpread1_Sheet1.Columns[16].Visible = false;
                    fpSpread1_Sheet1.Columns[17].Visible = false;
                    fpSpread1_Sheet1.ColumnHeader.Columns[5].Label = "URL";
                }
            }
        }

        public void InitTree()
        {
            nTreeView1.Nodes.Clear();
            //生成根分类
            foreach (Neusoft.HISFC.BizLogic.Privilege.Model.Resource _menu in treeRes)
            {
                if (_menu.ParentId == "ROOT")//第一级为分类
                {
                    TreeNode _node = new TreeNode(_menu.Name);
                    _node.Tag = _menu;
                    _node.ImageIndex = 0;
                    _node.SelectedImageIndex = 0;
                    this.nTreeView1.Nodes.Add(_node);
                }
            }

        }

        public void AddType(String typeRes)
        {

            Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentRes = new Neusoft.HISFC.BizLogic.Privilege.Model.Resource();
            currentRes.ParentId = "ROOT";
            currentRes.Type = "Menu";
            currentRes.Enabled = true;
            currentRes.Layer = "1";
            currentRes.UserId = Neusoft.FrameWork.Management.Connection.Operator.ID;
            currentRes.OperDate =FrameWork.Function.NConvert.ToDateTime( new FrameWork.Management.DataBaseManger().GetSysDateTime());
            currentRes.Name = "新分类";

            currentRes.ControlType = typeRes;
            //保存分类信息
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                FrameWork.Management.PublicTrans.BeginTransaction();
                using (_proxy as IDisposable)
                {
                    currentRes = _proxy.SaveResourcesItem(currentRes);
                }
                FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message);
                return;
            }


            TreeNode _node = new TreeNode(currentRes.Name);
            _node.ImageIndex = 0;
            _node.SelectedImageIndex = 0;
            _node.Tag = currentRes;
            this.nTreeView1.Nodes.Add(_node);
            this.nTreeView1.SelectedNode = _node;
            AddMenuToList(currentRes);

            _node.BeginEdit();
        }

        public void RemoveType()
        {
            EndTreeEdit();
            TreeNode _node = nTreeView1.SelectedNode;
            if (_node == null)
            {
                MessageBox.Show("请选择要删除的类！");
                return;
            }

            if (MessageBox.Show("是否要删除该分类?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            if (currentResourcesLists.Count > 0)
            {
                MessageBox.Show("改分类中有数据，不能删除！！");
                return;
            }

            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                FrameWork.Management.PublicTrans.BeginTransaction();
                using (_proxy as IDisposable)
                {
                    _proxy.RemoveResourcesItem((_node.Tag as Neusoft.HISFC.BizLogic.Privilege.Model.Resource).Id);
                }
                FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }

            RemoveResFromList((_node.Tag as Neusoft.HISFC.BizLogic.Privilege.Model.Resource).Id);
            nTreeView1.Nodes.Remove(_node);
        }

        public void AddRes()
        {
            if (nTreeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择要选取的分类！");
                return;
            }

            AddResourceForm _frmAdd = new AddResourceForm(nTreeView1.SelectedNode.Tag as Neusoft.HISFC.BizLogic.Privilege.Model.Resource, (nTreeView1.SelectedNode.Tag as Neusoft.HISFC.BizLogic.Privilege.Model.Resource).ControlType);
            _frmAdd.ShowDialog();
            if (_frmAdd.DialogResult == DialogResult.OK)
            {
                Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentRes = _frmAdd.currentRes;
                if (currentRes != null)
                {
                    AddMenuToList(currentRes);
                }

                nTreeView1_AfterSelect(null, null);
            }

        }

        public void RemoveRes()
        {
            if (fpSpread1_Sheet1.Rows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show("是否要删除该资源?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                FrameWork.Management.PublicTrans.BeginTransaction();
                using (_proxy as IDisposable)
                {
                    Neusoft.HISFC.BizLogic.Privilege.Model.Resource res = new Neusoft.HISFC.BizLogic.Privilege.Model.Resource();
                    res.Id = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 0].Text.Trim();
                    res.Type = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 6].Text.Trim();
                    _proxy.RemoveResourcesItem(res);
                }
                FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }

            RemoveResFromList(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 0].Text.Trim());
            fpSpread1_Sheet1.Rows.Remove(fpSpread1_Sheet1.ActiveRowIndex, 1);
        }
        #endregion

        #region 私有方法
        private void AddMenuToList(Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentRes)
        {
            //删除先
            int i = RemoveResFromList(currentRes.Id);

            if (i >= 0)
            {
                treeRes.Insert(i, currentRes);
            }
            else
            {
                treeRes.Add(currentRes);
            }
        }

        private int RemoveResFromList(string resourcesId)
        {
            for (int i = 0; i < treeRes.Count; i++)
            {
                Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentRes = treeRes[i];
                if (currentRes.Id == resourcesId)
                {
                    treeRes.Remove(currentRes);
                    return i;
                }
            }

            return -1;
        }

        private void TranslateTabel(List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource> currentResourcesLists)
        {
            foreach (Neusoft.HISFC.BizLogic.Privilege.Model.Resource resourcesItem in currentResourcesLists)
            {
                DataRow newRow = resTabel.NewRow();
                newRow["ID"] = resourcesItem.Id;
                newRow["Name"] = resourcesItem.Name;
                newRow["ParentID"] = resourcesItem.ParentId;
                newRow["Layer"] = resourcesItem.Layer;
                newRow["DllName"] = resourcesItem.DllName;
                newRow["WinName"] = resourcesItem.WinName;
                newRow["ControlType"] = resourcesItem.ControlType;
                newRow["ShowType"] = resourcesItem.ShowType;
                newRow["Shortcut"] = resourcesItem.Shortcut;
                newRow["Icon"] = resourcesItem.Icon;
                newRow["Tooltip"] = resourcesItem.Tooltip;
                newRow["Param"] = resourcesItem.Param;
                newRow["Enabled"] = resourcesItem.Enabled;
                newRow["UserID"] = resourcesItem.UserId;
                newRow["OperDate"] = resourcesItem.OperDate;
                newRow["Order"] = resourcesItem.Order;
                newRow["TreeDllName"] = resourcesItem.TreeDllName;
                newRow["TreeName"] = resourcesItem.TreeName;
                resTabel.Rows.Add(newRow);
            }
        }

        private void TranslateEntity(Neusoft.HISFC.BizLogic.Privilege.Model.Resource resourcesItem)
        {
            resourcesItem.Id = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 0].Text.Trim();
            resourcesItem.Name = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 1].Text.Trim();
            resourcesItem.ParentId = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 2].Text.Trim();
            resourcesItem.Layer = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 3].Text.Trim();
            resourcesItem.DllName = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 4].Text.Trim();
            resourcesItem.WinName = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 5].Text.Trim();
            resourcesItem.ControlType = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 6].Text.Trim();
            resourcesItem.ShowType = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 7].Text.Trim();
            resourcesItem.Shortcut = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 8].Text.Trim();
            resourcesItem.Icon = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 9].Text.Trim();
            resourcesItem.Tooltip = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 10].Text.Trim();
            resourcesItem.Param = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 11].Text.Trim();
            resourcesItem.TreeDllName = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 16].Text.Trim();
            resourcesItem.TreeName = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 17].Text.Trim();
            resourcesItem.UserId = Neusoft.FrameWork.Management.Connection.Operator.ID;
            resourcesItem.OperDate = FrameWork.Function.NConvert.ToDateTime(new FrameWork.Management.DataBaseManger().GetSysDateTime());
            resourcesItem.Enabled = FrameWork.Function.NConvert.ToBoolean(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, 12].Text.Trim());
        }

        private void Reload()
        {
            resTabel.Clear();

            if (currentResourcesLists != null)
            {
                TranslateTabel(currentResourcesLists);
            }
            fpSpread1_Sheet1.DataSource = resTabel;
        }

        private void EndTreeEdit()
        {
            foreach (TreeNode currentNode in nTreeView1.Nodes)
            {
                currentNode.EndEdit(true);
            }
        }
        #endregion

        #region 事件
        private void nTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentResourcesLists = new List<Neusoft.HISFC.BizLogic.Privilege.Model.Resource>();
            foreach (Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentRes in treeRes)
            {
                if ((nTreeView1.SelectedNode.Tag as Neusoft.HISFC.BizLogic.Privilege.Model.Resource).Id == currentRes.ParentId)
                {
                    currentResourcesLists.Add(currentRes);
                }
            }
            Reload();
        }

        private void nTreeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode _node = nTreeView1.SelectedNode;
            if (_node == null) return;

            //不是分类,不许编辑
            if (_node.Level > 0) e.CancelEdit = true;

        }

        private void nTreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

            //保存编辑信息            
            Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentRes = (Neusoft.HISFC.BizLogic.Privilege.Model.Resource)e.Node.Tag;

            if (e.Label == null || e.Label.Trim() == "")
            {
                e.CancelEdit = true;
                return;
            }

            if (!FrameWork.Public.String.ValidMaxLengh(e.Label, 60))
            {
                e.CancelEdit = true;
                MessageBox.Show("分类的名称不能超过30个汉字!", "提示");
                e.Node.BeginEdit();
                return;
            }

            currentRes.Name = e.Label;
            //保存分类信息
            try
            {
                PrivilegeService _proxy = Common.Util.CreateProxy();
                using (_proxy as IDisposable)
                {
                    currentRes = _proxy.SaveResourcesItem(currentRes);
                }

                if (currentRes == null) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            AddMenuToList(currentRes);

        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.BizLogic.Privilege.Model.Resource oldResItem = new Neusoft.HISFC.BizLogic.Privilege.Model.Resource();
            TranslateEntity(oldResItem);
            AddResourceForm _frmAdd = new AddResourceForm(oldResItem, (nTreeView1.SelectedNode.Tag as Neusoft.HISFC.BizLogic.Privilege.Model.Resource).ControlType, "updataRes");
            _frmAdd.ShowDialog();

            if (_frmAdd.DialogResult == DialogResult.OK)
            {
                Neusoft.HISFC.BizLogic.Privilege.Model.Resource currentResources = _frmAdd.currentRes;

                if (currentResources != null)
                {
                    AddMenuToList(currentResources);
                }
                nTreeView1_AfterSelect(null, null);
            }

        }

        private void PrivilegeResourceControl_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void AddTypeItem_Click(object sender, EventArgs e)
        {
           // AddType((nTreeView1.SelectedNode.Tag as Neusoft.HISFC.BizLogic.Privilege.Model.Resource).ControlType.Trim());
           // AddType();
        }

        private void RemoveTypeItem_Click(object sender, EventArgs e)
        {
            RemoveType();
        }

        private void AddResItem_Click(object sender, EventArgs e)
        {
            AddRes();
        }

        private void ModifyResItem_Click(object sender, EventArgs e)
        {
            fpSpread1_CellDoubleClick(null, null);
        }

        private void RemoveResItem_Click(object sender, EventArgs e)
        {
            RemoveRes();
        }

        private void mnuTest_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex < 0) return;

            int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            
            Neusoft.HISFC.Models.Admin.SysMenu obj = new Neusoft.HISFC.Models.Admin.SysMenu();
            obj.ModelFuntion.DllName = this.fpSpread1_Sheet1.Cells[row, 4].Text;
            obj.ModelFuntion.WinName = this.fpSpread1_Sheet1.Cells[row, 5].Text;
            obj.MenuParm = this.fpSpread1_Sheet1.Cells[row, 11].Text;
            obj.MenuName = this.fpSpread1_Sheet1.Cells[row, 1].Text;
            #region {CCC3E877-ADB8-43e5-80B5-53FDEE94C47E}
            obj.ModelFuntion.FormShowType = this.fpSpread1_Sheet1.Cells[row, 7].Text; 
            #endregion
            obj.ModelFuntion.TreeControl.WinName = this.fpSpread1_Sheet1.Cells[row, 17].Text;
            obj.ModelFuntion.TreeControl.DllName = this.fpSpread1_Sheet1.Cells[row, 16].Text;
            //obj.ModelFuntion.TreeControl.Param = this.fpSpread1_Sheet1.Cells[row, 5].Text;
            //obj.MenuWin = this.fpSpread1_Sheet1.Cells[row, 11].Text;
            Function.ShowForm(obj);

        }

        #endregion

      
    }
}
