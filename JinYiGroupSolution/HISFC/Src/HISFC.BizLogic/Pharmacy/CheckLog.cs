using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Neusoft.HISFC.Models.Pharmacy;

namespace Neusoft.HISFC.BizLogic.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品盘点日志相关管理类]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2010-05]<br></br>
    /// <修改记录>
    ///     
    /// </修改记录>
    /// </summary>
    public class CheckLog : Neusoft.FrameWork.Management.Database
    {
        #region 私有方法

        /// <summary>
        /// 更新单表操作
        /// </summary>
        /// <param name="sqlIndex">SQL语句索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: >= 1 失败 -1 没有更新到数据 0</returns>
        private int UpdateSingleTable(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, args);
        }
        
        /// <summary>
        /// 获得insert日志传入数组
        /// </summary>
        /// <param name="check">盘点信息实体</param>
        /// <returns>成功盘点信息字符串数组</returns>
        private string[] GetParmForCheckLogs(Check check)
        {
            string[] parm = {
                             check.CheckNO,		    //0 盘点单号
							 check.StockDept.ID,	    //1 库房编码 0 为全部部门
							 check.Item.ID,			//2 药品编码
							 check.BatchNO,			//3 批号
							 check.Item.Name,		//4 商品名称
							 check.Item.Specs,		//5 药品规格
							 check.Item.PriceCollection.RetailPrice.ToString(),	//6 零售价
							 check.Item.PackUnit,				//7 包装单位
							 check.Item.PackQty.ToString(),		//8 包装数量
							 check.AdjustQty.ToString(),			//9 实际盘存数量
							 check.Item.MinUnit,					//10 最小单位
							 check.PlaceNO,					    //11 货位号
                             check.Memo,                         //12 备注
							 check.Operation.Oper.ID,			//13 操作员
							 check.Operation.Oper.OperTime.ToString()			//14 操作时间		
							};
            return parm;
        }

        /// <summary>
        /// 根据索引和参数查询盘点日志记录
        /// </summary>
        /// <param name="index">sql语句索引</param>
        /// <param name="parms">参数</param>
        /// <returns>成功 盘点相关日志结合, 失败null</returns>
        private ArrayList QueryCheckLogsByIndex(string index, params string[] parms)
        {
            string sql = string.Empty;//SELECT语句
            
            //获得Sql语句
            if (this.Sql.GetSql(index, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + index + "的SQL语句";

                return null;
            }
            
            ArrayList logLists = new ArrayList();
            if (this.ExecQuery(sql, parms) == -1)
            {
                this.Err = "查询盘点日志失败，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";

                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Check check = new Check();

                    check.CheckNO = this.Reader[0].ToString();//药品代码
                    check.FOper.Dept.ID = this.Reader[1].ToString();//科室
                    check.Item.ID = this.Reader[2].ToString();
                    check.BatchNO = this.Reader[3].ToString();
                    check.Item.Name = this.Reader[4].ToString();
                    check.Item.Specs = this.Reader[5].ToString();
                    check.Item.PriceCollection.RetailPrice = Convert.ToDecimal(this.Reader[6].ToString());
                    check.Item.PackUnit = this.Reader[7].ToString();
                    check.Item.PackQty = Convert.ToDecimal(this.Reader[8].ToString());
                    check.AdjustQty = Convert.ToDecimal(this.Reader[9].ToString());
                    check.Item.MinUnit = this.Reader[10].ToString();
                    check.PlaceNO = this.Reader[11].ToString();
                    check.Memo = this.Reader[12].ToString();
                    check.Operation.Oper.ID = this.Reader[13].ToString();
                    check.Operation.Oper.OperTime = Convert.ToDateTime(this.Reader[14].ToString());
                    check.Operation.Oper.Name = this.Reader[15].ToString();

                    logLists.Add(check);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询盘点日志时出错！" + ex.Message;
                this.ErrCode = "-1";

                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return logLists;
        }

        #endregion

        #region 共有方法

        #region 生成盘点日志

        /// <summary>
        /// 插入盘点日志
        /// </summary>
        /// <param name="check">盘点信息实体</param>
        /// <returns>成功 1 失败 -1</returns>
        public int InsertCheckLogs(Check check)
        {
            return this.UpdateSingleTable("Pharmacy.Item.UpdateCheckDetail.InsertLogs", this.GetParmForCheckLogs(check));
        }

        #endregion

        #region 相关查询

        /// <summary>
        /// 查询盘点日志
        /// </summary>
        /// <param name="deptCode">科室代码</param>
        /// <param name="checkNo">盘点单号,"ALL"代表所有</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功 盘点相关日志结合, 失败null</returns>
        public ArrayList QueryCheckLogs(string deptCode, string checkNo, string beginTime, string endTime)
        {
            return this.QueryCheckLogsByIndex("Pharmacy.Item.UpdateCheckDetail.QueryLogs", deptCode, checkNo, beginTime.ToString(), endTime.ToString());
        }

        #endregion

        #endregion
    }
}
