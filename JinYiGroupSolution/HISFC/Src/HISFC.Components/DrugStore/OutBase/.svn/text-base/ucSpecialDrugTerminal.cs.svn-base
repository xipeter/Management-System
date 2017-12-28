using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.OutBase
{
    /// <summary>
    /// [控件名称:ucSpecialDrugTerminal]<br></br>
    /// [功能描述: 门诊特殊终端维护]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-29]<br></br>
    /// <修改记录 
    ///		修改人='梁俊泽' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的='Bug'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucSpecialDrugTerminal : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucSpecialDrugTerminal( )
        {
            InitializeComponent( );


            this.neuSpread1.ActiveSheetChanged += new EventHandler(neuSpread1_ActiveSheetChanged);

            this.ucDrugTerminalList1.SelectTerminalDoubleClickedEvent += new ucDrugTerminalList.SelectTerminalDoubleClickedHandler( ucDrugTerminalList1_SelectTerminalDoubleClickedEvent );
            this.ucDrugTerminalList1.SelectTerminalEvent += new ucDrugTerminalList.SelectTerminalHandler( ucDrugTerminalList1_SelectTerminalEvent );
        }     

        #region 变量

        /// <summary>
        /// 存储药品列表
        /// </summary>
        ArrayList drugItemList;

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
        ArrayList regLevelList = new ArrayList();

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper( );

        /// <summary>
        /// 操作员权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject( );

        /// <summary>
        /// 业务层管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStore = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore( );

        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager( );

        /// <summary>
        /// 是否有权限编辑
        /// </summary>
        private bool isPrivilegeEdit = false;
        
        /// <summary>
        /// 当前选择的终端实体
        /// </summary>
        Neusoft.HISFC.Models.Pharmacy.DrugTerminal currDrugTerminal = null;

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

        /// <summary>
        /// 是否显示挂号级别Sheet
        /// </summary>
        [Description("是否显示挂号基本调剂设置"),Category("设置"),DefaultValue(true)]
        public bool IsShowRegLevel
        {
            get
            {
                return this.neuSpread1.Sheets.Contains(this.sheetSpeRegLevel);
            }
            set
            {
                if (value)
                {
                    if (!this.neuSpread1.Sheets.Contains(this.sheetSpeRegLevel))
                    {
                        this.neuSpread1.Sheets.Add(this.sheetSpeRegLevel);
                    }
                }
                else
                {
                    if (this.neuSpread1.Sheets.Contains(this.sheetSpeRegLevel))
                    {
                        this.neuSpread1.Sheets.Remove(this.sheetSpeRegLevel);
                    }
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 设置neuSpread1格式和名称
        /// </summary>
        private void InitFp( )
        {
            for( int i = 0 ; i < this.neuSpread1.Sheets.Count ; i++ )
            {
                this.neuSpread1.Sheets[ i ].Reset( );
                this.neuSpread1.Sheets[ i ].ColumnCount = 10;
                this.neuSpread1.Sheets[ i ].RowCount = 0;
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 0 ).Text = "配药台名称";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 1 ).Text = "特殊项目";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 2 ).Text = "备注";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 3 ).Text = "操作员";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 4 ).Text = "操作时间";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 5 ).Text = "配药台编码";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 6 ).Text = "特殊项目编码";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 7 ).Text = "扩展标志1";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 8 ).Text = "扩展标志2";
                this.neuSpread1.Sheets[ i ].ColumnHeader.Cells.Get( 0 , 9 ).Text = "扩展标志3";
                this.neuSpread1.Sheets[ i ].Columns.Get( 0 ).Label = "配药台名称";
                this.neuSpread1.Sheets[ i ].Columns.Get( 0 ).Width = 125F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 0 ).Locked = true;

                this.neuSpread1.Sheets[ i ].Columns.Get( 1 ).Label = "特殊项目";
                this.neuSpread1.Sheets[ i ].Columns.Get( 1 ).Width = 120F;

                //收费窗口的项目是用户自己录入的，对应的是写在实际发药窗口本地配置文件（HISDefaultValue.xml）中
                if( this.neuSpread1.Sheets[i] == this.sheetSpeFeeWindow )
                {
                    this.neuSpread1.Sheets[ i ].Columns.Get( 1 ).Locked = false;
                    //如果是发药窗口，设置项目名称的背景
                    this.neuSpread1.Sheets[ i ].Columns.Get( 1 ).BackColor = Color.LightSkyBlue;
                }
                else
                {
                    this.neuSpread1.Sheets[ i ].Columns.Get( 1 ).Locked = true;
                    this.neuSpread1.Sheets[ i ].Columns.Get( 1 ).BackColor = Color.LightYellow;
                }

                this.neuSpread1.Sheets[ i ].Columns.Get( 2 ).Label = "备注";
                this.neuSpread1.Sheets[ i ].Columns.Get( 2 ).Width = 150F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 2 ).Locked = false;

                this.neuSpread1.Sheets[ i ].Columns.Get( 3 ).Label = "操作员";
                this.neuSpread1.Sheets[ i ].Columns.Get( 3 ).Width = 85F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 3 ).Locked = true;

                this.neuSpread1.Sheets[ i ].Columns.Get( 4 ).Label = "操作时间";
                this.neuSpread1.Sheets[ i ].Columns.Get( 4 ).Width = 120F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 4 ).Locked = true;

                this.neuSpread1.Sheets[ i ].Columns.Get( 5 ).Label = "配药台编码";
                this.neuSpread1.Sheets[ i ].Columns.Get( 5 ).Visible = false;
                this.neuSpread1.Sheets[ i ].Columns.Get( 5 ).Width = 77F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 6 ).Label = "特殊项目编码";
                this.neuSpread1.Sheets[ i ].Columns.Get( 6 ).Visible = false;
                this.neuSpread1.Sheets[ i ].Columns.Get( 6 ).Width = 87F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 7 ).Label = "扩展标志1";
                this.neuSpread1.Sheets[ i ].Columns.Get( 7 ).Visible = false;
                this.neuSpread1.Sheets[ i ].Columns.Get( 7 ).Width = 72F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 8 ).Label = "扩展标志2";
                this.neuSpread1.Sheets[ i ].Columns.Get( 8 ).Visible = false;
                this.neuSpread1.Sheets[ i ].Columns.Get( 8 ).Width = 71F;
                this.neuSpread1.Sheets[ i ].Columns.Get( 9 ).Label = "扩展标志3";
                this.neuSpread1.Sheets[ i ].Columns.Get( 9 ).Visible = false;
                this.neuSpread1.Sheets[ i ].Columns.Get( 9 ).Width = 67F;

                this.neuSpread1.Sheets[ i ].GrayAreaBackColor = System.Drawing.Color.White;
                this.neuSpread1.Sheets[ i ].OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
                this.neuSpread1.Sheets[ i ].RowHeader.Columns.Default.Resizable = false;

                switch( i )
                {
                    case 0:
                        this.neuSpread1.Sheets[ i ].SheetName = "药品类别";
                        break;
                    case 1:
                        this.neuSpread1.Sheets[ i ].SheetName = "专科类别";
                        break;
                    case 2:
                        this.neuSpread1.Sheets[ i ].SheetName = "结算类别";
                        break;
                    case 3:
                        this.neuSpread1.Sheets[ i ].SheetName = "收费窗口";
                        break;
                    case 4:
                        this.neuSpread1.Sheets[ i ].SheetName = "挂号级别";
                        break;
                }

            }
        }

        /// <summary>
        /// 初始化基本数据
        /// </summary>
        private void InitConstant( )
        {
            //获取药品简单信息列表
            Neusoft.HISFC.BizLogic.Pharmacy.Item item = new Neusoft.HISFC.BizLogic.Pharmacy.Item( );

            List<Neusoft.HISFC.Models.Pharmacy.Item> alDrug = item.QueryItemAvailableList( );
            if( alDrug == null )
            {
                MessageBox.Show( item.Err );
                return;
            }
            else //转换成ArrayList
            {
                this.drugItemList = new ArrayList( alDrug.ToArray( ) );
            }

            //获取科室信息列表
            this.deptList = manager.GetDepartment( Neusoft.HISFC.Models.Base.EnumDepartmentType.C );
            if( deptList == null )
            {
                MessageBox.Show( manager.Err );
                return;
            }

            //获取结算类别
            //this.feeItemList = manager.GetConstantList( Neusoft.HISFC.Models.Base.EnumConstant.PACTUNIT );
            Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            this.feeItemList = feeIntegrate.QueryPactUnitAll();
            if( feeItemList == null )
            {
                MessageBox.Show(feeIntegrate.Err);
                return;
            }

            //获取人员列表
            ArrayList al = manager.QueryEmployeeAll( );
            if( al == null )
            {
                MessageBox.Show( manager.Err );
                return;
            }
            this.personHelper.ArrayObject = al;

            //获取挂号级别(暂时屏蔽)
            //Neusoft.HISFC.BizLogic.Registration.RegLevel regLevelManager = new Neusoft.HISFC.BizLogic.Registration.RegLevel( );
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
        /// <param name="index">当前的SheetIndex</param>
        private void ShowData( int index)
        {
            
            try
            {
                ArrayList al = this.drugStore.QueryDrugSPETerminalByDeptCode( this.privDept.ID , ( index + 1 ).ToString( ) );
                if( al == null )
                {
                    MessageBox.Show( Language.Msg( "获取特殊配药台信息出错!" ) + this.drugStore.Err );
                    return;
                }

                this.neuSpread1.Sheets[ index ].Rows.Count = al.Count;
                Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal info;

                for( int i = 0 ; i < al.Count ; i++ )
                {
                    info = al[ i ] as Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal;
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

        /// <summary>
        /// 弹出窗口供操作员选择特殊项目
        /// </summary>
        private void ShowList( )
        {
            //如无数据则返回
            if( this.neuSpread1.ActiveSheet.Rows.Count == 0 )
            {
                return;
            }
            //获取当前活动的行、列
            int i = this.neuSpread1.ActiveSheet.ActiveRowIndex;
            //操作员对窗口选择返回的信息
            Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject( );
            ArrayList al;
            switch( this.neuSpread1.ActiveSheetIndex )
            {
                case 0:
                    al = this.drugItemList;
                    break;
                case 1:
                    al = this.deptList;
                    break;
                case 2:
                    al = this.feeItemList;
                    break;
                //case 3:
                //    break;
                case 4:
                    al = this.regLevelList;
                    return;
                default:
                    al = new ArrayList( );
                    return;
            }
            if( Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem( al , ref info ) == 0 )
            {
                return;
            }
            else
            {

                //特殊项目名称
                this.neuSpread1.ActiveSheet.Cells[ i , 1 ].Value = info.Name;
                //特殊项目编码
                this.neuSpread1.ActiveSheet.Cells[ i , 6 ].Value = info.ID;
            }
        }

        /// <summary>
        /// 添加记录
        /// </summary>
        private void AddTerminal( )
        {
            //判断是否有权限操作
            if( !this.isPrivilegeEdit )
            {
                return;
            }

            if( this.currDrugTerminal == null )
            {
                return;
            }
            //定义特殊终端实体
            Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal info = new Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal( );
            info.Terminal = this.currDrugTerminal;

            try
            {
                int rowCount = this.neuSpread1.ActiveSheet.Rows.Count;
                //添加一行
                this.neuSpread1.ActiveSheet.Rows.Add(rowCount, 1);
                //终端名称
                this.neuSpread1.ActiveSheet.Cells[rowCount, 0].Value = this.currDrugTerminal.Name;
                //终端ID
                this.neuSpread1.ActiveSheet.Cells[rowCount, 5].Value = this.currDrugTerminal.ID;

                //操作员
                this.neuSpread1.ActiveSheet.Cells[rowCount, 3].Value = this.drugStore.Operator.Name;
                //操作时间
                this.neuSpread1.ActiveSheet.Cells[rowCount, 4].Value = this.drugStore.GetDateTimeFromSysDateTime();

                //实体
                this.neuSpread1.ActiveSheet.Rows[rowCount].Tag = info;
                //新增标志
                this.neuSpread1.ActiveSheet.Cells[rowCount, 7].Text = "1";
            }
            catch
            {
                MessageBox.Show(this.neuSpread1.ActiveSheet.Rows.Count.ToString());
            }

        }

        /// <summary>
        /// 删除记录
        /// </summary>
        private void DeleteTerminal( )
        {           
            if (this.neuSpread1.ActiveSheet.Rows.Count <= 0)
            {
                return;
            }

            DialogResult result = MessageBox.Show(Language.Msg( "确实要删除该数据吗？") , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 );
            if( result == DialogResult.No )
            {
                return;
            }

            //定义数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Transaction t = new Transaction( Connection.Instance );
            //t.BeginTransaction( );
            this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                int i = this.neuSpread1.ActiveSheet.ActiveRowIndex;
                if( i < 0 )
                {
                    return;
                }
                //已经保存的数据、从数据库删除
                if( this.neuSpread1.ActiveSheet.Cells[ i , 7 ].Text == "0" )		
                {
                    Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal info = this.neuSpread1.ActiveSheet.Rows[ i ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal;
                    if( info == null )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show( Language.Msg( "删除特殊终端信息时发生类型转换错误!" ) );
                        return;
                    }
                    //删除数据
                    if( this.drugStore.DeleteDrugSPETerminal( info ) == -1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show( this.drugStore.Err );
                        return;
                    }
                }
                //从sheet中移除
                this.neuSpread1.ActiveSheet.Rows.Remove( i , 1 );
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show( Language.Msg( "删除成功" ) );
            }
            catch( Exception ex )
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( ex.Message );
                return;
            }
        }

        /// <summary>
        /// 检查数据完整性
        /// </summary>
        /// <returns>成功返回true 失败返回false</returns>
        private bool IsValid( )
        {
            bool isSuccess = true;

            //检查项目是否录入完整
            for( int i = 0 ; i < this.neuSpread1.ActiveSheet.Rows.Count ; i++ )
            {
                if (this.neuSpread1.ActiveSheet == this.sheetSpeFeeWindow)
                {
                    if (this.neuSpread1.ActiveSheet.Cells[i, 1].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请在特殊项目列内输入收费窗口号"));
                        isSuccess = false;
                        break;
                    }
                }
                else
                {
                    if (this.neuSpread1.ActiveSheet.Cells[i, 1].Text == "")
                    {
                        MessageBox.Show(Language.Msg("请双击或回车选择特殊项目"));
                        isSuccess = false;
                        break;
                    }
                }

                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.neuSpread1.ActiveSheet.Cells[i, 2].Text, 50))
                {
                    MessageBox.Show(Language.Msg("备注字段录入超长 请适当简略"));
                    return false;
                }

                if (this.neuSpread1.ActiveSheet == this.sheetSpeFeeWindow)
                {
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.neuSpread1.ActiveSheet.Cells[i, 1].Text, 12))
                    {
                        MessageBox.Show(Language.Msg("收费窗口特殊项目录入超长 请适当简略"));
                        return false;
                    }
                }
                else
                {
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.neuSpread1.ActiveSheet.Cells[i, 1].Text, 64))
                    {
                        MessageBox.Show(Language.Msg("特殊项目录入超长 请适当简略"));
                        return false;
                    }
                }
            
            }
            return isSuccess;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveTerminal( )
        {
            if( this.neuSpread1.ActiveSheet.Rows.Count <= 0 )
            {
                return;
            }
            if( !this.IsValid( ) )
            {
                return;
            }

            //项目类别(1药品2专科3结算类别4特定收费窗口5挂号级别)
            int index = this.neuSpread1.ActiveSheetIndex + 1;
            //定义数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Transaction t = new Transaction( Connection.Instance );
            //t.BeginTransaction( );
            this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 删除原数据

            try
            {
                if( this.drugStore.DeleteDrugSPETerminal( this.privDept.ID , index.ToString() ) == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( Language.Msg("执行保存操作 删除原数据过程中出错!") + this.drugStore.Err );
                    return;
                }
            }
            catch( Exception ex )
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( Language.Msg("执行保存操作 删除原数据过程中出错!") + ex.Message );
                return;
            }
            #endregion

            #region 保存新数据
            try
            {
                Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal info;
                //保存数据
                for( int i = 0 ; i < this.neuSpread1.ActiveSheet.Rows.Count ; i++ )
                {
                    info = this.neuSpread1.ActiveSheet.Rows[ i ].Tag as Neusoft.HISFC.Models.Pharmacy.DrugSPETerminal;
                    if( info == null )
                    {
                        continue;
                    }
                    //项目类别(1药品2专科3结算类别4特定收费窗口5挂号级别)
                    info.ItemType = index.ToString();
                    //项目名称
                    info.Item.Name = this.neuSpread1.ActiveSheet.Cells[ i , 1 ].Text;
                    //项目编码
                    info.Item.ID = this.neuSpread1.ActiveSheet.Cells[ i , 6 ].Text;		
                    
                    //专科类别
                    if( this.neuSpread1.ActiveSheetIndex == 1 )
                    {
                        info.Item.ID = info.Item.ID.PadLeft( 4 , '0' );
                    }

                    //收费窗口
                    if( this.neuSpread1.ActiveSheetIndex == 3 )
                    {
                        info.Item.ID = info.Item.Name;
                    }
                    //备注
                    info.Memo = this.neuSpread1.ActiveSheet.Cells[ i , 2 ].Text;			

                    if( this.drugStore.InsertDrugSPETerminal( info ) == -1 )
                    {
                        if( this.drugStore.DBErrCode == 1 )
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show( Language.Msg("第") + ( i + 1 ).ToString( ) + Language.Msg("行与其它行数据重复") );
                            return;
                        }
                        else
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show( Language.Msg("保存第") + ( i + 1 ).ToString( ) + Language.Msg("行时出错\n") + this.drugStore.Err );
                            return;
                        }
                    }
                }

            }
            catch( Exception ex )
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( Language.Msg("执行保存操作出错!") + ex.Message );
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show( Language.Msg( "保存成功" ) );
            #endregion
        }

        #endregion

        #region 事件

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            #region 权限判断

            //取操作员权限科室（暂时以所在科室代替 ）
            this.privDept = ( ( Neusoft.HISFC.Models.Base.Employee )this.drugStore.Operator ).Dept;

            //判断是否有模版维护权限
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager user = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager( );
            List<Neusoft.FrameWork.Models.NeuObject> alPrivDetail = user.QueryUserPrivCollection( this.drugStore.Operator.ID , "0350" , this.privDept.ID );
            if( alPrivDetail != null )
            {
                foreach( Neusoft.FrameWork.Models.NeuObject privInfo in alPrivDetail )
                {
                    //门诊终端维护权限
                    if( privInfo.ID == "01" )
                    {
                        this.isPrivilegeEdit = true;
                        break;
                    }
                }
            }
            else
            {
                this.isPrivilegeEdit = true;
            }

            this.IsEdit = this.isPrivilegeEdit;

            #endregion

            #region 初始化

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( Language.Msg( "正在加载门诊终端信息...." ) );
            Application.DoEvents( );

            //初始化sheet格式
            this.InitFp( );

            //初始化科室终端数据
            this.ucDrugTerminalList1.InitDeptTerminal( this.privDept.ID );

            ////多线程加载数据
            //System.Threading.ThreadStart start = new System.Threading.ThreadStart( this.InitConstant );
            //System.Threading.Thread thread = new System.Threading.Thread( start );
            //thread.Start( );

            this.InitConstant();

            //默认选择药品
            this.neuSpread1.ActiveSheetIndex = 0;
            this.ShowData( this.neuSpread1.ActiveSheetIndex );

            //改变FarPoint的回车事件，使回车转到下一行当前列
            FarPoint.Win.Spread.InputMap im;
            im = this.neuSpread1.GetInputMap( FarPoint.Win.Spread.InputMapMode.WhenFocused );
            im.Put( new FarPoint.Win.Spread.Keystroke( Keys.Enter , Keys.None ) , FarPoint.Win.Spread.SpreadActions.MoveToNextRow );

            //屏蔽挂号级别功能
            if (this.neuSpread1.Sheets.Contains(this.sheetSpeRegLevel))
            {
                this.neuSpread1.Sheets.Remove(this.sheetSpeRegLevel);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );

            #endregion

            base.OnLoad( e );
        }

        private void neuSpread1_ActiveSheetChanged(object sender, EventArgs e)
        {
            this.ShowData(this.neuSpread1.ActiveSheetIndex);
        }

        /// <summary>
        /// 双击添加终端事件
        /// </summary>
        /// <param name="drugTerminal">选中的终端实体</param>
        void ucDrugTerminalList1_SelectTerminalDoubleClickedEvent( Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal )
        {
            if (drugTerminal != null)
            {
                this.currDrugTerminal = drugTerminal;
                this.AddTerminal();
            }
        }

        /// <summary>
        /// 终端单击事件
        /// </summary>
        /// <param name="drugTerminal">选中的终端实体</param>
        void ucDrugTerminalList1_SelectTerminalEvent( Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal )
        {
            this.currDrugTerminal = drugTerminal;
        }

        /// <summary>
        /// 双击sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick( object sender , FarPoint.Win.Spread.CellClickEventArgs e )
        {
            //双击特殊项目名称列时
            if( e.Column == 1 )
            {
                this.ShowList( );
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave( object sender , object neuObject )
        {
            this.SaveTerminal( );
            return base.OnSave( sender , neuObject );
        }

        /// <summary>
        /// 空格时弹出选择窗口
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey( Keys keyData )
        {
            if( this.neuSpread1.ContainsFocus && ( keyData == Keys.Space ) )
            {
                if( this.neuSpread1.ActiveSheet.ActiveColumnIndex == 1 )
                {
                    this.ShowList( );
                }
            }
            return base.ProcessDialogKey( keyData );
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
