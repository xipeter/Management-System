using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Neusoft.WinForms;
using Neusoft.WinForms.Forms;
using System.Drawing;
using Neusoft.HISFC.BizLogic.Privilege.Model;
using Neusoft.HISFC.BizLogic.Privilege.Service;

using HIS;
using Neusoft.FrameWork.WinForms.Forms;
using System.Runtime.InteropServices;

namespace HIS
{
    internal class Menu
    {
        /// <summary>
        /// 菜单集合
        /// </summary>
        private static System.Windows.Forms.Form parentForm = null;

        private static List<RoleResourceMapping> menuCollection;

        private static Dictionary<string, Control> openedForms = new Dictionary<string, Control>();

        /// <summary>
        /// 根据角色生成菜单
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public static MenuStrip InitMenu(string roleID, System.Windows.Forms.Form mainForm)
        {
            parentForm = mainForm;
            //清空已打开的窗口
            for (int i = 0; i < parentForm.MdiChildren.Length; i++)
            {
                parentForm.MdiChildren[i].Close();
            }

            PrivilegeService _proxy = new PrivilegeService();
            using (_proxy as IDisposable)
            {
                menuCollection = _proxy.QueryByTypeRoleId("MenuRes", roleID);
            }

            foreach (Control _ctl in parentForm.Controls)
            {
                if (_ctl.GetType() == typeof(MenuStrip))
                    parentForm.Controls.Remove(_ctl);
            }

            return AddRootMenu();
        }

        /// <summary>
        /// 增加菜单
        /// </summary>
        /// <returns></returns>
        private static MenuStrip AddRootMenu()
        {
            int iShortCut = 65;

            MenuStrip _main = new MenuStrip();
            _main.ItemAdded += new ToolStripItemEventHandler(main_ItemAdded);

            List<RoleResourceMapping> _menus = sequenceLists(GetSubMenu("root"));//第一级为模块

            foreach (RoleResourceMapping _menu in _menus)
            {
                _menu.Name = _menu.Name + "(&" + ((char)iShortCut).ToString() + ")";
                ToolStripMenuItem _menuItem = CreateMenuItem(_menu);
                _main.Items.Add(_menuItem);
                _menuItem.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.PR菜单下);// ImageRes.主菜单节点_关闭16;
                _menuItem.DropDownOpened += new EventHandler(menuItem_DropDownOpened);
                _menuItem.DropDownClosed += new EventHandler(menuItem_DropDownClosed);

                AddSubMenu(_menu.Id, _menuItem);

                iShortCut++;
            }

            //创建缺省的退出等菜单
            CreateDefaultMenu(_main, iShortCut);

            return _main;
        }

        /// <summary>
        /// 去掉菜单栏图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void main_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length == 0)
            {
                e.Item.Visible = false;
            }

        }

        static void menuItem_DropDownClosed(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.PR菜单下);//ImageRes.主菜单节点_关闭16;
        }

        static void menuItem_DropDownOpened(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.PR菜单上);//ImageRes.主菜单节点_打开16;
        }

        /// <summary>
        /// 获取直接下属菜单
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private static List<RoleResourceMapping> GetSubMenu(string parentID)
        {
            List<RoleResourceMapping> _menus = new List<RoleResourceMapping>();

            foreach (RoleResourceMapping _menu in menuCollection)
            {
                if (_menu.ParentId == parentID)
                {
                    _menus.Add(_menu);
                }
            }

            return _menus;
        }

        /// <summary>
        /// 增加菜单项
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="parent"></param>
        private static void AddSubMenu(string parentId, ToolStripMenuItem parent)
        {
            List<RoleResourceMapping> _menus = sequenceLists(GetSubMenu(parentId));

            foreach (RoleResourceMapping _menu in _menus)
            {
                ToolStripMenuItem _menuItem = CreateMenuItem(_menu);
                parent.DropDownItems.Add(_menuItem);

                AddSubMenu(_menu.Id, _menuItem);
            }
        }

        /// <summary>
        /// 生成系统默认帮助菜单
        /// </summary>
        /// <param name="menuStrip"></param>
        private static void CreateDefaultMenu(MenuStrip menuStrip, int iShortCut)
        {
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("帮助" + "(&" + ((char)iShortCut).ToString() + ")");

            helpMenu.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.PR菜单下);//ImageRes.主菜单节点_关闭16;
            helpMenu.DropDownOpened += new EventHandler(menuItem_DropDownOpened);
            helpMenu.DropDownClosed += new EventHandler(menuItem_DropDownClosed);


            RoleResourceMapping _register = new RoleResourceMapping();
            _register.Name = "注册";
            _register.Resource.WinName = "*#$%Register";
            _register.ValidState = "1";
            _register.Icon = Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销.GetHashCode().ToString();

            helpMenu.DropDownItems.Add(CreateMenuItem(_register));

            RoleResourceMapping _changeRegister = new RoleResourceMapping();
            _changeRegister.Name = "更改登录";
            _changeRegister.Resource.WinName = "*#$%ResetGroup";
            _changeRegister.ValidState = "1";
            _changeRegister.Icon = Neusoft.FrameWork.WinForms.Classes.EnumImageList.J集体.GetHashCode().ToString();

            helpMenu.DropDownItems.Add(CreateMenuItem(_changeRegister));

            helpMenu.DropDownItems.Add( new ToolStripSeparator() );

            RoleResourceMapping _change = new RoleResourceMapping();
            _change.Name = "修改密码";
            _change.Resource.WinName = "*#$%ChangePWD";
            _change.ValidState = "1";
            _change.Icon = Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改.GetHashCode().ToString();

            helpMenu.DropDownItems.Add(CreateMenuItem(_change));

            helpMenu.DropDownItems.Add( new ToolStripSeparator() );

            RoleResourceMapping _about = new RoleResourceMapping();
            _about.Name = "关于";
            _about.Resource.WinName = "*#$%About";
            _about.ValidState = "1";
            _about.Icon = Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息.GetHashCode().ToString();

            helpMenu.DropDownItems.Add( CreateMenuItem( _about ) );

            #region {DD84CBE6-6C42-4b29-AB55-4775F7A759D0}

            RoleResourceMapping _calc = new RoleResourceMapping();
            _calc.Name = "计算器";
            _calc.Resource.WinName = "*#$%Calc";
            _calc.ValidState = "1";
            _calc.Icon = Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息.GetHashCode().ToString();

            helpMenu.DropDownItems.Add(CreateMenuItem(_calc)); 

            #endregion

            RoleResourceMapping _helpManual = new RoleResourceMapping();
            _helpManual.Name = "帮助";
            _helpManual.Resource.WinName = "*#$%Help";
            _helpManual.ValidState = "1";
            _helpManual.Icon = Neusoft.FrameWork.WinForms.Classes.EnumImageList.B帮助.GetHashCode().ToString();

            helpMenu.DropDownItems.Add(CreateMenuItem(_helpManual));

            helpMenu.DropDownItems.Add( new ToolStripSeparator() );

            //RoleResourceMapping _language = new RoleResourceMapping();
            //_language.Name = "语言设置";
            //_language.Resource.WinName = "*#$%Language";
            //_language.ValidState = "1";

            //_help.DropDownItems.Add(CreateMenuItem(_language));

            //RoleResourceMapping _skin = new RoleResourceMapping();
            //_skin.Name = "皮肤";
            //_skin.Resource.WinName = "*#$%Skin";
            //_skin.ValidState = "1";

            //_help.DropDownItems.Add(CreateMenuItem(_skin));
           
            RoleResourceMapping _exit = new RoleResourceMapping();
            _exit.Name = "退出";
            _exit.Resource.WinName = "*#$%Exit";
            _exit.ValidState = "1";
            _exit.Icon = Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出.GetHashCode().ToString();

            helpMenu.DropDownItems.Add(CreateMenuItem(_exit));

            menuStrip.Items.Add(helpMenu);
        }

        /// <summary>
        /// 生成菜单项
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private static ToolStripMenuItem CreateMenuItem(RoleResourceMapping menu)
        {
            ToolStripMenuItem _menuItem = new ToolStripMenuItem();
            string _menuName = "";

            if (string.IsNullOrEmpty(menu.Resource.Shortcut))
            {
                _menuName = menu.Name;
            }
            else
            {
                _menuName = menu.Name;
                _menuItem.ShowShortcutKeys = true;
                Shortcut _shortcut = (Shortcut)Enum.Parse(typeof(Shortcut), menu.Resource.Shortcut);
                _menuItem.ShortcutKeys = (Keys)_shortcut;
            }

            _menuItem.Text = _menuName;
            _menuItem.ToolTipText = _menuName;
            if (!string.IsNullOrEmpty(menu.Icon))
                _menuItem.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage((Neusoft.FrameWork.WinForms.Classes.EnumImageList)(Neusoft.FrameWork.Function.NConvert.ToInt32(menu.Icon))); ;
            _menuItem.Tag = menu;
            _menuItem.Enabled = Neusoft.FrameWork.Function.NConvert.ToBoolean(menu.ValidState);
            _menuItem.Click += new EventHandler(MenuItemClick);

            return _menuItem;
        }

        private static void MenuItemClick(object sender, EventArgs e)
        {
            RoleResourceMapping _menuItem =
                (sender as ToolStripMenuItem).Tag as RoleResourceMapping;

            if (_menuItem == null) return;
            if (string.IsNullOrEmpty(_menuItem.Resource.WinName)) return;
            int _rtn = ResponseDefaultMenu(_menuItem);
            //if (_rtn == 0 | _rtn == 1) return;//返回2继续
            //{D55E413A-9947-4783-B031-9EA1F2E6104B}
            if (_rtn == 0 | _rtn == 1|_rtn == -1) return;//返回2继续

            //控制重复打开窗口
            if (openedForms.ContainsKey(_menuItem.Id))
            {
                Form form = openedForms[_menuItem.Id] as Form;
                if (form != null && form.Visible)
                {
                    form.Icon = HIS.Properties.Resources.标无白边;
                    ((Form)openedForms[_menuItem.Id]).Activate();
                    return;
                }
            }

            Control _control = DynamicCreateControl(_menuItem);
            if (_control == null) return;
            _control.Dock = DockStyle.Fill;

            Control preTemControl = _control;

            //传入的控件不是窗口,用系统自动创建承载窗体
            if (!_control.GetType().IsSubclassOf(typeof(System.Windows.Forms.Form)))
            {
                _control = (Control)DynamicCreateForm(_control, _menuItem);

            }

            if (_control == null) return;


            if (_control.GetType() == typeof(frmBaseForm) ||
                _control.GetType().IsSubclassOf(typeof(frmBaseForm)))
            {
                //要修改，读取菜单的样式。
                (_control as frmBaseForm).SetFormID(_menuItem.Id);//设置窗体显示风格
            }
            #region 4.5中有此段代码，移植过来的
            //获取接口是否实现
            Neusoft.FrameWork.WinForms.Classes.IPreArrange preArrange = preTemControl as Neusoft.FrameWork.WinForms.Classes.IPreArrange;

            if (preArrange != null)
            {

                if (preArrange.PreArrange() == -1)
                {
                    return;
                }
            }
            #endregion
            openedForms[_menuItem.Id] = _control as Form;


            //显示窗体
            ShowControl(_control, _menuItem.Resource.WinName.Trim(), _menuItem.Resource.ShowType);
        }

        private static System.Windows.Forms.Control DynamicCreateForm(Control control, RoleResourceMapping menuItem)
        {
            System.Windows.Forms.Form _form = null;

            IMaintenanceControlable _query = control as IMaintenanceControlable;

            if (_query != null)//实现该接口,为一般查询窗口,对应承载窗体为frmQueryBase
            {
                _form = new frmQuery(_query);
                _form.Text = control.Text;
                _form.Icon = HIS.Properties.Resources.标无白边;
                return _form;
            }

            IControlable _operation = control as IControlable;

            if (_operation != null)//业务操作窗口,承载窗体为frmOperationBase
            {
                TreeView _tree = null;

                //生成树
                if (!string.IsNullOrEmpty(menuItem.Resource.TreeName))
                {
                    _tree = CreateTree(menuItem.Resource.TreeName, menuItem.Resource.TreeDllName);
                    if (_tree == null) return null;
                }

                if (_tree == null)
                {
                    _form = new frmBaseForm(control);
                }
                else
                {
                    _form = new frmBaseForm(control, _tree);
                }
                _form.Text = control.Text;
            }
            else
            {
                //_form = new System.Windows.Forms.Form();
                //_form.Controls.Add(control);
                //_form.Size = new Size(control.Size.Width + 10, control.Size.Height + 30);
                //_form.StartPosition = FormStartPosition.CenterScreen;

                // _form.Text = control.Text;
                return control;
            }

            _form.Tag = menuItem.Parameter;
            _form.Icon = HIS.Properties.Resources.标无白边;
            return _form;
        }

        private static int ResponseDefaultMenu(RoleResourceMapping menuItem)
        {
            switch (menuItem.Resource.WinName)
            {
                case "*#$%Register":

                    frmLogin _frmLogin = new frmLogin();
                    _frmLogin.ShowDialog();

                    return 0;

                case "*#$%ResetGroup":
                    foreach (Form f in parentForm.MdiChildren)
                    {
                        f.Close();
                    }
                    Neusoft.HISFC.Models.Base.Employee user = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
                    //{D55E413A-9947-4783-B031-9EA1F2E6104B}
                    //LoginFunction.Login(user.User01, user.Password);
                    if (LoginFunction.Login(user.User01, user.Password) < 0)
                    {
                        return -1;
                       
                    }
                    if (HIS.Program.MainForm == null)
                        HIS.Program.MainForm = new frmMain();
                    HIS.Program.MainForm.InitMenu(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).CurrentGroup.ID);

                    return 0;

                case "*#$%ChangePWD":

                    frmChangePwd _frmChange = new frmChangePwd();
                    _frmChange.ShowDialog();

                    return 0;
                case "*#$%Help":
                    try
                    {
                        System.Diagnostics.Process.Start(Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + "help.chm");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return 0;
                case "*#$%About":
                    frmAbout frm = new frmAbout();
                    frm.ShowDialog();

                    return 0;
                #region {DD84CBE6-6C42-4b29-AB55-4775F7A759D0}
                case "*#$%Calc":
                    try
                    {
                        System.Diagnostics.Process.Start("calc.exe");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载系统计算器时发生异常");
                    }
                    return 0; 
                #endregion
                case "*#$%Language":
                    //frmLanguage language = new frmLanguage();
                    //language.ShowDialog();
                    return 0;
                case "*#$%SuperMan":
                    //frmSelectUser frmSuperMan = new frmSelectUser();
                    //frmSuperMan.MdiParent = mainForm;
                    //frmSuperMan.Show();
                    //frmSuperMan.WindowState = FormWindowState.Normal;
                    //frmSuperMan.WindowState = FormWindowState.Maximized;
                    return 0;

                case "*#$%Skin":
                    //frmSkinManager frmSkin = new frmSkinManager();
                    //frmSkin.ShowDialog();
                    return 0;

                case "*#$%Exit":
                    parentForm.Close();
                    return 0;


            }

            return 2;//继续下面的
        }

        /// <summary>
        /// 利用反射动态生成控件
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        private static Control DynamicCreateControl(RoleResourceMapping menuItem)
        {
            string _controlName = menuItem.Resource.WinName.Trim();
            string _argument = "";

            if (_controlName.IndexOf(" ") > 0)//控件带参数
            {
                _argument = _controlName.Substring(_controlName.IndexOf(" ") + 1).Trim();
                _controlName = _controlName.Substring(0, _controlName.IndexOf(" "));
            }

            object _obj;
            Control _control;

            try
            {
                //装载程序集
                Assembly _assembly;

                Type _type = Type.GetType(_controlName);
                if (_type == null)
                {
                    _assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + menuItem.Resource.DllName.Trim() + ".dll");
                }
                else
                {
                    _assembly = System.Reflection.Assembly.GetAssembly(_type);
                }

                _type = _assembly.GetType(_controlName);
                if (_type == null)
                {
                    MessageBox.Show("程序集:" + menuItem.Resource.DllName.Trim() + ".dll中无类型为" + _controlName + "的控件!");
                    return null;
                }

                object[] _arguments = null;
                if (!string.IsNullOrEmpty(_argument))
                {
                    _arguments = new object[1];
                    _arguments[0] = _argument;
                }
                _obj = Activator.CreateInstance(_type, _arguments);
            }
            catch (Exception e)
            {
                SystemErrorForm _error = new SystemErrorForm(e);
                _error.ShowDialog();
                return null;
            }

            _control = _obj as Control;
            _control.Tag = menuItem.Parameter;
            _control.Text = menuItem.Name;
            return _control;
        }

        private static TreeView CreateTree(string treeName, string treeDllName)
        {
            TreeView _tree = null;

            try
            {
                //装载程序集
                Assembly _assembly;

                Type _type = Type.GetType(treeName);
                if (_type == null)
                {
                    if (string.IsNullOrEmpty(treeDllName))
                    {
                        MessageBox.Show("树控件程序集名称不能为空!", "提示");
                        return null;
                    }

                    _assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + treeDllName.Trim() + ".dll");
                }
                else
                {
                    _assembly = System.Reflection.Assembly.GetAssembly(_type);
                }

                _type = _assembly.GetType(treeName);
                if (_type == null)
                {
                    MessageBox.Show("程序集:" + treeDllName.Trim() + ".dll中无类型为" + treeName + "的控件!");
                    return null;
                }

                _tree = Activator.CreateInstance(_type) as TreeView;
            }
            catch (Exception e)
            {
                SystemErrorForm _error = new SystemErrorForm(e);
                _error.ShowDialog();
                return null;
            }

            return _tree;
        }

        private static void ShowControl(Control control, string controlName, string showType)
        {
            switch (showType)
            {
                case "ShowDialog":
                    if (control.GetType().IsSubclassOf(typeof(System.Windows.Forms.Form))
                        || control.GetType() == typeof(System.Windows.Forms.Form))
                    {
                        ((Form)control).Icon = HIS.Properties.Resources.标无白边;
                        (control as Form).ShowDialog();
                    }
                    else
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(control);
                    }

                    //加载完成后清理内存   {96BAA10E-A35A-49d8-98FB-1490B04D85E8}
                    FlushMemory();

                    break;
                case "Web":
                    try
                    {
                        System.Diagnostics.Process.Start("iexplore.exe", controlName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                default:
                    if (control.GetType().IsSubclassOf(typeof(Form)) || control.GetType() == typeof(Form))
                    {
                        ((Form)control).Icon = HIS.Properties.Resources.标无白边;
                        (control as Form).MdiParent = parentForm;
                        (control as Form).Show();
                    }
                    else
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(control);
                    }
                    //加载完成后清理内存   {96BAA10E-A35A-49d8-98FB-1490B04D85E8}
                    FlushMemory();

                    break;
            }
        }

        private static List<RoleResourceMapping> sequenceLists(List<RoleResourceMapping> childRoleResourceList)
        {
            for (int j = 1; j < childRoleResourceList.Count; j++)
            {
                for (int i = 0; i < childRoleResourceList.Count - j; i++)
                {
                    if (childRoleResourceList[i].OrderNumber > childRoleResourceList[i + 1].OrderNumber)
                    {
                        RoleResourceMapping roleResourceChange = new RoleResourceMapping();
                        roleResourceChange = childRoleResourceList[i];
                        childRoleResourceList[i] = childRoleResourceList[i + 1];
                        childRoleResourceList[i + 1] = roleResourceChange;
                    }
                }
            }

            return childRoleResourceList;
        }

        #region 加载完成后清理内存   {96BAA10E-A35A-49d8-98FB-1490B04D85E8}

        //需增加using System.Runtime.InteropServices;

        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        public static void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static void FlushMemory()
        {
            GarbageCollect();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Menu.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        #endregion

    }

}
