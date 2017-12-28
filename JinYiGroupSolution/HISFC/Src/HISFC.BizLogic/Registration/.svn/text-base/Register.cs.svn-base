using System;
using System.Collections;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Registration
{
	/// <summary>
	/// 挂号管理类
	/// </summary>
	public class Register:Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		///  挂号管理类
		/// </summary>
		public Register()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private ArrayList al = new ArrayList();
		private Neusoft.HISFC.Models.Registration.Register reg ;

		#region 增、删、改

        //账户流程 医生站收挂号费，置挂号费收费状态 {6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 置已收挂号费标志
        /// </summary>
        /// <param name="clinicID"></param>
        /// <param name="operID"></param>
        /// <param name="operDate"></param>
        /// <returns></returns>
        public int UpdateAccountFeeState(string clinicID, string operID,string dept, DateTime operDate)
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.Register.UpdateAccountFeeState", ref sql) == -1) return -1;

            try
            {
                sql = string.Format(sql, clinicID, operID,dept, operDate.ToString());
                return this.ExecNoQuery(sql);
            }
            catch (Exception e)
            {
                this.Err = "置患者收费标志出错![Registration.Register.UpdateAccountFeeState]" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }


       
		/// <summary>
        /// 插入挂号记录表{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
		/// </summary>
		/// <param name="register"></param>
		/// <returns></returns>
		public int Insert(Neusoft.HISFC.Models.Registration.Register register)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.Register.Insert.1",ref sql)==-1)return -1;
			
			try
			{
                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
				sql = string.Format(sql,register.ID,    register.PID.CardNO,
                    register.DoctorInfo.SeeDate.ToString(),     register.DoctorInfo.Templet.Noon.ID,
					register.Name,  register.IDCard,  register.Sex.ID,  register.Birthday.ToString(),
					register.Pact.PayKind.ID,register.Pact.PayKind.Name,register.Pact.ID,register.Pact.Name,
					register.SSN,  register.DoctorInfo.Templet.RegLevel.ID,     register.DoctorInfo.Templet.RegLevel.Name,
                    register.DoctorInfo.Templet.Dept.ID,    register.DoctorInfo.Templet.Dept.Name,
                    register.DoctorInfo.SeeNO,  register.DoctorInfo.Templet.Doct.ID,
                    register.DoctorInfo.Templet.Doct.Name,	Neusoft.FrameWork.Function.NConvert.ToInt32(register.IsFee),
                    (int)register.RegType,      Neusoft.FrameWork.Function.NConvert.ToInt32(register.IsFirst),
					register.RegLvlFee.RegFee.ToString(),   register.RegLvlFee.ChkFee.ToString(),
                    register.RegLvlFee.OwnDigFee.ToString(),    register.RegLvlFee.OthFee.ToString(),
					register.OwnCost.ToString(),    register.PubCost.ToString(),    register.PayCost.ToString(),
                    (int)register.Status,		register.InputOper.ID,  Neusoft.FrameWork.Function.NConvert.ToInt32(register.IsSee),
					Neusoft.FrameWork.Function.NConvert.ToInt32(register.CheckOperStat.IsCheck),  register.PhoneHome,
					register.AddressHome,   (int)register.TranType,     register.CardType.ID,
                    register.DoctorInfo.Templet.Begin.ToString(),   register.DoctorInfo.Templet.End.ToString(),
					register.CancelOper.ID,     register.CancelOper.OperTime.ToString(),
                    register.InvoiceNO, register.RecipeNO,		Neusoft.FrameWork.Function.NConvert.ToInt32(register.DoctorInfo.Templet.IsAppend),
                    register.OrderNO,   register.DoctorInfo.Templet.ID,
					register.InputOper.OperTime.ToString(),     register.InSource.ID ,Neusoft.FrameWork.Function.NConvert.ToInt32(register.CaseState),
                    Neusoft.FrameWork.Function.NConvert.ToInt32(register.IsEncrypt),register.NormalName,register.EcoCost, NConvert.ToInt32(register.IsAccount).ToString(),register.OperSeq,register.AccountNO) ;

				return this.ExecNoQuery(sql);				
			}
			catch(Exception e)
			{
				this.Err="插入挂号主表类别表出错![Registration.Register.Insert.1]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}

		/// <summary>
		/// 更新挂号信息,作废(注销)、退号、取消作废、换科、修改患者信息
		/// </summary>
		/// <param name="status"></param>
		/// <param name="register"></param>
		/// <returns></returns>
		public int Update(EnumUpdateStatus status,Neusoft.HISFC.Models.Registration.Register register)
		{
			if(status == EnumUpdateStatus.Cancel)
			{
				return this.CancelReg(register.ID,register.CancelOper.ID,register.CancelOper.OperTime,status);
			}
			else if(status == EnumUpdateStatus.Return)
			{
				return this.CancelReg(register.ID,register.CancelOper.ID,register.CancelOper.OperTime,status);
			}
			else if(status == EnumUpdateStatus.ChangeDept)
			{
				return this.ChangeDept(register);
			}
			else if(status == EnumUpdateStatus.PatientInfo) 
			{
				return this.UpdatePatientInfo(register) ;
			}
			else if(status == EnumUpdateStatus.Uncancel)
			{
				return this.Uncancel(register.ID) ;
			}
			return 0;
		}

		/// <summary>
		/// 置已分诊标志
		/// </summary>
		/// <param name="clinicID"></param>
		/// <param name="operID"></param>
		/// <param name="operDate"></param>
		/// <returns></returns>
		public int Update(string clinicID,string operID,DateTime operDate)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.UpdateTriage",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,clinicID,operID,operDate.ToString());
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="置患者分诊标志出错![Registration.Register.UpdateTriage]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}

		/// <summary>
		/// 作废原有挂号记录
		/// </summary>
		/// <param name="clinicID"></param>
		/// <param name="cancelID"></param>
		/// <param name="cancelDate"></param>
		/// <param name="cancelFlag"></param>
		/// <returns></returns>
		private int CancelReg(string clinicID,string cancelID,DateTime cancelDate,EnumUpdateStatus cancelFlag)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.CancelReg",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,clinicID,cancelID,cancelDate.ToString(),(int)cancelFlag);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="作废挂号记录出错![Registration.Register.CancelReg]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 换科(无用，暂无该需求)
		/// </summary>
		/// <param name="register"></param>
		/// <returns></returns>
		private int ChangeDept(Neusoft.HISFC.Models.Registration.Register register)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.ChangeDept",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,register.ID,register.DoctorInfo.Templet.Dept.ID,register.DoctorInfo.Templet.Dept.Name,
					register.DoctorInfo.SeeNO,register.DoctorInfo.Templet.Doct.ID,register.DoctorInfo.Templet.Doct.Name,
					register.RegLvlFee.RegFee,register.RegLvlFee.ChkFee,register.RegLvlFee.OwnDigFee,register.RegLvlFee.OthFee,
					register.OwnCost,register.PubCost,register.PayCost);

				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="更新挂号记录出错![Registration.Register.ChangeDept]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 取消作废(注销)
		/// </summary>
		/// <param name="clinicID"></param>
		/// <returns></returns>
		private int Uncancel(string clinicID)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.Uncancel",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,clinicID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="作废挂号记录出错![Registration.Register.Uncancel]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		/// <summary>
		/// 取消分诊状态
		/// </summary>
		/// <param name="clinicID"></param>
		/// <returns></returns>
		public int CancelTriage(string clinicID)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.CancelTriage",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,clinicID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="取消挂号信息的分诊状态出错![Registration.Register.CancelTriage]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		
		/// <summary>
		/// 更新患者基本信息
		/// </summary>
		/// <param name="register"></param>
		/// <returns></returns>
		private int UpdatePatientInfo(Neusoft.HISFC.Models.Registration.Register register)
		{
			//{D944AF1A-3BDE-4d51-BBA3-EB0FE779C7FC}增加身份证号
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.Update.PatientInfo",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,register.Name, register.Birthday.ToString(), register.Sex.ID,
										register.AddressHome, register.PhoneHome, register.PID.CardNO, register.CardType.ID,
                                        register.InSource.ID, register.Pact.PayKind.ID, register.Pact.ID, register.Pact.Name,
                                        register.SSN,Neusoft.FrameWork.Function.NConvert.ToInt32( register.IsEncrypt),register.NormalName,register.IDCard);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="更新患者信息出错![Registration.Register.Update.PatientInfo]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}

        /// <summary>
        /// 换科{87C56F02-B81A-4fac-BA4D-654C8E56C500}
        /// </summary>
        /// <param name="clinicNO">挂号流水号</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="deptName">科室名称</param>
        /// <param name="doctCode">医生编码</param>
        /// <param name="doctName">医生名称</param>
        /// <param name="dtReg">挂号时间</param>
        /// <returns></returns>
        public int UpdateDeptAndDoct(string clinicNO, string deptCode, string deptName, string doctCode, string doctName, string dtReg)
        {
            string strSql = string.Empty;
            int returnValue = this.Sql.GetSql("Registration.Register.UpdateDeptAndDoct", ref  strSql);
            if (returnValue < 0)
            {
                this.Err = "没有Registration.Register.UpdateDeptAndDoct对应的sql语句";
                return -1;
            }
            strSql = string.Format(strSql, clinicNO, deptCode, deptName, doctCode, doctName, dtReg);
            return this.ExecNoQuery(strSql);
        }

		#endregion

		#region 挂号更新限额
		/// <summary>
		/// 更新看诊序号
		/// </summary>
		/// <param name="Type">1医生 2科室 4全院</param>
		/// <param name="seeDate">看诊日期</param>
		/// <param name="Subject">Type=1时,医生代码;Type=2,科室代码;Type=4,ALL</param>
		/// <param name="noonID">午别</param>
		/// <returns></returns>
		public int UpdateSeeNo(string Type ,DateTime seeDate,string Subject, string noonID)
		{
			string sql = "" ;

			#region 更新看诊序号			

			if(this.Sql.GetSql("Registration.Register.UpdateSeeSequence",ref sql) == -1)return -1;
			try
			{
				sql = string.Format(sql,seeDate.Date.ToString(), Type, Subject, noonID);
				int rtn = this.ExecNoQuery(sql);

				if(rtn == -1) return -1;

				//没有更新记录,插入一条新记录
				if(rtn == 0)
				{
					if(this.Sql.GetSql("Registration.Register.InsertSeeSequence",ref sql) == -1)return -1;

					sql = string.Format(sql,seeDate.Date.ToString(), Type, Subject, "", 1, noonID);

					if(this.ExecNoQuery(sql) == -1)return -1 ;
				}
			}
			catch(Exception e)
			{
				this.Err = "更新看诊序号出错"+e.Message;
				this.ErrCode = e.Message;
				return -1;
			}
			#endregion
			return 0;
		}
		
		
		/// <summary>
		/// 获得患者看诊序号
		/// </summary>
		/// <param name="Type">Type:1专家序号、2科室序号、4全院序号</param>
		/// <param name="current">看诊日期</param>
		/// <param name="subject">Type=1时,医生代码;Type=2,科室代码;Type=4,ALL</param>
		/// <param name="noonID">午别</param>
		/// <param name="seeNo">当前看诊号</param>
		/// <returns></returns>
		public int GetSeeNo(string Type,DateTime current,string subject, string noonID, ref int seeNo)
		{
			string sql="", rtn = ""  ;			

			if(this.Sql.GetSql("Registration.Register.getSeeNo",ref sql)==-1)return -1;

			try
			{
				sql = string.Format(sql,current.Date.ToString(),Type,subject, noonID);
				
				rtn = this.ExecSqlReturnOne(sql,"0") ;

				seeNo = Neusoft.FrameWork.Function.NConvert.ToInt32(rtn) ; 

				return 0 ;
			}
			catch(Exception e)
			{
				this.Err="查询看诊序号出错![Registration.Register.getSeeNo]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}			
		}

		#endregion

		#region 更新日结数据
		/// <summary>
		/// 根据操作员、时间段更新日结信息
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <param name="OperID"></param>
		/// <param name="BalanceID"></param>
		/// <returns></returns>
		public int Update(DateTime begin,DateTime end,string OperID,string BalanceID)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.Update.DayBalance",ref sql)==-1)return -1;

			try
			{
				sql=string.Format(sql,begin.ToString(),end.ToString(),OperID,BalanceID);
				return this.ExecNoQuery(sql);
			}
			catch(Exception e)
			{
				this.Err="置挂号信息日结标志出错![Registration.Register.Update.DayBalance]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		#endregion

        #region 自动取卡号
        /// <summary>
        /// 取数据库序列值来作为就诊卡号
        /// </summary>
        /// <returns>序列值</returns>
        public int AutoGetCardNO()
        {
            string sql = "";

            if (this.Sql.GetSql("Registration.Register.GetNewCardNo", ref sql) == -1) return -1;

            try
            {
                return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(sql));
            }
            catch (Exception e)
            {
                this.Err = "自动取卡号出错![Registration.Register.GetNewCardNo]" + e.Message;
                this.ErrCode = e.Message;
                return -1;
            }
        }
        #endregion

        #region 诊间使用
        #region 更新已经看诊

        /// <summary>
		///  更新已经看诊－－根据门诊流水号
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		public int UpdateSeeDone(string clinicNo)
		{
			string sql = "Registration.Register.Update.SeeDone";
			if(this.Sql.GetSql(sql,ref sql)==-1) return -1;
			return this.ExecNoQuery(sql,clinicNo);
		}

		#endregion

		#region 更新看诊科室
		/// <summary>
		/// 更新看诊科室
		/// </summary>
		/// <param name="clinicID"></param>
		/// <param name="seeDeptID"></param>
		/// <param name="seeDoctID"></param>
		/// <returns></returns>
		public int UpdateDept(string clinicID, string seeDeptID, string seeDoctID)
		{
			string sql = "" ;
			string[] parm = new string[]{clinicID, seeDeptID, seeDoctID} ;

			if(this.Sql.GetSql("Registration.Register.Query.17",ref sql)==-1) return -1;

			return this.ExecNoQuery(sql, parm );
        }
        #endregion

       
        
        #endregion
        
        #region 查询
        #region 按病历号查询一条最近的挂号信息,屏蔽
        /*
        /// <summary>
		/// 根据病历号查询患者最近一次挂号信息
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Registration.Register Query(string cardNo)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.2",ref where)==-1)return null;

			try
			{
				where=string.Format(where,cardNo);
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.2]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;

			if(this.QueryRegister(sql)==null)return null;
			
			if(al == null)
			{
				return null;
			}
			else if(al.Count == 0)
			{
				return new Neusoft.HISFC.Models.Registration.Register() ;
			}
			else
			{
				return (Neusoft.HISFC.Models.Registration.Register)this.al[0];
			}
		}*/
		
		#endregion

		#region 按患者名称查询患者基本信息
		/// <summary>
		/// 根据患者姓名查询
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public ArrayList QueryByName(string Name)
		{
			string sql = "" ;

			if(this.Sql.GetSql("Registration.Register.Query.10",ref sql) == -1)return null ;

			sql = string.Format(sql,Name) ;

			if(this.ExecQuery(sql) == -1)return null;

			this.al = new ArrayList() ;

			try
			{
				while(this.Reader.Read() )
				{
					this.reg = new Neusoft.HISFC.Models.Registration.Register() ;
					
					reg.PID.CardNO = this.Reader[0].ToString() ;
					reg.Name = this.Reader[1].ToString() ;
					reg.IDCard = this.Reader[2].ToString() ;
					reg.Sex.ID = this.Reader[3].ToString() ;
					reg.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString()) ;
					reg.PhoneHome = this.Reader[5].ToString() ;
					reg.AddressHome = this.Reader[6].ToString() ;

					this.al.Add(reg) ;
				}

				this.Reader.Close() ;
			}
			catch(Exception e)
			{
				this.Err="检索患者基本信息出错!"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}
			return al ;
		}
		#endregion

		#region 按门诊号查询一条挂号信息
		/// <summary>
		/// 按门诊号查询挂号信息
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Registration.Register GetByClinic(string clinicNo)
		{
			string sql="",where="";
			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;			
			if(this.Sql.GetSql("Registration.Register.Query.4",ref where)==-1)return null;

			try
			{
				where=string.Format(where,clinicNo);
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.4]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;

			if(this.QueryRegister(sql) == null)return null;

			if( al == null)
			{
				return null ;
			}
			else if(al.Count == 0)
			{
				return new Neusoft.HISFC.Models.Registration.Register() ;
			}
			else
			{
				return (Neusoft.HISFC.Models.Registration.Register)this.al[0];
			}
		}
		
		#endregion

		#region 按处方号查询一条挂号信息
		/// <summary>
		/// 按处方号查询
		/// </summary>
		/// <param name="recipeNo"></param>
		/// <returns></returns>
		public ArrayList QueryByRecipe(string recipeNo)
		{
			string sql="",where="";
			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;			
			if(this.Sql.GetSql("Registration.Register.Query.14",ref where)==-1)return null;

			try
			{
				where=string.Format(where,recipeNo);
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.14]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;

			return this.QueryRegister(sql) ;
			
		}
		#endregion 
        //{B6E76F4C-1D79-4fa2-ABAD-4A22DE89A6F7}
        #region 根据发票号查询挂号信息
        /// <summary>
        /// 根据发票号查询挂号信息
        /// </summary>
        /// <param name="recipeNo"></param>
        /// <returns></returns>
        public ArrayList QueryByRegInvoice(string invoiceNo)
        {
            string sql = "", where = "";
            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.22", ref where) == -1) return null;

            try
            {
                where = string.Format(where, invoiceNo);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.Register.Query.22]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.QueryRegister(sql);

        }
        #endregion 
        #region 按照病历号，医保类别（大类），时间有效查询挂号信息
        /// <summary>
        ///  按照病历号，医保类别（大类），时间有效查询挂号信息{46F865E4-9B79-4cc6-814D-3847DDBC85F9}
        /// </summary>
        /// <param name="cardNO"></param>
        /// <param name="beginDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <param name="payKindCode"></param>
        /// <returns></returns>
        public ArrayList QueryRegInfo(string cardNO,string beginDateTime,string EndDateTime,string payKindCode)
        {
            string sql = "", where = "";
            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.23", ref where) == -1) return null;

            try
            {
                where = string.Format(where, cardNO,beginDateTime,EndDateTime,payKindCode);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.Register.Query.23]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.QueryRegister(sql);

        }
        #endregion

        #region 按病历号、开始时间查询患者的挂号信息s
        /// <summary>
		/// 查询患者一段时间内挂的有效号
		/// </summary>
		/// <param name="cardNo"></param>
		/// <param name="limitDate"></param>
		/// <returns></returns>
		public ArrayList Query(string cardNo,DateTime limitDate)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.3",ref where)==-1)return null;

			try
			{
				where=string.Format(where,cardNo,limitDate.ToString());
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.3]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;

			return this.QueryRegister(sql);			
		}

        
        /// <summary>
        /// 查询患者一段时间内挂的有效号
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="limitDate"></param>
        /// <returns></returns>
        public ArrayList QueryRegisterByName(string name, DateTime limitDate)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.100", ref where) == -1) return null;

            try
            {
                where = string.Format(where, name, limitDate.ToString());
            }
            catch (Exception e)
            {
                this.Err = "[Registration.Register.Query.100]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.QueryRegister(sql);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="cardNo"></param>
       /// <param name="limitDate"></param>
       /// <returns></returns>
        public ArrayList QueryUnionNurse(string cardNo, DateTime limitDate)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.20", ref where) == -1) return null;

            try
            {
                where = string.Format(where, cardNo, limitDate.ToString());
            }
            catch (Exception e)
            {
                this.Err = "[Registration.Register.Query.20]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.QueryRegister(sql);
        }
		/// <summary>
		/// 查询一段时间内作废挂号信息
		/// </summary>
		/// <param name="cardNo"></param>
		/// <param name="limitDate"></param>
		/// <returns></returns>
		public ArrayList QueryCancel(string cardNo, DateTime limitDate)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.16",ref where)==-1)return null;

			try
			{
				where=string.Format(where,cardNo,limitDate.ToString());
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.16]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;

			return this.QueryRegister(sql);	
		}
		#endregion

		#region 按看诊序号查询患者挂号信息 门诊收费使用
		/// <summary>
		/// 按看诊序号、开始时间查询挂号信息
		/// </summary>
		/// <param name="seeNo"></param>
		/// <param name="limitDate"></param>
		/// <returns></returns>
		public ArrayList QueryBySeeNo(string seeNo, DateTime limitDate)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.18",ref where)==-1)return null;

			try
			{
				where=string.Format(where,seeNo,limitDate.ToString());
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.18]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;

			return this.QueryRegister(sql);	
		}
		#endregion

       /// <summary>
       /// 按时间段统计查询挂号员的有效挂号数
       /// </summary>
       /// <param name="operID">挂号员id</param>
       /// <param name="beginDateTime">起始时间</param>
       /// <param name="endDateTime">截至时间</param>
       /// <returns></returns>
        public string QueryValidRegNumByOperAndOperDT(string operID,string beginDateTime,string endDateTime)
        {
            string sql = string.Empty ;
            if (this.Sql.GetSql("Registration.QueryValidRegNumByOperAndOperDT.Select1", ref sql) == -1)
            {
                this.Err += "没有找到索引为:Registration.QueryValidRegNumByOperAndOperDT.Select1 的SQL语句";
                return "-1";
            }
            try
            {
                sql = string.Format(sql, operID, beginDateTime, endDateTime);
            }
            catch (Exception e) 
            { 
                this.Err = "组成sql语句失败[Registration.QueryValidRegNumByOperAndOperDT.Select1]" + e.Message;
                this.ErrCode = e.Message;
            }
            
            return this.ExecSqlReturnOne(sql);
        }

		#region 按操作员、时间段查询挂号信息
		/// <summary>
		/// 按操作员、时间段查询挂号信息
		/// </summary>
		/// <param name="beginDate"></param>
		/// <param name="endDate"></param>
		/// <param name="operID"></param>
		/// <returns></returns>
		public ArrayList Query(DateTime beginDate,DateTime endDate, string operID)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.9",ref where)==-1)return null;

			try
			{
				where=string.Format(where,beginDate.ToString(),endDate.ToString(),operID) ;
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.9]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;

			return this.QueryRegister(sql);		
		}
		#endregion
      
        /// <summary>
        /// 查询复诊记录
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        public int QueryRegiterByCardNO(string cardNO)
        { 
            string sql = string.Empty;
            int returnValue  = Sql.GetSql("Registration.QueryRegiterByCardNO.Select.1", ref sql);
            if (returnValue == -1)
            {
                return -1;
            }
            try
            {
                sql = string.Format(sql, cardNO);
            }
            catch (Exception e)
            {
                this.Err = "[Registration.QueryRegiterByCardNO.Select.1]出错"+e.Message;
                return -1;
                
            }
            
           
            int result =  Neusoft.FrameWork.Function.NConvert.ToInt32( this.ExecSqlReturnOne(sql));

            return result;
        }

		#region 查询一段时间内未分诊的挂号患者 门诊护士使用
		/// <summary>
		/// 查询一段时间内未分诊的挂号患者
		/// </summary>
		/// <param name="begin"></param>
		/// <returns></returns>
		public ArrayList QueryNoTriage(DateTime begin)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.5",ref where)==-1)return null;

			try
			{
				where=string.Format(where,begin.ToString());
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.5]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql+" "+where;

			return this.QueryRegister(sql);
		}
		#endregion

		#region 分诊
        /// <summary>
        /// 通过一段时间内 某护理站对应科室的挂号患者 addby sunxh
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="myNurseDept">护理站代码</param>
        /// <returns></returns>
		public ArrayList QueryNoTriagebyDept(DateTime begin,string myNurseDept)
		{
           
            string sql = ""; string where="";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.byNurseDept", ref where) == -1) return null;

            where = string.Format(where, begin.ToString(), myNurseDept);

            sql = sql + " " + where;

            return this.QueryRegister(sql);
		}

        /// <summary>
        /// 通过一段时间内 某护理站对应科室的挂号患者未看诊 addby niuxy
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="myNurseDept">护理站代码</param>
        /// <returns></returns>
        public ArrayList QueryNoTriagebyDeptUnSee(DateTime begin, string myNurseDept)
        {
            string sql = ""; string where="";

            if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.byNurseDept1", ref where) == -1) return null;

            where = string.Format(where, begin.ToString(), myNurseDept);
            
            sql = sql +" "+ where;
            
            return this.QueryRegister(sql);
        }

		/// <summary>
		/// 根据门诊号判断挂号信息是否分诊
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		public bool QueryIsTriage( string clinicNo)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.Register.Query.IsTriage",ref sql) == -1)return false;

			try
			{
				sql = string.Format(sql,clinicNo );

				string rtn = this.ExecSqlReturnOne(sql, "0") ;

				// return Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn) ;
				if( rtn == "1")
				{
					return true ;
				}
				else
				{
					return false ;
				}

			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.IsTriage]"+e.Message;
				this.ErrCode=e.Message;
				return false;
			}			
		}

		/// <summary>
		/// 根据门诊号判断挂号信息是否作废
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		public bool QueryIsCancel(string clinicNo)
		{
			string sql="";

			if(this.Sql.GetSql("Registration.Register.Query.IsCancel",ref sql) == -1)return false;

			try
			{
				sql = string.Format(sql,clinicNo );

				string rtn = this.ExecSqlReturnOne(sql, "0") ;

				if( rtn == "1")
				{
					return false ;//有效,未作废
				}
				else
				{
					return true ;
				}

			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.IsCancel]"+e.Message;
				this.ErrCode=e.Message;
				return false;
			}			
		}
		#endregion

		#region 查询公费患者某日挂号数量
		/// <summary>
		/// 查询公费患者某日挂号数量
		/// </summary>
		/// <param name="cardNo"></param>
		/// <param name="regDate"></param>
		/// <returns></returns>
		public int QuerySeeNum(string cardNo, DateTime regDate)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.Query.12",ref sql) == -1)return -1;

			try
			{
				sql=string.Format(sql,cardNo, regDate.Date.ToString(), regDate.Date.AddDays(1).ToString());
				string Cnt = this.ExecSqlReturnOne(sql, "0") ;

				return Neusoft.FrameWork.Function.NConvert.ToInt32(Cnt) ;
			}
			catch(Exception e)
			{
				this.Err="获得患者挂号数量出错![Registration.Register.Query.12]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		#endregion

		#region 按门诊号查询已打印发票数量
		/// <summary>
		/// 按门诊号查询已打印发票数量
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		public int QueryPrintedInvoiceCnt( string clinicNo)
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.Query.15",ref sql) == -1)return -1;

			try
			{
				sql=string.Format(sql,clinicNo );
				string Cnt = this.ExecSqlReturnOne(sql, "0") ;

				return Neusoft.FrameWork.Function.NConvert.ToInt32(Cnt) ;
			}
			catch(Exception e)
			{
				this.Err="获得患者打印发票数量出错![Registration.Register.Query.15]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}

		/// <summary>
		/// 按门诊号更新已打印发票数量
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		public int UpdatePrintInvoiceCnt( string clinicNo) 
		{
			string sql="";
			
			if(this.Sql.GetSql("Registration.Register.Update.InvoiceCnt",ref sql) == -1)return -1;

			try
			{
				sql=string.Format(sql,clinicNo);
				
				return this.ExecNoQuery(sql) ;
			}
			catch(Exception e)
			{
				this.Err="更新患者打印发票数量出错![Registration.Register.Update.InvoiceCnt]"+e.Message;
				this.ErrCode=e.Message;
				return -1;
			}
		}
		#endregion

		#region 共有查询
		/// <summary>
		/// 挂号查询
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public ArrayList QueryRegister(string sql)
		{
			if(this.ExecQuery(sql) == -1)return null;

			this.al = new ArrayList();

			try
			{
				while(this.Reader.Read())
				{
					this.reg = new Neusoft.HISFC.Models.Registration.Register();
					
					this.reg.ID = this.Reader[0].ToString();//序号
					this.reg.PID.CardNO = this.Reader[1].ToString();//病历号
					this.reg.DoctorInfo.SeeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[2].ToString());//挂号日期
					this.reg.DoctorInfo.Templet.Noon.ID = this.Reader[3].ToString();
					this.reg.Name = this.Reader[4].ToString();
					this.reg.IDCard = this.Reader[5].ToString();
					this.reg.Sex.ID = this.Reader[6].ToString();

					this.reg.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());//出生日期

					this.reg.Pact.PayKind.ID = this.Reader[8].ToString();//结算类别
					this.reg.Pact.PayKind.Name = this.Reader[9].ToString();

					this.reg.Pact.ID = this.Reader[10].ToString();//合同单位
					this.reg.Pact.Name = this.Reader[11].ToString();
					this.reg.SSN = this.Reader[12].ToString();

					this.reg.DoctorInfo.Templet.RegLevel.ID = this.Reader[13].ToString();//挂号级别
					this.reg.DoctorInfo.Templet.RegLevel.Name = this.Reader[14].ToString();

					this.reg.DoctorInfo.Templet.Dept.ID = this.Reader[15].ToString();//挂号科室
					this.reg.DoctorInfo.Templet.Dept.Name = this.Reader[16].ToString();

					this.reg.DoctorInfo.SeeNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[17].ToString());

					this.reg.DoctorInfo.Templet.Doct.ID = this.Reader[18].ToString();//看诊医生
					this.reg.DoctorInfo.Templet.Doct.Name = this.Reader[19].ToString();

					this.reg.RegType = (Neusoft.HISFC.Models.Base.EnumRegType)Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[20].ToString());
					this.reg.IsFirst = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[21].ToString());

					this.reg.RegLvlFee.RegFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[22].ToString());
					this.reg.RegLvlFee.ChkFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[23].ToString());
					this.reg.RegLvlFee.OwnDigFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[24].ToString());
					this.reg.RegLvlFee.OthFee = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[25].ToString());

					this.reg.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[26].ToString());
					this.reg.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[27].ToString());
					this.reg.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[28].ToString());

					this.reg.Status = (Neusoft.HISFC.Models.Base.EnumRegisterStatus)Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[29].ToString());

					this.reg.InputOper.ID = this.Reader[30].ToString();
					this.reg.IsSee = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[31].ToString());
					this.reg.InputOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[32].ToString());
					this.reg.TranType = (Neusoft.HISFC.Models.Base.TransTypes)Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[33].ToString());
					this.reg.BalanceOperStat.IsCheck = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[34]);//日结
					this.reg.BalanceOperStat.CheckNO = this.Reader[35].ToString();
					this.reg.BalanceOperStat.Oper.ID = this.Reader[36].ToString();

					if(!this.Reader.IsDBNull(37))
						this.reg.BalanceOperStat.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[37].ToString());								
					
					this.reg.PhoneHome = this.Reader[38].ToString();//联系电话
					this.reg.AddressHome = this.Reader[39].ToString();//地址
					this.reg.IsFee = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[40].ToString());
					//作废人信息
					this.reg.CancelOper.ID = this.Reader[41].ToString();
					this.reg.CancelOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[42].ToString());
					this.reg.CardType.ID = this.Reader[43].ToString() ;//证件类型
					this.reg.DoctorInfo.Templet.Begin = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[44].ToString()) ;
					this.reg.DoctorInfo.Templet.End = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[45].ToString()) ;
					//this.reg.InvoiceNo = this.Reader[50].ToString() ;
					//this.reg.InvoiceNO = this.Reader[51].ToString() ; by niuxinyuan
                    this.reg.InvoiceNO = this.Reader[50].ToString();
                    this.reg.RecipeNO = this.Reader[51].ToString();

					this.reg.DoctorInfo.Templet.IsAppend = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[52].ToString()) ;
					this.reg.OrderNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[53].ToString()) ;
					this.reg.DoctorInfo.Templet.ID = this.Reader[54].ToString() ;
					this.reg.InSource.ID = this.Reader[55].ToString() ;
                    this.reg.PVisit.InState.ID = this.Reader[56].ToString();
                    this.reg.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[57].ToString());
                    this.reg.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[58].ToString());
                    this.reg.PVisit.ZG.ID = this.Reader[59].ToString();
                    this.reg.PVisit.PatientLocation.Bed.ID = this.Reader[60].ToString();

                    //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                    //标识是否是账户流程挂号 1代表是
                    this.reg.IsAccount = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[61].ToString());

                    //{E26C3EE9-D480-421e-9FD3-7094D8E4E1D0}
                    this.reg.SeeDPCD = this.Reader[62].ToString(); //看诊科室
                    this.reg.SeeDOCD = this.Reader[63].ToString();//看诊医生

                    this.al.Add(this.reg);
				}
			}
			catch(Exception e)
			{
				this.Err="检索挂号信息出错!"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			return this.al;
		}		
		#endregion

		#region 门诊医生站使用查询
		/// <summary>
		/// 按挂号医生查询某一段时间内挂的有效号
		/// </summary>
		/// <param name="doctID"></param>
		/// <param name="beginDate"></param>
		/// <param name="endDate"></param>
		/// <param name="isSee"></param>
		/// <returns></returns>
		public ArrayList QueryByDoct(string doctID,DateTime beginDate,DateTime endDate,bool isSee)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.7",ref where)==-1)return null;

			try
			{
				where=string.Format(where,doctID,beginDate.ToString(),endDate.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(isSee));
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.7]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql+" "+where;

			return this.QueryRegister(sql);
		}
		/// <summary>
		/// 按挂号科室查询某一段时间内挂的有效号
		/// </summary>
		/// <param name="deptID"></param>
		/// <param name="beginDate"></param>
		/// <param name="endDate"></param>
		/// <param name="isSee"></param>
		/// <returns></returns>
		public ArrayList QueryByDept(string deptID,DateTime beginDate,DateTime endDate,bool isSee)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.8",ref where)==-1)return null;

			try
			{
				where=string.Format(where,deptID,beginDate.ToString(),endDate.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(isSee));
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.8]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql+" "+where;

			return this.QueryRegister(sql);
		}
		/// <summary>
		/// 按看诊医生查询某一段时间内挂的有效号
		/// </summary>
		/// <param name="docID"></param>
		/// <param name="beginDate"></param>
		/// <param name="endDate"></param>
		/// <param name="isSee"></param>
		/// <returns></returns>
		public ArrayList QueryBySeeDoc(string docID,DateTime beginDate,DateTime endDate,bool isSee)
		{
			string sql="",where="";

			if(this.Sql.GetSql("Registration.Register.Query.1",ref sql)==-1)return null;
			if(this.Sql.GetSql("Registration.Register.Query.19",ref where)==-1)return null;

			try
			{
				where=string.Format(where,docID,beginDate.ToString(),endDate.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(isSee));
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.19]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql+" "+where;

			return this.QueryRegister(sql);
		}

        /// <summary>
        /// 按看诊医生查询某一段时间内已经看诊的有效号
        /// </summary>
        /// <param name="docID"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSee"></param>
        /// <returns></returns>
        public ArrayList QueryBySeeDocAndSeeDate(string docID, DateTime beginDate, DateTime endDate, bool isSee)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.21", ref where) == -1) return null;

            try
            {
                where = string.Format(where, docID, beginDate.ToString(), endDate.ToString(), Neusoft.FrameWork.Function.NConvert.ToInt32(isSee));
            }
            catch (Exception e)
            {
                this.Err = "[Registration.Register.Query.21]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.QueryRegister(sql);
        }

		#endregion	
       

		#region 按照姓名查询具有划价信息的患者
		/// <summary>
		/// 按照姓名查询具有划价信息的患者
		/// </summary>
		/// <param name="name" >姓名</param>
		/// <param name="days ">有效天数</param>
		/// <returns></returns>
		public  ArrayList QueryRegHaveChargedInfo(string name,int days)
		{
			string strSql = "";

			ArrayList al = new ArrayList();

			if(this.Sql.GetSql("Registration.Register.Query.HaveChargedInfo",ref strSql) == -1)
			{
				this.Err = "Can't Find Sql:Registration.Register.Query.HaveChargedInfo";
				return null;
			}
			strSql = System.String.Format(strSql,name,days);
			if(this.ExecQuery(strSql) < 0)
			{
				this.Err = "Execute Err;";
				return null;
			}

			while(this.Reader.Read())
			{
				this.reg = new Neusoft.HISFC.Models.Registration.Register();

				reg.ID = this.Reader[0].ToString();//流水号
				reg.PID.CardNO = this.Reader[1].ToString();//病利号
				reg.OrderNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[2].ToString());//方号
				reg.Name = this.Reader[3].ToString();//姓名
				reg.DoctorInfo.Templet.Dept.ID = this.Reader[4].ToString();
				reg.DoctorInfo.Templet.Dept.Name = this.Reader[5].ToString();//挂号科室
				reg.DoctorInfo.SeeDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());
				reg.Sex.ID = this.Reader[7].ToString();
				reg.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8].ToString());//出生日期
				reg.Pact.ID = this.Reader[9].ToString();
				reg.Pact.Name = this.Reader[10].ToString();//合同单位
				reg.DoctorInfo.Templet.Doct.ID = this.Reader[11].ToString();
				reg.DoctorInfo.Templet.Doct.Name = this.Reader[12].ToString();//挂号医生
				reg.SSN = this.Reader[13].ToString();//医疗证号
				reg.DoctorInfo.Templet.RegLevel.ID = this.Reader[14].ToString();
				reg.DoctorInfo.Templet.RegLevel.Name = this.Reader[15].ToString();

				al.Add(reg);
			}
			return al;
		}
		#endregion


        #region 按护士站和急诊留观状态查询患者列表
        /// <summary>
        /// 按护士站和急诊留观状态查询患者列表
        /// </summary>
        /// <param name="nurseCellCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ArrayList PatientQueryByNurseCell(string nurseCellCode, string status)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.byNurseCellCode", ref where) == -1) return null;

            where = string.Format(where, nurseCellCode, status);
            
            sql = sql + " " + where;

            return this.QueryRegister(sql);

        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 医生站加载留观患者信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ArrayList PatientQueryByNurseCell(string deptCode)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.QueryEnEmergencyPatient.byDeptCode", ref where) == -1) return null;

            where = string.Format(where, deptCode);

            sql = sql + " " + where;

            return this.QueryRegister(sql);
        }

        #endregion

        #region 按护士站和急诊留观状态查询患者列表
        /// <summary>
        /// 按科室查询和急诊留观状态查询患者列表
        /// </summary>
        /// <param name="nurseCellCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ArrayList QueryPatient(string deptcode, string status)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.byDeptCode", ref where) == -1) return null;

            where = string.Format(where, deptcode, status);

            sql = sql + " " + where;

            return this.QueryRegister(sql);

        }

        /// <summary>
        /// 急诊留观查询当前护理站的不同状态的病人信息(出观)
        /// </summary>
        /// <param name="deptcode">科室编码</param>
        /// <param name="status">状态</param>
        /// <param name="fromDate">出观起始时间</param>
        /// <param name="toDate">出观截至时间</param>
        /// <returns></returns>
        public ArrayList QueryPatient(string deptcode, string status,string fromDate,string toDate)
        {
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.byDeptCodeAndOutDate", ref where) == -1) return null;

            where = string.Format(where, deptcode, status,fromDate,toDate);

            sql = sql + " " + where;

            return this.QueryRegister(sql);

        }

        /// <summary>
        /// 根据门诊号去有效的挂号信息
        /// </summary>
        /// <param name="clinicNO">门诊号</param>
        /// <returns></returns>
        public ArrayList QueryPatient(string clinicNO)
        {
            string sql = string.Empty;
            string whereSql = string.Empty;

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1)
            {
                this.Err = "未能找到索引为[Registration.Register.Query.1]的sql语句";
                return null;
            }

            if (this.Sql.GetSql("Registration.Register.Query.WhereByClinic", ref whereSql) == -1)
            {
                this.Err = "未能找到索引为[Registration.Register.Query.WhereByClinic]的sql语句";
                return null;
            }

            try
            {
                whereSql = string.Format(whereSql, clinicNO);
                sql = sql + "  " + whereSql;
            }
            catch (Exception ex)
            {

                this.Err = "设置参数出错" + ex.Message;
                return null;
            }

            return this.QueryRegister(sql);
        }

        #endregion

        //{543BD236-C9BD-4c92-A4EA-DC2EEBDF1317}
        public int GetMaxOperSeq(string OperID, DateTime dtBegin,DateTime dtEnd)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Registration.OperSeq", ref sql) == -1)
            {
                this.Err = "没有找到Registration.OperSeq";
                return -1;
            }

            sql = string.Format(sql, OperID, dtBegin, dtEnd);

            if (this.ExecQuery(sql) == -1)
            {
                this.Err = "查询出错";
                return -1;
            }
            int seq = 0;
            try
            {                
                while (this.Reader.Read())
                {
                    seq = FrameWork.Function.NConvert.ToInt32(this.Reader[0]);
                }
            }
            catch (Exception e)
            {
                this.Err = "查询出错" + e.Message;
                return -1;
            }

            return seq;
        }

        #endregion

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户新增
        /// <summary>
        /// 根据病历号查询已看诊的有效挂号信息
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结算时间</param>
        public ArrayList GetRegisterByCardNODate(string cardNO, DateTime beginDate, DateTime endDate)
        {
            //Registration.Register.Query.Where
            string sql = "", where = "";

            if (this.Sql.GetSql("Registration.Register.Query.1", ref sql) == -1) return null;
            if (this.Sql.GetSql("Registration.Register.Query.Where", ref where) == -1) return null;

            try
            {
                where = string.Format(where, cardNO, beginDate.ToString(), endDate.ToString());
            }
            catch (Exception e)
            {
                this.Err = "[Registration.Register.Query.Where]" + e.Message;
                this.ErrCode = e.Message;
                return null;
            }

            sql = sql + " " + where;

            return this.QueryRegister(sql);
        }
        #endregion

        #region 郑大新增
        public int UpdateRegister(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("Registration.Register.UpdatePatientInfo", ref strSql);
            if (returnValue < 0)
            {
                this.Err = " 查找Registration.Register.UpdatePatientInfo对应的sql失败！";
                return -1;
            }

            strSql = string.Format(strSql, patientInfo.PID.CardNO, patientInfo.Name, patientInfo.IDCard, patientInfo.Sex.ID, patientInfo.Birthday.ToString(), patientInfo.Kin.RelationPhone, patientInfo.AddressHome);
            return this.ExecNoQuery(strSql);

            
        }

        public string QueryTodayNumber(string doctCode)
        {
            string strSql = @"
select count(1)
  from fin_opr_register a
 where a.oper_date between trunc(sysdate) and trunc(sysdate) + 1
   and a.doct_code = '{0}'

";
            strSql = string.Format(strSql, doctCode);

            return this.ExecSqlReturnOne(strSql);

        }

        #endregion
    }
	/// <summary>
	/// 退号、作废、换科、患者信息
	/// </summary>
	public enum EnumUpdateStatus
	{
		/// <summary>
		/// 退号
		/// </summary>
		Return ,		
		/// <summary>
		/// 换科
		/// </summary>
		ChangeDept ,
		/// <summary>
		/// 作废
		/// </summary>
		Cancel,
		/// <summary>
		/// 患者信息
		/// </summary>
		PatientInfo,
		/// <summary>
		/// 取消作废
		/// </summary>
		Uncancel,
	}

	/// <summary>
	/// 挂号打印接口
	/// </summary>
	public interface IRegPrint
	{
		/// <summary>
		/// 患者挂号信息
		/// </summary>
		Neusoft.HISFC.Models.Registration.Register RegInfo
		{
			get;
			set;
		}

		/// <summary>
		/// 打印函数
		/// </summary>
		/// <returns></returns>
		int Print();	
	}
}
