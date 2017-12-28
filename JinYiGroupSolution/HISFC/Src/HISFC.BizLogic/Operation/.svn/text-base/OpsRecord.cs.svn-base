using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Operation
{
	/// <summary>
	/// OpsRecord 的摘要说明。
	/// 手术登记管理类
	/// 2005-01-07 Written by liling 
	/// </summary>
	public abstract class OpsRecord : Neusoft.FrameWork.Management.Database
	{
		public OpsRecord()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private Neusoft.HISFC.BizLogic.Operation.OpsTableManage tableManager = new Neusoft.HISFC.BizLogic.Operation.OpsTableManage();
		//手术申请单控制类实例
        protected abstract Neusoft.HISFC.BizLogic.Operation.Operation operationManager
        {
            get;
        }
        //private Neusoft.HISFC.Integrate.RADT radtManager = new Neusoft.HISFC.Integrate.RADT();
		/// <summary>
		/// 手术登记实体 add by huangxw
		/// </summary>
		private Neusoft.HISFC.Models.Operation.OperationRecord record = null;
		private ArrayList al=null;
		
		#region 查询手术登记单
		/// <summary>
		/// 查询指定手术序号的手术登记记录
		/// </summary>
		/// <param name="OperatorNo"></param>
		/// <returns>手术登记单对象</returns>
		public Neusoft.HISFC.Models.Operation.OperationRecord GetOperatorRecord( string operatorNO )
		{
			if(operatorNO == string.Empty)
			{
				return null;
			}
			
			string strSql = string.Empty;
			string strWhere = string.Empty;
			if(this.Sql.GetSql("Operator.OpsRecord.GetOperatorRecord.Select.1",ref strSql) == -1) 
			{
				return null;
			}

			if(this.Sql.GetSql("Operator.OpsRecord.GetOperatorRecord.Where.2",ref strWhere) == -1) 
			{
				return null;
			}

			strWhere = string.Format(strWhere,operatorNO);
			strSql = strSql + " \n" + strWhere;

            Neusoft.HISFC.Models.Operation.OperationRecord thisOpsRec = new Neusoft.HISFC.Models.Operation.OperationRecord();
            ArrayList list = QueryMyOperatorRecord(strSql);
            if (list == null || list.Count == 0)  //donggq--201009.29--{2E905D88-B8CD-48f0-BB94-EB6E30612BDE}
            {
                return null;
            }
            if (list.Count > 0)
            {
                thisOpsRec = (Neusoft.HISFC.Models.Operation.OperationRecord)list[0];
            }
			return thisOpsRec;
		}
        private ArrayList QueryMyOperatorRecord(string strSql)
        {
            al = new ArrayList();
            if (this.ExecQuery(strSql) == -1) return al;
            try
            {
                while (this.Reader.Read())
                {
                    record = new Neusoft.HISFC.Models.Operation.OperationRecord();
                    record.OperationAppllication.ID = Reader[0].ToString();					//手术序号
                    //先获得关联的手术申请单
                    //record.m_objOpsApp = m_objOperator.GetOpsApp(record.m_objOpsApp.OperationNo);
                    //如果手术申请单没有实际值（即可能是补登的手术记录），则下面的关于record.m_objOpsApp的赋值还是有意义的。

                    record.OperationAppllication.PatientInfo.ID = Reader[1].ToString();//住院流水号/门诊号(如'ZY010000000001')
                    record.OperationAppllication.PatientInfo = this.GetPatientInfo(record.OperationAppllication.PatientInfo.ID);
                    //----------------------------------------------------------------------------------------------------------
                    record.OperationAppllication.PatientInfo.PID.ID = Reader[2].ToString();//门诊卡号/病案号
                    record.OperationAppllication.PatientInfo.PID.PatientNO = Reader[2].ToString();//病案号(如'0000000001')
                    record.OperationAppllication.PatientInfo.PID.CardNO = Reader[2].ToString();//门诊卡号(如'0000000001')
                    //----------------------------------------------------------------------------------------------------------
                    record.OperationAppllication.PatientSouce = Reader[3].ToString();//1门诊/2住院
                    record.OperationAppllication.PatientInfo.Name = Reader[4].ToString();//姓名
                    record.OperationAppllication.PatientInfo.PVisit.PatientLocation.Dept.ID = Reader[5].ToString();//住院科室
                    record.OperationAppllication.PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[6].ToString();//病床号
                    record.OperationAppllication.PatientInfo.Sex.ID = Reader[7].ToString();//性别
                    record.OperationAppllication.PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[8].ToString());//生日
                    record.OperationAppllication.PatientInfo.BloodType.ID = Reader[9].ToString();//血型
                    record.OperationAppllication.OperateKind = Reader[10].ToString();					//1普通2急诊3感染					

                    if (Reader.IsDBNull(11) == false)
                    {
                        record.OperationAppllication.OperationDoctor.ID = Reader[11].ToString();//手术医生
                    }

                    if (Reader.IsDBNull(12) == false)
                    {
                        record.OperationAppllication.GuideDoctor.ID = Reader[12].ToString();//指导医生	
                    }

                    record.OperationAppllication.PreDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[13].ToString());		//手术预约时间					

                    if (Reader.IsDBNull(14) == false)
                        record.OperationAppllication.Duration = System.Convert.ToDecimal(Reader[14].ToString());		//手术预定用时					

                    record.OperationAppllication.AnesType.ID = Reader[15].ToString();					//麻醉类型					
                    //Reader[16]助手数
                    //Reader[17]洗手护士数
                    //Reader[18]随台护士数
                    //Reader[19]巡回护士数
                    record.OperationAppllication.TableType = Reader[20].ToString();					//0正台1加台2点台					

                    if (Reader.IsDBNull(21) == false)
                    {
                        record.OperationAppllication.ExeDept = this.GetDeptmentById(Reader[21].ToString());//执行科室					
                        if (record.OperationAppllication.ExeDept == null)
                            record.OperationAppllication.ExeDept = new Neusoft.HISFC.Models.Base.Department();
                        record.OperationAppllication.OperateRoom =
                            (Neusoft.HISFC.Models.Base.Department)record.OperationAppllication.ExeDept;//手术室(对于需要填申请单的手术来说，手术室即执行科室)
                    }

                    if (Reader.IsDBNull(22) == false)
                    {
                        record.OperationAppllication.OpsTable.ID = Reader[22].ToString();				//手术台
                        record.OperationAppllication.OpsTable.Name =
                            this.tableManager.GetTableNameFromID(record.OperationAppllication.OpsTable.ID.ToString());
                    }

                    if (Reader.IsDBNull(23) == false)
                    {
                        record.OperationAppllication.ApplyDoctor.ID = Reader[23].ToString();	//申请医生

                    }

                    record.OperationAppllication.ApplyDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[24].ToString());	//申请时间					
                    if (Reader.IsDBNull(25) == false)
                    {
                        record.OperationAppllication.ApproveDoctor.ID = Reader[25].ToString();//审批医生
                    }

                    record.OperationAppllication.OperationType.ID = Reader[26].ToString();				//手术规模					
                    #region 有菌、无菌不用
                    try
                    {
                        string strGerm = Reader[27].ToString();						//1 有菌 0无菌
                        record.OperationAppllication.IsGermCarrying = Neusoft.FrameWork.Function.NConvert.ToBoolean(strGerm);
                    }
                    catch { }
                    #endregion

                    record.OperationAppllication.InciType.ID = Reader[28].ToString();					//切口类型
                    record.OperationAppllication.ScreenUp = Reader[29].ToString();					//1 幕上 2 幕下
                    record.OpsDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[30].ToString());		//手术时间
                    record.AcceptDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[31].ToString());	//接患者时间
                    record.Memo = Reader[32].ToString();							//备注
                    record.OperationAppllication.BloodType.ID = Reader[33].ToString();			//血液成分（全血、血浆、血清等）				
                    //					try
                    //					{
                    //						record.m_objOpsApp.BloodNum =  System.Convert.ToDecimal(Reader[34].ToString());	//血量
                    //					}
                    //					catch{}
                    record.OperationAppllication.BloodUnit = Reader[35].ToString();			//用血单位
                    record.EnterDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[36].ToString());//入手术室时间
                    record.OutDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[37].ToString());	//出手术室时间					
                    if (Reader.IsDBNull(38) == false)
                    {
                        record.Duration = System.Convert.ToDecimal(Reader[38].ToString());		//手术实际用时
                    }
                    #region 暂时不用
                    //					try
                    //					{
                    //						string strForeSober = Reader[39].ToString();						//术前意识，1清醒/0不清醒       
                    //						record.bForeSober = Neusoft.FrameWork.Function.NConvert.ToBoolean(strForeSober);
                    //					}
                    //					catch{}
                    //					try
                    //					{
                    //						string strStepSober = Reader[40].ToString();						//术后意识，1清醒/0不清醒       
                    //						record.bStepSober = Neusoft.FrameWork.Function.NConvert.ToBoolean(strStepSober);
                    //					}
                    //					catch{}
                    //					record.ForePress = Reader[41].ToString();		//术前血压
                    //					record.StepPress = Reader[42].ToString();		//术后血压					
                    //					try
                    //					{
                    //						record.ForePulse =  System.Convert.ToDecimal(Reader[43].ToString());		//术前脉搏
                    //					}
                    //					catch{}
                    //					try
                    //					{
                    //						record.StepPulse =  System.Convert.ToDecimal(Reader[44].ToString());		//术后脉搏
                    //					}
                    //					catch{}
                    //					record.ScarNum = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[45].ToString());	//褥疮数量					
                    //					try
                    //					{
                    //						record.TransFusionQty =  System.Convert.ToDecimal(Reader[46].ToString());	//输液量
                    //					}
                    //					catch{}
                    //					record.SampleQty = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[47].ToString());	//标本数量
                    //					record.GuidtubeNum = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[48].ToString());	//引流管个数
                    //					record.BeforeReady.ID = Reader[49].ToString();	//术前准备					
                    //					try
                    //					{
                    //						string strToolExam = Reader[50].ToString();						//工具核查     
                    //						record.bToolExam = Neusoft.FrameWork.Function.NConvert.ToBoolean(strToolExam);
                    //					}
                    //					catch{}
                    //					try
                    //					{
                    //						string strSeperate = Reader[51].ToString();						//是否隔离 
                    //						record.bSeperate = Neusoft.FrameWork.Function.NConvert.ToBoolean(strSeperate);
                    //					}
                    //					catch{}
                    //					try
                    //					{
                    //						string strDanger = Reader[52].ToString();						//是否危重
                    //						record.bDanger = Neusoft.FrameWork.Function.NConvert.ToBoolean(strDanger);
                    //					}
                    //					catch{}
                    //					record.LetBlood = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[53].ToString());	//抽血次数
                    //					record.MainLine = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[54].ToString());	//静注次数
                    //					record.MusleLine = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[55].ToString());	//肌注次数
                    //					record.TransFusion = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[56].ToString());	//输液次数
                    //					record.TransOxyen = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[57].ToString());	//输氧次数
                    //					record.Stale = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[58].ToString());	//导尿次数					
                    //					try
                    //					{
                    //						string strQues = Reader[59].ToString();						//是否差错
                    //						record.bQuestion = Neusoft.FrameWork.Function.NConvert.ToBoolean(strQues);
                    //					}
                    //					catch{}  
                    #endregion
                    string strI_Infec = Reader[60].ToString();						//I类切口感染 1是 2否
                    record.IsInfected = Neusoft.FrameWork.Function.NConvert.ToBoolean(strI_Infec); 
                    if (Reader.IsDBNull(61) == false)
                    {
                        //是否死亡
                        record.IsDead = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[61].ToString());
                    }

                    record.ExtraMemo = Reader[62].ToString();			//特殊说明					

                    if (Reader.IsDBNull(63) == false)
                    {
                        //是否有效
                        record.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[63].ToString());
                    }

                    if (Reader.IsDBNull(64) == false)
                    {
                        //是否收费
                        record.IsCharged = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[64].ToString());
                    }

                    record.OperationAppllication.PatientInfo.Weight = Reader[65].ToString();//体重	
                    record.OperationAppllication.RoomID = Reader[66].ToString();//房号
                    record.OperDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[67].ToString());
                    record.BloodPressureIn = Reader[68].ToString();//手术诊断   add by huangxw	借用术前血压属性
                    record.OperationAppllication.OperationDoctor.Dept.ID = Reader[69].ToString();
                    al.Add(record);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = "获得手术登记单数组信息出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                al.Clear();
                return al;
            }

            try
            {
                foreach (Neusoft.HISFC.Models.Operation.OperationRecord obj in al)
                {
                    obj.OperationAppllication.DiagnoseAl = this.operationManager.GetIcdFromApp(obj.OperationAppllication);	//诊断列表					
                    obj.OperationAppllication.OperationInfos = this.operationManager.GetOpsInfoFromApp(obj.OperationAppllication.ID);//手术项目信息列表				
                    obj.OperationAppllication.RoleAl = this.operationManager.GetRoleFromApp(obj.OperationAppllication.ID);//人员角色列表
                    //冗余属性赋值，为突出表现层申请部分业务调用方便
                    foreach (Neusoft.HISFC.Models.Operation.ArrangeRole thisRole in obj.OperationAppllication.RoleAl)
                    {
                        if (thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper1.ToString()
                            || thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper2.ToString()
                            || thisRole.RoleType.ID.ToString() == Neusoft.HISFC.Models.Operation.EnumOperationRole.Helper3.ToString())
                            //助手医师列表
                            obj.OperationAppllication.HelperAl.Add(thisRole.Clone());
                    }
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得手术登记单数组信息出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                al.Clear();
                return al;
            }
            return al;
        }
		/// <summary>
		/// 查询指定时间段内的手术登记记录列表
		/// </summary>
		/// <param name="ExeDeptID">string 执行科室代码</param>
		/// <param name="BeginDate">DateTime 起始时间</param>
		/// <param name="EndDate">DateTime 截至时间</param>
		/// <returns>手术登记记录列表（元素为Neusoft.HISFC.Models.Operation.OperatorRecord类型）</returns>
		public ArrayList GetOperatorRecords(string ExeDeptID,DateTime BeginDate,DateTime EndDate)
		{
			al=new ArrayList();
			string strSql = string.Empty;
			string strWhere = string.Empty;

			if(this.Sql.GetSql("Operator.OpsRecord.GetOperatorRecord.Select.1",ref strSql) == -1) 
			{
				return al;
			}

			if(this.Sql.GetSql("Operator.OpsRecord.GetOperatorRecord.Where.1",ref strWhere) == -1) 
			{
				return al;
			}

			if(strSql == null || strWhere == null) 
			{
				return al;
			}

			strWhere = string.Format(strWhere,ExeDeptID,BeginDate.ToString(),EndDate.ToString());
			strSql = strSql + " \n" + strWhere;
            al = QueryMyOperatorRecord(strSql);
			return al;
		}
		#endregion

		#region 手术登记单操作
		/// <summary>
		/// 新增手术登记
		/// </summary>
		/// <param name="OpsRecord">手术登记单对象</param>
		/// <returns>0 success -1 fail</returns>
		public int AddOperatorRecord(Neusoft.HISFC.Models.Operation.OperationRecord OpsRecord)
		{
			#region 新建手术登记记录
			///新建登记记录
			///Operation.Operation.CreateApplication.1
			///传入：67
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
			string ls_SickRoom = string.Empty;  //病房号
			Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp = new Neusoft.HISFC.Models.Operation.OperationAppllication();
			OpsApp = OpsRecord.OperationAppllication;
			
			ls_ClinicCode = OpsApp.PatientInfo.ID;
			ls_PatientNo = OpsApp.PatientInfo.PID.ID;
			ls_Name =  OpsApp.PatientInfo.Name;
			ls_Sex =  OpsApp.PatientInfo.Sex.ID.ToString();
			ldt_Birthday =  OpsApp.PatientInfo.Birthday;
			ls_DeptCode =  OpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID.ToString();
			ls_BedNo =  OpsApp.PatientInfo.PVisit.PatientLocation.Bed.ID.ToString();
			ls_BloodCode =  OpsApp.PatientInfo.BloodType.ID.ToString();
			ls_SickRoom =  OpsApp.PatientInfo.PVisit.PatientLocation.Room;
			//--------------------------------------------------------
			#endregion			
			//OpsApp.ExeDept =  OpsApp.OperateRoom;//执行科室(对于需要填申请单的手术来说，手术室即执行科室)
			//bool标志值转换
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
			string strForeSober = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsSoberIn).ToString();
			string strStepSober = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsSoberOut).ToString();
			string strToolExam = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.bToolExam).ToString();
			string strSeperate = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsSeperated).ToString();
			if(OpsRecord.OperationAppllication.IsHeavy || OpsRecord.OperationAppllication.IsChange)
				OpsRecord.IsDangerous = true;
			else 
				OpsRecord.IsDangerous = false;
			string strDanger = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsDangerous).ToString();
			string strQues = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsMistaken).ToString();
			string strI_Infection = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsInfected).ToString();
			string strDie = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsDead).ToString();
			string strFee = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsCharged).ToString();
			if(OpsRecord.OperationAppllication.PatientInfo.Weight == "") 
				OpsRecord.OperationAppllication.PatientInfo.Weight = "0";
			string strOperDate = OpsRecord.OperDate.ToString();//Add By Maokb

	        string docDetp = OpsRecord.OperationAppllication.OperationDoctor.Dept.ID;//by zlw

			if(this.Sql.GetSql("Operator.OpsRecord.AddOperatorRecord.1",ref strSql)==-1) 
			{
				return -1;
			}

			try
			{				
				//手术登记表中增加记录
				//每行5个参数
				string []str = new string[]{
											   OpsApp.ID,//1
											   ls_ClinicCode,
											   ls_PatientNo,
											   OpsApp.PatientSouce,
											   ls_Name,
											   ls_DeptCode,
											   ls_BedNo,
											   ls_Sex,
											   ldt_Birthday.ToString(),
											   ls_BloodCode,//10
											   OpsApp.OperateKind,
											   OpsApp.OperationDoctor.ID.ToString(),
											   OpsApp.GuideDoctor.ID.ToString(),
											   OpsApp.PreDate.ToString(),
											   OpsApp.Duration.ToString(),
											   OpsApp.AnesType.ID.ToString(),
											   OpsApp.HelperAl.Count.ToString(),
                                               "0","0","0",//20
											   OpsApp.TableType,
											   OpsApp.ExeDept.ID.ToString(),
											   OpsApp.OpsTable.ID.ToString(),
											   OpsApp.ApplyDoctor.ID.ToString(),
											   OpsApp.ApplyDate.ToString(),//25
											   OpsApp.ApproveDoctor.ID.ToString(),
											   OpsApp.OperationType.ID.ToString(),
											   strGerm,OpsApp.InciType.ID.ToString(),
											   OpsApp.ScreenUp,
											   OpsRecord.OpsDate.ToString(),//30
											   OpsRecord.AcceptDate.ToString(),
											   OpsRecord.Memo,
											   OpsApp.BloodType.ID.ToString(),
											   OpsApp.BloodNum.ToString(),
											   OpsApp.BloodUnit,//35
											   OpsRecord.EnterDate.ToString(),
											   OpsRecord.OutDate.ToString(),
											   OpsRecord.Duration.ToString(),
											   strForeSober,
											   strStepSober,""/*OpsRecord.ForePress by huangxw*/,//41
											   OpsRecord.StepPress,
											   OpsRecord.ForePulse.ToString(),
											   OpsRecord.StepPulse.ToString(),
											   OpsRecord.BedsoreCount.ToString(),
											   OpsRecord.TransfusionQuantity.ToString(),
											   OpsRecord.SampleCount.ToString(),
											   OpsRecord.EduceFlowTubeCount.ToString(),
											   OpsRecord.BeforeReady.ID.ToString(),
											   strToolExam,strSeperate,strDanger,//50
											   OpsRecord.PhlebotmomizeTimes.ToString(),
											   OpsRecord.VeinInjectionTimes.ToString(),
											   OpsRecord.MuscleInjectionTimes.ToString(),
											   OpsRecord.TransfusionTimes.ToString(),
											   OpsRecord.TransoxygenTimes.ToString(),
											   OpsRecord.ExportUrineTimes.ToString(),
											   strQues,//57
											   strI_Infection,strDie,
											   OpsRecord.ExtraMemo,
                                               "1",strFee,//62
											   OpsRecord.OperationAppllication.PatientInfo.Weight,
											   this.Operator.ID.ToString(),
											   OpsRecord.OperationAppllication.RoomID,
											   strOperDate,
											   OpsRecord.BloodPressureIn,
											   docDetp/*医生所在科室 by zlw */
										   };
//				strSql = string.Format(strSql,OpsApp.OperationNo,ls_ClinicCode,ls_PatientNo,OpsApp.Pasource,ls_Name,
//					ls_DeptCode,ls_BedNo,ls_Sex,ldt_Birthday.ToString(),ls_BloodCode,
//					OpsApp.OperateKind,OpsApp.Ops_docd.ID.ToString(),OpsApp.Gui_docd.ID.ToString(),OpsApp.Pre_Date.ToString(),OpsApp.Duration.ToString(),
//					OpsApp.Anes_type.ID.ToString(),OpsApp.HelperAl.Count,0,0,0,
//					OpsApp.TableType,OpsApp.ExeDept.ID.ToString(),OpsApp.OpsTable.ID.ToString(),OpsApp.Apply_Doct.ID.ToString(),OpsApp.Apply_Date.ToString(),
//					OpsApp.ApprDocd.ID.ToString(),OpsApp.OperateType.ID.ToString(),strGerm,OpsApp.InciType.ID.ToString(),OpsApp.ScreenUp,
//					OpsRecord.OpsDate.ToString(),OpsRecord.ReceptDate.ToString(),OpsRecord.Remark,OpsApp.BloodType.ID.ToString(),OpsApp.BloodNum.ToString(),
//					OpsApp.BloodUnit,OpsRecord.EnterDate.ToString(),OpsRecord.OutDate.ToString(),OpsRecord.RealDuation.ToString(),strForeSober,
//					strStepSober,""/*OpsRecord.ForePress by huangxw*/,OpsRecord.StepPress,OpsRecord.ForePulse.ToString(),OpsRecord.StepPulse.ToString(),
//					OpsRecord.ScarNum.ToString(),OpsRecord.TransFusionQty.ToString(),OpsRecord.SampleQty.ToString(),OpsRecord.GuidtubeNum.ToString(),OpsRecord.BeforeReady.ID.ToString(),
//					strToolExam,strSeperate,strDanger,OpsRecord.LetBlood.ToString(),OpsRecord.MainLine.ToString(),
//					OpsRecord.MusleLine.ToString(),OpsRecord.TransFusion.ToString(),OpsRecord.TransOxyen.ToString(),OpsRecord.Stale.ToString(),strQues,
//					strI_Infection,strDie,OpsRecord.SpecialComment,"1",strFee,
//					OpsRecord.m_objOpsApp.PatientInfo.Weight,this.Operation.ID.ToString(),OpsRecord.m_objOpsApp.RoomID,strOperDate,OpsRecord.ForePress);
				if(this.ExecNoQuery(strSql,str) == -1) 
				{
					return -1;
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
		/// 更新手术登记
		/// </summary>
		/// <param name="OpsRecord">手术登记单对象</param>
		/// <returns>0 success -1 fail</returns>
		public int UpdateOperatorRecord(Neusoft.HISFC.Models.Operation.OperationRecord OpsRecord)
		{				
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
			string ls_SickRoom = string.Empty;  //病房号
			Neusoft.HISFC.Models.Operation.OperationAppllication OpsApp = new Neusoft.HISFC.Models.Operation.OperationAppllication();
			OpsApp = OpsRecord.OperationAppllication;
			
			ls_ClinicCode = OpsApp.PatientInfo.ID;
			ls_PatientNo = OpsApp.PatientInfo.PID.ID;
			ls_Name =  OpsApp.PatientInfo.Name;
			ls_Sex =  OpsApp.PatientInfo.Sex.ID.ToString();
			ldt_Birthday =  OpsApp.PatientInfo.Birthday;
			ls_DeptCode =  OpsApp.PatientInfo.PVisit.PatientLocation.Dept.ID.ToString();
			ls_BedNo =  OpsApp.PatientInfo.PVisit.PatientLocation.Bed.ID.ToString();
			ls_BloodCode =  OpsApp.PatientInfo.BloodType.ID.ToString();
			ls_SickRoom =  OpsApp.PatientInfo.PVisit.PatientLocation.Room;
			//--------------------------------------------------------
			#endregion			
			//OpsApp.ExeDept =  OpsApp.OperateRoom;//执行科室(对于需要填申请单的手术来说，手术室即执行科室)

			//bool标志值转换
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
			string strForeSober = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsSoberIn).ToString();
			string strStepSober = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsSoberOut).ToString();
			string strToolExam = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.bToolExam).ToString();
			string strSeperate = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsSeperated).ToString();
			if(OpsRecord.OperationAppllication.IsHeavy || OpsRecord.OperationAppllication.IsChange)
				OpsRecord.IsDangerous = true;
			else 
				OpsRecord.IsDangerous = false;
			string strDanger = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsDangerous).ToString();
			string strQues = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsMistaken).ToString();
			string strI_Infection = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsInfected).ToString();
			string strDie = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsDead).ToString();
			string strFee = Neusoft.FrameWork.Function.NConvert.ToInt32(OpsRecord.IsCharged).ToString();
			if(OpsRecord.OperationAppllication.PatientInfo.Weight == "") 
				OpsRecord.OperationAppllication.PatientInfo.Weight = "0";
			//by zlw
	        string docDept = OpsRecord.OperationAppllication.OperationDoctor.Dept.ID;
			if(this.Sql.GetSql("Operator.OpsRecord.UpdateOperatorRecord.1",ref strSql)==-1) return -1;
			try
			{				
				//手术登记表中增加记录
				//每行5个参数
				string []str = new string[]{
											   OpsApp.ID,ls_ClinicCode,ls_PatientNo,OpsApp.PatientSouce,ls_Name,
											   ls_DeptCode,ls_BedNo,ls_Sex,ldt_Birthday.ToString(),ls_BloodCode,
											   OpsApp.OperateKind,OpsApp.OperationDoctor.ID.ToString(),OpsApp.GuideDoctor.ID.ToString(),OpsApp.PreDate.ToString(),OpsApp.Duration.ToString(),
											   OpsApp.AnesType.ID.ToString(),OpsApp.HelperAl.Count.ToString(),"0","0","0",
											   OpsApp.TableType,OpsApp.ExeDept.ID.ToString(),OpsApp.OpsTable.ID.ToString(),OpsApp.ApplyDoctor.ID.ToString(),OpsApp.ApplyDate.ToString(),
											   OpsApp.ApproveDoctor.ID.ToString(),OpsApp.OperationType.ID.ToString(),strGerm,OpsApp.InciType.ID.ToString(),OpsApp.ScreenUp,
											   OpsRecord.OpsDate.ToString(),OpsRecord.AcceptDate.ToString(),OpsRecord.Memo,OpsApp.BloodType.ID.ToString(),OpsApp.BloodNum.ToString(),
											   OpsApp.BloodUnit,OpsRecord.EnterDate.ToString(),OpsRecord.OutDate.ToString(),OpsRecord.Duration.ToString(),strForeSober,
											   strStepSober,""/*OpsRecord.ForePress add by huangxw*/,OpsRecord.StepPress,OpsRecord.ForePulse.ToString(),OpsRecord.StepPulse.ToString(),
											   OpsRecord.BedsoreCount.ToString(),OpsRecord.TransfusionQuantity.ToString(),OpsRecord.SampleCount.ToString(),OpsRecord.EduceFlowTubeCount.ToString(),OpsRecord.BeforeReady.ID.ToString(),
											   strToolExam,strSeperate,strDanger,OpsRecord.PhlebotmomizeTimes.ToString(),OpsRecord.VeinInjectionTimes.ToString(),
											   OpsRecord.MuscleInjectionTimes.ToString(),OpsRecord.TransfusionTimes.ToString(),OpsRecord.TransoxygenTimes.ToString(),OpsRecord.ExportUrineTimes.ToString(),strQues,
											   strI_Infection,strDie,OpsRecord.ExtraMemo,"1",strFee,
											   OpsRecord.OperationAppllication.PatientInfo.Weight,this.Operator.ID.ToString(),OpsRecord.OperationAppllication.RoomID,docDept,OpsRecord.BloodPressureIn
										   };
//				strSql = string.Format(strSql,OpsApp.OperationNo,ls_ClinicCode,ls_PatientNo,OpsApp.Pasource,ls_Name,
//					ls_DeptCode,ls_BedNo,ls_Sex,ldt_Birthday.ToString(),ls_BloodCode,
//					OpsApp.OperateKind,OpsApp.Ops_docd.ID.ToString(),OpsApp.Gui_docd.ID.ToString(),OpsApp.Pre_Date.ToString(),OpsApp.Duration.ToString(),
//					OpsApp.Anes_type.ID.ToString(),OpsApp.HelperAl.Count,0,0,0,
//					OpsApp.TableType,OpsApp.ExeDept.ID.ToString(),OpsApp.OpsTable.ID.ToString(),OpsApp.Apply_Doct.ID.ToString(),OpsApp.Apply_Date.ToString(),
//					OpsApp.ApprDocd.ID.ToString(),OpsApp.OperateType.ID.ToString(),strGerm,OpsApp.InciType.ID.ToString(),OpsApp.ScreenUp,
//					OpsRecord.OpsDate.ToString(),OpsRecord.ReceptDate.ToString(),OpsRecord.Remark,OpsApp.BloodType.ID.ToString(),OpsApp.BloodNum.ToString(),
//					OpsApp.BloodUnit,OpsRecord.EnterDate.ToString(),OpsRecord.OutDate.ToString(),OpsRecord.RealDuation.ToString(),strForeSober,
//					strStepSober,""/*OpsRecord.ForePress add by huangxw*/,OpsRecord.StepPress,OpsRecord.ForePulse.ToString(),OpsRecord.StepPulse.ToString(),
//					OpsRecord.ScarNum.ToString(),OpsRecord.TransFusionQty.ToString(),OpsRecord.SampleQty.ToString(),OpsRecord.GuidtubeNum.ToString(),OpsRecord.BeforeReady.ID.ToString(),
//					strToolExam,strSeperate,strDanger,OpsRecord.LetBlood.ToString(),OpsRecord.MainLine.ToString(),
//					OpsRecord.MusleLine.ToString(),OpsRecord.TransFusion.ToString(),OpsRecord.TransOxyen.ToString(),OpsRecord.Stale.ToString(),strQues,
//					strI_Infection,strDie,OpsRecord.SpecialComment,"1",strFee,
//					OpsRecord.m_objOpsApp.PatientInfo.Weight,this.Operation.ID.ToString(),OpsRecord.m_objOpsApp.RoomID);
				if(this.ExecNoQuery(strSql,str) == -1) return -1;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
//			if (strSql == null) return -1;	
//			
//			if(this.ExecNoQuery(strSql) == -1) return -1;
			return 0;
		}
		/// <summary>
		/// 作废手术登记信息
		/// </summary>
		/// <param name="operationNo"></param>
		/// <returns></returns>
		public int CancelRecord(string operationNo)
		{
			string sql=string.Empty;
			if(this.Sql.GetSql("Operator.OpsRecord.CancelOperatorRecord.1",ref sql)==-1)return -1;
			
			sql=string.Format(sql,operationNo);
			return this.ExecNoQuery(sql);
		}

        /// <summary>
        /// 作废手术登记信息后更新申请单状态(路志鹏 2007-4-17)
        /// </summary>
        /// <param name="operationNo">手术序列号</param>
        /// <returns></returns>
        public int CacelApply(string operationNo)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Operator.OpsRecord.CancelOperatorRecord.2", ref sql) == -1) return -1;
            sql = string.Format(sql, operationNo);
            return this.ExecNoQuery(sql);
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

			if (strSql == null) 
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
				this.Err = "系统未维护是否允许修改手术登记记录参数，请联系系统管理员！";
				this.ErrCode = "系统未维护是否允许修改手术登记记录参数，请联系系统管理员！";	
				this.WriteErr();
				return "Error";
			}
			return strFlag;
		}

        protected abstract Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfo(string id);
        protected abstract Neusoft.HISFC.Models.Base.Department GetDeptmentById(string id);

        ////{80D89813-7B64-4acf-A2CD-55BFD9F1E7C6}
        public int DeleteOpsRecord(string operationNO)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("Operator.OpsRecord.DeleteOperatorRecord.1", ref strSql);

            if (returnValue < 0)
            {
                this.Err = "获取[Operator.OpsRecord.DeleteOperatorRecord.1]对应的sql语句失败";
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, operationNO);
            }
            catch (Exception ex)
            {

                this.Err = "格式化sql语句失败!" + ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);

        }
	}
}
