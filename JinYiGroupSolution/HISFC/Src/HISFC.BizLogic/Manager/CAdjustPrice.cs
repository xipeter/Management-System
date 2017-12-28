using System;
using System.Collections;
namespace Neusoft.HISFC.Management.Manager
{
	/// <summary>
	/// CAdjustPrice 的摘要说明。
	/// </summary>
	public class CAdjustPrice  : Neusoft.NFC.Management.Database
	{
		public CAdjustPrice()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 获取调价单号
		/// </summary>
		/// <returns></returns>
		public string  GetAdjustPriceSequence()
		{
			string strSql = "";
			string   Se ="";
			try
			{
			
				if (this.Sql.GetSql("Fee.CAdjustPrice.GetAdjustPriceSequence",ref strSql)==-1)return null;
				this.ExecQuery(strSql);

				while(this.Reader.Read())
				{

					Se = Reader[0].ToString();
				
				}
			}
			catch(Exception ee)
			{
				this.Err=ee.Message;
			}
			return Se;

		}
		/// <summary>
		/// 非药品调价头表  插入
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>

		public int  InsertCAdjustPrice(Neusoft.HISFC.Object.Fee.Item.AdjustPrice info)
		{
			string strSql = "";
			//待更改if(info.IsNow)
//			{
//				//调价即时生效
//				if (this.Sql.GetSql("Fee.CAdjustPrice.InsertCAdjustPrice1",ref strSql)==-1)return -1;
//				try
//				{
//					string OperId = this.Operator.ID;
//					//insert into fin_com_adjustundrugpricehead values('[父级编码]','[本级编码]','{0}',sysdate,'{1}',sysdate)
//					strSql = string.Format(strSql,info.AdjustPriceNO,OperId);
//				}
//				catch(Exception ee)
//				{
//					this.Err = ee.Message;
//				}
//			}
			//else
			{
				if (this.Sql.GetSql("Fee.CAdjustPrice.InsertCAdjustPrice2",ref strSql)==-1)return -1;
				try
				{
					string OperId = this.Operator.ID;
					//insert into fin_com_adjustundrugpricehead values('[父级编码]','[本级编码]','{0}',{1},'{2}',sysdate)
					strSql = string.Format(strSql,info.AdjustPriceNO,info.Oper.OperTime,OperId);
				}
				catch(Exception ee)
				{
					this.Err = ee.Message;
				}
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 非药品调价记录表 插入
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertCAdjustPriceDetail(Neusoft.HISFC.Object.Fee.Item.AdjustPrice info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.CAdjustPrice.InsertCAdjustPriceDetail",ref strSql)==-1)return -1;
			try
			{
				string OperId = this.Operator.ID;
				string ValueState ="";
				if(info.User03=="已生效")
				{
					ValueState ="0";
				}
				else if(info.User03=="未生效")
				{
					ValueState="1";
				}
				else
				{
					ValueState ="2";
				}
				strSql = string.Format(strSql,info.AdjustPriceNO,info.OrgItem.ID,info.NewItem.Price,info.NewItem.ChildPrice,info.NewItem.SpecialPrice,OperId,ValueState);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 查询头表
		/// </summary>
		/// <param name="BeginTime"></param>
		/// <param name="EndTime"></param>
		/// <returns></returns>
		public ArrayList SelectPriceAdjustHead(System.DateTime  BeginTime,System.DateTime EndTime )
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Fee.CAdjustPrice.SelectPriceAdjustHead",ref strSql)==-1) return null;
			try
			{
				strSql = string.Format(strSql,BeginTime,EndTime);
				this.ExecQuery(strSql);
				Neusoft.HISFC.Object.Fee.Item.AdjustPrice info = null;
				List = new ArrayList();
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Object.Fee.Item.AdjustPrice();
					info.AdjustPriceNO = Reader[0].ToString();
					if(Reader[1]!=DBNull.Value)
					{
						info.Oper.OperTime = Convert.ToDateTime(Reader[1]);
					}
					List.Add(info);
					info = null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				List = null;
			}
			return List;
		}
		/// <summary>
		/// 查询明细 
		/// </summary>
		/// <param name="AdjustPriceNo"></param>
		/// <returns></returns>
		public ArrayList SelectPriceAdjustTail(string AdjustPriceNo)
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Fee.CAdjustPrice.SelectPriceAdjustTail",ref strSql)==-1) return null;
			try
			{
				strSql = string.Format(strSql,AdjustPriceNo);
				this.ExecQuery(strSql);
				Neusoft.HISFC.Object.Fee.Item.AdjustPrice info = null;
				List = new ArrayList();
				while(this.Reader.Read())
				{
					info = new Neusoft.HISFC.Object.Fee.Item.AdjustPrice();
					info.AdjustPriceNO = Reader[0].ToString();
					info.OrgItem.ID = Reader[1].ToString();
					info.OrgItem.Name = Reader[2].ToString();
					if(Reader[3]!=DBNull.Value)
					{
						info.OrgItem.Price = Convert.ToDecimal(Reader[3]);
					}
					if(Reader[4]!=DBNull.Value)
					{
						info.NewItem.Price = Convert.ToDecimal(Reader[4]);
					}
					if(Reader[5]!=DBNull.Value)
					{
						info.OrgItem.ChildPrice = Convert.ToDecimal(Reader[5]);
					}
					if(Reader[6]!=DBNull.Value)
					{
						info.NewItem.ChildPrice = Convert.ToDecimal(Reader[6]);
					}
					if(Reader[7]!=DBNull.Value)
					{
						info.OrgItem.SpecialPrice = Convert.ToDecimal(Reader[7]);
					}
					if(Reader[8]!=DBNull.Value)
					{
						info.NewItem.SpecialPrice = Convert.ToDecimal(Reader[8]);
					}
					info.Oper.ID = Reader[9].ToString();
					if(Reader[10]!=DBNull.Value)
					{
						info.Oper.OperTime =Convert.ToDateTime(Reader[10]);
					}
					string ValueState =Reader[11].ToString();
					if(ValueState=="0")
					{
						info.User03= "已生效"; //
					}
					else if(ValueState=="1")
					{
						info.User03 = "未生效";//
					}
					else
					{
						info.User03 ="已作废";
					}

					List.Add(info);
					info = null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				List = null;
			}
			return List;
		}
		/// <summary>
		/// 更新调价明细表 将目前没有生效的变成无效状态
		/// </summary>
		/// <param name="ItemCode">要变更的非药品编码</param>
		/// <returns></returns>
		public int UpdateCAdjustPriceDetail(string ItemCode)
		{
			string strSql ="";
			try
			{
				if (this.Sql.GetSql("Manager.CAdjustPrice.UpdateCAdjustPriceDetail",ref strSql)==-1) return -1;
				string OperCode = this.Operator.ID;
				strSql = string.Format(strSql,ItemCode,OperCode);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
	}
}
