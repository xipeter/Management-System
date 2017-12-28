using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    public class Fee : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 输入住院流水号 从费用明细表里 查询费用信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        public ArrayList QueryFeeInfoState(string InpatientNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.BaseDML.GetFeeInfoState", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.RADT.Patient info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.Patient();
                    info.DIST = this.Reader[0].ToString(); //统计大类编码
                    info.AreaCode = this.Reader[1].ToString(); //统计名称 
                    info.IDCard = this.Reader[2].ToString(); //统计费用
                    List.Add(info);
                    info = null;
                }
                return List;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        ///从病案信息表里查询信息 
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        public ArrayList QueryCaseFeeState(string InpatientNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.BaseDML.GetCaseFeeState", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.RADT.Patient info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.Patient();
                    info.DIST = this.Reader[4].ToString(); //统计大类编码
                    info.AreaCode = this.Reader[5].ToString(); //统计名称 
                    info.IDCard = this.Reader[6].ToString(); //统计费用
                    List.Add(info);
                    info = null;
                }
                return List;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="info"> 这里借用了患者实体来存储费用信息</param>
        /// <returns></returns>
        public int InsertFeeInfo(Neusoft.HISFC.Models.RADT.Patient info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.BaseDML.InsertFeeInfo", ref strSql) == -1) return -1;
            try
            {
                //查询
                strSql = string.Format(strSql, GetInfo(info));
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 更新一条数据 如果更新失败 则执行插入操作
        /// </summary>
        /// <param name="info">这里借用了患者实体来存储费用信息</param>
        /// <returns></returns>
        public int UpdateFeeInfo(Neusoft.HISFC.Models.RADT.Patient info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Case.BaseDML.UpdateFeeInfo", ref strSql) == -1) return -1;
            try
            {
                //查询
                strSql = string.Format(strSql, GetInfo(info));
                int i = this.ExecNoQuery(strSql);
                if (i < 1) //更新失败 
                {
                    return InsertFeeInfo(info); //执行插入操作
                }
                else
                {
                    return i;
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 获取实体里的数据
        /// </summary>
        /// <param name="info">这里借用了患者实体来存储费用信息</param>
        /// <returns></returns>
        private string[] GetInfo(Neusoft.HISFC.Models.RADT.Patient info)
        {
            string[] str = new string[8];
            str[0] = info.ID; //住院流水号 
            str[2] = info.DIST; //统计大类
            str[3] = info.AreaCode; //统计名称
            str[4] = info.IDCard; //统计费用
            str[5] = info.User01; //出院日期
            str[7] = this.Operator.ID; //操作员
            return str;
        }

        #region 废弃
        /// <summary>
        ///从病案信息表里查询信息 
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        [Obsolete("废弃 ,用QueryCaseFeeState 代替")]
        public ArrayList GetCaseFeeState(string InpatientNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.BaseDML.GetCaseFeeState", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.RADT.Patient info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.Patient();
                    info.DIST = this.Reader[4].ToString(); //统计大类编码
                    info.AreaCode = this.Reader[5].ToString(); //统计名称 
                    info.IDCard = this.Reader[6].ToString(); //统计费用
                    List.Add(info);
                    info = null;
                }
                return List;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 输入住院流水号 从费用明细表里 查询费用信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        [Obsolete("废弃,用 QueryFeeInfoState 代替")]
        public ArrayList GetFeeInfoState(string InpatientNo)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("Case.BaseDML.GetFeeInfoState", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, InpatientNo);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.RADT.Patient info = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.Patient();
                    info.DIST = this.Reader[0].ToString(); //统计大类编码
                    info.AreaCode = this.Reader[1].ToString(); //统计名称 
                    info.IDCard = this.Reader[2].ToString(); //统计费用
                    List.Add(info);
                    info = null;
                }
                return List;
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
