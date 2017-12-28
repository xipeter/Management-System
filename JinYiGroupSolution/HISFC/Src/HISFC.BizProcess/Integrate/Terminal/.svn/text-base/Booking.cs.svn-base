using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.BizLogic.Fee;
using Neusoft.HISFC.BizLogic.Manager;
using Neusoft.HISFC.BizLogic.Registration;
using Neusoft.HISFC.BizLogic.Terminal;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.FrameWork.Models;
using Department=Neusoft.HISFC.BizLogic.Manager.Department;
using DeptItem=Neusoft.HISFC.BizLogic.Manager.DeptItem;
using InPatient=Neusoft.HISFC.BizLogic.RADT.InPatient;
using Item=Neusoft.HISFC.BizLogic.Fee.Item;
using Spell=Neusoft.HISFC.BizLogic.Manager.Spell;

namespace Neusoft.HISFC.BizProcess.Integrate.Terminal
{
	public class Booking : IntegrateBase
	{
		/// <summary>
		/// 构造函数

		/// </summary>
		public Booking()
		{
			
		}

		/// <summary>
		/// 带事务的构造函数

		/// </summary>
		/// <param name="trans">事务</param>
		public Booking(System.Data.IDbTransaction trans)
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
		/// 当前操作环境
		/// </summary>
		public static Neusoft.HISFC.Models.Base.OperEnvironment CurrentOperEnvironment = new OperEnvironment();
		
		/// <summary>
		/// 医技预约业务层

		/// </summary>
        protected Neusoft.HISFC.BizLogic.Terminal.Terminal serviceTerminal = new Neusoft.HISFC.BizLogic.Terminal.Terminal();
		
		/// <summary>
		/// 医技预约排班模板业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Terminal.MedTechItemTemp serviceMedTechItemTemp = new MedTechItemTemp();
		
		/// <summary>
		/// 医技预约排班业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Terminal.MedTechItemArray serviceMedTechItemArray = new MedTechItemArray();
		
		/// <summary>
		/// 医技预约业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Terminal.MedTechItemBook serviceMedTechItemBook = new MedTechItemBook();
		
		/// <summary>
		/// 人员管理业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Manager.Person serviceEmployee = new Person();
		
		/// <summary>
		/// 组套管理业务层 
		/// </summary>
        //protected static Neusoft.HISFC.BizLogic.Fee.UndrugComb serviceUndrugComb = new UndrugComb();
		
		/// <summary>
		/// 科室管理业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Manager.Department serviceDept = new Department();
		
		/// <summary>
		/// 常数管理业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Manager.Constant serviceConstant = new Constant();
		
		/// <summary>
		/// 午别业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Registration.DoctSchema serviceDoctSchema = new DoctSchema();
		
		/// <summary>
		/// 首拼码业务层
		/// </summary>
		protected Neusoft.HISFC.BizLogic.Manager.Spell serviceSpell = new Spell();
		
		/// <summary>
		/// 非药品业务层
		/// </summary>
		protected Neusoft.HISFC.BizLogic.Fee.Item serviceUndrug = new Item();
		
		/// <summary>
		/// 挂号业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.Registration.Register serviceRegister = new Register();
		
		/// <summary>
		/// 住院业务层

		/// </summary>
		protected Neusoft.HISFC.BizLogic.RADT.InPatient serviceInpatient = new InPatient();
		
		/// <summary>
		/// 门诊收费业务层

		/// </summary>
        //protected static Neusoft.HISFC.BizLogic.Fee.Outpatient serviceOutpatient = new Outpatient();

		/// <summary>
		/// 科常用业务层
		/// </summary>
		public Neusoft.HISFC.BizLogic.Manager.DeptItem serviceDeptItem = new DeptItem();
        /// <summary>
        /// 体检主信息

        /// </summary>
        public Neusoft.HISFC.BizLogic.PhysicalExamination.Register registerMgr = new Neusoft.HISFC.BizLogic.PhysicalExamination.Register();

        /// 医技设备业务层
        /// {250AAC5B-EC56-4e2e-B51A-8427AAFC9740}
        /// </summary>
        public Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier serviceCarrier = new TerminalCarrier();

		#endregion

		#region 私有函数

		/// <summary>
		/// 获取当前操作环境
		/// </summary>
		protected void GetEnvironment()
		{
			CurrentOperEnvironment.ID = serviceTerminal.Operator.ID;
			CurrentOperEnvironment.Name = serviceTerminal.Operator.Name;
			CurrentOperEnvironment.Dept = ((Neusoft.HISFC.Models.Base.Employee)serviceTerminal.Operator).Dept;
			CurrentOperEnvironment.OperTime = serviceTerminal.GetDateTimeFromSysDateTime();
		}

		#endregion

		#region 公共函数
        #region 作废医技预约申请主表
        /// <summary>
        /// 根据医嘱流水号和项目号作废终端确认 
        /// </summary>
        /// <param name="MoOrder">医嘱流水号</param>
        /// <param name="ItemCode">项目编码</param>
        /// <returns></returns> 
        public int CancelConfirmApply(string MoOrder, string ItemCode)
        {
            this.SetDB(serviceTerminal);
            return serviceTerminal.DeleteMedTechBookApply(MoOrder);
        }
        #endregion

        /// <summary>
        /// 更新 更新医技预约表 的数量 如果可退数量 等于 收费数量 则删除

        /// </summary>
        /// <param name="MoOrder"></param>
        /// <param name="Qty"></param>
        /// <param name="BackQty"></param>
        /// <returns></returns>
        public int UpdateOrDeleteMedTechApply(string MoOrder, int Qty, int BackQty)
        {
            this.SetDB(serviceTerminal);
            if (Qty == BackQty)
            {
                return serviceTerminal.DeleteMedTechBookApply(MoOrder);
            }
            else
            {
                return serviceTerminal.UpdateMedTechApplyByMoOrder(MoOrder, BackQty);
            }
        }

		/// <summary>
		/// 设置事务对象
		/// </summary>
		/// <param name="trans">数据库事务</param>
		public override void SetTrans(System.Data.IDbTransaction trans)
		{
			this.trans = trans;

			serviceTerminal.SetTrans(trans);
			serviceMedTechItemArray.SetTrans(trans);
			serviceMedTechItemBook.SetTrans(trans);
			serviceMedTechItemTemp.SetTrans(trans);
			serviceEmployee.SetTrans(trans);
			serviceDept.SetTrans(trans);
			serviceConstant.SetTrans(trans);
			serviceDoctSchema.SetTrans(trans);
			serviceSpell.SetTrans(trans);
			serviceUndrug.SetTrans(trans);
			serviceRegister.SetTrans(trans);
			serviceInpatient.SetTrans(trans);
			serviceDeptItem.SetTrans(trans);
            registerMgr.SetTrans(trans);
		}

		/// <summary>
		/// 获取当前时间
		/// </summary>
		/// <returns>当前时间</returns>
		public System.DateTime GetCurrentDateTime()
		{
			return serviceTerminal.GetDateTimeFromSysDateTime();
		}


        /// <summary>
		/// 删除预约信息
		/// </summary>
		/// <param name="sequenceNO">医技预约流水号</param>
		/// <returns>-1 出错 1 删除成功</returns>
        public int DeleteMedTechBookApply(string sequenceNO)
        {
            this.SetDB(serviceTerminal);
            return serviceTerminal.DeleteMedTechBookApply(sequenceNO);
        }
		#endregion

		#region 查询获取
		
		/// <summary>
		/// 获取指定科室的常用项目

		/// </summary>
		/// <param name="deptItemList">指定科室的常用项目</param>
		/// <param name="deptCode">科室</param>
		/// <returns>结果</returns>
		public Result QueryDeptItem(ref ArrayList deptItemList, string deptCode)
		{
			this.SetDB(serviceDeptItem);
			// 获取
			deptItemList = serviceDeptItem.QueryItemByDeptID(deptCode);
			
			return Result.Success;
		}

		/// <summary>
		/// 获取预约项目信息
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="itemCode">项目编码</param>
		/// <returns>预约项目信息</returns>
		public Neusoft.HISFC.Models.Terminal.MedTechItem GetMedTechItem(string deptCode, string itemCode)
		{
			this.SetDB(serviceTerminal);
			
			return serviceTerminal.GetMedTechItem(deptCode, itemCode);
		}
		
		
		/// <summary>
		/// 获取操作员信息

		/// </summary>
		/// <param name="employeeID">操作员编码</param>
		/// <returns>操作员信息</returns>
		public Neusoft.HISFC.Models.Base.Employee GetEmployee(string employeeID)
		{
			this.SetDB(serviceTerminal);
			
			return serviceEmployee.GetPersonByID(employeeID);
		}
		
		/// <summary>
		/// 获取组套信息
		/// </summary>
		/// <param name="combID">组套ID</param>
		/// <returns>组套信息</returns>
        [Obsolete("作废,复合项目已归并到非药品", true)]
		public Neusoft.HISFC.Models.Fee.Item.UndrugComb GetUndrugCombByCode(string combID)
		{
            Neusoft.HISFC.Models.Fee.Item.UndrugComb com = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
            return com;
		}
		
		/// <summary>
		/// 获取所有科室

		/// </summary>
		/// <returns>所有科室</returns>
		public ArrayList GetDeptmentAll()
		{
			this.SetDB(serviceDept);

			return serviceDept.GetDeptmentAll();
		}
		
		/// <summary>
		/// 获取科室的预约项目

		/// </summary>
		/// <param name="deptCode">科室</param>
		/// <returns>预约项目</returns>
		public ArrayList QueryMedTechItem(string deptCode)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.QueryMedTechItem(deptCode);
		}
		
		/// <summary>
		/// 获取常数
		/// </summary>
		/// <param name="constType">常数类别</param>
		/// <param name="constID">常数编码</param>
		/// <returns>常数</returns>
		public NeuObject GetConstant(string constType, string constID)
		{
			this.SetDB(serviceConstant);

			return serviceConstant.GetConstant(constType, constID);
		}

		/// <summary>
		/// 获取常数
		/// </summary>
		/// <param name="typeCode">常数类别编码</param>
		/// <returns>常数</returns>
		public ArrayList GetAllList(string typeCode)
		{
			this.SetDB(serviceConstant);

			return serviceConstant.GetAllList(typeCode);
		}

		/// <summary>
		/// 获取午别
		/// </summary>
		/// <returns>午别</returns>
		public ArrayList DoctSchemaQuery()
		{
			this.SetDB(serviceDoctSchema);

			return serviceDoctSchema.Query();
		}
		
		/// <summary>
		/// 获取科室排班模板
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="week">星期</param>
		/// <returns>科室排班模板</returns>
		public ArrayList QueryTemp(string deptCode, string week)
		{
			this.SetDB(serviceMedTechItemTemp);

			return serviceMedTechItemTemp.QueryTemp(deptCode, week);
		}

		/// <summary>
		/// 获取拼音码

		/// </summary>
		/// <param name="name">名称</param>
		/// <returns>拼音码</returns>
		public Neusoft.HISFC.Models.Base.Spell GetSpell(string name)
		{
			this.SetDB(serviceSpell);
			
			return (Neusoft.HISFC.Models.Base.Spell)serviceSpell.Get(name);
		}
		
		/// <summary>
		/// 查询该科室一日排班记录

		/// </summary>
		/// <param name="deptCode">科室</param>
		/// <param name="bookDate">日期</param>
		/// <returns>科室一日排班记录</returns>
		public ArrayList QueryArrange(string deptCode, string bookDate)
		{
			this.SetDB(serviceMedTechItemArray);

			return serviceMedTechItemArray.QueryItem(deptCode, bookDate);
		}
		
		/// <summary>
		/// 获取预约信息
		/// </summary>
		/// <param name="orderID">医嘱流水号</param>
		/// <returns>预约信息</returns>
		public ArrayList QueryTerminalApply(string orderID)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.QueryTerminalApply(orderID);
		}
		
		/// <summary>
		/// 获取非药品信息

		/// </summary>
		/// <param name="code">编码</param>
		/// <returns>非药品信息</returns>
		public Neusoft.HISFC.Models.Fee.Item.Undrug GetValidItemByUndrugCode(string code)
		{
			this.SetDB(serviceUndrug);

			return serviceUndrug.GetValidItemByUndrugCode(code);
		}
		
		/// <summary>
		/// 获取项目排班表项目具体信息 
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="beginDate">起始日期</param>
		/// <param name="endDate">结束日期</param>
		/// <param name="itemCode">项目编码</param>
		/// <param name="noonID">午别编码</param>
		/// <returns>出错返回null</returns>
		public ArrayList QuerySchema(string deptCode, System.DateTime beginDate, System.DateTime endDate, string itemCode, string noonID)
		{
			this.SetDB(serviceMedTechItemArray);

			return serviceMedTechItemArray.QuerySchema(deptCode, beginDate, endDate, itemCode, noonID);
		}
		
		/// <summary>
		/// 获取患者挂号信息

		/// </summary>
		/// <param name="clinicNO">门诊号</param>
		/// <returns>患者挂号信息</returns>
        public Neusoft.HISFC.Models.Registration.Register GetByClinic(string clinicNO)
        {
            this.SetDB(serviceRegister);
            Neusoft.HISFC.Models.Registration.Register objReg = new Neusoft.HISFC.Models.Registration.Register();
            objReg = serviceRegister.GetByClinic(clinicNO);
            if (objReg.ID == null || objReg.ID.Length == 0)
            {
                Neusoft.HISFC.Models.PhysicalExamination.Register examiObj = registerMgr.GetRegisterByClinicNO(clinicNO);
                if (examiObj.ID != "")
                {
                    #region  赋值

                    objReg.ID = examiObj.ID;
                    objReg.Name = examiObj.Name;
                    objReg.Sex.ID = examiObj.Sex.ID;
                    objReg.MaritalStatus.ID = examiObj.MaritalStatus.ID;
                    objReg.Country.ID = examiObj.Country.ID;
                    objReg.Age = examiObj.Age;
                    objReg.Birthday = examiObj.Birthday;
                    #endregion
                }
            }
            return objReg;
        }
		
		/// <summary>
		/// 获取患者住院信息

		/// </summary>
		/// <param name="inpatientNO">住院号</param>
		/// <returns>患者住院信息</returns>
		public Neusoft.HISFC.Models.RADT.PatientInfo QueryPatientInfoByInpatientNO(string inpatientNO)
		{
			this.SetDB(serviceInpatient);

			return serviceInpatient.QueryPatientInfoByInpatientNO(inpatientNO);
		}
		
		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="execDept">执行科室</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <param name="clinicN0">门诊号或卡号</param>
		/// <param name="codeType">修饰 ClinicN0 1 卡号 2 门诊号</param>
		/// <returns>病人预约项目信息</returns>
		public System.Collections.ArrayList QueryMedTechApplyList(string execDept, System.DateTime beginDate, System.DateTime endDate, string clinicN0, string codeType)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.QueryMedTechApplyList(execDept, beginDate, endDate, clinicN0, codeType);
		}
		
		/// <summary>
		/// 查询 病人预约项目信息 
		/// </summary>
		/// <param name="execDept">执行科室</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <param name="clinicN0">门诊号或卡号</param>
		/// <param name="codeType">修饰 ClinicN0 1 卡号 2 门诊号</param>
		/// <returns>病人预约项目信息</returns>
		public System.Collections.ArrayList QueryMedTechApplyDetailList(string execDept, System.DateTime beginDate, System.DateTime endDate, string clinicN0, string codeType)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.QueryMedTechApplyDetailList(execDept, beginDate, endDate, clinicN0, codeType);
		}
				
		/// <summary>
		/// 获取项目排班表项目具体信息

		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="beginDate">起始日期</param>
		/// <param name="endDate">结束日期</param>
		/// <param name="itemCode">项目编码</param>
		/// <param name="dsSchema"></param>
		/// <returns>出错返回-1</returns>
		public int QuerySchema(string deptCode, System.DateTime beginDate, System.DateTime endDate, string itemCode, ref System.Data.DataSet dsSchema)
		{
			this.SetDB(serviceMedTechItemArray);

			return serviceMedTechItemArray.QuerySchema(deptCode, beginDate, endDate, itemCode, ref dsSchema);
		}
		
		/// <summary>
		/// 查询 病人预约项目信息
		/// </summary>
		/// <param name="exeDept">执行科室</param>
		/// <param name="noonID">午别</param>
		/// <param name="itemComparison">项目号</param>
		/// <param name="beginDate">开始时间</param>
		/// <param name="endDate">结束时间</param>
		/// <returns></returns>
		public System.Collections.ArrayList QueryMedTechApplyDetailList(string exeDept, string noonID, string itemComparison, System.DateTime beginDate, System.DateTime endDate)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.QueryMedTechApplyDetailList(exeDept, noonID, itemComparison, beginDate, endDate);
		}
		
		/// <summary>
		/// 获取年龄
		/// </summary>
		/// <param name="birthday">出生日期</param>
		/// <returns>年龄</returns>
		public string GetAge(System.DateTime birthday)
		{
			this.SetDB(serviceRegister);

			return serviceRegister.GetAge(birthday);
		}

		/// <summary>
		/// 查询已终端确认信息 跟目前已安排数量 由次判断是否可以取消一条预约安排

		/// </summary>
		/// <param name="medTechBookApply"></param>
		/// <returns>1 可以取消  0 不可以取消 －1 查询出错</returns>
		public int IsCanCancelMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.IsCanCancelMedTechBookApply(medTechBookApply);
		}

        /// <summary>
        /// 获取科室的设备
        /// </summary>
        /// <param name="deptCode">科室</param>
        /// <returns>设备</returns>
        public ArrayList QueryMedTechEquipment ( string deptCode )
        {
            this.SetDB ( serviceTerminal );

            return serviceTerminal.QueryMedTechEquipment ( deptCode );
        }

        /// <summary>
        /// 获取科室的大型设备
        /// {250AAC5B-EC56-4e2e-B51A-8427AAFC9740}
        /// </summary>
        /// <param name="deptCode">科室 'ALL'所有科室</param>
        /// <param name="isLarge">是否大型设备 '1'是'0'否'ALL'不管是不是</param>
        /// <returns>设备</returns>
        //public ArrayList QueryMedTechEquipment(string deptCode, string isLarge)
        //{
        //    this.SetDB(serviceCarrier);

        //    return serviceCarrier.GetLargeDesigns(deptCode, isLarge);
        //}
		
		#endregion

		#region 数据更新

		/// <summary>
		/// 插入医技预约项目
		/// </summary>
		/// <param name="medTechItem">医技预约项目</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int InsertMedTechItem(Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.InsertMedTechItem(medTechItem);
		}

		/// <summary>
		/// 更新医技预约项目
		/// </summary>
		/// <param name="medTechItem">医技预约项目</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int UpdateMedTechItem(Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.UpdateMedTechItem(medTechItem);
		}
		
		/// <summary>
		/// 删除医技预约
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="itemCode">项目编码</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int DeleteMedTechItem(string deptCode, string itemCode)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.DeleteMedTechItem(deptCode, itemCode);
		}
		
		/// <summary>
		/// 插入医技预约模板
		/// </summary>
		/// <param name="medTechItemTemp">医技预约模板</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int InsertMedTechItemTemp(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			this.SetDB(serviceMedTechItemTemp);

			return serviceMedTechItemTemp.Insert(medTechItemTemp);
		}

		/// <summary>
		/// 删除医技预约模板
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="itemCode">项目编码</param>
		/// <param name="week">星期</param>
		/// <param name="noon">午别</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int DeleteMedTechItemTemp(string deptCode, string itemCode, string week, string noon)
		{
			this.SetDB(serviceMedTechItemTemp);

			return serviceMedTechItemTemp.Delete(deptCode, itemCode, week, noon);
		}

		/// <summary>
		/// 更新医技预约模板
		/// </summary>
		/// <param name="medTechItemTemp">医技预约模板</param>
		/// <returns>－1－失败；影响的行数</returns>
        [Obsolete("否决,该函数没有被引用,修改人路志鹏",true)]
		public int UpdateMedTechItemTemp(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			this.SetDB(serviceMedTechItemTemp);

			return serviceMedTechItemTemp.Update(medTechItemTemp);
		}
		
		/// <summary>
		/// 插入医技预约排班
		/// </summary>
		/// <param name="medTechItemTemp">医技预约模板</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int InsertMedTechItemArrange(Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp)
		{
			this.SetDB(serviceMedTechItemArray);

			return serviceMedTechItemArray.Insert(medTechItemTemp);
		}
		
		/// <summary>
		/// 删除医技预约排班
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="itemCode">项目编码</param>
		/// <param name="bookDate">时间</param>
		/// <param name="noon">午别</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int DeleteMedTechItemArrange(string deptCode, string itemCode, string bookDate, string noon)
		{
			this.SetDB(serviceMedTechItemArray);

			return serviceMedTechItemArray.Delete(deptCode, itemCode, bookDate, noon);
		}

		/// <summary>
		/// 预约安排 
		/// </summary>
		/// <param name="medTechBookApply">医技预约申请</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int PlanMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.PlanMedTechBookApply(medTechBookApply);
		}
		
		/// <summary>
		/// 插入医技预约安排明细表

		/// </summary>
		/// <param name="medTechBookApply">医技预约安排明细</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int InsertMedTechApplyDetailInfo(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.InsertMedTechApplyDetailInfo(medTechBookApply);
		}
		
		/// <summary>
		/// 更新 met_tec_apply的已安排数量
		/// </summary>
		/// <param name="applyNum">已安排数量</param>
		/// <param name="tempMedTechBookApply">医技预约</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int UpdateApplyNum(int applyNum, Neusoft.HISFC.Models.Terminal.MedTechBookApply tempMedTechBookApply)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.UpdateApplyNum(applyNum, tempMedTechBookApply);
		}
		
		/// <summary>
		/// 更新预约限额
		/// </summary>
		/// <param name="tempMedTechItemTemp">预约模板</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int UpdateItemBookingNumber(Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp)
		{
			this.SetDB(serviceMedTechItemArray);

			return serviceMedTechItemArray.UpdateItemBookingNumber(tempMedTechItemTemp);
		}
		
		/// <summary>
		/// 医技预约取消
		/// </summary>
		/// <param name="medTechBookApply">医技预约申请</param>
		/// <returns>－1－失败；影响的行数</returns>
		public int CancelMedTechBookApply(Neusoft.HISFC.Models.Terminal.MedTechBookApply medTechBookApply)
		{
			this.SetDB(serviceTerminal);

			return serviceTerminal.CancelMedTechBookApply(medTechBookApply);
		}
		
		#endregion

		#region 外部服务
        /// <summary>
        /// 住院医技预约
        /// </summary>
        /// <param name="fee">住院收费实体</param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList fee)
        {
            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
            feeItem.ID = fee.ID;//住院流水号

            feeItem.Patient.PID.CardNO = fee.Patient.PID.PatientNO;//住院号

            if (fee.Name == null || fee.Name == "")
            {
                feeItem.Name = fee.Patient.Name;//姓名
            }
            else
            {
                feeItem.Name = fee.Name;//姓名
            }
            feeItem.Item.ID = fee.Item.ID; //项目编码
            feeItem.Item.Name = fee.Item.Name;//项目名称 
            feeItem.Item.Qty = fee.Item.Qty;//项目数量
            feeItem.RecipeNO = fee.RecipeNO;//处方号

            feeItem.SequenceNO = fee.SequenceNO;//处方内序号

            feeItem.Order.DoctorDept.Name = fee.Order.DoctorDept.Name;//开单科室

            feeItem.ExecOper.Dept.ID = fee.Order.ExecOper.Dept.ID; //执行科室
            feeItem.ExecOper.Dept.Name  = fee.ExecOper.Dept.Name; //执行科室
            feeItem.Order.DoctorDept.ID = fee.Order.DoctorDept.ID;//操作科室
            feeItem.Order.ID = fee.Order.ID;//医嘱流水号

            this.SetDB(serviceTerminal);
            return  Insert(feeItem);
        }
		/// <summary>
		/// 插入医技预约信息
		/// </summary>
		/// <param name="feeItem">门诊费用实体</param>
		/// <returns>1－成功；－1－失败</returns>
		public int Insert(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem)
		{
			this.SetDB(serviceTerminal);

			this.intReturn = serviceTerminal.MedTechApply(feeItem);

			if (this.intReturn == -1)
			{
				return -1;
			}

			return 1;
		}
		
		#endregion
	}
}
