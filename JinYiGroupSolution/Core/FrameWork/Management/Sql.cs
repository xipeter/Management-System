using System;
using System.Collections;
using System.Xml;
namespace Neusoft.FrameWork.Management
{
    /// <summary>
    /// Sql<br></br>
    /// [功能描述: Sql类,加载sql设置xml,进行sql语句的替换]<br></br>
    /// [创 建 者: 李云凡]<br></br>
    /// [创建时间: 2006-08-28]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    
    public class Sql:Neusoft.FrameWork.Management.Database
	{
	
		public Sql()
		{
          
		}

        //构造函数重载
		public Sql(string FileName)
		{
			this.LoadSql(FileName);
		}
		public Sql(System.Data.IDbConnection con)
		{
			this.con=con;

            this.GetSQLTable();

            this.LoadSql(this.con);
        }

        #region 变量
        public string FileName;
        public ArrayList alSql = new ArrayList();
        protected int mode = 0;//默认是sql.xml连接
        public ArrayList table_name = new ArrayList();
     
        #endregion

        /// <summary>
		/// 连接数据库
		/// </summary>
		/// <param name="con"></param>
		public int LoadSql(System.Data.IDbConnection con)
		{
			mode=1;//数据库连接
			this.con=con;
            if (this.LoadSql() < 0)
            {
                alSql = null;
                table_name = null;
                return -1;
            }
			return 0;

		}
		
		/// <summary>
		/// 加载sql文件
		/// </summary>
		/// <returns>0 成功 -1 失败</returns>
		public int LoadSql()
        {
            #region 加载SQL
            switch (mode)
			{
				case 0:
				System.Xml.XmlDataDocument doc=new System.Xml.XmlDataDocument();
					try
					{
						doc.Load(FileName);
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.ErrCode="-1";
						this.WriteErr();
						return -1;
					}
					XmlNodeList nodes;
					nodes=doc.SelectNodes(@"//SQL");
					try
					{
						foreach(XmlNode node in nodes)
						{
							Neusoft.FrameWork.Models.NeuObject objValue=new Neusoft.FrameWork.Models.NeuObject();
							objValue.ID=node.Attributes[0].Value.ToString();
							objValue.Name=node.InnerText.ToString();
							objValue.Name=objValue.Name.Replace("\r"," ");
							//objValue.Name=objValue.Name.Replace("\n"," ");
							objValue.Name=objValue.Name.Replace("\t"," ");
							try
							{
								objValue.Memo=node.Attributes[1].Value.ToString();
							}
							catch{}
							this.alSql.Add(objValue);
						}
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.ErrCode="-1";
						this.WriteErr();
						return -1;
					}
					break;
				default:
                    for (int i = 0; i < table_name.Count; i++)
                    {
                        Neusoft.FrameWork.Models.NeuObject obj = table_name[i] as Neusoft.FrameWork.Models.NeuObject;
                        if (obj.ID == "1")//开始时候加载
                        {
                            //因为要增加对不同数据库的支持,不同数据库里的SQL语句存储的字段不同, 所以才这样
                            //{476364C9-195A-4ca8-A2D7-6782088016FA}
                            string mySQL = string.Empty;
                            if (Neusoft.FrameWork.Management.Connection.DBType== Connection.EnumDBType.ORACLE)
                            {
                                mySQL = string.Format("select id,name,memo from {0}", table_name[i].ToString());
                            }
                            else if (Neusoft.FrameWork.Management.Connection.DBType == Connection.EnumDBType.DB2)
                            {
                                mySQL = string.Format("select id,db2_sql,memo from {0}", table_name[i].ToString());
                            }
                           
                            else//以后再用
                            {
                                mySQL = string.Format("select id,name,memo from {0}", table_name[i].ToString());
                            }
                            //end ;
                            if (this.ExecQuery(mySQL) == -1) return -1;//表有问题
                            while (this.Reader.Read())
                            {
                                Neusoft.FrameWork.Models.NeuObject objValue = new Neusoft.FrameWork.Models.NeuObject();
                                objValue.ID = this.Reader[0].ToString();
                                objValue.Name = this.Reader[1].ToString();
                                objValue.Name = objValue.Name.Replace("\r", " ");
                                //objValue.Name=objValue.Name.Replace("\n"," ");
                                objValue.Name = objValue.Name.Replace("\t", " ");
                                try
                                {
                                    objValue.Memo = this.Reader[2].ToString();
                                }
                                catch { }
                                this.alSql.Add(objValue);
                            }
                            this.Reader.Close();
                        }
                    }
					break;
            }
            #endregion
            return 0;
		}
		/// <summary>
		/// 加载sql文件
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public int LoadSql(string FileName)
		{
			this.FileName=FileName;
			LoadSql();
			return 0;
		}
		/// <summary>
		/// 获得sql语句
		/// </summary>
		/// <param name="index"></param>
		/// <param name="Sql"></param>
		/// <returns></returns>
		public int GetSql(string index,ref string Sql)
		{
			for(int i=0;i<this.alSql.Count;i++)
			{
				if(((Neusoft.FrameWork.Models.NeuObject)this.alSql[i]).ID.Trim()==index.Trim())
				{
					Sql=((Neusoft.FrameWork.Models.NeuObject)this.alSql[i]).Name;
					this.Err="获得Sql语句，索引为："+index+"\n Sql为："+Sql;
					this.WriteDebug(this.Err);
					return 0;
				}
			}
            for (int i = 0; i < table_name.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = table_name[i] as Neusoft.FrameWork.Models.NeuObject;
                if (obj.ID == "0")//开始时候加载
                {
                    //因为要增加对不同数据库的支持,不同数据库里的SQL语句存储的字段不同, 所以才这样
                    //{844EC201-D874-4d1e-B2B3-DBC61DA21599}
                    //string mySQL = string.Format("select id,name,memo from {0} where id='{1}'", table_name[i].ToString(), index);//原来的程序
                    string mySQL = string.Empty;
                    if (Neusoft.FrameWork.Management.Connection.DBType == Connection.EnumDBType.ORACLE)
                    {
                        mySQL = string.Format("select id,name,memo from {0} where id='{1}'", table_name[i].ToString(), index);
                    }
                    else if (Neusoft.FrameWork.Management.Connection.DBType == Connection.EnumDBType.DB2)
                    {
                        mySQL = string.Format("select id,db2_sql,memo from {0} where id='{1}'", table_name[i].ToString(), index);
                    }
                    else//以后再用
                    {
                        mySQL = string.Format("select id,name,memo from {0} where id='{1}'", table_name[i].ToString(), index);
                    }
                    //end ;

                    if (this.ExecQuery(mySQL) == -1) return -1;//表有问题
                    if (this.Reader.Read())
                    {
                        Neusoft.FrameWork.Models.NeuObject objValue = new Neusoft.FrameWork.Models.NeuObject();
                        objValue.ID = this.Reader[0].ToString();
                        objValue.Name = this.Reader[1].ToString();
                        objValue.Name = objValue.Name.Replace("\r", " ");
                        //objValue.Name=objValue.Name.Replace("\n"," ");
                        objValue.Name = objValue.Name.Replace("\t", " ");
                        try
                        {
                            objValue.Memo = this.Reader[2].ToString();
                        }
                        catch { }

                        this.alSql.Add(objValue);
                        Sql = objValue.Name;
                        this.Err = "获得Sql语句，索引为：" + index + "\n Sql为：" + Sql;
                        this.WriteDebug(this.Err);
                        this.Reader.Close();
                        return 0;
                    }
                    
                    this.Reader.Close();
                    
                }
            }
			this.Err="没找到Sql语句！"+index;
            this.WriteErr();
			return -1;
		}

        /// <summary>
        /// 根据组添加SQL语句
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        private int GetSQLTable()
        {
            string strSql = "select sqlTableName,isBeginLoad from com_sql_setting "; //取加载的SQL语句

            if (this.ExecQuery(strSql) == -1)
            {
                //没有这个表，拉拉拉拉，只取COM_SQL
                table_name.Add(new Neusoft.FrameWork.Models.NeuObject("1", "COM_SQL", ""));
                return -1;
            }
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    obj.ID = this.Reader[1].ToString();
                    obj.Name = this.Reader[0].ToString();
                    table_name.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
            }
            this.Reader.Close();

            return 0;
        }

	}
}
