using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Base
{
    /// <summary>
    /// [控件名称:ucPharmacyFunction]<br></br>
    /// [功能描述: 药理作用维护<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-17]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPharmacyFunction : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPharmacyFunction( )
        {
            InitializeComponent( );
        }

        #region 变量

        //药理常数管理
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant pharmacyConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant( );
        private Neusoft.HISFC.Models.Pharmacy.PhaFunction functionObject = null;
        //定义药理作用属性
        ucPharmacyFunctionProperty ucProperty = null;

        #endregion

        #region 属性

        /// <summary>
        /// 是否允许修改编辑
        /// </summary>
        public bool IsCanEdit
        {
            set
            {
                this.toolBarService.SetToolButtonEnabled("修改", value);
                this.menuModify.Enabled = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化ListView
        /// </summary>
        private void InitListView( )
        {
            //清除列表
            this.lvFunctionList.Items.Clear( );
            if( this.tvFunction.SelectedNode.Nodes.Count > 0 )
            {
                foreach( TreeNode node in this.tvFunction.SelectedNode.Nodes )
                {
                    ListViewItem lvi = new ListViewItem( );
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
        private void GetAllNode( TreeNodeCollection tnc , string newnodecode , TreeNode newnode ) //遍历整个树
        {
            foreach( TreeNode node in tnc )
            {
                if( node.Nodes.Count != 0 )
                {
                    GetAllNode( node.Nodes , newnodecode , newnode );
                }
                if( newnodecode == node.Tag.ToString( ) )
                {
                    node.Nodes.Add( newnode );
                    SettreeImage( node , false );
                }
            }
        }

        /// <summary>
     /// 设置数节点图标 true 表示是叶子节点
     /// </summary>
     /// <param name="node"></param>
     /// <param name="iFtrue"></param>
        public void SettreeImage( TreeNode node , bool iFtrue )
        {
            if( iFtrue )
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


        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService( );

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit( object sender , object NeuObject , object param )
        {
            //增加工具栏
            this.toolBarService.AddToolButton( "增加" , "增加药理作用" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加 , true , false , null );
            this.toolBarService.AddToolButton( "删除" , "删除药理作用" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除 , true , false , null );
            this.toolBarService.AddToolButton( "修改" , "修改药理作用" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改 , true , false , null );
            this.toolBarService.AddToolButton( "上层" , "返回上层目录" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个 , true , false , null );
            return this.toolBarService;
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked( object sender , ToolStripItemClickedEventArgs e )
        {
            switch( e.ClickedItem.Text )
            {
                case "增加":
                    this.menuAdd_Click( sender , e );
                    break;
                case "删除":
                    this.menuDelete_Click( sender , e );
                    break;
                case "修改":
                    this.menuModify_Click( sender , e );
                    break;
                case "上层":
                    TreeNode node;
                    if( this.tvFunction.Nodes.Count == 0 )
                    {
                        return;
                    }
                    node = this.tvFunction.SelectedNode.Parent;
                    if( node != null )
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
        private void tvFunction_AfterSelect( object sender , TreeViewEventArgs e )
        {
            if (e.Node != null)
            {
                this.InitListView();
                //设置工具栏按钮
                if (e.Node.Nodes.Count > 0)
                {
                    this.toolBarService.SetToolButtonEnabled("删除", false);
                    this.menuDelete.Enabled = false;
                }
                else
                {
                    this.toolBarService.SetToolButtonEnabled("删除", true);
                    this.menuDelete.Enabled = true;
                }

                if (e.Node.Tag == null || e.Node.Text == "药理作用")
                {
                    this.IsCanEdit = false;
                }
                else
                {
                    this.IsCanEdit = true;
                }
            }
            else
            {
                this.IsCanEdit = false;
            }

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            //只展开树的第一层
            if( this.tvFunction.Nodes.Count > 0 )
            {
                this.tvFunction.Nodes[ 0 ].Expand( );
                //默认选中根节点
                this.tvFunction.SelectedNode = this.tvFunction.Nodes[ 0 ];
            }

            //设置工具栏
            this.toolBarService.SetToolButtonEnabled( "删除" , false );
            this.toolBarService.SetToolButtonEnabled( "修改" , false );
            this.menuModify.Enabled = false;
            this.menuDelete.Enabled = false;

            base.OnLoad( e );
        }

        #region 菜单事件

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdd_Click( object sender , EventArgs e )
        {
            string nodecode;
            //{FF5503FA-0057-413e-BF08-5A8C1DCF7ED8}  药理作用级别校验
            int girdLevel;
            //如果选择了节点，则选择的节点作为父节点，否则添加到根节点下
            if( this.tvFunction.SelectedNode != null)
            {
                nodecode = this.tvFunction.SelectedNode.Tag.ToString( );
                girdLevel = this.tvFunction.SelectedNode.Level;         //根据树节点层次设置药理作用级别  {FF5503FA-0057-413e-BF08-5A8C1DCF7ED8} 
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
            functionObject = new Neusoft.HISFC.Models.Pharmacy.PhaFunction( );
            //初始化控件
            ucProperty = new ucPharmacyFunctionProperty( nodecode, "INSERT", girdLevel + 1);
            //窗口标题
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "添加药理作用";
            DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( ucProperty );
            if( dlg == DialogResult.OK )
            {
                TreeNode tn = new TreeNode( );
                //获取最近插入的实体
                functionObject = ( Neusoft.HISFC.Models.Pharmacy.PhaFunction )this.pharmacyConstant.QueryPhaFunctionNodeName( )[ 0 ];
                //插入新加节点
                tn.Tag = functionObject.ID;
                tn.Text = functionObject.Name;
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                if( this.tvFunction.SelectedNode != null )
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
                ListViewItem lvi = new ListViewItem( );
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
        private void menuDelete_Click( object sender , EventArgs e )
        { 
            //如果树节点数为零则不触发
            if( this.tvFunction.Nodes.Count == 0 )
            {
                return;
            }

            TreeNode node = null;
            //如果列表中有选中的节点
            if( this.lvFunctionList.Focused == true && this.lvFunctionList.SelectedItems.Count > 0 )
            {
                node = this.lvFunctionList.SelectedItems[ 0 ].Tag as TreeNode;
            }
            else //列表中没有选中的节点，则取树当前选中的节点
            {
                node = this.tvFunction.SelectedNode;
            }
            //如果该节点下没有子节点则可以删除，否则不允许删除
            if( node.Nodes.Count == 0 )
            {
                //初始化控件
                ucProperty = new ucPharmacyFunctionProperty( node.Tag.ToString(), "DELETE", this.tvFunction.SelectedNode.Level);
                //窗口标题
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "删除药理作用";
                DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( ucProperty );
                if( dlg == DialogResult.OK )
                {
                    TreeNode tn = new TreeNode( );
                    tn = node.Parent;
                    node.Remove( );                       //删除树节点
                    if( this.tvFunction.Nodes.Count > 0 )     //判断如果不是删除根节点
                    {
                        if (this.lvFunctionList.SelectedItems.Count > 0)
                            this.lvFunctionList.SelectedItems[ 0 ].Remove( );//删除listview 节点

                        if( tn.Nodes.Count == 0 )
                        {
                            tn.ImageIndex = 0;
                            tn.SelectedImageIndex = 0;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuModify_Click( object sender , EventArgs e )
        {
            //如果当前树没有节点则不能显示
            if( this.tvFunction.Nodes.Count == 0 )
            {
                return;
            }
            //定义当前节点和父节点
            TreeNode node , nodep;
            if( this.lvFunctionList.Focused == true && this.lvFunctionList.SelectedItems.Count > 0 )
            {
                node = this.lvFunctionList.SelectedItems[ 0 ].Tag as TreeNode;
                nodep = node.Parent;
            }
            else
            {
                node = this.tvFunction.SelectedNode;
            }

            //初始化实体
            functionObject = new Neusoft.HISFC.Models.Pharmacy.PhaFunction( );
            //初始化控件
            ucProperty = new ucPharmacyFunctionProperty( node.Tag.ToString( ) , "UPDATE",this.tvFunction.SelectedNode.Level  );
            //窗口标题
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "修改作用维护";
            DialogResult dlg = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( ucProperty );

            object myobj = new object( );
            if( dlg == DialogResult.OK )
            {         
                functionObject = ( Neusoft.HISFC.Models.Pharmacy.PhaFunction )this.pharmacyConstant.QueryPhaFunctionNodeName( )[ 0 ];
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
                        GetAllNode(this.tvFunction.Nodes, functionObject.ParentNode, (TreeNode)myobj);
                        //如果当前修改的节点的父节点没有子节点，则更新子节点标志为0（因为当前节点的的节点类别已经更改）
                        if (nodep.Nodes.Count == 0)
                        {
                            //叶子节点更改nodekind
                            this.pharmacyConstant.UpdateFunctionnNodekind(nodep.Tag.ToString(), 0);
                            SettreeImage(nodep, true);
                        }
                    }
                }
                else
                {
                    this.tvFunction.InitTreeView();

                    if (this.tvFunction.Nodes.Count > 0)
                        this.tvFunction.Nodes[0].Expand();
                }
            }
        }

        /// <summary>
        /// 列表显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShowList_Click( object sender , EventArgs e )
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
        private void menuShowLarge_Click( object sender , EventArgs e )
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
        private void menuShowSmall_Click( object sender , EventArgs e )
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
        private void lvFunctionList_Click( object sender , EventArgs e )
        {
            TreeNode node;
            if( this.lvFunctionList.SelectedItems.Count > 0 && this.lvFunctionList.Focused == true )
            {
  
                node = this.lvFunctionList.SelectedItems[ 0 ].Tag as TreeNode;
                if (node == null)
                {
                    return;
                }

                //如果选中节点有子节点
                if( node.Nodes.Count > 0 )
                {
                    this.menuDelete.Enabled = false;
                    this.menuModify.Enabled = true;
                    this.toolBarService.SetToolButtonEnabled( "删除" , false );
                    this.toolBarService.SetToolButtonEnabled( "修改" , true );
                }
                else
                {
                    this.menuDelete.Enabled = true;
                    this.menuModify.Enabled = true;
                    this.toolBarService.SetToolButtonEnabled( "删除" , true );
                    this.toolBarService.SetToolButtonEnabled( "修改" , true );
                }
            }
            else
            {
                this.menuDelete.Enabled = false;
                this.menuModify.Enabled = false;
                this.toolBarService.SetToolButtonEnabled( "删除" , false );
                this.toolBarService.SetToolButtonEnabled( "修改" , false );
                return;
            }
        }

        /// <summary>
        /// 列表视图双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvFunctionList_DoubleClick( object sender , EventArgs e )
        {
            if( this.lvFunctionList.SelectedItems.Count > 0 && this.lvFunctionList.Focused )
            {
                //当前节点下还有节点则打开，和树相对应
                TreeNode node = this.lvFunctionList.SelectedItems[ 0 ].Tag as TreeNode;
                if (node == null)
                {
                    return;
                }
                if( node.Nodes.Count >= 1 )
                {
                    this.tvFunction.SelectedNode = node;
                }
            }
        }

        #endregion



    }
}
