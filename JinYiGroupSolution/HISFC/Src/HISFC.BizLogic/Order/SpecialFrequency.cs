using System;

namespace Neusoft.HISFC.BizLogic.Order
{
	/// <summary>
	/// SpecialFrequency 的摘要说明。
	/// </summary>
	public class SpecialFrequency :Neusoft.FrameWork.Management.Database 
	{
		public SpecialFrequency()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 增删改
		/// <summary>
		/// 插入特殊频次
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public  int InsertSpecialFrequency(Neusoft.HISFC.Models.Order.SpecialFrequency info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Order.Dfqspecial.InsertDfqspecial",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				string OperId = this.Operator.ID;
				strSql = string.Format(strSql,info.OrderID,info.Combo.ID,info.ID,info.Point,info.Dose,OperId);
			}
			catch(Exception ex)
			{
				this.Err  = ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新特殊频次
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateSpecialFrequency( Neusoft.HISFC.Models.Order.SpecialFrequency info )
		{
			string strSql = "";
			if (this.Sql.GetSql("Order.Dfqspecial.updateIDfqspecial",ref strSql)==-1)return -1;
			try
			{
				string OperId =this.Operator.ID;
				strSql = string.Format(strSql,info.OrderID,info.Combo.ID ,info.ID,info.Point,info.Dose,OperId);
			}
			catch(Exception ex)
			{
				this.Err  = ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		#endregion

		#region 共有
		/// <summary>
		/// 更新或插入数据
		/// </summary>
		/// <param name="info"></param>
		/// <returns>  -1 失败 >=0 返回更新记录的条数 </returns>
		public int SetFrequency(Neusoft.HISFC.Models.Order.SpecialFrequency info)
		{
			string strSql ="";

			if (this.Sql.GetSql("Order.Dfqspecial.updateOrInsertDfqspecial",ref strSql) == -1)
			{
				this.Err = this.Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql,info.OrderID,info.Combo.ID );
				if(this.ExecQuery(strSql)==-1) 
				{
					return -1;
				}
				if(this.Reader.Read())
				{
					//更新
					return this.UpdateSpecialFrequency(info );
				}
				else
				{
					//插入
					return this.InsertSpecialFrequency(info);
				}
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				return -1;
			}
		}
		
		/// <summary>
		/// 获得特殊频次
		/// </summary>
		/// <param name="moOrder"></param>
		/// <param name="comNo"></param>
		/// <returns></returns>
		public  Neusoft.HISFC.Models.Order.SpecialFrequency  GetSpecialFrequency(string moOrder,string comNo)
		{
			string strSql = "";
			Neusoft.HISFC.Models.Order.SpecialFrequency info = null;
			if (this.Sql.GetSql("Order.Dfqspecial.GetDfqspecial",ref strSql) == -1) return null;

			try
			{ 
				strSql = string.Format(strSql,moOrder,comNo);
				if(this.ExecQuery(strSql) == -1) return null;
				if(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Order.SpecialFrequency();
					info.ID = Reader[0].ToString();
					info.Name =Reader[1].ToString();
					info.Point = Reader[2].ToString();
					info.Dose = Reader[3].ToString();
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
