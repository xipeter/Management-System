using System;

namespace Neusoft.HISFC.Management.Order
{
	/// <summary>
	/// Dfqspecial 的摘要说明。
	/// </summary>
	public class Dfqspecial :Neusoft.NFC.Management.Database 
	{
		public Dfqspecial()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private  int InsertDfqspecial(Neusoft.HISFC.Object.Order.SpecialFrequency info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Order.Dfqspecial.InsertDfqspecial",ref strSql)==-1)return -1;
			try
			{
				string OperId =this.Operator.ID;
				strSql = string.Format(strSql,info.OrderID,info.Combo.ID,info.ID,info.Point,info.Dose,OperId);
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		private  int updateIDfqspecial(Neusoft.HISFC.Object.Order.SpecialFrequency info )
		{
			string strSql = "";
			if (this.Sql.GetSql("Order.Dfqspecial.updateIDfqspecial",ref strSql)==-1)return -1;
			try
			{
				string OperId =this.Operator.ID;
				strSql = string.Format(strSql,info.OrderID,info.Combo.ID ,info.ID,info.Point,info.Dose,OperId);
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		///    更新或插入数据
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int updateOrInsertDfqspecial(Neusoft.HISFC.Object.Order.SpecialFrequency info)
		{
			string strSql ="";
			int Result  = 0;
			bool IsUpdate = false;
			if (this.Sql.GetSql("Order.Dfqspecial.updateOrInsertDfqspecial",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,info.OrderID,info.Combo.ID );
				if(this.ExecQuery(strSql)==-1)return -1;
				
				if(this.Reader.Read())
					IsUpdate = true;
			
				if(IsUpdate)
				{
					//更新
					Result =updateIDfqspecial(info );
				}
				else
				{
					//插入
					Result =InsertDfqspecial(info);
				}
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				Result=-1;
			}
			return Result;
		}
		public  Neusoft.HISFC.Object.Order.SpecialFrequency  GetDfqspecial(string moOrder,string comNo)
		{
			string strSql = "";
			Neusoft.HISFC.Object.Order.SpecialFrequency info = null;
			if (this.Sql.GetSql("Order.Dfqspecial.GetDfqspecial",ref strSql)==-1) return null;

			try
			{ 
				strSql = string.Format(strSql,moOrder,comNo);
				if(this.ExecQuery(strSql)==-1) return null;
				if(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Object.Order.SpecialFrequency();
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
	}
}
