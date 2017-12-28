using System;
using System.Collections;
using System.Xml;
namespace Neusoft.HISFC.BizLogic.AdminQuery
{
	/// <summary>
	/// 院长查询
	/// 继承于DataBase类
	/// [修改记录]
	/// 2006-11-7
	/// 添加院长查询人员表信息类
	/// </summary>
	public class AdminQuery:Neusoft.FrameWork.Management.Database
	{
		/// <summary>
		/// 构着函数
		/// </summary>
		public AdminQuery()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected const string index = "AdministratorQuery";
		/// <summary>
		/// ArrayList 
		/// 获得所有
		/// </summary>
		/// <returns></returns>
		public ArrayList GetListItems(string SqlID,string EmplID, string[] Params) 
		{
			//Filled By Neusoft.HISFC.Object.Base.Department
			string sql = "";
			if(this.Sql.GetSql(SqlID,ref sql)== -1)
				return null;

			sql = sql.Replace("[登录人员编码]", EmplID);
			if(Params != null)
			{
				for(int i=0;i<Params.Length;i+=2)
				{
					sql = sql.Replace(Params[i],Params[i+1]);
				}
			}

			return this.myGetListItems(sql);
		}
		/// <summary>
		/// 根据sql语句取科室列表
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private ArrayList myGetListItems(string sql) 
		{
			if(this.ExecQuery(sql) == -1) return null;

			ArrayList result = new ArrayList();   
			while(this.Reader.Read()) 
			{
				Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
				obj.ID = (string)this.Reader[0];
				if(this.Reader[1] == null || this.Reader[1] == System.DBNull.Value)
				{
					obj.Name = "(空白)";
				}
				else
				{
					obj.Name = (string)this.Reader[1];
				}
				result.Add(obj);
			}
			this.Reader.Close();
			return result;
		}
		/// <summary>
		/// 获得相关SQL
		/// 返回NeuObject
		/// </summary>
		/// <returns></returns>
		public ArrayList GetSQL()
		{
			ArrayList al = new ArrayList();
			if(this.Sql == null) 
			{
				this.Err = "没有设置sql";
				return null;
			}
			foreach(Neusoft.FrameWork.Models.NeuObject  info in this.Sql.alSql)
			{
				//				if(info.ID.IndexOf(index)>=0)
				if(info.ID.ToLower().StartsWith(index.ToLower()))
					al.Add(info);
			}
			return al;
		}
		
		/// <summary>
		/// 获得sql里面的参数信息参数
		/// [参数名]
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public object[] GetParams(string sql)
		{
			int start = 0 ,end =0;
			ArrayList al =new ArrayList();
			string s = "";
			al.Add("无");
			while(1 == 1)
			{
				start = sql.IndexOf("[",end);
				end = sql.IndexOf("]",end);
				if(start<0 || end < 0) break;
				s = sql.Substring(start+1,end - start-1);
				s = "["+s+"]";
				al.Add(s);
				end++;
			}
			return al.ToArray();	
		}
		
		/// <summary>
		/// 获得查询的字段
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public object[] GetFields(string sql)
		{
			ArrayList al =new ArrayList();
			object[] param = this.GetParams(sql);
			for(int j=0;j<param.Length;j++)
			{
				sql = sql.Replace(param[j].ToString(),System.DateTime.Now.ToString());
			}

			System.Data.OracleClient.OracleDataAdapter adapter = new System.Data.OracleClient.OracleDataAdapter(sql,this.con.ConnectionString);
			System.Data.DataSet ds = new System.Data.DataSet();
			adapter.Fill(ds,0,0,"table");
			if(ds==null) return al.ToArray();
			for(int i=0;i<ds.Tables[0].Columns.Count;i++)
			{
				al.Add(ds.Tables[0].Columns[i].Caption);
			}
			return al.ToArray();
		}
        static string strConn;
		/// <summary>
		/// 执行sql
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="strDataSet"></param>
		/// <param name="strXSLFileName"></param>
		/// <param name="SettingXml"></param>
		/// <returns></returns>
        public int ExecQuery(string strSql, ref string strDataSet, string strXSLFileName, string SettingXml)
        {
            System.Data.OracleClient.OracleConnection con = new System.Data.OracleClient.OracleConnection(strConn);
            System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand();
            command.Connection = con;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();
            command.CommandText = strSql + "";
            try
            {
                System.Data.OracleClient.OracleDataReader TempReader1;
                TempReader1 = command.ExecuteReader();
                XmlDocument doc = new XmlDocument();
                XmlNode root;
                XmlElement node, row;
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", "GB2312", ""));
                if (strXSLFileName != null && strXSLFileName != "")
                {
                    string PI = "type='text/xsl' href='" + strXSLFileName + "'";
                    System.Xml.XmlProcessingInstruction xmlProcessingInstruction = doc.CreateProcessingInstruction("xml-stylesheet", PI);
                    doc.AppendChild(xmlProcessingInstruction);
                }
                string Header = doc.OuterXml + "\n<DataSet>\n" + SettingXml;
                doc = new XmlDocument();
                root = doc.CreateElement("Table");
                doc.AppendChild(root);
                while (TempReader1.Read())
                {
                    row = doc.CreateElement("Row");
                    for (int i = 0; i < TempReader1.FieldCount; i++)
                    {
                        node = doc.CreateElement("Column");
                        node.SetAttribute("Name", TempReader1.GetName(i).ToString());
                        node.InnerText = TempReader1[i].ToString() + "";
                        row.AppendChild(node);
                    }
                    root.AppendChild(row);
                }
                strDataSet = Header + "\n" + doc.OuterXml + "\n</DataSet>";
                TempReader1.Close();
            }
            catch (Exception ex)
            {
                this.Err = "执行语句产生错误!" + ex.Message;
                this.ErrorException = ex.InnerException + "+ " + ex.Source;
                this.ErrCode = strSql;
                this.WriteErr();
                return -1;
            }

            WriteDebug("执行查询sql语句！" + strSql);
            return 0;
        }

		#region 按科室和状态查询患者信息列表
		/// <summary>
		/// 患者查询-根据输入在院状态参数查询全院所有患者
		/// </summary>
		/// <param name="State">住院状态</param>
		/// <returns></returns>
		public ArrayList PatientQueryByState(Neusoft.HISFC.Models.RADT.InStateEnumService State) 
		{
			#region 接口说明
			//RADT.Inpatient.PatientQuery.where.6
			//传入：科室编码，住院状态
			//传出：患者信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";
			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;
			
			if(this.Sql.GetSql("RADT.Inpatient.PatientQuery.WebQuery.ByState",ref sql2)==-1) 
			{
				this.Err="没有找到RADT.Inpatient.PatientQuery.WebQuery.ByState字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			sql2=" "+string.Format(sql2,State.ID.ToString());
			return this.myPatientQuery(sql1+sql2);
		}

		/// <summary>
		/// 患者查询-根据输入患者住院号参数查询全院所有患者
		/// </summary>
		/// <param name="ID">住院号</param>
		/// <returns></returns>
		public ArrayList PatientQueryByID(string ID) 
		{
			#region 接口说明
			//RADT.Inpatient.PatientQuery.where.6
			//传入：科室编码，住院状态
			//传出：患者信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";
			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;
			
			if(this.Sql.GetSql("RADT.Inpatient.PatientQuery.WebQuery.ByID",ref sql2)==-1) 
			{
				this.Err="没有找到RADT.Inpatient.PatientQuery.WebQuery.ByID字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			sql2=" "+string.Format(sql2,ID);
			return this.myPatientQuery(sql1+sql2);
		}

		/// <summary>
		/// 患者查询-根据输入患者姓名参数查询全院所有患者
		/// </summary>
		/// <param name="Name">患者姓名</param>
		/// <returns></returns>
		public ArrayList PatientQueryByName(string Name) 
		{
			#region 接口说明
			//RADT.Inpatient.PatientQuery.where.6
			//传入：科室编码，住院状态
			//传出：患者信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";
			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;
			
			if(this.Sql.GetSql("RADT.Inpatient.PatientQuery.WebQuery.ByName",ref sql2)==-1) 
			{
				this.Err="没有找到RADT.Inpatient.PatientQuery.WebQuery.ByName字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			sql2=" "+string.Format(sql2,Name);
			return this.myPatientQuery(sql1+sql2);
		}

		/// <summary>
		/// 患者查询-根据输入入院时间参数查询全院所有患者
		/// </summary>
		/// <param name="BeginDate">查询开始时间</param>
		/// <param name="EndDate">查询结束时间</param>
		/// <returns></returns>
		public ArrayList PatientQueryByInDate(string BeginDate, string EndDate) 
		{
			#region 接口说明
			//RADT.Inpatient.PatientQuery.where.6
			//传入：科室编码，住院状态
			//传出：患者信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";
			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;
			
			if(this.Sql.GetSql("RADT.Inpatient.PatientQuery.WebQuery.ByInDate",ref sql2)==-1) 
			{
				this.Err="没有找到RADT.Inpatient.PatientQuery.WebQuery.ByInDate字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			sql2=" "+string.Format(sql2,BeginDate, EndDate);
			return this.myPatientQuery(sql1+sql2);
		}

		/// <summary>
		/// 患者查询-根据输入科室参数查询全院所有患者
		/// </summary>
		/// <param name="Dept">科室编码</param>
		/// <returns></returns>
		public ArrayList PatientQueryByDept(string Dept) 
		{
			#region 接口说明
			//RADT.Inpatient.PatientQuery.where.6
			//传入：科室编码，住院状态
			//传出：患者信息
			#endregion
			ArrayList al=new ArrayList();
			string sql1="",sql2="";
			sql1 = PatientQuerySelect();
			if (sql1==null ) return null;
			
			if(this.Sql.GetSql("RADT.Inpatient.PatientQuery.WebQuery.ByDept",ref sql2)==-1) 
			{
				this.Err="没有找到RADT.Inpatient.PatientQuery.WebQuery.ByDept字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			sql2=" "+string.Format(sql2,Dept);
			return this.myPatientQuery(sql1+sql2);
		}

//		/// <summary>
//		/// 患者查询-查询科室不同状态的患者
//		/// </summary>
//		/// <param name="dept_code">科室编码</param>
//		/// <param name="State">住院状态</param>
//		/// <returns></returns>
//		public ArrayList PatientQuery(string dept_code,Object.RADT.VisitStatus State) 
//		{
//			#region 接口说明
//			//RADT.Inpatient.PatientQuery.where.6
//			//传入：科室编码，住院状态
//			//传出：患者信息
//			#endregion
//			ArrayList al=new ArrayList();
//			string sql1="",sql2="";
//			sql1 = PatientQuerySelect();
//			if (sql1==null ) return null;
//			
//			if(this.Sql.GetSql("RADT.Inpatient.PatientQuery.Where.9",ref sql2)==-1) 
//			{
//				this.Err="没有找到RADT.Inpatient.PatientQuery.Where.9字段!";
//				this.ErrCode="-1";
//				this.WriteErr();
//				return null;
//			}
//			sql2=" "+string.Format(sql2,State.ID.ToString());
//			return this.myPatientQuery(sql1+sql2);
//		}
		#endregion

		#region 按传入的Sql语句查询患者信息列表--私有
		private ArrayList myPatientQuery(string SqlOperator) 
		{
			ArrayList al=new ArrayList();
			Neusoft.FrameWork.Models.NeuObject PatientInfo = new Neusoft.FrameWork.Models.NeuObject();
			this.ProgressBarText="正在查询患者...";
			this.ProgressBarValue=0;

			if(this.ExecQuery(SqlOperator) == -1) return null;
			//取系统时间,用来得到年龄字符串
			DateTime sysDate = this.GetDateTimeFromSysDateTime();

			try 
			{
				while (this.Reader.Read()) 
				{
					PatientInfo=new Neusoft.FrameWork.Models.NeuObject();
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
					//,76 总共金额tot_cost ,77 自费金额 own_cost,	78 自付金额 Pay_Cost,79 公费金额 Pub_Cost
					//,80 剩余金额 Left_Cost,81 优惠金额
					//,82  预交金额 ，83    费用金额(已结)，84    预交金额(已结) ， 85 结算日期(上次)     
					//，86 警戒线, 87 转归代号,88 ChangePrepay 转入预交金额（未结)  ,89 转入费用金额(未结),90 病床状态91公费日限额超标部分
					//,92 特注93公费日限额94血滞纳金95住院次数96床位上限97空调上限98门诊诊断99收住医师100生育保险电脑号
					//-->
					#endregion
					try 
					{
						if(!this.Reader.IsDBNull(0)) PatientInfo.ID = this.Reader[0].ToString();// 住院流水号
						if(!this.Reader.IsDBNull(1)) PatientInfo.Name =this.Reader[1].ToString();//姓名
						if(!this.Reader.IsDBNull(2)) PatientInfo.Memo =this.Reader[2].ToString();//  住院号						
						if(!this.Reader.IsDBNull(3)) PatientInfo.User01 =Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[3]).ToLongDateString();//  入院日期
						if(!this.Reader.IsDBNull(4)) PatientInfo.User02 =this.Reader[4].ToString();//  科室代码
						if(!this.Reader.IsDBNull(5)) PatientInfo.User03 =this.Reader[5].ToString();// 科室名称
					}
					catch(Exception ex) 
					{ 
						this.Err=ex.Message;
						this.WriteErr();
						if(!Reader.IsClosed)
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
					this.ProgressBarValue++;
					al.Add(PatientInfo);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得患者基本信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				return al;
			}
			this.Reader.Close();
			
			this.ProgressBarValue=-1;
			return al;
		}
		#endregion		

		#region 无条件查询患者信息列表
		/// 查询患者信息的select语句（无where条件）
		private string PatientQuerySelect() 
		{
			#region 接口说明
			//RADT.Inpatient.PatientQuery.select.1
			//传入：0
			//传出：sql.select
			#endregion
			string sql="";
			if(this.Sql.GetSql("RADT.Inpatient.PatientQuery.WebQuery.Select",ref sql)==-1) 
			{
				this.Err="没有找到RADT.Inpatient.PatientQuery.WebQuery.Select字段!";
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			return sql;
		}
		#endregion

		/// <summary>
		/// 获得用户TreeList
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public ArrayList GetUserTreeList(string userID)
		{
			return null;
		}

        //public string GetDate(string sid)
        //{
        //    QueryResult result = new QueryResult();
        //    return result.GetDate(sid);
        //}

		#region 院长查询人员表
		/// <summary>
		/// 删除院长查询人员信息
		/// </summary>
		/// <param name="Empl_Code"></param>
		/// <returns></returns>
		public int DeleteAQOperator(string Empl_Code) 
		{
			string sql = "";
			if(this.Sql.GetSql("AdminQuery.AQPermission.Delete",ref sql)== -1)
				return -1;

		 
			try 
			{
				sql=string.Format(sql, Empl_Code);
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}

			if(this.ExecNoQuery(sql) == -1) return -1;

			return 1;
		}

		/// <summary>
		/// 插入院长查询人员信息
		/// </summary>
		/// <param name="info">患者实体</param>
		/// <returns></returns>
		public int InsertAQPermission(Neusoft.FrameWork.Models.NeuObject info) 
		{
			
			string sql = "";
			if(this.Sql.GetSql("AdminQuery.AQPermission.Insert",ref sql)== -1)
				return -1;
//			insert into his_role_aqOperator
//			(PARENT_CODE,    --VARCHAR2(6)                   父级组代码   
//			GROUP_CODE ,    --VARCHAR2(6)                   本级组代码   
//			EMPL_CODE,      --VARCHAR2(6)                   员工代码     
//			LOGIN_PASSWORD, --VARCHAR2(8)  Y                登录人员密码 
//			LOGIN_NAME,     --VARCHAR2(20)                  员工登录姓名 
//			MANAGER_FLAG,   --VARCHAR2(1)  Y                管理员标志   
//			GROUP_NAME,     --VARCHAR2(30) Y                本级组名称   
//			PARENT_NAME ,   --VARCHAR2(30) Y                父级组名称   
//			EMPL_NAME,      --VARCHAR2(10) Y                员工姓名     
//			OWNER_FLAG)     --VARCHAR2(1)  Y        0        
//			values('{0}','{0}', '{1}', '{2}','{3}','0','{4}','{4}','{5}','0')
			try 
			{
				sql=string.Format(sql, info.User02, info.ID, info.User01, info.Memo, info.User03, info.Name);
				
			}
			catch(Exception ex) 
			{
				this.ErrCode=ex.Message;
				this.Err="接口错误！"+ex.Message;
				this.WriteErr();
				return -1;
			}

			if(this.ExecNoQuery(sql) == -1) return -1;


			return 1;
		}

		/// <summary>
		/// 获得查询人员列表
		/// </summary>
		/// <returns></returns>
		public ArrayList GetAQOperator() 
		{
			#region 接口说明
			//获得各类型人员列表
			//Manager.Person.GetEmployee.1
			//传入：0 type 人员类型 
			//传出：人员信息
			#endregion
			string strSql="";
			if (this.Sql.GetSql("AdminQuery.AQPermission.GetOperatorList",ref  strSql) == 0 ) 
			{
				try 
				{
					strSql= string.Format(strSql);
				}
				catch(Exception ex) 
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
			}
			else 
			{
				return null;
			}
			return this.myOperatorQuery(strSql);
		}

		/// <summary>
		/// 获得单个查询人员权限列表
		/// </summary>
		/// <param name="Operator_ID"></param>
		/// <returns></returns>
		public ArrayList GetAQOperatorPermission(string Operator_ID) 
		{
			string strSql="";
			if (this.Sql.GetSql("AdminQuery.AQPermission.GetOPeratorPermissionList",ref  strSql) == 0 ) 
			{
				try 
				{
					strSql= string.Format(strSql, Operator_ID);
				}
				catch(Exception ex) 
				{
					this.Err=ex.Message;
					this.ErrCode=ex.Message;
					return null;
				}
			}
			else 
			{
				return null;
			}
			return this.myOperatorPermissionQuery(strSql);
		}

		/// <summary>
		/// 私有函数，所有院长查询人员基本信息
		/// </summary>
		/// <param name="SqlOperator"></param>
		/// <returns></returns>
		private ArrayList myOperatorQuery(string SqlOperator) 
		{
			ArrayList al=new ArrayList();
			
			if (this.ExecQuery(SqlOperator) == -1) return null;
			try 
			{
		
				while(this.Reader.Read()) 
				{
					Neusoft.FrameWork.Models.NeuObject obj= new Neusoft.FrameWork.Models.NeuObject();
					try 
					{
//						SELECT   distinct a.empl_code,   --员工代码
//						a.empl_name,   --员工姓名
//						a.login_password,   --登录人员密码
//						a.login_name,   --员工登录姓名
//						a.manager_flag,   --管理员标志
//						a.owner_flag,   --特殊标志
//						'',--五笔码
//						''   --拼音码
//						FROM his_role_Aqoperator a ,r_employee b  --权限管理人员明细
//						where a.empl_code = b.empl_code 
    
						obj.ID = this.Reader[0].ToString();
						obj.Name = this.Reader[1].ToString();
						obj.User01 = this.Reader[2].ToString();
						obj.Memo = this.Reader[3].ToString();				
						obj.User02 = "0";
						obj.User03 = "0";
					}	
					catch(Exception ex) 
					{
						this.Err="获得院长查询人员信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					al.Add(obj);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得院长查询人员信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return al;
		}

		/// <summary>
		/// 私有函数，单个查询人员权限信息
		/// </summary>
		/// <param name="SqlOperatorPermission"></param>
		/// <returns></returns>
		private ArrayList myOperatorPermissionQuery(string SqlOperatorPermission) 
		{
			ArrayList al=new ArrayList();
			
			if (this.ExecQuery(SqlOperatorPermission) == -1) return null;
			try 
			{
		
				while(this.Reader.Read()) 
				{
					Neusoft.FrameWork.Models.NeuObject obj= new Neusoft.FrameWork.Models.NeuObject();
					try 
					{
//						select 
//						PARENT_CODE,    --VARCHAR2(6)                   父级组代码   
//						GROUP_CODE,     --VARCHAR2(6)                   本级组代码   
//						EMPL_CODE,      --VARCHAR2(6)                   员工代码     
//						LOGIN_PASSWORD, --VARCHAR2(8)  Y                登录人员密码 
//						LOGIN_NAME,     --VARCHAR2(20)                  员工登录姓名 
//						MANAGER_FLAG,   --VARCHAR2(1)  Y                管理员标志   
//						GROUP_NAME,     --VARCHAR2(30) Y                本级组名称   
//						PARENT_NAME,    --VARCHAR2(30) Y                父级组名称   
//						EMPL_NAME,      --VARCHAR2(10) Y                员工姓名     
//						OWNER_FLAG     --VARCHAR2(1)  Y        0                 
//						from his_role_aqoperator --院长查询权限表
//						where empl_code = '{0}'    
						obj.ID = this.Reader[2].ToString();
						obj.Name = this.Reader[8].ToString();
						obj.User01 = this.Reader[3].ToString();
						obj.Memo = this.Reader[4].ToString();				
						obj.User02 = this.Reader[1].ToString();
						obj.User03 = this.Reader[6].ToString();
					}	
					catch(Exception ex) 
					{
						this.Err="获得院长查询人员信息出错！"+ex.Message;
						this.WriteErr();
						return null;
					}
					al.Add(obj);
				}
			}//抛出错误
			catch(Exception ex) 
			{
				this.Err="获得院长查询人员信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return null;
			}
			this.Reader.Close();
			return al;
		}
		#endregion 院长查询人员表

	}
}
