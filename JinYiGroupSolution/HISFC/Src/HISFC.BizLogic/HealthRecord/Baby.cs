using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public class Baby : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 查询某个住院号下的婴儿信息
        /// </summary>
        /// <param name="inpatientNo"> 住院号</param>
        /// <returns> 返回符合条件的信息</returns>
        public ArrayList QueryBabyByInpatientNo(string inpatientNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.CBaby.SelectInfo", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, inpatientNo);
                //查询
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Baby info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.Baby();
                    info.InpatientNo = Reader[0].ToString();
                    info.HappenNum = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1]);
                    info.SexCode = Reader[2].ToString();
                    info.BirthEnd = Reader[3].ToString();
                    if (Reader[4] != DBNull.Value)
                    {
                        info.Weight = Convert.ToSingle(Reader[4]);
                    }
                    else
                    {
                        info.Weight = 0;
                    }
                    info.BabyState = Reader[5].ToString();
                    info.Breath = Reader[6].ToString();
                    if (Reader[7] != DBNull.Value)
                    {
                        info.InfectNum = Convert.ToInt32(Reader[7].ToString());
                    }
                    info.Infect.ID = Reader[8].ToString();
                    info.Infect.Name = Reader[9].ToString();
                    if (Reader[10] != DBNull.Value)
                    {
                        info.SalvNum = Convert.ToInt32(Reader[10].ToString());
                    }
                    if (Reader[11] != DBNull.Value)
                    {
                        info.SuccNum = Convert.ToInt32(Reader[11].ToString());
                    }
                    List.Add(info);
                    info = null;
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }

        /// <summary>
        /// 查询某个住院号下的最大的序号
        /// Creator: zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="Inpatient"></param>
        /// <returns></returns>
        public int GetMaxHappenNum(string Inpatient)
        {
            //发生序号
            int HappenNum = 0;
            string strSql = "";
            if (this.Sql.GetSql("Case.CBaby.GetMaxHappenNum", ref strSql) == -1) return -1;
            strSql = string.Format(strSql, Inpatient);
            string strReturn = this.ExecSqlReturnOne(strSql);
            //取发生序号
            HappenNum = Neusoft.FrameWork.Function.NConvert.ToInt32(strReturn);
            return HappenNum;
        }
        /// <summary>
        ///更新某条记录
        ///zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="info"></param>
        /// <returns>失败返回 －1 成功返回 1</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.Baby info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.CBaby.Update", ref strSql) == -1) return -1;
            try
            {
                info.OperInfo.ID = this.Operator.ID;
                object[] mm = GetInfo(info);
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
        ///插入某条记录
        ///zhangjunyi@neusoft.com
        /// </summary>
        /// <param name="info"></param>
        /// <returns>失败返回 －1 成功返回 1</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Baby info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.CBaby.Insert", ref strSql) == -1) return -1;
            try
            {
                info.HappenNum = GetMaxHappenNum(info.InpatientNo);
                info.OperInfo.ID = this.Operator.ID;
                object[] mm = GetInfo(info);
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
        private object[] GetInfo(Neusoft.HISFC.Models.HealthRecord.Baby info)
        {
            try
            {
                object[] s = new object[14];
                s[0] = info.InpatientNo;		//住院流水号
                s[1] = info.HappenNum;//婴儿序号  
                s[2] = info.SexCode;			//性别   M 男性 F女性 
                s[3] = info.BirthEnd;	 //妊辰结果 0 活产 1 死产 2  死胎    
                s[4] = info.Weight;  //  体重  
                s[5] = info.BabyState; // 转归  0 死亡  1 转科 2 出院   
                s[6] = info.Breath; //呼吸  0 自然 1 I度窒息 2 II度窒息 
                s[7] = info.InfectNum;// 感染次数  
                s[8] = info.Infect.ID; //感染代码
                s[9] = info.Infect.Name;//感染名称
                s[10] = info.SalvNum;// 抢救次数  
                s[11] = info.SuccNum;// 成功次数   
                s[12] = info.BirthMod;//生产方式 
                s[13] = info.OperInfo.ID;//记录人
                return s;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns>成功返回 1 失败返回 －1 </returns>
        public int Delete(Neusoft.HISFC.Models.HealthRecord.Baby info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.CBaby.Delete", ref strSql) == -1) return -1;
            try
            {
                //格式化字符串
                strSql = string.Format(strSql, info.InpatientNo, info.HappenNum);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        #region 废弃
        /// <summary>
        /// 婴儿转归
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 常数 ZG 表示", true)]
        public ArrayList GetBabyState()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "死亡";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "转科";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "出院";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 呼吸
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 常数 BREATHSTATE 表示", true)]
        public ArrayList GetBreath()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "自然";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "I度感染";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "II度感染";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 分娩结果
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 常数 CHILDBEARINGRESULT 表示", true)]
        public ArrayList GetBirthEnd()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "活产";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "死产";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "死胎";
            //list.Add(info);
            return list;

        }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃 枚举表示" ,true)]
        public ArrayList GetSex()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "男";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "女";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 查询某个住院号下的婴儿信息
        /// </summary>
        /// <param name="inpatientNo"> 住院号</param>
        /// <returns> 返回符合条件的信息</returns>
        [Obsolete("废弃 用QueryBabyByInpatientNo代替",true)]
        public ArrayList SelectInfo(string inpatientNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.CBaby.SelectInfo", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, inpatientNo);
                //查询
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Baby info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.HealthRecord.Baby();
                    info.InpatientNo = Reader[0].ToString();
                    info.HappenNum = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1]);
                    info.SexCode = Reader[2].ToString();
                    info.BirthEnd = Reader[3].ToString();
                    if (Reader[4] != DBNull.Value)
                    {
                        info.Weight = Convert.ToSingle(Reader[4]);
                    }
                    else
                    {
                        info.Weight = 0;
                    }
                    info.BabyState = Reader[5].ToString();
                    info.Breath = Reader[6].ToString();
                    if (Reader[7] != DBNull.Value)
                    {
                        info.InfectNum = Convert.ToInt32(Reader[7].ToString());
                    }
                    info.Infect.ID = Reader[8].ToString();
                    info.Infect.Name = Reader[9].ToString();
                    if (Reader[10] != DBNull.Value)
                    {
                        info.SalvNum = Convert.ToInt32(Reader[10].ToString());
                    }
                    if (Reader[11] != DBNull.Value)
                    {
                        info.SuccNum = Convert.ToInt32(Reader[11].ToString());
                    }
                    List.Add(info);
                    info = null;
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                List = null;
            }
            return List;
        }
        #endregion 

    }
}
