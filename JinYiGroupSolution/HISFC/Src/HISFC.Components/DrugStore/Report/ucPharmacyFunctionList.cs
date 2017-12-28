using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Report
{
    /// <summary>
    /// [控件名称: ucPharmacyFunctionList]<br></br>
    /// [功能描述: 药理作用列表<br></br>
    /// [创 建 者: 孙久海]<br></br>
    /// [创建时间: 2009-6-2]<br></br>
    /// </summary>
    public partial class ucPharmacyFunctionList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPharmacyFunctionList( )
        {
            InitializeComponent( );
            this.IniConstant();
        }

        #region 变量

        //药理常数管理
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant pharmacyConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant( );
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
            List<Neusoft.HISFC.Models.Pharmacy.Item> al = cItem.QueryItemListByFunctionID(fCode, 1);
            if (al != null)
            {
                this.PutList(al);
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
                fpDrugList.Cells[i, 5].Text = ehSysClass.GetName(pItem.SysClass.ID.ToString());
                //项目分类                
                fpDrugList.Cells[i, 6].Text = ehMinFee.GetName(pItem.MinFee.ID);
                fpDrugList.Cells[i, 7].Text = pItem.PackUnit;
                fpDrugList.Cells[i, 8].Text = pItem.MinUnit;
                //药品类别
                fpDrugList.Cells[i, 9].Text = ehType.GetName(pItem.Type.ID);
                //药品性质
                fpDrugList.Cells[i, 10].Text = ehQuality.GetName(pItem.Quality.ID);
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
                fpDrugList.Cells[i, 15].Text = ehFunction1.GetName(pItem.PhyFunction1.ID);
                fpDrugList.Cells[i, 16].Text = ehFunction2.GetName(pItem.PhyFunction2.ID);
                fpDrugList.Cells[i, 17].Text = ehFunction3.GetName(pItem.PhyFunction3.ID);
            }
            
        }

        /// <summary>
        /// 初始化常数
        /// </summary>
        private void IniConstant()
        {
            this.ehSysClass.ArrayObject = Neusoft.HISFC.Models.Base.SysClassEnumService.List();//系统类别
            this.ehType.ArrayObject = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE);//药品类别
            this.ehQuality.ArrayObject = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);//药品性质
            this.ehMinFee.ArrayObject = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE);//项目分类
            ArrayList alLevel1Function = new ArrayList(this.pharmacyConstant.QueryPhaFunction());//(1, "NONE").ToArray());//一级药理作用
            this.ehFunction1.ArrayObject = new ArrayList(alLevel1Function.ToArray());
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
                this.ShowDrugList(e.Node.Tag.ToString(), e.Node.Level);
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

            base.OnLoad( e );
        }

        #region 菜单事件

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
                    ShowDrugList(node.Tag.ToString(), node.Level);
                }
            }
        }

        #endregion

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string strCode = this.fpDrugList.Cells[e.Row, 0].Text;
            Neusoft.HISFC.BizLogic.Pharmacy.Item Pitem = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            Neusoft.HISFC.Models.Pharmacy.Item al = new Neusoft.HISFC.Models.Pharmacy.Item();
              al = Pitem.GetItem(strCode);
            this.neutext.Text=al.Product.Manual;
           
           
        }



    }
}
