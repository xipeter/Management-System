using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.Order
{
    /// <summary>
    /// 
    /// 医嘱药品限制管理类
    /// </summary>
    public class SpecialLimit : Neusoft.FrameWork.Management.Database
    {
        public SpecialLimit()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 私有方法

        /// <summary>
        /// 格式化SQL语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="pharmacyLimit"></param>
        /// <returns></returns>
        private string FormatPharcamyLimit(string strSql, Neusoft.HISFC.Models.Order.PharmacyLimit pharmacyLimit)
        {
            string mySql = "";
            try
            {
                System.Object[] s = {pharmacyLimit.ID,//住院流水号
									 Neusoft.FrameWork.Function.NConvert.ToInt32(pharmacyLimit.IsLeaderCheck).ToString(),//序列号
									 Neusoft.FrameWork.Function.NConvert.ToInt32(pharmacyLimit.IsNeedRecipe).ToString(),//科室代码
                                     Neusoft.FrameWork.Function.NConvert.ToInt32(pharmacyLimit.IsValid).ToString(),//有效性
									 pharmacyLimit.Remark,//备注
									 pharmacyLimit.Oper.ID,//操作员
									 pharmacyLimit.Oper.OperTime.ToString(),//操作日期
									};
                string myErr = "";
                if (Neusoft.FrameWork.Public.String.CheckObject(out myErr, s) == -1)
                {
                    this.Err = myErr;
                    this.WriteErr();
                    return null;
                }
                mySql = string.Format(strSql, s);
            }
            catch (System.Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return null;
            }
            return mySql;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList myPharmacyLimitQuery(string strSql)
        {
            ArrayList al = new ArrayList();

            if (this.ExecQuery(strSql) == -1) return null;
            
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Order.PharmacyLimit obj = new Neusoft.HISFC.Models.Order.PharmacyLimit();
                    try
                    {
                        obj.ID = this.Reader[0].ToString();
                        obj.IsLeaderCheck = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[1].ToString());
                        obj.IsNeedRecipe = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[2].ToString());
                        obj.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());//有效性
                        obj.Remark = this.Reader[4].ToString();//备注
                        obj.Oper.ID = this.Reader[5].ToString();//操作员
                        obj.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//操作日期
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得医嘱药品限制信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    al.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得医嘱药品限制信息出错！" + ex.Message;
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        #endregion

        #region 公有方法
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="pharmacyLimit"></param>
        /// <returns></returns>
        public int InsertSpecialLimit(Neusoft.HISFC.Models.Order.PharmacyLimit pharmacyLimit)
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.SpecialLimit.Insert.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            strSql = this.FormatPharcamyLimit(strSql, pharmacyLimit);
            if (strSql == null)
            {
                this.Err = "格式化Sql语句时出错";
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="pharmacyLimit"></param>
        /// <returns></returns>
        public int UpdateSpecialLimit(Neusoft.HISFC.Models.Order.PharmacyLimit pharmacyLimit)
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.SpecialLimit.Update.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            strSql = this.FormatPharcamyLimit(strSql, pharmacyLimit);
            if (strSql == null)
            {
                this.Err = "格式化Sql语句时出错";
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pharmacyID"></param>
        /// <returns></returns>
        public int DeleteSpecialLimitByID(string pharmacyID)
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.SpecialLimit.Delete.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, pharmacyID);
            }
            catch
            {
                this.Err = "传入参数不对！";
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryPharmacyLimit()
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.SpecialLimit.Select.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            return this.myPharmacyLimitQuery(strSql);
        }

        /// <summary>
        /// 查询一条
        /// </summary>
        /// <param name="pharmacyID"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.PharmacyLimit QueryPharmacyLimitByID(string pharmacyID)
        {
            string strSql = "";
            string strSql1 = "";
            ArrayList al = new ArrayList();

            if (this.Sql.GetSql("Order.SpecialLimit.Select.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            if (this.Sql.GetSql("Order.SpecialLimit.Where.1", ref strSql1) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSql = strSql + " " + string.Format(strSql1, pharmacyID);
            }
            catch
            {
                this.Err = "传入参数不对！";
                return null;
            }
            al = this.myPharmacyLimitQuery(strSql);
            if (al != null && al.Count > 0)
            {
                return al[0] as Neusoft.HISFC.Models.Order.PharmacyLimit;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询有效数据
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryValid()
        {
            string strSql = "";
            string strSql1 = "";
            ArrayList al = new ArrayList();

            if (this.Sql.GetSql("Order.SpecialLimit.Select.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            if (this.Sql.GetSql("Order.SpecialLimit.Where.2", ref strSql1) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSql = strSql + " " + strSql1;
            }
            catch
            {
                this.Err = "传入参数不对！";
                return null;
            }

            return this.myPharmacyLimitQuery(strSql);
        }

        #endregion

    }
}
