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
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Registration;
using Neusoft.HISFC.Models.Terminal;
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Components.Terminal.Confirm;
namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	/// <summary>
	/// ucTerminalConfirm <br></br>
	/// [功能描述: 终端确认UC]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-03-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    public partial class ucTerminalConfirm : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucTerminalConfirm()
		{
			InitializeComponent();
		}

		#region 变量

		/// <summary>
		/// 窗口类型：1-门诊/2-住院
		/// </summary>
		string windowType = "1";

		/// <summary>
		/// 患者实体

		/// </summary>
		Neusoft.HISFC.Models.Registration.Register register = new Register();

		/// <summary>
		/// 工具栏服务

		/// </summary>
		Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new ToolBarService();

		/// <summary>
		/// 终端确认事件
		/// </summary>
		protected event System.EventHandler ConfirmEvent;

		/// <summary>
		/// 选择全部事件
		/// </summary>
		protected event System.EventHandler SelectAllEvent;

		/// <summary>
		/// 取消选择全部事件
		/// </summary>
		protected event System.EventHandler UnselectAllEvent;

		/// <summary>
		/// 增加项目事件
		/// </summary>
		protected event System.EventHandler AddItemEvent;

		/// <summary>
		/// 删除增加项目事件
		/// </summary>
		protected event System.EventHandler DeleteItemEvent;
        private bool InpatientFeeConfirm = false;// 如果执行时扣费,护士站不调用收费方法,由终端调用.退费时,终端控制调用退费方法.
		/// <summary>
		/// 刷新患者事件

		/// </summary>
		protected event System.EventHandler RefreshEvent;
        Neusoft.HISFC.BizProcess.Integrate.Manager conl = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager examMgr = new Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager();

        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        private bool IsConfirm = true;

        #region {172414C5-0702-4304-BF68-AFA399A43CC3} 终端读卡操作 by guanyx
        private event System.EventHandler ReadCardEvent;
        #endregion

        /// <summary>
        /// 账户是否终端扣费
        /// </summary>
        //private bool isAccountTerimalFee = false;

        #region 医技终端增加门诊病历内容查询功能，供医技人员参考用 {967CA656-AB9D-4841-8BFE-9A2EC7E8F886}
        /// <summary>
        /// 门诊病历接口显示
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Terminal.IOutpatientCase IOutpatientCaseInstance = null;

        protected event System.EventHandler patientCaseEventHandler;
        #endregion

        #endregion

        #region 属性

        private bool IsCanConfirm = true; //是否允许确认其他科室的项目

		/// <summary>
		/// 窗口类型：1-门诊/2-住院
		/// </summary>
		[Category("HIS系统设置"), Description("设置功能的使用对象：1-门诊；2－住院；9－全部")]
		public string WindowType
		{
			get
			{
				return this.windowType;
			}
			set
			{
				this.windowType = value;
				this.Tag = this.windowType;

				//this.InitUC();
			}
		}

		/// <summary>
		/// 患者信息

		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Neusoft.HISFC.Models.Registration.Register Register
		{
			get
			{
				return this.register;
			}
			set
			{
				this.register = value;
			}
		}
        /// <summary>
        /// 设置终端确认项目类别
        /// </summary>
        private Neusoft.HISFC.Components.Common.Controls.EnumShowItemType enumItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.All;
        [Category("HIS系统设置"), Description("设置终端确认项目类别")]
        public Neusoft.HISFC.Components.Common.Controls.EnumShowItemType EnumItemType
        {
            get
            {
                return this.enumItemType;
            }
            set
            {
                this.enumItemType = value;
            }
        }


		#endregion

		#region 函数

		/// <summary>
		/// 初始化UC
		/// </summary>
		public void InitUC()
		{
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待，正在进行初始化...");
			Application.DoEvents();
			// 设置窗口类型：1-门诊用；2-住院用

			this.ucPatientInformation.WindowType = this.windowType;
			this.ucPatientTree.WindowType = this.windowType;
			this.ucItemApply.WindowType = this.windowType;

			// 初始化各子UC
			this.ucPatientTree.isLoad = true;
			this.ucPatientTree.Init();
            this.ucItemApply.EnumItemType = this.EnumItemType;
			this.ucItemApply.Init();

			// 患者树事件代理
			this.ucPatientTree.ClickTreeNode += new ucPatientTree.delegatePatientTree(ucPatientTree_ClickTreeNode);
			this.ucPatientTree.TreeNodeKeyDown += new ucPatientTree.delegateKeyDown(ucPatientTree_TreeNodeKeyDown);

			// 单击明细，根据明细检索患者信息

			this.ucItemApply.ClickApply += new ucItemApply.MyDelegate(ucItemApply_ClickApply);

			// 在明细中上下移动箭头，显示不同状态的患者信息

			this.ucItemApply.KeyUpAndDown += new ucItemApply.MySecondDelegate(ucItemApply_KeyUpAndDown);


            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            InpatientFeeConfirm = controlParamIntegrate.GetControlParam<bool>("A00001", false, true);

            string objIsConfirm = conl.QueryControlerInfo("TJ0072");　//是否需要插确认表

            if (objIsConfirm != null)
            {
                if (!Neusoft.FrameWork.Public.String.StringEqual(objIsConfirm, "1"))
                {
                    IsConfirm = false;
                }
            }
            string objTemp = conl.QueryControlerInfo("TC007");　//是否允许确认其他科室项目
            if (objTemp != null)
            {
                if (!Neusoft.FrameWork.Public.String.StringEqual(objTemp, "1"))
                {
                    IsCanConfirm = false;
                }
            }
            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            //isAccountTerimalFee = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Account_Process, false);


			// 患者检索事件

			this.ucPatientInformation.KeyDownInQureyCode += new ucPatientInformation.MyDelegate(ucPatientInformation_KeyDownInQureyCode);
			this.ucPatientInformation.SelectInpatientNO += new ucPatientInformation.delegateInpatient(ucPatientInformation_SelectInpatientNO);
			
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}
         
		/// <summary>
		/// 保存
		/// </summary>
		public void Save()
		{
			//
			// 变量定义
			//
			// 有效保存记录的个数

			int j = 0;
			// 操作结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 申请单实体

			Neusoft.HISFC.Models.Terminal.TerminalApply apply = new TerminalApply();
            Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            //// 事务对象
            //Neusoft.FrameWork.Management.Transaction transaction = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
			//
			// 校验合法性

			//
			if (this.Validata() != 1) // 校验输入的有效性

			{
				return;
			} 

			// 设置患者实体

			this.Register = this.ucPatientInformation.Register;
			if (this.Register == null) // 如果当前没有选择患者

			{
				MessageBox.Show("没有选择患者", "医技终端确认");
				this.Focus();
				return;
			}
			//
			// 保存确认
			//
			if (MessageBox.Show("是否保存终端确认?", "医技终端确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				this.ucItemApply.Focus();
				return;
			}
			this.Focus();

            #region 门诊账户
            AccountType accountType = AccountType.None; 
            decimal OldTotCost = 0; //其他科室划价
            decimal NewTotCost = 0;//本科室划价

            decimal accountCost = 0;

            //
            if (Register.Memo == "1" || Register.Memo == "4" )
            {
                #region 废弃
                ////门诊,体检患者 才需要判断是否需要扣门诊账户 ,要在事务开始前操作  

                //OldTotCost = ucItemApply.QueryOldList();
                //NewTotCost = ucItemApply.QueryNewList();
                //accountCost = 0;

                //if (OldTotCost > 0 || NewTotCost > 0)
                //{
                //    int IntReturn = feeMgr.GetAccountVacancy(register.PID.CardNO, ref accountCost);

                //    #region  账户不存在或停用
                //    if (IntReturn == -1)
                //    {
                //        if (NewTotCost == 0 && OldTotCost > 0)//有其他科室开立没有收费的项目,本科室没有新开立

                //        {
                //            MessageBox.Show(feeMgr.Err + " ,请缴费后再做终端确认");
                //            return;
                //        }
                //        else if (NewTotCost > 0 && OldTotCost > 0) //既有其他科室开立的没有收费的项目也有本科室新开立的项目
                //        {
                //            MessageBox.Show(feeMgr.Err + ",如果需要增划价项目,请只选中新增加的项目");
                //            return;
                //        }
                //        else if (NewTotCost > 0 && OldTotCost == 0) //只有本科新开立的划价项目,其他科室开立的没有选中
                //        {
                //            if (MessageBox.Show("目前只是划价,只有去收费处收费后才真正计费,是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                //            {
                //                accountType = AccountType.ClinicCharge;
                //                return;
                //            }
                //        }
                //    }
                //    #endregion

                //    #region 账户存在  
                //    if (accountCost < OldTotCost + NewTotCost) //账户金额不够
                //    {
                //        #region 账户金额不够
                //        if (NewTotCost >= 0 && OldTotCost > 0)
                //        {
                //            MessageBox.Show("账户余额不足,请去收费处收费");
                //            return;
                //        }
                //        else if (NewTotCost > 0 && OldTotCost == 0)
                //        {
                //            if (MessageBox.Show("目前只是划价,只有去收费处收费后才真正计费,是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                //            {
                //                accountType = AccountType.ClinicCharge;
                //                return;
                //            }
                //        }
                //        #endregion
                //    } 
                //    else //账户金额够 ,需要扣账户
                //    {
                //        #region 账户金额够 ,需要扣账户
                //        accountType = AccountType.ClinicFee;
                //        #endregion  
                //    }
                //    #endregion
                //} 
                #endregion
                //门诊,体检患者 才需要判断是否需要扣门诊账户 ,要在事务开始前操作  

                OldTotCost = ucItemApply.QueryOldList();
                NewTotCost = ucItemApply.QueryNewList();
                Neusoft.HISFC.Models.Registration.Register regObj = registerIntegrate.GetByClinic(Register.ID);
                if (regObj == null)
                {
                    MessageBox.Show("查询患者信息失败！" + registerIntegrate.Err);
                    return;
                }
                //if (isAccountTerimalFee && regObj.IsAccount)
                //{
                //    accountCost = 0;

                //    if (OldTotCost > 0 || NewTotCost > 0)
                //    {
                //        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                //        int IntReturn = feeMgr.GetAccountVacancy(register.PID.CardNO, ref accountCost);

                //        #region  账户不存在或停用
                //        if (IntReturn == -1)
                //        {
                //            MessageBox.Show("账户不存在或已停用！");
                //            return;

                //        }
                //        #endregion

                //        if (!feeMgr.CheckAccountPassWord(register))
                //        {
                //            return;
                //        }
                //        #region 账户存在
                //        if (accountCost < OldTotCost + NewTotCost) //账户金额不够
                //        {

                //            MessageBox.Show("账户金额不足，请交费后再确认！");
                //            return;
                //        }
                //        else //账户金额够 ,需要扣账户
                //        {
                //            #region 账户金额够 ,需要扣账户
                //            accountType = AccountType.ClinicFee;
                //            #endregion
                //        }
                //        #endregion
                //    }
                //}
            }
            
            #endregion 

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在进行保存...");
			Application.DoEvents();

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            Neusoft.HISFC.Models.Base.Employee var = (Neusoft.HISFC.Models.Base.Employee)dataManager.Operator;

            ArrayList alRecipe = new ArrayList();
			//
			// 开始一个事务 
			//
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //transaction.BeginTransaction();
            confirmIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            feeMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            #region 扣门诊账户

            //if (isAccountTerimalFee && accountType == AccountType.ClinicFee) //需要扣账户
            //{
            //    if (feeMgr.AccountPay(this.register, decimal.Round(OldTotCost + NewTotCost), "", var.Dept.ID, "") < 0)
            //    {
            //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //        MessageBox.Show("扣门诊账户出错 :" + feeMgr.Err);
            //        return;
            //    }
            //}
            #endregion 

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在进行保存...");
            Application.DoEvents();
			//
			// 逐条更新
			//
            try
            {
                for (int i = 0; i < this.ucItemApply.RowCount; i++)
                {
                    if (this.ucItemApply.Register == null)
                    {
                        this.ucItemApply.Register = this.Register;
                    }
                    // 获取每条记录的承载对象


                    //apply = this.ucItemApply.GetRow(i, Neusoft.FrameWork.Management.PublicTrans.Trans);
                    apply = this.ucItemApply.GetRow(i);
                    if (apply == null)
                    {
                        // 如果返回空，那么放弃单前记录，保存下一条记录 
                        continue;
                    }

                    if (ucItemApply.GetItem(i, (int)ucItemApply.DisplayField.ItemStatus) == "划价" && (accountType == AccountType.ClinicCharge || accountType == AccountType.ClinicFee)) //需要扣账户
                    {
                        if (accountType == AccountType.ClinicFee)
                        { 
                            apply.ItemStatus = "2";
                            apply.SpecalFlag = "1";//扣门诊账户

                        }
                        else if (accountType == AccountType.ClinicCharge)
                        {
                            apply.ItemStatus = "0";
                        }
                    }
                    //将药品存入alRecipe准备处方打印 by yuyun 7-17{EA8E11A1-207E-4cb7-B399-31F863886DBB}
                    if (ucItemApply.GetItem(i, (int)ucItemApply.DisplayField.ItemStatus) == "划价"//)
                            && apply.Item.Item.ItemType == HISFC.Models.Base.EnumItemType.Drug)
                    {
                        alRecipe.Add(apply.Item);
                    }

                    //
                    // 保存
                    //
                    if (register.Memo == "2" && InpatientFeeConfirm) //住院处终端收费
                    {
                        apply.SpecalFlag = "2";
                    }
                    if (IsConfirm && register.Memo == "5")
                    {
                        result = confirmIntegrate.Save(apply, this.register,true);
                    }
                    else
                    {
                        result = confirmIntegrate.Save(apply, this.register, false);
                    }
                    if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("第" + (i + 1).ToString() + "行保存失败\n" + confirmIntegrate.Err);
                        return;
                    }
                    // 如果是有效记录，则自动加1
                    j++;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("保存失败!\n" + ex.Message);
            }
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
			// 如果有效记录个数大于0，进行更新操作

			if (j != 0)
			{
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                
                //--------------
				// 清空界面
				this.ucItemApply.Clear();
				this.ucPatientInformation.Clear();
				this.Register = null;
				// 刷新患者树
				if (this.WindowType == "1")
				{
					this.ucPatientTree.LoadOutpatient();
				}
				// 设置焦点
				this.ucPatientInformation.textBoxCode.Focus();
			}
			else
			{
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
			}
		}

		/// <summary>
		/// 保存校验（1：成功/-1失败）

		/// </summary>
		/// <returns>1-成功/-1-失败</returns>
		int Validata()
		{
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在校验数据的合法性...");
			
			if (this.register == null || this.register.ID == "")
			{
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
				return -1;
			}
			// 记录个数不允许为0
			if (this.ucItemApply.RowCount == 0)
			{
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
				return -1;
			}

			// 调用明细UC的校验

			if (this.ucItemApply.DataValidate() == -1)
			{
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
				return -1;
			}

			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
			return 1;
		}

		/// <summary>
		/// 检索后设置焦点
		/// </summary>
		public void SetFocusAfterQuery()
		{
			if (this.ucItemApply.RowCount == 0)
			{
				// 如果没有申请单明细，那么自动增加一空行
				this.ucItemApply.NewRow();

				// 设置焦点到项目名称

				this.ucItemApply.CellFocus(0, 1);
			}
			else
			{
				// 如果存在记录，那么设置焦点到确认数量
				this.ucItemApply.CellFocus(0, 6);
			}
		}

		/// <summary>
		/// 设置Register
		/// </summary>
		/// <param name="argRegister">传入的register</param>
		public void SetAllRegister(Neusoft.HISFC.Models.Registration.Register argRegister)
		{
			this.Register = argRegister;
			this.ucPatientInformation.Register = argRegister;
			this.ucItemApply.Register = argRegister;
		}

		/// <summary>
		/// 获取挂号科室和合同单位

		/// </summary>
		/// <param name="argRegister">返回的挂号实体</param>
		public void SetPactAndRegDept(ref Neusoft.HISFC.Models.Registration.Register argRegister)
		{
			// 业务
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 合同单位实体
			Neusoft.HISFC.Models.Base.PactInfo pact = new PactInfo();
			// 科室实体
			Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

			// 获取合同单位信息
			confirmIntegrate.GetPact(ref pact, argRegister.Pact.ID);
			argRegister.Pact = pact;

			// 获取科室信息
			confirmIntegrate.GetDept(ref dept, argRegister.DoctorInfo.Templet.Dept.ID);
			argRegister.DoctorInfo.Templet.Dept = dept;
		}

		/// <summary>
		/// 根据编号和患者类别检索患者后续处理

		/// </summary>
		/// <param name="result">执行查询的返回值</param>
		/// <param name="confirmIntegrate">终端确认业务层</param>
		/// <param name="queryRegister">返回的患者信息</param>
		/// <param name="boolOther">是否是查询其它科室</param>
		public void ActionAfterByIDAndType(Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result, Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate, ref Neusoft.HISFC.Models.Registration.Register queryRegister, bool boolOther)
		{
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
				// 如果检索失败，那么清空所有UC的患者基本信息

				this.SetAllRegister(null);

				MessageBox.Show("获取患者信息失败!\n" + confirmIntegrate.Err, "医技终端确认");

				// 设置焦点到检索码输入框

				this.ucPatientInformation.textBoxCode.Focus();

				return;
			}
			else
			{
				// 如果检索成功，那么清空现有申请单明细

				this.ucItemApply.Clear();

				// 如果返回空的患者实体，那么返回
				if (queryRegister.PID.CardNO == null)
				{
					this.SetAllRegister(null);
					MessageBox.Show("患者不存在!\n" + confirmIntegrate.Err, "医技终端确认");
					this.ucPatientInformation.textBoxCode.Focus();
					return;
				}

				// 设置患者信息和显示申请单明细

				this.ActionAfterQuery(ref queryRegister, boolOther);
			}
		}

		/// <summary>
		/// 检索到患者后进行的操作

		/// </summary>
		/// <param name="argRegister">返回的患者信息</param>
		/// <param name="boolOther">是否是查询其它科室的患者</param>
		public void ActionAfterQuery(ref Neusoft.HISFC.Models.Registration.Register argRegister, bool boolOther)
		{
			// 临时挂号实体
			Neusoft.HISFC.Models.Registration.Register tempRegister = new Register();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 年龄
			string age = "";
			
			if (argRegister.ID == "")
			{
				argRegister.ID = argRegister.PID.ID;
			}

			// 门诊患者根据就诊号获取挂号信息
			if (argRegister.Memo == "1")
			{
				confirmIntegrate.GetRegisterByClinicCode(ref tempRegister, argRegister.ID);
				// 设置年龄
				if (tempRegister != null)
				{
					argRegister.Birthday = tempRegister.Birthday;
				}
			}
            // 门诊患者根据就诊号获取挂号信息
            else if (argRegister.Memo == "4" || argRegister.Memo == "5")
            {
                Neusoft.HISFC.Models.PhysicalExamination.Register obj = examMgr.GetRegisterByClinicNO(argRegister.ID);
                if (obj != null)
                {
                    argRegister.Sex = obj.Sex;
                    confirmIntegrate.GetAge(ref age, obj.Birthday.Date);
                    argRegister.Age = age;
                    argRegister.Age = argRegister.Age.Substring(0, argRegister.Age.Length - 1); 
                }
                // 设置年龄
                if (tempRegister != null)
                {
                    argRegister.Birthday = tempRegister.Birthday;
                }
            }
			else if (argRegister.Memo == "2")
			{
				// 住院患者根据住院号获取患者基本信息

				Neusoft.HISFC.Models.RADT.PatientInfo inpatient = new PatientInfo();
				if (confirmIntegrate.GetInpatient(argRegister.ID, ref inpatient) == Result.Success)
				{
					if (inpatient != null)
					{
						argRegister.Birthday = inpatient.Birthday;
					}
				}
			}

			if (argRegister.Age == null || argRegister.Age.Equals(""))
			{
				confirmIntegrate.GetAge(ref age, argRegister.Birthday.Date);
				argRegister.Age = age;
				argRegister.Age = argRegister.Age.Substring(0, argRegister.Age.Length - 1);
			}

			//挂号日期
			argRegister.DoctorInfo.SeeDate = tempRegister.DoctorInfo.SeeDate;

			// 获取患者的挂号科室和合同单位

			this.SetPactAndRegDept(ref argRegister);

			// 设置各子UC的患者实体

			this.SetAllRegister(argRegister);

			// 获取患者申请单明细
			this.ucItemApply.GetApplyByRegister(false, true, boolOther);

			// 设置焦点
			this.SetFocusAfterQuery();
		}

		/// <summary>
		/// 是收费项目选择控件不可见

		/// </summary>
		private void MakeItemListDisappear()
		{
			if (this.ucItemApply.ucItemList.Visible)
			{
				this.ucItemApply.ucItemList.Visible = false;
			}
		}
		
		#endregion

		#region 事件

		/// <summary>
		/// 初始化事件

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="neuObject"></param>
		/// <param name="param"></param>
		/// <returns></returns>
		protected override ToolBarService OnInit(object sender, object neuObject, object param)
		{
			if (this.DesignMode)
			{
				return base.OnInit(sender, neuObject, param);
			}
			// 按钮对应事件
			this.ConfirmEvent += new EventHandler(ucTerminalConfirm_ConfirmEvent);
			this.SelectAllEvent += new EventHandler(ucTerminalConfirm_SelectAllEvent);
			this.UnselectAllEvent += new EventHandler(ucTerminalConfirm_UnselectAllEvent);
			this.AddItemEvent += new EventHandler(ucTerminalConfirm_AddItemEvent);
			this.DeleteItemEvent += new EventHandler(ucTerminalConfirm_DeleteItemEvent);
			this.RefreshEvent += new EventHandler(ucTerminalConfirm_RefreshEvent);
			// 显示按钮
			this.toolbarService.AddToolButton("执行保存", "执行终端确认，保存执行信息(F7)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z执行, true, false, this.ConfirmEvent);
			this.toolbarService.AddToolButton("全部选择", "选择全部项目(F5)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, this.SelectAllEvent);
			this.toolbarService.AddToolButton("取消全选", "取消所有项目的选择状态(F6)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, this.UnselectAllEvent);
			this.toolbarService.AddToolButton("新增划价", "新增补收项目的划价信息(F9)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, this.AddItemEvent);
			this.toolbarService.AddToolButton("删除划价", "删除指定的新增加的划价信息(F10)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, this.DeleteItemEvent);
			this.toolbarService.AddToolButton("刷新患者", "刷新患者树信息(F8)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, this.RefreshEvent);
            #region {172414C5-0702-4304-BF68-AFA399A43CC3} 终端读卡操作 by guanyx
            this.ReadCardEvent += new EventHandler(ucTerminalConfirm_ReadCardEvent);
            this.toolbarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z召回, true, false, this.ReadCardEvent);
            #endregion

            #region 医技终端增加门诊病历内容查询功能，供医技人员参考用 {967CA656-AB9D-4841-8BFE-9A2EC7E8F886}
            patientCaseEventHandler += new EventHandler(ucTerminalConfirm_PatientCaseEvent);
            this.toolbarService.AddToolButton("门诊病历", "查看当前患者的门诊病历信息(F11)", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B病历, true, false, patientCaseEventHandler);
            #endregion

            return this.toolbarService;
        }


        #region {172414C5-0702-4304-BF68-AFA399A43CC3} 终端读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
       /// <summary>
       /// 读卡操作
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        void ucTerminalConfirm_ReadCardEvent(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.ucPatientInformation.textBoxCode.Text = cardno;
                    this.ucPatientInformation.textBoxCode_KeyDown(this.ucPatientInformation.textBoxCode, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
        #endregion

        /// <summary>
		/// 刷新患者事件

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucTerminalConfirm_RefreshEvent(object sender, EventArgs e)
		{
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在加载患者信息列表...");
			this.ucPatientTree.LoadOutpatient();
			this.MakeItemListDisappear();
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		/// <summary>
		/// 删除新项目事件

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucTerminalConfirm_DeleteItemEvent(object sender, EventArgs e)
		{
			this.MakeItemListDisappear();
			this.ucItemApply.DeleteNew();
		}

		/// <summary>
		/// 增加新项目事件

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucTerminalConfirm_AddItemEvent(object sender, EventArgs e)
		{
			if (this.Register == null)
			{
				MessageBox.Show("当前没有可用的患者基本信息!", "医技终端确认");
				this.ucPatientInformation.textBoxCode.Focus();
				return;
			}
           
			this.MakeItemListDisappear();
			this.ucItemApply.Register = this.ucPatientInformation.Register;
			this.ucItemApply.NewRow();
		}

		/// <summary>
		/// 取消选择全部事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucTerminalConfirm_UnselectAllEvent(object sender, EventArgs e)
		{
			this.MakeItemListDisappear();
			this.ucItemApply.CancelAll();
		}

		/// <summary>
		/// 选择全部事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucTerminalConfirm_SelectAllEvent(object sender, EventArgs e)
		{
			this.ucItemApply.SelectAll();
			this.MakeItemListDisappear();
		}

		/// <summary>
		/// 执行保存确认事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucTerminalConfirm_ConfirmEvent(object sender, EventArgs e)
		{
			this.Save();
			this.MakeItemListDisappear();
		}

		/// <summary>
		/// 单击树结点设置当前患者

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucPatientTree_ClickTreeNode(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Level != 2)
			{
				return;
			}

            if (e.Node.Parent.Text == "门诊患者")
            {
                ucPatientInformation.labelDisplayType.Text = "门诊号:";
            } 
            else if (e.Node.Parent.Text == "体检患者")
            {
                ucPatientInformation.labelDisplayType.Text = "体检号:";
            }
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在获取项目信息...");

			// 获取单击的树结点的Tag属性,里面承载着患者基本信息

			Neusoft.HISFC.Models.Registration.Register treeNode = (Neusoft.HISFC.Models.Registration.Register)e.Node.Tag;

			// 设置本身患者基本信息

			this.register = treeNode;
			// 设置项目列表的患者基本信息

			this.ucItemApply.Register = treeNode;

			// 获取患者申请单明细
			this.ucItemApply.GetApplyByRegister(true, false, false);

			// 更改显示的号码


            if (ucPatientInformation.labelDisplayType.Text == "体检号:" || ucPatientInformation.labelDisplayType.Text == "门诊号:")
			{
				this.ucPatientInformation.textBoxCode.Text = this.register.PID.CardNO;
			}
			else
			{
				this.ucPatientInformation.textBoxCode.Text = this.register.ID;
			}
            // 设置患者基本信息UC属性

            this.ucPatientInformation.Register = treeNode;
			//切换患者清空

			this.ucItemApply.ClearFp2();
			this.ucItemApply.fpSpread1.Focus();
			//
			// 隐藏等待窗口
			//
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		/// <summary>
		/// 树节点按键事件

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucPatientTree_TreeNodeKeyDown(object sender, KeyEventArgs e)
		{
			TreeNode currentNode = this.ucPatientTree.GetCurrentNode();
			if (currentNode.Level != 2 || e.KeyCode != Keys.Enter)
			{
				return;
			}

			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在获取项目信息...");
			
			Application.DoEvents();

			// 获取单击的树结点的Tag属性,里面承载着患者基本信息

			Neusoft.HISFC.Models.Registration.Register treeNode = (Neusoft.HISFC.Models.Registration.Register)currentNode.Tag;
			// 设置患者基本信息UC属性

			this.ucPatientInformation.Register = treeNode;
			// 设置本身患者基本信息

			this.register = treeNode;
			// 设置项目列表的患者基本信息

			this.ucItemApply.Register = treeNode;

			// 获取患者申请单明细
			this.ucItemApply.GetApplyByRegister(true, false, false);

			// 更改显示的号码


            if (this.ucPatientInformation.labelDisplayType.Text == "体检号:" || this.ucPatientInformation.labelDisplayType.Text == "门诊号:")
			{
				this.ucPatientInformation.textBoxCode.Text = this.register.PID.CardNO;
			}
			else
			{
				this.ucPatientInformation.textBoxCode.Text = this.register.ID;
			}
			//切换患者清空

			this.ucItemApply.ClearFp2();
			//
			// 隐藏等待窗口
			//
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		/// <summary>
		/// 单击明细，根据明细检索患者信息 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ucItemApply_ClickApply(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (this.ucItemApply.CurrentColumn == 0)
			{
				return;
			}
			if (this.register.Memo == "2")
			{
				return;
			}
			this.MakeItemListDisappear();
			//
			// 显示等待窗口
			//
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在检索患者基本信息...");
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 合同单位
			Neusoft.HISFC.Models.Base.PactInfo pact = new PactInfo();
			// 科室
			Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
			
			// 获取合同单位信息
			confirmIntegrate.GetPact(ref pact, this.ucItemApply.Register.Pact.ID);
			this.ucItemApply.Register.Pact = pact;
			// 获取科室信息
			confirmIntegrate.GetDept(ref dept, this.ucItemApply.Register.DoctorInfo.Templet.Dept.ID);
			this.ucItemApply.Register.DoctorInfo.Templet.Dept = dept;
			// 设置显示信息
			this.ucPatientInformation.Register = this.ucItemApply.Register;
			//
			// 隐藏等待窗口
			//
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		/// <summary>
		/// 在明细中按上下箭头，切换不同的患者基本信息 
		/// </summary>
		/// <param name="key"></param>
		void ucItemApply_KeyUpAndDown(Keys key)
		{
			// 保证患者基本信息UC显示的是当前单击项目的患者信息

			this.ucPatientInformation.Register = this.ucItemApply.Register;
		}

		/// <summary>
		/// 在患者病历号回车检索明细 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        void ucPatientInformation_KeyDownInQureyCode(object sender, KeyEventArgs e)
        {
            // 检索码
            string queryCode = "";
            // 患者信息


            Neusoft.HISFC.Models.Registration.Register queryRegister = new Register();
            // 患者姓名确认


            Terminal.Confirm.frmPatientName frmPatient = new frmPatientName();
            // 操作结果
            Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
            // 业务层


            Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
            // 清空申请单明细


            this.ucItemApply.Clear();
            this.ucItemApply.ClearFp2();
            // 显示等待窗口
            //Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在检索患者基本信息...");
            //
            // 根据不同的查询类型,执行不同的检索 
            //
            if (this.ucPatientInformation.labelDisplayType.Text == "门诊号:")
            {
                #region 门诊病历号


                //queryCode = this.ucPatientInformation.textBoxCode.Text.PadLeft(10, '0');
                //{D7742D35-6162-4b30-8F60-1F22E48C271D}
                queryCode = this.ucPatientInformation.textBoxCode.Text.PadLeft(10, '0');
                // 显示填充后的病历号



                this.ucPatientInformation.textBoxCode.Text = queryCode;
                //
                // 根据不同的窗口类型执行不同的查询:门诊用



                //
                if (this.WindowType == "1")
                {
                    // 根据病历号从申请单获取患者基本信息 
                    result = confirmIntegrate.GetOutpatientByCardNOFromTerminal(ref queryRegister, queryCode, false);
                    if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                    {
                        // 显示患者基本信息、和申请单明细、设置焦点 
                        this.ActionAfterQuery(ref queryRegister, false);

                        //----{F7A86CA8-6C64-4f27-955C-6B5B912E495F}
                        this.ucItemApply.GetFeeDetailByClinicCode(queryRegister.ID);
                        //
                    }
                    else
                    { 
                        result = confirmIntegrate.GetOutpatientByCardNOFromTerminal(ref queryRegister, queryCode, true);
                        if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success && IsCanConfirm)
                        {
                            #region  如果不存在,那么再获取一次其他执行科室的该卡号的信息
                            // 让医生确认患者姓名


                            if (DialogResult.OK.Equals(frmPatient.ShowDialog()))
                            {
                                if (queryRegister.Name.Equals(frmPatient.patientName))
                                {
                                    // 显示患者基本信息、和申请单明细、设置焦点



                                    this.ActionAfterQuery(ref queryRegister, true);
                                }
                            }
                            else
                            {
                                MessageBox.Show("您输入的姓名不正确!" + "\n" + "您不能执行该卡号患者的项目!");
                                this.ucPatientInformation.Focus(); 
                            }
                            frmPatient.Close();
                            #endregion
                        }
                        else
                        {
                            #region 如果不存在，那么再从挂号表中获取一次，如果存在，那么可以直接划价


                            // 如果不存在，那么再从挂号表中获取一次，如果存在，那么可以直接划价 
                            result = confirmIntegrate.GetOutpatientByCardNOFromRegister(ref queryRegister, queryCode);
                            if (Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success == result)
                            {
                                queryRegister.Memo = "1";
                                // 如果存在该病历号，那么显示患者基本信息、和申请单明细、设置焦点 
                                this.ActionAfterQuery(ref queryRegister, false);
                            }
                            else
                            {
                                // 否则，清空所有UC的患者属性



                                this.SetAllRegister(null);
                                //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show("患者信息不存在!\n" + confirmIntegrate.Err, "医技终端确认");
                                this.ucPatientInformation.Focus();
                                this.ucPatientInformation.textBoxCode.Text = "";
                                // 设置焦点到检索码输入框



                                this.ucPatientInformation.textBoxCode.Focus();
                                //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                return;
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
            else if (this.ucPatientInformation.labelDisplayType.Text == "体检号:")
            {
                
                //queryCode = this.ucPatientInformation.textBoxCode.Text.PadLeft(10, '0');
                //{D7742D35-6162-4b30-8F60-1F22E48C271D}
                queryCode = this.ucPatientInformation.textBoxCode.Text.PadLeft(10, '0');

                // 显示填充后的病历号



                this.ucPatientInformation.textBoxCode.Text = queryCode;
                //
                // 根据不同的窗口类型执行不同的查询:门诊用



                //
                if (this.WindowType == "1")
                {
                    // 根据病历号从申请单获取患者基本信息



                    result = confirmIntegrate.GetOutpatientByCardNOFromTerminal(ref queryRegister, queryCode, false);
                    if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                    {
                        // 显示患者基本信息、和申请单明细、设置焦点



                        this.ActionAfterQuery(ref queryRegister, false);
                        // 隐藏等待窗口
                        //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    }
                    else
                    {

                        result = confirmIntegrate.GetOutpatientByCardNOFromTerminal(ref queryRegister, queryCode, true);
                        if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success && IsCanConfirm)
                        {
                            #region  如果不存在,那么再获取一次其他执行科室的该卡号的信息
                            // 让医生确认患者姓名


                            if (DialogResult.OK.Equals(frmPatient.ShowDialog()))
                            {
                                if (queryRegister.Name.Equals(frmPatient.patientName))
                                {
                                    // 显示患者基本信息、和申请单明细、设置焦点 
                                    this.ActionAfterQuery(ref queryRegister, true);
                                }
                            }
                            else
                            {
                                MessageBox.Show("您输入的姓名不正确!" + "\n" + "您不能执行该卡号患者的项目!");
                                this.ucPatientInformation.Focus(); 
                            }
                            frmPatient.Close();
                            #endregion
                        }
                        else  
                        {
                            #region 查询体检登记信息
                            ArrayList list = examMgr.QueryRegisterByCardNO(queryCode);
                            if (list == null)
                            {
                                this.SetAllRegister(null); 
                                this.ucPatientInformation.Focus();
                                this.ucPatientInformation.textBoxCode.Text = "";
                                // 设置焦点到检索码输入框



                                this.ucPatientInformation.textBoxCode.Focus();
                                MessageBox.Show("查询失败" + examMgr.Err);
                                return;
                            }
                            if (list.Count == 0)
                            {
                                this.SetAllRegister(null);
                                this.ucPatientInformation.Focus();
                                this.ucPatientInformation.textBoxCode.Text = "";
                                MessageBox.Show("没有查到相关信息");
                                return;
                            }
                            if (list.Count > 0)
                            {
                                this.SetAllRegister(null);
                                this.ucPatientInformation.Focus();
                                this.ucPatientInformation.textBoxCode.Text = "";
                                MessageBox.Show("该患者是体检患者不允许终端科室直接划价");
                                return;
                            }
                            return;
                            #endregion
                        } 
                    }
                }
            } 
        }

		/// <summary>
		/// 选择住院号事件 
		/// </summary>
		void ucPatientInformation_SelectInpatientNO()
		{
			// 查询住院号

			string queryCode = this.ucPatientInformation.ucQueryInpatientNo1.InpatientNo;
			// 操作结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
			// 临时患者实体

			Neusoft.HISFC.Models.Registration.Register queryRegister = new Register();
			// 如果为空，那么返回

			if (queryCode == "")
			{
				return;
			}
			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询患者基本信息...");
			// 根据患者类型和患者编号从申请单表查询患者基本信息

			result = confirmIntegrate.GetPatientByClinicCodeFromTerminal(ref queryRegister, queryCode, false, "2");
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
                queryRegister.Memo = "2";

                #region 查询其他科室终端确认项目
                // 如果不存在,那么再获取一次其他执行科室的信息
                //result = confirmIntegrate.GetPatientByClinicCodeFromTerminal(ref queryRegister, queryCode, true, "2");
                //if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                //{
                //    // 患者姓名控件

                //    frmPatientName frmPatient = new frmPatientName();
                //    // 隐藏等待窗口
                //    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //    // 让医生确认患者姓名

                //    if (!DialogResult.OK.Equals(frmPatient.ShowDialog()))
                //    {
                //        // 隐藏等待窗口
                //        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //        if (queryRegister.Name.Equals(frmPatient.patientName))
                //        {
                //            // 如果存在该病历号，那么显示患者基本信息、和申请单明细、设置焦点

                //            this.ActionAfterByIDAndType(Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success, confirmIntegrate, ref queryRegister, true);
                //        }
                //        else
                //        {
                //            // 出错信息
                //            MessageBox.Show("您输入的姓名不正确!" + "\n" + "您不能执行该卡号患者的项目!");
                //            // 清空
                //            this.ucPatientInformation.textBoxCode.Text = "";
                //            // 设置焦点
                //            this.ucPatientInformation.textBoxCode.Focus();
                //        }
                //    }
                //}
                #endregion 
            }
			Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
		}

		/// <summary>
		/// 按键事件
		/// </summary>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.F9)
			{
				// 增加一条新项目
				if (this.Register == null)
				{
					MessageBox.Show("当前没有可用的患者基本信息!", "医技终端确认");
					this.ucPatientInformation.textBoxCode.Focus();
					return true;
				}
				this.ucItemApply.Register = this.ucPatientInformation.Register;
				this.ucItemApply.NewRow();
				this.MakeItemListDisappear();
				
				return true;
			}
			else if (keyData == Keys.F10)
			{
				// 删除一条新项目
				this.ucItemApply.DeleteNew();
				this.MakeItemListDisappear();

				return true;
			}
			else if (keyData == Keys.F7)
			{
				// 保存终端确认
				this.Save();
				this.MakeItemListDisappear();

				return true;
			}
			else if (keyData == Keys.F5)
			{
				// 选中全部明细
				this.ucItemApply.SelectAll();
				this.MakeItemListDisappear();

				return true;
			}
			else if (keyData == Keys.F6)
			{
				// 取消全部明细的选中状态

				this.ucItemApply.CancelAll();
				this.MakeItemListDisappear();

				return true;
			}
			else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.P.GetHashCode())
			{
				// 切换焦点到患者列表

				this.ucPatientTree.SetFocus();

				return true;
			}
			else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.A.GetHashCode())
			{
				// 切换焦点到患者检索文本框
				this.ucPatientInformation.SetFocus();

				return true;
			}
			else if (keyData == Keys.F3)
			{
				// 设置焦点到明细

				this.ucItemApply.fpSpread1.Focus();

				return true;
			}
            //else if (keyData == Keys.F2)
            //{
            //    // 切换检索方式


            //    this.ucPatientInformation.QueryType = ucPatientInformation.QueryType + 1;

            //    // 设置焦点到检索文本框
            //    if (this.ucPatientInformation.QueryType == 4)
            //    {
            //        this.ucPatientInformation.ucQueryInpatientNo1.Focus();
            //    }
            //    else
            //    {
            //        this.ucPatientInformation.textBoxCode.Focus();
            //    }

            //    // 设置检索文本框为全选

            //    this.ucPatientInformation.textBoxCode.SelectAll();

            //    return true;
            //}
			else if (keyData == Keys.F8)
			{
				// 刷新患者树
				Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("请等待,正在加载患者信息列表...");
				this.ucPatientTree.LoadOutpatient();
				this.MakeItemListDisappear();
				Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

				return true;
			}
			else if (keyData == Keys.Escape)
			{
				// 取消项目列表可见状态

				if (this.ucItemApply.Visible)
				{
					this.ucItemApply.UnDisplayUcItemList();
				}
				return true;
			}
			else if (keyData == Keys.F1)
			{
				//frmHelp help = new frmHelp();
				//help.ShowDialog();
			}
			//else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.P.GetHashCode())
			//{
			//    this.Print();
			//    return true;
            //}
            #region 医技终端增加门诊病历内容查询功能，供医技人员参考用 {967CA656-AB9D-4841-8BFE-9A2EC7E8F886}
            else if (keyData == Keys.F11)
            {
                this.patientCaseEventHandler(null, null);
            }
            #endregion

            return base.ProcessDialogKey(keyData);
        }

        #region 医技终端增加门诊病历内容查询功能，供医技人员参考用 {967CA656-AB9D-4841-8BFE-9A2EC7E8F886}

        void ucTerminalConfirm_PatientCaseEvent(object sender, EventArgs e)
        {
            if (this.IOutpatientCaseInstance == null)
            {
                this.IOutpatientCaseInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Terminal.IOutpatientCase)) as Neusoft.HISFC.BizProcess.Interface.Terminal.IOutpatientCase;
            }
            if (this.IOutpatientCaseInstance != null)
            {
                this.IOutpatientCaseInstance.IsBrowse = true;
                this.IOutpatientCaseInstance.InitUC();
            }
            else
            {
                MessageBox.Show("门诊病历数据显示接口未维护", "提示");
            }
            if (this.ucPatientTree.GetCurrentNode() == null)
            {
                return;
            }
            TreeNode currentNode = this.ucPatientTree.GetCurrentNode();
            if (currentNode == null)
            {
                return;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行门诊病历数据加载 请稍候...");
            Application.DoEvents();
            // 获取单击的树结点的Tag属性,里面承载着患者基本信息
            try
            {
                //{971F13CD-0523-4ea4-A0F5-02DA57698331} modified by shangxw 2009-12-14 当点到的不是患者的时候抛异常
                //Neusoft.HISFC.Object.Registration.Register registerInfo = (Neusoft.HISFC.Object.Registration.Register)currentNode.Tag;
                Neusoft.HISFC.Models.Registration.Register registerInfo = currentNode.Tag as Neusoft.HISFC.Models.Registration.Register;
                if (registerInfo == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }
                this.IOutpatientCaseInstance.Register = registerInfo;
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                this.IOutpatientCaseInstance.Show();
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

        private void ucItemApply_Load(object sender, EventArgs e)
        {
            this.InitUC();
        }
    }

    public enum EnumShowItemType
    {
        /// <summary>
        /// 药品
        /// </summary>
        Pharmacy,
        /// <summary>
        /// 非药品

        /// </summary>
        Undrug,
        /// <summary>
        /// 全部
        /// </summary>
        All,
        /// <summary>
        /// 科常用

        /// </summary>
        DeptItem
    }
}
