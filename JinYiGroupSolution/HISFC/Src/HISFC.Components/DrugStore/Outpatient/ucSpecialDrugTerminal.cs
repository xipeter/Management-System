using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.NFC.Management;

namespace Neusoft.UFC.DrugStore.Outpatient
{
    /// <summary>
    /// [控件名称:ucSpecialDrugTerminal]<br></br>
    /// [功能描述: 门诊特殊终端维护]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucSpecialDrugTerminal : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucSpecialDrugTerminal( )
        {
            InitializeComponent( );
        }

        #region 变量

        /// <summary>
        /// 存储药品列表
        /// </summary>
        List<Neusoft.HISFC.Object.Pharmacy.Item> drugItemList;
        /// <summary>
        /// 存储科室列表
        /// </summary>
        ArrayList deptList;
        /// <summary>
        /// 存储收费类别列表
        /// </summary>
        ArrayList feeItemList;
        /// <summary>
        /// 挂号级别
        /// </summary>
        ArrayList regLevelList;
        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.NFC.Public.ObjectHelper personHelper = new Neusoft.NFC.Public.ObjectHelper( );
        /// <summary>
        /// 操作员权限科室
        /// </summary>
        private Neusoft.NFC.Object.NeuObject privDept = new Neusoft.NFC.Object.NeuObject( );

        /// <summary>
        /// 业务层管理类
        /// </summary>
        private Neusoft.HISFC.Management.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.Management.Pharmacy.DrugStore( );
        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.Integrate.Manager manager = new Neusoft.HISFC.Integrate.Manager( );
        /// <summary>
        /// 是否有权限编辑
        /// </summary>
        private bool isPrivilegeEdit = false;

        #endregion

        #region 属性

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return this.isPrivilegeEdit;
            }
            set
            {
                this.isPrivilegeEdit = value;
                this.toolBarService.SetToolButtonEnabled( "增加" , value );
                this.toolBarService.SetToolButtonEnabled( "删除" , value );
                this.toolBarService.SetToolButtonEnabled( "保存" , value );
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化基本数据
        /// </summary>
        private void InitConstant( )
        {
            //获取药品简单信息列表
            Neusoft.HISFC.Management.Pharmacy.Item item = new Neusoft.HISFC.Management.Pharmacy.Item( );

            drugItemList = item.QueryItemAvailableList( );
            if( drugItemList == null )
            {
                MessageBox.Show( item.Err );
                return;
            }

            //获取科室信息列表
            deptList = manager.GetDepartment( Neusoft.HISFC.Object.Base.EnumDepartmentType.C );
            if( deptList == null )
            {
                MessageBox.Show( manager.Err );
                return;
            }

            //获取结算类别
            manager.GetConstantList( Neusoft.HISFC.Object.Base.EnumConstant.PACKUNIT );
            if( feeItemList == null )
            {
                MessageBox.Show( manager.Err );
                return;
            }

            //获取人员列表
            ArrayList al = manager.QueryEmployeeAll( );
            if( al == null )
            {
                MessageBox.Show( "获取人员信息出错" + manager.Err );
                return;
            }
            this.personHelper.ArrayObject = al;

            //获取挂号级别(暂时屏蔽)
            //Neusoft.HISFC.Management.Registration.RegLevel regLevelManager = new Neusoft.HISFC.Management.Registration.RegLevel( );
            //this.regLevelList = regLevelManager.Query( );
            //if( this.regLevelList == null )
            //{
            //    MessageBox.Show( "获取挂号级别出错" + regLevelManager.Err );
            //    return -1;
            //}

            return;
        }

        /// <summary>
        /// 检索数据显示
        /// </summary>
        private void ShowData( )
        {
            int index = this.neuSpread1.ActiveSheetIndex + 1;
            try
            {
                ArrayList al = this.drugStore.QueryDrugSPETerminalByDeptCode( this.privDept.ID , index.ToString( ) );
                if( al == null )
                {
                    MessageBox.Show( Language.Msg( "获取特殊配药台信息出错!" ) + this.drugStore.Err );
                    return;
                }

                this.neuSpread1.Sheets[ index ].Rows.Count = al.Count;
                Neusoft.HISFC.Object.Pharmacy.DrugSPETerminal info;

                for( int i = 0 ; i < al.Count ; i++ )
                {
                    info = al[ i ] as Neusoft.HISFC.Object.Pharmacy.DrugSPETerminal;
                    if( info == null )
                    {
                        continue;
                    }
                    //配药台名称
                    this.neuSpread1.Sheets[ index ].Cells[ i , 0 ].Text = info.Terminal.Name;
                    //特殊项目名称
                    this.neuSpread1.Sheets[ index ].Cells[ i , 1 ].Text = info.Item.Name;
                    //备注
                    this.neuSpread1.Sheets[ index ].Cells[ i , 2 ].Text = info.Memo;
                    //操作员
                    if( this.personHelper != null )
                    {
                        this.neuSpread1.Sheets[ index ].Cells[ i , 3 ].Text = this.personHelper.GetName( info.Oper.ID );
                    }
                    //操作时间
                    this.neuSpread1.Sheets[ index ].Cells[ i , 4 ].Text = info.Oper.OperTime.ToString( );
                    //配药台编码
                    this.neuSpread1.Sheets[ index ].Cells[ i , 5 ].Text = info.Terminal.ID;
                    //特殊项目编码
                    this.neuSpread1.Sheets[ index ].Cells[ i , 6 ].Text = info.Item.ID;
                    // 0 数据库检索 1 本次新添加
                    this.neuSpread1.Sheets[ index ].Cells[ i , 7 ].Text = "0";
                    //实体
                    this.neuSpread1.Sheets[ index ].Rows[ i ].Tag = info;
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message );
                return;
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            //取操作员权限科室（暂时以所在科室代替 ）
            this.privDept = ( ( Neusoft.HISFC.Object.Base.Employee )this.drugStore.Operator ).Dept;

            //判断是否有模版维护权限
            Neusoft.HISFC.Management.Manager.UserPowerDetailManager user = new Neusoft.HISFC.Management.Manager.UserPowerDetailManager( );
            //ArrayList alPrivDetail = user.QueryUserPriv( this.drugStore.Operator.ID , "0350" , this.privDept.ID );
            //if( alPrivDetail != null )
            //{
            //    foreach( Neusoft.NFC.Object.NeuObject privInfo in alPrivDetail )
            //    {
            //        //门诊终端维护权限
            //        if( privInfo.ID == "01" )
            //        {
            //            this.isPrivilegeEdit = true;
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    this.isPrivilegeEdit = true;
            //}
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm( Language.Msg( "正在加载门诊终端信息...." ) );
            Application.DoEvents( );

            //初始化科室终端数据
            this.ucDrugTerminalList1.InitDeptTerminal( this.privDept.ID );

            //多线程加载数据
            System.Threading.ThreadStart start = new System.Threading.ThreadStart( this.InitConstant );
            System.Threading.Thread thread = new System.Threading.Thread( start );
            thread.Start( );

            //设置当前选中的第一个sheet
            this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet1;
            //初始化数据
            //this.ShowData( );

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm( );

            base.OnLoad( e );
        }

        /// <summary>
        /// 双击sheettab时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_SheetTabClick( object sender , FarPoint.Win.Spread.SheetTabClickEventArgs e )
        {
            
        }

        #endregion

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService( );

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit( object sender , object NeuObject , object param )
        {
            //增加工具栏
            this.toolBarService.AddToolButton( "增加" , "增加记录" , 0 , true , false , null );
            this.toolBarService.AddToolButton( "删除" , "删除记录" , 1 , true , false , null );

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
                    break;
                case "删除":
                    break;
            }

        }

        #endregion

        private void neuSpread1_ActiveSheetChanged( object sender , EventArgs e )
        {
            this.ShowData( );
        }


    }
}
