using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.RADT;

namespace Neusoft.Report.InpatientFee.Class
{
    public class LocalInpatientManager:Neusoft.NFC.Management.Database
    {
        /// <summary>
        /// 获取sql执行操作
        /// </summary>
        /// <param name="sqlIndex"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private int UpdateSingleTable(string sqlIndex, params string[] args)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

                return -1;
            }

            return this.ExecNoQuery(sql, args);
        }

        /// <summary>
        /// 更新FIN_IPB_ITEMLIST合同单位（变更身份用）
        /// </summary>
        /// <param name="parmPatientinfo"></param>
        /// <returns></returns>
        public int UpdateItemListForChangePact(PatientInfo parmPatientinfo)
        {
            return this.UpdateSingleTable("LiaoCheng.InPatient.UpdateItemListForChangePact", parmPatientinfo.ID, parmPatientinfo.Pact.PayKind.ID, parmPatientinfo.Pact.ID);
        }

        /// <summary>
        /// 更新FIN_IPB_MEDICINELIST合同单位（变更身份用）
        /// </summary>
        /// <param name="parmPatientinfo"></param>
        /// <returns></returns>
        public int UpdateMedicineListForChangePact(PatientInfo parmPatientinfo)
        {
            return this.UpdateSingleTable("LiaoCheng.InPatient.UpdateMedicineListForChangePact", parmPatientinfo.ID, parmPatientinfo.Pact.PayKind.ID, parmPatientinfo.Pact.ID);
        }

        /// <summary>
        /// 更新FIN_IPB_FEEINFO合同单位（变更身份用）
        /// </summary>
        /// <param name="parmPatientinfo"></param>
        /// <returns></returns>
        public int UpdateFeeinfoForChangePact(PatientInfo parmPatientinfo)
        {
            return this.UpdateSingleTable("LiaoCheng.InPatient.UpdateFeeInfoForChangePact", parmPatientinfo.ID, parmPatientinfo.Pact.PayKind.ID, parmPatientinfo.Pact.ID);
        }
    }
}
