using System;
using neusoft.HISFC.Object.RADT;
using System.Collections;
using neusoft.neuFC.Object;

namespace neusoft.HISFC.Management.Case
{
	/// <summary>
	/// Diagnose 的摘要说明。
	/// </summary>
	public class Diagnose:neusoft.neuFC.Management.Database
	{
		public Diagnose()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 诊断业务
			#region 申请新诊断发生序号
			/// <summary>
			/// 申请新诊断发生序号
			/// </summary>
			/// <returns>long 新申请的序号 错误时返回-1</returns>
			public long GetNewDignoseNo()
			{
				long lNewNo = -1;
				string strSql = "";
				if(this.Sql.GetSql("RADT.Diagnose.GetNewDiagnoseNo.1",ref strSql) == -1) return -1; 
				if (strSql == null) return -1;
				this.ExecQuery(strSql);
				try
				{
					while(this.Reader.Read())
					{
						lNewNo = long.Parse(Reader[0].ToString());
					}
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.WriteErr();;
					return -1;            
				}
				this.Reader.Close();
				return lNewNo;
			}
			#endregion
			#region 登记患者诊断信息
			/// <summary>
			/// 登记新的患者诊断
			/// </summary>
			/// <param name="Diagnose"></param>
			/// <returns></returns>
			public int CreatePatientDiagnose(neusoft.HISFC.Object.RADT.Diagnose Diagnose)
			{
				#region "接口说明"
				///接口名称 RADT.Diagnose.CreatePatientDiagnose.1
				// 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
				// 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
				// 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
				#endregion
				string strSql="";
				if(this.Sql.GetSql("RADT.Diagnose.CreatePatientDiagnose.1",ref strSql)==-1) return -1;
				
				try
				{
					string[] s=new string[15];
					try
					{
						s[0]=Diagnose.Patient.ID.ToString();// --患者住院流水号
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[1]=Diagnose.HappenNo.ToString();//  --发生序号
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[2]=Diagnose.Patient.PID.CardNo;// --就诊卡号
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[3]=Diagnose.DiagType.ID.ToString();//  --诊断类别
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[4]=Diagnose.ID.ToString();// --诊断编码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[5]=Diagnose.Name ;//--诊断名称
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[6]=Diagnose.DiagDate.ToString();//  --诊断时间
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[7]=Diagnose.Doctor.ID.ToString();//    --诊断医生
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[8]=Diagnose.Doctor.Name;//    --诊断医生
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[9]=(System.Convert.ToInt16(Diagnose.IsValid)).ToString();//    --是否有效
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[10]=Diagnose.Dept.ID.ToString();//  --诊断科室
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[11]=(System.Convert.ToInt16(Diagnose.IsMain)).ToString();//  --是否主诊断
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					
					try
					{
						s[12]=Diagnose.Memo;//    --备注
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[13]=this.Operator.ID.ToString();//    --操作人
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[14]=this.GetSysDateTime().ToString();//    --操作人
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					
					strSql=string.Format(strSql,s);
				}
				catch(Exception ex)
				{
					this.Err="赋值时候出错！"+ex.Message;
					this.WriteErr();
					return -1;
				}	
				return this.ExecNoQuery(strSql);
			}
			#endregion
			#region 更新患者诊断信息
			/// <summary>
			/// 更新患者诊断信息
			/// </summary>
			/// <param name="Diagnose"></param>
			/// <returns></returns>
			public int UpdatePatientDiagnose(neusoft.HISFC.Object.RADT.Diagnose Diagnose)
			{
				#region "接口说明"
				///接口名称 RADT.Diagnose.UpdatePatientDiagnose.1
				// 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
				// 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
				// 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
				#endregion
				string strSql="";
				if(this.Sql.GetSql("RADT.Diagnose.UpdatePatientDiagnose.1",ref strSql)==-1) return -1;
				
				try
				{
					string[] s=new string[15];
					try
					{
						s[0]=Diagnose.Patient.ID.ToString();// --诊断编码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[1]=Diagnose.HappenNo.ToString();//  --发生序号
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[2]=Diagnose.Patient.PID.CardNo;// --诊断编码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[3]=Diagnose.DiagType.ID.ToString();//  --诊断类别
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[4]=Diagnose.ID.ToString();// --诊断编码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[5]=Diagnose.Name ;//--诊断名称
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[6]=Diagnose.DiagDate.ToString();//  --诊断时间
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[7]=Diagnose.Doctor.ID.ToString();//    --诊断医生
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[8]=Diagnose.Doctor.Name;//    --诊断医生
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[9]=(System.Convert.ToInt16(Diagnose.IsValid)).ToString();//    --是否有效
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[10]=Diagnose.Dept.ID.ToString();//  --诊断科室
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[11]=(System.Convert.ToInt16(Diagnose.IsMain)).ToString();//  --是否主诊断
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					
					try
					{
						s[12]=Diagnose.Memo;//    --备注
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[13]=this.Operator.ID.ToString();//    --操作人
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						s[14]=this.GetSysDateTime().ToString();//    --操作人
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					strSql=string.Format(strSql,s);
				}
				catch(Exception ex)
				{
					this.Err="赋值时候出错！"+ex.Message;
					this.WriteErr();
					return -1;
				}	
				return this.ExecNoQuery(strSql);
			}
			#endregion
			#region 作废患者诊断信息
			/// <summary>
			/// 作废患者诊断信息
			/// </summary>
			/// <param name="Diagnose"></param>
			/// <returns></returns>
			public int DcPatientDiagnose(neusoft.HISFC.Object.RADT.Diagnose Diagnose)
			{
				#region 接口说明
				///作废患者诊断信息
				///RADT.Diagnose.DcPatientDiagnose.1
				///传入：0 InpatientNo住院流水号,1 happenno 发生序号
				///传出：0 
				#endregion
				string strSql="";
				if(this.Sql.GetSql("RADT.Diagnose.DcPatientDiagnose.1",ref strSql)==-1) return -1;
				try
				{
					strSql=string.Format(strSql,Diagnose.Patient.ID,Diagnose.HappenNo.ToString());
				}
				catch
				{
					this.Err="传入参数不对！RADT.Diagnose.DcPatientDiagnose.1";
					return -1;
				}
				return this.ExecNoQuery(strSql);
			}
			#endregion
		#endregion
		#region "查询功能"
        #region "查询患者诊断"
		/// <summary>
		/// 查询患者所有诊断
		/// </summary>
		/// <param name="InPatientNo"></param>
		/// <returns></returns>
		public ArrayList PatientDiagnoseQuery(string InPatientNo)
		{
			#region 接口说明
			/////RADT.Diagnose.PatientDiagnoseQuery.1
			///传入：住院流水号
			///传出：患者诊断信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";

			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;

			if(this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.1",ref sql2)==-1)
			{
				this.Err="没有找到RADT.Diagnose.PatientDiagnoseQuery.1字段!";
				this.ErrCode="-1";
				return null;
			}
			sql1=sql1+" "+string.Format(sql2,InPatientNo);
			return this.myPatientQuery(sql1);
		}
		/// <summary>
		/// 查询患者各类型诊断
		/// </summary>
		/// <param name="InPatientNo"></param>
		/// <param name="DiagType"></param>
		/// <returns></returns>
		public ArrayList PatientDiagnoseQuery(string InPatientNo,string DiagType)
		{
			#region 接口说明
			/////RADT.Diagnose.PatientDiagnoseQuery.2
			///传入：住院流水号
			///传出：患者诊断信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";

			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;

			if(this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.2",ref sql2)==-1)
			{
				this.Err="没有找到RADT.Diagnose.PatientDiagnoseQuery.2字段!";
				this.ErrCode="-1";
				return null;
			}
			sql1=sql1+" "+string.Format(sql2,InPatientNo,DiagType);
			return this.myPatientQuery(sql1);
		}
		/// <summary>
		/// 查询患者各状态诊断
		/// </summary>
		/// <param name="InPatientNo"></param>
		/// <param name="IsValid"></param>
		/// <returns></returns>
		public ArrayList PatientDiagnoseQuery(string InPatientNo,bool IsValid)
		{
			#region 接口说明
			/////RADT.Diagnose.PatientDiagnoseQuery.3
			///传入：住院流水号
			///传出：患者诊断信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";

			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;

			if(this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.3",ref sql2)==-1)
			{
				this.Err="没有找到RADT.Diagnose.PatientDiagnoseQuery.3字段!";
				this.ErrCode="-1";
				return null;
			}
			sql1=sql1+" "+string.Format(sql2,InPatientNo,neusoft.neuFC.Function.NConvert.ToInt32(IsValid).ToString());
			return this.myPatientQuery(sql1);
		}
		/// <summary>
		/// 查询患者主/非主诊断
		/// </summary>
		/// <param name="InPatientNo"></param>
		/// <param name="IsMain"></param>
		/// <returns></returns>
		public ArrayList MainDiagnoseQuery(string InPatientNo,bool IsMain)
		{
			#region 接口说明
			/////RADT.Diagnose.PatientDiagnoseQuery.4
			///传入：0住院流水号1 是否主诊断
			///传出：患者诊断信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";

			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;

			if(this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.4",ref sql2)==-1)
			{
				this.Err="没有找到RADT.Diagnose.PatientDiagnoseQuery.4字段!";
				this.ErrCode="-1";
				return null;
			}
			sql1=sql1+" "+string.Format(sql2,InPatientNo,IsMain.ToString());
			return this.myPatientQuery(sql1);
		}
		/// 查询患者诊断信息的select语句（无where条件）
		private string PatientQuerySelect()
		{
			#region 接口说明
			///RADT.Diagnose.DiagnoseQuery.select.1
			///传入：0
			///传出：sql.select
			#endregion
			string sql="";
			if(this.Sql.GetSql("RADT.Diagnose.DiagnoseQuery.select.1",ref sql)==-1)
			{
				this.Err="没有找到RADT.Diagnose.DiagnoseQuery.select.1字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			return sql;
		}
		//私有函数，查询患者基本信息
		private ArrayList myPatientQuery(string SQLPatient)
		{
			ArrayList al=new ArrayList();
			neusoft.HISFC.Object.RADT.Diagnose Diagnose ;
			this.ProgressBarText="正在查询患者诊断...";
			this.ProgressBarValue=0;
			
			this.ExecQuery(SQLPatient);
			try
			{
				while (this.Reader.Read())
				{
					Diagnose=new neusoft.HISFC.Object.RADT.Diagnose();
					#region "接口说明"
					// 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
					// 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
					// 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
					#endregion
					try
					{
						Diagnose.Patient.ID = this.Reader[0].ToString();// 住院流水号
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.HappenNo = neusoft.neuFC.Function.NConvert.ToInt32(this.Reader[1].ToString());//  发生序号
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.Patient.PID.CardNo = this.Reader[2].ToString();//病历号
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.DiagType.ID = this.Reader[3].ToString();//诊断类别
						DiagnoseType diagnosetype =new DiagnoseType();
						diagnosetype.ID = Diagnose.DiagType.ID;
						Diagnose.DiagType.Name = diagnosetype.Name;//获得诊断名称

					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.ID = this.Reader[4].ToString();		//诊断代码
						Diagnose.ICD10.ID = this.Reader[4].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.Name = this.Reader[5].ToString();		//诊断名称
						Diagnose.ICD10.Name = this.Reader[5].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
				
					try
					{
						Diagnose.DiagDate = neusoft.neuFC.Function.NConvert.ToDateTime(this.Reader[6].ToString());
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.Doctor.ID = this.Reader[7].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.Doctor.Name = this.Reader[8].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.IsValid = neusoft.neuFC.Function.NConvert.ToBoolean(this.Reader[9]);
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.Dept.ID = this.Reader[10].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.IsMain = neusoft.neuFC.Function.NConvert.ToBoolean(this.Reader[11]);
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.Memo = this.Reader[12].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.User01 = this.Reader[13].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						Diagnose.User02 = this.Reader[14].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					al.Add(Diagnose);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得患者诊断信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return al;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}
		#endregion
		#region "ICD10"
		/// <summary>
		/// 查询各疾病编码所对应ICD10
		/// </summary>
		/// <param name="DiseaseCode"></param>
		/// <returns></returns>
		public ArrayList ICD10Query(string  DiseaseCode)
		{
			#region 接口说明
			/////RADT.Diagnose.ICD10Query.1
			///传入：0疾病分类码
			///传出：ICD10诊断信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";

			sql1 = ICD10QuerySelect();
			if (sql1==null ) return null;

			if(this.Sql.GetSql("RADT.Diagnose.ICD10Query.1",ref sql2)==-1)
			{
				this.Err="没有找到RADT.Diagnose.ICD10Query.1字段!";
				this.ErrCode="-1";
				return null;
			}
			sql1=sql1+" "+string.Format(sql2,DiseaseCode);
			return this.myICD10Query(sql1);
		}


		public ArrayList ICD10QueryAll()
		{
			ArrayList al = new ArrayList();
	
			string sqlBegin = "";

			sqlBegin = this.ICD10QuerySelect();

			return this.myICD10Query( sqlBegin );
		}

		/// <summary>
		/// 查询各分类ICD10
		/// </summary>
		/// <param name="DiagnoseType"></param>
		/// <returns></returns>
		public ArrayList ICD10Query(DiagnoseType DiagnoseType)
		{
			#region 接口说明
			/////RADT.Diagnose.ICD10Query.2
			///传入：0诊断分类
			///传出：ICD10诊断信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";

			sql1 = ICD10QuerySelect();
			if (sql1==null ) return null;

			if(this.Sql.GetSql("RADT.Diagnose.ICD10Query.2",ref sql2)==-1)
			{
				this.Err="没有找到RADT.Diagnose.ICD10Query.2字段!";
				this.ErrCode="-1";
				return null;
			}
			sql1=sql1+" "+string.Format(sql2,DiagnoseType.ID);
			return this.myICD10Query(sql1);
		}
		/// 查询患者诊断信息的select语句（无where条件）
		private string ICD10QuerySelect()
		{
			#region 接口说明
			///RADT.Diagnose.ICD10Query.select.1
			///传入：0
			///传出：sql.select
			#endregion
			string sql="";
			if(this.Sql.GetSql("RADT.Diagnose.ICD10Query.select.1",ref sql)==-1)
			{
				this.Err="没有找到RADT.Diagnose.ICD10Query.select.1字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			return sql;
		}
		//私有函数，查询患者基本信息
		private ArrayList myICD10Query(string SQLPatient)
		{
			ArrayList al=new ArrayList();
			neusoft.HISFC.Object.RADT.ICD10 objICD ;
			this.ProgressBarText="正在查询ICD10诊断...";
			this.ProgressBarValue=0;
			
			this.ExecQuery(SQLPatient);
			try
			{
				while (this.Reader.Read())
				{
					objICD=new ICD10();
					#region "接口说明"
					///接口名称 RADT.Diagnose.CreatePatientDiagnose.1
					// 0  --ICD10码      1   --副诊断码     2   --拼音码         3   --五笔码  ,    4   --中文疾病名称
					// 5  --疾病名称1,   6   --疾病名称2   ,7   --疾病死亡原因  ,8   --疾病分类码 , 9   --标准住院日
					// 10 --住院等级    11   --操作员      12   --操作时间
					#endregion
					try
					{
						objICD.ID = this.Reader[0].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.SICD10 = this.Reader[1].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.SpellCode.Spell_Code = this.Reader[2].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.SpellCode.WB_Code  = this.Reader[3].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.Name = this.Reader[4].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.User01 = this.Reader[5].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.User02 = this.Reader[6].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.DeadReason = this.Reader[7].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.DiseaseCode = this.Reader[8].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.InDays = int.Parse(this.Reader[9].ToString());
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.Memo = this.Reader[10].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						objICD.User03 = this.Reader[11].ToString();
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					
					try
					{
						objICD.OperDate = neusoft.neuFC.Function.NConvert.ToDateTime(this.Reader[12]);
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					
					al.Add(objICD);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得ICD10诊断信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return al;
			}
			this.Reader.Close();

			this.ProgressBarValue=-1;
			return al;
		}
		/// <summary>
		/// 更新ICD10信息，如果发现不能更新则插入一条
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateICD( neusoft.HISFC.Object.RADT.ICD10 info )
		{
			string strSql = "", strSql2;
			int i = 0;
			if (this.Sql.GetSql("RADT.Diagnose.myIcdManagerImpl.UpdatemyIcd",ref strSql)==-1) return -1;
			
			try
			{   				
				strSql = string.Format(strSql,info.ID, info.SICD10, info.SpellCode.Spell_Code, 
										info.SpellCode.WB_Code, info.Name, info.User01, info.User02, 
										info.DeadReason, info.DiseaseCode, info.InDays.ToString(), 
										info.Memo, info.User03, info.OperDate.ToString());

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				i = this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}

			if( i == 0 ) //插入
			{			
				if (this.Sql.GetSql("RADT.Diagnose.myIcdManagerImpl.InsertmyIcd",ref strSql)==-1) return -1;
				try
				{
					strSql2 = string.Format(strSql,strSql,info.ID, info.SICD10, info.SpellCode.Spell_Code, 
						info.SpellCode.WB_Code, info.Name, info.User01, info.User02, 
						info.DeadReason, info.DiseaseCode, info.InDays.ToString(), 
						info.Memo, info.User03, info.OperDate.ToString());
				}
				catch(Exception ex)
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return -1;
				}
				
				return this.ExecNoQuery(strSql2);
			}
			else if( i > 0 )
				return 0;
			else
			{
				return -1;
			}
		}
		/// <summary>
		/// 删除ICD10信息
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int DeleteICD( neusoft.HISFC.Object.RADT.ICD10 info )
		{
			string strSql = "";
			if (this.Sql.GetSql("RADT.Diagnose.myIcdManagerImpl.DeletemyIcd",ref strSql)==-1) return -1;
				
			try
			{   				
				strSql = string.Format(strSql, info.ID);

			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}      			

			try
			{
				return this.ExecNoQuery(strSql);
			}
			catch(Exception ex)
			{
				this.ErrCode=ex.Message;
				this.Err=ex.Message;
				return -1;
			}

		}

		#endregion
		#endregion


	}
}
