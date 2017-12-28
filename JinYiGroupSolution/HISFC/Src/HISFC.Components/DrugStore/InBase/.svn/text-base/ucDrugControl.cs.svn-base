using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.BizLogic.Pharmacy;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.HISFC.BizLogic.Manager;


namespace Neusoft.HISFC.Components.DrugStore.InBase
{
    /// <summary>
    /// [控件名称:ucDrugControl]<br></br>
    /// [功能描述: 摆药台设置]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-13]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDrugControl : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
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
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore( );
        //定义当前选择科室
        private Neusoft.FrameWork.Models.NeuObject currentDept = new Neusoft.FrameWork.Models.NeuObject( );
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
            this.lvDrugControlList.Columns.Add( "名称" , 120 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "用途" , 100 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "发送类型" , 80 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "显示等级" , 120 , HorizontalAlignment.Left );

            this.lvDrugControlList.Columns.Add( "自动打印" , 80 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "需要预览" , 80 , HorizontalAlignment.Left );
            this.lvDrugControlList.Columns.Add( "打印门诊标签" , 120 , HorizontalAlignment.Left );

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
                this.cmbUser.AddItems( DrugAttribute.List( ) );
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
            //摆药台名称
            this.txtName.Text = this.currentDrugControlInfo.Name;
            //摆药台属性
            this.cmbUser.Tag = this.currentDrugControlInfo.DrugAttribute.ID;
            //发送类型
            this.cmbSendType.SelectedIndex = this.currentDrugControlInfo.SendType;
            //显示等级
            this.cmbShowGrade.SelectedIndex = this.currentDrugControlInfo.ShowLevel;

            //是否自动打印摆药单
            this.cbxAutoPrint.Checked = this.currentDrugControlInfo.IsAutoPrint;

            //说明
            this.RtxMark.Text = this.currentDrugControlInfo.Memo;
        }

        /// <summary>
        /// 获得摆药台编辑信息(from tabpage2)
        /// </summary>
        /// <returns>当前编辑摆药台</returns>
        public DrugControl GetNewDrugControlInfo( )
        {
            //摆药台名称
            this.currentDrugControlInfo.Name = this.txtName.Text;
            //摆药台用途      
            this.currentDrugControlInfo.DrugAttribute.ID = this.cmbUser.Tag;
            //医嘱发送类型（1集中发送，2临时发送）
            this.currentDrugControlInfo.SendType = this.cmbSendType.SelectedIndex;
            //显示等级：0显示科室汇总，1显示科室明细，2显示患者明细     
            this.currentDrugControlInfo.ShowLevel = this.cmbShowGrade.SelectedIndex;

            //屏蔽摆药单自动打印功能
            ////是否自动打印摆药单
            //this.currentDrugControlInfo.IsAutoPrint = this.cbxAutoPrint.Checked ;
            this.currentDrugControlInfo.IsAutoPrint = false;


            //摆药科室      
            this.currentDrugControlInfo.Dept = this.currentDept;  
            //备注
            this.currentDrugControlInfo.Memo = this.RtxMark.Text; 

            return currentDrugControlInfo;
        }
        /// <summary>
        /// 取得摆药台显示属性名称
        /// 
        /// {AB3B4EEB-A1C5-4a37-AD42-4EF66DF8F859}  增加多种显示方式
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
                case 2:
                    showTypeName = "显示患者明细(摆药单优先)";
                    break;
                case 3:
                    showTypeName = "显示患者明细(患者优先)";
                    break;
                default:
                    showTypeName = "显示患者明细(摆药单优先)";
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

            //用途
            lvi.SubItems.Add( drugControl.DrugAttribute.Name );
            //发送类型
            lvi.SubItems.Add( drugControl.SendType == 0 ? "全部" : ( drugControl.SendType == 1 ? "集中" : "临时" ) );
            //显示等级
            lvi.SubItems.Add( this.GetShowTypeName(drugControl.ShowLevel) );

            //是否自动打印摆药单
            lvi.SubItems.Add( drugControl.IsAutoPrint ? "是" : "否" );
            //摆药单是否需要预览 打印门诊标签时该字段无效
            lvi.SubItems.Add( drugControl.IsBillPreview ? "是" : "否" );
            //是否打印门诊标签 该参数只对出院带药摆药有效
            lvi.SubItems.Add( drugControl.IsPrintLabel ? "是" : "否" );

            //所属药房
            lvi.SubItems.Add( this.currentDept.Name );
            //备注
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
        /// 增加摆药台
        /// </summary>
        private void AddDrugControl( )
        {
            if( currentDept.ID == "" )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择具体的科室" ) );
                return;
            }

            if (this.neuTabControl1.TabPages.ContainsKey(this.tabPage2.Name))
            {
                this.neuTabControl1.TabPages.Remove(this.tabPage2);
            }

           //清理摆药台选状态
            //置所有的非当前摆药台为未选中状态
            foreach( ListViewItem L in this.lvDrugControlList.Items )
            {
                L.Selected = false;
                L.Checked = false;
            }
            //清理摆药单选择状态
            this.ResetDrugBill();
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
            this.neuTabControl1.TabPages.Add( this.tabPage2 );
            this.neuTabControl1.SelectedIndex = 1;
        }


        /// <summary>
        /// 删除单条摆药台
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
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择您要删除的摆药台！") );
                return;
            }

            if( this.currentDrugControlInfo.ID != "" )
            {
                DialogResult result = MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "您确定要删除【" + this.currentDrugControlInfo.Name + "】摆药台吗？" ), Neusoft.FrameWork.Management.Language.Msg( "删除提示") , System.Windows.Forms.MessageBoxButtons.OKCancel );
                if( result == DialogResult.Cancel ) return;

                int parm;

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );

                this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //删除旧摆药台摆药明细中的所有数据
                parm = this.drugStore.DeleteDrugControl( this.currentDrugControlInfo.ID );

                if( parm == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( this.drugStore.Err ,Neusoft.FrameWork.Management.Language.Msg( "提示"));
                    return;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
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
        /// 保存有效性查询
        /// </summary>
        /// <returns>成功返回True  失败返回False</returns>
        private bool IsSaveDrugControlValid(DrugControl drugControl)
        {
            foreach (ListViewItem lv in this.lvDrugControlList.Items)
            {
                DrugControl tempDrugControl = lv.Tag as DrugControl;

                if (tempDrugControl != null && tempDrugControl.ID != drugControl.ID && tempDrugControl.Name == drugControl.Name)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(drugControl.Name + " 摆药台名称重复"));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 保存摆药台信息
        /// </summary>
        private void SaveDrugControl( )
        {
            if( currentDept.ID == "" )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择具体的科室" ) );
                return;
            }
            //判断是否选择摆药单
            if( this.lvPutDrugBill1.CheckedItems.Count == 0 )
            {
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请为摆药台添加摆药单!" ));
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
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "请选择一个摆药台。" ));
                return;
            }

            if (!this.IsSaveDrugControlValid(this.currentDrugControlInfo))
            {
                return;
            }

            if (this.currentDrugControlInfo.Name.Length > 16)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("摆药台名称超长,请适当简略"));
                return;
            }
            if (this.currentDrugControlInfo.Memo.Length > 30)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("备注超长,请适当简略"));
                return;
            }

            //如果是新增加的摆药台，则取此摆药台的流水号
            if( currentDrugControlInfo.ID == "" )
            {
                currentDrugControlInfo.ID = this.drugStore.GetDrugControlNO( );
                if( currentDrugControlInfo.ID == "-1" )
                {
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "取摆药台流水号时失败:") + this.drugStore.Err );
                    return;
                }
            }

            int parm;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );
            //t.BeginTransaction( );

            drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                //先删除旧摆药台摆药明细中的所有数据，然后插入新的数据。
                parm = drugStore.DeleteDrugControl( currentDrugControlInfo.ID );
                if( parm == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
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
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show( this.drugStore.Err );
                            return;
                        }
                    }
                }
                //提交数据库
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.neuTabControl1.SelectedIndex = 0;
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "摆药台设置成功！" ));
            }
            catch( Exception ex )
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "保存摆药台数据时出错：" + ex.Message ));
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

            //{9738B143-F85C-4255-8C5B-FD3EA729FE32}
            //currentDrugControlInfo.SendType 改为 currentDrugControlInfo.ShowLevel
            this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 3 ].Text = this.GetShowTypeName( currentDrugControlInfo.ShowLevel );

            //this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 4 ].Text = this.currentDept.Name;
            //this.lvDrugControlList.SelectedItems[ 0 ].SubItems[ 5 ].Text = currentDrugControlInfo.Memo;

            this.lvDrugControlList.SelectedItems[0].SubItems[4].Text = currentDrugControlInfo.IsAutoPrint ? "是" : "否";
            this.lvDrugControlList.SelectedItems[0].SubItems[5].Text = currentDrugControlInfo.IsBillPreview ? "是" : "否";
            this.lvDrugControlList.SelectedItems[0].SubItems[6].Text = currentDrugControlInfo.IsPrintLabel ? "是" : "否";

            this.lvDrugControlList.SelectedItems[0].SubItems[8].Text = currentDrugControlInfo.Memo;
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
                    if( e.Level == 1 )
                    {
                        //当前选择的科室
                        this.currentDept = e.Tag as Neusoft.FrameWork.Models.NeuObject;
                        //显示当前科室的摆药台信息
                        this.ShowDrugControlByDept( );
                    }
                    else
                    {
                        this.currentDept = new Neusoft.FrameWork.Models.NeuObject( );

                        if (this.isLoad)
                        {
                            this.isLoad = false;
                        }
                        else
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择具体的科室"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                        }
                    }
                }
                else
                {
                    this.currentDept = new Neusoft.FrameWork.Models.NeuObject( );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message ,Neusoft.FrameWork.Management.Language.Msg( "提示"));
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
                //显示摆药台编辑信息
                this.neuTabControl1.TabPages.Add( this.tabPage2 );
                this.SetDrugControlInfo( this.lvDrugControlList.SelectedItems[ 0 ].Tag as DrugControl );
                this.neuTabControl1.SelectedIndex = 1;
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
        /// <summary>
        /// tab切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTabControl1_SelectedIndexChanged( object sender , EventArgs e )
        {
            if( this.neuTabControl1.SelectedIndex == 0 )
            {
                this.neuTabControl1.TabPages.Remove( this.tabPage2 );
            }
        }
        /// <summary>
        /// 摆药台属性更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUser_SelectedIndexChanged( object sender , EventArgs e )
        {

        }
        /// <summary>
        /// 摆药单是否需要预览选择状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxPrintClinicLabel_CheckedChanged( object sender , EventArgs e )
        {

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
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService( );

        private bool isLoad = false;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            this.isLoad = true;

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
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit( object sender , object neuObject , object param )
        {
            //this.ToolButtonClicked += new EventHandler( ToolButton_clicked );
            //增加工具栏
            this.toolBarService.AddToolButton( "增加" , "增加摆药台" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加 , true , false ,null );
            this.toolBarService.AddToolButton( "删除" , "删除摆药台" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除 , true , false , null );
            return this.toolBarService;
        }

        /// <summary>
        /// 保存摆药台设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave( object sender , object neuObject )
        {
            //保存
            this.SaveDrugControl( );
            return base.OnSave( sender , neuObject );
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
            }
           
        }
        #endregion

 
    }
}
