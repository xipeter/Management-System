using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.HealthRecord;
using Neusoft.FrameWork.Function;
using System.Data;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Case
{
    /// <summary>
    /// Visit<br></br>
    /// [功能描述: 病案柜基本维护]<br></br>
    /// [创 建 者: 蒋飞]<br></br>
    /// [创建时间: 2007-08-21]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CaseCabinet : Neusoft.FrameWork.Management.Database
    {
        #region 数据库基本操作

        /// <summary>
        /// 新增病案柜
        /// </summary>
        /// <param name="caseCabinet">病案柜记录类</param>
        /// <returns>出现异常返回－1 成功返回1 插入失败返回 0</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet caseCabinet)
        {

            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseCabinet.Insert", ref strSql) == -1) return -1;
            try
            {
                //插入
                strSql = string.Format(strSql, GetInfo(caseCabinet));
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }      

        }

        private string[] GetInfo(Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet caseCabinet)
        {
            string[] str = new string[7];
            str[0] = caseCabinet.Store.ID; //病案库编码 
            str[1] = caseCabinet.ID;       //病案柜编码
            str[2] = caseCabinet.GridCount.ToString(); //格数
            if (caseCabinet.IsValid)
            {
                str[3] = "1";
            }
            else
            {
                str[3] = "0";
            }
            str[4] = caseCabinet.Memo;  //备注
            str[5] = caseCabinet.OperEnv.ID; //最后一次操作员工号
            str[6] = caseCabinet.OperEnv.OperTime.ToString(); //最后一次操作时间
           
            return str;
        }

        /// <summary>
        /// 更新病案柜记录
        /// </summary>
        /// <param name="caseCabinet">病案柜记录类</param>
        /// <returns>影响的行数-成功;-1-更新失败,0-异常</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet caseCabinet)
        {
            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseCabinet.Update", ref strSql) == -1) return -1;
            try
            {
                string[] strParm = GetInfo(caseCabinet);
                strSql = string.Format(strSql, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                 return -1;
            }

            //　执行SQL语句返回
            return this.ExecNoQuery(strSql);

        }
        /// <summary>
       
        #endregion

        #region 查询

        /// <summary>
        ///　根据病案柜编码查询病案柜的信息
        /// </summary>
        /// <param name="cabinetCode,cabinetCode">病案柜编码</param>
        /// <returns>信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet</returns>

        public ArrayList Query(string storeCode, string cabinetCode)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseCabinet.Select", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, storeCode, cabinetCode);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet cabinet = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    cabinet = new Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet();
                    cabinet.Store.ID = this.Reader[0].ToString();        //病案库编码
                    cabinet.ID = this.Reader[1].ToString();        //病案库编码
                    cabinet.GridCount = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[2].ToString()); // 病案柜格数
                    //Cabinet.IsValid = this.Reader[3].ToString().Equals("0") ? false : true;   //是否有效：1－是、0－否
                    cabinet.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());//是否有效：1－是、0－否
                    cabinet.Memo = this.Reader[4].ToString();      //备注
                    cabinet.OperEnv.ID = this.Reader[5].ToString();//最后一次操作员工号                  
                    cabinet.OperEnv.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());  //最后一次操作时间
                    List.Add(cabinet);
                    cabinet = null;
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
        ///　根据病案柜编码查询病案柜的信息
        /// </summary>
        /// <param name="cabinetCode,cabinetCode">病案柜编码</param>
        /// <returns>信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet</returns>
        public ArrayList QueryAll()
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseCabinet.SelectAll", ref strSql) == -1)
                return null;
            try
            {
                //查询
                strSql = string.Format(strSql);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet cabinet = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    cabinet = new Neusoft.HISFC.Models.HealthRecord.Case.CaseCabinet();
                    cabinet.Store.ID = this.Reader[0].ToString();        //病案库编码
                    cabinet.ID = this.Reader[1].ToString();        //病案柜编码
                    cabinet.GridCount = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[2].ToString()); // 病案柜格数
                    cabinet.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[3].ToString());//是否有效：1－是、0－否
                    cabinet.Memo = this.Reader[4].ToString();      //备注
                    cabinet.OperEnv.ID = this.Reader[5].ToString();//最后一次操作员工号
                    cabinet.OperEnv.Name = this.Reader[6].ToString();
                    cabinet.OperEnv.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString());  //最后一次操作时间
                    List.Add(cabinet);
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
