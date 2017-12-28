using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizProcess.Integrate.Terminal;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Terminal;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	/// <summary>
	/// ucConfirmRecord <br></br>
	/// [功能描述: 执行情况查询]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-03-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class ucConfirmRecord : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucConfirmRecord()
		{
			InitializeComponent();
		}

		#region 变量
		
		/// <summary>
		/// 是否是查询窗口

		/// </summary>
		bool isQueryForm = true;
		
		/// <summary>
		/// 业务明细
		/// </summary>
		public Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail confirmDetail = new TerminalConfirmDetail();
        Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking confirmMgr = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking();
		
		/// <summary>
		/// 业务明细数组
		/// </summary>
		ArrayList confirmDetailList = new ArrayList();
		
		/// <summary>
		/// 申请单流水号
		/// </summary>
		public string applySequence = "";
		
		/// <summary>
		/// 业务明细
		/// </summary>
		public string detailSequence = "";
		
		/// <summary>
		/// 申请单实体

		/// </summary>
		public Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply = new TerminalApply();
		
		/// <summary>
		/// 患者卡号

		/// </summary>
		public string cardNO = "";
		
		/// <summary>
		/// 行号
		/// </summary>
		int row = 0;
		
		/// <summary>
		/// 申请单列枚举
		/// </summary>
		enum ApplyField
		{
			/// <summary>
			/// 状态0
			/// </summary>
			Status = 0,
			/// <summary>
			/// 项目名称1
			/// </summary>
			ItemName = 1,
			/// <summary>
			/// 开立数量2
			/// </summary>
			Qty = 2,
			/// <summary>
			/// 剩余数量3
			/// </summary>
			FreeQty = 3,
			/// <summary>
			/// 开立医生4
			/// </summary>
			Doctor = 4,
			/// <summary>
			/// 开立科室5
			/// </summary>
			Department = 5
		}
		
		/// <summary>
		/// 业务明细列枚举

		/// </summary>
		enum DetailField
		{
			/// <summary>
			/// 状态0
			/// </summary>
			Status = 0,
			/// <summary>
			/// 执行科室
			/// </summary>
			ConfirmDepartment = 1,
			/// <summary>
			/// 确认时间2
			/// </summary>
			ConfirmTime = 2,
			/// <summary>
			/// 确认人

			/// </summary>
			ConfirmEmployee = 3,
			/// <summary>
			/// 确认数量
			/// </summary>
			ConfirmQty = 4,
			/// <summary>
			/// 剩余数量
			/// </summary>
			FreeQty = 5
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
            //toolBarService.AddToolButton("查询", "查询", Neusoft.FrameWork.WinForms.Classes.EnumImageList.A查找, true, false, null);
            toolBarService.AddToolButton("取消", "取消", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);  
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
                //case "查询":
                //    TerminalQuery();
                //    break;
                case "取消":
                    CancelConfirm();
                    break; 
                default:
                    break;
            }
        }
        #endregion

  #endregion

		#region 函数
		
		/// <summary>
		/// 根据申请单流水号获取业务明细,初始化窗口

		/// </summary>
		/// <returns>1－成功；－1－失败</returns>
		private int InitByApplySequence()
		{
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 业务明细数组
			ArrayList detailList = new ArrayList();
			// 申请单数组

			ArrayList applyList = new ArrayList();
			//
			// 根据申请单获取业务明细

			//
			result = confirmIntegrate.QueryDetailsByApply(this.terminalApply, ref detailList);
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
				MessageBox.Show(confirmIntegrate.Err);
				return -1;
			}
			//
			// 设置业务明细
			//
			this.DisplayDetail(detailList);
			//
			// 设置申请单

			//
			applyList.Add(this.terminalApply);
			this.DisplayApply(applyList);
			
			return 1;
		}

		/// <summary>
		/// 显示申请单

		/// [参数: ArrayList alApply - 申请单数组]
		/// </summary>
		/// <param name="alApply">申请单数组</param>
		private void DisplayApply(ArrayList alApply)
		{
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 员工实体
			Neusoft.HISFC.Models.Base.Employee employee = new Employee();
			// 科室实体
			Neusoft.HISFC.Models.Base.Department department = new Neusoft.HISFC.Models.Base.Department();

			this.neuSpreadItem_SheetItem.RowCount = 0;
			
			foreach (Neusoft.HISFC.Models.Terminal.TerminalApply tempTerminalApply in alApply)
			{
				// 增加一行

				this.neuSpreadItem_SheetItem.AddRows(this.neuSpreadItem_SheetItem.RowCount, 1);
				// 当前行号
				this.row = this.neuSpreadItem_SheetItem.RowCount - 1;
				// 状态

				if (tempTerminalApply.ItemStatus.Equals("1"))
				{ 
					this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.Status].Text = "未执行";
				}
				else
				{
                    if (tempTerminalApply.AlreadyConfirmCount == 0)
                    {
                        this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.Status].Text = "未执行";
                    }
                    else
                    {
                        this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.Status].Text = "已执行";
                    }
				}
				// 项目名称
				this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.ItemName].Text = tempTerminalApply.Item.Item.Name;
				// 开立数量

				this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.Qty].Text = tempTerminalApply.Item.Item.Qty.ToString();
				// 剩余数量
				this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.FreeQty].Text = (tempTerminalApply.Item.Item.Qty - tempTerminalApply.AlreadyConfirmCount).ToString();
				// 开立医生

				confirmIntegrate.GetEmployee(ref employee, tempTerminalApply.Item.Order.Doctor.ID);
				this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.Doctor].Text = employee.Name;
				// 开立科室

				confirmIntegrate.GetDept(ref department, tempTerminalApply.Item.ExecOper.Dept.ID);
				this.neuSpreadItem_SheetItem.Cells[this.row, (int)ApplyField.Department].Text = department.Name;
				// 保存Tag为实体

				this.neuSpreadItem_SheetItem.Rows[this.row].Tag = tempTerminalApply;
				// 患者姓名

				this.neuTextBoxName.Text = tempTerminalApply.Patient.Name; 
			}
            if (alApply.Count > 0)
            {
                Neusoft.HISFC.Models.Terminal.TerminalApply tempTerminalApply = (Neusoft.HISFC.Models.Terminal.TerminalApply)alApply[0];
                if (tempTerminalApply.PatientType == "1" || tempTerminalApply.PatientType == "4" || tempTerminalApply.PatientType == "5")
                {
                    //门诊 或体检患者

                    Neusoft.HISFC.Models.Registration.Register obj = new Neusoft.HISFC.Models.Registration.Register();
                    obj = confirmMgr.GetByClinic(tempTerminalApply.Patient.PID.ID);
                    if (obj == null)
                    {
                        MessageBox.Show("获取患者基本信息失败");
                        return;
                    }
                    tempTerminalApply.Patient.Sex.ID = obj.Sex.ID;
                }
                else if (tempTerminalApply.PatientType == "2")
                {//住院
                }
                else if (tempTerminalApply.PatientType == "3")
                {
                    //急诊
                }
                if (tempTerminalApply.Patient.Sex.ID == null)
                {
                    //this.neuTextBoxSex.Text = "未知";
                }
                else if (tempTerminalApply.Patient.Sex.ID.Equals("M"))
                {
                    this.neuTextBoxSex.Text = "男";
                }
                else if (tempTerminalApply.Patient.Sex.ID.Equals("F"))
                {
                    this.neuTextBoxSex.Text = "女";
                }
                else
                {
                    this.neuTextBoxSex.Text = "未知";
                }
            }
		}

		/// <summary>
		/// 显示业务明细
		/// [参数: ArrayList alDetail - 业务明细数组]
		/// </summary>
		/// <param name="terminalConfirmDetailList">业务明细数组</param>
		private void DisplayDetail(ArrayList terminalConfirmDetailList)
		{
			// 员工实体
			Neusoft.HISFC.Models.Base.Employee employee = new Employee();
			// 科室实体
			Neusoft.HISFC.Models.Base.Department department = new Neusoft.HISFC.Models.Base.Department();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();

			// 清空
			this.neuSpreadItemDetail_SheetItemDetail.RowCount = 0;
			foreach (Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail tempConfirmDetail in terminalConfirmDetailList)
			{
				// 增加一行新记录
				this.neuSpreadItemDetail_SheetItemDetail.AddRows(this.neuSpreadItemDetail_SheetItemDetail.RowCount, 1);
				// 取增加的行号
				this.row = this.neuSpreadItemDetail_SheetItemDetail.RowCount - 1;
				// 状态

				if (tempConfirmDetail.Status.ID.Equals("0"))
				{
					this.neuSpreadItemDetail_SheetItemDetail.Cells[this.row, (int)DetailField.Status].Text = "正常";
				}
				else
				{
					this.neuSpreadItemDetail_SheetItemDetail.Cells[this.row, (int)DetailField.Status].Text = "取消";
				}
				// 执行科室
				confirmIntegrate.GetDept(ref department, tempConfirmDetail.Apply.Item.ConfirmOper.Dept.ID);
				this.neuSpreadItemDetail_SheetItemDetail.Cells[this.row, (int)DetailField.ConfirmDepartment].Text = department.Name;
				// 执行时间
				this.neuSpreadItemDetail_SheetItemDetail.Cells[this.row, (int)DetailField.ConfirmTime].Text = tempConfirmDetail.Apply.ConfirmOperEnvironment.OperTime.ToString();
				// 确认人

				confirmIntegrate.GetEmployee(ref employee, tempConfirmDetail.Apply.ConfirmOperEnvironment.ID);
				this.neuSpreadItemDetail_SheetItemDetail.Cells[this.row, (int)DetailField.ConfirmEmployee].Text = employee.Name;
                this.neuSpreadItemDetail_SheetItemDetail.Columns[(int)DetailField.FreeQty].Visible = false; // 隐藏这列,如果发生多次确认后退费,次数不准,之所以保留是为了便与根据旧发票号查询当时的情况

				// 确认数量
				this.neuSpreadItemDetail_SheetItemDetail.Cells[this.row, (int)DetailField.ConfirmQty].Text = tempConfirmDetail.Apply.Item.ConfirmedQty.ToString();
				// 剩余数量
				this.neuSpreadItemDetail_SheetItemDetail.Cells[this.row, (int)DetailField.FreeQty].Text = tempConfirmDetail.FreeCount.ToString();

				// 保存Tag为实体

				this.neuSpreadItemDetail_SheetItemDetail.Rows[this.row].Tag = tempConfirmDetail;
			}
		}
		
		/// <summary>
		/// 执行查询
		/// </summary>
		protected void TerminalQuery()
		{
			// 申请单数组

			ArrayList alApply = new ArrayList();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 如果病历号为空,那么返回
			if (this.neuTextBoxCardNO.Text.Equals("") || this.neuTextBoxCardNO.Text == null)
			{
				return;
			}
			// 填充病历号

			this.neuTextBoxCardNO.Text = this.neuTextBoxCardNO.Text.PadLeft(10, '0');
			//
			// 根据病历号获取申请单明细
			//
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在获取项目信息...");

            Application.DoEvents();
			// 获取申请单明细

			result = confirmIntegrate.QueryApplyListByCardNO(this.neuTextBoxCardNO.Text, ref alApply);
			if (Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure == result)
			{
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
				MessageBox.Show("获取记录失败!" + "\n" + confirmIntegrate.Err);
				return;
			}
			//
			// 显示申请单明细

			//
            if (alApply.Count == 0)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("该患者不存在终端确认信息或病例号录入错误!" + "\n" + confirmIntegrate.Err);
                return;
            }
			this.DisplayApply(alApply);
			// 隐藏等待信息
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		#endregion

		#region 事件

		/// <summary>
		/// 病历号获得焦点事件

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTextBoxCardNO_Enter(object sender, EventArgs e)
		{
			this.neuTextBoxCardNO.SelectAll();
		}

		/// <summary>
		/// 病历号回车事件

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuTextBoxCardNO_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.TerminalQuery();
			}
		}

		/// <summary>
		/// 收费项目双击选择事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuSpreadItem_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			//
			// 如果没有记录,那么返回
			//
			if (this.neuSpreadItem_SheetItem.RowCount == 0)
			{
				return;
			}
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm ();
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();

			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在获取项目信息...");
			//
			// 获取当前选择的记录

			//
			this.terminalApply = new TerminalApply();
			this.terminalApply = (Neusoft.HISFC.Models.Terminal.TerminalApply)this.neuSpreadItem_SheetItem.Rows[this.neuSpreadItem_SheetItem.ActiveRowIndex].Tag;
			//
			// 根据申请单号获取业务明细
			//
			confirmDetailList = new ArrayList();
			result = confirmIntegrate.QueryDetailsByApply(terminalApply, ref confirmDetailList);
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
				MessageBox.Show("获取业务明细失败!" + "\n" + confirmIntegrate.Err);
				return;
			}
			//
			// 设置业务明细
			//
			this.DisplayDetail(confirmDetailList);
			//
			// 显示项目名称
			//
			this.neuLabelConfirmTitle.Text = "开立的收费项目对应的执行明细 —— " + terminalApply.Item.Name;

			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		/// <summary>
		/// 确定按钮单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuButtonOK_Click(object sender, EventArgs e)
		{

			// 如果是查询窗口,那么只执行查询

			if (this.isQueryForm)
			{
				this.Hide();
			}
			else
			{
				// 如果是取消终端确认

				//this.DialogResult = DialogResult.OK;
				this.Hide();
			}
		}

		/// <summary>
		/// 查询按钮单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="neuObject"></param>
		/// <returns></returns>
		protected override int OnQuery(object sender, object neuObject)
		{
			this.TerminalQuery();

			return 1;
		}

        ///// <summary>
        ///// 初始化事件

        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="neuObject"></param>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        //{
        //    if (this.DesignMode)
        //    {
        //        return null;
        //    }
        //    if (this.isQueryForm)
        //    {
        //        this.neuButtonOK.Visible = false;
        //    }
        //    else
        //    {
        //        this.neuButtonOK.Visible = true;
        //    }

        //    return null;
        //}
		
		

		#endregion

        #region 取消终端确认
        private void CancelConfirm()
        {
            if (this.neuSpreadItemDetail_SheetItemDetail.RowCount == 0)
            {
                return;
            }
            if (MessageBox.Show("是否取消该次确认", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            
            if (this.neuSpreadItemDetail_SheetItemDetail.Rows[this.neuSpreadItemDetail_SheetItemDetail.ActiveRowIndex].Tag == null)
            {
                MessageBox.Show("获取终端确认明细出错");
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm terminalConfim = new Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm();
            Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager examiMgr = new Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager();
            Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            Neusoft.HISFC.BizProcess.Integrate.RADT serviceInpatient = new Neusoft.HISFC.BizProcess.Integrate.RADT();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(terminalConfim.Connection);            
            //t.BeginTransaction();
            //terminalConfim.SetTrans(t.Trans);
            //examiMgr.SetTrans(t.Trans);
            //feeMgr.SetTrans(t.Trans);
            //serviceInpatient.SetTrans(t.Trans);

            Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail = (Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail)this.neuSpreadItemDetail_SheetItemDetail.Rows[this.neuSpreadItemDetail_SheetItemDetail.ActiveRowIndex].Tag;
            Neusoft.HISFC.Models.Terminal.TerminalApply apply = terminalConfim.GetItemListBySequence(detail.Apply.Order.ID,detail.Apply.ID);

            Neusoft.HISFC.Models.Base.Employee employee = (Neusoft.HISFC.Models.Base.Employee)terminalConfim.Operator;
            if (detail.OperInfo.ID != terminalConfim.Operator.ID)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("只能取消自己做过的终端确认");
                return;
            }
            if (detail == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("获取终端确认明细出错");
                return;
            }
            int BackQty = Neusoft.FrameWork.Function.NConvert.ToInt32(detail.Apply.Item.ConfirmedQty);
            if (terminalConfim.UpdateConfirmDetail(detail.Sequence, "1") <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("作废终端确认明细表出错" + terminalConfim.Err);
                return;
            }
            if (terminalConfim.UpdateTerminalConfirmByMoOrder(detail.Apply.Order.ID, BackQty) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新终端确认主表失败" + terminalConfim.Err);
                return;
            }
            string confirmFlag = "1";
            if (apply.AlreadyConfirmCount - BackQty == 0)
            {
                confirmFlag = "0";
            }
            if (apply.PatientType != "5"&&(apply.PatientType == "1" ||apply.PatientType == "4"))
            {
                if (terminalConfim.UpdateFeeConfirmQty(detail.Apply.Order.ID, confirmFlag, -BackQty) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新费用表失败" + terminalConfim.Err);
                    return;
                }
                #region 扣门诊账户

                if (detail.Apply.SpecalFlag == "1")
                {   //退费用到门诊账户 ,目前门诊账户项目不能分开多次确认
                    decimal totCost = decimal.Round(apply.Item.Item.Price * apply.Item.Item.Qty,2);
                    if (feeMgr.AccountCancelPay(apply.Patient, totCost, "终端退费", employee.Dept.ID, "") < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("退门诊账户失败 :" + feeMgr.Err);
                        return;
                    }
                    #region 更新费用表

                    if (feeMgr.UpdateAccountByMoOrderAndItemCode(apply.Item.Item.ID, apply.Order.ID, false) <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("门诊收费表扣费标志失败 :" +feeMgr.Err);
                        return;
                    }
                    #endregion 

                    #region 更新执行标志到划价状态

                    if (terminalConfim.UpdateConfirmSendFlag(detail.Apply.Order.ID, detail.Apply.Item.Item.ID, "0") <= 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("更新终端确认表执行标志失败 :" + terminalConfim.Err);
                        return;
                    }
                    #endregion 
                }
                #endregion 

            }
            if (apply.PatientType == "4" || apply.PatientType == "5")
            {
                //体检中心的可退数量 
                int NoBackQty = Neusoft.FrameWork.Function.NConvert.ToInt32(apply.Item.Item.Qty - apply.Item.ConfirmedQty + BackQty);
                if (examiMgr.UpdateConfirmInfo(detail.Apply.Order.ID, confirmFlag, NoBackQty) <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新体检表失败:" + examiMgr.Err);
                    return;
                }
            }
            if (apply.PatientType == "2" && detail.Apply.SpecalFlag == "2") //回退住院费用
            {
                #region 构建住院患者实体

                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = serviceInpatient.QueryPatientInfoByInpatientNO(apply.Patient.PID.ID);
                if (patientInfo == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("获取住院患者信息失败:" + serviceInpatient.Err);
                    return ;
                }
                #endregion

                #region 构建住院费用实体
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply = apply.Clone();
                feeItemList.Item = terminalApply.Item.Item.Clone();
                feeItemList.Item.PriceUnit = terminalApply.Item.Item.PriceUnit;//计价单位
                if (terminalApply.Item.Order.DoctorDept.ID == null || terminalApply.Item.Order.DoctorDept.ID == "")
                {
                    feeItemList.RecipeOper.Dept = employee.Dept;
                }
                else
                {
                    feeItemList.RecipeOper.Dept = terminalApply.Item.Order.DoctorDept;
                }
                if (terminalApply.Item.Order.Doctor.ID == null || terminalApply.Item.Order.Doctor.ID == "")
                {
                    feeItemList.RecipeOper.ID = employee.ID;
                    feeItemList.RecipeOper.Name = employee.Name;
                    feeItemList.ChargeOper.ID = employee.ID;
                    feeItemList.ChargeOper.Name = employee.Name;
                    feeItemList.ChargeOper.Dept = employee.Dept;
                }
                else
                {
                    feeItemList.RecipeOper.ID = terminalApply.Item.Order.Doctor.ID;
                    feeItemList.RecipeOper.Name = terminalApply.Item.Order.Doctor.Name;
                    feeItemList.ChargeOper.ID = terminalApply.Item.Order.Doctor.ID;
                    feeItemList.ChargeOper.Name = terminalApply.Item.Order.Doctor.Name;
                } 
                feeItemList.ExecOper.ID = employee.ID;
                feeItemList.ExecOper.Name = employee.Name;
                feeItemList.ExecOper.Dept = employee.Dept;
                feeItemList.StockOper.Dept = employee.Dept;//药品的扣库存的科室

                feeItemList.Item.PackQty = terminalApply.Item.Item.PackQty;
                feeItemList.Item.Qty = terminalApply.Item.Item.Price;
                feeItemList.Item.Qty = terminalApply.Item.Item.Qty;

                if (feeItemList.Item.PackQty == 0)
                {
                    feeItemList.Item.PackQty = 1;
                }
                feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber((feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty), 2);
                feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
                feeItemList.IsBaby = patientInfo.IsBaby;
                feeItemList.IsEmergency = false;
                feeItemList.Order = new Neusoft.HISFC.Models.Order.Inpatient.Order();
                feeItemList.ExecOrder.ID = terminalApply.Item.Order.ID;
                feeItemList.NoBackQty = 0;
                feeItemList.FTRate.OwnRate = 1;
                feeItemList.BalanceState = "0";
                feeItemList.FeeOper.ID = employee.ID;
                feeItemList.FeeOper.Name = employee.Name;
                feeItemList.FeeOper.Dept = employee.Dept; 
                feeItemList.TransType = TransTypes.Positive;
                #endregion

                if (feeMgr.QuitItem(patientInfo, feeItemList) <= 0)
                {
                    MessageBox.Show("退住院费用失败" + feeMgr.Err);
                    return ;
                }
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.neuSpreadItemDetail_SheetItemDetail.Rows.Remove(this.neuSpreadItemDetail_SheetItemDetail.ActiveRowIndex, 1);
            #region  修改界面上的数量
            for (int i = 0; i < this.neuSpreadItem_SheetItem.RowCount; i++)
            {
                Neusoft.HISFC.Models.Terminal.TerminalApply obj = (Neusoft.HISFC.Models.Terminal.TerminalApply)this.neuSpreadItem_SheetItem.Rows[i].Tag;
                if (obj.Order.ID == detail.Apply.Order.ID)
                {
                    int freeQty = Neusoft.FrameWork.Function.NConvert.ToInt32(detail.Apply.Item.ConfirmedQty) + Neusoft.FrameWork.Function.NConvert.ToInt32(neuSpreadItem_SheetItem.Cells[i, (int)ApplyField.FreeQty].Text);
                    this.neuSpreadItem_SheetItem.Cells[i, (int)ApplyField.FreeQty].Text = freeQty.ToString();
                    break;
                }
            }
            #endregion
            MessageBox.Show("取消成功");
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelConfirm();
        }
        #endregion

    }
}
