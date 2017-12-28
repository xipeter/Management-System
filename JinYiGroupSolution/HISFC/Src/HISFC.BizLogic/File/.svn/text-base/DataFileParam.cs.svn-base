using System;
using System.Collections;
namespace  Neusoft.HISFC.BizLogic.File
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class DataFileParam:Neusoft.FrameWork.Management.Database,Neusoft.HISFC.Models.Base.IManagement
	{
		public DataFileParam()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region IManagement 成员
		/// <summary>
		/// 获得列表
		/// </summary>
		/// <returns></returns>
		public System.Collections.ArrayList GetList()
		{
			// TODO:  添加 DataFileParam.GetList 实现
			string sql="";
			if(this.Sql.GetSql("Manager.DataFileParam.GetList",ref sql)==-1) return null;
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al = new ArrayList();
            //if(this.Reader.HasRows)
			
		    try
		    {
			    while(this.Reader.Read())
			    {
				    Neusoft.HISFC.Models.File.DataFileParam datafileparam = new Neusoft.HISFC.Models.File.DataFileParam();
				    datafileparam.ID = this.Reader[0].ToString();
				    datafileparam.Name = this.Reader[1].ToString();
				    datafileparam.IsInDB = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[2].ToString());
				    datafileparam.Type = this.Reader[3].ToString();
				    datafileparam.IP = this.Reader[4].ToString();
				    datafileparam.Folders = this.Reader[5].ToString();
				    datafileparam.ModualFolders = this.Reader[6].ToString();
				    datafileparam.Http = this.Reader[7].ToString();
				    datafileparam.User01 = this.Reader[8].ToString();
				    datafileparam.User02= this.Reader[9].ToString();
				    al.Add(datafileparam);
			    }
				
		    }
		    catch
		    {
			    return null;
		    }
			
			this.Reader.Close();
			return al;
		}

		public int Del(object obj)
		{
			// TODO:  添加 DataFileParam.Del 实现
			return 0;
		}

		public int SetList(System.Collections.ArrayList al)
		{
			// TODO:  添加 DataFileParam.SetList 实现
			return 0;
		}

		public Neusoft.FrameWork.Models.NeuObject Get(object strType)
		{
			// TODO:  添加 DataFileParam.Get 实现
			//接口名称 Manager.DataFileParam.Get.1
			//<!--0 系统类别, 1 参数, 2 是否在数据库,3 数据表名,4 ip ,5 数据文件夹,6 摸板文件夹 ,7 http-->
			string strSql="";
			if(this.Sql.GetSql("Manager.DataFileParam.Get.1",ref strSql)==-1) return null;
			Neusoft.HISFC.Models.File.DataFileParam DataFileParam=new Neusoft.HISFC.Models.File.DataFileParam();
			try
			{
				//DataFileParam=sender as Neusoft.HISFC.Models.Base.DataFileParam;
				strSql=string.Format(strSql,strType);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(strSql)==-1)return null;
			try
			{
				this.Reader.Read();
			}
			catch{return null;}
			try
			{
				DataFileParam.Type =this.Reader[0].ToString();//系统类别
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.WriteErr();
			}
			try
			{
				DataFileParam.ID =this.Reader[1].ToString();//参数
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.WriteErr();
			}
			try
			{
				DataFileParam.IsInDB =System.Convert.ToBoolean(int.Parse(this.Reader[2].ToString()));//是否在数据库
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.WriteErr();
			}
			try
			{
				DataFileParam.Name =this.Reader[3].ToString();//数据表名
				DataFileParam.IP =this.Reader[4].ToString();//IP
				DataFileParam.Folders  =this.Reader[5].ToString();//数据文件夹名
				DataFileParam.ModualFolders  =this.Reader[6].ToString();//摸板文件夹名
				DataFileParam.Http =this.Reader[7].ToString();//摸板文件夹名
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.WriteErr();
				
			}
			this.Reader.Close();

			//接口名称 Manager.Ftp.Get.1
			//<!--0 ip,1 username,2 pwd,3 root-->
			if( this.Sql.GetSql("Manager.Ftp.Get.1",ref strSql)==-1) return null;
			try
			{
				strSql=string.Format(strSql,DataFileParam.IP);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.WriteErr();
				return null;
			}
			if(this.ExecQuery(strSql)==-1)return null;
			try
			{
                if (DataFileParam.IsInDB) //数据库里面不用取ftp
                {
                }
                else
                {
                    if (this.ExecQuery(strSql) == -1) return null;
                    if (this.Reader.Read())
                    {
                        DataFileParam.UserName = this.Reader[1].ToString();
                        DataFileParam.PassWord = this.Reader[2].ToString();
                        DataFileParam.Root = this.Reader[3].ToString();
                    }
                    else 
                    {
                        this.Err = "没有设置ftp!";
                        return null;
                    }
                }
                this.Reader.Close();
                
			}
			catch{return null;}	
			
			return DataFileParam;
		}

		/// <summary>
		/// 设置参数
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int Set(Neusoft.FrameWork.Models.NeuObject obj)
		{
			// TODO:  添加 DataFileParam.Set 实现
			return 0;
		}
		#endregion
		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int Update(Neusoft.FrameWork.Models.NeuObject obj)
		{
			// TODO:  添加 DataFileParam.Update 实现
			string sql="",sql1="";
			if(this.Sql.GetSql("Manager.DataFileParam.Update",ref sql)==-1) return -1;
			if(this.Sql.GetSql("Manager.DataFileParam.Update.2",ref sql1)==-1) return -1;
			Neusoft.HISFC.Models.File.DataFileParam o = obj as Neusoft.HISFC.Models.File.DataFileParam;
			if(o==null) return -1;
			try
			{
				sql = string.Format(sql,o.ID,o.Name,o.IsInDB.GetHashCode().ToString(),
					o.Type,o.IP,o.Folders,o.ModualFolders,o.Http,this.Operator.ID);
				sql1 = string.Format(sql1,o.ID,o.Name,o.IsInDB.GetHashCode().ToString(),
					o.Type,o.IP,o.Folders,o.ModualFolders,o.Http,this.Operator.ID);
			}
			catch(Exception ex){this.Err=ex.Message;return -1;}
			if(this.ExecNoQuery(sql)<=0) return -1;
			if(this.ExecNoQuery(sql1)<0) return -1;
			return 0;
		}
		/// <summary>
		/// 插入
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int Insert(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string sql="";
			if(this.Sql.GetSql("Manager.DataFileParam.Insert",ref sql)==-1) return -1;
			Neusoft.HISFC.Models.File.DataFileParam o = obj as Neusoft.HISFC.Models.File.DataFileParam;
			if(o==null) return -1;
			try
			{
				sql = string.Format(sql,o.ID,o.Name,o.IsInDB.GetHashCode().ToString(),
					o.Type,o.IP,o.Folders,o.ModualFolders,o.Http,this.Operator.ID);
			}
			catch(Exception ex){this.Err=ex.Message;return -1;}
			if(this.ExecNoQuery(sql)<=0) return -1;
			return 0;
		}
		
	}
}
