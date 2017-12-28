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
    /// [控件名称:DrugTerminalTemplate]<br></br>
    /// [功能描述: 门诊终端模板设置]<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-27]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class DrugTerminalTemplate : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public DrugTerminalTemplate( )
        {
            InitializeComponent( );
            this.ucDrugTerminalList1.SelectTerminalEvent += new ucDrugTerminalList.SelectTerminalHandler( ucDrugTerminalList1_SelectTerminalEvent );
            this.ucDrugTerminalList1.SelectTerminalDoubleClickedEvent += new ucDrugTerminalList.SelectTerminalDoubleClickedHandler( ucDrugTerminalList1_SelectTerminalDoubleClickedEvent );
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
        /// 当前操作的模板信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject currTemplate = null;

        /// <summary>
        /// 当前的选中的终端信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugTerminal currTerminal = null;

        /// <summary>
        /// 是否新增节点
        /// </summary>
        private bool isNew = false;

        /// <summary>
        /// 是否有权限编辑
        /// </summary>
        private bool isPrivilegeEdit = false;

        /// <summary>
        /// 当前选中节点 用于进行模版重命名
        /// </summary>
        private System.Windows.Forms.TreeNode selectNode = null;

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
                this.toolBarService.SetToolButtonEnabled( "新建模板" , value );
                this.toolBarService.SetToolButtonEnabled( "删除模板" , value );
                this.toolBarService.SetToolButtonEnabled( "保存" , value );
                //this.toolBarService.SetToolButtonEnabled( "执行模板" , value );
                this.toolBarService.SetToolButtonEnabled( "删除终端" , value );
                this.toolBarService.SetToolButtonEnabled( "增加终端" , value );
                //无权限编辑的用户隐藏终端区域
                if( !this.isPrivilegeEdit )
                {
                    this.HideDrugTerminal( );
                }
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 显示模板列表
        /// </summary>
        private void ShowTemplateList( )
        {
            this.neuTreeView1.ImageList = this.neuTreeView1.groupImageList;

            //清空列表
            this.neuTreeView1.Nodes.Clear( );

            ArrayList al = this.drugStore.QueryDrugOpenTerminalByDeptCode( this.privDept.ID );

            if( al == null )
            {
                MessageBox.Show( this.drugStore.Err );
                return;
            }

            //添加根节点
            if( al.Count > 0 )
            {
                this.neuTreeView1.Nodes.Add( new TreeNode( "模板列表" , 0 , 0 ) );
            }
            else
            {
                this.neuTreeView1.Nodes.Add( new TreeNode( "无可用模板" , 0 , 0 ) );

            }

            //添加模板信息列表 Text 名称 Tag 模板编号
            foreach( Neusoft.FrameWork.Models.NeuObject info in al )
            {
                TreeNode node = new TreeNode( );
                node.Text = info.Name;				//模板名称
                node.ImageIndex = 2;
                node.SelectedImageIndex = 4;
                node.Tag = info.ID;					//模板编号

                this.neuTreeView1.Nodes[ 0 ].Nodes.Add( node );                
            }

            this.neuTreeView1.Nodes[ 0 ].ExpandAll( );
            this.neuTreeView1.SelectedNode = this.neuTreeView1.Nodes[ 0 ];
        }

        /// <summary>
        /// 显示模板数据
        /// </summary>
        private void ShowTemplateData( )
        {
            //清空
           this.neuSpread1_Sheet1.Rows.Count = 0;
            //如果当前没有选择模板，则返回
            if( string.IsNullOrEmpty(this.currTemplate.ID ))
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( Language.Msg("正在加载终端模板信息...." ));
            Application.DoEvents( );

            //获取模板详细信息
            ArrayList al = this.drugStore.QueryDrugOpenTerminalById( this.currTemplate.ID );
            if( al == null )
            {
                MessageBox.Show( Language.Msg("获取门诊终端模板信息出错!") + this.drugStore.Err );
                return;
            }

            this.neuSpread1_Sheet1.Rows.Count = al.Count;
            Neusoft.FrameWork.Models.NeuObject info;
            Neusoft.HISFC.Models.Pharmacy.DrugTerminal temp;
            for( int i = 0 ; i < al.Count ; i++ )
            {
                info = al[ i ] as Neusoft.FrameWork.Models.NeuObject;
                //模板编号
                this.neuSpread1_Sheet1.Cells[ i , 0 ].Text = info.ID;
                //模板名称
                this.neuSpread1_Sheet1.Cells[ i , 1 ].Text = info.Name;
                //终端编码
                this.neuSpread1_Sheet1.Cells[ i , 2 ].Text = info.User01;
                //终端名称
                temp = this.drugStore.GetDrugTerminalById( info.User01 );
                this.neuSpread1_Sheet1.Cells[ i , 3 ].Text = temp.Name; 
                //是否开放 0 开放 1 关闭
                this.neuSpread1_Sheet1.Cells[ i , 4 ].Text = info.User02 == "0" ? "是" : "否";
                //备注
                this.neuSpread1_Sheet1.Cells[ i , 5 ].Text = info.Memo;
                //是否新增 1 新增 0 否
                this.neuSpread1_Sheet1.Cells[ i , 6 ].Text = "0";				
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );
        }

        /// <summary>
        /// 增加终端
        /// </summary>
        private void AddTerminal(  )
        {
            //判断编辑权限
            if( !this.isPrivilegeEdit )
            {
                return;
            }
            if( this.currTerminal == null )
            {
                return;
            }
            if( this.currTemplate == null )
            {
                MessageBox.Show( Language.Msg( "请先选择模板!" ) );
                return;
            }
            //判断已经添加的终端中，是否已经存在了新增加的这条终端
            int rowCount = this.neuSpread1_Sheet1.Rows.Count;
            if( rowCount > 0 )
            {
                int row = 0;
                int col = 0;
                string find = this.neuSpread1.Search( 0 , this.currTerminal.ID , false , true , false , false , 0 , 0 , ref row , ref col );
                //如果已经存在此终端，则不能添加。
                if( find == this.currTerminal.ID )
                {
                    MessageBox.Show( Language.Msg( "终端【" ) + this.currTerminal.Name + Language.Msg( "】已经存在，不能重复添加" ) );
                    return;
                }
            }
            this.neuSpread1_Sheet1.Rows.Add( rowCount , 1 );
            //模板编号
            this.neuSpread1_Sheet1.Cells[ rowCount , 0 ].Text = this.currTemplate.ID;
            //模板名称
            this.neuSpread1_Sheet1.Cells[ rowCount , 1 ].Text = this.currTemplate.Name;
            //终端编码
            this.neuSpread1_Sheet1.Cells[ rowCount , 2 ].Text = this.currTerminal.ID;
            //终端名称
            this.neuSpread1_Sheet1.Cells[ rowCount , 3 ].Text = this.currTerminal.Name;
            //是否开放 0 开放 1 关闭(默认选择的全部开放)
            this.neuSpread1_Sheet1.Cells[ rowCount , 4 ].Text = "是";//this.currTerminal.IsClose ? "是" : "否";
            //备注
            this.neuSpread1_Sheet1.Cells[ rowCount , 5 ].Text = this.currTerminal.Memo;
            //是否新增 1 新增 0 否
            this.neuSpread1_Sheet1.Cells[ rowCount , 6 ].Text = "1";
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="flag">标志删除方式:
        /// 1 按模板编号、终端编号单条删除
        /// 2 按模板编号删除该模板
        /// 3 对该模板按配药台删除
        /// 4 对该模板按发药窗删除
        /// </param>
        private void DeleteTerminal(string flag )
        {
            //判断编辑权限
            if( !this.isPrivilegeEdit )
            {
                return;
            }
            if( this.neuSpread1_Sheet1.Rows.Count == 0 )
            {
                return;
            }

			//提示用户是否确认删除
			DialogResult result = MessageBox.Show(Language.Msg("确认删除当前记录?"),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
			if(result == DialogResult.No) {
				return;
			}
			//定义数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Transaction t = new  Transaction(Connection.Instance);
            //t.BeginTransaction();
			
			//模板编码
            string tempTemplateCode = this.neuSpread1_Sheet1.Cells[ this.neuSpread1_Sheet1.ActiveRowIndex , 0 ].Text;
			//终端编码
            string tempTerminalCode = this.neuSpread1_Sheet1.Cells[ this.neuSpread1_Sheet1.ActiveRowIndex , 2 ].Text;

			try{
                this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
				int parm;
				switch(flag){
					case "1":		//单条删除
						parm = this.drugStore.DeleteDrugOpenTerminalById(tempTemplateCode,tempTerminalCode);
						break;
					case "2":		//整模板删除
						parm = this.drugStore.DeleteDrugOpenTerminalByTemplateCode(tempTemplateCode);
						break;
					case "3":		//配药台
						parm = this.drugStore.DeleteDrugOpenTerminalByType(tempTemplateCode,"1");
						break;	
					default:		//发药窗
						parm = this.drugStore.DeleteDrugOpenTerminalByType(tempTemplateCode,"0");
						break;
				}
				if (parm == -1) {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					MessageBox.Show(this.drugStore.Err);
					return;
				}
			}
			catch(Exception ex) {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show(ex.Message);
				return;
			}

            Neusoft.FrameWork.Management.PublicTrans.Commit();
			MessageBox.Show(Language.Msg("删除成功"));

            // 刷新
			if(flag =="1")
            {
                 this.neuSpread1_Sheet1.Rows.Remove( this.neuSpread1_Sheet1.ActiveRowIndex , 1 );
                 if( this.neuSpread1_Sheet1.Rows.Count == 0 )
                 {
                     this.ShowTemplateList( );
                 }
			}
            else
            {
                this.neuSpread1_Sheet1.Rows.Count = 0;
                this.ShowTemplateList( );
			}
        }

        /// <summary>
        /// 新建模板
        /// </summary>
        private void NewTemplate( )
        {
            //判断编辑权限
            if( !this.isPrivilegeEdit )
            {
                return;
            }
            TreeNode node = new TreeNode( );

            node.Text = "新建模板";
            node.Tag = "";
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            this.neuTreeView1.Nodes[ 0 ].Nodes.Add( node );
            this.neuTreeView1.SelectedNode = node;

            this.neuTreeView1.LabelEdit = true;
            node.BeginEdit( );
            this.isNew = true;
        }

        /// <summary>
        /// 检查是否合法
        /// </summary>
        private bool isValid( )
        {
            bool isValid = false;
            for( int i = 0 ; i < this.neuSpread1_Sheet1.Rows.Count ; i++ )
            {
                string memo = this.neuSpread1_Sheet1.Cells[i, 5].Text;
                if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(memo, 50))
                {
                    MessageBox.Show(Language.Msg("第" + (i + 1).ToString() + " 行记录 备注字段录入超长 请适当简略"));
                    return false;
                }

                Neusoft.HISFC.Models.Pharmacy.DrugTerminal info = this.drugStore.GetDrugTerminalById( this.neuSpread1_Sheet1.Cells[ i , 2 ].Text );
                if( info.TerminalProperty == Neusoft.HISFC.Models.Pharmacy.EnumTerminalProperty.普通)
                {
                    isValid = true;
                }               
            }
            if( !isValid )
            {
                MessageBox.Show(Language.Msg( "不允许在一个模版内只维护特殊配药台 需至少增加一普通配药台" ));
            }
            return isValid;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private int SaveTerminal( )
        {
            //判断编辑权限
            if( !this.isPrivilegeEdit )
            {
                return -1;
            }
            if( this.neuSpread1_Sheet1.Rows.Count == 0 )
            {
                return -1;
            }

            if( !this.isValid( ) )
            {
                return -1;
            }

            //定义数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Transaction t = new Transaction( Connection.Instance );
            //t.BeginTransaction( );
            try
            {
                this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                bool isSave = true;
                bool isGetCode = false;
                string tempTemplateCode = "";
                Neusoft.FrameWork.Models.NeuObject info;
                //保存数据
                for( int i = 0 ; i < this.neuSpread1_Sheet1.Rows.Count ; i++ )
                {
                    info = new Neusoft.FrameWork.Models.NeuObject( );
                    info.ID = this.neuSpread1_Sheet1.Cells[ i , 0 ].Text;		//模板编号
                    info.Name = this.neuSpread1_Sheet1.Cells[ i , 1 ].Text;		//模板名称
                    info.User01 = this.neuSpread1_Sheet1.Cells[ i , 2 ].Text;	//终端编号
                    info.User02 = this.neuSpread1_Sheet1.Cells[ i , 4 ].Text == "是" ? "0" : "1";	//是否开放 0 开放 1 关闭
                    info.Memo = this.neuSpread1_Sheet1.Cells[ i , 5 ].Text;		//备注
                    info.User03 = this.privDept.ID;

                    //对新增数据无模板编号 只取一次模板编号
                    if( info.ID == "" || info.ID == null )
                    {		
                        if( isGetCode )
                            info.ID = tempTemplateCode;
                        else
                        {
                            info.ID = this.drugStore.GetSequence( "Pharmacy.Constant.GetNewCompanyID" );
                            tempTemplateCode = info.ID;
                            isGetCode = true;
                        }
                    }

                    if( this.drugStore.SetDrugOpenTerminal( info ) == -1 )
                    {	//先进行更新操作，如无数据则插入
                        isSave = false;
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg( "保存第") + i.ToString( ) + Language.Msg("行时出错\n") + this.drugStore.Err );
                        break;
                    }
                }

                if( isSave )
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    MessageBox.Show( Language.Msg("保存成功" ));
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

            return 1;
        }

        /// <summary>
        /// 执行模板设置
        /// </summary>
        private void Exec( )
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
            {
				return;
            }
            if( this.currTemplate == null )
            {
                MessageBox.Show( Language.Msg("请先选择执行模板"));
                return;
            }
			//提示用户是否确认
			DialogResult result = MessageBox.Show(Language.Msg("确认执行当前记录吗?"),"",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
			if(result == DialogResult.No) 
            {
				return;
			}
			
			//定义数据库事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Transaction t = new Transaction(Connection.Instance);
            //t.BeginTransaction();

			try{
                this.drugStore.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                int param = this.drugStore.ExecOpenTerminal(this.privDept.ID,this.currTemplate.ID);
                if (param == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					MessageBox.Show(this.drugStore.Err);
					return;
				}
                else if (param == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("请选择需执行模版");
                    return;
                }
			}
			catch(Exception ex) {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show(ex.Message);
				return;
			}

            Neusoft.FrameWork.Management.PublicTrans.Commit();
			MessageBox.Show(Language.Msg("执行成功"));
		}

        /// <summary>
        /// 隐藏终端（对无权限的用户）
        /// </summary>
        private void HideDrugTerminal( )
        {
            this.splitContainer2.Panel1Collapsed = true;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 终端选择事件
        /// </summary>
        /// <param name="drugTerminal">选中的终端实体</param>
        private void ucDrugTerminalList1_SelectTerminalEvent( Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal )
        {
            this.currTerminal = drugTerminal;
        }

        /// <summary>
        /// 终端双击事件
        /// </summary>
        /// <param name="drugTerminal">选中的终端实体</param>
        private void ucDrugTerminalList1_SelectTerminalDoubleClickedEvent( Neusoft.HISFC.Models.Pharmacy.DrugTerminal drugTerminal )
        {
            currTerminal = drugTerminal;
            this.AddTerminal(  );
        }

        /// <summary>
        /// 已维护终端双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick( object sender , FarPoint.Win.Spread.CellClickEventArgs e )
        {
            this.DeleteTerminal( "1" );
        }

        /// <summary>
        /// 模板树选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTreeView1_AfterSelect( object sender , TreeViewEventArgs e )
        {
            if( e.Node.Tag == null )
            {
                this.currTemplate = null;

                return;
            }
            try
            {
                this.currTemplate = new Neusoft.FrameWork.Models.NeuObject( );
                // 模板编码
                this.currTemplate.ID = e.Node.Tag as string;
                //模板名称
                this.currTemplate.Name = e.Node.Text;
                //显示模板终端数据
                this.ShowTemplateData( );
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message );
                return;
            }
        }

        /// <summary>
        /// 模板名称编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTreeView1_AfterLabelEdit( object sender , NodeLabelEditEventArgs e )
        {
            //根节点不允许编辑
            if (e.Node != null && e.Node.Parent == null)
            {
                e.CancelEdit = true;
                e.Node.EndEdit(true);
                return;
            }

            if( e.Label != null )
            {
                if( e.Label.Length > 0 )
                {
                    if( e.Label.IndexOfAny( new char[ ] { '@' , '.' , ',' , '!' } ) == -1 )
                    {
                        e.Node.EndEdit( false );
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show(Language.Msg( "存在无效字符!请重新命名" ));
                        e.Node.BeginEdit( );
                        return;
                    }

                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(e.Label, 32))
                    {
                        e.CancelEdit = true;
                        MessageBox.Show(Language.Msg("模版名称超长 请适当简略"));
                        e.Node.BeginEdit();
                        return;
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show( Language.Msg("模板名称不能为空" ));
                    e.Node.BeginEdit( );
                    return;
                }

                if( !this.isNew )
                {
                    this.neuTreeView1.LabelEdit = false;
                    this.currTemplate.Name = e.Label;
                    for( int i = 0 ; i < this.neuSpread1_Sheet1.Rows.Count ; i++ )
                    {
                        this.neuSpread1_Sheet1.Cells[ i , 1 ].Text = this.currTemplate.Name;
                    }
                    //更新数据库
                    this.SaveTerminal( );
                }
                else
                {
                    this.currTemplate.ID = "";
                    this.currTemplate.Name = e.Label;
                    this.isNew = false;
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            //取操作员权限科室（暂时以所在科室代替 ）
            this.privDept = ( ( Neusoft.HISFC.Models.Base.Employee )this.drugStore.Operator ).Dept;

            //判断是否有模版维护权限
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager( );
            List<Neusoft.FrameWork.Models.NeuObject> alPrivDetail = userManager.QueryUserPrivCollection( this.drugStore.Operator.ID , "0350" , this.privDept.ID );
            if( alPrivDetail != null)
            {
                this.isPrivilegeEdit = false;
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

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg( "正在加载门诊终端信息...." ));
            Application.DoEvents( );

            //初始化科室终端数据
            this.ucDrugTerminalList1.InitDeptTerminal( this.privDept.ID );
            //初始化模板列表
            this.ShowTemplateList( );

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm( );

            base.OnLoad( e );
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
            this.toolBarService.AddToolButton( "新建模板" , "新建模板" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建 , true , false , null );
            this.toolBarService.AddToolButton( "删除模板" , "删除整个模板" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空 , true , false , null );
            this.toolBarService.AddToolButton( "执行模板" , "执行模板设置" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z执行 , true , false , null );
            this.toolBarService.AddToolButton( "增加终端" , "增加终端到模板" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加 , true , false , null );
            this.toolBarService.AddToolButton( "删除终端" , "删除单条终端" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除 , true , false , null );
            this.toolBarService.AddToolButton( "删除窗口" , "删除模板中的发药窗口" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消 , true , false , null );
            this.toolBarService.AddToolButton( "删除配药台" , "删除模板中的配药台" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销 , true , false , null );
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
                case "新建模板":
                    this.NewTemplate( );
                    break;
                case "删除模板":
                    this.DeleteTerminal( "2" );
                    break;
                case "增加终端":
                    this.AddTerminal( );
                    break;
                case "删除终端":
                    this.DeleteTerminal( "1" );
                    break;
                case "执行模板":
                    this.Exec( );
                    break;
                case "删除窗口":
                    this.DeleteTerminal( "4" );
                    break;
                case "删除配药台":
                    this.DeleteTerminal( "3" );
                    break;
            }

        }

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object NeuObject)
        {
            if (this.SaveTerminal() == 1)
            {
                this.ShowTemplateList();

                this.neuSpread1_Sheet1.Rows.Count = 0;
            }

            return base.OnSave(sender, NeuObject);
        }


        #endregion

        private void neuTreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.neuTreeView1.ContextMenu != null)
                this.neuTreeView1.ContextMenu.MenuItems.Clear();

            this.selectNode = this.neuTreeView1.GetNodeAt(e.X, e.Y);
            if (this.selectNode != null && this.selectNode.Parent != null)
            {
                MenuItem reNameItem = new MenuItem(Language.Msg("重命名"));

                reNameItem.Click -= new EventHandler(reNameItem_Click);
                reNameItem.Click += new EventHandler(reNameItem_Click);

                System.Windows.Forms.ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add(reNameItem);

                this.neuTreeView1.ContextMenu = menu;
            }
        }

        void reNameItem_Click(object sender, EventArgs e)
        {
            //非根节点可以改名称
            if (this.selectNode != null && this.selectNode.Parent != null)
            {
                this.neuTreeView1.SelectedNode = this.selectNode;
                this.neuTreeView1.LabelEdit = true;
                if (!this.selectNode.IsEditing)
                {
                    this.selectNode.BeginEdit();
                }
            }
        }
     
    }
}
