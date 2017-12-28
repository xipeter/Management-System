using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neusoft.HISFC.BizLogic.Order
{
    public class MedicalTeamForDoct : Neusoft.FrameWork.Management.Database
    {
        #region MyRegion

        /// <summary>
        /// 插入或删除信息
        /// </summary>
        /// <param name="sqlIndex"></param>
        /// <param name="medicalTeam"></param>
        /// <returns></returns>
        private int InsertOrUpdateTable(string sqlIndex, Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medicalTeamForDoct)
        {
            string[] args = this.GetArgs(medicalTeamForDoct);

            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql(sqlIndex, ref strSql);

            if (returnValue < 0)
            {
                this.Err = "查询" + sqlIndex + "对应的sql语句失败！\n" + this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, args);
            }
            catch (Exception ex)
            {

                this.Err = "格式化字符串出错!\n" + ex.Message;
                return -1;
            }



            return this.ExecNoQuery(strSql);
        }

        private string[] GetArgs(Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medicalTeamForDoct)
        {
            string[] args = new string[]
            {
               medicalTeamForDoct.MedcicalTeam.Dept.ID,
               medicalTeamForDoct.MedcicalTeam.ID,
               medicalTeamForDoct.Doct.ID,
               medicalTeamForDoct.Doct.Name,
               
               medicalTeamForDoct.Oper.OperTime.ToString(),
                medicalTeamForDoct.Oper.ID,
               Neusoft.FrameWork.Function.NConvert.ToInt32(medicalTeamForDoct.IsValid).ToString()
              
            };
            return args;
        }


        /// <summary>
        /// 根据sql语句插叙医疗组维护信息
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> ExcuteQueryMedicalTeamForDoctBySql(string strSql)
        {
            int returnValue = this.ExecQuery(strSql);

            if (returnValue < 0)
            {
                return null;
            }
            List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> medicalTeamForDoctList = new List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct>();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medicalTeamForDoctObj = new Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct();
                medicalTeamForDoctObj.MedcicalTeam.Dept.ID = this.Reader[0].ToString();

                medicalTeamForDoctObj.MedcicalTeam.ID = this.Reader[1].ToString();

                medicalTeamForDoctObj.Doct.ID = this.Reader[2].ToString();
                medicalTeamForDoctObj.Doct.Name = this.Reader[3].ToString();
                medicalTeamForDoctObj.Oper.ID = this.Reader[5].ToString();
                medicalTeamForDoctObj.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[4].ToString());
                medicalTeamForDoctObj.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[6].ToString());
                medicalTeamForDoctList.Add(medicalTeamForDoctObj);

            }
            this.Reader.Close();
            return medicalTeamForDoctList;
        }

        /// <summary>
        /// 根据索引查询
        /// </summary>
        /// <param name="sqlIndex"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> QueryMedicalTeamForDoctBySqlIndex(string whereIndex, params string[] args)
        {
            string strSql = string.Empty;
            string sqlIndex = "MedicalTeam.Doctor.Select.Base";
            string strWhere = string.Empty;

            //查询基本sql
            int returnValue = this.Sql.GetSql(sqlIndex, ref strSql);
            if (returnValue < 0)
            {
                this.Err = "查询" + sqlIndex + "对应的sql语句失败\n" + this.Sql.Err;
                return null;
            }

            //查询条件
            returnValue = this.Sql.GetSql(whereIndex, ref strWhere);
            if (returnValue < 0)
            {
                this.Err = "查询" + sqlIndex + "对应的sql语句失败\n" + this.Sql.Err;
                return null;
            }

            try
            {
                strWhere = string.Format(strWhere, args);
            }
            catch (Exception ex)
            {

                this.Err = "格式化字符串出错!\n" + ex.Message;
                return null;
            }

            return this.ExcuteQueryMedicalTeamForDoctBySql(strSql + " " + strWhere);
        }

        #endregion
        #region 公有方法

        /// <summary>
        /// 根据科室和医生姓名查询医疗组信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="doctCode"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> QueryQueryMedicalTeamForDoctInfo(string deptCode, string doctCode)
        {
            return this.QueryMedicalTeamForDoctBySqlIndex("MedicalTeam.Doctor.Select.Where1", deptCode, doctCode);
        }

        /// <summary>
        /// 根据科室查询医疗组
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> QueryQueryMedicalTeamForDoctInfo(string deptCode)
        {
            return this.QueryMedicalTeamForDoctBySqlIndex("MedicalTeam.Doctor.Select.Where2", deptCode);
        }


        public List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> QueryQueryMedicalTeamForDoctInfo()
        {
            return this.QueryMedicalTeamForDoctBySqlIndex("MedicalTeam.Doctor.Select.All");
        }


        /// <summary>
        /// 根据科室和医疗组信息查询医生信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> QueryQueryMedicalTeamForDoctInfo(string deptCode, string medicalTeamcode, string validFlag)
        {
            return this.QueryMedicalTeamForDoctBySqlIndex("MedicalTeam.Doctor.Select.Where3", deptCode, medicalTeamcode,validFlag);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="medicalTeam"></param>
        /// <returns></returns>
        public int InsertMedicalTeamForDoct(Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medicalTeamForDoct)
        {
            return this.InsertOrUpdateTable("MedicalTeamForDoct.Insert", medicalTeamForDoct);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="medicalTeam"></param>
        /// <returns></returns>
        public int UpdateMedicalTeamForDoct(Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct medicalTeamForDoct)
        {
            return this.InsertOrUpdateTable("MedicalTeamForDoct.Update", medicalTeamForDoct);
        }

        /// <summary>
        /// 根据科室医疗组医生信息删除医疗组信息
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="medicalTeamCode"></param>
        /// <returns></returns>
        public int DeleteMedicalTeamMedicalTeamForDoct(string deptCode, string medicalTeamCode,string doctCode)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("MedicalTeamForDoct.Delete", ref strSql);

            if (returnValue < 0)
            {
                this.Err = "查询MedicalTeamForDoct.Delete对应的sql语句失败！\n" + this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, deptCode, medicalTeamCode,doctCode);
            }
            catch (Exception ex)
            {

                this.Err = "格式化字符串出错!\n" + ex.Message;
                return -1;
            }



            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更细医疗组下所以医生状态
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="medicalTeamCode"></param>
        /// <returns></returns>
        public int UpdateValidFlag(string isValidFalg, string deptCode, string medicalTeamCode)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("MedicalTeam.Doctor.update.ValidFlag2", ref strSql);

            if (returnValue < 0)
            {
                this.Err = "查询MedicalTeam.Doctor.update.ValidFlag2对应的sql语句失败！\n" + this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, isValidFalg ,deptCode, medicalTeamCode);
            }
            catch (Exception ex)
            {

                this.Err = "格式化字符串出错!\n" + ex.Message;
                return -1;
            }



            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更细医疗组下所以医生状态
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="medicalTeamCode"></param>
        /// <param name="doctCode"></param>
        /// <param name="isValidFalg"></param>
        /// <returns></returns>
        public int UpdateValidFlag(string isValidFalg, string deptCode, string medicalTeamCode,string doctCode)
        {
            string strSql = string.Empty;

            int returnValue = this.Sql.GetSql("MedicalTeam.Doctor.update.ValidFlag1", ref strSql);

            if (returnValue < 0)
            {
                this.Err = "查询MedicalTeam.Doctor.update.ValidFlag2对应的sql语句失败！\n" + this.Sql.Err;
                return -1;
            }

            try
            {
                strSql = string.Format(strSql, isValidFalg, deptCode, medicalTeamCode,doctCode);
            }
            catch (Exception ex)
            {

                this.Err = "格式化字符串出错!\n" + ex.Message;
                return -1;
            }



            return this.ExecNoQuery(strSql);
        }
        #endregion
    }
}
