using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.NFC.Function;
using Neusoft.NFC.Management;

namespace Neusoft.UFC.DrugStore.Outpatient
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
    public partial class ucDrugTerminal : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDrugTerminal( )
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

        #endregion

        #region 属性

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return this.toolBarService.GetToolButton( "保存" ).Enabled;
            }
            set
            {
                this.toolBarService.SetToolButtonEnabled( "增加" , value );
                this.toolBarService.SetToolButtonEnabled( "删除" , value );
                this.toolBarService.SetToolButtonEnabled( "保存" , value );
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
        private void InitDeptTerminal( )
        {
            this.InitPrepareTerminalHeader( );
            this.InitSendDrugWindowHeader( );
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
                //添加节点
                this.SetItem( info );
            }
        }

        /// <summary>
        /// 设置终端属性
        /// </summary>
        /// <param name="drugTerminalClass">终端实体</param>
        private void SetTerminalProperty( Neusoft.HISFC.Object.Pharmacy.DrugTerminal drugTerminal )
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
        private Neusoft.HISFC.Object.Pharmacy.DrugTerminal GetTerminalProperty( )
        {
            try
            {
                DrugTerminalClass info = ( ( DrugTerminalClass )this.propertyGrid1.SelectedObject );
                if( info == null )
                    return null;

                Neusoft.HISFC.Object.Pharmacy.DrugTerminal temp = new Neusoft.HISFC.Object.Pharmacy.DrugTerminal( );
                //发药窗口
                if( this.neuTabControl1.SelectedTab == this.tabPage1 )
                {
                    temp = ( Neusoft.HISFC.Object.Pharmacy.DrugTerminal )this.neuListView1.SelectedItems[ 0 ].Tag;
                }
                else//配药台
                {
                    temp = ( Neusoft.HISFC.Object.Pharmacy.DrugTerminal )this.neuListView2.SelectedItems[ 0 ].Tag;
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
            if( info.TerminalType == Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.配药台 )//配药台
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
        /// 增加终端
        /// </summary>
        private void AddTerminal( )
        {
            Neusoft.HISFC.Object.Pharmacy.DrugTerminal info = new Neusoft.HISFC.Object.Pharmacy.DrugTerminal( );
            //配药台
            if( this.neuTabControl1.SelectedTab == this.tabPage1 )
            {
                info.Name = "新建发药窗口";
                info.TerminalType = Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.发药窗口;
                info.User01 = "New";
            }
            else
            {
                info.Name = "新建配药台";
                info.TerminalType = Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.配药台;
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
            Neusoft.HISFC.Object.Pharmacy.DrugTerminal drugTerminal;
            //如果没有选中节点，则返回
            //发药窗口
            if( neuTabControl1.SelectedTab == this.tabPage1 )
            {
                if( this.neuListView1.SelectedItems.Count > 0 )
                {
                    drugTerminal = this.neuListView1.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                }
                else
                {
                    return;
                }
            }
            else //配药台
            {
                if( this.neuListView2.SelectedItems.Count > 0 )
                {
                    drugTerminal = this.neuListView2.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                }
                else
                {
                    return;
                }
            }
            //确认删除
            DialogResult result = MessageBox.Show( Neusoft.NFC.Management.Language.Msg( "删除后将不能恢复，是否继续？" ) , Neusoft.NFC.Management.Language.Msg( "提示" ) , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 );
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
                    DialogResult res = MessageBox.Show( Neusoft.NFC.Management.Language.Msg( "该条记录为其他终端的替代终端、确认进行删除吗？" ) , Neusoft.NFC.Management.Language.Msg( "提示" ) , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 , MessageBoxOptions.RightAlign );
                    if( res == DialogResult.No )
                    {
                        return;
                    }
                }

                //定义数据库事务
                Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction( Neusoft.NFC.Management.Connection.Instance );
                t.BeginTransaction( );

                try
                {
                    this.drugStore.SetTrans( t.Trans );
                    //删除数据
                    if( this.drugStore.DeleteDrugTerminal( drugTerminal.ID ) == -1 )
                    {
                        t.RollBack( );
                        MessageBox.Show( this.drugStore.Err );
                        return;
                    }
                }
                catch( Exception ex )
                {
                    t.RollBack( );
                    MessageBox.Show( ex.Message );
                    return;
                }

                t.Commit( );
                MessageBox.Show( "删除成功" );
            }

            //从列表中删除
            // 发药窗口
            if( neuTabControl1.SelectedTab == this.tabPage1 )
            {
                if( this.neuListView1.SelectedItems.Count > 0 )
                {
                    this.neuListView1.Items.Remove( this.neuListView1.SelectedItems[ 0 ] );
                }

            }
            else //配药台
            {
                if( this.neuListView2.SelectedItems.Count > 0 )
                {
                    this.neuListView2.Items.Remove( this.neuListView2.SelectedItems[ 0 ] );
                }
            }

        }

        /// <summary>
        ///  保存终端
        /// </summary>
        private void SaveTerminal( )
        {
            ListView currListView;
            //如果没有选中节点，则返回
            //发药窗口
            if( neuTabControl1.SelectedTab == this.tabPage1 )
            {
                if( this.neuListView1.Items.Count > 0 )
                {
                    currListView = this.neuListView1;
                }
                else
                {
                    return;
                }
            }
            else //配药台
            {
                if( this.neuListView2.Items.Count > 0 )
                {
                    currListView = this.neuListView2;
                }
                else
                {
                    return;
                }
            }
            //判断是否信息已填完整
            if( this.IsValid( ) == -1 )
            {
                return;
            }
            //判断是否存在重名信息
            if( this.isSameName( ) == -1 )
            {
                return;
            }

            Neusoft.HISFC.Object.Pharmacy.DrugTerminal info;
            //定义数据库事务
            Neusoft.NFC.Management.Transaction t = new Neusoft.NFC.Management.Transaction( Neusoft.NFC.Management.Connection.Instance );
            t.BeginTransaction( );
            try
            {
                this.drugStore.SetTrans( t.Trans );
                bool isSave = true;
                //保存数据
                for( int i = 0 ; i < currListView.Items.Count ; i++ )
                {
                    info = currListView.Items[ i ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                    info.Dept.ID = this.privDept.ID;
                    if( this.drugStore.SetDrugTerminal( info ) == -1 )
                    {	//先进行更新操作，如无数据则插入
                        isSave = false;
                        t.RollBack( );
                        MessageBox.Show( Language.Msg( "保存第" ) + i.ToString( ) + Language.Msg( "行时出错\n" ) + this.drugStore.Err );
                        break;
                    }
                }

                if( isSave )
                {
                    t.Commit( );
                    MessageBox.Show( Language.Msg( "保存成功" ) );
                }
                else
                {
                    return;
                }
            }
            catch( Exception ex )
            {
                t.RollBack( );
                MessageBox.Show( ex.Message );
                return;
            }

            //更新是否新增的标记
            for( int i = 0 ; i < currListView.Items.Count ; i++ )
            {
                info = currListView.Items[ i ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                info.User01 = "";
                currListView.Items[ i ].Tag = info;
            }
        }

        /// <summary>
        /// 判断是否信息已填完整
        /// </summary>
        /// <returns>成功返回1 失败返回－1 其他错误返回-2</returns>
        private int IsValid( )
        {

            ListView currListView;
            //发药窗口
            if( this.neuTabControl1.SelectedTab == this.tabPage1 )
            {
                currListView = this.neuListView1;
            }
            else//配药台
            {
                currListView = this.neuListView2;
            }

            Neusoft.HISFC.Object.Pharmacy.DrugTerminal info;
            int iCloseNum = 0;
            //是否关闭所有普通配药台
            bool closeFlag = true;
            for( int i = 0 ; i < currListView.Items.Count ; i++ )
            {
                info = currListView.Items[ i ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;

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

                if( info.RefreshInterval1.ToString( ) == "" )
                {
                    MessageBox.Show( Language.Msg( "请设置第" ) + ( i + 1 ).ToString( ) + Language.Msg( "行程序刷新时间间隔" ) );
                    return -1;
                }
                if( info.RefreshInterval2.ToString( ) == "" )
                {
                    MessageBox.Show( Language.Msg( "请设置第" ) + ( i + 1 ).ToString( ) + Language.Msg( "行打印/显示刷新间隔" ) );
                    return -1;
                }
                if( info.AlertQty.ToString( ) == "" )
                {
                    MessageBox.Show( Language.Msg( "请设置第" ) + ( i + 1 ).ToString( ) + Language.Msg( "行警戒线" ) );
                    return -1;
                }
                if( info.ShowQty.ToString( ) == "" )
                {
                    MessageBox.Show( Language.Msg( "请设置第" ) + ( i + 1 ).ToString( ) + Language.Msg( "行大屏幕显示患者人数" ) );
                    return -1;
                }
                #endregion

                //不允许关闭所有普通配药台
                if( info.TerminalProperty == Neusoft.HISFC.Object.Pharmacy.EnumTerminalProperty.普通 && !info.IsClose )
                {
                    closeFlag = false;
                }
                //配药台已存在发药窗口时才进行此项判断
                if( info.TerminalType == Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.配药台 )
                {
                    if( info.SendWindow.ID == "" )
                    {
                        MessageBox.Show( Language.Msg( "请为第" ) + ( i + 1 ).ToString( ) + Language.Msg( "行配药台设置发药窗口" ) );
                        return -1;
                    }
                    if( info.ReplaceTerminal.ID == info.ID )
                    {
                        MessageBox.Show( Language.Msg( "对" ) + info.Name + Language.Msg( "进行替代配药台设置时不允许自己替代自己" ) );
                        return -1;
                    }
                }
                //发药窗口不允许关闭
                if( info.TerminalType == Neusoft.HISFC.Object.Pharmacy.EnumTerminalType.发药窗口 )
                {
                    if( info.IsClose )
                    {
                        MessageBox.Show( "不允许关闭发药窗口 关闭相应的配药台即可以达到关闭发药窗口相同的效果" );
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
        /// 判断是否存在重名信息
        /// </summary>
        /// <returns>不存在重复成功返回1 失败返回-1</returns>
        private int isSameName( )
        {
            ListView currListView;
            //发药窗口
            if( this.neuTabControl1.SelectedTab == this.tabPage1 )
            {
                currListView = this.neuListView1;
            }
            else//配药台
            {
                currListView = this.neuListView2;
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
            //发药窗口
            if( this.neuTabControl1.SelectedTab == this.tabPage1 )
            {
                if( this.neuListView1.SelectedItems.Count > 0 )
                {
                    this.SetItem( this.GetTerminalProperty( ) , this.neuListView1.SelectedItems[ 0 ] );
                }
            }
            else //配药台
            {
                if( this.neuListView2.SelectedItems.Count > 0 )
                {
                    this.SetItem( this.GetTerminalProperty( ) , this.neuListView2.SelectedItems[ 0 ] );
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
            if( this.neuListView1.SelectedItems.Count > 0 )
            {
                Neusoft.HISFC.Object.Pharmacy.DrugTerminal info = this.neuListView1.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
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

            if( this.neuListView2.SelectedItems.Count > 0 )
            {
                Neusoft.HISFC.Object.Pharmacy.DrugTerminal info = this.neuListView2.SelectedItems[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
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
            Neusoft.HISFC.Object.Pharmacy.DrugTerminal info = null;
            if( this.neuTabControl1.SelectedTab == tabPage1 )
            {
                if( this.neuListView1.Items.Count > 0 )
                {
                    this.neuListView1.Items[ 0 ].Selected = true;
                    info = this.neuListView1.Items[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
                }
            }
            else
            {
                if( this.neuListView2.Items.Count > 0 )
                {
                    this.neuListView2.Items[ 0 ].Selected = true;
                    info = this.neuListView2.Items[ 0 ].Tag as Neusoft.HISFC.Object.Pharmacy.DrugTerminal;
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
            if( this.neuTabControl1.SelectedTab == tabPage1 )
            {
                this.neuListView1.View = View.Details;
            }
            else
            {
                this.neuListView2.View = View.Details;
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
            if( this.neuTabControl1.SelectedTab == tabPage1 )
            {
                this.neuListView1.View = View.LargeIcon;
            }
            else
            {
                this.neuListView2.View = View.LargeIcon;
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
            if( this.neuTabControl1.SelectedTab == tabPage1 )
            {
                this.neuListView1.View = View.SmallIcon;
            }
            else
            {
                this.neuListView2.View = View.SmallIcon;
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
            if( Neusoft.HISFC.Integrate.Pharmacy.ChoosePiv( "0300" ) )
            {
                this.IsEdit = true;
            }
            else
            {
                this.IsEdit = false;
            }

            //获取操作科室
            this.privDept = ( ( Neusoft.HISFC.Object.Base.Employee )this.drugStore.Operator ).Dept;
            //初始化科室数据
            this.InitDeptTerminal( );
            //选中tabpage1
            this.neuTabControl1.SelectedIndex = 0;
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
            this.SaveTerminal( );
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
