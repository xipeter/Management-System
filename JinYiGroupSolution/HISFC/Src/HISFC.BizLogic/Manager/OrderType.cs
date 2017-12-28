using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// OrderType 的摘要说明。
	/// </summary>
	public class OrderType:Neusoft.FrameWork.Management.Database,Neusoft.HISFC.Models.Base.IManagement
	{
		public OrderType()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region IManagement 成员
		public ArrayList GetList()
		{
			// TODO:  添加 Frequency.GetList 实现
			string sql="";
			if(this.Sql.GetSql("Manager.OrderType.GetList.1",ref sql)==-1) return null;
//			try
//			{
//				sql=string.Format(sql);
//			}
//			catch{return null;}
			if(this.ExecQuery(sql)==-1) return null;
			ArrayList al=new ArrayList();
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Order.OrderType obj=new Neusoft.HISFC.Models.Order.OrderType();
					
					try
					{
						obj.ID=this.Reader[0].ToString();//id频次id
					}
					catch
					{}
					try
					{
						obj.Name =this.Reader[1].ToString();//name频次名称
					}
					catch
					{}
					try
					{
						obj.IsCharge =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[2].ToString());//
					}
					catch
					{}
					try
					{
						obj.IsConfirm =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());
					}
					catch
					{}
					try
					{
						obj.IsDecompose=Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[4].ToString());//
					}
					catch
					{}
					try
					{
						obj.IsNeedPharmacy  =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[5].ToString());//
					}
					catch
					{}
					try
					{
						obj.IsPrint =Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());//
					}
					catch
					{}
					al.Add(obj);
				}
				return al;
			}
			catch{return null;}
		}

		public int Del(object obj)
		{
			// TODO:  添加 OrderType.Del 实现
			string strSql="";
			if(this.Sql.GetSql("Manager.OrderType.Delete.1",ref strSql)==-1) return -1;
			if(this.GetStrings(obj,ref strSql)==-1) return -1;
			if(this.ExecNoQuery(strSql)<=0)
			{
				return -1;
			}
			return 0;
		}
		private int GetStrings(object obj,ref string strSql)
		{
			#region "接口"
			//<!--0 id医嘱类型id, 1 name医嘱类型, 2 是否记费, 3 确认, 4 是否分解, 5 是否需要摆药,6 是否打印,
			//	 7 operator id, 8 operator name,9 operator time -->
			#endregion
			Neusoft.HISFC.Models.Order.OrderType o=obj as Neusoft.HISFC.Models.Order.OrderType;
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
					s[2]=System.Convert.ToInt16(o.IsCharge).ToString();//是否记费
				}
				catch{}
				try
				{
					s[3]=System.Convert.ToInt16(o.IsConfirm).ToString() ;//确认
				}
				catch{}
				try
				{
					s[4]=System.Convert.ToInt16(o.IsDecompose).ToString() ;//是否分解
				}
				catch{}
				try
				{
					s[5]=System.Convert.ToInt16(o.IsNeedPharmacy).ToString();//是否需要摆药
				}
				catch{}
				try
				{
					s[6]=System.Convert.ToInt16(o.IsPrint).ToString();//是否打印
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
			
			}
			catch(Exception ex)
			{
				this.Err="赋值时候出错！"+ex.Message;
				this.WriteErr();
				return -1;
			}
			return 0;
		}
		public int SetList(ArrayList al)
		{
			// TODO:  添加 Frequency.SetList 实现
			return 0;
		}

		public Neusoft.FrameWork.Models.NeuObject Get(object obj)
		{
			// TODO:  添加 Frequency.Get 实现
			Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
			return obj1;
		}

		public int Set(Neusoft.FrameWork.Models.NeuObject obj)
		{
			// TODO:  添加 OrderType.Set 实现
			#region "接口"
			//接口名称 Manager.OrderType.Update.1
			//<!--0 id医嘱类型id, 1 name医嘱类型, 2 是否记费, 3 确认, 4 是否分解, 5 是否需要摆药,6 是否打印,
			//	 7 operator id, 8 operator name,9 operator time -->
			#endregion
			string strSql="",strSql1="";
			if(this.Sql.GetSql("Manager.OrderType.Update.1",ref strSql)==-1) return -1;
			if(this.Sql.GetSql("Manager.OrderType.Insert.1",ref strSql1)==-1) return -1;
			if(this.GetStrings(obj,ref strSql)==-1) return -1;
			if(this.GetStrings(obj,ref strSql1)==-1) return -1;
			if(this.ExecNoQuery(strSql)<=0)
			{
				if(this.ExecNoQuery(strSql1)<=0)
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
	}
}
