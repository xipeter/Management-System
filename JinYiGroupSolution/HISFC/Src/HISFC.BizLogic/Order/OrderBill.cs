using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Order
{
    public class OrderBill : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 医嘱打印管理类
        /// </summary>
        public OrderBill()
        {
            //
			// TODO: 在此处添加构造函数逻辑
			//
        }

        /// <summary>
        /// 插入医嘱打印信息
        /// </summary>
        /// <param name="orderBill"></param>
        /// <returns></returns>
        public int InsertOrderBill(Neusoft.HISFC.Models.Order.OrderBill orderBill)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.InsertOderBill", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            System.Object[] s = {
									orderBill.Order.Patient.ID,
									orderBill.PrintSequence,
									orderBill.Order.ID ,
									orderBill.PageNO ,
									orderBill.LineNO ,
									Neusoft.FrameWork.Function.NConvert.ToInt32(orderBill.Order.OrderType.IsDecompose) ,
									orderBill.PrintFlag ,
									orderBill.Order.Combo.ID ,
									orderBill.PrintDCFlag ,
									orderBill.Oper.ID ,
									orderBill.Oper.OperTime  				 	
								};
            try
            {
                strSql = string.Format(strSql, s);

            }
            catch
            {
                this.Err = "sql格式化错误";
                return -1;
            }

            return this.ExecNoQuery(strSql);

        }


        /// <summary>
        /// 获得医嘱打印信息
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="prnFlag">打印标志（0未打印，1已打印）</param>
        /// <returns>医嘱打印信息</returns>
        public ArrayList GetOrderBill(string inpatientNo, string prnFlag)
        {
            ArrayList al = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.GetOderBill", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo, prnFlag);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获得医嘱打印信息" + this.Err;
                return null;
            }
            Neusoft.HISFC.Models.Order.OrderBill orderBill;
            try
            {
                while (this.Reader.Read())
                {
                    try
                    {
                        orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                        orderBill.Order.Patient.ID = this.Reader[0].ToString();
                        orderBill.PrintSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());
                        orderBill.Order.ID = this.Reader[2].ToString();
                        orderBill.PageNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString());
                        orderBill.LineNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());
                        orderBill.Order.OrderType.ID = this.Reader[5].ToString();
                        orderBill.PrintFlag = this.Reader[6].ToString();
                        orderBill.Order.Combo.ID = this.Reader[7].ToString();
                        orderBill.PrintDCFlag = this.Reader[8].ToString();
                        orderBill.Oper.ID = this.Reader[9].ToString();
                        orderBill.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得医嘱打印信息出错" + ex.Message;
                        this.Reader.Close();
                        return null;
                    }
                    al.Add(orderBill);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得医嘱打印信息出错" + ex.Message;
                this.Reader.Close();
                return null;
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 获得医嘱打印信息
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="prnFlag">打印标志（0未打印，1已打印）</param>
        /// <param name="pageNo">页码</param>
        /// <returns>医嘱打印信息</returns>
        public ArrayList GetOrderBill(string inpatientNo, string prnFlag, int pageNo)
        {
            ArrayList al = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.GetOderBill.pageNo", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo, prnFlag, pageNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获得医嘱打印信息" + this.Err;
                return null;
            }
            Neusoft.HISFC.Models.Order.OrderBill orderBill;
            try
            {
                while (this.Reader.Read())
                {
                    try
                    {
                        orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                        orderBill.Order.Patient.ID = this.Reader[0].ToString();
                        orderBill.PrintSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());
                        orderBill.Order.ID = this.Reader[2].ToString();
                        orderBill.PageNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString());
                        orderBill.LineNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());
                        orderBill.Order.OrderType.ID = this.Reader[5].ToString();
                        orderBill.PrintFlag = this.Reader[6].ToString();
                        orderBill.Order.Combo.ID = this.Reader[7].ToString();
                        orderBill.PrintDCFlag = this.Reader[8].ToString();
                        orderBill.Oper.ID = this.Reader[9].ToString();
                        orderBill.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得医嘱打印信息出错" + ex.Message;
                        this.Reader.Close();
                        return null;
                    }
                    al.Add(orderBill);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得医嘱打印信息出错" + ex.Message;
                this.Reader.Close();
                return null;
            }
            this.Reader.Close();
            return al;
        }


        /// <summary>
        /// 获得已打印医嘱
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns>打印信息</returns>
        public ArrayList GetPrnOrderBill(string inpatientNo)
        {
            return this.GetOrderBill(inpatientNo, "1");

        }


        /// <summary>
        /// 获得未打印医嘱
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns>打印信息</returns>
        public ArrayList GetUnPrnOrderBill(string inpatientNo)
        {
            return this.GetOrderBill(inpatientNo, "0");
        }

        /// <summary>
        /// 获取患者已打印医嘱单的最大序号,页码,行号
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="orderType">0临时医嘱1长期医嘱</param>
        /// <param name="orderSeq"></param>
        /// <param name="orderPageNO"></param>
        /// <param name="orderLineNO"></param>
        /// <returns></returns>
        public int GetLastOrderBillArg(string inpatientNO, string orderType, out int orderSeq, out int orderPageNO, out int orderLineNO)
        {
            orderSeq = 0;
            orderPageNO = 1;
            orderLineNO = 0;
            //先获取最大序号页码,然后再获取最大页码上的最大行号
            string strSql1 = "";
            string strSql2 = "";
            if (this.Sql.GetSql("Order.OrderBill.GetLastOrderBillArg.1", ref strSql1) == -1)
            {
                this.Err = "Can not find the Sql Order.OrderBill.GetLastOrderBillArg.1";
                return -1;
            }
            if (this.Sql.GetSql("Order.OrderBill.GetLastOrderBillArg.2", ref strSql2) == -1)
            {
                this.Err = "Can not find the Sql Order.OrderBill.GetLastOrderBillArg.1";
                return -1;
            }
            try
            {
                strSql1 = string.Format(strSql1, inpatientNO, orderType);
                this.ExecQuery(strSql1);
                while (this.Reader.Read())
                {
                    orderSeq = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1]);
                    orderPageNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0]);
                }
                //this.Reader.Close();
                if (orderPageNO > 0)
                {
                    strSql2 = string.Format(strSql2, inpatientNO, orderPageNO, orderType);
                    this.ExecQuery(strSql2);
                    while (this.Reader.Read())
                    {
                        orderLineNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0]);
                    }
                    this.Reader.Close();
                }
                else
                {
                    orderLineNO = 0;
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 更新医嘱是否打印
        /// </summary>
        /// <param name="OrderNo">医嘱流水号</param>
        /// <param name="prnFlag">打印标志（0未打印，1已打印）</param>
        /// <returns></returns>
        public int UpdatePrnFlag(string OrderNo, string prnFlag)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.SetOderBillPrn", ref strSql) == -1)
            {
                this.Err = "获得sql语句出错" + this.Sql.Err + this.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, OrderNo, prnFlag);
            }
            catch
            {
                this.Err = "sql语句格式化错误" + this.Err;
                return -1;
            }
            return this.ExecNoQuery(strSql);

        }
        /// <summary>
        /// 更新医嘱是否打印
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="prnFlag"></param>
        /// <param name="Seq"></param>
        /// <param name="pageNO"></param>
        /// <param name="lineNO"></param>
        /// <returns></returns>
        public int UpdatePrnFlag(string OrderNo, string prnFlag, int Seq, int pageNO, int lineNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.UpdatePrnFlag", ref strSql) == -1)
            {
                this.Err = "获得sql语句出错" + this.Sql.Err + this.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, OrderNo, prnFlag, Seq, pageNO, lineNO);
            }
            catch
            {
                this.Err = "sql语句格式化错误" + this.Err;
                return -1;
            }
            return this.ExecNoQuery(strSql);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="orderBill"></param>
        /// <returns></returns>
        public int UpdateOderBill(string OrderNo, Neusoft.HISFC.Models.Order.OrderBill orderBill)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.UpdateOderBill", ref strSql) == -1)
            {
                this.Err = "获得sql语句出错" + this.Sql.Err + this.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, OrderNo, orderBill.PrintFlag, orderBill.PrintSequence, orderBill.PageNO, orderBill.LineNO);
            }
            catch
            {
                this.Err = "sql语句格式化错误" + this.Err;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新医嘱单打印行号和页码
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="lineNo"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public int UpdateLineNoPageNo(string orderID, int lineNo,int pageNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.UpdatePrnLinePage", ref strSql) == -1)
            {
                this.Err = "获得sql语句出错" + this.Sql.Err + this.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, orderID, pageNo.ToString(), lineNo.ToString());
            }
            catch
            {
                this.Err = "sql语句格式化错误" + this.Err;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新医嘱是否停止
        /// </summary>
        /// <param name="OrderNo">医嘱流水号</param>
        /// <param name="stopFlag">停止标志（0未停止，1已停止）</param>
        /// <returns></returns>
        public int UpdateStopFlag(string OrderNo, string stopFlag)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.SetOderBillStop", ref strSql) == -1)
            {
                this.Err = "获得sql语句出错" + this.Sql.Err + this.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, OrderNo, stopFlag);
            }
            catch
            {
                this.Err = "sql语句格式化错误" + this.Err;
                return -1;
            }
            
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 查询一条医嘱单打印信息
        /// </summary>
        /// <param name="orderID">医嘱流水号</param>
        /// <returns>OrderBill</returns>
        public Neusoft.HISFC.Models.Order.OrderBill GetOrderBillByOrderID(string orderID)
        {
            ArrayList al = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.GetOrderBillByOrderID", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSql = string.Format(strSql, orderID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获得医嘱打印信息" + this.Err;
                return null;
            }
            Neusoft.HISFC.Models.Order.OrderBill orderBill;
            try
            {
                while (this.Reader.Read())
                {
                    try
                    {
                        orderBill = new Neusoft.HISFC.Models.Order.OrderBill();
                        orderBill.Order.Patient.ID = this.Reader[0].ToString();
                        orderBill.PrintSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());
                        orderBill.Order.ID = this.Reader[2].ToString();
                        orderBill.PageNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[3].ToString());
                        orderBill.LineNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[4].ToString());
                        orderBill.Order.OrderType.ID = this.Reader[5].ToString();
                        orderBill.PrintFlag = this.Reader[6].ToString();
                        orderBill.Order.Combo.ID = this.Reader[7].ToString();
                        orderBill.PrintDCFlag = this.Reader[8].ToString();
                        orderBill.Oper.ID = this.Reader[9].ToString();
                        orderBill.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得医嘱打印信息出错" + ex.Message;
                        this.Reader.Close();
                        return null;
                    }
                    al.Add(orderBill);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得医嘱打印信息出错" + ex.Message;
                this.Reader.Close();
                return null;
            }
            this.Reader.Close();
            if (al.Count == 0) return null;
            
            return al[0] as Neusoft.HISFC.Models.Order.OrderBill;
        }
        /// <summary>
        /// 更新医嘱是否停止
        /// </summary>
        /// <param name="OrderNo">医嘱流水号</param>
        /// <param name="stopFlag">停止标志（0未停止，1已停止）</param>
        /// <returns></returns>
        public int UpdatePrinStopFlag(string OrderNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Order.OrderPrn.SetOderBillPrintStop", ref strSql) == -1)
            {
                this.Err = "获得sql语句出错" + this.Sql.Err + this.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, OrderNo, "1");
            }
            catch
            {
                this.Err = "sql语句格式化错误" + this.Err;
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

    }
}
