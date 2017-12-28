using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Neusoft.WinForms.Report.Finance.FinOpb.FinRegPatientInfo
{
    public class BizLogicFeeOutPatient : Neusoft.FrameWork.Management.Database
    {
        #region 根据病历号获取挂号记录
        /// <summary>
        /// 根据病历号获取挂号记录
        /// [参数1: string QueryString - 查询条件值]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: QueryType queryType - 查询方式]
        /// [参数4: OperateType operateType - 是否模糊查询]
        /// [参数5: bool boolRegisterDate - 是否有时间限制]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="QueryString">查询条件值</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="queryType">查询方式</param>
        /// <param name="operateType">是否模糊查询</param>
        /// <param name="boolRegisterDate">是否有时间限制</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterList(string QueryString, ArrayList alRegister, ucRegInfoQuery.QueryType queryType, ucRegInfoQuery.OperateType operateType, bool boolRegisterDate, DateTime dtFrom, DateTime dtTo)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // OTHERWHERE语句
            string OTHERWHERE = "";
            // SQL语句
            string SQL = "";

            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Select", ref SELECT);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Select失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (operateType.Equals(ucRegInfoQuery.OperateType.LikeQuery))
            {
                switch (queryType)
                {
                    case ucRegInfoQuery.QueryType.CardCode: intReturn = this.Sql.GetSql("Registration.Register.Query.ByCardCode.Like", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByCardCode.Like失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.PatientName: intReturn = this.Sql.GetSql("Registration.Register.Query.ByPatientName.Like", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByPatientName.Like失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.PactCode: intReturn = this.Sql.GetSql("Registration.Register.Query.ByPactCode.Like", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByPactCode.Like失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.SeeDepartment: intReturn = this.Sql.GetSql("Registration.Register.Query.BySeeDepartment.Like", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.BySeeDepartment.Like失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.SeeDoctor: intReturn = this.Sql.GetSql("Registration.Register.Query.BySeeDoctor.Like", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.BySeeDoctor.Like失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.MedicareCode: intReturn = this.Sql.GetSql("Registration.Register.Query.ByMedicareCode.Like", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByMedicareCode.Like失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.InvoiceCode: intReturn = this.Sql.GetSql("Registration.Register.Query.ByInvoiceCode.Like", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByInvoiceCode.Like失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;
                }
            }
            else
            {
                switch (queryType)
                {
                    case ucRegInfoQuery.QueryType.CardCode:
                        intReturn = this.Sql.GetSql("Registration.Register.Query.ByCardCode", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByCardCode失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.PatientName: intReturn = this.Sql.GetSql("Registration.Register.Query.ByPatientName", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByPatientName失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.PactCode: intReturn = this.Sql.GetSql("Registration.Register.Query.ByPactCode", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByPactCode失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.SeeDepartment: intReturn = this.Sql.GetSql("Registration.Register.Query.BySeeDepartment", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.BySeeDepartment失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.SeeDoctor: intReturn = this.Sql.GetSql("Registration.Register.Query.BySeeDoctor", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.BySeeDoctor失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.MedicareCode: intReturn = this.Sql.GetSql("Registration.Register.Query.ByMedicareCode", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByMedicareCode失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;

                    case ucRegInfoQuery.QueryType.InvoiceCode: intReturn = this.Sql.GetSql("Registration.Register.Query.ByInvoiceCode", ref WHERE);
                        if (intReturn == -1)
                        {
                            this.Err = "获取SQL语句Registration.Register.Query.ByInvoiceCode失败!" + "\n" + this.Err;
                            return -1;
                        }
                        break;
                }
            }
            if (boolRegisterDate)
            {
                intReturn = this.Sql.GetSql("Registration.Register.Query.ByRegDate", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Registration.Register.Query.ByRegDate失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            #region 匹配SQL语句
            try
            {
                if (boolRegisterDate)
                {
                    SQL = string.Format(SQL, QueryString, dtFrom, dtTo);              
                }
                else
                {
                    SQL = string.Format(SQL, QueryString);
                }
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            } 
            #endregion

            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败!" + "\n" + this.Err;
                return -1;
            }

            //
            // 根据查询的门诊号,查询患者挂号实体,形成最终查询结果
            // 原来只有下面一行,但是在DB2里不行,改了
            //this.GetRegisterByClinicCode( alRegister );

            // 循环获取
            List<string> alClinic = new List<string>();
            while (this.Reader.Read())
            {
                // 门诊号
                string clinicCode = this.Reader[0].ToString();
                alClinic.Add(clinicCode);
            }
            this.Reader.Close();


            // 挂号业务层
            Neusoft.HISFC.BizLogic.Registration.Register function = new Neusoft.HISFC.BizLogic.Registration.Register();
            // 挂号实体
            Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();
            foreach (string s in alClinic)
            {
                register = function.GetByClinic(s);
                if (register != null)
                {
                    alRegister.Add(register);
                }
            }

            //
            // 成功返回
            //
            return 1;
        }
        #endregion


        #region 根据门诊号获取费用明细
        /// <summary>
        /// 根据门诊号获取费用明细
        /// [参数1: string clinicCode - 门诊号]
        /// [参数2: System.Data.DataSet dsResult - 返回的费用明细]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="clinicCode">门诊号</param>
        /// <param name="dsResult">返回的费用明细</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetFeeDetailByClinicCode(string clinicCode,ref System.Data.DataSet dsResult)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // SQL语句
            string SQL = "";

            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetFeeDetailByClinicCode.Select", ref SELECT);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetFeeDetailByClinicCode.Select失败!" + "\n" + this.Err;
                return -1;
            }
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetFeeDetailByClinicCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetFeeDetailByClinicCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            SQL = SELECT + " " + WHERE;

            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, clinicCode);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL, ref dsResult);
            if (intReturn == -1)
            {
                this.Err = "执行SQL语句失败!\n" + this.Err;
                return -1;
            }

            //
            // 成功返回
            //
            return 1;
        }
        #endregion
    }
}
