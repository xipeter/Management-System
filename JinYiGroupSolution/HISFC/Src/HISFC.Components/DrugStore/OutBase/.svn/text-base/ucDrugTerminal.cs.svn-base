using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.OutBase
{
    /// <summary>
    /// [控件名称:ucDrugTerminal]<br></br>
    /// [功能描述: 门诊终端设置]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-24]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDrugTerminal : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugTerminal( )
        {
            InitializeComponent( );

            this.propertyGrid1.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid1_PropertyValueChanged);
        }    

        #region 变量

        /// <summary>
        /// 操作员权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject( );

        /// <summary>
        /// 业务层管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore( );

        /// <summary>
        /// 打开界面时是否首先显示发药窗口Tabpage
        /// </summary>
        private bool isShowSendDrugWindowFirst = false;

        /// <summary>
        /// 保存后是否刷新界面
        /// </summary>
        private bool isSaveRefresh = false;

        #endregion

        #region 属性

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool IsEdit
        {
            set
            {
                this.toolBarService.SetToolButtonEnabled( "增加" , value );
                this.toolBarService.SetToolButtonEnabled( "删除" , value );
                this.toolBarService.SetToolButtonEnabled( "保存" , value );
            }
        }

        /// <summary>
        /// 打开界面时是否首先显示发药窗口Tabpage
        /// </summary>
        [Description( "打开界面时是否首先显示发药窗口Tab页" ),Category("设置"),DefaultValue(false)]
        public bool IsShowSendDrugWindowFirst
        {
            get
            {
                return isShowSendDrugWindowFirst;
            }
            set
            {
                isShowSendDrugWindowFirst = value;
            }
        }

        /// <summary>
        /// 是否显示属性上部工具栏
        /// </summary>
        [Description("是否显示属性上部工具栏"), Category("设置"), DefaultValue(true)]
        public bool IsShowPropertyToolBar
        {
            get
            {
                return this.propertyGrid1.ToolbarVisible;
            }
            set
            {
                this.propertyGrid1.ToolbarVisible = value;
            }
        }

        /// <summary>
        /// 是否保存后刷新界面
        /// </summary>
        [Description("是否保存后刷新界面"), Category("设置"), DefaultValue(false),Browsable(false)]
        public bool IsSaveRefresh
        {
            get
            {
                return isSaveRefresh;
            }
            set
            {
                isSaveRefresh = value;
            }
        }
        #endregion

        #region  方法

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsSaveRefresh = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Terminal_Save_Refresh, true, false);
        }

        /// <summary>
        /// 初始化发药窗口列表标题信息
        /// </summary>
        private void InitSendDrugWindowHeader( )
        {
            this.lvSendTerminal.SuspendLayout( );
            this.lvSendTerminal.Columns.Clear( );
            this.lvSendTerminal.Items.Clear( );
            this.lvSendTerminal.Columns.Add( "名称" , 140 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "终端性质" , 70 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "是否关闭" , 70 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "警戒线" , 55 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "替代终端" , 100 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "程序刷新间隔" , 100 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "大屏幕刷新间隔" , 100 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "显示人数" , 80 , HorizontalAlignment.Left );
            this.lvSendTerminal.Columns.Add( "备注" , 200 , HorizontalAlignment.Left );
            this.lvSendTerminal.ResumeLayout( );
        }

        /// <summary>
        /// 配药台列表标题信息
        /// </summary>
        private void InitPrepareTerminalHeader( )
        {
            this.lvDrugTerminal.SuspendLayout( );
            this.lvDrugTerminal.Columns.Clear( );
            this.lvDrugTerminal.Items.Clear( );
            this.lvDrugTerminal.Columns.Add( "名称" , 140 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "终端性质" , 70 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "是否关闭" , 70 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "警戒线" , 55 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "发药窗口" , 100 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "替代终端" , 100 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "程序刷新间隔" , 100 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "是否自动打印" , 100 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "显示人数" , 80 , HorizontalAlignment.Left );
            this.lvDrugTerminal.Columns.Add( "备注" , 200 , HorizontalAlignment.Left );
            this.lvDrugTerminal.ResumeLayout( );
        }

        /// <summary>
        /// 初始化科室终端数据
        /// </summary>
        private void InitDeptTerminal( )
        {
            this.InitPrepareTerminalHeader( );
            this.InitSendDrugWindowHeader( );
            //初始化配药台
            this.InitData( Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.配药台 );
            //初始化发药窗口
            this.InitData(Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口);
        }

        /// <summary>
        /// 根据科室、终端类型初始化
        /// </summary>
        /// <param name="enumType"></param>
        protected virtual void InitData( Neusoft.HISFC.Models.Pharmacy.EnumTerminalType enumType )
        {
            //根据库房编码、终端类型检索数据
            ArrayList al = drugStore.QueryDrugTerminalByDeptCode( this.privDept.ID , ( NConvert.ToInt32( enumType ) ).ToString( ) );
            if( al == null )
            {
                MessageBox.Show( this.drugStore.Err );
                return;
            }
            Neusoft.HISFC.Models.Pharmacy.DrugTerminal info;
            for( int i = 0 ; i < al.Count ; i++ )
            {
                info = al[ i ] as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                if( info == null )
                {
                    continue;
                }
                //添加节点
                this.SetItem( info );
            }
        }

        /// <summary>
        /// 设置终端属性
        /// </summary>
        /// <param name="drugTerminalClass">终端实体</param>
        private void SetTerminalProperty( Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal )
        {
            try
            {
                if( drugTerminal == null )
                {
                    this.propertyGrid1.SelectedObject = null;
                    return;
                }
                DrugTerminalClass property = new DrugTerminalClass( this.privDept.ID , drugTerminal.TerminalType.GetHashCode( ).ToString( ) );                

                property.名称 = drugTerminal.Name;
                property.类别 = drugTerminal.TerminalType;
                property.性质 = drugTerminal.TerminalProperty;

                //获取替代终端名称
                property.替代终端 = GetTerminalName( drugTerminal , "1" );
                //获取发药窗口名称
                property.发药窗口 = GetTerminalName( drugTerminal , "0" );

                property.是否关闭 = drugTerminal.IsClose ? "是" : "否";
                property.是否自动打印 = drugTerminal.IsAutoPrint ? "是" : "否";
                property.程序刷新间隔 = drugTerminal.RefreshInterval1;
                property.显示刷新间隔 = drugTerminal.RefreshInterval2;
                property.警戒线 = drugTerminal.AlertQty;
                property.显示人数 = drugTerminal.ShowQty;
                property.备注 = drugTerminal.Memo;
                property.打印类型 = drugTerminal.TerimalPrintType;

                //属性控件赋值
                this.propertyGrid1.SelectedObject = property;
                this.propertyGrid1.Focus( );
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message );
                return;
            }
        }

        /// <summary>
        /// 由属性控件内读取更改的属性值
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugTerminal GetTerminalProperty( )
        {
            try
            {
                DrugTerminalClass info = ( ( DrugTerminalClass )this.propertyGrid1.SelectedObject );
                if( info == null )
                    return null;

                Neusoft.HISFC.Models.Pharmacy.DrugTerminal temp = new Neusoft.HISFC.Models.Pharmacy.DrugTerminal( );
                //发药窗口
                if( this.neuTabControl1.SelectedTab == this.tpSend )
                {
                    temp = ( Neusoft.HISFC.Models.Pharmacy.DrugTerminal )this.lvSendTerminal.SelectedItems[ 0 ].Tag;
                }
                else//配药台
                {
                    temp = ( Neusoft.HISFC.Models.Pharmacy.DrugTerminal )this.lvDrugTerminal.SelectedItems[ 0 ].Tag;
                }

                temp.Name = info.名称;
                temp.TerminalType = info.类别;
                temp.TerminalProperty = info.性质;
                //获取替代终端编号
                string tempStr = info.替代终端;
                if( tempStr != "" && tempStr != "无替代" )
                {		//如tempStr 为初始设置时 为空 
                    int index = tempStr.IndexOf( ">" );
                    temp.ReplaceTerminal.ID = tempStr.Substring( 1 , index - 1 );
                }
                else
                {
                    temp.ReplaceTerminal.ID = "";
                }

                temp.IsClose = info.是否关闭 == "是" ? true : false;
                temp.IsAutoPrint = info.是否自动打印 == "是" ? true : false;
                temp.RefreshInterval1 = info.程序刷新间隔;
                temp.RefreshInterval2 = info.显示刷新间隔;
                temp.AlertQty = info.警戒线;
                temp.ShowQty = info.显示人数;
                //获取发药窗口终端编号
                string temp1 = info.发药窗口;
                if( !string.IsNullOrEmpty( temp1 ) )
                {
                    int index1 = temp1.IndexOf( ">" );
                    temp.SendWindow.ID = temp1.Substring( 1 , index1 - 1 );
                }

                temp.Memo = info.备注;
                temp.TerimalPrintType = info.打印类型;

                return temp;
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message );
                return null;
            }
        }

        /// <summary>
        /// 获取终端名称
        /// </summary>
        /// <param name="drugTerminal">终端实体</param>
        /// <param name="type">类型0发药窗口1替代终端</param>
        /// <returns>名称</returns>
        private string GetTerminalName( Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal , string type )
        {
            string tempStr;
            if( type == "0" )
            {
                tempStr = drugTerminal.SendWindow.ID;
            }
            else
            {
                tempStr = drugTerminal.ReplaceTerminal.ID;
            }

            if( !string.IsNullOrEmpty( tempStr ) )
            {
                int index = tempStr.IndexOf( ">" );
                if( index == -1 )
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugTerminal temp = new Neusoft.HISFC.Models.Pharmacy.DrugTerminal( );
                    temp = this.drugStore.GetDrugTerminalById( tempStr );
                    if( temp != null )
                    {
                        tempStr = "<" + temp.ID + ">" + temp.Name;
                    }
                }
                else
                {
                    //<编号> 名称 
                    tempStr = drugTerminal.SendWindow.ID;
                }
            }
            return tempStr;
        }

        /// <summary>
        /// 设置ListView
        /// </summary>
        /// <param name="info">当前的DrugTerminal实体</param>
        private void SetItem( Neusoft.HISFC.Models.Pharmacy.DrugTerminal info )
        {
            ListViewItem item = new ListViewItem( );
            this.SetItem( info , item );
            //发药窗口
            if( info.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口 )
            {
                this.lvSendTerminal.Items.Add( item ).Selected = true;
            }
            else //配药台
            {
                this.lvDrugTerminal.Items.Add( item ).Selected = true;
            }
        }

        /// <summary>
        /// 设置ListView
        /// </summary>
        /// <param name="info">当前的DrugTerminal实体</param>
        /// <param name="item">当前的ListViewItem</param>
        private void SetItem( Neusoft.HISFC.Models.Pharmacy.DrugTerminal info , ListViewItem item )
        {
            if (info == null)
            {
                return;
            }

            //清空
            item.SubItems.Clear( );
            //终端名称
            item.Name = info.ID;
            item.Text = info.Name;
            item.Tag = info;
            item.ImageIndex = 0;
            item.StateImageIndex = 1;
            //终端性质
            item.SubItems.Add( ( ( Neusoft.HISFC.Models.Pharmacy.EnumTerminalProperty )NConvert.ToInt32( info.TerminalProperty ) ).ToString( ) );
            //是否关闭
            item.SubItems.Add( info.IsClose ? "是" : "否" );
            //警戒线
            item.SubItems.Add( info.AlertQty.ToString( ) );
            //发药窗口
            if( info.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.配药台 )//配药台
            {
                item.SubItems.Add( this.GetTerminalName( info , "0" ) );
            }
            //替代终端
            item.SubItems.Add( this.GetTerminalName( info , "1" ) );
            //程序刷行间隔
            item.SubItems.Add( info.RefreshInterval1.ToString( ) );
            //发药窗口
            if( info.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口 )
            {
                //大屏幕显示间隔
                item.SubItems.Add( info.RefreshInterval2.ToString( ) );
            }
            else //配药台
            {
                //是否自动打印
                item.SubItems.Add( info.IsAutoPrint ? "是" : "否" );
            }
            //显示人数
            item.SubItems.Add( info.ShowQty.ToString( ) );
            //备注
            item.SubItems.Add( info.Memo );
            //关闭的终端用红色显示
            if( info.IsClose )
            {
                item.ForeColor = System.Drawing.Color.Red;
            }

        }

        /// <summary>
        /// 增加终端
        /// </summary>
        private void AddTerminal( )
        {
            Neusoft.HISFC.Models.Pharmacy.DrugTerminal info = new Neusoft.HISFC.Models.Pharmacy.DrugTerminal( );
            //配药台
            if( this.neuTabControl1.SelectedTab == this.tpSend )
            {
                info.Name = "新建发药窗口";
                info.TerminalType = Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口;
                info.User01 = "New";
            }
            else
            {
                info.Name = "新建配药台";
                info.TerminalType = Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.配药台;
                info.User01 = "New";
            }
            //添加节点
            this.SetItem( info );

        }

        /// <summary>
        /// 删除终端
        /// </summary>
        private void DeleteTerminal( )
        {
            Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal;
            //如果没有选中节点，则返回
            //发药窗口
            if( neuTabControl1.SelectedTab == this.tpSend )
            {
                if (this.lvSendTerminal.Items.Count == 1)
                {
                    MessageBox.Show(Language.Msg("系统内应至少保留一个发药窗口 不能全部删除"));
                    return;
                }
                if( this.lvSendTerminal.SelectedItems.Count > 0 )
                {
                    drugTerminal = this.lvSendTerminal.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                    //判断该发药窗口是否已设置对应其它配药台
                    if (!this.IsSendWindowValid(drugTerminal.ID))
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else //配药台
            {
                if (this.lvDrugTerminal.Items.Count == 1)
                {
                    MessageBox.Show(Language.Msg("系统内应至少保留一个配药台 不能全部删除"));
                    return;
                }

                if( this.lvDrugTerminal.SelectedItems.Count > 0 )
                {
                    drugTerminal = this.lvDrugTerminal.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                    //当本台开放时 检查是否其他台全部关闭 如果全部关闭应至少开放一个台
                    if (!drugTerminal.IsClose)
                    {
                        bool isAllClose = true ;
                        for (int i = 0; i < this.lvDrugTerminal.Items.Count; i++)
                        {
                            Neusoft.HISFC.Models.Pharmacy.DrugTerminal tempTerminal = this.lvDrugTerminal.Items[i].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                            if (tempTerminal.ID != drugTerminal.ID && !tempTerminal.IsClose)
                            {
                                isAllClose = false;
                                break;
                            }
                        }
                        if (isAllClose)
                        {
                            MessageBox.Show(Language.Msg("删除本台后 其它台全部处于关闭状态 应至少开放一台后再关闭本台"));
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            if (this.drugStore.IsHaveRecipe(drugTerminal.ID))
            {
                MessageBox.Show(Language.Msg("该终端还存在未取药处方 不能进行删除操作"));
                return;
            }

            //确认删除
            DialogResult result = MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "删除后将不能恢复，是否继续？" ) , Neusoft.FrameWork.Management.Language.Msg( "提示" ) , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 );
            if( result == DialogResult.No )
            {
                return;
            }
            //判断是否已经保存的数据
            if( !( drugTerminal.User01 == "New" ) )
            {
                int parm;
                //判断该终端是否为其他终端的替代终端、提示操作员
                parm = this.drugStore.IsReplaceFlag( drugTerminal.ID );
                if( parm == -1 )
                {
                    return;
                }
                if( parm == 1 )
                {
                    //提示用户是否确认删除
                    DialogResult res = MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "该条记录为其他终端的替代终端、确认进行删除吗？" ) , Neusoft.FrameWork.Management.Language.Msg( "提示" ) , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 , MessageBoxOptions.RightAlign );
                    if( res == DialogResult.No )
                    {
                        return;
                    }
                }

                //定义数据库事务
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );
                //t.BeginTransaction( );

                try
                {
                    this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    //删除数据
                    if( this.drugStore.DeleteDrugTerminal( drugTerminal.ID ) == -1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show( this.drugStore.Err );
                        return;
                    }
                }
                catch( Exception ex )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( ex.Message );
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show( "删除成功" );
            }

            //从列表中删除
            // 发药窗口
            if( neuTabControl1.SelectedTab == this.tpSend )
            {
                if( this.lvSendTerminal.SelectedItems.Count > 0 )
                {
                    this.lvSendTerminal.Items.Remove( this.lvSendTerminal.SelectedItems[ 0 ] );
                }

            }
            else //配药台
            {
                if( this.lvDrugTerminal.SelectedItems.Count > 0 )
                {
                    this.lvDrugTerminal.Items.Remove( this.lvDrugTerminal.SelectedItems[ 0 ] );
                }
            }

        }

        /// <summary>
        ///  保存终端
        /// </summary>
        private int SaveTerminal( )
        {
            //重新获取当前选中的信息
            this.propertyGrid1_Leave(null, System.EventArgs.Empty);

            ListView currListView;
            //如果没有选中节点，则返回
            //发药窗口
            if( neuTabControl1.SelectedTab == this.tpSend )
            {
                if( this.lvSendTerminal.Items.Count > 0 )
                {
                    currListView = this.lvSendTerminal;
                }
                else
                {
                    return -1;
                }
            }
            else //配药台
            {
                if( this.lvDrugTerminal.Items.Count > 0 )
                {
                    currListView = this.lvDrugTerminal;
                }
                else
                {
                    return -1;
                }
            }
            //判断是否信息已填完整
            if( this.IsValid( ) == -1 )
            {
                return -1;
            }
            //判断是否存在重名信息
            if( this.isSameName( ) == -1 )
            {
                return -1;
            }

            Neusoft.HISFC.Models.Pharmacy.DrugTerminal info;
            //定义数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );
            //t.BeginTransaction( );
            try
            {
                this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                bool isSave = true;
                //保存数据
                for( int i = 0 ; i < currListView.Items.Count ; i++ )
                {
                    info = currListView.Items[ i ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                    info.Dept.ID = this.privDept.ID;
                    if( this.drugStore.SetDrugTerminal( info ) == -1 )
                    {	//先进行更新操作，如无数据则插入
                        isSave = false;
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show( Language.Msg( "保存第" ) + i.ToString( ) + Language.Msg( "行时出错\n" ) + this.drugStore.Err );
                        break;
                    }
                }

                if( isSave )
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show( Language.Msg( "保存成功" ) );
                }
                else
                {
                    return -1;
                }
            }
            catch( Exception ex )
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( ex.Message );
                return -1;
            }

            //更新是否新增的标记
            for( int i = 0 ; i < currListView.Items.Count ; i++ )
            {
                info = currListView.Items[ i ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                info.User01 = "";
                currListView.Items[ i ].Tag = info;
            }

            return 1;
        }

        /// <summary>
        /// 判断是否信息已填完整
        /// </summary>
        /// <returns>成功返回1 失败返回－1 其他错误返回-2</returns>
        private int IsValid( )
        {

            ListView currListView;
            //发药窗口
            if( this.neuTabControl1.SelectedTab == this.tpSend )
            {
                currListView = this.lvSendTerminal;
            }
            else//配药台
            {
                currListView = this.lvDrugTerminal;
            }

            Neusoft.HISFC.Models.Pharmacy.DrugTerminal info;
            int iCloseNum = 0;
            //是否关闭所有普通配药台
            bool closeFlag = true;
            for( int i = 0 ; i < currListView.Items.Count ; i++ )
            {
                info = currListView.Items[ i ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;

                #region 终端通用判断

                if( info == null )
                {
                    MessageBox.Show( Language.Msg( "第" ) + ( i + 1 ).ToString( ) + Language.Msg( "行类型转换错误" ) );
                    return -2;
                }

                if( info.Name == "" )
                {
                    MessageBox.Show( Language.Msg( "请输入第" ) + ( i + 1 ).ToString( ) + Language.Msg( "行终端名称" ) );
                    return -1;
                }

                if( info.RefreshInterval1.ToString( ) == "" || info.RefreshInterval1 == 0)
                {
                    MessageBox.Show( Language.Msg( "请设置" + info.Name + " 程序刷新时间间隔" ) );
                    return -1;
                }
                if( info.RefreshInterval2.ToString( ) == "" || info.RefreshInterval2 == 0)
                {
                    MessageBox.Show( Language.Msg( "请设置 " + info.Name + " 打印/显示刷新间隔" ) );
                    return -1;
                }
                if( info.AlertQty.ToString( ) == "" || info.AlertQty == 0)
                {
                    MessageBox.Show( Language.Msg( "请设置 " + info.Name + " 警戒线" ) );
                    return -1;
                }
                if( info.ShowQty.ToString( ) == "" || info.ShowQty == 0)
                {
                    MessageBox.Show( Language.Msg( "请设置 " + info.Name + " 大屏幕显示患者人数" ) );
                    return -1;
                }
                #endregion

                if (!this.IsValid(info))
                {
                    return -1;
                }

                //不允许关闭所有普通配药台
                if( info.TerminalProperty == Neusoft.HISFC.Models.Pharmacy.EnumTerminalProperty.普通 && !info.IsClose )
                {
                    closeFlag = false;
                }
                //配药台已存在发药窗口时才进行此项判断
                if( info.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.配药台 )
                {
                    if( info.SendWindow.ID == "" )
                    {
                        MessageBox.Show( Language.Msg( "请为 [" + info.Name + " ]配药台设置发药窗口" ) );
                        return -1;
                    }
                    if( info.ReplaceTerminal.ID == info.ID && info.ID != "")
                    {
                        MessageBox.Show( Language.Msg( "对" ) + info.Name + Language.Msg( "进行替代配药台设置时不允许自己替代自己" ) );
                        return -1;
                    }
                }
                //发药窗口不允许关闭
                if( info.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口 )
                {
                    if( info.IsClose )
                    {
                        MessageBox.Show( "不允许关闭发药窗口 关闭相应的配药台即可以达到关闭发药窗口相同的效果" );
                        info.IsClose = false;
                        return -1;
                    }
                }
                else
                {
                    if( info.IsClose )
                    {
                        iCloseNum = iCloseNum + 1;
                    }
                }
            }
            if( iCloseNum == currListView.Items.Count )
            {
                MessageBox.Show( Language.Msg( "不允许关闭所有配药台" ) );
                return -1;
            }
            if( closeFlag )
            {
                MessageBox.Show( Language.Msg( "不允许关闭所有普通配药台" ) );
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 判断终端部分信息是否有效
        /// </summary>
        /// <param name="drugTerminal">门诊终端实体</param>
        /// <returns>成功返回True 无效返回False</returns>
        private bool IsValid(Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal)
        {
            if (drugTerminal == null)
            {
                return false;
            }

            if (drugTerminal.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口)
            {
                if (drugTerminal.IsClose)
                {
                    MessageBox.Show(Language.Msg("不能对发药窗口进行关闭"));
                    return false;
                }
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(drugTerminal.Name, 32))
            {
                MessageBox.Show(Language.Msg("终端名称过长 请适当简略"));
                return false;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(drugTerminal.Memo, 50))
            {
                MessageBox.Show(Language.Msg("终端备注过长 请适当简略"));
                return false;
            }
            if (drugTerminal.RefreshInterval1 > 999)
            {
                MessageBox.Show(Language.Msg("刷新间隔应小于999"));
                return false;
            }
            if (drugTerminal.RefreshInterval2 > 999)
            {
                MessageBox.Show(Language.Msg("刷新间隔小于999"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断终端信息是否有效并进行修改
        /// </summary>
        /// <param name="drugTerminal">门诊终端实体</param>
        /// <returns>成功返回True 无效返回False</returns>
        private bool IsValidAndModify(ref Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal)
        {
            if (drugTerminal == null)
            {
                return false;
            }

            if (drugTerminal.TerminalType == Neusoft.HISFC.Models.Pharmacy.EnumTerminalType.发药窗口)
            {
                if (drugTerminal.IsClose)
                {
                    MessageBox.Show(Language.Msg("不能对发药窗口进行关闭"));
                    drugTerminal.IsClose = false;
                    return false;
                }
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(drugTerminal.Name, 32))
            {
                MessageBox.Show(Language.Msg("终端名称过长 请适当简略"));
                drugTerminal.Name = drugTerminal.Name.Substring(0, 32);
                return false;
            }
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(drugTerminal.Memo, 50))
            {
                MessageBox.Show(Language.Msg("终端备注过长 请适当简略"));
                drugTerminal.Memo = drugTerminal.Memo.Substring(0, 32);
                return false;
            }
            if (drugTerminal.RefreshInterval1 > 999 || drugTerminal.RefreshInterval1 <= 0)
            {
                MessageBox.Show(Language.Msg("刷新间隔应介于0与999之间"));
                drugTerminal.RefreshInterval1 = 10;
                return false;
            }
            if (drugTerminal.RefreshInterval2 > 999 || drugTerminal.RefreshInterval2 <= 0)
            {
                MessageBox.Show(Language.Msg("刷新间隔应介于0与999之间"));
                drugTerminal.RefreshInterval2 = 55;
                return false;
            }
            if (drugTerminal.AlertQty > 99 || drugTerminal.AlertQty <= 0)
            {
                MessageBox.Show(Language.Msg("警戒线应介于0与99之间"));
                drugTerminal.AlertQty = 15;
                return false;
            }
            if (drugTerminal.ShowQty > 99 || drugTerminal.ShowQty <= 0)
            {
                MessageBox.Show(Language.Msg("显示人数应介于0与99之间"));
                drugTerminal.ShowQty = 20;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 配药台对应发药窗口是否有效
        /// </summary>
        /// <returns></returns>
        private bool IsSendWindowValid(string sendTerminalID)
        {
            for (int i = 0; i < this.lvDrugTerminal.Items.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.DrugTerminal info = this.lvDrugTerminal.Items[i].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;

                //配药台已存在发药窗口时才进行此项判断
                if (info.SendWindow.ID == sendTerminalID)
                {
                    MessageBox.Show(Language.Msg("该发药窗口已设置对应 [" + info.Name + " ]配药台 请对该配药台重新设置发药窗口 然后删除发药窗口"));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 判断是否存在重名信息
        /// </summary>
        /// <returns>不存在重复成功返回1 失败返回-1</returns>
        private int isSameName( )
        {
            ListView currListView;
            //发药窗口
            if( this.neuTabControl1.SelectedTab == this.tpSend )
            {
                currListView = this.lvSendTerminal;
            }
            else//配药台
            {
                currListView = this.lvDrugTerminal;
            }

            for( int i = 0 ; i < currListView.Items.Count - 1 ; i++ )
            {
                string name = currListView.Items[ i ].Text;

                for( int j = i + 1 ; j < currListView.Items.Count ; j++ )
                {
                    if( currListView.Items[ j ].Text == name )
                    {
                        MessageBox.Show( Language.Msg( "第 " ) + ( i + 1 ).ToString( ) + Language.Msg( " 行终端名称与第 " ) + ( j + 1 ).ToString( ) + Language.Msg( " 行名称重复！\n请重新设置" ) );
                        return -1;
                    }
                }
            }
            return 1;
        }
        #endregion

        #region 事件

        /// <summary>
        /// 当属性控件失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertyGrid1_Leave( object sender , EventArgs e )
        {           
         

        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {            
            //发药窗口
            if (this.neuTabControl1.SelectedTab == this.tpSend)
            {
                if (this.lvSendTerminal.SelectedItems.Count > 0)
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugTerminal sendTerminal = this.GetTerminalProperty();

                    if (!this.IsValidAndModify(ref sendTerminal))
                    {
                        this.SetTerminalProperty(sendTerminal);
                    }
                    this.SetItem(sendTerminal, this.lvSendTerminal.SelectedItems[0]);
                }
                else
                {
                    MessageBox.Show(Language.Msg("请选择需修改终端"));
                }
            }
            else //配药台
            {
                if (this.lvDrugTerminal.SelectedItems.Count > 0)
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal = this.GetTerminalProperty();

                    if (!this.IsValidAndModify(ref drugTerminal))
                    {
                        this.SetTerminalProperty(drugTerminal);
                    }
                    this.SetItem(drugTerminal, this.lvDrugTerminal.SelectedItems[0]);
                }
                else
                {
                    MessageBox.Show(Language.Msg("请选择需修改终端"));
                }
            }
        }

        /// <summary>
        /// 发药窗口选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuListView1_SelectedIndexChanged( object sender , EventArgs e )
        {
            if( this.lvSendTerminal.SelectedItems.Count > 0 )
            {
                Neusoft.HISFC.Models.Pharmacy.DrugTerminal info = this.lvSendTerminal.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                this.SetTerminalProperty( info );
            }
        }

        /// <summary>
        /// 配药台选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuListView2_SelectedIndexChanged( object sender , EventArgs e )
        {

            if( this.lvDrugTerminal.SelectedItems.Count > 0 )
            {
                Neusoft.HISFC.Models.Pharmacy.DrugTerminal info = this.lvDrugTerminal.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                this.SetTerminalProperty( info );
            }

        }

        /// <summary>
        /// 切换配药台、发药窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTabControl1_SelectedIndexChanged( object sender , EventArgs e )
        {
            Neusoft.HISFC.Models.Pharmacy.DrugTerminal info = null;
            if( this.neuTabControl1.SelectedTab == tpSend )
            {
                if( this.lvSendTerminal.Items.Count > 0 )
                {
                    this.lvSendTerminal.Items[ 0 ].Selected = true;
                    info = this.lvSendTerminal.Items[ 0 ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                }
            }
            else
            {
                if( this.lvDrugTerminal.Items.Count > 0 )
                {
                    this.lvDrugTerminal.Items[ 0 ].Selected = true;
                    info = this.lvDrugTerminal.Items[ 0 ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;
                }
            }

            this.SetTerminalProperty( info );
        }

        /// <summary>
        /// 增加终端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdd_Click( object sender , EventArgs e )
        {
            this.AddTerminal( );
        }

        /// <summary>
        /// 删除终端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click( object sender , EventArgs e )
        {
            this.DeleteTerminal( );
        }

        /// <summary>
        /// 列表显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShowList_Click( object sender , EventArgs e )
        {
            if( this.neuTabControl1.SelectedTab == tpSend )
            {
                this.lvSendTerminal.View = View.Details;
            }
            else
            {
                this.lvDrugTerminal.View = View.Details;
            }
            //设置状态
            this.menuShowLarge.Checked = false;
            this.menuShowSmall.Checked = false;
            this.menuShowList.Checked = true;
        }

        /// <summary>
        /// 大图标显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShowLarge_Click( object sender , EventArgs e )
        {
            if( this.neuTabControl1.SelectedTab == tpSend )
            {
                this.lvSendTerminal.View = View.LargeIcon;
            }
            else
            {
                this.lvDrugTerminal.View = View.LargeIcon;
            }
            //设置状态
            this.menuShowLarge.Checked = true;
            this.menuShowSmall.Checked = false;
            this.menuShowList.Checked = false;
        }

        /// <summary>
        /// 小图标显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuShowSmall_Click( object sender , EventArgs e )
        {
            if( this.neuTabControl1.SelectedTab == tpSend )
            {
                this.lvSendTerminal.View = View.SmallIcon;
            }
            else
            {
                this.lvDrugTerminal.View = View.SmallIcon;
            }
            //设置状态
            this.menuShowLarge.Checked = false;
            this.menuShowSmall.Checked = true;
            this.menuShowList.Checked = false;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            //判断操作员是否拥有操作权限 
            if( Neusoft.HISFC.BizProcess.Integrate.Pharmacy.ChoosePiv( "0300" ) )
            {
                this.IsEdit = true;
            }
            else
            {
                this.IsEdit = false;
            }

            //获取操作科室
            this.privDept = ( ( Neusoft.HISFC.Models.Base.Employee )this.drugStore.Operator ).Dept;
            //初始化科室数据
            this.InitDeptTerminal( );
            //根据属性设置判断首先显示那个Tab页
            if( this.isShowSendDrugWindowFirst )
            {
                this.neuTabControl1.SelectedIndex = 0;
            }
            else
            {
                this.neuTabControl1.SelectedIndex = 1;
            }

            this.InitControlParam();

            base.OnLoad( e );
        }

        /// <summary>
        /// 保存摆药台设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <returns></returns>
        protected override int OnSave( object sender , object NeuObject )
        {
            if (this.SaveTerminal() == 1)
            {
                if (this.isSaveRefresh)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在刷新界面显示"));
                    Application.DoEvents();

                    this.InitDeptTerminal();

                    this.propertyGrid1.SelectedObject = null;

                    //根据属性设置判断首先显示那个Tab页
                    Neusoft.HISFC.Models.Pharmacy.DrugTerminal info;
                    if (this.neuTabControl1.SelectedTab == this.tpDrug)
                    {
                        if (this.lvDrugTerminal.Items.Count > 0)
                        {
                            this.lvDrugTerminal.Items[0].Selected = true;

                            info = this.lvDrugTerminal.Items[0].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;

                            this.SetTerminalProperty(info);
                        }
                    }
                    else
                    {
                        if (this.lvSendTerminal.Items.Count > 0)
                        {
                            this.lvSendTerminal.Items[0].Selected = true;

                            info = this.lvSendTerminal.Items[0].Tag as Neusoft.HISFC.Models.Pharmacy.DrugTerminal;

                            this.SetTerminalProperty(info);
                        }
                    }

                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                }
            }

            return base.OnSave( sender , NeuObject );
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

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit( object sender , object NeuObject , object param )
        {
            //this.ToolButtonClicked += new EventHandler( ToolButton_clicked );
            //增加工具栏
            this.toolBarService.AddToolButton( "增加" , "增加终端" , 0 , true , false , null );
            this.toolBarService.AddToolButton( "删除" , "删除终端" , 1 , true , false , null );
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
                    this.AddTerminal( );
                    break;
                case "删除":
                    this.DeleteTerminal( );
                    break;
            }

        }

        #endregion



    }
}
