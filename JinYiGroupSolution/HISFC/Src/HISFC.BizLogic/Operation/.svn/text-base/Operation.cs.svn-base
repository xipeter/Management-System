using System;
using Neusoft.HISFC.Models;
using System.Collections;
using System.Collections.Generic;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.BizLogic.Operation
{
	#region 手术管理业务描述
	//手术管理包括下列业务：
	//手术人员排班、手术正台分配、手术申请、手术室更换、手术安排
	//麻醉安排、收费模板维护、手术麻醉批费、手术退费、手术登记、麻醉登记、手术取消
	//业务处理对象：
	//手术申请、手术安排、手术取消 业务实际是处理手术申请单类的信息
	//手术登记 业务实际是处理手术登记记录类的信息
	//麻醉登记 业务实施是处理麻醉登记记录类的信息
	//手术麻醉批费、手术退费 业务实际是调用费用接口处理费用
	//收费模板维护 业务实际是调用通用模板类维护本类型模板
	//手术人员安排 业务实际是调用通用排班类维护本类型排班信息
	//手术正台分配 业务实际是处理手术台类信息
	#endregion
	/// [功能描述: 手术管理类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-28]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public abstract class Operation : Neusoft.FrameWork.Management.Database
	{
		public Operation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

#region 字段

		private OperationRoleEnumService roleType = new OperationRoleEnumService();
		private Neusoft.HISFC.BizLogic.Operation.OpsTableManage TableManage = new OpsTableManage();

#endregion		
        /// <summary>
		/// 手术人员排班
		/// </summary>
		/// <param name=""></param>
		/// <returns>0 success -1 fail</returns>
		public int PlanOperator()
		{
			return 0;
		}
		
		#region 获取手术申请单信息
        /// <summary>
        /// 获取主要SQL 
        /// </summary>
        /// <returns></returns>
        private string GetOperationSql()
        {
            string strSql = string.Empty;
            if (this.Sql.GetSql("Operator.Operator.Select.2", ref strSql) == -1)
            {
                return null;
            }
            return strSql;
        }
		/// <summary>
		/// 根据手术序号获得手术申请单
		/// </summary>
		/// <param name="OperatorNo">手术序号</param>
		/// <returns>手术申请单对象</returns>
		public Neusoft.HISFC.Models.Operation.OperationAppllication GetOpsApp(string operationNo)
		{
			Neusoft.HISFC.Models.Operation.OperationAppllication opsApp = new Neusoft.HISFC.Models.Operation.OperationAppllication();
			ArrayList myAl = new ArrayList();
			//业务规则：遴选出手术时间小于给定时间的所有有效的已进行过手术安排的手术申请单。			
            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
			}

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.0",ref strSqlwhere) == -1) 
			{
				return opsApp;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,operationNo);
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operation.Operation.GetOpsApp";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return opsApp;            
			}			

			strSql = strSql + " \n" + strSqlwhere;
			myAl =  this.GetOpsAppListFromSql(strSql);
			//myAl中应该只有一个元素
			if(myAl.Count == 0)
			{
				return null;
			}
			
			opsApp = myAl[0] as Neusoft.HISFC.Models.Operation.OperationAppllication;
			

			return opsApp;
		}
		/// <summary>
		/// 获取患者的手术申请单信息
		/// </summary>
		/// <param name="PatientInfo">患者对象</param>
		/// <param name="Pasource">手术类型1门诊2住院</param>
		/// <param name="endTime">查询截至时间</param>
		/// <returns>患者的手术申请单对象数组</returns>
		public ArrayList GetOpsAppList(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo,string Pasource,string endTime)
		{			
			if(PatientInfo == null)
			{
				return null;	//传入的患者对象为空
			}

			ArrayList myAl = new ArrayList();

			//业务规则：遴选出该患者手术时间小于给定时间的所有有效的未做的手术申请单。

			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.1",ref strSql) == -1) 
			{
				return myAl;
			}

			try
			{
				switch(Pasource)
				{
					case "1":
						//strSql = string.Format(strSql,PatientInfo.Patient.PID.CardNo,Pasource,endTime);
						strSql = string.Format(strSql,PatientInfo.ID.ToString(),Pasource,endTime);
						break;
					case "2":
						//患者住院流水号赋值			
						//PatientInfo.Patient.ID = this.GetInPatientNo(PatientInfo.Patient.PID.ID.ToString());
						//strSql = string.Format(strSql,PatientInfo.Patient.PID.PatientNo,Pasource,endTime);
						strSql = string.Format(strSql,PatientInfo.ID.ToString(),Pasource,endTime);
						break;
				}
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsAppList 1";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OperationAppllication opsApplication = new Neusoft.HISFC.Models.Operation.OperationAppllication();
					
					opsApplication.ID = Reader[0].ToString();										//手术序号					
					try
					{
						opsApplication.OperationDoctor.ID = Reader[1].ToString();					//手术医生
						// by zlw 2006-5-24
						opsApplication.User01 = Reader[1].ToString();	//手术医生所在科室
					}
					catch{}
					
					opsApplication.GuideDoctor.ID = Reader[2].ToString();											//指导医生	

					opsApplication.PreDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[3].ToString());		//手术预约时间					
					try
					{
						opsApplication.Duration = System.Convert.ToDecimal(Reader[4].ToString());					//手术预定用时					
					}
					catch{}
					opsApplication.AnesType.ID = Reader[5].ToString();												//麻醉类型

					opsApplication.ExeDept.ID = Reader[6].ToString();												//执行科室

					opsApplication.OperateRoom = opsApplication.ExeDept as Neusoft.HISFC.Models.Base.Department;	//手术室(对于需要填申请单的手术来说，手术室即执行科室)

					opsApplication.TableType = Reader[7].ToString();					//0正台1加台2点台					
					
					opsApplication.ApplyDoctor.ID = Reader[8].ToString();				//申请医生

					
					opsApplication.ApplyDoctor.Dept.ID = Reader[9].ToString();//申请科室
					
					opsApplication.ApplyDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());	//申请时间
					opsApplication.ApplyNote = Reader[11].ToString();					//申请备注					

					opsApplication.ApproveDoctor.ID = Reader[12].ToString();//审批医生					

					opsApplication.ApproveDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[13].ToString());	//审批时间
					opsApplication.ApproveNote = Reader[14].ToString();					//审批备注
					opsApplication.OperationType.ID = Reader[15].ToString();				//手术规模
					opsApplication.InciType.ID = Reader[16].ToString();					//切口类型					
					
					string strGerm = Reader[17].ToString();						//1 有菌 0无菌
					opsApplication.IsGermCarrying = Neusoft.FrameWork.Function.NConvert.ToBoolean(strGerm);
					
					opsApplication.ScreenUp = Reader[18].ToString();					//1 幕上 2 幕下					
					opsApplication.BloodType.ID = Reader[19].ToString();				//血液成分					
					try
					{
						opsApplication.BloodNum =  System.Convert.ToDecimal(Reader[20].ToString());		//血量
					}
					catch{}
					opsApplication.BloodUnit = Reader[21].ToString();					//用血单位
					opsApplication.OpsNote = Reader[22].ToString();						//手术注意事项
					opsApplication.AneNote = Reader[23].ToString();						//麻醉注意事项				
					opsApplication.ExecStatus = Reader[24].ToString();					//1手术申请 2 手术审批 3手术安排 4手术完成
					
					
					string strFinished = Reader[25].ToString();					//0未做手术/1已做手术
					opsApplication.IsFinished = Neusoft.FrameWork.Function.NConvert.ToBoolean(strFinished);
					
					
					string strAnesth = Reader[26].ToString();					//0未麻醉/1已麻醉
					opsApplication.IsAnesth = Neusoft.FrameWork.Function.NConvert.ToBoolean(strAnesth);
					
					opsApplication.Folk = Reader[27].ToString();						//签字家属
					opsApplication.RelaCode.ID = Reader[28].ToString();					//家属关系
					opsApplication.FolkComment = Reader[29].ToString();					//家属意见
					
					try
					{
						string strUrgent = Reader[30].ToString();					//加急手术,1是/0否
						opsApplication.IsUrgent = Neusoft.FrameWork.Function.NConvert.ToBoolean(strUrgent);
					}
					catch{}
					try
					{
						string strChange = Reader[31].ToString();					//1病危/0否
						opsApplication.IsChange = Neusoft.FrameWork.Function.NConvert.ToBoolean(strChange);
					}
					catch{}
					try
					{
						string strHeavy = Reader[32].ToString();						//1重症/0否
						opsApplication.IsHeavy = Neusoft.FrameWork.Function.NConvert.ToBoolean(strHeavy);
					}
					catch{}
					try
					{
						opsApplication.IsSpecial = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[33].ToString());	//1特殊手术/0否
					}
					catch{}

					opsApplication.User.ID = Reader[34].ToString();	//操作员

					try
					{
						opsApplication.IsUnite = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[35].ToString());//1合并/0否	
					}
					catch{}
					opsApplication.OperateKind = Reader[37].ToString();					//1普通2急诊3感染				
					try
					{
						string strIsNeedAcco = Reader[38].ToString();					//是否需要随台护士
						opsApplication.IsAccoNurse = Neusoft.FrameWork.Function.NConvert.ToBoolean(strIsNeedAcco);
					}
					catch{}
					try
					{
						string strIsNeedPrep = Reader[39].ToString();					//是否需要巡回护士
						opsApplication.IsPrepNurse = Neusoft.FrameWork.Function.NConvert.ToBoolean(strIsNeedPrep);
					}
					catch{}
					opsApplication.RoomID=Reader[40].ToString();
					opsApplication.PatientInfo = PatientInfo.Clone();					//患者基本信息					
					opsApplication.PatientSouce = Pasource;									//1门诊2住院
					opsApplication.IsValid = true;										//1有效0无效	
						
					myAl.Add(opsApplication);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得患者手术申请单信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return myAl;
			}
			this.Reader.Close();
			try
			{
				foreach(Neusoft.HISFC.Models.Operation.OperationAppllication opsApplication in myAl)
				{
					opsApplication.DiagnoseAl = this.GetIcdFromApp(opsApplication);							//诊断列表					
					opsApplication.OperationInfos = this.GetOpsInfoFromApp(opsApplication.ID);				//手术项目信息列表				
					opsApplication.RoleAl = this.GetRoleFromApp(opsApplication.ID);							//人员角色列表
					//冗余属性赋值，为突出表现层申请部分业务调用方便
					foreach(Neusoft.HISFC.Models.Operation.ArrangeRole thisRole in opsApplication.RoleAl)
					{
						if(thisRole.RoleType.ID.ToString()== Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper1.ToString()
							|| thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper2.ToString()
							||thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper3.ToString())
							//助手医师列表
							opsApplication.HelperAl.Add(thisRole.Clone());
					}
					opsApplication.AppaRecAl = GetAppaRecFromApp(opsApplication.ID);//手术资料安排列表
				}
			}
			catch(Exception ex)
			{
				this.Err="获得患者手术列表信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return myAl;
			}
			return myAl;
		}		
		/// <summary>
		/// 获取手术科室手术申请单信息 (重载)
		/// </summary>
		/// <param name="OpsRoomID">手术科室编码</param>
		/// <param name="endTime">查询截至时间</param>
		/// <returns>手术申请单对象数组</returns>
		public ArrayList GetOpsAppList( string opsRoomID, string endTime )
		{
			ArrayList myAl = new ArrayList();
			//业务规则：遴选出手术室手术时间小于给定时间的所有有效的未做的手术申请单。			
            string strSql = GetOperationSql();
            if (strSql == null) 
			{
				return myAl;
			}
			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.2",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,opsRoomID,endTime);			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsAppList 2";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}
			strSql = strSql + " \n" + strSqlwhere;
			return GetOpsAppListFromSql(strSql);
		}		
		/// <summary>
		/// 获取手术科室手术申请单信息 (重载)
		/// </summary>
		/// <param name="OpsRoomID">手术科室编码</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">查询截至时间</param>
		/// <returns>手术申请单对象数组</returns>
		public ArrayList GetOpsAppList(string OpsRoomID,string beginTime,string endTime)
		{
			ArrayList myAl = new ArrayList();

            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }
			
			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.6",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,OpsRoomID,beginTime,endTime);			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operation.Operation.GetOpsAppList 6";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}
			strSql = strSql + " \n" + strSqlwhere;
			return GetOpsAppListFromSql(strSql);
		}
		/// <summary>
		/// 获取某个时间段内的所有的有效的手术申请，麻醉收费时参照用
		/// </summary>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <returns></returns>
		public ArrayList GetAnaesthAppList(string beginTime,string endTime)
		{
			ArrayList myAl = new ArrayList();
			
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.Operation.Select.2",ref strSql) == -1) 
			{
				return myAl;
			}

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operation.GetApplication.zjy",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,beginTime,endTime);			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsAppList zjy";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}
			strSql = strSql + " \n" + strSqlwhere;
			return GetOpsAppListFromSql(strSql);
		}
		/// <summary>
		/// 获取某手术室在某个时间内所有的有效的手术申请单信息
		/// </summary>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <param name="DeptId"></param>
		/// <returns></returns>
		public ArrayList GetApplistByDeptIdandTime(string beginTime,string endTime,string DeptId)
		{
			ArrayList myAl = new ArrayList();

            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.GetApplistByDeptIdandTime",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,beginTime,endTime,DeptId);			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsAppList GetApplistByDeptIdandTime";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}
			strSql = strSql + " \n" + strSqlwhere;
			return GetOpsAppListFromSql(strSql);
		}
		/// <summary>
		/// 获取所有已安排过的手术申请单信息 (重载)
		/// </summary>
		/// <param name="endTime">查询截至时间</param>
		/// <returns>手术申请单对象数组</returns>
		public ArrayList GetOpsAppList(string endTime)
		{
			ArrayList myAl = new ArrayList();
			//业务规则：遴选出手术时间小于给定时间的所有有效的已进行过手术安排的手术申请单。			
            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.3",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,endTime);			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsAppList 3";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}			
			strSql = strSql + " \n" + strSqlwhere;
			myAl =  GetOpsAppListFromSql(strSql);
			return myAl;
		}		
		/// <summary>
		/// 获取所有已安排过的手术申请单信息 (重载)hxw
		/// </summary>
		/// <param name="beginDate">查询开始时间</param>
		/// <param name="endTime">查询截至时间</param>
		/// <returns>手术申请单对象数组</returns>
		public ArrayList GetOpsAppList(DateTime beginDate,DateTime endTime)
		{
			ArrayList myAl = new ArrayList();

            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.7",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,beginDate.ToString(),endTime.ToString());			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsAppList 7";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;
			}			
			strSql = strSql + " \n" + strSqlwhere;
			myAl =  GetOpsAppListFromSql(strSql);
			return myAl;
		}	
		/// <summary>
		/// 根据住院流水号获取该患者最大手术序号
		/// </summary>
		/// <param name="inpatientno"></param>
		/// <returns></returns>
		public string GetMaxByPatient(string inpatientno)
		{
            string strSql = @"

SELECT MAX(OPERATIONNO)
 FROM MET_OPS_APPLY
WHERE CLINIC_CODE = '{0}'
  AND YNVALID = '1'
  AND EXECSTATUS='3'
";// string.Empty;
			#region sql
//			  select max(operationno)
//				from met_ops_apply
//			where inpatient_no='{0}'
//				and ynvalid='1'
	   #endregion
            //if(this.Sql.GetSql("Operator.Operator.GetApplication.8",ref strSql)==-1)
            //{
            //    return string.Empty;
            //}

			try
			{
				strSql=string.Format(strSql,inpatientno);
			}
			catch(Exception e)
			{
				this.Err="HISFC.Operator.Operator.GetMaxByPatient"+e.Message;
				this.ErrCode=e.Message;
				WriteErr();

				return string.Empty;
			}

			return this.ExecSqlReturnOne(strSql);			
		}
		/// <summary>
		/// 获取所有未登记过的手术申请单信息 (重载)
		/// </summary>
		/// <param name="OpsRoomID">手术科室编码</param>
		/// <param name="beginTime">查询起始时间</param>
		/// <param name="endTime">查询截至时间</param>
		/// <param name="Valid">0无效 1 有效</param>
		/// <returns>手术申请单对象数组</returns>
		public ArrayList GetOpsAppList(string OpsRoomID,DateTime beginTime,DateTime endTime,string Valid)
		{
			ArrayList myAl = new ArrayList();
			//业务规则：遴选出手术时间小于给定时间的所有有效的已进行过手术安排的手术申请单。			
            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.4",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,OpsRoomID,beginTime.ToString(),endTime.ToString(),Valid);			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsList 4";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}			
			strSql = strSql + " \n" + strSqlwhere;
			myAl = GetOpsAppListFromSql(strSql);
			return myAl;
		}
		/// <summary>
		/// 获取已安排未登记手术
		/// </summary>
		/// <param name="OpsRoomID"></param>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <param name="Isvalid"></param>
		/// <returns></returns>
		public ArrayList GetOpsAppList(string OpsRoomID,DateTime begin,DateTime end,bool Isvalid)
		{
			ArrayList myAl = new ArrayList();
			//业务规则：遴选出手术时间小于给定时间的所有有效的已进行过手术安排的手术申请单。			
            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }
			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.9",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,OpsRoomID,begin.ToString(),end.ToString(),
					Neusoft.FrameWork.Function.NConvert.ToInt32(Isvalid));			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsList 9";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;
			}			
			strSql = strSql + " \n" + strSqlwhere;
			myAl = GetOpsAppListFromSql(strSql);
			return myAl;
		}

        //==============================================================================================
        //==============================================================================================
        #region 新增加代码
        //修改人：路志鹏 时间：2007-4-12 
        //目的：在手术登记中增加按照住院号查询到该住院号以安排的手术申请
        public ArrayList GetOpsAppListByPatient(string OpsRoomID, string Patient_code)
        {
            ArrayList myAl = new ArrayList();
            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }
            string strSqlwhere = string.Empty;
            if (this.Sql.GetSql("Operator.Operator.GetApplication.11", ref strSqlwhere) == -1)
            {
                return myAl;
            }
            strSqlwhere = string.Format(strSqlwhere, OpsRoomID, Patient_code);
            strSql = strSql + "\n" + strSqlwhere;
            myAl = GetOpsAppListFromSql(strSql);
            return myAl;
        }

        //目的：在手术登记窗口中显示作废的手术单
        public ArrayList GetOpsCancelRecord(string ExeDeptID, DateTime begin, DateTime end)
        {
            ArrayList myAl = new ArrayList();
            string strSql = string.Empty;
            if (this.Sql.GetSql("Operator.Operator.Select.3", ref strSql) == -1)
            {
                return myAl;
            }
            strSql = string.Format(strSql, ExeDeptID, begin.ToString(), end.ToString());
            myAl = GetOpsAppListFromSql(strSql);
            return myAl;
        }
       
       
        #endregion

        //===========================================================================================
        //===========================================================================================

		/// <summary>
		/// 获取安排在同一个房间的所有手术 
		/// </summary>
		/// <param name="dept">房间号</param>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public ArrayList GetOpsApplistInSameRoom(Neusoft.FrameWork.Models.NeuObject dept,DateTime begin,DateTime end)
		{
			ArrayList myAl = new ArrayList();

            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplicationInSameRoom",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,dept.ID,begin.ToString(),end.ToString());			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsList 10";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;
			}			
			strSql = strSql + " \n" + strSqlwhere;
			myAl = GetOpsAppListFromSql(strSql);
			return myAl;
		}
		/// <summary>
		/// 获取科室一段时间范围内所有申请单
		/// </summary>
		/// <param name="dept"></param>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public ArrayList GetOpsAppList(Neusoft.FrameWork.Models.NeuObject dept,DateTime begin,DateTime end)
		{
			ArrayList myAl = new ArrayList();

            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.10",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,dept.ID,begin.ToString(),end.ToString());			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsList 10";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;
			}			
			strSql = strSql + " \n" + strSqlwhere;
			myAl = GetOpsAppListFromSql(strSql);
			return myAl;
		}
		/// <summary>
		/// 获取所有未标记已麻醉过的手术申请单信息 (重载)
		/// 麻醉登记用
		/// </summary>
		/// <param name="beginTime">查询起始时间</param>
		/// <param name="endTime">查询截至时间</param>
		/// <param name="Valid">0无效 1 有效</param>
		/// <returns>手术申请单对象数组</returns>
		public ArrayList GetOpsAppList(DateTime beginTime,DateTime endTime,string Valid)
		{
			ArrayList myAl = new ArrayList();
			//业务规则：遴选出手术时间小于给定时间的所有有效的已进行过手术安排的手术申请单。			
            string strSql = GetOperationSql();
            if (strSql == null)
            {
                return null;
            }

			string strSqlwhere = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplication.5",ref strSqlwhere) == -1) 
			{
				return myAl;
			}

			try
			{				
				strSqlwhere = string.Format(strSqlwhere,beginTime.ToString(),endTime.ToString(),Valid);			
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsAppList 5";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return myAl;            
			}			
			strSql = strSql + " \n" + strSqlwhere;
			myAl = GetOpsAppListFromSql(strSql);
			return myAl;
		}		
		/// <summary>
		/// 获得给定SQL语句查询出的申请单对象数组
		/// </summary>
		/// <param name="strSql">指定的查询语句</param>
		/// <returns>手术申请单对象数组</returns>
		private ArrayList GetOpsAppListFromSql(string strSql)
		{
			ArrayList myAl = new ArrayList();

//			Neusoft.HISFC.BizLogic.Manager.Person Person = new Neusoft.HISFC.BizLogic.Manager.Person();
//			Neusoft.HISFC.BizLogic.Manager.Department Department = new Neusoft.HISFC.BizLogic.Manager.Department();
			
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
                    Neusoft.HISFC.Models.Operation.OperationAppllication opsApplication = new Neusoft.HISFC.Models.Operation.OperationAppllication();
					opsApplication.ID = Reader[0].ToString();					//手术序号					
					
					opsApplication.OperationDoctor.ID = Reader[1].ToString();	//手术医生				
                    opsApplication.OperationDoctor.Name = this.GetEmployeeName(opsApplication.OperationDoctor.ID);
                        
					opsApplication.GuideDoctor.ID = Reader[2].ToString();		//指导医生	
					
					opsApplication.PreDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[3].ToString());		//手术预约时间					
					
					if(Reader.IsDBNull(4))
						opsApplication.Duration=0m;
					else
                        opsApplication.Duration =  System.Convert.ToDecimal(Reader[4].ToString());		//手术预定用时					
					
					opsApplication.AnesType.ID = Reader[5].ToString();					//麻醉类型					
					
					opsApplication.ExeDept.ID = Reader[6].ToString();//执行科室					

					opsApplication.OperateRoom = 
						opsApplication.ExeDept as Neusoft.HISFC.Models.Base.Department;	//手术室(对于需要填申请单的手术来说，手术室即执行科室)
					
					opsApplication.TableType = Reader[7].ToString();					//0正台1加台2点台					
					
					opsApplication.ApplyDoctor.ID = Reader[8].ToString();				//申请医生
                    opsApplication.ApplyDoctor.Name = this.GetEmployeeName(opsApplication.ApplyDoctor.ID);
                        
					
					opsApplication.ApplyDoctor.Dept.ID = Reader[9].ToString();//申请科室
					
					opsApplication.ApplyDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[10].ToString());	//申请时间
					opsApplication.ApplyNote = Reader[11].ToString();					//申请备注					
					
					opsApplication.ApproveDoctor.ID = Reader[12].ToString();//审批医生
					
					opsApplication.ApproveDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[13].ToString());	//审批时间
					opsApplication.ApproveNote = Reader[14].ToString();					//审批备注					
					opsApplication.OperationType.ID = Reader[15].ToString();				//手术规模
					opsApplication.InciType.ID = Reader[16].ToString();					//切口类型					
					
					string strGerm = Reader[17].ToString();						//1 有菌 0无菌
					opsApplication.IsGermCarrying = Neusoft.FrameWork.Function.NConvert.ToBoolean(strGerm);
				
					opsApplication.ScreenUp = Reader[18].ToString();					//1 幕上 2 幕下					
					opsApplication.BloodType.ID = Reader[19].ToString();				//血液成分					
					if(Reader.IsDBNull(20))
						opsApplication.BloodNum=0m;
					else
                        opsApplication.BloodNum =  System.Convert.ToDecimal(Reader[20].ToString());		//血量
					
					opsApplication.BloodUnit = Reader[21].ToString();					//用血单位
					opsApplication.OpsNote = Reader[22].ToString();						//手术注意事项
					opsApplication.AneNote = Reader[23].ToString();						//麻醉注意事项					
					opsApplication.ExecStatus = Reader[24].ToString();					//1手术申请 2 手术审批 3手术安排 4手术完成
					
					string strFinished = Reader[25].ToString();						//0未做手术/1已做手术
					opsApplication.IsFinished = Neusoft.FrameWork.Function.NConvert.ToBoolean(strFinished);
					
					string strAnesth = Reader[26].ToString();					//0未麻醉/1已麻醉
					opsApplication.IsAnesth = Neusoft.FrameWork.Function.NConvert.ToBoolean(strAnesth);
					
					opsApplication.Folk = Reader[27].ToString();						//签字家属
					opsApplication.RelaCode.ID = Reader[28].ToString();					//家属关系
					opsApplication.FolkComment = Reader[29].ToString();					//家属意见					
					
					string strUrgent = Reader[30].ToString();					//加急手术,1是/0否
					opsApplication.IsUrgent = Neusoft.FrameWork.Function.NConvert.ToBoolean(strUrgent);
					
					string strChange = Reader[31].ToString();					//1病危/0否
					opsApplication.IsChange = Neusoft.FrameWork.Function.NConvert.ToBoolean(strChange);
				
					string strHeavy = Reader[32].ToString();						//1重症/0否
					opsApplication.IsHeavy = Neusoft.FrameWork.Function.NConvert.ToBoolean(strHeavy);
					
					string strSpecial = Reader[33].ToString();					//1特殊手术/0否
					opsApplication.IsSpecial = Neusoft.FrameWork.Function.NConvert.ToBoolean(strSpecial);
					
					opsApplication.User.ID = Reader[34].ToString();	//操作员
				
					opsApplication.IsUnite = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[35].ToString());//1合并/0否
					
					opsApplication.OperateKind = Reader[37].ToString();					//1普通2急诊3感染
					opsApplication.PatientSouce = Reader[38].ToString();					//1门诊/2住院					
					//try
					//{
						//thisOpsApp.PatientInfo.Patient.PID.PatientNo = Reader[39].ToString();//住院号
						//thisOpsApp.PatientInfo.Patient.ID  = this.GetInPatientNo(thisOpsApp.PatientInfo.Patient.PID.PatientNo);//住院流水号
					//}
					//catch{}
                    
					opsApplication.PatientInfo.ID = Reader[39].ToString();//门诊号/住院流水号
                    opsApplication.PatientInfo = this.GetPatientInfo(opsApplication.PatientInfo.ID);
					//-----------------------------------------------------------------------------------
					opsApplication.PatientInfo.PID.ID = Reader[40].ToString();//门诊卡号/住院号
					opsApplication.PatientInfo.PID.CardNO = Reader[40].ToString();//门诊卡号
					opsApplication.PatientInfo.PID.PatientNO = Reader[40].ToString();//住院号
					//-----------------------------------------------------------------------------------
					opsApplication.PatientInfo.Name = Reader[41].ToString();	//姓名
					opsApplication.PatientInfo.Sex.ID = Reader[42].ToString();	//性别
					opsApplication.PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[43].ToString());//生日					
					
					if(Reader.IsDBNull(44))
						opsApplication.PatientInfo.FT.PrepayCost=0m;
					else
						opsApplication.PatientInfo.FT.PrepayCost =  System.Convert.ToDecimal(Reader[44].ToString());//预交金
					
					opsApplication.PatientInfo.PVisit.PatientLocation.Dept.ID = Reader[45].ToString();//住院科室
					
					opsApplication.PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[46].ToString();//病床号
					opsApplication.PatientInfo.BloodType.ID = Reader[47].ToString();//血型					
					try
					{
						opsApplication.OpsTable.ID = Reader[48].ToString();				//手术台
						opsApplication.OpsTable.Name = 
							this.TableManage.GetTableNameFromID(opsApplication.OpsTable.ID.ToString());
					}
					catch{}
					
					string strIsNeedAcco = Reader[49].ToString();					//是否需要随台护士
					opsApplication.IsAccoNurse = Neusoft.FrameWork.Function.NConvert.ToBoolean(strIsNeedAcco);
					
					string strIsNeedPrep = Reader[50].ToString();					//是否需要巡回护士
					opsApplication.IsPrepNurse = Neusoft.FrameWork.Function.NConvert.ToBoolean(strIsNeedPrep);
					
					opsApplication.RoomID=Reader[51].ToString();
					opsApplication.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[52].ToString());//1有效0无效	
                    opsApplication.OperationDoctor.Dept.ID = Reader[54].ToString();
                    ////{B9DDCC10-3380-4212-99E5-BB909643F11B}
                    opsApplication.AnesWay = Reader[55].ToString();
					myAl.Add(opsApplication);
                   
				}
			}
			catch(Exception ex)
			{
				this.Err="获得患者手术申请单信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return myAl;
			}
			this.Reader.Close();
			try
			{
				foreach(Neusoft.HISFC.Models.Operation.OperationAppllication opsApp in myAl)
				{
					opsApp.DiagnoseAl = this.GetIcdFromApp(opsApp);	//诊断列表					
					opsApp.OperationInfos = GetOpsInfoFromApp(opsApp.ID);//手术项目信息列表				
					opsApp.RoleAl = GetRoleFromApp(opsApp.ID);//人员角色列表
					//冗余属性赋值，为突出表现层申请部分业务调用方便
					foreach(Neusoft.HISFC.Models.Operation.ArrangeRole thisRole in opsApp.RoleAl)
					{
						if(thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper1.ToString()
							|| thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper2.ToString()
							|| thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper3.ToString()
                            || thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.TmpHelper1.ToString()
                            || thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.TmpHelper2.ToString()) //donggq
							//助手医师列表
							opsApp.HelperAl.Add(thisRole.Clone());
					}
					//thisOpsApp.AppaRecAl = GetAppaRecFromApp(thisOpsApp.OperationNo);//手术资料安排列表
				}
			}
			catch(Exception ex)
			{
				this.Err="获得患者手术列表信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return myAl;
			}
			return myAl;
		}
	
		/// <summary>
		///根据手术序号获得手术项目信息列表
		/// </summary>
		/// <param name="OperatorNo">手术序号</param>
		/// <returns>患者的项目信息对象数组</returns>
        public List<OperationInfo> GetOpsInfoFromApp(string operationNO)
		{
            List<OperationInfo> InfoAl = new List<OperationInfo>();
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetOpsInfoFromApp.1",ref strSql) == -1) 
			{
				return InfoAl;//空数组
			}

			try
			{
				strSql = string.Format(strSql,operationNO);
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetOpsInfoFromApp";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return InfoAl;            
			}

			if (strSql == null) 
			{
				return InfoAl;
			}

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OperationInfo thisOperateInfo = new Neusoft.HISFC.Models.Operation.OperationInfo();
					thisOperateInfo.OperationItem.ID = Reader[0].ToString();//项目编码
                    thisOperateInfo.OperationItem.Name = Reader[1].ToString();//项目名称
					if(Reader.IsDBNull(2)==false)
                        thisOperateInfo.OperationItem.Price = System.Convert.ToDecimal(Reader[2].ToString());//单价
					if(Reader.IsDBNull(3)==false)
						thisOperateInfo.FeeRate =  System.Convert.ToDecimal(Reader[3].ToString());//收费比例
					if(Reader.IsDBNull(4)==false)
						thisOperateInfo.Qty = System.Convert.ToInt16(Reader[4]);//数量
					
					thisOperateInfo.StockUnit = Reader[5].ToString();//单位
					thisOperateInfo.OperateType.ID = Reader[6].ToString();//手术规模
					thisOperateInfo.InciType.ID = Reader[7].ToString();//切口类型
					thisOperateInfo.OpePos.ID = Reader[8].ToString();//手术部位
					thisOperateInfo.IsMainFlag = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[9].ToString());//主手术标志 1是/0否
					
					thisOperateInfo.IsValid = true;
					InfoAl.Add(thisOperateInfo);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术项目信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return InfoAl;
			}
			this.Reader.Close();
			return InfoAl;
		}
		/// <summary>
		/// 根据手术序号获得人员角色安排列表
		/// </summary>
		/// <param name="OperatorNo">手术申请单序号</param>
		/// <returns>指定的手术人员安排类对象数组</returns>
		public ArrayList GetRoleFromApp(string OperatorNo)
		{
			ArrayList RoleAl = new ArrayList();
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetRoleFromApp.1",ref strSql) == -1) 
			{
				return RoleAl;//空数组
			}

			try
			{
				strSql = string.Format(strSql,OperatorNo);
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetRoleFromApp";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return RoleAl;            
			}
			if (strSql == null) 
			{
				return RoleAl;
			}

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.ArrangeRole thisRole = new Neusoft.HISFC.Models.Operation.ArrangeRole();
					thisRole.RoleType.ID = Reader[0].ToString();		//角色编码
					thisRole.ID = Reader[1].ToString();			//人员编码
					thisRole.Name = Reader[2].ToString();		//人员姓名
					thisRole.ForeFlag = Reader[3].ToString();			//0术前安排1术后记录
					if (thisRole.ForeFlag == string.Empty || thisRole.ForeFlag == null)
						thisRole.ForeFlag = "0";
					thisRole.RoleOperKind.ID = Reader[4].ToString();//人员状态
					RoleAl.Add(thisRole);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术人员角色信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return RoleAl;
			}
			this.Reader.Close();
			return RoleAl;
		}
		/// <summary>
		/// 根据手术序号获得手术资料安排列表
		/// </summary>
		/// <param name="OperatorNo">手术申请单序号</param>
		/// <returns>指定的手术人员安排类对象数组</returns>
		public ArrayList GetAppaRecFromApp(string OperatorNo)
		{
			ArrayList AppaRecAl = new ArrayList();
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetAppaRec.1",ref strSql) == -1) 
			{
				return AppaRecAl;//空数组
			}

			try
			{
				strSql = string.Format(strSql,OperatorNo);
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetAppaRecFromApp";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return AppaRecAl;            
			}
			if (strSql == null) 
			{
				return AppaRecAl;
			}

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OpsApparatusRec thisRec = new Neusoft.HISFC.Models.Operation.OpsApparatusRec();
					
					thisRec.OperationNo = OperatorNo;//手术序号
					thisRec.OpsAppa.ID = Reader[0].ToString();//设备代码					
					thisRec.OpsAppa.Name = Reader[1].ToString();//设备名称
					thisRec.foreflag = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[2].ToString());//1.术前安排/2.术后记录						
					if (thisRec.foreflag == 0)
						thisRec.foreflag = 1;
					thisRec.Qty = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[3].ToString());//数量
					thisRec.AppaUnit = Reader[4].ToString();//单位
					
					AppaRecAl.Add(thisRec);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术资料安排信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return AppaRecAl;
			}
			this.Reader.Close();
			return AppaRecAl;
		}

		#endregion
		#region 针对手术申请单的操作
		/// <summary>
		/// 获取新手术申请单序号
		/// </summary>
		/// <returns>新申请单序号</returns>
		public string GetNewOperationNo()
		{
			string strNewNo = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetNewOperationNo.1",ref strSql) == -1) 
			{
				return strNewNo; //空字符串
			}
			if (strSql == null) return strNewNo;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					strNewNo = Reader[0].ToString();
				}
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetNewOperationNo";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return strNewNo;
			}
			this.Reader.Close();
			return strNewNo;
		}
		/// <summary>
		/// 获取手术申请单状态
		/// </summary>
		/// <param name="OperatorNo">手术申请单序号</param>
		/// <returns>申请单状态 1已申请 2已审批 3已安排 4已完成</returns>
		public string GetApplicationStatus( string operatorNO )
		{
			string strStatus = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetApplicationStatus.1",ref strSql) == -1) 
			{
				return strStatus;//空数组
			
			}
			
			try
			{
				strSql = string.Format(strSql,operatorNO);
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.GetApplicationStatus";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return strStatus;            
			}

			if (strSql == null) 
				return strStatus;
			
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					strStatus = Reader[0].ToString();
				}
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operation.Operation.GetApplicationStatus";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return strStatus;            
			}
			this.Reader.Close();

			return strStatus;
		}

		/// <summary>
		/// 手术申请(新建手术申请单)
		/// </summary>
		/// <param name="OpsApp">手术申请单实例</param>
		/// <returns>0 success -1 fail</returns>
		public int CreateApplication(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{
			#region 新建手术申请单
			///新建手术申请单
			///Operation.Operation.CreateApplication.1
			///传入：58
			///传出：0 
			#endregion			
			string strSql = string.Empty;		
			#region 获取患者基本信息
			//--------------------------------------------------------		
			//局部变量定义
			string ls_ClinicCode = string.Empty;		//住院流水号/门诊号
			string ls_PatientNo = string.Empty;			//病案号/病历号
			string ls_Name = string.Empty;				//患者姓名
			string ls_Sex = string.Empty;				//性别
			DateTime ldt_Birthday = DateTime.MinValue;	//生日
			string ls_DeptCode = string.Empty;			//住院科室
			string ls_BedNo = string.Empty;				//床位号
			string ls_BloodCode = string.Empty;			//患者血型
			decimal ld_PrePay = 0;						//预交金
			string ls_SickRoom = string.Empty;			//病房号		
	
			#region 首先判断是门诊手术还是住院手术，确定应该输入的患者号			
			switch (OpsApp.PatientSouce)
			{
				case "1":  //门诊手术
					ls_PatientNo = OpsApp.PatientInfo.PID.CardNO;
					break;
				case "2":  //住院手术
					ls_PatientNo = OpsApp.PatientInfo.PID.PatientNO;
					break;
				default:
					break;
			}			
			#endregion

			ls_ClinicCode = OpsApp.PatientInfo.ID.ToString();
			//ls_PatientNo = OpsApp.PatientInfo.Patient.PID.RecordNo;
			ls_Name = OpsApp.PatientInfo.Name;
			ls_Sex = OpsApp.PatientInfo.Sex.ID.ToString();
			ldt_Birthday = OpsApp.PatientInfo.Birthday;
			ls_DeptCode = OpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID.ToString();
			ls_BedNo = OpsApp.PatientInfo.PVisit.PatientLocation.Bed.ID.ToString();
			ls_BloodCode = OpsApp.PatientInfo.BloodType.ID.ToString();
			ld_PrePay = OpsApp.PatientInfo.FT.PrepayCost;
			ls_SickRoom = OpsApp.PatientInfo.PVisit.PatientLocation.Room;
			//--------------------------------------------------------
			#endregion
			DateTime ldt_ReceptDate = DateTime.MinValue;//接患者时间
			//对新增申请单：申请时间即为当前系统时间
			OpsApp.ApplyDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.GetSysDateTime());
			OpsApp.ExeDept = OpsApp.OperateRoom;//执行科室(对于需要填申请单的手术来说，手术室即执行科室)
			string strGerm = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsGermCarrying).ToString();
			string strFinished = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsFinished).ToString();
			string strAnesth = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsAnesth).ToString();
			string strUrgent = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsUrgent).ToString();
			string strChange = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsChange).ToString();
			string strHeavy = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsHeavy).ToString();
			string strSpecial = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsSpecial).ToString();
            string strValid = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsValid).ToString();
			string strUnite = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsUnite).ToString();
            string strNeedAcco = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsAccoNurse).ToString();
            string strNeedPrep = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsPrepNurse).ToString();
			//默认取第一个诊断为统计术前诊断
			string strDiagnose = string.Empty;
			if(OpsApp.DiagnoseAl.Count > 0)
			{
				foreach(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase MainDiagnose in OpsApp.DiagnoseAl)
				{
					if(MainDiagnose.IsValid)
					{
						strDiagnose = MainDiagnose.Name + "(" + MainDiagnose.ID.ToString() + ")";
						break;
					}
				}
			}

			if(this.Sql.GetSql("Operator.Operator.CreateApplication.1",ref strSql)==-1) 
			{
				return -1;
			}

			try
			{
					string []str = new string[]{	OpsApp.ID,ls_ClinicCode,ls_PatientNo,OpsApp.PatientSouce,ls_Name,
												   ls_Sex,ldt_Birthday.ToString(),ld_PrePay.ToString(),ls_DeptCode,ls_BedNo,
												  ls_BloodCode,strDiagnose,OpsApp.OperateKind,OpsApp.OperationDoctor.ID.ToString(),OpsApp.GuideDoctor.ID.ToString(),
						ls_SickRoom,OpsApp.PreDate.ToString(),OpsApp.Duration.ToString(),OpsApp.AnesType.ID.ToString(),OpsApp.HelperAl.Count.ToString(),
						"0","0","0",OpsApp.ExeDept.ID.ToString(),OpsApp.TableType,
						OpsApp.ApplyDoctor.ID.ToString(),OpsApp.ApplyDoctor.Dept.ID.ToString(),OpsApp.ApplyDate.ToString(),OpsApp.ApplyNote,OpsApp.ApproveDoctor.ID.ToString(),
						OpsApp.ApproveDate.ToString(),OpsApp.ApproveNote,"",OpsApp.OperationType.ID.ToString(),OpsApp.InciType.ID.ToString(),
						strGerm,OpsApp.ScreenUp,OpsApp.OpsTable.ID.ToString(),ldt_ReceptDate.ToString(),OpsApp.BloodType.ID.ToString(),
						OpsApp.BloodNum.ToString(),OpsApp.BloodUnit,OpsApp.OpsNote,OpsApp.AneNote,OpsApp.ExecStatus,
						strFinished,strAnesth,OpsApp.Folk,OpsApp.RelaCode.ID.ToString(),OpsApp.FolkComment,
						strUrgent,strChange,strHeavy,strSpecial,OpsApp.User.ID.ToString(),
						System.DateTime.Now.ToString(),strValid,strUnite,"",strNeedAcco,strNeedPrep,OpsApp.OperationDoctor.Dept.ID,/*{B9DDCC10-3380-4212-99E5-BB909643F11B}*/OpsApp.AnesWay
											   }	;	
				//手术申请单表中增加记录
//				//每行5个参数
//				strSql = string.Format(strSql,OpsApp.OperationNo,ls_ClinicCode,ls_PatientNo,OpsApp.Pasource,ls_Name,
//					ls_Sex,ldt_Birthday.ToString(),ld_PrePay.ToString(),ls_DeptCode,ls_BedNo,
//					ls_BloodCode,strDiagnose,OpsApp.OperateKind,OpsApp.Ops_docd.ID.ToString(),OpsApp.Gui_docd.ID.ToString(),
//					ls_SickRoom,OpsApp.Pre_Date.ToString(),OpsApp.Duration.ToString(),OpsApp.Anes_type.ID.ToString(),OpsApp.HelperAl.Count,
//					0,0,0,OpsApp.ExeDept.ID.ToString(),OpsApp.TableType,
//					OpsApp.Apply_Doct.ID.ToString(),OpsApp.Apply_Doct.Dept.ID.ToString(),OpsApp.Apply_Date.ToString(),OpsApp.ApplyNote,OpsApp.ApprDocd.ID.ToString(),
//					OpsApp.ApprDate.ToString(),OpsApp.ApprNote,"",OpsApp.OperateType.ID.ToString(),OpsApp.InciType.ID.ToString(),
//					strGerm,OpsApp.ScreenUp,OpsApp.OpsTable.ID.ToString(),ldt_ReceptDate.ToString(),OpsApp.BloodType.ID.ToString(),
//					OpsApp.BloodNum.ToString(),OpsApp.BloodUnit,OpsApp.OpsNote,OpsApp.AneNote,OpsApp.ExecStatus,
//					strFinished,strAnesth,OpsApp.Folk,OpsApp.RelaCode.ID.ToString(),OpsApp.FolkComment,
//					strUrgent,strChange,strHeavy,strSpecial,OpsApp.User.ID.ToString(),
//					this.GetSysDateTime(),strValid,strUnite,"",strNeedAcco,strNeedPrep);
				if(this.ExecNoQuery(strSql,str) == -1) 
				{
					return -1;
				}
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operation.Operation.CreateApplication";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
			#region 处理手术项目基本信息
			//--------------------------------------------------------			
			//针对本申请单中涉及到的手术添加手术信息
			foreach (Neusoft.HISFC.Models.Operation.OperationInfo OperateInfo in OpsApp.OperationInfos)
			{
				//添加手术信息
				try
				{
					if(AddOperationInfo(OpsApp,OperateInfo) == -1) 
					{
						return -1;
					}
				}
				catch(Exception ex)
				{
					this.Err = "HISFC.Operation.Operation.CreateApplication OperateInfo";
					this.ErrCode = ex.Message;
					this.WriteErr();
					return -1;            
				}
			}
			//--------------------------------------------------------
			#endregion
			#region 处理手术诊断信息
			//获得患者已有的所有术前诊断
			ArrayList al = this.GetIcdFromApp(OpsApp);
			//判断是否存在记录的标志
			bool bIsExist = false;
			//遍历要加入的诊断信息列表(OpsApp.DiagnoseAl)
			foreach(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase willAddDiagnose in OpsApp.DiagnoseAl)
			{
				bIsExist = false;				
				//遍历患者已有的所有手术诊断，如果willAddDiagnose已经存在，更新其状态，
				//如果willAddDiagnose尚不存在，则新增该记录到数据库中
				foreach(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase thisDiagnose in al)
				{
					if(thisDiagnose.HappenNo == willAddDiagnose.HappenNo && thisDiagnose.Patient.ID.ToString() == willAddDiagnose.Patient.ID.ToString())
					{
						//已经存在	更新				
                        //TODO:病案业务层
						//if(this.DiagnoseManager.UpdatePatientDiagnose(willAddDiagnose) == -1) return -1;
						//bIsExist = true;
					}
				}
				//遍历完毕后发现不存在 新增
				if(bIsExist == false)
				{
                    //TODO:病案业务层
					//if(this.DiagnoseManager.CreatePatientDiagnose(willAddDiagnose) == -1) return -1;
				}
			}
			#endregion
			#region 处理手术人员角色信息
			try
			{
				if(this.ProcessRoleForApply(OpsApp) == -1) return -1;
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operation.Operation.CreateApplication Role";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
			#endregion
			return 0;
		}

		/// <summary>
		/// 手术申请(修改手术申请单)
		/// </summary>
		/// <param name="OpsApp">手术申请单实例</param>
		/// <returns>0 success -1 fail</returns>
        public int UpdateApplication(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{
			#region 修改手术申请单
			///修改手术申请单
			///Operation.Operation.UpdateApplication.1
			///传入：58
			///传出：0 
			#endregion
			
			string strSql = string.Empty;		
			#region 获取患者基本信息
			//--------------------------------------------------------		
			//局部变量定义
			string ls_ClinicCode = string.Empty;//住院流水号/门诊号
			string ls_PatientNo = string.Empty; //病案号/病历号
			string ls_Name = string.Empty;	  //患者姓名
			string ls_Sex = string.Empty;		  //性别
			DateTime ldt_Birthday = DateTime.MinValue; //生日
			string ls_DeptCode = string.Empty;  //住院科室
			string ls_BedNo = string.Empty;	  //床位号
			string ls_BloodCode = string.Empty; //患者血型
			decimal ld_PrePay = 0;	  //预交金
			string ls_SickRoom = string.Empty;  //病房号
			
			#region 首先判断是门诊手术还是住院手术，确定应该输入的患者号			
			switch (OpsApp.PatientSouce)
			{
				case "1":  //门诊手术
					ls_PatientNo = OpsApp.PatientInfo.PID.CardNO;
					break;
				case "2":  //住院手术
					ls_PatientNo = OpsApp.PatientInfo.PID.PatientNO;
					break;
			}			
			#endregion
			ls_ClinicCode = OpsApp.PatientInfo.ID.ToString();
			//ls_PatientNo = OpsApp.PatientInfo.Patient.PID.RecordNo;
			ls_Name = OpsApp.PatientInfo.Name;
			ls_Sex = OpsApp.PatientInfo.Sex.ID.ToString();
			ldt_Birthday = OpsApp.PatientInfo.Birthday;
			ls_DeptCode = OpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID.ToString();
			ls_BedNo = OpsApp.PatientInfo.PVisit.PatientLocation.Bed.ID.ToString();
			ls_BloodCode = OpsApp.PatientInfo.BloodType.ID.ToString();
			ld_PrePay = OpsApp.PatientInfo.FT.PrepayCost;
			ls_SickRoom = OpsApp.PatientInfo.PVisit.PatientLocation.Room;
			//--------------------------------------------------------
			#endregion
			DateTime ldt_ReceptDate = DateTime.MinValue;//接患者时间
			OpsApp.ExeDept = OpsApp.OperateRoom;//执行科室(对于需要填申请单的手术来说，手术室即执行科室)
			string strGerm = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsGermCarrying).ToString();
			string strFinished = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsFinished).ToString();
			string strAnesth = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsAnesth).ToString();
			string strUrgent = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsUrgent).ToString();
			string strChange = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsChange).ToString();
			string strHeavy = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsHeavy).ToString();
			string strSpecial = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsSpecial).ToString();
            string strValid = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsValid).ToString();
			string strUnite = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsUnite).ToString();
            string strNeedAcco = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsAccoNurse).ToString();
            string strNeedPrep = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsPrepNurse).ToString();
			//默认取第一个诊断为统计术前诊断
			string strDiagnose = string.Empty;
			if(OpsApp.DiagnoseAl.Count > 0)
			{
				foreach(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase MainDiagnose in OpsApp.DiagnoseAl)
				{
					if(MainDiagnose.IsValid)
					{
						strDiagnose = MainDiagnose.Name + "(" + MainDiagnose.ID.ToString() + ")";
						break;
					}
				}
			}
			if(this.Sql.GetSql("Operator.Operator.UpdateApplication.1",ref strSql)==-1) return -1;
			try
			{
				string []str = new string[]{
											   OpsApp.ID,ls_ClinicCode,ls_PatientNo,OpsApp.PatientSouce,ls_Name,
											   ls_Sex,ldt_Birthday.ToString(),ld_PrePay.ToString(),ls_DeptCode,ls_BedNo,
											   ls_BloodCode,strDiagnose,OpsApp.OperationDoctor.ID.ToString(),OpsApp.GuideDoctor.ID.ToString(),ls_SickRoom,
											   OpsApp.PreDate.ToString(),OpsApp.Duration.ToString(),OpsApp.AnesType.ID.ToString(),OpsApp.HelperAl.Count.ToString(),"0",
											   "0","0",OpsApp.ExeDept.ID.ToString(),OpsApp.TableType,OpsApp.ApplyDoctor.ID.ToString(),
											   OpsApp.ApplyDoctor.Dept.ID.ToString(),OpsApp.ApplyDate.ToString(),OpsApp.ApplyNote,OpsApp.ApproveDoctor.ID,OpsApp.ApproveDate.ToString(),
											   OpsApp.ApproveNote,"",OpsApp.OperationType.ID.ToString(),OpsApp.InciType.ID.ToString(),strGerm,
											   OpsApp.ScreenUp,OpsApp.OpsTable.ID.ToString(),ldt_ReceptDate.ToString(),OpsApp.BloodType.ID.ToString(),OpsApp.BloodNum.ToString(),
											   OpsApp.BloodUnit,OpsApp.OpsNote,OpsApp.AneNote,OpsApp.ExecStatus,strFinished,
											   strAnesth,OpsApp.Folk,OpsApp.RelaCode.ID.ToString(),OpsApp.FolkComment,strUrgent,
											   strChange,strHeavy,strSpecial,OpsApp.User.ID.ToString(),this.GetSysDateTime(),
											   strValid,strUnite,"",OpsApp.OperateKind,strNeedAcco,strNeedPrep,OpsApp.RoomID,OpsApp.OperationDoctor.Dept.ID,
                                               /*{B9DDCC10-3380-4212-99E5-BB909643F11B}*/OpsApp.AnesWay
										   };
				//每行5个参数
//				strSql = string.Format(strSql,OpsApp.OperationNo,ls_ClinicCode,ls_PatientNo,OpsApp.Pasource,ls_Name,
//					ls_Sex,ldt_Birthday.ToString(),ld_PrePay.ToString(),ls_DeptCode,ls_BedNo,
//					ls_BloodCode,strDiagnose,OpsApp.Ops_docd.ID.ToString(),OpsApp.Gui_docd.ID.ToString(),ls_SickRoom,
//					OpsApp.Pre_Date.ToString(),OpsApp.Duration.ToString(),OpsApp.Anes_type.ID.ToString(),OpsApp.HelperAl.Count,0,
//					0,0,OpsApp.ExeDept.ID.ToString(),OpsApp.TableType,OpsApp.Apply_Doct.ID.ToString(),
//					OpsApp.Apply_Doct.Dept.ID.ToString(),OpsApp.Apply_Date.ToString(),OpsApp.ApplyNote,OpsApp.ApprDocd.ID.ToString(),OpsApp.ApprDate.ToString(),
//					OpsApp.ApprNote,"",OpsApp.OperateType.ID.ToString(),OpsApp.InciType.ID.ToString(),strGerm,
//					OpsApp.ScreenUp,OpsApp.OpsTable.ID.ToString(),ldt_ReceptDate.ToString(),OpsApp.BloodType.ID.ToString(),OpsApp.BloodNum.ToString(),
//					OpsApp.BloodUnit,OpsApp.OpsNote,OpsApp.AneNote,OpsApp.ExecStatus,strFinished,
//					strAnesth,OpsApp.Folk,OpsApp.RelaCode.ID.ToString(),OpsApp.FolkComment,strUrgent,
//					strChange,strHeavy,strSpecial,OpsApp.User.ID.ToString(),this.GetSysDateTime(),
//					strValid,strUnite,"",OpsApp.OperateKind,strNeedAcco,strNeedPrep,OpsApp.RoomID);	
			
				if(this.ExecNoQuery(strSql,str) == -1) return -1;
			}
			catch(Exception ex)
			{
				this.Err ="HISFC.Operation.Operation.UpdateApplication";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
	

			#region 处理手术项目基本信息
			if (DelOperationInfo(OpsApp) == -1) return -1;
			//针对本申请单中涉及到的手术添加手术项目信息
			foreach (Neusoft.HISFC.Models.Operation.OperationInfo OperateInfo in OpsApp.OperationInfos)
			{
				//添加手术项目信息
				if(AddOperationInfo(OpsApp,OperateInfo) == -1) return -1;
			}
			#endregion
			#region 处理手术诊断信息
			//获得患者已有的所有术前诊断
			ArrayList al = this.GetIcdFromApp(OpsApp);
			//判断是否存在记录的标志
			bool bIsExist = false;
			//遍历要加入的诊断信息列表(OpsApp.DiagnoseAl)
			foreach(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase willAddDiagnose in OpsApp.DiagnoseAl)
			{
				bIsExist = false;				
				//遍历患者已有的所有手术诊断，如果willAddDiagnose已经存在，更新其状态，
				//如果willAddDiagnose尚不存在，则新增该记录到数据库中
				foreach(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase thisDiagnose in al)
				{
					if(thisDiagnose.HappenNo == willAddDiagnose.HappenNo && thisDiagnose.Patient.ID.ToString() == willAddDiagnose.Patient.ID.ToString())
					{
						//已经存在	更新	
                        //TODO:病案业务层
                        //if(this.DiagnoseManager.UpdatePatientDiagnose(willAddDiagnose) == -1) return -1;
						bIsExist = true;
					}
				}
				//遍历完毕后发现不存在 新增
				if(bIsExist == false)
				{
                    //TODO:病案业务层
					//if(this.DiagnoseManager.CreatePatientDiagnose(willAddDiagnose) == -1) return -1;
				}
			}
			#endregion
			#region 处理手术人员角色信息
			try
			{
				if(this.ProcessRoleForApply(OpsApp) == -1) return -1;
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operation.Operation.UpdateApplication Role";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
			#endregion
			#region 处理手术资料信息
			try
			{
				if(this.ProcessAppaRecForApply(OpsApp) == -1) return -1;
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operation.Operation.UpdateApplication Apparatus";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
			#endregion
			return 0;
		}		
		/// <summary>
		/// 手术取消
		/// </summary>
		/// <param name="OpsApplication">手术申请单实例</param>
		/// <returns>0 success -1 fail</returns>
        public int CancelApplication(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{
			#region 取消手术申请单
			///取消手术申请单
			///Operation.Operation.CancelApplication.1
			///传入：4
			///传出：0 
			#endregion
			string strSql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.UpdateApplication.2",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OpsApp.ID,OpsApp.User.ID.ToString(),this.GetSysDateTime(),"0");
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.CancelApplication";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
			if (strSql == null) return -1;	
			return this.ExecNoQuery(strSql);
		}
	
		/// <summary>
		/// 手术登记后更新申请单状态
		/// </summary>
		/// <param name="OperatorNo">手术申请单序号</param>
		/// <returns>0 success -1 fail</returns>
		public int DoOperatorRecord(string OperatorNo)
		{			
			//已做手术置为1，手术状态置为4
			string strSql=string.Empty;

			if(this.Sql.GetSql("Operator.Operator.UpdateApplication.3",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OperatorNo);
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.DoOperatorRecord";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
			if (strSql == null) return -1;			
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 麻醉登记后更新申请单状态
		/// </summary>
		/// <param name="OperatorNo"></param>
		/// <returns></returns>
		public int DoAnaeRecord(string OperatorNo)
		{			
			string strSql=string.Empty;

			if(this.Sql.GetSql("Operator.Operator.UpdateApplication.4",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OperatorNo);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}
			if (strSql == null) return -1;			
			return this.ExecNoQuery(strSql);
		}

        /// <summary>//{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}
        /// 麻醉登记后更新申请单状态
        /// </summary>
        /// <param name="OperatorNo"></param>
        /// <returns></returns>
        public int DoAnaeRecord(string OperatorNo,string status)
        {
            string strSql = string.Empty;

            if (this.Sql.GetSql("Operator.Operator.UpdateApplication.Status", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, OperatorNo,status);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                this.WriteErr();
                return -1;
            }
            if (strSql == null) return -1;
            return this.ExecNoQuery(strSql);
        }		
		#endregion
		#region 手术申请业务规则判断
		/// <summary>
		/// 获得指定日期科室在指定手术室剩余可申请的正台数
		/// </summary>
		/// <param name="OpsRoom">手术室对象</param>
		/// <param name="DeptID">手术申请科室编号</param>
		/// <param name="PreDate">手术预约日期</param>
		/// <returns> >=0 可申请的正台数， -1 fail </returns>
		public int GetEnableTableNum(Neusoft.HISFC.Models.Base.Department operationRoom,string deptID,DateTime preDate)
		{
			int iTotalNum = 0;	//总数
			int iAlreadyNum = 0;//已申请数
			int iEnableNum = 0;	//尚可申请数
			
			string strWeekDay = string.Empty;//星期几
			switch(preDate.DayOfWeek)
			{
				case System.DayOfWeek.Monday:
					strWeekDay = "1";
					break;
				case System.DayOfWeek.Tuesday:
					strWeekDay = "2";
					break;
				case System.DayOfWeek.Wednesday:
					strWeekDay = "3";
					break;
				case System.DayOfWeek.Thursday:
					strWeekDay = "4";
					break;
				case System.DayOfWeek.Friday:
					strWeekDay = "5";
					break;
				case System.DayOfWeek.Saturday:
					strWeekDay = "6";
					break;
				case System.DayOfWeek.Sunday:
					strWeekDay = "7";
					break;
			}
			//根据科室和手术室以及星期几来获得原始分配的正台数
			string strSql1 = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableAlloc.GetAllotInfo.3",ref strSql1) == -1) return -1;
			try
			{
				strSql1 = string.Format(strSql1,operationRoom.ID.ToString(),deptID,strWeekDay);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql1 == null) return -1;
			this.ExecQuery(strSql1);
			try
			{
				while(this.Reader.Read())
				{
					iTotalNum = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());//获得原分配的总数
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			this.Reader.Close();
			//再获取已经申请的正台数
			string strSql2 = string.Empty;
			if(this.Sql.GetSql("Operator.Operator.GetAlreadyNum.1",ref strSql2) == -1) return -1;
			try
			{
				string strBegin,strEnd;
				strBegin = preDate.Date.ToString();
				strEnd = preDate.Date.AddDays(1).ToString();
				strSql2 = string.Format(strSql2,strBegin,strEnd,operationRoom.ID.ToString(),deptID);

			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql2 == null) return -1;
			this.ExecQuery(strSql2);
			try
			{
				while(this.Reader.Read())
				{
					iAlreadyNum = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());//获得已经申请掉的正台数
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			this.Reader.Close();
			//尚可申请的正台数
			iEnableNum = iTotalNum - iAlreadyNum;
			return iEnableNum;
		}
		/// <summary>
		/// 手术预约日期时效性判断
		/// </summary>
		/// <param name="PreDate">手术预约日期</param>
		/// <returns>Error:系统值未维护或格式非法，Before:预约时间小于现在，Over:不能申请该日的正台，OK:可以申请</returns>
		public string PreDateValidity(DateTime PreDate)
		{
			//规则：如果预约日期是明天，则判断申请时间是否过了手术申请截至时间，返回相应值
			//如果小于现在时间，返回相应值
			DateTime dtNow = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.GetSysDateTime());
			DateTime dtTomorrow = dtNow.AddDays(1).Date;
			DateTime dtLimited = DateTime.MinValue;
			if(PreDate < dtNow)//小于现在
			{return "Before";}
			else if(PreDate.Date.Date == dtNow.Date)//当日预约
			{
				//超过截至时间是否允许手术申请
				string allowApply=GetControlArgument("100031");
				if(allowApply=="Error")return "Error";
				
				if(allowApply.Trim()=="1")//允许
				{
					return "OK";
				}
				else//不允许
				{
					return "Over";
				}
			}
			else if(PreDate.Date == dtTomorrow) //预约日期是明天
			{
				//日手术申请截至时间
				string strTimeLimited = GetControlArgument("optime");
				if(strTimeLimited == "Error"||strTimeLimited==string.Empty) return "Error";
				//判断strTimeLimited是否是有效的时间格式
				try
				{
					string Today = dtNow.Year.ToString() + "-" +dtNow.Month.ToString() +"-" +dtNow.Day.ToString();
					string TodayTime = Today + " " + strTimeLimited;	
					dtLimited = Neusoft.FrameWork.Function.NConvert.ToDateTime(TodayTime);
				}
				catch
				{
					this.Err = "系统手术申请截至时间参数格式非法，请联系系统管理员！";
					this.ErrCode = "系统手术申请截至时间参数格式非法，请联系系统管理员！";
					this.WriteErr();
					return "Error"; 
				}
				if(dtNow > dtLimited)
				{
					string allowApply=GetControlArgument("100031");
					if(allowApply=="Error")return "Error";
					if(allowApply.Trim()=="1")
					{
						return "OK";
					}
					else
					{
						return "Over";
					}					
				}
			}
			return "OK";
		}
		/// <summary>
		/// 获取系统设置
		/// </summary>
		/// <returns>截至时间字符串，若为Error,则系统参数未设置</returns>
		private string GetControlArgument(string ctlID)
		{
			string strSql = string.Empty;
			string ctlValue=string.Empty;

			if(this.Sql.GetSql("QueryControlerInfo.2",ref strSql) == -1) return string.Empty;				
			if (strSql == null) return string.Empty;						
			try
			{
				strSql=string.Format(strSql,ctlID);
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					ctlValue=this.Reader[0].ToString();
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				this.WriteErr();
				if(Reader.IsClosed==false)Reader.Close();
				return "Error";
			}
			this.Reader.Close();
		
			if(ctlValue==string.Empty) 
			{
				this.Err = "系统未维护参数设置，参数代码:"+ctlID+"请联系系统管理员！";
				this.ErrCode ="系统未维护参数设置，参数代码:"+ctlID+"请联系系统管理员！";	
				this.WriteErr();
				return "Error";
			}
			return ctlValue;
		}
		#endregion
		#region 手术项目记录信息处理
		/// <summary>
		/// 添加手术记录信息
		/// </summary>
		/// <param name="OpsApp">手术申请单实例</param>
		/// <param name="OperateInfo">手术信息类实例</param>
		/// <returns>0 success -1 fail</returns>
        public int AddOperationInfo(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp, Neusoft.HISFC.Models.Operation.OperationInfo OperateInfo)
		{
			#region 添加手术记录信息
			///添加手术记录信息
			///Operation.Operation.AddOperationInfo.1
			///传入：23
			///传出：0 
			#endregion
			#region 获取手术项目基本信息
			//----------------------------------------------------
			//局部变量定义 和费用有关的信息
			string ls_ItemCode = string.Empty;	//手术项目编码
			string ls_ItemName = string.Empty;	//手术项目名称
			decimal ld_UnitPrice = 0;	//单价
			decimal ld_FeeRate = 1;		//收费比例
			int	   li_Qty = 0;			//数量
			string ls_StockUnit = string.Empty;	//单位

            ls_ItemCode = OperateInfo.OperationItem.ID.ToString();
            ls_ItemName = OperateInfo.OperationItem.Name;
            ld_UnitPrice = OperateInfo.OperationItem.Price;
			ld_FeeRate = OperateInfo.FeeRate;
			li_Qty = OperateInfo.Qty;
			ls_StockUnit = OperateInfo.StockUnit;

			//局部变量定义 和手术有关的信息
			string ls_OperateType = string.Empty;	//手术规模
			string ls_InciType = string.Empty;		//切口类型
			string ls_OpePos = string.Empty;		//手术部位

			//ls_OperateType = OpsApp.OperateType.ID.ToString();
			//ls_InciType = OpsApp.InciType.ID.ToString();
			//ls_OpePos = OpsApp.OpePos.ID.ToString();
			ls_OperateType = OperateInfo.OperateType.ID.ToString();
			ls_InciType = OperateInfo.InciType.ID.ToString();
			ls_OpePos = OperateInfo.OpePos.ID.ToString();
			//----------------------------------------------------
			#endregion
			#region 获取患者基本信息
			//--------------------------------------------------------
			//局部变量定义 患者基本信息
			string ls_ClinicCode = string.Empty;//住院流水号/门诊号
			string ls_DeptCode = string.Empty;  //住院科室
			ls_ClinicCode = OpsApp.PatientInfo.ID.ToString();
			/*
			#region 首先判断是门诊手术还是住院手术，确定应该输入的患者号			
			switch (OpsApp.Pasource)
			{
				case "1":  //门诊手术
					ls_ClinicCode = OpsApp.PatientInfo.Patient.PID.CardNo;
					break;
				case "2":  //住院手术
					ls_ClinicCode = OpsApp.PatientInfo.Patient.PID.PatientNo;
					break;
				default:
					break;
			}			
			#endregion
			*/
			ls_DeptCode = OpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID;
			//--------------------------------------------------------
			#endregion
			string strSql = string.Empty;
			string strGerm = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsGermCarrying).ToString();
			string strUrgent = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsUrgent).ToString();
			string strChange = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsChange).ToString();
			string strHeavy = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsHeavy).ToString();
			string strSpecial = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsApp.IsSpecial).ToString();
			string strValid = Neusoft.FrameWork.Function.NConvert.ToInt32(OperateInfo.IsValid).ToString();
			string strMainFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(OperateInfo.IsMainFlag).ToString();
			if(this.Sql.GetSql("Operator.Operator.AddOperationInfo.1",ref strSql) == -1) return -1;
			try
			{
				string []str2 = new string[]{
												OpsApp.ID,ls_ClinicCode,ls_DeptCode,ls_ItemCode,ls_ItemName,
												ld_UnitPrice.ToString(),ld_FeeRate.ToString(),li_Qty.ToString(),ls_StockUnit,ls_OperateType,
												ls_InciType,OpsApp.ScreenUp,strGerm,ls_OpePos,strUrgent,
												strChange,strHeavy,strSpecial,strMainFlag,OperateInfo.Remark,
												strValid,OpsApp.User.ID.ToString(),System.DateTime.Now.ToString()
											};
				//在手术记录表中增加记录
				//每行5个参数
//				strSql = string.Format(strSql,OpsApp.OperationNo,ls_ClinicCode,ls_DeptCode,ls_ItemCode,ls_ItemName,
//					ld_UnitPrice.ToString(),ld_FeeRate.ToString(),li_Qty.ToString(),ls_StockUnit,ls_OperateType,
//					ls_InciType,OpsApp.ScreenUp,strGerm,ls_OpePos,strUrgent,
//					strChange,strHeavy,strSpecial,strMainFlag,OperateInfo.Remark,
//					strValid,OpsApp.User.ID.ToString(),System.DateTime.Now.ToString());
				return this.ExecNoQuery(strSql,str2);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}			
			
		}
		/// <summary>
		/// 删除手术申请单中手术记录信息
		/// </summary>
		/// <param name="OpsApp">手术申请单实例</param>
		/// <returns>0 success -1 fail</returns>
        public int DelOperationInfo(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{
			#region 删除手术记录信息
			///删除手术记录信息
			///Operation.Operation.DelOperationInfo.1
			///传入：23
			///传出：0 
			#endregion		
			
			string strSql = string.Empty;

			if(this.Sql.GetSql("Operator.Operator.DelOperationInfo.1",ref strSql) == -1) return -1;
			try
			{				
				strSql = string.Format(strSql,OpsApp.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}
		#endregion
		#region 手术人员角色处理
		/// <summary>
		/// 手术申请单涉及的人员角色处理
		/// </summary>
		/// <param name="OpsApp">手术申请单对象</param>
		/// <returns>0 success,-1 fail</returns>
        public int ProcessRoleForApply(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{	
			//先不管三七二十一清除掉该手术申请单中原有的所有角色安排
			try
			{
				if(DelArrangeRoleAll(OpsApp) == -1) return -1;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}

			//所有角色(包含了手术医生、指导医生、助手、手术护士、麻醉医生等角色)
			try
			{
				foreach(Neusoft.HISFC.Models.Operation.ArrangeRole thisRole in OpsApp.RoleAl)
				{
					if(AddArrangeRole(OpsApp,thisRole,thisRole.RoleType.ID.ToString(),thisRole.RoleOperKind.ID.ToString(),thisRole.ForeFlag) == -1) return -1;
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			return 0;
		}
		/// <summary>
		///  添加手术人员角色
		/// </summary>
		/// <param name="OpsApp">手术申请单对象</param>
		/// <param name="Person">角色人员对象</param>
		/// <param name="strRole">角色编码</param>
		/// <param name="strOperKind">角色状态 正常/接班/直落等</param>
		/// <param name="strForeFlag">角色编码</param>
		/// <returns>0 success, -1 fail</returns>
        public int AddArrangeRole(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp, Neusoft.HISFC.Models.Operation.ArrangeRole employee, string strRole, string strOperKind, string strForeFlag)
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.AddArrangeRole.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OpsApp.ID,strRole,employee.ID.ToString(),
					employee.Name,strForeFlag,OpsApp.User.ID.ToString(),strOperKind);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 删除手术单中的所有人员角色安排
		/// </summary>
		/// <param name="OpsApp">手术申请单对象实例</param>
		/// <returns>0 success -1 fail</returns>
        public int DelArrangeRoleAll(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.DelArrangeRole.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OpsApp.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除手术单中某一角色的人员安排
		/// </summary>
		/// <param name="OpsApp">手术申请单对象</param>
		/// <param name="strRole">角色编码</param>
		/// <returns>0 success -1 fail</returns>
        public int DelArrangeRole(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp, string strRole)
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.DelArrangeRole.2",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OpsApp.ID,strRole);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}

		#endregion
		#region 手术资料处理（仪器设备）
		/// <summary>
		/// 手术申请单涉及的手术资料处理
		/// </summary>
		/// <param name="OpsApp">手术申请单对象</param>
		/// <returns>0 success,-1 fail</returns>
        public int ProcessAppaRecForApply(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{	
			//先清除掉该手术申请单中原有的所有手术资料安排信息
			try
			{
				if(DelAppaRecAll(OpsApp) == -1) return -1;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			
			//所有手术资料安排信息
			try
			{
				foreach(Neusoft.HISFC.Models.Operation.OpsApparatusRec thisRec in OpsApp.AppaRecAl)
				{
					if(AddAppaRec(thisRec) == -1) return -1;
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			return 0;
		}
		/// <summary>
		/// 增加手术资料记录信息
		/// </summary>
		/// <param name="OpsAppaRec">手术资料记录对象</param>
		/// <returns> 0 success -1 fail</returns>
		public int AddAppaRec(Neusoft.HISFC.Models.Operation.OpsApparatusRec OpsAppaRec)
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.AddAppaRec.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OpsAppaRec.OperationNo,OpsAppaRec.OpsAppa.ID.ToString(),
					OpsAppaRec.OpsAppa.Name,OpsAppaRec.foreflag.ToString(),OpsAppaRec.Qty.ToString(),
					OpsAppaRec.AppaUnit,OpsAppaRec.User.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除某一手术申请单所有手术资料记录信息
		/// </summary>
		/// <param name="OpsApp">手术申请单对象</param>
		/// <param name="strRole">角色编码</param>
		/// <returns>0 success -1 fail</returns>
        public int DelAppaRecAll(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.DelAppaRec.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,OpsApp.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			
			return this.ExecNoQuery(strSql);
		}
		#endregion
		/// <summary>
		/// 手术室更换
		/// </summary>
		/// <param name="OpsApplication">手术申请单实例</param>
		/// <returns>0 success -1 fail</returns>
        public int ChangeOperatorRoom(Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp)
		{
			#region 手术室更换
			///更换手术室
			///Operation.Operation.ChangeOperatorRoom.1
			///传入：60
			///传出：0 
			#endregion
			string strSql=string.Empty;

			if(this.Sql.GetSql("Operator.Operator.UpdateApplication.5",ref strSql)==-1) return -1;
			try
			{			
				//根据手术序号更新手术日期、手术室(执行科室)、操作人
				strSql = string.Format(strSql,OpsApp.ID,OpsApp.PreDate.ToString(),OpsApp.OperateRoom.ID.ToString(),
					OpsApp.TableType,this.Operator.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "HISFC.Operator.Operator.ChangeOperatorRoom";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;            
			}

			if (strSql == null) 
				return -1;
			
			return this.ExecNoQuery(strSql);
		}	

		/// <summary>
		/// 置手术收费标志
		/// </summary>
		/// <param name="operationNo"></param>
		/// <returns></returns>
		public int UpdateOpsFee(string operationNo)
		{
			string sql=string.Empty;

			if(this.Sql.GetSql("Operator.Operator.UpdateFee",ref sql)==-1)
			{
				return -1;
			}

			try
			{
				sql=string.Format(sql,operationNo);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="置手术收费标志出错[Operator.Operator.UpdateFee]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}

        /// <summary>
        /// 置手术作废标志
        /// </summary>
        /// <param name="operationNo"></param>
        /// <returns></returns>
        public int SetOpsStop(string operationNo)
        {
            string sql = @"

update MET_OPS_APPLY set YNVALID='0' where OPERATIONNO='{0}' and EXECSTATUS='3'
"; 
            //string.Empty;

            //if (this.Sql.GetSql("Operator.Operator.UpdateFee", ref sql) == -1)
            //{
            //    return -1;
            //}

            try
            {
                sql = string.Format(sql, operationNo);

                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "置手术作废标志" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }

        /// <summary>
        /// 根据住院号取得所有的手术
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public System.Data.DataTable QueryAllOps(string inpatientNo,string exec)
        {
            string sql = @"

SELECT app.OPERATIONNO,
   (SELECT item.ITEM_NAME FROM MET_OPS_OPERATIONITEM item 
   WHERE item.OPERATIONNO=app.OPERATIONNO
       AND item.MAIN_FLAG='1'
       AND item.YNVALID='1'
   ) OPERATIONName,
    app.PRE_DATE,
    fun_get_empl_name( app.OPS_DOCD )
FROM MET_OPS_APPLY app
WHERE  app.CLINIC_CODE='{0}'
AND app.YNVALID='1'
AND app.EXECSTATUS='3'
AND app.EXEC_DEPT='{1}'

";// string.Empty;

            //if (this.Sql.GetSql("Operator.Operator.QueryIsFee", ref sql) == -1)
            //{
            //    return -1;
            //}

            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                sql = string.Format(sql, inpatientNo, exec);

                if (this.ExecQuery(sql, ref ds) == -1)
                {
                    return null;
                }

                //没有进行手术
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else 
                    {
                        return null;
                    }
                }
                else 
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                this.Err = "查询患者手术时出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据住院号取得所有登记过的手术
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public System.Data.DataTable QueryAllRegOps(string inpatientNo, string exec)
        {
            string sql = @"

SELECT app.OPERATIONNO,
   (SELECT item.ITEM_NAME FROM MET_OPS_OPERATIONITEM item 
   WHERE item.OPERATIONNO=app.OPERATIONNO
       AND item.MAIN_FLAG='1'
       AND item.YNVALID='1'
   ) OPERATIONName,
    fun_get_empl_name( app.OPER_CODE),
    app.OPER_DATE,
    fun_get_empl_name( app.OPS_DOCD )
FROM MET_OPS_RECORD app
WHERE  app.CLINIC_CODE='{0}'
AND app.YNVALID='1'
AND app.EXEC_DEPT='{1}'

";// string.Empty;

            //if (this.Sql.GetSql("Operator.Operator.QueryIsFee", ref sql) == -1)
            //{
            //    return -1;
            //}

            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                sql = string.Format(sql, inpatientNo, exec);

                if (this.ExecQuery(sql, ref ds) == -1)
                {
                    return null;
                }

                //没有进行手术
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                this.Err = "查询患者手术时出错!" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }
        }



		/// <summary>
		/// 判断患者手术是否已收费: 1已收费、0未收费、2没有手术、-1出错
		/// </summary>
		/// <param name="inpatientNo"></param>
		/// <returns></returns>
		public int IsFee(string inpatientNo)
		{
			string sql = string.Empty;

			if(this.Sql.GetSql("Operator.Operator.QueryIsFee",ref sql)==-1)
			{
				return -1;
			}

			try
			{
				sql=string.Format(sql,inpatientNo);

				if(this.ExecQuery(sql)==-1)
				{
					return -1;
				}

				//没有进行手术
				while(this.Reader.Read())
				{
					if(this.Reader[0].ToString()=="0")
					{
						this.Reader.Close();
						return 0;
					}
				}
				this.Reader.Close();

				return 1;
			}
			catch(Exception e)
			{
				this.Err="查询患者手术费用时出错!"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 判断时候手术申请是否已经存在 -1 出错，1 不存在重复申请，2 存在重复申请
		/// </summary>
		/// <param name="InaptientNo"></param>
		/// <param name="Diagnose"></param>
		/// <param name="PreDate"></param>
		/// <returns></returns>
		public int IsExistSameApplication(string InaptientNo,string Diagnose,string PreDate)
		{
			string sql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.IsExistSameApplication",ref sql)==-1)return -1;
			try
			{
                string[] str = new string[] { InaptientNo, Diagnose, PreDate };
                //sql=string.Format(sql,InaptientNo,Diagnose,PreDate);
                if (this.ExecQuery(sql, str) == -1)
				{
					return -1;
				}

				//没有进行手术
				if(this.Reader.Read())
				{
					this.Reader.Close();
					return 2;
				}
				else
				{ //存在重复的手术申请 需要提示医生
					this.Reader.Close();
					return 1;
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return -1;
			}
		}
		/// <summary>
		/// 某个科室某天的手术申请的台序是否存在重复 ，1 不存在重复申请，2 存在重复申请
		/// </summary>
		/// <param name="InaptientNo"></param>
		/// <param name="Diagnose"></param>
		/// <param name="PreDate"></param>
		/// <returns></returns>
		public int IsExistSameApplicationTableSeq(string strBegin,string strEnd,string ExeDept,string TableType)
		{
			string sql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.IsExistSameApplicationTableSeq",ref sql)==-1)
			{
				return -1;
			}

			try
			{
				sql=string.Format(sql,ExeDept,TableType,strBegin,strEnd);
				if(this.ExecQuery(sql)==-1)
				{
					return -1;
				}

				//没有进行手术
				if(this.Reader.Read())
				{
					this.Reader.Close();
					return 1;
				}
				else
				{ //存在重复的手术申请 需要提示医生
					this.Reader.Close();
					return 2;
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return -1;
			}
		}
		/// <summary>
		/// 判断时候手术申请是否应该是正台  1 已经有人申请正台 2 没有人申请正台   -1 出错
		/// </summary>
		/// <param name="BeginDate">开始时间</param>
		/// <param name="EndDate">结束时间</param>
		/// <param name="ExeDept">执行科室</param>
		/// <param name="ExeDept">申请科室</param>
		/// <param name="Type">类型</param>
		/// <returns></returns>
		public int SameDeptApplication(string BeginDate,string EndDate,string ExeDept,string AppDept ,string Type )
		{
			string sql=string.Empty;
			if(this.Sql.GetSql("Operator.Operator.SameDeptApplication",ref sql)==-1)
			{
				return -1;
			}

			try
			{
				sql=string.Format(sql,BeginDate,EndDate,ExeDept,AppDept,Type);
				if(this.ExecQuery(sql)==-1)
				{
					return -1;
				}

				//没有进行手术 需要提示医生
				if(this.Reader.Read())
				{
					this.Reader.Close();
					return 1;
				}
				else
				{ //存在手术申请 
					this.Reader.Close();
					return 2;
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return -1;
			}
		}


        protected abstract Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfo(string id);
        protected abstract string GetEmployeeName(string id);
        public abstract ArrayList GetIcdFromApp(Neusoft.HISFC.Models.Operation.OperationAppllication opsApp);
	}
}
