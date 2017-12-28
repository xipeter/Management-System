using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// PactUnitItemRate 的摘要说明。
	/// </summary>
	public class PactUnitItemRate:  Neusoft.FrameWork.Management.Database
	{
		
		/// <summary>
		/// 
		/// </summary>
		public PactUnitItemRate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 查询数据库，得到某合同单位下的最小费用/项目
		/// pact_code 是合同单位编码，index 为0 表示查的是最小费用，为1表示查的是项目
		/// </summary>
		/// <returns></returns>
		public ArrayList GetPactUnitItemRate(string pact_code,int index)
		{
			string strSql = "";
			if(index ==0)
			{
                if (this.Sql.GetSql("Fee.PactUnitItemRate.GetPactUnitItemRate", ref strSql) == -1) return null;
				strSql = string.Format(strSql,pact_code);
			}
			else
			{
                if (this.Sql.GetSql("Fee.PactUnitItemRate.GetPactUnitItemRate2", ref strSql) == -1) return null;
				strSql = string.Format(strSql,pact_code);
			}
			System.Collections.ArrayList list = new System.Collections.ArrayList();
			try
			{
				this.ExecQuery(strSql);
				while(this.Reader.Read())
				{
					Neusoft.HISFC.Models.Base.PactItemRate info = new Neusoft.HISFC.Models.Base.PactItemRate();
					//合同代码
					info.ID = Reader[0].ToString();
					//名称 (最小费用或项目名称)Item.Name
					info.PactItem.Name = Reader[1].ToString();
					//类别  int ItemType
					info.ItemType = Reader[2].ToString();
					//公费比例 float PubRate
					info.Rate.PubRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[3].ToString());
					//自费比例 float OwnRate
                    info.Rate.OwnRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[4].ToString());
					//自付比例 float PayRate
                    info.Rate.PayRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[5].ToString());
                    //减免比例 float RebateRate   {1C0DA8D4-50FF-4097-B29F-C6CB21595A1B}
                    info.Rate.RebateRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[6].ToString());
					//欠费比例 float ArrearageRate
                    info.Rate.ArrearageRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[7].ToString());
					//编码（最小费用或项目代码）Item.id
					info.PactItem.ID = Reader[8].ToString();
					//添加到数组中
					list.Add(info);
					info = null;
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				list = null;
			}
			return list;
		}
/// <summary>
/// 
/// </summary>
/// <param name="pact_code"></param>
/// <param name="ItemOrMincode"></param>
/// <param name="index"></param>
/// <returns></returns>
		private  Neusoft.HISFC.Models.Base.PactItemRate   GetOnePactUnitItemRate(string pact_code,string ItemOrMincode,int index)
		{
			string strSql = "";
			Neusoft.HISFC.Models.Base.PactItemRate info =null;
			if(index ==0)
			{
                if (this.Sql.GetSql("Fee.PactUnitItemRate.GetOnePactUnitItemRate", ref strSql) == -1) return null;
				strSql = string.Format(strSql,pact_code,ItemOrMincode);
			}
			else
			{
                if (this.Sql.GetSql("Fee.PactUnitItemRate.GetOnePactUnitItemRate2", ref strSql) == -1) return null;
				strSql = string.Format(strSql,pact_code,ItemOrMincode);
			}
			try
			{
				if(this.ExecQuery(strSql)==-1) return null;
				if (this.Reader.Read())
				{
					info = new Neusoft.HISFC.Models.Base.PactItemRate();
					//合同代码
					info.ID = Reader[0].ToString();
					//名称 (最小费用或项目名称)Item.Name
					info.PactItem.Name = Reader[1].ToString();
					//类别  int ItemType
					info.ItemType = Reader[2].ToString();
					//公费比例 float PubRate
					info.Rate.PubRate = Convert.ToDecimal(Reader[3].ToString());
					//自费比例 float OwnRate
					info.Rate.OwnRate = Convert.ToDecimal(Reader[4].ToString());
					//自付比例 float PayRate
					info.Rate.PayRate = Convert.ToDecimal(Reader[5].ToString());
                    //优惠比例 float RebateRate   {1C0DA8D4-50FF-4097-B29F-C6CB21595A1B}
					info.Rate.RebateRate = Convert.ToDecimal(Reader[6].ToString());
					//欠费比例 float ArrearageRate
					info.Rate.ArrearageRate = Convert.ToDecimal(Reader[7].ToString());
					//编码（最小费用或项目代码）Item.id
					info.PactItem.ID = Reader[8].ToString();
				}
				this.Reader.Close();
			}
			catch(Exception ee)
			{
				this.Err= ee.Message;
				info = null;
			}
			return info ;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pact_code"></param>
		/// <param name="Item"></param>
		/// <returns></returns>
		public Neusoft.HISFC.Models.Base.PactItemRate GetOnepPactUnitItemRateByItem(string pact_code,string Item)
		{
			return GetOnePactUnitItemRate(pact_code,Item,1);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pact_code"></param>
		/// <param name="FeeCode"></param>
		/// <returns></returns>
		public  Neusoft.HISFC.Models.Base.PactItemRate GetOnePaceUnitItemRateByFeeCode(string pact_code,string FeeCode)
		{
			return GetOnePactUnitItemRate(pact_code,FeeCode,0);
		}
		/// <summary>
		/// 更新数据库中的值
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int  UpdatePactUnitItemRate(Neusoft.HISFC.Models.Base.PactItemRate info )
		{
			string strSql = "";
            if (this.Sql.GetSql("Fee.PactUnitItemRate.UpdatePactUnitItemRate", ref strSql) == -1) return -1;
			try
			{
                //{1C0DA8D4-50FF-4097-B29F-C6CB21595A1B}
				strSql = string.Format(strSql,info.ID,info.ItemType,info.PactItem.ID,info.Rate.PubRate,info.Rate.OwnRate,info.Rate.PayRate,info.Rate.RebateRate,info.Rate.ArrearageRate);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			//返回更新结果
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 向数据库中插如新的数据行
		/// </summary>
		/// <returns></returns>
		public int InsertPactUnitItemRate(Neusoft.HISFC.Models.Base.PactItemRate info )
		{
			string strSql = "";
			string  OPER_CODE = this.Operator.ID;
            if (this.Sql.GetSql("Fee.PactUnitItemRate.InsertPactUnitItemRate", ref strSql) == -1) return -1;
			try
			{
                //{1C0DA8D4-50FF-4097-B29F-C6CB21595A1B}
				strSql = string.Format(strSql,info.ID,info.ItemType,info.PactItem.ID,info.Rate.PubRate,info.Rate.OwnRate,info.Rate.PayRate,info.Rate.RebateRate,info.Rate.ArrearageRate,OPER_CODE);
			}
			catch(Exception ee)
			{
				this.Err  = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="info"></param>
	/// <returns></returns>
		public int DeletePactUnitItemRate(Neusoft.HISFC.Models.Base.PactItemRate info)
		{
			string strSql = "";
            if (this.Sql.GetSql("Fee.PactUnitItemRate.DeletePactUnitItemRate", ref strSql) == -1) return -1;

			try
			{
				//0领取时间1领取人
				strSql = string.Format(strSql,info.ID,info.PactItem.ID);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
	}
}
