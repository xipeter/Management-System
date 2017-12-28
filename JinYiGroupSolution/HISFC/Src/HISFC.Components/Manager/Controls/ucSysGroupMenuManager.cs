using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucSysGroupMenuManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSysGroupMenuManager()
        {
            InitializeComponent();
            if (DesignMode == false)
            {
                try
                {
                    Initialize();
                    this.tabControl1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("创建菜单维护窗口出错！") + ex.Message);
                }
            }
        }

        #region 变量
        protected string[] icons = null;

        private Neusoft.HISFC.Models.Base.Employee person = null;
        private FarPoint.Win.Spread.CellType.ComboBoxCellType cmbForms = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        private FarPoint.Win.Spread.CellType.ComboBoxCellType cmbIcons = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

        protected Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager formManager = new Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager();
        //系统组
        protected Neusoft.HISFC.BizLogic.Manager.SysMenuManager menuManager = new Neusoft.HISFC.BizLogic.Manager.SysMenuManager();
        protected Neusoft.HISFC.BizLogic.Manager.SysGroup sysGroupManager = new Neusoft.HISFC.BizLogic.Manager.SysGroup();
        protected Neusoft.HISFC.Models.Admin.SysGroup curGroup = null;
        protected ArrayList alMainMenu = null;
        protected Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
        protected bool isMenuDirty = false;
        protected Hashtable modelCache = new Hashtable();
        protected ArrayList Models = new ArrayList();
        protected Neusoft.HISFC.BizLogic.Manager.SysGroup constManager = new Neusoft.HISFC.BizLogic.Manager.SysGroup();
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        /// <summary>
        /// 
        /// </summary>
        protected bool IsMenuDirty
        {
            get
            {
                return isMenuDirty;
            }
            set
            {
                isMenuDirty = value;
            }
        }
        protected List<string> DelRows=new List<string>();    // Robin Add
        protected override void OnLoad(EventArgs e)
        {
            
        }

        #endregion

        #region 初始化
        /// <summary>
        /// 初始化函数
        /// </summary>
        public void Initialize()
        {
            person = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            if (person == null) return;
            if (person.IsManager)
            {
                curGroup = new Neusoft.HISFC.Models.Admin.SysGroup();
                curGroup.ID = "ROOT";
                curGroup.Name = "系统组";
                curGroup.ParentGroup.ID = "ROOT";
                curGroup.ParentGroup.Name = "ROOT";
            }
            else
            {
                curGroup = person.CurrentGroup as Neusoft.HISFC.Models.Admin.SysGroup;
            }

   
            //初始化FarPoint3.
            //
            FarPoint.Win.Spread.CellType.ComboBoxCellType combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cmbIcons = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            Neusoft.HISFC.BizLogic.Manager.SysModelManager modelMgr = new Neusoft.HISFC.BizLogic.Manager.SysModelManager();
            Models = modelMgr.LoadAll();
            string[] items = new string[Models.Count];
            int max = Enum.GetValues(typeof(Neusoft.FrameWork.WinForms.Classes.EnumImageList)).Length;
            icons = new string[max];

            int index = 0;
            foreach (Neusoft.HISFC.Models.Admin.SysModel model in Models)
            {
                items[index] = model.SysName;
                modelCache.Add(model.SysCode, model.SysName);
                index++;
            }
            for (index = 0; index < icons.Length; index++)
            {
                icons[index] = Enum.GetValues(typeof(Neusoft.FrameWork.WinForms.Classes.EnumImageList)).GetValue(index).ToString();
            }
            combo.Items = items;
            cmbIcons.Items = icons;
            this.fpSpread1_Sheet1.Columns[1].CellType = combo;
            this.fpSpread1_Sheet1.Columns[5].CellType = cmbIcons;
            this.fpSpread1_Sheet1.Columns[2].Visible = false;
            this.fpSpread1_Sheet1.Columns[6].Visible = false;
            this.fpSpread1_Sheet1.Columns[8].Visible = false;
            this.fpSpread1_Sheet1.Columns[0].Width = 120;
            this.fpSpread1_Sheet1.Columns[1].Width = 200;
            this.fpSpread1_Sheet1.Columns[3].Width = 200;
            this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
            this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpSpread1_Sheet1_CellChanged);

        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("新建组", "添加新组", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加.GetHashCode(), true, false, null);
            toolBarService.AddToolButton("删除组", "删除改组", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除.GetHashCode(), true, false, null);
           
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "新建组")
            {
                this.Add();
            }
            else if (e.ClickedItem.Text == "删除组")
            {
                this.DelGroup();
            }
           
        }
        #endregion

        #region 系统组维护

        /// <summary>
        /// 添加listView 人员及菜单
        /// </summary>
        /// <param name="node"></param>
        private void AddListView(TreeNode node)
        {
            this.lsvPerson.Items.Clear();
            foreach (TreeNode n in node.Nodes)
            {
                if (n.Tag != null)
                {
                    this.myAddListView(n.Tag, 2);
                }
            }

            ArrayList alPerson = null;


            if (node.Tag == null)
            {
                alPerson = sysGroupManager.GetPeronFromGroup(curGroup.ID);
            }
            else
            {
                Neusoft.HISFC.Models.Admin.SysGroup o = node.Tag as Neusoft.HISFC.Models.Admin.SysGroup;
                if (o == null) return;
                alPerson = sysGroupManager.GetPeronFromGroup(o.ID);

            }
            for (int i = 0; i < alPerson.Count; i++)
            {
                myAddListView(alPerson[i], 2);
            }
        }

        private void myAddListView(object obj, int imageindex)
        {
            try
            {
                Neusoft.HISFC.Models.Admin.SysGroup o = obj as Neusoft.HISFC.Models.Admin.SysGroup;
                if ( o != null )
                {
                    ListViewItem item = new ListViewItem(o.Name, imageindex);
                    item.Text = o.Name;
                    item.Tag = o;
                    this.lsvPerson.Items.Add(item);
                    return;
                }
                Neusoft.HISFC.Models.Base.Employee p = obj as Neusoft.HISFC.Models.Base.Employee;
                if ( p != null )
                {
                    ListViewItem item = new ListViewItem(p.Name, imageindex);
                    item.Text = p.Name;
                    item.Tag = p;

                    if (p.Sex.ID.ToString() == "F")
                    {
                        item.ImageIndex = 6;
                    }
                    else
                    {
                        item.ImageIndex = 4;
                    }
                    this.lsvPerson.Items.Add(item);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 添加系统组
        /// </summary>
        /// <param name="node"></param>
        private void AddGroup(TreeNode node)
        {
            Neusoft.HISFC.Models.Admin.SysGroup obj = null;
            if (node.Tag == null)
            {
                obj = new Neusoft.HISFC.Models.Admin.SysGroup();
                obj.ID = "ROOT";
                obj.Name = "ROOT";
            }
            else
            {
                obj = (node.Tag as Neusoft.HISFC.Models.Admin.SysGroup).Clone();
            }

            //添加组控件
            Forms.frmAddGroup f = new Manager.Forms.frmAddGroup();
            f.SysGroup = obj;
            f.OkEvent += new Neusoft.FrameWork.WinForms.Forms.OKHandler(f_OkEvent);
            f.ShowDialog();
        }

        void f_OkEvent(object sender, Neusoft.FrameWork.Models.NeuObject e)
        {
            TreeNode node = new TreeNode(e.Name);
            node.Tag = e;
            node.ImageIndex = 2;
            node.SelectedImageIndex = 2;
            this.treeView1.SelectedNode.Nodes.Add(node);
        }

        /// <summary>
        /// 删除组
        /// </summary>
        /// <returns></returns>
        private int DelGroup()
        {
            try
            {
                if (this.treeView1.SelectedNode == null) return 0;
                if (this.lsvMainMenu.Items.Count > 0)
                {
                    MessageBox.Show("该组有子菜单，不能执行删除操作！");
                    return 0;
                }
                if (this.treeView1.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("有子结点不能删除！");
                    return -1;
                }

                if (this.treeView1.SelectedNode.Tag == null) return -1;

                if (MessageBox.Show("真的删除系统组吗" + this.treeView1.SelectedNode.Tag.ToString(), "删除组", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();

                    sysGroupManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    if (sysGroupManager.Del(this.treeView1.SelectedNode.Tag) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show("删除错误！" + sysGroupManager.Err);
                        return -1;
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.Commit();;
                        this.treeView1.SelectedNode.Parent.Nodes.Remove(this.treeView1.SelectedNode);
                        MessageBox.Show("成功删除系统组");
                        return 0;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return 0;
        }

     
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            try
            {
                this.AddGroup(this.treeView1.SelectedNode);
            }
            catch { }

            return 0;
        }


        #endregion

        #region Menu
        protected void AddMenuItem()
        {
            this.fpSpread1_Sheet1.AddRows(this.fpSpread1_Sheet1.Rows.Count, 1);
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.Rows.Count - 1, 4].Value = true;
        }

        private void DelMenuItem()
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                this.fpSpread1_Sheet1.RemoveRows(this.fpSpread1_Sheet1.ActiveRowIndex, 1);
                this.IsMenuDirty = true;
            }
            else
            {
                MessageBox.Show("没有可以删除的数据");
            }
        }

       

        private void upMenuButton_Click(object sender, System.EventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex <= 0)
                return;
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            Neusoft.HISFC.Models.Admin.SysMenu menu = this.fpSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Admin.SysMenu;
            if (menu == null)
            {
                menu = new Neusoft.HISFC.Models.Admin.SysMenu();
                Neusoft.HISFC.Models.Admin.SysGroup group = this.lsvMainMenu.SelectedItems[0].Tag as Neusoft.HISFC.Models.Admin.SysGroup;
                menu.PargrpCode = group.ParentGroup.ID;
                menu.CurgrpCode = group.ID;
                menu.X = row;
                menu.Y = 0;
                menu.MenuName = this.fpSpread1_Sheet1.GetText(row, 0);
                menu.ShortCut = this.fpSpread1_Sheet1.GetText(row, 1);

            }
            this.fpSpread1_Sheet1.RemoveRows(row, 1);
            this.fpSpread1_Sheet1.AddRows(row - 1, 1);
            this.fpSpread1_Sheet1.SetText(row - 1, 0, menu.MenuName);
            this.fpSpread1_Sheet1.SetText(row - 1, 1, menu.ShortCut);
            menu.NewX = row - 1;
            this.fpSpread1_Sheet1.Rows[row - 1].Tag = menu;

            this.IsMenuDirty = true;

            this.fpSpread1_Sheet1.ActiveRowIndex = row - 1;


        }

        private void downMenuButton_Click(object sender, System.EventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex >= this.fpSpread1_Sheet1.Rows.Count - 1)
                return;
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            Neusoft.HISFC.Models.Admin.SysMenu menu = this.fpSpread1_Sheet1.Rows[row].Tag as Neusoft.HISFC.Models.Admin.SysMenu;
            if (menu == null)
            {
                menu = new Neusoft.HISFC.Models.Admin.SysMenu();
                Neusoft.HISFC.Models.Admin.SysGroup group = this.lsvMainMenu.SelectedItems[0].Tag as Neusoft.HISFC.Models.Admin.SysGroup;
                menu.PargrpCode = group.ParentGroup.ID;
                menu.CurgrpCode = group.ID;
                menu.X = row;
                menu.Y = 0;
                menu.MenuName = this.fpSpread1_Sheet1.GetText(row, 0);
                menu.ShortCut = this.fpSpread1_Sheet1.GetText(row, 1);

            }
            this.fpSpread1_Sheet1.RemoveRows(row, 1);
            this.fpSpread1_Sheet1.AddRows(row + 1, 1);
            this.fpSpread1_Sheet1.SetText(row + 1, 0, menu.MenuName);
            this.fpSpread1_Sheet1.SetText(row + 1, 1, menu.ShortCut);
            menu.NewX = row + 1;
            this.fpSpread1_Sheet1.Rows[row + 1].Tag = menu;
            this.IsMenuDirty = true;
            this.fpSpread1_Sheet1.ActiveRowIndex = row + 1;

        }

        private ArrayList GetSubMenus(ArrayList menus, int X, int newX)
        {
            ArrayList menuList = new ArrayList();
            foreach (Neusoft.HISFC.Models.Admin.SysMenu menu in menus)
            {
                if (menu.X == X && menu.Y != 0)
                {
                    Neusoft.HISFC.Models.Admin.SysMenu newMenu = menu.Clone();
          
                    newMenu.X = newX;
                    menuList.Add(newMenu);
                }
            }

            return menuList;
        }

        private void subMenuItemButton_Click(object sender, System.EventArgs e)
        {
            if (this.lsvMainMenu.SelectedItems.Count <= 0) return;
            this.fpSpread1_Sheet1.AddRows(this.fpSpread1_Sheet1.Rows.Count, 1);
            this.fpSpread1_Sheet1.SetValue(this.fpSpread1_Sheet1.Rows.Count - 1, 7, true);

        }

        private void subDelMenuButton_Click(object sender, System.EventArgs e)
        {
            if (this.fpSpread1_Sheet1.Rows.Count > 0 && this.fpSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                this.fpSpread1_Sheet1.RemoveRows(this.fpSpread1_Sheet1.ActiveRowIndex, 1);
            }
            else
            {
                MessageBox.Show("没有数据可删除");
            }
        }

        private void subSaveMenuButton_Click(object sender, System.EventArgs e)
        {
            if (this.curGroup == null) return;
            if (SaveMainMenu() && this.SaveSubMenu())
            {
                MessageBox.Show("保存成功");
            }
        }

      
        private bool ValidateMainMenuValue()
        {
            this.fpSpread1.StopCellEditing();
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
                return true;
            foreach (FarPoint.Win.Spread.Row row in this.fpSpread1_Sheet1.Rows)
            {
                string text = this.fpSpread1_Sheet1.GetText(row.Index, 0);
                if (text == "")
                {
                    MessageBox.Show("菜单名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread1_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }
                if (text == "-")
                {
                    MessageBox.Show("菜单名称不能为分隔符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread1_Sheet1.ActiveRowIndex = row.Index;
                    return false;

                }
            }

            return true;

        }

        private bool SaveMainMenu()
        {
            bool Result = true;
            if (this.IsMenuDirty == false) return true;

            if (!ValidateMainMenuValue())
            {
                return false;
            }

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            try
            {

                ArrayList allMenus = this.menuManager.LoadAll(curGroup.ID);
                if (allMenus == null)
                {
                    Result = false;
                    throw new Exception("菜单组不存在.");
                }

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //trans.BeginTransaction();

                this.menuManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (menuManager.Delete(curGroup.ID) < 0)
                {
                    Result = false;
                    throw new Exception("菜单组不存在.");
                }

                ArrayList newMenus = new ArrayList();
                int iRow = 0;
                foreach (Neusoft.HISFC.Models.Admin.SysMenu menu in this.alMainMenu)
                {
                    if (menu != null)
                    {
                        ArrayList menus = GetSubMenus(allMenus, menu.X, iRow);
                        menu.X = iRow;
                        menu.Y = 0;
                        menus.Insert(0, menu);
                        newMenus.AddRange(menus);
                    }
                    else
                    {
                        Result = false;
                        throw new Exception("保存失败");
                    }
                    iRow++;
                }


                foreach (Neusoft.HISFC.Models.Admin.SysMenu newMenu in newMenus)
                {
                    if (newMenu.MenuName.Trim() == "")
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                        MessageBox.Show("名称不能为空!");
                        return false;
                    }
                    if (menuManager.InsertSysMenu(newMenu) < 0)
                    {
                        Result = false;
                        throw new Exception(menuManager.Err);
                    }
                }
                if (Result)
                {

                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    return true;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show("保存失败" + menuManager.Err);
                }

            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                Result = false;
                MessageBox.Show("数据保存失败" + ex.Message + menuManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return Result;
        }

        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            this.IsMenuDirty = true;
        }

    

        private ArrayList GetSubMenus(ArrayList menus, int x)
        {
            ArrayList sub = new ArrayList();
            foreach (Neusoft.HISFC.Models.Admin.SysMenu menu in menus)
            {
                if (menu.X == x && menu.Y != 0)
                {
                    sub.Add(menu);
                }
            }

            return sub;
        }

        private bool ValidateSubMenuValue()
        {
            foreach (FarPoint.Win.Spread.Row row in this.fpSpread1_Sheet1.Rows)
            {
                string name = this.fpSpread1_Sheet1.GetText(row.Index, 0).Trim();
                if (name.Length <= 0)
                {
                    MessageBox.Show("菜单名称不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread1_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }
                if (name == "-")
                    continue;

                if (this.fpSpread1_Sheet1.GetText(row.Index, 1).Trim().Length <= 0)
                {
                    MessageBox.Show("调用模块不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread1_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }

                if (this.fpSpread1_Sheet1.GetText(row.Index, 3).Trim().Length <= 0)
                {
                    MessageBox.Show("窗口名称不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread1_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }


            }
            return true;
        }

        // Robin Add
        private bool ValidateConstValue()
        {
            foreach (FarPoint.Win.Spread.Row row in this.fpSpread2_Sheet1.Rows)
            {
                string name = this.fpSpread2_Sheet1.GetText(row.Index, 0).Trim();
                if (name.Length == 0)
                {
                    MessageBox.Show("不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread2_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }

                if (this.fpSpread2_Sheet1.GetText(row.Index, 1).Trim().Length == 0)
                {
                    MessageBox.Show("不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread2_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }
                if (this.fpSpread2_Sheet1.GetText(row.Index, 2).Trim().Length == 0)
                {
                    MessageBox.Show("不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread2_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }
                if (this.fpSpread2_Sheet1.GetText(row.Index, 3).Trim().Length == 0)
                {
                    MessageBox.Show("不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.fpSpread2_Sheet1.ActiveRowIndex = row.Index;
                    return false;
                }


            }
            return true;
        }

        /// <summary>
        /// 保存子菜单
        /// </summary>
        /// <returns></returns>
        protected bool SaveSubMenu()
        {
            bool Result = true;
            if (!ValidateSubMenuValue())
            {
                return false;
            }

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);

            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //trans.BeginTransaction();

                this.menuManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (lsvMainMenu.SelectedItems.Count > 0)
                {
                    Neusoft.HISFC.Models.Admin.SysMenu obj = this.lsvMainMenu.SelectedItems[0].Tag as Neusoft.HISFC.Models.Admin.SysMenu;
                    if (this.menuManager.Delete(curGroup.ID, obj.NewX) < 0)
                    {
                        Result = false;
                       
                    }
                    ArrayList menus = new ArrayList();
                    foreach (FarPoint.Win.Spread.Row row in this.fpSpread1_Sheet1.Rows)
                    {
                        Neusoft.HISFC.Models.Admin.SysMenu menu = new Neusoft.HISFC.Models.Admin.SysMenu();
                        menu.PargrpCode = curGroup.ParentGroup.ID;
                        menu.CurgrpCode = curGroup.ID;
                        menu.X = obj.NewX;
                        menu.Y = row.Index + 1;
                        menu.MenuName = this.fpSpread1_Sheet1.GetText(row.Index, 0);
                        if (menu.MenuName != "-")
                        {
                            menu.SysCode = this.fpSpread1_Sheet1.GetText(row.Index, 2);
                            menu.MenuWin = this.fpSpread1_Sheet1.GetText(row.Index, 6);
                            menu.Memo = this.fpSpread1_Sheet1.GetText(row.Index, 3);
                            menu.Enabled = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpSpread1_Sheet1.GetValue(row.Index, 4));
                            menu.Icon = this.fpSpread1_Sheet1.GetText(row.Index, 8);
                        }
                        menus.Add(menu);

                    }


                    foreach (Neusoft.HISFC.Models.Admin.SysMenu saveMenu in menus)
                    {
                        if (menuManager.InsertSysMenu(saveMenu) < 0)
                        {
                            Result = false;
                            break;
                        }
                    }
                }
                if (Result)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                    return true;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存失败"+menuManager.Err);
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Result = false;
                MessageBox.Show("数据保存失败!" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            return Result;
        }


        private void subUpButton_Click(object sender, System.EventArgs e)
        {



        }

        private void subDownButton_Click(object sender, System.EventArgs e)
        {


        }

        #endregion

        // Robin Add
        #region Const   
        protected void AddConstItem()
        {
            this.fpSpread2_Sheet1.AddRows(this.fpSpread2_Sheet1.Rows.Count, 1);
        }
        private void DelConstItem()
        {
            if (this.fpSpread2_Sheet1.ActiveRowIndex >= 0)
            {
                if (fpSpread2_Sheet1.Cells[fpSpread2_Sheet1.ActiveRowIndex, 0].Tag.ToString() == "old")                    
                        this.DelRows.Add(this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex,0].Text);
                
                this.fpSpread2_Sheet1.RemoveRows(this.fpSpread2_Sheet1.ActiveRowIndex, 1);
                this.IsMenuDirty = true;
            }
            else
            {
                MessageBox.Show("没有可以删除的数据");
            }
        }
        protected int GetConstItem()
        {
            try
            {
                if (this.curGroup == null) return 0;

                ArrayList al = null;
                try
                {
                    al = this.constManager.GetConstByGroup(this.curGroup.ID);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return -1; }
                if (al == null)
                {
                    MessageBox.Show(this.constManager.Err);
                    return -1;
                }

                this.fpSpread2.Sheets[0].RowCount = al.Count;
                int iRow = 0;
                foreach (Neusoft.HISFC.Models.Admin.SysModelFunction obj in al)
                {
                    this.fpSpread2.Sheets[0].Cells[iRow, 0].Text = obj.ID;
                    this.fpSpread2.Sheets[0].Cells[iRow, 0].Tag = "old"; //注明是已经保存过的行
                    this.fpSpread2.Sheets[0].Cells[iRow, 0].Locked = true;
                    this.fpSpread2.Sheets[0].Cells[iRow, 1].Text = obj.Name;
                    this.fpSpread2.Sheets[0].Cells[iRow, 2].Text = obj.WinName;
                    this.fpSpread2.Sheets[0].Cells[iRow, 3].Text = obj.DllName;
                    this.fpSpread2.Sheets[0].Cells[iRow, 4].Text = obj.Param;
                    this.fpSpread2.Sheets[0].Cells[iRow, 5].Text = obj.Mark + string.Empty;

                    this.fpSpread2.Sheets[0].Rows[iRow].Tag = obj;
                    iRow++;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            return 0;
        }
        /// <summary>
        /// 保存常数
        /// </summary>
        /// <returns></returns>
        protected bool SaveConst()
        {
            bool Result = true;
            if (!ValidateConstValue())
            {
                return false;
            }

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);

            try
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //trans.BeginTransaction();
                this.constManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    ArrayList menus = new ArrayList();
                    foreach (FarPoint.Win.Spread.Row row in this.fpSpread2_Sheet1.Rows)
                    {
                        Neusoft.HISFC.Models.Admin.SysModelFunction constItem=new Neusoft.HISFC.Models.Admin.SysModelFunction();
                       
                        constItem.ID = this.fpSpread2_Sheet1.Cells[row.Index,0].Text;
                        constItem.Name = this.fpSpread2_Sheet1.Cells[row.Index,1].Text;
                        constItem.WinName = this.fpSpread2_Sheet1.Cells[row.Index,2].Text;
                        constItem.DllName = this.fpSpread2_Sheet1.Cells[row.Index,3].Text;
                        constItem.Param = this.fpSpread2_Sheet1.Cells[row.Index,4].Text;
                        constItem.Memo = this.fpSpread2_Sheet1.Cells[row.Index,5].Text;
                        menus.Add(constItem);

                    }


                    foreach (Neusoft.HISFC.Models.Admin.SysModelFunction saveMenu in menus)
                    {
                        
                        if (this.constManager.SetConst(this.curGroup.ID, saveMenu) < 0)
                        {
                            Result = false;
                            break;
                        }
                    }

                    for (int i = 0; i < DelRows.Count; i++)
                    {
                        Neusoft.HISFC.Models.Admin.SysModelFunction obj = new Neusoft.HISFC.Models.Admin.SysModelFunction();
                        obj.ID = DelRows[i].ToString();
                        this.constManager.DelConst(this.curGroup.ID, obj);
                    }
                
                if (Result)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    this.DelRows.Clear();
                    return true;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存失败" + menuManager.Err);
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Result = false;
                MessageBox.Show("数据保存失败!" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            return Result;
        }
#endregion

        #region newMenu
        
        private void GetMainMenu(Neusoft.HISFC.Models.Admin.SysGroup group)
        {
            this.lsvMainMenu.Items.Clear();
            this.lsvMainMenu.HideSelection = false;

            ArrayList menus = this.menuManager.LoadAllParentMenu(group.ID);

            alMainMenu = new ArrayList();
            if (menus.Count <= 0)
                return;
            foreach (Neusoft.HISFC.Models.Admin.SysMenu menu in menus)
            {
                if (menu.Y != 0)
                    break;
                if (menu.MenuName.Trim() != "")
                {
                    ListViewItem item = new ListViewItem(menu.MenuName, 0);
                    item.Text = menu.MenuName;
                    item.Tag = menu;
                    alMainMenu.Add(menu);
                    this.lsvMainMenu.Items.Add(item);
                }
            }
            if (this.lsvMainMenu.Items.Count > 0) this.lsvMainMenu.Items[0].Selected = true;
        }

        private void subMenuListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.lsvMainMenu.SelectedItems.Count <= 0)
                return;
            ListViewItem item = this.lsvMainMenu.SelectedItems[0];

            if (item == null) return;

            //
            //加载子菜单。
            //
            ArrayList subMenus = new ArrayList();
            subMenus = this.menuManager.LoadAll(this.curGroup.ID);
            
            Neusoft.HISFC.Models.Admin.SysMenu obj = item.Tag as Neusoft.HISFC.Models.Admin.SysMenu;
            ArrayList subMenuList = GetSubMenus(subMenus, obj.NewX);

            this.fpSpread1_Sheet1.Rows.Count = 0;            

            foreach (Neusoft.HISFC.Models.Admin.SysMenu menu in subMenuList)
            {
                this.fpSpread1_Sheet1.AddRows(this.fpSpread1_Sheet1.Rows.Count, 1);
                this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.Rows.Count - 1, 0, menu.MenuName);
                if (menu.MenuName == "-")
                    continue;
                this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.Rows.Count - 1, 1, modelCache[menu.SysCode].ToString());
                this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.Rows.Count - 1, 2, menu.SysCode);
                this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.Rows.Count - 1, 3, menu.ModelFuntion.FunName);
                this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.Rows.Count - 1, 6, menu.MenuWin);
                this.fpSpread1_Sheet1.SetValue(this.fpSpread1_Sheet1.Rows.Count - 1, 4, menu.Enabled);
                this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.Rows.Count - 1, 5, icons[Neusoft.FrameWork.Function.NConvert.ToInt32(menu.Icon)]);
                this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.Rows.Count - 1, 8, menu.Icon);
                this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.Rows.Count - 1].Tag = menu;
            }

        }

        private void UpMenu()
        {
            try
            {
                
                if (this.lsvMainMenu.SelectedItems.Count <= 0)
                    return;

                int row = this.lsvMainMenu.SelectedItems[0].Index;
                ListViewItem selectedItem = this.lsvMainMenu.SelectedItems[0];


                Neusoft.HISFC.Models.Admin.SysMenu menu = selectedItem.Tag as Neusoft.HISFC.Models.Admin.SysMenu;
                if (row == 0) return;

                this.alMainMenu.RemoveAt(row);
                this.alMainMenu.Insert(row - 1, menu);
             
                this.IsMenuDirty = true;
                this.RefreshMainMenu();
                if (lsvMainMenu.Items.Count > 1)
                {
                    this.lsvMainMenu.Items[row - 1].Selected = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void DownMenu()
        {
            if (this.lsvMainMenu.SelectedItems.Count <= 0)
                return;
            int row = this.lsvMainMenu.SelectedItems[0].Index;
            ListViewItem selectedItem = this.lsvMainMenu.SelectedItems[0];


            Neusoft.HISFC.Models.Admin.SysMenu menu = selectedItem.Tag as Neusoft.HISFC.Models.Admin.SysMenu;
            if (row >= this.lsvMainMenu.Items.Count - 1) return;
            this.alMainMenu.RemoveAt(row);
            this.alMainMenu.Insert(row + 1, menu);//0,1,2,4,3,5

            this.IsMenuDirty = true;
            this.RefreshMainMenu();
            this.lsvMainMenu.Items[row + 1].Selected = true;
        }
        private void RefreshMainMenu()
        {
            this.lsvMainMenu.Items.Clear();

            foreach (Neusoft.HISFC.Models.Admin.SysMenu menu in alMainMenu)
            {
                if (menu.Y != 0)
                    break;
                ListViewItem item = new ListViewItem(menu.MenuName, 0);
                item.Text = menu.MenuName;
                item.Tag = menu;
                this.lsvMainMenu.Items.Add(item);
            }
        }
        private void AddMainMenu()
        {
            try
            {
                Neusoft.HISFC.Models.Admin.SysMenu menu = new Neusoft.HISFC.Models.Admin.SysMenu();
                menu.MenuName = "新菜单";
                if (alMainMenu != null)
                {
                    menu.X = this.alMainMenu.Count;
                    menu.NewY = 0;
                    menu.CurgrpCode = curGroup.ID;
                    menu.PargrpCode = curGroup.ParentGroup.ID;
                    ListViewItem item = new ListViewItem(menu.MenuName, 0);
                    item.ImageIndex = 0;
                    item.Text = menu.MenuName;
                    item.Tag = menu;
                    this.lsvMainMenu.Items.Add(item);
                    this.IsMenuDirty = true;

                    this.alMainMenu.Add(menu);
                }
                else
                {
                    MessageBox.Show("请先选择菜单");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        #endregion

        #region 处理
        private void lnkMainUp_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.UpMenu();

        }

        private void lnkMainDown_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.DownMenu();
        }

        private void lnkMainAdd_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.AddMainMenu();
        }

        private void lnkMainModify_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (lsvMainMenu.SelectedItems.Count > 0)
                {
                    this.lsvMainMenu.SelectedItems[0].BeginEdit();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MainMenuListView_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
        {
            try
            {
                Neusoft.HISFC.Models.Admin.SysMenu menu = this.alMainMenu[this.lsvMainMenu.SelectedItems[0].Index] as Neusoft.HISFC.Models.Admin.SysMenu;
                menu.MenuName = e.Label;
                this.alMainMenu.RemoveAt(this.lsvMainMenu.SelectedItems[0].Index);
                this.alMainMenu.Insert(this.lsvMainMenu.SelectedItems[0].Index, menu);
                this.IsMenuDirty = true;
                SetEnable(true);
            }
            catch { }
        }

        private void SetEnable(bool b)
        {
            this.lblModify.Enabled = b;
            this.lnkAdd.Enabled = b;
            this.lnkDown.Enabled = b;
            this.lnkUp.Enabled = b;
            this.lnkMenuSave.Enabled = b;
            this.lnkMenuAdd.Enabled = b;
            this.lnkMenuDelete.Enabled = b;
            this.lnkDelete.Enabled = b;
            this.lnkUp1.Enabled = b;
            this.lnkDown1.Enabled = b;
        }
        private void lnkMainDel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (lsvMainMenu.SelectedItems.Count > 0)
                {
                    this.alMainMenu.RemoveAt(this.lsvMainMenu.SelectedItems[0].Index);
                    this.lsvMainMenu.Items.RemoveAt(this.lsvMainMenu.SelectedItems[0].Index);
                    this.IsMenuDirty = true;
                }

            }
            catch { }
        }
        ArrayList alCurrentForms = null;
        private void fpSpread1_ComboSelChanged(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 1)
            {
                Neusoft.HISFC.Models.Admin.SysModel model = Models[((FarPoint.Win.FpCombo)e.EditingControl).SelectedIndex] as Neusoft.HISFC.Models.Admin.SysModel;
                if (model != null)
                    this.fpSpread1_Sheet1.SetValue(e.Row, 2, model.SysCode);

                alCurrentForms = formManager.QuerySysModelFunction(model.SysCode);
                if (alCurrentForms == null) return;
                string[] items = new string[alCurrentForms.Count];

                int index = 0;
                foreach (Neusoft.HISFC.Models.Admin.SysModelFunction m in alCurrentForms)
                {
                    items[index] = m.ID + "-" +m.FunName;
                    index++;
                }
                cmbForms.Items = items;
                this.fpSpread1_Sheet1.Cells[e.Row, 3].CellType = cmbForms;
            }
            else if (e.Column == 3)
            {
                string[] ss = this.fpSpread1_Sheet1.Cells[e.Row, 3].Text.Split('-');
                if ( ss.Length < 2 ) return;
                if (this.fpSpread1_Sheet1.Cells[e.Row, 0].Text == "")
                    this.fpSpread1_Sheet1.Cells[e.Row, 0].Text = ss[1];
                this.fpSpread1_Sheet1.Cells[e.Row, 6].Text = ss[0];
            }
          
        }

        private void lnkSubItemUp_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex >= this.fpSpread1_Sheet1.Rows.Count - 1)
                return;
            int rowIndex = this.fpSpread1_Sheet1.ActiveRowIndex;

            this.fpSpread1_Sheet1.AddRows(rowIndex + 2, 1);
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 0, this.fpSpread1_Sheet1.GetValue(rowIndex, 0));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 1, this.fpSpread1_Sheet1.GetValue(rowIndex, 1));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 2, this.fpSpread1_Sheet1.GetValue(rowIndex, 2));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 3, this.fpSpread1_Sheet1.GetValue(rowIndex, 3));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 4, this.fpSpread1_Sheet1.GetValue(rowIndex, 4));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 5, this.fpSpread1_Sheet1.GetValue(rowIndex, 5));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 6, this.fpSpread1_Sheet1.GetValue(rowIndex, 6));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 7, this.fpSpread1_Sheet1.GetValue(rowIndex, 7));
            this.fpSpread1_Sheet1.SetValue(rowIndex + 2, 8, this.fpSpread1_Sheet1.GetValue(rowIndex, 8));
            this.fpSpread1_Sheet1.RemoveRows(rowIndex, 1);
            this.fpSpread1_Sheet1.ActiveRowIndex = rowIndex + 1;
        }

        private void lnkSubItemDown_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex <= 0)
                return;
            int rowIndex = this.fpSpread1_Sheet1.ActiveRowIndex;

            this.fpSpread1_Sheet1.AddRows(rowIndex - 1, 1);
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 0, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 0));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 1, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 1));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 2, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 2));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 3, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 3));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 4, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 4));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 5, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 5));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 6, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 6));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 7, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 7));
            this.fpSpread1_Sheet1.SetValue(rowIndex - 1, 8, this.fpSpread1_Sheet1.GetValue(rowIndex + 1, 8));

            this.fpSpread1_Sheet1.RemoveRows(rowIndex + 1, 1);
            this.fpSpread1_Sheet1.ActiveRowIndex = rowIndex - 1;
        }

        private void treeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                this.fpSpread1_Sheet1.RowCount = 0;
                if (e.Node == this.treeView1.Nodes[0]) return;//根结点
                this.curGroup = e.Node.Tag as Neusoft.HISFC.Models.Admin.SysGroup;
                this.AddListView(e.Node);  //添加人员组显示  		
                if (this.curGroup != null)
                {
                    this.GetMainMenu(this.curGroup);//显示组菜单

                    this.GetConstItem();    //Robin Add
                    //this.ucGroupConstManager1.GroupID = this.curGroup.ID;//显示组常数
                    //ucGroupReportManager1.GroupID = this.curGroup.ID;
                }
            }
            catch { }
        }

        private void lnkMenuAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.AddMenuItem();
        }

        private void lnkMenuDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DelMenuItem();
        }

        private void lnkMenuSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            subSaveMenuButton_Click(null, null);
        }

        private void fpSpread1_Sheet1_CellChanged_1(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == 5) //图象
            {
                int i = 0;
                foreach (string s in icons)
                {
                    if (this.fpSpread1_Sheet1.Cells[e.Row, 5].Text == s)
                    {
                        this.fpSpread1_Sheet1.Cells[e.Row, 8].Text = i.ToString();
                        this.fpSpread1_Sheet1.Cells[e.Row, 7].Value = Neusoft.FrameWork.WinForms.Classes.Function.GetImage((Neusoft.FrameWork.WinForms.Classes.EnumImageList)i);
                        break;
                    }
                    i++;
                }
            }

        }

        private void lnkConstAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.AddConstItem();
        }

        private void lnkConstDel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DelConstItem();
        }

        private void lnkConstSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SaveConst();
        }
     
#endregion

        private void fpSpread2_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == 3)
            {

                string dllname = this.fpSpread2_Sheet1.Cells[e.Row, 3].Text;
                if (dllname == "") return;
                try
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllname + ".dll");
                    Type[] type = assembly.GetTypes();
                    FarPoint.Win.Spread.CellType.ComboBoxCellType funCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    string[] ss = new string[type.Length];
                    int i = 0;
                    foreach (Type mytype in type)
                    {
                        if (mytype.IsPublic && mytype.IsClass)
                        {
                            ss[i] = mytype.ToString();
                            i++;
                        }
                    }
                    funCellType.Editable = true;
                    funCellType.Items = ss;
                    this.fpSpread2_Sheet1.Cells[e.Row, 2].CellType = funCellType;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.curGroup.ID + "_" + this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.ActiveRowIndex, 0].Text;
            Neusoft.FrameWork.WinForms.Controls.ucMaintenanceXML m = new Neusoft.FrameWork.WinForms.Controls.ucMaintenanceXML(id);
            Neusoft.FrameWork.WinForms.Forms.frmQuery f = new Neusoft.FrameWork.WinForms.Forms.frmQuery(m);
            f.ShowDialog();
        }

        private void fpSpread2_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
        }
    }
}
