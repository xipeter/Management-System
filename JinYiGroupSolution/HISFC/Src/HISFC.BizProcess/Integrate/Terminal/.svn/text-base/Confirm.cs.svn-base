using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizLogic.Fee;
using Neusoft.HISFC.BizLogic.Manager;
using Neusoft.HISFC.BizLogic.Order;
using Neusoft.HISFC.BizLogic.Pharmacy;
using Neusoft.HISFC.BizLogic.Terminal;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.HISFC.Models.PhysicalExamination;
using Neusoft.HISFC.Models.Terminal;
using Controler = Neusoft.HISFC.BizLogic.Manager.Controler;
using Department = Neusoft.HISFC.BizLogic.Manager.Department;
using DeptItem=Neusoft.HISFC.BizLogic.Manager.DeptItem;
using InPatient=Neusoft.HISFC.BizLogic.RADT.InPatient;
using Item = Neusoft.HISFC.BizLogic.Pharmacy.Item;
using Register = Neusoft.HISFC.BizLogic.Registration.Register;

namespace Neusoft.HISFC.BizProcess.Integrate.Terminal
{
    /// <summary>
    /// Confirm <br></br>
    /// [功能描述: 终端确认Integrate]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2006-03-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述='控制参数500000更改为tc002'
    ///  />
    /// </summary>
    public class Confirm : IntegrateBase
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public Confirm()
        {
            this.GetEnvironment();
        }
        /// <summary>
        /// 带事务的构造函数


        /// </summary>
        /// <param name="trans">事务</param>
        public Confirm(System.Data.IDbTransaction trans)
        {
            this.SetTrans(trans);

            this.GetEnvironment();
        }

        #region 普通变量



        /// <summary>
        /// 返回值


        /// </summary>
        protected int intReturn = 0;

        #endregion

        #region 静态变量



        /// <summary>
        /// 终端确认业务层


        /// </summary>
        protected Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm serviceTerminalConfirm = new TerminalConfirm();

        /// <summary>
        /// 终端确认工作量业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Terminal.WorkloadItem serviceWorkloadItem = new WorkloadItem();

        /// <summary>
        /// 合同单位业务层


        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.PactUnitInfo servicePact = new PactUnitInfo();

        /// <summary>
        /// 科室管理业务层


        /// </summary>
        protected Neusoft.HISFC.BizLogic.Manager.Department serviceDept = new Department();

        /// <summary>
        /// 控制参数业务层


        /// </summary>
        protected Neusoft.HISFC.BizLogic.Manager.Controler serviceControler = new Controler();

        /// <summary>
        /// 挂号业务层


        /// </summary>
        protected Neusoft.HISFC.BizLogic.Registration.Register serviceRegister = new Register();

        /// <summary>
        /// 当前操作环境
        /// </summary>
        public static Neusoft.HISFC.Models.Base.OperEnvironment CurrentOperEnvironment = new OperEnvironment();

        /// <summary>
        /// 药品业务层


        /// </summary>
        public Neusoft.HISFC.BizLogic.Pharmacy.Item serviceDrug = new Item();

        /// <summary>
        /// 非药品业务层
        /// </summary>
        public Neusoft.HISFC.BizLogic.Fee.Item serviceUndrug = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 住院医嘱业务层


        /// </summary>
        public Neusoft.HISFC.BizLogic.Order.Order serviceInpatientOrder = new Neusoft.HISFC.BizLogic.Order.Order();

        /// <summary>
        /// 门诊收费业务层


        /// </summary>
        public Neusoft.HISFC.BizLogic.Fee.Outpatient serviceOutpatientFee = new Outpatient();

        /// <summary>
        /// 门诊医嘱业务层


        /// </summary>
        public Neusoft.HISFC.BizLogic.Order.OutPatient.Order serviceOutpatientOrder = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();

        /// <summary>
        /// 体检登记业务层


        /// </summary>
        public Neusoft.HISFC.BizLogic.PhysicalExamination.Register servicePERegister = new Neusoft.HISFC.BizLogic.PhysicalExamination.Register();

        /// <summary>
        /// 医技预约业务层


        /// </summary>
		public Neusoft.HISFC.BizLogic.Terminal.MedTechItemArray serviceTerminalBooking = new MedTechItemArray();

        /// <summary>
        /// 员工业务层


        /// </summary>
		public Neusoft.HISFC.BizLogic.Manager.UserManager serviceEmployee = new UserManager();
    	
    	/// <summary>
    	/// 住院患者业务层
    	/// </summary>
		public Neusoft.HISFC.BizLogic.RADT.InPatient serviceInpatient = new InPatient();
    	
    	

        #endregion

        #region 私有函数

        /// <summary>
        /// 获取当前操作环境
        /// </summary>
        protected void GetEnvironment()
        {
            CurrentOperEnvironment.ID = serviceTerminalConfirm.Operator.ID;
            CurrentOperEnvironment.Name = serviceTerminalConfirm.Operator.Name;
            CurrentOperEnvironment.Dept = ((Neusoft.HISFC.Models.Base.Employee)serviceTerminalConfirm.Operator).Dept;
            // CurrentOperEnvironment.OperTime = serviceTerminalConfirm.GetDateTimeFromSysDateTime();
        }

        #endregion

        #region 公共函数
        #region 作废终端确认主表
        /// <summary>
        /// 根据医嘱流水号和项目号作废终端确认 
        /// </summary>
        /// <param name="MoOrder">医嘱流水号</param>
        /// <param name="ItemCode">项目编码</param>
        /// <returns></returns> 
        public int CancelConfirmTerminal(string MoOrder, string ItemCode)
        {
            this.SetDB(serviceTerminalConfirm);
            return serviceTerminalConfirm.UpdateConfirm(MoOrder, ItemCode);
        }
        /// <summary>
        /// 根据医嘱流水号和项目号作废终端确认 
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        [Obsolete("废弃,用CancelConfirmTerminal代替",true)]
        public int UpdateConfirm(string MoOrder,string ItemCode)
        {
            this.SetDB(serviceTerminalConfirm);
            return serviceTerminalConfirm.UpdateConfirm(MoOrder, ItemCode);
        }
         #endregion
        /// <summary>
        /// 设置事务对象
        /// </summary>
        /// <param name="trans">数据库事务</param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            serviceTerminalConfirm.SetTrans(trans);
            serviceWorkloadItem.SetTrans(trans);
            servicePact.SetTrans(trans);
            serviceDept.SetTrans(trans);
            serviceControler.SetTrans(trans);
            serviceRegister.SetTrans(trans);
            serviceDrug.SetTrans(trans);
            serviceUndrug.SetTrans(trans);
            serviceInpatientOrder.SetTrans(trans);
            serviceOutpatientFee.SetTrans(trans);
            serviceOutpatientOrder.SetTrans(trans);
            servicePERegister.SetTrans(trans);
            serviceTerminalBooking.SetTrans(trans);
            serviceEmployee.SetTrans(trans);
        	serviceInpatient.SetTrans(trans);
            //if (serviceFee.trans == null)
            //{
                //serviceFee.SetTrans(trans);
            //}
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns>当前时间</returns>
        public System.DateTime GetCurrentDateTime()
        {
            return serviceTerminalConfirm.GetDateTimeFromSysDateTime();
        }

        #region 根据医嘱号判断申请单是否存在，返回已经确认标志(1：存在/0：不存在/-1：失败)
        /// <summary>
        /// 根据医嘱号判断申请单是否存在，返回已经确认标志(1：存在/0：不存在/-1：失败)
        /// </summary>
        /// <param name="orderCode">医嘱流水号</param>
        /// <param name="sendFlag">医嘱执行状态：'2'已经执行</param>
        /// <returns>1：存在/0：不存在/-1：失败</returns>
        public int JudgeIfConfirm(string orderCode, ref string sendFlag)
        {
            this.SetDB(serviceTerminalConfirm);
            return serviceTerminalConfirm.JudgeIfConfirm(orderCode,  ref sendFlag);
        }
        #endregion

        #region 根据医嘱流水号删除申请单(1：成功/-1：失败)
        /// <summary>
        /// 根据医嘱流水号删除申请单(1：成功/-1：失败)
        /// </summary>
        /// <param name="stringOrderNo">医嘱流水号</param>
        /// <returns>1：成功/-1：失败</returns>
        public int DeleteByOrder(string stringOrderNo)
        {
            this.SetDB(serviceTerminalConfirm);
            return serviceTerminalConfirm.DeleteByOrder(stringOrderNo);
        }
        #endregion
        #endregion

        #region 查询获取
         /// <summary>
        /// 根据医嘱号获取终端确认主表信息

        /// </summary>
        /// <param name="SequenceNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Terminal.TerminalApply GetItemListBySequence(string MoOrder, string ApplyNum)
        {
            this.SetDB(serviceTerminalConfirm);
            return serviceTerminalConfirm.GetItemListBySequence(MoOrder, ApplyNum);
        }
        //
        // 终端确认
        //
        /// <summary>
        /// 获取等待进行终端确认的患者树节点
        /// </summary>
        /// <param name="treeNode">树结点</param>
        /// <returns>结果</returns>
        public Result GetOutpatientTreeNode(ref TreeNode treeNode)
        {
            // 患者列表天数限制

            int limitedDays = 0;
            // 患者数组

            ArrayList patientList = new ArrayList();
            // 设置根节点

            treeNode.Text = "患者列表";
            treeNode.ImageIndex = 3;
            treeNode.SelectedImageIndex = 3;
            treeNode.Tag = treeNode.Text;
        	// 门诊患者节点

        	TreeNode outpatientNode = new TreeNode("门诊患者");
            outpatientNode.SelectedImageIndex = 0;
            outpatientNode.ImageIndex = 1;
            //// 住院患者节点

            //TreeNode inpatientNode = new TreeNode("住院患者");
            //inpatientNode.SelectedImageIndex = 0;
            //inpatientNode.ImageIndex = 1;
        	// 体检患者

        	TreeNode peNode = new TreeNode("体检患者");
            peNode.SelectedImageIndex = 0;
            peNode.ImageIndex = 1;
            // 获取患者列表的天数限制
            try
            {
                this.SetDB(serviceControler);
                limitedDays = Neusoft.FrameWork.Function.NConvert.ToInt32(serviceControler.QueryControlerInfo("TC001"));
            }
            catch (Exception exception)
            {
                this.Err += "\n" + exception.Message;
                return Result.Failure;
            }
            if (limitedDays >= 1)
            {
                limitedDays = limitedDays - 1;
            }
            // 获取患者数组


            this.SetDB(serviceTerminalConfirm);
            this.intReturn = serviceTerminalConfirm.QueryPatients(ref patientList, CurrentOperEnvironment.Dept.ID, limitedDays);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 构造患者树结点
            foreach (Neusoft.HISFC.Models.Registration.Register patient in patientList)
            {
                // 患者结点

                TreeNode patientNode = new TreeNode();
                patientNode.ImageIndex = 6;
                patientNode.SelectedImageIndex = 7;
                // 挂号时间
                System.DateTime registerTime = new DateTime();
                // 挂号实体
                Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();
                // 获取合同单位信息
                this.SetDB(servicePact);
                patient.Pact = servicePact.GetPactUnitInfoByPactCode(patient.Pact.ID);
                // 获取科室信息
                this.SetDB(serviceDept);
                patient.DoctorInfo.Templet.Dept = serviceDept.GetDeptmentById(patient.DoctorInfo.Templet.Dept.ID);
                // 计算年龄
                if (patient.Memo == "1" )
            	{
					this.SetDB(serviceRegister);
					register = serviceRegister.GetByClinic(patient.ID);
					if (register != null)
					{
						patient.Birthday = register.Birthday;
					}
            	}
                else if (patient.Memo == "4" || patient.Memo == "5")
                {
                    this.SetDB(servicePERegister);
                    Neusoft.HISFC.Models.PhysicalExamination.Register ss = servicePERegister.GetRegisterByClinicNO(patient.ID);
                    if (ss != null)
                    {
                        patient.Birthday = ss.Birthday;
                        patient.Sex = ss.Sex;
                    }
                }
                else
                {
                    this.SetDB(serviceInpatient);
                    Neusoft.HISFC.Models.RADT.PatientInfo tempInfo = serviceInpatient.GetPatientInfoByPatientNO(patient.PID.ID);
                    if (tempInfo != null)
                    {
                        register.Birthday = tempInfo.Birthday;
                    }
                }
                
                if (patient.Age == null || patient.Age.Equals(""))
                {
                    patient.Age = serviceDept.GetAge(patient.Birthday.Date);
                    patient.Age = patient.Age.Substring(0, patient.Age.Length - 1);
                }
                // 保存结点tag为患者类实体
                patientNode.Tag = patient;
                // 设置结点文本为患者姓名

                patientNode.Text = patient.Name;
            	
            	switch(patient.Memo)
            	{
            		case "1":
						outpatientNode.Nodes.Add(patientNode);
						break;
					case "2":
                        //inpatientNode.Nodes.Add(patientNode);
						break;
					case "3":
                        //inpatientNode.Nodes.Add(patientNode);
						break;
					case "4":
                    case "5":
						peNode.Nodes.Add(patientNode);
						break;
            	}
            }
			treeNode.Nodes.Add(outpatientNode);
            //treeNode.Nodes.Add(inpatientNode);
			treeNode.Nodes.Add(peNode);
        	
            // 成功返回
            return Result.Success;
        }
        /// <summary>
        /// 更新 更新终端确认表 的数量 如果可退数量 等于 收费数量则删除

        /// </summary>
        /// <param name="MoOrder"></param>
        /// <param name="Qty"></param>
        /// <param name="BackQty"></param>
        /// <returns></returns>
        public int UpdateOrDeleteTerminalConfirmApply(string MoOrder, int Qty, int BackQty, decimal TotCost)
        {
            this.SetDB(serviceTerminalConfirm);
            if (Qty == BackQty)
            {
                return serviceTerminalConfirm.DeleteByOrder(MoOrder);
            }
            else
            {
                return serviceTerminalConfirm.UpdateTerminalConfirmByMoOrder(MoOrder, BackQty, TotCost);
            }
        }
        /// <summary>
        /// 根据医嘱号 更新终端确认表的数量
        /// </summary>
        /// <param name="MoOrder">医嘱流水号</param>
        /// <param name="BackQty">退的数量 (最小数量)</param>
        /// <returns></returns>
        public int UpdateTerminalByMoOrder(string MoOrder,int BackQty,decimal TotCost)
        {
            this.SetDB(serviceTerminalConfirm);
            return serviceTerminalConfirm.UpdateTerminalConfirmByMoOrder(MoOrder, BackQty, TotCost);
        }
        /// <summary>
        /// 根据药品编码获取药品信息
        /// </summary>
        /// <param name="drug">药品信息</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>结果</returns>
        public Result GetDrug(ref Neusoft.HISFC.Models.Pharmacy.Item drug, string drugCode)
        {
            this.SetDB(serviceDrug);
            // 获取
            drug = serviceDrug.GetItem(drugCode);
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据非药品编码获取非药品信息
        /// </summary>
        /// <param name="undrug">非药品信息</param>
        /// <param name="undrugCode">非药品编码</param>
        /// <returns>结果</returns>
        public Result GetUndrug(ref Neusoft.HISFC.Models.Fee.Item.Undrug undrug, string undrugCode)
        {
            this.SetDB(serviceUndrug);
            // 获取
            undrug = serviceUndrug.GetValidItemByUndrugCode(undrugCode);
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据科室编码或者科室信息


        /// </summary>
        /// <param name="dept">科室信息</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>结果</returns>
        public Result GetDept(ref Neusoft.HISFC.Models.Base.Department dept, string deptCode)
        {
            this.SetDB(serviceDept);
            // 获取
            dept = serviceDept.GetDeptmentById(deptCode);
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据门诊号获取终端确认申请单
        /// </summary>
        /// <param name="clinicCode">门诊号</param>
        /// <param name="applyList">终端确认申请单</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>结果</returns>
        public Result QueryApplyListByClinicCode(string clinicCode, ref ArrayList applyList, string deptCode)
        {
            this.SetDB(serviceTerminalConfirm);
            // 获取
            this.intReturn = serviceTerminalConfirm.QueryTerminalApplyList(clinicCode, ref applyList, deptCode);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据病历号获取终端确认申请单
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="applyList">终端确认申请单</param>
        /// <param name="deptCode">科室编码，空为所有科室</param>
        /// <param name="IsExami">true 集体体检 false 不是集体体检 </param>
        /// <returns>结果</returns>
        public Result QueryApplyListByCardNO(string cardNO, ref ArrayList applyList, string deptCode,bool IsExami)
        {
            this.SetDB(serviceTerminalConfirm);
            // 获取
            this.intReturn = serviceTerminalConfirm.QueryApplyListByCardNO(cardNO, ref applyList, deptCode, IsExami);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据病历号获取终端确认申请单
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="applyList">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result QueryApplyListByCardNO(string cardNO, ref ArrayList applyList)
        {
            this.SetDB(serviceTerminalConfirm);
            // 获取
            this.intReturn = serviceTerminalConfirm.QueryApplyListByCardNO(cardNO, ref applyList);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        public Result QueryConfirmInfoByInpatientNO(string inpatientNO, string operDept, ref ArrayList al)
        {
            this.SetDB(serviceTerminalConfirm);
            // 获取
            this.intReturn = serviceTerminalConfirm.QueryTerminalConfirmList(inpatientNO, operDept, ref al);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据医嘱号获取发票明细


        /// </summary>
        /// <param name="dsInvoiceDetail">发票明细</param>
        /// <param name="orderCode">医嘱号</param>
        /// <returns>结果</returns>
        public Result QueryInvoiceDetailByOrderCode(ref System.Data.DataSet dsInvoiceDetail, string orderCode)
        {
            this.SetDB(serviceTerminalConfirm);
            // 获取
            this.intReturn = serviceTerminalConfirm.QueryInvoiceDetailByOrderCode(orderCode, ref dsInvoiceDetail);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据门诊号获取详细的患者基本信息


        /// </summary>
        /// <param name="register">患者基本信息</param>
        /// <param name="clinicCode">门诊号</param>
        /// <returns>结果</returns>
        public Result GetRegisterByClinicCode(ref Neusoft.HISFC.Models.Registration.Register register, string clinicCode)
        {
            this.SetDB(serviceRegister);
            // 获取
            register = serviceRegister.GetByClinic(clinicCode);
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据出生日期获取年龄
        /// </summary>
        /// <param name="age">年龄</param>
        /// <param name="birthday">出生日期</param>
        /// <returns>结果</returns>
        public Result GetAge(ref string age, DateTime birthday)
        {
            this.SetDB(serviceDept);
            // 获取
            age = serviceDept.GetAge(birthday);
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据合同单位编码获取合同单位
        /// </summary>
        /// <param name="pact">合同单位</param>
        /// <param name="pactCode">合同单位编码</param>
        /// <returns>结果</returns>
        public Result GetPact(ref Neusoft.HISFC.Models.Base.PactInfo pact, string pactCode)
        {
            this.SetDB(servicePact);
            // 获取
            pact = servicePact.GetPactUnitInfoByPactCode(pactCode);
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据病历号获取门诊患者基本信息


        /// </summary>
        /// <param name="register">门诊患者基本信息</param>
        /// <param name="code">病历号</param>
        /// <param name="isAllDept">是否全部科室</param>
        /// <returns>结果</returns>
        public Result GetOutpatientByCardNOFromTerminal(ref Neusoft.HISFC.Models.Registration.Register register, string code, bool isAllDept)
        {
            this.GetEnvironment();
            this.SetDB(serviceTerminalConfirm);
            // 患者数组


            ArrayList registerList = new ArrayList();
            // 科室编码
            string deptCode = "";
            if (!isAllDept)
            {
                deptCode = CurrentOperEnvironment.Dept.ID;
            }
            // 查询
            this.intReturn = serviceTerminalConfirm.GetPatientsByCardNO(code, deptCode, ref registerList);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            if (registerList.Count > 0)
            {
                register = (Neusoft.HISFC.Models.Registration.Register)registerList[0];
            }
            else
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据病历号获取门诊患者基本信息


        /// </summary>
        /// <param name="register">门诊患者基本信息</param>
        /// <param name="code">病历号</param>
        /// <returns>结果</returns>
        public Result GetOutpatientByCardNOFromRegister(ref Neusoft.HISFC.Models.Registration.Register register, string code)
        {
            this.SetDB(serviceRegister);
            // 患者挂号实体


            ArrayList registerList = new ArrayList();
            // 查询
            registerList = serviceRegister.Query(code, DateTime.MinValue);
            if (registerList.Count <= 0)
            {
                return Result.Failure;
            }
            register = (Neusoft.HISFC.Models.Registration.Register)registerList[registerList.Count - 1];
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据就诊号获取门诊患者基本信息


        /// </summary>
        /// <param name="register">患者基本信息</param>
        /// <param name="code">就诊号</param>
        /// <param name="isAllDept">是否全部科室</param>
        /// <param name="patientType">患者类别：1－门诊；4－体检</param>
        /// <returns>结果</returns>
        public Result GetPatientByClinicCodeFromTerminal(ref Neusoft.HISFC.Models.Registration.Register register, string code, bool isAllDept, string patientType)
        {
            this.SetDB(serviceTerminalConfirm);
            // 科室编码
            string deptCode = "";
            if (!isAllDept)
            {
                deptCode = CurrentOperEnvironment.Dept.ID;
            }
            // 查询
            this.intReturn = serviceTerminalConfirm.GetPatientsByClinicCode(code, patientType, deptCode, ref register);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据就诊号获取患者基本信息


        /// </summary>
        /// <param name="register">患者基本信息</param>
        /// <param name="code">就诊号</param>
        /// <returns>结果</returns>
        public Result GetPatientByClinicCodeFromRegister(ref Neusoft.HISFC.Models.Registration.Register register, string code)
        {
            this.SetDB(serviceRegister);
            // 查询
            register = serviceRegister.GetByClinic(code);
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据员工编号获取员工信息
        /// </summary>
        /// <param name="employee">员工信息</param>
        /// <param name="employeeID">员工编号</param>
        /// <returns></returns>
        public Result GetEmployee(ref Neusoft.HISFC.Models.Base.Employee employee, string employeeID)
        {
            this.SetDB(serviceEmployee);
            // 查询
            employee = serviceEmployee.GetPerson(employeeID);
            // 成功返回
            return Result.Success;
        }

        public Result QueryConfirmInfoByClinicNo(string clinicNo, string deptID, ref List<Neusoft.HISFC.Models.Terminal.TerminalApply> apply)
        {
            this.SetDB(serviceTerminalConfirm);
            // 获取
            intReturn = serviceTerminalConfirm.QueryConfirmInfoByClinicNo(clinicNo, deptID, ref apply);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 根据申请单流水号获取业务明细
        /// </summary>
        /// <param name="apply">申请单</param>
        /// <param name="detailsList">业务明细</param>
        /// <returns>结果</returns>
        public Result QueryDetailsByApply(Neusoft.HISFC.Models.Terminal.TerminalApply apply, ref ArrayList detailsList)
        {
            this.SetDB(serviceTerminalConfirm);
            // 获取
            this.intReturn = serviceTerminalConfirm.QueryDetailsByApply(apply, ref detailsList);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }
    	
    	/// <summary>
    	/// 获取住院患者信息

    	/// </summary>
    	/// <param name="inpatientNO">住院号</param>
    	/// <param name="inpatient">患者信息</param>
    	/// <returns>结果</returns>
    	public Result GetInpatient(string inpatientNO, ref Neusoft.HISFC.Models.RADT.PatientInfo inpatient)
    	{
    		this.SetDB(serviceInpatient);
    		
    		// 查询
			inpatient = serviceInpatient.GetPatientInfoByPatientNO(inpatientNO);

			return Result.Success;
    	}

        #endregion

        #region 数据更新

        //
        // 终端确认
        //
        /// <summary>
        /// 终端确认保存
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <param name="register">患者信息</param>
        /// <param name="register">集体体检</param>
        /// <returns>结果</returns>
        public Result Save(Neusoft.HISFC.Models.Terminal.TerminalApply apply, Neusoft.HISFC.Models.Registration.Register register, bool IsExami)
        {
            // 获取当前操作环境
            this.GetEnvironment();
            // 确认操作环境
            apply.ConfirmOperEnvironment = CurrentOperEnvironment;
            // 判断新老项目

            if (apply.NewOrOld == "1")
            {
                return this.SaveNew(apply, register, IsExami);
            }
            else
            {
            	if (register.Memo == "2")
            	{
					return this.SaveInpatient(apply, register);
            	}
                else
            	{
                    return this.SaveOld(apply, register, IsExami);
            	}
            }
        }

        /// <summary>
        /// 保存新项目


        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result SaveNew(Neusoft.HISFC.Models.Terminal.TerminalApply apply,Neusoft.HISFC.Models.Registration.Register register,bool IsExami)
        {
            /// <summary>
		    /// 费用业务层

		    /// </summary>
		    Neusoft.HISFC.BizProcess.Integrate.Fee serviceFee = new Fee();
            // 医嘱流水号

            string orderID = "";

            if (this.trans != null)
            {
                serviceFee.SetTrans(this.trans);
            }
            // 门诊费用数组
            ArrayList feeItemList = new ArrayList();
        	// 错误信息
        	string errText = "";
        	// 判断身份：住院、急诊不用保存
        	if (apply.Patient.Memo == "2" || apply.Patient.Memo == "3")
        	{
				return Result.Success;
        	}
            // 取医嘱流水号
            this.SetDB(serviceInpatientOrder);
            orderID = serviceInpatientOrder.GetNewOrderID();
            if (orderID.Equals("") || orderID == null)
            {
                return Result.Failure;
            }
            // 划价时间
            apply.Item.ChargeOper.OperTime = this.GetCurrentDateTime();
            // 新项目划价

			apply.Item.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
			apply.Item.Patient.ID = apply.Patient.ID;
            apply.Order.ID = orderID;
            apply.Item.Order.ID = orderID;
        	feeItemList.Add(apply.Item);
			if (!serviceFee.SetChargeInfo(apply.Patient, feeItemList, apply.InsertOperEnvironment.OperTime, ref errText))
        	{
				this.Err = errText;
				return Result.Failure;
        	}
            if (apply.SpecalFlag == "1")
            {
                #region 门诊终端扣费
                //终端划价并且扣账户收费 ,需要插 终端确认和预约表  
                apply.Item.ConfirmedQty = apply.Item.Item.Qty;
                apply.Item.PayType = PayTypes.Balanced;
                apply.Item.FT.TotCost = apply.Item.Item.Price * apply.Item.Item.Qty;
                apply.Item.FT.TotCost = decimal.Round(apply.Item.FT.TotCost, 2);
                if (this.Insert(apply) <= 0)
                {
                    this.Err = serviceTerminalConfirm.Err;
                    return Result.Failure;
                }  
                Neusoft.HISFC.Models.Terminal.TerminalApply temApply = this.GetItemListBySequence(apply.Order.ID,apply.ID);
                if (temApply == null )
                {
                    this.Err =  "划价后获取确认申请单信息失败"  + this.Err;
                    return Result.Failure;
                }
                if (temApply.ID == "" || temApply.ID == null || temApply.ID == string.Empty)
                {
                    this.Err = "划价后获取确认申请单信息失败" ;
                    return Result.Failure;
                }
                temApply.Item.ConfirmedQty = apply.Item.Item.Qty;
                temApply.SpecalFlag = apply.SpecalFlag;
                if (SaveOld(temApply, register, IsExami) == Result.Failure)
                {
                    return Result.Failure;
                }
                #endregion 
            }
            else if (apply.SpecalFlag == "2")//终端扣住院费用

            {
                #region  住院终端扣费
                apply.Item.ConfirmedQty = apply.Item.Item.Qty;
                apply.Item.PayType = PayTypes.Balanced;
                apply.Item.FT.TotCost = apply.Item.Item.Price * apply.Item.Item.Qty;
                apply.Item.FT.TotCost = decimal.Round(apply.Item.FT.TotCost, 2);
                if (this.Insert(apply) <= 0)
                {
                    this.Err = serviceTerminalConfirm.Err;
                    return Result.Failure;
                }
                Neusoft.HISFC.Models.Terminal.TerminalApply temApply = this.GetItemListBySequence(apply.Order.ID,apply.ID);
                if (temApply == null)
                {
                    this.Err = "划价后获取确认申请单信息失败" + this.Err;
                    return Result.Failure;
                }
                if (temApply.ID == "" || temApply.ID == null || temApply.ID == string.Empty)
                {
                    this.Err = "划价后获取确认申请单信息失败";
                    return Result.Failure;
                }
                temApply.Item.ConfirmedQty = apply.Item.Item.Qty;
                temApply.SpecalFlag = apply.SpecalFlag;
                if (SaveInpatient(temApply, register) == Result.Failure)
                {
                    return Result.Failure;
                }
                #endregion 
            }

            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 保存老项目 
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <param name="register">患者基本信息</param>
        /// <returns>结果</returns>
        public Result SaveOld(Neusoft.HISFC.Models.Terminal.TerminalApply apply, Neusoft.HISFC.Models.Registration.Register register,bool IsExami)
        {
            Neusoft.HISFC.BizProcess.Integrate.Fee serviceFee = new Fee(); 
            if (this.trans != null)
            {
                serviceFee.SetTrans(this.trans);
            }

			if (register.Memo == "2")
			{
				this.Err = "住院患者，请进行住院患者的终端确认!";
				return Result.Failure;
			}
            // 判断是否存在
            if (this.IsExists(apply) == Result.Failure)
            {
                return Result.Failure;
            }
            // 自我更新执行信息
            if (this.Update(apply) == Result.Failure)
            {
                return Result.Failure;
            }
            // 创建业务明细
            if (this.CreateDetail(apply, register) == Result.Failure)
            {
                return Result.Failure;
            }

            //if (apply.SpecalFlag == "1")
            //{
            //    ////{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            //    string errText = string.Empty;

            //    bool resultValue = serviceFee.SaveFeeToAccount(register, apply.Item.RecipeNO, apply.Item.SequenceNO, ref errText);
            //    if (!resultValue)
            //    {
            //        this.Err = errText;
            //        return Result.Failure;
            //    }
            //}


            if (!IsExami)//是集体体检并且是需要划价时插终端确认表
            {
                // 更新费用执行信息
                if (this.UpdateFee(apply) == Result.Failure)
                {
                    return Result.Failure;
                }
            }
            // 更新医嘱执行信息
            if (this.UpdateOrder(apply) == Result.Failure)
            {
                return Result.Failure;
            }
            // 更新体检执行信息
            if (this.UpdatePhysicalExamination(apply) == Result.Failure)
            {
                return Result.Failure;
            }
            // 更新医技预约信息
            if (this.UpdateTerminalBooking(apply) == Result.Failure)
            {
                return Result.Failure;
            }
            // 更新药品出库信息
            if (this.UpdatePharmacyOut(apply) == Result.Failure)
            {
            }
            // 成功返回
            return Result.Success;
        }

		/// <summary>
		/// 保存老项目（住院患者）
		/// </summary>
		/// <param name="apply">终端确认申请单</param>
		/// <param name="register">患者基本信息</param>
		/// <returns>结果</returns>
		public Result SaveInpatient(Neusoft.HISFC.Models.Terminal.TerminalApply apply, Neusoft.HISFC.Models.Registration.Register register)
		{
			if (register.Memo != "2")
			{
				this.Err = "非住院患者，不能进行住院患者的终端确认!";
				return Result.Failure;
			}
            Neusoft.HISFC.BizProcess.Integrate.Fee serviceFee = new Fee();
            // 医嘱流水号 
            if (this.trans != null)
            {
                serviceFee.SetTrans(this.trans);
            }
			// 判断是否存在
			if (this.IsExists(apply) == Result.Failure)
			{
				return Result.Failure;
			}
			// 自我更新执行信息
			if (this.Update(apply) == Result.Failure)
			{
				return Result.Failure;
			}
			// 创建业务明细
			if (this.CreateDetail(apply, register) == Result.Failure)
			{
				return Result.Failure;
			}
			
            if (apply.SpecalFlag == "2")
            {
                //住院患者终端扣费

                #region 构建住院患者实体 
                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = serviceInpatient.QueryPatientInfoByInpatientNO(apply.Patient.PID.ID);
                if (patientInfo == null)
                {
                    this.Err = "获取住院患者信息失败";
                    return Result.Failure;
                }
                #endregion 

                #region 构建住院费用实体 
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply = apply.Clone();
                feeItemList.Item = terminalApply.Item.Item.Clone();
                feeItemList.Item.PriceUnit = terminalApply.Item.Item.PriceUnit;//计价单位
                if (terminalApply.Item.Order.DoctorDept.ID == null || terminalApply.Item.Order.DoctorDept.ID == "")
                {
                    feeItemList.RecipeOper.Dept = CurrentOperEnvironment.Dept;
                }
                else
                {
                    feeItemList.RecipeOper.Dept = terminalApply.Item.Order.DoctorDept;
                }
                if (terminalApply.Item.Order.Doctor.ID == null || terminalApply.Item.Order.Doctor.ID == "")
                {
                    feeItemList.RecipeOper.ID = CurrentOperEnvironment.ID;
                    feeItemList.RecipeOper.Name = CurrentOperEnvironment.Name;
                    feeItemList.ChargeOper = CurrentOperEnvironment;
                }
                else
                {
                    feeItemList.RecipeOper.ID = terminalApply.Item.Order.Doctor.ID;
                    feeItemList.RecipeOper.Name = terminalApply.Item.Order.Doctor.Name;
                    feeItemList.ChargeOper.ID = terminalApply.Item.Order.Doctor.ID;
                    feeItemList.ChargeOper.Name = terminalApply.Item.Order.Doctor.Name;
                }
                feeItemList.ExecOper = CurrentOperEnvironment;
                feeItemList.StockOper.Dept = CurrentOperEnvironment.Dept;//药品的扣库存的科室

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
                feeItemList.FeeOper = CurrentOperEnvironment;
                feeItemList.TransType = TransTypes.Positive;
                #endregion 

                if (serviceFee.FeeItem(patientInfo,feeItemList) <= 0)
                {
                    this.Err = "扣住院费用失败";
                    return Result.Failure;
                }
            }
            else
            {
                // 更新住院费用执行信息
            }
			// 更新住院医嘱执行信息

			// 更新医技预约信息
			if (this.UpdateTerminalBooking(apply) == Result.Failure)
			{
				return Result.Failure;
			}
			// 更新药品出库信息
			if (this.UpdatePharmacyOut(apply) == Result.Failure)
			{
			}
			// 成功返回
			return Result.Success;
		}

        /// <summary>
        /// 判断终端确认项目是否存在
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result IsExists(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
        {
            this.SetDB(serviceTerminalConfirm);
            // 申请单流水号
            string applyNO = "";
            // 获取
            this.intReturn = serviceTerminalConfirm.GetApplyNoByOrderNo(apply.Order.ID, ref applyNO);
            if (intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 更新终端确认申请单


        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result Update(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
        {
            this.SetDB(serviceTerminalConfirm);
            // 更新
            this.intReturn = serviceTerminalConfirm.Update(apply);
            if (intReturn <= 0)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 创建终端确认执行明细
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <param name="register">患者基本信息</param>
        /// <returns>结果</returns>
        public Result CreateDetail(Neusoft.HISFC.Models.Terminal.TerminalApply apply, Neusoft.HISFC.Models.Registration.Register register)
        {
            this.SetDB(serviceTerminalConfirm);
            // 终端确认执行明细
            Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail = new TerminalConfirmDetail();
            // 将申请单信息复制到明细


            detail.Apply = apply;
            // 计算剩余数量
			detail.FreeCount = apply.Item.Item.Qty - apply.Item.ConfirmedQty - apply.AlreadyConfirmCount;
            // 状态标志:0-正常,1-取消,2-退费


            detail.Status.ID = "0";
            // 设置患者基本信息


            detail.Apply.Patient = register;
			detail.Apply.ConfirmOperEnvironment.OperTime = this.GetCurrentDateTime();
            detail.OperInfo = detail.Apply.ConfirmOperEnvironment;
            // 创建业务明细
            this.intReturn = serviceTerminalConfirm.Insert(detail);
            if (intReturn == -1)
            {
                return Result.Failure;
            }
            //  成功返回
            return Result.Success;
        }

        /// <summary>
        /// 更新费用执行信息
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result UpdateFee(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
        {
            this.SetDB(serviceOutpatientFee);

			apply.ConfirmOperEnvironment.OperTime = this.GetCurrentDateTime();
            // 更新
            this.intReturn = serviceOutpatientFee.UpdateConfirmFlag(
                // 处方号


                                                                apply.Item.RecipeNO,
                // 处方内项目流水号
                                                                apply.Item.SequenceNO,
                // 确认标志
                                                                "1",
                // 确认人


                                                                apply.ConfirmOperEnvironment.ID,
                // 确认科室
                                                                apply.Item.ExecOper.Dept.ID,
                // 确认时间
                                                                apply.ConfirmOperEnvironment.OperTime,
                // 剩余数量
                                                                apply.Item.Item.Qty - apply.AlreadyConfirmCount - apply.Item.ConfirmedQty,
                // 已确认数量


                                                                apply.AlreadyConfirmCount + apply.Item.ConfirmedQty);
            if (this.intReturn <= 0)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 更新门诊医嘱执行信息
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result UpdateOrder(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
        {
            if (apply.PatientType == "1" || apply.PatientType == "3")
            {
                this.SetDB(serviceOutpatientOrder);
                // 更新
                //Neusoft.HISFC.Models.RADT.Person person = new Person();
                //person = (Neusoft.HISFC.Models.RADT.Person)apply.ConfirmOperator;
                //this.intReturn = serviceOutpatientOrder.UpdateOrderHaveDone(person, apply.Order.ID);
                //if (intReturn == -1)
                //{
                //    return Result.Failure;
                //}
            }


            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 更新体检执行信息
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result UpdatePhysicalExamination(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
        {
            if (apply.PatientType == "4" || apply.PatientType == "5")
            {
                this.SetDB(servicePERegister);
                // 体检项目实体
                //Neusoft.HISFC.Models.PhysicalExamination.ItemList peItemList = new ItemList();
                //// 赋值


                //peItemList.SequenceNO = apply.Order.ID;
                //peItemList.ConformOper = apply.ConfirmOperEnvironment;
                //peItemList.ConformOper.OperTime = apply.ConfirmOperEnvironment.OperTime; 
                //peItemList.IsConfirm = "2";
                //peItemList.NoBackQty = apply.Item.Item.Qty - apply.AlreadyConfirmCount - apply.Item.ConfirmedQty;
                int NoBackQty = Neusoft.FrameWork.Function.NConvert.ToInt32(apply.Item.Item.Qty - apply.AlreadyConfirmCount - apply.Item.ConfirmedQty);
                // 更新
                this.intReturn = servicePERegister.UpdateConfirmInfo(apply.Order.ID, "2", NoBackQty);
                if (this.intReturn < 0 )
                {
                    return Result.Failure;
                }
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 更新医技预约信息
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result UpdateTerminalBooking(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
        {
            //this.SetDB(serviceTerminalBooking);
            //// 更新
            //this.intReturn = serviceTerminalBooking.UpdateItemConfirm(apply.Order.ID, OperType.Minus);
            //if (this.intReturn == -1)
            //{
            //    return Result.Failure;
            //}
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 更新药品出库信息
        /// </summary>
        /// <param name="apply">终端确认申请单</param>
        /// <returns>结果</returns>
        public Result UpdatePharmacyOut(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
        {
            this.SetDB(serviceDrug);
            // 出库实体
            Neusoft.HISFC.Models.Pharmacy.Output output = new Output();
            // 出库科室编码
            output.StockDept.ID = apply.Item.ExecOper.Dept.ID;
            // 出库分类（门诊发药）
            output.SystemType = "M1";
            // 药品编码
            output.Item.ID = apply.Item.ID;
            // 药品商品名


            output.Item.Name = apply.Item.Name;
            // 药品类别
			output.Item.Type.ID = "";//((Neusoft.HISFC.Models.Pharmacy.Item)(apply.Item.Item)).Type.ID;
            // 药品性质
            output.Item.Quality.ID = "";//((Neusoft.HISFC.Models.Pharmacy.Item)(apply.Item.Item)).Quality.ID;
            // 规格
            output.Item.Specs = apply.Item.Item.Specs;
            // 包装单位
            output.Item.PackUnit = apply.Item.Item.PriceUnit;
            // 包装数


            output.Item.PackQty = apply.Item.Item.PackQty;
            // 最小单位


            output.Item.MinUnit = apply.Item.Item.PriceUnit;
            // 显示的单位标记（0最小单位，1包装单位）


            output.ShowState = "0";
            // 零售价


            output.Item.PriceCollection.RetailPrice = apply.Item.Item.Price;
            // 出库量


            output.Quantity = apply.Item.Item.Qty;
            // 审批数量（扣库存的数量）
            output.Operation.ExamQty = apply.Item.Item.Qty;
            // 审批人（扣库存操作的人）
            output.Operation.ExamOper.ID = apply.ConfirmOperEnvironment.ID;
            // 审批日期（扣库存的时间）
            output.Operation.ExamOper.OperTime = apply.ConfirmOperEnvironment.OperTime;
            // 领药单位编码
            output.TargetDept.ID = apply.Item.ConfirmOper.Dept.ID;
            // 处方号（药房发药出库时必须填写）
            output.RecipeNO = apply.Item.RecipeNO;
            // 处方流水号（药房发药出库时必须填写）
            output.SequenceNO = apply.Item.SequenceNO;
            // 操作时间
            output.Operation.Oper.OperTime = apply.ConfirmOperEnvironment.OperTime;
            // 领药人（患者ID）


            output.GetPerson = apply.Item.Patient.ID;
            // 更新
            this.intReturn = serviceDrug.Output(output);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 更新fin_opb_feedetail中对应医嘱的可退数量
        /// </summary>
        /// <param name="apply"></param>
        /// <returns>结果</returns>
        public Result UpdateNobackNum(string moOrder, string itemCode, decimal cancelNum)
        {
            this.SetDB(serviceTerminalConfirm);

            this.intReturn = serviceTerminalConfirm.UpdateNobackNum(moOrder, itemCode, cancelNum);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        // <summary>
        /// 直接更新met_tec_ta_detail中的已确认数量，将之前的已确认数量存入extend_field3
        /// </summary>
        /// <param name="apply"></param>
        /// <returns>结果</returns>
        public Result UpdateConfirmedQty(string applyID, decimal newConfirmedQty, string oldConfirmedQtyString)
        {
            this.SetDB(serviceTerminalConfirm);

            this.intReturn = serviceTerminalConfirm.UpdateConfirmedQty(applyID, newConfirmedQty, oldConfirmedQtyString);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }


        // <summary>
        /// 直接更新met_tec_ta_detail中的已确认数量，将之前的已确认数量存入extend_field3
        /// </summary>
        /// <param name="apply"></param>
        /// <returns>结果</returns>
        public Result UpdateConfirmedFlag(string applyID, string operCode, string operDate)
        {
            this.SetDB(serviceTerminalConfirm);

            this.intReturn = serviceTerminalConfirm.UpdateConfirmedFlag(applyID, operCode, operDate);
            if (this.intReturn <=0)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        /// <summary>
        /// 住院费用插入终端申请单

        /// </summary>
        /// <param name="inpatientFee">住院费用</param>
        /// <returns>1：成功/-1：失败</returns>
        public int Insert(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList inpatientFee,
                          Neusoft.HISFC.Models.Terminal.InpatientChargeType chargeType)
        {
            this.SetDB(serviceTerminalConfirm);

            return serviceTerminalConfirm.Insert(inpatientFee, chargeType);
        }
    	
    	/// <summary>
    	/// 非住院模块插入终端申请单
    	/// </summary>
		/// <param name="apply">终端申请单</param>
		/// <returns>1：成功/-1：失败</returns>
    	public int Insert(Neusoft.HISFC.Models.Terminal.TerminalApply apply)
    	{
			this.SetDB(serviceTerminalConfirm);

			return serviceTerminalConfirm.Insert(apply);
    	}

        // <summary>
        /// 直接更新met_tec_terminalapply中的已确认数量
        /// </summary>
        /// <param name="apply"></param>
        /// <returns>结果</returns>
        public Result UpdateApplyConfirmQty(string applyID, decimal cancelQty)
        {
            this.SetDB(serviceTerminalConfirm);

            this.intReturn = serviceTerminalConfirm.UpdateApplyConfirmQty(applyID, cancelQty);
            if (this.intReturn == -1)
            {
                return Result.Failure;
            }
            // 成功返回
            return Result.Success;
        }

        #endregion

		#region 提供的外部服务

    	/// <summary>
    	/// 住院患者获取项目的执行数量
    	/// </summary>
    	/// <param name="patient">患者实体</param>
    	/// <param name="fee">费用实体</param>
    	/// <param name="confirmedCount">已经确认执行数量</param>
    	/// <returns>结果</returns>
    	public Result ServiceGetInpatientConfirmInformation(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList fee, ref int confirmedCount)
    	{
    		this.SetDB(serviceTerminalConfirm);
    		// 查询
			this.intReturn = serviceTerminalConfirm.GetInpatientConfirmInformation(patient, fee, ref confirmedCount);
    		if (this.intReturn == -1)
    		{
				return Result.Failure;
    		}
    		else if (this.intReturn == 0)
    		{
				return Result.None;
    		}
    		
			return Result.Success;
    	}
    	/// <summary>
    	/// 住院插入终端确认
    	/// </summary>
        /// <param name="patient">住院病人实体</param>
        /// <param name="fee">住院费用实体</param>
    	/// <returns>操作结果</returns>
        public Result ServiceInsertTerminalApply(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList fee)
        {
            Neusoft.HISFC.Models.Terminal.TerminalApply apply = new TerminalApply();
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemlist = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
            Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();
            register.PID = patient.PID;
            register.PID.ID = patient.PID.ID; //住院流水号

            register.PID.CardNO = patient.PID.CardNO;//卡号
            register.Name = patient.Name;//姓名
            register.Sex = patient.Sex;//性别
            register.Pact.ID = patient.Pact.ID;//合同单位
            feeItemlist.Order.DoctorDept.ID = fee.Order.DoctorDept.ID; //申请部门编码
            feeItemlist.ExecOper.Dept.ID = fee.ExecOper.Dept.ID;//终端科室编码
            register.DoctorInfo.Templet.Dept.ID = patient.PVisit.PatientLocation.Dept.ID;//在院科室
            feeItemlist.RecipeOper.ID = fee.RecipeOper.ID;//开立医生

            feeItemlist.RecipeNO = fee.RecipeNO;//处方号

            feeItemlist.SequenceNO = fee.SequenceNO;//处方内项目流水号
            apply.Item.RecipeOper.ID = fee.RecipeOper.ID;//开立医师代码


            #region item
            apply.Item.Item.ID = fee.Item.ID;// 项目代码 
            apply.Item.Item.Name = fee.Item.Name;// 项目名称 
            apply.Item.Item.Price = fee.Item.Price;// 单价 
            apply.Item.Item.Qty = fee.Item.Qty;// 数量 
            apply.Item.Item.PriceUnit = fee.Item.PriceUnit;// 当前单位 
            apply.Item.UndrugComb.ID = fee.UndrugComb.ID; // 组套代码 
            apply.Item.UndrugComb.Name = fee.UndrugComb.Name;// 组套名称 
            apply.Item.FT.TotCost = fee.FT.TotCost;// 费用金额 
            feeItemlist.Item = fee.Item;
            #endregion 

            apply.Order = fee.Order;
            feeItemlist.Order.ID = fee.Order.ID;//医嘱流水号 
            apply.IsValid = true;
            apply.Patient = register;
            apply.Item = feeItemlist; 
            apply.InsertOperEnvironment.OperTime = fee.FeeOper.OperTime;
            apply.InsertOperEnvironment.ID = fee.FeeOper.ID;
            //apply.PatientType = register.ChkKind.Length > 0 ? "4" : "1";//有待商讨
            apply.PatientType = "2";//住院

            if (serviceTerminalConfirm.Insert(apply) == -1)
            {
                return Result.Failure;
            }
            return Result.Success;
        }
    	/// <summary>
        /// 插入终端确认
    	/// </summary>
    	/// <param name="fee">门诊费用</param>
		/// <param name="register">门诊患者实体</param>
    	/// <returns>操作结果</returns>
    	public Result ServiceInsertTerminalApply(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList fee, Neusoft.HISFC.Models.Registration.Register register)
		{
			this.SetDB(serviceTerminalConfirm);
    		// 终端确认申请单实体

    		Neusoft.HISFC.Models.Terminal.TerminalApply apply = new TerminalApply();

			apply.Item = fee;
			apply.Patient = register;
            //apply.InsertOperEnvironment.OperTime = fee.FeeOper.OperTime;
            //apply.InsertOperEnvironment.ID = fee.FeeOper.ID;

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            //if (register.IsAccount)
            //{
            //    apply.InsertOperEnvironment.ID = fee.ChargeOper.ID;
            //    apply.InsertOperEnvironment.OperTime = fee.ChargeOper.OperTime;
            //    apply.ItemStatus = "0";
            //    apply.Item.FT.TotCost = apply.Item.FT.OwnCost;

            //}
            //else
            //{
                apply.InsertOperEnvironment.ID = fee.FeeOper.ID;
                apply.InsertOperEnvironment.OperTime = fee.FeeOper.OperTime;
            //}

            apply.PatientType = register.ChkKind.Length > 0 ? "4" : "1";//有待商讨
			apply.Order = fee.Order;

    		// 插入或更新

			if (serviceTerminalConfirm.Insert(apply) == -1)
			{
				return Result.Failure;
			}

    		// 成功返回
    		return Result.Success;
    	}
    	
		#endregion

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户
        /// <summary>
        /// 删除有效的申请数据
        /// </summary>
        /// <param name="recipeNO">处方序号</param>
        /// <param name="recipeSequenceNO">处方内项目流水号</param>
        /// <returns></returns>
        public int DelTecApply(string recipeNO, string recipeSequenceNO)
        {
            this.SetDB(serviceTerminalConfirm);
            return serviceTerminalConfirm.DelTecApply(recipeNO, recipeSequenceNO);
        }
        #endregion
	}

    /// <summary>
    /// 结果
    /// </summary>
    public enum Result
    {
        /// <summary>
        /// 失败
        /// </summary>
        Failure = -1,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 对数据无影响
        /// </summary>
        None = 0
    }
}