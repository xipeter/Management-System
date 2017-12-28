using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.DrugStore.Base
{
    /// <summary>
    /// [控件名称:ucGetDrugDept]<br></br>
    /// [功能描述: 默认取药科室维护<br></br>
    /// [创 建 者: 杨永刚]<br></br>
    /// [创建时间: 2006-11-5]<br></br>
    /// <修改记录 
    ///		修改人='梁俊泽' 
    ///		修改时间='2007-01-31' 
    ///		修改目的='bug'
    ///		修改描述='重新整理修改'
    ///  />
    /// <修改记录>
    ///    1、科室药房对照中加删除提示 by Sunjh 2010-8-23 {D77FC0F8-4BE1-4ce5-A303-AC788C9FA773} 
    /// </修改记录>
    /// </summary>
    public partial class ucGetDrugDept : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucGetDrugDept( )
        {
            InitializeComponent( );
        }

        #region 变量

        /// <summary>
        /// 定义当前选择科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject currentDept = new Neusoft.FrameWork.Models.NeuObject();

        //定义默认取药科室
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstant = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
        //定义帮助
        Neusoft.FrameWork.Public.ObjectHelper objHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        //过虑用
        private DataSet ds = new DataSet();
        private DataView dv;

        FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();       

        /// <summary>
        /// 药库大类编码
        /// </summary>
        private string piStatCode = "S001";

        /// <summary>
        /// 药房大类编码
        /// </summary>
        private string pStatCode = "S002";

        /// <summary>
        /// 是否使用科室结构树显示
        /// </summary>
        private bool isUseDeptStruct = false;

        #endregion

        #region 属性

        /// <summary>
        /// 药库大类编码
        /// </summary>
        [Description("科室结构中维护的药库大类编码，默认为S001"), Category("设置"), DefaultValue("S001")]
        public string PIStatCode
        {
            get
            {
                return this.piStatCode;
            }
            set
            {
                this.piStatCode = value;
            }
        }

        /// <summary>
        /// 药房大类编码
        /// </summary>
        [Description("科室结构中维护的药房大类编码，默认为S002"), Category("设置"), DefaultValue("S002")]
        public string PStatCode
        {
            get
            {
                return this.pStatCode;
            }
            set
            {
                this.pStatCode = value;
            }
        }

        /// <summary>
        /// 是否使用科室结构树显示
        /// </summary>
        [Description("是否使用科室结构树显示。设置为True使用科室结构显示时，需注意设置PIStatCode与PStatCode属性值"), Category("设置"), DefaultValue(false)]
        public bool IsUseDeptStruct
        {
            get
            {
                return this.isUseDeptStruct;
            }
            set
            {
                this.isUseDeptStruct = value;
            }
        }

        #endregion
        
        #region 方法
        /// <summary>
        /// 初始化列表
        /// </summary>
        private void SetFp( )
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType( );
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType( );
            dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;

            this.neuSpread1_Sheet1.Columns.Get( 0 ).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get( 0 ).Label = "取药科室编码";
            this.neuSpread1_Sheet1.Columns.Get( 0 ).Visible = false;

            this.neuSpread1_Sheet1.Columns.Get( 1 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Label = "取药科室";
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Locked = true;
            this.neuSpread1_Sheet1.Columns.Get( 1 ).Width = 165F;

            this.neuSpread1_Sheet1.Columns.Get( 2 ).AllowAutoSort = true;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Label = "药品类别";
            this.neuSpread1_Sheet1.Columns.Get( 2 ).Width = 82F;
            this.neuSpread1_Sheet1.Columns.Get( 2 ).CellType = comboBoxCellType1;

            this.neuSpread1_Sheet1.Columns.Get( 3 ).Label = "开始时间";
            this.neuSpread1_Sheet1.Columns.Get( 3 ).Width = 92F;
            this.neuSpread1_Sheet1.Columns.Get( 3 ).CellType = dateTimeCellType1;

            this.neuSpread1_Sheet1.Columns.Get( 4 ).Label = "结束时间";
            this.neuSpread1_Sheet1.Columns.Get( 4 ).Width = 92F;
            this.neuSpread1_Sheet1.Columns.Get( 4 ).CellType = dateTimeCellType1;

            this.neuSpread1_Sheet1.Columns.Get( 5 ).Label = "备注";
            this.neuSpread1_Sheet1.Columns.Get( 5 ).Width = 119F;

            this.neuSpread1_Sheet1.Columns.Get( 6 ).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Label = "拼音码";
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get( 6 ).Width = 129F;

            this.neuSpread1_Sheet1.Columns.Get( 7 ).CellType = textCellType1;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Label = "五笔码";
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Visible = false;
            this.neuSpread1_Sheet1.Columns.Get( 7 ).Width = 129F;
        }

        /// <summary>
        /// 初始化DataSet并绑定到neuSpread1_Sheet1
        /// </summary>
        private void InitDataSet( )
        {
            //定义类型
            System.Type dtStr = System.Type.GetType( "System.String" );
            System.Type dtTime = System.Type.GetType( "System.DateTime" );

            this.ds.Tables.Clear( );
            this.ds.Tables.Add( );

            //在DataSet中添加列
            this.ds.Tables[ 0 ].Columns.AddRange( new DataColumn[ ] {
																	new DataColumn("取药科室编码",dtStr),
																	new DataColumn("取药科室",    dtStr),
																	new DataColumn("药品类别",	  dtStr),
																	new DataColumn("开始时间",	  dtTime),
																	new DataColumn("结束时间",    dtTime),
																	new DataColumn("备注",	      dtStr),
																	new DataColumn("拼音码",      dtStr),
																	new DataColumn("五笔码",      dtStr),
																} );
            this.dv = new DataView( this.ds.Tables[ 0 ] );

            this.dv.AllowDelete = true;
            this.dv.AllowEdit = true;
            this.dv.AllowNew = true;

            //设定用于对DataView进行重复行检索的主键
            DataColumn[ ] keys = new DataColumn[ 3 ];
            keys[ 0 ] = this.ds.Tables[ 0 ].Columns[ "取药科室编码"];
            keys[1] = this.ds.Tables[0].Columns["药品类别"];
            keys[2] = this.ds.Tables[0].Columns["开始时间"];
            this.ds.Tables[ 0 ].PrimaryKey = keys;

            //数据绑定
            this.neuSpread1_Sheet1.DataSource = this.dv;

            //设置数据格式
            this.SetFp( );
        }

        /// <summary>
        /// 为表格设置药品类型下拉控件
        /// </summary>
        private void InitGetDrugType( )
        {
            //取药品类型数组
            Neusoft.HISFC.BizLogic.Manager.Constant cons = new Neusoft.HISFC.BizLogic.Manager.Constant( );
            Neusoft.FrameWork.Models.NeuObject neuObj = new Neusoft.FrameWork.Models.NeuObject( );
            ArrayList alDrugType = new ArrayList( );

            alDrugType = cons.GetList( Neusoft.HISFC.Models.Base.EnumConstant.ITEMTYPE );
            if( alDrugType == null ) 
                return;

            //将药品类型赋值给objHelper，用于根据编码检索名称
            neuObj.ID = "A";
            neuObj.Name = "全部";
            objHelper.ArrayObject.Add( neuObj );
            objHelper.ArrayObject.AddRange( alDrugType );

            //生成下拉列表
            string[ ] str = new string[ objHelper.ArrayObject.Count ];
            for( int i = 0 ; i < objHelper.ArrayObject.Count ; i++ )
            {
                neuObj = objHelper.ArrayObject[ i ] as Neusoft.FrameWork.Models.NeuObject;
                str[ i ] = neuObj.ID + neuObj.Name;
            }
            comboBoxCellType1.Items = str;
        }

        /// <summary>
        /// 初始化Dataset
        /// </summary>
        /// <param name="al"></param>
        private void AddToDataSet( ArrayList al )
        {
            Neusoft.HISFC.Models.Base.Spell spellobj = new Neusoft.HISFC.Models.Base.Spell( );
            Neusoft.HISFC.BizLogic.Manager.Spell spell = new Neusoft.HISFC.BizLogic.Manager.Spell( );

            if( al.Count <= 0 )
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg("正在检索数据.请稍候..."));
            Application.DoEvents();

            for( int i = 0 ; i < al.Count ; i++ )
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject( );
                obj = ( Neusoft.FrameWork.Models.NeuObject )al[ i ];
                spellobj = spell.Get( obj.Name ) as Neusoft.HISFC.Models.Base.Spell;
                if (spellobj == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(obj.Name + " 自动生成该科拼音码时发生错误." + obj.ID + "科室"));
                    continue;
                }

                //{BB505126-A265-4c62-9392-30D99503E36E}
                //替换obj.User01.tostring() 为 Neusoft.FrameWork.Function.NConvert.ToDateTime(obj.User01).ToLongTimeString()
                string[] key = { obj.ID, obj.User03 + this.objHelper.GetName(obj.User03), Neusoft.FrameWork.Function.NConvert.ToDateTime(obj.User01).ToLongTimeString() };
                if (this.ds.Tables[0].Rows.Find(key) != null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(obj.Name + "该科已存在 不能重复添加" + obj.ID + "该科室"));
                    continue;
                }

                this.ds.Tables[ 0 ].Rows.Add( new object[ ]{
                    obj.ID,//取药科室编码
                    obj.Name,//取药科室名称
                    obj.User03 + this.objHelper.GetName( obj.User03 ),//药品类型
                    Neusoft.FrameWork.Function.NConvert.ToDateTime(obj.User01).ToLongTimeString(),//开始时间
                    Neusoft.FrameWork.Function.NConvert.ToDateTime(obj.User02).ToLongTimeString(),//结束时间
                    obj.Memo,//备注
                    spellobj.SpellCode.Length > 10 ? spellobj.SpellCode.Substring(0,10):spellobj.SpellCode,//拼音码保留十位
                    spellobj.WBCode.Length > 10 ? spellobj.WBCode.Substring(0,10):spellobj.WBCode    //五笔码保留十位
                } );

            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.ds.Tables[ 0 ].AcceptChanges( );
            this.SetFp( );
        }

        /// <summary>
        /// 取药房的领药科室
        /// </summary>
        private void GetDeptByStore( )
        {
            try
            {
                this.Clear();

                //如果部门编号为空返回
                if( this.currentDept.ID == "" ) 
                    return;

                //获得取药科室列表
                ArrayList al = phaConstant.QueryReciveDrugDept( this.currentDept.ID );

                //数据填充添加到DataSet
                this.AddToDataSet(al);
            }
            catch( Exception ex )
            {
                MessageBox.Show( "请选择药房/药库编号！" + ex.Message );
                return;
            }
        }

        /// <summary>
        /// 增加科室
        /// </summary>
        private void AddDept( )
        {
            if( this.currentDept.ID == "" ) 
                return;

            List<Neusoft.HISFC.Models.Base.Department> selectedDeptList = Common.Classes.Function.ChooseMultiDept( ); ;
            ArrayList al = new ArrayList( );

            try
            {
                for( int i = 0 ; i < selectedDeptList.Count ; i++ )
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject( );
                    obj = ( Neusoft.FrameWork.Models.NeuObject )selectedDeptList[ i ];
                    obj.ID = selectedDeptList[ i ].ID;
                    obj.Name = selectedDeptList[ i ].Name;
                    obj.User03 = "A全部";
                    obj.User01 = "2000-01-01 00:00:00";
                    obj.User02 = "2000-01-01 23:59:59";

                    al.Add( obj );
                }

                //数据填充添加到DataSet
                this.AddToDataSet( al );
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
        }

        /// <summary>
        /// 删除科室
        /// </summary>
        private void DeleteDept( )
        {
            //科室药房对照中加删除提示 by Sunjh 2010-8-23 {D77FC0F8-4BE1-4ce5-A303-AC788C9FA773}
            if (MessageBox.Show("确定删除当前选择科室吗? 删除后需保存生效", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                //选择一条记录进行删除，药房/药库编号不能为空，右侧表格行数药大于0并且有选中行
                if( this.neuSpread1_Sheet1.RowCount > 0 && this.neuSpread1_Sheet1.ActiveRowIndex >= 0 )
                {
                    //this.neuSpread1_Sheet1.RemoveRows( this.neuSpread1_Sheet1.ActiveRowIndex , 1 );
                    string[] key = { this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text ,
                                     this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex,2].Text,
                                     this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex,3].Text};
                    DataRow dr = this.ds.Tables[0].Rows.Find(key);
                    if (dr != null)
                    {
                        this.ds.Tables[0].Rows.Remove(dr);
                    }
                    //this.ds.Tables[ 0 ].Rows.RemoveAt( this.neuSpread1_Sheet1.ActiveRowIndex );
                    //this.ds.Tables[ 0 ].AcceptChanges( );
                }
                else
                {
                    MessageBox.Show( "请选择删除的记录！" );
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( this , ex.Message , "取药科室维护" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        private void SaveDept( )
        {
            if( this.currentDept.ID == "" )
                return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );
            //t.BeginTransaction( );

            this.phaConstant.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                //清除原来数据
                if( this.phaConstant.DelAllDrugRoom( this.currentDept.ID ) == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( this , "数据保存出错！" + this.phaConstant.Err , "保存错误" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    return;
                }

                for(int i = 0;i < this.ds.Tables[0].Rows.Count;i++)
                {
                    this.ds.Tables[0].Rows[i].EndEdit();
                }

                this.dv.RowFilter = "1=1";

                //装入新数据
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject( );
                for( int i = 0 ; i < this.neuSpread1_Sheet1.RowCount ; i++ )
                {
                    obj.ID = this.currentDept.ID;									        //药房/药库编号
                    obj.Name = this.neuSpread1_Sheet1.Cells[ i , 0 ].Text;					//取药科室编号
                    obj.User03 = this.neuSpread1_Sheet1.Cells[ i , 2 ].Text.Substring( 0 , 1 );	//药品类型
                    obj.User01 = "2000-01-01 " + this.neuSpread1_Sheet1.Cells[ i , 3 ].Text;	//开始时间 日期都固定为2000-01-01
                    obj.User02 = "2000-01-01 " + this.neuSpread1_Sheet1.Cells[ i , 4 ].Text;	//结束时间 日期都固定为2000-01-01
                    obj.Memo = this.neuSpread1_Sheet1.Cells[ i , 5 ].Text;					//备注

                    //检查数据录入是否有效
                    try
                    {
                        if( DateTime.Parse( obj.User01 ) >= DateTime.Parse( obj.User02 ) )
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            this.neuSpread1_Sheet1.ActiveRowIndex = i;
                            MessageBox.Show( "开始时间必须小于结束时间" + "\n科室名称:" + this.neuSpread1_Sheet1.Cells[ i , 1 ].Text , "保存提示" );
                            return;
                        }
                    }
                    catch
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.neuSpread1_Sheet1.ActiveRowIndex = i;
                        MessageBox.Show( "请输入有效的开始时间和结束时间" + "\n科室名称:" + this.neuSpread1_Sheet1.Cells[ i , 1 ].Text , "保存提示" );
                        return;
                    }

                    //数据更新
                    if( this.phaConstant.InsertDrugRoom( obj ) != 1 )
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        if( this.phaConstant.DBErrCode == 1 )
                        {
                            this.neuSpread1_Sheet1.ActiveRowIndex = i;
                            MessageBox.Show( "数据重复,已有相同的记录存在.请维护不同的记录." , "保存提示" );
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.ActiveRowIndex = i;
                            MessageBox.Show( this , "数据保存出错！" + this.phaConstant.Err , "保存错误" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        }
                        return;
                    }
                }
            }
            catch( Exception e )
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( e.Message );
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show( "保存成功！" );
        }

        /// <summary>
        /// 显示清空
        /// </summary>
        protected void Clear()
        {
            if (this.ds != null && this.ds.Tables.Count > 0)
                this.ds.Tables[0].Rows.Clear();
        }
 
        #endregion

        #region 事件

        /// <summary>
        /// 控件装载事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.InitDataSet();

                this.InitGetDrugType();

                Neusoft.HISFC.Components.DrugStore.Base.tvDeptTree tvDeptTree = this.tv as Neusoft.HISFC.Components.DrugStore.Base.tvDeptTree;

                if (tvDeptTree != null)
                {
                    tvDeptTree.IsUseDeptStruct = this.isUseDeptStruct;
                    tvDeptTree.Reset();
                }
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// 与科室树控件通讯
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue( object neuObject , TreeNode e )
        {
            try
            {
                if( e != null && e.Tag != null)
                {
                    //当前选择的科室
                    this.currentDept = e.Tag as Neusoft.FrameWork.Models.NeuObject;

                    //显示当前药房、药库的领药科室
                    this.GetDeptByStore( );
                }
                else
                {
                    this.Clear();

                    this.currentDept = new Neusoft.FrameWork.Models.NeuObject( );
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message , "提示" );
            }
            return base.OnSetValue( neuObject , e );
        }

        /// <summary>
        /// 科室过虑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_TextChanged( object sender , EventArgs e )
        {
            if( this.ds.Tables[ 0 ].Rows.Count == 0 ) return;

            try
            {
                string queryCode = "";
                queryCode = "%" + this.neuTextBox1.Text.Trim( ) + "%";

                string filter = "(拼音码 LIKE '" + queryCode + "') OR " + "(五笔码 LIKE '" + queryCode + "') OR " + "(取药科室编码 LIKE '" + queryCode + "') ";

                //设置过滤条件
                this.dv.RowFilter = filter;
                this.SetFp( );
            }
            catch( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }

        }

        /// <summary>
        /// 响应键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBox1_KeyDown( object sender , KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Down )
            {
                this.neuSpread1_Sheet1.ActiveRowIndex++;
                this.neuSpread1_Sheet1.AddSelection( this.neuSpread1_Sheet1.ActiveRowIndex , 0 , 1 , 0 );
                return;
            }

            if( e.KeyCode == Keys.Up )
            {
                this.neuSpread1_Sheet1.ActiveRowIndex--;
                this.neuSpread1_Sheet1.AddSelection( this.neuSpread1_Sheet1.ActiveRowIndex , 0 , 1 , 0 );
                return;
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
            this.toolBarService.AddToolButton( "增加" , "增加取药科室" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加 , true , false , null );
            this.toolBarService.AddToolButton( "删除" , "删除取药科室" , Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除 , true , false , null );
            return this.toolBarService;
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave( object sender , object neuObject )
        {
            this.SaveDept( );
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
                    this.AddDept( );
                    break;
                case "删除":
                    this.DeleteDept( );
                    break;
            }

        }

        #endregion

    }
}
