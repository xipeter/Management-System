using System;
using System.Collections;
using System.Data;
using Neusoft.HISFC.Models.Fee.Item;
using Neusoft.FrameWork.Function;
using System.Collections.Generic;

namespace Neusoft.Report.Finance.FinIpb
{
    public class sql : Neusoft.FrameWork.Management.Database 
    {
        /// <summary>
        /// 按照统计大类获取各项费用
        /// </summary>
        public static string GetKindFeeSql = @"SELECT SUM(t1.pub_cost + t1.own_cost + t1.pay_cost) AS tot_cost,
t2.fee_stat_name,
t2.fee_stat_cate
FROM fin_ipb_feeinfo t1, fin_com_feecodestat t2
WHERE t1.fee_code = t2.fee_code
and
t1.fee_date between to_date('{0}','yyyy-mm-dd hh24:mi:ss') and  to_date('{1}','yyyy-mm-dd hh24:mi:ss')
and t2.report_code = '{2}'
GROUP BY t2.fee_stat_name,t2.fee_stat_cate
ORDER BY t2.fee_stat_name
 ";
        /// <summary>
        /// 获取住院患者的项目信息，包括药品和非药品
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ArrayList GetItemList(string InpatientNo, string beginTime, string endTime)
        {
            string sql = string.Empty;
            if (Sql.GetSql("WinForms.Report.Finance.FinIpb.ucFinIpbPatientDayFee2.2", ref sql) == -1)
            {
                return null;
            }
            sql = " " + string.Format(sql,InpatientNo, beginTime, endTime);
            ArrayList items = new ArrayList(); //用于返回非药品信息的数组
			
			//执行当前Sql语句
			if (this.ExecQuery(sql) == -1)
			{
				this.Err = this.Sql.Err;

				return null;
			}

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    Undrug item = new Undrug();

                    item.ID = this.Reader[0].ToString();//非药品编码 
                    item.Name = this.Reader[1].ToString(); //非药品名称 
                    item.Specs = this.Reader[2].ToString(); //规格
                    item.Qty = NConvert.ToDecimal(this.Reader[3].ToString());//数量
                    item.PriceUnit = this.Reader[4].ToString();//单位
                    item.Price = NConvert.ToDecimal(this.Reader[5].ToString()); //默认价代替总额(为了方便)

                    items.Add(item);
                }//循环结束

				//关闭Reader
				this.Reader.Close();
				
				return items;
            }
            catch (Exception e)
            {
                this.Err = "获得项目基本信息出错！" + e.Message;
                this.WriteErr();

                //如果还没有关闭Reader 关闭之
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                items = null;

                return null;
            }	
        }

        public ArrayList GetMinFeeList(string InpatientNo, string beginTime, string endTime)
        {
            string sql = string.Empty;
            if (Sql.GetSql("WinForms.Report.Finance.FinIpb.ucFinIpbPatientDayFee2.1", ref sql) == -1)
            {
                return null;
            }
            sql = " " + string.Format(sql,InpatientNo, beginTime, endTime);
            ArrayList minFees = new ArrayList(); //用于最小费用金额信息的数组

            //执行当前Sql语句
            if (this.ExecQuery(sql) == -1)
            {
                this.Err = this.Sql.Err;

                return null;
            }

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj=new Neusoft.FrameWork.Models.NeuObject ();
                    obj.ID = this.Reader[0].ToString(); //最小费用名字
                    obj.Memo = this.Reader[1].ToString(); //该最小费用对应的金额

                    minFees.Add(obj);
                }//循环结束

                //关闭Reader
                this.Reader.Close();

                return minFees;
            }
            catch (Exception e)
            {
                this.Err = "获得项目基本信息出错！" + e.Message;
                this.WriteErr();

                //如果还没有关闭Reader 关闭之
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }

                minFees = null;

                return null;
            }
        }
        public int GetKindFee(string begin_time, string end_time, string report_id,ref DataSet ds) {
            string sql = string.Empty;
            try
            {
                sql = GetKindFeeSql;
                sql = string.Format(sql, begin_time, end_time, report_id);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL出错";
                return -1;
            }
            int rev = this.ExecQuery(sql, ref ds);
            if (rev == -1) {
                this.Err = "执行SQl出错";
                return -1;
            }
            return 1;
        }
    }
}
