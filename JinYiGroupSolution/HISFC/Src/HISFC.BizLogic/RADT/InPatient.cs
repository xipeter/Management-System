using System;
using System.Collections;
using System.Data;
using System.Globalization;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Models;
using Bed=Neusoft.HISFC.Models.Base.Bed;

namespace Neusoft.HISFC.BizLogic.RADT
{
	/// <summary>
	/// 主要是完成患者的入院（ADMISSION）、出院(DISCHARGE)和转院(TRANSFER)等任务。
	/// 它提供和管理的信息包括病人自然信息(Patient Identification)，病人访问信息(Patient Visit) ,
	/// 过敏信息，病人死亡和尸检信息等。门（急）诊挂号、住院登记，出院转院管理等都以此为基类。  
	///1、	RegisterPatient
	///2、	DischargePatient 
	///3、	TransferPatient
	///4、	--ChangeOutToIn
	///5、	--ChangeInToOut
	///6、	UpdatePatient
    ///7、	ArrivePatient(2)
	///8、	CancelTransfer
	///9、	CancelDischarge
	///10、	PendingAdmit
	///11、	PendingTransfer
	///12、	PendingDischarge
	///13、	CancelPendingAdmit
	///14、	CancelPendingTransfer
	///15、	CancelPendingDischarge
	///16、	SwapPatient
	///17、	PatientQuery
	///18、	BedStatusUpdate
	///19、	DeletePatient
	///20、ChangePID
	///  </summary>
	public class InPatient : Database
	{
		/// <summary>
		/// 住院患者入出转
		/// </summary>
		public InPatient()
		{
		}

		#region 入出转

        #region 更新警戒线 {A45EE85D-B1E3-4af0-ACAD-9DAF65610611}

        /// <summary>
        /// 更新患者警戒线
        /// </summary>
        /// <param name="inpatientNO">住院流水号
        /// <param name="moneyAlert">警戒线
        /// <returns></returns>
        public int UpdatePatientAlert(string inpatientNO, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate) 
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("RADT.UpdatePatientAlert.Update", ref sql) == -1) 
            {
                this.Err = "没有找到索引为: RADT.UpdatePatientAlert.Update 的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, inpatientNO, moneyAlert.ToString(),alertType,beginDate.ToString(),endDate.ToString());
        }
        /// <summary>
        /// 更新患者警戒线(根据护士站)
        /// </summary>
        /// <param name="nurseCellID">护士站号
        /// <param name="moneyAlert">警戒线
        /// <returns></returns>
        public int UpdatePatientAlertByNurseCellID(string nurseCellID, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("RADT.UpdatePatientAlertByNurseCellID.Update", ref sql) == -1)
            {
                this.Err = "没有找到索引为: RADT.UpdatePatientAlertByNurseCellID.Update 的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, nurseCellID, moneyAlert.ToString(),alertType.ToString(),beginDate.ToString(),endDate.ToString());
        }
        /// <summary>
        /// 更新患者警戒线(根据护士站和科室)
        /// </summary>
        /// <param name="nurseCellID"></param>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        public int UpdatePatientAlertByNurseCellIDAndDept(string nurseCellID, string deptCode, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("RADT.UpdatePatientAlertByNurseCellIDAndDept.Update", ref sql) == -1)
            {
                this.Err = "没有找到索引为: RADT.UpdatePatientAlertByNurseCellIDAndDept.Update 的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, nurseCellID,deptCode ,moneyAlert.ToString(),alertType,beginDate.ToString(),endDate.ToString());
        }
        /// <summary>
        /// 更新患者警戒线(根据住院科室)
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="moneyAlert">警戒线</param>
        /// <returns></returns>
        public int UpdatePatientAlertByDeptID(string deptID, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("RADT.UpdatePatientAlertByDeptID.Update", ref sql) == -1)
            {
                this.Err = "没有找到索引为: RADT.UpdatePatientAlertByDeptID.Update 的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, deptID, moneyAlert.ToString(),alertType,beginDate.ToString(),endDate.ToString());
        }
        /// <summary>
        /// 更新患者警戒线(所有)
        /// </summary>
        /// <param name="moneyAlert">警戒线
        /// <returns></returns>
        public int UpdatePatientAlert(decimal moneyAlert,string alertType,DateTime beginDate,DateTime endDate)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("RADT.UpdatePatientAlertAll.Update", ref sql) == -1)
            {
                this.Err = "没有找到索引为: RADT.UpdatePatientAlertAll.Update 的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql,moneyAlert.ToString(),alertType,beginDate.ToString(),endDate.ToString());
        }
        /// <summary>
        /// 更新患者警戒线(合同单位)
        /// </summary>
        /// <param name="inpatientNO">住院流水号
        /// <param name="moneyAlert">警戒线
        /// <returns></returns>
        public int UpdatePatientAlertByPactID(string pactID, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("RADT.UpdatePatientAlertByPactID.Update", ref sql) == -1)
            {
                this.Err = "没有找到索引为: RADT.UpdatePatientAlertByPactID.Update 的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, pactID, moneyAlert.ToString(),alertType,beginDate.ToString(),endDate.ToString());
        }

        #endregion

        #region 患者入院登记   过期

        [Obsolete("过期改名为  RegisterInpatient",true)]
		public int InPatientRegister(PatientInfo PatientInfo)
		{
			return -1;
		}
		#endregion
		
		#region 患者入院登记
		/// <summary>
		/// 患者入院登记,同时向变更信息表中插入一条记录
		/// </summary>
		/// <param name="PatientInfo">预约床位放置在PatientInfo的bed 中</param>
		/// <returns>大于 0 成功 小于 0 失败</returns>
		public int RegisterInpatient(PatientInfo PatientInfo)
		{
			//更新住院主表
			if (InsertPatient(PatientInfo) < 0)
			{
				Err = "插入患者主表时失败";
				WriteErr();
				return -1;
			}
			
			//更新病人基本信息
			if (UpdatePatientInfo(PatientInfo) < 0)
			{
				Err = "更新患者基本信息时失败";
				WriteErr();
				return -1;
			}
			
			//更新变更记录主表
			if (SetShiftData(PatientInfo.ID, EnumShiftType.B, "住院登记", PatientInfo.PVisit.PatientLocation.Dept,PatientInfo.PVisit.PatientLocation.Dept) >= 0)
			{		
				return 0;
			}
			
			Err = "更新变更记录表失败";
			WriteErr();
			return -1;
		}

		#endregion

        /// <summary>
        /// 更新未使用的住院号为使用状态
        /// </summary>
        /// <param name="oldPatienNO">旧的住院号，未使用的</param>
        /// <returns>1成功；0,产生并发，应该重新获取住院号；-1 失败</returns>
        public int UpdatePatientNOState(string oldPatienNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("RADT.InPatient.UpdatePateintNoState", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql,
                    oldPatienNO,		//0 患者旧的住院号
                    this.Operator.ID	//1 操作员
                    );
            }
            catch
            {
                this.Err = "传入参数错误！RADT.InPatient.UpdatePateintNoState!";
                this.WriteErr();
                return -1;
            }

            int parm = this.ExecNoQuery(strSql);
            if (parm == 0)
            {
                this.Err = "该住院号已被使用。";
            }
            return parm;
        }

		#region 按就诊卡号查询患者信息

		/// <summary>
		/// 通过医疗卡号检索已经存在的患者信息
		/// </summary>
		/// <param name="CardNO">医疗卡卡号</param>
		/// <returns>返回一条患者信息记录</returns>
		public ArrayList QureyPatientInfo(string CardNO)
		{
			ArrayList al = new ArrayList();

			PatientInfo PatientInfo = new PatientInfo();
			//查询预约表
			al = this.GetPreInByCardNO(CardNO);
			if (al != null)
			{
				for (int i = 0; i < al.Count; i++)
				{
					PatientInfo = (PatientInfo) al[i];
					ArrayList al1 = new ArrayList();
					al1 = this.GetPatientInfoByCardNO(CardNO);
					if (al1 != null && al1.Count > 0 ) //by niuxinyuan 
					{
						PatientInfo obj = new PatientInfo();
						obj = (PatientInfo) al1[0];
						PatientInfo.ID = obj.ID;
						PatientInfo.ID = obj.ID;
					}
				}
			}
			//查询主表
			al = GetPatientInfoByCardNO(CardNO);
			if (al != null)
			{
				return al;
			}


			//查询患者基本信息表
			PatientInfo = QueryComPatientInfo(CardNO);
			if (PatientInfo.ID != null)
			{
				al.Add(PatientInfo);
				return al;
			}
			//查询病案表
			return null;
		}

		#endregion

		#region 取出最大的住院号
		
		[System.Obsolete("更改为GetPatientNO",true)]
		public string GetMaxPatientNo(string parm)
		{
			return null;
		}
		
		/// <summary>
		/// 取出最大的住院号---wangrc
		/// </summary>
		/// <param name="parm"></param>
		/// <returns>string -最住院号</returns>
		public string GetMaxPatientNO(string parm)
		{
			string strSql = string.Empty;
            if (Sql.GetSql("RADT.QueryMaxPatientNo.1", ref strSql) == -1) return null;
			#region SQL
			/*
			   select nvl(max(t.patient_no),'0000000001') from fin_ipr_inmaininfo t
				where t.parent_code = '[父级编码]'
				and t.current_code = '[本级编码]'
				and t.patient_no not like '{0}%'
				and t.patient_no not like '%B%'
				and t.patient_no not like '%F%'
				and t.patient_no not like '%L%'
				and t.patient_no not like '%C%'
				and t.patient_no not like '0009%'
                and t.in_state <> '6'
								*/
			#endregion
			strSql = String.Format(strSql, parm);
			return ExecSqlReturnOne(strSql, string.Empty);
		}

		#endregion

		#region	自动获得住院号 没有用到的地方，所以注释了。	
//
//		/// <summary>
//		/// 获得一个新的临时住院号-自动获得住院号用
//		/// </summary>
//		/// <returns></returns>
//		public string GetNewTempPatientNo()
//		{
//			#region "接口说明"
//
//			//获得一个新的临时住院号-自动获得住院号用
//			//RADT.Inpatient.GetNewTempPatientNo.1
//			//传入：无
//			//传出:临时住院号
//
//			#endregion
//
//			string strSql = string.Empty;
//			string strReturn = string.Empty;
//			if (Sql.GetSql("RADT.Inpatient.GetNewTempPatientNo.1", ref strSql) == 0)
//			{
//				#region SQL
//				/*
//				 select value+1 from	r_tempno where name='I' 
//				 */
//				#endregion
//				ExecQuery(strSql);
//				if (Reader.Read())
//				{
//					strReturn = Reader[0].ToString(); //查到住院号
//					strReturn = strReturn.PadLeft(10, '0'); //格式化住院号
//					Reader.Close();
//					//更新住院号
//
//					#region "接口说明"
//
//					//更新临时住院号-自动获得住院号用
//					//RADT.Inpatient.GetNewTempPatientNo.2
//					//传入：临时住院号
//					//传出:无
//
//					#endregion
//
//					if (Sql.GetSql("RADT.Inpatient.GetNewTempPatientNo.2", ref strSql) == -1) return "-1";
//					{
//						#region SQL
//						/*
//						 	update r_tempno	set	 value='{0}' where name='I'
//						*/
//						#endregion
//						
//						strSql = string.Format(strSql, strReturn);
//					}
//					if (ExecNoQuery(strSql) <= 0)
//					{
//						return "-1";
//					}
//				}
//				else
//				{
//					return "-1"; //应该插入 --待添
//				}
//			}
//			else
//			{
//				return "-1";
//			}
//			return strReturn;
//		}
//
		#endregion 

		#region 根据住院号生成住院流水号

		/// <summary>
		/// 获得新的住院流水号
		/// <memo>入院登记时候输入患者的住院号，自动生成新住院的住院流水号</memo>
		/// </summary>
		/// <param name="PatientNO">患者住院号</param>
		/// <returns>新的住院流水号</returns>
		[System.Obsolete("更改为GetNewInpatientNO",true)]
		public string GetNewInpatientNo(string PatientNO)
		{

			ArrayList al = new ArrayList();
			string strReturn = string.Empty;
			int Max = 0;
			NeuObject obj = new NeuObject();
			try
			{
				al = QueryInpatientNOByPatientNO(PatientNO); //获得住院流水号列表
				for (int i = 0; i < al.Count; i++)
				{
					obj = (NeuObject) al[i];
					strReturn = obj.ID.Substring(2, 2);
					if (Max < Neusoft.FrameWork.Function.NConvert.ToInt32(strReturn))
					{
						Max = Neusoft.FrameWork.Function.NConvert.ToInt32(strReturn);
					}
				}
			}
			catch(Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			Max++;
			strReturn = "ZY" + Max.ToString().PadLeft(2, '0') + PatientNO;

			return strReturn;
		}
		/// <summary>
		/// 获得新的住院流水号
		/// <memo>入院登记时候输入患者的住院号，自动生成新住院的住院流水号</memo>
		/// </summary>
		/// <param name="PatientNO">患者住院号</param>
		/// <returns>新的住院流水号</returns>
		public string GetNewInpatientNO(string PatientNO)
		{
			#region "接口说明"

			//获得新的住院流水号
			//RADT.InPatient>GetNewInpatientNo.1
			//传入：患者住院号
			//传出：新的患者住院流水号

			#endregion

			ArrayList al = new ArrayList();
			string strReturn = string.Empty;
			int Max = 0;
			NeuObject obj = new NeuObject();
			
			try
			{
				al = QueryInpatientNOByPatientNO(PatientNO); //获得住院流水号列表
				for (int i = 0; i < al.Count; i++)
				{
					obj = (NeuObject) al[i];
					strReturn = obj.ID.Substring(2, 2);
					if (Max < Neusoft.FrameWork.Function.NConvert.ToInt32(strReturn))
					{
						Max = Neusoft.FrameWork.Function.NConvert.ToInt32(strReturn);
					}
				}
			}
			catch(Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			Max++;
			strReturn = "ZY" + Max.ToString().PadLeft(2, '0') + PatientNO;

			return strReturn;
		}


		#endregion

		#region 通过卡号获得最大住院号

		/// <summary>
		/// 获得最大住院号by CardNO
		/// </summary>
		/// <param name="CardNO"></param>
		/// <returns></returns>
		public string GetMaxPatientNOByCardNO(string CardNO)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.GetMaxInpatientNoByCardNo.1", ref strSql) == -1) return null;

			#region SQL
			/*
			Select Max(inpatient_no)
			From fin_ipr_inmaininfo
			where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and card_no = '{0}' 
			*/
			#endregion
			try
			{
				strSql = string.Format(strSql, CardNO);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			return ExecSqlReturnOne(strSql, string.Empty);
		}
		
		[System.Obsolete("更改为GetMaxPatientNOByCardNO",true)]
		public string GetMaxInpatientNoByCardNo(string CardNO)
		{
			return null;
		}
		#endregion

		#region 获得登记患者的门诊卡号

		/// <summary>
		/// 获得登记患者的门诊卡号 ----------wangrc
		/// </summary>
		/// <param name="PatientNO"></param>
		/// <returns></returns>
		public string GetCardNOByPatientNO(string PatientNO)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.GetCardNoForEnregister.1", ref strSql) == -1) return null;
			try
			{
				#region SQL
				/*
				Select nvl(card_no,'')
				From fin_ipr_inmaininfo
				where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and patient_no = '{0}' and in_state <> '6'and rownum=1
				*/
				#endregion
				strSql = string.Format(strSql, PatientNO);
			}
			catch (Exception ex)
			{
				ErrCode = ex.Message;
				Err = ex.Message;
				WriteErr();
				return null;
			}
			return ExecSqlReturnOne(strSql, string.Empty);
		}
		[Obsolete("GetCardNoForEnregister 更改为 GetCardNOByPatientNO",true)]
		public string GetCardNoForEnregister(string PatientNO)
		{
			return null;
		}
		#endregion

		#region 获得患者的在院状态

		/// <summary>
		/// 获得患者的在院状态-----wangrc
		/// </summary>
		/// <param name="InpatientNO"></param>
		/// <returns></returns>
		public string GetInStateByInpatientNO(string InpatientNO)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.GetInStateByInpatientNo.1", ref strSql) == -1)
			{
				return null;
			}
			try
			{
				strSql = string.Format(strSql, InpatientNO);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			return ExecSqlReturnOne(strSql);
		}
		[Obsolete("更改为GetInStateByInpatientNO",true)]
		public string GetInStateByInpatientNo(string InpatientNo)
		{
			return null;
		}
		/// <summary>
		/// 获得患者的在院状态根据就诊卡号
		/// </summary>
		/// <param name="CardNO"></param>
		/// <returns></returns>
		public string GetInStateByCardNo(string CardNO)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.GetInStateByCardNo.1", ref strSql) == -1) return null;
			try
			{
				strSql = string.Format(strSql, CardNO);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			return ExecSqlReturnOne(strSql);
		}

		#endregion

		#region 检查住院号是否重复

		/// <summary>
		/// 检查表的PatientNO是否重复
		/// </summary>
		/// <param name="PatientNO"></param>
		/// <returns>0 不重复 1重复</returns>
		public int CheckIsPatientNORepeated(string PatientNO)
		{
			ArrayList al = new ArrayList();
			try
			{
				al = this.QueryInpatientNOByPatientNO(PatientNO);
				if (al.Count > 0)
				{
					return 1;
				}
			}
			catch
			{
				return 0;
			}
			return 0;
		}
		[Obsolete("更改为 CheckIsPatientNORepeated ,原来 －1 表示重复 现在改成 1 为重复，注意调用！",true)]
		public int CheckPatientNo(string PatientNO)
		{
			return 0;
		}
		#endregion

		#region 按住院号查询患者多次住院患者最基本信息

		/// <summary>
		/// 查询住院流水号-根据住院号
		/// 多次入院问题
		/// </summary>
		/// <param name="patientNO">住院号</param>
		/// <returns> 多次住院记录 ArrayList</returns>
		public ArrayList QueryInpatientNOByPatientNO(string patientNO)
		{
			string strSql = string.Empty;

			#region 接口说明

			//RADT.Inpatient.QeryInpatientNoFromPatientNo.1
			//传入：住院号
			//传出：住院流水号，姓名，在院状态

			#endregion

			if (Sql.GetSql("RADT.Inpatient.QeryInpatientNoFromPatientNo.1", ref strSql) == 0)
			{
				#region SQL
				/*	select
				 inpatient_no,name,
				 in_state,
				 DEPT_CODE,
				 dept_name,
				 in_date from fin_ipr_inmaininfo	
				 where  PARENT_CODE='[父级编码]'	and	CURRENT_CODE='[本级编码]' and  patient_no = '{0}'
				 */
				#endregion
				try
				{
					strSql = string.Format(strSql, patientNO);
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					WriteErr();
					return null;
				}
				return GetPatientInfoBySQL(strSql);
			}
			else
			{
				return null;
			}
		}
		[Obsolete("更改为 QueryInpatientNOByPatientNO ",true)]
		public ArrayList QueryInpatientNoFromPatientNo(string PatientNO)
		{
			return null;
		}
		/// <summary>
		/// 查询患者信息
		/// </summary>
		/// <param name="patientNO">患者住院号</param>
		/// <param name="bShowBaby">是否显示婴儿</param>
		/// <returns>返回患者信息</returns>
		public ArrayList QueryInpatientNOByPatientNO(string patientNO, bool bShowBaby)
		{
			string strSql = string.Empty;

			#region 接口说明

			//RADT.Inpatient.QeryInpatientNoFromPatientNo.1
			//传入：住院号
			//传出：住院流水号，姓名，在院状态

			#endregion

			if (!bShowBaby)
			{
				if (Sql.GetSql("RADT.Inpatient.QeryInpatientNoFromPatientNo.1", ref strSql) == 0)
				{
					#region SQL
					/*
					 select inpatient_no,name,in_state,DEPT_CODE,dept_name,in_date from fin_ipr_inmaininfo	where  PARENT_CODE='[父级编码]'	and	CURRENT_CODE='[本级编码]' and  patient_no = '{0}'
					 */
					#endregion
					try
					{
						strSql = string.Format(strSql, patientNO);
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						ErrCode = ex.Message;
						WriteErr();
						return null;
					}
					return GetPatientInfoBySQL(strSql);
				}
				else
				{
					return null;
				}
			}
			else
			{
				if (Sql.GetSql("RADT.Inpatient.QeryInpatientNoFromPatientNo.AndBaby", ref strSql) == 0)
				{
					#region SQL
					/*select 
					 * inpatient_no,name,
					 * in_state,
					 * DEPT_CODE,
					 * dept_name,
					 * in_date from fin_ipr_inmaininfo	
					 * where  PARENT_CODE='[父级编码]'	and	CURRENT_CODE='[本级编码]' and  patient_no like '%'||substr('{0}',3,8) */
					#endregion
					try
					{
						strSql = string.Format(strSql, patientNO);
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						ErrCode = ex.Message;
						WriteErr();
						return null;
					}
					return GetPatientInfoBySQL(strSql);
				}
				else
				{
					return null;
				}
			}
		}

		#endregion

		#region 根据传入Sql语句获得住院患者基本信息 -- 保护

		protected ArrayList GetPatientInfoBySQL(string strSql)
		{
			ArrayList al = new ArrayList();
			if (ExecQuery(strSql) == -1)
			{
				return null;
			}
			while (Reader.Read())
			{
				NeuObject obj = new NeuObject();
				obj.ID = Reader[0].ToString();
				obj.Name = Reader[1].ToString();
				obj.Memo = Reader[2].ToString();
				try
				{
					obj.User01 = Reader[3].ToString();
					obj.User02 = Reader[4].ToString();
					obj.User03 = Reader[5].ToString();
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					WriteErr();
					return null;
				}
				al.Add(obj);
			}
			Reader.Close();
			return al;
		}

		
		[System.Obsolete("更改为 GetPatientInfoBySQL",true)]
		protected ArrayList GetPatientInfo(string strSql)
		{
			return null;
		}
		#endregion

		#region 按住院流水号更新患者病历信息    ----  该函数重复,只用下一个就行
        
		/// <summary>
		/// 更新病历---wangrc
		/// </summary>
		/// <param name="InpatientNO"></param>
		/// <returns></returns>
		[System.Obsolete("已经作废，该函数与一下个重复！",true)]
		public int UpdateCase(string InpatientNO, bool IsCase)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.UpdateCase.1", ref strSql) == -1)
			{
				return -1;
			}
			
			#region SQL
			//update fin_ipr_inmaininfo set case_flag = '{1}' where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and inpatient_no = '{0}'
			#endregion
			try
			{
				strSql = string.Format(strSql, InpatientNO, NConvert.ToInt32(IsCase).ToString());
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}
        
	 
		/// <summary>
		/// 更新病例，CaseFlag ＝病案状态: 0 无需病案 1 需要病案 2 医生站形成病案 3 病案室形成病案 4病案封存
		/// </summary>
		/// <param name="InpatientNO">住院流水号</param>
		/// <param name="CaseFlag">病例标志</param>
		/// <returns></returns>
		public int UpdateCase(string InpatientNO, string CaseFlag)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.UpdateCase.1", ref strSql) == -1) return -1;
			try
			{
				strSql = string.Format(strSql, InpatientNO, CaseFlag);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		#region 按住院流水号更新患者在院状态

		/// <summary>
		/// 按住院流水号更新患者在院状态
		/// </summary>
		/// <param name="InpatientNo">住院流水号</param>
		/// <param name="inState">在院状态</param>
		/// <param name="nurseCellCode">护士站编码</param>
		/// <param name="nurseCellName">护士站名称</param>
		/// <returns></returns>
		public int UpdateInState(string InpatientNo, string inState, string nurseCellCode, string nurseCellName)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.UpdateInState.Update", ref strSql) == -1)
			{
				return -1;
			}
			#region SQL
			/*
			 * update fin_ipr_inmaininfo set IN_STATE = '{1}',
                     nurse_cell_code = '{2}',
                     nurse_cell_name = '{3}'		                          
				where PARENT_CODE='[父级编码]' 
				and CURRENT_CODE='[本级编码]' 
				and inpatient_no = '{0}'*/
			#endregion
			try
			{
				strSql = string.Format(strSql, InpatientNo, inState, nurseCellCode, nurseCellName);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		#region 删除患者基本信息 －不是患者主表   addby sun.xh@Neusoft.com

		/// <summary>
		/// 删除患者基本信息 －不是患者主表
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public int DeletePatientInfo(string cardNo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.DeletePatientInfo.1", ref strSql) == -1)
			{
				return -1;
			}
			#region SQL
			/*病人基本信息表 com_patientinfo
			  delete from com_patientinfo where card_no = '{0}'
			  */
			#endregion
			try
			{
				strSql = string.Format(strSql, cardNo);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}
			return ExecQuery(strSql);
		}

		#endregion

		#region 按住院流水号检索患者是否有病历 该过程体只有返回值
		
		/// <summary>
		/// 是否有病历
		/// </summary>
		/// <param name="InpatientNo"></param>
		/// <returns></returns>
		[System.Obsolete("被禁用，该过程体只有返回值true ，没有函数体",true)]
		public bool QueryIsHaveCase(string InpatientNo)
		{
			return true;
		}
		
		#endregion

        #region 插入住院证信息表
        ///
        ///插入住院证信息表:zz_opr_inpatientproof
        ///
        public int InsertInpatientProof(InPatientProof InPatientProof)
        {
            string strSql = string.Empty;
            if (Sql.GetSql("RADT.InPatient.InsertInPatientProofInfo.1", ref strSql) == -1) return -1;
            try
            {
                string[] s = new string[62];
                try
                {
                    s[0] = InPatientProof.Clinic_code; //就诊卡号
                    s[1] = InPatientProof.Card_no; //就诊卡号
                    s[2] = InPatientProof.Name;  //姓名
                    s[3] = InPatientProof.Idenno; //身份证
                    s[4] = InPatientProof.Sex_code.ID.ToString(); //性别
                    s[5] = InPatientProof.Birthday.ToString(); //出生日期
                    s[6] = InPatientProof.Age; //年龄
                    s[7] = InPatientProof.Dept_code.ID;//科室
                    s[8] = InPatientProof.Dept_code.Name;//科室名称
                    s[9] = InPatientProof.Room;//病室
                    s[10] = InPatientProof.Diagnose;//诊断
                    s[11] = InPatientProof.Address;//地址
                    s[12] = InPatientProof.Intext;//内容
                    s[13] = InPatientProof.Wwfs;//卧位方式
                    s[14] = InPatientProof.Is_ys;//饮食
                    s[15] = InPatientProof.Is_tj;//抬价
                    s[16] = InPatientProof.Is_zx;//自行
                    s[17] = InPatientProof.Is_my;//沐浴
                    s[18] = InPatientProof.Is_lf;//理发
                    s[19] = InPatientProof.In_date.ToString();//开证日期
                    s[20] = InPatientProof.Doct_code.ID;//医生
                    s[21] = InPatientProof.Doct_code.Name;//医生姓名
                    s[22] = InPatientProof.Inpatient_count.ToString(); //住院约计日数
                    s[23] = InPatientProof.Is_drug;//
                    s[24] = InPatientProof.Ops_type;//
                    s[25] = InPatientProof.Blood_qty.ToString();//输血数量
                    s[26]= InPatientProof.Xxfs;//X线
                    s[27] = InPatientProof.Memo;//备注
                    s[28] = InPatientProof.Memo1;//
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    WriteErr();
                }
                //strSql = string.Format(strSql, s);
                return ExecNoQuery(strSql, s);
            }
            catch (Exception ex)
            {
                Err = "赋值时候出错！" + ex.Message;
                WriteErr();
                return -1;
            }

        }

        #endregion
        #region 更新住院证信息
        ///
        ///更新住院证信息表
        ///
        public int UpdateInpatientProof(InPatientProof InPatientProof)
        {
            string strSql = string.Empty;
            if (Sql.GetSql("RADT.InPatient.UpdateInPatientProofInfo.1", ref strSql) == -1) return -1;
            try
            {
                string[] s = new string[62];
                try
                {
                    s[0] = InPatientProof.Clinic_code; //就诊卡号
                    s[1] = InPatientProof.Card_no; //就诊卡号
                    s[2] = InPatientProof.Name;  //姓名
                    s[3] = InPatientProof.Idenno; //身份证
                    s[4] = InPatientProof.Sex_code.ID.ToString(); //性别
                    s[5] = InPatientProof.Birthday.ToString(); //出生日期
                    s[6] = InPatientProof.Age; //年龄
                    s[7] = InPatientProof.Dept_code.ID;//科室
                    s[8] = InPatientProof.Dept_code.Name;//科室名称
                    s[9] = InPatientProof.Room;//病室
                    s[10] = InPatientProof.Diagnose;//诊断
                    s[11] = InPatientProof.Address;//地址
                    s[12] = InPatientProof.Intext;//内容
                    s[13] = InPatientProof.Wwfs;//卧位方式
                    s[14] = InPatientProof.Is_ys;//饮食
                    s[15] = InPatientProof.Is_tj;//抬价
                    s[16] = InPatientProof.Is_zx;//自行
                    s[17] = InPatientProof.Is_my;//沐浴
                    s[18] = InPatientProof.Is_lf;//理发
                    s[19] = InPatientProof.In_date.ToString();//开证日期
                    s[20] = InPatientProof.Doct_code.ID;//医生
                    s[21] = InPatientProof.Doct_code.Name;//医生姓名
                    s[22] = InPatientProof.Inpatient_count.ToString(); //住院约计日数
                    s[23] = InPatientProof.Is_drug;//
                    s[24] = InPatientProof.Ops_type;//
                    s[25] = InPatientProof.Blood_qty.ToString();//输血数量
                    s[26] = InPatientProof.Xxfs;//X线
                    s[27] = InPatientProof.Memo;//备注
                    s[28] = InPatientProof.Memo1;//
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    WriteErr();
                }
                //strSql = string.Format(strSql, s);
                return ExecNoQuery(strSql, s);
            }
            catch (Exception ex)
            {
                Err = "赋值时候出错！" + ex.Message;
                WriteErr();
                return -1;
            }

        }
        #endregion 

        #region 插入病人基本信息表

        /// <summary>
		/// 插入病人基本信息表-不是患者主表 表名：com_patientinfo 
		/// </summary>
		/// <param name="PatientInfo">患者基本信息</param>
		/// <returns>成功标志 0 失败，1 成功</returns>
		/// <returns></returns>
		public int  InsertPatientInfo(PatientInfo PatientInfo)
		{
			#region "接口"

			//			0 就诊卡号,          1 姓名,              2 拼音码,             3 五笔,
			//			4 出生日期,          5 性别,              6 身份证号,           7 血型,
			//			8 职业,              9 工作单位,         10 单位电话,          11 单位邮编,
			//			12 户口或家庭所在,   13 家庭电话,         14 户口或家庭邮政编码,15 籍贯,
			//			16 民族,	     17 联系人姓名,       18 联系人电话,        19 联系人住址,
			//			20 联系人关系,       21 婚姻状况,         22 国籍,              23 结算类别,
			//			24 结算类别名称,     25 合同代码,         26 合同单位名称,      27 医疗证号,
			//			28 地区,             29 医疗费用,         30 电脑号,            31 药物过敏,
			//			32 重要疾病,         33 帐户密码,         34 帐户总额,          35 上期帐户余额,
			//			36 上期银行余额,     37 欠费次数,         38 欠费金额,          39 住院来源,
			//			40 最近住院日期,     41 住院次数,         42 最近出院日期,      43 初诊日期,
			//			44 最近挂号日期,     45 违约次数,         46 结束日期,          47 备注,
			//			48 操作员,           49 操作日期

			#endregion

			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.CreatePatientInfo.1", ref strSql) == -1) return -1;
			try
			{
				string[] s = new string[62];
				try
				{
					s[0] = PatientInfo.PID.CardNO; //就诊卡号
					s[1] = PatientInfo.Name; //姓名
					s[2] = PatientInfo.SpellCode; //拼音码
					s[3] = PatientInfo.WBCode; //五笔
					s[4] = PatientInfo.Birthday.ToString(); //出生日期
					s[5] = PatientInfo.Sex.ID.ToString(); //性别
					s[6] = PatientInfo.IDCard; //身份证号
					s[7] = PatientInfo.BloodType.ID.ToString(); //血型
					s[8] = PatientInfo.Profession.ID; //职业
					s[9] = PatientInfo.CompanyName; //工作单位
					s[10] = PatientInfo.PhoneBusiness; //单位电话
					s[11] = PatientInfo.BusinessZip; //单位邮编
					s[12] = PatientInfo.AddressHome; //户口或家庭所在
					s[13] = PatientInfo.PhoneHome; //家庭电话
					s[14] = PatientInfo.HomeZip; //户口或家庭邮政编码
					s[15] = PatientInfo.DIST; //籍贯
					s[16] = PatientInfo.Nationality.ID; //民族
					s[17] = PatientInfo.Kin.Name; //联系人姓名
					s[18] = PatientInfo.Kin.RelationPhone; //联系人电话
					s[19] = PatientInfo.Kin.RelationAddress; //联系人住址
					s[20] = PatientInfo.Kin.Relation.ID; //联系人关系
					s[21] = PatientInfo.MaritalStatus.ID.ToString(); //婚姻状况
					s[22] = PatientInfo.Country.ID; //国籍
					s[23] = PatientInfo.Pact.PayKind.ID; //结算类别
					s[24] = PatientInfo.Pact.PayKind.Name; //结算类别名称
					s[25] = PatientInfo.Pact.ID; //合同代码
					s[26] = PatientInfo.Pact.Name; //合同单位名称
					s[27] = PatientInfo.SSN; //医疗证号
					s[28] = PatientInfo.AreaCode; //出生地
					s[29] = PatientInfo.FT.TotCost.ToString(); //医疗费用
					s[31] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsAlleray).ToString(); //药物过敏
					s[30] = string.Empty; //电脑号
                    s[32] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsMainDisease).ToString(); //重要疾病
					s[33] = string.Empty; //帐户密码
					s[34] = "0"; //帐户总额
					s[35] = "0"; //上期帐户余额
					s[36] = "0"; //上期银行余额
					s[37] = "0"; //欠费次数
					s[38] = "0"; //欠费金额
					s[39] = string.Empty; //住院来源
					s[40] = string.Empty; //最近住院日期
					s[41] = PatientInfo.InTimes.ToString(); //住院次数
					s[42] = string.Empty; //最近出院日期
					s[43] = GetSysDateTime().ToString(); //初诊日期
					s[44] = string.Empty; //最近挂号日期
					s[45] = "0"; //违约次数
					s[46] = string.Empty; //结束日期
					s[47] = PatientInfo.Memo; //备注
					s[48] = Operator.ID; //操作员
					s[49] = GetSysDateTime().ToString(); //操作日期
                    s[50] = Neusoft.FrameWork.Function.NConvert.ToInt32( PatientInfo.IsEncrypt).ToString();
                    s[51] = PatientInfo.NormalName;

                    //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
                    s[52] = PatientInfo.IDCardType.ID;//证件类型
                    s[53] = NConvert.ToInt32(PatientInfo.VipFlag).ToString(); //是否Vip
                    s[54] = PatientInfo.MatherName;//母亲姓名
                    s[55] = NConvert.ToInt32(PatientInfo.IsTreatment).ToString(); //是否急诊患者
                    //s[56] = PatientInfo.CaseNO;//病案号
                    s[56] = PatientInfo.PID.CaseNO;//病案号
                    //{112F6B96-DC1D-4e20-8290-0403A25B443C}
                    s[57] = PatientInfo.Insurance.ID; //保险公司编码
                    s[58] = PatientInfo.Insurance.Name; //保险公司名称
                    s[59] = PatientInfo.Kin.RelationDoorNo;//联系人地址门牌号
                    s[60] = PatientInfo.AddressHomeDoorNo;//家庭住址门牌号
                    s[61] = PatientInfo.Email;//email地址
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					WriteErr();
				}
                //strSql = string.Format(strSql, s);
                return ExecNoQuery(strSql, s);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}
			
		}
		[System.Obsolete("更改为 InsertPatientInfo",true)]	
		public int CreatePatientInfo(PatientInfo PatientInfo)
		{
			return -1;
		}
		#endregion
        #region  查询病人基本信息 com_patientinfo表
        public Neusoft.HISFC.Models.RADT.PatientInfo GetPatient(string CardNO)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo obj = new PatientInfo();
            string strSql = "";
            if (this.Sql.GetSql("RADT.InPatient.GetPatient.1", ref strSql) == -1) return null;
            strSql = string.Format(strSql, CardNO);
            if (this.ExecQuery(strSql) == -1) return null;
            while (this.Reader.Read())
            {
                obj.PID.CardNO = Reader[0].ToString(); //卡号 
                obj.Name = Reader[1].ToString();//姓名
            }
            this.Reader.Close();
            return obj;
        }
        #endregion 
        #region 更新患者基本信息

        /// <summary>
		/// 更新基本信息表－不是患者主表  表名：com_patientinfo
		/// </summary>
		/// <param name="PatientInfo"></param>
		/// <returns></returns>
		public int UpdatePatientInfo(PatientInfo PatientInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdatePatientInfo.1", ref strSql) == -1)
			{
				return -1;
			}
			
			try
			{
				string[] s = new string[62];
				try
				{
					s[0] = PatientInfo.PID.CardNO; //就诊卡号
					s[1] = PatientInfo.Name; //姓名
					s[2] = PatientInfo.SpellCode; //拼音码
					s[3] = PatientInfo.WBCode; //五笔
					s[4] = PatientInfo.Birthday.ToString(); //出生日期
					s[5] = PatientInfo.Sex.ID.ToString(); //性别
					s[6] = PatientInfo.IDCard; //身份证号
					s[7] = PatientInfo.BloodType.ID.ToString(); //血型
					s[8] = PatientInfo.Profession.ID; //职业
					s[9] = PatientInfo.CompanyName; //工作单位
					s[10] = PatientInfo.PhoneBusiness; //单位电话
					s[11] = PatientInfo.BusinessZip; //单位邮编
					s[12] = PatientInfo.AddressHome; //户口或家庭所在
					s[13] = PatientInfo.PhoneHome; //家庭电话
					s[14] = PatientInfo.HomeZip; //户口或家庭邮政编码
					s[15] = PatientInfo.DIST; //籍贯
					s[16] = PatientInfo.Nationality.ID; //民族
					s[17] = PatientInfo.Kin.Name; //联系人姓名
					s[18] = PatientInfo.Kin.RelationPhone; //联系人电话
					s[19] = PatientInfo.Kin.RelationAddress; //联系人住址
					s[20] = PatientInfo.Kin.Relation.ID; //联系人关系
					s[21] = PatientInfo.MaritalStatus.ID.ToString(); //婚姻状况
					s[22] = PatientInfo.Country.ID; //国籍
					s[23] = PatientInfo.Pact.PayKind.ID; //结算类别
					s[24] = PatientInfo.Pact.PayKind.Name; //结算类别名称
					s[25] = PatientInfo.Pact.ID; //合同代码
					s[26] = PatientInfo.Pact.Name; //合同单位名称
					s[27] = PatientInfo.SSN; //医疗证号
					s[28] = PatientInfo.AreaCode; //出生地
					s[29] = PatientInfo.FT.TotCost.ToString(); //医疗费用
                    s[31] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsAlleray).ToString(); //药物过敏
					s[30] = string.Empty; //电脑号
                    s[32] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsMainDisease).ToString(); //重要疾病
					s[33] = string.Empty; //帐户密码
					s[34] = "0"; //帐户总额
					s[35] = "0"; //上期帐户余额
					s[36] = "0"; //上期银行余额
					s[37] = "0"; //欠费次数
					s[38] = "0"; //欠费金额
					s[39] = string.Empty; //住院来源
					s[40] = GetSysDateTime(); //最近住院日期
					s[41] = PatientInfo.InTimes.ToString(); //住院次数
					s[42] = GetSysDateTime(); //最近出院日期
					s[43] = GetSysDateTime().ToString(); //初诊日期
					s[44] = GetSysDateTime(); //最近挂号日期
					s[45] = "0"; //违约次数
					s[46] = GetSysDateTime(); //结束日期
					s[47] = PatientInfo.Memo; //备注
					s[48] = Operator.ID; //操作员
					s[49] = GetSysDateTime().ToString(); //操作日期
                    s[50] = Neusoft.FrameWork.Function.NConvert.ToInt32( PatientInfo.IsEncrypt).ToString();
                    s[51] = PatientInfo.NormalName;

                    s[52] = PatientInfo.IDCardType.ID;//证件类型
                    s[53] = NConvert.ToInt32(PatientInfo.VipFlag).ToString(); //是否Vip
                    s[54] = PatientInfo.MatherName;//母亲姓名
                    s[55] = NConvert.ToInt32(PatientInfo.IsTreatment).ToString(); //是否急诊患者
                    //s[56] = PatientInfo.CaseNO;//病案号
                    s[56] = PatientInfo.PID.CaseNO;//病案号
                    //{112F6B96-DC1D-4e20-8290-0403A25B443C}
                    s[57] = PatientInfo.Insurance.ID;//保险公司编码
                    s[58] = PatientInfo.Insurance.Name;//保险公司名称
                    s[59] = PatientInfo.Kin.RelationDoorNo;//联系人地址门牌号
                    s[60] = PatientInfo.AddressHomeDoorNo;//家庭住址门牌号
                    s[61] = PatientInfo.Email; //email地址

				}
				catch (Exception ex)
				{
					Err = ex.Message;
					WriteErr();
					return -1;
				}
                return ExecNoQuery(strSql, s);
                //strSql = string.Format(strSql);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			
		}

		#endregion

		#region 插入住院主表

		/// <summary>
		/// 插入住院主表 
		/// </summary>
		/// <param name="PatientInfo">插入住院主表</param>
		/// <returns>0成功 -1失败</returns>患者基本信息
		public int InsertPatient(PatientInfo PatientInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.RegisterPatient.1", ref strSql) == -1)
			{
				return -1;
			}

			try
			{
				string[] s = new string[76];
				try
				{
					s[0] = PatientInfo.ID; // --住院流水号
					s[1] = PatientInfo.Name; //--姓名
					s[2] = PatientInfo.PID.PatientNO; //  --住院号
					s[3] = PatientInfo.PID.CardNO; //  --就诊卡号
					s[4] = PatientInfo.SSN; //  --医疗证号
					s[5] = PatientInfo.PVisit.MedicalType.ID; //    --医疗类别id zhouxs
					s[6] = PatientInfo.Sex.ID.ToString(); //  --性别
					s[7] = PatientInfo.IDCard; //  --身份证号
					s[8] = PatientInfo.Memo; //  --拼音
					s[9] = PatientInfo.Birthday.ToString(); //  --生日
					s[10] = PatientInfo.Profession.ID; //  --职业名称
					s[11] = PatientInfo.CompanyName; //  --工作单位
					s[12] = PatientInfo.PhoneBusiness; //  --工作单位电话
					s[13] = PatientInfo.User01; //  --单位邮编
					s[14] = PatientInfo.AddressHome; //  --户口或家庭地址
					s[15] = PatientInfo.PhoneHome; //  --家庭电话
					s[16] = PatientInfo.User02; //  --户口或家庭邮编
					s[17] = PatientInfo.DIST; // --籍贯name
					s[18] = PatientInfo.AreaCode; //  --出生地代码---地区
					s[19] = PatientInfo.Nationality.ID; //  --民族id
					s[20] = PatientInfo.Nationality.Name; // --民族name
					s[21] = PatientInfo.Kin.Name; //  --联系人姓名
					s[22] = PatientInfo.Kin.RelationPhone; //  --联系人电话
					s[23] = PatientInfo.Kin.RelationAddress; //  --联系人地址
					s[24] = PatientInfo.Kin.Relation.ID; //  --联系人关系id
					s[25] = PatientInfo.Kin.Relation.Name; //  --联系人关系name
					s[26] = PatientInfo.MaritalStatus.ID.ToString(); //  --婚姻状况id
					s[27] = PatientInfo.MaritalStatus.Name; // --婚姻状况name
					s[28] = PatientInfo.Country.ID; //  --国籍id
					s[29] = PatientInfo.Country.Name; //--国籍名称
					s[30] = PatientInfo.Height; //  --身高
					s[31] = PatientInfo.Weight; //  --体重
					s[32] = PatientInfo.Profession.ID; //  --职业id
					s[33] = PatientInfo.BloodType.ID.ToString(); //  --ABO血型
                    s[34] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsMainDisease).ToString(); //  --重大疾病标志
                    s[35] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsAlleray).ToString(); //  --过敏标志
					s[36] = PatientInfo.PVisit.InTime.ToString(); //  --入院日期
					s[37] = PatientInfo.PVisit.PatientLocation.Dept.ID; //  --科室代码
					s[38] = PatientInfo.PVisit.PatientLocation.Dept.Name; // --科室名称
					s[39] = PatientInfo.Pact.PayKind.ID; // --结算类别id 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
					s[40] = PatientInfo.Pact.PayKind.Name; //  --结算类别名称
					s[41] = PatientInfo.Pact.ID; // --合同代码
					s[42] = PatientInfo.Pact.Name; // --合同单位名称
					s[43] = PatientInfo.PVisit.PatientLocation.Bed.ID; // --床号
					s[44] = PatientInfo.PVisit.PatientLocation.NurseCell.ID; //--护理单元代码
					s[45] = PatientInfo.PVisit.PatientLocation.NurseCell.Name; // --护理单元名称
					s[46] = PatientInfo.PVisit.AdmittingDoctor.ID; //--医师代码(住院)
					s[47] = PatientInfo.PVisit.AdmittingDoctor.Name; //--医师姓名(住院)
					s[48] = PatientInfo.PVisit.AttendingDoctor.ID; // --医师代码(主治)
					s[49] = PatientInfo.PVisit.AttendingDoctor.Name; //--医师姓名(主治)
					s[50] = PatientInfo.PVisit.ConsultingDoctor.ID; // --医师代码(主任)
					s[51] = PatientInfo.PVisit.ConsultingDoctor.Name; //--医师姓名(主任)
					s[52] = PatientInfo.PVisit.TempDoctor.ID; //--医师代码(实习)
					s[53] = PatientInfo.PVisit.TempDoctor.Name; //--医师姓名(实习)
					s[54] = PatientInfo.PVisit.AdmittingNurse.ID; // --护士代码(责任)
					s[55] = PatientInfo.PVisit.AdmittingNurse.Name; // --护士姓名(责任)
					s[56] = PatientInfo.PVisit.Circs.ID; // --入院情况id
					s[57] = PatientInfo.PVisit.Circs.Name; // --入院情况name
					s[58] = PatientInfo.PVisit.AdmitSource.ID; // --入院途径id
					s[59] = PatientInfo.PVisit.AdmitSource.Name; // --入院途径name
					s[60] = PatientInfo.PVisit.InSource.ID; // --入院来源id 1 -门诊 2 -急诊 3 -转科 4 -转院
					s[61] = PatientInfo.PVisit.InSource.Name; // --入院来源name
					s[62] = PatientInfo.PVisit.InState.ID.ToString(); // --住院登记  i-病房接诊 -出院登记 o-出院结算 p-预约出院 n-无费退院
					s[63] = PatientInfo.PVisit.PreOutTime.ToString(); // --出院日期(预约)
					s[64] = PatientInfo.PVisit.OutTime.ToString(); // --出院日期
					if (PatientInfo.PVisit.ICULocation == null)
					{
						s[65] = "0";
					}
					else
					{
						s[65] = "1"; // --是否在ICU
					}
					s[66] = Operator.ID;
					s[67] = PatientInfo.DoctorReceiver.ID; //收住医师
					s[68] = PatientInfo.InTimes.ToString(); //住院次数
					s[69] = PatientInfo.FT.FixFeeInterval.ToString(); //床费间隔
					s[70] = PatientInfo.ClinicDiagnose; //门诊诊断
                    
					try
					{
						s[71] = PatientInfo.ExtendFlag; //是否允许日限额超标 0 不同意 1 同意
						s[72] = PatientInfo.ExtendFlag1;
						s[73] = PatientInfo.ExtendFlag2;
					}
					catch
					{
					}
                    s[74] = Neusoft.FrameWork.Function.NConvert.ToInt32( PatientInfo.IsEncrypt).ToString();
                    s[75] = PatientInfo.NormalName;
				}
				catch (Exception ex)
				{
					Err = "赋值时候出错！" + ex.Message;
					WriteErr();
					return -1;
				}
				strSql = string.Format(strSql, s);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			return ExecNoQuery(strSql);
		}
		[System.Obsolete("更改为 InsertPatient",true)]
		public int RegisterPatient(PatientInfo PatientInfo)
		{
			return 0;
		}
		#endregion

		#region 更新住院主表

		/// <summary>
		/// 更新主表
		/// </summary>
		/// <param name="PatientInfo"></param>
		/// <returns></returns>
		public int UpdatePatient(PatientInfo PatientInfo)
		{
			#region "接口说明"

			//			/接口名称 RADT.InPatient.UpdatePatient.1
			//			/max 66
			//					<!-- 0  --住院流水号,1 --姓名 2   --住院号   ,3   --就诊卡号  ,4   --医疗证号
			//			    ,5     --医疗类别,   ,6   --性别   ,7   --身份证号  ,8   --拼音     ,9   --生日
			//			    ,10   --职业代码     ,11   --工作单位    ,12   --工作单位电话      ,13   --单位邮编
			//			    ,14   --户口或家庭地址     ,15   --家庭电话   ,16   --户口或家庭邮编   , 17  --籍贯name
			//			    ,18   --出生地代码        ,19   --民族id    ,20  --民族name    ,21   --联系人姓名
			//			    ,22   --联系人电话       ,23   --联系人地址     ,24   --联系人关系id , 25   --联系人关系id 
			//			    ,26   --婚姻状况id              ,27  --婚姻状况name  ,28   --国籍id     29 --国籍名称
			//			    ,30   --身高           ,31   --体重         ,32   -- 职位id    ,33   --ABO血型
			//			    ,34   --重大疾病标志    ,35   --过敏标志            
			//			    ,36   --入院日期      ,37   --科室代码   , 38  --科室名称  , 39  --结算类别id 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
			//			    ,40   --结算类别名称   , 41  --合同代码   , 42  --合同单位名称  , 43  --床号
			//			   , 44 --护理单元代码  , 45  --护理单元名称, 46 --医师代码(住院), 47 --医师姓名(住院)
			//			   , 48 --医师代码(主治) , 49 --医师姓名(主治) , 50 --医师代码(主任) , 51 --医师姓名(主任)
			//			   , 52 --医师代码(实习) , 53 --医师姓名(实习), 54  --护士代码(责任), 55  --护士姓名(责任)
			//			   , 56  --入院情况id  , 57  --入院情况name   , 58  --入院途径id    , 59  --入院途径name      
			//			   , 60  --入院来源id 1 -门诊 2 -急诊 3 -转科 4 -转院    , 61  --入院来源name
			//			   , 62  --住院登记  i-病房接诊 -出院登记 o-出院结算 p-预约出院 n-无费退院
			//			  ,  63  --出院日期(预约)  , 64  --出院日期 , 65  --是否在ICU 0 no 1 yes ,66 操作员 -->

			#endregion

			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdatePatient.1", ref strSql) == -1)
			{
				return -1;
			}

			try
			{
				string[] s = new string[83];
				try
				{
					s[0] = PatientInfo.ID; // --住院流水号
					s[1] = PatientInfo.Name; //--姓名
					s[2] = PatientInfo.PID.PatientNO; //  --住院号
					s[3] = PatientInfo.PID.CardNO; //  --就诊卡号
					s[4] = PatientInfo.SSN; //  --医疗证号
					s[5] = PatientInfo.PVisit.MedicalType.ID; //    --医疗类别id
					s[6] = PatientInfo.Sex.ID.ToString(); //  --性别
					s[7] = PatientInfo.IDCard; //  --身份证号
					s[8] = PatientInfo.Memo; //  --拼音
					s[9] = PatientInfo.Birthday.ToString(); //  --生日
					s[10] = PatientInfo.Profession.ID; //  --职业名称
					s[11] = PatientInfo.CompanyName; //  --工作单位
					s[12] = PatientInfo.PhoneBusiness; //  --工作单位电话
					s[13] = PatientInfo.User01; //  --单位邮编
					s[14] = PatientInfo.AddressHome; //  --户口或家庭地址
					s[15] = PatientInfo.PhoneHome; //  --家庭电话
					s[16] = PatientInfo.User02; //  --户口或家庭邮编
					s[17] = PatientInfo.DIST; // --籍贯name
					s[18] = PatientInfo.AreaCode; //  --出生地代码
					s[19] = PatientInfo.Nationality.ID; //  --民族id
					s[20] = PatientInfo.Nationality.Name; // --民族name
					s[21] = PatientInfo.Kin.Name; //  --联系人姓名
					s[22] = PatientInfo.Kin.RelationPhone; //  --联系人电话
					s[23] = PatientInfo.Kin.RelationAddress; //  --联系人地址
					s[24] = PatientInfo.Kin.Relation.ID; //  --联系人关系id
					s[25] = PatientInfo.Kin.Relation.Name; //  --联系人关系name
					s[26] = PatientInfo.MaritalStatus.ID.ToString(); //  --婚姻状况id
					s[27] = PatientInfo.MaritalStatus.Name; // --婚姻状况name
					s[28] = PatientInfo.Country.ID; //  --国籍id
					s[29] = PatientInfo.Country.Name; //--国籍名称
					s[30] = PatientInfo.Height; //  --身高
					s[31] = PatientInfo.Weight; //  --体重
					s[32] = PatientInfo.Profession.Name; //  --职业id
					s[33] = PatientInfo.BloodType.ID.ToString(); //  --ABO血型
                    s[34] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsMainDisease).ToString(); //  --重大疾病标志
                    s[35] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.Disease.IsAlleray).ToString(); //  --过敏标志
					s[36] = PatientInfo.PVisit.InTime.ToString(); //  --入院日期
					s[37] = PatientInfo.PVisit.PatientLocation.Dept.ID; //  --科室代码
					s[38] = PatientInfo.PVisit.PatientLocation.Dept.Name; // --科室名称
					s[39] = PatientInfo.Pact.PayKind.ID; // --结算类别id 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
					s[40] = PatientInfo.Pact.PayKind.Name; //  --结算类别名称
					s[41] = PatientInfo.Pact.ID; // --合同代码
					s[42] = PatientInfo.Pact.Name; // --合同单位名称
					s[43] = PatientInfo.PVisit.PatientLocation.Bed.ID; // --床号
					s[44] = PatientInfo.PVisit.PatientLocation.NurseCell.ID; //--护理单元代码
					s[45] = PatientInfo.PVisit.PatientLocation.NurseCell.Name; // --护理单元名称
					s[46] = PatientInfo.PVisit.AdmittingDoctor.ID; //--医师代码(住院)
					s[47] = PatientInfo.PVisit.AdmittingDoctor.Name; //--医师姓名(住院)
					s[48] = PatientInfo.PVisit.AttendingDoctor.ID; // --医师代码(主治)
					s[49] = PatientInfo.PVisit.AttendingDoctor.Name; //--医师姓名(主治)
					s[50] = PatientInfo.PVisit.ConsultingDoctor.ID; // --医师代码(主任)
					s[51] = PatientInfo.PVisit.ConsultingDoctor.Name; //--医师姓名(主任)
					s[52] = PatientInfo.PVisit.TempDoctor.ID; //--医师代码(实习)
					s[53] = PatientInfo.PVisit.TempDoctor.Name; //--医师姓名(实习)
					s[54] = PatientInfo.PVisit.AdmittingNurse.ID; // --护士代码(责任)
					s[55] = PatientInfo.PVisit.AdmittingNurse.Name; // --护士姓名(责任)
					s[56] = PatientInfo.PVisit.Circs.ID; // --入院情况id
					s[57] = PatientInfo.PVisit.Circs.Name; // --入院情况name
					s[58] = PatientInfo.PVisit.AdmitSource.ID; // --入院途径id
					s[59] = PatientInfo.PVisit.AdmitSource.Name; // --入院途径name
					s[60] = PatientInfo.PVisit.InSource.ID; // --入院来源id 1 -门诊 2 -急诊 3 -转科 4 -转院
					s[61] = PatientInfo.PVisit.InSource.Name; // --入院来源name
					s[62] = PatientInfo.PVisit.InState.ID.ToString(); // --住院登记  i-病房接诊 -出院登记 o-出院结算 p-预约出院 n-无费退院
					s[63] = PatientInfo.PVisit.PreOutTime.ToString(); // --出院日期(预约)
					s[64] = PatientInfo.PVisit.OutTime.ToString(); // --出院日期
					try
					{
						if (PatientInfo.PVisit.ICULocation == null)
						{
							s[65] = "0";
						}
						else
						{
							s[65] = "1"; // --是否在ICU
						}
						s[66] = Operator.ID;
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						WriteErr();
					}
					s[67] = PatientInfo.Memo;
					s[68] = PatientInfo.FT.BloodLateFeeCost.ToString(); //血滞纳金
					s[69] = PatientInfo.FT.BedLimitCost.ToString(); //床位上限
					s[70] = PatientInfo.FT.AirLimitCost.ToString(); //空调上限
					s[71] = PatientInfo.ProCreateNO; //生育保险电脑号
					s[72] = PatientInfo.FT.FixFeeInterval.ToString(); //床费间隔
					s[73] = PatientInfo.FT.BedOverDeal.ToString(); //超标处理
					s[74] = PatientInfo.ExtendFlag; //是否允许日限额超标 0 不同意 1 同意
					s[75] = PatientInfo.ExtendFlag1;
					s[76] = PatientInfo.ExtendFlag2;
					s[77] = PatientInfo.ClinicDiagnose; //门诊诊断
					s[78] = PatientInfo.MainDiagnose; //住院主诊断
                    s[79] = PatientInfo.DoctorReceiver.ID;//收住医师
                    s[80] = Neusoft.FrameWork.Function.NConvert.ToInt32(PatientInfo.IsEncrypt).ToString();
                    s[81] = PatientInfo.NormalName;

                    s[82] = PatientInfo.IDCardType.ID;//证件类型
					strSql = string.Format(strSql, s);

				}
				catch (Exception ex)
				{
					Err = ex.Message;
					WriteErr();
				}
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			int parm = ExecNoQuery(strSql);
			if (parm != 1)
			{
				return parm;
			}

			//如果婴儿主表信息修改,则同时更新婴儿表中的信息
			if (PatientInfo.ID.IndexOf("B") > 0)
			{
				return UpdateBabyInfo(PatientInfo);
			}

			return 1;
		}

		/// <summary>
		/// 根据妈妈的信息,更新患者她的所有孩子的住院主表信息
		/// 在患者科室,床位和住院状态发生变化的时候调用
		/// UpdatePatient
		/// </summary>
		/// <param name="patientInfo"></param>
		/// <returns></returns>
		public int UpdatePatientByMother(PatientInfo patientInfo)
		{
			//取妈妈的所有孩子信息
			ArrayList al = QueryBabiesByMother(patientInfo.ID);
			if (al == null)
			{
				return -1;
			}

			int parm;
			//更新每个婴儿的住院主表信息
			foreach (PatientInfo baby in al)
			{
                //如果孩子已经办理了出院结算或者无费退院,则不对此婴儿进行处理    对于出院登记的患者也不应处理 add by niuxinyuan  2007-03-16
                if (baby.PVisit.InState.ID.ToString() == "O" || baby.PVisit.InState.ID.ToString() == "N" || baby.PVisit.InState.ID.ToString() == "B") continue;

				//将妈妈的科室信息付给孩子
				baby.PVisit.PatientLocation = patientInfo.PVisit.PatientLocation;
				//将妈妈的在院状态付给孩子
				baby.PVisit.InState = patientInfo.PVisit.InState;
                #region add by xuewj 2010-10-9 母亲出院登记时同时更新婴儿的出院日期 {2125627B-7267-4a9a-AFD5-D30CF5796C73}
                if (patientInfo.PVisit.InState.ID.ToString() == "B")
                {
                    baby.PVisit.OutTime = patientInfo.PVisit.PreOutTime;
                } 
                #endregion

				//更新婴儿住院主表信息
				parm = UpdatePatient(baby);
				if (parm == -1)
				{
					return parm;
				}
			}
			return 1;
		}

		/// <summary>
		/// 更新患者出院日期 特殊入院时调用
		/// </summary>
		/// <param name="inpatientNO">患者住院流水号</param>
		/// <param name="dtOutTime">出院日期</param>
		/// <returns>成功返回1 出错返回－1 未找到数据返回0</returns>
		public int UpdatePatientOutDate(string inpatientNO, DateTime dtOutTime)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.UpdatePatientOutDate", ref strSql) == -1) return -1;
			#region SQl
			/*
			    update fin_ipr_inmaininfo t
				set    t.out_date = to_date('{1}','yyyy-mm-dd hh24:mi:ss')
				where  t.parent_code = '[父级编码]'
				and    t.current_code = '[本级编码]'
				and    t.inpatient_no = '{0}'
			*/
			#endregion
			try
			{
				strSql = string.Format(strSql, inpatientNO, dtOutTime.ToString());
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		#region 更新住院主表的血滞纳金和公费日限额和日限额累计and生育保险电脑号and日限额超标金额and超标处理

		/// <summary>
		/// 更新登记时候的血滞纳金和公费日限额和日限额累计and生育保险电脑号and日限额超标金额-----wangrc
		/// </summary>
		/// <param name="patientInfo"></param>
		/// <returns>大于 0 成功 小于0 失败</returns>
		public int UpdateOtherPatientInfoForRegister(PatientInfo patientInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.UpdatePatientInfoForRegister.1", ref strSql) == -1)
			{
				return -1;
			}
			#region SQL
			/*
			  update fin_ipr_inmaininfo 
			        set    BLOOD_LATEFEE = {0} ,          --血滞纳金
			               DAY_LIMIT={1} ,                --公费药品日限额
			               LIMIT_TOT ={2},                --日限额累计
			               PROCREATE_PCNO='{4}',          --生育保险电脑号
			               LIMIT_OVERTOP={5},             --超过日限额的药品费用
			               BURSARY_TOTMEDFEE=0,           --公费药费合计
			               BED_LIMIT={6},                 --床位限制金额
			               AIR_LIMIT={7},                 --空调限制金额
			               BEDOVERDEAL='{8}',             --床费超标处理 0超标不限1超标自理
			               OWN_RATE = {9},                --自费比例
			               PAY_RATE = {10}                --自付比例
			        where  PARENT_CODE  = '[父级编码]'  
			        and    CURRENT_CODE = '[本级编码]'   
			        and    inpatient_no = '{3}' 
				*/
			#endregion
			try
			{
				//0血滞纳金1日限额2日限额累计3住院流水号4生育保险电脑号5日限额超标金额6床位超标上限7空调超标上限8超标处理 0超标不限1超标自理
				strSql = string.Format(strSql,
				                       patientInfo.FT.BloodLateFeeCost.ToString(), //0 血滞纳金
				                       patientInfo.FT.DayLimitCost.ToString(), //1 日限额
				                       patientInfo.FT.DayLimitTotCost.ToString(), //2 日限额累计
				                       patientInfo.ID, //3 住院流水号
				                       patientInfo.ProCreateNO, //4 生育保险电脑号
				                       patientInfo.FT.OvertopCost.ToString(), //5 日限额超标金额
				                       patientInfo.FT.BedLimitCost.ToString(), //6 床位超标上限
				                       patientInfo.FT.AirLimitCost.ToString(), //7 空调超标上限
				                       patientInfo.FT.BedOverDeal, //8 超标处理 0超标不限1超标自理
				                       patientInfo.FT.FTRate.OwnRate, //9 自费比例
				                       patientInfo.FT.FTRate.PayRate //10自付比例
					);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}
		#endregion

		#region 住院登记修改住院科室

		/// <summary>
		/// 更新登记患者的科室信息
		/// </summary>
		/// <param name="patientInfo"></param>
		/// <returns> 0 成功  －1 失败</returns>
		public int UpdatePatientDeptByInpatientNo(PatientInfo patientInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.UpdatePatientDeptByInpatientNo", ref strSql) == -1)
			{
				return -1;
			}
			#region SQL
			/*
			 update fin_ipr_inmaininfo
             set   dept_code = '{1}',dept_name = '{2}'
			 where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and inpatient_no = '{0}' 
			 */
			#endregion
			try
			{
				strSql =
					string.Format(strSql, patientInfo.ID, patientInfo.PVisit.PatientLocation.Dept.ID, patientInfo.PVisit.PatientLocation.Dept.Name);
			}
			catch (Exception ex)
			{
				ErrCode = ex.Message;
				Err = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

        #region 住院登记修改住院科室

        /// <summary>
        /// 更新登记患者的病区信息{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns> 0 成功  －1 失败</returns>
        public int UpdatePatientNursCellByInpatientNo(PatientInfo patientInfo)
        {
            string strSql = string.Empty;
            if (Sql.GetSql("RADT.UpdatePatientNurseCellByInpatientNo", ref strSql) == -1)
            {
                return -1;
            }
         
            try
            {
                strSql =
                    string.Format(strSql, patientInfo.ID, patientInfo.PVisit.PatientLocation.NurseCell.ID, patientInfo.PVisit.PatientLocation.NurseCell.Name);
            }
            catch (Exception ex)
            {
                ErrCode = ex.Message;
                Err = ex.Message;
                WriteErr();
                return -1;
            }
            return ExecNoQuery(strSql);
        }

        #endregion

		#region  患者信息更改 在院状态，转床，转科

		/// <summary>
		/// 患者出院登记
		/// </summary>
		/// <param name="patientInfo">患者基本信息</param>
		/// <returns></returns>
		public int RegisterOutHospital(PatientInfo patientInfo)
		{
			//定义枚举类型在院状态:出院登记
			InStateEnumService inState = new InStateEnumService();
			inState.ID = EnumInState.B.ToString();

			//更新患者在院状态,返回0则表示并发
			int parm = UpdatePatientStatus(patientInfo, inState);
			if (parm != 1) return parm;

			//如果患者不是婴儿,则更新床位信息
			if (patientInfo.ID.IndexOf("B") < 0)
			{
				//出院登记后床位信息:空床,住院号为N
				Bed newBed = patientInfo.PVisit.PatientLocation.Bed.Clone();
				newBed.Status.ID = EnumBedStatus.U.ToString();
				newBed.InpatientNO = "N";

				//更新床位状态,并判断并发
				parm = UpdateBedStatus(newBed, patientInfo.PVisit.PatientLocation.Bed);
				if (parm <= 0)
				{
					return parm;
				}
			}
			//变更信息处理
			if (SetShiftData(patientInfo.ID, EnumShiftType.O,
			                 "出院登记", patientInfo.PVisit.PatientLocation.Dept, patientInfo.PVisit.PatientLocation.NurseCell) < 0)
				return -1;

			return 1;
		}
		[System.Obsolete("更改为 RegisterOutHospital ",true)]
		public int InpatientOutorBack(PatientInfo patientInfo)
		{
			return 0;
		}
		#endregion

		#region 更新患者状态

		/// <summary>
		/// 更新患者状态 以住院流水号为主键
		/// </summary>
		/// <param name="patientInfo">患者基本信息</param>
		/// <param name="patientStatus">患者状态</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int UpdatePatientStatus( PatientInfo patientInfo, InStateEnumService patientStatus )
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdatePatientStatus.1", ref strSql) == -1)
			{
				return -1;
			}
		
			#region SQL
			/*
			        UPDATE 	FIN_IPR_INMAININFO  
					SET    	IN_STATE = '{2}',    --更新后的在院状态
							ZG = '{3}'  ,        --转归
							OUT_DATE = to_date('{4}','yyyy-mm-dd HH24:mi:ss') 
					WHERE  	PARENT_CODE  = '[父级编码]' 
					  AND   CURRENT_CODE = '[本级编码]'  
					  AND   INPATIENT_NO = '{0}' 
					  AND   IN_STATE     = '{5}' 
			*/
			#endregion
			try
			{
				strSql = string.Format(strSql,
				                       patientInfo.ID, //0患者住院流水号
				                       patientInfo.Name, //1患者姓名
                                       patientStatus.ID.ToString(), //2更新后的在院状态
				                       patientInfo.PVisit.ZG.ID, //3患者转归信息
				                       patientInfo.PVisit.PreOutTime.ToString(), //4预出院日期
				                       patientInfo.PVisit.InState.ID.ToString() //5更新前的在院状态,用于判断并发
					);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.UpdatePatientStatus.1";
				WriteErr();
				return -1;
			}

			int parm = ExecNoQuery(strSql);
			if (parm != 1) return parm;


			//更新患者状态时同步婴儿信息----如果操作的患者是母亲并且不是出院结算,则更新婴儿的在院状态
			if (patientInfo.IsHasBaby && patientInfo.PVisit.InState.ID.ToString() != "O")
			{
				//母亲信息
				PatientInfo motherInfo = patientInfo.Clone();
				//母亲在院状态
				motherInfo.PVisit.InState.ID = patientStatus.ID;
				//同步婴儿信息
				if (UpdatePatientByMother(motherInfo) == -1)
				{
					return -1;
				}
			}

			return 1;
		}

		#endregion

		#region 修改患者信息

		
		#region 删除住院主表信息

		/// <summary>
		/// 删除患者信息-删除一个患者的信息资料
		/// </summary>
		/// <param name="patientInfo">患者基本信息</param>
		/// <returns>0 成功 -1失败</returns>
		[System.Obsolete("过期，废弃，没有应用的位置",true)]
		public int DeletePatient(PatientInfo patientInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.DeletePatient.1", ref strSql) == -1)
			{
				return -1;
			}
			
			#region SQL
			/*
			 delete fin_ipr_inmaininfo	 WHERE PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]'  and  inpatient_no	= '{0}'		
			 */
			#endregion
			
			try
			{
				strSql = string.Format(strSql, patientInfo.ID);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.DeletePatient.1";
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		#endregion

		#region 更改病人住院号

		/// <summary>
		/// 变化住院号-暂时不写
		/// </summary>
		/// <param name="PatientInfo">患者基本信息</param>
		/// <param name="newPatientNo">新的住院号</param>
		/// <returns></returns>
		[System.Obsolete("过期，废弃，没有应用的位置",true)]
		public int ChangePID(PatientInfo PatientInfo, string newPatientNo)
		{
			#region 接口说明

			//变化住院号
			//RADT.InPatient.ChangePID.1
			//传入：0 InpatientNo住院流水号,1患者姓名,2old住院号,3新住院号
			//传出：0 

			#endregion

			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.ChangePID.1", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, PatientInfo.ID, PatientInfo.Name, PatientInfo.PID.PatientNO, newPatientNo);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.ChangePID.1";
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		#region 转科操作

		/// <summary>
		/// 转移患者申请/取消 -换科室，换病区
		/// 也可用更新患者信息来做将TempLocation付给申请的科室 
		/// </summary>
		/// <param name="patientInfo">患者信息</param>
		/// <param name="newLocation">新的位置信息</param>
		/// <param name="isCancel">是否取消</param>
		/// <returns>0,没有更新数据,1成功 -1失败</returns>
		public int TransferPatientApply(PatientInfo patientInfo, Location newLocation, bool isCancel, string state)
		{
			//转科
			if (newLocation.Dept.ID != patientInfo.PVisit.PatientLocation.Dept.ID || newLocation.NurseCell.ID != patientInfo.PVisit.PatientLocation.NurseCell.ID)
			{
				int parm;
				//取转出申请序号
				int intHappenNo = CheckShiftOutHappenNo(patientInfo.ID, patientInfo.PVisit.PatientLocation, state);
				//如果是转科申请
				if (isCancel == false)
				{
					//如果已存在转科申请,则更新此转科申请
					if (intHappenNo > 0)
					{
						parm = UpdateShiftDept(patientInfo.ID, intHappenNo, state, "1", newLocation);
						if (parm < 1)
						{
							return parm;
						}
					}
					else
					{
						//如果没有已存在的转科申请,则插入一条新的转科申请
						if (InsertShiftDept(patientInfo.ID, patientInfo.PVisit.PatientLocation, newLocation, "1", newLocation.Dept.Memo) != 1)
						{
							return -1;
						}
					}
				}
				else
				{
					//取消转科
					if (intHappenNo <= 0)
					{
						Err = "无效的申请序号";
						return -1;
					}
					parm = UpdateShiftDept(patientInfo.ID, intHappenNo, state, "3", newLocation);
					if (parm < 1)
					{
						return parm;
					}
				}
			}

			return 1;
		}

		#endregion

		#region 查找转科申请序号 --私有

		/// <summary>
		/// 查找转入到某科室的转科申请序号
		/// </summary>
		/// <param name="InpatientNo">患者住院流水号</param>
		/// <param name="newLocation">转入科室信息</param>
		/// <param name="Type">转科状态</param>
		/// <returns></returns>
		private int CheckShiftInHappenNo(string InpatientNo, Location newLocation, string Type)
		{
			string strSQL = string.Empty;
			int intHappenNo = 0;
			//取SQL语句
			if (Sql.GetSql("RADT.InPatient.CheckShiftInHappenNo.1", ref strSQL) == -1)
			{
				return -1;
			}

			//格式化参数
			try
			{
				strSQL = string.Format(strSQL,
				                       InpatientNo, //患者住院流水号
				                       newLocation.Dept.ID, //转入科室编码
				                       newLocation.NurseCell.ID, //转入护理站编码
				                       Type //转科状态
					);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.CheckShiftInHappenNo.1";
			    WriteErr();
				return -1;
			}

			if (ExecQuery(strSQL) < 0)
			{
				return -1;
			}
//			if(this.Reader.HasRows) {
			if (Reader.Read())
			{
				intHappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());
				Reader.Close();
			}
			//返回序号
			return intHappenNo;
		}


		/// <summary>
		/// 查找转出到某科室的转科申请序号
		/// </summary>
		/// <param name="inpatientNo">患者住院流水号</param>
		/// <param name="location">转出科室信息</param>
		/// <param name="type">转科状态</param>
		/// <returns></returns>
		private int CheckShiftOutHappenNo(string inpatientNo, Location location, string type)
		{
			string strSQL = string.Empty;
			int intHappenNo = 0;
			
			//取SQL语句
			if (Sql.GetSql("RADT.InPatient.CheckShiftOutHappenNo.1", ref strSQL) == -1)
			{
				return -1;
			}
			
			#region SQL
			/*
			    select 	NVL(happen_no,0) 
				from  	fin_ipr_shiftapply  
				WHERE 	PARENT_CODE  = '[父级编码]' 
				AND    	CURRENT_CODE = '[本级编码]' 
				AND    	inpatient_no = '{0}'  
				AND    	old_dept_code= '{1}'     
				AND    	shift_state  in('1','0') --当前状态,0未生效,1转科申请,2确认,3取消申请
			 */
			#endregion
			
			//格式化参数
			try
			{
				strSQL = string.Format(strSQL, inpatientNo, location.Dept.ID);
			}
			catch(Exception ee)
			{
				Err = ee.Message;
				WriteErr();
				return -1;
			}

			if (ExecQuery(strSQL) < 0)
			{
				return -1;
			}
			try
			{
				if (Reader.Read())
				{
					intHappenNo = NConvert.ToInt32(Reader[0].ToString());
		
				}
			}
			catch(Exception ee)
			{
				Reader.Close();
				Err = ee.Message;
				WriteErr();
				return -1;
			}
			
			Reader.Close();
			//返回序号
			return intHappenNo;
		}

		#endregion

		#region 转床，转科室，转病区

		/// <summary>
		/// 转移患者 -换床，换科室，换病区
		/// 需要事务操作(更新住院主表，更新病床表,更新变更表)
		/// </summary>
		/// <param name="PatientInfo">患者信息</param>
		/// <param name="newLocation">新的位置信息</param>
		/// <returns>0没有更新(并发操作),1成功 -1失败</returns>
		public int TransferPatient(PatientInfo PatientInfo, Location newLocation)
		{
			//转病区
			if (newLocation.NurseCell.ID == string.Empty)
			{
				newLocation.NurseCell.ID = PatientInfo.PVisit.PatientLocation.NurseCell.ID;
				newLocation.NurseCell.Name = PatientInfo.PVisit.PatientLocation.NurseCell.Name;
			}
			//转科
			if (newLocation.Dept.ID == string.Empty)
			{
				newLocation.Dept.ID = PatientInfo.PVisit.PatientLocation.Dept.ID;
				newLocation.Dept.Name = PatientInfo.PVisit.PatientLocation.Dept.Name;
			}
			//转床
			if (newLocation.Bed.ID == string.Empty)
			{
				newLocation.Bed.ID = PatientInfo.PVisit.PatientLocation.Bed.ID;
			}
			//更新患者基本信息表
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.TransferPatient.1", ref strSql) == -1)
				#region SQL
				/*UPDATE 	FIN_IPR_INMAININFO 
					SET    	NURSE_CELL_CODE='{7}' ,    -- 变更后的护理站编码
					NURSE_CELL_NAME='{8}',     -- 变更后的护理站名称
					DEPT_CODE='{9}',           -- 变更后的科室编码
					DEPT_NAME='{10}',          -- 变更后的科室名称
					BED_NO='{11}'              -- 变更后的床号
					WHERE  	PARENT_CODE  = '[父级编码]' 
					AND   	CURRENT_CODE = '[本级编码]' 
					AND    	INPATIENT_NO = '{0}'        --患者住院流水号
					AND    	IN_STATE IN ('I','B')        --在院状态
					*/
				#endregion
			{
				return -1;
			}

			try
			{
				strSql = string.Format(strSql,
				                       PatientInfo.ID, //0 患者住院流水号
				                       PatientInfo.Name, //1 变更前的患者姓名
				                       PatientInfo.PVisit.PatientLocation.NurseCell.ID, //2 变更前的护理站编码
				                       PatientInfo.PVisit.PatientLocation.NurseCell.Name, //3 变更前的护理站名称
				                       PatientInfo.PVisit.PatientLocation.Dept.ID, //4 变更前的科室编码
				                       PatientInfo.PVisit.PatientLocation.Dept.Name, //5 变更前的科室名称
				                       PatientInfo.PVisit.PatientLocation.Bed.ID, //6 变更前的床号
				                       newLocation.NurseCell.ID, //7 变更后的护理站编码
				                       newLocation.NurseCell.Name, //8 变更后的护理站名称
				                       newLocation.Dept.ID, //9 变更后的科室编码
				                       newLocation.Dept.Name, //10变更后的科室名称
				                       newLocation.Bed.ID); //11变更后的床号
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}

			int parm = ExecNoQuery(strSql);
			if (parm <= 0)
			{
				return parm;
			}


			//转移患者(换床，换科室，换病区)时同步婴儿信息
			if (PatientInfo.IsHasBaby)
			{
				//母亲信息
				PatientInfo motherInfo = PatientInfo.Clone();
				//母亲变动信息
				motherInfo.PVisit.PatientLocation = newLocation.Clone();
				//同步婴儿信息
				if (UpdatePatientByMother(motherInfo) == -1)
				{
					return -1;
				}
			}

			//如果患者的科室或者病区发生变化,则更新科室或者病区信息
			if (newLocation.Dept.ID != PatientInfo.PVisit.PatientLocation.Dept.ID ||
			    newLocation.NurseCell.ID != PatientInfo.PVisit.PatientLocation.NurseCell.ID)
			{
				//取转科申请序号
				int intHappenNo;
				intHappenNo = CheckShiftInHappenNo(PatientInfo.ID, newLocation, "1");
				if (intHappenNo <= 0) return intHappenNo;

				//更新转科申请
				if (UpdateShiftDept(PatientInfo.ID, intHappenNo, "1", "2", newLocation) <= 0)
				{
					return -1;
				}

				//保存转科前后的病区和床位编码 added by cuipeng 2005-4-7
				PatientInfo.PVisit.PatientLocation.Dept.Memo = PatientInfo.PVisit.PatientLocation.NurseCell.ID; //保存转科前病区编码
				PatientInfo.PVisit.PatientLocation.Dept.User01 = PatientInfo.PVisit.PatientLocation.Bed.ID; //保存转科前床位编码
				newLocation.Dept.Memo = newLocation.NurseCell.ID; //保存转科后病区编码

                PatientInfo.PVisit.PatientLocation.NurseCell.Memo = PatientInfo.PVisit.PatientLocation.Dept.ID; //保存转科前病区编码
                PatientInfo.PVisit.PatientLocation.NurseCell.User01 = PatientInfo.PVisit.PatientLocation.Bed.ID; //保存转科前床位编码
                //{B1E611C2-7A04-4b79-B64B-3D280D5769CE} 修改病案日报

                newLocation.NurseCell.Memo = newLocation.Dept.ID;
                PatientInfo.PVisit.PatientLocation.NurseCell.User02 = "N";
                PatientInfo.PVisit.PatientLocation.NurseCell.User03 = PatientInfo.PVisit.PatientLocation.Dept.ID;

				//变更信息处理: 插入转出变更记录表
				if (SetShiftData(PatientInfo.ID, EnumShiftType.RO,"转出", PatientInfo.PVisit.PatientLocation.Dept, newLocation.Dept) < 0)
				{
					return -1;
				}


                if (SetShiftData(PatientInfo.ID, EnumShiftType.CNO, "转出", PatientInfo.PVisit.PatientLocation.NurseCell, newLocation.NurseCell) < 0)
                {
                    return -1;
                }


				//变更信息处理: 插入转入变更记录表
				if (SetShiftData(PatientInfo.ID, EnumShiftType.RI,"转入", PatientInfo.PVisit.PatientLocation.Dept, newLocation.Dept) < 0)
				{
					return -1;
				}

                //变更信息处理: 插入转入变更记录表
                if (SetShiftData(PatientInfo.ID, EnumShiftType.CN, "转入", PatientInfo.PVisit.PatientLocation.NurseCell, newLocation.NurseCell) < 0)
                {
                    return -1;
                }
			}

			//如果患者床位发生变化,则更新病床表信息(此处的处理有:转床,转入,转病区)
			if (newLocation.Bed.ID != PatientInfo.PVisit.PatientLocation.Bed.ID)
			{
				//更新患者所在床位的信息
				//保存新床位变更前的信息,用于判断并发
				Bed tempBed = newLocation.Bed.Clone();
				//oldBed.InpatientNo  = "N";
				//oldBed.BedStatus.ID = "U";

				//处理变更信息
				if (SetShiftData(PatientInfo.ID, EnumShiftType.RB,
				                 "转床", PatientInfo.PVisit.PatientLocation.Bed, tempBed) < 0)
				{
					return -1;
				}

				//修改新的床位信息(患者ID和患者原床位的状态)
				tempBed.InpatientNO = PatientInfo.ID;
				//如果变更前患者原床位为空,则修改为占床
				if (PatientInfo.PVisit.PatientLocation.Bed.ID == string.Empty)
					tempBed.Status.ID = "O";
				else
					tempBed.Status.ID = PatientInfo.PVisit.PatientLocation.Bed.Status.ID;

				//更新新床位:原床位上的患者换到新床位上
				parm = UpdateBedStatus(tempBed, newLocation.Bed);
				if (parm <= 0) return parm;

				//如果新床位在变更前是空床而且患者在变更前有床位(说明本次操作是换床,不是接珍操作),则清空患者原床位的床位信息
				if (newLocation.Bed.InpatientNO == "N" && PatientInfo.PVisit.PatientLocation.Bed.ID != string.Empty)
				{
					//修改患者变更前的床位信息
					tempBed = PatientInfo.PVisit.PatientLocation.Bed.Clone();
					tempBed.InpatientNO = "N";
					tempBed.Status.ID = "U";

					//更新患者变更前床位:清空
					parm = UpdateBedStatus(tempBed, PatientInfo.PVisit.PatientLocation.Bed);
					if (parm <= 0) return parm;
				}
			}

			return 1;
		}

        /// <summary>
        /// （住院处使用，省略了申请）转移患者 -换床，换科室，换病区
        /// 需要事务操作(更新住院主表，更新病床表,更新变更表)
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="newLocation">新的位置信息</param>
        /// <returns>0没有更新(并发操作),1成功 -1失败</returns>
        public int TransferPatientLocation(PatientInfo PatientInfo, Location newLocation)
        {
            //转病区
            if (newLocation.NurseCell.ID == string.Empty)
            {
                newLocation.NurseCell.ID = PatientInfo.PVisit.PatientLocation.NurseCell.ID;
                newLocation.NurseCell.Name = PatientInfo.PVisit.PatientLocation.NurseCell.Name;
            }
            //转科
            if (newLocation.Dept.ID == string.Empty)
            {
                newLocation.Dept.ID = PatientInfo.PVisit.PatientLocation.Dept.ID;
                newLocation.Dept.Name = PatientInfo.PVisit.PatientLocation.Dept.Name;
            }
            //转床
            if (newLocation.Bed.ID == string.Empty)
            {
                newLocation.Bed.ID = PatientInfo.PVisit.PatientLocation.Bed.ID;
            }
            //更新患者基本信息表
            string strSql = string.Empty;
            if (Sql.GetSql("RADT.InPatient.TransferPatient.1", ref strSql) == -1)
            #region SQL
            /*UPDATE 	FIN_IPR_INMAININFO 
					SET    	NURSE_CELL_CODE='{7}' ,    -- 变更后的护理站编码
					NURSE_CELL_NAME='{8}',     -- 变更后的护理站名称
					DEPT_CODE='{9}',           -- 变更后的科室编码
					DEPT_NAME='{10}',          -- 变更后的科室名称
					BED_NO='{11}'              -- 变更后的床号
					WHERE  	PARENT_CODE  = '[父级编码]' 
					AND   	CURRENT_CODE = '[本级编码]' 
					AND    	INPATIENT_NO = '{0}'        --患者住院流水号
					AND    	IN_STATE IN ('I','B')        --在院状态
					*/
            #endregion
            {
                return -1;
            }

            try
            {
                strSql = string.Format(strSql,
                                       PatientInfo.ID, //0 患者住院流水号
                                       PatientInfo.Name, //1 变更前的患者姓名
                                       PatientInfo.PVisit.PatientLocation.NurseCell.ID, //2 变更前的护理站编码
                                       PatientInfo.PVisit.PatientLocation.NurseCell.Name, //3 变更前的护理站名称
                                       PatientInfo.PVisit.PatientLocation.Dept.ID, //4 变更前的科室编码
                                       PatientInfo.PVisit.PatientLocation.Dept.Name, //5 变更前的科室名称
                                       PatientInfo.PVisit.PatientLocation.Bed.ID, //6 变更前的床号
                                       newLocation.NurseCell.ID, //7 变更后的护理站编码
                                       newLocation.NurseCell.Name, //8 变更后的护理站名称
                                       newLocation.Dept.ID, //9 变更后的科室编码
                                       newLocation.Dept.Name, //10变更后的科室名称
                                       newLocation.Bed.ID); //11变更后的床号
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                ErrCode = ex.Message;
                WriteErr();
                return -1;
            }

            int parm = ExecNoQuery(strSql);
            if (parm <= 0)
            {
                return parm;
            }


            //转移患者(换床，换科室，换病区)时同步婴儿信息
            if (PatientInfo.IsHasBaby)
            {
                //母亲信息
                PatientInfo motherInfo = PatientInfo.Clone();
                //母亲变动信息
                motherInfo.PVisit.PatientLocation = newLocation.Clone();
                //同步婴儿信息
                if (UpdatePatientByMother(motherInfo) == -1)
                {
                    return -1;
                }
            }

            //如果患者的科室或者病区发生变化,则更新科室或者病区信息
            if (newLocation.Dept.ID != PatientInfo.PVisit.PatientLocation.Dept.ID ||
                newLocation.NurseCell.ID != PatientInfo.PVisit.PatientLocation.NurseCell.ID)
            {
                //取转科申请序号
                //int intHappenNo;
                //intHappenNo = CheckShiftInHappenNo(PatientInfo.ID, newLocation, "1");
                //if (intHappenNo <= 0) return intHappenNo;

                ////更新转科申请
                //if (UpdateShiftDept(PatientInfo.ID, intHappenNo, "1", "2", newLocation) <= 0)
                //{
                //    return -1;
                //}

                //保存转科前后的病区和床位编码 added by cuipeng 2005-4-7
                PatientInfo.PVisit.PatientLocation.Dept.Memo = PatientInfo.PVisit.PatientLocation.NurseCell.ID; //保存转科前病区编码
                PatientInfo.PVisit.PatientLocation.Dept.User01 = PatientInfo.PVisit.PatientLocation.Bed.ID; //保存转科前床位编码
                newLocation.Dept.Memo = newLocation.NurseCell.ID; //保存转科后病区编码
                //变更信息处理: 插入转出变更记录表
                if (SetShiftData(PatientInfo.ID, EnumShiftType.RO, "转出", PatientInfo.PVisit.PatientLocation.Dept, newLocation.Dept) < 0)
                {
                    return -1;
                }


                //变更信息处理: 插入转入变更记录表
                if (SetShiftData(PatientInfo.ID, EnumShiftType.RI, "转入", PatientInfo.PVisit.PatientLocation.Dept, newLocation.Dept) < 0)
                {
                    return -1;
                }
            }

            //如果患者床位发生变化,则更新病床表信息(此处的处理有:转床,转入,转病区)
            if (newLocation.Bed.ID != PatientInfo.PVisit.PatientLocation.Bed.ID)
            {
                //更新患者所在床位的信息
                //保存新床位变更前的信息,用于判断并发
                Bed tempBed = newLocation.Bed.Clone();
                //oldBed.InpatientNo  = "N";
                //oldBed.BedStatus.ID = "U";

                //处理变更信息
                if (SetShiftData(PatientInfo.ID, EnumShiftType.RB,
                                 "转床", PatientInfo.PVisit.PatientLocation.Bed, tempBed) < 0)
                {
                    return -1;
                }

                //修改新的床位信息(患者ID和患者原床位的状态)
                tempBed.InpatientNO = PatientInfo.ID;
                //如果变更前患者原床位为空,则修改为占床
                if (PatientInfo.PVisit.PatientLocation.Bed.ID == string.Empty)
                    tempBed.Status.ID = "O";
                else
                    tempBed.Status.ID = PatientInfo.PVisit.PatientLocation.Bed.Status.ID;

                //更新新床位:原床位上的患者换到新床位上
                parm = UpdateBedStatus(tempBed, newLocation.Bed);
                if (parm <= 0) return parm;

                //如果新床位在变更前是空床而且患者在变更前有床位(说明本次操作是换床,不是接珍操作),则清空患者原床位的床位信息
                if (newLocation.Bed.InpatientNO == "N" && PatientInfo.PVisit.PatientLocation.Bed.ID != string.Empty)
                {
                    //修改患者变更前的床位信息
                    tempBed = PatientInfo.PVisit.PatientLocation.Bed.Clone();
                    tempBed.InpatientNO = "N";
                    tempBed.Status.ID = "U";

                    //更新患者变更前床位:清空
                    parm = UpdateBedStatus(tempBed, PatientInfo.PVisit.PatientLocation.Bed);
                    if (parm <= 0) return parm;
                }
            }

            return 1;
        }

		#endregion

		#region 患者已有床位接诊
        /// <summary>
        /// 接诊了
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int RecievePatient(PatientInfo PatientInfo, Neusoft.HISFC.Models.RADT.InStateEnumService Status)
        {
            string strSql = string.Empty;
            int parm;
            if (Sql.GetSql("RADT.InPatient.ArrivePatient.1", ref strSql) == -1)
            {
                return -1;
            }
            try
            {
                string[] s = {
				             	PatientInfo.ID, //0 住院流水号
				             	PatientInfo.PVisit.PatientLocation.Dept.ID, //1 科室编码
				             	PatientInfo.PVisit.PatientLocation.Dept.Name, //2 科室名称
				             	PatientInfo.PVisit.PatientLocation.Bed.ID, //3 床号
				             	PatientInfo.PVisit.PatientLocation.Bed.Status.ID.ToString(), //4 床位状态(此处根本没用,不知道谁瞎写的)
				             	PatientInfo.PVisit.AttendingDoctor.ID, //5
				             	PatientInfo.PVisit.AttendingDoctor.Name, //6
				             	PatientInfo.PVisit.ReferringDoctor.ID, //7
				             	PatientInfo.PVisit.ReferringDoctor.Name, //8
				             	PatientInfo.PVisit.ConsultingDoctor.ID, //9 主任医师编码
				             	PatientInfo.PVisit.ConsultingDoctor.Name, //10主任医师姓名
				             	PatientInfo.PVisit.AdmittingDoctor.ID, //11
				             	PatientInfo.PVisit.AdmittingDoctor.Name, //12
				             	PatientInfo.PVisit.AdmitSource.ID, //13
				             	PatientInfo.PVisit.AdmitSource.Name, //14
				             	PatientInfo.PVisit.AdmittingNurse.ID, //15责任护士编码
				             	PatientInfo.PVisit.AdmittingNurse.Name, //16责任护士姓名
				             	PatientInfo.PVisit.InSource.ID, //17入院来源ID
				             	PatientInfo.PVisit.InSource.Name, //18入院来源名称
				             	PatientInfo.PVisit.Circs.ID, //19入院情况ID
				             	PatientInfo.PVisit.Circs.Name, //20入院情况名称
				             	PatientInfo.PVisit.PatientLocation.NurseCell.ID, //21护理站编码
				             	PatientInfo.PVisit.PatientLocation.NurseCell.Name, //22护理站名称
				             	Status.ID.ToString() //23患者在院状态
                                
                                //{FA32C976-E003-4a10-9028-71F2CD154052} 接诊时间
                                ,PatientInfo.PVisit.RegistTime.ToString("yyyy-MM-dd HH:mm:ss")
				             };
                strSql = string.Format(strSql, s);
            }
            catch (Exception ex)
            {
                Err = "付数值时候出错！" + ex.Message;
                WriteErr();
                return -1;
            }

            parm = ExecNoQuery(strSql);
            if (parm <= 0)
            {
                return parm;
            }

            //更新患者接诊记录
            if (Sql.GetSql("RADT.InPatient.ArrivePatient.2", ref strSql) == -1) return -1;
            try
            {
                string[] n = {
				             	PatientInfo.ID,//0
				             	PatientInfo.PVisit.PatientLocation.Dept.ID,
				             	PatientInfo.PVisit.PatientLocation.Dept.Name,
				             	PatientInfo.PVisit.PatientLocation.Bed.ID,
				             	PatientInfo.PVisit.PatientLocation.Bed.Status.ID.ToString(),
				             	PatientInfo.PVisit.AttendingDoctor.ID,
				             	PatientInfo.PVisit.AttendingDoctor.Name,
				             	PatientInfo.PVisit.ReferringDoctor.ID,
				             	PatientInfo.PVisit.ReferringDoctor.Name,
				             	PatientInfo.PVisit.ConsultingDoctor.ID,
				             	PatientInfo.PVisit.ConsultingDoctor.Name,
				             	PatientInfo.PVisit.AdmittingDoctor.ID,
				             	PatientInfo.PVisit.AdmittingDoctor.Name,
				             	PatientInfo.PVisit.AdmitSource.ID,
				             	PatientInfo.PVisit.AdmitSource.Name,
				             	PatientInfo.PVisit.AdmittingNurse.ID,
				             	PatientInfo.PVisit.AdmittingNurse.Name,
				             	PatientInfo.PVisit.InSource.ID,
				             	PatientInfo.PVisit.InSource.Name,
				             	PatientInfo.PVisit.Circs.ID,
				             	PatientInfo.PVisit.Circs.Name,
				             	PatientInfo.PVisit.PatientLocation.NurseCell.ID,
				             	PatientInfo.PVisit.PatientLocation.NurseCell.Name,
				             	Operator.ID ,//操作人编码
                                PatientInfo.PVisit.AttendingDirector.ID,//科主任编码
                                PatientInfo.PVisit.AttendingDirector.Name//科主任名称
				             };

                strSql = string.Format(strSql, n);
            }
            catch (Exception ex)
            {
                Err = "付数值时候出错！" + ex.Message;
                WriteErr();
                return -1;
            }

            parm = ExecNoQuery(strSql);
            if (parm <= 0)
            {
                return parm;
            }

            //召回,转科时同步婴儿信息--婴儿的床号和科室跟母亲相同
            if (PatientInfo.IsHasBaby && PatientInfo.PVisit.InState.ID.ToString() != "O")
            {
                //母亲信息
                PatientInfo motherInfo = PatientInfo.Clone();
                //处理后的母亲在院状态为入院登记状态"I"
                motherInfo.PVisit.InState.ID = "I";
                //同步婴儿信息
                if (UpdatePatientByMother(motherInfo) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }
		/// <summary>
        /// 患者接诊-更新患者接诊信息 置接诊标记
        /// </summary>
        /// <param name="PatientInfo">患者基本信息(患者入院登记时已确定床位)</param>
		/// <param name="Status">患者状态</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
		public int RecievePatient(PatientInfo PatientInfo, Neusoft.HISFC.Models.Base.EnumInState Status)
		{
			#region 接口说明

			// 患者接诊
			//RADT.InPatient.ArrivePatient.1
			//传入：0 InpatientNo住院流水号,1科室ID,2科室名称,3床号,4病床状态ID,
			//5主治医生ID,6主治医生名称,7副主任医师ID,8副主任医师名称,9主任医师ID,10主任医师名称
			//11责任医师ID,12责任医师名称,13入院途径ID,14入院途径名称,15责任护士ID,16责任护士名称,
			//17入院来源ID,18入院来源名称,19入院情况ID,20入院情况名称
			//传出：0 

			#endregion

			string strSql = string.Empty;
			int parm;
			if (Sql.GetSql("RADT.InPatient.ArrivePatient.1", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				string[] s = {
				             	PatientInfo.ID, //0 住院流水号
				             	PatientInfo.PVisit.PatientLocation.Dept.ID, //1 科室编码
				             	PatientInfo.PVisit.PatientLocation.Dept.Name, //2 科室名称
				             	PatientInfo.PVisit.PatientLocation.Bed.ID, //3 床号
				             	PatientInfo.PVisit.PatientLocation.Bed.Status.ID.ToString(), //4 床位状态(此处根本没用,不知道谁瞎写的)
				             	PatientInfo.PVisit.AttendingDoctor.ID, //5
				             	PatientInfo.PVisit.AttendingDoctor.Name, //6
				             	PatientInfo.PVisit.ReferringDoctor.ID, //7
				             	PatientInfo.PVisit.ReferringDoctor.Name, //8
				             	PatientInfo.PVisit.ConsultingDoctor.ID, //9 主任医师编码
				             	PatientInfo.PVisit.ConsultingDoctor.Name, //10主任医师姓名
				             	PatientInfo.PVisit.AdmittingDoctor.ID, //11
				             	PatientInfo.PVisit.AdmittingDoctor.Name, //12
				             	PatientInfo.PVisit.AdmitSource.ID, //13
				             	PatientInfo.PVisit.AdmitSource.Name, //14
				             	PatientInfo.PVisit.AdmittingNurse.ID, //15责任护士编码
				             	PatientInfo.PVisit.AdmittingNurse.Name, //16责任护士姓名
				             	PatientInfo.PVisit.InSource.ID, //17入院来源ID
				             	PatientInfo.PVisit.InSource.Name, //18入院来源名称
				             	PatientInfo.PVisit.Circs.ID, //19入院情况ID
				             	PatientInfo.PVisit.Circs.Name, //20入院情况名称
				             	PatientInfo.PVisit.PatientLocation.NurseCell.ID, //21护理站编码
				             	PatientInfo.PVisit.PatientLocation.NurseCell.Name, //22护理站名称
				             	Status.ToString() //23患者在院状态

                               //{FA32C976-E003-4a10-9028-71F2CD154052} 接诊时间
                               ,PatientInfo.PVisit.RegistTime.ToString("yyyy-MM-dd HH:mm:ss")
				             };
				strSql = string.Format(strSql, s);
			}
			catch (Exception ex)
			{
				Err = "付数值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			parm = ExecNoQuery(strSql);
			if (parm <= 0)
			{
				return parm;
			}

			//更新患者接诊记录
			if (Sql.GetSql("RADT.InPatient.ArrivePatient.2", ref strSql) == -1) return -1;
			try
			{
				string[] n = {
				             	PatientInfo.ID,
				             	PatientInfo.PVisit.PatientLocation.Dept.ID,
				             	PatientInfo.PVisit.PatientLocation.Dept.Name,
				             	PatientInfo.PVisit.PatientLocation.Bed.ID,
				             	PatientInfo.PVisit.PatientLocation.Bed.Status.ID.ToString(),
				             	PatientInfo.PVisit.AttendingDoctor.ID,
				             	PatientInfo.PVisit.AttendingDoctor.Name,
				             	PatientInfo.PVisit.ReferringDoctor.ID,
				             	PatientInfo.PVisit.ReferringDoctor.Name,
				             	PatientInfo.PVisit.ConsultingDoctor.ID,
				             	PatientInfo.PVisit.ConsultingDoctor.Name,
				             	PatientInfo.PVisit.AdmittingDoctor.ID,
				             	PatientInfo.PVisit.AdmittingDoctor.Name,
				             	PatientInfo.PVisit.AdmitSource.ID,
				             	PatientInfo.PVisit.AdmitSource.Name,
				             	PatientInfo.PVisit.AdmittingNurse.ID,
				             	PatientInfo.PVisit.AdmittingNurse.Name,
				             	PatientInfo.PVisit.InSource.ID,
				             	PatientInfo.PVisit.InSource.Name,
				             	PatientInfo.PVisit.Circs.ID,
				             	PatientInfo.PVisit.Circs.Name,
				             	PatientInfo.PVisit.PatientLocation.NurseCell.ID,
				             	PatientInfo.PVisit.PatientLocation.NurseCell.Name,
				             	Operator.ID, //操作人编码
                                PatientInfo.PVisit.AttendingDirector.ID,//科主任编码
                                PatientInfo.PVisit.AttendingDirector.Name//科主任名称
				             };

				strSql = string.Format(strSql, n);
			}
			catch (Exception ex)
			{
				Err = "付数值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			parm = ExecNoQuery(strSql);
			if (parm <= 0)
			{
				return parm;
			}

			//召回,转科时同步婴儿信息--婴儿的床号和科室跟母亲相同
			if (PatientInfo.IsHasBaby && PatientInfo.PVisit.InState.ID.ToString() != "O")
			{
				//母亲信息
				PatientInfo motherInfo = PatientInfo.Clone();
				//处理后的母亲在院状态为入院登记状态"I"
				motherInfo.PVisit.InState.ID = "I";
				//同步婴儿信息
				if (UpdatePatientByMother(motherInfo) == -1)
				{
					return -1;
				}
			}

			return 1;
		}

		#endregion
		[System.Obsolete("更改为RecievePatient",true)]
		public int ArrivePatient(PatientInfo PatientInfo, string Status)
		{
			return 0;
		}

		#region 患者没有床位接诊

		/// <summary>
		/// 患者接诊-更新患者接诊信息 置接诊标记 更新床位记录
		/// </summary>
		/// <param name="patientInfo">患者信息</param>
		/// <param name="bed">床位信息</param>
		/// <param name="type">变更类别</param>
		/// <param name="notes">注释信息</param>
		/// <returns>0没有更新 1成功 -1失败</returns>
		public int RecievePatient(PatientInfo patientInfo, Bed bed, EnumShiftType type, string notes)
		{
            Neusoft.HISFC.Models.Base.EnumInState status = EnumInState.R;
			int parm;
			//婴儿不更新床位信息
			if (patientInfo.IsBaby ==false)
			{
				//更新前的床位信息
				Bed oldBed = new Bed();
				oldBed.InpatientNO = "N"; //'N'代表没有患者
				oldBed.Status.ID = "U"; //'U'代表空床

				//更新后的床位信息
				bed.InpatientNO = patientInfo.ID;
				bed.Status.ID = "O";

				//更新床位信息
				parm = UpdateBedStatus(bed, oldBed);
				if (parm != 1)
				{
					return parm;
				}
			}

			patientInfo.PVisit.PatientLocation.Bed = bed;

			if (type.ToString() == "K")
				//对于变更类型等于"接珍K"的在院状态是"入院登记R"
                status = EnumInState.R;
			else if (type.ToString() == "C")
				//对于变更类型等于"召回C"的在院状态是"出院登记B"
                status = EnumInState.B;

			//接珍处理
			parm = RecievePatient(patientInfo, status);
			if (parm <= 0)
			{
				return parm;
            }

            #region {6738F887-6A7B-48eb-8653-FC2AA1893DA8} 
            if (type.ToString() == "K")
            {
                //变更信息
                //{FA32C976-E003-4a10-9028-71F2CD154052} 接诊时间
                if (SetShiftData(patientInfo.ID, patientInfo.PVisit.RegistTime, type, notes, patientInfo.PVisit.PatientLocation.NurseCell, patientInfo.PVisit.PatientLocation.Bed) < 0)
                {
                    return -1;
                }

            }
            else
            {
                if (SetShiftData(patientInfo.ID, type, notes, patientInfo.PVisit.PatientLocation.NurseCell, patientInfo.PVisit.PatientLocation.Bed) < 0)
                {
                    return -1;
                }
            }
            #endregion
            return 1;
		}

		#endregion

		#region 转床

		/// <summary>
		/// 交换两个人的床位信息
		/// <br>传入：源患者,目标患者</br>
		/// </summary>
		/// <param name="sourcePatientInfo">原患者基本信息</param>
		/// <param name="targetPatientInfo">目标患者基本信息</param>
		/// <returns>0成功 -1失败</returns>
		public int SwapPatientBed(PatientInfo sourcePatientInfo, PatientInfo targetPatientInfo)
		{
			#region 接口说明

			//交换两个人的床位信息
			//更新患者的床位、科室、病区信息。
			//RADT.InPatient.SwapPatient.1
			//传入：old (0 InpatientNo住院流水号,1患者姓名,(2病区id,3病区name,
			//		4科室id,5科室name,6病床id)
			//		new(7 住院流水号，8姓名,9病区id,10病区name,
			//		11科室id,12科室name,13病床id)
			//传出：0 

			#endregion

			//更新病床表
			if (sourcePatientInfo.PVisit.PatientLocation.Bed.ID != targetPatientInfo.PVisit.PatientLocation.Bed.ID)
			{
				//前者换床处理
				int parm = TransferPatient(sourcePatientInfo, targetPatientInfo.PVisit.PatientLocation);
				if (parm != 1)
				{
					return parm;
				}

				//后者换床处理
				parm = TransferPatient(targetPatientInfo, sourcePatientInfo.PVisit.PatientLocation);
				if (parm != 1)
				{
					return parm;
				}
			}

			return 1;
		}
		
		[System.Obsolete("更改为 SwapPatientBed",true)]
		public int SwapPatient(PatientInfo sourcePatientInfo, PatientInfo targetPatientInfo)
		{
			
            
            return 0;
		}
		#endregion

		#region 特殊床位管理 （包床、挂床）

		/// <summary>
		/// 特殊床位管理 （包床、挂床）
		/// 挂床用此函数必须确定目标床位未占用
		/// 床位状态说明： C  = "关闭" U = "空床" K = "污染"  I = "隔离" O = "占用" R = "假床" W = "包床" H = "挂床"
		/// </summary>
		/// <param name="patientInfo">患者基本信息</param>
		/// <param name="bedNO">病床id</param>
		/// <param name="type">1挂床 2  包床 </param>
		/// <returns>0没有更新 1 成功 -1 失败</returns>
		public int SwapPatientBed(PatientInfo patientInfo, string bedNO, string type)
		{
			#region 接口说明

			//特殊床位管理 （包床、挂床）
			//RADT.InPatient.PatientWapBed.1
			//传入：0 InpatientNo住院流水号,1患者姓名,2病床号
			//传出：0 

			#endregion

			string strSql = string.Empty;
			string strSql1 = string.Empty;
			string strStatus = string.Empty;
			int parm;
			if (type == "1")
			{
				strStatus = "H";
				//更改前的床位信息
				Bed oldBed = patientInfo.PVisit.PatientLocation.Bed.Clone();
				//更改后的床位信息
				patientInfo.PVisit.PatientLocation.Bed.Status.ID = NConvert.ToInt32(EnumBedStatus.U).ToString();
				patientInfo.PVisit.PatientLocation.Bed.InpatientNO = "N";

				//更新床位状态
				parm = UpdateBedStatus(patientInfo.PVisit.PatientLocation.Bed, oldBed);
				if (parm <= 0)
				{
					return parm;
				}

				//更新患者基本信息表"
				if (Sql.GetSql("RADT.InPatient.TransferPatient.1", ref strSql1) == 0)
					#region SQL
					/*
					UPDATE 	FIN_IPR_INMAININFO 
			        SET    	NURSE_CELL_CODE='{7}' ,    -- 变更后的护理站编码
					NURSE_CELL_NAME='{8}',     -- 变更后的护理站名称
					DEPT_CODE='{9}',           -- 变更后的科室编码
					DEPT_NAME='{10}',          -- 变更后的科室名称
					BED_NO='{11}'              -- 变更后的床号
			        WHERE  	PARENT_CODE  = '[父级编码]' 
			        AND   	CURRENT_CODE = '[本级编码]' 
			        AND    	INPATIENT_NO = '{0}'        --患者住院流水号
			        AND    	IN_STATE IN ('I','B')        --在院状态
					*/
					#endregion
				{
					try
					{
						strSql1 =
							string.Format(strSql1, patientInfo.ID, patientInfo.Name, patientInfo.PVisit.PatientLocation.NurseCell.ID,
							              patientInfo.PVisit.PatientLocation.NurseCell.Name,
							              patientInfo.PVisit.PatientLocation.Dept.ID, patientInfo.PVisit.PatientLocation.Dept.Name,
							              patientInfo.PVisit.PatientLocation.Bed.ID, patientInfo.PVisit.PatientLocation.NurseCell.ID,
							              patientInfo.PVisit.PatientLocation.NurseCell.Name, patientInfo.PVisit.PatientLocation.Dept.ID,
							              patientInfo.PVisit.PatientLocation.Dept.Name, bedNO);
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						ErrCode = ex.Message;
						WriteErr();
						return -1;
					}
				}
				else
				{
					return -1;
				}
				if (ExecNoQuery(strSql1) <= 0)
				{
					return -1;
				}
			}
			else if (type == "2")
			{
				strStatus = "W";
			}

			if (Sql.GetSql("RADT.InPatient.PatientWapBed.1", ref strSql) == -1)
				#region SQL
				/*
				 UPDATE COM_BEDINFO 
			     SET  CLINIC_NO= '{0}',BED_STATE = '{3}' 
			     WHERE  PARENT_CODE='[父级编码]'  and 
			     CURRENT_CODE='[本级编码]' and 
			     BED_NO = '{2}' and
			     BED_STATE <> 'O'
				 */
				#endregion
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, patientInfo.ID, patientInfo.Name, bedNO, strStatus);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.PatientWapBed.1";
				WriteErr();
				return -1;
			}
			parm = ExecNoQuery(strSql);
			if (parm < 0) return parm;

			if (ChangeBedInfo(patientInfo.ID, bedNO, type) < 0)
			{
				return -1;
			}
			return 0;
		}


		[System.Obsolete("更改为 SwapPatientBed",true)]
		public int PatientWapBed(PatientInfo patientInfo, string bedNO, string type)
		{
			return 0;
		}
		#endregion

		#region 更新患者病床状态

		/// <summary>
		/// 更新患者病床状态-更新床位状态
		/// </summary>
		/// <param name="Bed">病床信息</param>
		/// <returns>0没更新 >1 成功 -1 失败</returns>
		public int UpdateBedStatus(Bed Bed)
		{
			#region 接口说明

			//更新患者的床位信息。
			//RADT.InPatient.UpdateSickBedInfo.1
			//传入：0 bed no 床号 1 InpatientNo住院流水号,2 床位状态)
			//传出：0 

			#endregion

			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdateSickBedInfo.1", ref strSql) == -1)
				#region SQL
				/*
				 UPDATE COM_BEDINFO 
					SET   CLINIC_NO= '{1}',BED_STATE = '{2}' 
					WHERE PARENT_CODE='[父级编码]'  and 
			      CURRENT_CODE='[本级编码]' and 
			      BED_NO =	'{0}'
				  */
				#endregion
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, Bed.ID, Bed.InpatientNO, Bed.Status.ID);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}

			return ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新床位状态和inpatientNo,并用原病床信息进行并发判断
		/// writed by cuipeng
		/// 2005-5
		/// </summary>
		/// <param name="newBed">新病床信息</param>
		/// <param name="oldBed">旧病床信息</param>
		/// <returns>0没更新 >1 成功 -1 失败</returns>
		public int UpdateBedStatus(Bed newBed, Bed oldBed)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdateSickBedInfo.2", ref strSql) == -1)
				#region SQL
				/*
				UPDATE 	COM_BEDINFO 
			    SET   	CLINIC_NO= '{3}',        --更新后的患者流水号
	            		BED_STATE = '{4}'        --更新后的床位状态
			    WHERE 	PARENT_CODE  = '[父级编码]'  
		        AND   	CURRENT_CODE = '[本级编码]' 
		        AND   	BED_NO       = '{0}'     --更新前的床号
		        AND   	CLINIC_NO    = '{1}'     --更新前的患者流水号
		        AND   	BED_STATE    = '{2}'     --更新前的床位状态 
				*/
				#endregion
			{
				return -1;
			}

			try
			{
				strSql = string.Format(strSql,
				                       newBed.ID, //0床号
				                       oldBed.InpatientNO, //1更新前患者ID
				                       oldBed.Status.ID, //2更新前床位状态
				                       newBed.InpatientNO, //3更新后患者ID
				                       newBed.Status.ID //4更新后床位状态
					);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		#region 记录包床、挂床信息

		
		/// <summary>
		/// 记录包床、挂床信息 BED_KIND 1 挂床 2 包床
		/// STATUS 状态 0 挂床 1 解挂
		/// </summary>
		/// <param name="inpatientNO">住院号</param>
		/// <param name="bedNO">床号</param>
		/// <param name="kind">类别</param>
		/// <returns>大于 0 成功，小于 0 失败</returns>
		public int ChangeBedInfo(string inpatientNO, string bedNO, string kind)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdateBedInfoRecord.1", ref strSql) == -1)
				#region SQL
				/*UPDATE fin_ipr_hangbedinfo   --挂床信息表

					 SET  status='1',   --状态 0 挂床 1 解挂
							  bed_kind = '{2}',
						  oper_code='{3}',   --操作员

						  oper_date=sysdate    --操作日期
				   WHERE PARENT_CODE='[父级编码]'  and 
						 CURRENT_CODE='[本级编码]' and 
						 INPATIENT_NO='{0}' and
						 BED_NO = '{1}' and
						 STATUS='0'
						 */
				#endregion
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, inpatientNO, bedNO, kind, Operator.ID);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.UpdateBedInfoRecord.1";
				WriteErr();
				return -1;
			}
			if (ExecNoQuery(strSql) <= 0)
			{
				if (Sql.GetSql("RADT.InPatient.InsertBedInfoRecord.1", ref strSql) == -1)
				{
					return -1;
				}
				try
				{
					strSql = string.Format(strSql, inpatientNO, bedNO, kind, Operator.ID);
				}
				catch(Exception ex)
				{
					Err = ex.Message;
					WriteErr();
					return -1;
				}
				return ExecNoQuery(strSql);
			}
			return 0;
		}
		[System.Obsolete("更改为ChangeBedInfo",true)]
		public int ChangeBedInfoRecord(string InPatientNo, string BedNo, string kind)
		{
			return 0;
		}
		#endregion

		#region  解包床 将某个包床释放

		/// <summary>
		/// 解包床 将某个包床释放
		/// 解挂床用此函数必须确定目标床位未占用
		/// </summary>
		/// <param name="patientInfo">患者基本信息</param>
		/// <param name="bedNO">病床id</param>
		/// <param name="type">1挂床 2  包床</param>
		/// <returns>0没有更新 1成功 -1 失败</returns>
		public int UnWrapPatientBed(PatientInfo patientInfo, string bedNO, string type)
		{
			#region 接口说明

			//包床 解包床 将某个包床释放
			//RADT.InPatient.PatientUnWapBed.2
			//传入：0 InpatientNo住院流水号,1患者姓名,2病床号
			//传出：0 

			#endregion

			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.PatientWapBed.2", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, patientInfo.ID, patientInfo.Name, bedNO);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.PatientWapBed.2";
				WriteErr();
				return -1;
			}
			if (ExecNoQuery(strSql) <= 0)
			{
				return -1;
			}
			if (ChangeBedInfo(patientInfo.ID, bedNO, type) < 0)
			{
				return -1;
			}
			return 0;
		}
        [System.Obsolete("更改为 UnWrapPatientBed", true)]
		public int PatientUnWapBed(PatientInfo PatientInfo, string BedNo, string Type)
		{
			return 0;
		}
		#endregion		    

		#endregion

		#region 更新预约入院登记信息

		/// <summary>
		/// 更新单患者全部预约信息
		/// </summary>
		/// <param name="patientInfo">发生序号记录与PatientInfo.memo</param>
		/// <returns></returns>
		public int UpdatePreIn(PatientInfo patientInfo)
		{
			#region "接口"

			//			接口名称 RADT.InPatient.UpdatePrepayIn.1
			//			<!-- 0 就诊卡号,  1 发生序号, 2 姓名,3 性别,4 身份证号, 5 生日, 6 医疗证号,
			//			7 结算类别,  8 合同单位, 9 床号,10 护士站代码,    11 职务,12 工作单位,
			//			13 工作单位电话,         14 家庭住址,  15 家庭电话,16 籍贯,17 出生地,
			//			18 民族,     19 联系人,  20 联系人电话,21 联系人地址,      22 联系人关系,
			//			23 婚姻状况, 24 国籍,    25 诊断代码,  26 诊断名称,        27 预约科室,
			//			28 科室名称 ,29 预约医师,30 状态, 31 预约日期,   32 操作员,33 操作日期-->

			#endregion

			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdatePrepayIn.1", ref strSql) == -1) return -1;

			#region --

			try
			{
				string[] s = new string[34];
				
				s[0] = patientInfo.PID.CardNO; //就诊卡号
				s[1] = patientInfo.Memo;       //发生序号
				s[2] = patientInfo.Name;       //姓名
				s[3] = patientInfo.Sex.ID.ToString(); //性别
				s[4] = patientInfo.IDCard; //身份证号
				s[5] = patientInfo.Birthday.ToString(); //生日
				s[6] = patientInfo.SSN; //医疗证号
				s[7] = patientInfo.Pact.PayKind.ID; //结算类别
				s[8] = patientInfo.Pact.ID; //合同单位
				s[9] = patientInfo.PVisit.PatientLocation.Bed.ID; //床号
				s[10] = patientInfo.PVisit.PatientLocation.NurseCell.ID; //护士站代码
				s[11] = patientInfo.Profession.ID; //职务
				s[12] = patientInfo.CompanyName; //工作单位
				s[13] = patientInfo.PhoneBusiness; //工作单位电话
				s[14] = patientInfo.AddressHome; //家庭住址
				s[15] = patientInfo.PhoneHome; //家庭电话
				s[16] = patientInfo.DIST; //籍贯
				s[17] = patientInfo.DIST; //出生地
				s[18] = patientInfo.Nationality.ID; //民族
				s[19] = patientInfo.Kin.ID; //联系人
				s[20] = patientInfo.Kin.RelationPhone; //联系人电话
				s[21] = patientInfo.Kin.RelationAddress; //联系人地址
				s[22] = patientInfo.Kin.Relation.ID; //联系人关系
				s[23] = patientInfo.MaritalStatus.ID.ToString(); //婚姻状况
				s[24] = patientInfo.Country.ID; //国籍
				
				if (patientInfo.Diagnoses.Count > 0)
				{
					s[25] = patientInfo.Diagnoses[0].ToString();//诊断代码
				} 
				
				s[26] = string.Empty; //诊断名称
				s[27] = patientInfo.PVisit.PatientLocation.Dept.ID; //预约科室
				s[28] = patientInfo.PVisit.PatientLocation.Dept.Name; //科室名称
				s[29] = patientInfo.PVisit.AdmittingDoctor.ID; //预约医师
				s[30] = "0"; //状态
				s[31] = patientInfo.PVisit.InTime.ToString(); //预约日期
				s[32] = Operator.ID; //操作员
				s[33] = GetSysDateTime().ToString(); //操作日期
		
				strSql = string.Format(strSql, s);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			#endregion
			return ExecNoQuery(strSql);
		}
		[System.Obsolete("更改为 UpdatePreIn",true)]
		public int UpdatePrepayIn(PatientInfo PatientInfo)
		{
			return 0;
		}
		#endregion

		#region 新婴儿登记

		/// <summary>
		/// 新婴儿登记
		/// </summary>
		/// <param name="babyInfo">新婴儿信息</param>
		/// <returns> 大于 0 成功  小于 0 失败</returns>
		public int InsertNewBabyInfo(PatientInfo babyInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.ResigerNewBaby.1", ref strSql) == -1)
			{
				return -1;
			}
			
			#region SQL
			/*
			 INSERT INTO fin_ipr_babyinfo   --婴儿住院主表
		          ( parent_code,   --父级医疗机构编码
		            current_code,   --本级医疗机构编码
		            inpatient_no,   --住院流水号
		            happen_no,   --发生序号
		            name,   --姓名
		            sex_code,   --性别
		            birthday,   --生日
		            height,   --身高
		            weight,   --体重
		            blood_code,   --血型编码
		            in_date,   --入院日期
		            prepay_outdate,   --出院日期(预约)
		            oper_code,   --操作员
		            oper_date,
		            cancel_flag,
					MOTHER_INPATIENT_NO )  
		     VALUES 
		          ( '[父级编码]',   --父级医疗机构编码
		            '[本级编码]',   --本级医疗机构编码
		            '{0}',   --住院流水号
		            (select NVL(MAX(happen_no),0)+1 from fin_ipr_babyinfo where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and  MOTHER_INPATIENT_NO = '{12}' ),   --发生序号
		            '{2}',   --姓名
		            '{3}',   --性别
		            to_date('{4}','yyyy-mm-dd hh24:mi:ss'),   --生日
		            '{5}',   --身高
		            '{6}',   --体重
		            '{7}',   --血型编码
		            to_date('{8}','yyyy-mm-dd hh24:mi:ss'),   --入院日期
		            to_date('{9}','yyyy-mm-dd hh24:mi:ss'),   --出院日期(预约)
		            '{10}',   --操作员
		            to_date('{11}','yyyy-mm-dd hh24:mi:ss'),'0', '{12}')
		*/
			#endregion
			
			try
			{
				string[] s = new string[13];
				s[0] = babyInfo.ID;     //住院流水号
				s[1] = babyInfo.User01; //发生序号
				s[2] = babyInfo.Name;   //姓名
				s[3] = babyInfo.Sex.ID.ToString();   //性别
				s[4] = babyInfo.Birthday.ToString(); //生日
				s[5] = babyInfo.Height; //身高
				s[6] = babyInfo.Weight; //体重
				s[7] = babyInfo.BloodType.ID.ToString();      //血型编码
				s[8] = babyInfo.PVisit.InTime.ToString();     //入院日期
				s[9] = babyInfo.PVisit.PreOutTime.ToString(); //出院日期(预约)
				s[10] = Operator.ID; //操作员
				s[11] = GetSysDateTime().ToString();    //操作日期
				s[12] = babyInfo.PID.MotherInpatientNO; //母亲住院流水号
				strSql = string.Format(strSql, s);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			return ExecNoQuery(strSql);
		}
		[System.Obsolete("更改为 InsertNewBabyInfo",true)]
		public int ResigerNewBaby(PatientInfo BabyInfo)
		{
			return 0;
		}
		public int UpdateBabyInfo(PatientInfo babyInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.UpdateBabyInfo.1", ref strSql) == -1)
			{
				return -1;
			}

			try
			{
				string[] s = new string[13];
				s[0] = babyInfo.ID; //婴儿住院流水号
				s[1] = babyInfo.User01; //发生序号
				s[2] = babyInfo.Name; //姓名
				s[3] = babyInfo.Sex.ID.ToString(); //性别
				s[4] = babyInfo.Birthday.ToString(); //生日
				s[5] = babyInfo.Height; //身高
				s[6] = babyInfo.Weight; //体重
				s[7] = babyInfo.BloodType.ID.ToString(); //血型编码
				s[8] = babyInfo.PVisit.InTime.ToString(); //入院日期
				s[9] = babyInfo.PVisit.PreOutTime.ToString(); //出院日期(预约)
				s[10] = Operator.ID; //操作员
				s[11] = GetSysDateTime().ToString(); //操作日期
				s[12] = babyInfo.PID.MotherInpatientNO; //母亲住院流水号
				strSql = string.Format(strSql, s);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}

			return ExecNoQuery(strSql);
		}

		/// <summary>
		/// 取消婴儿登记
		/// </summary>
		/// <param name="inpatientNO"> 住院流水号</param>
		/// <returns>大于 0 成功 小于 0失败</returns>
		public int DiscardBabyRegister(string inpatientNO)
		{
			string strSql = string.Empty;
			//传入： 0住院流水号,1发生序号 
			if (Sql.GetSql("RADT.Inpatient.CancelBaby.1", ref strSql) < 0)
			{
				return -1;
			}
			#region SQL
			/*
				update 	fin_ipr_babyinfo   --婴儿住院主表
				set   	cancel_flag='1'    --
				where 	PARENT_CODE='[父级编码]' 
				AND     CURRENT_CODE='[本级编码]' 
				AND     inpatient_no='{0}' 
			*/
			#endregion
			try
			{
				strSql = string.Format(strSql, inpatientNO);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}
		[System.Obsolete("更改为 DiscardBabyRegister",true)]
		public int CancelBaby(string InpatientNo)
		{
			return 0;
		}
		
        /// <summary>
		/// 获得患者婴儿
		/// </summary>
		/// <param name="inpatientNo">住院流水号</param>
		/// <returns>婴儿列表</returns>
		public ArrayList QueryBabiesByMother(string inpatientNo)
		{
			ArrayList al = new ArrayList();
			string strSql = string.Empty;
			//取SQL语句
			if (Sql.GetSql("RADT.Inpatient.GetBabys.1", ref strSql) == -1)
				#region SQL
				/*
				select 	INPATIENT_NO,	--0 婴儿住院流水号
        				happen_no,		--1 发生序号 	
						name,			--2 姓名
						SEX_CODE,		--3 性别
						birthday,		--4 出生日期
						HEIGHT,			--5 身高
						WEIGHT,			--6 体重
						BLOOD_CODE,		--7 血型编码
						IN_DATE,		--8 入院日期
						PREPAY_OUTDATE,		--9 出院日期(预约)
						MOTHER_INPATIENT_NO,	--10婴儿住院流水号
						OPER_CODE,		--11操作员
						OPER_DATE		--12操作日期
				from 	fin_ipr_babyinfo 
				where 	PARENT_CODE='[父级编码]' 
					AND	CURRENT_CODE='[本级编码]' 
					AND	MOTHER_INPATIENT_NO = '{0}' 
					AND	cancel_flag='0'
				*/
				#endregion
			{
				return null;
			}

			try
			{
				strSql = string.Format(strSql, inpatientNo);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}

			if (ExecQuery(strSql) == -1)
			{
				return null;
			}

			PatientInfo obj = null;
			while (Reader.Read())
			{
				obj = new PatientInfo();
				try
				{
					obj.ID = Reader[0].ToString(); //0婴儿住院流水号
					obj.User01 = Reader[1].ToString(); //1发生序号
					obj.Name = Reader[2].ToString(); //2姓名
					obj.Sex.ID = Reader[3].ToString(); //3性别
					obj.Birthday = NConvert.ToDateTime(Reader[4]); //4出生日期
					obj.Height = Reader[5].ToString(); //5身高
					obj.Weight = Reader[6].ToString(); //6体重
					obj.BloodType.ID = Reader[7].ToString(); //7血型编码
					obj.PVisit.InTime = NConvert.ToDateTime(Reader[8].ToString()); //8入院日期
					obj.PVisit.PreOutTime = NConvert.ToDateTime(Reader[9].ToString()); //9出院日期(预约)
					obj.PID.MotherInpatientNO = Reader[10].ToString(); //10母亲住院流水号
					obj.User02 = Reader[11].ToString(); //11操作员
					obj.User03 = Reader[12].ToString(); //12操作日期
					al.Add(obj);
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					WriteErr();
					Reader.Close();
					return null;
				}
				
			}
			Reader.Close();

			//取婴儿在住院主表中的信息
			ArrayList alReturn = new ArrayList();
			PatientInfo babyMainInfo = null; //婴儿住院主表信息
			foreach (PatientInfo baby in al)
			{
				//取住院主表中的婴儿信息
				babyMainInfo = QueryPatientInfoByInpatientNO(baby.ID);
				if (babyMainInfo == null || babyMainInfo.ID == string.Empty)
				{
					return null;
				}

				babyMainInfo.PID.MotherInpatientNO = baby.PID.MotherInpatientNO; //母亲住院流水号
				babyMainInfo.User01 = baby.User01; //婴儿发生序号
				babyMainInfo.User02 = baby.User02; //操作人编码
				babyMainInfo.User03 = baby.User03; //操作日期

				//添加到婴儿数组中
				alReturn.Add(babyMainInfo);
			}

			return alReturn;
		}
		[System.Obsolete("更改为 QueryBabiesByMother",true)]
		public ArrayList GetBabys(string inpatientNo)
		{
			return null;
		}
		/// <summary>
		/// 获得某患者是否有在院婴儿
		/// </summary>
		/// <param name="inpatientNO">母亲住院流水号</param>
		/// <returns>1有，0没有</returns>
		public int IsMotherHasBabiesInHos(string inpatientNO)
		{
			string strSql = string.Empty;
			//取SQL语句
			if (Sql.GetSql("RADT.Inpatient.GetBabys.2", ref strSql) == -1)
				#region SQL
				/*				
				SELECT  COUNT(*) 
				FROM   	FIN_IPR_INMAININFO R 
				WHERE  	R.IN_STATE IN ('I','B') 
				AND  	R.INPATIENT_NO IN 
				       ( 
						SELECT 	T.INPATIENT_NO 
						FROM   	FIN_IPR_BABYINFO T  
						WHERE  	T.MOTHER_INPATIENT_NO = '{0}'
					    ) 
				 */
				#endregion	
			{
				return -1;
			}

			try
			{
				strSql = string.Format(strSql, inpatientNO);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}

			if (ExecQuery(strSql) == -1)
			{
				return -1;
			}

			int parm = 0;
			try
			{
				parm = Neusoft.FrameWork.Function.NConvert.ToInt32(ExecSqlReturnOne(strSql));
			}
			catch
			{
				parm = 0;
			}

			return parm;
		}
		[System.Obsolete("更改为 IsMotherHasBabiesInHos",true)]
		public int GetBabysInHos(string inpatientNO)
		{
			return 0;
		}
		/// <summary>
		/// 获得最大婴儿住院号 
		/// </summary>
		/// <param name="inpatientNO">住院号</param>
		/// <returns>没有返回 0 有返回最大号 字符串</returns>
		public string GetMaxBabyNO(string inpatientNO)
		{
			string sql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.Baby.GetMaxBabyNo", ref sql) == -1)
			{
				return "-1";
			}
			#region SQL
			/*
			    SELECT NVL(MAX(HAPPEN_NO),0)
				FROM  FIN_IPR_BABYINFO   
				WHERE PARENT_CODE  = '[父级编码]' 
				AND   CURRENT_CODE = '[本级编码]' 
				AND   MOTHER_INPATIENT_NO = '{0}'
				*/
			#endregion
			try
			{
				sql = string.Format(sql, inpatientNO);
			}
			catch
			{
				Err = "RADT.InPatient.Baby.GetMaxBabyNo 传参数时候出错！";
				WriteErr();
				return "-1";
			}
			return ExecSqlReturnOne(sql);
		}
		[System.Obsolete("更改为 GetMaxBabyNO",true)]
		public string GetMaxBabyNo(string InpatientNo)
		{
			return string.Empty;
		}
		/// <summary>
		/// 更新母亲是否有婴标志
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <param name="isHasBaby">是否有婴儿</param>
		/// <returns>-1 ,0 </returns>
		public int UpdateMumBabyFlag(string inpatientNO, bool isHasBaby)
		{
			string strSQL = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdateMumBabyFlag", ref strSQL) == -1)
			{
				return -1;
			}
			#region SQL
			/*
			 UPDATE 	fin_ipr_inmaininfo  
				SET	baby_flag ='{1}' 
				WHERE	parent_code='[父级编码]' 
				AND	current_code='[本级编码]'  
				AND	inpatient_no='{0}'
		
			 */
			#endregion
			
			try
			{
				strSQL = string.Format(strSQL, inpatientNO, NConvert.ToInt32(isHasBaby).ToString());
			}
			catch(Exception ex)
			{
				Err = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSQL);
		}

        //{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F} 婴儿的费用是否可以收取到妈妈身上

        /// <summary>
        /// 通过婴儿的住院流水号,查询母亲的住院流水号
        /// </summary>
        /// <param name="babyInpatientNO">婴儿住院流水号</param>
        /// <returns>母亲的住院流水号 错误返回 null 或者 string.Empty</returns>
        public string QueryBabyMotherInpatientNO(string babyInpatientNO) 
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("RADT.Inpatient.QueryBabyMotherInpatientNO.Query.1", ref sql) == -1) 
            {
                this.Err = "没有找到索引为:RADT.Inpatient.QueryBabyMotherInpatientNO.Query.1的SQL语句";

                return null;
            }
            try
            {
                sql = string.Format(sql, babyInpatientNO);
            }
            catch (Exception e) 
            {
                this.Err = e.Message;

                return null;
            }

            return this.ExecSqlReturnOne(sql);
        }
        ////{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F} 婴儿的费用是否可以收取到妈妈身上 结束

		#endregion

		#region shiftData

        /// <summary>
        /// 获取转科信息
        /// </summary>
        /// <param name="patientNo"></param>
        /// <returns></returns>
        public ArrayList GetPatientRADTInfo(string patientNo)
        {
            string strSQL = string.Empty;
            ArrayList alPatientRADT = new ArrayList();
            if (Sql.GetSql("RADT.InPatient.QueryShiftDeptInfo", ref strSQL) == -1)
            {
                this.Err = "RADT.InPatient.QueryShiftDeptInfo出错!";
                WriteErr();
                return null;
            }

            try
            {
                strSQL = string.Format(strSQL, patientNo);
            }
            catch (Exception ee)
            {
                Err = ee.Message;
                WriteErr();
                return null;
            }

            if (ExecQuery(strSQL) < 0)
            {
                return null;
            }
            try
            {
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Invalid.CShiftData myCShiftDate = new Neusoft.HISFC.Models.Invalid.CShiftData();
                    myCShiftDate.ClinicNo = this.Reader[0].ToString();//住院号
                    myCShiftDate.Mark = this.Reader[1].ToString();//发生序号
                    myCShiftDate.OldDataCode = this.Reader[2].ToString();//存储原科室
                    myCShiftDate.OldDataName = this.Reader[3].ToString();//存储原护士站
                    myCShiftDate.NewDataCode = this.Reader[4].ToString();//存储新科室
                    myCShiftDate.NewDataName = this.Reader[5].ToString();//存储新护士站
                    myCShiftDate.User01 = this.Reader[6].ToString();//原床号
                    myCShiftDate.User02 = this.Reader[7].ToString();//新床号
                    myCShiftDate.OperCode = this.Reader[8].ToString();//操作员
                    myCShiftDate.User03 = this.Reader[9].ToString();//确认时间

                    alPatientRADT.Add(myCShiftDate);
                }
            }
            catch (Exception ee)
            {
                Reader.Close();
                Err = ee.Message;
                WriteErr();
                return null;
            }
            this.Reader.Close();
            return alPatientRADT;
        }

		/// <summary>
		/// 获得患者的变更记录
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <returns></returns>
		public ArrayList QueryPatientShiftInfo(string inpatientNO)
		{
			ArrayList al = new ArrayList();
			string strSql = string.Empty;

			#region 接口说明

			//RADT.Inpatient.GetShiftDataList.1
			//传入：住院号流水号
			//传出：住院流水号,发生序号,变更类型,原资料代号,原资料名称,新资料代号,新资料名称,变更原因 ,操作员代码 ,操作时间,备注                                                            

			#endregion

			if (Sql.GetSql("RADT.Inpatient.GetShiftDataList.1", ref strSql) == 0)
			{
				#region SQL
				/* select	HAPPEN_NO,SHIFT_TYPE,OLD_DATA_CODE,
				 * OLD_DATA_NAME,NEW_DATA_CODE,NEW_DATA_NAME,mark,
				 * SHIFT_CAUSE,OPER_CODE,OPER_Date from com_shiftdata	
				 * where  PARENT_CODE='[父级编码]' 
				 * and CURRENT_CODE='[本级编码]' 
				 * and clinic_no='{0}' 	
				 */
				#endregion
				try
				{
					strSql = string.Format(strSql, inpatientNO);
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					WriteErr();
					return null;
				}
				ExecQuery(strSql);
				while (Reader.Read())
				{
					NeuObject obj = new NeuObject();
					NeuObject old_Obj = new NeuObject();
					NeuObject new_Obj = new NeuObject();
					obj.ID = Reader[0].ToString();
					obj.Name = Reader[1].ToString();
					old_Obj.ID = Reader[2].ToString();
					old_Obj.Name = Reader[3].ToString();
					new_Obj.ID = Reader[4].ToString();
					new_Obj.Name = Reader[5].ToString();
					obj.Memo = Reader[6].ToString();
					obj.User01 = Reader[7].ToString();
					obj.User02 = Reader[8].ToString();
					obj.User03 = Reader[9].ToString();
					al.Add(obj);
				}
				Reader.Close();
			}
			else
			{
				return null;
			}
			return al;
		}

        /// <summary>
        /// 获得患者的变更记录,返回的是CShiftData(注意有些字段没法对应实体，请具体查看本函数取值!)
        /// 上边原来的那个返回的是NeuObject，不全！
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryPatientShiftInfoNew(string inpatientNO)
        {
            ArrayList al = new ArrayList();
            string strSql = string.Empty;
            #region 接口说明
            //RADT.Inpatient.GetShiftDataList.1
            //传入：住院号流水号
            //传出：住院流水号,发生序号,变更类型,原资料代号,原资料名称,新资料代号,新资料名称,变更原因 ,操作员代码 ,操作时间,备注
            #endregion
            if (Sql.GetSql("RADT.Inpatient.GetShiftDataList.1", ref strSql) == 0)
            {
                /*
                 *  select  HAPPEN_NO,
                            SHIFT_TYPE,
                            OLD_DATA_CODE,
                            OLD_DATA_NAME,
                            NEW_DATA_CODE,
                            NEW_DATA_NAME,
                            mark,
                            SHIFT_CAUSE,
                            OPER_CODE,
                            OPER_Date 
                    from com_shiftdata  
                    where   clinic_no='{0}'   
                 */
                try
                {
                    strSql = string.Format(strSql, inpatientNO);
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    ErrCode = ex.Message;
                    WriteErr();
                    return null;
                }
                ExecQuery(strSql);
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Invalid.CShiftData myCShiftDate = new Neusoft.HISFC.Models.Invalid.CShiftData();

                    myCShiftDate.User01 = Reader[0].ToString();
                    myCShiftDate.ShitType = Reader[1].ToString();
                    myCShiftDate.OldDataCode = Reader[2].ToString();
                    myCShiftDate.OldDataName = Reader[3].ToString();
                    myCShiftDate.NewDataCode = Reader[4].ToString();
                    myCShiftDate.NewDataName = Reader[5].ToString();
                    myCShiftDate.Mark = Reader[6].ToString();
                    myCShiftDate.ShitCause = Reader[7].ToString();
                    myCShiftDate.OperCode = Reader[8].ToString();
                    myCShiftDate.Memo = Reader[9].ToString();
                    al.Add(myCShiftDate);
                }
                Reader.Close();
            }
            else
            {
                return null;
            }
            return al;
        }


		[System.Obsolete("更改为 QueryPatientShiftInfo",true)]
		public ArrayList GetShiftDataList(string inpatientNO)
		{
			return null;
		}



        /// <summary>
        /// 设置变更信息-插入变更信息表
        /// insert {FA32C976-E003-4a10-9028-71F2CD154052} 接诊时间
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="Type">变更类型</param>
        /// <param name="Memo">备注</param>
        /// <param name="oldObject">变更前数据</param>
        /// <param name="newObject">变更后数据</param>
        /// <returns>0 成功  -1失败</returns>
        public int SetShiftData(string InpatientNo, DateTime operDate,EnumShiftType Type, string Memo, NeuObject oldObject, NeuObject newObject)
        {
            string strSql = "";
            if (this.Sql.GetSql("RADT.InPatient.ShiftData.2", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql,
                    InpatientNo,		//0 患者住院流水号
                    Type.ToString(),	//1 变更类型
                    oldObject.ID,		//2 变更前数据编码
                    oldObject.Name,		//3 变更前数据名称
                    newObject.ID,		//4 变更后数据编码
                    newObject.Name,		//5 变更后数据名称
                    Memo,				//6 备注
                    this.Operator.ID,	//7 操作人
                    ((Employee)Operator).Dept.ID,//8 操作人所在科室
                    oldObject.Memo,		//9 变更前护理站编码
                    newObject.Memo		//10 变更后护理站编码

                    //{FA32C976-E003-4a10-9028-71F2CD154052} 接诊时间
                    ,operDate.ToString("yyyy-MM-dd HH:mm:ss")
                    );
            }
            catch
            {
                this.Err = "传入参数错误！RADT.InPatient.ShiftData.2!";
                this.WriteErr();
                return -1;
            }

            int parm = this.ExecNoQuery(strSql);
            if (parm != 1)
                return parm;

            //如果患者不是婴儿,并且床位发生变化，则更新住院日报。
            //added by cuipeng 
            //2005-4
            //1接珍neusoft.HISFC.Management.RADT.InPatient.enuShiftType.K－接诊，
            //2转科（转入、转出）neusoft.HISFC.Management.RADT.InPatient.enuShiftType.RD－转科，
            //3出院登记neusoft.HISFC.Management.RADT.InPatient.enuShiftType.O－出院登记，
            //4招回neusoft.HISFC.Management.RADT.InPatient.enuShiftType.C－召回，
            //5无费退院－neusoft.HISFC.Management.RADT.InPatient.enuShiftType.OF－无费退院"
            if (InpatientNo.IndexOf("ZY") == 0 && InpatientNo.IndexOf("B") < 0 && (Type.ToString() == "K" || Type.ToString() == "RI" || Type.ToString() == "RO" || Type.ToString() == "O" || Type.ToString() == "C" || Type.ToString() == "OF"))
            {
                try
                {
                    //取患者此时刻的信息（转科之后的信息）
                    //Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.GetPatientInfoByPatientNO(InpatientNo);
                    Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.QueryPatientInfoByInpatientNO(InpatientNo);
                    if (patientInfo == null)
                        return -1;

                    //如果无费退院时没有床位，则不更新住院日报
                    if (patientInfo.PVisit.PatientLocation.Bed.ID == "" && Type.ToString() == "OF")
                        return 1;


                    //取系统时间
                    DateTime sysDate = Convert.ToDateTime(this.GetSysDate() + " 00:00:00");

                    //定义住院日报管理类
                    InpatientDayReport reportManager = new InpatientDayReport();

                    //传递Transaction
                    reportManager.SetTrans(this.Trans);

                    //患者最新的科室编码和护理站编码,对于转出前的科室不正确
                    if (Type.ToString() == "RO")
                    {
                        patientInfo.PVisit.PatientLocation.Dept.ID = oldObject.ID;			//转科前科室编码
                        patientInfo.PVisit.PatientLocation.NurseCell.ID = oldObject.Memo;	//转科前护理站编码
                        patientInfo.PVisit.PatientLocation.Bed.ID = oldObject.User01;		//转科前床位编码
                        patientInfo.PVisit.PatientLocation.Dept.User03 = newObject.ID;		//user03用来保存转科后的科室编码
                    }
                    else
                    {
                        patientInfo.PVisit.PatientLocation.Dept.User03 = oldObject.ID;		//user03用来保存转科前的科室编码
                    }

                    parm = reportManager.DynamicUpdate(patientInfo, Type.ToString());
                    if (parm != 1)
                    {
                        this.Err = reportManager.Err;
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return -1;
                }
            }//end if
            return 1;
        }




		/// <summary>
		/// 设置变更信息-插入变更信息表
		/// insert
		/// </summary>
		/// <param name="InpatientNo">住院流水号</param>
		/// <param name="Type">变更类型</param>
		/// <param name="Memo">备注</param>
		/// <param name="oldObject">变更前数据</param>
		/// <param name="newObject">变更后数据</param>
		/// <returns>0 成功  -1失败</returns>
        public int SetShiftData(string InpatientNo, EnumShiftType Type, string Memo, NeuObject oldObject, NeuObject newObject)
        {
            string strSql = "";
            if (this.Sql.GetSql("RADT.InPatient.ShiftData.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql,
                    InpatientNo,		//0 患者住院流水号
                    Type.ToString(),	//1 变更类型
                    oldObject.ID,		//2 变更前数据编码
                    oldObject.Name,		//3 变更前数据名称
                    newObject.ID,		//4 变更后数据编码
                    newObject.Name,		//5 变更后数据名称
                    Memo,				//6 备注
                    this.Operator.ID,	//7 操作人
                    ((Employee)Operator).Dept.ID,//8 操作人所在科室
                    oldObject.Memo,		//9 变更前护理站编码
                    newObject.Memo		//10 变更后护理站编码
                    );
            }
            catch
            {
                this.Err = "传入参数错误！RADT.InPatient.ShiftData.1!";
                this.WriteErr();
                return -1;
            }

            int parm = this.ExecNoQuery(strSql);
            if (parm != 1) return parm;

            //如果患者不是婴儿,并且床位发生变化，则更新住院日报。
            //added by cuipeng 
            //2005-4
            //1接珍neusoft.HISFC.Management.RADT.InPatient.enuShiftType.K－接诊，
            //2转科（转入、转出）neusoft.HISFC.Management.RADT.InPatient.enuShiftType.RD－转科，
            //3出院登记neusoft.HISFC.Management.RADT.InPatient.enuShiftType.O－出院登记，
            //4招回neusoft.HISFC.Management.RADT.InPatient.enuShiftType.C－召回，
            //5无费退院－neusoft.HISFC.Management.RADT.InPatient.enuShiftType.OF－无费退院"
            if (InpatientNo.IndexOf("ZY") == 0 && InpatientNo.IndexOf("B") < 0 && (Type.ToString() == "K" || Type.ToString() == "RI" || Type.ToString() == "RO" || Type.ToString() == "O" || Type.ToString() == "C" || Type.ToString() == "OF" || Type.ToString() == "CN"|| Type.ToString() == "CNO"))
            {
                try
                {
                    //取患者此时刻的信息（转科之后的信息）
                    //Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.GetPatientInfoByPatientNO(InpatientNo);
                    Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.QueryPatientInfoByInpatientNO(InpatientNo);
                    if (patientInfo == null) return -1;

                    //如果无费退院时没有床位，则不更新住院日报
                    if (patientInfo.PVisit.PatientLocation.Bed.ID == "" && Type.ToString() == "OF") return 1;


                    //取系统时间
                    DateTime sysDate = Convert.ToDateTime(this.GetSysDate() + " 00:00:00");

                    //定义住院日报管理类
                    InpatientDayReport reportManager = new InpatientDayReport();

                    //传递Transaction
                    reportManager.SetTrans(this.Trans);

                    //患者最新的科室编码和护理站编码,对于转出前的科室不正确
                    //{B1E611C2-7A04-4b79-B64B-3D280D5769CE} 修改病案日报
                    if (Type.ToString() == "RO" || Type.ToString() == "CNO")
                    {
                        if (oldObject.User02 != "N")
                        {
                            patientInfo.PVisit.PatientLocation.Dept.ID = oldObject.ID;			//转科前科室编码
                            patientInfo.PVisit.PatientLocation.NurseCell.ID = oldObject.Memo;	//转科前护理站编码
                            patientInfo.PVisit.PatientLocation.Bed.ID = oldObject.User01;		//转科前床位编码
                            patientInfo.PVisit.PatientLocation.Dept.User03 = newObject.ID;		//user03用来保存转科后的科室编码
                        }
                        else
                        {
                            patientInfo.PVisit.PatientLocation.Dept.ID = oldObject.User03;			//转科前科室编码
                            patientInfo.PVisit.PatientLocation.NurseCell.ID = oldObject.ID;	//转科前护理站编码
                            patientInfo.PVisit.PatientLocation.Bed.ID = oldObject.User01;		//转科前床位编码
                            patientInfo.PVisit.PatientLocation.Dept.User03 = newObject.ID;		//user03用来保存转科后的科室编码
                        }
                        
                        
                    }
                    else
                    {
                        patientInfo.PVisit.PatientLocation.Dept.User03 = oldObject.ID;		//user03用来保存转科前的科室编码
                    }

                    #region {8997C648-0AE4-42f4-943A-4E34EC127B39}
                    //召回的日报处理那块使用了患者的出院时间，但召回操作把患者信息的出院时间清空了
                    //此函数上面重新取了患者信息，所以没取到出院时间，在这里取一下变更信息，把患者最新的出院时间找到
                    if (Type.ToString() == "C")
                    {
                        ArrayList altmp = this.QueryPatientShiftInfoNew(patientInfo.ID);

                        DateTime outtime = DateTime.MinValue;

                        foreach (Neusoft.HISFC.Models.Invalid.CShiftData myCShiftDate in altmp)
                        {
                            if (myCShiftDate.ShitType == "O")
                            {
                                if (outtime < Neusoft.FrameWork.Function.NConvert.ToDateTime(myCShiftDate.Memo))
                                {
                                    outtime = Neusoft.FrameWork.Function.NConvert.ToDateTime(myCShiftDate.Memo);
                                }
                            }
                        }

                        patientInfo.PVisit.OutTime = outtime;
                    }
                    #endregion
                    //如果新科室编码==旧科室编码就是转病区，不用插入日报{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
                    if (oldObject.ID != newObject.ID || oldObject.Memo != newObject.Memo)
                    {
                        parm = reportManager.DynamicUpdate(patientInfo, Type.ToString());
                        if (parm != 1)
                        {
                            this.Err = reportManager.Err;
                            return -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return -1;
                }
            }//end if
            return 1;
        }

		#endregion
    
		#region 身份变更
		/// <summary>
		/// 修改住院主表合同单位和结算类别信息
		/// </summary>
		/// <param name="PatientNo"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int UpdatemainInfoPact(string PatientNo,NeuObject obj) 
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("RADT.InPatient.UpdatePact",ref strSql) == -1) 
			{
				return -1;
			}

			try 
			{
				strSql=string.Format(strSql,
					PatientNo,	//4 		住院号	
					obj.ID,	//1 合同单位代码
					obj.Name,		//2 	合同单位名称	
					obj.User01,	//3 结算类别代码
					//					obj.User02,	//0 结算类别名称
					obj.User03
									
					);
			}
			catch (Exception ex)
			{
				this.Err="传入参数错误！RADT.InPatient.ShiftData.1!";
				this.ErrCode = ex.Message;
				this.WriteErr();

				return -1;
			}
			int parm = this.ExecNoQuery(strSql);
			if(parm != 1)
			{
				return parm;
			}

			return 0;

		}
		/// <summary>
		/// 身份变更，更改变更后公费患者主表信息
		/// </summary>
		/// <param name="patient"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int UpdateMainInfoPubPact(PatientInfo patient,NeuObject obj)
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("RADT.InPatient.UpdateMainInfoPubPact",ref strSql) == -1) 
			{
				return -1;
			}
			/*update fin_ipr_inmaininfo 
			Set    PACT_CODE = '{1}',--		合同代码
				PACT_NAME ='{2}',--	合同单位名称
				PAYKIND_CODE	='{3}',--		结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干       
				MCARD_NO = '{4}',
				FEE_INTERVAL = {5},
				bed_limit = {6},
				bedoverdeal='{7}',
				day_limit ={8},
				limit_tot={9},
				limit_overtop={10},
				air_limit={11}       
			WHERE  PARENT_CODE='[父级编码]'	
			and 	CURRENT_CODE='[本级编码]' 
			and inpatient_no ='{0}'
			*/
			try 
			{
				strSql=string.Format(strSql,
					patient.ID,	//0 		住院号	
					obj.ID,	//1 合同单位代码
					obj.Name,		//2 	合同单位名称	
					obj.User01,	//3 结算类别代码
					obj.User03,//4卡号
					patient.FT.FixFeeInterval.ToString(),//5固定费用周期
					patient.FT.BedLimitCost.ToString(),//6床位标准
					patient.FT.BedOverDeal,//7床位处理
					patient.FT.DayLimitCost.ToString(),//8日限额
					patient.FT.DayLimitTotCost.ToString(),//9日限总额
					patient.FT.OvertopCost.ToString(),//10超标金额
					patient.FT.AirLimitCost.ToString()//11监护床									
					);
			}
			catch (Exception ex)
			{
				this.Err="传入参数错误！RADT.InPatient.ShiftData.1!";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSql);
			
		}
		/// <summary>
		/// 修改患者信息表合同单位和结算类别信息
		/// </summary>
		/// <param name="PatientNo"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int UpdatePatientPact(string PatientNo,NeuObject obj) 
		{
			string strSql=string.Empty;
			if(this.Sql.GetSql("RADT.InPatient.SetPact",ref strSql) == -1) 
			{
				return -1;
			}

			try 
			{
				strSql=string.Format(strSql,
					PatientNo,
					obj.User01,
					obj.User02	,//0 患者流水号
					obj.ID,	//1 合同单位代码
					obj.Name		//2 合同单位名称
					//3 结算类别编码				
					);
			}
			catch (Exception ex)
			{
				this.Err="传入参数错误！RADT.InPatient.SetPact!";
			    this.ErrCode = ex.Message;
				this.WriteErr();
	
				return -1;
			}
			int parm = this.ExecNoQuery(strSql);
			if(parm != 1)
			{
				return parm;
			}

			return 0;
		}
		/// <summary>
		/// 身份变更
		/// </summary>
		/// <param name="patient"></param>
		/// <returns></returns>
		public int SetPactShiftData(PatientInfo patient,NeuObject newobj,NeuObject oldobj) 
		{
			if(patient.Pact.PayKind.ID=="03")/*公费患者，Add by maokb -2006-2-24*/
			{
				if(this.UpdateMainInfoPubPact(patient,newobj)!=1)
				{
					this.Err="更新住院主表失败!";
					return -1;
				}
			}
			else
			{
				if(this.UpdatemainInfoPact(patient.ID,newobj)!=0) 
				{
					this.Err="更新住院主表失败!";
					return -1;
				}
			}
			if(this.UpdatePatientPact(patient.PID.CardNO,newobj)!=0) 
			{
				this.Err="更新患者信息表失败!";
				return -1;
			}
			if(this.SetShiftData(patient.ID,EnumShiftType.CP,"身份变更",oldobj,newobj)<0) 
			{
				this.Err="更新变更表失败!";
				return -1;
			}
			return 0;

		}
		#endregion

		#region 取住院号，住院流水号生成规则，变更住院号,取可以用于病案的住院号号，更新住院号状态

		/// <summary>
		/// 根据自动生成住院号，住院流水号
		/// </summary>
		/// <param name="pInfo">如果从未用住院号表中取得，pInfo.User03 = "UnUsed"</param>
		/// <returns></returns>
		public int AutoCreatePatientNO(PatientInfo pInfo)
		{
			string patientNO = string.Empty;
			string usedPatientNO = string.Empty;
			if (GetNoUsedPatientNO(ref patientNO, ref usedPatientNO))
			{
				//如果是从未用住院号表中取得数据，标示以下
				pInfo.User03 = "UNUSED";
				return AutoCreatePatientNO(patientNO, usedPatientNO, ref pInfo);
			}
			else
			{
				return AutoCreatePatientNO(string.Empty, ref pInfo);
			}
		}

		/// <summary>
		/// 根据住院号生成住院流水号--用于多次入院,用已有住院号
		/// </summary>
		/// <param name="patientNO">患者住院号</param>
		/// <param name="pInfo"></param>
		/// <returns></returns>
		public int AutoCreatePatientNO(string patientNO, ref PatientInfo pInfo)
		{
			return AutoCreatePatientNO(patientNO, patientNO, ref pInfo);
		}
        /// <summary>
        /// 根据住院号取第一个就诊卡号
        /// </summary>
        /// <param name="patientNO"></param>
        /// <returns></returns>
        public int GetCardNOByPatientNO(string patientNO,ref string CardNo)
        {
            string Sqlstr = string.Empty;
            try
            {
                if (this.Sql.GetSql("RADT.InPatient.GetCardNOByPatientNO", ref Sqlstr) < 0)
                    return -1;
                Sqlstr = string.Format(Sqlstr, patientNO);
                CardNo = this.ExecSqlReturnOne(Sqlstr);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

		/// <summary>
		/// 根据住院号生成住院流水号
		/// </summary>
		/// <param name="patientNO">患者住院号</param>
		/// <param name="usedPatientNO">原来用患者新住院号的患者的当前住院号</param>
		/// <param name="pInfo"></param>
		/// <returns></returns>
		public int AutoCreatePatientNO(string patientNO, string usedPatientNO, ref PatientInfo pInfo)
		{
			if (pInfo == null)
			{
				pInfo = new PatientInfo();
			}
			if (patientNO == string.Empty)
			{
				//获取新的住院号和住院流水号
				string MaxPatientNo = string.Empty;
				Int64 iPatientNo = 0;
				MaxPatientNo = GetMaxPatientNO("0008");
				try
				{
					iPatientNo = Int64.Parse(MaxPatientNo) + 1;
					MaxPatientNo = iPatientNo.ToString();
					MaxPatientNo = MaxPatientNo.PadLeft(10, '0');
					pInfo.PID.PatientNO = MaxPatientNo;
					if (pInfo.ID == string.Empty)
					{
						pInfo.ID = "ZY01" + MaxPatientNo;
					}
					pInfo.PID.CardNO = "T" + MaxPatientNo.Substring(1, 9);
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					return -1;
				}
			}
			else
			{
				pInfo.PID.PatientNO = patientNO;
                string CardNo=string.Empty;
                //根据住院号取第一个就诊卡号（从预约登记中选取患者门诊卡号有可能不是自动生成的）
                if (this.GetCardNOByPatientNO(patientNO,ref CardNo) < 0)
                    return -1;
                if (CardNo !="-1")
                {
                    pInfo.PID.CardNO = CardNo;
                }
                else
                {
                    pInfo.PID.CardNO = "T" + patientNO.Substring(1, 9);
                }
				if (pInfo.ID == string.Empty)
				{
					//根据住院号取新的流水号
					string InPatientNo = GetMaxPatientNOByCardNO(pInfo.PID.CardNO);
					if (InPatientNo == string.Empty)
					{
						pInfo.ID = "ZY01" + patientNO;
					}
					else
					{

                        pInfo = this.QueryPatientInfoByInpatientNO(InPatientNo);
                      
                        int Seq = Neusoft.FrameWork.Function.NConvert.ToInt32(InPatientNo.Substring(2, 2));
						Seq++;
						pInfo.ID = "ZY" + Seq.ToString().PadLeft(2, '0') + patientNO;
                        pInfo.User03 = "SECOND";
					}
				}
			}
			return 1;
		}
		[Obsolete("更改为 AutoCreatePatientNO",true)]
		public int AutoPatientNo(string PatientNO, string UsedPatientNo, PatientInfo pInfo)
		{return 0 ;}
		/// <summary>
		/// 插入住院号变更记录
		/// </summary>
		/// <param name="NewPatientNO">新住院号</param>
		/// <param name="OldPatientNo">原住院号</param>
		/// <returns>1成功 ；其他，失败</returns>
		public int SetPatientNOShift(string NewPatientNO, string OldPatientNo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.SetPatientNoShift", ref strSql) == -1)
			{
				return -1;
			}
			//判断并发 如果更新成功则存在并发
			if (UpdatePatientNoState(OldPatientNo) == 1)
			{
				Err = "已经存在未使用的住院号" + OldPatientNo + ",可能存在并发";
				return -1;
			}

			try
			{
				strSql = string.Format(strSql,
				                       NewPatientNO, //0 患者新的住院号
				                       OldPatientNo, //1 患者旧的住院号
				                       Operator.ID //2 变更后数据编码
					);
			}
			catch
			{
				Err = "传入参数错误！RADT.InPatient.SetPatientNoShift!";
				WriteErr();
				return -1;
			}

			int parm = ExecNoQuery(strSql);
			return parm;
		}
		[Obsolete("更改为 SetPatientNOShift",true)]
		public int SetPatientNoShift(string NewPatientNO, string OldPatientNo)
		{
			return 0 ;
		}
		/// <summary>
		/// 获取还没有用过的住院号
		/// </summary>
		/// <param name="patientNO">未用住院号</param>
		/// <param name="usedPatientNo">已用住院号</param>
		/// <returns>true,取到；false 没有未使用的住院号</returns>
		public bool GetNoUsedPatientNO(ref string patientNO, ref string usedPatientNo)
		{
			string strSql = string.Empty;
			bool rtn = false;
			try
			{
				if (Sql.GetSql("RADT.InPatient.GetNoUsedPatientNo", ref strSql) == -1)
				{
					return false;
				}

				if (ExecQuery(strSql) == -1)
				{
					return false;
				}
				while (Reader.Read())
				{
					rtn = true;
					usedPatientNo = Reader[0].ToString();
					patientNO = Reader[1].ToString();
				}
				return rtn;
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				WriteErr();
				return false;
			}
		}
		[System.Obsolete("更改为 GetNoUsedPatientNO ",true)]
		public bool GetNoUsedPatientNo(ref string PatientNO, ref string UsedPatientNo)
		{
			return true;
		}
		/// <summary>
		/// 更新未使用的住院号为使用状态
		/// </summary>
		/// <param name="OldPatienNo">旧的住院号，未使用的</param>
		/// <returns>1成功；0,产生并发，应该重新获取住院号；-1 失败</returns>
		public int UpdatePatientNoState(string OldPatienNo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdatePateintNoState", ref strSql) == -1)
			{
				return -1;
			}

			try
			{
				strSql = string.Format(strSql,
				                       OldPatienNo, //0 患者旧的住院号
				                       Operator.ID //1 操作员
					);
			}
			catch
			{
				Err = "传入参数错误！RADT.InPatient.UpdatePateintNoState!";
				WriteErr();
				return -1;
			}

			int parm = ExecNoQuery(strSql);
			if (parm == 0)
			{
				Err = "该住院号已被使用。";
			}
			return parm;
		}

		/// <summary>
		/// 更改住院号
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <param name="oldCardNo">原门诊卡号</param>
		/// <param name="newPatientNO">新住院号</param>
		/// <returns></returns>
		public int UpdatePatientNO(string inpatientNO, string oldCardNo, string newPatientNO)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;
			string NewCardNo = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdatePatientNo", ref strSql1) == -1)
			{
				return -1;
			}
			if (Sql.GetSql("RADT.InPatient.UpdateCardNo", ref strSql2) == -1)
			{
				return -1;
			}
			try
			{
				NewCardNo = "T" + newPatientNO.Substring(1, 9);

				strSql1 = string.Format(strSql1, inpatientNO, newPatientNO, NewCardNo);
				strSql2 = string.Format(strSql2, oldCardNo, NewCardNo);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			if (ExecNoQuery(strSql1) != 1)
			{
				return -1;
			}
			if (ExecNoQuery(strSql2) != 1)
			{
				if (DBErrCode == 1)
				{
					//主键重复,则继续进行
					return 1;
				}
				else
				{
					return -1;
				}
			}
			return 1;
		}
		
		[Obsolete("更改为 UpdatePatientNO",true)]
		public int UpdatePatientNo(string inpatientNO, string oldCardNo, string newPatientNO)
		{
			return 0 ;
		}
		/// <summary>
		/// 更改医保主表住院号
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <param name="newPatientNO">新住院号</param>
		/// <returns></returns>
		public int UpdateSIPatientNO(string inpatientNO, string newPatientNO)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdateSIPatientNo", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, inpatientNO, newPatientNO);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		#region 转科申请

		
		/// <summary>
		/// 插入转科表
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <param name="oldLocation">原科室</param>
		/// <param name="newLocation">新科室</param>
		/// <param name="type"></param>
		/// <param name="reason"></param>
		/// <returns></returns>
		private int InsertShiftDept(string inpatientNO, Location oldLocation, Location newLocation, string type,string reason)
		{
			string strSQL = string.Empty;
			if (Sql.GetSql("RADT.InPatient.InsertShiftDept.1", ref strSQL) == -1)
			{
				return -1;
			}
			try
			{
				strSQL = string.Format(strSQL,
				                       inpatientNO, //0 住院流水号
				                       oldLocation.Dept.ID, //1 原来科室
				                       newLocation.Dept.ID, //2 转往科室
				                       oldLocation.NurseCell.ID, //3 护士站代码
				                       newLocation.NurseCell.ID, //4 转往护理站代码
				                       type, //5 当前状态,1转科申请,2确认,3取消申请
				                       Operator.ID, //6 操作员
				                       reason, //7 备注
				                       oldLocation.Bed.ID); //8 原病床号
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.InsertShiftDept.1";
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSQL);
		}
		[System.Obsolete("未用",true)]
		private int myInsertShiftDept(string InpatientNo, Location oldLocation, Location newLocation, string type,string reason)
		{
			return 0;
		}
		/// <summary>
		/// 更新转科确认新分配的病床和确认人.
		/// </summary>
		/// <param name="inpatientNo">患者住院流水号</param>
		/// <param name="location">新分配的床位信息</param>
		/// <returns>-1 失败, 0 更新失败(没有找到记录), rows 更新的行数</returns>
		public int UpdateShiftApply(string inpatientNo, Location location)
		{
			#region "接口说明"

			//更新转科表
			//RADT.InPatient.UpdateShiftDept.1
			//传入：0 住院流水号,1新分配的床号
			//传出：0

			#endregion

			string strSQL = string.Empty;
			int happenNo = 0;

			if (Sql.GetSql("RADT.Inpatient.UpdateShiftApply.1", ref strSQL) == -1)
			{
				Err = "获得SQL语句出错!";
				WriteErr();
				return -1;
			}

			happenNo = CheckShiftInHappenNo(inpatientNo, location, "1");

			try
			{
				strSQL = string.Format(strSQL, inpatientNo, location.Bed.ID, Operator.ID, happenNo);
			}
			catch (Exception e)
			{
				Err = "传入参数不对！RADT.InPatient.UpdateShiftDept.1" + e.Message;
				WriteErr();
				return -1;
			}

			return ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 更新科室申请（确认和取消）
		/// </summary>
		/// <param name="inPatientNo">患者信息</param>
		/// <param name="happenno">转科序号</param>
		/// <param name="type">1转科申请,2确认,3取消申请</param>
		/// <param name="newLocation">床位信息</param>
		/// <returns></returns>
		private int UpdateShiftDept(string inPatientNo, int happenno, string oldType, string type, Location newLocation)
		{
			#region "接口说明"

			//更新转科表
			//RADT.InPatient.UpdateShiftDept.1
			//传入：0 住院流水号,1发生序号 2 原来的状态 3 新状态 4 确认人ID 5 确认时间 6 取消人ID 7 取消时间 
			//传出：0

			#endregion

			string strSQL = string.Empty;
			string old_type = "1";
			old_type = oldType;
			//更新转科申请信息
			if (type == "2" || type == "1")
			{
				if (Sql.GetSql("RADT.InPatient.UpdateShiftDept.1", ref strSQL) == -1)
				{
					return -1;
				}

				try
				{
					strSQL = string.Format(strSQL,
					                       inPatientNo, //0住院流水号
					                       happenno, //1发生序号	
					                       old_type, //2更新前申请状态
					                       type, //3更新后申请状态
					                       Operator.ID, //4确认人
					                       newLocation.Dept.ID, //5转入科室编码
					                       newLocation.NurseCell.ID, //6转入护理站编码
					                       newLocation.Bed.ID); //7床号
				}
				catch
				{
					Err = "传入参数不对！RADT.InPatient.UpdateShiftDept.1";
					WriteErr();
					return -1;
				}
			}
				//作废转科申请
			else if (type == "3")
			{
				if (Sql.GetSql("RADT.InPatient.UpdateShiftDept.2", ref strSQL) == -1)
				{
					return -1;
				}

				try
				{
					strSQL = string.Format(strSQL,
					                       inPatientNo, //0住院流水号
					                       happenno, //1发生序号	
					                       old_type, //2更新前申请状态
					                       type, //3更新后申请状态
					                       Operator.ID); //4取消人编码
				}
				catch
				{
					Err = "传入参数不对！RADT.InPatient.UpdateShiftDept.2";
					WriteErr();
					return -1;
				}
			}
			else
			{
				Err = "无效的转科状态";
				return -1;
			}

			return ExecNoQuery(strSQL);
		}
		[System.Obsolete("已过期",true)]
		private int myUpdateShiftDept(string inPatientNo, int happenno, string oldType, string type, Location newLocation)
		{
			return 0;
		}
		/// <summary>
		///  更新转科申请的状态
		/// </summary>
		/// <param name="inpatientNo"></param>// 住院流水号
		/// <param name="newState"></param>// 新状态
		/// <param name="oldState"></param>// 原来状态
		/// <returns></returns>
		public int UpdateApplyState(string inpatientNo, Location location, string newState, string oldState)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdateApplyState", ref strSql) == -1)
			{
				return -1;
			}
			int happenNo = CheckShiftOutHappenNo(inpatientNo, location, oldState);
			try
			{
				strSql = String.Format(strSql, inpatientNo, newState, oldState, location.Dept.ID, location.NurseCell.ID, happenNo);
			}
			catch
			{
				Err = "传入参数不对！RADT.InPatient.UpdateShiftDept.2";
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

        #region 转病区申请
        
        /// <summary>
        /// 插入转科表
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="oldLocation">原科室</param>
        /// <param name="newLocation">新科室</param>
        /// <param name="type"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        private int InsertShiftNurseCell(string inpatientNO, Location oldLocation, Location newLocation, string type, string reason)
        {
            string strSQL = string.Empty;
            if (Sql.GetSql("RADT.InPatient.InsertShiftNurseCell.1", ref strSQL) == -1)
            {
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL,
                                       inpatientNO, //0 住院流水号
                                       oldLocation.Dept.ID, //1 原来科室
                                       newLocation.Dept.ID, //2 转往科室
                                       oldLocation.NurseCell.ID, //3 护士站代码
                                       newLocation.NurseCell.ID, //4 转往护理站代码
                                       type, //5 当前状态,1转科申请,2确认,3取消申请
                                       Operator.ID, //6 操作员
                                       reason, //7 备注
                                       oldLocation.Bed.ID); //8 原病床号
            }
            catch
            {
                Err = "传入参数不对！RADT.InPatient.InsertShiftNurseCell.1";
                WriteErr();
                return -1;
            }
            return ExecNoQuery(strSQL);
        }
        
        /// <summary>
        /// 更新转科确认新分配的病床和确认人.
        /// </summary>
        /// <param name="inpatientNo">患者住院流水号</param>
        /// <param name="location">新分配的床位信息</param>
        /// <returns>-1 失败, 0 更新失败(没有找到记录), rows 更新的行数</returns>
        public int UpdateShiftNurseCell(string inpatientNo, Location location)
        {
            #region "接口说明"

            //更新转科表
            //RADT.InPatient.UpdateShiftDept.1
            //传入：0 住院流水号,1新分配的床号
            //传出：0

            #endregion

            string strSQL = string.Empty;
            int happenNo = 0;

            if (Sql.GetSql("RADT.InPatient.UpdateShiftNurseCell.1", ref strSQL) == -1)
            {
                Err = "获得SQL语句出错!";
                WriteErr();
                return -1;
            }

            happenNo = CheckShiftInHappenNo(inpatientNo, location, "1");

            try
            {
                strSQL = string.Format(strSQL, inpatientNo, location.Bed.ID, Operator.ID, happenNo);
            }
            catch (Exception e)
            {
                Err = "传入参数不对！RADT.InPatient.UpdateShiftNurseCell.1" + e.Message;
                WriteErr();
                return -1;
            }

            return ExecNoQuery(strSQL);
        }

        /// <summary>
        /// 更新科室申请（确认和取消）
        /// </summary>
        /// <param name="inPatientNo">患者信息</param>
        /// <param name="happenno">转科序号</param>
        /// <param name="type">1转科申请,2确认,3取消申请</param>
        /// <param name="newLocation">床位信息</param>
        /// <returns></returns>
        private int UpdateShiftNurseCell(string inPatientNo, int happenno, string oldType, string type, Location newLocation)
        {
            #region "接口说明"

            //更新转科表
            //RADT.InPatient.UpdateShiftDept.1
            //传入：0 住院流水号,1发生序号 2 原来的状态 3 新状态 4 确认人ID 5 确认时间 6 取消人ID 7 取消时间 
            //传出：0

            #endregion

            string strSQL = string.Empty;
            string old_type = "1";
            old_type = oldType;
            //更新转科申请信息
            if (type == "2" || type == "1")
            {
                if (Sql.GetSql("RADT.InPatient.UpdateShiftNurseCell.2", ref strSQL) == -1)
                {
                    return -1;
                }

                try
                {
                    strSQL = string.Format(strSQL,
                                           inPatientNo, //0住院流水号
                                           happenno, //1发生序号	
                                           old_type, //2更新前申请状态
                                           type, //3更新后申请状态
                                           Operator.ID, //4确认人
                                           newLocation.Dept.ID, //5转入科室编码
                                           newLocation.NurseCell.ID, //6转入护理站编码
                                           newLocation.Bed.ID); //7床号
                }
                catch
                {
                    Err = "传入参数不对！RADT.InPatient.UpdateShiftNurseCell.2";
                    WriteErr();
                    return -1;
                }
            }
            //作废转科申请
            else if (type == "3")
            {
                if (Sql.GetSql("RADT.InPatient.UpdateShiftNurseCell.3", ref strSQL) == -1)
                {
                    return -1;
                }

                try
                {
                    strSQL = string.Format(strSQL,
                                           inPatientNo, //0住院流水号
                                           happenno, //1发生序号	
                                           old_type, //2更新前申请状态
                                           type, //3更新后申请状态
                                           Operator.ID); //4取消人编码
                }
                catch
                {
                    Err = "传入参数不对！RADT.InPatient.UpdateShiftNurseCell.3";
                    WriteErr();
                    return -1;
                }
            }
            else
            {
                Err = "无效的转科状态";
                return -1;
            }

            return ExecNoQuery(strSQL);
        }
        
        /// <summary>
        ///  更新转科申请的状态
        /// </summary>
        /// <param name="inpatientNo"></param>// 住院流水号
        /// <param name="newState"></param>// 新状态
        /// <param name="oldState"></param>// 原来状态
        /// <returns></returns>
        public int UpdateShiftNurseCellState(string inpatientNo, Location location, string newState, string oldState)
        {
            string strSql = string.Empty;
            if (Sql.GetSql("RADT.InPatient.UpdateShiftNurseCellState.1", ref strSql) == -1)
            {
                return -1;
            }
            int happenNo = CheckShiftOutHappenNo(inpatientNo, location, oldState);
            try
            {
                strSql = String.Format(strSql, inpatientNo, newState, oldState, location.Dept.ID, location.NurseCell.ID, happenNo);
            }
            catch
            {
                Err = "传入参数不对！RADT.InPatient.UpdateShiftNurseCellState.1";
                return -1;
            }
            return ExecNoQuery(strSql);
        }
                
        #endregion

		#region "请假管理"

		/// <summary>
		/// 插入请假信息表 传入：0 InpatientNo,1 docid,2 days,3 remark 4 operator
		/// </summary>
		/// <param name="patientLeave">请假信息</param>
		/// <param name="bed">床位</param>
		/// <returns>大于 0 成功 小于 0 失败</returns>
		public int InsertPatientLeave(Leave patientLeave, Bed bed)
		{
			string strSql = string.Empty;

			if (Sql.GetSql("RADT.InPatient.InsertPatientLeave", ref strSql) == 0)
			{
				#region SQL
				/*			
					INSERT INTO MET_NUI_LEAVE (
					PARENT_CODE ,                           --父级医疗机构编码
					CURRENT_CODE ,                          --本级医疗机构编码
					INPATIENT_NO ,                          --住院流水号
					LEAVE_DATE ,                            --请假时间
					LEAVE_DAYS ,                            --请假天数
					DOCT_CODE ,                             --给假医生
					OPER_CODE ,                             --请假操作人
					LEAVE_FLAG ,                            --0请假 1消假,2作废
					REMARK                                  --备注
					)  VALUES(
						'[父级编码]',       --父级医疗机构编码
						'[本级编码]',       --本级医疗机构编码
						'{0}' ,       --住院流水号
						SYSDATE ,     --请假时间
						{1} ,         --请假天数
						'{2}' ,       --给假医生
						'{3}' ,       --请假操作人
						'0' ,       --0请假 1消假,作废
						'{4}'         --备注
					) 
			    */
				#endregion
				try
				{
					strSql = string.Format(strSql,
					                       patientLeave.ID, //住院流水号
					                       patientLeave.LeaveDays.ToString(), //请假天数
					                       patientLeave.DoctCode, //给假医生
					                       Operator.ID, //请假操作人
					                       patientLeave.Memo); //备注
				}
				catch
				{
					Err = "传入参数错误！RADT.InPatient.InsertPatientLeave!";
					WriteErr();
					return -1;
				}
			}
			if (ExecNoQuery(strSql) <= 0)
			{
				return -1;
			}

			//更改前的床位信息
			Bed newBed = bed.Clone();
			//更改后的床位信息:请假R
			newBed.Status.ID = "R";
			//更新床位状态
			return UpdateBedStatus(newBed, bed);
		}

		/// <summary>
		/// 更新请假信息（请假）
		/// </summary>
		/// <param name="patientLeave"></param>
		/// <returns></returns>
		private int UpdatePatientLeave(Leave patientLeave)
		{
			string strSql = string.Empty;

			if (Sql.GetSql("RADT.InPatient.UpdatePatientLeave", ref strSql) == 0)
			{
				#region SQL
				/*UPDATE	MET_NUI_LEAVE 
					SET	LEAVE_DAYS = {2} ,                      --请假天数
					DOCT_CODE = '{3}' ,                     --给假医生
					OPER_CODE = '{4}' ,                   	--请假操作人
					LEAVE_FLAG = '0' ,                    	--0请假 1消假,2作废
					REMARK = '{5}'                          --备注
					WHERE 	PARENT_CODE = '[父级编码]' 
					AND  	CURRENT_CODE = '[本级编码]' 
					AND 	INPATIENT_NO = '{0}'  
					AND 	LEAVE_DATE = to_date('{1}','yyyy-mm-dd HH24:mi:ss')  
				*/
				#endregion
				try
				{
					strSql = string.Format(strSql,
					                       patientLeave.ID, //0住院流水号
					                       patientLeave.LeaveTime, //1请假日期
					                       patientLeave.LeaveDays.ToString(), //2请假天数
					                       patientLeave.DoctCode, //3给假医生
					                       Operator.ID, //4请假操作人
					                       patientLeave.Memo); //5备注
				}
				catch
				{
					Err = "传入参数错误！RADT.InPatient.UpdatePatientLeave!";
					WriteErr();
					return -1;
				}
			}
			return ExecNoQuery(strSql);
		}

		/// <summary>
		/// 保存请假信息－－先执行更新操作，如果没有找到可以更新的数据，则插入一条新记录
		/// </summary>
		/// <param name="patientLeave"></param>
		/// <param name="bed"></param>
		/// <returns>0未更新，大于1成功，-1失败</returns>
		public int SetPatientLeave(Leave patientLeave, Bed bed)
		{
			int parm;
			//执行更新操作
			parm = UpdatePatientLeave(patientLeave);

			//如果没有找到可以更新的数据，则插入一条新记录
			if (parm == 0)
			{
				parm = InsertPatientLeave(patientLeave, bed);
			}

			return parm;
		}


		/// <summary>
		/// 取消患者请假信息
		/// </summary>
		/// <param name="patientLeave"></param>
		/// <param name="bed"></param>
		/// <returns>0没有更新, 1成功, -1未成功</returns>
		public int DiscardPatientLeave(Leave patientLeave, Bed bed)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.CancelPatientLeave", ref strSql) == -1)
				#region SQL			
				/*  UPDATE 	MET_NUI_LEAVE   	--请假信息表
					SET 	LEAVE_FLAG   = '{2}',   --0请假 1消假,2作废
			   		CANCEL_OPCD  = '{3}',	--消假人(作废操作人)
			   		CANCEL_DATE  = sysdate	--消假时间(作废时间)
					WHERE 	PARENT_CODE  = '[父级编码]' 
					AND 	CURRENT_CODE = '[本级编码]'
					AND 	INPATIENT_NO = '{0}' 
					AND 	LEAVE_DATE = to_date('{1}','yyyy-mm-dd HH24:mi:ss') 
				*/
				#endregion
			{
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,
				                       patientLeave.ID, //住院流水号
				                       patientLeave.LeaveTime.ToString(), //请假日期
				                       patientLeave.LeaveFlag, //0请假 1消假,2作废
				                       Operator.ID); //消假(作废)操作人
			}
			catch
			{
				Err = "传入参数错误！RADT.InPatient.CancelPatientLeave!";
				WriteErr();
				return -1;
			}

			int parm = ExecNoQuery(strSql);
			if (parm != 1) return parm;

			//更改前的床位信息
			Bed newBed = bed.Clone();
			//更改后的床位信息:占用O
			newBed.Status.ID = EnumBedStatus.O.ToString();
			//更新床位状态
			return UpdateBedStatus(newBed, bed);
		}
        [Obsolete("更改为 DiscardPatientLeave",true)]
		public int CancelPatientLeave(Leave patientLeave, Bed bed)
        {
       	  return 0;
		}
		/// <summary>
		/// 通过住院流水检索患者请假信息
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <returns>患者请假信息</returns>
		public ArrayList QueryPatientLeaveInfo(string inpatientNO)
		{
			string strSql = string.Empty;
			ArrayList al = new ArrayList();

			//取select语句
			if (Sql.GetSql("RADT.InPatient.GetPatientLeave", ref strSql) == -1)
			{
				#region SQL
				/* 
				SELECT	INPATIENT_NO,                   --住院流水号
				LEAVE_DATE,                             --请假时间
				LEAVE_DAYS,                             --请假天数
				DOCT_CODE,                              --给假医生
				OPER_CODE,                              --请假操作人
				LEAVE_FLAG,                             --0请假 1消假,2作废
				REMARK,                                 --备注
				CANCEL_OPCD,                            --消假人(作废操作人)
				CANCEL_DATE                             --消假时间(作废时间)
				FROM 	MET_NUI_LEAVE 
				WHERE	PARENT_CODE  = '[父级编码]' 
				AND  	CURRENT_CODE = '[本级编码]' 
				AND 	INPATIENT_NO = '{0}' */
				#endregion
			}

			try
			{
				strSql = string.Format(strSql, inpatientNO);
			}
			catch
			{
				Err = "传入参数错误！GetPatientLeaveAll!";
				WriteErr();
				return null;
			}

			//执行SQL语句
			return QueryPatientLeave(strSql);
		}
		[System.Obsolete("更改为 QueryPatientLeaveInfo",true)]
		public ArrayList GetPatientLeaveAll(string InpatientNo)
		{
			return null;
		}

		/// <summary>
		/// 检索患者请假信息
		/// </summary>
		/// <param name="inpatientNo">住院流水号</param>
		/// <returns>住院患者一条有效的请假信息</returns>
		public ArrayList GetPatientLeaveAvailable(string inpatientNo)
		{
			string strSql = string.Empty;
			string strWhere = string.Empty;
			ArrayList al = new ArrayList();

			//取select语句
			if (Sql.GetSql("RADT.InPatient.GetPatientLeave", ref strSql) == -1)
				#region SQL
				/* 
				SELECT	INPATIENT_NO,                   --住院流水号
				LEAVE_DATE,                             --请假时间
				LEAVE_DAYS,                             --请假天数
				DOCT_CODE,                              --给假医生
				OPER_CODE,                              --请假操作人
				LEAVE_FLAG,                             --0请假 1消假,2作废
				REMARK,                                 --备注
				CANCEL_OPCD,                            --消假人(作废操作人)
				CANCEL_DATE                             --消假时间(作废时间)
				FROM 	MET_NUI_LEAVE 
				WHERE	PARENT_CODE  = '[父级编码]' 
				AND  	CURRENT_CODE = '[本级编码]' 
				AND 	INPATIENT_NO = '{0}' */
				#endregion
			{
				return null;
			}

			//取where语句
			if (Sql.GetSql("RADT.InPatient.GetPatientLeave.Available", ref strWhere) == -1)
				#region SQL
				/*	AND	LEAVE_FLAG <> '2' */
				#endregion
			{
				return null;
			}

			try
			{
				strSql = string.Format(strSql + " " + strWhere, inpatientNo);
			}
			catch
			{
				Err = "传入参数错误！GetPatientLeaveAvailable!";
				WriteErr();
				return null;
			}

			//执行SQL语句
			return QueryPatientLeave(strSql);
		}


		/// <summary>
		/// 取患者请假信息
		/// </summary>
		/// <param name="strSQL">取请假的SQL语句</param>
		/// <returns>请假信息数组</returns>
		private ArrayList QueryPatientLeave(string strSQL)
		{
			if (ExecQuery(strSQL) == -1)
			{
				return null;
			}
			ArrayList al = new ArrayList();
			try
			{
				Leave info; //请假实体	
				while (Reader.Read())
				{
					info = new Leave();
					info.ID = Reader[0].ToString(); //0住院流水号
					info.LeaveTime = NConvert.ToDateTime(Reader[1].ToString()); //1请假时间
					info.LeaveDays = NConvert.ToInt32(Reader[2].ToString()); //2请假天数
					info.DoctCode = Reader[3].ToString(); //3给假医生
					info.Oper.ID = Reader[4].ToString(); //4请假操作人
					info.LeaveFlag = Reader[5].ToString(); //5请假状态0请假 1消假,2作废
					info.Memo = Reader[6].ToString(); //6备注
					info.CancelOper.ID = Reader[7].ToString(); //7消假人(作废操作人)
					info.CancelOper.OperTime = NConvert.ToDateTime(Reader[8].ToString()); //8消假时间(作废时间)
					al.Add(info);
				}
				Reader.Close();
			} //抛出错误
			catch (Exception ex)
			{
				Err = "取患者请假信息出错！" + ex.Message;
				ErrCode = "-1";
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}

			return al;
		}

		#endregion

		#region 获得护理级别

		/// <summary>
		/// 获得护理级别
		/// </summary>
		/// <param name="inpatientNO">患者住院号</param>
		/// <returns></returns>
		public string GetTendName(string inpatientNO)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.GetTendName", ref strSql) == -1)
			{
				return "";
			}
			#region SQL
			/* SELECT tend                --护理级别(TEND):名称显示护理级别名称(一级护理，二级护理，三级护理)
				FROM fin_ipr_inmaininfo   --住院主表
				WHERE PARENT_CODE='[父级编码]'	and 	CURRENT_CODE='[本级编码]' and inpatient_no ='{0}'*/
			#endregion
			try
			{
				strSql = string.Format(strSql, inpatientNO);
			}
			catch
			{
				Err = "传入参数错误！RADT.InPatient.GetTendName";
				WriteErr();
				return string.Empty;
			}
			return ExecSqlReturnOne(strSql);
		}

		#endregion

		#region 获得饮食

		/// <summary>
		/// 获得患者饮食
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <returns>返回患者饮食名称</returns>
		public string GetFoodName(string inpatientNO)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.GetFoodName", ref strSql) == -1)
			{
				return string.Empty;
			}
	
			#region SQL
			/*SELECT DIETETIC_MARK
				FROM fin_ipr_inmaininfo   --住院主表
				WHERE PARENT_CODE='[父级编码]'	and CURRENT_CODE='[本级编码]' and inpatient_no ='{0}'
	        */
			#endregion
			
			try
			{
				strSql = string.Format(strSql, inpatientNO);
			}
			catch
			{
				Err = "传入参数错误！RADT.InPatient.GetFoodName";
				WriteErr();
				return string.Empty;
			}
			return ExecSqlReturnOne(strSql);
		}

		#endregion

		#region 更新饮食

		/// <summary>
		/// 更新饮食
		/// </summary>
		/// <param name="inpatientNO"></param>
		/// <param name="food"></param>
		/// <returns></returns>
		public int UpdatePatientFood(string inpatientNO, string food)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.SetFoodName", ref strSql) == -1) return -1;
			#region SQL
			/*UPDATE fin_ipr_inmaininfo   --住院主表
				SET DIETETIC_MARK='{1}'
				WHERE  PARENT_CODE='[父级编码]'	and 	CURRENT_CODE='[本级编码]' and inpatient_no ='{0}'*/
			#endregion
			try
			{
				strSql = string.Format(strSql, inpatientNO, food);
			}
			catch
			{
				Err = "传入参数错误！RADT.InPatient.SetFoodName";
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}
		[Obsolete("更改为 UpdatePatientFood",true)]
		public int SetFood(string inpatientNO, string food)
		{
			return 0;
		}
		#endregion

		#region 更新护理

		/// <summary>
		/// 更新住院患者护理级别
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <param name="tend">级别护理</param>
		/// <returns>大于 0 成功 小于 0 失败</returns>
		public int UpdatePatientTend(string inpatientNO, string tend)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.SetTend", ref strSql) == -1) return -1;
			#region SQL
			/* UPDATE fin_ipr_inmaininfo	 --住院主表
				SET tend='{1}'				 --护理级别(TEND):名称显示护理级别名称(一级护理，二级护理，三级护理)
				WHERE  PARENT_CODE='[父级编码]'	and 	CURRENT_CODE='[本级编码]' and inpatient_no ='{0}'
			*/
			#endregion
			try
			{
				strSql = string.Format(strSql, inpatientNO, tend);
			}
			catch
			{
				Err = "传入参数错误！RADT.InPatient.SetTend";
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}
		[Obsolete("更改为 UpdatePatientTend",true)]
		public int SetTend(string inpatientNO, string tend)
		{
			return 0;
		}
		#endregion

		#region 获取卡号

		/// <summary>
		/// 获取卡号
		/// </summary>
		/// <returns></returns>
		public string GetCardNOSequece()
		{
			string str = GetSequence("Exami.ChkPatient.GetCHKCardNoSequence");
			#region SQL
			/* SELECT SEQ_COM_CARDNO.NEXTVAL FROM DUAL */
			#endregion
			str = str.PadLeft(10, '0');
			return str;
		}
		[Obsolete("更改为 GetCardNOSequece",true)]
		public string GetCardNoSequence()
		{
			return null;
		}
		#endregion

		#region 查询功能

		#region 按住院流水号查询患者基本信息

		/// <summary>
		/// 患者查询-按住院号查
		/// </summary>
		/// <param name="inPatientNO">患者住院流水号</param>
		/// <returns>返回患者信息</returns>
		public PatientInfo GetPatientInfoByPatientNO(string inPatientNO)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;

			strSql1 = PatientQueryBasicSelect();
			
			if (strSql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.7", ref strSql2) == -1)
			{
				return null;
			}
			#region SQL
			/*	where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and Inpatient_no='{0}'*/
			#endregion
			try
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, inPatientNO);
			}
			catch
			{
				Err = "RADT.Inpatient.PatientQuery.Where.7赋值不匹配！";
				ErrCode = "RADT.Inpatient.PatientQuery.Where.7赋值不匹配！";
				return null;
			}
			ArrayList al = new ArrayList();
			PatientInfo PatientInfo = new PatientInfo();
			;
			try
			{
				al = myPatientBasicQuery(strSql1);
				if (al.Count == 0) return PatientInfo;
				PatientInfo = (PatientInfo) al[0];
			}
			catch (Exception ee)
			{
				string Error = ee.Message;
				return null;
			}
			return PatientInfo;
		}
		[Obsolete("更改为 GetPatientInfoByPatientNO",true)]
		public PatientInfo PatientQueryBasic(string inPatientNo)
		{
			return null;
		}
		#region 查询一定时间断内的所有出院结算患者

		/// <summary>
		/// 查询一定时间断内的所有出院结算患者
		/// </summary>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <param name="inState"></param>
		/// <returns></returns>
		public ArrayList QueryPatientInfoByTimeInState(DateTime dtBegin, DateTime dtEnd, string inState)
		{
			ArrayList al = new ArrayList();
			
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			
			sql1  = PatientQuerySelect();
			if (sql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.PatientQueryBalance", ref sql2) == -1)
			{
				#region SQL
				/*  where in_state = 'O'
					and parent_code = '[父级编码]'
					and current_code = '[本级编码]'
					and balance_date >= to_date('{0}','yyyy-mm-dd hh24:mi:ss')
					and balance_date <= to_date('{1}','yyyy-mm-dd hh24:mi:ss')
					and paykind_code = '{2}'
					and pact_code <> '4' 
				 */
				#endregion
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, dtBegin.ToString(), dtEnd.ToString(), inState);

			return myPatientQuery(sql1);
		}
		[Obsolete("更改为 QueryPatientInfoByTimeInState",true)]
		public ArrayList PatientQuery(DateTime dtBegin, DateTime dtEnd, string inState)
		{
			return null;
		}
		#endregion

		#endregion

		#region 按住院状态查询患者基本信息

		/// <summary>
		/// 患者查询-按住院状态查询患者基本信息
		/// </summary>
		/// <param name="inState">住院状态</param>
		/// <returns></returns>
		public ArrayList QueryPatientBasicByInState(InStateEnumService inState)
		{

			ArrayList al = new ArrayList();
			
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			
			sql1 = PatientQueryBasicSelect();
			if (sql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.9", ref sql2) == -1)
				#region SQL
				/*  where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and In_state='{0}'  */
				#endregion
			{
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, inState.ID.ToString());
			return myPatientBasicQuery(sql1);
		}
		
		[Obsolete("更改为 QueryPatientInfoByInState ",true)]
		public ArrayList PatientQueryBasic(InStateEnumService State)
		{
			return null;
		}

		#endregion

		#region 按住院流水号查询患者信息

        #region addby xuewj 2010-9-28 查询患者费用明细 {98057398-9233-4aec-8FAF-662A8E82BF74}
        //患者查询
        /// <summary>
        /// 患者查询-按住院号查
        /// </summary>
        /// <param name="inPatientNO"></param>
        /// <returns>患者信息 PatientInfo</returns>
        public PatientInfo LocalQueryPatientInfoByInpatientNO(string inPatientNO)
        {
            string strSql1 = string.Empty;
            string strSql2 = string.Empty;

            #region 接口说明

            /////RADT.Inpatient.PatientQuery.where.7
            //传入:住院流水号
            //传出：患者信息

            #endregion

            strSql1 = PatientQuerySelect();
            if (strSql1 == null) return null;

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.7", ref strSql2) == -1)
            {
                return null;
            }
            try
            {
                strSql1 = strSql1 + " " + string.Format(strSql2, inPatientNO);
            }
            catch
            {
                Err = "RADT.Inpatient.PatientQuery.Where.7赋值不匹配！";
                ErrCode = "RADT.Inpatient.PatientQuery.Where.7赋值不匹配！";
                return null;
            }
            ArrayList al = new ArrayList();
            PatientInfo PatientInfo;
            try
            {
                al = myPatientQuery(strSql1);
                PatientInfo = (PatientInfo)al[0];
            }
            catch (Exception ee)
            {
                Err = "没有找到患者信息!" + ee.Message;
                WriteErr();
                return null;
            }
            return PatientInfo;
        } 
        #endregion

		//患者查询
		/// <summary>
		/// 患者查询-按住院号查
		/// </summary>
		/// <param name="inPatientNO"></param>
		/// <returns>患者信息 PatientInfo</returns>
		public PatientInfo QueryPatientInfoByInpatientNO(string inPatientNO)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;

			#region 接口说明

			/////RADT.Inpatient.PatientQuery.where.7
			//传入:住院流水号
			//传出：患者信息

			#endregion

			strSql1 = PatientQuerySelect();
			if (strSql1 == null) return null;

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.7", ref strSql2) == -1)
			{
				return null;
			}
			try
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, inPatientNO);
			}
			catch
			{
				Err = "RADT.Inpatient.PatientQuery.Where.7赋值不匹配！";
				ErrCode = "RADT.Inpatient.PatientQuery.Where.7赋值不匹配！";
				return null;
			}
			ArrayList al = new ArrayList();
			PatientInfo PatientInfo;
			try
			{
				al = myPatientQuery(strSql1);
				PatientInfo = (PatientInfo) al[0];
			}
			catch (Exception ee)
			{
				Err = "没有找到患者信息!" + ee.Message;
				WriteErr();
				return null;
			}
			return PatientInfo;
		}
		[Obsolete("更改为 QueryPatientInfoByInpatientNO",true)]
		public PatientInfo PatientQuery(string inPatientNO)
		{
			return null;
		}
		#endregion

		#region 按床位号得到病人信息

		/// <summary>
		/// 获得住院流水号从病床号
		/// </summary>
		/// <param name="BedNo">床号</param>
		/// <returns>在院患者信息</returns>
		public ArrayList QueryInpatientNOByBedNO(string BedNo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.QeryInpatientNoFromPatientNo.2", ref strSql) == 0)
			{
				#region SQL
				/*
				 select inpatient_no,name,in_state,DEPT_CODE,dept_name,in_date from fin_ipr_inmaininfo 
				 where  PARENT_CODE='[父级编码]'	and	CURRENT_CODE='[本级编码]' and  bed_no='{0}' and in_state ='I'
				 */
				#endregion
				try
				{
					strSql = string.Format(strSql, BedNo);
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					return null;
				}
				return GetPatientInfoBySQL(strSql);
			}
			else
			{
				return null;
			}
		}
		[Obsolete("更改为 QueryInpatientNOByBedNO",true)]
		public ArrayList QueryInpatientNoFromBedNo(string BedNo)
		{
			return null;
		}
		#endregion

		#region 按合同单位,科室,在院状态查询患者信息

		/// <summary>
		/// 根据过滤条件得到患者住院流水号
		/// </summary>
		/// <param name="pactCode">合同单位编码</param>
		/// <param name="deptCode">部门编码</param>
		/// <param name="status">患者状态</param>
		/// <param name="beginDate">开始日期</param>
		/// <param name="endDate">结束日期</param>
        /// <returns>符合条件的患者信息列表（住院号，姓名）</returns>
        [Obsolete("过期", true)]
        public ArrayList QueryPatienByConditons(string pactCode, string deptCode, string status, DateTime beginDate,
		                                         DateTime endDate)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.QueryPatientByConditons.Select.1", ref strSql) == -1)
				#region SQL
				/*
				    select inpatient_no,name
					from fin_ipr_inmaininfo
					where 
					pact_code like '{0}'
					and dept_code like '{1}'
					and in_state like '{2}'
					and in_date >= trunc(to_date('{3}','yyyy-mm-dd hh24:mi:ss'))
					and in_date <= to_date('{4}','yyyy-mm-dd hh24:mi:ss')
				*/
				#endregion
			{
				return null;
			}
			try
			{
				strSql = string.Format(strSql, pactCode, deptCode, status, beginDate, endDate);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = "-1";
				WriteErr();
				return null;
			}
			try
			{
				ArrayList al = new ArrayList();
				ExecQuery(strSql);
				while (Reader.Read())
				{
					NeuObject obj = new NeuObject();
					obj.ID = Reader[0].ToString();
					obj.Name = Reader[1].ToString();

					al.Add(obj);
				}

				Reader.Close();

				return al;
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = "-1";
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
		}

		#endregion

		#region 按合同单位,科室,在院状态查询患者详细信息列表

		/// <summary>
		/// 根据过滤条件得到患者住院详细信息--Edit By Maokb
		/// </summary>
		/// <param name="pactCode"></param>
		/// <param name="deptCode"></param>
		/// <param name="status"></param>
		/// <param name="beginDate"></param>
		/// <param name="endDate"></param>
		/// <returns></returns>
        public ArrayList QueryPatientByConditons(string pactCode, string deptCode, string status, DateTime beginDate,
		                                      DateTime endDate)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;
			ArrayList al = new ArrayList();

			strSql1 = PatientQuerySelect();
			if (strSql1 == null) return null;

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.12", ref strSql2) == -1)
			{
				return null;
			}
			try
				#region SQL
				/*
				 * where PARENT_CODE='[父级编码]' 
				 * and CURRENT_CODE='[本级编码]' 
				 * and NURSE_CELL_CODE like '{0}' 
				 * and  pact_code like '{1}'
				 * and (TRUNC(in_date) >=to_date('{2}','yyyy-mm-dd HH24:mi:ss')) 
				 * and (TRUNC(in_date) <=to_date('{3}','yyyy-mm-dd HH24:mi:ss')) 
				 * and In_state like '{4}'
				 */
				#endregion
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, deptCode, pactCode, beginDate, endDate, status);
			}
			catch
			{
				Err = "RADT.Inpatient.PatientQuery.Where.12赋值不匹配！";
				ErrCode = "RADT.Inpatient.PatientQuery.Where.12赋值不匹配！";
				return null;
			}

			return myPatientQuery(strSql1);
		}

		#endregion

		#region 按住院流水号查询患者接诊信息

		/// <summary>
		/// 查询患者接诊信息
		/// </summary>
		/// <param name="inPatientNO">住院流水号</param>
		/// <returns>返回接诊病人信息</returns>
		public ArrayList QueryPatientReceiveInfo(string inPatientNO)
		{
			string sql = string.Empty;
			ArrayList al = new ArrayList();

			if (Sql.GetSql("RADT.Inpatient.GetPatientReceiveInfo.1", ref sql) == -1)
				#region SQL
				/*SELECT happen_no,   --发生序号
					   nurse_cell_code,   --护理单元代码
					   nurse_cell_name,   --护理单元名称
					   house_doc_code,   --医师代码(住院)
					   house_doc_name,   --医师姓名(住院)
					   charge_doc_code,   --医师代码(主治)
					   charge_doc_name,   --医师姓名(主治)
					   chief_doc_code,   --医师代码(主任)
					   chief_doc_name,   --医师姓名(主任)
					   duty_nurse_code,   --护士代码(责任)
					   duty_nurse_name,   --护士姓名(责任)
					   practice_doc_code,   --实习医师
					   practice_doc_name,   --实习医师姓名
					   noviciate_doc_code,   --进修医师
					   noviciate_doc_name,   --进修医师姓名
					   convoy_nrs_code,   --护送护士
					   convoy_nrs_name,   --护送护士姓名
					   convoy_tool_code,   --护送工具
					   convoy_tool_name,   --护送工具名称
					   director_code,   --科主任代码
					   director_name,   --科主任姓名
					   oper_code,   --操作员
					   oper_date    --操作日期
				  FROM fin_ipr_receiveinfo   --接诊信息表
				 where PARENT_CODE='[父级编码]' and 
					   CURRENT_CODE='[本级编码]' and  
					   inpatient_no='{0}' and cancel_flag='0'
					   */
				#endregion
			{
				return null;
			}
			sql = string.Format(sql, inPatientNO);
			if (ExecQuery(sql) < 0)
			{
				return null;
			}

			try
			{
				while (Reader.Read())
				{
					PatientInfo PatientInfo = new PatientInfo();

					PatientInfo.ID = inPatientNO;
					try
					{
						if (!Reader.IsDBNull(0)) PatientInfo.Memo = Reader[0].ToString(); //发生序号
						if (!Reader.IsDBNull(1)) PatientInfo.PVisit.PatientLocation.NurseCell.ID = Reader[1].ToString(); //护理单元代码
						if (!Reader.IsDBNull(2)) PatientInfo.PVisit.PatientLocation.NurseCell.Name = Reader[2].ToString(); //护理单元名称
						if (!Reader.IsDBNull(3)) PatientInfo.PVisit.AdmittingDoctor.ID = Reader[3].ToString(); //医师代码(住院)
						if (!Reader.IsDBNull(4)) PatientInfo.PVisit.AdmittingDoctor.Name = Reader[4].ToString(); //医师姓名(住院)
						if (!Reader.IsDBNull(5)) PatientInfo.PVisit.AttendingDoctor.ID = Reader[5].ToString(); //医师代码(主治)
						if (!Reader.IsDBNull(6)) PatientInfo.PVisit.AttendingDoctor.Name = Reader[6].ToString(); //医师姓名(主治)
						if (!Reader.IsDBNull(7)) PatientInfo.PVisit.ConsultingDoctor.ID = Reader[7].ToString(); //医师代码(主任)
						if (!Reader.IsDBNull(8)) PatientInfo.PVisit.ConsultingDoctor.Name = Reader[8].ToString(); //医师姓名(主任)
						if (!Reader.IsDBNull(9)) PatientInfo.PVisit.AdmittingNurse.ID = Reader[9].ToString(); //护士代码(责任)
						if (!Reader.IsDBNull(10)) PatientInfo.PVisit.AdmittingNurse.Name = Reader[10].ToString(); //护士姓名(责任)
						if (!Reader.IsDBNull(11)) PatientInfo.PVisit.TempDoctor.ID = Reader[11].ToString(); //实习医师
						if (!Reader.IsDBNull(12)) PatientInfo.PVisit.TempDoctor.Name = Reader[12].ToString(); //实习医师姓名
						if (!Reader.IsDBNull(13)) PatientInfo.PVisit.ReferringDoctor.ID = Reader[13].ToString(); //进修医师
						if (!Reader.IsDBNull(14)) PatientInfo.PVisit.ReferringDoctor.Name = Reader[14].ToString(); //进修医师姓名
						//						if(!this.Reader.IsDBNull(15)) PatientInfo=this.Reader[15].ToString();//护送护士
						//						if(!this.Reader.IsDBNull(16)) PatientInfo=this.Reader[17].ToString();//护送护士姓名
						//						if(!this.Reader.IsDBNull(18)) PatientInfo=this.Reader[18].ToString();//护送工具
						//						if(!this.Reader.IsDBNull(19)) PatientInfo=this.Reader[19].ToString();//护送工具名称
						//						if(!this.Reader.IsDBNull(20)) PatientInfo=this.Reader[20].ToString();//科主任代码		
						//						if(!this.Reader.IsDBNull(21)) PatientInfo=this.Reader[21].ToString();//科主任姓名
						if (!Reader.IsDBNull(22)) PatientInfo.User01 = Reader[22].ToString(); //操作员
						if (!Reader.IsDBNull(23)) PatientInfo.User02 = Reader[23].ToString(); //操作日期
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						WriteErr();
					}
					al.Add(PatientInfo);
				}
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
			Reader.Close();

			return al;
		}
		[Obsolete("更改为 QueryPatientReceiveInfo",true)]
		public ArrayList GetPatientReceiveInfo(string InPatientNo)
		{
			return null;
		}
		#endregion

		#region 按住院流水号查询患者特殊床位占用状态

		/// <summary>
		/// 查询患者特殊床位占用信息（包床、挂床）
		/// </summary>
		/// <param name="InPatientNo"></param>
		/// <returns></returns>
		public ArrayList GetSpecialBedInfo(string InPatientNo)
		{
			string sql = string.Empty;
			ArrayList al = new ArrayList();

			if (Sql.GetSql("RADT.Inpatient.GetSpecialBedInfo.1", ref sql) == -1)
				#region SQL
				/*
				  SELECT bed_no,                    --床号
				         bed_kind                   --1 挂床 2 包床 
				         FROM fin_ipr_hangbedinfo   --挂床信息表
				   where PARENT_CODE='[父级编码]' and 
							CURRENT_CODE='[本级编码]' and 
							inpatient_no='{0}'  and
							status = '0'            --挂床
				*/
				#endregion
			{
				return null;
			}
			sql = string.Format(sql, InPatientNo);
			if (ExecQuery(sql) < 0) return null;

			#region "read"

			try
			{
				while (Reader.Read())
				{
					Bed obj = new Bed();

					try
					{
						obj.ID = Reader[0].ToString();
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						WriteErr();
					}
					try
					{
						obj.Memo = Reader[1].ToString();
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						WriteErr();
					}
					al.Add(obj);
				}
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
			Reader.Close();

			#endregion

			return al;
		}

		#endregion

		#region 按医疗证号和电脑号查询患者信息

		/// <summary>
		/// 按医疗证号和电脑号查询
		/// </summary>
		/// <param name="strPcNo">保险号</param>
		/// <param name="strMcardNo">医疗证号</param>
		/// <returns></returns>
		//		public PatientInfo PatientQueryByPcNo(string strPcNo,string strMcardNo)
		//		{
		//			string strSql1=string.Empty,strSql2=string.Empty,strSql3 = string.Empty,strSqlWhere = string.Empty;
		//					
		//			strSql1 = PatientQuerySelect();
		//			if (strSql1==null ) return null;
		//			
		//			if(this.Sql.GetSql("FT.FeeReport.Where",ref strSqlWhere)==-1)return null;
		//			strSql1 = strSql1+" "+ strSqlWhere;
		//			if(strPcNo!=string.Empty)
		//			{
		//				if(this.Sql.GetSql("FT.FeeReport.Where1",ref strSql2)==-1)return null;//电脑号
		//				try
		//				{
		//					strSql1=strSql1+" "+string.Format(strSql2,strPcNo);
		//				}
		//				catch
		//				{
		//					this.Err="赋值不匹配！";
		//					this.ErrCode="赋值不匹配！";
		//					return null;
		//				}
		//			}
		//			if(strMcardNo!=string.Empty)
		//			{
		//				if(this.Sql.GetSql("FT.FeeReport.Where2",ref strSql3)==-1)return null;//医疗证号
		//				try
		//				{
		//					strSql1 = strSql1+" "+string.Format(strSql3,strMcardNo);
		//				}
		//				catch
		//				{
		//					this.Err="赋值不匹配！";
		//					this.ErrCode="赋值不匹配！";
		//					return null;
		//				}
		//			}
		//			ArrayList al=new ArrayList();
		//			Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo;
		//			try
		//			{
		//				al=this.myPatientQuery(strSql1);
		//				PatientInfo=(Neusoft.HISFC.Models.RADT.PatientInfo)al[0];
		//			}
		//			catch(Exception ee)
		//			{
		//				string Error = ee.Message;
		//				return null;
		//			}
		//			return PatientInfo;
		//						
		//		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strPcNo"></param>
		/// <param name="strMcardNo"></param>
		/// <returns></returns>
		public ArrayList PatientQueryByPcNoRetArray(string strPcNo, string strMcardNo)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;
			string strSql3 = string.Empty;
			string strSqlWhere = string.Empty;

			ArrayList al = new ArrayList();
			strSql1 = PatientQuerySelect();
			if (strSql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("FT.FeeReport.Where", ref strSqlWhere) == -1)
			{
				return null;
			}
			strSql1 = strSql1 + " " + strSqlWhere;
			if (strPcNo != string.Empty)
			{
				if (Sql.GetSql("FT.FeeReport.Where1", ref strSql2) == -1)
				{
					return null;
				} //电脑号
				try
				{
					strSql1 = strSql1 + " " + string.Format(strSql2, strPcNo);
				}
				catch
				{
					Err = "赋值不匹配！";
					ErrCode = "赋值不匹配！";
					WriteErr();
					return null;
				}
				try
				{
					al = myPatientQuery(strSql1);
				}
				catch (Exception ee)
				{
					Err = ee.Message;
					WriteErr();
					return null;
				}
			}
			else
			{
			}
			if (strMcardNo != string.Empty)
			{
				if (Sql.GetSql("FT.FeeReport.Where2", ref strSql3) == -1)
				{
					return null;
				} //医疗证号
				try
				{
					strSql1 = strSql1 + " " + string.Format(strSql3, strMcardNo);
				}
				catch
				{
					Err = "赋值不匹配！";
					ErrCode = "赋值不匹配！";
					al = null;
				}
				try
				{
					al = myPatientQuery(strSql1);
				}
				catch (Exception ee)
				{
					string Error = ee.Message;
					return null;
				}
			}
			else
			{
			}

			return al;
		}

		#endregion

		#region 查询患者申请转科的目标科室

		/// <summary>
		///  查询患者申请转科的目标科室
		/// </summary>
		/// <param name="inpatientNO">住院流水号</param>
		/// <param name="oldLocationID"></param>
		/// <returns></returns>
		public Location QueryShiftNewLocation(string inpatientNO, string oldLocationID)
		{
			#region 接口说明

			//RADT.Inpatient.QueryShiftNewLocation.1
			//传入：0 住院流水号 1原部门ID
			//传出：新目标部门信息

			#endregion

			string sql = string.Empty;
			Location newLocation = new Location();
			if (sql == null)
			{
				return null;
			}
			
			if (Sql.GetSql("RADT.Inpatient.QueryShiftNewLocation.1", ref sql) == -1)
			{
				return null;
			}
			
			try
				#region SQL
				/*SELECT       new_dept_code,         --转往科室
							   new_nurse_cell_code,   --转往护理站代码
							   confirm_opercode,      --确认人
							   confirm_date,          --转科确认时间
							   cancel_code,           --取消人
							   cancel_date,           --取消申请时间
							   mark,                  --备注
						       SHIFT_STATE --申请状态
						FROM fin_ipr_shiftapply   --转科申请表
						where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and 
							  inpatient_no = '{0}' and old_dept_code= '{1}' and shift_state in('1','0')
				*/
				#endregion
			{
				sql = string.Format(sql, inpatientNO, oldLocationID);
			}
			catch (Exception ex)
			{
				Err = "RADT.Inpatient.QueryShiftNewLocation.1的参数错误！" + ex.Message;
				WriteErr();
				return null;
			}
			if (ExecQuery(sql) == -1)
			{
				return null;
			} 
			if (Reader.Read())
			{
				newLocation.Dept.ID = Reader[0].ToString();
				try
				{
					newLocation.NurseCell.ID = Reader[1].ToString();
				}
				catch
				{
				}
				newLocation.Memo = Reader[6].ToString();
				newLocation.User03 = Reader[7].ToString();
			}
			Reader.Close();
			return newLocation;
		}

		#endregion

		#region 按病区和状态查询患者基本信息列表

		/// <summary>
		/// 患者查询-查询病区不同状态的患者
		/// </summary>
        /// <param name="nurseCode">病区编码</param>
		/// <param name="State">住院状态</param>
		/// <returns></returns>
        public ArrayList QueryPatientBasicByNurseCell(string nurseCode, InStateEnumService State)
		{
			#region 接口说明

			//RADT.Inpatient.PatientQuery.where.5
			//传入：病区编码，住院状态
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			sql1 = PatientQueryBasicSelect();
			if (sql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.5", ref sql2) == -1)
				#region SQL
				/* WHERE PARENT_CODE='[父级编码]' AND CURRENT_CODE='[本级编码]' AND NURSE_CELL_CODE ='{0}' AND IN_STATE = '{1}' ORDER BY BED_NO */
				#endregion
			{
				Err = "没有找到RADT.Inpatient.PatientQuery.Where.5字段!";
				ErrCode = "-1";
				return null;
			}
            sql1 = sql1 + " " + string.Format(sql2, nurseCode, State.ID.ToString());
			return myPatientBasicQuery(sql1);
		}

		#endregion

		#region 按病区和状态查询患者信息列表

		/// <summary>
		/// 患者查询-查询病区不同状态的患者
		/// </summary>
        /// <param name="nurseCode">病区编码</param>
		/// <param name="State">住院状态</param>
		/// <returns></returns>
		public ArrayList PatientQueryByNurseCell(string nurseCode,Neusoft.HISFC.Models.Base.EnumInState State)
		{
			#region 接口说明

			//RADT.Inpatient.PatientQuery.where.5
			//传入：病区编码，住院状态
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.5", ref sql2) == -1)
			{
				Err = "没有找到RADT.Inpatient.PatientQuery.Where.5字段!";
				ErrCode = "-1";
				WriteErr();
				return null;
			}
            sql1 = sql1 + " " + string.Format(sql2, nurseCode, State.ToString());
			return myPatientQuery(sql1);
		}
        //{62EAD92D-49F6-45d5-B378-1E573EC27728}
        /// <summary>
        /// 患者查询-查询病区不同状态的患者(欠费)
        /// </summary>
        /// <param name="nurseCode">病区编码</param>
        /// <param name="State">住院状态</param>
        /// <returns></returns>
        public ArrayList PatientQueryByNurseCellForAlert(string nurseCode, Neusoft.HISFC.Models.Base.EnumInState State)
        {
            #region 接口说明

            //RADT.Inpatient.PatientQuery.where.5
            //传入：病区编码，住院状态
            //传出：患者信息

            #endregion

            ArrayList al = new ArrayList();
            string sql1 = string.Empty, sql2 = string.Empty;
            sql1 = PatientQuerySelect();
            if (sql1 == null)
            {
                return null;
            }

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.19", ref sql2) == -1)
            {
                Err = "没有找到RADT.Inpatient.PatientQuery.Where.19字段!";
                ErrCode = "-1";
                WriteErr();
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, nurseCode, State.ToString());
            return myPatientQuery(sql1);
        }
        /// <summary>
        /// 患者查询-按病区和科室查询不同状态的患者
        /// </summary>
        /// <param name="nurseCode"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public ArrayList PatientQueryByNurseCellAndDept(string nurseCode,string deptCode, Neusoft.HISFC.Models.Base.EnumInState State)
        {
            #region 接口说明

            //RADT.Inpatient.PatientQuery.where.5
            //传入：病区编码，科室,住院状态
            //传出：患者信息

            #endregion

            ArrayList al = new ArrayList();
            string sql1 = string.Empty, sql2 = string.Empty;
            sql1 = PatientQuerySelect();
            if (sql1 == null)
            {
                return null;
            }

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.16", ref sql2) == -1)
            {
                Err = "没有找到RADT.Inpatient.PatientQuery.Where.16字段!";
                ErrCode = "-1";
                WriteErr();
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, nurseCode, deptCode, State.ToString());
            return myPatientQuery(sql1);
        }
        //
        /// <summary>
        /// 患者查询-按病区和科室查询不同状态的患者(欠费){62EAD92D-49F6-45d5-B378-1E573EC27728}
        /// </summary>
        /// <param name="nurseCode"></param>
        /// <param name="State"></param>
        /// <returns></returns>
        public ArrayList PatientQueryByNurseCellAndDeptForAlert(string nurseCode, string deptCode, Neusoft.HISFC.Models.Base.EnumInState State)
        {
            #region 接口说明

            //RADT.Inpatient.PatientQuery.where.5
            //传入：病区编码，科室,住院状态
            //传出：患者信息

            #endregion

            ArrayList al = new ArrayList();
            string sql1 = string.Empty, sql2 = string.Empty;
            sql1 = PatientQuerySelect();
            if (sql1 == null)
            {
                return null;
            }

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.17", ref sql2) == -1)
            {
                Err = "没有找到RADT.Inpatient.PatientQuery.Where.17字段!";
                ErrCode = "-1";
                WriteErr();
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, nurseCode, deptCode, State.ToString());
            return myPatientQuery(sql1);
        }
		/// <summary>
		/// 患者查询-查询病区不同状态的患者(不包括婴儿)
		/// </summary>
        /// <param name="nurseCode">病区编码</param>
		/// <param name="State">住院状态</param>
		/// <returns></returns>
        public ArrayList PatientQueryExceptBaby(string nurseCode, Neusoft.HISFC.Models.Base.EnumInState State)
		{
			#region 接口说明

			//RADT.Inpatient.PatientQuery.where.5
			//传入：病区编码，住院状态
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.ExceptBaby", ref sql2) == -1)
			{
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2,nurseCode,State.ToString());
			return myPatientQuery(sql1);
		}

		#endregion

        #region 根据出院召回的有效天数获得出院患者的信息

        /// <summary>
        /// 根据有效出院召回的有效天数查询出院登记患者信息
        /// ----Create By ZhangQi
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="inState"></param>
        /// <param name="vaildDays"></param> 
        /// <returns></returns>
        public ArrayList PatientQueryByVaildDate(string deptCode, Neusoft.HISFC.Models.RADT.InStateEnumService inState, int vaildDays)
        {
            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();
            Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo;
            al = this.PatientQuery(deptCode, inState);
            for (int i = 0; i < al.Count; i++)
            {
                PatientInfo = al[i] as Neusoft.HISFC.Models.RADT.PatientInfo;
                DateTime dt = PatientInfo.PVisit.OutTime;
                DateTime ds = dt.AddDays(vaildDays);
                ds = ds.Date;
                ds = ds.AddHours(23);
                ds = ds.AddMinutes(59);
                ds = ds.AddSeconds(59);
                DateTime sysdate = GetDateTimeFromSysDateTime();
                if (ds > sysdate)
                    al2.Add(PatientInfo);
            }
            return al2;
        }

        /// <summary>
        /// 根据有效出院召回的有效天数查询出院登记患者信息
        /// ----Create By Sunm
        /// {9A2D53D3-25BE-4630-A547-A121C71FB1C5}
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="inState"></param>
        /// <param name="vaildDays"></param> 
        /// <returns></returns>
        public ArrayList PatientQueryByNurseCellVaildDate(string deptCode, Neusoft.HISFC.Models.Base.EnumInState inState, int vaildDays)
        {
            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();
            Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo;
            al = this.PatientQueryByNurseCell(deptCode, inState);
            for (int i = 0; i < al.Count; i++)
            {
                PatientInfo = al[i] as Neusoft.HISFC.Models.RADT.PatientInfo;
                DateTime dt = PatientInfo.PVisit.OutTime;
                DateTime ds = dt.AddDays(vaildDays);
                ds = ds.Date;
                ds = ds.AddHours(23);
                ds = ds.AddMinutes(59);
                ds = ds.AddSeconds(59);
                DateTime sysdate = GetDateTimeFromSysDateTime();
                if (ds > sysdate)
                    al2.Add(PatientInfo);
            }
            return al2;
        }


        #endregion

        #region 根据有效召回期查询一段时间内某个科室在有效召回期的出院登记患者(起止时间  科室代码 有效天数)

        /// <summary>
        /// 根据有效召回期查询一段时间内某个科室的出院登记患者(起止时间  科室代码 有效天数)
        /// ----Create By ZhangQi
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="beginTime"></param>
        ///  <param name="endTime"></param>
        /// <param name="vaildDays"></param> 
        ///  <param name="myPatientState"></param>
        /// <returns></returns>
        public ArrayList OutHosPatientByState(string deptCode, string beginTime, string endTime, int vaildDays, int myPatientState)
        {
            #region 接口说明

            //RADT.Inpatient.PatientQuery.Where.OutHos
            //传入：科室编码，时间范围, 有效天数
            //传出：患者信息
            #endregion
            Neusoft.HISFC.Models.Base.EnumInState inState = new EnumInState();
            inState = EnumInState.B;
            Neusoft.HISFC.Models.RADT.InStateEnumService istate = new Neusoft.HISFC.Models.RADT.InStateEnumService();
            istate.ID = inState;

            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();
            Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo;
            al = this.PatientQuery(deptCode, istate);

            for (int i = 0; i < al.Count; i++)
            {
                PatientInfo = al[i] as Neusoft.HISFC.Models.RADT.PatientInfo;
                DateTime dt = PatientInfo.PVisit.OutTime;
                DateTime ds = dt.AddDays(vaildDays);
                ds = ds.Date;
                ds = ds.AddHours(23);
                ds = ds.AddMinutes(59);
                ds = ds.AddSeconds(59);
                DateTime sysdate = GetDateTimeFromSysDateTime();

                if (PatientInfo.PVisit.OutTime >= Convert.ToDateTime(beginTime)
                    && (PatientInfo.PVisit.OutTime <= Convert.ToDateTime(endTime)))
                {
                    if ((myPatientState == 0) && (ds > sysdate))
                    {
                        al2.Add(PatientInfo);
                    }
                    else if ((myPatientState == 1) && (ds <= sysdate))
                    {
                        al2.Add(PatientInfo);
                    }
                    else
                    {
                    }
                }
            }
            return al2;
        }



        #endregion

		#region 按科室和状态查询患者基本信息列表

		/// <summary>
		/// 患者查询-查询科室不同状态的患者
		/// </summary>
		/// <param name="dept_code">科室编码</param>
		/// <param name="State">住院状态</param>
		/// <returns></returns>
        public ArrayList QueryPatientBasic(string dept_code, InStateEnumService State)
		{
			#region 接口说明

			//RADT.Inpatient.PatientQuery.where.6
			//传入：科室编码，住院状态
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQueryBasicSelect();
			if (sql1 == null) return null;

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.6", ref sql2) == -1)
			{
				return null;
			}
			sql2 = " " + string.Format(sql2, dept_code, State.ID.ToString());
			return myPatientBasicQuery(sql1 + sql2);
		}

		#endregion

		#region 按科室和状态查询患者信息列表

		/// <summary>
		/// 患者查询-查询科室不同状态的患者
		/// </summary>
		/// <param name="dept_code">科室编码</param>
		/// <param name="State">住院状态</param>
		/// <returns></returns>
		public ArrayList PatientQuery(string dept_code, InStateEnumService State)
		{
			#region 接口说明

			//RADT.Inpatient.PatientQuery.where.6
			//传入：科室编码，住院状态
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null) return null;

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.6", ref sql2) == -1)
			{
				return null;
			}
			sql2 = " " + string.Format(sql2, dept_code, State.ID.ToString());
			return myPatientQuery(sql1 + sql2);
		}

		#endregion

        #region 按科室和状态查询患者信息列表

        /// <summary>
        /// 患者查询-查询医疗组不同状态的患者//{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        /// </summary>
        /// <param name="medicalTeamCode">科室编码</param>
        /// <param name="State">住院状态</param>
        /// <returns></returns>
        public ArrayList PatientQueryByMedicalTeam(string medicalTeamCode, InStateEnumService State,string deptCode)
        {
            #region 接口说明

            //RADT.Inpatient.PatientQuery.where.6
            //传入：科室编码，住院状态
            //传出：患者信息

            #endregion

            ArrayList al = new ArrayList();
            string sql1 = string.Empty, sql2 = string.Empty;
            sql1 = PatientQuerySelect();
            if (sql1 == null) return null;

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.98", ref sql2) == -1)
            {
                return null;
            }
            sql2 = " " + string.Format(sql2, medicalTeamCode, State.ID.ToString(), deptCode);
            return myPatientQuery(sql1 + sql2);
        }

        #endregion

		#region  按结算类别和住院时间和在院状态查询患者信列表

		#endregion

        #region 按照科室和时间段查询无费退院患者信息 
        /// <summary>
        /// 按照科室和时间段查询无费退院患者信息 --Create by ZhangQi
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ArrayList PatientNoFeeQuery(string deptCode, string beginTime, string endTime)
        {
            string sql = string.Empty;
            if (Sql.GetSql("Local.Report.Patient.NoFee.Query", ref sql) == -1)
            {
                return null;
            }
            sql = " " + string.Format(sql,deptCode, beginTime, endTime);
            return myPatientNoFeeQuery(sql);
        }

        #endregion

        #region 按照科室 时间段 和医生代码查询出院患者情况
        /// <summary>
        /// 按照科室 时间段 和医生代码查询出院患者情况 --Create By ZhangQi
        /// </summary>
        /// <param name="inState"></param>
        /// <param name="deptCode"></param>
        /// <param name="docCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ArrayList PatientOutHosQuery(string inState, string deptCode, string docCode, string beginTime, string endTime)
        {
            //inState.ID
            string sql=string.Empty;
            if (Sql.GetSql("Local.Report.Patient.OutHos.Query", ref sql) == -1)
            {
                return null;
            }
            sql = " " + string.Format(sql,inState, deptCode, docCode, beginTime, endTime);
            return myPatientOutHosQuery(sql);
        }
        #endregion

        #region 按照科室 时间段和主要诊断查询出院患者的诊断情况
        /// <summary>
        /// 按照科室 时间段和主要诊断查询出院患者的诊断情况--Create By ZhangQi
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="diagnoreName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ArrayList PatientDiagnoreQuery(string deptCode, string diagnoreName, string beginTime, string endTime)
        {
            string sql=string.Empty;
            if (Sql.GetSql("Local.Report.Patient.Diagnore.Query", ref sql) == -1)
            {
                return null;
            }
            sql = " " + string.Format(sql,deptCode, diagnoreName, beginTime, endTime);
            return myPatientDiagnoreQuery(sql);
        }
        #endregion

        #region 诊断查询
        /// <summary>
        /// 诊断查询 ---Create By ZhangQi
        /// </summary>
        /// <param name="SQLPatient"></param>
        /// <returns></returns>
        private ArrayList myPatientDiagnoreQuery(string SQLPatient)
        {
            ArrayList al = new ArrayList();
            PatientInfo PatientInfo;
            ProgressBarText = "正在查询患者...";
            ProgressBarValue = 0;

            if (ExecQuery(SQLPatient) == -1)
            {
                return null;
            }
            //取系统时间,用来得到年龄字符串
            DateTime sysDate = GetDateTimeFromSysDateTime();

            try
            {
                while (Reader.Read())
                {
                    PatientInfo = new PatientInfo();
                    try
                    {
                        if (!Reader.IsDBNull(0)) PatientInfo.PID.PatientNO= Reader[0].ToString(); // 住院流水号
                        if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); // 姓名
                        if (!Reader.IsDBNull(2)) PatientInfo.Sex.ID = Reader[2].ToString();//性别
                        if (!Reader.IsDBNull(3)) PatientInfo.Age = Reader[3].ToString();//年龄
                        if (!Reader.IsDBNull(4)) PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[4].ToString();//科室
                        if (!Reader.IsDBNull(5)) PatientInfo.PVisit.InTime =Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5]);//入院日期
                        if (!Reader.IsDBNull(6)) PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[6]);//出院日期
                        if (!Reader.IsDBNull(7)) PatientInfo.MainDiagnose = Reader[7].ToString();//主要诊断
                    }
                    catch (Exception ex)
                    {
                        Err = ex.Message;
                        WriteErr();
                        if (!Reader.IsClosed)
                        {
                            Reader.Close();
                        }
                        return null;
                    }
                    ProgressBarValue++;
					al.Add(PatientInfo);
				}
            }
            catch (Exception ex)
            {
                Err = "获得患者基本信息出错！" + ex.Message;
                ErrCode = "-1";
                WriteErr();
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                return al;
            }
            Reader.Close();

            ProgressBarValue = -1;
            return al;
        }
        #endregion

        #region 出院患者情况查询
        /// <summary>
        /// 出院患者情况查询 --Create By ZhangQi
        /// </summary>
        /// <param name="SQLPatient"></param>
        /// <returns></returns>
        private ArrayList myPatientOutHosQuery(string SQLPatient)
        {
            ArrayList al=new ArrayList();
            PatientInfo PatientInfo = new PatientInfo();
            ProgressBarText = "正在查询...";
            ProgressBarValue = 0;

            if(ExecQuery(SQLPatient)==-1)
            {
                return null;
            }
            try
            {
                while (Reader.Read())
                {
                    try
                    {
                        PatientInfo = new PatientInfo();
                        if (!Reader.IsDBNull(0)) PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[0].ToString();
                        if (!Reader.IsDBNull(1)) PatientInfo.PID.PatientNO = Reader[1].ToString();
                        if (!Reader.IsDBNull(2)) PatientInfo.Name = Reader[2].ToString();
                        if (!Reader.IsDBNull(3)) PatientInfo.Sex.ID = Reader[3].ToString();
                        if (!Reader.IsDBNull(4)) PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[4].ToString();
                        if (!Reader.IsDBNull(5)) PatientInfo.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5]);
                        if (!Reader.IsDBNull(6)) PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[6]);
                    }
                    catch(Exception ex)
                    {
                        Err = ex.Message;
                        WriteErr();
                        if (!Reader.IsClosed)
                        {
                            Reader.Close();
                        }
                        return null;
                    }
                    ProgressBarValue++;
                    al.Add(PatientInfo);
                }

            }
            catch (Exception ex)
            {
                Err = "获得基本信息出错" + ex.Message;
                WriteErr();
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                return al;
            }
            Reader.Close();
            ProgressBarValue = -1;
            return al;
        }

        #endregion

        #region 无费退院患者
        /// <summary>
        /// 无费退院患者查询 --Create By ZhangQi
        /// </summary>
        /// <param name="SQLPatient"></param>
        /// <returns></returns>
        private ArrayList myPatientNoFeeQuery(string SQLPatient)
        {
            ArrayList al = new ArrayList();
            PatientInfo PatientInfo=new PatientInfo ();
            if (ExecQuery(SQLPatient) == -1)
            {
                return null;
            }
            try
            {
                while (Reader.Read())
                {
                    try
                    {
                        PatientInfo = new PatientInfo();
                        if (!Reader.IsDBNull(0)) PatientInfo.PID.PatientNO = Reader[0].ToString();
                        if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString();
                        if (!Reader.IsDBNull(2)) PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[2].ToString();
                        if (!Reader.IsDBNull(3)) PatientInfo.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[3]);
                        if (!Reader.IsDBNull(4)) PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4]);
                    }
                    catch(Exception ex)
                    {
                        Err = ex.Message;
                        WriteErr();
                        if (!Reader.IsClosed)
                        {
                            Reader.Close();
                        }
                        return null;
                    }
                    ProgressBarValue++;
                    al.Add(PatientInfo);
                }
            }
            catch(Exception ex)
            {
                Err = "获得患者信息出错" + ex.Message;
                WriteErr();
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                return al;
            }
            Reader.Close();
            ProgressBarValue = -1;
            return al;
        }
        #endregion

        #region 根据科室 时间点查询某一时间点的在院患者情况
        /// <summary>
        /// 无费退院患者查询 --Create By ZhangQi 聊城项目需求
        /// </summary>
        /// <param name="SQLPatient"></param>
        /// <returns></returns>
        public ArrayList PatientInHosQueryByTime(string deptCode,string queryTime)
        {
            ArrayList al = new ArrayList();
            string sql1 = string.Empty, sql2 = string.Empty;
            sql1 = PatientQuerySelect();
            if (sql1 == null)
            {
                return null;
            }
            string sql=string.Empty;
            if (Sql.GetSql("Local.Report.Patient.InHos.QueryByTime", ref sql2) == -1)
            {
                Err = "没有找到Local.Report.Patient.InHos.QueryByTime字段!";
                ErrCode = "-1";
                WriteErr();
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, deptCode,queryTime);
            return myPatientQuery(sql1);
        }
        #endregion


        /// <summary>
		/// 
		/// </summary>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <param name="State"></param>
		/// <param name="PayKind"></param>
		/// <returns></returns>
		public ArrayList PatientQuery(string Begin, string End, string State, string PayKind)
		{
			#region 接口说明

			//RADT.Inpatient.PatientQuery.where.6
			//传入：开始时间，结束时间，住院状态，支付类别
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null) return null;

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.26", ref sql2) == -1)
			{
				return null;
			}
			sql2 = " " + string.Format(sql2, Begin, End, PayKind, State);
			return myPatientQuery(sql1 + " " + sql2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <param name="State"></param>
		/// <param name="PayKind"></param>
		/// <returns></returns>
		public ArrayList PatientQuery(string Begin, string End, string State, string PayKind, string flag)
		{
			#region 接口说明

			//RADT.Inpatient.PatientQuery.where.6
			//传入：开始时间，结束时间，住院状态，支付类别
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null) return null;

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.26.ForBill", ref sql2) == -1)
			{
				return null;
			}
			sql2 = " " + string.Format(sql2, Begin, End, PayKind, State);
			return myPatientQuery(sql1 + " " + sql2);
		}

		#endregion

		public DataSet PatientqueryByUnitRetdts(string pactUnit, string beginTime, string endTime)
		{
			string strSql = string.Empty;
			DataSet dts = new DataSet();
			string strsql1 = string.Empty;
			string strsql2 = string.Empty;
			string strSqlBegin = string.Empty;
			string strSqlEnd = string.Empty;
			string strPact = string.Empty;
			
			//获取sql select 语句
			strsql1 = QueryComPatientInfoSelect();
			strSql += strsql1;
			if (strsql1 == null)
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.20", ref strsql2) == -1)
			{
				#region SQL
				//	where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]'  
				#endregion
				return null;
			}
			else
			{
				strSql += strsql2;
			}
			string[] arg = new string[2];
			if (pactUnit != string.Empty)
			{
				if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.Pact", ref strPact) == -1)
				{
					#region SQL
					//and  pact_code='{0}'
					#endregion
					
					return null;
				}
				else
				{
					strSql += " " + string.Format(strPact, pactUnit);
				}
			}
			if (beginTime != string.Empty)
			{
				if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.DateBegin", ref strSqlBegin) == -1)
				{
					#region SQL
					//	and OPER_DATE >= to_date('{0}','yyyy-mm-dd HH24:mi:ss') 
					#endregion
					
					return null;
				}
				else
				{
					strSql += " " + string.Format(strSqlBegin, beginTime);
				}
			}
			if (endTime != string.Empty)
			{
				if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.DateEnd", ref strSqlEnd) == -1)
				{
					#region SQL
					//	and OPER_DATE <= to_date('{0}','yyyy-mm-dd HH24:mi:ss') 
					#endregion
					
					return null;
				}
				else
				{
					strSql += " " + string.Format(strSqlEnd, endTime);
				}
			}
			
            dts = new DataSet();
			if (ExecQuery(strSql, ref dts) == -1)
			{
				return null;
			}
			else
			{
				return dts;
			}
		}

		# region 查询病危患者，供医务科管理

		/// <summary>
		/// 按照病情查询患者
		/// </summary>
		/// <param name="criticalFlag">病情代码  0 普通 1 病重 2 病危</param>
		/// <returns>返回患者信息列表</returns>
		public ArrayList QuerySpecialPatient(string criticalFlag)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("Manager.SpecialPatient.QuerySpecialPatient", ref strSql) == -1)
				#region SQL 病危：0 普通 1 病重 2 病危
				/*SELECT INPATIENT_NO,   --住院流水号
				 CRITICAL_FLAG   --病人标志
					FROM  FIN_IPR_INMAININFO
					WHERE PARENT_CODE = '[父级编码]' AND CURRENT_CODE = '[本级编码]' AND IN_STATE = 'I' AND CRITICAL_FLAG = '2' 
					ORDER BY INPATIENT_NO
				*/
				#endregion
			{
				return null;
			}
			if (strSql == null || strSql == string.Empty)
			{
				return null;
			}
			strSql = string.Format(strSql, criticalFlag);
			
			return myGetSpecialPatient(strSql);
		}
		[Obsolete("更改为 QuerySpecialPatient(string criticalFlag) 加参数 2",true)]
		public ArrayList QuerySpecialPatient()
		{
			return null;
		}
		# endregion

		# region 获得病位患者基本信息

		/// <summary>
		/// 获得病位，重 患者基本信息
		/// </summary>
		/// <param name="strWhere"></param>
		/// <returns></returns>
		[Obsolete("过期",true)]
        public ArrayList QuerySpecilPatient(string strWhere)
		{
			string strSql = string.Empty;
			strSql = PatientQuerySelect();
		
			if (strSql == null || strSql == string.Empty)
			{
				return null;
			}
			strSql = strSql + strWhere;
			return myPatientQuery(strSql);
		}

		# endregion

		# region 查询病重患者，供医务科管理

		/// <summary>
		/// 查询病重患者，供医务科管理
		/// </summary>
		/// <returns></returns>
		[Obsolete("更改为 QuerySpecialPatient(string criticalFlag) 加参数 1",true)]
		public ArrayList QuerySpecialPatient1()
		{
			string strSql = string.Empty;
			if (Sql.GetSql("Manager.SpecialPatient.QuerySpecialPatient1", ref strSql) == -1)
				#region SQL
				/* SELECT INPATIENT_NO,   --住院流水号
				   CRITICAL_FLAG  --病人标志
					FROM  FIN_IPR_INMAININFO
					WHERE PARENT_CODE = '[父级编码]' AND CURRENT_CODE = '[本级编码]' AND IN_STATE = 'I' AND CRITICAL_FLAG = '1' 
					ORDER BY INPATIENT_NO*/
				#endregion
			{
				return null;
			}
			if (strSql == null || strSql == string.Empty)
			{
				return null;
			}
			return myGetSpecialPatient(strSql);
		}

		# endregion

		#region 按合同单位查询病人信息列表

		/// <summary>
		/// 按照合同单位，时间段查询患者信息
		/// </summary>
		/// <param name="pactUnit">合同单位</param>
		/// <param name="beginTime"></param>
		/// <param name="endTime"></param>
		/// <returns></returns>
        public ArrayList QueryPatientByUnit(string pactUnit, string beginTime, string endTime)
		{
			string strSql = string.Empty;
			ArrayList al = new ArrayList();
			string strsql1 = string.Empty;
			string strsql2 = string.Empty;
			string strSqlBegin = string.Empty;
			string strSqlEnd = string.Empty;
			string strPact = string.Empty;
			strsql1 = QueryComPatientInfoSelect();
			strSql += strsql1;
			
			if (strsql1 == null)
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.20", ref strsql2) == -1)
				#region SQL
				/*  where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' */
				#endregion
			{
				return null;
			}
			else
			{
				strSql += strsql2;
			}
			string[] arg = new string[2];
			if (pactUnit != string.Empty)
			{
				if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.Pact", ref strPact) == -1)
					#region SQL
					/*	and  pact_code='{0}' */
					#endregion
				{
					return null;
				}
				else
				{
					strSql += " " + string.Format(strPact, pactUnit);
				}
			}
			if (beginTime != string.Empty)
			{
				if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.DateBegin", ref strSqlBegin) == -1)
					#region SQL
					/*  and OPER_DATE >= to_date('{0}','yyyy-mm-dd HH24:mi:ss') */
					#endregion
				{
					return null;
				}
				else
				{
					strSql += " " + string.Format(strSqlBegin, beginTime);
				}
			}
			if (endTime != string.Empty)
			{
				if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.DateEnd", ref strSqlEnd) == -1)
					#region SQL
					/*	and OPER_DATE <= to_date('{0}','yyyy-mm-dd HH24:mi:ss') */
					#endregion
				{
					return null;
				}
				else
				{
					strSql += " " + string.Format(strSqlEnd, endTime);
				}
			}

			return myCardPatientQuery(strSql);
		}

        [Obsolete("用QueryPatientByUnit代替",true)]
        public ArrayList PatientQueryByUnit(string pactUnit, string beginTime, string endTime)
        {
            return null;
        }
		#endregion

        #region 按姓名查询患者基本信息com_patientinfo
        /// <summary>
        /// 按姓名查询患者基本信息com_patientinfo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByName(string name)
        {
            string sql = QueryComPatientInfoSelect();
            string where = "";

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.WhereByName", ref where) == -1)
            {
                return null;
            }

            sql = sql + where;

            try
            {
                sql = string.Format(sql, name);
            }
            catch (Exception e)
            {
                Err = "查询患者信息出错!" + e.Message;
                return null;
            }

            return myCardPatientQuery(sql);
        }

        #endregion

        #region 按就诊卡号查询病人信息列表

        /// <summary>
		/// 按就诊卡号查询患者
		/// </summary>
		/// <param name="cardNO"></param>
		/// <returns></returns>
		public ArrayList GetPatientInfoByCardNO(string cardNO)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;
			
			ArrayList al = new ArrayList();

			#region 接口说明

			/////RADT.Inpatient.PatientOneQuery.where.1
			//传入:就诊卡号
			//传出：患者信息

			#endregion

			strSql1 = PatientQuerySelect();
			if (strSql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientCardNoQuery.Where.1", ref strSql2) == -1)
				#region SQL
				/* where PARENT_CODE='[父级编码]'  and  CURRENT_CODE='[本级编码]' and  card_no='{0}' */
				#endregion
			{
				return null;
			}
			try
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, cardNO);
			}
			catch
			{
				Err = "RADT.Inpatient.PatientCardNoQuery.Where.1赋值不匹配！";
				ErrCode = "RADT.Inpatient.PatientCardNoQuery.Where.1赋值不匹配！";
				WriteErr();
				return null;
			}

			return myPatientQuery(strSql1);
		}
		[System.Obsolete("更改为 GetPatientInfoByCardNO",true)]
		public ArrayList PatientCardNoQuery(string CardNO)
		{
			return null;
		}
		#endregion

        /// <summary>
        /// 按就诊卡号查询住院期间有病案的患者
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        public ArrayList GetPatientInfoHaveCaseByCardNO(string cardNO)
        {
            string strSql1 = string.Empty;
            string strSql2 = string.Empty;

            ArrayList al = new ArrayList();

            #region 接口说明

            /////RADT.Inpatient.PatientOneQuery.where.1
            //传入:就诊卡号
            //传出：患者信息

            #endregion

            strSql1 = PatientQuerySelect();
            if (strSql1 == null)
            {
                return null;
            }

            if (Sql.GetSql("RADT.Inpatient.PatientCardNoQuery.Where.99", ref strSql2) == -1)
            #region SQL
            /* where PARENT_CODE='[父级编码]'  and  CURRENT_CODE='[本级编码]' and  card_no='{0}' */
            #endregion
            {
                return null;
            }
            try
            {
                strSql1 = strSql1 + " " + string.Format(strSql2, cardNO);
            }
            catch
            {
                Err = "RADT.Inpatient.PatientCardNoQuery.Where.99赋值不匹配！";
                ErrCode = "RADT.Inpatient.PatientCardNoQuery.Where.99赋值不匹配！";
                WriteErr();
                return null;
            }

            return myPatientQuery(strSql1);
        }

        #region 按门诊号查询住院证信息
        /// <summary>
        /// 患者基本信息查询  com_patientinfo
        /// </summary>
        /// <param name="cardNO">卡号</param>
        /// <returns></returns>
        public InPatientProof QueryInPatientProofinfo(string clinicNO)
        {
            InPatientProof inpatientproofinfo = new InPatientProof();
            string sql = string.Empty;
            if (Sql.GetSql("RADT.Inpatient.InPatientProofInfoQuery.1", ref sql) == -1)
            #region SQL
            #endregion
            {
                return null;
            }
            sql = string.Format(sql, clinicNO);

            if (ExecQuery(sql) < 0)
            {
                return null;
            }

            if (Reader.Read())
            {
                try
                {
                    if (!Reader.IsDBNull(0)) inpatientproofinfo.Clinic_code = Reader[0].ToString(); //门诊号
                    if (!Reader.IsDBNull(1)) inpatientproofinfo.Card_no = Reader[1].ToString(); //卡号
                    if (!Reader.IsDBNull(2)) inpatientproofinfo.Name = Reader[2].ToString(); //姓名
                    if (!Reader.IsDBNull(3)) inpatientproofinfo.Idenno = Reader[3].ToString(); //身份证
                    if (!Reader.IsDBNull(4)) inpatientproofinfo.Sex_code.ID =  Reader[4].ToString(); //性别
                    if (!Reader.IsDBNull(5)) inpatientproofinfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5].ToString()); //出生日期
                    if (!Reader.IsDBNull(6)) inpatientproofinfo.Age = Reader[6].ToString(); //年龄
                    if (!Reader.IsDBNull(7)) inpatientproofinfo.Dept_code.ID = Reader[7].ToString(); //科室代码
                    if (!Reader.IsDBNull(8)) inpatientproofinfo.Dept_code.Name = Reader[8].ToString(); //科室名称
                    if (!Reader.IsDBNull(9)) inpatientproofinfo.Room = Reader[9].ToString(); //病室
                    if (!Reader.IsDBNull(10)) inpatientproofinfo.Diagnose = Reader[10].ToString(); //诊断
                    if (!Reader.IsDBNull(11)) inpatientproofinfo.Address = Reader[11].ToString(); //地址
                    if (!Reader.IsDBNull(12)) inpatientproofinfo.Intext = Reader[12].ToString(); //入院内容
                    if (!Reader.IsDBNull(13)) inpatientproofinfo.Wwfs = Reader[13].ToString(); //卧位方式
                    if (!Reader.IsDBNull(14)) inpatientproofinfo.Is_ys = Reader[14].ToString(); //饮食
                    if (!Reader.IsDBNull(15)) inpatientproofinfo.Is_tj = Reader[15].ToString(); //抬价
                    if (!Reader.IsDBNull(16)) inpatientproofinfo.Is_zx = Reader[16].ToString(); //自行
                    if (!Reader.IsDBNull(17)) inpatientproofinfo.Is_my = Reader[17].ToString(); //沐浴
                    if (!Reader.IsDBNull(18)) inpatientproofinfo.Is_lf = Reader[18].ToString(); //理发
                    if (!Reader.IsDBNull(19)) inpatientproofinfo.In_date = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[19].ToString()); //开证日期
                    if (!Reader.IsDBNull(20)) inpatientproofinfo.Doct_code.ID = Reader[20].ToString(); //开证医生
                    if (!Reader.IsDBNull(21)) inpatientproofinfo.Doct_code.Name = Reader[21].ToString(); //医生名称
                    if (!Reader.IsDBNull(22)) inpatientproofinfo.Inpatient_count = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[22].ToString()); //住院约计天数
                    if (!Reader.IsDBNull(23)) inpatientproofinfo.Is_drug = Reader[23].ToString(); //贵重药品
                    if (!Reader.IsDBNull(24)) inpatientproofinfo.Ops_type = Reader[24].ToString(); //手术类型
                    if (!Reader.IsDBNull(25)) inpatientproofinfo.Blood_qty = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[25].ToString()); //输血数量
                    if (!Reader.IsDBNull(26)) inpatientproofinfo.Xxfs = Reader[26].ToString(); //X光照相
                    if (!Reader.IsDBNull(27)) inpatientproofinfo.Memo = Reader[27].ToString(); //备注
                    if (!Reader.IsDBNull(28)) inpatientproofinfo.Memo1 = Reader[28].ToString(); //备注1
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    WriteErr();
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    return null;
                }
            }

            Reader.Close();

            return inpatientproofinfo;
        }
        #endregion

        #region 按就诊卡号查询病人基本信息

        /// <summary>
		/// 患者基本信息查询  com_patientinfo
		/// </summary>
		/// <param name="cardNO">卡号</param>
		/// <returns></returns>
		public PatientInfo QueryComPatientInfo(string cardNO)
		{
			PatientInfo PatientInfo = new PatientInfo();
			string sql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.PatientInfoQuery.1", ref sql) == -1)
				#region SQL
				/*SELECT card_no,
						   name,   --姓名
								   spell_code,   --拼音码

								   wb_code,   --五笔
								   birthday,   --出生日期
								   sex_code,   --性别
								   idenno,   --身份证号
								   blood_code,   --血型

								   prof_code,   --职业
								   work_home,   --工作单位
								   work_tel,   --单位电话
								   work_zip,   --单位邮编
								   home,   --户口或家庭所在

								   home_tel,   --家庭电话
								   home_zip,   --户口或家庭邮政编码

								   district,   --籍贯
								   nation_code,   --民族
								   linkman_name,   --联系人姓名

								   linkman_tel,   --联系人电话

								   linkman_add,   --联系人住址
								   rela_code,   --联系人关系

								   mari,   --婚姻状况
								   coun_code,   --国籍
								   paykind_code,   --结算类别
								   paykind_name,   --结算类别名称
								   pact_code,   --合同代码
								   pact_name,   --合同单位名称
								   mcard_no,   --医疗证号
								   area_code,   --出生地

								   framt,   --医疗费用
								   ic_cardno,   --电脑号

								   anaphy_flag,   --药物过敏
								   hepatitis_flag,   --重要疾病
								   act_code,   --帐户密码
								   act_amt,   --帐户总额
								   lact_sum,   --上期帐户余额
								   lbank_sum,   --上期银行余额
								   arrear_times,   --欠费次数
								   arrear_sum,   --欠费金额
								   inhos_source,   --住院来源
								   lihos_date,   --最近住院日期

								   inhos_times,   --住院次数
								   louthos_date,   --最近出院日期

								   fir_see_date,   --初诊日期
								   lreg_date,   --最近挂号日期

								   disoby_cnt,   --违约次数
								   end_date,   --结束日期
								   mark,   --备注
								   oper_code,   --操作员

								   oper_date    --操作日期
							  FROM com_patientinfo   --病人基本信息表
							 WHERE PARENT_CODE='[父级编码]'  and 
								   CURRENT_CODE='[本级编码]' and 
								   card_no='{0}'
								   */
				#endregion
			{
				return null;
			}
			sql = string.Format(sql, cardNO);
			
			if (ExecQuery(sql) < 0)
			{
				return null;
			}

			if (Reader.Read())
			{
				try
				{
					if (!Reader.IsDBNull(0)) PatientInfo.PID.CardNO = Reader[0].ToString(); //就诊卡号
					if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); //姓名
					if (!Reader.IsDBNull(2)) PatientInfo.SpellCode = Reader[2].ToString(); //拼音码
					if (!Reader.IsDBNull(3)) PatientInfo.WBCode = Reader[3].ToString(); //五笔
					if (!Reader.IsDBNull(4)) PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString()); //出生日期
					if (!Reader.IsDBNull(5)) PatientInfo.Sex.ID = Reader[5].ToString(); //性别
					if (!Reader.IsDBNull(6)) PatientInfo.IDCard = Reader[6].ToString(); //身份证号
					if (!Reader.IsDBNull(7)) PatientInfo.BloodType.ID = Reader[7].ToString(); //血型
					if (!Reader.IsDBNull(8)) PatientInfo.Profession.ID = Reader[8].ToString(); //职业
					if (!Reader.IsDBNull(9)) PatientInfo.CompanyName = Reader[9].ToString(); //工作单位
					if (!Reader.IsDBNull(10)) PatientInfo.PhoneBusiness = Reader[10].ToString(); //单位电话
					if (!Reader.IsDBNull(11)) PatientInfo.BusinessZip = Reader[11].ToString(); //单位邮编
					if (!Reader.IsDBNull(12)) PatientInfo.AddressHome = Reader[12].ToString(); //户口或家庭所在
					if (!Reader.IsDBNull(13)) PatientInfo.PhoneHome = Reader[13].ToString(); //家庭电话
					if (!Reader.IsDBNull(14)) PatientInfo.HomeZip = Reader[14].ToString(); //户口或家庭邮政编码
					if (!Reader.IsDBNull(15)) PatientInfo.DIST = Reader[15].ToString(); //籍贯
					if (!Reader.IsDBNull(16)) PatientInfo.Nationality.ID = Reader[16].ToString(); //民族
					if (!Reader.IsDBNull(17)) PatientInfo.Kin.Name = Reader[17].ToString(); //联系人姓名
					if (!Reader.IsDBNull(18)) PatientInfo.Kin.RelationPhone = Reader[18].ToString(); //联系人电话
					if (!Reader.IsDBNull(19)) PatientInfo.Kin.RelationAddress = Reader[19].ToString(); //联系人住址
					if (!Reader.IsDBNull(20)) PatientInfo.Kin.Relation.ID = Reader[20].ToString(); //联系人关系
					if (!Reader.IsDBNull(21)) PatientInfo.MaritalStatus.ID = Reader[21].ToString(); //婚姻状况
					if (!Reader.IsDBNull(22)) PatientInfo.Country.ID = Reader[22].ToString(); //国籍
					if (!Reader.IsDBNull(23)) PatientInfo.Pact.PayKind.ID = Reader[23].ToString(); //结算类别
					if (!Reader.IsDBNull(24)) PatientInfo.Pact.PayKind.Name = Reader[24].ToString(); //结算类别名称
					if (!Reader.IsDBNull(25)) PatientInfo.Pact.ID = Reader[25].ToString(); //合同代码
					if (!Reader.IsDBNull(26)) PatientInfo.Pact.Name = Reader[26].ToString(); //合同单位名称
					if (!Reader.IsDBNull(27)) PatientInfo.SSN = Reader[27].ToString(); //医疗证号
					if (!Reader.IsDBNull(28)) PatientInfo.AreaCode = Reader[28].ToString(); //地区
					if (!Reader.IsDBNull(29)) PatientInfo.FT.TotCost = NConvert.ToDecimal(Reader[29].ToString()); //医疗费用
					if (!Reader.IsDBNull(30)) PatientInfo.Card.ICCard.ID = Reader[30].ToString(); //电脑号
					if (!Reader.IsDBNull(31)) PatientInfo.Disease.IsAlleray = NConvert.ToBoolean(Reader[31].ToString()); //药物过敏
					if (!Reader.IsDBNull(32)) PatientInfo.Disease.IsMainDisease = NConvert.ToBoolean(Reader[32].ToString()); //重要疾病
					if (!Reader.IsDBNull(33)) PatientInfo.Card.NewPassword = Reader[33].ToString(); //帐户密码
					if (!Reader.IsDBNull(34)) PatientInfo.Card.NewAmount = NConvert.ToDecimal(Reader[34].ToString()); //帐户总额
					if (!Reader.IsDBNull(35)) PatientInfo.Card.OldAmount = NConvert.ToDecimal(Reader[35].ToString()); //上期帐户余额
					//					if (!this.Reader.IsDBNull(36)) PatientInfo=this.Reader[36].ToString();//上期银行余额
					//					if (!this.Reader.IsDBNull(37)) PatientInfo=this.Reader[37].ToString();//欠费次数
					//					if (!this.Reader.IsDBNull(38)) PatientInfo=this.Reader[38].ToString();//欠费金额
					//					if (!this.Reader.IsDBNull(39)) PatientInfo=this.Reader[39].ToString();//住院来源
					//					if (!this.Reader.IsDBNull(40)) PatientInfo=this.Reader[40].ToString();//最近住院日期
					//					if (!this.Reader.IsDBNull(41)) PatientInfo=this.Reader[41].ToString();//住院次数
					//					if (!this.Reader.IsDBNull(42)) PatientInfo=this.Reader[42].ToString();//最近出院日期
					//					if (!this.Reader.IsDBNull(43)) PatientInfo=this.Reader[43].ToString();//初诊日期
					//					if (!this.Reader.IsDBNull(44)) PatientInfo=this.Reader[44].ToString();//最近挂号日期
					//					if (!this.Reader.IsDBNull(45)) PatientInfo=this.Reader[45].ToString();//违约次数
					//					if (!this.Reader.IsDBNull(46)) PatientInfo=this.Reader[46].ToString();//结束日期
					if (!Reader.IsDBNull(47)) PatientInfo.Memo = Reader[47].ToString(); //备注
					if (!Reader.IsDBNull(48)) PatientInfo.User01 = Reader[48].ToString(); //操作员
					if (!Reader.IsDBNull(49)) PatientInfo.User02 = Reader[49].ToString(); //操作日期
                    if (!Reader.IsDBNull(50)) PatientInfo.IsEncrypt = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[50].ToString());
                    if (!Reader.IsDBNull(51)) PatientInfo.NormalName = Reader[51].ToString();
                    //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
                    if (!Reader.IsDBNull(52)) PatientInfo.IDCardType.ID = Reader[52].ToString();//证件类型
                    if (!Reader.IsDBNull(53)) PatientInfo.VipFlag = NConvert.ToBoolean(Reader[53]);//vip标识
                    if (!Reader.IsDBNull(54)) PatientInfo.MatherName = Reader[54].ToString();//母亲姓名
                    if (!Reader.IsDBNull(55)) PatientInfo.IsTreatment = NConvert.ToBoolean(Reader[55]);//是否急诊
                    if (!Reader.IsDBNull(56)) PatientInfo.PID.CaseNO = Reader[56].ToString();//病案号
                    if (PatientInfo.IsEncrypt && PatientInfo.NormalName != string.Empty)
                    {
                        PatientInfo.DecryptName = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(PatientInfo.NormalName);
                    }
                    if (!Reader.IsDBNull(57)) PatientInfo.Insurance.ID = Reader[57].ToString(); //保险公司编码
                    if (!Reader.IsDBNull(58)) PatientInfo.Insurance.Name = Reader[58].ToString(); //保险公司名称
                    if (!Reader.IsDBNull(59)) PatientInfo.Kin.RelationDoorNo = Reader[59].ToString(); //联系人地址门牌号
                    if (!Reader.IsDBNull(60)) PatientInfo.AddressHomeDoorNo = Reader[60].ToString(); //家庭住址门牌号
                    if (!Reader.IsDBNull(61)) PatientInfo.Email = Reader[61].ToString(); //email
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					WriteErr();
					if (!Reader.IsClosed)
					{
						Reader.Close();
					}
					return null;
				}
			}

			Reader.Close();

			return PatientInfo;
		}

        //{971E891B-4E05-42c9-8C7A-98E13996AA17}
        /// <summary>
        /// 患者基本信息查询  com_patientinfo
        /// </summary>
        /// <param name="idNO">身份证号</param>
        /// <returns></returns>
        public PatientInfo QueryComPatientInfoByIDNO(string IDNO)
        {
            PatientInfo PatientInfo = new PatientInfo();
            string sql = string.Empty;
            if (Sql.GetSql("RADT.Inpatient.PatientInfoQuerybyIDNO", ref sql) == -1)
            #region SQL
            /*SELECT card_no,
						   name,   --姓名
								   spell_code,   --拼音码

								   wb_code,   --五笔
								   birthday,   --出生日期
								   sex_code,   --性别
								   idenno,   --身份证号
								   blood_code,   --血型

								   prof_code,   --职业
								   work_home,   --工作单位
								   work_tel,   --单位电话
								   work_zip,   --单位邮编
								   home,   --户口或家庭所在

								   home_tel,   --家庭电话
								   home_zip,   --户口或家庭邮政编码

								   district,   --籍贯
								   nation_code,   --民族
								   linkman_name,   --联系人姓名

								   linkman_tel,   --联系人电话

								   linkman_add,   --联系人住址
								   rela_code,   --联系人关系

								   mari,   --婚姻状况
								   coun_code,   --国籍
								   paykind_code,   --结算类别
								   paykind_name,   --结算类别名称
								   pact_code,   --合同代码
								   pact_name,   --合同单位名称
								   mcard_no,   --医疗证号
								   area_code,   --出生地

								   framt,   --医疗费用
								   ic_cardno,   --电脑号

								   anaphy_flag,   --药物过敏
								   hepatitis_flag,   --重要疾病
								   act_code,   --帐户密码
								   act_amt,   --帐户总额
								   lact_sum,   --上期帐户余额
								   lbank_sum,   --上期银行余额
								   arrear_times,   --欠费次数
								   arrear_sum,   --欠费金额
								   inhos_source,   --住院来源
								   lihos_date,   --最近住院日期

								   inhos_times,   --住院次数
								   louthos_date,   --最近出院日期

								   fir_see_date,   --初诊日期
								   lreg_date,   --最近挂号日期

								   disoby_cnt,   --违约次数
								   end_date,   --结束日期
								   mark,   --备注
								   oper_code,   --操作员

								   oper_date    --操作日期
							  FROM com_patientinfo   --病人基本信息表
							 WHERE PARENT_CODE='[父级编码]'  and 
								   CURRENT_CODE='[本级编码]' and 
								   card_no='{0}'
								   */
            #endregion
            {
                return null;
            }
            sql = string.Format(sql, IDNO);

            if (ExecQuery(sql) < 0)
            {
                return null;
            }

            if (Reader.Read())
            {
                try
                {
                    if (!Reader.IsDBNull(0)) PatientInfo.PID.CardNO = Reader[0].ToString(); //就诊卡号
                    if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); //姓名
                    if (!Reader.IsDBNull(2)) PatientInfo.SpellCode = Reader[2].ToString(); //拼音码
                    if (!Reader.IsDBNull(3)) PatientInfo.WBCode = Reader[3].ToString(); //五笔
                    if (!Reader.IsDBNull(4)) PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString()); //出生日期
                    if (!Reader.IsDBNull(5)) PatientInfo.Sex.ID = Reader[5].ToString(); //性别
                    if (!Reader.IsDBNull(6)) PatientInfo.IDCard = Reader[6].ToString(); //身份证号
                    if (!Reader.IsDBNull(7)) PatientInfo.BloodType.ID = Reader[7].ToString(); //血型
                    if (!Reader.IsDBNull(8)) PatientInfo.Profession.ID = Reader[8].ToString(); //职业
                    if (!Reader.IsDBNull(9)) PatientInfo.CompanyName = Reader[9].ToString(); //工作单位
                    if (!Reader.IsDBNull(10)) PatientInfo.PhoneBusiness = Reader[10].ToString(); //单位电话
                    if (!Reader.IsDBNull(11)) PatientInfo.BusinessZip = Reader[11].ToString(); //单位邮编
                    if (!Reader.IsDBNull(12)) PatientInfo.AddressHome = Reader[12].ToString(); //户口或家庭所在
                    if (!Reader.IsDBNull(13)) PatientInfo.PhoneHome = Reader[13].ToString(); //家庭电话
                    if (!Reader.IsDBNull(14)) PatientInfo.HomeZip = Reader[14].ToString(); //户口或家庭邮政编码
                    if (!Reader.IsDBNull(15)) PatientInfo.DIST = Reader[15].ToString(); //籍贯
                    if (!Reader.IsDBNull(16)) PatientInfo.Nationality.ID = Reader[16].ToString(); //民族
                    if (!Reader.IsDBNull(17)) PatientInfo.Kin.Name = Reader[17].ToString(); //联系人姓名
                    if (!Reader.IsDBNull(18)) PatientInfo.Kin.RelationPhone = Reader[18].ToString(); //联系人电话
                    if (!Reader.IsDBNull(19)) PatientInfo.Kin.RelationAddress = Reader[19].ToString(); //联系人住址
                    if (!Reader.IsDBNull(20)) PatientInfo.Kin.Relation.ID = Reader[20].ToString(); //联系人关系
                    if (!Reader.IsDBNull(21)) PatientInfo.MaritalStatus.ID = Reader[21].ToString(); //婚姻状况
                    if (!Reader.IsDBNull(22)) PatientInfo.Country.ID = Reader[22].ToString(); //国籍
                    if (!Reader.IsDBNull(23)) PatientInfo.Pact.PayKind.ID = Reader[23].ToString(); //结算类别
                    if (!Reader.IsDBNull(24)) PatientInfo.Pact.PayKind.Name = Reader[24].ToString(); //结算类别名称
                    if (!Reader.IsDBNull(25)) PatientInfo.Pact.ID = Reader[25].ToString(); //合同代码
                    if (!Reader.IsDBNull(26)) PatientInfo.Pact.Name = Reader[26].ToString(); //合同单位名称
                    if (!Reader.IsDBNull(27)) PatientInfo.SSN = Reader[27].ToString(); //医疗证号
                    if (!Reader.IsDBNull(28)) PatientInfo.AreaCode = Reader[28].ToString(); //地区
                    if (!Reader.IsDBNull(29)) PatientInfo.FT.TotCost = NConvert.ToDecimal(Reader[29].ToString()); //医疗费用
                    if (!Reader.IsDBNull(30)) PatientInfo.Card.ICCard.ID = Reader[30].ToString(); //电脑号
                    if (!Reader.IsDBNull(31)) PatientInfo.Disease.IsAlleray = NConvert.ToBoolean(Reader[31].ToString()); //药物过敏
                    if (!Reader.IsDBNull(32)) PatientInfo.Disease.IsMainDisease = NConvert.ToBoolean(Reader[32].ToString()); //重要疾病
                    if (!Reader.IsDBNull(33)) PatientInfo.Card.NewPassword = Reader[33].ToString(); //帐户密码
                    if (!Reader.IsDBNull(34)) PatientInfo.Card.NewAmount = NConvert.ToDecimal(Reader[34].ToString()); //帐户总额
                    if (!Reader.IsDBNull(35)) PatientInfo.Card.OldAmount = NConvert.ToDecimal(Reader[35].ToString()); //上期帐户余额
                    //					if (!this.Reader.IsDBNull(36)) PatientInfo=this.Reader[36].ToString();//上期银行余额
                    //					if (!this.Reader.IsDBNull(37)) PatientInfo=this.Reader[37].ToString();//欠费次数
                    //					if (!this.Reader.IsDBNull(38)) PatientInfo=this.Reader[38].ToString();//欠费金额
                    //					if (!this.Reader.IsDBNull(39)) PatientInfo=this.Reader[39].ToString();//住院来源
                    //					if (!this.Reader.IsDBNull(40)) PatientInfo=this.Reader[40].ToString();//最近住院日期
                    //					if (!this.Reader.IsDBNull(41)) PatientInfo=this.Reader[41].ToString();//住院次数
                    //					if (!this.Reader.IsDBNull(42)) PatientInfo=this.Reader[42].ToString();//最近出院日期
                    //					if (!this.Reader.IsDBNull(43)) PatientInfo=this.Reader[43].ToString();//初诊日期
                    //					if (!this.Reader.IsDBNull(44)) PatientInfo=this.Reader[44].ToString();//最近挂号日期
                    //					if (!this.Reader.IsDBNull(45)) PatientInfo=this.Reader[45].ToString();//违约次数
                    //					if (!this.Reader.IsDBNull(46)) PatientInfo=this.Reader[46].ToString();//结束日期
                    if (!Reader.IsDBNull(47)) PatientInfo.Memo = Reader[47].ToString(); //备注
                    if (!Reader.IsDBNull(48)) PatientInfo.User01 = Reader[48].ToString(); //操作员
                    if (!Reader.IsDBNull(49)) PatientInfo.User02 = Reader[49].ToString(); //操作日期
                    if (!Reader.IsDBNull(50)) PatientInfo.IsEncrypt = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[50].ToString());
                    if (!Reader.IsDBNull(51)) PatientInfo.NormalName = Reader[51].ToString();
                    //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
                    if (!Reader.IsDBNull(52)) PatientInfo.IDCardType.ID = Reader[52].ToString();//证件类型
                    if (!Reader.IsDBNull(53)) PatientInfo.VipFlag = NConvert.ToBoolean(Reader[53]);//vip标识
                    if (!Reader.IsDBNull(54)) PatientInfo.MatherName = Reader[54].ToString();//母亲姓名
                    if (!Reader.IsDBNull(55)) PatientInfo.IsTreatment = NConvert.ToBoolean(Reader[55]);//是否急诊
                    if (!Reader.IsDBNull(56)) PatientInfo.PID.CaseNO = Reader[56].ToString();//病案号
                    if (PatientInfo.IsEncrypt && PatientInfo.NormalName != string.Empty)
                    {
                        PatientInfo.DecryptName = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(PatientInfo.NormalName);
                    }
                    if (!Reader.IsDBNull(57)) PatientInfo.Insurance.ID = Reader[57].ToString(); //保险公司编码
                    if (!Reader.IsDBNull(58)) PatientInfo.Insurance.Name = Reader[58].ToString(); //保险公司名称
                    if (!Reader.IsDBNull(59)) PatientInfo.Kin.RelationDoorNo = Reader[59].ToString(); //联系人地址门牌号
                    if (!Reader.IsDBNull(60)) PatientInfo.AddressHomeDoorNo = Reader[60].ToString(); //家庭住址门牌号
                    if (!Reader.IsDBNull(61)) PatientInfo.Email = Reader[61].ToString(); //email
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    WriteErr();
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    return null;
                }
            }

            Reader.Close();

            return PatientInfo;
        }

        /// <summary>
        /// 根据医保编号查询患者基本信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        public PatientInfo QueryComPatientInfoByMcardNO(string cardNO)
        {
            PatientInfo PatientInfo = new PatientInfo();
            string sql = string.Empty;
            if (Sql.GetSql("RADT.Inpatient.PatientInfoQuery.96", ref sql) == -1)
            {
                return null;
            }
            sql = string.Format(sql, cardNO);

            if (ExecQuery(sql) < 0)
            {
                return null;
            }

            if (Reader.Read())
            {
                try
                {
                    if (!Reader.IsDBNull(0)) PatientInfo.PID.CardNO = Reader[0].ToString(); //就诊卡号
                    if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); //姓名
                    if (!Reader.IsDBNull(2)) PatientInfo.SpellCode = Reader[2].ToString(); //拼音码
                    if (!Reader.IsDBNull(3)) PatientInfo.WBCode = Reader[3].ToString(); //五笔
                    if (!Reader.IsDBNull(4)) PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString()); //出生日期
                    if (!Reader.IsDBNull(5)) PatientInfo.Sex.ID = Reader[5].ToString(); //性别
                    if (!Reader.IsDBNull(6)) PatientInfo.IDCard = Reader[6].ToString(); //身份证号
                    if (!Reader.IsDBNull(7)) PatientInfo.BloodType.ID = Reader[7].ToString(); //血型
                    if (!Reader.IsDBNull(8)) PatientInfo.Profession.ID = Reader[8].ToString(); //职业
                    if (!Reader.IsDBNull(9)) PatientInfo.CompanyName = Reader[9].ToString(); //工作单位
                    if (!Reader.IsDBNull(10)) PatientInfo.PhoneBusiness = Reader[10].ToString(); //单位电话
                    if (!Reader.IsDBNull(11)) PatientInfo.BusinessZip = Reader[11].ToString(); //单位邮编
                    if (!Reader.IsDBNull(12)) PatientInfo.AddressHome = Reader[12].ToString(); //户口或家庭所在
                    if (!Reader.IsDBNull(13)) PatientInfo.PhoneHome = Reader[13].ToString(); //家庭电话
                    if (!Reader.IsDBNull(14)) PatientInfo.HomeZip = Reader[14].ToString(); //户口或家庭邮政编码
                    if (!Reader.IsDBNull(15)) PatientInfo.DIST = Reader[15].ToString(); //籍贯
                    if (!Reader.IsDBNull(16)) PatientInfo.Nationality.ID = Reader[16].ToString(); //民族
                    if (!Reader.IsDBNull(17)) PatientInfo.Kin.Name = Reader[17].ToString(); //联系人姓名
                    if (!Reader.IsDBNull(18)) PatientInfo.Kin.RelationPhone = Reader[18].ToString(); //联系人电话
                    if (!Reader.IsDBNull(19)) PatientInfo.Kin.RelationAddress = Reader[19].ToString(); //联系人住址
                    if (!Reader.IsDBNull(20)) PatientInfo.Kin.Relation.ID = Reader[20].ToString(); //联系人关系
                    if (!Reader.IsDBNull(21)) PatientInfo.MaritalStatus.ID = Reader[21].ToString(); //婚姻状况
                    if (!Reader.IsDBNull(22)) PatientInfo.Country.ID = Reader[22].ToString(); //国籍
                    if (!Reader.IsDBNull(23)) PatientInfo.Pact.PayKind.ID = Reader[23].ToString(); //结算类别
                    if (!Reader.IsDBNull(24)) PatientInfo.Pact.PayKind.Name = Reader[24].ToString(); //结算类别名称
                    if (!Reader.IsDBNull(25)) PatientInfo.Pact.ID = Reader[25].ToString(); //合同代码
                    if (!Reader.IsDBNull(26)) PatientInfo.Pact.Name = Reader[26].ToString(); //合同单位名称
                    if (!Reader.IsDBNull(27)) PatientInfo.SSN = Reader[27].ToString(); //医疗证号
                    if (!Reader.IsDBNull(28)) PatientInfo.AreaCode = Reader[28].ToString(); //地区
                    if (!Reader.IsDBNull(29)) PatientInfo.FT.TotCost = NConvert.ToDecimal(Reader[29].ToString()); //医疗费用
                    if (!Reader.IsDBNull(30)) PatientInfo.Card.ICCard.ID = Reader[30].ToString(); //电脑号
                    if (!Reader.IsDBNull(31)) PatientInfo.Disease.IsAlleray = NConvert.ToBoolean(Reader[31].ToString()); //药物过敏
                    if (!Reader.IsDBNull(32)) PatientInfo.Disease.IsMainDisease = NConvert.ToBoolean(Reader[32].ToString()); //重要疾病
                    if (!Reader.IsDBNull(33)) PatientInfo.Card.NewPassword = Reader[33].ToString(); //帐户密码
                    if (!Reader.IsDBNull(34)) PatientInfo.Card.NewAmount = NConvert.ToDecimal(Reader[34].ToString()); //帐户总额
                    if (!Reader.IsDBNull(35)) PatientInfo.Card.OldAmount = NConvert.ToDecimal(Reader[35].ToString()); //上期帐户余额
                    //					if (!this.Reader.IsDBNull(36)) PatientInfo=this.Reader[36].ToString();//上期银行余额
                    //					if (!this.Reader.IsDBNull(37)) PatientInfo=this.Reader[37].ToString();//欠费次数
                    //					if (!this.Reader.IsDBNull(38)) PatientInfo=this.Reader[38].ToString();//欠费金额
                    //					if (!this.Reader.IsDBNull(39)) PatientInfo=this.Reader[39].ToString();//住院来源
                    //					if (!this.Reader.IsDBNull(40)) PatientInfo=this.Reader[40].ToString();//最近住院日期
                    //					if (!this.Reader.IsDBNull(41)) PatientInfo=this.Reader[41].ToString();//住院次数
                    //					if (!this.Reader.IsDBNull(42)) PatientInfo=this.Reader[42].ToString();//最近出院日期
                    //					if (!this.Reader.IsDBNull(43)) PatientInfo=this.Reader[43].ToString();//初诊日期
                    //					if (!this.Reader.IsDBNull(44)) PatientInfo=this.Reader[44].ToString();//最近挂号日期
                    //					if (!this.Reader.IsDBNull(45)) PatientInfo=this.Reader[45].ToString();//违约次数
                    //					if (!this.Reader.IsDBNull(46)) PatientInfo=this.Reader[46].ToString();//结束日期
                    if (!Reader.IsDBNull(47)) PatientInfo.Memo = Reader[47].ToString(); //备注
                    if (!Reader.IsDBNull(48)) PatientInfo.User01 = Reader[48].ToString(); //操作员
                    if (!Reader.IsDBNull(49)) PatientInfo.User02 = Reader[49].ToString(); //操作日期
                    if (!Reader.IsDBNull(50)) PatientInfo.IsEncrypt = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[50].ToString());
                    if (!Reader.IsDBNull(51)) PatientInfo.NormalName = Reader[51].ToString();
                    //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
                    if (!Reader.IsDBNull(52)) PatientInfo.IDCardType.ID = Reader[52].ToString();//证件类型
                    if (!Reader.IsDBNull(53)) PatientInfo.VipFlag = NConvert.ToBoolean(Reader[53]);//vip标识
                    if (!Reader.IsDBNull(54)) PatientInfo.MatherName = Reader[54].ToString();//母亲姓名
                    if (!Reader.IsDBNull(55)) PatientInfo.IsTreatment = NConvert.ToBoolean(Reader[55]);//是否急诊
                    if (!Reader.IsDBNull(56)) PatientInfo.PID.CaseNO = Reader[56].ToString();//病案号
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    WriteErr();
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    return null;
                }
            }

            Reader.Close();

            return PatientInfo;
        }
		[Obsolete("更改为 QueryComPatientInfo",true)]
		public PatientInfo PatientInfoQuery(string CardNO)
		{
			return null;
		}
		#endregion

		#region 按住院患者实体获得患者变更信息

		private void myGetTempLocation(PatientInfo PatientInfo)
		{
			#region 接口说明

			//RADT.Inpatient.Trans.1
			//获得患者变更信息
			//传入：住院流水号
			//传出：0 科室id,1科室 name ,2 病区id ,3病区name ，4楼，5层，6 屋，7 bedno

			#endregion

			string strSql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.Trans.1", ref strSql) == -1)
				#region SQL
				/*select	new_data_code,new_data_name,'','','','','','' from com_shiftdata	 
		                 where	PARENT_CODE='[父级编码]' 
						 and CURRENT_CODE='[本级编码]' 
						 and  shift_type='RD' and clinic_no='{0}' 
						 and happen_no=(select max(happen_no) 
						 from	com_shiftdata where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and clinic_no='{0}') */
				#endregion
			{
				return;
			}
			strSql = string.Format(strSql, PatientInfo.ID);
			try
			{
				this.ExecQueryByTempReader(strSql);
				this.TempReader.Read();
				if (!this.TempReader.IsDBNull(0)) PatientInfo.PVisit.TemporaryLocation.Dept.ID = this.TempReader[0].ToString();
				if (!this.TempReader.IsDBNull(1)) PatientInfo.PVisit.TemporaryLocation.Dept.Name = this.TempReader[1].ToString();
				if (!this.TempReader.IsDBNull(2))
					PatientInfo.PVisit.TemporaryLocation.NurseCell.ID = this.TempReader[2].ToString();
				if (!this.TempReader.IsDBNull(3))
					PatientInfo.PVisit.TemporaryLocation.NurseCell.Name = this.TempReader[3].ToString();
				if (!this.TempReader.IsDBNull(4)) PatientInfo.PVisit.TemporaryLocation.Building = this.TempReader[4].ToString();
//				if (!this.TempReader1.IsDBNull(5)) PatientInfo.PVisit.TemporaryLocation.Floor = this.TempReader1[5].ToString();
				if (!this.TempReader.IsDBNull(6)) PatientInfo.PVisit.TemporaryLocation.Room = this.TempReader[6].ToString();
				if (!this.TempReader.IsDBNull(7)) PatientInfo.PVisit.TemporaryLocation.Bed.ID = this.TempReader[7].ToString();
				this.Reader.Close();
			}

			catch (Exception ex)
			{
				Err = ex.Message;
				WriteErr();
			}
		}

		#endregion

		

		#region 查询患者信息列表--仅用于住院登记的时候显示当天患者和未接诊的患者

		/// <summary>
		/// 患者查询--仅用于住院登记的时候显示当天患者和未接诊的患者
		/// </summary>
		/// <param name="beginDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <returns></returns>
		public ArrayList PatientsForRegiDisplay(DateTime beginDateTime, DateTime endDateTime)
		{
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null)
			{
				return null;
			}

			string[] arg = new string[2];
			
			arg[0] = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			arg[1] = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);

			if (Sql.GetSql("RADT.Inpatient.PatientsForRegiDisplay", ref sql2) == -1)
				#region SQL
				/* where PARENT_CODE='[父级编码]' 
					and CURRENT_CODE='[本级编码]' 
					and ((TRUNC(in_date) >=to_date('{0}','yyyy-mm-dd')) 
					and (TRUNC(in_date)  <=to_date('{1}','yyyy-mm-dd')) 
					or In_state='R')
					order by in_date desc 
				*/
				#endregion
			{
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, arg);
			return myPatientQuery(sql1);
		}

		#endregion

		#region 按姓名查询患者信息列表

		/// <summary>
		/// 患者姓名查询患者---wangrc
		/// </summary>
		/// <param name="patientName"></param>
		/// <returns></returns>
		public ArrayList QueryPatientInfoByName(string patientName)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;

			strSql1 = PatientQuerySelect();
			if (strSql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientNameQuery.Where.12", ref strSql2) == -1)
				#region SQL
				/*
				 * 	where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and NAME like '{0}'and in_state in('I','B') 
				 * */
				#endregion
			{
				return null;
			}
			try
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, patientName);
			}
			catch
			{
				Err = "RADT.Inpatient.PatientCardNoQuery.Where.1赋值不匹配！";
				ErrCode = "RADT.Inpatient.PatientCardNoQuery.Where.1赋值不匹配！";
				WriteErr();
				return null;
			}

			return myPatientQuery(strSql1);
		}

        /// <summary>
        /// 患者姓名查询患者 wolf
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList QueryInpatientNOByName(string name)
        {
            string strSql = string.Empty;
            if (Sql.GetSql("RADT.Inpatient.QeryInpatientNoFromPatientNo.3", ref strSql) == 0)
            {
                #region SQL
                /*
				 * select inpatient_no,name,in_state,DEPT_CODE,dept_name,in_date 
				 * from fin_ipr_inmaininfo  where  PARENT_CODE='[父级编码]'	
				 * and	CURRENT_CODE='[本级编码]' 
				 * and  name='{0}'
				*/
                #endregion
                try
                {
                    strSql = string.Format(strSql, name);
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    ErrCode = ex.Message;
                    WriteErr();
                    return null;
                }
                return GetPatientInfoBySQL(strSql);
            }
            else
            {
                return null;
            }
        }

		[Obsolete("更改为QueryPatientInfoByName",true)]
		public ArrayList PatientNameQuery(string PatientName)
		{
			return null;
		}
		#endregion
		
		#region 按姓名获得患者信息列表1	

		/// <summary>
		/// 获得住院流水号从姓名
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[Obsolete("更改为 QueryInpatientNOByName",true)]
		public ArrayList QueryInpatientNoFromName(string name)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.QeryInpatientNoFromPatientNo.3", ref strSql) == 0)
			{
				#region SQL
				/*
				 * select inpatient_no,name,in_state,DEPT_CODE,dept_name,in_date 
				 * from fin_ipr_inmaininfo  where  PARENT_CODE='[父级编码]'	
				 * and	CURRENT_CODE='[本级编码]' 
				 * and  name='{0}'
				*/
				#endregion
				try
				{
					strSql = string.Format(strSql, name);
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					WriteErr();
					return null;
				}
				return GetPatientInfoBySQL(strSql);
			}
			else
			{
				return null;
			}
		}
		

		#endregion

		#region 按住院状态查询患者信息列表

		/// <summary>
		/// 患者查询-按住院状态查
		/// </summary>
		/// <param name="State">住院状态</param>
		/// <returns></returns>
        public ArrayList QueryPatient(Neusoft.HISFC.Models.Base.EnumInState State)
		{
			#region 接口说明

			/////RADT.Inpatient.4
			//传入：住院状态
			//传出：患者信息

			#endregion

			ArrayList al = new ArrayList();
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			
			sql1 = PatientQuerySelect();
			
			if (sql1 == null)
			{
				return null;
			}

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.9", ref sql2) == -1)
			{
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, State.ToString());
			return myPatientQuery(sql1);
		}

		#endregion

        #region {FF8C2D27-9ED0-4c4d-B3A0-D801BEF29626}优化病案综合查询

        /// <summary>
        /// 通过where条件查找记录
        /// </summary>
        /// <param name="strSqlWhere"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByWhere(string strSqlWhere)
        {

            ArrayList al = new ArrayList();

            string sql1 = PatientQuerySelect();

            if (sql1 == null)
            {
                return null;
            }
            
            return myPatientQuery(sql1 + " " + strSqlWhere);
        }

        #endregion

		#region 按入院时间查询患者信息列表

		/// <summary>
		/// 患者查询--按入院时间查询 wangrc
		/// </summary>
		/// <param name="beginDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <returns></returns>
        public ArrayList QueryPatient(DateTime beginDateTime, DateTime endDateTime)
		{
			#region 接口说明

			/////RADT.Inpatient.2
			//传入:住院时间开始，结束
			//传出：患者信息

			#endregion

			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null) return null;

			string[] arg = new string[2];
			arg[0] = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			arg[1] = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);

			if (Sql.GetSql("RADT.Inpatient.PatientQueryByDateIn", ref sql2) == -1)
			{
				Err = "没有找到RADT.Inpatient.PatientQuery.Where.8字段!";
				ErrCode = "-1";
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, arg);
			return myPatientQuery(sql1);
		}

		#endregion

		#region 按入院时间和状态查询患者信息列表

		/// <summary>
		/// 患者查询-按入院时间和状态查
		/// </summary>
		/// <param name="beginDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <param name="State"></param>
		/// <returns></returns>
        public ArrayList QueryPatient(DateTime beginDateTime, DateTime endDateTime, Neusoft.HISFC.Models.Base.EnumInState State)
		{
			#region 接口说明

			/////RADT.Inpatient.2
			//传入:住院时间开始，结束，状态
			//传出：患者信息

			#endregion

			string sql1 = string.Empty;
			string sql2 = string.Empty;
			sql1 = PatientQuerySelect();
			if (sql1 == null)
			{
				return null;
			}

			string[] arg = new string[3];
			arg[0] = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			arg[1] = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			arg[2] = State.ToString();
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.8", ref sql2) == -1)
			{
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, arg);
			return myPatientQuery(sql1);
		}

		#endregion

	

		#region 根据 入院时间,病人状态 ,科室 查询医保看病患者基本信息

		/// <summary>
		///  入院时间,病人状态 ,科室 查询医保 患者
		/// </summary>
		/// <param name="beginDateTime">入院开始时间</param>
		/// <param name="endDateTime">入院结束时间</param>
		/// <param name="inState">病人状态</param>
		/// <param name="deptCode">科室编码</param>
		/// <param name="pactCode">合同单位编码</param>
		/// <returns>符合条件的数据集</returns>
		/// creator zhangjunyi@Neusoft.com
        public ArrayList QueryMedicarePatientBasic(DateTime beginDateTime, DateTime endDateTime, Neusoft.HISFC.Models.Base.EnumInState inState, string deptCode, string pactCode)
		{
			//定义字符串 存储SQL语句
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			
			string beginTime = string.Empty;
			string endTime = string.Empty;
			//获取 查询基本信息 SQL语句 
			sql1 = PatientQueryBasicSelect();
			
			if (sql1 == null)
			{
				return null;
			}

			beginTime = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			endTime = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			

			//获取 查询条件 
			if (Sql.GetSql("RADT.Inpatient.PatientQueryMedicare", ref sql2) == -1)
			{
				return null;
			}
			//组建查询SQL语句 
			sql1 = sql1 + " " + string.Format(sql2, beginTime,endTime,inState.ToString(),deptCode,pactCode);
			
			return myPatientBasicQuery(sql1);
		}

		#endregion

		#region 查询未提交病案登记的患者信息列表

		/// <summary>
		/// 查询未提交病案登记的患者信息
		/// </summary>
		/// <param name="caseFlag">患者得提交状态</param>
		/// <returns></returns>
		[Obsolete("过期，该函数有问题！",true)]
		public ArrayList PatientsHavingCase(string caseFlag)
		{
			string strSQLSelect = string.Empty;
			string strSQLWhere = string.Empty;

			strSQLSelect = PatientQuerySelect();

			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.10", ref strSQLWhere) == -1)
				#region SQL
				/* where PARENT_CODE='[父级编码]' and C
				 * URRENT_CODE='[本级编码]' 
				 * and CASESEND_FLAG = '0' 
				 * and In_state = '{0}' 
				 * and CASE_FLAG <>'0' 
				*/
				#endregion
			{
				return null;
			}
			try
			{
				strSQLSelect += " " + string.Format(strSQLWhere, caseFlag);
			}
			catch
			{
				Err = "RADT.Inpatient.PatientQuery.Where.10 赋值不匹配！";
				ErrCode = "RADT.Inpatient.PatientQuery.Where.10 赋值不匹配！";
				WriteErr();
				return null;
			}

			return myPatientQuery(strSQLSelect);
		}

		#endregion

		#region 按病区和状态（转入、转出）查询患者信息列表

		/// <summary>
		/// 患者查询-查询病区的转入患者
		/// </summary>
        /// <param name="deptCode">科室编码</param>
		/// <param name="status">状态 1 申请 2 确认</param>
		/// <returns>患者信息</returns>
		public ArrayList QueryPatientShiftInApply(string deptCode, string status)
		{
			ArrayList al = new ArrayList();
			string sql1 = string.Empty; 
			string sql2 = string.Empty;
			
			sql1 = PatientQuerySelect();
			
			if (sql1 == null)
			{
				return null;
			}
			
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.1", ref sql2) == -1)
			{
				#region SQL
				/*
				 *where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' 
				 and inpatient_no in 
				 (select inpatient_no from fin_ipr_shiftapply where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and new_dept_code = '{0}' and shift_state = '{1}') 
				 and in_state = 'I' */
				#endregion
				return null;
			}
            sql2 = " " + string.Format(sql2, deptCode, status);
			return myPatientQuery(sql1 + sql2);
		}

        /// <summary>
        /// 患者查询-查询病区的转入患者
        /// </summary>
        /// <param name="deptCode">病区编码</param>
        /// <param name="status">状态 1 申请 2 确认</param>
        /// <returns>患者信息</returns>
        public ArrayList QueryPatientShiftInApplyByNurseCell(string deptCode, string status)
        {
            ArrayList al = new ArrayList();
            string sql1 = string.Empty;
            string sql2 = string.Empty;

            sql1 = PatientQuerySelect();

            if (sql1 == null)
            {
                return null;
            }

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.ShiftNurseCell.Where.1", ref sql2) == -1)
            {
                #region SQL
                /*
				 *where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' 
				 and inpatient_no in 
				 (select inpatient_no from fin_ipr_shiftapply where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and new_dept_code = '{0}' and shift_state = '{1}') 
				 and in_state = 'I' */
                #endregion
                return null;
            }
            sql2 = " " + string.Format(sql2, deptCode, status);
            return myPatientQuery(sql1 + sql2);
        }

		[Obsolete("更改为 QueryPatientShiftInApply",true)]
		public ArrayList PatientQueryShiftInApply(string locationID, string status)
		{
			return null;
		}
		#endregion

		#region

		/// <summary>
		/// 获得需要确认的急诊留观科室患者列表
		/// </summary>
		/// <returns></returns>
		public ArrayList QueryShiftOutPatientNeedConfirm(string state)
		{
			string strSql = string.Empty;
			ArrayList al = new ArrayList();
			
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.ShiftOutPatientNeedConfirm", ref strSql) == -1)
			{
				return null;
			}
			strSql = String.Format(strSql, state);
			if (ExecQuery(strSql) == -1)
			{
				return null;
			}
			while (Reader.Read())
			{
				NeuObject obj = new NeuObject();
				obj.ID = Reader[0].ToString(); //住院流水号
				obj.Name = Reader[1].ToString(); //原科室代码
				obj.Memo = Reader[2].ToString(); //原科室名称
				obj.User01 = Reader[3].ToString(); //目标科室代码
				obj.User02 = Reader[4].ToString(); //目标科室名称
				al.Add(obj);
			}
			Reader.Close();
			return al;
		}

		#endregion

		#region 查询病区转出患者信息列表

		/// <summary>
		/// 患者查询-查询病区的转出患者
		/// </summary>
        /// <param name="deptCode">转出科室编码</param>
		/// <param name="status">转入转出状态</param>
		/// <returns>转出患者信息</returns>
        public ArrayList QueryPatientShiftOutApply(string deptCode, string status)
		{
			ArrayList al = new ArrayList();
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			
			sql1 = PatientQuerySelect();
			
			if (sql1 == null)
			{
				return null;
			}
			
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.2", ref sql2) == -1)
				#region SQL
				/* where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' 
				 * and inpatient_no in 
				 * (select inpatient_no from fin_ipr_shiftapply where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and old_dept_code = '{0}' and shift_state = '{1}') 
				 * and in_state = 'I'*/
				#endregion
			{
				return null;
			}
            sql2 = " " + string.Format(sql2, deptCode, status);
			return myPatientQuery(sql1 + sql2);
		}
        /// <summary>
        /// 患者查询-查询病区的转出患者
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ArrayList QueryPatientShiftOutApplyByNurseCell(string deptCode, string status)
        {
            ArrayList al = new ArrayList();
            string sql1 = string.Empty;
            string sql2 = string.Empty;

            sql1 = PatientQuerySelect();

            if (sql1 == null)
            {
                return null;
            }

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.99", ref sql2) == -1)
            #region SQL
           
            #endregion
            {
                return null;
            }
            sql2 = " " + string.Format(sql2, deptCode, status);
            return myPatientQuery(sql1 + sql2);
        }
		
		[Obsolete("更改为 QueryPatientShiftOutApply",true)]
		public ArrayList PatientQueryShiftOutApply(string locationID, string status)
		{
			return null;
		}
		#endregion

		#region 查询医生分管患者信息列表

		/// <summary>
		/// 患者查询-查询医生分管患者，分管患者分给住院医生
		/// </summary>
		/// <param name="objOpertor">医生编码</param>
		/// <param name="State">住院状态</param>
		/// <returns>患者信息列表</returns>
		public ArrayList QueryHouseDocPatient(NeuObject objOpertor, Neusoft.HISFC.Models.Base.EnumInState State, string deptCode)
		{
			ArrayList al = new ArrayList();
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			
			sql1 = PatientQuerySelect();
			if (sql1 == null)
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.3", ref sql2) == -1)
				#region SQL
				/* where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and house_doc_code = '{0}' and in_state ='{1}' and dept_code = '{2}'*/
				#endregion
			{
				return null;
			}
			sql2 =sql1 + " " + string.Format(sql2, objOpertor.ID, State.ToString(), deptCode);
			
			return myPatientQuery(sql2);
		}
		[Obsolete("更改为 QueryHouseDocPatient",true)]
		public ArrayList PatientQueryHouseDoc(NeuObject objOpertor, InStateEnumService State, string deptCode)
		{
			return null;
		}
		#endregion

		#region 查询医生会诊患者信息列表

		/// <summary>
		/// 患者查询-查询医生会诊患者
		/// </summary>
		/// <param name="objOpertor"></param>
		/// <param name="status">1 申请 2 确认</param>
		/// <param name="beginDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <returns></returns>
		public ArrayList PatientQueryConsultation(NeuObject objOpertor, string status, DateTime beginDateTime,DateTime endDateTime, string deptID)
		{
			ArrayList al = new ArrayList();
			
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			string sql3 = string.Empty;
			
			sql1 = PatientQuerySelect();
			if (sql1 == null)
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.4", ref sql2) == -1)
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.15", ref sql3) == -1)
			{
				return null;
			}
			
			string beginTime = string.Empty;;
			string endTime = string.Empty;
			beginTime = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			endTime = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			
			sql2 = " " + string.Format(sql2, objOpertor.ID, status, beginTime, endTime);
			al = myPatientQuery(sql1 + sql2);
			status = "1";
			sql3 = " " + string.Format(sql3, deptID, status, beginTime, endTime);
			
			al.AddRange(myPatientQuery(sql1 + sql3));
			
			return al;
		}

		/// <summary>
		/// 查询医生自己的会诊患者
		/// </summary>
		/// <param name="objOpertor">医生编码</param>
		/// <param name="status">状态</param>
		/// <param name="beginDateTime">处方起始时间</param>
		/// <param name="endDateTime">处方终止时间</param>
		/// <returns>患者信息</returns>
		public ArrayList QueryConsultationPatientInfo(NeuObject objOpertor, string status, DateTime beginDateTime,DateTime endDateTime)
		{
			ArrayList al = new ArrayList();
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			string sql3 = string.Empty;
			
			sql1 = PatientQuerySelect();
			
			if (sql1 == null)
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.4", ref sql2) == -1)
				#region SQL
				/* where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and inpatient_no in 
				 * (select inpatient_no from	MET_IPM_CONSULTATION  where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and cnsl_doccd = '{0}' and CNSL_KIND	= '{1}' and sysdate>=MO_STDT and sysdate<=MO_EDDT )
				 */
				#endregion
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.15", ref sql3) == -1)
				#region SQL
				/*where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and inpatient_no in 
				 * (select inpatient_no from	MET_IPM_CONSULTATION  where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and cnsl_deptcd = '{0}' and CNSL_KIND	= '{1}' and sysdate>=MO_STDT and sysdate<=MO_EDDT )
				 */
				#endregion
			{
				return null;
			}
			string[] arg = new string[2];
			
			string beginTime = string.Empty;
			string endTime = string.Empty;
			
			beginTime = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			endTime = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			
			sql2 = " " + string.Format(sql2, objOpertor.ID, status, beginTime, endTime);
			
			al = myPatientQuery(sql1 + sql2);
			return al;
		}
		[Obsolete("更改为 QueryConsultationPatientInfo",true)]
		public ArrayList PatientQueryConsultation(NeuObject objOpertor, string Status, DateTime beginDateTime,DateTime endDateTime)
		{
			return null;
		}
		#endregion

		#region 查询医生授权患者信息列表

		/// <summary>
		/// 查询授权的患者 met_ipm_permission
		/// </summary>
		/// <param name="strDoc">医生代码</param>
		/// <returns>患者信息</returns>
        public ArrayList QueryPatientByPermission(string strDoc)
		{
			ArrayList al = new ArrayList();
			string strsql1 = string.Empty;
			string strsql2 = string.Empty;
			
			strsql1 = PatientQuerySelect();
			
			if (strsql1 == null)
			{
				return null;
			}
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.30", ref strsql2) == -1)
				#region SQL
				/*
				 *where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and inpatient_no in 
				 (select inpatient_no from	 met_ipm_permission where  PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and valid_flag ='0'  and DOC_CODE ='{0}' and sysdate>=mo_stdt and sysdate <= mo_eddt)
				 */
				#endregion
			{
				return null;
			}

			strsql2 = " " + string.Format(strsql2, strDoc);
			string strSql = string.Empty;

			strSql = strsql1 + strsql2;
			return myPatientQuery(strSql);
		}

        [Obsolete("用 QueryPatientByPermission(string strDoc) 代替了的说", true)]
        public ArrayList PatientQueryByPermission(string strDoc)
        {
            return null;
        }
		#endregion
        #region 根据医保卡号查询住院患者信息
        /// <summary>
        /// 根据医保卡号查询住院患者信息
        /// </summary>
        /// <param name="markNO"></param>
        /// <returns></returns>
        public ArrayList PatientQueryByMcardNO(string markNO)
        {
            #region 接口说明

            //RADT.Inpatient.PatientQuery.where.5
            //传入：病区编码，住院状态
            //传出：患者信息

            #endregion

            ArrayList al = new ArrayList();
            string sql1 = string.Empty, sql2 = string.Empty;
            sql1 = PatientQuerySelect();
            if (sql1 == null)
            {
                return null;
            }

            if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.18", ref sql2) == -1)
            {
                Err = "没有找到RADT.Inpatient.PatientQuery.Where.18字段!";
                ErrCode = "-1";
                WriteErr();
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2,markNO);
            return myPatientQuery(sql1);
        }
        #endregion

        #region "预约登记功能"

        #region 按就诊卡号查询预约信息列表

        /// <summary>
		///  预约信息查询--wangrc
		/// </summary>
		/// <param name="CardNO">就诊卡号</param>
		/// <returns>大于1成功 -1失败</returns>
		private ArrayList GetPreInByCardNO(string CardNO)
		{
			string strSql = string.Empty;
			string strSqlWhere = string.Empty;
			
			strSql = GetSqlForPrepayin();
			if (Sql.GetSql("RADT.Inpatient.PrepayInQuery.1", ref strSqlWhere) == -1)
			{
				#region SQL
				/*   
					WHERE  PARENT_CODE='[父级编码]'  and 
					CURRENT_CODE='[本级编码]' and 
					card_no='{0}'
				 */
				#endregion
				return null;
			}
			strSql = strSql + strSqlWhere;
			try
			{
				strSql = string.Format(strSql, CardNO);
			}
			catch (Exception ex)
			{
				ErrCode = ex.Message;
				Err = ex.Message;
				return null;
			}
			return GetPreInpatientInfo(strSql);
		}
		[System.Obsolete("更改为GetPreInByCardNO",true)]
		public ArrayList GetPrepayInByCardNo(string CardNO)
		{
			string strSql = string.Empty;
			string strSqlWhere = string.Empty;
			
			strSql = GetSqlForPrepayin();
			if (Sql.GetSql("RADT.Inpatient.PrepayInQuery.1", ref strSqlWhere) == -1)
			{
				#region SQL
				/*   
					WHERE  PARENT_CODE='[父级编码]'  and 
					CURRENT_CODE='[本级编码]' and 
					card_no='{0}'
				 */
				#endregion
				return null;
			}
			strSql = strSql + strSqlWhere;
			try
			{
				strSql = string.Format(strSql, CardNO);
			}
			catch (Exception ex)
			{
				ErrCode = ex.Message;
				Err = ex.Message;
				WriteErr();
				return null;
			}
			return GetPreInpatientInfo(strSql);
		}
        #endregion
		
		#region 按就诊卡号查询预约床号
		/// <summary>
		/// 按就诊卡号查询预约床号--wangrc
		/// </summary>
		/// <param name="CardNO">门诊卡号</param>
		/// <returns>-1失败1成功</returns>
		public string QueryPreInPatientBedNO(string CardNO)
		{
			string sql = string.Empty;
			string bedNO = string.Empty;
			
			if (Sql.GetSql("RADT.InPatient.PrepayInBedNoQuery", ref sql) == -1)
			{
				return null;
			}
			sql = string.Format(sql, CardNO);
			
			if (ExecQuery(sql) <= 0)
			{
				return null;
			}
			if (Reader.Read())
			{
				try
				{
					bedNO = Reader[0].ToString(); //床号
				}

				catch (Exception ex)
				{
					Err = ex.Message;
					WriteErr();
					if (!Reader.IsClosed)
					{
						Reader.Close();
					}
				}
			}
			Reader.Close();
			
			return bedNO;
		}
		[Obsolete("更改为 QueryPreInPatientBedNO",true)]
		public string PrepayInBedNoQuery(string CardNO)
		{
			return null;
		}
	    #endregion
		#region  "无条件查询预约登记表"

		/// <summary>
		/// 无条件查询预约登记表---wangrc
		/// </summary>
		/// <returns>string sql</returns>
		private string GetSqlForPrepayin()
		{
			//检索预约登记表的sql
			string strSql = string.Empty;
			
			if (Sql.GetSql("RADT.Inpatient.GetSqlForPrepayin", ref strSql) == -1)
			{
				#region SQL
				/* 索引值  RADT.Inpatient.GetSqlForPrepayin
				   SELECT card_no,
								   happen_no,   --发生序号
								   name,   --姓名
								   sex_code,   --性别
								   idenno,   --身份证号
								   birthday,   --生日
								   mcard_no,   --医疗证号
								   paykind_code,   --结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
								   pact_code,   --合同单位
								   bed_no,   --床号
								   nurse_cell_code,   --护士站代码
								   prof_code,   --职务
								   work_name,   --工作单位
								   work_tel,   --工作单位电话
								   home,   --家庭住址
								   home_tel,   --家庭电话
								   dist,   --籍贯
								   birth_area,   --出生地
								   nation_code,   --民族
								   linkma_name,   --联系人
								   linkman_tel,   --联系人电话
								   linkman_add,   --联系人地址
								   rela_code,   --联系人关系
								   mari,   --婚姻状况
								   coun_code,   --国籍
								   diag_code,   --诊断代码
								   diag_name,   --诊断名称
								   dept_code,   --预约科室
								   dept_name,   --科室名称
								   predoct_code,   --预约医师
								   pre_state,   --状态
								   pre_date,   --预约日期
								   oper_code,   --操作员
								   oper_date    --操作日期
							  FROM fin_ipr_prepayin   --住院预约表
				 */
				#endregion
				return null;
				
			}
			return strSql;
		}
	     #endregion
		#region "按传入的sql语句查询预约登记表"

		/// <summary>
		/// 按传入的sql语句查询预约登记表
		/// </summary>
		/// <param name="strSql">sql语句</param>
		/// <returns>数组 实体为patientinfo</returns>
		private ArrayList GetPreInpatientInfo(string strSql)
		{
			ArrayList al = new ArrayList();
			PatientInfo PatientInfo;
			if (ExecQuery(strSql) == -1) return null;

			while (Reader.Read())
			{
				PatientInfo = new PatientInfo();
				try
				{
					if (!Reader.IsDBNull(0)) PatientInfo.PID.CardNO = Reader[0].ToString(); //就诊卡号
					if (!Reader.IsDBNull(1)) PatientInfo.User01 = Reader[1].ToString(); //发生序号
					if (!Reader.IsDBNull(2)) PatientInfo.Name = Reader[2].ToString(); //姓名
					if (!Reader.IsDBNull(3)) PatientInfo.Sex.ID = Reader[3].ToString(); //性别
					if (!Reader.IsDBNull(4)) PatientInfo.IDCard = Reader[4].ToString(); //身份证号
					if (!Reader.IsDBNull(5)) PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5].ToString()); //生日
					if (!Reader.IsDBNull(6)) PatientInfo.SSN = Reader[6].ToString(); //医疗证号
					if (!Reader.IsDBNull(7)) PatientInfo.Pact.PayKind.ID = Reader[7].ToString(); //结算类别
					if (!Reader.IsDBNull(8)) PatientInfo.Pact.ID = Reader[8].ToString(); //合同单位
					if (!Reader.IsDBNull(9)) PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[9].ToString(); //床号
					if (!Reader.IsDBNull(10)) PatientInfo.PVisit.PatientLocation.NurseCell.ID = Reader[10].ToString(); //护士站代码
					if (!Reader.IsDBNull(11)) PatientInfo.Profession.ID = Reader[11].ToString(); //职务
					if (!Reader.IsDBNull(12)) PatientInfo.CompanyName = Reader[12].ToString(); //工作单位
					if (!Reader.IsDBNull(13)) PatientInfo.PhoneBusiness = Reader[13].ToString(); //工作单位电话
					if (!Reader.IsDBNull(14)) PatientInfo.AddressHome = Reader[14].ToString(); //家庭住址
					if (!Reader.IsDBNull(15)) PatientInfo.PhoneHome = Reader[15].ToString(); //家庭电话
					if (!Reader.IsDBNull(16)) PatientInfo.DIST = Reader[16].ToString(); //籍贯
					if (!Reader.IsDBNull(17)) PatientInfo.AreaCode = Reader[17].ToString(); //出生地
					if (!Reader.IsDBNull(18)) PatientInfo.Nationality.ID = Reader[18].ToString(); //民族
					if (!Reader.IsDBNull(19)) PatientInfo.Kin.ID = Reader[19].ToString(); //联系人
					if (!Reader.IsDBNull(20)) PatientInfo.Kin.RelationPhone = Reader[20].ToString(); //联系人电话
					if (!Reader.IsDBNull(21)) PatientInfo.Kin.RelationAddress = Reader[21].ToString(); //联系人地址
					if (!Reader.IsDBNull(22)) PatientInfo.Kin.Relation.ID = Reader[22].ToString(); //联系人关系
					if (!Reader.IsDBNull(23)) PatientInfo.MaritalStatus.ID = Reader[23].ToString(); //婚姻状况
					if (!Reader.IsDBNull(24)) PatientInfo.Country.ID = Reader[24].ToString(); //国籍
                    if (!this.Reader.IsDBNull(25))
                    {
                        NeuObject obj=new NeuObject();
                        obj.ID=this.Reader[25].ToString();
                        PatientInfo.Diagnoses.Add(obj);
                    }
                    //if (!this.Reader.IsDBNull(25)) PatientInfo.Diagnoses = this.Reader[25].ToString();//诊断代码
                    if (!this.Reader.IsDBNull(26)) PatientInfo.ClinicDiagnose = this.Reader[26].ToString();//诊断名称
					if (!Reader.IsDBNull(27)) PatientInfo.PVisit.PatientLocation.Dept.ID = Reader[27].ToString(); //预约科室
					if (!Reader.IsDBNull(28)) PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[28].ToString(); //科室名称
					if (!Reader.IsDBNull(29)) PatientInfo.PVisit.AdmittingDoctor.ID = Reader[29].ToString(); //预约医师
					if (!Reader.IsDBNull(30)) PatientInfo.User02 = Reader[30].ToString(); //状态
					if (!Reader.IsDBNull(31)) PatientInfo.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[31].ToString()); //预约日期
					if (!Reader.IsDBNull(32) && !Reader.IsDBNull(33))
						PatientInfo.User03 = Reader[32].ToString() + Reader[33].ToString(); //操作员、操作时间
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					if (!Reader.IsClosed)
					{
						Reader.Close();
					}
					return null;
				}
				al.Add(PatientInfo);
			}
			Reader.Close();
			return al;
		}
		[System.Obsolete("更改为 GetPreInpatientInfo ",true)]
		private ArrayList GetPrepayInAllData(string strSql)
		{
			return null;
		}
		#endregion

		#region "按传入的sql语句查询预约登记表根据发生序号返回实体"

		/// <summary>
		/// 返回实体按发生序号
		/// </summary>
		/// <param name="strSql">sql语句</param>
		/// <returns>实体patientinfo</returns>
		[Obsolete("无用",true)]
		private PatientInfo GetPrepayInAllDataByNo(string strSql)
		{
			PatientInfo PatientInfo = null;
			
			if (ExecQuery(strSql) == -1)
			{
				return null;
			}

			if (Reader.Read())
			{
				PatientInfo = new PatientInfo();
				try
				{
					if (!Reader.IsDBNull(0)) PatientInfo.PID.CardNO = Reader[0].ToString(); //就诊卡号
					if (!Reader.IsDBNull(1)) PatientInfo.User01 = Reader[1].ToString(); //发生序号
					if (!Reader.IsDBNull(2)) PatientInfo.Name = Reader[2].ToString(); //姓名
					if (!Reader.IsDBNull(3)) PatientInfo.Sex.ID = Reader[3].ToString(); //性别
					if (!Reader.IsDBNull(4)) PatientInfo.IDCard = Reader[4].ToString(); //身份证号
					if (!Reader.IsDBNull(5)) PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[5].ToString()); //生日
					if (!Reader.IsDBNull(6)) PatientInfo.SSN = Reader[6].ToString(); //医疗证号
					if (!Reader.IsDBNull(7)) PatientInfo.Pact.PayKind.ID = Reader[7].ToString(); //结算类别
					if (!Reader.IsDBNull(8)) PatientInfo.Pact.ID = Reader[8].ToString(); //合同单位
					if (!Reader.IsDBNull(9)) PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[9].ToString(); //床号
					if (!Reader.IsDBNull(10)) PatientInfo.PVisit.PatientLocation.NurseCell.ID = Reader[10].ToString(); //护士站代码
					if (!Reader.IsDBNull(11)) PatientInfo.Profession.ID = Reader[11].ToString(); //职务
					if (!Reader.IsDBNull(12)) PatientInfo.CompanyName = Reader[12].ToString(); //工作单位
					if (!Reader.IsDBNull(13)) PatientInfo.PhoneBusiness = Reader[13].ToString(); //工作单位电话
					if (!Reader.IsDBNull(14)) PatientInfo.AddressHome = Reader[14].ToString(); //家庭住址
					if (!Reader.IsDBNull(15)) PatientInfo.PhoneHome = Reader[15].ToString(); //家庭电话
					if (!Reader.IsDBNull(16)) PatientInfo.DIST = Reader[16].ToString(); //籍贯
					if (!Reader.IsDBNull(17)) PatientInfo.AreaCode = Reader[17].ToString(); //出生地
					if (!Reader.IsDBNull(18)) PatientInfo.Nationality.ID = Reader[18].ToString(); //民族
					if (!Reader.IsDBNull(19)) PatientInfo.Kin.ID = Reader[19].ToString(); //联系人
					if (!Reader.IsDBNull(20)) PatientInfo.Kin.RelationPhone = Reader[20].ToString(); //联系人电话
					if (!Reader.IsDBNull(21)) PatientInfo.Kin.RelationAddress = Reader[21].ToString(); //联系人地址
					if (!Reader.IsDBNull(22)) PatientInfo.Kin.Relation.ID = Reader[22].ToString(); //联系人关系
					if (!Reader.IsDBNull(23)) PatientInfo.MaritalStatus.ID = Reader[23].ToString(); //婚姻状况
					if (!Reader.IsDBNull(24)) PatientInfo.Country.ID = Reader[24].ToString(); //国籍
					//						if (!this.Reader.IsDBNull(25)) PatientInfo.Diagnoses=this.Reader[25].ToString();//诊断代码
					//						if (!this.Reader.IsDBNull(26)) PatientInfo.Diagnoses=this.Reader[26].ToString();//诊断名称
					if (!Reader.IsDBNull(27)) PatientInfo.PVisit.PatientLocation.Dept.ID = Reader[27].ToString(); //预约科室
					if (!Reader.IsDBNull(28)) PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[28].ToString(); //科室名称
					if (!Reader.IsDBNull(29)) PatientInfo.PVisit.AdmittingDoctor.ID = Reader[29].ToString(); //预约医师
					if (!Reader.IsDBNull(30)) PatientInfo.User02 = Reader[30].ToString(); //状态
					if (!Reader.IsDBNull(31)) PatientInfo.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[31].ToString()); //预约日期
					if (!Reader.IsDBNull(32) && !Reader.IsDBNull(33))
						PatientInfo.User03 = Reader[32].ToString() + Reader[33].ToString(); //操作员、操作时间
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					if (!Reader.IsClosed)
					{
						Reader.Close();
					}
					return null;
				}
			}

			return PatientInfo;
		}

		#endregion

		#region 插入预约入院登记表

		/// <summary>
		/// 插入预约入院登记患者-基本信息
		/// </summary>
		/// <param name="PatientInfo"></param>
		/// <returns>大于 0 成功 小于 0 失败</returns>
		public int InsertPreInPatient(PatientInfo PatientInfo)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.PrepayInPatient.1", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				#region SQL
				/*
				 *  INSERT INTO fin_ipr_prepayin   --住院预约表

							          ( parent_code,   --父级医疗机构编码
							            current_code,   --本级医疗机构编码
							            card_no,   --就诊卡号
							            happen_no,   --发生序号
							            name,   --姓名
							            sex_code,   --性别
							            idenno,   --身份证号
							            birthday,   --生日
							            mcard_no,   --医疗证号
							            paykind_code,   --结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
							            pact_code,   --合同单位
							            bed_no,   --床号
							            nurse_cell_code,   --护士站代码

							            prof_code,   --职务
							            work_name,   --工作单位
							            work_tel,   --工作单位电话
							            home,   --家庭住址
							            home_tel,   --家庭电话
							            dist,   --籍贯
							            birth_area,   --出生地

							            nation_code,   --民族
							            linkma_name,   --联系人

							            linkman_tel,   --联系人电话

							            linkman_add,   --联系人地址
							            rela_code,   --联系人关系

							            mari,   --婚姻状况
							            coun_code,   --国籍
							            diag_code,   --诊断代码
							            diag_name,   --诊断名称
							            dept_code,   --预约科室
							            dept_name,   --科室名称
							            predoct_code,   --预约医师
							            pre_state,   --状态

							            pre_date,   --预约日期
							            oper_code,   --操作员

							            oper_date )  --操作日期
							     VALUES 
							          ( '[父级编码]',   --父级医疗机构编码
							            '[本级编码]',   --本级医疗机构编码
							            '{0}',   --就诊卡号
							            (select NVL(MAX(happen_no),0)+1 from fin_ipr_prepayin where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编	码]' 	and 	card_no='{0}'),   --发生序号
							            '{2}',   --姓名
							            '{3}',   --性别
							            '{4}',   --身份证号
							            to_date('{5}','yyyy-mm-dd HH24:mi:ss'),   --生日
							            '{6}',   --医疗证号
							            '{7}',   --结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
							            '{8}',   --合同单位
							            '{9}',   --床号
							            '{10}',   --护士站代码

							            '{11}',   --职务
							            '{12}',   --工作单位
							            '{13}',   --工作单位电话
							            '{14}',   --家庭住址
							            '{15}',   --家庭电话
							            '{16}',   --籍贯
							            '{17}',   --出生地

							            '{18}',   --民族
							            '{19}',   --联系人

							            '{20}',   --联系人电话

							            '{21}',   --联系人地址
							            '{22}',   --联系人关系

							            '{23}',   --婚姻状况
							            '{24}',   --国籍
							            '{25}',   --诊断代码
							            '{26}',   --诊断名称
							            '{27}',   --预约科室
							            '{28}',   --科室名称
							            '{29}',   --预约医师
							            '{30}',   --状态

							            to_date('{31}','yyyy-mm-dd HH24:mi:ss'),   --预约日期
							            '{32}',   --操作员

							            sysdate )
			*/
				#endregion
				string[] s = new string[34];
				try
				{
					s[0] = PatientInfo.PID.CardNO; //就诊卡号
					s[2] = PatientInfo.Name; //姓名
					s[3] = PatientInfo.Sex.ID.ToString(); //性别
					s[4] = PatientInfo.IDCard; //身份证号
					s[5] = PatientInfo.Birthday.ToString(); //生日
					s[6] = PatientInfo.SSN; //医疗证号
					s[7] = PatientInfo.Pact.PayKind.ID; //结算类别
					s[8] = PatientInfo.Pact.ID; //合同单位
					s[9] = PatientInfo.PVisit.PatientLocation.Bed.ID; //床号
					s[10] = PatientInfo.PVisit.PatientLocation.NurseCell.ID; //护士站代码
					s[11] = PatientInfo.Profession.ID; //职务
					s[12] = PatientInfo.CompanyName; //工作单位
					s[13] = PatientInfo.PhoneBusiness; //工作单位电话
					s[14] = PatientInfo.AddressHome; //家庭住址
					s[15] = PatientInfo.PhoneHome; //家庭电话
					s[16] = PatientInfo.DIST; //籍贯
					s[17] = PatientInfo.DIST; //出生地
					s[18] = PatientInfo.Nationality.ID; //民族
					s[19] = PatientInfo.Kin.ID; //联系人
					s[20] = PatientInfo.Kin.RelationPhone; //联系人电话
					s[21] = PatientInfo.Kin.RelationAddress; //联系人地址
					s[22] = PatientInfo.Kin.Relation.ID; //联系人关系
					s[23] = PatientInfo.MaritalStatus.ID.ToString(); //婚姻状况
					s[24] = PatientInfo.Country.ID; //国籍
					if (PatientInfo.Diagnoses.Count > 0) s[25] = (PatientInfo.Diagnoses[0] as NeuObject).ID; //诊断代码
					s[26] = PatientInfo.ClinicDiagnose.ToString(); //诊断名称
					s[27] = PatientInfo.PVisit.PatientLocation.Dept.ID; //预约科室
					s[28] = PatientInfo.PVisit.PatientLocation.Dept.Name; //科室名称
					s[29] = PatientInfo.PVisit.AdmittingDoctor.ID; //预约医师
					s[30] = "0"; //状态
					s[31] = PatientInfo.PVisit.InTime.ToString(); //预约日期
					s[32] = Operator.ID; //操作员
					s[33] = GetSysDateTime().ToString(); //操作日期
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					WriteErr();
				}

				strSql = string.Format(strSql, s);
                return ExecNoQuery(strSql);
			}
			catch (Exception ex)
			{
				Err = "赋值时候出错！" + ex.Message;
				WriteErr();
				return -1;
			}
			
		}

		[Obsolete("更改为 InsertPreInPatient",true)]
		public int PrepayInPatient(PatientInfo PatientInfo)
		{
			return 0;
		}
		#endregion

        //修改人：路志鹏 时间：2007-4-19 
        //目的：患者可以预约多次，根据门诊号 发生序号更新预约状态 0 为预约 1 为作废 2转入院
        /// <summary>
        /// 患者可以预约多次，根据门诊号 发生序号更新预约状态 0 为预约 1 为作废 2转入院
        /// </summary>
        /// <param name="CardNO">门诊卡号</param>
        /// <param name="State">状态</param>
        /// <param name="HappenNO">发生序号</param>
        /// <returns></returns>
        public int UpdatePreInPatientState(string CardNO, string State, string HappenNO)
        {
            string StrSql = string.Empty;
            string strSql = string.Empty;
            if (Sql.GetSql("RADT.InPatient.UpdatePrepayinState.2", ref strSql) == -1)
            {
                return -1;
            }
            try
            {
                //卡号 状态 操作员  发生序号
                strSql = string.Format(strSql, CardNO, State, Operator.ID, HappenNO);
                return ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                ErrCode = ex.Message;
                WriteErr();
                return -1;
            }
        }

		/// <summary>
		/// 更新预约状态 0 为预约 1 为作废 2转入院
		/// </summary>
		/// <param name="cardNO">门诊卡号</param>
		/// <param name="State">状态</param>
		/// <returns></returns>
		public int UpdatePreInPatientState(string cardNO, string State)
		{
			string strSql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.UpdatePrepayinState.1", ref strSql) == -1)
			{
				return -1;
			}
			try
			{
				//卡号 状态 操作员
				strSql = string.Format(strSql, cardNO, State, Operator.ID);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return -1;
			}
			return ExecNoQuery(strSql);
		}
		[Obsolete("更改为 UpdatePreInPatientState",true)]
		public int UpdatePrepayinState(string CardNO, string State)
		{
			return 0;
		}
		/// <summary>
		/// 获取预约登记信息通过状态和预约时间
		/// </summary>
		/// <param name="State"></param>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <returns></returns>
		public ArrayList GetPreInPatientInfoByDateAndState(string State, string Begin, string End)
		{
			string strSql = string.Empty;
			string strSqlWhere = string.Empty;
			
			strSql = GetSqlForPrepayin();
			
			if (Sql.GetSql("RADT.Inpatient.GetPrepayInByDateAndState", ref strSqlWhere) == -1)
				#region SQL
				/*WHERE PARENT_CODE='[父级编码]'  and 
					CURRENT_CODE='[本级编码]' and 
					PRE_STATE= '{0}' 
					and pre_date >=to_date('{1}','yyyy-mm-dd HH24:mi:ss') 
				and pre_date <= to_date('{2}','yyyy-mm-dd HH24:mi:ss')*/
				#endregion
			{
				return null;
			}
			strSql = strSql + strSqlWhere;

			try
			{
				strSql = string.Format(strSql, State, Begin, End);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			return GetPreInpatientInfo(strSql);
		}
		[Obsolete("更改为 GetPreInPatientInfoByDateAndState",true)]
		public ArrayList GetPrepayInByDateAndState(string State, string Begin, string End)
		{
			return null;
		}
		/// <summary>
		/// 按发生序号获得登记实体
		/// </summary>
		/// <param name="strNo">发生序号</param>
		/// <param name="cardNO">卡号</param>
		/// <returns></returns>
		public PatientInfo GetPreInPatientInfoByCardNO(string strNo, string cardNO)
		{
			string strSql = string.Empty;
			string strSqlWhere = string.Empty;
			
			strSql = GetSqlForPrepayin();
			
			if (Sql.GetSql("RADT.Inpatient.GetPrepayInByNo", ref strSqlWhere) == -1)
				#region SQL
				/*		WHERE PARENT_CODE='[父级编码]'  and 
						 CURRENT_CODE='[本级编码]' and 
						 happen_no= '{0}'  and 
						 CARD_NO = '{1}'						
				 */
				#endregion
			{
				return null;
			}
			strSql = strSql + strSqlWhere;

			try
			{
				strSql = string.Format(strSql, strNo, cardNO);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			ArrayList al = new ArrayList();
			al = GetPreInpatientInfo(strSql);
			if (al == null)
			{
				return null;
			}
			PatientInfo PatientInfo;
			PatientInfo = (PatientInfo) al[0];
			
			return PatientInfo;
			//			return this.GetPrepayInAllDataByNo(strSql);
		}
		[Obsolete("更改为 GetPreInPatientInfoByCardNO",true)]
		public PatientInfo GetPrepayInByNo(string strNo, string cardNO)
		{
			return null;
		}
		#endregion

		#region 查询在指定科室指定时间内发生过费用的人

		/// <summary>
		/// 获取在指定科室指定时间内发生过费用的人的住院流水号
		/// </summary>
		/// <param name="DeptID"></param>
		/// <param name="BeginTime"></param>
		/// <param name="EndTime"></param>
		/// <returns></returns>
		public ArrayList GetDeptInpatientNo(string DeptID, string BeginTime, string EndTime)
		{
			ArrayList al = new ArrayList();
			string strsql1 = string.Empty;
			
			if (Sql.GetSql("RADT.Inpatient.GetDeptInpatientNo", ref strsql1) == -1)
				#region SQL
				/*
				 * select distinct t.inpatient_no  
					from fin_ipb_feeinfo t  
					where t.feeoper_deptcode = '6400' 
					and t.fee_date >= to_date('2005-7-31 0:00:00','yyyy-mm-dd HH24:mi:ss')  
					and t.fee_date <= to_date('2005-10-13 0:00:00','yyyy-mm-dd HH24:mi:ss') 
				*/
				#endregion
			{
				return null;
			}
			strsql1 = string.Format(strsql1, DeptID, BeginTime, EndTime);
			ExecQuery(strsql1);
			PatientInfo PatientInfo;
			while (Reader.Read())
			{
				PatientInfo = new PatientInfo();
				PatientInfo.ID = Reader[0].ToString();
				PatientInfo.ID = Reader[0].ToString();
				al.Add(PatientInfo);
				PatientInfo = null;
			}
			Reader.Close();
			return al;
		}

		#endregion 

		#region  根据组合的条件查询 患者信息  其中 where 语句部分是 根据查询控件组合出来的

		/// <summary>
		/// 查询病人基本信息 适用于 用组合查询框 生成查询条件的情况。
		/// </summary>
		/// <param name="strWhere"> 传入的where 条件</param>
		/// <returns> 成功返回数组，失败返回null</returns>
		public ArrayList PatientInfoGet(string strWhere)
		{
			//定义要返回的数组
			ArrayList al = new ArrayList();
			try
			{
				//获取检索主SQL语句
				string strSql = PatientQuerySelect();
				strSql = strSql + " " + strWhere;
				//查询患者信息
				al = myPatientQuery(strSql);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				WriteErr();
				return null;
			}
			return al;
		}

		#endregion

		#region 私有

		#region 按传入的Sql语句查询病人信息列表--私有

		/// <summary>
		/// 就诊卡查询
		/// </summary>
		/// <param name="SQLPatient">SQL语句</param>
		/// <returns>返回一条患者卡基本信息</returns>
		private ArrayList myCardPatientQuery(string SQLPatient)
		{
			ArrayList al = new ArrayList();
			PatientInfo PatientInfo;
			ProgressBarText = "正在查询患者...";
			ProgressBarValue = 0;

			ExecQuery(SQLPatient);
			try
			{
				while (Reader.Read())
				{
					PatientInfo = new PatientInfo();
					try
					{
						if (!Reader.IsDBNull(0)) PatientInfo.PID.CardNO = Reader[0].ToString(); //就诊卡号
						if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); //姓名
						if (!Reader.IsDBNull(2)) PatientInfo.SpellCode = Reader[2].ToString(); //拼音码
						if (!Reader.IsDBNull(3)) PatientInfo.WBCode = Reader[3].ToString(); //五笔
						if (!Reader.IsDBNull(4)) PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString()); //出生日期
						if (!Reader.IsDBNull(5)) PatientInfo.Sex.ID = Reader[5].ToString(); //性别
						if (!Reader.IsDBNull(6)) PatientInfo.IDCard = Reader[6].ToString(); //身份证号
						if (!Reader.IsDBNull(7)) PatientInfo.BloodType.ID = Reader[7].ToString(); //血型
						if (!Reader.IsDBNull(8)) PatientInfo.Profession.ID = Reader[8].ToString(); //职业
						if (!Reader.IsDBNull(9)) PatientInfo.CompanyName = Reader[9].ToString(); //工作单位
						if (!Reader.IsDBNull(10)) PatientInfo.PhoneBusiness = Reader[10].ToString(); //单位电话
						if (!Reader.IsDBNull(11)) PatientInfo.BusinessZip = Reader[11].ToString(); //单位邮编
						if (!Reader.IsDBNull(12)) PatientInfo.AddressHome = Reader[12].ToString(); //户口或家庭所在
						if (!Reader.IsDBNull(13)) PatientInfo.PhoneHome = Reader[13].ToString(); //家庭电话
						if (!Reader.IsDBNull(14)) PatientInfo.HomeZip = Reader[14].ToString(); //户口或家庭邮政编码
						if (!Reader.IsDBNull(15)) PatientInfo.DIST = Reader[15].ToString(); //籍贯
						if (!Reader.IsDBNull(16)) PatientInfo.Nationality.ID = Reader[16].ToString(); //民族
						if (!Reader.IsDBNull(17)) PatientInfo.Kin.Name = Reader[17].ToString(); //联系人姓名
						if (!Reader.IsDBNull(18)) PatientInfo.Kin.RelationPhone = Reader[18].ToString(); //联系人电话
						if (!Reader.IsDBNull(19)) PatientInfo.Kin.RelationAddress = Reader[19].ToString(); //联系人住址
						if (!Reader.IsDBNull(20)) PatientInfo.Kin.Relation.ID = Reader[20].ToString(); //联系人关系
						if (!Reader.IsDBNull(21)) PatientInfo.MaritalStatus.ID = Reader[21].ToString(); //婚姻状况
						if (!Reader.IsDBNull(22)) PatientInfo.Country.ID = Reader[22].ToString(); //国籍
						if (!Reader.IsDBNull(23)) PatientInfo.Pact.PayKind.ID = Reader[23].ToString(); //结算类别
						if (!Reader.IsDBNull(24)) PatientInfo.Pact.PayKind.Name = Reader[24].ToString(); //结算类别名称
						if (!Reader.IsDBNull(25)) PatientInfo.Pact.ID = Reader[25].ToString(); //合同代码
						if (!Reader.IsDBNull(26)) PatientInfo.Pact.Name = Reader[26].ToString(); //合同单位名称
						if (!Reader.IsDBNull(27)) PatientInfo.SSN = Reader[27].ToString(); //医疗证号
						if (!Reader.IsDBNull(28)) PatientInfo.AreaCode = Reader[28].ToString(); //地区
						//						if(!this.Reader.IsDBNull(29)) PatientInfo.FT.TotCost=this.Reader[29].ToString();//医疗费用
						//						if(!this.Reader.IsDBNull(30)) PatientInfo.User03 = this.Reader[30].ToString();//电脑号
						//						if(!this.Reader.IsDBNull(31)) PatientInfo.Disease.IsAlleray=System.Convert.ToBoolean(this.Reader[31].ToString());//药物过敏
						//						if(!this.Reader.IsDBNull(32)) PatientInfo.Disease.IsMainDisease=System.Convert.ToBoolean(this.Reader[32].ToString());//重要疾病
						//						if(!this.Reader.IsDBNull(33)) PatientInfo=this.Reader[33].ToString();//帐户密码
						//						if(!this.Reader.IsDBNull(34)) PatientInfo=this.Reader[34].ToString();//帐户总额
						//						if(!this.Reader.IsDBNull(35)) PatientInfo=this.Reader[35].ToString();//上期帐户余额
						//						if(!this.Reader.IsDBNull(36)) PatientInfo=this.Reader[36].ToString();//上期银行余额
						//						if(!this.Reader.IsDBNull(37)) PatientInfo=this.Reader[37].ToString();//欠费次数
						//						if(!this.Reader.IsDBNull(38)) PatientInfo=this.Reader[38].ToString();//欠费金额
						//						if(!this.Reader.IsDBNull(39)) PatientInfo=this.Reader[39].ToString();//住院来源
						//						if(!this.Reader.IsDBNull(40)) PatientInfo=this.Reader[40].ToString();//最近住院日期
						//						if(!this.Reader.IsDBNull(41)) PatientInfo=this.Reader[41].ToString();//住院次数
						//						if(!this.Reader.IsDBNull(42)) PatientInfo=this.Reader[42].ToString();//最近出院日期
						//						if(!this.Reader.IsDBNull(44)) PatientInfo=this.Reader[44].ToString();//最近挂号日期
						//						if(!this.Reader.IsDBNull(45)) PatientInfo=this.Reader[45].ToString();//违约次数
						//						if(!this.Reader.IsDBNull(46)) PatientInfo=this.Reader[46].ToString();//结束日期
						if (!Reader.IsDBNull(47)) PatientInfo.Memo = Reader[47].ToString(); //备注
						if (!Reader.IsDBNull(48)) PatientInfo.User01 = Reader[48].ToString(); //操作员
						if (!Reader.IsDBNull(49)) PatientInfo.User02 = Reader[49].ToString(); //操作日期
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						WriteErr();
						if (!Reader.IsClosed)
						{
							Reader.Close();
						}
					}
					al.Add(PatientInfo);
				}
			} //抛出错误
			catch (Exception ex)
			{
				Err = "获得患者基本信息出错！" + ex.Message;
				ErrCode = "-1";
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return al;
			}
			Reader.Close();

			ProgressBarValue = -1;
			return al;
		}

		
		#endregion

		#region 按传入的Sql语句查询病人基本信息列表--私有
		/// <summary>
		/// 查询患者基本信息 基本查询
		/// </summary>
		/// <param name="SQLPatient">SQL语句</param>
		/// <returns>返回一条患者基本信息</returns>
		private ArrayList myPatientBasicQuery(string SQLPatient)
		{
			ArrayList al = new ArrayList();
			PatientInfo PatientInfo;
			ProgressBarText = "正在查询患者...";
			ProgressBarValue = 0;
			if (ExecQuery(SQLPatient) == -1) return null;
			try
			{
				while (Reader.Read())
				{
					PatientInfo = new PatientInfo();
					if (!Reader.IsDBNull(0)) PatientInfo.ID = Reader[0].ToString();
					PatientInfo.ID = PatientInfo.ID;
					PatientInfo.PID.ID = PatientInfo.ID;
					if (!Reader.IsDBNull(1)) PatientInfo.PID.PatientNO = Reader[1].ToString();
					if (!Reader.IsDBNull(2)) PatientInfo.Name = Reader[2].ToString();
					PatientInfo.Name = PatientInfo.Name;
					if (!Reader.IsDBNull(3)) PatientInfo.Sex.ID = Reader[3].ToString();
					if (!Reader.IsDBNull(4)) PatientInfo.Birthday = NConvert.ToDateTime(Reader[4].ToString());
					if (!Reader.IsDBNull(5)) PatientInfo.PVisit.InTime = NConvert.ToDateTime(Reader[5].ToString());
					if (!Reader.IsDBNull(6)) PatientInfo.PVisit.PatientLocation.Dept.ID = Reader[6].ToString();
					if (!Reader.IsDBNull(7)) PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[7].ToString();
					if (!Reader.IsDBNull(8)) PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[8].ToString();
					if (!Reader.IsDBNull(9)) PatientInfo.PVisit.PatientLocation.Bed.Status.ID = Reader[9].ToString();
					if (!Reader.IsDBNull(10)) PatientInfo.PVisit.PatientLocation.NurseCell.ID = Reader[10].ToString();
					if (!Reader.IsDBNull(11)) PatientInfo.PVisit.PatientLocation.NurseCell.Name = Reader[11].ToString();
					if (!Reader.IsDBNull(12)) PatientInfo.PVisit.AdmittingDoctor.ID = Reader[12].ToString(); //医师代码(住院)
					if (!Reader.IsDBNull(13)) PatientInfo.PVisit.AdmittingDoctor.Name = Reader[13].ToString(); //医师姓名(住院)
					if (!Reader.IsDBNull(14)) PatientInfo.PVisit.AttendingDoctor.ID = Reader[14].ToString(); //医师代码(主治)
					if (!Reader.IsDBNull(15)) PatientInfo.PVisit.AttendingDoctor.Name = Reader[15].ToString(); //医师姓名(主治)
					if (!Reader.IsDBNull(16)) PatientInfo.PVisit.ConsultingDoctor.ID = Reader[16].ToString(); //医师代码(主任)
					if (!Reader.IsDBNull(17)) PatientInfo.PVisit.ConsultingDoctor.Name = Reader[17].ToString(); //医师姓名(主任)
					if (!Reader.IsDBNull(18)) PatientInfo.PVisit.TempDoctor.ID = Reader[18].ToString(); //医师代码(实习)
					if (!Reader.IsDBNull(19)) PatientInfo.PVisit.TempDoctor.Name = Reader[19].ToString(); //医师姓名(实习)
					if (!Reader.IsDBNull(20)) PatientInfo.PVisit.AdmittingNurse.ID = Reader[20].ToString(); // 护士代码(责任)
					if (!Reader.IsDBNull(21)) PatientInfo.PVisit.AdmittingNurse.Name = Reader[21].ToString(); // 护士姓名(责任)
					if (!Reader.IsDBNull(22)) PatientInfo.Disease.Tend.Name = Reader[22].ToString();
					if (!Reader.IsDBNull(23)) PatientInfo.Disease.Memo = Reader[23].ToString(); //饮食
					if (!Reader.IsDBNull(24)) PatientInfo.Diagnoses.Add(Reader[24].ToString()); //诊断
                    if (!Reader.IsDBNull(25)) PatientInfo.FT.TotCost = NConvert.ToDecimal( Reader[25]);
                    if (!Reader.IsDBNull(26)) PatientInfo.FT.LeftCost =NConvert.ToDecimal( Reader[26]);
                    if (!Reader.IsDBNull(27)) PatientInfo.PVisit.MoneyAlert =NConvert.ToDecimal( Reader[27]);
                    if (!Reader.IsDBNull(28)) PatientInfo.FT.PrepayCost = NConvert.ToDecimal(Reader[28]);//预交金
                    PatientInfo.PVisit.AlertType.ID = this.Reader[29].ToString();
                    PatientInfo.PVisit.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[30]);
                    PatientInfo.PVisit.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[31]);
					ProgressBarValue++;
					al.Add(PatientInfo);
				}
			} //抛出错误
			catch (Exception ex)
			{
				Err = "获得患者基本信息出错！" + ex.Message;
				ErrCode = "-1";
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return al;
			}
			Reader.Close();

			ProgressBarValue = -1;
			return al;
		}

		#endregion

		#region 按传入的Sql语句查询患者信息列表--私有

		private ArrayList myPatientQuery(string SQLPatient)
		{
			ArrayList al = new ArrayList();
			PatientInfo PatientInfo;
			ProgressBarText = "正在查询患者...";
			ProgressBarValue = 0;

			if (ExecQuery(SQLPatient) == -1)
			{
				return null;
			}
			//取系统时间,用来得到年龄字符串
			DateTime sysDate = GetDateTimeFromSysDateTime();

			try
			{
				while (Reader.Read())
				{
					PatientInfo = new PatientInfo();

					#region "接口说明"

					//<!-- 0  住院流水号,1 姓名 ,2   住院号   ,3 就诊卡号  ,4  病历号, 5  医疗证号
					//,6    医疗类别,   7   性别   ,8   身份证号  ,9   拼音     ,10  生日
					//,11   职业代码     ,12 职业名称,13   工作单位    ,14   工作单位电话      ,15   单位邮编
					//,16   户口或家庭地址     ,17   家庭电话   ,18   户口或家庭邮编   , 19  籍贯id,20  籍贯name
					//,21   出生地代码    , 22 出生地名称   ,23   民族id    ,24  民族name    ,25   联系人id
					//,26   联系人姓名    ,27   联系人电话       ,28   联系人地址     ,29   联系人关系id , 30   联系人关系name
					//,31   婚姻状况id    ,32  婚姻状况name  ,33   国籍id    , 34 国籍名称
					//,35   身高           ,36   体重         ,37   血压      ,38   ABO血型
					//,39   重大疾病标志    ,40   过敏标志            
					//,41   入院日期      ,42   科室代码   , 43  科室名称  , 44  结算类别id 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
					//,45   结算类别名称   , 46 合同代码   , 47  合同单位名称  , 48  床号
					//, 49 护理单元代码  , 50  护理单元名称, 51 医师代码(住院), 52 医师姓名(住院)
					//, 53 医师代码(主治) , 54 医师姓名(主治) , 55 医师代码(主任) , 56 医师姓名(主任)
					//, 57 医师代码(实习) , 58 医师姓名(实习), 59  护士代码(责任), 60  护士姓名(责任)
					//, 61  入院情况id  , 62  入院情况name   , 63  入院途径id    , 64  入院途径name      
					//, 65  入院来源id 1 -门诊 2 -急诊 3 -转科 4 -转院    , 66  入院来源name
					//, 67  在院状态 住院登记  i-病房接诊 -出院登记 o-出院结算 p-预约出院 n-无费退院
					//,  68  出院日期(预约)  , 69  出院日期 , 70  是否在ICU 0 no 1 yes,71 icu code,72 icu name
					//,73 楼 ,74 层,75 屋 
					//,76 总共金额TotCost ,77 自费金额 OwnCost,	78 自付金额 PayCost,79 公费金额 PubCost
					//,80 剩余金额 LeftCost,81 优惠金额
					//,82  预交金额 ，83    费用金额(已结)，84    预交金额(已结) ， 85 结算日期(上次)     
					//，86 警戒线, 87 转归代号,88 TransferPrepayCost 转入预交金额（未结)  ,89 转入费用金额(未结),90 病床状态91公费日限额超标部分
					//,92 特注93公费日限额94血滞纳金95住院次数96床位上限97空调上限98门诊诊断99收住医师100生育保险电脑号
					//-->

					#endregion

					try
					{
						if (!Reader.IsDBNull(0)) PatientInfo.ID = Reader[0].ToString(); // 住院流水号
						if (!Reader.IsDBNull(0)) PatientInfo.ID = Reader[0].ToString(); // 住院流水号
						if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); //姓名
						if (!Reader.IsDBNull(1)) PatientInfo.Name = Reader[1].ToString(); //姓名
						if (!Reader.IsDBNull(2)) PatientInfo.PID.PatientNO = Reader[2].ToString(); //  住院号						
						if (!Reader.IsDBNull(3)) PatientInfo.PID.CardNO = Reader[3].ToString(); //就诊卡号
						if (!Reader.IsDBNull(4)) PatientInfo.PID.CaseNO = Reader[4].ToString(); // 病历号
						if (!Reader.IsDBNull(5)) PatientInfo.SSN = Reader[5].ToString(); // 医疗证号
						if (!Reader.IsDBNull(6)) PatientInfo.PVisit.MedicalType.ID = Reader[6].ToString(); //   医疗类别id
						if (!Reader.IsDBNull(7)) PatientInfo.Sex.ID = Reader[7].ToString(); //  性别
						if (!Reader.IsDBNull(8)) PatientInfo.IDCard = Reader[8].ToString(); //  身份证号
						if (!Reader.IsDBNull(9)) PatientInfo.Memo = Reader[9].ToString(); //  拼音
						if (!Reader.IsDBNull(10)) PatientInfo.Birthday = NConvert.ToDateTime(Reader[10]); // 生日
						if (!Reader.IsDBNull(11)) PatientInfo.Profession.ID = Reader[11].ToString(); //  职业代码
						if (!Reader.IsDBNull(12)) PatientInfo.Profession.Name = Reader[12].ToString(); //职业名称
						if (!Reader.IsDBNull(13)) PatientInfo.CompanyName = Reader[13].ToString(); //  工作单位
						if (!Reader.IsDBNull(14)) PatientInfo.PhoneBusiness = Reader[14].ToString(); //  工作单位电话
						if (!Reader.IsDBNull(15)) PatientInfo.User01 = Reader[15].ToString(); //  单位邮编
						if (!Reader.IsDBNull(16)) PatientInfo.AddressHome = Reader[16].ToString(); //  户口或家庭地址
						if (!Reader.IsDBNull(17)) PatientInfo.PhoneHome = Reader[17].ToString(); //  家庭电话
						if (!Reader.IsDBNull(18)) PatientInfo.User02 = Reader[18].ToString(); //  户口或家庭邮编
						if (!Reader.IsDBNull(20)) PatientInfo.DIST = Reader[20].ToString(); // 籍贯name
						if (!Reader.IsDBNull(21)) PatientInfo.AreaCode = Reader[21].ToString(); //  出生地代码
						if (!Reader.IsDBNull(23)) PatientInfo.Nationality.ID = Reader[23].ToString(); //  民族id
						if (!Reader.IsDBNull(24)) PatientInfo.Nationality.Name = Reader[24].ToString(); // 民族name
						if (!Reader.IsDBNull(25)) PatientInfo.Kin.ID = Reader[25].ToString(); //  联系人id
						if (!Reader.IsDBNull(26)) PatientInfo.Kin.Name = Reader[26].ToString(); //  联系人姓名
						if (!Reader.IsDBNull(27)) PatientInfo.Kin.RelationPhone = Reader[27].ToString(); //  联系人电话
						if (!Reader.IsDBNull(28)) PatientInfo.Kin.RelationAddress = Reader[28].ToString(); //  联系人地址
						if (!Reader.IsDBNull(29)) PatientInfo.Kin.Relation.ID = Reader[29].ToString(); //  联系人关系id
						if (!Reader.IsDBNull(30)) PatientInfo.Kin.Relation.Name = Reader[30].ToString(); //  联系人关系name
						if (!Reader.IsDBNull(31)) PatientInfo.MaritalStatus.ID = Reader[31].ToString(); //  婚姻状况id
						if (!Reader.IsDBNull(33)) PatientInfo.Country.ID = Reader[33].ToString(); //  国籍id
						if (!Reader.IsDBNull(34)) PatientInfo.Country.Name = Reader[34].ToString(); //国籍名称
						if (!Reader.IsDBNull(35)) PatientInfo.Height = Reader[35].ToString(); //  身高
						if (!Reader.IsDBNull(36)) PatientInfo.Weight = Reader[36].ToString(); //  体重
						if (!Reader.IsDBNull(38)) PatientInfo.BloodType.ID = Reader[38].ToString(); //  ABO血型
						if (!Reader.IsDBNull(39)) PatientInfo.Disease.IsMainDisease = NConvert.ToBoolean(Reader[39]); //  重大疾病标志
						if (!Reader.IsDBNull(40)) PatientInfo.Disease.IsAlleray = NConvert.ToBoolean(Reader[40]); //  过敏标志
						if (!Reader.IsDBNull(41)) PatientInfo.PVisit.InTime = NConvert.ToDateTime(Reader[41]); //  入院日期
						if (!Reader.IsDBNull(42)) PatientInfo.PVisit.PatientLocation.Dept.ID = Reader[42].ToString(); //  科室代码
						if (!Reader.IsDBNull(43)) PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[43].ToString(); // 科室名称
						if (!Reader.IsDBNull(44)) PatientInfo.Pact.PayKind.ID = Reader[44].ToString();
						// 结算类别id 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
						if (!Reader.IsDBNull(45)) PatientInfo.Pact.PayKind.Name = Reader[45].ToString(); //  结算类别名称
						if (!Reader.IsDBNull(46)) PatientInfo.Pact.ID = Reader[46].ToString(); //合同代码
						if (!Reader.IsDBNull(47)) PatientInfo.Pact.Name = Reader[47].ToString(); // 合同单位名称
						if (!Reader.IsDBNull(48)) PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[48].ToString(); // 床号
						if (!Reader.IsDBNull(48))
							PatientInfo.PVisit.PatientLocation.Bed.Name = PatientInfo.PVisit.PatientLocation.Bed.ID.Length > 4
							                                              	? PatientInfo.PVisit.PatientLocation.Bed.ID.Substring(4)
							                                              	: PatientInfo.PVisit.PatientLocation.Bed.ID; // 床号
						if (!Reader.IsDBNull(90)) PatientInfo.PVisit.PatientLocation.Bed.Status.ID = Reader[90].ToString(); //床位状态
						if (!Reader.IsDBNull(90)) PatientInfo.PVisit.PatientLocation.Bed.InpatientNO = Reader[0].ToString(); // 住院流水号
						if (!Reader.IsDBNull(49)) PatientInfo.PVisit.PatientLocation.NurseCell.ID = Reader[49].ToString(); //护理单元代码
						if (!Reader.IsDBNull(50)) PatientInfo.PVisit.PatientLocation.NurseCell.Name = Reader[50].ToString(); // 护理单元名称
						if (!Reader.IsDBNull(51)) PatientInfo.PVisit.AdmittingDoctor.ID = Reader[51].ToString(); //医师代码(住院)
						if (!Reader.IsDBNull(52)) PatientInfo.PVisit.AdmittingDoctor.Name = Reader[52].ToString(); //医师姓名(住院)
						if (!Reader.IsDBNull(53)) PatientInfo.PVisit.AttendingDoctor.ID = Reader[53].ToString(); //医师代码(主治)
						if (!Reader.IsDBNull(54)) PatientInfo.PVisit.AttendingDoctor.Name = Reader[54].ToString(); //医师姓名(主治)
						if (!Reader.IsDBNull(55)) PatientInfo.PVisit.ConsultingDoctor.ID = Reader[55].ToString(); //医师代码(主任)
						if (!Reader.IsDBNull(56)) PatientInfo.PVisit.ConsultingDoctor.Name = Reader[56].ToString(); //医师姓名(主任)
						if (!Reader.IsDBNull(57)) PatientInfo.PVisit.TempDoctor.ID = Reader[57].ToString(); //医师代码(实习)
						if (!Reader.IsDBNull(58)) PatientInfo.PVisit.TempDoctor.Name = Reader[58].ToString(); //医师姓名(实习)
						if (!Reader.IsDBNull(59)) PatientInfo.PVisit.AdmittingNurse.ID = Reader[59].ToString(); // 护士代码(责任)
						if (!Reader.IsDBNull(60)) PatientInfo.PVisit.AdmittingNurse.Name = Reader[60].ToString(); // 护士姓名(责任)
						if (!Reader.IsDBNull(61)) PatientInfo.PVisit.Circs.ID = Reader[61].ToString(); // 入院情况id
						if (!Reader.IsDBNull(62)) PatientInfo.PVisit.Circs.Name = Reader[62].ToString(); // 入院情况name
						if (!Reader.IsDBNull(63)) PatientInfo.PVisit.AdmitSource.ID = Reader[63].ToString(); // 入院途径id
						if (!Reader.IsDBNull(64)) PatientInfo.PVisit.AdmitSource.Name = Reader[64].ToString(); // 入院途径name
						if (!Reader.IsDBNull(65)) PatientInfo.PVisit.InSource.ID = Reader[65].ToString();
						// 入院来源id 1 -门诊 2 -急诊 3 -转科 4 -转院
						if (!Reader.IsDBNull(66)) PatientInfo.PVisit.InSource.Name = Reader[66].ToString(); // 入院来源name
						if (!Reader.IsDBNull(67)) PatientInfo.PVisit.InState.ID = Reader[67].ToString();
						// 在院状态 住院登记  i-病房接诊 -出院登记 o-出院结算 p-预约出院 n-无费退院
						if (!Reader.IsDBNull(68)) PatientInfo.PVisit.PreOutTime = NConvert.ToDateTime(Reader[68]); // 出院日期(预约)
                        #region {8D72F2C7-624C-41e4-9922-7A5556B9D82E}
                        if (!Reader.IsDBNull(69))
                        {
                            if (NConvert.ToDateTime(Reader[69]) < NConvert.ToDateTime("1000-01-01"))
                            {
                                PatientInfo.PVisit.OutTime = DateTime.MinValue;
                            }
                            else//{3D0766DE-A5AA-409f-8A04-C56F4C9D53DA}
                            {
                                PatientInfo.PVisit.OutTime = NConvert.ToDateTime(Reader[69]);
                            }

                        }
                        #endregion
                        if (!Reader.IsDBNull(71)) PatientInfo.PVisit.ICULocation.ID = Reader[71].ToString(); //icu code
						if (!Reader.IsDBNull(72)) PatientInfo.PVisit.ICULocation.Name = Reader[72].ToString(); //icu name
						if (!Reader.IsDBNull(73)) PatientInfo.PVisit.PatientLocation.Building = Reader[73].ToString(); //楼
						if (!Reader.IsDBNull(74)) PatientInfo.PVisit.PatientLocation.Floor = Reader[74].ToString(); //层
						if (!Reader.IsDBNull(75)) PatientInfo.PVisit.PatientLocation.Room = Reader[75].ToString(); //屋
						if (!Reader.IsDBNull(76)) PatientInfo.FT.TotCost = NConvert.ToDecimal(Reader[76]); //总共金额TotCost
						if (!Reader.IsDBNull(77)) PatientInfo.FT.OwnCost = NConvert.ToDecimal(Reader[77]); //自费金额 OwnCost
						if (!Reader.IsDBNull(78)) PatientInfo.FT.PayCost = NConvert.ToDecimal(Reader[78]); //自付金额 PayCost
						if (!Reader.IsDBNull(79)) PatientInfo.FT.PubCost = NConvert.ToDecimal(Reader[79]); //公费金额 PubCost
						if (!Reader.IsDBNull(80)) PatientInfo.FT.LeftCost = NConvert.ToDecimal(Reader[80]); //剩余金额 LeftCost
						if (!Reader.IsDBNull(81)) PatientInfo.FT.RebateCost = NConvert.ToDecimal(Reader[81]); //优惠金额
						if (!Reader.IsDBNull(82)) PatientInfo.FT.PrepayCost = NConvert.ToDecimal(Reader[82]); // 预交金额
						if (!Reader.IsDBNull(83)) PatientInfo.FT.BalancedCost = NConvert.ToDecimal(Reader[83]); //   费用金额(已结)
						if (!Reader.IsDBNull(84)) PatientInfo.FT.BalancedPrepayCost = NConvert.ToDecimal(Reader[84]); //   预交金额(已结)
                        if(!Reader.IsDBNull(85)) 
                        {
                            try
                            {
                                PatientInfo.BalanceDate = NConvert.ToDateTime(Reader[85]); //结算时间
                            }
                            catch { }
                        }
						if (!Reader.IsDBNull(86)) PatientInfo.PVisit.MoneyAlert = NConvert.ToDecimal(Reader[86]); //警戒线
						if (!Reader.IsDBNull(87)) PatientInfo.PVisit.ZG.ID = Reader[87].ToString(); //  转归代码
						if (!Reader.IsDBNull(88)) PatientInfo.FT.TransferPrepayCost = NConvert.ToDecimal(Reader[88]); // 转入预交金额（未结) 
						if (!Reader.IsDBNull(89)) PatientInfo.FT.TransferTotCost = NConvert.ToDecimal(Reader[89]); //  转入费用金额（未结) 
						if (!Reader.IsDBNull(91)) PatientInfo.FT.OvertopCost = NConvert.ToDecimal(Reader[91]); //   公费超标金额
						if (!Reader.IsDBNull(92)) PatientInfo.Memo = Reader[92].ToString(); //特注
						if (!Reader.IsDBNull(93)) PatientInfo.FT.DayLimitCost = NConvert.ToDecimal(Reader[93]); //   公费日限额
						if (!Reader.IsDBNull(94)) PatientInfo.FT.BloodLateFeeCost = NConvert.ToDecimal(Reader[94]); //  血滞纳金
						if (!Reader.IsDBNull(95)) PatientInfo.InTimes = NConvert.ToInt32(Reader[95]); //住院次数
						if (!Reader.IsDBNull(96)) PatientInfo.FT.BedLimitCost = NConvert.ToDecimal(Reader[96].ToString()); //床位上限
						if (!Reader.IsDBNull(97)) PatientInfo.FT.AirLimitCost = NConvert.ToDecimal(Reader[97].ToString()); //空调上限
						if (!Reader.IsDBNull(99)) PatientInfo.DoctorReceiver.ID = Reader[99].ToString();
						if (!Reader.IsDBNull(98)) PatientInfo.ClinicDiagnose = Reader[98].ToString();
						if (!Reader.IsDBNull(100)) PatientInfo.ProCreateNO = Reader[100].ToString(); //生育保险电脑号
						PatientInfo.IsHasBaby = NConvert.ToBoolean(Reader[101].ToString()); //是否有婴儿
						PatientInfo.Disease.Tend.Name = Reader[102].ToString(); //护理级别
						//费用收取间隔
						PatientInfo.FT.FixFeeInterval = NConvert.ToInt32(Reader[103].ToString());
						//上次收取时间
						PatientInfo.FT.PreFixFeeDateTime = NConvert.ToDateTime(Reader[104].ToString());
						//床费超标处理 0超标不限1超标自理
						PatientInfo.FT.BedOverDeal = Reader[105].ToString();
						//日限额累计
						PatientInfo.FT.DayLimitTotCost = NConvert.ToDecimal(Reader[106].ToString());
						//病案状态: 0 无需病案 1 需要病案 2 医生站形成病案 3 病案室形成病案 4病案封存
						PatientInfo.CaseState = Reader[107].ToString();

						PatientInfo.ExtendFlag = Reader[108].ToString(); //是否允许日限额超标 0 不同意 1 同意 中山一院需求
						PatientInfo.ExtendFlag1 = Reader[109].ToString(); //扩展标记1
						PatientInfo.ExtendFlag2 = Reader[110].ToString(); //扩展标记2
						PatientInfo.FT.BoardCost = NConvert.ToDecimal(Reader[111]); //膳食花费总额
						PatientInfo.FT.BoardPrepayCost = NConvert.ToDecimal(Reader[112]); //膳食预交金额
						PatientInfo.PVisit.BoardState = Reader[113].ToString(); //膳食结算状态：0在院 1出院
						PatientInfo.FT.FTRate.OwnRate = NConvert.ToDecimal(Reader[114].ToString()); //自费比例
						PatientInfo.FT.FTRate.PayRate = NConvert.ToDecimal(Reader[115].ToString()); //自付比例
						PatientInfo.FT.DrugFeeTotCost = NConvert.ToDecimal(Reader[116].ToString()); //公费患者公费药品累计(日限额)
						PatientInfo.MainDiagnose = Reader[117].ToString(); //患者住院主诊断

						PatientInfo.Age = GetAge(PatientInfo.Birthday, sysDate); //根据出生日期取患者年龄
                        PatientInfo.IsEncrypt = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[118].ToString());
                        PatientInfo.NormalName = Reader[119].ToString();
                        if (!Reader.IsDBNull(120)) PatientInfo.BalanceNO = NConvert.ToInt32(Reader[120].ToString());//结算次数
                        //{F0C48258-8EFB-4356-B730-E852EE4888A0}
                        PatientInfo.ExtendFlag1 = Reader[121].ToString();//病情

                        //if (PatientInfo.PID.PatientNO.Substring(0, 1) == "B")
                        //{
                        //    //是否婴儿
                        //    PatientInfo.IsBaby = true;
                        //}
                        //else
                        //{
                        //    PatientInfo.IsBaby = false;
                        //}
                        //{2FA0D4CE-E2EB-4bc7-975A-3693B71C62CF}
                        if (!Reader.IsDBNull(122))
                        {
                            PatientInfo.IsStopAcount = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[122].ToString());
                        }
                        PatientInfo.PVisit.AlertType.ID = this.Reader[123].ToString();
                        PatientInfo.PVisit.BeginDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[124]);
                        PatientInfo.PVisit.EndDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[125]);
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						WriteErr();
						if (!Reader.IsClosed)
						{
							Reader.Close();
						}
						return null;
					}
					//获得变更信息

					#region "获得变更信息"

					//deleted by cuipeng 2005-5 不知道此功能为啥用,而且有问题
					//this.myGetTempLocation(PatientInfo);

					#endregion

					ProgressBarValue++;
					al.Add(PatientInfo);
				}
			} //抛出错误
			catch (Exception ex)
			{
				Err = "获得患者基本信息出错！" + ex.Message;
				ErrCode = "-1";
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return al;
			}
			Reader.Close();

			ProgressBarValue = -1;
			return al;
		}

		#endregion

		#region 查询患者信息的select语句（无where条件）--私有
		/// <summary>
		/// RADT.RADT.InPatient.QueryBaseInfo (fin_ipr_inmaininfo)
		/// </summary>
		/// <returns></returns>
		private string PatientQueryBasicSelect()
		{
			string sql = string.Empty;
			if (Sql.GetSql("RADT.InPatient.QueryBaseInfo", ref sql) == -1)
			{
				#region SQL
				/*
				select inpatient_no,patient_no,name,
				sex_code,   --性别 M,F,O,U 
				birthday,   --生日 
				in_date,   --入院日期 
				dept_code,   --科室代码 
				dept_name,   --科室名称 
				bed_no,   --床号 
				 (select t.bed_state from com_bedinfo t where t.bed_no=d.bed_no) ,
				nurse_cell_code,   --护理单元代码 
				nurse_cell_name,   --护理单元名称 
				house_doc_code,   --医师代码(住院) 
				house_doc_name,   --医师姓名(住院) 
				charge_doc_code,   --医师代码(主治) 50 
				charge_doc_name,   --医师姓名(主治) 
				chief_doc_code,   --医师代码(主任) 
				chief_doc_name,   --医师姓名(主任) 
				'', --实习 
				'', --实习55 
				duty_nurse_code,   --护士代码(责任) 
				duty_nurse_name,   --护士姓名(责任) 
				tend,--护理
				dietetic_mark, --饮食
				(select t.diag_name from MET_COM_DIAGNOSE t where t.inpatient_no = inpatient_no and t.main_flag='1' and rownum=1)
				from fin_ipr_inmaininfo  d
				*/
				#endregion
				return null;
			}
			return sql;
		}

		#endregion

		#region 根据患者姓名和在院状态模糊查找患者列表

		/// <summary>
		/// 根据患者姓名和在院状态模糊查找患者列表
		/// </summary>
		/// <param name="name"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public ArrayList QueryInpatientBySlurName(string name, string state)
		{
			string strSql = string.Empty;
			string strSqlWhere = string.Empty;

			strSql = PatientQuerySelect();

			if (Sql.GetSql("RADT.Inpatient.QueryInpatientBySlurName.Where.1", ref strSqlWhere) == -1)
			{
				return null;
			}

			try
			{
				strSqlWhere = string.Format(strSqlWhere, name, state);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				WriteErr();
				return null;
			}
			strSql = strSql + strSqlWhere;

			return myPatientQuery(strSql);
		}

		#endregion

		#region 按病区指定标准获得欠费患者信息列表

		/// <summary>
		/// 获得欠费患者信息(按指定标准)
		/// </summary>
		/// <param name="nurseCellCode"></param>
		/// <param name="alert"></param>
		/// <returns></returns>
		public ArrayList GetAlertPerson(string nurseCellCode, decimal alert)
		{
			string strSql1 = string.Empty;
			string strSql2 = string.Empty;
			
			strSql1 = PatientQuerySelect();
			if (strSql1 == null)
			{
				return null;
			}

			//取查询报表的where语句
			if (Sql.GetSql("RADT.Inpatient.GetAlertPerson.1", ref strSql2) == -1)
			{
				return null;
			}

			try
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, nurseCellCode, alert.ToString());
			}
			catch
			{
				Err = "RADT.Inpatient.GetAlertPerson.1赋值不匹配！";
				ErrCode = "RADT.Inpatient.GetAlertPerson.1赋值不匹配！";
				WriteErr();
				return null;
			}

			return myPatientQuery(strSql1);
		}

		#endregion

		#region 按病区指定比例获得欠费患者信息列表

		/// <summary>
		/// 获得欠费患者信息(按指定比例)
		/// </summary>
		/// <param name="nurseCellCode"></param>
		/// <param name="alert"></param>
		/// <returns></returns>
		public ArrayList GetAlertPercent(string nurseCellCode, decimal alert)
		{
			string strSql1 = string.Empty, strSql2 = string.Empty;
			strSql1 = PatientQuerySelect();
			if (strSql1 == null) return null;

			//取查询报表的where语句
			if (Sql.GetSql("RADT.Inpatient.GetAlertPerson.2", ref strSql2) == -1)
			{
				return null;
			}

			try
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, nurseCellCode, alert.ToString());
			}
			catch
			{
				Err = "RADT.Inpatient.GetAlertPerson.2赋值不匹配！";
				ErrCode = "RADT.Inpatient.GetAlertPerson.2赋值不匹配！";
				WriteErr();
				return null;
			}

			return myPatientQuery(strSql1);
		}

		#endregion

		#region	按病区获得欠费患者信息列表

		/// <summary>
		/// 获得欠费患者信息(按最底下限)
		/// </summary>
		/// <param name="nurseCellCode"></param>
		/// <returns></returns>
		public ArrayList GetAlertPerson(string nurseCellCode)
		{
			string strSql1 = string.Empty, strSql2 = string.Empty;
			strSql1 = PatientQuerySelect();
			if (strSql1 == null) return null;

			//取查询报表的where语句
			if (Sql.GetSql("RADT.Inpatient.GetAlertPerson.3", ref strSql2) == -1)
			{
				return null;
			}

			try
			{
				strSql1 = strSql1 + " " + string.Format(strSql2, nurseCellCode);
			}
			catch
			{
				Err = "RADT.Inpatient.GetAlertPerson.3赋值不匹配！";
				ErrCode = "RADT.Inpatient.GetAlertPerson.3赋值不匹配！";
				WriteErr();
				return null;
			}

			return myPatientQuery(strSql1);
		}

		#endregion

		# region  获得特殊病人列表,供医务科管理

		/// <summary>
		/// 获得特殊病人列表
		/// </summary>
		/// <returns></returns>
		private ArrayList myGetSpecialPatient(string strSql)
		{
			if (strSql == string.Empty || strSql == null)
				return null;
			if (ExecQuery(strSql) == -1)
				return null;
			ArrayList alPatient = new ArrayList();
			try
			{
				while (Reader.Read())
				{
					PatientInfo pInfo = new PatientInfo();
					try
					{
						pInfo.PID.PatientNO = Reader[0].ToString();
					}
					catch (Exception ex)
					{
						Err = ex.Message;
						WriteErr();
						if (!Reader.IsClosed)
						{
							Reader.Close();
						}
						return null;
					}
					alPatient.Add(pInfo);
				}
			}
			catch (Exception ex)
			{
				Err = "获得患者基本信息出错！" + ex.Message;
				ErrCode = "-1";
				WriteErr();
				if (!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
			Reader.Close();
			return alPatient;
		}

		# endregion

		#region 预留接口

		#region 作废一个患者的信息资料

		/// <summary>
		/// 注销用户 作废一个患者的信息资料
		/// </summary>
		/// <param name="PatientInfo">注销的患者信息</param>
		/// <returns>0成功 -1失败</returns>
		public int DischargePatient(PatientInfo PatientInfo)
		{
			return 0;
		}

		#endregion

		#region 更新患者信息是否送病案标志

		/// <summary>
		/// 更新病历是否送病案
		/// </summary>
		/// <param name="InpatientNo"></param>
		/// <param name="IsSended"></param>
		/// <returns></returns>
		public int UpdateCaseSend(string InpatientNo, bool IsSended)
		{
			return 1;
		}

		#endregion

		#region 查询患者病历是否送病案室

		/// <summary>
		/// 查询是否病历送病案
		/// </summary>
		/// <param name="InpatientNo"></param>
		/// <returns></returns>
		public bool QueryIsCaseSended(string InpatientNo)
		{
			return true;
		}

		#endregion

		#region 查询没有送病案的患者信息列表

		/// <summary>
		/// 查询没有送病案的患者
		/// </summary>
		/// <returns></returns>
		public ArrayList QueryPatientNoSendCase()
		{
			return null;
		}

		#endregion

		#endregion
		
		#region 获取 无条件查询病人信息列表 SQL语句 com_patientinfo

		/// <summary>
		/// 患者就诊卡卡列表查询 com_patientinfo
		/// </summary>
		/// <returns>COM_PATIENTINFO Select SQL语句</returns>
		private string QueryComPatientInfoSelect()
		{
			string sql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Select.2", ref sql) == -1)
				#region SQL
				/* SELECT card_no,
					name,   --姓名
					spell_code,   --拼音码
					wb_code,   --五笔
					to_char(birthday,'YYYY-MM-DD') as birthday,   --出生日期
					decode( sex_code,'U','未知','F','女','M','男') as sex_code,   --性别
					idenno,   --身份证号
					blood_code,   --血型
					prof_code,   --职业
					work_home,   --工作单位
					work_tel,   --单位电话
					work_zip,   --单位邮编
					home,   --户口或家庭所在
					home_tel,   --家庭电话
					home_zip,   --户口或家庭邮政编码
					district,   --籍贯
					nation_code,   --民族
					linkman_name,   --联系人姓名
					linkman_tel,   --联系人电话
					linkman_add,   --联系人住址
					rela_code,   --联系人关系
					mari,   --婚姻状况
					coun_code,   --国籍
					paykind_code,   --结算类别
					paykind_name,   --结算类别名称
					pact_code,   --合同代码
					pact_name,   --合同单位名称
					mcard_no,   --医疗证号
					area_code,   --出生地
					framt,   --医疗费用
					ic_cardno,   --电脑号
					anaphy_flag,   --药物过敏
					hepatitis_flag,   --重要疾病
					act_code,   --帐户密码
					act_amt,   --帐户总额
					lact_sum,   --上期帐户余额
					lbank_sum,   --上期银行余额
					arrear_times,   --欠费次数
					arrear_sum,   --欠费金额
					inhos_source,   --住院来源
					lihos_date,   --最近住院日期
					inhos_times,   --住院次数
					louthos_date,   --最近出院日期
					fir_see_date,   --初诊日期
					lreg_date,   --最近挂号日期
					disoby_cnt,   --违约次数
					end_date,   --结束日期
					mark,   --备注
					oper_code,   --操作员								   
					oper_date,    --操作日期
					is_valid
					FROM com_patientinfo   --病人基本信息表
					*/
				#endregion
			{
				return null;
			}
			return sql;
		}
		[Obsolete("更改为 QueryComPatientInfoSelect",true)]
		private string PatientInfoQuerySelect()
		{
			return null;
		}
		#endregion
		
		#region 获取 无条件查询患者信息列表 SQL语句 FIN_IPR_INMAININFO

		/// <summary>
		/// 查询患者信息 FIN_IPR_INMAININFO
		/// </summary>
		/// <returns>FIN_IPR_INMAININFO SQL 语句</returns>
		private string PatientQuerySelect()
		{
			string sql = string.Empty;
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Select.1", ref sql) == -1)
			{
				#region SQL
				/*
				SELECT	inpatient_no,	--0 住院流水号
				name,		--1 姓名
				patient_no,	--2 住院号
				card_no,	--3 就诊卡号
				patient_no,	--4 病历号
				mcard_no,	--5 医疗证号
				MEDICAL_TYPE,	--6 医疗类别
				sex_code,   	--7 性别 M,F,O,U
				idenno,   	--8 身份证号
				spell_code,   	--9 拼音10
				birthday,   	--10生日
				prof_code,   	--11职业代码
				'',		--12 职业名称
				work_name,   	--13工作单位
				work_tel,   	--14工作单位电话15
				work_zip,   	--15单位邮编Memo
				home,   	--16户口或家庭地址
				home_tel,   	--17家庭电话
				home_zip,   	--18户口或家庭邮编		
				'',		--19籍贯id20
				dist,   	--20籍贯name
				birth_area,   	--21出生地代码		
				'',		--22出生地名称
				nation_code,   	--23民族id
				'',		--24民族名称
				'',		--25联系人ID
				linkman_name,   --26联系人姓名			
				linkman_tel,   	--27联系人电话		
				linkman_add,   	--28联系人地址
				rela_code,   	--29联系人关系ID
				'',		--30联系人关系名称
				mari,   	--31婚姻状况id
				'',		--32婚姻状况名称
				coun_code,   	--33国籍id
				'',		--34
				height,   	--35身高30
				weight,   	--36体重
				blood_dress,   	--37血压
				blood_code,  	--38血型编码
				hepatitis_flag, --39重大疾病标志 1:有  0:无
				anaphy_flag,   	--40过敏标志 1有  0:无 35
				in_date,   	--41入院日期
				dept_code,   	--42科室代码
				dept_name,   	--43科室名称
				paykind_code,   --44结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干 40
				'',		--45
				pact_code,   	--46合同代码
				pact_name,   	--47合同单位名称
				bed_no,   	--48床号
				nurse_cell_code,--49护理单元代码
				nurse_cell_name,--50护理单元名称
				house_doc_code, --51医师代码(住院)
				house_doc_name, --52医师姓名(住院)
				charge_doc_code,--53医师代码(主治) 50
				charge_doc_name,--54医师姓名(主治)
				chief_doc_code, --55医师代码(主任)
				chief_doc_name, --56医师姓名(主任)
				'', 		--57实习
				'', 		--58实习55
				duty_nurse_code,--59护士代码(责任)
				duty_nurse_name,--60护士姓名(责任)
				in_circs,   	--61入院情况ID
				'',		--62入院情况Name
				in_avenue,   	--63入院途径ID
				'',		--64入院途径Name
				in_source,   	--65入院来源ID 1:门诊，2:急诊，3:转科，4:转院 60
				'',		--66入院来源Name
				in_state,   	--67在院状态 R-住院登记  I 病房接诊 B-出院登记 O-出院结算 P-预约出院,N-无费退院 C 取消 
				prepay_outdate, --68出院日期(预约) 
				out_date,   	--69出院日期
				in_icu, 	--70是否在ICU
				'', 		--71 icu code
				'', 		--72 icu name
				'', 		--73楼
				'', 		--74层
				'',		--75房间
				tot_cost,   	--76费用金额(未结)
				own_cost,   	--77自费金额(未结)75
				pay_cost,   	--78自付金额(未结)
				pub_cost,   	--79公费金额(未结)
				free_cost,   	--80余额(未结)80
				eco_cost,   	--81优惠金额(未结)
				prepay_cost,   	--82预交金额(未结)
				balance_cost,   --83费用金额(已结)
				balance_prepay, --84预交金额(已结)
				balance_date,   --85结算日期(上次)
				money_alert,   	--86警戒线
				zg,            	--87转归代号
				CHANGE_PREPAYCOST,--88转入预交金
				CHANGE_TOTCOST,   --89转入费用 
				(SELECT t.BED_STATE FROM COM_BEDINFO t WHERE t.BED_NO=d.BED_NO AND PARENT_CODE='[父级编码]' AND CURRENT_CODE='[本级编码]'), --病床状态
				LIMIT_OVERTOP,  --91公费日限额超标部分
				Memo,  		--92特注
				DAY_LIMIT,	--93日限额
				BLOOD_LATEFEE,	--94血滞纳金
				in_times,	--95入院次数
				BED_LIMIT,	--96床位上限
				AIR_LIMIT,	--97空调上限
				CLINIC_DIAGNOSE,--98门诊诊断
				EMPL_CODE,	--99收住医生代码
				PROCREATE_PCNO,	--100生育保险电脑号
				BABY_FLAG,	--101是否有婴儿
				TEND,		--102护理级别 
				fee_interval,	--103固定费用间隔天数
				prefixfee_date,	--104上次固定费用时间
				BEDOVERDEAL,	--105床费超标处理 0超标不限1超标自理
				LIMIT_TOT,	--106公费患者日限额累计
				CASE_FLAG,	--107病案状态: 0 无需病案 1 需要病案 2 医生站形成病案 3 病案室形成病案 4病案封存
				ext_flag,	--108是否允许日限额超标 0 不同意 1 同意 中山一院需求
				ext_flag1,	--109扩展标记1
				ext_flag2,	--110扩展标记2
				BOARD_COST,	--111膳食花费总额
				BOARD_PREPAY,	--112膳食预交金额
				BOARD_STATE,	--113膳食结算状态：0在院 1出院
				OWN_RATE,	--114自费比例
				PAY_RATE,	--115自付比例
				BURSARY_TOTMEDFEE,	--116公费患者公费药品累计(日限额)
				DIAG_NAME   ---117住院主诊断名称 
			FROM 	FIN_IPR_INMAININFO  d				*/
				#endregion
				
				return null;
			}
			return sql;
		}

        #region addby xuewj 2010-9-28 查询患者费用明细 {98057398-9233-4aec-8FAF-662A8E82BF74}
        /// <summary>
        /// 查询患者信息 FIN_IPR_INMAININFO
        /// </summary>
        /// <returns>FIN_IPR_INMAININFO SQL 语句</returns>
        private string LocalPatientQuerySelect()
        {
            string sql = string.Empty;
            if (Sql.GetSql("ZZLocal.Inpatient.PatientQuery.Select.1", ref sql) == -1)
            {
                #region SQL
                /*
				SELECT	inpatient_no,	--0 住院流水号
				name,		--1 姓名
				patient_no,	--2 住院号
				card_no,	--3 就诊卡号
				patient_no,	--4 病历号
				mcard_no,	--5 医疗证号
				MEDICAL_TYPE,	--6 医疗类别
				sex_code,   	--7 性别 M,F,O,U
				idenno,   	--8 身份证号
				spell_code,   	--9 拼音10
				birthday,   	--10生日
				prof_code,   	--11职业代码
				'',		--12 职业名称
				work_name,   	--13工作单位
				work_tel,   	--14工作单位电话15
				work_zip,   	--15单位邮编Memo
				home,   	--16户口或家庭地址
				home_tel,   	--17家庭电话
				home_zip,   	--18户口或家庭邮编		
				'',		--19籍贯id20
				dist,   	--20籍贯name
				birth_area,   	--21出生地代码		
				'',		--22出生地名称
				nation_code,   	--23民族id
				'',		--24民族名称
				'',		--25联系人ID
				linkman_name,   --26联系人姓名			
				linkman_tel,   	--27联系人电话		
				linkman_add,   	--28联系人地址
				rela_code,   	--29联系人关系ID
				'',		--30联系人关系名称
				mari,   	--31婚姻状况id
				'',		--32婚姻状况名称
				coun_code,   	--33国籍id
				'',		--34
				height,   	--35身高30
				weight,   	--36体重
				blood_dress,   	--37血压
				blood_code,  	--38血型编码
				hepatitis_flag, --39重大疾病标志 1:有  0:无
				anaphy_flag,   	--40过敏标志 1有  0:无 35
				in_date,   	--41入院日期
				dept_code,   	--42科室代码
				dept_name,   	--43科室名称
				paykind_code,   --44结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干 40
				'',		--45
				pact_code,   	--46合同代码
				pact_name,   	--47合同单位名称
				bed_no,   	--48床号
				nurse_cell_code,--49护理单元代码
				nurse_cell_name,--50护理单元名称
				house_doc_code, --51医师代码(住院)
				house_doc_name, --52医师姓名(住院)
				charge_doc_code,--53医师代码(主治) 50
				charge_doc_name,--54医师姓名(主治)
				chief_doc_code, --55医师代码(主任)
				chief_doc_name, --56医师姓名(主任)
				'', 		--57实习
				'', 		--58实习55
				duty_nurse_code,--59护士代码(责任)
				duty_nurse_name,--60护士姓名(责任)
				in_circs,   	--61入院情况ID
				'',		--62入院情况Name
				in_avenue,   	--63入院途径ID
				'',		--64入院途径Name
				in_source,   	--65入院来源ID 1:门诊，2:急诊，3:转科，4:转院 60
				'',		--66入院来源Name
				in_state,   	--67在院状态 R-住院登记  I 病房接诊 B-出院登记 O-出院结算 P-预约出院,N-无费退院 C 取消 
				prepay_outdate, --68出院日期(预约) 
				out_date,   	--69出院日期
				in_icu, 	--70是否在ICU
				'', 		--71 icu code
				'', 		--72 icu name
				'', 		--73楼
				'', 		--74层
				'',		--75房间
				tot_cost,   	--76费用金额(未结)
				own_cost,   	--77自费金额(未结)75
				pay_cost,   	--78自付金额(未结)
				pub_cost,   	--79公费金额(未结)
				free_cost,   	--80余额(未结)80
				eco_cost,   	--81优惠金额(未结)
				prepay_cost,   	--82预交金额(未结)
				balance_cost,   --83费用金额(已结)
				balance_prepay, --84预交金额(已结)
				balance_date,   --85结算日期(上次)
				money_alert,   	--86警戒线
				zg,            	--87转归代号
				CHANGE_PREPAYCOST,--88转入预交金
				CHANGE_TOTCOST,   --89转入费用 
				(SELECT t.BED_STATE FROM COM_BEDINFO t WHERE t.BED_NO=d.BED_NO AND PARENT_CODE='[父级编码]' AND CURRENT_CODE='[本级编码]'), --病床状态
				LIMIT_OVERTOP,  --91公费日限额超标部分
				Memo,  		--92特注
				DAY_LIMIT,	--93日限额
				BLOOD_LATEFEE,	--94血滞纳金
				in_times,	--95入院次数
				BED_LIMIT,	--96床位上限
				AIR_LIMIT,	--97空调上限
				CLINIC_DIAGNOSE,--98门诊诊断
				EMPL_CODE,	--99收住医生代码
				PROCREATE_PCNO,	--100生育保险电脑号
				BABY_FLAG,	--101是否有婴儿
				TEND,		--102护理级别 
				fee_interval,	--103固定费用间隔天数
				prefixfee_date,	--104上次固定费用时间
				BEDOVERDEAL,	--105床费超标处理 0超标不限1超标自理
				LIMIT_TOT,	--106公费患者日限额累计
				CASE_FLAG,	--107病案状态: 0 无需病案 1 需要病案 2 医生站形成病案 3 病案室形成病案 4病案封存
				ext_flag,	--108是否允许日限额超标 0 不同意 1 同意 中山一院需求
				ext_flag1,	--109扩展标记1
				ext_flag2,	--110扩展标记2
				BOARD_COST,	--111膳食花费总额
				BOARD_PREPAY,	--112膳食预交金额
				BOARD_STATE,	--113膳食结算状态：0在院 1出院
				OWN_RATE,	--114自费比例
				PAY_RATE,	--115自付比例
				BURSARY_TOTMEDFEE,	--116公费患者公费药品累计(日限额)
				DIAG_NAME   ---117住院主诊断名称 
			FROM 	FIN_IPR_INMAININFO  d				*/
                #endregion

                return null;
            }
            return sql;
        } 
        #endregion

		#endregion
		#endregion 
		
		#region 过期
		
		#region 按入院时间和状态查询患者基本信息列表

		/// <summary>
		/// 患者查询-按入院时间和状态查
		/// </summary>
		/// <param name="beginDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <param name="State"></param>
		/// <returns></returns>
        [Obsolete("QueryPatientBasic代替", true)]
		public ArrayList PatientQueryBasic(DateTime beginDateTime, DateTime endDateTime, InStateEnumService State)
		{
			string sql1 = string.Empty;
			string sql2 = string.Empty;
			
			sql1 = PatientQueryBasicSelect();
			
			if (sql1 == null)
			{
				return null;
			}

			string[] arg = new string[3];
			arg[0] = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			arg[1] = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			arg[2] = State.ID.ToString();
			if (Sql.GetSql("RADT.Inpatient.PatientQuery.Where.8", ref sql2) == -1)
				#region SQL
				/*where PARENT_CODE='[父级编码]' and CURRENT_CODE='[本级编码]' and (TRUNC(in_date) >=to_date('{0}','yyyy-mm-dd')) and (TRUNC(in_date) <=to_date('{1}','yyyy-mm-dd')) and In_state='{2}'*/
				#endregion
			{;
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, arg);
			
			return myPatientBasicQuery(sql1);
		}

		#endregion
		
		#region 按入院开始时间和结束时间查询患者基本信息列表

		/// <summary>
		/// 患者查询--按入院时间查询 wangrc
		/// </summary>
		/// <param name="beginDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <returns></returns>
        public ArrayList QueryPatientBasic(DateTime beginDateTime, DateTime endDateTime)
		{
			#region 接口说明

			/////RADT.Inpatient.2
			//传入:住院时间开始，结束
			//传出：患者信息

			#endregion

			string sql1 = string.Empty, sql2 = string.Empty;
			sql1 = PatientQueryBasicSelect();
			if (sql1 == null)
			{
				return null;
			}

			string[] arg = new string[2];
			arg[0] = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			arg[1] = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);

			if (Sql.GetSql("RADT.Inpatient.PatientQueryByDateIn", ref sql2) == -1)
			{
				return null;
			}
			sql1 = sql1 + " " + string.Format(sql2, arg);
			return myPatientBasicQuery(sql1);
		}

		#endregion
		
		[Obsolete("更改为 QueryMedicarePatientInfo",true)]
		public ArrayList PatientQueryMedicare(DateTime beginDateTime, DateTime endDateTime, string inState, string deptCode,string pactCode)
		{
			return null;
		}
		#endregion

        #region 查询患者
        /// <summary>
        ///  查询出院几天内的患者信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="outDays"></param>
        /// <returns></returns>
        public ArrayList PatientQuery(string deptCode, int outDays)
        {
            string sql = "";
            string strWhere = "";
            if (this.Sql.GetSql("RADT.Inpatient.PatientQuery.Select.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("RADT.Inpatient.PatientQuery.Where.35", ref strWhere) == -1) return null;

            sql = sql + " " + strWhere;
            try
            {
                sql = string.Format(sql, deptCode, outDays.ToString());
            }
            catch { return null; }
            return this.myPatientQuery(sql);
        }
        #endregion


        #region 更改患者病情{F0C48258-8EFB-4356-B730-E852EE4888A0}
        /// <summary>
        /// 更新患者病情状态（更新为病重）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateBZ_Info(string id)
        {
            string strsql="";
            try
            {
                string sql = "update  fin_ipr_inmaininfo t  set t.CRITICAL_FLAG='1'  where t.inpatient_no='{0}'";
                strsql = string.Format(sql, id);                
            }
            catch(Exception e)
            {
                this.ErrCode = e.Message;
                this.Err = e.Message;
                return -1;
            }
            return ExecNoQuery(strsql);
        }
        /// <summary>
        /// 更新患者病情状态（更新为普通）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdatePT_Info(string id)
        {
            string strsql = "";
            try
            {
                string sql = "update  fin_ipr_inmaininfo t  set t.CRITICAL_FLAG='0'  where t.inpatient_no='{0}'";
                strsql = string.Format(sql, id);
            }
            catch (Exception e)
            {
                this.ErrCode = e.Message;
                this.Err = e.Message;
                return -1;
            }
            return ExecNoQuery(strsql);
        }

        public string SelectBQ_Info(string id)
        {
            PatientInfo PatientInfo = new PatientInfo();
            string strsql = "";
                string sql = "select a.critical_flag from fin_ipr_inmaininfo a where a.inpatient_no ='{0}'";
                strsql = string.Format(sql, id);
                if (ExecQuery(strsql) < 0)
                {
                    return null;
                }
                if (Reader.Read())
                {
                    try
                    {
                        PatientInfo.ExtendFlag1 = Reader[0].ToString();//查询患者病情信息
                    }
                    catch (Exception e)
                    {
                        Err = e.Message;
                        WriteErr();
                        if (!Reader.IsClosed)
                        {
                            Reader.Close();
                        }
                        return "0";
                    }
                }               
            Reader.Close();
            return PatientInfo.ExtendFlag1;
        }
        #endregion

        #region 基本信息修改 修改明细，处方明细表中名称{F577FEF5-53D1-4768-B345-F2EBD3E9DF9C}

        /// <summary>
        /// 更新非药品明细
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int ModifyPatientNOForFeeItemList(string inpatientNO,string patientName)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("RADT.UpdateFeeItemListPatientName", ref strSql);
            if (returnValue < 0)
            {
                this.Err = "没有找到RADT.UpdateFeeItemListPatientName 对应的sql语句";
            }

            try
            {
                strSql = string.Format(strSql, inpatientNO, patientName);
            }
            catch (Exception ex)
            {

                this.Err = "格式化数据失败";
                return -1;
            }

            return this.ExecNoQuery(strSql); 
            
            
            return 1;
        }
        /// <summary>
        /// 更新药品明细
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int ModifyPatientNOForMedicineList(string inpatientNO, string patientName)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("RADT.UpdateMedicineListPatientName", ref strSql);
            if (returnValue < 0)
            {
                this.Err = "没有找到RADT.UpdateMedicineListPatientName 对应的sql语句";
            }

            try
            {
                strSql = string.Format(strSql, inpatientNO, patientName);
            }
            catch (Exception ex)
            {

                this.Err = "格式化数据失败";
                return -1;
            }

            return this.ExecNoQuery(strSql);


            return 1;
        }
        /// <summary>
        /// 更新处方明细
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int ModifyPatientNOForFeeInfo(string inpatientNO, string patientName)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("RADT.UpdateFeeInfoPatientName", ref strSql);
            if (returnValue < 0)
            {
                this.Err = "没有找到RADT.UpdateMedicineListPatientName 对应的sql语句";
            }

            try
            {
                strSql = string.Format(strSql, inpatientNO, patientName);
            }
            catch (Exception ex)
            {

                this.Err = "格式化数据失败";
                return -1;
            }

            return this.ExecNoQuery(strSql);


            return 1;
        }
       

        #endregion

    }
}