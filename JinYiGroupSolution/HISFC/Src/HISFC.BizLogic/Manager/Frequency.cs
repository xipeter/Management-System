using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// Frequency 的摘要说明。
	/// </summary>
	public class Frequency:Neusoft.FrameWork.Management.Database,Neusoft.HISFC.Models.Base.IManagement
	{
		public Frequency()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region IManagement 成员

		public ArrayList GetList()
		{
			// TODO:  添加 Frequency.GetList 实现
			return null;
		}

		public int Del(object obj)
		{
			// TODO:  添加 Frequency.Del 实现
			#region "接口"
			//接口名称 Manager.Frequency.Update.1
			//<!--0 id频次id, 1 name频次名称, 2 deptcode, 3 执行时间点, 4 用法id, 5 用法name,6 SortID,
			//	 7 operator id, 8 operator name,9 operator time -->
			#endregion
			string strSql="";
			if(this.Sql.GetSql("Manager.Frequency.Delete.1",ref strSql)==-1) return -1;
			Neusoft.HISFC.Models.Order.Frequency o=obj as Neusoft.HISFC.Models.Order.Frequency;
			try
			{
				string[] s=new string[10];
				try
				{
					s[0]=o.ID ;//id频次id
				}
				catch{}
				try
				{
					s[1]=o.Name ;//name频次名称
				}
				catch{}
				try
				{
					s[2]=o.Dept.ID;//deptcode
				}
				catch{}
				try
				{
					s[3]=o.Time ;//执行时间点
				}
				catch{}
				try
				{
					s[4]=o.Usage.ID ;//用法id
				}
				catch{}
				try
				{
					s[5] = o.Usage.Name ;//用法name
				}
				catch{}
				try
				{
					s[6] = o.SortID.ToString() ;//SortID
				}
				catch{}
				try
				{
					s[7] = this.Operator.ID ;//operator id
				}
				catch{}
				try
				{
					s[8]=this.Operator.Name ;//operator name
				}
				catch{}
				try
				{
					s[9]=this.GetSysDate();//operator time
				}
				catch{}
				strSql=string.Format(strSql,s);
			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
            if (this.ExecQuery(strSql) < 0)
			{
                return -1;
       
			}
           
			return 0;
		}

        /// <summary>
        ///已经使用的频次不能删除
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public int ExistFrequencyCounts(Neusoft.HISFC.Models.Order.Frequency frequency)
        {
            string strSql = "";
            if (this.Sql.GetSql("Manager.Frequency.DeleteCheck.1", ref strSql) == -1)
            {
                this.Err = "没有找到索引为: Manager.Frequency.DeleteCheck.1的SQL语句!";
                
                return -1;
            }
            
            try
            {   
                strSql = string.Format(strSql, frequency.ID);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                this.WriteErr();

                return -1;
            }

            return Neusoft.FrameWork.Function.NConvert.ToInt32(this.ExecSqlReturnOne(strSql));
        }
        
		public int SetList(ArrayList al)
		{
			// TODO:  添加 Frequency.SetList 实现
			return 0;
		}

		public Neusoft.FrameWork.Models.NeuObject Get(object obj)
		{
			return null;
		}
		public Neusoft.FrameWork.Models.NeuObject Get(object obj,string DeptCode)
		{
			//选择
			string sql="";
			Neusoft.HISFC.Models.Order.Frequency f =null;
			try
			{
				f = (Neusoft.HISFC.Models.Order.Frequency)obj;
			}
			catch{this.Err = "参数类型不是频次！";return null;}

			if(this.Sql.GetSql("Manager.Frequency.Get.1",ref sql)==-1) return null;
			try
			{
				sql = string.Format(sql,f.ID,f.Usage.ID,f.Dept.ID);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.WriteErr();
				return null;
			}

			ArrayList al = new ArrayList();
			al = myList(sql);
			if(al == null || al.Count ==0) 
			{
				this.Err = "没有找到频次" + f.ID +"的时间点设置!";
				this.WriteErr();
				return null;
			}
			if(al.Count ==1)
			{
				return al[0] as Neusoft.FrameWork.Models.NeuObject;//一个返回当前
			}
			
			int fit =0;
			for(int i=0;i<al.Count;i++)
			{
				Neusoft.HISFC.Models.Order.Frequency tmpf =(Neusoft.HISFC.Models.Order.Frequency)al[i];
				if(tmpf.Dept.ID == DeptCode) fit = i;
				if(tmpf.Usage.ID == f.Usage.ID ) fit = i;
				if(tmpf.Usage.ID == f.Usage.ID && tmpf.Dept.ID == DeptCode)
				{
					fit = i;
					break;
				}
			}

			// TODO:  添加 Frequency.Get 实现
			return  al[fit] as Neusoft.FrameWork.Models.NeuObject;//一个返回当前;
		}
		/// <summary>
		/// 取全部的频次
		/// </summary>
		/// <param name="DeptCode"></param>
		/// <returns></returns>
		public ArrayList GetAll(string DeptCode) {
			string strSql = "";
			if(this.Sql.GetSql("Manager.Frequency.Get.All",ref strSql) == -1) {
			     this.Err = "没有找到Manager.Frequency.Get.All字段";
				 return null;
			}
			try {
				strSql = string.Format(strSql,DeptCode);
			}
			catch {
			    this.Err = "格式化语句出错";
				return null;
			}
			return this.myList(strSql);
		}
		public int Set(Neusoft.FrameWork.Models.NeuObject obj)
		{
			// TODO:  添加 Frequency.Set 实现
			#region "接口"
			//接口名称 Manager.Frequency.Update.1
			//<!--0 id频次id, 1 name频次名称, 2 deptcode, 3 执行时间点, 4 用法id, 5 用法name,6 SortID,
			//	 7 operator id, 8 operator name,9 operator time -->
			#endregion
			string strSql="",strSql1="";
			if(this.Sql.GetSql("Manager.Frequency.Update.1",ref strSql)==-1) return -1;
			if(this.Sql.GetSql("Manager.Frequency.Insert.1",ref strSql1)==-1) return -1;
			Neusoft.HISFC.Models.Order.Frequency o=obj as Neusoft.HISFC.Models.Order.Frequency;
			try
			{
				string[] s=new string[10];
				try
				{
					s[0]=o.ID ;//id频次id
				}
				catch{}
				try
				{
					s[1]=o.Name ;//name频次名称
				}
				catch{}
				try
				{
					s[2]=o.Dept.ID;//deptcode
					}
				catch{}
				try
				{
					s[3]=o.Time ;//执行时间点
				}
				catch{}
				try
				{
					s[4]=o.Usage.ID ;//用法id
					}
				catch{}
				try
				{
					s[5]=o.Usage.Name ;//用法name
					}
				catch{}
				try
				{
					s[6]=o.SortID.ToString() ;//SortID
					}
				catch{}
				try
				{
					s[7]=this.Operator.ID ;//operator id
					}
				catch{}
				try
				{
					s[8]=this.Operator.Name ;//operator name
					}
				catch{}
				try
				{
					s[9]=this.GetSysDate();//operator time
				}
				catch{}
				strSql=string.Format(strSql,s);
				strSql1=string.Format(strSql1,s);
			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			if(this.ExecNoQuery(strSql1)<=0)
			{
				if(this.ExecNoQuery(strSql)<=0)
				{
					return -1;
				}
				else
				{
					return 0;
				}
			}
			return 0;
		}

		#endregion
		#region 
		/// <summary>
		/// 获得科室的频次
		/// </summary>
		/// <param name="DeptCode">科室编码</param>
		/// <returns></returns>
		public ArrayList GetList(string DeptCode)
		{
			// TODO:  添加 Frequency.GetList 实现
			string sql="";
			if(this.Sql.GetSql("Manager.Frequency.GetList.1",ref sql)==-1) return null;
			try
			{
				sql=string.Format(sql,DeptCode);
			}
			catch{return null;}
			return myList(sql);
		}
		private ArrayList myList(string sql)
		{
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al=new ArrayList();
			#region "接口"
			//接口名称 Manager.Frequency.GetList.1
			//<!--0 id频次id, 1 name频次名称, 2 deptcode, 3 执行时间点, 4 用法id, 5 用法name,6 SortID,
			//	 7 operator id, 8 operator name,9 operator time -->
			#endregion
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Order.Frequency obj=new Neusoft.HISFC.Models.Order.Frequency();
					obj.ID=this.Reader[0].ToString();//id频次id
					obj.Name =this.Reader[1].ToString();//name频次名称
					obj.Dept.ID = this.Reader[2].ToString();//deptcode
					obj.Time = this.Reader[3].ToString();//执行时间点
					obj.Usage.ID = this.Reader[4].ToString();//用法id
					obj.Usage.Name = this.Reader[5].ToString();//用法name
					obj.SortID = FrameWork.Function.NConvert.ToInt32(this.Reader[6].ToString());//sortid
					obj.User02 =this.Reader[7].ToString();//operator id
					//obj.User02 =this.Reader[8].ToString();//operator name
					obj.User03 =this.Reader[9].ToString();//operator time
					al.Add(obj);
				}
				return al;
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return null;
			}
			finally
			{
				this.Reader.Close();
			}
		}


        /// <summary>
        /// 获取单独一条频次
        /// {24F859D1-3399-4950-A79D-BCCFBEEAB939} 附材有时间间隔的处理
        /// </summary>
        /// <param name="DeptCode">科室代码</param>
        /// <param name="sysClass">系统类别</param>
        /// <returns></returns>
        public ArrayList GetBySysClassAndID(string DeptCode, string sysClass, string frequencyID)
        {
            string strSql = "";
            if (this.Sql.GetSql("Manager.Frequency.GetByType.FrequencyID.1", ref strSql) == -1)
            {
                this.Err = "没有找到Manager.Frequency.GetByType.1字段";
                return null;
            }
            try
            {
                strSql = string.Format(strSql, DeptCode, sysClass, frequencyID);
            }
            catch
            {
                this.Err = "格式化语句出错";
                return null;
            }
            return this.myList(strSql);
        }

		#endregion
		#region 获得特殊频次
		/// <summary>
		/// 获得特殊频次点和时间
		/// </summary>
		/// <param name="moOrder"></param>
		/// <param name="comNo"></param>
		/// <returns></returns>
		public  Neusoft.HISFC.Models.Order.Frequency  GetDfqspecial(string moOrder,string comNo)
		{
			string strSql = "";
			Neusoft.HISFC.Models.Order.Frequency info = null;
			if (this.Sql.GetSql("Order.Dfqspecial.GetDfqspecial",ref strSql)==-1) return null;

			try
			{ 
				strSql = string.Format(strSql,moOrder,comNo);
				if(this.ExecQuery(strSql)==-1) return null;
				if(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Order.Frequency();
					info.ID = Reader[0].ToString();
					info.Name =Reader[1].ToString();
					info.Time = Reader[2].ToString();
					info.User01 = Reader[3].ToString();					
				}
				else
				{
					return null;
				}
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				info = null;
			}
			finally
			{
				this.Reader.Close();
			}
			return info;
		}
		#endregion
	}
}
