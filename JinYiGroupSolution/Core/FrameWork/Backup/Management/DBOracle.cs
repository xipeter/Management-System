using System;
using System.Data.OracleClient;
using System.Xml;//使用Xml类进行xmlDataSet的输出
using System.Data;
namespace Neusoft.FrameWork.Management 
{
	/// <summary>
	/// Database 数据库管理类 
	/// con 需要传入
	/// sql 需要传入
	/// operator 需要传入
	/// wolf 2004-6
	/// </summary>
    [Serializable]
	public class DBOracle:Neusoft.FrameWork.Models.NeuManageObject,IDataBase
	{
		protected Neusoft.FrameWork.Models.NeuLog Logo;
		protected Neusoft.FrameWork.Models.NeuLog debugLogo;
		protected string ErrorException ="";
		private bool bDebug;
		protected string DebugSqlIndex = "Manager.Logo.GetDebug";
		protected string ErrorSqlIndex = "Manager.Logo.GetError";
		protected string DebugSql= "";
		protected string ErrorSql = "";
		protected System.Data.OracleClient.OracleDataReader TempReader1;
		protected System.Data.OracleClient.OracleDataReader  TempReader2;
		protected System.Data.OracleClient.OracleDataReader  reader;
		//protected System.Data.OracleClient.OracleCommand tempCommand = new OracleCommand();
		/// <summary>
		/// DataReader 数据读取指针
		/// </summary>
		public System.Data.IDataReader  Reader
		{
			get
			{
				return (System.Data.IDataReader)reader;
			}
			
		}
		/// <summary>
		/// 
		/// </summary>
		public System.Data.IDataReader  TempReader
		{
			get
			{
				return (System.Data.IDataReader)TempReader1;
			}
			
		}

		public DBOracle(){
//			this.con = Neusoft.NFC.Management.Connection.Instance;
//			this.Sql = Neusoft.NFC.Management.Connection.Sql;
//			this.Operator = Neusoft.NFC.Management.Connection.Operator;
			newDatabase("./err.log");
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="errLogoFileName">日志文件名</param>
		public DBOracle(string errLogoFileName) 
		{
			newDatabase(errLogoFileName);
		}
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose(bool isDisposing)
		{
			base.Dispose (isDisposing);
            try
            {
                this.command.Dispose();
                this.Reader.Dispose();
            }
            catch { }
		}

		/// <summary>
		/// 加载内存 判断是否debug 非公开
		/// </summary>
		/// <param name="errLogoFileName">errLogoFileName</param>
		private void newDatabase(string errLogoFileName) 
		{
			if(this.con ==null) 
			{
				con = new OracleConnection();
			}
            command = con.CreateCommand() as OracleCommand;
            //this.command.Connection =con as OracleConnection;
            command.Transaction = (OracleTransaction)Neusoft.FrameWork.Management.PublicTrans.Trans;

			Logo=new Neusoft.FrameWork.Models.NeuLog(errLogoFileName);
			string debugLogoFileName="./debugSql.log";
			if(System.IO.File.Exists(debugLogoFileName)) 
			{
				debugLogo=new Neusoft.FrameWork.Models.NeuLog(debugLogoFileName);
				bDebug=true;
			}
			else 
			{
				bDebug=false;
			}
			
		

		}
		private Sql sql;
		/// <summary>
		/// 转换sql语句
		/// 通过引用全局的sql语句类进行访问
		/// </summary>
		public Sql Sql
		{
			get
			{
				return sql;
			}
			set
			{
				sql = value;
			}
		}
		/// <summary>
		/// 设置sql
		/// </summary>
		/// <param name="sql"></param>
		public void SetSql(Sql sql) 
		{
			this.Sql=sql;
		}

		/// <summary>
		/// 设置事务
		/// </summary>
		/// <param name="Trans">设置command事务</param>
		public void SetTrans(IDbTransaction Trans) 
		{
			try 
			{
				this.command.Transaction = (System.Data.OracleClient.OracleTransaction)Trans;
			}
			catch(Exception ex) 
			{
				this.Err="传递事务出错！" +ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.ErrCode="-1";
				this.WriteErr();
			}
		}
		
		/// <summary>
		/// 写错误日志
		/// </summary>
        public virtual void WriteErr() 
		{
            this.Logo.WriteLog(this.GetType().ToString() + ":" + this.Err +":"+this.ErrCode);
			
			if(bDebug) 
			{
				this.debugLogo.WriteLog("Error:" +this.GetType().ToString()+":"+this.Err+this.ErrCode);
				
			}
		}
		/// <summary>
		/// 写调试日志
		/// </summary>
		/// <param name="strDebugInfo"></param>
		public virtual void WriteDebug(string strDebugInfo) 
		{
			if(bDebug) 
			{
				this.debugLogo.WriteLog("Debug:" +this.GetType().ToString()+":"+strDebugInfo);			
				
			}
			
		}


		#region 数据库操作
		/// <summary>
		/// 连接 私有
		/// </summary>
		protected System.Data.OracleClient.OracleConnection con1;
		/// <summary>
		/// 命令 私有
		/// </summary>
		protected System.Data.OracleClient.OracleCommand command;
		/// <summary>
		/// 日志 私有
		/// </summary>
		/// <summary>
		/// 设置/读取连接
		/// </summary>
		public OracleConnection Connection 
		{
			get 
			{
				return con as OracleConnection;
			}
			set 
			{
				con=value;
                if (con != null)
                {
                    command = con.CreateCommand() as OracleCommand;
                }
			}
		}
		/// <summary>
		///  设置连接 
		/// </summary>
		/// <param name="strConnectString">连接的字符串</param>
		/// <returns>0 success -1 fail</returns>
		public int Connect(string strConnectString) 
		{
			try 
			{
				//显示进度
				this.ProgressBarValue=50;
				this.ProgressBarText="正在连接数据库...";

				con=new OracleConnection(strConnectString);
				con.Open();

				Neusoft.FrameWork.Management.Connection.Instance = con as OracleConnection;//传给全局连接
				
				WriteDebug("连接数据库！" +strConnectString);
				this.ProgressBarValue=0;
				return 0;
			}
			catch(Exception ex) 
			{
				this.ProgressBarValue=0;
				this.Err="连接数据库产生错误！"+ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.ErrCode="-1";
				this.WriteErr();
				return -1;
			}
		}

		/// <summary>
		/// 执行非查询语句
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <returns>执行sql语句影响的行数 0执行到零行,-1没有执行有错误，对于update,insert,del外都为-1。>0成功的行数</returns>
		public int ExecNoQuery(string strSql) 
		{
			//this.command=new OracleCommand();
        a:
            this.command.Connection = this.con as OracleConnection;
            if(this.command.Transaction == null) //没有事务，用全局事务
                this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			this.command.CommandType=System.Data.CommandType.Text;
			this.command.Parameters.Clear();
			
			this.command.CommandText =strSql + "";
			int i=0;
			try 
			{
				i=this.command.ExecuteNonQuery();
			}
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
                //if(ex.Code == 3113) 
                if (ex.Code == 12571 || ex.Code == 3113 || ex.Code == 3114) 
				{
					while(this.Connect(this.con.ConnectionString)==-1) 
					{
					}
					goto a;
				}
				return -1;
			}
			if(i==0) 
			{
				this.Err="没找到相应的行数！";
				this.ErrCode =strSql;
				this.WriteErr();
			}
			WriteDebug("执行无返回sql语句！" +strSql);
			return i;
		}
		/// <summary>
		/// 执行无返回sql语句
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="parms"></param>
		/// <returns></returns>
		public int ExecNoQuery(string strSql,params string[] parms) 
		{
			string sReturn;
			if(Neusoft.FrameWork.Public.String.FormatString(strSql,out sReturn,parms)==-1)
			{
				this.Err = "参数不对./n "+strSql;
				return -1;
			}
			return this.ExecNoQuery(sReturn);
		}
		/// <summary>
		/// 执行查询语句,返回Reader
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <returns>0 success -1 fail</returns>
		public int ExecQuery(string strSql) 
		{
			//IDataReader reader = (IDataReader)this.reader;
			return this.ExecQuery(strSql,ref this.reader );
		}
		/// <summary>
		/// 执行查询语句，返回Reader
		/// </summary>
		/// <param name="strSql">原始sql语句</param>
		/// <param name="parms">需要替换的参数数组</param>
		/// <returns>返回执行状态 －1失败 0 成功 </returns>
		public int ExecQuery(string strSql,params string[] parms) 
		{
			string sReturn;
			if(Neusoft.FrameWork.Public.String.FormatString(strSql,out sReturn,parms)==-1) 
			{
				this.Err = "参数不对./n "+strSql;
				return -1;
			}
			return this.ExecQuery(sReturn);
		}
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecQueryByTempReader(string strSql)
        {
            return this.ExecQuery(strSql, ref this.TempReader1);
        }
		/// <summary>
		/// 执行查询语句,返回Reader
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <returns>0 success -1 fail</returns>
		public int ExecQuery(string strSql,ref OracleDataReader  Reader) 
		{
			//this.command=new OracleCommand();
			a:
			    this.command.Connection=this.con as OracleConnection;
            //command = con.CreateCommand() as OracleCommand;
            if (this.command.Transaction == null) //没有事务，用全局事务
                this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			this.command.CommandText =strSql + "";
			this.command.CommandType=System.Data.CommandType.Text;
			this.command.Parameters.Clear();
			try 
			{
				Reader = this.command.ExecuteReader();
			}
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
                //if(ex.Code == 3113) 
                if (ex.Code == 12571 || ex.Code == 3113 || ex.Code == 3114) 
				{
					{
					}
					goto a;
				}
				return -1;
			}
			catch(Exception ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.ErrCode=strSql;
				this.WriteErr();
			}
			WriteDebug("执行查询sql语句！" +strSql);
			return 0;
		}
		/// <summary>
		/// 执行sql语句 重载
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="strDataSet">返回DataSet xml</param>
		/// <returns></returns>
		public int ExecQuery(string strSql,ref string strDataSet) 
		{
			this.command.Connection=this.con as OracleConnection;
            if (this.command.Transaction == null) //没有事务，用全局事务
              this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			this.command.CommandType=System.Data.CommandType.Text;
			this.command.Parameters.Clear();
			this.command.CommandText =strSql + "";
			try 
			{
				this.TempReader1=this.command.ExecuteReader();
				XmlDocument doc=new XmlDocument();
				XmlNode root;
				XmlNode node,table;
				root=doc.CreateElement("DataSet");
				doc.AppendChild(root);
				while(this.TempReader1.Read()) 
				{
					table=doc.CreateElement("Table");
					for(int i=0;i<this.TempReader1.FieldCount;i++) 
					{
						node=doc.CreateElement(this.TempReader1.GetName(i).ToString());
						node.InnerText=this.TempReader1[i].ToString() +"";
						table.AppendChild(node);
					}
					root.AppendChild(table);
				}
				strDataSet=doc.OuterXml;
				TempReader1.Close();
			}	
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
				return -1;
			}
			catch(Exception ex) 
			{
				this.Err="执行语句产生错误!"+ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.ErrCode=strSql;
				this.WriteErr();
				return -1;
			}
			
			WriteDebug("执行查询sql语句！" +strSql);
			return 0;
		}
		/// <summary>
		/// 执行sql
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="strDataSet"></param>
		/// <returns></returns>
		public int ExecQuery(string strSql,ref string strDataSet,string strXSLFileName) 
		{
			this.command.Connection=this.con as OracleConnection;
            if (this.command.Transaction == null) //没有事务，用全局事务
                this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			this.command.CommandType=System.Data.CommandType.Text;
			this.command.Parameters.Clear();
			this.command.CommandText =strSql + "";
			try 
			{
				this.TempReader1=this.command.ExecuteReader();
				XmlDocument doc=new XmlDocument();
				XmlNode root;
				XmlElement node,row;
				doc.AppendChild(doc.CreateXmlDeclaration("1.0","GB2312",""));
				if(strXSLFileName!=null && strXSLFileName!="")
				{
					string PI  = "type='text/xsl' href='" + strXSLFileName + "'";
					System.Xml.XmlProcessingInstruction xmlProcessingInstruction = doc.CreateProcessingInstruction("xml-stylesheet", PI);
					doc.AppendChild(xmlProcessingInstruction);
				}
				root=doc.CreateElement("Table");
				doc.AppendChild(root);
				while(this.TempReader1.Read()) 
				{
					row=doc.CreateElement("Row");
					for(int i=0;i<this.TempReader1.FieldCount;i++) 
					{
						node=doc.CreateElement("Column");
						node.SetAttribute("Name",this.TempReader1.GetName(i).ToString());
						node.InnerText = this.TempReader1[i].ToString() +"";
						row.AppendChild(node);
					}
					root.AppendChild(row);
				}
				strDataSet=doc.OuterXml;
				TempReader1.Close();
			}	
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
				return -1;
			}
			catch(Exception ex) 
			{
				this.Err="执行语句产生错误!"+ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.ErrCode=strSql;
				this.WriteErr();
				return -1;
			}
			
			WriteDebug("执行查询sql语句！" +strSql);
			return 0;
		}
		/// <summary>
		/// 执行sql，返回DataSet
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="DataSet"></param>
		/// <returns></returns>
		public int ExecQuery(string strSql,ref DataSet DataSet) 
		{
			a:
		    this.command.Connection=this.con as OracleConnection;
            if (this.command.Transaction == null) //没有事务，用全局事务
                 this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			this.command.CommandType=System.Data.CommandType.Text;
			this.command.Parameters.Clear();
			this.command.CommandText =strSql + "";
			try 
			{
				OracleDataAdapter adapter = new OracleDataAdapter(this.command);
				adapter.Fill(DataSet);
			}	
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
                //if(ex.Code == 3113) 
                if (ex.Code == 12571 || ex.Code == 3113 || ex.Code == 3114)
                {
					while(this.Connect(this.con.ConnectionString)==-1) 
					{
					}
					goto a;
				}
				return -1;
			}
			catch(Exception ex) 
			{
				this.Err="执行语句产生错误!"+ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.ErrCode=strSql;
				this.WriteErr();
				return -1;
			}
			
			WriteDebug("执行查询sql语句！" +strSql);
			return 0;
		}


		/// <summary>
		/// 执行sql，返回DataSet
		/// writed by cuipeng 
		/// 2005-08
		/// </summary>
		/// <param name="indexes">SQL语句在xml中的索引位置</param>
		/// <param name="dataSet">返回的DataSet</param>
		/// <param name="parms">参数数组,如果没有参数则传入null</param>
		/// <returns>0成功，-1错误</returns>
		public int ExecQuery(string[] indexes, ref DataSet dataSet, params string[] parms) 
		{
			string strSql ="";  //获得SELECT语句

			if (indexes.Length == 0) 
			{
				this.Err = "无效的参数：sql索引数组indexes不能为空";
				return -1;
			}
			
			//取SELECT语句
			foreach(string index in indexes) 
			{
				string s ="";
				if (this.Sql.GetSql(index, ref s) == -1) 
				{
					this.Err="没有找到"+index+"字段!";
					return -1;
				}

				strSql = strSql + " " + s;
			}

			//根据参数parms格式化sql语句。
			try 
			{
				strSql = string.Format(strSql, parms);
			}
			catch (Exception ex) 
			{
				this.Err = ex.Message;
				return -1;
			}

			//根据sql语句，返回DataSet
			return ExecQuery(strSql, ref dataSet);
		}


		/// <summary>
		/// 执行sql，返回DataSet
		/// writed by cuipeng 
		/// 2005-08
		/// </summary>
		/// <param name="index">SQL语句在xml中的索引位置</param>
		/// <param name="dataSet">返回的dataSet</param>
		/// <param name="parms">参数数组,如果没有参数则传入null</param>
		/// <returns>0成功，-1错误</returns>
		public int ExecQuery(string index, ref DataSet dataSet, params string[] parms) 
		{
			//定义索引数组，将字符串参数做为数组的第0个
			string[] indexes = {index};
			//根据索引数组，返回DataSet
			return ExecQuery(indexes, ref dataSet, parms);
		}

		/// <summary>
		/// 执行sql语句，返回一条记录
		/// </summary>
		/// <param name="strSql">执行sql语句</param>
		/// <returns> "-1" fail</returns>
		public string ExecSqlReturnOne(string strSql) 
		{
			//IDataReader tempReader = (IDataReader)this.TempReader1;
            if (this.ExecQuery(strSql, ref this.TempReader1) == 0) 
			{
				try 
				{
					string strReturn;
					if(this.TempReader1.Read()==false) return "-1";
					strReturn=this.TempReader1[0].ToString();
					try
					{
						this.TempReader1.Close();
					}
					catch{}
					WriteDebug("执行查询sql语句！" +strSql+"返回:"+strReturn);
					return strReturn;
				}	
				catch(OracleException ex) 
				{
					this.Err="执行产生错误!"+ex.Message;
					this.ErrCode=strSql;
					this.DBErrCode = ex.Code;
					this.WriteErr();
					return "-1";
				}
				catch(Exception ex) 
				{
					this.Err="执行语句产生错误!"+ex.Message;
					this.ErrorException = ex.InnerException +"+ "+ ex.Source;
					this.ErrCode=strSql;
					this.WriteErr();
					return "-1";
				}
			
			}
			else
			{
				WriteDebug("执行查询sql语句！" +strSql+"返回:-1");
				return "-1";
			}
		}
		
		/// <summary>
		/// 执行sql语句，返回一条记录 ,如果没有记录，返回默认字符串
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="defaultstring"></param>
		/// <returns></returns>
		public string ExecSqlReturnOne(string strSql,string defaultstring) 
		{
			//IDataReader tempReader = (IDataReader)this.TempReader1;
            if (this.ExecQuery(strSql, ref this.TempReader1) == 0) 
			{
				try 
				{
					string strReturn;
					if(((System.Data.OracleClient.OracleDataReader)this.TempReader1).HasRows==false)return defaultstring;
					this.TempReader1.Read();
					strReturn=this.TempReader1[0].ToString();
					try
					{
						this.TempReader1.Close();
					}
					catch{}
					WriteDebug("执行查询sql语句！" +strSql+"返回:"+strReturn);
					return strReturn;
				}	
				catch(OracleException ex) 
				{
					this.Err="执行产生错误!"+ex.Message;
					this.ErrCode=strSql;
					this.DBErrCode = ex.Code;
					this.WriteErr();
					return "-1";
				}
				catch(Exception ex) 
				{
					this.Err="执行语句产生错误!"+ex.Message;
					this.ErrorException = ex.InnerException +"+ "+ ex.Source;
					this.ErrCode=strSql;
					this.WriteErr();
					return "-1";
				}
			}
			else 
			{
				WriteDebug("执行查询sql语句！" +strSql+"返回:-1");
				return "-1";
			}
		}

		/// <summary>
		/// 更新数据库的Blob数据类型,需指定sql参数为length=1的参数
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="ImageData"></param>
		/// <returns></returns>
		public int InputBlob(string strSql,byte[] ImageData) 
		{
		
			//			string block="INSERT INTO test_image(id,name, image) VALUES (2,'a', :blobtodb)";
			this.command.Connection=this.con as OracleConnection;
            if (this.command.Transaction == null) //没有事务，用全局事务
                 this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			command.CommandText = strSql + "";
			command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Clear();
			string strParam="";
			int i=strSql.IndexOf(":",0);
			if(i<=0) 
			{
				this.Err="未指定参数！"+strSql;
				this.WriteErr();
				return -1;
			}
			strParam=strSql.Substring(i+1,1);
			OracleParameter param = command.Parameters.Add(strParam, OracleType.Blob);
			param.Direction = System.Data.ParameterDirection.Input;

			// Assign Byte Array to Oracle Parameter
			param.Value = ImageData;
			// Step 5
			// Execute the Anonymous PL/SQL Block
			try 
			{
				command.ExecuteNonQuery();
			}	
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
				return -1;
			}
			catch(Exception ex) 
			{
				this.Err=ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.WriteErr();
				return -1;
			}
			
			return 0;
		}
		/// <summary>
		/// 输出blob
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public byte[] OutputBlob(string strSql) 
		{
			
			//string block="SELECT image  from test_image WHERE id = 100";//INTO :b
			// Set command to create Anonymous PL/SQL Block
            this.command.Connection = this.con as OracleConnection;
            if (this.command.Transaction == null) //没有事务，用全局事务
                this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			command.CommandText = strSql+"";
			command.CommandType = System.Data.CommandType.Text;
			System.Data.OracleClient.OracleDataReader reader;
            command.Parameters.Clear();
			// The anonymous PL/SQL block retrieves the images as an output parameter
			try 
			{
				//cmd.ExecuteNonQuery();
				reader=command.ExecuteReader();
			}	
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
				return null;
			}
			catch(Exception ex) 
			{
				this.Err=ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.WriteErr();
				return null;
			}
			
			reader.Read();
			// Create a byte array
			byte[] byteData = new byte[0];

			// fetch the value of Oracle parameter into the byte array
			//byteData = (byte[])(cmd.Parameters[0].Value);
			try 
			{
                byteData = (byte[])(reader[0]);
			}
			catch(Exception ex){
                this.Err = ex.Message;
                reader.Close();
                return null;
            }
			reader.Close();
			return byteData;
		}
		/// <summary>
		/// 输入长字符串
		/// 针对>4000长度的字符串
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public int InputLong(string strSql,string data) 
		{
			this.command.Connection=this.con as OracleConnection;
            if (this.command.Transaction == null) //没有事务，用全局事务
                 this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			command.CommandText = strSql + "";
			command.CommandType = System.Data.CommandType.Text;
			 this.command.Parameters.Clear();
			string strParam="";
			int i=strSql.IndexOf(":",0);
			if(i<=0) 
			{
				this.Err="未指定参数！"+strSql;
				this.WriteErr();
				return -1;
			}
			strParam=strSql.Substring(i+1,1);
           
			OracleParameter param = command.Parameters.Add(strParam, OracleType.LongVarChar);
			param.Direction = System.Data.ParameterDirection.Input;

			// Assign Byte Array to Oracle Parameter
			param.Value = data;
			// Step 5
			// Execute the Anonymous PL/SQL Block
			try 
			{
				command.ExecuteNonQuery();
			}	
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
				return -1;
			}
			catch(Exception ex) 
			{
				this.Err=ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.WriteErr();
				return -1;
			}
			
			return 0;
		
		}
		/// <summary>
		/// 执行存储过程
		/// <example>PRC_HIEBILL_CHARGE_ext,arg_checkopercode,22,1,{0},
		///		arg_exec_Sqn,22,1,{1},arg_yearcode,22,1,{2},return_code,30,2,{3},return_result,22,2,{4}</example>
		/// </summary>
		/// <param name="strSql">存储过程-参数,类型，输入输出,数值<br>22 varchar 30 double 33 int 6 DATETIME </br></param>
		/// <param name="Return">存储过程返回值 逗号分割</param>
		/// <returns>0 成功 -1 失败</returns>
		public int ExecEvent(string strSql,ref string Return) 
		{
			this.command.CommandType=System.Data.CommandType.StoredProcedure;
			this.command.Connection=this.con as OracleConnection;
            if (this.command.Transaction == null) //没有事务，用全局事务
                 this.command.Transaction = Neusoft.FrameWork.Management.PublicTrans.Trans as OracleTransaction;
			this.command.Parameters.Clear();
			string prcName="";
			string[] prcParams=strSql.Split(',');
			try 
			{
				prcName=prcParams[0];
				this.command.CommandText=prcName;
				//'22 varchar 30 double 33 int 6 DATETIME 
				for(int i=1;i<prcParams.GetUpperBound(0);i=i+4) 
				{
					OracleParameter param=new OracleParameter();
					param.ParameterName=prcParams[i].Trim();
					param.OracleType=(OracleType)int.Parse(prcParams[i+1]);
					param.Direction=(System.Data.ParameterDirection)int.Parse(prcParams[i+2]);
					if(param.Direction==System.Data.ParameterDirection.Input) 
					{
						param.Value = prcParams[i+3].Trim();
						param.Size = 50;
					}
					else if(param.OracleType==OracleType.VarChar) 
					{
						param.Size=50;
					}
					this.command.Parameters.Add(param);
				}
				this.command.ExecuteNonQuery();
			}	
			catch(OracleException ex) 
			{
				this.Err="执行产生错误!"+ex.Message;
				this.ErrCode=strSql;
				this.DBErrCode = ex.Code;
				this.WriteErr();
				return -1;
			}
			catch(Exception ex) 
			{
				this.Err="执行存储过程出错！"+strSql+ex.Message;
				this.ErrorException = ex.InnerException +"+ "+ ex.Source;
				this.WriteErr();
				return -1;
			}
			
			try 
			{
				for(int i=0;i<this.command.Parameters.Count;i++) 
				{
					if(this.command.Parameters[i].Direction==System.Data.ParameterDirection.Output) 
					{
						Return=Return+","+this.command.Parameters[i].Value;
					}
				}
				Return=Return.Substring(1);
			}
			catch(Exception ex) 
			{
				this.Err="执行存储过程出错！"+strSql+ex.Message;
				this.WriteErr();
				return -1;
			}

			return 0;
		}
		#endregion

		#region 获得时间
		/// <summary>
		/// 获得系统时间/日期
		/// </summary>
		/// <returns>DateTime from Oracle</returns>
		public string GetSysDateTime() 
		{
			return this.ExecSqlReturnOne("select sysdate from dual");
		}
		public string GetSysDateTime(string format) 
		{
			return this.ExecSqlReturnOne("select to_char(sysdate,'"+format+"') from dual");
		}
		public DateTime GetDateTimeFromSysDateTime() 
		{
			return DateTime.Parse(this.ExecSqlReturnOne("select sysdate from dual"));
		}
		/// <summary>
		/// 获得系统日期 -
		/// </summary>
		/// <returns>Date yyyy-mm-dd</returns>
		public string GetSysDate() 
		{
			DateTime t;
			t=DateTime.Parse(this.GetSysDateTime());
			return t.Year.ToString() + "-" +t.Month.ToString() +"-" +t.Day.ToString();
		}
		/// <summary>
		/// 获得系统日期 yyyy?mm?dd
		/// </summary>
		/// <returns>Date</returns>
		public string GetSysDate(string format ) 
		{
			DateTime t;
			t=DateTime.Parse(this.GetSysDateTime());
			return t.Year.ToString() + format +t.Month.ToString() +format +t.Day.ToString();
		}
		/// <summary>
		/// 获得系统日期yyymmdd
		/// </summary>
		/// <returns>Date yyyymmdd</returns>
		public string GetSysDateNoBar() 
		{
			DateTime t;
			string strYear, strMonth, strDay;
			t = DateTime.Parse(GetSysDateTime());
			strMonth = t.Month.ToString();
			strDay = t.Day.ToString();
			strYear = t.Year.ToString();
			if( strMonth.Length == 1)
				strMonth = "0" + strMonth;
			
			if( strDay.Length == 1)
				strDay = "0" + strDay;
			
			return strYear + strMonth + strDay;
		}
		#endregion

		#region 取流水号,取年龄
		/// <summary>
		/// 取流水号
		/// writed by cuipeng 
		/// 2005.2
		/// </summary>
		/// <param name="GetSqlIndex">取得SQL的索引字符串</param>
		/// <returns>错误返回null，正确返回string</returns>
		public string GetSequence(string GetSqlIndex) 
		{
			string strSQL = "";
			if (this.Sql.GetSql(GetSqlIndex,ref strSQL) == -1)  
			{
				this.Err = "SQL索引:" + GetSqlIndex + " 不存在！";
				return null;
			}
			string strReturn = this.ExecSqlReturnOne(strSQL);
			if (strReturn == "-1") 
			{
				this.Err = "取序列号"+GetSqlIndex+"时出错！" + this.Err;
				return null;
			}
			return strReturn;
		}
		
		/// <summary>
		/// 根据传入的出生日期,返回年龄
		/// </summary>
		/// <param name="birthday">出生日期</param>
		/// <returns>年龄字符串</returns>
		public string GetAge(DateTime birthday) 
		{
			//取系统时间
			DateTime sysDate = this.GetDateTimeFromSysDateTime();
			return this.GetAge(birthday, sysDate);
		}

		
		/// <summary>
		/// 根据传入的出生日期,返回年龄
		/// </summary>
		/// <param name="birthday">出生日期</param>
		/// <param name="sysDate">系统时间</param>
		/// <returns>年龄字符串</returns>
		public string GetAge(DateTime birthday, DateTime sysDate) 
		{
			try 
			{
				//取时间间隔
				TimeSpan s = new TimeSpan( sysDate.Ticks -birthday.Ticks);
				int i = 0;
				if(s.TotalDays >= 365) 
				{
					//大于等于365天,返回年
					i = (int)(s.TotalDays / 365);
					return i.ToString() + "岁";
				}
				else if(s.TotalDays >= 30) 
				{
					//小于365天且大于等于30天,返回月
					i = (int)(s.TotalDays / 30);
					return i.ToString() + "月";
				}
				else 
				{
					//小于30天,返回天
					i = (int)s.TotalDays + 1;
					return i.ToString() + "天";
				}
			}
			catch 
			{
				return "";
			}
		}
		#region IDataBase 成员

		public IDbConnection con
		{
			get
			{
				// TODO:  添加 DBOracle.Neusoft.NFC.Management.IDataBase.con getter 实现
				return this.con1;
			}
			set
			{
				// TODO:  添加 DBOracle.Neusoft.NFC.Management.IDataBase.con setter 实现
				this.con1 = value as OracleConnection;
			}
		}

		#endregion
	}
	#endregion


}
