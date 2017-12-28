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
    /// [功能描述: 组套维护]<br></br>
    /// [创 建 者: 薛占广]<br></br>
    /// [创建时间: 2006－12－12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucGroupDetail :FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucGroupDetail()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 是否只对一个科室进行组套操作
        /// </summary>
        private bool isDeptOnly = true;
        
        /// <summary>
        /// 是否为非药品
        /// </summary>
        private bool isUndrug = false;

        /// <summary>
        /// 当前登陆科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject deptInfo;

     #endregion

        #region 枚举
        #region cols
        /// <summary>
		/// 列枚举
		/// </summary>
		private enum Cols {
			ItemName,//项目名称
			Price,//价格
			Qty,//数量
			Unit,//单位
			Dept,//执行科室
			Combo,//组合号
			Memo,//备注
			OperCode,//操作员
			OperDate,//操作日期
			SortId//排序号
		}
		#endregion

        #endregion

        #region 业务层变量
        /// <summary>
        /// 组套管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.ComGroup grpMgr = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
        /// <summary>
        /// 执行科室列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbDept = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        #endregion

        /// <summary>
        /// 项目列表
        /// </summary>        
        private Neusoft.HISFC.Components.Common.Controls.ucItemList ItemList;   
        //存储所有组套
        private ArrayList iGroups = new ArrayList();

        #region 属性
        /// <summary>
        /// 是否只对当前操作员登陆科室进行组套操作
        /// </summary>
        public bool IsDeptOnly
        {
            get
            {
                return this.isDeptOnly;
            }
            set
            {
                this.isDeptOnly = value;
            }
        }
        /// <summary>
        /// 是否为非药品
        /// </summary>
        public bool IsUndrug
        {
            set
            {
                this.isUndrug = value;
            }
        }
       
        /// <summary>
        /// 当前登陆科室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject DeptInfo
        {
            get
            {
                if (this.deptInfo != null)
                    this.deptInfo = new Neusoft.FrameWork.Models.NeuObject();
                return this.deptInfo;
            }
            set
            {
                this.deptInfo = value;
            }
        }
        #endregion

        #region 工具栏
        /// <summary>
        /// 定义工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("添加组套", "添加组套", 0, true, false, null);
            toolBarService.AddToolButton("删除组套","删除组套",1,true,false,null);
            toolBarService.AddToolButton("添加明细", "添加明细", 2, true, false, null);
            toolBarService.AddToolButton("删除明细", "删除明细", 3, true, false, null);
            toolBarService.AddToolButton("另存", "另存", 6, true, false, null);
             
            return toolBarService;
        }
        /// <summary>
        /// 退出方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Exit(object sender, object neuObject)
        {
            return base.Exit(sender, neuObject);
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        public override int Save(object sender, object neuObject)
        {
            //保存方法
            Save();
            return base.Save(sender, neuObject);
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text.Trim())
            {
                case "添加组套":
                    AddGroup();
                    break;
                case "删除组套":
                    DelGroup();
                    break;
                case "添加明细":
                    AddGroupDetail();
                    break;
                case "删除明细":
                    DelGroupDetail();
                    break;             
                case "另存":
                    SaveAs();
                    break;
                default:
                    break;
                    
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int ucInit()
        {
            this.FindForm().KeyPreview = true;
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在载入数据,请稍候...");
                Application.DoEvents();

                //初始化科室列表 获取执行科室时调用
                this.InitDeptList();
                
                //如果是对一个科室操作
                if (this.isDeptOnly)
                {
                    this.deptInfo = (grpMgr.Operator as Neusoft.HISFC.Models.Base.Employee).Dept;
                    //只对一个科室进行组套操作 只获取一个科室的组套列表
                    this.neuTreeView1.Nodes.Clear();
                    TreeNode node = new TreeNode();
                    node.Text = this.deptInfo.Name;
                    node.Tag = this.deptInfo;//当前登陆科室
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;

                    this.neuTreeView1.Nodes.Add(node);
                    //当前登陆科室node作为根结点
                    //根据科室ID添加科室组套
                    this.AddDeptGroup(node, this.deptInfo.ID);

                    //设置当前执行科室显示信息
                    this.cmbDept.Tag = this.deptInfo.ID;
                    this.cmbDept.Text = this.deptInfo.Name;
                    this.cmbDept.Enabled = false;
                    this.neuTreeView1.ExpandAll();
                }
                else
                {	//可查看全院科室组套 并可另存为
                    this.GetAllGroups();
                    this.InitTree();                    
                    this.cmbDept.IsListOnly = true;
                }

                // 设置farpoint响应键盘录入
                this.InitFP();

                #region 添加科室列表控件
                Controls.Add(lbDept);
                lbDept.Hide();
                lbDept.BorderStyle = BorderStyle.FixedSingle;
                lbDept.BringToFront();
               // lbDept.SelectedIndexChanged += new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup.SelectedIndexCollection(lbDept_SelectItem);
                lbDept.ItemSelected += new EventHandler(lbDept_ItemSelected);
            #endregion

                #region 添加项目列表控件
                ItemList = new ucItemList();//{1FA0BCB8-3325-4db1-A9E2-74CE8453810E}
                Controls.Add(ItemList);//{1FA0BCB8-3325-4db1-A9E2-74CE8453810E}
                //如果是非药品
                if (this.isUndrug)
                {
                    //ItemList = new ucItemList(EnumShowItemType.Undrug);{1FA0BCB8-3325-4db1-A9E2-74CE8453810E}
                    ItemList.enuShowItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.Undrug;//非药品
                        
                }
                else
                {
                    //ItemList = new ucItemList(EnumShowItemType.All);{1FA0BCB8-3325-4db1-A9E2-74CE8453810E}
                    ItemList.enuShowItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.All;//全部
                }
                ItemList.Init(string.Empty);//{1FA0BCB8-3325-4db1-A9E2-74CE8453810E}
                ItemList.Hide();
                ItemList.BringToFront();

                /* [2007/01/27]
                 * 原来是注释掉的,不知道为什么.
                 */
                //ItemList.Init("");

                ItemList.SelectItem += new Neusoft.HISFC.Components.Common.Controls.ucItemList.MyDelegate(ItemList_SelectItem);
                #endregion

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch(Exception a)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(a.Message);
            }

            return 0;
        }
        
        /// <summary>
        /// 选择执行科室
        /// </summary>
        /// <returns></returns>
        private int SelectDept()
        {
            int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
            if (CurrentRow < 0) return 0;

            fpSpread1.StopCellEditing();
            Neusoft.FrameWork.Models.NeuObject item = null;
            item = lbDept.GetSelectedItem();
            if (item == null) return -1;

            fpSpread1_Sheet1.SetTag(CurrentRow, (int)Cols.Dept, item.ID);
            fpSpread1_Sheet1.SetValue(CurrentRow, (int)Cols.Dept, item.Name, false);

            lbDept.Visible = false;

            return 0;
        }

        /// <summary>
        /// 生成科室树形列表
        /// </summary>
        /// <returns></returns>
        private int InitTree()
        {
            this.neuTreeView1.Nodes.Clear();
            //科室类型
            ArrayList deptTypes = Neusoft.HISFC.Models.Base.DepartmentTypeEnumService.List();

            //一级为科室类型
            foreach (Neusoft.FrameWork.Models.NeuObject obj in deptTypes)
            {
                TreeNode node = new TreeNode();
                node.Text = obj.Name;//科室类型名称
                node.Tag = obj;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;

                this.neuTreeView1.Nodes.Add(node);
                //添加科室类型包含的科室     
                if (AddDepts(obj, node) == -1) return -1;
            }
            return 0;
        }

        /// <summary>
        /// 生成科室列表
        /// </summary>
        /// <returns></returns>
        private int InitDeptList()
        {
            try
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList depts = deptManager.GetDeptmentAll();
                if (depts == null || depts.Count == 0) return -1;

                //所属科室ComboBox添加科室
                cmbDept.AddItems(depts);
                //在执行科室NeuListBoxPopup中添加科室
                lbDept.AddItems(depts);

            }
            catch (Exception e)
            {
                MessageBox.Show("添加科室列表时出错!" + e.Message, "提示");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 添加科室类型包含的科室
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        private int AddDepts(Neusoft.FrameWork.Models.NeuObject type, TreeNode parent)
        {
            try
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                //获取type类型科室
                ArrayList depts = deptManager.GetDeptmentByType(type.ID);
                if (depts == null) return 0;
                //添加科室
                foreach (Neusoft.HISFC.Models.Base.Department dept in depts)
                {
                    TreeNode child = new TreeNode();
                    child.Text = dept.Name;
                    child.Tag = dept;
                    child.ImageIndex = 3;
                    child.SelectedImageIndex = 3;

                    parent.Nodes.Add(child);
                    AddGroups(child, dept.ID);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("获取科室列表出错!" + e.Message, "提示");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 显示组套信息
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private int ShowGroup(Neusoft.HISFC.Models.Fee.ComGroup group)
        {
            txtName.Text = group.Name;
            txtName.Tag = group;
            txtInput.Text = group.inputCode;
            txtSpell.Text = group.spellCode;
            txtMemo.Text = group.reMark;

            if (group.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                chkValid.Checked = true;
            else
                chkValid.Checked = false;

            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDeptmentById(group.deptCode);
            if (dept == null)
                cmbDept.Text = group.deptCode;
            else
                cmbDept.Text = dept.Name;

            return 0;
        }

        /// <summary>
        /// 显示组套明细
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        private int ShowDetail(string groupID)
        {
            Neusoft.HISFC.BizLogic.Manager.ComGroupTail detailManager = new Neusoft.HISFC.BizLogic.Manager.ComGroupTail();
            //组套明细
            ArrayList details = detailManager.GetComGroupTailByGroupID(groupID);
            if (details == null)
            {
                MessageBox.Show("提取组套明细失败 " + detailManager.Err);
                return -1;
            }

            if (fpSpread1_Sheet1.Rows.Count > 0)
                fpSpread1_Sheet1.Rows.Remove(0, fpSpread1_Sheet1.Rows.Count);
            foreach (Neusoft.HISFC.Models.Fee.ComGroupTail detail in details)
            {
                AddDetailToFP(detail);
            }
            return 0;
        }

        /// <summary>
        /// 清空显示组套信息
        /// </summary>
        /// <returns></returns>
        private int Clear()
        {
            txtName.Text = "";
            txtName.Tag = null;
            txtInput.Text = "";
            txtSpell.Text = "";
            chkValid.Checked = true;
            txtMemo.Text = "";
            if (!this.isDeptOnly)
                cmbDept.Text = "";

            if (fpSpread1_Sheet1.Rows.Count > 0)
                fpSpread1_Sheet1.Rows.Remove(0, fpSpread1_Sheet1.Rows.Count);

            return 0;
        }

        #region 获取组套
        /// <summary>
        /// 读取所有组套
        /// </summary>
        /// <returns></returns>
        private int GetAllGroups()
        {
            Neusoft.HISFC.BizLogic.Manager.ComGroup groupManager = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
            try
            {
                //iGroups = groupManager.GetAllGroups();
                iGroups = groupManager.GetAllGroupsByRoot("1");
            }
            catch (Exception e)
            {
                if (iGroups == null) iGroups = new ArrayList();
                MessageBox.Show("调用HISFC.Manager.ComGroup.GetAllGroups()出错!" + e.Message);
                return -1;
            }
            if (iGroups == null) iGroups = new ArrayList();

            return 0;
        }

        /// <summary>
        /// 添加科室下组套列表
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="deptID"></param>						
        private int AddGroups(TreeNode parent, string deptID)
        {
            foreach (Neusoft.HISFC.Models.Fee.ComGroup group in iGroups)
            {
                if (group.deptCode == deptID)
                {
                    //AddGroup(parent, group);
                    this.AddGroupsRecursion(parent, group);
                }
            }

            //AddGroupsRecursion(parent, deptID, "ROOT");
            return 0;
        }

        private int AddGroupsRecursion(TreeNode parent, Neusoft.HISFC.Models.Fee.ComGroup group)
        {

            ArrayList al = this.grpMgr.GetGroupsByDeptParent("1", group.deptCode, group.ID);
            if (al.Count == 0)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = group;
                newNode.Text = group.Name;// +"[" + group.ID + "]";
                parent.Nodes.Add(newNode);
                
                return -1;
            }
            else
            {
                #region donggq.--2010.09.28--{5461FEE6-FDEC-49c6-BE84-6015D1965878}--修改了组套递归
                
                TreeNode newNode = new TreeNode();
                newNode.Tag = group;
                newNode.Text = group.Name;// +"[" + group.ID + "]";
                parent.Nodes.Add(newNode); 

                #endregion
                
                foreach (Neusoft.HISFC.Models.Fee.ComGroup item in al)
                {
                    //if (item.ID == "aaa")
                    //{
                    //    MessageBox.Show("aaa");
                    //}


                    #region 原来的
                    //TreeNode newNode = new TreeNode ();
                    //newNode.Tag = group;
                    //newNode.Text = group.Name;// +"[" + group.ID + "]";
                    //parent.Nodes.Add(newNode);
                    //return this.AddGroupsRecursion(newNode, item); 
                    #endregion

                    #region donggq.--2010.09.28--{5461FEE6-FDEC-49c6-BE84-6015D1965878}--修改了组套递归
                    this.AddGroupsRecursion(newNode, item);
                    #endregion
                }
            }

            return 1;
        }

        /// <summary>
        /// 根据科室ID 添加科室组套
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <param name="deptID">科室编码</param>
        /// <returns>成功返回1 出错返回－1 无数据返回0</returns>
        private int AddDeptGroup(TreeNode parent, string deptID)
        {
            Neusoft.HISFC.BizLogic.Manager.ComGroup groupManager = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
            //ArrayList al = new ArrayList();
            ////根据科室获得所有组套
            //al = groupManager.GetAllGroupList(deptID);
            //if (al == null || al.Count == 0)
            //    return 0;
            //foreach (Neusoft.HISFC.Models.Fee.ComGroup group in al)
            //{
            //    //添加组套
            //    this.AddGroup(parent, group);
            //}
            ArrayList al = new ArrayList();
            //根据科室获得所有组套
            al = groupManager.GetAllGroupsByRoot("1");

            ArrayList alDeptList = new ArrayList();

            foreach (Neusoft.HISFC.Models.Fee.ComGroup item in al)
            {
                if (item.deptCode == deptID)
                {
                    alDeptList.Add(item);
                }
            }


            if (alDeptList == null || alDeptList.Count == 0)
                return 0;
            foreach (Neusoft.HISFC.Models.Fee.ComGroup group in alDeptList)
            {
                this.AddGroupsRecursion(parent, group);
            }
            return 1;
        }

        /// <summary>
        ///添加组套 
        /// </summary>
        /// <param name="parent">TreeNode</param>
        /// <param name="group">组套实体</param>
        /// <returns>0</returns>
        private int AddGroup(TreeNode parent, Neusoft.HISFC.Models.Fee.ComGroup group)
        {
            TreeNode node = new TreeNode();
            node.Tag = group;
            node.Text = group.Name;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 2;

            //if (this.isDeptOnly)
            //    this.neuTreeView1.Nodes[0].Nodes.Add(node);
            //else
                parent.Nodes.Add(node);
            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
            //this.AddGroupsRecursion(parent, group);
            this.neuTreeView1.SelectedNode = node;

            return 0;
        }

        #endregion

        #region 显示组套
        /// <summary>
        /// 添加明细到farpoint
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private int AddDetailToFP(Neusoft.HISFC.Models.Fee.ComGroupTail detail)
        {
            fpSpread1_Sheet1.Rows.Add(fpSpread1_Sheet1.Rows.Count, 1);
            int row = fpSpread1_Sheet1.Rows.Count - 1;

            if (detail.drugFlag == "1")
            {
                //药品进销存管理类
                Neusoft.HISFC.BizLogic.Pharmacy.Item drugManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
                //根据药品编码获得某一药品信息
                Neusoft.HISFC.Models.Pharmacy.Item drug = drugManager.GetItem(detail.itemCode);
                if (drug == null)//没找到
                {
                    drug = new Neusoft.HISFC.Models.Pharmacy.Item();
                    drug.Name = "帐目表中无该项目";
                }
                //如果规格不为空
                if (drug.Specs != null && drug.Specs != "")
                    drug.Name = drug.Name + "{" + drug.Specs + "}";

                fpSpread1_Sheet1.SetValue(row, (int)Cols.ItemName, drug.Name, false);//项目名称
                fpSpread1_Sheet1.SetValue(row, (int)Cols.Price, drug.Price, false);//价格
                fpSpread1_Sheet1.SetValue(row, (int)Cols.Unit, drug.PriceUnit, false);//单位
            }
            else
            {
                Neusoft.HISFC.BizLogic.Fee.Item undrugManager = new Neusoft.HISFC.BizLogic.Fee.Item();

                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = undrugManager.GetValidItemByUndrugCode(detail.itemCode);
                if (undrug == null)
                {//没找到
                    undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                    undrug.Name = "帐目表中无该项目";
                }
                fpSpread1_Sheet1.SetValue(row, (int)Cols.ItemName, undrug.Name, false);//项目名称
                fpSpread1_Sheet1.SetValue(row, (int)Cols.Price, undrug.Price, false);//价格
                fpSpread1_Sheet1.SetValue(row, (int)Cols.Unit, undrug.PriceUnit, false);//单位
            }

            //项目代码
            fpSpread1_Sheet1.SetTag(row, (int)Cols.ItemName, detail.itemCode);

            fpSpread1_Sheet1.SetValue(row, 2, detail.qty, false);//数量
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Dept, detail.deptName, false);//执行科室
            fpSpread1_Sheet1.SetTag(row, (int)Cols.Dept, detail.deptCode);//执行科室代码

            fpSpread1_Sheet1.SetValue(row, (int)Cols.Combo, detail.combNo, false);//组合号
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Memo, detail.reMark, false);//备注
            fpSpread1_Sheet1.SetValue(row, (int)Cols.OperCode, detail.operCode, false);//操作员
            fpSpread1_Sheet1.SetValue(row, (int)Cols.OperDate, detail.OperDate.ToString(), false);//操作时间
            fpSpread1_Sheet1.SetValue(row, (int)Cols.SortId, (decimal)detail.SortNum, false); //序号 
            fpSpread1_Sheet1.Rows[row].Tag = detail.drugFlag;
            return 0;
        }

        #endregion

        /// <summary>
        /// 设置farpoint响应键盘录入
        /// </summary>
        private void InitFP()
        {
            FarPoint.Win.Spread.InputMap im;
            im = this.fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = this.fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.PageUp, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            
            im = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            im.Put(new FarPoint.Win.Spread.Keystroke(Keys.PageDown, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }          

        #region FarPoint操作

        /// <summary>
        /// 设置项目列表、科室列表位置
        /// </summary>
        /// <returns></returns>
        private int SetLocation()
        {
            Control _cell = fpSpread1.EditingControl;
            if (_cell == null) return 0;

            if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.ItemName)
            {
                int y = this.splitContainer2.Location.Y + this.splitContainer2.Panel1.Height + _cell.Location.Y + _cell.Height + ItemList.Height + 7;
                if (y <= this.Height)
                    ItemList.Location = new Point(this.splitContainer1.Panel1.Width+ _cell.Location.X+10, y - ItemList.Height);
                else
                    ItemList.Location = new Point(this.splitContainer1.Panel1.Width + _cell.Location.X+10, this.splitContainer2.Panel1.Height+ _cell.Location.Y - ItemList.Height - 7);
            }
            else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.Dept)
            {
                lbDept.Location = new Point(this.splitContainer1.Panel1.Width + _cell.Location.X+10,
                    this.splitContainer2.Location.Y + this.splitContainer2.Panel1.Height + _cell.Location.Y + _cell.Height + SystemInformation.Border3DSize.Height * 2);
                lbDept.Size = new Size(_cell.Width + SystemInformation.Border3DSize.Width * 2, 150);
            }
            return 0;
        }

        /// <summary>
        /// 选择项
        /// </summary>
        /// <returns></returns>
        private int SelectItem()
        {
            if (ItemList.Visible == false)
            {
                ItemList.Visible = true;
                return 0;
            }
            try
            {
                fpSpread1.StopCellEditing();
                Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item();

                int rtn = ItemList.GetSelectItem(out item);
                if (rtn == -1 || rtn == 0) return -1;
                int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                if (CurrentRow < 0) return -1;
                //传入对象，填充FarPoint
                AddDetailToFP(item, CurrentRow);
                fpSpread1.Focus();
                fpSpread1_Sheet1.SetActiveCell(CurrentRow, (int)Cols.Qty, false);

                ItemList.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示");
                fpSpread1.Focus();
                fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemName, true);
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 选择项，传入当前行
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private int SelectItem(int row)
        {
            ItemList.SetCurrentRow(row);
            if (SelectItem() == -1) return -1;
            return 0;
        }
        /// <summary>
        /// 根据传入对象填充FarPoint
        /// 添加明细到FarPoint
        /// </summary>
        /// <param name="item"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int AddDetailToFP(Neusoft.HISFC.Models.Base.Item item, int row)
        {
            //项目价格
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Price, item.Price, false);
            //数量
            fpSpread1_Sheet1.SetText(row, (int)Cols.Qty, "1");
            //单位
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Unit, item.PriceUnit, false);
            //执行科室，为空
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Dept, "", false);
            //组合号
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Combo, "", false);
            //备注
            fpSpread1_Sheet1.SetValue(row, (int)Cols.Memo, "", false);
            //项目名称
            //if (item.IsPharmacy)
            if(item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
            {
                if (item.Specs != null && item.Specs != "")
                    fpSpread1_Sheet1.SetValue(row, (int)Cols.ItemName, item.Name + "{" + item.Specs + "}", false);
                else
                    fpSpread1_Sheet1.SetValue(row, (int)Cols.ItemName, item.Name, false);
            }
            else
                fpSpread1_Sheet1.SetValue(row, (int)Cols.ItemName, item.Name, false);
            //项目代码
            fpSpread1_Sheet1.SetTag(row, (int)Cols.ItemName, item.ID);

            //if (item.IsPharmacy)
            if(item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                fpSpread1_Sheet1.Rows[row].Tag = "1";
            else
                fpSpread1_Sheet1.Rows[row].Tag = "2";

            return 0;
        }


        #endregion

        #region 添加、删除组套明细
        /// <summary>
        /// 添加一条组套明细
        /// </summary>
        /// <returns></returns>
        public int AddGroupDetail()
        {
           this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.Rows.Count, 1);
           this.fpSpread1.Focus();           
           this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.Rows.Count - 1, 0);
          
                return 0; 
        }
        /// <summary>
        /// 删除一条组套明细
        /// </summary>
        /// <returns></returns>
        public int DelGroupDetail()
        {
            int row = fpSpread1_Sheet1.ActiveRowIndex;
            if (row < 0 || fpSpread1_Sheet1.RowCount == 0) return 0;

            string name = fpSpread1_Sheet1.GetText(row, (int)Cols.ItemName);
            if (MessageBox.Show("是否删除" + name + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                this.fpSpread1.StopCellEditing();
                fpSpread1_Sheet1.Rows.Remove(row, 1);
            }
            return 0;
        }

        #endregion

        #region 添加、删除组套
        /// <summary>
        /// 删除选中的组套
        /// </summary>
        /// <returns></returns>
        public int DelGroup()
        {
            TreeNode currNode = this.neuTreeView1.SelectedNode;

            //{C1B7688D-CFB1-4d7e-A4DA-E909B64B66D3}
            if (currNode.Nodes.Count > 0)
            {
                MessageBox.Show("该节点下还有组套节点，请从最底层节点开始删除!");
                return -1;
            }

            //当前没有选中项，返回
            if (currNode == null) return 0;
            //选中的不是组套，返回
            if (currNode.Tag.GetType() != typeof(Neusoft.HISFC.Models.Fee.ComGroup)) return 0;

            Neusoft.HISFC.Models.Fee.ComGroup group = currNode.Tag as Neusoft.HISFC.Models.Fee.ComGroup;
            //确认删除?
            if (MessageBox.Show("是否删除组套:" + group.Name + "?", "提示", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No) return 0;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Manager.ComGroup grpManager=new Neusoft.HISFC.BizLogic.Manager.ComGroup();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(grpManager.Connection);
            //t.BeginTransaction();//开始事务           
            
            //grpManager.SetTrans(t.Trans);
            try
            {
                //删除组套信息
                if (grpManager.DeleteComGroup(group) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除组套信息表时出错!" + grpManager.Err, "提示");
                    return -1;
                }
                //删除组套明细
                if (grpManager.DelGroupDetails(group.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除组套明细表时出错!" + grpManager.Err, "提示");
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("删除组套信息表时出错!" + e.Message, "提示");
                return -1;
            }
            this.neuTreeView1.Nodes.Remove(currNode);
            MessageBox.Show("组套删除成功!", "提示");

            return 0;
        }


        /// <summary>
        /// 添加组套
        /// </summary>
        /// <returns></returns>
        public int AddGroup()
        {
            Clear();
            AddGroupDetail();
            txtName.Focus();
            return 0;
        }
        /// <summary>
        /// 添加组套
        /// </summary>
        /// <param name="details">ArrayList数组</param>
        /// <param name="deptID">部门ID</param>
        /// <returns></returns>
        public int AddGroup(ArrayList details, string deptID)
        {           
           this.splitContainer1.Panel1.Hide();
            Clear();
            this.cmbDept.Tag = deptID;

            foreach (Neusoft.HISFC.Models.Fee.ComGroupTail detail in details)
            {
                this.AddDetailToFP(detail);
            }
            this.txtName.Focus();

            return 0;
        }
        #endregion


        #region 保存
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            this.fpSpread1.StopCellEditing();

            if (Valid() == -1) return -1;
            
            //组套管理类
            //Neusoft.HISFC.BizLogic.Manager.ComGroup grpMgr = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
            //事务
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(grpMgr.Connection);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //组套明细管理类
            Neusoft.HISFC.BizLogic.Manager.ComGroupTail detailMgr = new Neusoft.HISFC.BizLogic.Manager.ComGroupTail();
            grpMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            detailMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //获取组套代码
            object obj = txtName.Tag;
            string groupID = "";
            if (obj == null)//新组套
                groupID = detailMgr.getGroupID();
            else
                groupID = (obj as Neusoft.HISFC.Models.Fee.ComGroup).ID;

            //生成组套实体
           // Neusoft.HISFC.Models.Fee.ComGroup group = AddGroupInstance(groupID, Neusoft.FrameWork.Management.Connection.Operator.ID);
            Neusoft.HISFC.Models.Fee.ComGroup group = AddGroupInstance(groupID, Neusoft.FrameWork.Management.Connection.Operator.ID,obj);
            int count = 0;

            try
            {
                if (obj != null)
                {//删除原来组套
                    #region 删除原来组套
                    //删除组套信息
                    if (grpMgr.DeleteComGroup(group) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("删除组套信息表时出错!" + grpMgr.Err, "提示");
                        return -1;
                    }
                    //删除组套明细
                    if (grpMgr.DelGroupDetails(group.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("删除组套明细表时出错!" + grpMgr.Err, "提示");
                        return -1;
                    }
                    #endregion
                }
                //插入组套
                if (grpMgr.InsertInToComGroup(group) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入组套信息表出错!" + grpMgr.Err, "提示");
                    return -1;
                }
                //循环组套明细
                for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                {
                    if (fpSpread1_Sheet1.GetTag(i, (int)Cols.ItemName) == null || fpSpread1_Sheet1.GetTag(i, (int)Cols.ItemName).ToString()
                        == "") continue;
                    //赋值组套明细实体
                    Neusoft.HISFC.Models.Fee.ComGroupTail detail = AddGrpDetailInstance(i, groupID, Neusoft.FrameWork.Management.Connection.Operator.ID);
                    if (detail == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                    //插入组套明细
                    if (detailMgr.InsertDataIntoComGroupTail(detail) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入组套明细表时出错!" + detailMgr.Err, "提示");
                        return -1;
                    }
                    count++;
                }
                //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
                //if (count == 0)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show("请录入组套明细!", "提示");
                //    return -1;
                //}
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存组套时出错!" + e.Message, "提示");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //刷新树形列表
            if (obj == null)
            {
                //如果是新增组套，则在相应科室下面添加一个新节点
                //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
                //TreeNode node = FindNode(cmbDept.Tag.ToString());
                TreeNode node = this.neuTreeView1.SelectedNode;//FindNode(cmbDept.Tag.ToString());
                if (this.isDeptOnly)
                    this.AddGroup(node, group);
                else
                {

                    if (node != null) AddGroup(node, group);
                }
            }
            else
            {
                //如果是修改的组套，则修改节点的属性 
                this.neuTreeView1.SelectedNode.Tag = group;
                this.neuTreeView1.SelectedNode.Text = group.Name;
            }

            MessageBox.Show("保存成功!", "提示");
            txtName.Focus();

            return 0;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        private int Valid()
        {
            if (txtName.Text == null || txtName.Text == "")
            {
                MessageBox.Show("组套名称不能为空!", "提示");
                txtName.Focus();
                return -1;
            }
            if (cmbDept.Tag == null || cmbDept.Tag.ToString() == "")
            {
                MessageBox.Show("组套所属科室不能为空!", "提示");
                cmbDept.Focus();
                return -1;
            }
            string groupID = "";
            if (txtName.Tag != null)
            {
                Neusoft.HISFC.Models.Fee.ComGroup oldGroup = (Neusoft.HISFC.Models.Fee.ComGroup)txtName.Tag;
                groupID = oldGroup.ID;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txtName.Text, 50))
            {
                MessageBox.Show("组套名称过长!", "提示");
                txtName.Focus();
                return -1;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txtInput.Text, 8))
            {
                MessageBox.Show("助记码过长!", "提示");
                txtInput.Focus();
                return -1;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txtSpell.Text, 8))
            {
                MessageBox.Show("拼音码过长!", "提示");
                txtInput.Focus();
                return -1;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txtMemo.Text, 150))//{AC9872BD-F749-43a1-A31C-511352A198D6}
            {
                MessageBox.Show("备注过长!", "提示");
                txtInput.Focus();
                return -1;
            }
            ArrayList list = this.grpMgr.QueryGroupsByName(this.txtName.Text, cmbDept.Tag.ToString());
            foreach (Neusoft.HISFC.Models.Fee.ComGroup obj in list)
            {
                if (groupID != "")
                {
                    if (obj.ID != groupID)
                    {
                        MessageBox.Show(txtName.Text + "已经存在,请更换");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show(txtName.Text + "已经存在,请更换");
                    return -1;
                }
            }
            return 0;
        }

        /// <summary>
        /// 查找代码为deptID的科室节点
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        private TreeNode FindNode(string deptID)
        {
            foreach (TreeNode parent in this.neuTreeView1.Nodes)
            {
                foreach (TreeNode dept in parent.Nodes)
                {
                    if (dept.Tag.GetType() == typeof(Neusoft.HISFC.Models.Base.Department))
                    {
                        if ((dept.Tag as Neusoft.HISFC.Models.Base.Department).ID == deptID)
                        {
                            return dept;
                        }
                    }
                }
            }
            
            return null;
        }

        /// <summary>
        /// 查找代码为deptID的科室节点
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        private TreeNode FindNodeByGroupID(string groupID)
        {
            foreach (TreeNode parent in this.neuTreeView1.Nodes)
            {
                TreeNode node= FindNodeResu(parent, groupID);
                if (node == null) continue;
                return node;
            }

            return null;
        }
        //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
        private TreeNode FindNodeResu(TreeNode parentNode, string groupID)
        {
            if (parentNode.Tag.GetType() == typeof(Neusoft.FrameWork.Models.NeuObject)) //科室类型一级
            {
                foreach (TreeNode item in parentNode.Nodes)
                {
                    if (item.Nodes.Count > 0)
                    {
                        TreeNode tn = this.FindNodeResu(item, groupID);

                        if (tn == null)
                        {
                            continue;
                        }
                        else
                        {
                            return tn;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            else if (parentNode.Tag.GetType() == typeof(Neusoft.HISFC.Models.Base.Department)) //科室一级
            {
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if ((node.Tag as Neusoft.HISFC.Models.Fee.ComGroup).ID == groupID)
                    {
                        return node;
                    }
                    else
                    {
                        if (node.Nodes.Count > 0)
                        {
                            TreeNode tNode = this.FindNodeResu(node, groupID);
                            if (tNode == null)
                            {
                                continue;
                            }
                            else
                            {

                                return tNode;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

            }
            else
            {
                foreach (TreeNode node in parentNode.Nodes)//组套级
                {
                    if ((node.Tag as Neusoft.HISFC.Models.Fee.ComGroup).ID == groupID)
                    {
                        return node;
                    }
                    else
                    {
                        if (node.Nodes.Count > 0)
                        {
                            TreeNode tN =  this.FindNodeResu(node, groupID);
                            if (tN == null)
                            {
                                continue;
                            }
                            else
                            {
                                return tN;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }


            }
            return null;

        }
         

        /// <summary>
        ///生成组套实体
        /// </summary>
        /// <param name="newID"></param>
        /// <param name="OperID"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Fee.ComGroup AddGroupInstance(string newID, string OperID)
        {
            Neusoft.HISFC.Models.Fee.ComGroup group = new Neusoft.HISFC.Models.Fee.ComGroup();
            group.ID = newID;//组套ID
            group.Name = txtName.Text;//组套名称
            group.inputCode = txtInput.Text;//助记码
            group.spellCode = txtSpell.Text;//拼音码
            group.groupKind = "1";//组套类型
            group.deptCode = cmbDept.Tag.ToString();//组套科室
            group.deptName = cmbDept.Tag.ToString();
            group.reMark = txtMemo.Text;//备注
            group.operCode = OperID;//操作员ID
            //有效
            if (chkValid.Checked)
                group.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;//有效标志1有效2无效
            else
                group.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
            if (this.neuTreeView1.SelectedNode.Tag.GetType() != typeof(Neusoft.HISFC.Models.Fee.ComGroup))
            {
                group.ParentGroupID = "ROOT";
            }
            else
            {
                Neusoft.HISFC.Models.Fee.ComGroup comGroup = this.neuTreeView1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.ComGroup;
                group.ParentGroupID = comGroup.ID;
            }
            return group;
        }

        private Neusoft.HISFC.Models.Fee.ComGroup AddGroupInstance(string newID, string OperID,object obj)
        {
            Neusoft.HISFC.Models.Fee.ComGroup group = new Neusoft.HISFC.Models.Fee.ComGroup();
            group.ID = newID;//组套ID
            group.Name = txtName.Text;//组套名称
            group.inputCode = txtInput.Text;//助记码
            group.spellCode = txtSpell.Text;//拼音码
            group.groupKind = "1";//组套类型
            group.deptCode = cmbDept.Tag.ToString();//组套科室
            group.deptName = cmbDept.Tag.ToString();
            group.reMark = txtMemo.Text;//备注
            group.operCode = OperID;//操作员ID
            //有效
            if (chkValid.Checked)
                group.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;//有效标志1有效2无效
            else
                group.ValidState = Neusoft.HISFC.Models.Base.EnumValidState.Invalid;
            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
            if (obj == null)
            {
                if (this.neuTreeView1.SelectedNode.Tag.GetType() != typeof(Neusoft.HISFC.Models.Fee.ComGroup))
                {
                    group.ParentGroupID = "ROOT";
                }
                else
                {
                    Neusoft.HISFC.Models.Fee.ComGroup comGroup = this.neuTreeView1.SelectedNode.Tag as Neusoft.HISFC.Models.Fee.ComGroup;
                    group.ParentGroupID = comGroup.ID;
                }
            }
            else
            {
                if (this.neuTreeView1.SelectedNode.Parent.Tag.GetType() != typeof(Neusoft.HISFC.Models.Fee.ComGroup))
                {
                    group.ParentGroupID = "ROOT";
                }
                else
                {
                    Neusoft.HISFC.Models.Fee.ComGroup comGroup = this.neuTreeView1.SelectedNode.Parent.Tag as Neusoft.HISFC.Models.Fee.ComGroup;
                    group.ParentGroupID = comGroup.ID;
                }
            }
            return group;
        }

        //生成组套明细实体
        private Neusoft.HISFC.Models.Fee.ComGroupTail AddGrpDetailInstance(int row, string newID, string OperID)
        {
            Neusoft.HISFC.Models.Fee.ComGroupTail detail = new Neusoft.HISFC.Models.Fee.ComGroupTail();
            detail.ID = newID;
            detail.sequenceNo = row;
            detail.itemCode = fpSpread1_Sheet1.GetTag(row, (int)Cols.ItemName).ToString();//代码

            #region 判断数量
            decimal amount = 0;
            string qty = fpSpread1_Sheet1.GetText(row, (int)Cols.Qty);
            if (qty == null || qty == "") qty = "0";
            try
            {
                amount = Convert.ToDecimal(qty);
            }
            catch
            {
                MessageBox.Show("开立数量不合法!", "提示");
                return null;
            }
            if (amount < 0)
            {
                MessageBox.Show("开立数量不能小于零!", "提示");
                return null;
            }
            #endregion
            detail.qty = amount;
            object obj = fpSpread1_Sheet1.GetTag(row, (int)Cols.Dept);
            if (obj != null)
            {
                detail.deptCode = obj.ToString();//执行科室
                detail.deptName = obj.ToString();
            }

            detail.drugFlag = fpSpread1_Sheet1.Rows[row].Tag.ToString();
            detail.unitFlag = "2";//临时
            detail.combNo = fpSpread1_Sheet1.GetText(row, (int)Cols.Combo);
            detail.reMark = fpSpread1_Sheet1.GetText(row, (int)Cols.Memo);
            detail.SortNum = Neusoft.FrameWork.Function.NConvert.ToInt32(fpSpread1_Sheet1.GetText(row, (int)Cols.SortId)); //序号
            detail.operCode = OperID;

            return detail;
        }
        
      #endregion

        public int SaveAs()
        {
            this.fpSpread1.StopCellEditing();
            txtName.Tag = null;
            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
            //if (Valid() == -1) return -1;

            //组套管理类
            //Neusoft.HISFC.BizLogic.Manager.ComGroup grpMgr = new Neusoft.HISFC.BizLogic.Manager.ComGroup();
            //事务
            //Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(grpMgr.Connection);
            //t.BeginTransaction();//开始事务            
            //组套明细管理类
            Neusoft.HISFC.BizLogic.Manager.ComGroupTail detailMgr = new Neusoft.HISFC.BizLogic.Manager.ComGroupTail();

            //grpMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
           
            //detailMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //生成新的组套代码
            string groupID = detailMgr.getGroupID();
            //生成组套实体
            Neusoft.HISFC.Models.Fee.ComGroup group = AddGroupInstance(groupID,Neusoft.FrameWork.Management.Connection.Operator.ID);

            Forms.frmChooseSelectNode frm = new Neusoft.HISFC.Components.Common.Forms.frmChooseSelectNode();
            //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
            //frm.DeptObj = this.cmbDept.SelectedItem;
            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                return -1;
            }

            

            TreeNode selectedNode = frm.SelectedNode;

            frm.Dispose();

            //更新科室值

            if (selectedNode.Tag.GetType() == typeof(Neusoft.HISFC.Models.Base.Department))
            {
                group.deptCode = (selectedNode.Tag as Neusoft.HISFC.Models.Base.Department).ID;
                group.deptName = (selectedNode.Tag as Neusoft.HISFC.Models.Base.Department).ID;
                group.ParentGroupID = "ROOT";

            }
            else
            {
                group.deptCode = (selectedNode.Tag as Neusoft.HISFC.Models.Fee.ComGroup).deptCode;
                group.deptName = (selectedNode.Tag as Neusoft.HISFC.Models.Fee.ComGroup).deptCode;
                group.ParentGroupID = (selectedNode.Tag as Neusoft.HISFC.Models.Fee.ComGroup).ID;
            }

            
            int count = 0;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            try
            {
                //插入组套
                if (grpMgr.InsertInToComGroup(group) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("插入组套信息表出错!" + grpMgr.Err, "提示");
                    return -1;
                }

                //循环组套明细
                for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                {
                    if (fpSpread1_Sheet1.GetTag(i, (int)Cols.ItemName) == null || fpSpread1_Sheet1.GetTag(i, (int)Cols.ItemName).ToString()
                        == "") continue;
                    //赋值组套明细实体
                    Neusoft.HISFC.Models.Fee.ComGroupTail detail = AddGrpDetailInstance(i, groupID,Neusoft.FrameWork.Management.Connection.Operator.ID);
                    if (detail == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        return -1;
                    }
                    //插入组套明细
                    if (detailMgr.InsertDataIntoComGroupTail(detail) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入组套明细表时出错!" + detailMgr.Err, "提示");
                        return -1;
                    }
                    count++;
                }
                if (count == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("请录入组套明细!", "提示");
                    return -1;
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存组套时出错!" + e.Message, "提示");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            //刷新树形列表
            TreeNode node = new TreeNode();

            if (selectedNode.Tag.GetType() == typeof(Neusoft.HISFC.Models.Base.Department))
            {
                //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
                //node = FindNode(cmbDept.Tag.ToString());
                node = FindNode((selectedNode.Tag as Neusoft.HISFC.Models.Base.Department).ID);
            }
            else
            {
                node = FindNodeByGroupID((selectedNode.Tag as Neusoft.HISFC.Models.Fee.ComGroup).ID);
            }
            if (node != null)//{9317CF49-CD92-459c-A90A-845D543F11E6}
            {
                //TreeNode node = this.neuTreeView1.SelectedNode;
                //{9F3CF1C0-AF96-4d17-96B1-6B34636A42A7}
                if (this.isDeptOnly)
                    this.AddGroup(node, group);

                else
                {
                    if (node != null)
                    {
                        this.AddGroup(node, group);
                    }
                }

                node.ExpandAll();
            }
            //this.neuTreeView1.SelectedNode = node;

            
            MessageBox.Show("另存成功!", "提示");
       
            txtName.Focus();

            return 0;
        }

        #endregion

        #region 事件

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData==Keys.Up)
            {
                    #region Up
                    //判断该控件是否获得焦点
                    if (fpSpread1.ContainsFocus)
                    {
                        //如果项目列表显示
                        if (ItemList.Visible)
                            ItemList.PriorRow();
                        //如果执行科室显示
                        else if (lbDept.Visible)
                            lbDept.PriorRow();
                        else
                        {
                            int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                            if (CurrentRow > 0)
                            {
                                fpSpread1_Sheet1.ActiveRowIndex = CurrentRow - 1;
                                fpSpread1_Sheet1.AddSelection(CurrentRow - 1, 0, 1, 1);
                            }
                        }
                    }
                    #endregion
            }

            if (keyData == Keys.Down)
            {
                #region Down
                //判断该控件是否获得焦点
                if (fpSpread1.ContainsFocus)
                {
                    //如果项目列表显示
                    if (ItemList.Visible)
                        ItemList.NextRow();
                    //如果执行科室显示
                    else if (lbDept.Visible)
                        lbDept.NextRow();
                    else
                    {
                        int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                        if (CurrentRow < fpSpread1_Sheet1.RowCount - 1)
                        {
                            fpSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                            fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 1);
                        }
                        else
                        {   //添加一条组套明细
                            AddGroupDetail();
                        }
                    }
                }
                #endregion
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 重新ProcessDialogKey方法处理对话框键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Enter:
                    #region Enter
                    //判断该控件是否获得焦点
                    if (fpSpread1.ContainsFocus)
                    {   //当前激活列索引为ItemName(项目名称)
                        if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.ItemName)
                        {
                            if (SelectItem() == -1) return true;
                        }
                        //当前激活列索引为Qty(数量)
                        else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.Qty)
                        {   //设置激活Cell
                            fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.Dept, false);
                        }
                        //当前激活列索引为Dept(执行科室)
                        else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.Dept)
                        {   //执行科室列表显示
                            if (lbDept.Visible)
                            {
                                SelectDept();
                            }
                            fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.Combo, false);
                        }
                        //当前激活列索引为Combo(组合号)
                        else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.Combo)
                        {
                            fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.Memo, false);
                        }
                        //当前激活列索引为Memo(备注)
                        else if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.Memo)
                        {
                            if (fpSpread1_Sheet1.RowCount == fpSpread1_Sheet1.ActiveRowIndex + 1)
                            {
                                //添加一条组套明细
                                AddGroupDetail();
                            }
                            else
                            {
                                fpSpread1_Sheet1.ActiveRowIndex++;
                                fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, (int)Cols.ItemName, true);
                            }
                        }
                    }
                    #endregion
                    break;
                case Keys.Escape:
                    //如果项目名称显示
                    if (ItemList.Visible)
                        ItemList.Visible = false;
                    //如果执行科室显示
                    if (lbDept.Visible)
                        lbDept.Visible = false;
                    break;
                #region 2007-4-28 注释的代码 路志鹏 
                /* 该up down在此事件中不触发，被移到ProcessCmdKey事件中
                case Keys.Up:
                    #region Up
                    //判断该控件是否获得焦点
                    if (fpSpread1.ContainsFocus)
                    {
                        //如果项目列表显示
                        if (ItemList.Visible)
                            ItemList.PriorRow();
                        //如果执行科室显示
                        else if (lbDept.Visible)
                            lbDept.PriorRow();
                        else
                        {
                            int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                            if (CurrentRow > 0)
                            {
                                fpSpread1_Sheet1.ActiveRowIndex = CurrentRow - 1;
                                fpSpread1_Sheet1.AddSelection(CurrentRow - 1, 0, 1, 0);
                            }
                        }
                    }
                    #endregion
                    break;
                case Keys.Down:
                    #region Down
                    //判断该控件是否获得焦点
                    if (fpSpread1.ContainsFocus)
                    {
                        //如果项目列表显示
                        if (ItemList.Visible)
                            ItemList.NextRow();
                        //如果执行科室显示
                        else if (lbDept.Visible)
                            lbDept.NextRow();
                        else
                        {
                            int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                            if (CurrentRow < fpSpread1_Sheet1.RowCount - 1)
                            {
                                fpSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                                fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 0);
                            }
                            else
                            {   //添加一条组套明细
                                AddGroupDetail();
                            }
                        }
                    }
                    #endregion
                    break;
                 */
                #endregion
                #region F2,F3,F4
                case Keys.F2:
                    //如果FarPoint获得焦点并且项目名称显示
                    if (fpSpread1.ContainsFocus && ItemList.Visible)
                    {
                        int row = int.Parse(keyData.ToString().Substring(1)) - 1;
                        SelectItem(row);
                    }
                    break;
                case Keys.F3:
                    if (fpSpread1.ContainsFocus && ItemList.Visible)
                    {
                        int row = int.Parse(keyData.ToString().Substring(1)) - 1;
                        SelectItem(row);
                    }
                    break;
                case Keys.F4:
                    if (fpSpread1.ContainsFocus && ItemList.Visible)
                    {
                        int row = int.Parse(keyData.ToString().Substring(1)) - 1;
                        SelectItem(row);
                    }
                    break;
                #endregion
                default:
                    break;
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// FarPoint在编辑模式上触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditModeOn(object sender, EventArgs e)
        {
            fpSpread1.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);

            SetLocation();

            if (fpSpread1_Sheet1.ActiveColumnIndex != (int)Cols.Dept)
                lbDept.Visible = false;

            if (fpSpread1_Sheet1.ActiveColumnIndex != (int)Cols.ItemName)
                ItemList.Visible = false;
        }
        
        /// <summary>
        /// EditingControl.KeyDown委托事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (fpSpread1_Sheet1.ActiveColumnIndex == (int)Cols.ItemName)
            {
                if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F5 ||
                    e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 ||
                    e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 ||
                    e.KeyCode == Keys.F10)
                {
                    if (ItemList.Visible)
                    {
                        int row = int.Parse(e.KeyCode.ToString().Substring(1)) - 1;
                        SelectItem(row);
                    }
                }
                else if (e.KeyCode == Keys.F11)
                {//切换输入法
                    if (ItemList.Visible)
                    {
                        ItemList.ChangeQueryType();                       
                    }
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    if (ItemList.Visible)
                        ItemList.NextPage();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    if (ItemList.Visible)
                        ItemList.PriorPage();
                }          
            }
        }

        /// <summary>
        /// FarPoint编辑改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string _Text;
            switch (e.Column)
            {
                case (int)Cols.ItemName://项目名称
                    _Text = fpSpread1_Sheet1.ActiveCell.Text;
                    ItemList.Filter(_Text);
                    if (ItemList.Visible == false) ItemList.Visible = true;
                    //清空当前行变量
                    fpSpread1_Sheet1.SetValue(e.Row, (int)Cols.Price, "", false);
                    fpSpread1_Sheet1.SetValue(e.Row, (int)Cols.Qty, "", false);
                    fpSpread1_Sheet1.SetValue(e.Row, (int)Cols.Unit, "", false);
                    fpSpread1_Sheet1.SetValue(e.Row, (int)Cols.Dept, "", false);
                    fpSpread1_Sheet1.SetTag(e.Row, (int)Cols.ItemName, null);
                    break;
                case (int)Cols.Dept://过滤执行科室			
                    _Text = fpSpread1_Sheet1.ActiveCell.Text;
                    lbDept.Filter(_Text);

                    if (lbDept.Visible == false)
                    {
                        lbDept.Visible = true;
                    }
                    fpSpread1_Sheet1.SetTag(e.Row, (int)Cols.Dept, null);

                    break;
            }
        }

        /// <summary>
        /// TreeView选择后发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //选中组套
            if (e.Node.Tag.GetType() == typeof(Neusoft.HISFC.Models.Fee.ComGroup))
            {
                Neusoft.HISFC.Models.Fee.ComGroup group = e.Node.Tag as Neusoft.HISFC.Models.Fee.ComGroup;
                //显示组套信息
                ShowGroup(group);
                ShowDetail(group.ID);
                this.cmbDept.Enabled = false;
            }
            else
            {
                Clear();
                if (e.Node.Tag.GetType() == typeof(Neusoft.HISFC.Models.Base.Department))
                {
                    this.cmbDept.Tag = (e.Node.Tag as Neusoft.HISFC.Models.Base.Department).ID;
                    this.cmbDept.Enabled = false;
                }
                else
                {
                    this.cmbDept.Enabled = true;
                }
                
            }
        }

        /// <summary>
        /// 控件加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucGroupDetail_Load(object sender, EventArgs e)
        {
            if (this.Tag != null && this.Tag.ToString() != "")
            {
                this.IsDeptOnly = true;
                this.toolBarService.SetToolButtonEnabled("另存", true);
                //如果进入为护士站
                if (this.Tag.ToString() == "2")
                    this.IsUndrug = true;
                
                try
                {
                    Neusoft.FrameWork.Management.DataBaseManger data = new Neusoft.FrameWork.Management.DataBaseManger();
                    //获得当前登陆科室
                    this.DeptInfo = ((Neusoft.HISFC.Models.Base.Employee)data.Operator).Dept;
                }
                catch
                { }
            }
            //初始化
            ucInit();


        }

        #region 自定义事件
        /// <summary>
        /// lbDept代理动作实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lbDept_ItemSelected(object sender, EventArgs e)
        {
            SelectDept();
        }

        /// <summary>
        /// ucItemList代理动作实现
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int ItemList_SelectItem(Keys key)
        {
            //FarPoint选择项
            SelectItem();
            return 0;
        }
        
        #endregion

        #region 输入控件Enter事件
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtName.Text == null || txtName.Text == "")
                {
                    MessageBox.Show("组套名称不能为空!", "提示");
                    txtName.Focus();
                    return;
                }
                //生成拼音码
                object obj = txtName.Tag;
                if (obj == null || (obj as Neusoft.HISFC.Models.Fee.ComGroup).Name != txtName.Text)
                {
                    Neusoft.HISFC.Models.Base.Spell spell = new Neusoft.HISFC.Models.Base.Spell();
                    Neusoft.HISFC.BizLogic.Manager.Spell spellMgr = new Neusoft.HISFC.BizLogic.Manager.Spell();
                    try
                    {
                        spell = (Neusoft.HISFC.Models.Base.Spell)spellMgr.Get(txtName.Text);
                    }
                    catch { }

                    // [2007/02/08] 原来的代码
                    //  if (spell != null && spell.SpellCode.Trim() != "" && spell.SpellCode.Length > 9)
                    //  {
                    //     txtSpell.Text = spell.SpellCode.Substring(8);
                    //  }


                    if (spell.SpellCode.Trim() != "")
                    {
                        if (spell.SpellCode.Length > 9)
                        {
                            txtSpell.Text = spell.SpellCode.Substring(8);
                        }
                        else
                        {
                            txtSpell.Text = spell.SpellCode;
                        }
                    }
                }
                chkValid.Focus();
            }
        }
        
        private void chkValid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.txtInput.Focus();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.txtSpell.Focus();
        }

        private void txtSpell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (this.cmbDept.Enabled == true)
                {
                    this.cmbDept.Focus();
                }
                else 
                {
                    this.txtMemo.Focus();
                }
        }

        private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.txtMemo.Focus();
        }
        
        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpSpread1_Sheet1.RowCount == 0) AddGroupDetail();//添加一条组套明细
                this.fpSpread1.Focus();
            }
        }
        #endregion

        #endregion   

    }
}
