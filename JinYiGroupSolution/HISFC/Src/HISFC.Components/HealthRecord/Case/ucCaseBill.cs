using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.HealthRecord.Case
{
    /// <summary>
    /// ucCaseBill<br></br>
    /// [功能描述: 病历出入库管理]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-09-14]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucCaseBill : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCaseBill()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 工具栏
        /// </summary>
        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 集成业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Case.CaseBill caseBillIntegrate = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.Case.CaseBill();

        /// <summary>
        /// 当前登录科室
        /// </summary>
        private Neusoft.HISFC.Models.Base.Department loginDept = new Neusoft.HISFC.Models.Base.Department();

        /// <summary>
        /// 当前登录操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee loginEmpl = new Neusoft.HISFC.Models.Base.Employee();

        /// <summary>
        /// 返回值
        /// </summary>
        private int callReturn = -1;

        /// <summary>
        /// 当前选择的病历单据
        /// </summary>
        private Neusoft.HISFC.Models.HealthRecord.Case.CaseBill currentCaseBill = new Neusoft.HISFC.Models.HealthRecord.Case.CaseBill();

        /// <summary>
        /// 操作状态
        /// </summary>
        private OperateState operateState = OperateState.Idle;

        /// <summary>
        /// 管理类Integrate
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 当前单据号
        /// </summary>
        private string billCode = string.Empty;

        /// <summary>
        /// 窗口当前状态
        /// </summary>
        private Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState currentState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest;

        #endregion

        #region 属性

        /// <summary>
        /// 当前选择的病历信息
        /// </summary>
        private Neusoft.HISFC.Models.HealthRecord.Case.CaseBill CurrentCaseBill
        {
            get
            {
                return this.currentCaseBill;
            }
            set
            {
                this.currentCaseBill = value;

                if ( this.currentCaseBill == null )
                {
                    return;
                }

                this.neuTextBoxCardNo.Text = currentCaseBill.CaseInfo.Patient.PID.CardNO;
                this.neuTextBoxName.Text = currentCaseBill.CaseInfo.Patient.Name;
                this.neuTextBoxSex.Text = this.GetSex( currentCaseBill.CaseInfo.Patient.Sex.ID.ToString() );
                this.neuTextBoxState.Text = currentCaseBill.CaseInfo.CaseState.Name;

                if ( this.currentCaseBill.CaseInfo.InType == 1 )
                {
                    this.neuTextBoxBelong.Text = this.currentCaseBill.CaseInfo.InDept.Name;
                }
                else
                {
                    this.neuTextBoxBelong.Text = this.currentCaseBill.CaseInfo.InEmployee.Name;
                }

                if ( this.currentCaseBill.FromDept.Name != null)
                {
                    this.neuComboBoxDept.Text = this.currentCaseBill.FromDept.Name;
                }
            }
        }

        /// <summary>
        /// 操作状态
        /// </summary>
        private OperateState CurrentOperateState
        {
            get
            {
                return this.operateState;
            }
            set
            {
                this.operateState = value;

                this.neuTextBoxStatus.Text = this.GetOperateState( this.operateState );
                if ( this.operateState == OperateState.NewBill )
                {
                    this.neuTextBoxBillCode.Text = "";
                }
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 根据当前操作状态返回状态信息
        /// </summary>
        /// <param name="state">当前操作状态</param>
        /// <returns>状态信息</returns>
        private string GetOperateState( OperateState state)
        {
            string stateMsg = "无操作单据";

            switch ( state )
            {
                case OperateState.Idle:
                    stateMsg = "无操作单据";
                    break;
                case OperateState.NewBill:
                    stateMsg = "新建单据";
                    break;
                case OperateState.OldBill:
                    stateMsg = "现有单据";
                    break;
            }

            return stateMsg;
        }

        /// <summary>
        /// 初始化病历出库单树
        /// </summary>
        /// <returns>－1－失败，1－成功</returns>
        private int InitCaseBillTree()
        {
            DateTime fromDate = this.neuDateTimePicker1.Value.Date;
            TreeNode caseBillNode = new TreeNode("病历出入库单");

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在加载树结点..." );

            Application.DoEvents();

            this.callReturn = caseBillIntegrate.GetTreeNode( ref caseBillNode, fromDate );
            if ( this.callReturn == -1 )
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }

            this.neuTreeViewBill.Nodes.Clear();
            this.neuTreeViewBill.Nodes.Add( caseBillNode );
            this.neuTreeViewBill.ExpandAll();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 初始化病历基本信息显示
        /// </summary>
        private void InitCaseInfoDisplay()
        {
            this.neuTextBoxCardNo.Text = "";
            this.neuTextBoxName.Text = "";
            this.neuTextBoxSex.Text = "";
            this.neuTextBoxState.Text = "";
            this.neuTextBoxBelong.Text = "";
        }

        /// <summary>
        /// 初始化科室列表
        /// </summary>
        private void InitDeptComboBox()
        {
            ArrayList deptList = managerIntegrate.GetDeptmentAllValid();

            // 除去当前登录科室
            //int i = -1;
            //foreach ( Neusoft.HISFC.Models.Base.Department dept in deptList )
            //{
            //    if ( dept.ID == this.loginDept.ID )
            //    {
            //        break;
            //    }

            //    i++;
            //}

            //if ( i >= 0 )
            //{
            //    deptList.RemoveAt( i + 1 );
            //}

            if ( deptList != null )
            {
                
                this.neuComboBoxDept.AddItems( deptList );
            }
        }

        /// <summary>
        /// 新建病历出入库单
        /// </summary>
        private void NewCaseBill()
        {
            this.operateState = OperateState.NewBill;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.InitCaseInfoDisplay();
            this.neuTextBoxCardNo.Focus();
        }

        /// <summary>
        /// 加载现有病历出入库单据
        /// </summary>
        private void LoadCaseBill()
        {
            this.operateState = OperateState.OldBill;
            this.InitCaseInfoDisplay();
        }

        /// <summary>
        /// 根据病历号检索病历基本信息
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>－1－失败，1－成功</returns>
        private int QueryByCardNo( string cardNo )
        {
            Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo = new Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo();

            this.InitCaseInfoDisplay();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在检索病历信息..." );

            Application.DoEvents();

            this.callReturn = this.caseBillIntegrate.GetCaseInfoByCardNo( ref caseInfo, cardNo );
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            if ( this.callReturn == -1 )
            {
                MessageBox.Show( this.caseBillIntegrate.Err );

                return -1;
            }
            if ( this.callReturn == 0 )
            {
                MessageBox.Show( "该病历不存在" );

                return -1;
            }

            caseInfo.Patient.PID.CardNO = cardNo;
            Neusoft.HISFC.Models.HealthRecord.Case.CaseBill tempBill = new Neusoft.HISFC.Models.HealthRecord.Case.CaseBill();
            tempBill.CaseInfo = caseInfo;
            tempBill.Memo = "New";
            this.CurrentCaseBill = tempBill;

            return 1;
        }

        /// <summary>
        /// 根据病历单据号码检索病历出库单明细
        /// </summary>
        /// <param name="billCode">病历单据号码</param>
        /// <returns>－1－失败，1－成功</returns>
        private int QueryByBillCode( string billCode )
        {
            List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList = new List<Neusoft.HISFC.Models.HealthRecord.Case.CaseBill>();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在加载单据信息..." );

            Application.DoEvents();

            this.callReturn = this.caseBillIntegrate.QueryCaseBillByBillCode( ref caseBillList, billCode );

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            if ( this.callReturn == -1 )
            {
                MessageBox.Show( this.caseBillIntegrate.Err );

                return -1;
            }

            this.DisplayCaseBillList( caseBillList );

            return 1;
        }

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <param name="sexCode">性别编码</param>
        /// <returns>性别</returns>
        private string GetSex( string sexCode )
        {
            switch ( sexCode )
            {
                case "F":
                    return "女";
                case "M":
                    return "男";
                case "O":
                    return "其它";
                case "U":
                    return "未知";
            }

            return "男";
        }

        /// <summary>
        /// 添加病历出库单到表格
        /// </summary>
        /// <param name="caseBill">病历出库单</param>
        /// <returns>－1－失败，1－成功</returns>
        private int AddCaseBillToGrid( HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);
            int row = this.neuSpread1_Sheet1.Rows.Count - 1;

            try
            {
                #region 赋值

                SetBillToRow( caseBill, row );

                #endregion

            }
            catch ( Exception exception )
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                this.neuSpread1_Sheet1.RemoveRows( row, 1 );

                MessageBox.Show( exception.Message );

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 设置单据到行
        /// </summary>
        /// <param name="caseBill">单据</param>
        /// <param name="row">行号</param>
        private void SetBillToRow( HISFC.Models.HealthRecord.Case.CaseBill caseBill, int row )
        {
            this.neuSpread1_Sheet1.Rows [row].Tag = caseBill;

            // 病历号
            this.neuSpread1_Sheet1.Cells [row, 0].Text = caseBill.CaseInfo.Patient.PID.CardNO;
            // 姓名
            this.neuSpread1_Sheet1.Cells [row, 1].Text = caseBill.CaseInfo.Patient.Name;
            // 性别
            this.neuSpread1_Sheet1.Cells [row, 2].Text = this.GetSex( caseBill.CaseInfo.Patient.Sex.ID.ToString() );
            // 出生日期
            this.neuSpread1_Sheet1.Cells [row, 3].Text = caseBill.CaseInfo.Patient.Birthday.ToString("yyyy-MM-dd");
            // 申请的出库科室
            this.neuSpread1_Sheet1.Cells [row, 4].Text = caseBill.FromDept.Name;
            // 申请科室
            this.neuSpread1_Sheet1.Cells [row, 5].Text = caseBill.InRequestOper.Dept.Name;
            // 申请入库人
            this.neuSpread1_Sheet1.Cells [row, 6].Text = caseBill.InRequestOper.Name;
            // 申请入库日期
            this.neuSpread1_Sheet1.Cells [row, 7].Text = caseBill.InRequestOper.OperTime.ToString();
            // 出库审核人
            this.neuSpread1_Sheet1.Cells [row, 8].Text = caseBill.OutAuditingOper.Name;
            // 出库审核时间
            this.neuSpread1_Sheet1.Cells [row, 9].Text = caseBill.OutAuditingOper.OperTime.ToString();
            // 入库确认人
            this.neuSpread1_Sheet1.Cells [row, 10].Text = caseBill.InConfirmOper.Name;
            // 入库确认时间
            this.neuSpread1_Sheet1.Cells [row, 11].Text = caseBill.InConfirmOper.OperTime.ToString();
            // 单据类型
            this.neuSpread1_Sheet1.Cells [row, 12].Text = caseBill.BillType.Name;
            // 是否已经发送
            if ( caseBill.IsSend )
            {
                this.neuSpread1_Sheet1.Cells [row, 13].Text = "是";
            }
            else
            {
                this.neuSpread1_Sheet1.Cells [row, 13].Text = "否";
            }
            // 发送人
            this.neuSpread1_Sheet1.Cells [row, 14].Text = caseBill.SendOper.Name;
            // 发送时间
            this.neuSpread1_Sheet1.Cells [row, 15].Text = caseBill.SendOper.OperTime.ToString();
            // 是否已经接收
            if ( caseBill.IsReceive )
            {
                this.neuSpread1_Sheet1.Cells [row, 16].Text = "是";
            }
            else
            {
                this.neuSpread1_Sheet1.Cells [row, 16].Text = "否";
            }
            // 接收人
            this.neuSpread1_Sheet1.Cells [row, 17].Text = caseBill.ReceiveOper.Name;
            // 接收时间
            this.neuSpread1_Sheet1.Cells [row, 18].Text = caseBill.ReceiveOper.OperTime.ToString();
        }

        /// <summary>
        /// 更新原始单据信息
        /// </summary>
        /// <param name="caseBill">病历单据</param>
        /// <returns>－1－失败，1－成功</returns>
        private int UpdateCaseBillToGrid( HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            try
            {
                if ( this.neuSpread1_Sheet1.RowCount == 0 )
                {
                    caseBill.Memo = "New";
                    
                    this.callReturn = this.AddCaseBillToGrid( caseBill );
                }
                else
                {
                    // 查找行号
                    int row = this.GetRowID( caseBill );
                    if ( row >= 0 )
                    {
                        caseBill.Memo = "Old";
                        this.SetBillToRow( caseBill, row );
                    }
                    else
                    {
                        caseBill.Memo = "New";
                        this.AddCaseBillToGrid( caseBill );
                    }
                }
            }
            catch ( Exception exception )
            {
                MessageBox.Show( exception.Message );
                return -1;
            }

            return callReturn;
        }

        /// <summary>
        /// 查找病历单据行号
        /// </summary>
        /// <param name="caseBill">病历单据</param>
        /// <returns>行号</returns>
        private int GetRowID( Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill )
        {
            for ( int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++ )
            {
                Neusoft.HISFC.Models.HealthRecord.Case.CaseBill rowBill = this.neuSpread1_Sheet1.Rows [i].Tag as Neusoft.HISFC.Models.HealthRecord.Case.CaseBill;

                if ( rowBill == null || rowBill.CaseInfo.Patient.PID.CardNO == "" )
                {
                    MessageBox.Show("第" + i.ToString() + "行病历的病历信息或病历号为空");
                    return -1;
                }

                if ( rowBill.CaseInfo.Patient.PID.CardNO == caseBill.CaseInfo.Patient.PID.CardNO )
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 根据病历单据数组获取单据号码
        /// </summary>
        /// <param name="caseBillList">病历单据数组</param>
        /// <returns>单据号码</returns>
        private string GetBillCodeByCaseList( List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList )
        {
            Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill = new Neusoft.HISFC.Models.HealthRecord.Case.CaseBill();

            if ( caseBillList == null || caseBillList.Count == 0 )
            {
                return "";
            }
            else
            {
                caseBill = caseBillList [0] as Neusoft.HISFC.Models.HealthRecord.Case.CaseBill;

                return caseBill.BillCode;
            }
        }

        /// <summary>
        /// 显示当前单据病历数量
        /// </summary>
        private void DisplayCaseCount()
        {
            this.neuTextBoxCount.Text = this.neuSpread1_Sheet1.RowCount.ToString();
        }

        /// <summary>
        /// 显示病历出库单据
        /// </summary>
        /// <param name="caseBillList">病历出库单据</param>
        /// <returns>－1－失败，1－成功</returns>
        private int DisplayCaseBillList( List<HISFC.Models.HealthRecord.Case.CaseBill> caseBillList )
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm( "正在加载单据信息..." );

            Application.DoEvents();

            this.neuSpread1_Sheet1.RowCount = 0;
            foreach ( HISFC.Models.HealthRecord.Case.CaseBill caseBill in caseBillList )
            {
                caseBill.Memo = "Old";
                this.callReturn = this.AddCaseBillToGrid( caseBill );
                if ( this.callReturn == -1 )
                {
                    this.neuSpread1_Sheet1.RowCount = 0;

                    return -1;
                }
            }

            this.neuTextBoxBillCode.Text = this.GetBillCodeByCaseList( caseBillList );
            this.DisplayCaseCount();
            this.neuTextBoxStatus.Text = this.GetOperateState( this.operateState );

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            return 1;
        }

        /// <summary>
        /// 确认执行前，形成承载实体
        /// </summary>
        /// <returns>－1－失败，1－成功</returns>
        private int MakeCase()
        {
            try
            {
                if ( this.currentCaseBill.Memo == "New"  )
                {
                    if ( this.billCode != "" )
                    {
                        this.currentCaseBill.BillCode = this.billCode;
                    }
                    // 入库申请人工号
                    this.currentCaseBill.InRequestOper.ID = this.loginEmpl.ID;
                    this.currentCaseBill.InRequestOper.Name = this.loginEmpl.Name;
                    // 入库申请科室编码
                    this.currentCaseBill.InRequestOper.Dept.ID = this.loginDept.ID;
                    this.currentCaseBill.InRequestOper.Dept.Name = this.loginDept.Name;
                    // 入库申请病区编码
                    this.currentCaseBill.InRequestNurse.ID = this.loginDept.ID;
                    this.currentCaseBill.InRequestNurse.Name = this.loginDept.Name;
                    // 入库申请时间
                    this.currentCaseBill.InRequestOper.OperTime = this.caseBillIntegrate.GetDateTime();
                    // 入库申请分区编码

                    // 单据状态
                    this.currentCaseBill.CaseBillState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest;

                }
                else
                {
                    if ( this.currentCaseBill.CaseBillState == Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest )
                    {
                        this.currentCaseBill.OutAuditingOper.ID = this.loginEmpl.ID;
                        this.currentCaseBill.OutAuditingOper.Name = this.loginEmpl.Name;
                        this.currentCaseBill.OutAuditingOper.OperTime = this.caseBillIntegrate.GetDateTime();
                    }
                    else if ( this.currentCaseBill.CaseBillState == Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.OutAuditing )
                    {
                        this.currentCaseBill.InConfirmOper.ID = this.loginEmpl.ID;
                        this.currentCaseBill.InConfirmOper.Name = this.loginEmpl.Name;
                        this.currentCaseBill.InConfirmOper.OperTime = this.caseBillIntegrate.GetDateTime();
                    }
                }

                // 申请的出库部门
                this.currentCaseBill.FromDept.ID = this.neuComboBoxDept.SelectedItem.ID;
                this.currentCaseBill.FromDept.Name = this.neuComboBoxDept.SelectedItem.Name;
                if ( this.currentCaseBill.FromDept.ID == null || this.currentCaseBill.FromDept.ID == "" )
                {
                    MessageBox.Show( "请选择病历出处的\"申请目标\"" );
                    return -1;
                }
            }
            catch ( Exception exception )
            {
                MessageBox.Show( exception.Message );
                return -1;
            }
            

            return 1;
        }

        /// <summary>
        /// 确认执行
        /// </summary>
        /// <returns>－1－失败，1－成功</returns>
        private int ConfirmCase()
        {
            if ( this.currentCaseBill.CaseInfo == null || this.currentCaseBill.CaseInfo.ID == "" )
            {
                return -1;
            }

            if ( this.neuComboBoxDept.SelectedItem == null )
            {
                MessageBox.Show( "请选择病历所在的申请目标科室" );
                this.neuComboBoxDept.Focus();

                return -1;
            }

            // 形成实体
            this.callReturn = this.MakeCase();
            if ( this.callReturn == -1 )
            {
                return -1;
            }

            switch ( this.operateState )
            {
                case OperateState.Idle:
                    break;
                case OperateState.NewBill:
                    this.callReturn = this.UpdateCaseBillToGrid( this.currentCaseBill );
                    break;
                case OperateState.OldBill:
                    this.callReturn = this.UpdateCaseBillToGrid( this.currentCaseBill );
                    break;
            }

            this.DisplayCaseCount();

            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>1－成功，－1－失败</returns>
        private int SaveBill()
        {
            if ( this.neuSpread1_Sheet1.RowCount > 0 )
            {
                if ( DialogResult.Yes == MessageBox.Show( "是否保存？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 ) )
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    //Neusoft.FrameWork.Management.Transaction transaction = new Neusoft.FrameWork.Management.Transaction( Neusoft.FrameWork.Management.Connection.Instance );
                    //transaction.BeginTransaction();

                    this.caseBillIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    if ( this.CurrentOperateState == OperateState.NewBill )
                    {
                        this.billCode = this.caseBillIntegrate.GetBillCode();
                        if ( billCode == "" )
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show( "获取单据号失败" );
                            return -1;
                        }
                    }

                    DateTime operTime = this.caseBillIntegrate.GetDateTime();

                    foreach ( FarPoint.Win.Spread.Row row in this.neuSpread1_Sheet1.Rows )
                    {
                        Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill = row.Tag as Neusoft.HISFC.Models.HealthRecord.Case.CaseBill;

                        if ( caseBill.Memo == "Old" )
                        {
                            if ( caseBill.CaseInfo.Memo == "Delete" )
                            {
                                this.callReturn = this.caseBillIntegrate.Delete( caseBill );
                            }
                            else
                            {
                                switch ( this.currentState )
                                {
                                    case Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest:
                                        caseBill.InRequestOper.ID = this.loginEmpl.ID;
                                        caseBill.InRequestOper.OperTime = operTime;
                                        caseBill.InRequestOper.Dept.ID = this.loginDept.ID;
                                        caseBill.InRequestNurse.ID = this.loginDept.ID;
                                        break;
                                    case Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.OutAuditing:
                                        caseBill.OutAuditingOper.ID = this.loginEmpl.ID;
                                        caseBill.OutAuditingOper.Dept.ID = this.loginDept.ID;
                                        caseBill.OutAuditingOper.OperTime = operTime;
                                        caseBill.OutAuditingNurse.ID = this.loginDept.ID;
                                        caseBill.CaseBillState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.OutAuditing;
                                        break;
                                    case Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InConfirm:
                                        caseBill.InConfirmOper.ID = this.loginEmpl.ID;
                                        caseBill.InConfirmOper.OperTime = operTime;
                                        caseBill.CaseBillState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InConfirm;
                                        break;
                                }
                                this.callReturn = this.caseBillIntegrate.Update( caseBill );
                            }
                        }
                        else
                        {
                            caseBill.BillCode = this.billCode;

                            this.callReturn = this.caseBillIntegrate.Insert( caseBill );
                        }

                        if ( this.callReturn != 1 )
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();

                            MessageBox.Show( this.caseBillIntegrate.Err, "保存失败" );

                            return -1;
                        }
                    }

                    Neusoft.FrameWork.Management.PublicTrans.Commit();

                    InitUC();

                    return 1;
                }
                else
                {
                    return 1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 初始化UC
        /// </summary>
        private void InitUC()
        {
            this.InitCaseInfoDisplay();
            this.InitCaseBillTree();
            this.InitDeptComboBox();
            this.neuSpread1_Sheet1.RowCount = 0;
            this.operateState = OperateState.NewBill;
            this.billCode = string.Empty;
            this.neuTextBoxStatus.Text = this.GetOperateState( this.operateState );
            this.currentCaseBill = new Neusoft.HISFC.Models.HealthRecord.Case.CaseBill();
            this.DisplayCaseCount();
            this.currentState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest;
            this.neuButtonConfirmApply.Enabled = true;
            this.neuTextBoxCardNo.Enabled = true;
            this.neuComboBoxDept.Enabled = true;
            this.neuTextBoxCardNo.Focus();
        }

        #endregion

        #region 事件

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit( object sender, object neuObject, object param )
        {
            try
            {
                this.loginEmpl = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

                this.loginDept.ID = this.loginEmpl.Dept.ID;
                this.loginDept.Name = this.loginEmpl.Dept.Name;

                this.InitUC();

                toolbarService.AddToolButton( "新建", "新建病历出入库单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null );
            }
            catch ( Exception exception )
            {
                MessageBox.Show( exception.Message, "错误信息" );
            }

            return this.toolbarService;
        }

        /// <summary>
        /// 工具栏单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked( object sender, ToolStripItemClickedEventArgs e )
        {
            this.InitUC();
            
            base.ToolStrip_ItemClicked( sender, e );
        }

        /// <summary>
        /// 鼠标单击树结点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTreeViewBill_NodeMouseClick( object sender, TreeNodeMouseClickEventArgs e )
        {
            // 单击的是单据结点
            if ( e.Node.Level == 2 )
            {
                try
                {
                    Neusoft.FrameWork.Models.NeuObject node = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                    this.operateState = OperateState.OldBill;

                    this.billCode = node.ID;

                    TreeNode parentNode = e.Node.Parent;
                    switch ( parentNode.Text )
                    {
                        case "已经申请入库":
                            this.currentState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest;
                            break;
                        case "等待出库审核":
                            this.currentState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.OutAuditing;
                            break;
                        case "等待入库确认":
                            this.currentState = Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InConfirm;
                            break;
                    }

                    if ( this.currentState != Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest )
                    {
                        this.neuButtonConfirmApply.Enabled = false;
                        this.neuTextBoxCardNo.Enabled = false;
                        this.neuComboBoxDept.Enabled = false;
                    }
                    else
                    {
                        this.neuButtonConfirmApply.Enabled = true;
                        this.neuTextBoxCardNo.Enabled = true;
                        this.neuComboBoxDept.Enabled = true;
                    }

                    if ( this.currentState == Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InConfirm )
                    {
                        this.neuButtonDelete.Enabled = false;
                    }
                    else
                    {
                        this.neuButtonDelete.Enabled = true;
                    }

                    this.QueryByBillCode( node.ID );
                }
                catch ( Exception exception )
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

                    MessageBox.Show( exception.Message );
                }
            }
        }

        /// <summary>
        /// 病历号回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBoxCardNo_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                if ( this.neuTextBoxCardNo.Text != "" )
                {
                    this.neuTextBoxCardNo.Text = this.neuTextBoxCardNo.Text.PadLeft( 10, '0' );
                    this.callReturn = this.QueryByCardNo( this.neuTextBoxCardNo.Text );
                    if ( this.callReturn == -1 )
                    {
                        return;
                    }

                    switch ( this.operateState )
                    {
                        case OperateState.Idle:
                            this.CurrentOperateState = OperateState.NewBill;
                            if ( this.currentCaseBill.Memo == "" )
                            {
                                this.currentCaseBill.Memo = "New";
                            }
                            
                            break;
                        case OperateState.NewBill:
                            if ( this.currentCaseBill.Memo == "" )
                            {
                                this.currentCaseBill.Memo = "New";
                            }
                            break;
                        case OperateState.OldBill:
                            break;
                    }
                    this.neuComboBoxDept.Focus();
                }
            }
        }

        /// <summary>
        /// 确认执行按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuButtonConfirmApply_Click( object sender, EventArgs e )
        {
            if ( this.currentCaseBill.CaseInfo == null || this.currentCaseBill.CaseInfo.ID == "" )
            {
                return;
            }
            if ( this.currentState != Neusoft.HISFC.Models.HealthRecord.Case.EnumCaseBillState.InRequest )
            {
                return;
            }

            this.ConfirmCase();
        }

        /// <summary>
        /// 表格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellClick( object sender, FarPoint.Win.Spread.CellClickEventArgs e )
        {
            if ( this.neuSpread1_Sheet1.RowCount >0 && e.Row >= 0 )
            {
                try
                {
                    this.CurrentCaseBill = this.neuSpread1_Sheet1.Rows [e.Row].Tag as Neusoft.HISFC.Models.HealthRecord.Case.CaseBill;

                    if ( this.currentCaseBill.CaseInfo.Memo == "Delete" )
                    {
                        this.neuButtonDelete.Text = "取消删除";
                    }
                    else
                    {
                        this.neuButtonDelete.Text = "删除";
                    }
                }
                catch ( Exception exception )
                {
                    MessageBox.Show( exception.Message );
                }
            }
        }

        /// <summary>
        /// 删除按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuButtonDelete_Click( object sender, EventArgs e )
        {
            int selectRow = this.neuSpread1_Sheet1.SelectionCount;
            if ( selectRow > 0 )
            {
                if ( DialogResult.Yes != MessageBox.Show( "是否操作？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) )
                {
                    return;
                }

                foreach ( FarPoint.Win.Spread.Model.CellRange selectRange in this.neuSpread1_Sheet1.GetSelections() )
                {
                    try
                    {
                        FarPoint.Win.Spread.Row row = this.neuSpread1_Sheet1.Rows [selectRange.Row];
                        Neusoft.HISFC.Models.HealthRecord.Case.CaseBill caseBill = row.Tag as Neusoft.HISFC.Models.HealthRecord.Case.CaseBill;

                        if ( caseBill.Memo == "New" )
                        {
                            this.neuSpread1_Sheet1.Rows.Remove( selectRange.Row, 1 );
                        }
                        else
                        {
                            if ( caseBill.CaseInfo.Memo == "Delete" )
                            {
                                caseBill.CaseInfo.Memo = "";
                                this.neuSpread1_Sheet1.RowHeader.Rows [selectRange.Row].Label = "";
                                this.neuButtonDelete.Text = "删除";
                            }
                            else
                            {
                                caseBill.CaseInfo.Memo = "Delete";
                                this.neuSpread1_Sheet1.RowHeader.Rows [selectRange.Row].Label = "Del";
                                this.neuButtonDelete.Text = "取消删除";
                            }

                            this.neuSpread1_Sheet1.Rows [selectRange.Row].Tag = caseBill;
                        }
                    }
                    catch ( Exception exception )
                    {
                        MessageBox.Show( exception.Message );
                    }
                }

                
            }
        }

        /// <summary>
        /// 保存时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave( object sender, object neuObject )
        {
            this.SaveBill();

            return base.OnSave( sender, neuObject );
        }

        /// <summary>
        /// 日期控件值变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuDateTimePicker1_ValueChanged( object sender, EventArgs e )
        {
            this.InitUC();
        }

        /// <summary>
        /// 病历号控件成为当前控件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTextBoxCardNo_Enter( object sender, EventArgs e )
        {
            this.neuTextBoxCardNo.SelectAll();
        }

        /// <summary>
        /// 科室选择回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuComboBoxDept_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                if ( this.neuComboBoxDept.SelectedItem == null )
                {
                    return;
                }

                this.neuButtonConfirmApply.Focus();
            }
        }

        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey( Keys keyData )
        {
            switch ( keyData )
            {
                case Keys.F5:
                    this.neuTextBoxCardNo.Focus();
                    break;
            }

            return base.ProcessDialogKey( keyData );
        }

        #endregion
       
    }

    /// <summary>
    /// 操作状态
    /// </summary>
    public enum OperateState
    {
        /// <summary>
        /// 空闲的，什么单据都没有
        /// </summary>
        Idle = 0,
        /// <summary>
        /// 新建单据
        /// </summary>
        NewBill = 1,
        /// <summary>
        /// 处理非新单据
        /// </summary>
        OldBill = 2
    }
}
