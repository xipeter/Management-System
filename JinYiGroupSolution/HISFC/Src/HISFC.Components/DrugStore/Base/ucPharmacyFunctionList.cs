using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Base
{
    /// <summary>
    /// [功能描述: 药理作用列表<br></br>
    /// [创 建 者: 孙久海]<br></br>
    /// [创建时间: 2009-6-2]<br></br>
    /// </summary>
    public partial class ucPharmacyFunctionList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPharmacyFunctionList()
        {
            InitializeComponent();
        }

        #region 变量

        //药理常数管理
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant pharmacyConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
        private Neusoft.HISFC.Models.Pharmacy.PhaFunction functionObject = null;
        //常数管理类－取常数列表
        private Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();

        //帮助类
        Neusoft.FrameWork.Public.ObjectHelper ehSysClass = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper ehType = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper ehQuality = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper ehMinFee = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper ehFunction1 = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper ehFunction2 = new Neusoft.FrameWork.Public.ObjectHelper();
        Neusoft.FrameWork.Public.ObjectHelper ehFunction3 = new Neusoft.FrameWork.Public.ObjectHelper();

        //定义药理作用属性
        ucPharmacyFunctionProperty ucProperty = null;

        #endregion

        #region 方法

        /// <summary>
        /// 初始化ListView
        /// </summary>
        private void InitListView()
        {
            //清除列表
            this.lvFunctionList.Items.Clear();
            if (this.tvFunction.SelectedNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in this.tvFunction.SelectedNode.Nodes)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = node.Text;
                    lvi.Tag = node;
                    lvi.ImageIndex = node.ImageIndex;
                    this.lvFunctionList.Items.Add( lvi );
                }
            }
        }

        /// <summary>
        /// 递归遍历整个树节点
        /// </summary>
        /// <param name="tnc"></param>
        /// <param name="newnodecode"></param>
        /// <param name="newnode"></param>
        private void GetAllNode(TreeNodeCollection tnc, string newnodecode, TreeNode newnode) //遍历整个树
        {
            foreach (TreeNode node in tnc)
            {
                if (node.Nodes.Count != 0)
                {
                    GetAllNode( node.Nodes, newnodecode, newnode );
                }
                if (newnodecode == node.Tag.ToString())
                {
                    node.Nodes.Add( newnode );
                    SettreeImage( node, false );
                }
            }
        }

        /// <summary>
        /// 设置数节点图标 true 表示是叶子节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="iFtrue"></param>
        public void SettreeImage(TreeNode node, bool iFtrue)
        {
            if (iFtrue)
            {
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
            }
            else
            {
                node.ImageIndex = 2;
                node.SelectedImageIndex = 1;
            }
        }

        /// <summary>
        /// 查询药品列表 by Sunjh 2008-09-22
        /// </summary>
        /// <param name="fCode">药理作用代码</param>
        /// <param name="fLevl">药理作用分级</param>
        private void ShowDrugList(string fCode, int fLevl)
        {
            if (fCode == "" || fCode == null)
            {
                return;
            }
            Neusoft.HISFC.BizLogic.Pharmacy.Constant cItem = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            List<Neusoft.HISFC.Models.Pharmacy.Item> al = cItem.QueryItemListByFunctionID( fCode, 1 );
            if (al != null)
            {
                this.PutList( al );
            }
            else
            {
                fpDrugList.RowCount = 0;
            }
        }

        /// <summary>
        /// 加载药品列表到控件
        /// </summary>
        /// <param name="al"></param>
        private void PutList(List<Neusoft.HISFC.Models.Pharmacy.Item> al)
        {
            fpDrugList.RowCount = 0;
            fpDrugList.RowCount = al.Count;
            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.Item pItem = new Neusoft.HISFC.Models.Pharmacy.Item();
                pItem = al[i];
                fpDrugList.Cells[i, 0].Text = pItem.ID;
                fpDrugList.Cells[i, 1].Text = pItem.Name;
                fpDrugList.Cells[i, 2].Text = pItem.NameCollection.RegularName;
                fpDrugList.Cells[i, 3].Text = pItem.PackQty.ToString();
                fpDrugList.Cells[i, 4].Text = pItem.Specs;
                //系统类别
                fpDrugList.Cells[i, 5].Text = ehSysClass.GetName( pItem.SysClass.ID.ToString() );
                //项目分类                
                fpDrugList.Cells[i, 6].Text = ehMinFee.GetName( pItem.MinFee.ID );
                fpDrugList.Cells[i, 7].Text = pItem.PackUnit;
                fpDrugList.Cells[i, 8].Text = pItem.MinUnit;
                //药品类别
                fpDrugList.Cells[i, 9].Text = ehType.GetName( pItem.Type.ID );
                //药品性质
                fpDrugList.Cells[i, 10].Text = ehQuality.GetName( pItem.Quality.ID );
                fpDrugList.Cells[i, 11].Text = pItem.PriceCollection.RetailPrice.ToString();
                //有效性
                if (pItem.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    fpDrugList.Cells[i, 12].Text = "有效";
                }
                else if (pItem.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    fpDrugList.Cells[i, 12].Text = "无效";
                }
                else if (pItem.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
                {
                    fpDrugList.Cells[i, 12].Text = "废弃";
                }
                else if (pItem.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Extend)
                {
                    fpDrugList.Cells[i, 12].Text = "扩展";
                }

                fpDrugList.Cells[i, 13].Text = pItem.UserCode;
                fpDrugList.Cells[i, 14].Text = pItem.NameCollection.EnglishName;
                fpDrugList.Cells[i, 15].Text = ehFunction1.GetName( pItem.PhyFunction1.ID );
                fpDrugList.Cells[i, 16].Text = ehFunction2.GetName( pItem.PhyFunction2.ID );
                fpDrugList.Cells[i, 17].Text = ehFunction3.GetName( pItem.PhyFunction3.ID );
            }

        }

        /// <summary>
        /// 初始化常数
        /// </summary>
        private void IniConstant()
        {
            this.ehSysClass.ArrayObject = Neusoft.HISFC.Models.Base.SysClassEnumService.List();//系统类别
            this.ehType.ArrayObject = consManager.GetList( Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE );//药品类别
            this.ehQuality.ArrayObject = consManager.GetList( Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY );//药品性质
            this.ehMinFee.ArrayObject = consManager.GetList( Neusoft.HISFC.Models.Base.EnumConstant.MINFEE );//项目分类
            ArrayList alLevel1Function = new ArrayList( this.pharmacyConstant.QueryPhaFunction() );//(1, "NONE").ToArray());//一级药理作用
            this.ehFunction1.ArrayObject = new ArrayList( alLevel1Function.ToArray() );
            //alLevel1Function = new ArrayList(this.pharmacyConstant.QueryPhaFunctionByLevel(2, "NONE").ToArray());//二级药理作用
            //this.ehFunction2.ArrayObject = new ArrayList(alLevel1Function.ToArray());
            //alLevel1Function = new ArrayList(this.pharmacyConstant.QueryPhaFunctionByLevel(3, "NONE").ToArray());//三级药理作用
            //this.ehFunction3.ArrayObject = new ArrayList(alLevel1Function.ToArray());
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            //增加工具栏
            this.toolBarService.AddToolButton( "增加", "增加药理作用", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null );
            this.toolBarService.AddToolButton( "删除", "删除药理作用", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null );
            this.toolBarService.AddToolButton( "修改", "修改药理作用", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null );
            this.toolBarService.AddToolButton( "上层", "返回上层目录", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个, true, false, null );

            return this.toolBarService;
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.menuAdd_Click( sender, e );
                    break;
                case "删除":
                    this.menuDelete_Click( sender, e );
                    break;
                case "修改":
                    this.menuModify_Click( sender, e );
                    break;
                case "上层":
                    TreeNode node;
                    if (this.tvFunction.Nodes.Count == 0)
                    {
                        return;
                    }
                    node = this.tvFunction.SelectedNode.Parent;
                    if (node != null)
                    {
                        this.tvFunction.SelectedNode = node;
                    }
                    break;
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 树节点选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFunction_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                this.InitListView();
                this.ShowDrugList( e.Node.Tag.ToString(), e.Node.Level );
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在加载基础数据..." );
            Application.DoEvents();

            this.IniConstant();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            //只展开树的第一层
            if (this.tvFunction.Nodes.Count > 0)
            {
                this.tvFunction.Nodes[0].Expand();
                //默认选中根节点
                this.tvFunction.SelectedNode = this.tvFunction.Nodes[0];
            }

            base.OnLoad( e );
        }

        #region 菜单事件

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdd_Click(object sender, EventArgs e)
        {
            string nodecode;
            //{FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}  药理作用级别校验
            int girdLevel;
            //如果选择了节点，则选择的节点作为父节点，否则添加到根节点下
            if (this.tvFunction.SelectedNode != null)
            {
                nodecode = this.tvFunction.SelectedNode.Tag.ToString();
                girdLevel = this.tvFunction.SelectedNode.Level;             //根据树节点层次设置药理作用级别  {FF5503FA-0057-413e-BF08-5A8C1DCF7ED8} 
            }
            else
            {
                nodecode = "-1";
                girdLevel = 0;                                             //根节点下 药理作用级别为 1        {FF5503FA-0057-413e-BF08-5A8C1DCF7ED8} 
            }
            if (girdLevel == 3)           //父节点已经是三级节点
            {
                MessageBox.Show( "药理作最多支持三级分类，不能再进行四级分类添加", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }
            //初始化实体
            functionObject = new Neusoft.HISFC.Models.Pharmacy.PhaFunction();
            //初始化控件  {FF5503FA-0057-413e-BF08-5A8C1DCF7ED8} 此时增加的是当前节点的下一级节点 Level + 1
            ucProperty = new ucPharmacyFunctionProperty( nodecode, "INSERT", girdLevel + 1 );
            //窗口标题
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "添加药理作用";
            DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( ucProperty );
            if (dlg == DialogResult.OK)
            {
                TreeNode tn = new TreeNode();
                //获取最近插入的实体
                functionObject = (Neusoft.HISFC.Models.Pharmacy.PhaFunction)this.pharmacyConstant.QueryPhaFunctionNodeName()[0];
                //插入新加节点
                tn.Tag = functionObject.ID;
                tn.Text = functionObject.Name;
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                if (this.tvFunction.SelectedNode != null)
                {
                    this.tvFunction.SelectedNode.Nodes.Add( tn );
                    this.tvFunction.SelectedNode.ImageIndex = 2;
                    this.tvFunction.SelectedNode.SelectedImageIndex = 1;
                }
                else
                {
                    this.tvFunction.Nodes.Add( tn );
                }

                //添加到ListView
                ListViewItem lvi = new ListViewItem();
                lvi.Text = tn.Text;
                lvi.Tag = tn.Tag;
                lvi.ImageIndex = tn.ImageIndex;
                this.lvFunctionList.Items.Add( lvi );
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            //如果树节点数为零则不触发
            if (this.tvFunction.Nodes.Count == 0)
            {
                return;
            }

            TreeNode node = null;
            //如果列表中有选中的节点
            if (this.lvFunctionList.Focused == true && this.lvFunctionList.SelectedItems.Count > 0)
            {
                node = this.lvFunctionList.SelectedItems[0].Tag as TreeNode;
            }
            else //列表中没有选中的节点，则取树当前选中的节点
            {
                node = this.tvFunction.SelectedNode;
            }
            //如果该节点下没有子节点则可以删除，否则不允许删除
            if (node != null)//{5893E516-AD85-49b7-BAA9-652B2124B13C}
            {
                if (node.Nodes.Count == 0)
                {
                    //初始化控件
                    ucProperty = new ucPharmacyFunctionProperty(node.Tag.ToString(), "DELETE", this.tvFunction.SelectedNode.Level);
                    //窗口标题
                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "删除药理作用";
                    DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucProperty);
                    if (dlg == DialogResult.OK)
                    {
                        TreeNode tn = new TreeNode();
                        tn = node.Parent;
                        node.Remove();                       //删除树节点
                        if (this.tvFunction.Nodes.Count > 0)     //判断如果不是删除根节点
                        {
                            if (this.lvFunctionList.SelectedItems.Count > 0)
                                this.lvFunctionList.SelectedItems[0].Remove();//删除listview 节点

                            if (tn.Nodes.Count == 0)
                            {
                                tn.ImageIndex = 0;
                                tn.SelectedImageIndex = 0;
                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("请点击左侧节点，再删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuModify_Click(object sender, EventArgs e)
        {
            //如果当前树没有节点则不能显示
            if (this.tvFunction.Nodes.Count == 0)
            {
                return;
            }
            //定义当前节点和父节点
            TreeNode node, nodep;
            if (this.lvFunctionList.Focused == true && this.lvFunctionList.SelectedItems.Count > 0)
            {
                node = this.lvFunctionList.SelectedItems[0].Tag as TreeNode;
                nodep = node.Parent;
            }
            else
            {
                node = this.tvFunction.SelectedNode;
            }

            //初始化实体
            functionObject = new Neusoft.HISFC.Models.Pharmacy.PhaFunction();
            //初始化控件
            ucProperty = new ucPharmacyFunctionProperty( node.Tag.ToString(), "UPDATE",this.tvFunction.SelectedNode.Level );
            //窗口标题
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "修改作用维护";
            DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( ucProperty );

            object myobj = new object();
            if (dlg == DialogResult.OK)
            {
                functionObject = (Neusoft.HISFC.Models.Pharmacy.PhaFunction)this.pharmacyConstant.QueryPhaFunctionNodeName()[0];
                //取出最新更改的节点的名称
                node.Text = functionObject.Name;
                //如果更新的不是根节点
                if (this.lvFunctionList.SelectedItems.Count > 0)
                {
                    this.lvFunctionList.SelectedItems[0].Text = functionObject.Name;
                    //新更改节点的父节点和原来父节点不同则重新LOAD
                    if (functionObject.ParentNode != node.Parent.Tag.ToString())
                    {
                        myobj = node;
                        nodep = node.Parent;
                        node.Remove();
                        //从当前列表种删除
                        this.lvFunctionList.SelectedItems[0].Remove();
                        //递归遍历整个树，添加到新根节点下
                        GetAllNode( this.tvFunction.Nodes, functionObject.ParentNode, (TreeNode)myobj );
                        //如果当前修改的节点的父节点没有子节点，则更新子节点标志为0（因为当前节点的的节点类别已经更改）
                        if (nodep.Nodes.Count == 0)
                        {
                            //叶子节点更改nodekind
                            this.pharmacyConstant.UpdateFunctionnNodekind( nodep.Tag.ToString(), 0 );
                            SettreeImage( nodep, true );
                        }
                    }
                }
                else
                {
                    this.tvFunction.InitTreeView();

                    if (this.tvFunction.Nodes.Count > 0)
                    {
                        this.tvFunction.Nodes[0].Expand();
                    }
                }
            }
        }

        /// <summary>
        /// 列表显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShowList_Click(object sender, EventArgs e)
        {
            this.menuShowList.Checked = true;
            this.menuShowLarge.Checked = false;
            this.menuShowSmall.Checked = false;

            this.lvFunctionList.View = View.List;
        }

        /// <summary>
        ///  大图标显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShowLarge_Click(object sender, EventArgs e)
        {
            this.menuShowLarge.Checked = true;
            this.menuShowSmall.Checked = false;
            this.menuShowList.Checked = false;

            this.lvFunctionList.View = View.LargeIcon;
        }

        /// <summary>
        /// 小图标显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShowSmall_Click(object sender, EventArgs e)
        {
            this.menuShowLarge.Checked = false;
            this.menuShowSmall.Checked = true;
            this.menuShowList.Checked = false;

            this.lvFunctionList.View = View.SmallIcon;
        }

        #endregion

        /// <summary>
        /// 列表视图单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvFunctionList_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if (this.lvFunctionList.SelectedItems.Count > 0 && this.lvFunctionList.Focused == true)
            {

                node = this.lvFunctionList.SelectedItems[0].Tag as TreeNode;
                if (node == null)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 列表视图双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvFunctionList_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvFunctionList.SelectedItems.Count > 0 && this.lvFunctionList.Focused)
            {
                //当前节点下还有节点则打开，和树相对应
                TreeNode node = this.lvFunctionList.SelectedItems[0].Tag as TreeNode;
                if (node == null)
                {
                    return;
                }
                if (node.Nodes.Count >= 1)
                {
                    this.tvFunction.SelectedNode = node;
                    ShowDrugList( node.Tag.ToString(), node.Level );
                }
            }
        }

        #endregion

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string strCode = this.fpDrugList.Cells[e.Row, 0].Text;
            Neusoft.HISFC.BizLogic.Pharmacy.Item Pitem = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.Models.Pharmacy.Item item = new Neusoft.HISFC.Models.Pharmacy.Item();
            item = Pitem.GetItem( strCode );

            this.tpDescription.Text = item.Name + " [ " + item.Specs + " ] 药品详细信息";

            this.neutext.Text = item.Product.Manual;
        }
    }
}
