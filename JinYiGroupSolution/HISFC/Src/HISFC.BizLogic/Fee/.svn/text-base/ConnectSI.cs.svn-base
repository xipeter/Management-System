using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// ConnectSI 的摘要说明。
	/// </summary>
	public class ConnectSI
	{
		/// <summary>
		/// 构造函数，创建类的时候连接数据库
		/// </summary>
		public ConnectSI()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			conn.ConnectionString = this.GetConnectString();
			command.Connection = conn;
			command.CommandType = System.Data.CommandType.Text;
			
			try
			{
				conn.Open();
			}
			catch(SqlException ex)
			{
				this.Err = "数据库连接失败!" + ex.Message;
				this.ErrCode = "-1";
				this.WriteErr();
				throw ex;
			}
			try
			{
				trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
				command.Transaction = trans;
			}
			catch(SqlException ex)
			{
				this.Err = "数据库连接失败!" + ex.Message;
				this.ErrCode = "-1";
				this.WriteErr();
				throw ex;
			}
		}
		/// <summary>
		/// 去掉类的时候，关闭数据库
		/// </summary>
		~ConnectSI()
		{
			try
			{
				if(conn.State == System.Data.ConnectionState.Open)
				{
					conn.Dispose();
					conn.Close();
				}
			}
			catch(Exception ex)
			{
				this.Err = "数据库连接失败!" + ex.Message;
				this.ErrCode = "-1";
				this.WriteErr();
			}
		}

		SqlConnection conn = new SqlConnection();
		SqlCommand command = new SqlCommand();
		System.Data.SqlClient.SqlTransaction trans;
		private string profileName  = System.Windows.Forms.Application.StartupPath + @".\profile\SiDataBase.xml";//医保数据库连接设置;

        Neusoft.FrameWork.Models.NeuLog log = new Neusoft.FrameWork.Models.NeuLog();
		/// <summary>
		/// 错误信息
		/// </summary>
		public string Err;
		/// <summary>
		/// 错误编码
		/// </summary>
		public string ErrCode;
		private System.Data.SqlClient.SqlDataReader Reader;
		#region 数据库基本操作
		/// <summary>
		/// 提交
		/// </summary>
		public void Commit()
		{
			trans.Commit();
		}
		/// <summary>
		/// 回滚
		/// </summary>
		public void RollBack()
		{
			trans.Rollback();
		}
		/// <summary>
		/// 关闭数据库连接
		/// </summary>
		public void Close()
		{
			if(conn.State == System.Data.ConnectionState.Open)
			{
				conn.Dispose();
				conn.Close();
			}
		}
		/// <summary>
		/// 打开数据库连接
		/// </summary>
		public void Open()
		{
			conn.ConnectionString = this.GetConnectString();
			command.Connection = conn;
			command.CommandType = System.Data.CommandType.Text;
			
			try
			{
				conn.Open();
			}
			catch(SqlException ex)
			{
				this.Err = "数据库连接失败!" + ex.Message;
				this.ErrCode = "-1";
				this.WriteErr();
				throw ex;
			}
			try
			{
				trans = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
				command.Transaction = trans;
			}
			catch(SqlException ex)
			{
				this.Err = "数据库连接失败!" + ex.Message;
				this.ErrCode = "-1";
				this.WriteErr();
				throw ex;
			}
		}

		/// <summary>
		/// 写入错误信息
		/// </summary>
		private void WriteErr()
		{
			this.log.WriteLog("Error:" +this.GetType().ToString()+":"+this.Err+this.ErrCode);
		}
		/// <summary>
		/// 获得连接串
		/// </summary>
		/// <returns></returns>
		public string GetConnectString()
		{
			string dbInstance =  "";
			string DataBaseName = "";
			string userName = "";
			string password = "";
			string connString = "";
			
			if(!System.IO.File.Exists(profileName))
			{
				Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
				XmlDocument doc = new XmlDocument();
				XmlElement root;
				root = myXml.CreateRootElement(doc,"SqlServerConnectForHis4.0","1.0");
				
				XmlElement dbName = myXml.AddXmlNode(doc, root, "设置", "");

				myXml.AddNodeAttibute(dbName, "数据库实例名", "");
				myXml.AddNodeAttibute(dbName, "数据库名", "");
				myXml.AddNodeAttibute(dbName, "用户名", "");
				myXml.AddNodeAttibute(dbName, "密码", "");

				try
				{
					StreamWriter sr = new StreamWriter(profileName, false,System.Text.Encoding.Default);
					string cleandown = doc.OuterXml;
					sr.Write(cleandown);
					sr.Close();
				}
				catch(Exception ex)
				{
					this.Err = "创建医保连接服务配置出错!" + ex.Message;
					this.ErrCode = "-1";
					this.WriteErr();
					return "";
				}
				
				return "";
			}
			else
			{
				XmlDocument doc = new XmlDocument();
		
				try
				{
					StreamReader sr = new StreamReader(profileName ,System.Text.Encoding.Default);
					string cleandown = sr.ReadToEnd();
					doc.LoadXml(cleandown);
					sr.Close();
				}
				catch{return "";}
				
				XmlNode node = doc.SelectSingleNode("//设置");

				try
				{
				
					dbInstance = node.Attributes["数据库实例名"].Value.ToString();
					DataBaseName = node.Attributes["数据库名"].Value.ToString();
					userName = node.Attributes["用户名"].Value.ToString();
					password = node.Attributes["密码"].Value.ToString();
				}
				catch{return "";}

				connString = "packet size=4096;user id=" + userName + ";data source=" + dbInstance +";pers" +
					"ist security info=True;initial catalog=" + DataBaseName  + ";password=" + password;
			}
			
			return connString;
		}
		/// <summary>
		/// 执行更新,删除,插入等SQL语句
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private int ExecNoQuery(string sql)
		{
			command.CommandText = sql;

			try
			{
				return command.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				this.Err = "读取数据库失败!" + ex.Message + "|" + sql;
				this.ErrCode = "-1";
				this.WriteErr();
				return -1;
			}
		}
		/// <summary>
		/// 执行查询语句
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		private int ExecQuery(string sql)
		{
			if(conn.ConnectionString == "")
				return -1;
			
			command.CommandText = sql;

			try
			{
				Reader = command.ExecuteReader();
			}
			catch(Exception ex)
			{
				this.Err = "读取数据库失败!" + ex.Message + "|" + sql;
				this.ErrCode = "-1";
				this.WriteErr();
				return -1;
			}

			//conn.Close();

			return 0;
		}
		#endregion

		#region 登记
		/// <summary>
		/// 通过就诊号,获得患者基本信息
		/// </summary>
		/// <param name="regNo">就诊医疗号</param>
		/// <returns>null 没有找到或者数据库出错 obj 患者登记信息实体</returns>
		public Neusoft.HISFC.Models.RADT.PatientInfo GetRegPersonInfo(string regNo)
		{
			string sql = "select * from his_zydj where jydjh = '" + regNo + "'";
			
			if(this.ExecQuery(sql) == -1)
				return null;

			Neusoft.HISFC.Models.RADT.PatientInfo obj = new Neusoft.HISFC.Models.RADT.PatientInfo();
			try
			{
				while(Reader.Read())
				{
					
					obj.SIMainInfo.RegNo = Reader[0].ToString();
					obj.SIMainInfo.HosNo = Reader[1].ToString();
					obj.SIMainInfo.ID = Reader[0].ToString();
					obj.IDCard = Reader[2].ToString();
					obj.Name = Reader[3].ToString();
					obj.Name = Reader[3].ToString();
					obj.CompanyName = Reader[4].ToString();
					obj.Sex.ID = Reader[5].ToString();
					obj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[6].ToString());
					obj.SIMainInfo.EmplType = Reader[7].ToString();
					obj.SIMainInfo.User01 = Reader[8].ToString();
					obj.PID.PatientNO = Reader[9].ToString();
					obj.PVisit.MedicalType.ID = Reader[10].ToString();
					obj.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[11].ToString());
					obj.SIMainInfo.InDiagnose.Name = Reader[12].ToString();
					obj.SIMainInfo.InDiagnose.ID = Reader[13].ToString();
					obj.PVisit.PatientLocation.Dept.ID = Reader[14].ToString();
					obj.PVisit.PatientLocation.Bed.ID = Reader[15].ToString();
					obj.SIMainInfo.AppNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[16].ToString());
					obj.User01 = Reader[17].ToString();
					obj.User02 = Reader[18].ToString();
					obj.User03 = Reader[19].ToString();
					obj.SIMainInfo.ReadFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[20].ToString());
				}

				Reader.Close();
			}
			catch(Exception ex)
			{
				this.ErrCode = "-1";
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}
			
			return obj;
		}
		/// <summary>
		/// 获得某天的医保登记患者信息
		/// </summary>
		/// <param name="regDate">登记日期</param>
		/// <returns>null错误 ArrayList 包含患者登记信息的实体数组</returns>
		public ArrayList GetRegPersonInfo(DateTime regDate)
		{
			string sql = "select * from his_zydj where RYRQ = '" + regDate + "'";
			
			if(this.ExecQuery(sql) == -1)
				return null;

			ArrayList al = new ArrayList();
			
			
			try
			{
				while(Reader.Read())
				{
					Neusoft.HISFC.Models.RADT.PatientInfo obj = new Neusoft.HISFC.Models.RADT.PatientInfo();
					
					obj.SIMainInfo.RegNo = Reader[0].ToString();
					obj.SIMainInfo.HosNo = Reader[1].ToString();
					obj.SIMainInfo.ID = Reader[0].ToString();
					obj.IDCard = Reader[2].ToString();
					obj.Name = Reader[3].ToString();
					obj.Name = Reader[3].ToString();
					obj.CompanyName = Reader[4].ToString();
					obj.Sex.ID = Reader[5].ToString();
					obj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[6].ToString());
					obj.SIMainInfo.EmplType = Reader[7].ToString();
					obj.SIMainInfo.User01 = Reader[8].ToString();
					obj.PID.PatientNO = Reader[9].ToString();
					obj.PVisit.MedicalType.ID = Reader[10].ToString();
					obj.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[11].ToString());
					obj.SIMainInfo.InDiagnose.Name = Reader[12].ToString();
					obj.SIMainInfo.InDiagnose.ID = Reader[13].ToString();
					obj.PVisit.PatientLocation.Dept.ID = Reader[14].ToString();
					obj.PVisit.PatientLocation.Bed.ID = Reader[15].ToString();
					obj.SIMainInfo.AppNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[16].ToString());
					obj.User01 = Reader[17].ToString();
					obj.User02 = Reader[18].ToString();
					obj.User03 = Reader[19].ToString();
					obj.SIMainInfo.ReadFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[20].ToString());

					al.Add(obj);
				}

				Reader.Close();
			}
			catch(Exception ex)
			{
				this.ErrCode = "-1";
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}

			return al;
		}
		/// <summary>
		///  更新入院登记的读入标志
		/// </summary>
		/// <param name="regNo">医保患者就医流水号</param>
		/// <param name="readFlag">更新的标志 1 读入 0 未读入 2 错误</param>
		/// <param name="commit">是否直接提交?</param>
		/// <returns>-1 失败 0 成功</returns>
		public int UpdateRegReadFlag(string regNo, int readFlag, bool commit)
		{
			string sql = "update his_zydj set DRBZ = " + readFlag.ToString() + " where jydjh = '" + regNo + "'";

			int tempRows = 0;

			tempRows = this.ExecNoQuery(sql);
			
			if(tempRows <= 0)
			{
				if(commit)
				{
					trans.Rollback();
				}
				return -1;
			}
			
			try
			{
				if(commit)
				{
					trans.Commit();
				}

				return tempRows;
			}
			catch(Exception ex)
			{
				this.ErrCode = "-1";
				this.Err = ex.Message;
				this.WriteErr();
				//trans.Rollback();
				return -1;
			}
			
		}
		#endregion

		#region 医嘱明细操作

		/// <summary>
		/// 删除共享区上传的明细(结算召回用)
		/// </summary>
		/// <param name="regNo">就医登记号</param>
		/// <returns></returns>
		public int DeleteItemList(string regNo)
		{
			string strSql = "delete from his_cfxm where JYDJH = " + "'" + regNo + "'";
	
			return this.ExecNoQuery(strSql);
		}


		/// <summary>
		/// 插入单条医嘱明细
		/// </summary>
		/// <param name="pInfo">住院患者基本信息,包括医保基本信息</param>
		/// <param name="obj">费用明细信息</param>
		/// <returns></returns>
		public int InsertItemList(Neusoft.HISFC.Models.RADT.PatientInfo pInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj)
		{
			string sqlMaxNo = "select isnull(max(XMXH), 0) from his_cfxm where JYDJH = " + "'" + pInfo.SIMainInfo.RegNo + "'";
			int i = 1;

			if(this.ExecQuery(sqlMaxNo) == -1)
				return -1;

			while(Reader.Read())
			{
				i = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());
			}

			Reader.Close();

			i++;
			
			//if(obj.Item.IsPharmacy)
            if(obj.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
			{
				#region delete by maokb
//				try
//				{
//                    //将药品编码转换成自定义码
//					Neusoft.HISFC.Models.Pharmacy.Item drugItem = new Neusoft.HISFC.Models.Pharmacy.Item();
//					Neusoft.HISFC.Management.Pharmacy.Item iMgr = new Neusoft.HISFC.Management.Pharmacy.Item();
//					obj.Item = (Neusoft.HISFC.Models.Pharmacy.Item)obj.Item;
//					drugItem = iMgr.GetItem(obj.Item.ID);
//					obj.Item.ID = drugItem.UserCode;	
//				}
//				catch
//				{
//					this.Err = "获取药品自定义码出错！";
//					return -1;
//				}
//			}
//			else
//			{
//				try
//				{
//					//将非药品编码转换成自定义码
//					Neusoft.HISFC.Models.Fee.Item.Undrug item = new Neusoft.HISFC.Models.Fee.Item.Undrug();
//					Neusoft.HISFC.BizLogic.Fee.Item.Undrug itemMgr= new Neusoft.HISFC.BizLogic.Fee.Item.Undrug();
//					item = itemMgr.GetItem(obj.Item.ID);
//					obj.Item.ID = item.UserCode;
//				}
//				catch
//				{
//					this.Err = "获取非药品自定义码出错！";
//					return -1;
//				}
				#endregion
				obj.Item = (Neusoft.HISFC.Models.Pharmacy.Item)obj.Item;
			}
			
			//数据合法性判断主要针对数字型

			string sql = "insert into his_cfxm values('" + pInfo.SIMainInfo.RegNo + "','" +
														  pInfo.SIMainInfo.HosNo + "','" +
														  pInfo.IDCard + "','" + 
				                                          pInfo.PID.PatientNO + "','" +
				                                          pInfo.PVisit.InTime.ToString() + "','" + 
				                                          obj.FeeOper.OperTime.ToString() + "'," +
														  i.ToString() + ",'" + 
														  obj.Item.ID + "','" +
														  obj.Item.Name + "'," +
													      "0" + ",'" + 
													      obj.Item.Specs + "','" + 
													      "" + "'," +
													      (obj.Item.Price * obj.FTRate.OwnRate).ToString() + "," +
													      obj.Item.Qty.ToString() + "," +
													      obj.FT.TotCost.ToString() + ",'" +
													      "" + "','" + "" + "','" + "" + "'," + "0" + ",'" + "" + "')";
			if(this.ExecNoQuery(sql) == -1)
				return -1;

			return 0;	                                          
		}
		/// <summary>
		/// 循环插入医嘱明细
		/// </summary>
		/// <param name="pInfo">患者基本信息,包括医保信息</param>
		/// <param name="itemList">患者费用明细实体数组</param>
		/// <returns></returns>
		public int InsertItemList(Neusoft.HISFC.Models.RADT.PatientInfo pInfo, ArrayList itemList)
		{
			foreach(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj in itemList)
			{
				if(this.InsertItemList(pInfo, obj) == -1)
					return -1;
			}
			return 0;
		}
		/// <summary>
		///  根据读入标志 查询已传递的项目列表
		/// </summary>
		/// <param name="regNo">患者就医登记号</param>
		/// <param name="flag">0 未读入 1 读入 2 错误</param>
		/// <returns>Fee.Inpatient.FeeItemList实体集合</returns>
		public ArrayList GetUnValidItemList(string regNo, int flag)
		{
			string sql = "select * from his_cfxm where JYDJH = '" + regNo + "' and DRBZ = " + flag.ToString();

			if(this.ExecQuery(sql) == -1)
				return null;

			while(Reader.Read())
			{
				Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();


			}
			Reader.Close();
			
			return null;
		}

		#endregion

		#region 结算信息
		/// <summary>
		/// 得到医保患者的结算信息
		/// 医保结算的总金额 pInfo.SIMainInfo.TotCost
		/// 医保结算的帐户金额 pInfo.SIMainInfo.PayCost
		/// 医保结算的统筹金额 pInfo.SIMainInfo.PubCost
		/// 医保结算的自费金额 pInfo.SIMainInfo.OwnCost
		/// 其中 totcost = payCost + pubCost + ownCost;
		/// </summary>
		/// <param name="pInfo">患者基本信息,包括医保患者结算表的基本信息</param>
		/// <returns> -1 失败 0 没有结算信息 1 成功获取</returns>
		public int GetBalanceInfo(Neusoft.HISFC.Models.RADT.PatientInfo pInfo)
		{
			string sql = "select * from HIS_FYJS where JYDJH = '" + pInfo.SIMainInfo.RegNo + "'";

			if(this.ExecQuery(sql) == -1)
			{
				this.ErrCode = "-1";
				this.Err = "查询医保患者结算信息失败!";
				return -1;
			}

			if(!Reader.HasRows)
			{
				
				this.ErrCode = "-1";
				this.Err = "没有患者结算信息";
				return 0;
			}

			while(Reader.Read())
			{
				pInfo.SIMainInfo.RegNo = Reader[0].ToString();
				pInfo.SIMainInfo.FeeTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1].ToString());
				pInfo.SIMainInfo.BalanceDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(Reader[6].ToString());
				pInfo.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[7].ToString());
				pInfo.SIMainInfo.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8].ToString());
				pInfo.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[9].ToString());
				pInfo.SIMainInfo.ItemYLCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[10].ToString());
				pInfo.SIMainInfo.BaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[11].ToString());
				pInfo.SIMainInfo.ItemPayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[12].ToString());
				pInfo.SIMainInfo.PubOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[13].ToString());
				pInfo.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[14].ToString());
				pInfo.SIMainInfo.OverTakeOwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[15].ToString());
				pInfo.SIMainInfo.Memo = Reader[16].ToString();
				pInfo.SIMainInfo.HosCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[17].ToString());
				pInfo.SIMainInfo.User01 = Reader[18].ToString();
				pInfo.SIMainInfo.User02 = Reader[19].ToString();
				pInfo.SIMainInfo.User03 = Reader[20].ToString();
				pInfo.SIMainInfo.ReadFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[21].ToString());
			}

			Reader.Close();

			return 1;
		}
		/// <summary>
		/// 更新结算信息的读入标志
		/// </summary>
		/// <param name="regNo">患者就医登记号</param>
		/// <param name="readFlag"> 0 未读入 1 已读入 2 作废</param>
		/// <returns></returns>
		public int UpdateBalaceReadFlag(string regNo, int readFlag)
		{
			string sql = "update HIS_FYJS set DRBZ = " + readFlag.ToString() + " WHERE JYDJH = '" + regNo + "'";

			if(this.ExecNoQuery(sql) <= 0)
			{
				this.Err = "更新失败!";
				return -1;
			}

			return 0;
		}

		#endregion

		#region 对照信息
		/// <summary>
		/// 获得医保药品项目列表
		/// </summary>
		/// <returns></returns>
		public ArrayList GetSIDrugList()
		{
			string sql = "select MEDI_CODE,MEDI_ITEM_TYPE,MEDI_NAME,MODEL,CODE_PY,STAT_TYPE,MT_FLAG,STAPLE_FLAG,isnull(SELF_SCALE,0) "
						 + "from view_medi" +
                         " where VALID_FLAG = '1'";

			if(this.ExecQuery(sql) == -1)
			{
				this.ErrCode = "-1";
				this.Err = "查询医保药品目录失败!";
				return null;
			}

			if(!Reader.HasRows)
			{
				
				this.ErrCode = "-1";
				this.Err = "没有药品信息";
				return null;
			}

			ArrayList al = new ArrayList();

			Neusoft.HISFC.Models.SIInterface.Item item = null;

			string sysClass = "";
			try
			{
				while(Reader.Read())
				{
					item = new Neusoft.HISFC.Models.SIInterface.Item();

					item.ID = Reader[0].ToString();
					if(Reader[1].ToString() == "1")
					{
						sysClass = "X";
					}
					else
					{
						sysClass = "Z";
					}
					item.SysClass = sysClass;
					item.Name = Reader[2].ToString();
					item.DoseCode = Reader[3].ToString();
					item.SpellCode = (Reader[4].ToString()).Length > 9 ? (Reader[4].ToString()).Substring(0, 10): Reader[4].ToString();
					item.FeeCode = Reader[5].ToString();
					item.ItemType = Reader[6].ToString();
					item.ItemGrade = Reader[7].ToString();
					if(item.ItemGrade == "9")
					{
						item.ItemGrade = "3";
					}
					item.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8].ToString());

					al.Add(item);
				}

				Reader.Close();

				return al;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
		}
		/// <summary>
		/// 获得医保非药品项目列表
		/// </summary>
		/// <returns></returns>
		public ArrayList GetSIUndrugList()
		{
			string sql = "select item_code ," + "'F" + "'" + " as sys_class, item_name,STAT_TYPE as fee_code, " +
                         "MT_FLAG as ITEM_TYPE, SELF_SCALE from view_item";

			if(this.ExecQuery(sql) == -1)
			{
				this.ErrCode = "-1";
				this.Err = "查询医保非药品目录失败!";
				return null;
			}

			if(!Reader.HasRows)
			{
				
				this.ErrCode = "-1";
				this.Err = "没有非药品信息";
				return null;
			}

			ArrayList al = new ArrayList();

			Neusoft.HISFC.Models.SIInterface.Item item = null;
//			Neusoft.HISFC.Models.Base.SpellCode sp = null;
//			Neusoft.HISFC.Management.Manager.Spell spell = new Neusoft.HISFC.Management.Manager.Spell();
			try
			{
				while(Reader.Read())
				{
					item = new Neusoft.HISFC.Models.SIInterface.Item();

					item.ID = Reader[0].ToString();
					item.SysClass = Reader[1].ToString();
					item.Name = Reader[2].ToString();
//					sp = (Neusoft.HISFC.Models.Base.SpellCode)spell.Get(item.Name);
//					if(sp != null)
//					{
//						item.SpellCode = sp.SpellCode.Length > 9 ? sp.SpellCode.Substring(0,10) : sp.SpellCode;
//					}
					item.FeeCode = Reader[3].ToString();
					item.ItemType = Reader[4].ToString();
					item.Rate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[5].ToString());
					if(item.Rate == 0)
					{
						item.ItemGrade = "1";
					}
					else if(item.Rate == 1)
					{
						item.ItemGrade = "3";
					}
					else
					{
						item.ItemGrade = "2";
					}

					al.Add(item);
				}

				Reader.Close();

				return al;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
		}
		/// <summary>
		/// 由医保服务器获取医保已对照信息
		/// </summary>
		/// <returns></returns>
		public ArrayList GetSICompareList()
		{
			string sql = "select item_code,item_name,match_type,hosp_code,hosp_name from view_match order by match_type";

			if(this.ExecQuery(sql) == -1)
			{
				this.ErrCode = "-1";
				this.Err = "查询医保已对照信息失败!";
				return null;
			}

			if(!Reader.HasRows)
			{
				
				this.ErrCode = "-1";
				this.Err = "无已对照信息";
				return null;
			}

			ArrayList al = new ArrayList();
			Neusoft.FrameWork.Models.NeuObject info;
			try
			{
				while(Reader.Read())
				{
					info = new Neusoft.FrameWork.Models.NeuObject();
					info.ID = this.Reader[0].ToString();
					info.Name = this.Reader[1].ToString();
					info.Memo = this.Reader[2].ToString();
					info.User01 = this.Reader[3].ToString();
					info.User02 = this.Reader[4].ToString();
					al.Add(info);
				}

				Reader.Close();

				return al;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				return null;
			}
		}
		/// <summary>
		/// 获得非药品行数，判断是否需要更新用
		/// </summary>
		/// <returns></returns>
		public int GetSIUndrugCounts()
		{
			string sql = "select count(*) from view_item where VALID_FLAG = '1'";

			if(this.ExecQuery(sql) == -1)
			{
				this.ErrCode = "-1";
				this.Err = "查询医保非药品目录失败!";
				return -1;
			}

			if(!Reader.HasRows)
			{
				
				this.ErrCode = "-1";
				this.Err = "没有非药品信息";
				return -1;
			}

			int count = 0;
			try
			{
				while(Reader.Read())
				{
					count = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());
				}

				Reader.Close();

				return count;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				return -1;
			}
		}
		/// <summary>
		/// 获得药品行数，判断是否需要更新用
		/// </summary>
		/// <returns></returns>
		public int GetSIDrugCounts()
		{
			string sql = "select count(*) from view_medi where VALID_FLAG = '1'";

			if(this.ExecQuery(sql) == -1)
			{
				this.ErrCode = "-1";
				this.Err = "查询医保药品目录失败!";
				return -1;
			}

			if(!Reader.HasRows)
			{
				
				this.ErrCode = "-1";
				this.Err = "没有药品信息";
				return -1;
			}

			int count = 0;
			try
			{
				while(Reader.Read())
				{
					count = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());
				}

				Reader.Close();

				return count;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				if(!Reader.IsClosed)
				{
					Reader.Close();
				}
				return -1;
			}
		}

		#endregion
	}
}
