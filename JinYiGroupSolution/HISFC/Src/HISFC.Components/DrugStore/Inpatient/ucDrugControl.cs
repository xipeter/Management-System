using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Management.Pharmacy;
using Neusoft.HISFC.Object.Pharmacy;
using Neusoft.HISFC.Management.Manager;


namespace Neusoft.UFC.DrugStore.Inpatient
{
    public partial class ucDrugControl : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDrugControl( )
        {
            InitializeComponent( );
            //事件
            this.lvDrugControlList.DoubleClick += new System.EventHandler( this.lvDrugControlList_DoubleClick );
            this.lvDrugControlList.SelectedIndexChanged += new EventHandler( this.lvDrugControlList_SelectedIndexChanged );
        }

        #region 变量

        //定义药房管理类
        private Neusoft.HISFC.Management.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.Management.Pharmacy.DrugStore( );
        //定义当前选择科室
        private Neusoft.NFC.Object.NeuObject currentDept = new Neusoft.NFC.Object.NeuObject( );
        //定义当前选择的摆药台信息
        private DrugControl currentDrugControlInfo = new DrugControl( );

        #endregion

        #region 方法


        #region 初始化信息

        /// <summary>
        /// 初始化摆药台列表信息
        /// </summary>
        private void InitDrugControlList( )
        {
            this.lvDrugControlList.SuspendLayout( );
            this.lvDrugControlList.Columns.Clear( );
            this.lvDrugControlList.Items.Clear( );
            this.lvDrugControlList.Columns.Add( "摆药台名称" , 120 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "调用程序" , 100 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "发送类型" , 80 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "显示等级" , 120 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "所属药房" , 100 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "备注" , 200 , HorizontalAlignment.Left );
            this.lvDrugControlList.ResumeLayout( );
        }

        /// <summary>
        /// 初始化摆药台调用程序列表
        /// </summary>
        private void InitDrugAttribute( )
        {
            if( !this.DesignMode )
            {
                this.CbxUser.AddItems( DrugAttribute.List( ) );
            }
        }

        #endregion

        #region 摆药台设置信息

        /// <summary>
        /// 设置要编辑摆药台的详细信息( to tabpage2)
        /// </summary>
        /// <param name="drugControl">当前编辑的摆药台</param>
        public void SetDrugControlInfo( DrugControl drugControl )
        {
            this.currentDrugControlInfo = drugControl;

            this.txtName.Text = this.currentDrugControlInfo.Name;
            this.CbxUser.Tag = this.currentDrugControlInfo.DrugAttribute.ID;
            this.CbxSendType.SelectedIndex = this.currentDrugControlInfo.SendType;
            this.CbxShowGrade.SelectedIndex = this.currentDrugControlInfo.ShowLevel;
            this.RtxMark.Text = this.currentDrugControlInfo.Memo;
        }

        /// <summary>
        /// 获得摆药台编辑信息(from tabpage2)
        /// </summary>
        /// <returns>当前编辑摆药台</returns>
        public DrugControl GetNewDrugControlInfo( )
        {
            this.currentDrugControlInfo.Name = this.txtName.Text;                   //摆药台名称
            this.currentDrugControlInfo.DrugAttribute.ID = this.CbxUser.Tag;        //摆药台执行程序
            this.currentDrugControlInfo.SendType = this.CbxSendType.SelectedIndex;  //医嘱发送类型（1集中发送，2临时发送）
            this.currentDrugControlInfo.Memo = this.RtxMark.Text;                   //备注
            this.currentDrugControlInfo.Dept = this.currentDept;                    //摆药科室
            this.currentDrugControlInfo.ShowLevel = this.CbxShowGrade.SelectedIndex;//显示等级：0显示科室汇总，1显示科室明细，2显示患者明细

            return currentDrugControlInfo;
        }
        /// <summary>
        /// 取得摆药台显示属性名称
        /// </summary>
        /// <param name="showType"></param>
        private string GetShowTypeName( int showType )
        {
            string showTypeName;
            switch( showType )
            {
                case 0:
                    showTypeName = "显示科室汇总";
                    break;
                case 1:
                    showTypeName = "显示科室明细";
                    break;
                default:
                    showTypeName = "显示患者明细";
                    break;
            }
            return showTypeName;
        }
        /// <summary>
        /// 向摆药台列表中插入新节点
        /// </summary>
        /// <param name="drugControl">摆药台信息</param>
        /// <returns>插入的节点信息</returns>
        private ListViewItem AddDrugControlToListView( DrugControl drugControl )
        {
            //设置插入的节点信息
            ListViewItem lvi = new ListViewItem( );
            //区别新增加和已保存的图标
            if( drugControl.ID != "" )
            {
                lvi.ImageIndex = 0;
            }
            else
            {
                lvi.ImageIndex = 1;
            }
            lvi.Text = drugControl.Name;
            //Tag属性保存摆药单分类实体
            lvi.Tag = drugControl;
            //设置listView的子节点

            lvi.SubItems.Add( drugControl.DrugAttribute.Name );
            lvi.SubItems.Add( drugControl.SendType == 0 ? "全部" : ( drugControl.SendType == 1 ? "集中" : "临时" ) );
            lvi.SubItems.Add( this.GetShowTypeName(drugControl.SendType) );
            lvi.SubItems.Add( this.currentDept.Name );
            lvi.SubItems.Add( drugControl.Memo );
            //返回插入的节点
            return this.lvDrugControlList.Items.Add( lvi );
        }

        /// <summary>
        /// 设置全部摆药单为未选中状态
        /// </summary>
        private void ResetDrugBill( )
        {
            if( this.lvPutDrugBill1.Items.Count > 0 )
            {
                foreach( ListViewItem lvi in this.lvPutDrugBill1.Items )
                {
                    lvi.Checked = false;
                }
            }
        }

        /// <summary>
        /// 显示当前摆药台中的明细列表
        /// </summary>
        private void ShowBillListByDrugControl(  )
        {
            this.lvPutDrugBill1.BeginUpdate( );
            this.ResetDrugBill( );
            //取此摆药台对应的摆药单明细列表
            ArrayList al = this.drugStore.QueryDrugControlDetailList( currentDrugControlInfo.ID );
            if( al == null )
            {
                MessageBox.Show( this.drugStore.Err );
                return;
            }
            //在摆药单分类列表中显示当前摆药台的明细数据
            DrugBillClass billClass;
            foreach( DrugBillClass info in al )
            {
                //取摆药台明细中的每一条数据，在ListView中查找相同的项目，并将checked属性置为true
                foreach( ListViewItem lvi in this.lvPutDrugBill1.Items )
                {
                    billClass = lvi.Tag as DrugBillClass;
                    if( billClass.ID == info.ID )
                    {
                        lvi.Checked = true;
                    }
                }
            }
            this.lvPutDrugBill1.EndUpdate( );

        }

        /// <summary>
        /// 按科室显示摆药台信息
        /// </summary>
        /// <param name="dept">科室信息</param>
        /// <returns></returns>
        private void ShowDrugControlByDept( )
        {
            this.lvDrugControlList.Items.Clear( );

            //重新初始化摆药单信息
            this.ResetDrugBill( );
            if( currentDept.ID  == "" )
            {
                return ;
            }
            //取本科室全部摆药台列表
            ArrayList al = this.drugStore.QueryDrugControlList( currentDept.ID );
            if( al == null )
            {
                MessageBox.Show( this.drugStore.Err );
                return ;
            }
            //添加到到摆药台列表
            foreach( DrugControl controlInfo in al )
            {
                this.AddDrugControlToListView( controlInfo );
            }
        }

        #endregion

        #region 数据操作

        /// <summary>
        /// 增加摆药单
        /// </summary>
        private void AddDrugControl( )
        {
           //清理摆药单选择状态
            this.ResetDrugBill( );
           //清理摆药台选状态
            //置所有的非当前摆药台为未选中状态
            foreach( ListViewItem L in this.lvDrugControlList.CheckedItems )
            {
                L.Checked = false;
            }
            //设置要插入的节点
            DrugControl newInfo = new DrugControl( );
            newInfo.Name = "新建摆药台";

            //在ListView中插入新节点			
            ListViewItem lvi = this.AddDrugControlToListView( newInfo );
            //选中新增加的节点
            lvi.Selected = true;
            lvi.Checked = true;

            //在编辑信息中显示新增加的摆药台并切换到tabpage2
            this.SetDrugControlInfo( newInfo );
            this.neuTabControl1.TabPages.Remove( this.tabPage2 );
            this.neuTabControl1.TabPages.Add( this.tabPage2 );
            this.neuTabControl1.SelectedIndex = 1;
        }

        /// <summary>
        /// 删除单条摆药单
        /// </summary>
        private void DeleteDrugControl( )
        {
            //判断是否选中一个摆药台
            if( this.lvDrugControlList.SelectedItems.Count > 0 )
            {
                //获取当前摆药台信息
                this.GetNewDrugControlInfo( );
            }
            else
            {
                MessageBox.Show( "请选择您要删除的摆药台！" );
                return;
            }

            if( this.currentDrugControlInfo.ID != "" )
            {
                DialogResult result = MessageBox.Show( "您确定要删除【" + this.currentDrugControlInfo.Name + "】摆药台吗？" , "删除提示" , System.Windows.Forms.MessageBoxButtons.OKCancel );
                if( result == DialogResult.Cancel ) return;

                int parm;
                Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction( Neusoft.NFC.Management.Connection.Instance );
                this.drugStore.SetTrans( trans.Trans );

                //删除旧摆药台摆药明细中的所有数据
                parm = this.drugStore.DeleteDrugControl( this.currentDrugControlInfo.ID );

                if( parm == -1 )
                {
                    trans.RollBack( );
                    MessageBox.Show( this.drugStore.Err ,"提示");
                    return;
                }
                else
                {
                    trans.Commit( );
                }
            }

            //删除Listview中的节点
            this.lvDrugControlList.SelectedItems[ 0 ].Remove( );

            //如果ListView仍有节点，则选中第一个
            if( this.lvDrugControlList.Items.Count > 0 )
            {
                this.lvDrugControlList.Items[ 0 ].Selected = true;
            }
            this.neuTabControl1.SelectedIndex = 0;
        }
        /// <summary>
        /// 保存摆药单信息
        /// </summary>
        private void SaveDrugControl( )
        {
            //判断是否选择摆药单
            if( this.lvPutDrugBill1.CheckedItems.Count == 0 )
            {
                MessageBox.Show( "请为摆药台添加摆药单。" );
                return;
            }

            //判断是否选中一个摆药台
            if( this.lvDrugControlList.SelectedItems.Count > 0 )
            {
                //获取当前摆药台最新的编辑信息myDrugControlInfo
                this.GetNewDrugControlInfo( );
            }
            else
            {
                MessageBox.Show( "请选择一个摆药台。" );
                return;
            }
            //如果是新增加的摆药台，则取此摆药台的流水号
            if( currentDrugControlInfo.ID == "" )
            {
                currentDrugControlInfo.ID = this.drugStore.GetDrugControlNO( );
                if( currentDrugControlInfo.ID == "-1" )
                {
                    MessageBox.Show( "取摆药台流水号时失败:" + this.drugStore.Err );
                    return;
                }
            }

            int parm;
            Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction( Neusoft.NFC.Management.Connection.Instance );
            t.BeginTransaction( );
            drugStore.SetTrans( t.Trans );

            try
            {
                //先删除旧摆药台摆药明细中的所有数据，然后插入新的数据。
                parm = drugStore.DeleteDrugControl( currentDrugControlInfo.ID );
                if( parm == -1 )
                {
                    t.RollBack( );
                    MessageBox.Show( this.drugStore.Err );
                    return;
                }
                else
                {
                    //插入摆药台数据
                    foreach( ListViewItem lvi in this.lvPutDrugBill1.CheckedItems )
                    {
                        DrugBillClass info = lvi.Tag as DrugBillClass;
                        //为摆药台明细赋值
                        currentDrugControlInfo.DrugBillClass.ID = info.ID;
                        currentDrugControlInfo.DrugBillClass.Name = info.Name;

                        //插入摆药台明细数据
                        parm = this.drugStore.InsertDrugControl( currentDrugControlInfo );
                        if( parm != 1 )
                        {
                            t.RollBack( );
                            MessageBox.Show( this.drugStore.Err );
                            return;
                        }
                    }
                }
                //提交数据库
                t.Commit( );
                this.neuTabControl1.TabPages.Remove( this.tabPage2 );
                this.neuTabControl1.SelectedIndex = 0;
                MessageBox.Show( "摆药台设置成功！" );
            }
            catch( Exception ex )
            {
                t.RollBack( );
                MessageBox.Show( "保存摆药台数据时出错：" + ex.Message );
                return;
            }

            //更新listView上节点
            this.lvDrugControlList.SelectedItems[ 0 ].Tag = currentDrugControlInfo;
            this.lvDrugControlList.SelectedItems[ 0 ].Text = currentDrugControlInfo.Name;
            //区别新增加和已保存的图标
            if( currentDrugControlInfo.ID != "" )
            {
                this.lvDrugControlList.SelectedItems[ 0 ].ImageIndex = 0;
            }
            else
            {
                this.lvDrugControlList.SelectedItems[ 0 ].ImageIndex = 1;
            }
            //设置listView的子节点
            

            this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 1 ].Text = currentDrugControlInfo.DrugAttribute.Name;
            this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 2 ].Text = currentDrugControlInfo.SendType == 0 ? "全部" : ( currentDrugControlInfo.SendType == 1 ? "集中" : "临时" );
            this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 3 ].Text = this.GetShowTypeName( currentDrugControlInfo.SendType );
            this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 4 ].Text = this.currentDept.Name;
            this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 5 ].Text = currentDrugControlInfo.Memo;
        }
        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// 选择科室时发生（与科室控件通信）
        /// </summary>
        /// <param name="neuObject">控件名称</param>
        /// <param name="e">当前选中的树节点信息</param>
        /// <returns></returns>
        protected override int OnSetValue( object neuObject , TreeNode e )
        {
            try
            {
                if( e != null )
                {
                    //当前选择的科室
                    this.currentDept = e.Tag as Neusoft.NFC.Object.NeuObject;

                    //显示当前科室的摆药台信息
                    this.ShowDrugControlByDept( );
                }
                else
                {
                    this.currentDept = new Neusoft.NFC.Object.NeuObject( );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message ,"提示");
            }
            return base.OnSetValue( neuObject , e );
        }
        /// <summary>
        /// 摆药台类表双击进入摆药台编辑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDrugControlList_DoubleClick( object sender , EventArgs e )
        {
            if( this.lvDrugControlList.SelectedItems.Count > 0 )
            {
                //显示摆药单编辑信息
                this.neuTabControl1.TabPages.Remove( this.tabPage2 );
                this.neuTabControl1.TabPages.Add( this.tabPage2 );
                this.SetDrugControlInfo( this.lvDrugControlList.SelectedItems[ 0 ].Tag as DrugControl );
            }
            else
            {
                //重新置摆药单为未选中状态
                this.ResetDrugBill();
                this.currentDrugControlInfo = new DrugControl( );
            }
        }

        /// <summary>
        /// 摆药台选择改变时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDrugControlList_SelectedIndexChanged( object sender , EventArgs e )
        {
            if( this.lvDrugControlList.SelectedItems.Count > 0 )
            {
                //置所有的非当前摆药台为未选中状态
                foreach( ListViewItem lvi in this.lvDrugControlList.CheckedItems )
                {
                   lvi.Checked = false;
                }
                this.lvDrugControlList.SelectedItems[ 0 ].Checked = true;
                //设置当前摆药台信息
                this.SetDrugControlInfo( this.lvDrugControlList.SelectedItems[ 0 ].Tag as DrugControl );
                //显示摆药台对应的摆药单信息
                this.ShowBillListByDrugControl(  );
            }
            else
            {
                //重新置摆药单为未选中状态
                this.ResetDrugBill( );
                this.currentDrugControlInfo = new DrugControl( );
            }
        }

        #endregion

        #region 工具栏信息

        ///// <summary>
        ///// 定义事件委托
        ///// </summary>
        //private event System.EventHandler ToolButtonClicked;
        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService( );

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            //初始化摆药台列表信息
            this.InitDrugControlList( );
            //初始化摆药台调用信息
            this.InitDrugAttribute( );
            //隐藏tabpage2
            this.neuTabControl1.TabPages.Remove( this.tabPage2 );
            base.OnLoad( e );
        }

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit( object sender , object neuObject , object param )
        {
            //this.ToolButtonClicked += new EventHandler( ToolButton_clicked );
            //增加工具栏
            this.toolBarService.AddToolButton( "增加" , "增加摆药台" , 0 , true , false ,null );
            this.toolBarService.AddToolButton( "删除" , "删除摆药台" , 1 , true , false , null );
            this.toolBarService.AddToolButton( "保存" , "保存设置" , 2 , true , false , null );
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
                    this.AddDrugControl( );
                    break;
                case "删除":
                    this.DeleteDrugControl( );
                    break;

                case "保存":
                    this.SaveDrugControl( );
                    break;
            }
           
        }
        #endregion


    }
}
