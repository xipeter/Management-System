using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Neusoft.WinForms.Report.OutpatientFee.Class
{
    /// <summary>
    /// 肿瘤医院 20071130[门诊收费综合查询]
    /// </summary>
    public class OutPatientQuery : Neusoft.FrameWork.Management.Database
    {
        #region 门诊收费综合查询

        #region 根据病历号获取挂号记录
        /// <summary>
        /// 根据病历号获取挂号记录
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="boolLike">是否模糊查询</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByCardCode(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode.Like", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.PID.CardNO);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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
        #region 根据病历号获取挂号记录,有时间限制
        /// <summary>
        /// 根据病历号获取挂号记录,有时间限制
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: DateTime dtFrom - 起始时间]
        /// [参数4: DateTime dtTo - 截止时间]
        /// [参数5: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByCardCode(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, DateTime dtFrom, DateTime dtTo, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string WHERE1 = "";
            string WHERE2 = "";
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode.Like", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.CardCode失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 获取时间WHERE语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date", ref WHERE2);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date失败!" + "\n" + this.Err;
                return -1;
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + WHERE1 + " " + WHERE2;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.PID.CardNO, dtFrom.ToString(), dtTo.ToString());
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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

        #region 根据姓名获取挂号记录
        /// <summary>
        /// 根据姓名获取挂号记录
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="boolLike">是否模糊查询</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByName(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByName.Where.Name.Like", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByName.Where.Name.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByName.Where.Name", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByName.Where.Name失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.Name);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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
        #region 根据姓名获取挂号记录,有时间限制
        /// <summary>
        /// 根据姓名获取挂号记录,有时间限制
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: DateTime dtFrom - 起始时间]
        /// [参数4: DateTime dtTo - 截止时间]
        /// [参数5: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByName(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, DateTime dtFrom, DateTime dtTo, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string WHERE1 = "";
            string WHERE2 = "";
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByName.Where.Name.Like", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByName.Where.Name.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByName.Where.Name", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByName.Where.Name失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 获取时间WHERE语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date", ref WHERE2);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date失败!" + "\n" + this.Err;
                return -1;
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + WHERE1 + " " + WHERE2;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.Name, dtFrom.ToString(), dtTo.ToString());
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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

        #region 根据合同单位获取挂号记录
        /// <summary>
        /// 根据合同单位获取挂号记录
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="boolLike">是否模糊查询</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByPact(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact.Like", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.Pact.ID);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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
        #region 根据合同单位获取挂号记录,有时间限制
        /// <summary>
        /// 根据合同单位获取挂号记录,有时间限制
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: DateTime dtFrom - 起始时间]
        /// [参数4: DateTime dtTo - 截止时间]
        /// [参数5: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByPact(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, DateTime dtFrom, DateTime dtTo, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string WHERE1 = "";
            string WHERE2 = "";
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact.Like", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByPact.Where.Pact失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 获取时间WHERE语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date", ref WHERE2);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date失败!" + "\n" + this.Err;
                return -1;
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + WHERE1 + " " + WHERE2;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.Pact.ID, dtFrom.ToString(), dtTo.ToString());
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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

        #region 根据挂号科室获取挂号记录
        /// <summary>
        /// 根据合同单位获取挂号记录
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="boolLike">是否模糊查询</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByDepartment(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department.Like", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.DoctorInfo.Templet.Dept.ID);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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
        #region 根据挂号科室获取挂号记录,有时间限制
        /// <summary>
        /// 根据合同单位获取挂号记录,有时间限制
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: DateTime dtFrom - 起始时间]
        /// [参数4: DateTime dtTo - 截止时间]
        /// [参数5: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByDepartment(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, DateTime dtFrom, DateTime dtTo, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string WHERE1 = "";
            string WHERE2 = "";
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department.Like", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDepartment.Where.Department失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 获取时间WHERE语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date", ref WHERE2);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date失败!" + "\n" + this.Err;
                return -1;
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + WHERE1 + " " + WHERE2;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.DoctorInfo.Templet.Dept.ID, dtFrom.ToString(), dtTo.ToString());
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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

        #region 根据开单医生获取挂号记录
        /// <summary>
        /// 根据开单医生获取挂号记录
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="boolLike">是否模糊查询</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByDoctor(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string OTHERWHERE = "";
            // SQL语句
            string SQL = "";

            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Select", ref SELECT);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Select失败!" + "\n" + this.Err;
                return -1;
            }
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor.Like", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.DoctorInfo.Templet.Doct.ID);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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
        #region 根据开单医生获取挂号记录,有时间限制
        /// <summary>
        /// 根据开单医生获取挂号记录,有时间限制
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: DateTime dtFrom - 起始时间]
        /// [参数4: DateTime dtTo - 截止时间]
        /// [参数5: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByDoctor(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, DateTime dtFrom, DateTime dtTo, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string WHERE1 = "";
            string WHERE2 = "";
            // SQL语句
            string SQL = "";

            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Select", ref SELECT);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Select失败!" + "\n" + this.Err;
                return -1;
            }
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor.Like", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where.Doctor失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 获取时间WHERE语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date", ref WHERE2);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date失败!" + "\n" + this.Err;
                return -1;
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + WHERE1 + " " + WHERE2;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.DoctorInfo.Templet.Doct.ID, dtFrom.ToString(), dtTo.ToString());
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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

        #region 根据医疗证号获取挂号记录
        /// <summary>
        /// 根据医疗证号获取挂号记录
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="boolLike">是否模糊查询</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByMCard(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
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
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard.Like", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.SSN);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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
        #region 根据医疗证号获取挂号记录,有时间限制
        /// <summary>
        /// 根据医疗证号获取挂号记录,有时间限制
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: DateTime dtFrom - 起始时间]
        /// [参数4: DateTime dtTo - 截止时间]
        /// [参数5: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByMCard(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, DateTime dtFrom, DateTime dtTo, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string WHERE1 = "";
            string WHERE2 = "";
            // SQL语句
            string SQL = "";
            this.Err = "";

            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Select", ref SELECT);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Select失败!" + "\n" + this.Err;
                return -1;
            }
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard.Like", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByMCard.Where.MCard失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 获取时间WHERE语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date", ref WHERE2);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date失败!" + "\n" + this.Err;
                return -1;
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + WHERE1 + " " + WHERE2;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.SSN, dtFrom.ToString(), dtTo.ToString());
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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

        #region 根据发票号获取挂号记录
        /// <summary>
        /// 根据发票号获取挂号记录
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="boolLike">是否模糊查询</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByInvoice(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string OTHERWHERE = "";
            // SQL语句
            string SQL = "";

            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Select", ref SELECT);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Select失败!" + "\n" + this.Err;
                return -1;
            }
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice.Like", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice", ref OTHERWHERE);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + OTHERWHERE;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.Memo);
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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
        #region 根据发票号获取挂号记录,有时间限制
        /// <summary>
        /// 根据发票号获取挂号记录,有时间限制
        /// [参数1: Neusoft.HISFC.Models.Registration.Register r - 含有病历号的挂号实体]
        /// [参数2: ArrayList alRegister - 返回的挂号数组]
        /// [参数3: DateTime dtFrom - 起始时间]
        /// [参数4: DateTime dtTo - 截止时间]
        /// [参数5: bool boolLike - 是否模糊查询]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="r">含有病历号的挂号实体</param>
        /// <param name="alRegister">返回的挂号数组</param>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        public int GetRegisterListByInvoice(Neusoft.HISFC.Models.Registration.Register r, ArrayList alRegister, DateTime dtFrom, DateTime dtTo, bool boolLike)
        {
            // 返回值
            int intReturn = 0;
            // SELECT语句
            string SELECT = "";
            // WHERE语句
            string WHERE = "";
            // 其他WHERE语句
            string WHERE1 = "";
            string WHERE2 = "";
            // SQL语句
            string SQL = "";

            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Select", ref SELECT);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Select失败!" + "\n" + this.Err;
                return -1;
            }
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByDoctor.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByDoctor.Where失败!" + "\n" + this.Err;
                return -1;
            }
            // 判断是否是模糊查询
            if (boolLike)
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice.Like", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice.Like失败!" + "\n" + this.Err;
                    return -1;
                }

            }
            else
            {
                intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice", ref WHERE1);
                if (intReturn == -1)
                {
                    this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByInvoice.Where.Invoice失败!" + "\n" + this.Err;
                    return -1;
                }
            }
            // 获取时间WHERE语句
            intReturn = this.Sql.GetSql("Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date", ref WHERE2);
            if (intReturn == -1)
            {
                this.Err = "获取SQL语句Local.Clinic.Function.Report.GetRegisterListByCardCode.Where.Date失败!" + "\n" + this.Err;
                return -1;
            }
            // 合并SQL语句
            SQL = SELECT + " " + WHERE + " " + WHERE1 + " " + WHERE2;

            //
            // 匹配SQL语句
            //
            try
            {
                SQL = string.Format(SQL, r.Memo, dtFrom.ToString(), dtTo.ToString());
            }
            catch
            {
                this.Err = "匹配SQL语句失败!";
                return -1;
            }

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

        #region 根据Reader获取的ClinicCode获取挂号信息
        /// <summary>
        /// 根据Reader获取的ClinicCode获取挂号信息
        /// [参数: ArrayList alRegister - 返回的挂号实体数组]
        /// </summary>
        /// <param name="alRegister">返回的挂号实体数组</param>
        private void GetRegisterByClinicCode(ArrayList alRegister)
        {
            // 循环获取
            while (this.Reader.Read())
            {
                // 门诊号
                string clinicCode = this.Reader[0].ToString();
                // 挂号业务层
                Neusoft.HISFC.BizLogic.Registration.Register function = new Neusoft.HISFC.BizLogic.Registration.Register();
                // 挂号实体
                Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();

                //
                // 执行查询
                //
                register = function.GetByClinic(clinicCode);
                if (register != null)
                {
                    // 添加进实体数组
                    alRegister.Add(register);
                }
            }

            // 释放资源
            this.Reader.Close();
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
        public int GetFeeDetailByClinicCode(string clinicCode, ref System.Data.DataSet dsResult)
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


        #endregion


        /// <summary>
        /// 根据收款员或地结算信息的Dataset
        /// </summary>
        /// <returns></returns>
        public int QueryBalanceByOperCode(string operCode, DateTime beginTime, DateTime endTime, ref DataSet dataSet)
        {
            return this.QueryBalances("Fee.OutPatient.GetInvoiceInformationByOperCode.Where", ref dataSet, operCode, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 根据Where条件索引查询结算信息数组
        /// </summary>
        /// <param name="whereIndex">where条件</param>
        /// <param name="ds">返回的DataSet</param>
        /// <param name="args">参数</param>
        /// <returns>成功:结算信息DataSet 失败:null</returns>
        private int QueryBalances(string whereIndex, ref DataSet ds, params string[] args)
        {
            string select = string.Empty;//SELECT语句;
            string where = string.Empty;//WHERE语句;

            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return -1;
            }

            try
            {
                where = string.Format(where, args);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return -1;
            }

            select = this.GetQueryBalancesSql();

            return this.ExecQuery(select + " " + where, ref ds);
        }

        /// <summary>
        /// 获取发票基本信息(1：成功/-1：失败)
        /// </summary>
        /// <returns>成功:获取结算信息SQL查询语句 失败: null</returns>
        public string GetQueryBalancesSql()
        {
            string sql = string.Empty;//SQL语句

            if (this.Sql.GetSql("Fee.OutPatient.GetInvoiceInformation.Select", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.OutPatient.GetInvoiceInformation.Select的SQL语句";

                return null;
            }

            return sql;
        }
    }
}
