using System;
using System.Collections;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Order
{
    /// <summary>
    /// CurePhase 的摘要说明。
    /// 患者治疗阶段信息管理类
    /// </summary>
    public class CurePhase : Neusoft.FrameWork.Management.Database
    {
        public CurePhase()
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
        /// <param name="curePhase"></param>
        /// <returns></returns>
        private string FormatCurePhaseInfo(string strSql, Neusoft.HISFC.Models.Order.CurePhase curePhase)
        {
            string mySql = "";
            try
            {
                System.Object[] s = {curePhase.PatientID,//住院流水号
									 curePhase.ID,//序列号
									 curePhase.Dept.ID,//科室代码
									 curePhase.Dept.Name,//科室名称
									 curePhase.CurePhaseInfo.ID,//治疗阶段信息编码
									 curePhase.CurePhaseInfo.Name,//治疗阶段信息名称
									 curePhase.StartTime.ToString(),//开始时间
									 curePhase.EndTime.ToString(),//结束时间
									 curePhase.Doctor.ID,//诊断
                                     curePhase.Doctor.Name,//科室名称
                                     Neusoft.FrameWork.Function.NConvert.ToInt32(curePhase.IsVaild).ToString(),//有效性
									 curePhase.Remark,//备注
									 curePhase.Oper.ID,//操作员
									 curePhase.Oper.OperTime.ToString(),//操作日期
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
        private ArrayList myCurePhaseQuery(string strSql)
        {
            ArrayList al = new ArrayList();

            if (this.ExecQuery(strSql) == -1) return null;
            
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Order.CurePhase curePhase = new Neusoft.HISFC.Models.Order.CurePhase();
                    try
                    {
                        curePhase.PatientID = this.Reader[0].ToString();
                        curePhase.ID = this.Reader[1].ToString();//序列号
                        curePhase.Dept.ID = this.Reader[2].ToString();//科室代码
                        curePhase.Dept.Name = this.Reader[3].ToString();//科室名称
                        curePhase.CurePhaseInfo.ID = this.Reader[4].ToString();//治疗阶段信息编码
                        curePhase.CurePhaseInfo.Name = this.Reader[5].ToString();//治疗阶段信息名称
                        curePhase.StartTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());//开始时间
                        curePhase.EndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());//结束时间
                        curePhase.Doctor.ID = this.Reader[8].ToString();//诊断
                        curePhase.Doctor.Name = this.Reader[9].ToString();//科室名称
                        curePhase.IsVaild = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[10].ToString());//有效性
                        curePhase.Remark = this.Reader[11].ToString();//备注
                        curePhase.Oper.ID = this.Reader[12].ToString();//操作员
                        curePhase.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[13].ToString());//操作日期
                    }
                    catch (Exception ex)
                    {
                        this.Err = "获得患者治疗阶段信息出错！" + ex.Message;
                        this.WriteErr();
                        return null;
                    }
                    al.Add(curePhase);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得患者治疗阶段信息出错！" + ex.Message;
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
        /// <param name="curePhase"></param>
        /// <returns></returns>
        public int InsertCurePhase(Neusoft.HISFC.Models.Order.CurePhase curePhase)
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.CurePhase.Insert.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            strSql = this.FormatCurePhaseInfo(strSql, curePhase);
            if (strSql == null)
            {
                this.Err = "格式化Sql语句时出错";
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新治疗阶段信息
        /// </summary>
        /// <param name="curePhase"></param>
        /// <returns></returns>
        public int UpdateCurePhase(Neusoft.HISFC.Models.Order.CurePhase curePhase)
        {
            string strSql = "";

            if (this.Sql.GetSql("Order.CurePhase.Update.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            strSql = this.FormatCurePhaseInfo(strSql, curePhase);
            if (strSql == null)
            {
                this.Err = "格式化Sql语句时出错";
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 取治疗阶段信息序列
        /// </summary>
        /// <returns></returns>
        public string GetNewCurePhaseID()
		{
			string sql = "";
            if (this.Sql.GetSql("Order.CurePhase.GetNewCurePhaseID", ref sql) == -1) return null;
			string strReturn = this.ExecSqlReturnOne(sql);
			if(strReturn == "-1" || strReturn == "") return null;
			return strReturn;
		}

        /// <summary>
        /// 按照住院流水号查询
        /// </summary>
        /// <param name="inPatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryCurePhaseByInPatientNO(string inPatientNO)
        {
            string strSql = "";
            string strSql1 = "";
            ArrayList al = new ArrayList();

            if (this.Sql.GetSql("Order.CurePhase.QueryCurePhase.Select", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            if (this.Sql.GetSql("Order.CurePhase.QueryCurePhase.Where1", ref strSql1) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            strSql = strSql + " " + string.Format(strSql1,inPatientNO);

            return this.myCurePhaseQuery(strSql);
        }

        /// <summary>
        /// 按照序列号查询
        /// </summary>
        /// <param name="seqNO"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Order.CurePhase QuerCurePhaseBySeq(string seqNO)
        {
            string strSql = "";
            string strSql1 = "";
            ArrayList al = new ArrayList();

            if (this.Sql.GetSql("Order.CurePhase.QueryCurePhase.Select", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }

            if (this.Sql.GetSql("Order.CurePhase.QueryCurePhase.Where2", ref strSql1) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSql = strSql + " " + string.Format(strSql1, seqNO);
            }
            catch 
            {
                this.Err = "传入参数不对！";
                return null;
            }
            al = this.myCurePhaseQuery(strSql);
            if (al != null && al.Count > 0)
            {
                return al[0] as Neusoft.HISFC.Models.Order.CurePhase;
            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}
