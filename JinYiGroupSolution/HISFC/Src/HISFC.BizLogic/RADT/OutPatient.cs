using System;
using System.Collections;
using System.Globalization;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizLogic.RADT
{
	public class OutPatient : Database
	{
		/// <summary>
		/// write by lisy 2005-01-01
		/// </summary>
		///<history>
		/// adjust by zhouxs 2005-5-16
		///</history>
		public OutPatient()
		{
		}

		#region 域

		#endregion

		#region 属性

		#endregion

		#region 方法

		#region 公有方法

		#endregion

		#region 注册患者信息(没写呢)

		/// <summary>
		/// 注册患者信息
		/// </summary>
		/// <param name="PatientInfo">登记的患者信息</param>
		/// <returns>0成功 -1失败</returns>
		public int RegisterPatient(PatientInfo PatientInfo)
		{
			return 0;
		}

		#endregion

		#region 注销患者信息(没写呢)

		/// <summary>
		/// 注销用户
		/// </summary>
		/// <param name="PatientInfo">登记的患者信息</param>
		/// <returns>0成功 -1失败</returns>
		public int DischargePatient(PatientInfo PatientInfo)
		{
			return 0;
		}

		#endregion

		#region 更新患者信息(没写呢)

		/// <summary>
		/// 更新患者信息 以住院流水号为主键
		/// </summary>
		/// <param name="PatientInfo"></param>
		/// <returns>0 成功 -1失败</returns>
		public int UpdatePatient(PatientInfo PatientInfo)
		{
			return 0;
		}

		#endregion

		#region	删除患者信息(没写呢)

		/// <summary>
		/// 删除患者信息
		/// </summary>
		/// <param name="PatientInfo"></param>
		/// <returns>0 成功 -1 失败</returns>
		public int DeletePatient(PatientInfo PatientInfo)
		{
			return 0;
		}

		#endregion

		#region 更改变化住院号(没写呢)

		/// <summary>
		/// 变化住院号
		/// </summary>
		/// <param name="PatientInfo"></param>
		/// <param name="newPatientNo"></param>
		/// <returns></returns>
		public int ChangePID(PatientInfo PatientInfo, string newPatientNo)
		{
			return 0;
		}

		#endregion

		#region 生成新的门诊号(没写呢)

		/// <summary>
		/// 生成新的门诊号
		/// </summary>
		/// <returns>返回新的门诊号</returns>
		public string GetNewCardNo()
		{
			return "";
		}

		#endregion

		#region 按门诊卡号查询患者信息

		//患者查询
		/// <summary>
		/// 按门诊卡号查询患者信息
		/// </summary>
		/// <param name="strPatientNo"></param>
		/// <returns>患者信息实体</returns>
		public PatientInfo PatientQuery(string strPatientNo)
		{
			string strSql = "";

			#region 接口说明

			//RADT.OutPatient.Get.2
			//传入:门诊号
			//传出：患者信息

			#endregion

			if (Sql.GetSql("RADT.OutPatient.Get.2", ref strSql) == -1) return null;
			try
			{
				strSql = string.Format(strSql, strSql);
			}
			catch
			{
				Err = "参数不对！RADT.OutPatient.Get.2";
				WriteErr();
				return null;
			}
			ArrayList al = myPatientQuery(strSql);
			if (al.Count > 0) return (PatientInfo) al[0];
			return null;
		}

		#endregion

		#region 按入院时间段和状态查询患者信息

		/// <summary>
		/// 患者查询-按入院时间段和状态查询患者信息
		/// </summary>
		/// <param name="beginDateTime"></param>
		/// <param name="endDateTime"></param>
		/// <param name="State"></param>
		/// <returns>ArrayList列表</returns>
		public ArrayList PatientQuery(DateTime beginDateTime, DateTime endDateTime, InStateEnumService State)
		{
			#region 接口说明

			//RADT.OutPatient.1
			//传入:注册时间开始，结束，状态
			//传出：患者信息

			#endregion

			string strSql = "";
			string[] strArg = new string[3];
			strArg[0] = beginDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			strArg[1] = endDateTime.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
			strArg[2] = State.ID.GetHashCode().ToString();
			if (Sql.GetSql("RADT.OutPatient.1", ref strSql) == -1)
			{
				Err = "没有找到RADT.OutPatient.1字段!";
				ErrCode = "-1";
				WriteErr();
				return null;
			}
			strSql = string.Format(strSql, strArg);
			return myPatientQuery(strSql);
		}

		#endregion

		#region 更新电脑卡信息	

		/// <summary>
		/// 更新电脑卡信息 
		/// </summary>
		/// <param name="card">患者就诊卡信息</param>
		/// <returns>0 成功 -1 失败</returns>
		public int UpdateCardInfo(Card card)
		{
			#region 接口说明

			//卡号密码信息。RADT.OutPatient.UpdateCardInfo.1
			//update com_patientinfo
			//			set 
			//			IC_CARDNO='{1}',--电脑卡号
			//			ACT_CODE ='{2}'--账户密码 
			//			where 
			//			CARD_NO='{0}'--卡号 

			#endregion

			string strSql = "";
			try
			{
				if (Sql.GetSql("RADT.OutPatient.UpdateCard", ref strSql) == 0)
				{
					strSql = string.Format(strSql, card.ID, card.ICCard.ID);
				}
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#endregion

		public int UpdateCardState(string Card, string State)
		{
			#region 接口说明

			//卡号密码信息。RADT.OutPatient.UpdateCardInfo.1
			//update com_patientinfo
			//			set 
			//			IC_CARDNO='{1}',--电脑卡号
			//			ACT_CODE ='{2}'--账户密码 
			//			where 
			//			CARD_NO='{0}'--卡号 

			#endregion

			string strSql = "";
			try
			{
				if (Sql.GetSql("RADT.OutPatient.LoseCard", ref strSql) == 0)
				{
					strSql = string.Format(strSql, Card, State);
				}
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		#region 更新患者密码信息

		/// <summary>
		/// 密码变更记录
		/// </summary>
		/// <param name="card"></param>
		/// <returns>0 成功 -1 失败</returns>
		public int InsertPassWord(Card card)
		{
			#region

			//			insert into com_passwordrecord( parent_code,   --父级医疗机构编码
			//		            current_code,   --本级医疗机构编码		            
			//                CARD_NO,	--医疗流水号 门诊是挂号单号  住院是住院流水号
			//                HAPPEN_NO,	--发生序号
			//                OLD_PASSWORD,	--	原密码
			//                NEW_PASSWORD,	--		现密码
			//                OPER_CODE,--	操作员
			//                OPER_DATE	--		操作时间
			//                  VALUES 
			//		               ( '[父级编码]',   --父级医疗机构编码
			//		            '[本级编码]',   --本级医疗机构编码
			//		            '{0}',   --搅屏魉?门诊是挂号单号  住院是住院流水号
			//		            '{1}',   --发生序号
			//		            '{2}',   --原密码
			//		            '{3}',   --现密码
			//                '{4}',   --操作人		            
			//		            sysdate)  --操作时间		           

			#endregion

			string strSql = "";
			//			string strNo="";
			NeuObject obj = new NeuObject();

			if (Sql.GetSql("RADT.OutPatient.InsertPassWord", ref strSql) == -1) return -1;
			try
			{
				strSql = string.Format(strSql, card.ID, card.NewPassword, card.OldPassword, Operator.ID);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				return -1;
			}
			return ExecNoQuery(strSql);
        }

        #region 急诊留观登记\接诊\结束

        #region 急诊留观登记
        /// <summary>
        /// 急诊留观登记,同时向变更信息表中插入一条记录
        /// </summary>
        /// <param name="PatientInfo">预约床位放置在PatientInfo的bed 中</param>
        /// <returns>大于 0 成功 小于 0 失败</returns>
        public int RegisterObservePatient(Neusoft.HISFC.Models.Registration.Register OutPatient)
        {
            //更新留观标志
            if (UpdateEmergencyObserve(OutPatient.ID,Neusoft.HISFC.Models.Base.EnumInState.N,Neusoft.HISFC.Models.Base.EnumInState.R,GetSysDateTime(),DateTime.MinValue.ToString(),"") <= 0)
            {
                Err = "更新留观标志失败";
                WriteErr();
                return -1;
            }

            InPatient InpatentManager = new InPatient();

            InpatentManager.SetTrans(this.Trans);

            //更新变更记录主表
            if (InpatentManager.SetShiftData(OutPatient.ID, Neusoft.HISFC.Models.Base.EnumShiftType.EB, "留观登记", OutPatient.DoctorInfo.Templet.Dept, OutPatient.DoctorInfo.Templet.Dept) >= 0)
            {
                return 0;
            }

            Err = "更新变更记录表失败";
            WriteErr();
            return -1;
        }
        #endregion

        #region 急诊留观接诊

        /// <summary>
        /// 急诊留观接诊
        /// </summary>
        /// <param name="register">急诊留观患者</param>
        /// <returns></returns>
        public int RecievePatient(Neusoft.HISFC.Models.Registration.Register patientInfo, Neusoft.HISFC.Models.Base.Bed bed, Neusoft.HISFC.Models.Base.EnumShiftType type, string notes)
        {
            InPatient InpatentManager = new InPatient();

            InpatentManager.SetTrans(this.Trans);

            Neusoft.HISFC.Models.Base.EnumInState status = Neusoft.HISFC.Models.Base.EnumInState.R;
            int parm;

            //更新前的床位信息
            Bed oldBed = new Bed();
            oldBed.InpatientNO = "N"; //'N'代表没有患者
            oldBed.Status.ID = "U"; //'U'代表空床

            //更新后的床位信息
            bed.InpatientNO = patientInfo.ID;
            bed.Status.ID = "O";

            //更新床位信息
            parm = this.UpdateBedStatus(bed, oldBed);
            if (parm != 1)
            {
                return parm;
            }

            patientInfo.PVisit.PatientLocation.Bed = bed;

            if (type.ToString() == "EK")
                //对于变更类型等于"接珍K"的在院状态是"入院登记R"
                status = Neusoft.HISFC.Models.Base.EnumInState.R;
            else if (type.ToString() == "EC")
                //对于变更类型等于"召回C"的在院状态是"出院登记B"
                status = Neusoft.HISFC.Models.Base.EnumInState.B;

            string strSql = "";
            //接珍处理
            //更新患者接诊记录
            if (Sql.GetSql("RADT.InPatient.ArrivePatient.2", ref strSql) == -1) return -1;
            try
            {
                string[] n = {
				             	patientInfo.ID,
				             	patientInfo.PVisit.PatientLocation.Dept.ID,
				             	patientInfo.PVisit.PatientLocation.Dept.Name,
				             	patientInfo.PVisit.PatientLocation.Bed.ID,
				             	patientInfo.PVisit.PatientLocation.Bed.Status.ID.ToString(),
				             	patientInfo.PVisit.AttendingDoctor.ID,
				             	patientInfo.PVisit.AttendingDoctor.Name,
				             	patientInfo.PVisit.ReferringDoctor.ID,
				             	patientInfo.PVisit.ReferringDoctor.Name,
				             	patientInfo.PVisit.ConsultingDoctor.ID,
				             	patientInfo.PVisit.ConsultingDoctor.Name,
				             	patientInfo.PVisit.AdmittingDoctor.ID,
				             	patientInfo.PVisit.AdmittingDoctor.Name,
				             	patientInfo.PVisit.AdmitSource.ID,
				             	patientInfo.PVisit.AdmitSource.Name,
				             	patientInfo.PVisit.AdmittingNurse.ID,
				             	patientInfo.PVisit.AdmittingNurse.Name,
				             	patientInfo.PVisit.InSource.ID,
				             	patientInfo.PVisit.InSource.Name,
				             	patientInfo.PVisit.Circs.ID,
				             	patientInfo.PVisit.Circs.Name,
				             	patientInfo.PVisit.PatientLocation.NurseCell.ID,
				             	patientInfo.PVisit.PatientLocation.NurseCell.Name,
				             	Operator.ID, //操作人编码
                                patientInfo.PVisit.AttendingDirector.ID,//科主任编码
                                patientInfo.PVisit.AttendingDirector.Name//科主任名称
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
            };
            
            //变更信息
            if (InpatentManager.SetShiftData(patientInfo.ID, type, notes, patientInfo.PVisit.PatientLocation.NurseCell, patientInfo.PVisit.PatientLocation.Bed) < 0)
            {
                return -1;
            }
            if (type.ToString() == "EC") //出院召回
            {
                //更新病人状态
                if (UpdateEmergencyObserve(patientInfo.ID, Neusoft.HISFC.Models.Base.EnumInState.B, Neusoft.HISFC.Models.Base.EnumInState.I,patientInfo.PVisit.InTime.ToString(), patientInfo.PVisit.OutTime.ToString(), patientInfo.PVisit.ZG.ID) <= 0)
                {
                    return -1;
                }
            }
            //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            else if (type.ToString() == "IC") //留观转住院召回
            {
                //更新病人状态
                if (UpdateEmergencyObserve(patientInfo.ID, Neusoft.HISFC.Models.Base.EnumInState.C, Neusoft.HISFC.Models.Base.EnumInState.I, patientInfo.PVisit.InTime.ToString(), patientInfo.PVisit.OutTime.ToString(), patientInfo.PVisit.ZG.ID) <= 0)
                {
                    return -1;
                }
            }
            else
            {
                //更新病人状态
                if (UpdateEmergencyObserve(patientInfo.ID, Neusoft.HISFC.Models.Base.EnumInState.R, Neusoft.HISFC.Models.Base.EnumInState.I, patientInfo.PVisit.InTime.ToString(), patientInfo.PVisit.OutTime.ToString(), patientInfo.PVisit.ZG.ID) <= 0)
                {
                    return -1;
                }
            }
            return 1;
        }

        #endregion

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        #region 留观患者出关
        /// <summary>
        /// 留观患者出关函数
        /// </summary>
        /// <param name="OutPatient">患者信息</param>
        /// <param name="type">EO留观出院登记 CPI留观转住院 CI留观住院</param>
        /// <returns></returns>
        public int OutObservePatientManager(Neusoft.HISFC.Models.Registration.Register OutPatient,Neusoft.HISFC.Models.Base.EnumShiftType type,string note)
        {
            Neusoft.HISFC.Models.RADT.ShiftTypeEnumService shiftService = new ShiftTypeEnumService();
            int resultValue = 0;
            
            switch (type)
            {
                case EnumShiftType.EO:
                    {
                        //留观出院登记
                        resultValue = UpdateEmergencyObserve(OutPatient.ID, Neusoft.HISFC.Models.Base.EnumInState.I, Neusoft.HISFC.Models.Base.EnumInState.P, OutPatient.PVisit.InTime.ToString(), DateTime.MinValue.ToString(), "");
                        break;
                    }
                case EnumShiftType.CPI:
                    {
                        //留观转住院
                        resultValue = UpdateEmergencyObserve(OutPatient.ID, Neusoft.HISFC.Models.Base.EnumInState.I, Neusoft.HISFC.Models.Base.EnumInState.E, OutPatient.PVisit.InTime.ToString(), GetSysDateTime(), "");
                        break;
                    }
                case EnumShiftType.CI:
                    {
                        //留观住院
                        resultValue = UpdateEmergencyObserve(OutPatient.ID, Neusoft.HISFC.Models.Base.EnumInState.E, Neusoft.HISFC.Models.Base.EnumInState.C, OutPatient.PVisit.InTime.ToString(), GetSysDateTime(), "");
                        if (resultValue > 0)
                        {
                            //释放床位
                            Bed newBed = OutPatient.PVisit.PatientLocation.Bed.Clone();
                            OutPatient.PVisit.PatientLocation.Bed.InpatientNO = OutPatient.ID;
                            OutPatient.PVisit.PatientLocation.Bed.Status.ID = EnumBedStatus.O;
                            newBed.Status.ID = EnumBedStatus.U.ToString();
                            newBed.InpatientNO = "N";

                            //更新床位状态,并判断并发

                            resultValue = this.UpdateBedStatus(newBed, OutPatient.PVisit.PatientLocation.Bed);
                            if (resultValue <= 0)
                            {
                                return -1;
                            }
                        }
                        break;
                    }
            }
            
            if(resultValue <=0)
            {
                Err = "更新留观标志失败";
                return -1;
            }

            InPatient InpatentManager = new InPatient();

            InpatentManager.SetTrans(this.Trans);

            //更新变更记录主表
            if (InpatentManager.SetShiftData(OutPatient.ID, type, note, OutPatient.DoctorInfo.Templet.Dept, OutPatient.DoctorInfo.Templet.Dept) >= 0)
            {
                return 1;
            }

            Err = "更新变更记录表失败";
            return -1;
            
        }
        #endregion


        #region MyRegion

        /// <summary>
		/// 患者出院登记
		/// </summary>
		/// <param name="patientInfo">患者基本信息</param>
		/// <returns></returns>
		public int RegisterOutHospital(Neusoft.HISFC.Models.Registration.Register patientInfo)
		{
            InPatient InpatentManager = new InPatient();
            if (this.Trans != null)
            {
                InpatentManager.SetTrans(this.Trans);
            }
            Bed newBed = patientInfo.PVisit.PatientLocation.Bed.Clone();
            patientInfo.PVisit.PatientLocation.Bed.InpatientNO = patientInfo.ID;
            patientInfo.PVisit.PatientLocation.Bed.Status.ID = EnumBedStatus.O;
			newBed.Status.ID = EnumBedStatus.U.ToString();
			newBed.InpatientNO = "N";

			//更新床位状态,并判断并发
           
			int parm = this.UpdateBedStatus(newBed, patientInfo.PVisit.PatientLocation.Bed);
			if (parm <= 0)
			{
				return parm;
			}
			 
			//变更信息处理
            if (InpatentManager.SetShiftData(patientInfo.ID, EnumShiftType.EO,
			                 "出院登记", patientInfo.DoctorInfo.Templet.Dept, patientInfo.DoctorInfo.Templet.Dept) < 0)
            {
				return -1;
            }

		    //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            this.UpdateEmergencyObserve(patientInfo.ID,EnumInState.P,EnumInState.B,patientInfo.PVisit.InTime.ToString(),patientInfo.PVisit.OutTime.ToString(),patientInfo.PVisit.ZG.ID  );
            
            return 1; 
         
		}
        /// <summary>
        /// 记录包床、挂床信息 BED_KIND 1 挂床 2 包床
        /// STATUS 状态 0 挂床 1 解挂
        /// </summary>
        /// <param name="inpatientNO">住院号</param>
        /// <param name="bedNO">床号</param>
        /// <param name="kind">类别</param>
        /// <returns>大于 0 成功，小于 0 失败</returns>
        public int ChangeBedInfo(string clinicNO, string bedNO, string kind)
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
                strSql = string.Format(strSql, clinicNO, bedNO, kind, Operator.ID);
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
                    strSql = string.Format(strSql, clinicNO, bedNO, kind, Operator.ID);
                }
                catch (Exception ex)
                {
                    Err = ex.Message;
                    WriteErr();
                    return -1;
                }
                return ExecNoQuery(strSql);
            }
            return 0;
        }

        /// <summary>
        /// 查询患者特殊床位占用信息（包床、挂床）
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <returns></returns>
        public ArrayList GetSpecialBedInfo(string clinicNO)
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
            sql = string.Format(sql, clinicNO);
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
        /// <summary>
        /// 解包床 将某个包床释放
        /// 解挂床用此函数必须确定目标床位未占用
        /// </summary>
        /// <param name="patientInfo">患者基本信息</param>
        /// <param name="bedNO">病床id</param>
        /// <param name="type">1挂床 2  包床</param>
        /// <returns>0没有更新 1成功 -1 失败</returns>
        public int UnWrapPatientBed(Neusoft.HISFC.Models.Registration.Register patientInfo, string bedNO, string type)
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

        /// <summary>
        /// 转移患者 -换床，换科室，换病区
        /// 需要事务操作(更新病床表,更新变更表)
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="newLocation">新的位置信息</param>
        /// <returns>0没有更新(并发操作),1成功 -1失败</returns>
        public int TransferPatient(Neusoft.HISFC.Models.Registration.Register PatientInfo, Location newLocation)
        {
             InPatient InpatentManager = new InPatient();

            if (this.Trans != null)
            {
                InpatentManager.SetTrans(this.Trans);
            }
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


           

            //如果患者床位发生变化,则更新病床表信息(此处的处理有:转床,转入,转病区)
            if (newLocation.Bed.ID != PatientInfo.PVisit.PatientLocation.Bed.ID)
            {
                //更新患者所在床位的信息
                //保存新床位变更前的信息,用于判断并发
                Bed tempBed = newLocation.Bed.Clone();
                //oldBed.InpatientNo  = "N";
                //oldBed.BedStatus.ID = "U";

                //处理变更信息
                if (InpatentManager.SetShiftData(PatientInfo.ID, EnumShiftType.RB,
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
                int parm = UpdateBedStatus(tempBed, newLocation.Bed);
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
        #region 转床

        /// <summary>
        /// 交换两个人的床位信息
        /// <br>传入：源患者,目标患者</br>
        /// </summary>
        /// <param name="sourcePatientInfo">原患者基本信息</param>
        /// <param name="targetPatientInfo">目标患者基本信息</param>
        /// <returns>0成功 -1失败</returns>
        public int SwapPatientBed(Neusoft.HISFC.Models.Registration.Register sourcePatientInfo, Neusoft.HISFC.Models.Registration.Register targetPatientInfo)
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

       
        #endregion

		#endregion
        #endregion


        /// <summary>
        /// 急诊留观登记\接诊\结束
        /// </summary>
        /// <param name="clinicID">门诊号</param>
        /// <param name="enuInstate">状态</param>
        /// <param name="dtBeginTime">开始时间</param>
        /// <param name="dtEndTime">结束时间</param>
        /// <param name="strZG">转归代码</param>
        /// <returns>-1失败,其它成功</returns>
        public int UpdateEmergencyObserve(string clinicID, Neusoft.HISFC.Models.Base.EnumInState oldenuInstate, Neusoft.HISFC.Models.Base.EnumInState newenuInstate, string dtBeginTime, string dtEndTime, string strZG)
        {
            string StrSql = "";
            if (this.Sql.GetSql("RADT.OutPatient.UpdateEmergencyObserve.1", ref StrSql) == -1) return -1;
            StrSql = string.Format(StrSql, clinicID, oldenuInstate,newenuInstate,dtBeginTime, dtEndTime, strZG);
            return this.ExecNoQuery(StrSql);

        }
      

		#endregion

		#region 私有方法

		#endregion

		#region 根据传入sql语句查询患者信息

		/// <summary>
		/// 根据传入sql语句查询患者信息
		/// </summary>
		/// <param name="strSql">传入sql语句</param>
		/// <returns>ArrayList患者信息列表</returns>
		private ArrayList myPatientQuery(string strSql)
		{
			ArrayList al = new ArrayList();
			PatientInfo PatientInfo;
			ProgressBarText = "正在查询患者...";
			ProgressBarValue = 0;

			try
			{
				ExecQuery(strSql);
				try
				{
					while (Reader.Read())
					{
						PatientInfo = new PatientInfo();
						//<!--0 id, 1 name, 2 住院号, 3 门诊号, 4 病历号, 5 社保号
						//	 6 出生日期, 7 sex id or Name,8,address,9 country ,10 phone_home
						//	 11 phone_work,12 婚姻状态 id,13 身份证,14 民族,15 死亡时间
						//	 16 死亡证明人,17 职业 id,18 职业name ,19 籍贯
						//	-->
						//患者访问信息	<!--0 id, 1 name, 20 患者类别id, 21 科室id, 22 科室name, 23 病区id
						//			  24 病区name, 25 楼,26,层,27 屋 ,28 病床
						//			  29 病床状态,30 主治医师 id,31 主治医师name,32 副主任医师id,33 副主任医师 name
						//			  34 主任医师id,35 主任医师name,36 住院医师id  ,37 住院医师name,38,转入/转出科室 id
						//			  39 转入/转出科室name,40 在ICU科室 id ,41 在ICU科室 name,42 入院途径 id,43 入院途径 name
						//			  44 责任护士 id ,45 责任护士 name,46 费用状态id,47 费用状态 name,48 住院状态id,
						//			  49 住院日期 ,50 出院日期 ,51 预约出院日期 ,52 注册日期,53 午别id,
						//			  54 午别 name,55 看诊序号 -->
						//	患者费用信息
						//<!--0 id,1 name,56  总共金额tot_cost,57 自费金额 own_cost,
						//58  自付金额 Pay_Cost,59 公费金额 Pub_Cost,
						//60  剩余金额 Left_Cost,61 减免金额 Dereate_Cost
						//62  补收金额 Supply_Cost;-->

						#region 获得患者基本信息

						try
						{
							PatientInfo.ID = Reader[0].ToString();
							PatientInfo.Name = Reader[1].ToString();
							PatientInfo.ID = PatientInfo.ID;
							PatientInfo.Name = PatientInfo.Name;
							PatientInfo.PID.PatientNO = Reader[2].ToString();
							PatientInfo.PID.CardNO = Reader[3].ToString();
							PatientInfo.PID.CaseNO = Reader[4].ToString();
							PatientInfo.SSN = Reader[5].ToString();
							try
							{
								PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[6].ToString());
							}
							catch
							{
							}
							PatientInfo.Sex.ID = (Reader[7].ToString());

							PatientInfo.AddressHome = Reader[8].ToString();
							PatientInfo.Country.Name = Reader[9].ToString();
							PatientInfo.PhoneHome = Reader[10].ToString();
							PatientInfo.PhoneBusiness = Reader[11].ToString();
							PatientInfo.MaritalStatus.ID = Reader[12].ToString();
							PatientInfo.IDCard = Reader[13].ToString();
							PatientInfo.Nationality.ID = Reader[14].ToString();
							try
							{
								PatientInfo.DeathTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[15].ToString());
							}
							catch
							{
							}
							PatientInfo.DeathAttestor.Name = Reader[16].ToString();
							PatientInfo.Profession.ID = Reader[17].ToString();
							PatientInfo.Profession.Name = Reader[18].ToString();
							PatientInfo.DIST = Reader[19].ToString();
						}
						catch (Exception ex)
						{
							Err = "读取患者基本信息出错！" + ex.Message;
							WriteErr();
							al = null;
						}

						#endregion

						#region 患者访问信息

						try
						{
							PatientInfo.PVisit.ID = PatientInfo.ID;
							PatientInfo.PVisit.Name = PatientInfo.Name;
							PatientInfo.PVisit.PatientType.ID = Reader[20].ToString();
							PatientInfo.PVisit.PatientLocation.Dept.ID = Reader[21].ToString();
							PatientInfo.PVisit.PatientLocation.Dept.Name = Reader[22].ToString();
							PatientInfo.PVisit.PatientLocation.NurseCell.ID = Reader[23].ToString();
							PatientInfo.PVisit.PatientLocation.NurseCell.Name = Reader[24].ToString();
							PatientInfo.PVisit.PatientLocation.Building = Reader[25].ToString();
							PatientInfo.PVisit.PatientLocation.Floor = Reader[26].ToString();
							PatientInfo.PVisit.PatientLocation.Room = Reader[27].ToString();
							PatientInfo.PVisit.PatientLocation.Bed.ID = Reader[28].ToString();
							PatientInfo.PVisit.PatientLocation.Bed.Status.ID = Reader[29].ToString();
						}
						catch (Exception ex)
						{
							Err = "读取患者访问基本信息出错！" + ex.Message;
							WriteErr();
							al = null;
						}

						#endregion

						#region 患者费用信息

						try
						{
							PatientInfo.FT.ID = PatientInfo.ID;
							PatientInfo.FT.Name = PatientInfo.Name;
							PatientInfo.FT.TotCost = decimal.Parse(Reader[56].ToString());
							PatientInfo.FT.OwnCost = decimal.Parse(Reader[57].ToString());
							PatientInfo.FT.PayCost = decimal.Parse(Reader[58].ToString());
							PatientInfo.FT.PubCost = decimal.Parse(Reader[59].ToString());
							PatientInfo.FT.LeftCost = decimal.Parse(Reader[60].ToString());
							PatientInfo.FT.DerateCost = decimal.Parse(Reader[61].ToString());
							PatientInfo.FT.SupplyCost = decimal.Parse(Reader[62].ToString());
						}
						catch (Exception ex)
						{
							Err = "读取患者费用基本信息出错！" + ex.Message;
							WriteErr();
							al = null;
						}

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
					return al;
				}

				ProgressBarValue = -1;
				return al;
			}
			catch (Exception ex)
			{
				Err = "获得患者基本信息出错！" + ex.Message;
				ErrCode = "-1";
				WriteErr();
				al = null;
				return al;
			}
			finally
			{
				al = null;
			}
		}

		///流水号
		///
		///
		private string GetNewPassWordID()
		{
			// SELECT PASSWORD.nextval	FROM dual
			string sql = "";
			if (Sql.GetSql("RADT.OutPatient.GetNewPassWordID", ref sql) == -1) return null;
			string strReturn = ExecSqlReturnOne(sql);
			if (strReturn == "-1" || strReturn == "") return null;
			return strReturn;
		}


		public int SaveMoney(string strCardNo, decimal dMoney)
		{
			#region 接口说明

			//卡号密码信息。RADT.OutPatient.UpdateMoney
			//			update com_patientinfo set 
			//			lact_sum = act_amt,
			//			act_amt=act_amt+{1} 
			//			where 
			//			PARENT_CODE='[父级编码]'  
			//			and CURRENT_CODE='[本级编码]' 
			//			and card_no='{0}'

			#endregion

			int iRet = 1;
			string strSql = "";
			if (Sql.GetSql("RADT.OutPatient.UpdateMoney", ref strSql) == 0)
			{
				try
				{
					strSql = string.Format(strSql, strCardNo, dMoney);
					if (ExecNoQuery(strSql) > 0)
					{
						Card obj = new Card();
						obj = GetMoney(strCardNo);
						if (obj != null)
						{
							if (InsertMoney(obj) > 0)
								return iRet = 1;
						}
						else
						{
							return iRet = -1;
						}
					}
					else
					{
						return iRet = -1;
					}
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					return iRet = -1;
				}
			}
			else
			{
				return iRet = -1;
			}
			return iRet;
		}

		private int UpdateMoney()
		{
			return 0;
		}

		public Card GetMoney(string strCardNo)
		{
			Card obj = new Card();
			string sql1 = "";

			#region 接口说明

			//						select lact_sum,act_amt from com_patientinfo
			//			where
			//			PARENT_CODE='[父级编码]'  
			//			and CURRENT_CODE='[本级编码]' 
			//			and card_no = '{0}'
			//RADT.OutPatient.Get.2
			//传入:卡号
			//传出：卡金额信息

			#endregion

			if (Sql.GetSql("RADT.OutPatient.GetMoney", ref sql1) == -1) return null;
			try
			{
				sql1 = string.Format(sql1, strCardNo);
			}
			catch
			{
				Err = "RADT.OutPatient.GetMoney";
				WriteErr();
				return null;
			}
			if (ExecQuery(sql1) == -1) return null;
			if (Reader.Read())
			{
				obj.ID = strCardNo;
				obj.OldAmount = Convert.ToDecimal(Reader[0].ToString());
				obj.NewAmount = Convert.ToDecimal(Reader[1].ToString());
				Reader.Close();
				return obj;
			}
			else
			{
				Reader.Close();
				return null;
			}
		}

		private int InsertMoney(Card oECard)
		{
			#region 接口说明

			//INSERT  INTO 
			//FIN_COM_ACCOUNTRECORD 
			//(parent_code,   --父级医疗机构编码 \n                   
			// current_code,   --本级医疗机构编码 \n      
			//CARD_NO ,--卡号\n
			//HAPPEN_NO,--发生序号\n
			//OLD_AMOUNT,--旧帐户金额\n
			//NEW_AMOUNT,--新账户金额\n
			//OPER_CODE,OPER_DATE)
			//VALUES
			//('[父级编码]',   --父级医疗机构编码 \n                   
			//'[本级编码]',   --本级医疗机构编码 \n   
			//'{0}',
			//(SELECT NVL(MAX(HAPPEN_NO),0)+1 FROM FIN_COM_ACCOUNTRECORD),
			//{1},{2},'{3}',sysdate)

			#endregion

			string strSql = "";
			//			Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
			if (Sql.GetSql("RADT.OutPatient.InsertMoney", ref strSql) == -1) return -1;
			try
			{
				strSql = string.Format(strSql, oECard.ID, oECard.OldAmount, oECard.NewAmount, Operator.ID);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新电脑卡信息 
		/// <param name="strID"></param>
		/// <param name="strPassWord"></param>
		/// <returns></returns>
		/// </summary>
		public int SetCardPassword(string strID, string strPassWord)
		{
			int iRet = 1;

			#region 接口说明

			//卡号密码信息。RADT.OutPatient.SetCardPassword
			//update com_patientinfo
			//			set 
			//			ACT_CODE ='{1}'--账户密码 
			//			where 
			//PARENT_CODE='[父级编码]'  
			//and CURRENT_CODE='[本级编码]' 
			//and CARD_NO='{0}'--卡号 

			#endregion

			string strOldPassword = "";
			if (GetPassWord(strID) == "") strOldPassword = strPassWord;
			strOldPassword = GetPassWord(strID);
			string strSql = "";
			if (Sql.GetSql("RADT.OutPatient.SetCardPassword", ref strSql) == 0)
			{
				try
				{
					strSql = string.Format(strSql, strID, strPassWord);
				}
				catch (Exception ex)
				{
					Err = ex.Message;
					ErrCode = ex.Message;
					iRet = -1;
				}
			}
			else
			{
				iRet = -1;
			}
			Card obj = new Card();
			obj.ID = strID;
			obj.NewPassword = strPassWord;
			obj.OldPassword = strOldPassword;
			if (ExecNoQuery(strSql) > 0)
			{
				if (InsertPassWord(obj) != -1)
				{
					iRet = 1;
				}
			}
			else
			{
				iRet = -1;
			}
			return iRet;
		}

		private string GetPassWord(string strCardNo)
		{
			string strPassWord = "";
			string sql1 = "";

			#region 接口说明

			//			select ACT_CODE from com_patientinfo
			//			where
			//			PARENT_CODE='[父级编码]'  
			//			and CURRENT_CODE='[本级编码]' 
			//			and card_no = '{0}'
			//RADT.OutPatient.GetPassWord
			//传入:卡号
			//传出：卡金额信息

			#endregion

			if (Sql.GetSql("RADT.OutPatient.GetPassWord", ref sql1) == -1) return null;
			try
			{
				sql1 = string.Format(sql1, strCardNo);
			}
			catch
			{
				Err = "RADT.OutPatient.GetPassWord";
				WriteErr();
				return null;
			}
			if (ExecQuery(sql1) == -1) return null;
			if (Reader.Read())
			{
				strPassWord = Reader[0].ToString();
				Reader.Close();
			}
			else
			{
				Reader.Close();
				strPassWord = "";
			}
			return strPassWord;
		}

		public int LogoutCard(string strCardID)
		{
			string strSql = "";

			#region "接口"

			//传入：0 1 
			//传出：0

			#endregion

			if (Sql.GetSql("RADT.OutPatient.LogoutCard", ref strSql) == -1) return -1;
			try
			{
				strSql = string.Format(strSql, strCardID);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				return -1;
			}
			return ExecNoQuery(strSql);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientno">住院号</param>
		/// <returns></returns>
		public TransferFee leaveHospital(string patientno)
		{
			string strSql = "";
			TransferFee info = null;
			if (Sql.GetSql("Radt.OutPatient.leaveHospital", ref strSql) == -1) return null;
			try
			{
				strSql = string.Format(strSql, patientno);
				ExecQuery(strSql);
				while (Reader.Read())
				{
					info = new TransferFee();
					if (Reader[0] != DBNull.Value)
					{
						info.FT.TotCost = Convert.ToDecimal(Reader[0]); // 取费用金额 未结
					}
					if (Reader[1] != DBNull.Value)
					{
						info.FT.OwnCost = Convert.ToDecimal(Reader[1]); //取费用金额  已结
					}
					if (Reader[2] != DBNull.Value)
					{
						info.FT.PayCost = Convert.ToDecimal(Reader[2]); //取预交金  
					}
				}
				Reader.Close();
			}
			catch (Exception ee)
			{
				Err = ee.Message;
			}
			return info;
		}

		#endregion

		/// <summary>
		/// 根据卡号获得卡的状态
		/// </summary>
		/// <param name="CardNo"></param>
		/// <returns></returns>
		public string GetValidCardState(string CardNo)
		{
			string strSql = "";
			if (Sql.GetSql("RADT.GetValidCardState.1", ref strSql) == -1) return null;
			try
			{
				strSql = string.Format(strSql, CardNo);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				return null;
			}
			return ExecSqlReturnOne(strSql);
		}

		/// <summary>
		/// 根据卡号获得密码
		/// </summary>
		/// <param name="CardNo"></param>
		/// <returns></returns>
		public string GetOldPassword(string CardNo)
		{
			string strSql = "";
			if (Sql.GetSql("RADT.GetOldPassword.1", ref strSql) == -1) return null;
			try
			{
				strSql = string.Format(strSql, CardNo);
			}
			catch (Exception ex)
			{
				Err = ex.Message;
				ErrCode = ex.Message;
				return null;
			}
			return ExecSqlReturnOne(strSql);
		}

		#endregion
	}
}