using System;
using System.Collections;
using Neusoft.NFC.Function;
using Neusoft.HISFC.Object.RADT;
using System.Collections.Generic;

namespace Neusoft.HISFC.Management.Fee
{
    /// <summary>
    /// 按照最小费用由用户在
    /// 减免界面进行减免
    /// </summary>
    public class DerateForFeeCode: Neusoft.NFC.Management.Database
    {
        /// <summary>
        /// 
        /// </summary>
        public DerateForFeeCode()
        {

        }

        #region 检索患者费用明细和减免明细多表关联
        public List<HISFC.Object.Fee.DerateFee> GetInpatientFeeDetail(string InpatientNO)
        {
            string sql = string.Empty;

            List<HISFC.Object.Fee.DerateFee> list = new List<Neusoft.HISFC.Object.Fee.DerateFee>();

            if (this.Sql.GetSql("Neusoft.UFC.InpatientFee.Fee.DerateFee1",ref sql) == -1)
            {
                this.Err = "没有找到索引为Neusoft.UFC.InpatientFee.Fee.DerateFee1的sql语句！";

                return null;
            }
            try
            {
                sql = string.Format(sql, InpatientNO);

                if (this.ExecQuery(sql) < 0)
                {
                    this.Err = "查询患者费用明细及减免明细出错！";

                    return null;
                }

                while (Reader.Read())
                {
                    //t3.inpatient_no,t3.fee_code,t3.name,t3.fee_stat_cate,t3.fee_stat_name,
                    //t3.tot_cost,t4.derate_cost,t4.derate_kind,t4.derate_cause,
                    //t4.oper_code,t4.oper_date,t4.cancel_code,t4.cancel_date

                    HISFC.Object.Fee.DerateFee getValueObj = new HISFC.Object.Fee.DerateFee();

                    getValueObj.FeeCode = this.Reader[1].ToString();
                    getValueObj.FeeName = this.Reader[2].ToString();
                    getValueObj.FeeStatCate = this.Reader[3].ToString();
                    getValueObj.FeeStatName = this.Reader[4].ToString();
                    getValueObj.FeeTotCost = NFC.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                    getValueObj.DerateCost = NFC.Function.NConvert.ToDecimal(this.Reader[6].ToString());
                    getValueObj.DerateType.ID = this.Reader[7].ToString();
                    getValueObj.DerateType.Name = this.Reader[8].ToString();
                    getValueObj.DerateOper.ID = this.Reader[9].ToString();
                    getValueObj.DerateOper.OperTime = NFC.Function.NConvert.ToDateTime(this.Reader[10].ToString());
                    getValueObj.CancelDerateOper.ID = this.Reader[11].ToString();
                    getValueObj.CancelDerateOper.OperTime = NFC.Function.NConvert.ToDateTime(this.Reader[12].ToString());

                    list.Add(getValueObj);
                }

                this.Reader.Close();
         
                return list;
            }
            catch (Exception ex)
            {
                this.Reader.Close();
                this.Err = ex.Message;

                return null;
            }
        }
        #endregion

        #region 更新减免，或取消减免
        /// <summary>
        /// 更新减免，或取消减免
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateDertaeInfo(HISFC.Object.Fee.DerateFee obj)
        {
            string updateSql = string.Empty;

            if (this.Sql.GetSql("Neusoft.UFC.InpatientFee.Fee.DerateFee2", ref updateSql) == -1)
            {
                this.Err = "未找到索引为Neusoft.UFC.InpatientFee.Fee.DerateFee2的sql语句！";

                return -1;
            }

            try
            {
                //t.derate_kind,t.derate_cause ,t.fee_code',t.derate_cost,
                //t.oper_code',t.cancel_code,t.cancel_date,t.clinic_no
                string derate_kind = "3";
                int updateRows;
                updateSql = string.Format(updateSql, derate_kind,
                                                    obj.DerateType.Name,
                                                    obj.FeeCode,
                                                    obj.DerateCost,
                                                    obj.DerateOper.ID,
                                                    obj.DerateOper.OperTime,
                                                    obj.CancelDerateOper.ID,
                                                    obj.CancelDerateOper.OperTime,
                                                    obj.InpatientNO);

                updateRows = this.ExecNoQuery(updateSql);

                return updateRows;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }            
        }
        #endregion

        #region 新增减免记录
        public int insertDerateRecords(HISFC.Object.Fee.DerateFee obj)
        {
            string insertSql = string.Empty;
            if (this.Sql.GetSql("Neusoft.UFC.InpatientFee.Fee.DerateFee3", ref insertSql) == -1)
            {
                this.Err = "未找到索引为Neusoft.UFC.InpatientFee.Fee.DerateFee3的sql语句";
                return -1;
            }
            try
            {
                //OPER_CODE , OPER_DATE , CLINIC_NO ,HAPPEN_NO ,  DERATE_KIND ,FEE_CODE ,                            
	            //DERATE_COST ,DERATE_CAUSE,DEPT_CODE,BALANCE_NO ,BALANCE_STATE,  CANCEL_CODE ,CANCEL_DATE
                obj.DerateType.ID = "3";
                string balanceNO = "0";
                string balanceState = "0";
                insertSql = string.Format(insertSql,obj.DerateOper.ID,
                                                    obj.DerateOper.OperTime,
                                                    obj.InpatientNO,
                                                    obj.DerateType.ID,
                                                    obj.FeeCode,
                                                    obj.DerateCost,
                                                    obj.DerateType.Name,
                                                    obj.DerateOper.Dept.ID,
                                                    balanceNO,
                                                    balanceState,
                                                    obj.CancelDerateOper.ID,
                                                    obj.CancelDerateOper.OperTime);

                return (this.ExecNoQuery(insertSql)); 
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }
        #endregion
    }
}
