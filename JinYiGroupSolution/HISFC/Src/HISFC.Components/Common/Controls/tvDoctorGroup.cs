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
    public delegate void SelectOrderHandler(ArrayList alOrders);
    /// <summary>
    /// 医生同学的组套列表控件的说
    /// </summary>
    public partial class tvDoctorGroup : Neusoft.FrameWork.WinForms.Controls.NeuTreeView
    {
        public tvDoctorGroup()
        {
            InitializeComponent();
            this.ImageList = imageList1;
        }

        public tvDoctorGroup(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public event SelectOrderHandler SelectOrder;
        /// <summary>
        /// 科室组套
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;
        /// <summary>
        /// 个人组套
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper personHelper = null;

        #region {3E29ADED-FB2D-4243-B525-BBDD79D85C2B}
        /// <summary>
        /// 修改前组套名称
        /// </summary>
        string labelName = "";
        #endregion

        #region 属性


        protected enuType myType = enuType.Order;
        
        /// <summary>
        /// 当前组套类型，医嘱
        /// </summary>
        [DefaultValue(enuType.Order)]
        public enuType Type
        {
            get
            {
                return this.myType;
            }
            set
            {
                this.myType = value;
            }
        }

        /// <summary>
        /// 自己的常用组套
        /// </summary>
        protected enuGroupShowType myShowType = enuGroupShowType.Me;
        
        /// <summary>
        /// 显示组套类型
        /// </summary>
        [DefaultValue(enuGroupShowType.Me)]
        public enuGroupShowType ShowType
        {
            get
            {
                return this.myShowType;
            }
            set
            {
                this.myShowType = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected Neusoft.HISFC.Models.Base.ServiceTypes inpatientType = Neusoft.HISFC.Models.Base.ServiceTypes.I;
        
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue( Neusoft.HISFC.Models.Base.ServiceTypes.I)]
        public Neusoft.HISFC.Models.Base.ServiceTypes InpatientType
        {
            get
            {
                return inpatientType;
            }
            set
            {
                inpatientType = value;
            }
        }
        
        #endregion

        #region 函数
        /// <summary>
        /// 初始化函数
        /// </summary>
        public void Init()
        {
            try
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(manager.QueryEmployeeAll());
                this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(manager.QueryDeptmentsInHos(false));

                this.RefrshGroup();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        /// <summary>
        /// 刷新组套
        /// </summary>
        public void RefrshGroup()
        {
            if (this.myShowType == enuGroupShowType.Me)
            {
                this.RefreshGroupMe();
            }
            else
            {
                this.RefreshGroupAll();
            }

        }
        Neusoft.HISFC.BizLogic.Manager.Group groupManager = new Neusoft.HISFC.BizLogic.Manager.Group();

      
        protected  void RefreshGroupMe()
        {
            this.Nodes.Clear();
            TreeNode rootNode = new TreeNode("组套");
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 1;
            rootNode.Tag = null;
            this.Nodes.Add(rootNode);

            #region 添加科室节点、个人节点
            Neusoft.HISFC.Models.Base.Employee person = (Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator;


            //添加科室组套节点
            TreeNode deptNode = new TreeNode("科室组套");
            deptNode.ImageIndex = 4;
            deptNode.SelectedImageIndex = 5;
            deptNode.Tag = null;
            rootNode.Nodes.Add(deptNode);
            //添加个人组套节点
            TreeNode perNode = new TreeNode("个人组套");
            perNode.ImageIndex = 4;
            perNode.SelectedImageIndex = 5;
            perNode.Tag = null;
            rootNode.Nodes.Add(perNode);
            //添加全院组套节点
            TreeNode allNode = new TreeNode("全院组套");
            allNode.ImageIndex = 4;
            allNode.SelectedImageIndex = 5;
            allNode.Tag = null;
            rootNode.Nodes.Add(allNode);

          
            #endregion

            #region "获得组套 获取当前科室的科室组套 当前操作员的个人组套  全院组套"

            ArrayList alFolder = this.groupManager.GetAllFirstLVFolder(InpatientType, person.Dept.ID, person.ID);

            if (alFolder == null)
            {
                return;
            }

            ArrayList al = this.groupManager.GetDeptOrderGroup(InpatientType, person.Dept.ID, person.ID);
            if (al == null)
                return;
            #endregion

            try
            {
                TreeNode node;

                Neusoft.HISFC.Models.Base.Group info;
                for (int i = 0; i < alFolder.Count; i++)
                {
                    info = alFolder[i] as Neusoft.HISFC.Models.Base.Group;
                    if (info == null)
                    {
                        continue;
                    }
                    node = new TreeNode(info.Name);
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 3;
                    node.Tag = info;
                    if (info.ParentID == "ROOT")
                    {
                        switch (info.Kind)
                        {
                            case Neusoft.HISFC.Models.Base.GroupKinds.Dept:					//科室组套						
                                this.Nodes[0].Nodes[0].Nodes.Add(node);
                                break;
                            case Neusoft.HISFC.Models.Base.GroupKinds.Doctor:					//个人组套
                                this.Nodes[0].Nodes[1].Nodes.Add(node);
                                break;
                            case Neusoft.HISFC.Models.Base.GroupKinds.All:					//全院组套
                                this.Nodes[0].Nodes[2].Nodes.Add(node);
                                break;
                        }
                    }
                    else
                    {
                        switch (info.Kind)
                        {
                            case Neusoft.HISFC.Models.Base.GroupKinds.Dept:					//科室组套						
                                //this.Nodes[0].Nodes[0].Nodes.Add(node);
                                break;
                            case Neusoft.HISFC.Models.Base.GroupKinds.Doctor:					//个人组套
                                //this.Nodes[0].Nodes[1].Nodes.Add(node);
                                break;
                            case Neusoft.HISFC.Models.Base.GroupKinds.All:					//全院组套
                                //this.Nodes[0].Nodes[2].Nodes.Add(node);
                                break;
                        }
                    }
                    ArrayList alGroup = this.groupManager.GetGroupByFolderID(info.ID);
                    if (alGroup == null || alGroup.Count <= 0)
                    {
                        continue;
                    }
                    for (int j = 0; j < alGroup.Count; j++)
                    {
                        Neusoft.HISFC.Models.Base.Group group = alGroup[j] as Neusoft.HISFC.Models.Base.Group;
                        if (group == null)
                        {
                            continue;
                        }
                        TreeNode temNode = new TreeNode(group.Name);
                        temNode.ImageIndex = 10;
                        temNode.SelectedImageIndex = 11;
                        temNode.Tag = group;
                        node.Nodes.Add(temNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                TreeNode node;
                Neusoft.HISFC.Models.Base.Group info;
                for (int i = 0; i < al.Count; i++)
                {
                    info = al[i] as Neusoft.HISFC.Models.Base.Group;
                    if (info == null)
                    {
                        continue;
                    }
                    node = new TreeNode(info.Name);
                    node.ImageIndex = 10;
                    node.SelectedImageIndex = 11;
                    node.Tag = info;
                    switch (info.Kind)
                    {
                        case Neusoft.HISFC.Models.Base.GroupKinds.Dept:					//科室组套						
                            this.Nodes[0].Nodes[0].Nodes.Add(node);
                            break;
                        case Neusoft.HISFC.Models.Base.GroupKinds.Doctor:					//个人组套

                            this.Nodes[0].Nodes[1].Nodes.Add(node);
                            break;
                        case Neusoft.HISFC.Models.Base.GroupKinds.All:					//全院组套

                            this.Nodes[0].Nodes[2].Nodes.Add(node);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.Nodes[0].Expand();
            //this.Nodes[0].Nodes[0].Expand();
            //this.Nodes[0].Nodes[1].Expand();
            //this.Nodes[0].Nodes[2].Expand();
        }
        public ArrayList AllGroup = null;
        
        /// <summary>
        /// 刷新所有组套列表
        /// </summary>
        protected void RefreshGroupAll()
        {
            this.Nodes.Clear();
            TreeNode rootNode = new TreeNode("全院组套");
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 1;
            this.Nodes.Add(rootNode);
            ArrayList al = groupManager.GetAllOrderGroup(inpatientType);
            AllGroup = al;
            if (al == null) return;

            ArrayList alDepts = new ArrayList();
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList al1= manager.GetDepartment();
            for (int i = 0; i < al1.Count; i++)
            {
                Neusoft.HISFC.Models.Base.Department obj = al1[i] as Neusoft.HISFC.Models.Base.Department;

                if (this.myType == enuType.Order)
                {
                    if (obj.DeptType.ID.ToString() == "I")
                    {
                        alDepts.Add(obj);
                    }
                }
                else if (this.myType == enuType.Fee)
                {
                    if (obj.DeptType.ID.ToString() == "N" || obj.DeptType.ToString() == "F")
                    {
                        alDepts.Add(obj);
                    }
                }
                else if (this.myType == enuType.Terminal)
                {
                    if (obj.DeptType.ID.ToString() == "T")
                    {
                        alDepts.Add(obj);
                    }
                }
            }
         
            addDept(rootNode, alDepts);
            addPerson();
            addNodes(al);
            this.Nodes[0].Expand();
        }

      

        private static void addDept(TreeNode rootNode, ArrayList alDepts)
        {
            for (int i = 0; i < alDepts.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = alDepts[i] as Neusoft.FrameWork.Models.NeuObject;
                TreeNode node = new TreeNode(obj.Name);
                node.ImageIndex = 2;
                node.SelectedImageIndex = 3;
                node.Tag = obj.ID;

                TreeNode cnode = new TreeNode("科室组套");
                cnode.ImageIndex = 4;
                cnode.SelectedImageIndex = 5;
                node.Nodes.Add(cnode);

                TreeNode cnode1 = new TreeNode("医生组套");
                cnode1.ImageIndex = 4;
                cnode1.SelectedImageIndex = 5;
                node.Nodes.Add(cnode1);

                rootNode.Nodes.Add(node);
            }
        }
        /// <summary>
        /// 添加所有人员
        /// </summary>
        private void addPerson()
        {
            for (int i = 0; i < personHelper.ArrayObject.Count; i++)
            {
                Neusoft.HISFC.Models.Base.Employee obj = personHelper.ArrayObject[i] as Neusoft.HISFC.Models.Base.Employee;
                TreeNode deptNode = this.GetDeptNodeByTag(obj.Dept.ID);
                if (deptNode == null)
                {

                }
                else
                {
                    TreeNode node = new TreeNode(obj.Name);
                    node.ImageIndex = 6;
                    node.SelectedImageIndex = 7;
                    node.Tag = obj.ID;
                    deptNode.Nodes[1].Nodes.Add(node);
                }
            }
        }

        private void addNodes(ArrayList al)
        {
            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Base.Group info = al[i] as Neusoft.HISFC.Models.Base.Group;
                TreeNode myRoot = null;
                myRoot = this.GetDeptNodeByTag(info.Dept.ID);
                if (info.Kind == Neusoft.HISFC.Models.Base.GroupKinds.Dept)//科室属性
                {
                    if (myRoot != null)
                    {
                        TreeNode node = new TreeNode(info.Name);
                        node.ImageIndex = 10;
                        node.SelectedImageIndex = 11;
                        node.Tag = info;
                        myRoot.Nodes[0].Nodes.Add(node);
                    }
                }
                else
                {
                    if (myRoot != null)
                    {
                        myRoot = this.GetDocNodeByDeptNode(myRoot, info.Doctor.ID);
                        if (myRoot != null)
                        {
                            TreeNode node = new TreeNode(info.Name);
                            node.Tag = info;
                            node.ImageIndex = 10;
                            node.SelectedImageIndex = 11;
                            myRoot.Nodes.Add(node);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 获得科室结点
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private TreeNode GetDeptNodeByTag(string tag)
        {
            foreach (TreeNode node in this.Nodes[0].Nodes)
            {
                if (node.Tag != null && node.Tag.ToString() == tag)
                {
                    return node;
                }
            }
            return null;
        }
        /// <summary>
        /// 获得人员结点
        /// </summary>
        /// <param name="deptNode"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        private TreeNode GetDocNodeByDeptNode(TreeNode deptNode, string tag)
        {
            foreach (TreeNode node in deptNode.Nodes[1].Nodes)
            {
                if (node.Tag != null && node.Tag.ToString() == tag)
                {
                    return node;
                }
            }
            return null;
        }
        #endregion

        #region 事件
        protected override void  OnMouseUp(MouseEventArgs e)
        {
 	         base.OnMouseUp(e);

             this.SelectedNode = this.GetNodeAt(e.X, e.Y);

             if (this.SelectedNode == null || this.SelectedNode.Tag == null)
                 this.LabelEdit = false;
             else
                 this.LabelEdit = true;

             if (this.SelectedNode == this.Nodes[0])
             {
                 return;
             }

             try
             {
                 if (e.Button == MouseButtons.Right)
                 {
                     if (this.SelectedNode.Tag == null)
                     {
                         //						this.treeView1.ContextMenu = null;
                         ContextMenu m = new ContextMenu();
                         MenuItem AddItem = new MenuItem("增加文件夹");
                         AddItem.Click += new EventHandler(AddItem_Click);
                         m.MenuItems.Add(AddItem);

                         MenuItem deleteItem = new MenuItem("删除");
                         deleteItem.Click += new EventHandler(deleteItem_Click);
                         m.MenuItems.Add(deleteItem);

                         this.ContextMenu = m;
                         this.ContextMenu.Show(this, new Point(e.X, e.Y));
                     }
                     else
                     {
                         if (this.SelectedNode.Tag.GetType() == typeof(Neusoft.HISFC.Models.Base.Group))
                         {
                             if ((this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group).Kind
                                 == Neusoft.HISFC.Models.Base.GroupKinds.All && !(this.groupManager.Operator
                                 as Neusoft.HISFC.Models.Base.Employee).IsManager)
                             {
                                 //ContextMenu m = new ContextMenu();
                                 //MenuItem selectItem = new MenuItem("选择");
                                 //selectItem.Click += new EventHandler(selectItem_Click);
                                 //m.MenuItems.Add(selectItem);
                                 //this.ContextMenu = m;
                                 //this.ContextMenu.Show(this, new Point(e.X, e.Y));
                             }
                             else
                             {
                                 //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
                                 Neusoft.HISFC.Models.Base.Group groupTmp = this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group;
                                 if (groupTmp.UserCode == "F")
                                 {
                                     if (this.SelectedNode.Nodes.Count > 0)
                                     {
                                         ContextMenu m = new ContextMenu();

                                         MenuItem AddItem = new MenuItem("增加文件夹");
                                         AddItem.Click += new EventHandler(AddItem_Click);
                                         m.MenuItems.Add(AddItem);

                                         this.ContextMenu = m;
                                         this.ContextMenu.Show(this, new Point(e.X, e.Y));
                                     }
                                     else
                                     {
                                         ContextMenu m = new ContextMenu();
                                         MenuItem AddItem = new MenuItem("增加文件夹");
                                         AddItem.Click += new EventHandler(AddItem_Click);
                                         m.MenuItems.Add(AddItem);

                                         MenuItem deleteItem = new MenuItem("删除");
                                         deleteItem.Click += new EventHandler(deleteItem_Click);
                                         m.MenuItems.Add(deleteItem);

                                         this.ContextMenu = m;
                                         this.ContextMenu.Show(this, new Point(e.X, e.Y));
                                     }
                                 }
                                 else
                                 {
                                     ContextMenu m = new ContextMenu();

                                     MenuItem deleteItem = new MenuItem("删除");
                                     deleteItem.Click += new EventHandler(deleteItem_Click);
                                     m.MenuItems.Add(deleteItem);
                                     this.ContextMenu = m;
                                     this.ContextMenu.Show(this, new Point(e.X, e.Y));
                                 }


                                 //ContextMenu m = new ContextMenu();
                                 ////MenuItem selectItem = new MenuItem("选择");
                                 ////selectItem.Click += new EventHandler(selectItem_Click);
                                 ////m.MenuItems.Add(selectItem);

                                 //MenuItem deleteItem = new MenuItem("删除");
                                 //deleteItem.Click += new EventHandler(deleteItem_Click);
                                 //m.MenuItems.Add(deleteItem);
                                 //this.ContextMenu = m;
                                 //this.ContextMenu.Show(this, new Point(e.X, e.Y));
                             }
                         }
                         else
                         {
                             this.ContextMenu = null;
                         }
                     }
                 }
             }
             catch { }
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
            Neusoft.HISFC.Models.Base.Group group = new Neusoft.HISFC.Models.Base.Group();
            group.ID = this.groupManager.GetNewFolderID();
            group.Name = "新建文件夹";
            group.UserType = this.inpatientType;
            if (this.SelectedNode == this.Nodes[0].Nodes[0])
            {
                group.Kind = Neusoft.HISFC.Models.Base.GroupKinds.Dept;
                group.Dept.ID = (this.groupManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                group.Doctor = this.groupManager.Operator;
                group.ParentID = "ROOT";                //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
            }
            else if (this.SelectedNode == this.Nodes[0].Nodes[1])
            {
                group.Kind = Neusoft.HISFC.Models.Base.GroupKinds.Doctor;
                group.Dept.ID = (this.groupManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                group.Doctor = this.groupManager.Operator;
                group.ParentID = "ROOT";                //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
            }
            else if (this.SelectedNode == this.Nodes[0].Nodes[2])
            {
                group.Kind = Neusoft.HISFC.Models.Base.GroupKinds.All;
                group.Dept.ID = "ALL";
                group.Doctor = this.groupManager.Operator;
                group.ParentID = "ROOT";                //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
            }
            else
            {//{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
                Neusoft.HISFC.Models.Base.Group groupSelected = this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group;

                group.Kind = groupSelected.Kind;
                group.Dept = groupSelected.Dept;

                group.Doctor = this.groupManager.Operator;
                group.ParentID = groupSelected.ID;
            }
            group.UserCode = "F";
            if (this.groupManager.SetNewFolder(group) < 0)
            {
                MessageBox.Show("增加文件夹失败！");
                return;
            }
            node.Text = group.Name;
            node.Tag = group;
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
                Neusoft.HISFC.Models.Base.Group info = this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group;
                if (info.UserCode == "F")//文件夹
                {
                    if (MessageBox.Show("是否删除文件夹" + info.Name, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (this.groupManager.deleteFolder(info) < 0)
                        {
                            MessageBox.Show(this.groupManager.Err);
                        }
                        this.RefrshGroup();
                    }
                }
                else
                {
                    if (MessageBox.Show("是否删除组套" + info.Name, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (!(this.groupManager.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager &&
                            info.Kind == Neusoft.HISFC.Models.Base.GroupKinds.All)
                        {
                            MessageBox.Show("您不是管理员,没有权限删除组套", "提示");
                            return;
                        }
                        if (this.groupManager.DeleteGroup(info) == -1)
                        {
                            MessageBox.Show(this.groupManager.Err);
                        }
                        this.RefrshGroup();
                    }
                }
            }
            catch { }
        }

        #region{3E29ADED-FB2D-4243-B525-BBDD79D85C2B}
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
        #endregion

        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {

            if (e.Label == null)
            {
                this.LabelEdit = false;
                return;
            }

            #region 更改组套名称权限控制 --2007-11-21 zhangqi

            Neusoft.HISFC.Models.Base.Group group = this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group;

            //只有管理员能修改全院和科室组套名称
            if (!(this.groupManager.Operator as Neusoft.HISFC.Models.Base.Employee).IsManager &&
                        group.Kind == Neusoft.HISFC.Models.Base.GroupKinds.All)
            {
                MessageBox.Show("只有管理员才能修改全院组套名称！");
                return;
            }
            else
            {
                DialogResult r = MessageBox.Show("节点名称已经修改，是否保存？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Cancel)
                {
                    this.LabelEdit = false;
                    //{3E29ADED-FB2D-4243-B525-BBDD79D85C2B} 
                    this.SelectedNode.Text = this.labelName;
                    this.RefrshGroup();
                    return;
                }

                if ((this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group).UserCode == "F")
                {
                    Neusoft.HISFC.Models.Base.Group tem = this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group;
                    tem.Name = e.Label;
                    if (this.groupManager.updateFolder(tem) <= 0)
                    {
                        MessageBox.Show("文件夹名称更新失败·", "提示");
                    }
                    else
                    {
                        MessageBox.Show("文件夹名称更新成功！", "提示");
                    }
                }
                else
                {
                    string GroupId = (this.SelectedNode.Tag as Neusoft.HISFC.Models.Base.Group).ID;
                    if (groupManager.UpdateGroupName(GroupId, e.Label) > 0)
                        MessageBox.Show("组套名称更新成功", "提示");
                    else
                    {
                        MessageBox.Show("更新失败", "提示");
                    }
                }
            }
            #endregion

            this.LabelEdit = false;
          
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            
            object o = this.SelectedNode.Tag;
            if (o != null)
            {
                if (o.GetType() == typeof(Neusoft.HISFC.Models.Base.Group))
                {
                    Neusoft.HISFC.Models.Base.Group info = o as Neusoft.HISFC.Models.Base.Group;
                    if (info.UserCode != "F")
                    {
                        Forms.frmSelectGroup fSelect = new Neusoft.HISFC.Components.Common.Forms.frmSelectGroup(info);

                        fSelect.InpatientType = this.inpatientType;
                        if (fSelect.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                if (SelectOrder != null)
                                    SelectOrder(fSelect.Orders);
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        //{C2922531-DEE7-43a0-AB7A-CDD7C58691BD} 多级组套 yangw 20100916
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            object o = this.SelectedNode.Tag;
            if (o != null)
            {
                if (o.GetType() == typeof(Neusoft.HISFC.Models.Base.Group))
                {
                    this.SelectedNode.Nodes.Clear();
                    Neusoft.HISFC.Models.Base.Group info = o as Neusoft.HISFC.Models.Base.Group;
                    if (info.UserCode == "F")
                    {
                        #region add by xuewj 2010-9-18 单击时递归加载树节点 {A0ED03E4-547C-49cb-8F9C-F91FF17E968C}
                        this.LoadSubNodes(info,this.SelectedNode);
                        this.SelectedNode.Expand();
                        //#region 加载此文件夹下面的咚咚

                        //ArrayList alFolder = this.groupManager.GetAllFolderByFolderID(info.ID);

                        //if (alFolder == null)
                        //{
                        //    return;
                        //}

                        //try
                        //{
                        //    TreeNode node;

                        //    Neusoft.HISFC.Models.Base.Group myGroup;
                        //    for (int i = 0; i < alFolder.Count; i++)
                        //    {
                        //        myGroup = alFolder[i] as Neusoft.HISFC.Models.Base.Group;
                        //        if (info == null)
                        //        {
                        //            continue;
                        //        }
                        //        node = new TreeNode(myGroup.Name);
                        //        node.ImageIndex = 2;
                        //        node.SelectedImageIndex = 3;
                        //        node.Tag = myGroup;


                        //        switch (myGroup.Kind)
                        //        {
                        //            case Neusoft.HISFC.Models.Base.GroupKinds.Dept:					//科室组套						
                        //                this.SelectedNode.Nodes.Add(node);
                        //                break;
                        //            case Neusoft.HISFC.Models.Base.GroupKinds.Doctor:					//个人组套
                        //                this.SelectedNode.Nodes.Add(node);
                        //                break;
                        //            case Neusoft.HISFC.Models.Base.GroupKinds.All:					//全院组套
                        //                this.SelectedNode.Nodes.Add(node);
                        //                break;
                        //        }
                        //    }
                        //    ArrayList alGroup = this.groupManager.GetGroupByFolderID(info.ID);
                        //    if (alGroup != null && alGroup.Count > 0)
                        //    {
                        //        for (int j = 0; j < alGroup.Count; j++)
                        //        {
                        //            Neusoft.HISFC.Models.Base.Group group = alGroup[j] as Neusoft.HISFC.Models.Base.Group;
                        //            if (group == null)
                        //            {
                        //                continue;
                        //            }
                        //            TreeNode temNode = new TreeNode(group.Name);
                        //            temNode.ImageIndex = 10;
                        //            temNode.SelectedImageIndex = 11;
                        //            temNode.Tag = group;
                        //            this.SelectedNode.Nodes.Add(temNode);
                        //        }
                        //    }

                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message);
                        //    return;
                        //}

                        //this.SelectedNode.Expand();

                        //#endregion
                        #endregion
                    }
                }
            }
            base.OnAfterSelect(e);
        }
        #endregion

        private void tvDoctorGroup_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = System.Windows.Forms.DragDropEffects.Move;
        }

        private void tvDoctorGroup_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Drawing.Point position = new Point(0, 0);
            position.X = e.X;
            position.Y = e.Y;
            position = this.PointToClient(position);
            TreeNode dropNode = this.GetNodeAt(position);
            this.SelectedNode = dropNode;
            this.Focus();
        }

        private void tvDoctorGroup_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //开始进行"Drag"操作
                DoDragDrop((TreeNode)e.Item, DragDropEffects.Move);
            }
        }

        private void tvDoctorGroup_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeNode temp = new TreeNode();
            //得到要移动的节点
            TreeNode moveNode = (TreeNode)e.Data.GetData(temp.GetType());
            //转换坐标为控件treeview的坐标
            Point position = new Point(0, 0);
            position.X = e.X;
            position.Y = e.Y;
            position = this.PointToClient(position);

            //得到移动的目的地的节点
            TreeNode aimNode = this.GetNodeAt(position);
            if (aimNode == null)//超出区域 返回
            {
                return;
            }
            //			if(aimNode.Parent != moveNode.Parent) //不是同一级别 返回
            //			{
            //				if(aimNode.Parent.Parent!= moveNode.Parent.Parent)
            //				{
            //					return;
            //				}
            //			}
            if (moveNode.Tag as Neusoft.HISFC.Models.Base.Group == null) //是组套父节点 返回
            {
                return;
            }
            if ((moveNode.Tag as Neusoft.HISFC.Models.Base.Group).UserCode == "F")//是文件夹节点 返回
            {
                return;
            }
            if (aimNode.Tag as Neusoft.HISFC.Models.Base.Group == null)//目标节点 是父节点
            {
                return;
            }
            if ((aimNode.Tag as Neusoft.HISFC.Models.Base.Group).UserCode != "F")//目标节点不是文件夹
            {
                return;
            }
            Neusoft.HISFC.Models.Base.Group g1 = moveNode.Tag as Neusoft.HISFC.Models.Base.Group;
            Neusoft.HISFC.Models.Base.Group g2 = aimNode.Tag as Neusoft.HISFC.Models.Base.Group;
            if (g1.Kind != g2.Kind)//科室和个人之间不允许拖
            {
                return;
            }
            if (IsDragEnable(aimNode, moveNode) == true)
            {
                if (aimNode != moveNode)
                {
                    Neusoft.HISFC.Models.Base.Group temGroup = aimNode.Tag as Neusoft.HISFC.Models.Base.Group;
                    Neusoft.HISFC.Models.Base.Group tempGroup = moveNode.Tag as Neusoft.HISFC.Models.Base.Group;

                    if (temGroup == null || tempGroup == null)
                    {
                        return;
                    }
                    try
                    {
                        if (this.groupManager.UpdateGroupFolderID(tempGroup.ID, temGroup.ID) < 0)
                        {
                            MessageBox.Show("拖动组套到文件夹失败·");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("拖动组套到文件夹失败·" + ex.Message);
                        return;
                    }
                    this.Nodes.Remove(moveNode);
                    aimNode.Nodes.Add(moveNode);
                }
            }
        }

        /// <summary>
        /// 判断是否可以拖动动目标节点，如果可以则返回true，否则为false;
        /// 判断根据是：目标节点不能是被拖动的节点的父亲节点！
        /// </summary>
        private bool IsDragEnable(TreeNode aimNode, TreeNode oriNode)
        {
            while (aimNode != null)
            {
                if (aimNode.Parent != oriNode)
                {
                    aimNode = aimNode.Parent;
                    IsDragEnable(aimNode, oriNode);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        #region add by xuewj 2010-9-18 单击时递归加载树节点 {A0ED03E4-547C-49cb-8F9C-F91FF17E968C}

        /// <summary>
        /// 递归加载树节点
        /// </summary>
        /// <param name="info">当前节点对应的组套实体</param>
        /// <param name="activeNode">当前节点</param>
        private void LoadSubNodes(Neusoft.HISFC.Models.Base.Group info,TreeNode activeNode)
        {
            ArrayList alFolder = this.groupManager.GetAllFolderByFolderID(info.ID);

            if (alFolder == null)
            {
                return;
            }

            try
            {
                TreeNode node;

                Neusoft.HISFC.Models.Base.Group myGroup;
                for (int i = 0; i < alFolder.Count; i++)
                {
                    myGroup = alFolder[i] as Neusoft.HISFC.Models.Base.Group;
                    if (myGroup == null)
                    {
                        continue;
                    }
                    node = new TreeNode(myGroup.Name);
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 3;
                    node.Tag = myGroup;


                    switch (myGroup.Kind)
                    {
                        case Neusoft.HISFC.Models.Base.GroupKinds.Dept:					//科室组套						
                            activeNode.Nodes.Add(node);
                            break;
                        case Neusoft.HISFC.Models.Base.GroupKinds.Doctor:					//个人组套
                            activeNode.Nodes.Add(node);
                            break;
                        case Neusoft.HISFC.Models.Base.GroupKinds.All:					//全院组套
                            activeNode.Nodes.Add(node);
                            break;
                    }
                    if (myGroup.UserCode == "F")
                    {
                        this.LoadSubNodes(myGroup,node);
                    }
                }
                ArrayList alGroup = this.groupManager.GetGroupByFolderID(info.ID);
                if (alGroup != null && alGroup.Count > 0)
                {
                    for (int j = 0; j < alGroup.Count; j++)
                    {
                        Neusoft.HISFC.Models.Base.Group group = alGroup[j] as Neusoft.HISFC.Models.Base.Group;
                        if (group == null)
                        {
                            continue;
                        }
                        TreeNode temNode = new TreeNode(group.Name);
                        temNode.ImageIndex = 10;
                        temNode.SelectedImageIndex = 11;
                        temNode.Tag = group;
                        activeNode.Nodes.Add(temNode);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //activeNode.Expand();
        }

        #endregion
    }
    /// <summary>
    /// 显示类型
    /// </summary>
    public enum enuGroupShowType
    {
        All = 0,
        Me = 1
    }

    /// <summary>
    /// 门诊or住院
    /// </summary>
    public enum enuInpatientType
    {
        C = 0,//门诊
        I = 1 //住院
    }
    /// <summary>
    /// 组套
    /// </summary>
    public enum enuType
    {
        Order = 0,
        Fee = 1,
        Terminal = 2
    }
}
