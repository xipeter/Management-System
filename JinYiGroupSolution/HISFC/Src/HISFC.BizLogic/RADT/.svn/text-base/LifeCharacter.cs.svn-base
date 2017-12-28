using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models;

namespace Neusoft.HISFC.BizLogic.RADT
{
    /// <summary>
    /// [功能描述: 患者生命体征管理类]<br></br>
    /// [创 建 者: 孙盟]<br></br>
    /// [创建时间: 2007-05-02]<br></br>
    /// <修改记录/>
    /// </summary> 
    public class LifeCharacter : Database
    {
        public LifeCharacter()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 基本操作

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="lifeCharacter"></param>
        /// <returns></returns>
        public int InsertLifeCharacter(Neusoft.HISFC.Models.RADT.LifeCharacter lifeCharacter)
        {
            string strSql = "";

			if(this.Sql.GetSql("RADT.InPatient.LifeCharacter.Insert.1",ref strSql) == -1) 
			{
				this.Err = this.Sql.Err;
				return -1;
			}
            strSql = this.GetLifeCharacterSql(strSql, lifeCharacter);
            if (strSql == null) return -1;
            if (this.ExecNoQuery(strSql) <= 0) return -1;
            return 1;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="measureDate"></param>
        /// <returns></returns>
        public int DeleteLifeCharacter(string inpatientNO, DateTime measureDate)
        {
            string sql = "RADT.InPatient.LifeCharacter.Delete.1";
            if (this.Sql.GetSql(sql, ref sql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                sql = string.Format(sql, inpatientNO, measureDate);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();
                return -1;
            }
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 更新一条
        /// </summary>
        /// <param name="lifeCharacter"></param>
        /// <returns></returns>
        public int UpdateLifeCharacter(Neusoft.HISFC.Models.RADT.LifeCharacter lifeCharacter)
        {
            if (this.DeleteLifeCharacter(lifeCharacter.ID, lifeCharacter.MeasureDate) < 0)
            {
                return -1;
            }
            return this.InsertLifeCharacter(lifeCharacter);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询一条
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="measureDate"></param>
        /// <returns></returns>
        public ArrayList QueryLifeCharacter(string inpatientNO, DateTime measureDate)
        {
            string sql = "", sqlSelect = "", sqlWhere = "RADT.InPatient.LifeCharacter.Select.Where.1";
            if (this.GetSelectSql(ref sqlSelect) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            if (this.Sql.GetSql(sqlWhere, ref sqlWhere) == -1) return null;
            sql = sqlSelect + " " + sqlWhere;
            sql = string.Format(sql, inpatientNO, measureDate);
            return this.GetLifeCharacterAL(sql);
        }

        #endregion

        #region 私有方法

        private int GetSelectSql(ref string sql)
        {
            return this.Sql.GetSql("RADT.InPatient.LifeCharacter.Select.1", ref sql);
        }

        /// <summary>
        /// 读取数据生成ArrayList
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private ArrayList GetLifeCharacterAL(string sql)
        {
            if (this.ExecQuery(sql) == -1) return null;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.RADT.LifeCharacter lfch = new Neusoft.HISFC.Models.RADT.LifeCharacter();
                lfch.ID = this.Reader[0].ToString();
                lfch.Name = this.Reader[1].ToString();
                lfch.Dept.ID = this.Reader[2].ToString();
                lfch.Dept.Name = this.Reader[3].ToString();
                lfch.NurseStation.ID = this.Reader[4].ToString();
                lfch.NurseStation.Name = this.Reader[5].ToString();
                lfch.BedNO = this.Reader[6].ToString();
                lfch.PID.PatientNO = this.Reader[7].ToString();
                lfch.InDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8]);
                lfch.MeasureDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9]);
                lfch.Breath = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10]);
                lfch.Pulse = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[11]);
                lfch.Temperature = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[12]);
                lfch.HighBloodPressure = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13]);
                lfch.LowBloodPressure = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14]);
                lfch.Time = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[15]);
                lfch.IsForceHypothermia = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[16].ToString());
                lfch.ForceHypothermiaInt = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[16]);
                lfch.TargetTemperature = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17]);
                lfch.TemperatureType = this.Reader[18].ToString();
                lfch.Memo = this.Reader[19].ToString();
                lfch.Oper.ID = this.Reader[20].ToString();

                al.Add(lfch);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 获得SQL，传入参数
        /// </summary>
        /// <param name="sqlLifeCharacter"></param>
        /// <param name="lifeCharacter"></param>
        /// <returns></returns>
        private string GetLifeCharacterSql(string sqlLifeCharacter, Neusoft.HISFC.Models.RADT.LifeCharacter lifeCharacter)
        {
            try
            {
                System.Object[] s ={lifeCharacter.ID,
                                    lifeCharacter.Name,
                                    lifeCharacter.Dept.ID,
                                    lifeCharacter.Dept.Name,
                                    lifeCharacter.NurseStation.ID,
                                    lifeCharacter.NurseStation.Name,
                                    lifeCharacter.BedNO,
                                    lifeCharacter.PID.PatientNO,
                                    lifeCharacter.InDate.ToString("yyyyMMdd"),
                                    lifeCharacter.MeasureDate.ToString("yyyyMMddHHmmss"),
                                    lifeCharacter.Breath,
                                    lifeCharacter.Temperature,
                                    lifeCharacter.Pulse,
                                    lifeCharacter.HighBloodPressure,
                                    lifeCharacter.LowBloodPressure,
                                    lifeCharacter.Time,
                                    lifeCharacter.IsForceHypothermia == true ? 1 : 0,
                                    lifeCharacter.TargetTemperature,
                                    lifeCharacter.TemperatureType,
                                    lifeCharacter.Memo,
                                    lifeCharacter.Oper.ID};
                sqlLifeCharacter = string.Format(sqlLifeCharacter, s);
            }
            catch (Exception ex)
            {
                this.Err = "付数值时候出错！" + ex.Message;
                this.WriteErr();
                return null;
            }
            return sqlLifeCharacter;
        }

        #endregion
    }
}
