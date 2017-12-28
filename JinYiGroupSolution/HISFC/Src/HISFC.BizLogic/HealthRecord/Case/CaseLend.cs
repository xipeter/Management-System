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
    /// [功能描述: 病历查询借阅]<br></br>
    /// [创 建 者: 蒋飞]<br></br>
    /// [创建时间: 2007-08-27]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
        public class CaseLend : Neusoft.FrameWork.Management.Database
        {


        #region 查询

        /// <summary>
        ///　根据病历编码查询病历的信息
        /// </summary>
        /// <param name="">病历流水号</param>
        /// <returns>信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Case.CaseLend</returns>

        
        public ArrayList Query(string billID)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseLend.Select", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, billID);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Case.CaseLend caseLend = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    caseLend = new Neusoft.HISFC.Models.HealthRecord.Case.CaseLend();
                    caseLend.ID = this.Reader[0].ToString();         //病历号 
                    caseLend.LendEmpl.ID= this.Reader[2].ToString(); //借阅员工号
                    caseLend.StartingTime =NConvert.ToDateTime(this.Reader[3].ToString()); //开始借阅时间
                    caseLend.EndTime = NConvert.ToDateTime(this.Reader[4].ToString());           //归还时间 
                    caseLend.AuditingOper.ID = this.Reader[6].ToString(); //审核员工号
                    caseLend.AuditingOper.OperTime = NConvert.ToDateTime(this.Reader[7].ToString()); //出库审核时间
                    caseLend.IsAuditing = NConvert.ToBoolean(this.Reader[8].ToString()); //是否出库审核 
                    caseLend.IsReturn = NConvert.ToBoolean(this.Reader[9].ToString()); //是否已经归还
                    caseLend.ReturnOper.ID = this.Reader[10].ToString(); //归还员工号
                    caseLend.ReturnOper.OperTime = NConvert.ToDateTime(this.Reader[11].ToString()); //实际归还时间
                    caseLend.ReturnConfirmOper.ID = this.Reader[12].ToString();           //归还确认人工号 
                    caseLend.ReturnConfirmOper.OperTime = NConvert.ToDateTime(this.Reader[13].ToString()); //归还确认时间
                    if (this.Reader[14].ToString().Equals("0"))        //业务类型
                    {
                        caseLend.LendType = Neusoft.HISFC.Models.HealthRecord.Case.EnumLendType.Lend;
                    }
                    else
                    {
                        caseLend.LendType = Neusoft.HISFC.Models.HealthRecord.Case.EnumLendType.Refer;
                    }                  
                               
                    caseLend = null;
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
