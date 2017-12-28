using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public class ChildbirthRecord : Neusoft.FrameWork.Management.Database
    {

        #region 方法
        /// <summary>
        /// 根据住院号查询患者分娩记录
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord> QueryChildbirthRecord(string inpatientNO)
        {
            List<Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord> record = null;

            string strSql = "";

            if (this.Sql.GetSql("Case.ChildbirthRecord.Select", ref strSql) == -1)
            {
                return null;
            }

            try
            {
                strSql = string.Format(strSql, inpatientNO);

                this.ExecQuery(strSql);

                Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord info = null;

                record = new List<Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord>();

                while (this.Reader.Read())
                {
                       //is_normal,   --是否正常分娩
                       //is_dystocia,   --是否难产
                       //familyplanning,   --计划生育方式
                       //is_perineumbreak,   --是否会阴破裂
                       //womenkind,   --产妇类型
                       //isbreak,   --是否破裂
                       //breaklevel,   --破裂程度
                       //babysex,   --婴儿性别
                       //babyweight   --婴儿体重

                    info = new Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord();
                    info.Patient.ID = inpatientNO;
                    //是否正常分娩
                    if (Reader[0] != DBNull.Value)
                    {
                        info.IsNormalChildbirth = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[0].ToString());
                    }
                    else
                    {
                        info.IsNormalChildbirth = false;
                    }
                    //是否难产
                    if (Reader[1] != DBNull.Value)
                    {
                        info.IsDystocia = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[1].ToString());
                    }
                    else
                    {
                        info.IsDystocia = false;
                    }
                    //计划生育方式
                    info.FamilyPlanning.ID = Reader[2].ToString();
                    //是否会阴破裂
                    if (Reader[3] != DBNull.Value)
                    {
                        info.IsPerineumBreak = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[3].ToString());
                    }
                    else
                    {
                        info.IsPerineumBreak = false;
                    }
                    //产妇类型
                    info.WomenKind.ID = Reader[4].ToString();

                    //是否破裂
                    if (Reader[5] != DBNull.Value)
                    {
                        info.IsBreak = Neusoft.FrameWork.Function.NConvert.ToBoolean(Reader[5].ToString());
                    }
                    else
                    {
                        info.IsBreak = false;
                    }
                    //破裂程度

                    info.BreakLevel.ID = Reader[6].ToString();
         
                    //婴儿性别
                    switch (Reader[7].ToString())
                    {
                        case "U":
                            info.BabySex = Neusoft.HISFC.Models.Base.EnumSex.U;
                            break;
                        case "M":
                            info.BabySex = Neusoft.HISFC.Models.Base.EnumSex.M;
                            break;
                        case "F":
                            info.BabySex = Neusoft.HISFC.Models.Base.EnumSex.F;
                            break;
                            //{8893D34B-09AA-460f-9158-A1F48BE8B6C8} wbo 20100918
                        //case "O":
                        //    info.BabySex = Neusoft.HISFC.Models.Base.EnumSex.O;
                        //    break;
                        //case "A":
                        //    info.BabySex = Neusoft.HISFC.Models.Base.EnumSex.A;
                            break;
                    }
                    //婴儿体重
                    if (Reader[8] != DBNull.Value)
                    {
                        info.BabyWeight = Neusoft.FrameWork.Function.NConvert.ToDecimal(Reader[8].ToString());
                    }
                    else
                    {
                        info.BabyWeight = 0;
                    }
                    record.Add(info);
                    info = null;
                   
                }
                this.Reader.Close();
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                record = null;
            }
            return record;
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="obj">分娩记录实体</param>
        /// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.ChildbirthRecord.Insert", ref strSql) == -1)
                return -1;
            try
            {
                obj.HappenNO = this.GetMaxHappenNO(obj.Patient.ID);
                obj.Oper.ID = this.Operator.ID;
                object[] mm = GetInfo(obj);
                if (mm == null)
                {
                    this.Err = "业务层从实体中获取字符数组出错";
                    return -1;
                }
                strSql = string.Format(strSql, mm);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="obj">分娩记录实体</param>
        /// <returns></returns>
        public int Delete(Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.ChildbirthRecord.Delete", ref strSql) == -1)
                return -1;
            try
            {
                //格式化字符串
                strSql = string.Format(strSql, obj.Patient.ID, obj.HappenNO);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 删除患者全部记录
        /// </summary>
        /// <param name="obj">患者流水号</param>
        /// <returns></returns>
        public int DeleteAllByInpatientNO(string inpatientNO)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.ChildbirthRecord.Delete.All", ref strSql) == -1)
                return -1;
            try
            {
                //格式化字符串
                strSql = string.Format(strSql, inpatientNO);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="obj">分娩记录实体</param>
        /// <returns></returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord obj)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.ChildbirthRecord.Update", ref strSql) == -1)
                return -1;
            try
            {
                obj.Oper.ID = this.Operator.ID;
                object[] mm = GetInfo(obj);
                if (mm == null)
                {
                    this.Err = "业务层从实体中获取字符数组出错";
                    return -1;
                }
                strSql = string.Format(strSql, mm);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 获取发生序号
        /// </summary>
        /// <param name="Inpatient"></param>
        /// <returns></returns>
        private int GetMaxHappenNO(string InpatientNO)
        {
            //发生序号
            int HappenNum = 0;
            string strSql = "";
            if (this.Sql.GetSql("Case.ChildbirthRecord.GetMaxHappenNum", ref strSql) == -1)
                return -1;
            strSql = string.Format(strSql, InpatientNO);
            string strReturn = this.ExecSqlReturnOne(strSql);
            HappenNum = Neusoft.FrameWork.Function.NConvert.ToInt32(strReturn);
            return HappenNum;
        }

        /// <summary>
        /// 对象赋值
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private object[] GetInfo(Neusoft.HISFC.Models.HealthRecord.ChildbirthRecord info)
        {
            try
            {
                object[] s = new object[12];
                s[0] = info.Patient.ID;		//住院流水号
                s[1] = info.HappenNO;//序号  
                s[2] = Neusoft.FrameWork.Function.NConvert.ToInt32(info.IsNormalChildbirth);	//是否正常分娩
                s[3] = Neusoft.FrameWork.Function.NConvert.ToInt32(info.IsDystocia);	 //是否难产
                s[4] = info.FamilyPlanning.ID;  // 计划生育方式
                s[5] = Neusoft.FrameWork.Function.NConvert.ToInt32(info.IsPerineumBreak); // 是否会阴破裂
                s[6] = info.WomenKind.ID; //产妇类型
                s[7] = Neusoft.FrameWork.Function.NConvert.ToInt32(info.IsBreak);// 是否破裂 
                s[8] = info.BreakLevel.ID; //破裂程度
                s[9] = info.BabySex.ToString();//小孩性别
                s[10] = info.BabyWeight;//小孩体重  
                s[11] = info.Oper.ID;
                return s;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        #endregion
    }
}
