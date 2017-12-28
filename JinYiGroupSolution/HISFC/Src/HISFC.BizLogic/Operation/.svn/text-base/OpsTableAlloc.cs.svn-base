using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Operation
{
	/// <summary>
	/// OpsTableAlloc 的摘要说明。
	/// 手术正台分配操作类
	/// </summary>
	public class OpsTableAlloc : Neusoft.FrameWork.Management.Database 
	{
		public OpsTableAlloc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 成员函数	
		///<summary>
		///增加手术室正台分配信息
		///</summary>
		///<param name="AllotInfoAl">存有手术分配信息的数组，元素为Neusoft.HISFC.Models.Operation.OpsTableAllot类型</param>
		///<returns>0成功 -1失败</returns>
		public int AddAllotInfo(ArrayList AllotInfoAl)
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableAlloc.AddAllotInfo.1",ref strSql) == -1) 
			{
				return -1;
			}

			foreach(Neusoft.HISFC.Models.Operation.OpsTableAllot thisAllot in AllotInfoAl)
			{
				try
				{				
					//手术正台分配表中增加记录
					strSql = string.Format(strSql,thisAllot.OpsRoom.ID.ToString(),thisAllot.Dept.ID.ToString(),
						thisAllot.Week.ID.ToString(),thisAllot.Qty,thisAllot.User.ID.ToString(),this.GetSysDateTime());
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.ErrCode = ex.Message;
					return -1;            
				}
				if (strSql == null) return -1;	
			
				if(this.ExecNoQuery(strSql) == -1) return -1;
			}
			return 0;
		}
		///<summary>
		///更新手术室正台分配信息
		///</summary>
		///<param name="AllotInfoAl">存有手术分配信息的数组，元素为Neusoft.HISFC.Models.Operation.OpsTableAllot类型</param>
		///<returns>0成功 -1失败</returns>
		public int UpdateAllotInfo(ArrayList AllotInfoAl)
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableAlloc.UpdateAllotInfo.1",ref strSql) == -1) 
			{
				return -1;
			}

			foreach(Neusoft.HISFC.Models.Operation.OpsTableAllot thisAllot in AllotInfoAl)
			{
				try
				{				
					//手术正台分配表中更改记录
					strSql = string.Format(strSql,thisAllot.OpsRoom.ID.ToString(),thisAllot.Dept.ID.ToString(),
						thisAllot.Week.ID.ToString(),thisAllot.Qty,thisAllot.User.ID.ToString(),this.GetSysDateTime());
				}
				catch(Exception ex)
				{
					this.Err = ex.Message;
					this.ErrCode = ex.Message;
					return -1;            
				}
				if (strSql == null) return -1;	
			
				if(this.ExecNoQuery(strSql) == -1) return -1;
			}
			return 0;
		}
		///<summary>
		///删除手术室正台分配信息
		///</summary>
		///<param name="thisAllot">手术分配信息对象(Neusoft.HISFC.Models.Operation.OpsTableAllot类型)</param>
		///<returns>0成功 -1失败</returns>
		public int DelAllotInfo(Neusoft.HISFC.Models.Operation.OpsTableAllot thisAllot)
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableAlloc.DelAllotInfo.1",ref strSql) == -1) return -1;
			
			try
			{				
				//手术正台分配表中删除记录
				strSql = string.Format(strSql,thisAllot.OpsRoom.ID.ToString(),
					thisAllot.Dept.ID.ToString(),thisAllot.Week.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;			
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 获得手术室的正台分配信息
		/// </summary>
		/// <param name="AllotInfoAl">
		/// （引用，存有手术分配信息的数组，
		/// 元素为Neusoft.HISFC.Models.Operation.OpsTableAllot类型,传入时没有元素）</param>
		/// <param name="OpsRoom">（手术室实体）</param>
		/// <returns>0成功 -1失败 </returns>
		public int GetAllotInfo(ref ArrayList AllotInfoAl, Neusoft.FrameWork.Models.NeuObject OpsRoom)
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableAlloc.GetAllotInfo.1",ref strSql) == -1) return -1;
			try
			{
				//获取手术室正台分配信息
				strSql = string.Format(strSql,OpsRoom.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OpsTableAllot thisAllot = new Neusoft.HISFC.Models.Operation.OpsTableAllot();
					try
					{
						thisAllot.OpsRoom.ID = Reader[0].ToString();//手术科室代码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Dept.ID = Reader[1].ToString();//临床科室代码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Dept.Name = Reader[4].ToString();//临床科室名称
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Week.ID = Reader[2].ToString();//星期
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Qty = System.Convert.ToInt16(Reader[3]);//正台数
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}

					AllotInfoAl.Add(thisAllot);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术正台分配信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return -1;
			}
			this.Reader.Close();
			return 0;
		}
		/// <summary>
		/// 获得手术室的正台分配信息 （重载）
		/// </summary>
		/// <param name="AllotInfoAl">
		/// （引用，存有手术分配信息的数组，
		/// 元素为Neusoft.HISFC.Models.Operation.OpsTableAllot类型,传入时没有元素）</param>
		/// <param name="OpsRoom">（手术室实体）</param>
		/// <param name="Dept">（临床科室实体）</param>
		/// <returns>0成功 -1失败 </returns>
		public int GetAllotInfo(ref ArrayList AllotInfoAl, Neusoft.FrameWork.Models.NeuObject OpsRoom,Neusoft.FrameWork.Models.NeuObject Dept)
		{
			string strSql = string.Empty;
			if(this.Sql.GetSql("Operator.OpsTableAlloc.GetAllotInfo.2",ref strSql) == -1) return -1;
			try
			{
				//获取手术室正台分配信息
				strSql = string.Format(strSql,OpsRoom.ID.ToString(),Dept.ID.ToString());
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				return -1;            
			}
			if (strSql == null) return -1;
			this.ExecQuery(strSql);
			try
			{
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Operation.OpsTableAllot thisAllot = new Neusoft.HISFC.Models.Operation.OpsTableAllot();
					try
					{
						thisAllot.OpsRoom.ID = Reader[0].ToString();//手术科室代码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Dept.ID = Reader[1].ToString();//临床科室代码
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Dept.Name = Reader[4].ToString();//临床科室名称
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Week.ID = Reader[2].ToString();//星期
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}
					try
					{
						thisAllot.Qty = System.Convert.ToInt16(Reader[3]);//正台数
					}
					catch(Exception ex)
					{
						this.Err=ex.Message;
						this.WriteErr();
					}

					AllotInfoAl.Add(thisAllot);
				}
			}
			catch(Exception ex)
			{
				this.Err="获得手术正台分配信息出错！"+ex.Message;
				this.ErrCode="-1";
				this.WriteErr();
				return -1;
			}
			this.Reader.Close();
			return 0;
		}
		#endregion
	}
}
