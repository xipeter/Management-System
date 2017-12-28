using System;
using System.Collections.Generic;
//using Neusoft.HISFC.Models.Order.Medical;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Order.Medical
{
    /// <summary>
    /// Ability<br></br>
    /// [功能描述: 执业资质管理类]<br></br>
    /// [创 建 者: 孙久海]<br></br>
    /// [创建时间: 2008-04-09]<br></br>
    /// <修改记录
    ///		修改人='于洋'
    ///		修改时间='2008-09-08'
    ///		修改目的='增加特殊检查权限检查'
    ///		修改描述='在方法CheckPopedom中添加了特殊检查的权限检查'
    ///  />
    /// </summary>
    public class Ability : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 构造函数

        /// </summary>
        public Ability()
        {

        }

        #region 私有方法

        /// <summary>
        /// 更新单表操作
        /// </summary>
        /// <param name="sqlIndex">SQL语句索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: >= 1 失败 -1 没有更新到数据 0</returns>
        private int UpdateSingleTable(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, args);
        }

        /// <summary>
        /// 查询数据库中一个字段信息

        /// </summary>
        /// <param name="sqlIndex">SQL语句索引</param>
        /// <param name="args">传入字段</param>
        /// <returns>成功 返回字符串 失败 null</returns>
        private string GetParamsBySql(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;
            string paramsStr = string.Empty;
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return null;
            }
            if (this.ExecQuery(sql, args) == -1)
            {
                this.Err = "执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";

                return null;
            }

            try
            {
                if (this.Reader.Read())
                {
                    paramsStr = this.Reader[0].ToString();
                }
            }

            catch (System.Exception ex)
            {
                this.Err = "获得信息时出错！" + ex.Message;
                this.ErrCode = "-1";

                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return paramsStr;
        }

        /// <summary>
        /// 查询返回资质实体类列表

        /// </summary>
        /// <param name="sqlIndex">SQL语句索引</param>
        /// <param name="args">传入字段</param>
        /// <returns>成功 Ability列表 失败 null</returns>
        private List<Neusoft.HISFC.Models.Order.Medical.Ability> QueryBySql(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return null;
            }
            if (this.ExecQuery(sql, args) == -1)
            {
                this.Err = "执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";

                return null;
            }

            List<Neusoft.HISFC.Models.Order.Medical.Ability> al = new List<Neusoft.HISFC.Models.Order.Medical.Ability>();
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Order.Medical.Ability fection = new Neusoft.HISFC.Models.Order.Medical.Ability();

                    fection.Employee.ID = this.Reader[0].ToString();
                    fection.Speciality.ID = this.Reader[1].ToString();
                    fection.VocationCardNO = this.Reader[2].ToString();
                    fection.AbilityCardNO = this.Reader[3].ToString();
                    fection.VocationType.ID = this.Reader[4].ToString();
                    fection.VocationArea = this.Reader[5].ToString();
                    fection.Remark = this.Reader[6].ToString();
                    fection.ID = this.Reader[7].ToString();
                    fection.Employee.Name = this.Reader[8].ToString();
                    fection.Employee.Dept.ID = this.Reader[9].ToString();
                    fection.Employee.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    fection.Employee.Sex.ID = this.Reader[11].ToString();
                    fection.Employee.GraduateSchool.ID = this.Reader[12].ToString();
                    fection.Employee.Level.ID = this.Reader[13].ToString();

                    al.Add(fection);
                }
            }

            catch (System.Exception ex)
            {
                this.Err = "获得资质信息时出错！" + ex.Message;
                this.ErrCode = "-1";

                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }

        /// <summary>
        /// 根据药品代码获得药品等级
        /// </summary>
        /// <param name="itemID">药品代码</param>
        /// <returns>成功 字符串 失败 null</returns>
        private string GetDrugLevlByItemID(string itemID)
        {
            return this.GetParamsBySql("Medical.Ability.GetDrugLevlByID", itemID);
        }

        /// <summary>
        /// 根据药品代码获得药品性质
        /// </summary>
        /// <param name="itemID">药品代码</param>
        /// <returns>成功 字符串 失败 null</returns>
        private string GetDrugQualityByItemID(string itemID)
        {
            return this.GetParamsBySql("Medical.Ability.GetDrugQualityByID", itemID);
        }

        /// <summary>
        /// 根据项目代码获得手术规模
        /// </summary>
        /// <param name="itemID">项目代码</param>
        /// <returns>成功 字符串 失败 null</returns>
        private string GetOperateTypeByItemID(string itemID)
        {
            return this.GetParamsBySql("Medical.Ability.GetOperateTypeByID", itemID);
        }

        /// <summary>
        /// 通过权限ID和类型验证权限

        /// </summary>
        /// <param name="emplID">人员代码</param>
        /// <param name="popedomID">权限代码</param>
        /// <returns>成功 "1" 失败 "-1" 无权限 "0"</returns>
        public string CheckByType(string emplID, string popedomType, string popedomID)
        {
            return this.GetParamsBySql("Medical.Ability.CheckPopedomByType", emplID, popedomType, popedomID);
        }
        #region 原来的代码

        ///// <summary>
        ///// 通过权限类型验证权限
        ///// </summary>
        ///// <param name="emplID">人员代码</param>
        ///// <param name="popedomType">权限类型</param>
        ///// <returns>成功 "1" 失败 "-1" 无权限 "0"</returns>
        //private string CheckByType(string emplID, string popedomType)
        //{
        //    return this.GetParamsBySql("Medical.Ability.CheckPopedomOnlyByType", emplID, popedomType);
        //}

        #endregion

        #region 于洋修改的代码

        /// <summary>
        /// 通过权限类型验证权限
        /// </summary>
        /// <param name="emplID">人员代码</param>
        /// <param name="popedomType">权限类型</param>
        /// <returns>成功 "1" 失败 "-1" 无权限 "0"</returns>
        public string CheckByType(string emplID, string popedomType)
        {
            return this.GetParamsBySql("Medical.Ability.CheckPopedomOnlyByType", emplID, popedomType);
        }

        #endregion

        /// <summary>
        /// 验证传入人员ID是否存在权限表中
        /// </summary>
        /// <param name="emplID"></param>
        /// <returns></returns>
        private string CheckByEmplID(string emplID, string popedomType)
        {
            return this.GetParamsBySql("Medical.Ability.CheckInPopedomByID", emplID, popedomType);
        }

        /// <summary>
        /// 验证人员的某权限信息是否存在
        /// {EC320C77-250E-4f44-863D-2E47B9F2FA22}
        /// </summary>
        /// <param name="emplID">人员ID</param>
        /// <param name="popedomType">权限类型</param>
        /// <param name="popeCode">权限编码</param>
        /// <returns></returns>
        public int CheckByEmplRight(string emplID, string popedomType, string popedomCode)
        {
            return NConvert.ToInt32(this.GetParamsBySql("Medical.Ability.CheckByEmplRight", emplID, popedomType, popedomCode));
        }

        #endregion

        #region 公有方法
        /// <summary>
        /// 通过人员代码查询资质信息
        /// </summary>
        /// <param name="emplID">人员代码</param>
        /// <returns>资质实体</returns>
        public List<Neusoft.HISFC.Models.Order.Medical.Ability> QueryAbilityByPersonID(string emplID)
        {
            return this.QueryBySql("Medical.Ability.QueryByEmplID", emplID);
        }

        /// <summary>
        /// 通过科室代码查询资质信息
        /// </summary>
        /// <param name="deptID">科室代码</param>
        /// <returns>资质实体</returns>
        public List<Neusoft.HISFC.Models.Order.Medical.Ability> QueryAbilityByDeptID(string deptID)
        {
            return this.QueryBySql("Medical.Ability.QueryByDeptID", deptID);
        }

        /// <summary>
        /// 插入一条资质信息

        /// </summary>
        /// <param name="ability">资质实体</param>
        /// <returns>成功 1 失败 -1</returns>
        public int InsertAbility(Neusoft.HISFC.Models.Order.Medical.Ability ability)
        {
            return this.UpdateSingleTable("Medical.Ability.Insert",
                ability.Employee.ID.ToString(), ability.Speciality.ID,
                ability.VocationCardNO, ability.AbilityCardNO,
                ability.VocationType.ID, ability.VocationArea, ability.Remark);
        }

        /// <summary>
        /// 修改一条资质信息

        /// </summary>
        /// <param name="ability">资质实体</param>
        /// <returns>成功 1 失败 -1 没有更新到数据 0</returns>
        public int UpdateAbility(Neusoft.HISFC.Models.Order.Medical.Ability ability)
        {
            return this.UpdateSingleTable("Medical.Ability.Update",
                ability.ID, ability.Speciality.ID, ability.VocationCardNO,
                ability.AbilityCardNO, ability.VocationType.ID, ability.VocationArea, ability.Remark);
        }

        /// <summary>
        /// 删除一条资质信息

        /// </summary>
        /// <param name="happenNO">发生序号</param>
        /// <returns>成功 1 失败 -1 没有更新到数据 0</returns>
        public int DeleteAbilityByHappenNO(string happenNO)
        {
            return this.UpdateSingleTable("Medical.Ability.Delete", happenNO);
        }

        /// <summary>
        /// 根据人员，专业查询资质信息记录个数
        /// {65C2D1EE-A2ED-4781-BB10-48D7156CFD6C}
        /// </summary>
        /// <param name="emplCode"></param>
        /// <param name="speciality"></param>
        /// <returns></returns>
        public string GetAbilityCountByEmplAndSpeciality(string emplCode, string speciality)
        {
            return this.GetParamsBySql("Medical.Ability.GetAbilityCountByEmplAndSpeciality", emplCode, speciality);
        }

        /// <summary>
        /// 医疗权限检查方法
        /// 修改了，增加参数isAllowNonRight{67FBD55B-1B0E-41e9-B13B-976E235D9FA2}
        /// </summary>
        /// <param name="emplCode">医生代码</param>
        /// <param name="itemCode">项目代码</param>
        /// <param name="sysClass">系统类别</param>
        /// <param name="isAllowNonRight">当在医疗权限管理中，所给医生没有被维护过所给系统类型权限的情况下，默认该医生具有该类型的所有权限</param>
        /// <param name="failCause">验证失败原因</param>
        /// <returns>成功 1 失败 -1 无权限 0</returns>
        public int CheckPopedom(string emplCode, string itemCode, string sysClass, bool isAllowNonRight, ref string failCause)
        {
            //药品等级代码
            string drugGrade = string.Empty;
            //药品性质代码
            string drugQuality = string.Empty;
            //手术规模代码
            string operateType = string.Empty;
            //验证结果
            string checkResult = string.Empty;

            //权限类型
            string popedomType = string.Empty;
            //如果权限表没有找到该人员代码，则拥有所有权限
            //{67FBD55B-1B0E-41e9-B13B-976E235D9FA2}

            switch (sysClass)
            {
                case "P":
                    popedomType = "1";
                    break;
                case "UO":
                    popedomType = "0";
                    break;
                case "MC":
                    popedomType = "3";
                    break;
                case "UC":
                    popedomType = "9";
                    break;
                case "equipment":
                    popedomType = "4";
                    break;
                case "groupManager":
                    popedomType = "2";
                    break;
                default:
                    break;
            }

            //药品的特殊处理
            if (sysClass.Substring(0, 1) == "P")
            {
                popedomType = "1";
            }

            if (popedomType == string.Empty)
            {
                failCause = "sysClass错误，不是合法参数";
                return 1;
            }

            if (isAllowNonRight)
            {
                if (Convert.ToInt32(CheckByEmplID(emplCode, popedomType)) == 0)
                {
                    return 1;
                }
            }

            //判断是药品

            if (sysClass.Substring(0, 1) == "P")
            {
                #region 原来的代码

                //1。验证药品等级

                //drugGrade = this.GetDrugLevlByItemID(itemCode);
                //if (drugGrade == "")
                //{
                //    return 1;
                //}

                #endregion

                if (drugGrade == null)
                {
                    failCause = "获取药品等级信息失败";

                    return -1;
                }
                else
                {
                    //2。验证药品性质
                    drugQuality = this.GetDrugQualityByItemID(itemCode);
                    if (drugQuality == "")
                    {
                        return 1;
                    }

                    if (drugQuality == null)
                    {
                        failCause = "获取药品性质信息失败";

                        return -1;
                    }
                    else
                    {
                        checkResult = this.CheckByType(emplCode, "1", drugQuality);
                        if (checkResult == "1")
                        {
                            return 1;
                        }
                        else if (checkResult == "0")
                        {
                            failCause = "无此药品性质处方权限";

                            return 0;
                        }
                        else
                        {
                            failCause = "执行查询语句失败";

                            return -1;
                        }
                    }
                }

            }
            //判断是手术
            else if (sysClass == "UO")
            {
                operateType = this.GetOperateTypeByItemID(itemCode);
                if (operateType == "")
                {
                    return 1;
                }

                if (operateType == null)
                {
                    failCause = "获取手术规模信息失败";

                    return -1;
                }
                else
                {
                    checkResult = this.CheckByType(emplCode, "0", operateType);
                    if (checkResult == "1")
                    {
                        return 1;
                    }
                    else if (checkResult == "0")
                    {
                        failCause = "无此手术规模权限";

                        return 0;
                    }
                    else
                    {
                        failCause = "执行查询语句失败";

                        return -1;
                    }
                }
                //查询手术规模GetOperateTypeByItemID    [FIN_COM_UNDRUGINFO  /  OPERATE_TYPE]
            }
            //判断是会诊
            else if (sysClass == "MC")
            {
                checkResult = this.CheckByType(emplCode, "3");
                if (checkResult == "1")
                {
                    return 1;
                }
                else if (checkResult == "0")
                {
                    failCause = "无会诊权限";

                    return 0;
                }
                else
                {
                    failCause = "执行查询语句失败";

                    return -1;
                }
            }

            #region 于洋添加的代码
            //判断是非药品
            else if (sysClass == "UC")
            {

                checkResult = this.CheckByType(emplCode, "9", itemCode);
                if (checkResult == "1")
                {
                    return 1;
                }
                else if (checkResult == "0")
                {
                    failCause = "无该特殊检查权限";

                    return 0;
                }
                else
                {
                    failCause = "执行查询语句失败";

                    return -1;
                }
            }
            //判断是设备权限
            else if (sysClass == "equipment")
            {

                checkResult = this.CheckByType(emplCode, "4", itemCode);
                if (checkResult == "1")
                {
                    return 1;
                }
                else if (checkResult == "0")
                {
                    failCause = "无该设备权限";

                    return 0;
                }
                else
                {
                    failCause = "执行查询语句失败";

                    return -1;
                }
            }
            #endregion

            //{004207D4-A826-4606-81A4-582AA8CB98AB} 组套的修改通过资格资质控制
            else if (sysClass == "groupManager")
            {
                checkResult = this.CheckByType(emplCode, "2", itemCode);
                if (checkResult == "1")
                {
                    return 1;
                }
                else if (checkResult == "0")
                {
                    failCause = "无该组套权限";

                    return 0;
                }
                else
                {
                    failCause = "执行查询语句失败";

                    return -1;
                }
            }

            else
            {
                return 1;
            }
        }

        public List<Neusoft.HISFC.Models.Order.Medical.Ability> QueryDoctorListBySpecLevl(string spec, string levl)
        {
            return this.QueryBySql("Medical.Ability.QuerySpecLevl", spec, levl);
        }

        /// <summary>
        /// 插入医疗权限
        /// </summary>
        /// <param name="ppd">权限实体</param>
        /// <returns>成功 1 失败 -1</returns>
        public int InsertPopedom(Neusoft.HISFC.Models.Order.Medical.Popedom ppd)
        {
            return this.UpdateSingleTable("Medical.Ability.InsertPopedom", ppd.EmplCode, ppd.PopedomType.ID, ppd.Popedoms.ID, ppd.CheckFlag);
        }

        /// <summary>
        /// 修改医疗权限审核标志
        /// </summary>
        /// <param name="ppd">权限实体</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UpdatePopedom(Neusoft.HISFC.Models.Order.Medical.Popedom ppd)
        {
            return this.UpdateSingleTable("Medical.Ability.UpdatePopedom", ppd.ID, ppd.CheckFlag);
        }

        /// <summary>
        /// 删除一条医疗权限

        /// </summary>
        /// <param name="happenNO">发生序号</param>
        /// <returns>成功 1 失败 -1</returns>
        public int DeletePopedom(string happenNO)
        {
            return this.UpdateSingleTable("Medical.Ability.DeletePopedom", happenNO);
        }

        /// <summary>
        /// 通过人员代码查询医疗权限
        /// </summary>
        /// <param name="emplID">人员代码</param>
        /// <returns>成功 权限实体列表 失败 null</returns>
        public List<Neusoft.HISFC.Models.Order.Medical.Popedom> QueryPopedomByEmplID(string emplID)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Medical.Ability.QueryPopedom", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Medical.Ability.QueryPopedom的SQL语句";

                return null;
            }
            if (this.ExecQuery(sql, emplID) == -1)
            {
                this.Err = "执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";

                return null;
            }

            List<Neusoft.HISFC.Models.Order.Medical.Popedom> al = new List<Neusoft.HISFC.Models.Order.Medical.Popedom>();
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Order.Medical.Popedom fection = new Neusoft.HISFC.Models.Order.Medical.Popedom();

                    fection.ID = this.Reader[0].ToString();
                    fection.EmplCode = this.Reader[1].ToString();
                    fection.PopedomType.ID = this.Reader[2].ToString();
                    fection.Popedoms.ID = this.Reader[3].ToString();
                    fection.CheckFlag = this.Reader[4].ToString();

                    al.Add(fection);
                }
            }

            catch (System.Exception ex)
            {
                this.Err = "获得权限信息时出错！" + ex.Message;
                this.ErrCode = "-1";

                return null;
            }
            finally
            {
                this.Reader.Close();
            }
            return al;
        }


        #endregion

        #region 暂时不用的方法


        /// <summary>
        /// 查询全部资质信息
        /// </summary>
        /// <returns>资质实体</returns>
        public List<Neusoft.HISFC.Models.Order.Medical.Ability> QueryAbilityList()
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Medical.Ability.QueryAll", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Medical.Ability.QueryAll的SQL语句";

                return null;
            }

            //return this.ExecNoQuery(sql);
            return null;
        }

        #endregion

    }
}
