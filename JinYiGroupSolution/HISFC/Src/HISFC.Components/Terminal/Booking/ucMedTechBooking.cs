using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Terminal;
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Public;
using MedTechItemTemp=Neusoft.HISFC.Models.Terminal.MedTechItemTemp;

namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucMedTechBooking <br></br>
	/// [功能描述: 医技预约UC]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-14'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    public partial class ucMedTechBooking : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
	{
		public ucMedTechBooking()
		{
			InitializeComponent();
			
			if (this.DesignMode)
			{
				return;
			}

			this.operEnviroment.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
			this.operEnviroment.Name = Neusoft.FrameWork.Management.Connection.Operator.Name;
			this.operEnviroment.Dept = ((Neusoft.HISFC.Models.Base.Employee) Neusoft.FrameWork.Management.Connection.Operator).Dept;
            dateTimeBegin = System.DateTime.Now.AddDays(-beforeDays);
            dateTimeEnd = System.DateTime.Now.AddDays(afterDays);
		}

		#region 变量

		/// <summary>
		/// 文本类型的单元格
		/// </summary>
		FarPoint.Win.Spread.CellType.TextCellType textCellType = new FarPoint.Win.Spread.CellType.TextCellType();

		/// <summary>
		/// 午别数组
		/// </summary>
		private ArrayList noonList = null;

		/// <summary>
		/// 
		/// </summary>
		private Neusoft.FrameWork.Public.ObjectHelper noonListHelper = new ObjectHelper();
        /// <summary>
        /// 当前几天
        /// </summary>
        private int beforeDays = 3;
        /// <summary>
        /// 之后几天
        /// </summary>
        private int afterDays = 7;

		/// <summary>
		/// 拖动对象
		/// </summary>
		private Neusoft.HISFC.Models.Terminal.MedTechBookApply dragMedTechBookApply = new MedTechBookApply();

		/// <summary>
		/// 查询病人基本预约项目的起始时间 
		/// </summary>
		private System.DateTime dateTimeBegin ;
		
		/// <summary>
		/// 查询病人基本预约项目的结束时间 
		/// </summary>
		private System.DateTime dateTimeEnd ;
        Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
 
        Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
		/// <summary>
		/// 基础数据库类
		/// </summary>
		Neusoft.FrameWork.Management.DataBaseManger databaseManagerFunction = new DataBaseManger();
        Neusoft.HISFC.Components.Common.Controls.baseTreeView baseTreeView = new Neusoft.HISFC.Components.Common.Controls.baseTreeView();
        HISFC.Components.Terminal.Booking.IBookingPrint bookingPrint = null;
		/// <summary>
		/// 默认输入门诊
		/// </summary>
		private bool isClinic = true;

		/// <summary>
		/// 是否允许预约
		/// </summary>
		private bool isCanCancel = true;

		/// <summary>
		/// 预约表格的字段定义
		/// </summary>
		private enum Cols
		{
			/// <summary>
			/// 是否选中
			/// </summary>
			CheckUp,
			/// <summary>
			/// 预约项目
			/// </summary>
			ItemName,
			/// <summary>
			/// 预约日期
			/// </summary>
			PreDate,
            //{5A111831-190D-4187-8076-83E220BC97B2}
			/// <summary>
			/// 午别->时间段
			/// </summary>
			NoonType,
			/// <summary>
			/// 执行科室
			/// </summary>
			ExeDeptName,
			/// <summary>
			/// 序号
			/// </summary>
			Sort,
			/// <summary>
			/// 注释
			/// </summary>
			Memo,
			/// <summary>
			/// 预约单号
			/// </summary>
			ID,
            //{5A111831-190D-4187-8076-83E220BC97B2}
            /// <summary>
            /// 执行设备
            /// </summary>
            Machine
		}
		
		/// <summary>
		/// 排班信息
		/// </summary>
		private enum ExCols
		{
			/// <summary>
			/// 项目代码
			/// </summary>
			itemCode, 
			/// <summary>
			/// 项目名称
			/// </summary>
			itemName,
			/// <summary>
			/// 单位标识  1 明细 2 组套 3 复合项目
			/// </summary>
			unitFlag,
			/// <summary>
			/// 科室号
			/// </summary>
			deptCode,
			/// <summary>
			/// 科室名称
			/// </summary>
			deptName,
			/// <summary>
			/// 预约时间
			/// </summary>
			bookDate,
			/// <summary>
			/// 午别
			/// </summary>
			noonCode,
            /// <summary>
            /// 预约限额
			/// </summary>
			bookLimit,
			/// <summary>
			/// 特诊预约限额
			/// </summary>
			specialbookLimit,
			/// <summary>
			/// 已经预约数
			/// </summary>
			bookNum,
			/// <summary>
			/// 特诊预约数
			/// </summary>
			specalBook,
			/// <summary>
			/// 执行地点
			/// </summary>
			exeLocate,
			/// <summary>
			/// 取报告时间
			/// </summary>
			reportDate,
			/// <summary>
			/// 有创
			/// </summary>
			hurtFlag,
			/// <summary>
			/// 知情同意
			/// </summary>
			reasonable,
			/// <summary>
			/// 标本
			/// </summary>
			sampleKind,
			/// <summary>
			/// 采样方法
			/// </summary>
			sampleWay,
			/// <summary>
			/// 注意事项
			/// </summary>
			remark,
            confirmNum,
            /// <summary>
            /// 开始时间
            /// </summary>
            startTime,
            /// <summary>
            /// 结束时间
            /// </summary>
            endTime,
            /// <summary>
            /// 执行设备 //{5A111831-190D-4187-8076-83E220BC97B2}
            /// </summary>
            machine,
			
		}
		
		/// <summary>
		/// 操作环境
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment operEnviroment = new OperEnvironment();
		
		/// <summary>
		/// 业务
		/// </summary>
		private Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ();
		
		#endregion

        #region 属性
        /// <summary>
        /// 根据就诊号可以查询之前几天的数据
        /// </summary>
        [Category("控件设置"), System.ComponentModel.Description("根据就诊号可以查询之前几天的数据")]
        public int BeforeDays
        {
            get
            {
                return beforeDays;
            }
            set
            {
                beforeDays = value;
            }
        }
        /// <summary>
        /// 根据就诊号可以查询之前几天的数据
        /// </summary>
        [Category( "控件设置" ), System.ComponentModel.Description( "根据就诊号可以查询之后几天的数据" )]
        public int AfterDays
        {
            get
            {
                return afterDays;
            }
            set
            {
                afterDays = value;
            }
        }
        #endregion 

        #region 工具栏信息


        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("预约", "预约", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolBarService.AddToolButton("取消", "取消", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null); 

            if (this.DesignMode)
            {
                return toolBarService;
            }
            textCellType.Multiline = true;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询请等待 ...");

            Application.DoEvents();

            try
            {
                this.neuDateTimePicker1.Value = System.DateTime.Now;
                this.neuDateTimePicker2.Value = System.DateTime.Now.AddDays(7);

                this.InitInfo();
                this.noonList = managerMgr.QueryConstantList("NOON");
                //this.noonList = this.bookingIntegrate.DoctSchemaQuery();
                this.noonListHelper.ArrayObject = this.noonList;

                this.SetFarPoint();

                this.ucChooseList1.tvList.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvList_NodeMouseClick);
                this.ucChooseList1.tvList.ItemDrag += new ItemDragEventHandler(tvList_ItemDrag);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
            }

            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "预约":
                    this.Arrange(neuSpreadArrange_1.ActiveRowIndex);
                    break;
                case "取消":
                    this.Delete();
                    break; 
                default:
                    break;
            }
        }
        #endregion

                #endregion

        #region 函数 
        protected override int OnPrint(object sender, object neuObject)
        { 
            try
            {
                if (this.neuSpreadBooking_Sheet1.Rows.Count == 0)
                {
                    return -1;
                }
                ArrayList list = new ArrayList();
                for (int i = 0; i < this.neuSpreadBooking_Sheet1.RowCount; i++)
                {
                    if (this.neuSpreadBooking_Sheet1.Cells[i, 0].Value.ToString().ToLower() == "true")
                    {
                        Neusoft.HISFC.Models.Terminal.MedTechBookApply obj = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)this.neuSpreadBooking_Sheet1.Rows[i].Tag;
                        list.Add(obj);
                    }
                }
                if (list.Count == 0)
                {
                    return 0 ;
                }
                #region   打印
                if (list.Count > 0)
                {
                    if (this.bookingPrint == null)
                    {
                        foreach (Neusoft.HISFC.Models.Terminal.MedTechBookApply obj in list)
                        {
                            this.bookingPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(IBookingPrint)) as IBookingPrint;
                            if (this.bookingPrint == null)
                            {
                                MessageBox.Show("获得接口IBookingPrint错误\n，可能没有维护相关的打印控件或打印控件没有实现接口IBookingPrint\n请与系统管理员联系。");
                                return 1;
                            }
                            //清空
                            this.bookingPrint.Reset();
                            this.bookingPrint.SetValue(obj);
                            this.bookingPrint.Print();
                        }
                    }
                     
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return base.OnPrint(sender, neuObject);
        }
        /// <summary>
        /// 预约安排
        /// </summary>
        /// <param name="row">行号</param>
        /// <returns>－1－失败；</returns>
        private int Arrange(int row)
        {
            if (!this.isCanCancel)
            {
                return 0;
            }

            if (ValidBeforeSave(row) == -1)
            {
                return -1;
            }

            try
            {
                 
                // 医技预约实体
                Neusoft.HISFC.Models.Terminal.MedTechBookApply tempObj = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)this.ucChooseList1.tvList.SelectedNode.Tag;
                // 预约信息
                ArrayList tempList = this.bookingIntegrate.QueryTerminalApply(tempObj.ItemList.Order.ID);


                if (tempList == null || tempList.Count == 0)
                {
                    MessageBox.Show("根据MoOrder查询预约信息失败");
                    return -1;
                }

                Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBoolApply = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)tempList[0];

                if (tempMedTechBoolApply.ArrangeQty != tempObj.ArrangeQty)
                {
                    MessageBox.Show("数据已经改变请刷新数据");
                    return -1;
                }

                if (this.dragMedTechBookApply == null)
                {
                    this.dragMedTechBookApply = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)tempList[0];
                }
                // 项目代码
                this.dragMedTechBookApply.ItemComparison.ID = this.neuSpreadArrange_1.Cells[row, (int)ExCols.itemCode].Text;
                this.dragMedTechBookApply.ItemList.Item.ID = tempMedTechBoolApply.ItemList.Item.ID;

                Neusoft.HISFC.Models.Base.Const conItem = (Neusoft.HISFC.Models.Base.Const)managerMgr.GetConstant("MEDTECHITEM", dragMedTechBookApply.ItemComparison.ID);
                if (!conItem.IsValid)
                {
                    MessageBox.Show("该项目信息已经作废或删除,不允许预约");
                    return -1;
                }
                // 项目名称
                this.dragMedTechBookApply.ItemList.Item.Name = tempMedTechBoolApply.ItemList.Item.Name;
                // 单位标识 1 明细 2 组套 3 复合项目
                this.dragMedTechBookApply.ItemExtend.UnitFlag = this.neuSpreadArrange_1.Cells[row, (int)ExCols.unitFlag].Text;
                if (this.dragMedTechBookApply.ItemExtend.UnitFlag == "明细")
                {
                    this.dragMedTechBookApply.ItemExtend.UnitFlag = "1";
                }
                else
                {
                    this.dragMedTechBookApply.ItemExtend.UnitFlag = "2";
                }
                // 科室号

                if (dragMedTechBookApply.ItemList.ExecOper.Dept.ID != neuSpreadArrange_1.Cells[row, (int)ExCols.deptCode].Text)
                {
                    MessageBox.Show("执行科室不对应,请选择对应的科室");
                    return -1;
                }
                this.dragMedTechBookApply.ItemList.ExecOper.Dept.ID = this.neuSpreadArrange_1.Cells[row, (int)ExCols.deptCode].Text;
                // 科室名称
                this.dragMedTechBookApply.ItemList.ExecOper.Dept.Name = this.neuSpreadArrange_1.Cells[row, (int)ExCols.deptName].Text;
                // 预约时间
                this.dragMedTechBookApply.MedTechBookInfo.BookTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpreadArrange_1.Cells[row, (int)ExCols.bookDate].Value);
                // 午别
                this.dragMedTechBookApply.Noon.Name = this.neuSpreadArrange_1.Cells[row, (int)ExCols.noonCode].Text;
                //时间段 //{5A111831-190D-4187-8076-83E220BC97B2}
                this.dragMedTechBookApply.MedTechBookInfo.User01 = this.neuSpreadArrange_1.Cells[row, (int)ExCols.startTime].Text + "--" + this.neuSpreadArrange_1.Cells[row, (int)ExCols.endTime].Text;
                //执行设备 //{5A111831-190D-4187-8076-83E220BC97B2}
                this.dragMedTechBookApply.MedTechBookInfo.User02 = this.neuSpreadArrange_1.Cells[row, (int)ExCols.machine].Text;
                // 午别 
                this.dragMedTechBookApply.Noon.ID = this.noonListHelper.GetID(this.neuSpreadArrange_1.Cells[row, (int)ExCols.noonCode].Text);
                if (dragMedTechBookApply.Noon.ID == null || dragMedTechBookApply.Noon.ID == "")
                {
                    MessageBox.Show("没有午别信息,改午别可能已经作废或删除");
                    return -1;
                }
                Neusoft.HISFC.Models.Base.Const con = (Neusoft.HISFC.Models.Base.Const)managerMgr.GetConstant("NOON", dragMedTechBookApply.Noon.ID);
                if (!con.IsValid)
                {
                    MessageBox.Show("该午别已经作废或删除,不允许预约");
                    return -1;
                }
                // 执行地点 
                this.dragMedTechBookApply.ItemList.Order.DoctorDept.Name = this.neuSpreadArrange_1.Cells[row, (int)ExCols.exeLocate].Text;
                // 取报告时间

                this.dragMedTechBookApply.ReportTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpreadArrange_1.Cells[row, (int)ExCols.reportDate].Text);
                // 有创无创
                this.dragMedTechBookApply.ItemExtend.HurtFlag = this.neuSpreadArrange_1.Cells[row, (int)ExCols.hurtFlag].Text;
                // 知情同意书

                this.dragMedTechBookApply.ItemExtend.ReasonableFlag = this.neuSpreadArrange_1.Cells[row, (int)ExCols.reasonable].Text;
                // 标本或部位

                this.dragMedTechBookApply.ItemExtend.SimpleKind = this.neuSpreadArrange_1.Cells[row, (int)ExCols.sampleKind].Text;
                // 采样方法
                this.dragMedTechBookApply.ItemExtend.SimpleWay = this.neuSpreadArrange_1.Cells[row, (int)ExCols.sampleWay].Text;
                // 注意事项
                this.dragMedTechBookApply.Memo = this.neuSpreadArrange_1.Cells[row, (int)ExCols.remark].Text;

                return Save(this.dragMedTechBookApply, row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="row">行号</param>
        /// <returns>1－成功；－1－失败</returns>
        private int ValidBeforeSave(int row)
        {
            if (this.ucChooseList1.tvList.Nodes.Count == 0)
            {
                MessageBox.Show("请选择需要安排的项目");
                return -1;
            }
            if (this.ucChooseList1.tvList.SelectedNode == null)
            {
                MessageBox.Show("请选择需要安排的项目");
                return -1;
            }
            if (this.ucChooseList1.tvList.SelectedNode.Level != 1)
            {
                MessageBox.Show("请选择需要安排的项目");
                return -1;
            }
            if (this.ucChooseList1.tvList.SelectedNode.Tag == null)
            {
                MessageBox.Show("请选择需要安排的项目");
                return -1;
            }
            if (this.neuSpreadArrange_1.RowCount == 0)
            {
                MessageBox.Show("没有查到相关的安排信息");
                return -1;
            }
            if (Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpreadArrange_1.Cells[row, (int)ExCols.bookDate].Text).Date < System.DateTime.Now.Date)
            {
                MessageBox.Show("预约时间不能小于当前时间");
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="tempMedTechBoolApply">医技预约实体</param>
        /// <param name="row">行号</param>
        /// <returns></returns>
        private int Save(Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBoolApply, int row)
        {
            // 数据库事务

            //Neusoft.FrameWork.Management.Transaction transaction = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //是否是特诊患者

            bool isSpecalPatient = false;
            // 非药品

            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = null;
            // 项目排班表项目具体信息

            ArrayList itemArrangeList = new ArrayList();
            // 医技预约排班信息
            Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp = new MedTechItemTemp();
            // 返回值

            int i = 1;
            //
            // 设置事务
            //
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //transaction.BeginTransaction();
            this.bookingIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //
            // 查询信息的注意事项
            //
            undrug = this.bookingIntegrate.GetValidItemByUndrugCode(tempMedTechBoolApply.ItemList.Item.ID);
            if (undrug != null && undrug.Notice != null && undrug.Notice != "")
            {
                tempMedTechBoolApply.Memo = undrug.Notice;
            }
            this.neuRichTextBoxPatientNotice.Text = tempMedTechBoolApply.Memo;
            //
            // 判断住院/门诊病人是否是特诊患者

            //
            isSpecalPatient = IsSpecalPatient(tempMedTechBoolApply, ref i); // 门诊取卡号 ，住院取住院流水号

            if (i == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            if (tempMedTechBoolApply == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("请选择需要安排的病人项目");
                return -1;
            }
            if (row < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("请选择项目扩展信息");
                return -1;
            }
            //
            // 判断是否超出限额
            //
            // 获取项目排班表项目具体信息

            itemArrangeList = this.bookingIntegrate.QuerySchema(tempMedTechBoolApply.ItemList.ExecOper.Dept.ID, tempMedTechBoolApply.MedTechBookInfo.BookTime, tempMedTechBoolApply.MedTechBookInfo.BookTime, tempMedTechBoolApply.ItemComparison.ID, tempMedTechBoolApply.Noon.ID.ToString());
            if (itemArrangeList == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("获取扩展信息失败" + this.bookingIntegrate.Err);
                return -1;
            }
            if (itemArrangeList.Count == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("没有找到对应的扩展信息" + this.bookingIntegrate.Err);
                return -1;
            }
            // 医技预约排班信息
            tempMedTechItemTemp = (Neusoft.HISFC.Models.Terminal.MedTechItemTemp)itemArrangeList[0];
            tempMedTechItemTemp.NoonCode = this.noonListHelper.GetID(tempMedTechItemTemp.NoonCode);
            if (!isSpecalPatient)
            {
                //普通患者

                if (tempMedTechItemTemp.BookLmt <= tempMedTechItemTemp.MedTechItem.Item.ChildPrice)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(tempMedTechBoolApply.MedTechBookInfo.BookTime.ToShortDateString() + "预约数已满" + "请预约其他日期");
                    return -1;
                }
            }
            else
            {
                //特诊患者

                if (tempMedTechItemTemp.SpecialBookLmt <= tempMedTechItemTemp.MedTechItem.Item.SpecialPrice)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(tempMedTechBoolApply.MedTechBookInfo.BookTime.ToShortDateString() + "预约数已满" + "请预约其他日期");
                    return -1;
                }
            }
            //操作员科室

            tempMedTechBoolApply.ItemList.Order.DoctorDept.Name = this.operEnviroment.Dept.Name;
            tempMedTechBoolApply.ItemList.Order.DoctorDept.ID = this.operEnviroment.Dept.ID;
            //预约申请表

            if (this.bookingIntegrate.PlanMedTechBookApply(tempMedTechBoolApply) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("安排失败" + this.bookingIntegrate.Err);
                return -1;
            }
            // 预约安排明细表

            if (this.bookingIntegrate.InsertMedTechApplyDetailInfo(tempMedTechBoolApply) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("安排失败" + this.bookingIntegrate.Err);
                return -1;
            }
            // 更新已安排数量

            if (this.bookingIntegrate.UpdateApplyNum(tempMedTechBoolApply.ArrangeQty + 1, tempMedTechBoolApply) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新安排数量失败" + this.bookingIntegrate.Err);
                return -1;
            }
            if (isSpecalPatient)
            {
                tempMedTechItemTemp.MedTechItem.Item.SpecialPrice = tempMedTechItemTemp.MedTechItem.Item.SpecialPrice + 1;

                this.neuSpreadArrange_1.Cells[row, (int)ExCols.specalBook].Text = tempMedTechItemTemp.MedTechItem.Item.SpecialPrice.ToString();
            }
            else
            {
                tempMedTechItemTemp.MedTechItem.Item.ChildPrice = tempMedTechItemTemp.MedTechItem.Item.ChildPrice + 1;
                string strTemp = tempMedTechItemTemp.MedTechItem.Item.ChildPrice.ToString();
                this.neuSpreadArrange_1.Cells[row, (int)ExCols.bookNum].Text = strTemp;
            }
            if (this.bookingIntegrate.UpdateItemBookingNumber(tempMedTechItemTemp) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                #region 回退
                if (isSpecalPatient)
                {
                    tempMedTechItemTemp.MedTechItem.Item.SpecialPrice = tempMedTechItemTemp.MedTechItem.Item.SpecialPrice - 1;

                    this.neuSpreadArrange_1.Cells[row, (int)ExCols.specalBook].Text = tempMedTechItemTemp.MedTechItem.Item.SpecialPrice.ToString();
                }
                else
                {
                    tempMedTechItemTemp.MedTechItem.Item.ChildPrice = tempMedTechItemTemp.MedTechItem.Item.ChildPrice -1;
                    string strTemp = tempMedTechItemTemp.MedTechItem.Item.ChildPrice.ToString();
                    this.neuSpreadArrange_1.Cells[row, (int)ExCols.bookNum].Text = strTemp;
                }
                #endregion 
                MessageBox.Show("累加限额失败" + this.bookingIntegrate.Err);
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            // 设置FarPoint
            SetFarPoint();
            this.InitTree("all", this.dateTimeBegin, this.dateTimeEnd, tempMedTechBoolApply.ItemList.Patient.PID.CardNO, "1");
            MessageBox.Show(tempMedTechBoolApply.ItemList.Patient.Name + " 安排成功");
            return 1;
        }

        /// <summary>
        /// 判断是否是特诊患者 
        /// </summary>
        /// <param name="tempMedTechBookApply"> 预约信息</param>
        /// <param name="i">是否出错，－1－出错</param>
        /// <returns>是－true;否-false</returns>
        private bool IsSpecalPatient(Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBookApply, ref int i)
        {
            if (this.isClinic)
            {
                // 门诊挂号实体
                Neusoft.HISFC.Models.Registration.Register tempRegister = this.bookingIntegrate.GetByClinic(tempMedTechBookApply.ItemList.Patient.ID);
                if (tempRegister == null)
                {
                    MessageBox.Show("获取门诊信息出错" + this.bookingIntegrate.Err);
                    i = -1;
                    return false;
                }
                if (tempRegister.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Spe)
                {
                    return true;
                }
            }
            else
            {
                Neusoft.HISFC.Models.RADT.PatientInfo tempPatient = this.bookingIntegrate.QueryPatientInfoByInpatientNO(tempMedTechBookApply.ItemList.ID); //住院流水号
                if (tempPatient == null)
                {
                    MessageBox.Show("获取病人住院信息出错" + this.bookingIntegrate.Err);
                    i = -1;
                    return false;
                }
                if (tempPatient.Pact.ID == "82")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 设置FarPoint
        /// </summary>
        private void SetFarPoint()
        {
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.Memo].CellType = textCellType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.CheckUp].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType NumcellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            NumcellType.DecimalPlaces = 0;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.ItemName].Locked = true;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.PreDate].Locked = true;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.NoonType].Locked = true;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.ExeDeptName].Locked = true;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.Sort].Visible = false;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.Memo].Locked = true;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.ID].Locked = true;

            this.neuSpreadArrange_1.Columns[(int)ExCols.startTime].Visible = true;
            this.neuSpreadArrange_1.Columns[(int)ExCols.endTime].Visible = true;
            this.neuSpreadArrange_1.Columns[(int)ExCols.startTime].Locked = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.endTime].Locked = false;

            this.neuSpreadArrange_1.Columns[(int)ExCols.bookLimit].CellType = NumcellType;
            this.neuSpreadArrange_1.Columns[(int)ExCols.specialbookLimit].CellType = NumcellType;
            this.neuSpreadArrange_1.Columns[(int)ExCols.bookNum].CellType = NumcellType;
            this.neuSpreadArrange_1.Columns[(int)ExCols.specalBook].CellType = NumcellType;
            this.neuSpreadArrange_1.Columns[(int)ExCols.exeLocate].Visible = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.reportDate].Visible = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.hurtFlag].Visible = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.reasonable].Visible = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.sampleKind].Visible = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.sampleWay].Visible = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.remark].Visible = false;
            this.neuSpreadArrange_1.Columns[(int)ExCols.confirmNum].Visible = false;

           
            this.neuSpreadArrange_2.Columns[0].Label = "卡号";
            this.neuSpreadArrange_2.Columns[1].Label = "姓名";
            this.neuSpreadArrange_2.Columns[2].Label = "项目名称";
            this.neuSpreadArrange_2.Columns[3].Label = "执行科室";
            this.neuSpreadArrange_2.Columns[4].Label = "预约时间";
            this.neuSpreadArrange_2.Columns[5].Label = "午别";
            this.neuSpreadArrange_2.Columns[6].Label = "操作员";
            this.neuSpreadArrange_2.Columns[7].Label = "流水号";
            this.neuSpreadArrange_2.Columns[6].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuSpreadArrange_2.Columns[7].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuSpreadArrange_2.Columns[0].CellType = new FarPoint.Win.Spread.CellType.TextCellType();

            this.neuSpreadArrange_3.Columns[0].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.neuSpreadArrange_3.Columns[0].Label = "卡号";
            this.neuSpreadArrange_3.Columns[1].Label = "姓名";
            this.neuSpreadArrange_3.Columns[2].Label = "项目名称";
            this.neuSpreadArrange_3.Columns[3].Label = "执行科室";
            this.neuSpreadArrange_3.Columns[4].Label = "数量";
            this.neuSpreadArrange_3.Columns[5].Label = "收费时间";
            this.neuSpreadArrange_3.RowCount = 0;
           

            //this.neuSpreadArrange_1.SetColumnAllowAutoSort(-1, true);
        }

        /// <summary>
        /// 生成树的节点 
        /// </summary>
        /// <param name="ExecDept">执行科室</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="clinicNO"></param>
        ///  <param name="codeType">号码类别：1 卡号 ， 2 门诊流水号或住院流水号</param>
        private void InitTree(string ExecDept, System.DateTime beginDate, System.DateTime endDate, string clinicNO, string codeType)
        {
            TreeNode NOroot = new TreeNode();

            this.ucChooseList1.tvList.Nodes.Clear();

            NOroot.Text = "未安排项目";
            NOroot.ImageIndex = 0;
            NOroot.SelectedImageIndex = 0;
            this.ucChooseList1.tvList.ImageList = baseTreeView.groupImageList;

            this.ucChooseList1.tvList.Nodes.Add(NOroot);
            //
            // 加载树节点

            //
            // 检索预约主表中没有安排的项目

            ArrayList applyList = this.bookingIntegrate.QueryMedTechApplyList(ExecDept, beginDate, endDate, clinicNO, codeType);
            // 查询预约表中已经安排的项目

            ArrayList Arrangelist = this.bookingIntegrate.QueryMedTechApplyDetailList(ExecDept, beginDate, endDate, clinicNO, codeType);
            if (Arrangelist == null)
            {
                //MessageBox.Show("获取病人已预约项目信息出错");
                return;
            }
            if (applyList == null)
            {
                //MessageBox.Show("获取病人预约项目信息出错");
                return;
            }
            if (applyList.Count == 0 && Arrangelist.Count ==0)
            {
                if (neuTextBoxCardNO.Focused)
                {
                    if (neuTextBoxCardNO.Text != null && neuTextBoxCardNO.Text.Trim() != "")
                    {
                        MessageBox.Show("没有查到该患者的预约信息");
                    }
                }
                else if(ucQueryInpatientNo.TextBox.Focused)
                {
                    if (ucQueryInpatientNo.TextBox.Text != null && ucQueryInpatientNo.TextBox.Text.Trim() != "")
                    {
                        MessageBox.Show("没有查到该患者的预约信息");
                    }
                }
            }
            this.neuTextBoxPatientInformation.Text = "";

            foreach (Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBookApply in applyList)
            {
                //未安排 
                TreeNode node = new TreeNode();
                node.Text = tempMedTechBookApply.ItemList.Item.Name + "[" + tempMedTechBookApply.ItemList.ExecOper.Dept.Name + "]" + "数量 [" + (tempMedTechBookApply.ItemList.Item.Qty - tempMedTechBookApply.ArrangeQty) + "]";
                node.Tag = tempMedTechBookApply;
                node.ImageIndex = 3;
                node.SelectedImageIndex = 4;
                NOroot.Nodes.Add(node);
                if (tempMedTechBookApply == applyList[0])
                {
                    Neusoft.HISFC.Models.Terminal.MedTechBookApply temp = applyList[0] as Neusoft.HISFC.Models.Terminal.MedTechBookApply;
                    Neusoft.HISFC.Models.Registration.Register tempRegister = this.bookingIntegrate.GetByClinic(temp.ItemList.Patient.ID);

                    if (tempRegister == null || tempRegister.ID.Length <= 0)
                    {
                        MessageBox.Show("查询患者基本信息出错" + this.bookingIntegrate.Err, "提示");
                    }
                    else
                    {
                        this.neuTextBoxPatientInformation.Text = "姓名: " + tempRegister.Name + "; " + "性别: " + tempRegister.Sex.Name + " 年龄: " + this.bookingIntegrate.GetAge(tempRegister.Birthday);
                    }
                }
            }
            if (Arrangelist != null && Arrangelist.Count > 0 && this.neuTextBoxPatientInformation.Text == "")
            {
                Neusoft.HISFC.Models.Terminal.MedTechBookApply temp = Arrangelist[0] as Neusoft.HISFC.Models.Terminal.MedTechBookApply;
                Neusoft.HISFC.Models.Registration.Register regInfo = this.bookingIntegrate.GetByClinic(temp.ItemList.ID);

                if (regInfo == null || regInfo.ID.Length <= 0)
                {
                    MessageBox.Show("查询患者基本信息出错" + this.bookingIntegrate.Err, "提示");
                }
                else
                {
                    this.neuTextBoxPatientInformation.Text = "姓名: " + regInfo.Name + "; " + "性别: " + regInfo.Sex.Name + " 年龄: " + this.bookingIntegrate.GetAge(regInfo.Birthday);
                }
            }
            this.ucChooseList1.tvList.ExpandAll();

            AddFp(Arrangelist);
        }

        /// <summary>
        /// 填充已安排病人预约项目信息

        /// </summary>
        /// <param name="list"></param>
        private void AddFp(ArrayList list)
        {
            this.neuSpreadBooking_Sheet1.Rows.Count = 0;//.Remove(0, this.neuSpreadBooking_Sheet1.Rows.Count);
            if (list == null)
            {
                this.neuSpreadBooking_Sheet1.RowCount = 0;
                return;
            }
            foreach (Neusoft.HISFC.Models.Terminal.MedTechBookApply temp in list)
            {
                if (temp.MedTechBookInfo.Status == "2")
                {

                    this.neuSpreadBooking_Sheet1.Rows.Add(0, 1);
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.CheckUp].Value = true;
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.ItemName].Text = temp.ItemList.Item.Name;
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.PreDate].Text = temp.MedTechBookInfo.BookTime.ToShortDateString();
                    //午别改成时间段{5A111831-190D-4187-8076-83E220BC97B2}
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.NoonType].Text = temp.MedTechBookInfo.User01;//noonListHelper.GetName(temp.Noon.ID);
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.ExeDeptName].Text = temp.ItemList.ExecOper.Dept.Name;
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.Sort].Text = temp.SortID.ToString();
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.Memo].Text = temp.Memo;
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.ID].Text = temp.MedTechBookInfo.BookID;
                    //执行设备{5A111831-190D-4187-8076-83E220BC97B2}
                    this.neuSpreadBooking_Sheet1.Cells[0, (int)Cols.Machine].Text = temp.MedTechBookInfo.User02;
                    this.neuSpreadBooking_Sheet1.Rows[0].Tag = temp;
                }
            }
        }

        /// <summary>
        /// 加载患者信息

        /// </summary>
        /// <param name="list"></param>
        private void AddPatientArrangeList(ArrayList list)
        { 
            this.neuSpreadArrange_2.RowCount = 0;
            if (list == null)
            {
                return;
            }
            foreach (Neusoft.HISFC.Models.Terminal.MedTechBookApply info in list)
            {
                this.neuSpreadArrange_2.Rows.Add(0, 1);

                // 卡号
                this.neuSpreadArrange_2.Cells[0, 0].Text = info.ItemList.Patient.PID.CardNO;
                // 姓名
                this.neuSpreadArrange_2.Cells[0, 1].Text = info.ItemList.Patient.Name;
                // 项目名称
                this.neuSpreadArrange_2.Cells[0, 2].Text = info.ItemList.Item.Name;
                // 执行科室
                this.neuSpreadArrange_2.Cells[0, 3].Text = info.ItemList.ExecOper.Dept.Name;
                // 预约时间
                this.neuSpreadArrange_2.Cells[0, 4].Text = info.MedTechBookInfo.BookTime.ToShortDateString();

                // 午别
                this.neuSpreadArrange_2.Cells[0, 5].Text = noonListHelper.GetName(info.Noon.ID);
                // 操作员

                this.neuSpreadArrange_2.Cells[0, 6].Text = info.User01;
                // 流水号

                this.neuSpreadArrange_2.Cells[0, 7].Text = info.ItemList.ID;
                //{5A111831-190D-4187-8076-83E220BC97B2}
                //时间段
                this.neuSpreadArrange_2.Cells[0, 8].Text = info.MedTechBookInfo.User01;
                //执行设备
                this.neuSpreadArrange_2.Cells[0, 9].Text = info.MedTechBookInfo.User02;
            }
            this.neuSpreadArrange.ActiveSheet = this.neuSpreadArrange_2;

        }

        /// <summary>
        /// 加载患者收费明细信息

        /// </summary>
        private void AddFeeItemList()
        {
            if (this.neuSpreadArrange_2.Rows.Count == 0)
            {
                return;
            }
            string strClinicNo = this.neuSpreadArrange_2.Cells[this.neuSpreadArrange_2.ActiveRowIndex, 7].Text;
            string strName = this.neuSpreadArrange_2.Cells[this.neuSpreadArrange_2.ActiveRowIndex, 1].Text;
            if (strClinicNo.IndexOf("ZY") == -1)
            {//门诊患者

                ArrayList list = this.feeMgr.QueryFeeItemListsByClinicNO(strClinicNo);
                if (list == null)
                {
                    return;
                }
                if (this.neuSpreadArrange_3.Rows.Count > 0)
                {
                    this.neuSpreadArrange_3.RowCount = 0;
                }
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList tempItemList in list)
                {
                    this.neuSpreadArrange_3.Rows.Add(0, 1);

                    // 卡号
                    this.neuSpreadArrange_3.Cells[0, 0].Text = tempItemList.Patient.PID.CardNO;
                    // 姓名
                    this.neuSpreadArrange_3.Cells[0, 1].Text = strName;
                    // 项目名称
                    this.neuSpreadArrange_3.Cells[0, 2].Text = tempItemList.Item.Name;
                    // 执行科室
                    this.neuSpreadArrange_3.Cells[0, 3].Text = tempItemList.ExecOper.Dept.Name;
                    this.neuSpreadArrange_3.Cells[0, 4].Text = tempItemList.Item.Qty.ToString();
                    // 收费日期
                    this.neuSpreadArrange_3.Cells[0, 5].Text = tempItemList.FeeOper.OperTime.ToString();
                }
            }
            else
            {//住院患者

                ArrayList list = this.feeMgr.QueryFeeItemListsByClinicNO(strClinicNo);
                if (list == null)
                {
                    return;
                }
                if (this.neuSpreadArrange_3.Rows.Count > 0)
                {
                    this.neuSpreadArrange_3.RowCount = 0;
                }
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList tempItemList in list)
                {
                    this.neuSpreadArrange_3.Rows.Add(0, 1);

                    // 卡号
                    this.neuSpreadArrange_3.Cells[0, 0].Text = tempItemList.Patient.PID.CardNO;
                    // 姓名
                    this.neuSpreadArrange_3.Cells[0, 1].Text = strName;
                    // 项目名称
                    this.neuSpreadArrange_3.Cells[0, 2].Text = tempItemList.Item.Name;
                    // 执行科室
                    this.neuSpreadArrange_3.Cells[0, 3].Text = tempItemList.ExecOper.Dept.Name;
                    this.neuSpreadArrange_3.Cells[0, 4].Text = tempItemList.Item.Qty.ToString();
                    // 收费日期
                    this.neuSpreadArrange_3.Cells[0, 5].Text = tempItemList.FeeOper.OperTime.ToString();
                }
            }

            this.neuSpreadArrange.ActiveSheet = this.neuSpreadArrange_3;

        }
        /// <summary>
        /// 检索数据 
        /// </summary>
        private void Search()
        {
            dateTimeBegin = System.DateTime.Now.AddDays(-beforeDays);
            dateTimeEnd = System.DateTime.Now.AddDays(afterDays);

            //this.neuSpreadArrange_1.DataSource = null;
            System.Data.DataSet dataSet = new System.Data.DataSet();
            //预约到具体时间段




            this.bookingIntegrate.QuerySchema("all", this.neuDateTimePicker1.Value, this.neuDateTimePicker2.Value, "all", ref dataSet);
            if (dataSet == null)
            {
                MessageBox.Show("获取项目扩展信息出错");
            }
            if (dataSet.Tables.Count == 0)
            {
                return;
            }
            this.neuSpreadArrange_1.DataSource = dataSet;
            this.SetFarPoint();
            return;
        }

        /// <summary>
        /// 初始化

        /// </summary>
        private void InitInfo()
        {
            this.neuSpreadArrange_1.DataAutoSizeColumns = false; //设置单元格不自动调整
            //查询最近几天病人的预约信息
            this.InitTree(this.operEnviroment.Dept.ID, this.dateTimeBegin, this.dateTimeEnd, "", "1");
            #region  设定单元格

            FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtType.ReadOnly = true;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.ItemName].CellType = txtType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.PreDate].CellType = txtType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.NoonType].CellType = txtType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.ExeDeptName].CellType = txtType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.Sort].CellType = txtType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.Memo].CellType = txtType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.ID].CellType = txtType;
            this.neuSpreadBooking_Sheet1.Columns[(int)Cols.Machine].CellType = txtType;
            #endregion

            System.Data.DataSet ds = new System.Data.DataSet();
            //查询指定时间内的预约扩展信息
            bookingIntegrate.QuerySchema("all", this.neuDateTimePicker1.Value, this.neuDateTimePicker2.Value, "all", ref ds);
            if (ds == null)
            {
                MessageBox.Show("获取项目扩展信息出错");
            }
            if (ds.Tables.Count == 0)
            {
                return;
            }
            this.neuSpreadArrange_1.DataSource = ds;
        }

        /// <summary>
        /// 删除医技预约
        /// </summary>
        void Delete()
        {
            if (neuSpreadBooking_Sheet1.RowCount == 0)
            {
                MessageBox.Show("请选择需要取消的项目");
                return;
            }
            if (MessageBox.Show("是否真的取消该安排", "提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            ArrayList selectList = new ArrayList(); 
            //判断是否选择了多个
            for (int i = 0; i < this.neuSpreadBooking_Sheet1.RowCount; i++)
            {
                if (this.neuSpreadBooking_Sheet1.Cells[i, (int)Cols.CheckUp].Value != null && neuSpreadBooking_Sheet1.Cells[i, (int)Cols.CheckUp].Value.ToString().ToUpper() == "TRUE")
                {
                    Neusoft.HISFC.Models.Terminal.MedTechBookApply tempApply = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)this.neuSpreadBooking_Sheet1.Rows[i].Tag;
                    selectList.Add(tempApply);
                }
            }
            if (selectList.Count > 1)
            {
                MessageBox.Show("不允许多选删除");
                return;
            }
            if (selectList.Count == 0)
            {
                MessageBox.Show("请选择需要取消的项目");
                return;
            }
            Neusoft.HISFC.Models.Terminal.MedTechBookApply tempBookApply = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)selectList[0];
            if (Neusoft.FrameWork.Function.NConvert.ToDateTime(tempBookApply.MedTechBookInfo.BookTime.ToShortDateString()) < Neusoft.FrameWork.Function.NConvert.ToDateTime(System.DateTime.Now.ToShortDateString()))
            {
                if (MessageBox.Show("该条信息预约时间小于当前时间是否继续取消", "提示", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            if (tempBookApply.Noon.ID == "" || tempBookApply.Noon.ID == null)
            {
                MessageBox.Show("该午别已经作废或删除,请退出窗口重试");
                return;
            }
            Neusoft.HISFC.Models.Base.Const con = (Neusoft.HISFC.Models.Base.Const)managerMgr.GetConstant("NOON", tempBookApply.Noon.ID);
            if (!con.IsValid)
            {
                MessageBox.Show("该午别已经作废或删除,不能再取消预约");
                return ;
            }
            Neusoft.HISFC.Models.Base.Const conItem = (Neusoft.HISFC.Models.Base.Const)managerMgr.GetConstant("MEDTECHITEM", tempBookApply.ItemComparison.ID);
            if (!conItem.IsValid)
            {
                MessageBox.Show("该项目信息已经作废或删除,不能再取消预约");
                return ;
            }
            //ArrayList tempList = this.medTec.GetMedTechApplyList(tempBookApply.ItemList.MoOrder);
            ArrayList tempList = this.bookingIntegrate.QueryTerminalApply(tempBookApply.ItemList.Order.ID);
            if (tempList == null || tempList.Count == 0)
            {
                MessageBox.Show("根据MoOrder查询预约信息失败");
                return;
            }
            Neusoft.HISFC.Models.Terminal.MedTechBookApply tempInfo = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)tempList[0];
            //if (tempInfo.ArrangeQty != tempBookApply.ArrangeQty)
            //{
            //    MessageBox.Show("数据已经改变,请刷新数据");
            //    return;
            //}
            //int intResult = this.bookingIntegrate.IsCanCancelMedTechBookApply(tempInfo);
            //if (intResult == 0)
            //{
            //    MessageBox.Show("已经终端确认，不能取消");
            //    return;
            //}
            //else if (intResult == -1)
            //{
            //    MessageBox.Show("查询终端确认信息出错 " + this.bookingIntegrate.Err);
            //    return;
            //}
            ArrayList list = this.bookingIntegrate.QuerySchema(tempBookApply.ItemList.ExecOper.Dept.ID, tempBookApply.MedTechBookInfo.BookTime, tempBookApply.MedTechBookInfo.BookTime, tempBookApply.ItemComparison.ID, tempBookApply.Noon.ID);
            //Neusoft.FrameWork.Management.Transaction transaction = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            try
            {
                if (this.neuSpreadBooking_Sheet1.Rows.Count == 0)
                {
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                //transaction.BeginTransaction();
                this.bookingIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                int Result = this.bookingIntegrate.CancelMedTechBookApply(tempBookApply);
                if (Result < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("取消安排失败" + Neusoft.FrameWork.Management.PublicTrans.Err);
                    return;
                }
                else if (Result == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("数据已经改变请刷新数据" + Neusoft.FrameWork.Management.PublicTrans.Err);
                    return;
                }
                if (this.bookingIntegrate.UpdateApplyNum(tempInfo.ArrangeQty - 1, tempInfo) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新预约数目失败");
                    return;
                }
                //初始化树
                InitTree("all", this.dateTimeBegin, this.dateTimeEnd, tempBookApply.ItemList.Patient.ID, "1");

                Neusoft.HISFC.Models.Terminal.MedTechItemTemp info = (Neusoft.HISFC.Models.Terminal.MedTechItemTemp)list[0];
                info.NoonCode = this.noonListHelper.GetID(info.NoonCode);
                bool IsSpecalPatient = false;
                int i = 1;
                IsSpecalPatient = this.IsSpecalPatient(tempBookApply, ref i);
                if (i == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return;
                }
                if (IsSpecalPatient)
                {
                    info.MedTechItem.Item.SpecialPrice = info.MedTechItem.Item.SpecialPrice - 1;
                }
                else
                {
                    info.MedTechItem.Item.ChildPrice = info.MedTechItem.Item.ChildPrice - 1;
                }
                info.Dept.ID = this.dragMedTechBookApply.ItemList.ExecOper.Dept.ID;
                if (this.bookingIntegrate.UpdateItemBookingNumber(info) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更改预约数失败" + this.bookingIntegrate.Err);
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.InitTree("all", this.dateTimeBegin, this.dateTimeEnd, tempBookApply.ItemList.Patient.PID.CardNO, "1");
                this.Search();
                MessageBox.Show("取消安排成功");
                this.neuSpreadArrange_2.RowCount = 0;
                this.neuSpreadArrange_3.RowCount = 0;
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

		#region 事件
		/// <summary>
		/// 树节点选择事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void tvList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Level != 1)
			{
				return;
			}
			
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索信息...");
			Application.DoEvents();

			try
			{
                this.dragMedTechBookApply   = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)e.Node.Tag;
				System.Data.DataSet ds = new System.Data.DataSet();
				//查询指定时间内的预约扩展信息
                this.bookingIntegrate.QuerySchema(dragMedTechBookApply.ItemList.ExecOper.Dept.ID, this.neuDateTimePicker1.Value, this.neuDateTimePicker2.Value, "all", ref ds);
				if (ds == null)
				{
					MessageBox.Show("获取项目扩展信息出错");
					return;
				}
				if (ds.Tables.Count == 0)
				{
					return;
				}
				this.neuSpreadArrange_1.DataSource = ds;

				this.SetFarPoint();

                Neusoft.HISFC.Models.Fee.Item.Undrug undrug = feeMgr.GetItem(dragMedTechBookApply.ItemList.Item.ID);
				if (undrug != null && undrug.Memo != null && undrug.Memo != "")
				{
                    this.neuRichTextBoxPatientNotice.Text = undrug.Memo;
				}
			}
			catch(Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
			finally
			{
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
			}
		}

		/// <summary>
		/// 查询事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="neuObject"></param>
		/// <returns></returns>
		protected override int OnQuery(object sender, object neuObject)
		{
			this.Search();
			return base.OnQuery(sender, neuObject);
		}

		/// <summary>
		/// 保存安排
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="neuObject"></param>
		/// <returns></returns>
		protected override int OnSave(object sender, object neuObject)
		{
			this.Arrange(this.neuSpreadArrange_1.ActiveRowIndex);
			return base.OnSave(sender, neuObject);
		}

		/// <summary>
		/// 选择项目事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void tvList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (e.Item == null)
			{
				return;
			}
			if (e.Button == MouseButtons.Left)
			{
				if ((e.Item as TreeNode).Tag == null)
				{
					return;
				}
				this.dragMedTechBookApply = new MedTechBookApply();

				this.dragMedTechBookApply = (Neusoft.HISFC.Models.Terminal.MedTechBookApply)(e.Item as TreeNode).Tag;

				DragDropEffects dropEffect = this.ucChooseList1.tvList.DoDragDrop("dragObj", DragDropEffects.Copy | DragDropEffects.Move);
			}
		}

		/// <summary>
		/// UC大小改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucMedTechBooking_Resize(object sender, EventArgs e)
		{
			// 调整患者注意事项和操作员注意事项的宽度，使宽度相同
			//this.neuPanelRightBottomLeft.Width = this.neuPanelRightBottom.Width / 2;
            //this.groupBox2.Width = this.groupBox3.Width;
		}

		/// <summary>
		/// 住院号回车事件 
		/// </summary>
		private void ucQueryInpatientNo_myEvent()
		{
			if (ucQueryInpatientNo.InpatientNo == null || ucQueryInpatientNo.InpatientNo == "")
			{
				MessageBox.Show("没有查到该病人的住院信息");
				return;
			}
            dateTimeBegin = System.DateTime.Now.AddDays(-beforeDays);
            dateTimeEnd = System.DateTime.Now.AddDays(afterDays);
			//初始化树
			InitTree("all", this.dateTimeBegin, this.dateTimeEnd, ucQueryInpatientNo.InpatientNo, "1");
		}

		/// <summary>
		/// 门诊号回车事件 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTextBoxCardNO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
                dateTimeBegin = System.DateTime.Now.AddDays(-beforeDays);
                dateTimeEnd = System.DateTime.Now.AddDays(afterDays);
				//查询 
				this.neuTextBoxCardNO.Text = this.neuTextBoxCardNO.Text.PadLeft(10, '0');

				//初始化树
				InitTree("all", this.dateTimeBegin, this.dateTimeEnd, this.neuTextBoxCardNO.Text, "1");
			}
		}

		/// <summary>
		/// 项目树的可视改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucChooseList1_VisibleChanged(object sender, EventArgs e)
		{
			this.neuPanelLeft.Visible = this.ucChooseList1.Visible;
		}

		/// <summary>
		/// 排班信息、已排班病人、病人收费信息表格单击事件 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuSpreadArrange_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
		//    if (this.neuSpreadArrange.ActiveSheet == this.neuSpreadArrange_1)
		//    {
		//        if (this.neuSpreadArrange_1.RowCount == 0)
		//        {
		//            return;
		//        }
		//        // 注意事项
		//        this.neuRichTextBoxPatientNotice.Text = this.neuSpreadArrange_1.Cells[e.Row, (int)ExCols.remark].Text;
		//        Neusoft.HISFC.Models.Base.Const constEntity = (Neusoft.HISFC.Models.Base.Const)this.bookingIntegrate.GetConstant("MEDTECHITEM", this.neuSpreadArrange_1.Cells[e.Row, (int)ExCols.itemCode].Text);

		//        this.neuRichTextBoxOperNotice.Text = constEntity.Memo;
		//    }
		}

		/// <summary>
		/// 排班信息、已排班病人、病人收费信息表格双击事件 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuSpreadArrange_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (this.neuSpreadArrange.ActiveSheet == this.neuSpreadArrange_1)
			{
				if (this.neuSpreadArrange_1.Rows.Count == 0)
				{
                    neuSpreadArrange_2.Rows.Count = 0;
                    neuSpreadArrange_3.Rows.Count = 0;
					return;
				}
				// 预约时间
				System.DateTime d1 = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.neuSpreadArrange_1.Cells[this.neuSpreadArrange_1.ActiveRowIndex, (int)ExCols.bookDate].Text);
				string itemCompaison = neuSpreadArrange_1.Cells[this.neuSpreadArrange_1.ActiveRowIndex, (int)ExCols.itemCode].Text;
				string noonID = noonListHelper.GetID(neuSpreadArrange_1.Cells[this.neuSpreadArrange_1.ActiveRowIndex, (int)ExCols.noonCode].Text);
				ArrayList list = null;
                //if (this.Tag != null && this.Tag.ToString() != "")
                //{
                list = this.bookingIntegrate.QueryMedTechApplyDetailList(neuSpreadArrange_1.Cells[this.neuSpreadArrange_1.ActiveRowIndex, (int)ExCols.deptCode].Text, noonID,itemCompaison, d1, d1);
                //}
                //else
                //{
                //    list = this.bookingIntegrate.QueryMedTechApplyDetailList("all", itemCompaison, noonID, d1, d1);
                //}
				AddPatientArrangeList(list);
			}
			else if (this.neuSpreadArrange.ActiveSheet == this.neuSpreadArrange_2)
			{
				AddFeeItemList();
			}
		}

		/// <summary>
		/// 排班信息拖拽进入事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuSpreadArrange_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		/// <summary>
		/// 排班信息拖拽事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuSpreadArrange_DragDrop(object sender, DragEventArgs e)
		{
			if (this.dragMedTechBookApply == null || this.dragMedTechBookApply.ItemList.ID == "")
			{
				return;
			}

			Point point = this.neuSpreadArrange.PointToClient(new Point(e.X, e.Y));
			FarPoint.Win.Spread.Model.CellRange range = this.neuSpreadArrange.GetCellFromPixel(0, 0, point.X, point.Y);
			if (range.ColumnCount == -1 && range.RowCount == -1)
			{
				return;
			}
			this.Arrange(range.Row);
		}

		/// <summary>
		/// 删除医技预约事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuSpreadBooking_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			this.Delete();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.F12)
			{
				// 切换到门诊病历号
				this.neuTextBoxCardNO.Focus();
				this.neuTextBoxCardNO.SelectAll();
			}
			else if (keyData == Keys.F11)
			{
				// 切换到住院号
				this.ucQueryInpatientNo.Focus();
			}
			return base.ProcessDialogKey(keyData);
		}

		/// <summary>
		/// 门诊病历号获得焦点事件 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTextBoxCardNO_Enter(object sender, EventArgs e)
		{
			this.neuTextBoxCardNO.SelectAll();
		}

		/// <summary>
		/// 住院号获得焦点事件 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucQueryInpatientNo_Enter(object sender, EventArgs e)
		{
			this.ucQueryInpatientNo.TextBox.SelectAll();
		}

		#endregion

        #region 取消预约
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Delete();
        }
        #endregion 
    
        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get { return new Type[] { typeof(IBookingPrint) }; }
        }

        #endregion
    }
}
