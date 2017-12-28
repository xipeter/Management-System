using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Operation
{
	/// <summary>
	/// [功能描述: 麻醉登记控制类]<br></br>
	/// [创 建 者: 王铁全]<br></br>
	/// [创建时间: 2006-09-27]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public abstract class AnaeRecord : Neusoft.FrameWork.Management.Database
	{
		public AnaeRecord()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//手术申请单控制类实例
        protected abstract Neusoft.HISFC.BizLogic.Operation.Operation operationManager
        {
            get;
        }
		/// <summary>
		/// 获得指定序号的麻醉登记记录
		/// </summary>
		/// <param name="OperatorNo">手术序号</param>
		/// <returns>麻醉登记记录对象</returns>
		public Neusoft.HISFC.Models.Operation.AnaeRecord GetAnaeRecord( string operatorNo )
		{
			if(operatorNo.Length == 0)
			{
				return null;
			}
			
			string strSql = string.Empty;
			string strWhere = string.Empty;

			if(this.Sql.GetSql("Operator.AnaeRecord.GetAnaeRecord.Select.1",ref strSql) == -1) 
			{
				return null;
			}

			if(this.Sql.GetSql("Operator.AnaeRecord.GetAnaeRecord.Where.2",ref strWhere) == -1) 
			{
				return null;
			}

			strWhere = string.Format(strWhere,operatorNo);
			strSql = strSql + " \n" + strWhere;
			Neusoft.HISFC.Models.Operation.AnaeRecord anaeRecord = new Neusoft.HISFC.Models.Operation.AnaeRecord();
			//先获得关联的手术申请单
			anaeRecord.OperationApplication = operationManager.GetOpsApp(operatorNo);
			//如果手术申请单没有实际值（即可能是补登的麻醉记录），则下面的关于thisOpsRec.m_objOpsApp的赋值还是有意义的。

			//查询SQL语句已经获得，开始查询
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					anaeRecord.OperationApplication.ID = Reader[0].ToString();					//手术序号
					anaeRecord.OperationApplication.PatientInfo.ID  = Reader[1].ToString();//住院流水号/门诊号(如'ZY010000000001')
					//----------------------------------------------------------------------------------------------------------
					anaeRecord.OperationApplication.PatientInfo.PID.ID = Reader[2].ToString();//门诊卡号/病案号
					anaeRecord.OperationApplication.PatientInfo.PID.PatientNO = Reader[2].ToString();//病案号(如'0000000001')
					anaeRecord.OperationApplication.PatientInfo.PID.CardNO = Reader[2].ToString();//门诊卡号(如'0000000001')
					//----------------------------------------------------------------------------------------------------------
					anaeRecord.OperationApplication.PatientInfo.Name = Reader[3].ToString();//姓名
					anaeRecord.OperationApplication.PatientInfo.Sex.ID = Reader[4].ToString();//性别
					anaeRecord.OperationApplication.PatientSouce = Reader[5].ToString();//1门诊/2住院
					anaeRecord.OperationApplication.AnesType.ID = Reader[6].ToString();//麻醉方式
					anaeRecord.AnaeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[7].ToString());//麻醉时间
					//麻醉医师、麻醉助手的信息已经存在于thisAnaeRec.m_objOpsApp.RoleAl中
					//Reader[8] 麻醉医师
					//Reader[9] 麻醉助手
					anaeRecord.AnaeResult.ID = Reader[10].ToString();//麻醉效果
					try
					{
						anaeRecord.IsPACU = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[11].ToString());//是否入PACU,1是 0否 
					}
					catch{}
					anaeRecord.InPacuDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[12].ToString());//入(PACU)室时间
					anaeRecord.InPacuStatus.ID = Reader[13].ToString();//入(PACU)室状态
					anaeRecord.OutPacuDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[14].ToString());//出(PACU)室时间
					anaeRecord.OutPacuStatus.ID = Reader[15].ToString();//入(PACU)室状态
					anaeRecord.Memo = Reader[16].ToString();//备注
					anaeRecord.IsDemulcent = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[17].ToString());//术后镇痛，1是0否
					anaeRecord.DemulcentType.ID = Reader[18].ToString();//镇痛方式
					anaeRecord.DemulcentModel.ID = Reader[19].ToString();//泵型
					anaeRecord.DemulcentDays = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[20].ToString());//镇痛天数
					anaeRecord.PullOutDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[21].ToString());//拔管时间
					anaeRecord.PullOutOperator.ID = Reader[22].ToString();//拔管人
					anaeRecord.DemulcentEffect.ID = Reader[23].ToString();//镇痛效果
					anaeRecord.IsCharged = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[24].ToString());//0未记帐/1已记帐
					anaeRecord.ExecDept.ID = Reader[25].ToString();//执行科室
				}
			}
			catch(Exception ex)
			{
				this.Err="获得麻醉登记单信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			this.Reader.Close();	
			return anaeRecord;
		}
		/// <summary>
		/// 查询指定时间段内的麻醉登记记录列表
		/// </summary>
		/// <param name="ExeDeptID">string 执行科室代码</param>
		/// <param name="BeginDate">DateTime 起始时间</param>
		/// <param name="EndDate">DateTime 截至时间</param>
		/// <returns>麻醉登记记录列表（元素为Neusoft.HISFC.Models.Operation.AnaeRecord类型）</returns>
		public ArrayList GetAnaeRecords(string ExeDeptID,DateTime BeginDate,DateTime EndDate)
		{
			ArrayList AnaeRecordAl = new ArrayList();
			string strSql = string.Empty;
			string strWhere = string.Empty;
			if(this.Sql.GetSql("Operator.AnaeRecord.GetAnaeRecord.Select.1",ref strSql) == -1) 
			{
				return AnaeRecordAl;
			}

			if(this.Sql.GetSql("Operator.AnaeRecord.GetAnaeRecord.Where.1",ref strWhere) == -1) 
			{
				return AnaeRecordAl;
			}

			strWhere = string.Format(strWhere,ExeDeptID,BeginDate.ToString(),EndDate.ToString());
			strSql = strSql + " \n" + strWhere;
			//查询SQL语句已经获得，开始查询啦，大家注意啦！
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.AnaeRecord thisAnaeRec = new Neusoft.HISFC.Models.Operation.AnaeRecord();
					
					thisAnaeRec.OperationApplication.ID = Reader[0].ToString();					//手术序号
					//先获得关联的手术申请单
					thisAnaeRec.OperationApplication = operationManager.GetOpsApp(thisAnaeRec.OperationApplication.ID);
					//如果手术申请单没有实际值（即可能是补登的麻醉记录），则下面的关于thisOpsRec.m_objOpsApp的赋值还是有意义的。

					thisAnaeRec.OperationApplication.PatientInfo.ID  = Reader[1].ToString();//住院流水号/门诊号(如'ZY010000000001')
					//----------------------------------------------------------------------------------------------------------
					thisAnaeRec.OperationApplication.PatientInfo.PID.ID = Reader[2].ToString();//门诊卡号/病案号
					thisAnaeRec.OperationApplication.PatientInfo.PID.PatientNO = Reader[2].ToString();//病案号(如'0000000001')
					thisAnaeRec.OperationApplication.PatientInfo.PID.CardNO = Reader[2].ToString();//门诊卡号(如'0000000001')
					//----------------------------------------------------------------------------------------------------------
					thisAnaeRec.OperationApplication.PatientInfo.Name = Reader[3].ToString();//姓名
					thisAnaeRec.OperationApplication.PatientInfo.Sex.ID = Reader[4].ToString();//性别
					thisAnaeRec.OperationApplication.PatientSouce = Reader[5].ToString();//1门诊/2住院
					thisAnaeRec.OperationApplication.AnesType.ID = Reader[6].ToString();//麻醉方式
					thisAnaeRec.AnaeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[7].ToString());//麻醉时间
					//麻醉医师、麻醉助手的信息已经存在于thisAnaeRec.m_objOpsApp.RoleAl中
					//Reader[8] 麻醉医师
					//Reader[9] 麻醉助手
					thisAnaeRec.AnaeResult.ID = Reader[10].ToString();//麻醉效果
					try
					{
						thisAnaeRec.IsPACU = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[11].ToString());//是否入PACU,1是 0否 
					}
					catch{}
					thisAnaeRec.InPacuDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[12].ToString());//入(PACU)室时间
					thisAnaeRec.InPacuStatus.ID = Reader[13].ToString();//入(PACU)室状态
					thisAnaeRec.OutPacuDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[14].ToString());//出(PACU)室时间
					thisAnaeRec.OutPacuStatus.ID = Reader[15].ToString();//入(PACU)室状态
					thisAnaeRec.Memo = Reader[16].ToString();//备注
					thisAnaeRec.IsDemulcent = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[17].ToString());//术后镇痛，1是0否
					thisAnaeRec.DemulcentType.ID = Reader[18].ToString();//镇痛方式
					thisAnaeRec.DemulcentModel.ID = Reader[19].ToString();//泵型
					thisAnaeRec.DemulcentDays = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[20].ToString());//镇痛天数
					thisAnaeRec.PullOutDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[21].ToString());//拔管时间
					thisAnaeRec.PullOutOperator.ID = Reader[22].ToString();//拔管人
					thisAnaeRec.DemulcentEffect.ID = Reader[23].ToString();//镇痛效果
					thisAnaeRec.IsCharged = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[24].ToString());//0未记帐/1已记帐
					thisAnaeRec.ExecDept.ID = Reader[25].ToString();//执行科室
					AnaeRecordAl.Add(thisAnaeRec);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得麻醉登记单信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				AnaeRecordAl.Clear();
				return AnaeRecordAl;
			}
			this.Reader.Close();	
			return AnaeRecordAl;
		}
		#region 麻醉登记单操作
		/// <summary>
		/// 新增麻醉登记
		/// </summary>
		/// <param name="AnaeRecord">麻醉登记单对象</param>
		/// <returns>0 success -1 fail</returns>
		public int AddAnaeRecord(Neusoft.HISFC.Models.Operation.AnaeRecord AnaeRecord)
		{
			string strSql = string.Empty;	
			#region 获取患者基本信息
			//--------------------------------------------------------		
			//局部变量定义
			string ls_ClinicCode = string.Empty;//住院流水号/门诊号
			string ls_PatientNo = string.Empty; //病案号/病历号
			string ls_Name = string.Empty;	  //患者姓名
			string ls_Sex = string.Empty;		  //性别
			Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp;
			OpsApp = AnaeRecord.OperationApplication;
			
			ls_ClinicCode = OpsApp.PatientInfo.ID;
			ls_PatientNo = OpsApp.PatientInfo.PID.ID;
			ls_Name =  OpsApp.PatientInfo.Name;
			ls_Sex =  OpsApp.PatientInfo.Sex.ID.ToString();			
			//--------------------------------------------------------
			#endregion			
			//bool标志值转换
			string strIsPACU = Neusoft.FrameWork.Function.NConvert.ToInt32(AnaeRecord.IsPACU).ToString();
			string strDemulcent = Neusoft.FrameWork.Function.NConvert.ToInt32(AnaeRecord.IsDemulcent).ToString();
			string strChargeFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(AnaeRecord.IsCharged).ToString();
			if(this.Sql.GetSql("Operator.AnaeRecord.AddAnaeRecord.1",ref strSql)==-1) 
			{
				return -1;
			}

			try
			{				
				//手术登记表中增加记录
				//每行5个参数
				strSql = string.Format(strSql,OpsApp.ID,ls_ClinicCode,ls_PatientNo,ls_Name,ls_Sex,OpsApp.PatientSouce,
					OpsApp.AnesType.ID.ToString(),AnaeRecord.AnaeDate.ToString(),"","",AnaeRecord.AnaeResult.ID.ToString(),
					strIsPACU,AnaeRecord.InPacuDate.ToString(),AnaeRecord.InPacuStatus.ID.ToString(),AnaeRecord.OutPacuDate.ToString(),AnaeRecord.OutPacuStatus.ID.ToString(),
					AnaeRecord.Memo,strDemulcent,AnaeRecord.DemulcentType.ID.ToString(),AnaeRecord.DemulcentModel.ID.ToString(),AnaeRecord.DemulcentDays.ToString(),
					AnaeRecord.PullOutDate.ToString(),AnaeRecord.PullOutOperator.ID.ToString(),AnaeRecord.DemulcentEffect.ID.ToString(),strChargeFlag,this.Operator.ID.ToString(),
					AnaeRecord.ExecDept.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;	
			
			if(this.ExecNoQuery(strSql) == -1) return -1;
			return 0;
		}
		/// <summary>
		/// 更新麻醉登记信息
		/// </summary>
		/// <param name="AnaeRecord">麻醉登记实体对象</param>
		/// <returns>0 success -1 fail</returns>
		public int UpdateAnaeRecord(Neusoft.HISFC.Models.Operation.AnaeRecord AnaeRecord)
		{
			string strSql = string.Empty;	
			#region 获取患者基本信息
			//--------------------------------------------------------		
			//局部变量定义
			string ls_ClinicCode = string.Empty;//住院流水号/门诊号
			string ls_PatientNo = string.Empty; //病案号/病历号
			string ls_Name = string.Empty;	  //患者姓名
			string ls_Sex = string.Empty;		  //性别
			Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp = new Neusoft.HISFC.Models.Operation.OperationAppllication();
			OpsApp = AnaeRecord.OperationApplication;
			
			ls_ClinicCode = OpsApp.PatientInfo.ID;
			ls_PatientNo = OpsApp.PatientInfo.PID.ID;
			ls_Name =  OpsApp.PatientInfo.Name;
			ls_Sex =  OpsApp.PatientInfo.Sex.ID.ToString();			
			//--------------------------------------------------------
			#endregion			
			//bool标志值转换
			string strIsPACU = Neusoft.FrameWork.Function.NConvert.ToInt32(AnaeRecord.IsPACU).ToString();
			string strDemulcent = Neusoft.FrameWork.Function.NConvert.ToInt32(AnaeRecord.IsDemulcent).ToString();
			string strChargeFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(AnaeRecord.IsCharged).ToString();
			if(this.Sql.GetSql("Operator.AnaeRecord.UpdateAnaeRecord.1",ref strSql)==-1) 
			{
				return -1;
			}

			try
			{				
				//手术登记表中增加记录
				//每行5个参数
				strSql = string.Format(strSql,OpsApp.ID,ls_ClinicCode,ls_PatientNo,ls_Name,ls_Sex,OpsApp.PatientSouce,
					OpsApp.AnesType.ID.ToString(),AnaeRecord.AnaeDate.ToString(),"","",AnaeRecord.AnaeResult.ID.ToString(),
					strIsPACU,AnaeRecord.InPacuDate.ToString(),AnaeRecord.InPacuStatus.ID.ToString(),AnaeRecord.OutPacuDate.ToString(),AnaeRecord.OutPacuStatus.ID.ToString(),
					AnaeRecord.Memo,strDemulcent,AnaeRecord.DemulcentType.ID.ToString(),AnaeRecord.DemulcentModel.ID.ToString(),AnaeRecord.DemulcentDays.ToString(),
					AnaeRecord.PullOutDate.ToString(),AnaeRecord.PullOutOperator.ID.ToString(),AnaeRecord.DemulcentEffect.ID.ToString(),strChargeFlag,this.Operator.ID.ToString(),
					AnaeRecord.ExecDept.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;	
			
			if(this.ExecNoQuery(strSql) == -1) return -1;
			return 0;
		}
		#endregion
		/// <summary>
		/// 获取是否允许修改手术登记标志
		/// </summary>
		/// <returns>标志1允许修改 0不许修改，若为Error,则系统参数未设置</returns>
		public string GetModifyEnabled()
		{
			string strSql = string.Empty;
			string strFlag = string.Empty;
			if(this.Sql.GetSql("Operator.OpsRecord.GetRecordModifyFlag.1",ref strSql) == -1) 
			{
				return strFlag;				
			}

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					strFlag = this.Reader[0].ToString();
				}
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				this.WriteErr();
				return "Error";            
			}
			this.Reader.Close();		
			if(strFlag == "") 
			{
				this.Err = "系统未维护是否允许修改麻醉登记记录参数，请联系系统管理员！";
				this.ErrCode = "系统未维护是否允许修改麻醉登记记录参数，请联系系统管理员！";	
				this.WriteErr();
				return "Error";
			}
			return strFlag;
		}
	}
}
