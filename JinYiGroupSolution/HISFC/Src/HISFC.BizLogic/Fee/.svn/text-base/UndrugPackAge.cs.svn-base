using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// undrugztinfo 的摘要说明。
	/// </summary>
	public class UndrugPackAge: Neusoft.FrameWork.Management.Database 
	{
		
		/// <summary>
		/// 非药品组套明细表 
		/// </summary>
		/// <param name="packageCode"></param>
		/// <returns></returns>
		public ArrayList QueryUndrugPackagesBypackageCode(string packageCode)
		{
			ArrayList List = null;
			string strSql = "";
			if (this.Sql.GetSql("Fee.undrugzt.GetUndrugztinfo",ref strSql)==-1) return null;
			try
			{
				if(packageCode!="")
				{
					List = new ArrayList();
					
					strSql = string.Format(strSql,packageCode);
					this.ExecQuery(strSql);
					Neusoft.HISFC.Models.Fee.Item.UndrugComb info = null;
					while(this.Reader.Read())
					{
                        info = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();

						info.Package.ID = Reader[0].ToString(); //组套编码
						info.Name = Reader[1].ToString();//非药品名称
						info.ID =Reader[2].ToString();  //非药品编码
						if(Reader[3]!=DBNull.Value)
						{
							info.SortID =Convert.ToInt32(Reader[3]); //顺序号
						}
						else
						{
							info.SortID = 0;
						}
						info.SpellCode = Reader[4].ToString();  //取拼音码
						info.WBCode = Reader[5].ToString();    //取五笔码
						info.UserCode = Reader[6].ToString(); //输入码
						info.User01 =Reader[7].ToString(); //标志
						info.User02 = Reader[8].ToString(); // 是否特殊医疗项目 0 否 1 是
						info.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[9].ToString()); //数量
						List.Add(info);
						info = null;
					}
					this.Reader.Close();
				}
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				List = null;
			}
			return List;
		}
		/// <summary>
		/// 更新一条记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int UpdateUndrugztinfo(Neusoft.HISFC.Models.Fee.Item.UndrugComb info )
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.undrugzt.UpdateUndrugztinfo",ref strSql)==-1)return -1;
			try
			{
				// update fin_com_undrugztinfo set SORT_ID='{2}' where  PACKAGE_CODE ='{0}'and ITEM_CODE ='{1}' and parent_code = '[父级编码]' and current_code ='[本级编码]'
				strSql = string.Format(strSql,info.Package.ID,info.ID,info.SortID,info.SpellCode,info.WBCode,info.UserCode,info.User01,info.Qty);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 删除一条新的记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int DeleteUndrugztinfo(Neusoft.HISFC.Models.Fee.Item.UndrugComb info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.undrugzt.DeleteUndrugztinfo",ref strSql)==-1)return -1;
			try
			{
				// delete  fin_com_undrugztinfo  where PACKAGE_CODE = '{0}' and ITEM_CODE ='{1}' and parent_code = '[父级编码]' and current_code ='[本级编码]'
				strSql = string.Format(strSql,info.Package.ID,info.ID);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 插入一条新的记录
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int InsertUndruaztinfo(Neusoft.HISFC.Models.Fee.Item.UndrugComb info)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.undrugzt.InsertUndruaztinfo",ref strSql)==-1)return -1;
			try
			{
				string OperId = this.Operator.ID;
				// insert into fin_com_undrugztinfo  (PACKAGE_CODE,ITEM_CODE,SORT_ID,OPER_CODE,OPER_DATE) values ('{0},'{1}','{2}','{3}',sysdate)
				strSql = string.Format(strSql,info.Package.ID,info.ID,info.SortID,OperId,info.SpellCode,info.WBCode,info.UserCode,info.User01,info.Qty);
			}
			catch(Exception ee)
			{
				this.Err = ee.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}
        /// <summary>
        /// 获取复合项目的总价格
        /// </summary>
        /// <param name="ztID">复合项目编码</param>
        /// <returns></returns>
        public decimal GetUndrugCombPrice(string ztID)
        {
            decimal Price = 0;
            string sql = "";
            if (this.Sql.GetSql("Fee.undrugzt.GetUndrugztPrice", ref sql) == -1) return -1;
            try
            {
                sql = string.Format(sql, ztID);
                if (this.ExecQuery(sql) == -1) return -1;
                while (this.Reader.Read())
                {
                    Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.ErrCode = ee.Message;
                if (this.Reader.IsClosed == false) this.Reader.Close();
                return -1;
            }

            return Price;
        }
	}
}
