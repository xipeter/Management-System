using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.NFC.Function;

namespace Neusoft.UFC.DrugStore.Outpatient
{
    /// <summary>
    /// [控件名称: ucDrugTerminalList]<br></br>
    /// [功能描述: 门诊终端列表]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-24]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDrugTerminalList : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDrugTerminalList( )
        {
            InitializeComponent( );
        }

        #region 变量

        /// <summary>
        /// 操作员权限科室
        /// </summary>
        private Neusoft.NFC.Object.NeuObject privDept = new Neusoft.NFC.Object.NeuObject( );
        /// <summary>
        /// 业务层管理类
        /// </summary>
        private Neusoft.HISFC.Management.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.Management.Pharmacy.DrugStore( );
        /// <summary>
        /// 是否显示特殊的终端
        /// </summary>
        private bool isShowSpecialTerminal = true;
        /// <summary>
        /// 终端选择代理
        /// </summary>
        /// <param name="drugTerminal">当前选中的终端实体</param>
        public delegate void SelectTerminalHandler( Neusoft.HISFC.Object.Pharmacy.DrugTerminal drugTerminal );
        /// <summary>
        /// 终端选择事件
        /// </summary>
        public event SelectTerminalHandler SelectTerminalEvent;
        /// <summary>
        /// 终端双击事件代理
        /// </summary>
        /// <param name="drugTerminal">当前选中的终端实体</param>
        public delegate void SelectTerminalDoubleClickedHandler( Neusoft.HISFC.Object.Pharmacy.DrugTerminal drugTerminal );
        /// <summary>
        ///  终端双击事件
        /// </summary>
        public event SelectTerminalDoubleClickedHandler SelectTerminalDoubleClickedEvent;

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示特殊的终端
        /// </summary>
        [Description( "是否显示特殊终端" ) , Category( "设置" ) , DefaultValue( true )]
        public bool IsShowSpecialTerminal
        {
            get
            {
                return this.isShowSpecialTerminal;
            }
            set
            {
                this.isShowSpecialTerminal = value;
            }
        }
        /// <summary>
        /// 是否显示发药窗口
        /// </summary>
        [Description( "是否显示发药窗口" ) , Category( "设置" ) , DefaultValue( true )]
        public bool IsShowSendDrugWindow
        {
            get
            {
                if( this.neuTabControl1.Contains( this.tabPage1 ) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if( value )
                {
                    if( !this.neuTabControl1.Contains( this.tabPage1 ) )
                    {
                        this.neuTabControl1.TabPages.Add( this.tabPage1 );
                    }
                }
                else
                {
                    if( this.neuTabControl1.Contains( this.tabPage1 ) )
                    {
                        this.neuTabControl1.TabPages.Remove( this.tabPage1 );
                    }
                }
            }
        }
        /// <summary>
        ///是否显示配药台
        /// </summary>
        [Description( "是否显示配药台" ) , Category( "设置" ) , DefaultValue( true )]
        public bool IsShowPrepareTerminal
        {
            get
            {
                if( this.neuTabControl1.Contains( this.tabPage2 ) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if( value )
                {
                    if( !this.neuTabControl1.Contains( this.tabPage2 ) )
                    {
                        this.neuTabControl1.TabPages.Add( this.tabPage2 );
                    }
                }
                else
                {
                    if( this.neuTabControl1.Contains( this.tabPage2 ) )
                    {
                        this.neuTabControl1.TabPages.Remove( this.tabPage2 );
                    }
                }
            }
        }
        /// <summary>
        /// 是否显示选择框
        /// </summary>
        [Description( "是否显示选择框" ) , Category( "设置" ) , DefaultValue( false )]
        public bool IsShowCheckBox
        {
            get
            {
                if( this.neuTabControl1.Contains( this.tabPage1 ) )
                {
                    return this.neuListView1.CheckBoxes;
                }
                else
                {
                    return this.neuListView2.CheckBoxes;
                }
            }
            set
            {
                if( this.neuTabControl1.Contains( this.tabPage1 ) )
                {
                    this.neuListView1.CheckBoxes = value;
                }
                if( this.neuTabControl1.Contains( this.tabPage2 ) )
                {
                    this.neuListView2.CheckBoxes = value;
                }
            }
        }
        /// <summary>
        /// 当前选中终端列表
        /// </summary>
        [Description( "当前选中的终端列表,仅在显示CheckBox时有效" ) , Category( "设置" )]
        public List<Neusoft.HISFC.Object.Pharmacy.DrugTerminal> SelectedTerminal
        {
            get
            {
                List<Neusoft.HISFC.Object.Pharmacy.DrugTerminal> selectednodes = new  List<Neusoft.HISFC.Object.Pharmacy.DrugTerminal>( );
                ListView lvi;
                if(this.neuTabControl1.SelectedTab ==this.tabPage1)
                {
                    lvi = this.neuListView1;
                }
                else
                {
                    lvi = this.neuListView2;
                }
                foreach( ListViewItem item in lvi.Items)
                {
                    if( item.Checked)
                    {

                        selectednodes.Add( item.Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal );
                    }
                    else
                    {
                        selectednodes = null;
                    }
                }
                return selectednodes;
            }
        }

        #endregion

        #region  方法

            /// <summary>
            /// 初始化发药窗口列表标题信息
            /// </summary>
            private void InitSendDrugWindowHeader( )
            {
                this.neuListView1.SuspendLayout( );
                this.neuListView1.Columns.Clear( );
                this.neuListView1.Items.Clear( );
                this.neuListView1.Columns.Add( "名称" , 140 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "终端性质" , 70 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "是否关闭" , 70 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "警戒线" , 55 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "替代终端" , 100 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "程序刷新间隔" , 100 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "大屏幕刷新间隔" , 100 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "显示人数" , 80 , HorizontalAlignment.Left );
                this.neuListView1.Columns.Add( "备注" , 200 , HorizontalAlignment.Left );
                this.neuListView1.ResumeLayout( );
            }

            /// <summary>
            /// 配药台列表标题信息
            /// </summary>
            private void InitPrepareTerminalHeader( )
            {
                this.neuListView2.SuspendLayout( );
                this.neuListView2.Columns.Clear( );
                this.neuListView2.Items.Clear( );
                this.neuListView2.Columns.Add( "名称" , 140 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "终端性质" , 70 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "是否关闭" , 70 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "警戒线" , 55 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "发药窗口" , 100 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "替代终端" , 100 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "程序刷新间隔" , 100 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "是否自动打印" , 100 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "显示人数" , 80 , HorizontalAlignment.Left );
                this.neuListView2.Columns.Add( "备注" , 200 , HorizontalAlignment.Left );
                this.neuListView2.ResumeLayout( );
            }

            /// <summary>
            /// 初始化科室终端数据
            /// </summary>
            public void InitDeptTerminal( string privDeptCode )
            {
                this.privDept.ID = privDeptCode;
                //初始化配药台
                this.InitData( Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.配药台 );
                //初始化发药窗口
                this.InitData( Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.发药窗口 );
            }

            /// <summary>
            /// 根据科室、终端类型初始化
            /// </summary>
            /// <param name="enumType"></param>
            protected virtual void InitData( Neusoft.HISFC.Object.Pharmacy.EnumTerminalType enumType )
            {
                //根据库房编码、终端类型检索数据
                ArrayList al = drugStore.QueryDrugTerminalByDeptCode( this.privDept.ID , ( NConvert.ToInt32( enumType ) ).ToString( ) );
                if( al == null )
                {
                    MessageBox.Show( this.drugStore.Err );
                    return;
                }
                Neusoft.HISFC.Object.Pharmacy.DrugTerminal info;
                for( int i = 0 ; i < al.Count ; i++ )
                {
                    info = al[ i ] as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                    if( info == null )
                    {
                        continue;
                    }
                    if( !this.IsShowSpecialTerminal && info.TerminalProperty == Neusoft.HISFC.Object.Pharmacy.EnumTerminalProperty.普通 )
                    {
                        continue;
                    }
                    //添加节点
                    this.SetItem( info );
                }
            }

            /// <summary>
            /// 设置ListView
            /// </summary>
            /// <param name="info">当前的DrugTerminal实体</param>
            private void SetItem( Neusoft.HISFC.Object.Pharmacy.DrugTerminal info )
            {
                ListViewItem item = new ListViewItem( );
                this.SetItem( info , item );
                //发药窗口
                if( info.TerminalType == Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.发药窗口 )
                {
                    this.neuListView1.Items.Add( item ).Selected = true;
                }
                else //配药台
                {
                    this.neuListView2.Items.Add( item ).Selected = true;
                }
            }

            /// <summary>
            /// 设置ListView
            /// </summary>
            /// <param name="info">当前的DrugTerminal实体</param>
            /// <param name="item">当前的ListViewItem</param>
            private void SetItem( Neusoft.HISFC.Object.Pharmacy.DrugTerminal info , ListViewItem item )
            {
                //清空
                item.SubItems.Clear( );
                //终端名称
                item.Name = info.ID;
                item.Text = info.Name;
                item.Tag = info;
                item.ImageIndex = 0;
                item.StateImageIndex = 1;
                //终端性质
                item.SubItems.Add( ( ( Neusoft.HISFC.Object.Pharmacy.EnumTerminalProperty )NConvert.ToInt32( info.TerminalProperty ) ).ToString( ) );
                //是否关闭
                item.SubItems.Add( info.IsClose ? "是" : "否" );
                //警戒线
                item.SubItems.Add( info.AlertQty.ToString( ) );
                //发药窗口
                if( info.TerminalType == Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.配药台)//配药台
                {
                    item.SubItems.Add( this.GetTerminalName( info , "0" ) );
                }
                //替代终端
                item.SubItems.Add( this.GetTerminalName( info , "1" ) );
                //程序刷行间隔
                item.SubItems.Add( info.RefreshInterval1.ToString( ) );
                //发药窗口
                if( info.TerminalType == Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.发药窗口 )
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
            /// 获取终端名称
            /// </summary>
            /// <param name="drugTerminal">终端实体</param>
            /// <param name="type">类型0发药窗口1替代终端</param>
            /// <returns>名称</returns>
            private string GetTerminalName( Neusoft.HISFC.Object.Pharmacy.DrugTerminal drugTerminal , string type )
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
                        Neusoft.HISFC.Object.Pharmacy.DrugTerminal temp = new Neusoft.HISFC.Object.Pharmacy.DrugTerminal( );
                        temp = this.drugStore.GetDrugTerminalById( drugTerminal.SendWindow.ID );
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

            #endregion

        #region 事件

            /// <summary>
            /// 初始化
            /// </summary>
            /// <param name="e"></param>
            protected override void OnLoad( EventArgs e )
            {
                //初始化数据
                this.InitPrepareTerminalHeader( );
                this.InitSendDrugWindowHeader( );
                base.OnLoad( e );
            }

            /// <summary>
            ///  发药窗口选择事件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void neuListView1_SelectedIndexChanged( object sender , EventArgs e )
            {
                if( this.neuListView1.SelectedItems.Count > 0 )
                {
                    if( this.SelectTerminalEvent != null )
                    {
                        this.SelectTerminalEvent( this.neuListView1.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal );
                    }
                }

            }

            /// <summary>
            /// 配药台选择事件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void neuListView2_SelectedIndexChanged( object sender , EventArgs e )
            {
                if( this.neuListView2.SelectedItems.Count > 0 )
                {
                    if( this.SelectTerminalEvent != null )
                    {
                        this.SelectTerminalEvent( this.neuListView2.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal );
                    }
                }
            }
            /// <summary>
            /// 发药窗口终端双击事件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void neuListView1_DoubleClick( object sender , EventArgs e )
            {
                if( this.neuListView1.SelectedItems.Count > 0 )
                {
                    if( this.SelectTerminalDoubleClickedEvent != null )
                    {
                        this.SelectTerminalDoubleClickedEvent( this.neuListView1.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal );
                    }
                }
            }
            /// <summary>
            /// 配药台终端双击事件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void neuListView2_DoubleClick( object sender , EventArgs e )
            {
                if( this.neuListView2.SelectedItems.Count > 0 )
                {
                    if( this.SelectTerminalDoubleClickedEvent != null )
                    {
                        this.SelectTerminalDoubleClickedEvent( this.neuListView2.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal );
                    }
                }
            }
            #endregion



        }
    }
