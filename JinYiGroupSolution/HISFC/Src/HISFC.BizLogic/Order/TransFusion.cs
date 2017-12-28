using System;
using Neusoft.HISFC.Models;
using System.Collections;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.BizLogic.Order
{
	/// <summary>
	/// TransFusion 的摘要说明。
	/// 输液卡管理
	/// </summary>
	public class TransFusion:Neusoft.FrameWork.Management.Database
	{
		public TransFusion()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 添加输液卡设置信息
		/// 必须填写（NURSE_CELL_CODE,USAGE_CODE）
		/// </summary>
		/// <param name="nurseCode"></param>
		/// <param name="usageCode"></param>
		/// <returns></returns>
		public int InsertTransFusion( string nurseCode, string usageCode )
		{
			#region "接口"
			//传入：0 病区编码 1用法编码 2 操作员
			//传出：0
			#endregion
			string strSql = "";
		
			if (this.Sql.GetSql("Order.TransFusion.InsertItem.1",ref strSql)==-1) 
			{
				this.Err = "没有找到Order.TransFusion.InsertItem.1";
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,nurseCode,usageCode,this.Operator.ID);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		///  删除输液卡设置信息
		///  必须填写（NURSE_CELL_CODE,USAGE_CODE）
		/// </summary>
		/// <param name="nurseCode"></param>
		/// <param name="usageCode"></param>
		/// <returns>-1 错误 0 没有找到记录 >0 记录行数</returns>
		public int DeleteTransFusion(string nurseCode, string usageCode)
		{
			string strSql = "";

			#region "接口"
			//传入：0 病区编码 1用法编码 2 操作员 3 操作时间
			//传出：0
			#endregion
			if (this.Sql.GetSql("Order.TransFusion.DeleteItem.1", ref strSql) == -1)
			{
				this.Err = "没有找到Order.TransFusion.DeleteItem.1";
				
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,nurseCode,usageCode);
			}
			catch (Exception ex)
			{
				this.Err = ex.Message;
				this.ErrCode = ex.Message;
				
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		
		/// <summary>
		///  获得输液卡设置信息
		/// </summary>
		/// <param name="nurseCode"></param>
		/// <returns></returns>
		public ArrayList QueryTransFusion( string nurseCode )
		{
			ArrayList al = new ArrayList();
			string strSql = "";
			//Order.TransFusion.Select.1
			//传入：0  NurseCode
			//传出:属于该项目或用法的附材
			if(this.Sql.GetSql("Order.TransFusion.Select.1", ref strSql) == 0)
			{
				if(this.ExecQuery(strSql,nurseCode)==-1) return null;
				while(this.Reader.Read())
				{
					al.Add(this.Reader[0].ToString());
				}
				this.Reader.Close();
			}
			else
			{
				this.Err = "没有找到Order.TransFusion.Select.1";
				if(!this.Reader.IsClosed)
					this.Reader.Close();
				return null;
			}
			return al;
		}

		#region 作废
		[Obsolete("用QueryTransFusion代替了",true)]
		public ArrayList GetTransFusion( string nurseCode )
		{
			return this.QueryTransFusion(nurseCode);
		}
		#endregion
	}
}
