using System;
using System.Collections;
using System.Data;
namespace Neusoft.HISFC.BizLogic.Operation
{
	/// <summary>
	/// OpsReport 的摘要说明。
	/// </summary>
	public abstract class OpsReport : Neusoft.FrameWork.Management.Database 
	{
		public OpsReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 各报表函数
		/// <summary>
		/// 手术患者信息查询
		/// </summary>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport03(DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			//Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
			#region 获取数据的变量
			string strName = string.Empty;//姓名
			string strBedNo = string.Empty;//床号
			string strPatientNo = string.Empty;//住院号/病案号
			Neusoft.HISFC.Models.Base.SexEnumService sex = new Neusoft.HISFC.Models.Base.SexEnumService();//性别
			//获取年龄
			int iBirthYear = 0;//出生年
			int iThisYear = 0;//本年
			string strAge = string.Empty;//年龄
			string strDiagnose = string.Empty;//术前诊断
			string strItem = string.Empty;//手术名称(主手术)
			string strEnterDate = string.Empty;//开始手术时间
			string strOutDate = string.Empty;//结束手术时间
			string strOpsDoct = string.Empty;//手术医生
			string strAnesType = string.Empty;//麻醉方式
			Neusoft.FrameWork.Models.NeuObject OpsKind = new Neusoft.FrameWork.Models.NeuObject();//手术分类
			#endregion
			string strSql = string.Empty;
			
			if(this.Sql.GetSql("Operator.OpsReport.GetReport03",ref strSql) == -1) 
			{
				return null;
			}

			try
			{	
				strSql = string.Format(strSql,BeginTime.ToString(),EndTime.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport03";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			
			if (strSql == null) 
				return null;
			
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					Neusoft.HISFC.Models.Base.Employee employee = new Neusoft.HISFC.Models.Base.Employee();
					alDataRow.Clear();
					strName = Reader[0].ToString();//姓名
					strBedNo = Reader[1].ToString();//床号
					strPatientNo = Reader[2].ToString();//住院号/病案号
					sex.ID = Reader[3].ToString();//性别
					iBirthYear = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[4].ToString()).Year;
					iThisYear = this.GetDateTimeFromSysDateTime().Year;
					strAge = System.Convert.ToString(iThisYear - iBirthYear);//年龄
					strDiagnose = Reader[5].ToString();//术前诊断
					strItem = Reader[6].ToString();//手术名称
					strEnterDate = Reader[7].ToString();//手术开始时间
					strOutDate = Reader[8].ToString();//手术结束时间
					employee.ID = Reader[9].ToString();
					strOpsDoct = employee.Name;//手术医生
					strAnesType = Reader[10].ToString();//麻醉方式
					OpsKind.ID = Reader[11].ToString();//手术分类
					switch(OpsKind.ID.ToString())
					{
						case "1"://普通
							OpsKind.Name = "普通";
							break;
						case "2"://急诊
							OpsKind.Name = "急诊";
							break;
						case "3"://感染
							OpsKind.Name = "感染";
							break;
						default:
							OpsKind.Name = string.Empty;
							break;
					}
					//将当前行数据加载
					alDataRow.Add(strName);
					alDataRow.Add(strBedNo);
					alDataRow.Add(strPatientNo);
					alDataRow.Add(sex.Name);
					alDataRow.Add(strAge);
					alDataRow.Add(strDiagnose);
					alDataRow.Add(strItem);
					alDataRow.Add(strEnterDate);
					alDataRow.Add(strOutDate);
					alDataRow.Add(strOpsDoct);
					alDataRow.Add(strAnesType);
					alDataRow.Add(OpsKind.Name);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport03";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 手术分类统计一览表
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport05(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			
			string strOpsKind = string.Empty;
			string strDegree = string.Empty;
			string strCount = string.Empty;

			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport05",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport05";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strOpsKind = Reader[0].ToString();//手术类别
					strDegree = Reader[1].ToString();//手术规模
					strCount = Reader[2].ToString();//例数					
					
					//将当前行数据加载
					alDataRow.Add(strOpsKind);
					alDataRow.Add(strDegree);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport05";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 分类汇总统计手术例数(按手术医生所在病区)
		/// </summary>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		[Obsolete("这个函数有问题，不能用",true)]
		public ArrayList GetReport06(DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			
			string strDeptName = string.Empty;
			string strDegree = string.Empty;
			string strCount = string.Empty;
			Neusoft.HISFC.Models.Base.Employee employee =new Neusoft.HISFC.Models.Base.Employee();
			employee.ID= this.Operator.ID;
			string strSql = string.Empty;

			if(this.Sql.GetSql("Operator.OpsReport.GetReport06",ref strSql) == -1) 
			{
				return null;
			}

			try
			{	
				strSql = string.Format(strSql,BeginTime.ToString(),EndTime.ToString(),employee.Dept.ID);
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport06";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strDeptName = Reader[0].ToString();//手术医生所在科室
					strDegree = Reader[1].ToString();//手术规模
					strCount = Reader[2].ToString();//例数					
					
					//将当前行数据加载
					alDataRow.Add(strDeptName);
					alDataRow.Add(strDegree);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport06";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 分类汇总统计手术例数(按手术医生所在病区)  by  zlw 2006-5-17
		/// </summary>
		/// <param name="DeptID">执行科室</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport06(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			
			string strDeptName = string.Empty;
			string strDegree = string.Empty;
			string strCount = string.Empty;
//			Neusoft.HISFC.Models.RADT.Person ps = (Neusoft.HISFC.Models.RADT.Person)this.Operation;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport06",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,BeginTime.ToString(),EndTime.ToString(),DeptID);
				
				//				strSql = string.Format(strSql,BeginTime.ToString(),EndTime.ToString(),ps.Dept.ID);
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport06";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strDeptName = Reader[0].ToString();//手术医生所在科室
					strDegree = Reader[1].ToString();//手术规模
					strCount = Reader[2].ToString();//例数					
					
					//将当前行数据加载
					alDataRow.Add(strDeptName);
					alDataRow.Add(strDegree);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport06";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}

		
		/// <summary>
		/// 分类汇总统计手术例数(按患者所在病区)  by  cuip 2006-8
		/// </summary>
		/// <param name="DeptID">执行科室</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport06_1(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			
			string strDeptName = string.Empty;
			string strDegree = string.Empty;
			string strCount = string.Empty;
			//			Neusoft.HISFC.Models.RADT.Person ps = (Neusoft.HISFC.Models.RADT.Person)this.Operation;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport06_1",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,BeginTime.ToString(),EndTime.ToString(),DeptID);
				
				//				strSql = string.Format(strSql,BeginTime.ToString(),EndTime.ToString(),ps.Dept.ID);
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport06";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strDeptName = Reader[0].ToString();//手术医生所在科室
					strDegree = Reader[1].ToString();//手术规模
					strCount = Reader[2].ToString();//例数					
					
					//将当前行数据加载
					alDataRow.Add(strDeptName);
					alDataRow.Add(strDegree);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport06";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}

		/// <summary>
		/// 手术分类汇总统计(按性别)
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport07(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			Neusoft.HISFC.Models.Base.SexEnumService sex = new Neusoft.HISFC.Models.Base.SexEnumService();;
			string strCount = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport07",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport07";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					sex.ID = Reader[0].ToString();
					strCount = Reader[1].ToString();
					//将当前行数据加载
					alDataRow.Add(sex.Name);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport07";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 手术分类汇总统计(按术前诊断)
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport08(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			string strDiagnose = string.Empty;
			string strCount = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport08",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString(),"1");
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport08";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strDiagnose = Reader[0].ToString();
					strCount = Reader[1].ToString();
					//将当前行数据加载
					alDataRow.Add(strDiagnose);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport08";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 手术分类汇总统计(按手术名称)
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport09(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			string strItem = string.Empty;
			string strCount = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport09",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString(),"1");
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport09";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strItem = Reader[0].ToString();
					strCount = Reader[1].ToString();
					//将当前行数据加载
					alDataRow.Add(strItem);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport09";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 手术分类汇总统计(按麻醉方式)
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport10(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			string strAnaeType = string.Empty;
			string strCount = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport10",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString(),"1");
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport10";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strAnaeType = Reader[0].ToString();
					strCount = Reader[1].ToString();
					//将当前行数据加载
					alDataRow.Add(strAnaeType);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport10";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 按医生分类汇总统计手术例数
		/// Robin 修改，调用方法已变
		/// </summary>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport11(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();			 
			string strCount = string.Empty;
			string personID = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport11",ref strSql) == -1) 
				return null;

			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport11";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			
			if (strSql == null) 
				return null;

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
                    alDataRow = new ArrayList();
                    personID = Reader[0].ToString();
                    string deptName = Reader[1].ToString();
                    strCount = Reader[2].ToString(); 
                    alDataRow.Add(personID); 
                    alDataRow.Add(deptName);
                    alDataRow.Add(strCount);
					al.Add(alDataRow);
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport11";
				this.ErrCode = ex.Message;
				this.WriteErr();
				this.Reader.Close();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 进入PACU的病人统计
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport12(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			Neusoft.HISFC.Models.Base.SexEnumService sex = new Neusoft.HISFC.Models.Base.SexEnumService();
			string strCount = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport12",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport12";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}

			if (strSql == null) 
				return null;

			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					sex.ID = Reader[0].ToString();
					strCount = Reader[1].ToString();
					//将当前行数据加载
					alDataRow.Add(sex.Name);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport12";
				this.ErrCode = ex.Message;
				this.WriteErr();
				this.Reader.Close();
				return null;
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 按入室状况分类汇总统计进入PACU的手术例数
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport13(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			string strStatus = string.Empty;
			string strCount = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport13",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport13";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strStatus = Reader[0].ToString();
					strCount = Reader[1].ToString();
					//将当前行数据加载
					alDataRow.Add(strStatus);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport13";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 按出室状况分类汇总统计进入PACU的手术例数
		/// </summary>
		/// <param name="DeptID">科室编码</param>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport14(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			ArrayList alDataRow = new ArrayList();
			string strStatus = string.Empty;
			string strCount = string.Empty;
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport14",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,DeptID,BeginTime.ToString(),EndTime.ToString());
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport14";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{					
					alDataRow.Clear();
					strStatus = Reader[0].ToString();
					strCount = Reader[1].ToString();
					//将当前行数据加载
					alDataRow.Add(strStatus);
					alDataRow.Add(strCount);
					al.Add(alDataRow.Clone());
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport14";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 非正台手术统计表
		/// </summary>
		/// <param name="DeptID"></param>
		/// <param name="BeginTime"></param>
		/// <param name="EndTime"></param>
		/// <param name="opsQty1"></param>
		/// <param name="opsQty2"></param>
		/// <returns></returns>
		public int GetReport20(string DeptID,DateTime BeginTime,DateTime EndTime,ref int opsQty1,ref int opsQty2)
		{
			string strSql=string.Empty;
			int Qty1=0,Qty2=0;

			if(Sql.GetSql("Operator.OpsReport.GetReport20",ref strSql)==-1)return -1;
			try
			{
				strSql=string.Format(strSql,BeginTime.ToString(),EndTime.ToString(),DeptID);
				if(ExecQuery(strSql)==-1)return -1;
				while(Reader.Read())
				{
					decimal cost=Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[0].ToString());
					if(cost>=1000)
						Qty1++;
					else
						Qty2++;
				}
				Reader.Close();
			}
			catch(Exception e)
			{
				this.Err="Operator.OpsReport.GetReport20!"+e.Message;
				this.ErrCode=e.Message;
				WriteErr();
				return -1;
			}
			
			opsQty1=Qty1;
			opsQty2=Qty2;
			return 0;
		}
		/// <summary>
		/// 按病区分类汇总手术取消的数量
		/// </summary>
		/// <param name="BeginTime">起始时间</param>
		/// <param name="EndTime">终止时间</param>
		/// <returns>符合条件的数据行数组（元素为反映数据行信息的数组）</returns>
		public ArrayList GetReport21(string DeptID,DateTime BeginTime,DateTime EndTime)
		{
			ArrayList al = new ArrayList();
			
			//Neusoft.HISFC.BizLogic.Manager.Department objdept = new Neusoft.HISFC.BizLogic.Manager.Department();
			
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsReport.GetReport21",ref strSql) == -1) return null;
			try
			{	
				strSql = string.Format(strSql,BeginTime.ToString(),EndTime.ToString(),DeptID);
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport21";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			if (strSql == null) return null;
			if(this.ExecQuery(strSql)==-1)return null;
			try
			{
				while(this.Reader.Read())
				{					
					Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
					
					obj.ID=Reader[0].ToString();
					obj.Memo=Reader[1].ToString();
					Neusoft.HISFC.Models.Base.Department dept=this.GetDeptmentById(obj.ID);
					if(dept==null)
						obj.Name=obj.ID+"(未知)";
					else
						obj.Name=dept.Name;
					//将当前行数据加载
					al.Add(obj);
				}
			}
			catch(Exception ex)
			{
				this.Err = "Operator.OpsReport.GetReport21";
				this.ErrCode = ex.Message;
				this.WriteErr();
				return null;            
			}
			this.Reader.Close();
			return al;
		}
		/// <summary>
		/// 手术信息一览表
		/// </summary>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <returns></returns>
        public DataSet GetPersonOperation(string DeptID, DateTime Begin, DateTime End)
		{
			//手术信息一览表
			System.Data.DataSet  ds = new DataSet();
			try
			{
				string strSql = string.Empty;
				if(this.Sql.GetSql("Operator.OpsReport.GetPersonOperation",ref strSql) ==-1)
				{
					this.Err = this.Sql.Err;
					return null;
				}
				else
				{
					strSql = string.Format(strSql,DeptID,Begin.ToString(),End.ToString());
				}

				this.ExecQuery(strSql,ref ds);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
			return ds;
		}
		
		/// <summary>
		/// 急诊 感染 手术信息一览表
		/// </summary>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <returns></returns>
		public DataSet GetEmergencyOperation (string Begin,string End)
		{
			//手术信息一览表
			System.Data.DataSet  ds = new DataSet();
			try
			{
				string strSql = string.Empty;
                Neusoft.HISFC.Models.Base.Employee ee = (Neusoft.HISFC.Models.Base.Employee)this.Operator;
				if(this.Sql.GetSql("Operator.OpsReport.GetEmergencyOperation",ref strSql) ==-1)
				{
					this.Err = this.Sql.Err;
					return null;
				}
				else
				{
                    strSql = string.Format(strSql, Begin, End, ee.Dept.ID);
				}

				this.ExecQuery(strSql,ref ds);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
			return ds;
		}
		
		/// <summary>
		/// 按病区特诊手术查询
		/// </summary>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <returns></returns>
		public DataSet GetSpecalOperationReport (string DeptID,DateTime Begin,DateTime End)
		{
			//Neusoft.HISFC.Models.RADT.Person ps = new Neusoft.HISFC.Models.RADT.Person();
			//Neusoft.HISFC.BizLogic.Manager.Person p = new Neusoft.HISFC.BizLogic.Manager.Person();
			//ps = this.Operation as Neusoft.HISFC.Models.RADT.Person; 
//			if(ps == null)
//			{
//				this.Err = "查询人员信息出错";
//				return null;
//			}
			//手术信息一览表
			System.Data.DataSet  ds = new DataSet();
			try
			{
				string strSql = string.Empty;
				if(this.Sql.GetSql("Operator.OpsReport.GetReportSpecal",ref strSql) ==-1)
				{
					this.Err = this.Sql.Err;
					return null;
				}
				else
				{
					strSql = string.Format(strSql,Begin,End,DeptID);
				}

				this.ExecQuery(strSql,ref ds);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
			return ds;
		}
		
		/// <summary>
		/// 按病区特诊手术查询
		/// </summary>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <returns></returns>
//		public DataSet GetSpecalOperationReport (DateTime Begin,DateTime End)
//		{
//			Neusoft.HISFC.Models.RADT.Person ps = new Neusoft.HISFC.Models.RADT.Person();
//			//Neusoft.HISFC.BizLogic.Manager.Person p = new Neusoft.HISFC.BizLogic.Manager.Person();
//			ps = this.Operator as Neusoft.HISFC.Models.RADT.Person; 
//			if(ps == null)
//			{
//				this.Err = "查询人员信息出错";
//				return null;
//			}
//			//手术信息一览表
//			System.Data.DataSet  ds = new DataSet();
//			try
//			{
//				string strSql = string.Empty;
//				if(this.Sql.GetSql("Operator.OpsReport.GetReportSpecal",ref strSql) ==-1)
//				{
//					this.Err = this.Sql.Err;
//					return null;
//				}
//				else
//				{
//					strSql = string.Format(strSql,Begin,End,ps.Dept.ID);
//				}
//
//				this.ExecQuery(strSql,ref ds);
//			}
//			catch(Exception ee)
//			{
//				this.Err = ee.Message;
//				return null;
//			}
//			return ds;
//		}
//		
		/// <summary>
		/// 查询某个时间段内员工排班休息情况
		/// </summary>
		/// <param name="Begin"></param>
		/// <param name="End"></param>
		/// <returns></returns>
//		public DataSet GetEmployReport (string Begin,string End,string EmployCode)
//		{
//			Neusoft.HISFC.Models.RADT.Person ps = new Neusoft.HISFC.Models.RADT.Person();
//			Neusoft.HISFC.BizLogic.Manager.Person p = new Neusoft.HISFC.BizLogic.Manager.Person();
//			ps = p.GetPersonByID(EmployCode); //
//			if(ps == null)
//			{
//				this.Err = "查询人员信息出错";
//				return null;
//			}
//			//手术信息一览表
//			System.Data.DataSet  ds = new DataSet();
//			try
//			{
//				string strSql = string.Empty;
//				if(this.Sql.GetSql("Operator.OpsReport.GetEmployReport",ref strSql) ==-1)
//				{
//					this.Err = this.Sql.Err;
//					return null;
//				}
//				else
//				{
//					strSql = string.Format(strSql,Begin,End,ps.Dept.ID,EmployCode);
//				}
//
//				this.ExecQuery(strSql,ref ds);
//			}
//			catch(Exception ee)
//			{
//				this.Err = ee.Message;
//				return null;
//			}
//			return ds;
//		}

		#endregion

        protected abstract Neusoft.HISFC.Models.Base.Department GetDeptmentById(string id);
        protected abstract Neusoft.HISFC.Models.Base.Employee GetEmployee(string id);
	}
}
