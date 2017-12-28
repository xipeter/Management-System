using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord
{
    public class HealthRecordBase : IntegrateBase
    {
        protected Neusoft.HISFC.BizLogic.HealthRecord.ICD icdMgr = new Neusoft.HISFC.BizLogic.HealthRecord.ICD();
        protected Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diagMgr = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            icdMgr.SetTrans(trans);
            diagMgr.SetTrans(trans);
        }
        /// <summary>
        /// 获得相应查询类别的ICD信息 
        /// </summary>
        /// <param name="ICDType">诊断类型枚举</param>
        /// <param name="queryType">查询类型枚举</param>
        public ArrayList ICDQuery(ICDTypes ICDType, QueryTypes queryType)
        {
            this.SetDB(icdMgr);
            return icdMgr.Query(ICDType, queryType);
        } 
         /// <summary>
        /// 删除一个患者的所有病案诊断信息
        /// </summary>
        /// <param name="InpatientNO">string 患者住院流水号</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int DeleteDiagnoseAll(string InpatientNO, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            this.SetDB(diagMgr);
            return diagMgr.DeleteDiagnoseAll(InpatientNO, OperType);
        }
        /// <summary>
        /// 插入病案诊断信息
        /// </summary>
        /// <param name="Item">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int InsertDiagnose(Neusoft.HISFC.Models.HealthRecord.Diagnose Item)
        {
            this.SetDB(diagMgr);
            return diagMgr.InsertDiagnose(Item);
        }
         /// <summary>
        /// 获得病案诊断表中的患者诊断信息,针对已经有病案的患者查询 
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <param name="diagType">诊断类型 门诊诊断，入院诊断等 查询所有的可以输入 %</param>
        /// <param name="OperType">"DOC"查询医生站录入的诊断信息 “CAS" 查询病案是录入的诊断信息</param>
        /// <returns>诊断信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Diagnose</returns>
        public ArrayList QueryCaseDiagnose(string InpatientNO, string diagType, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            this.SetDB(diagMgr);
            return diagMgr.QueryCaseDiagnose(InpatientNO,diagType, OperType);
        }
        /// <summary>
        /// 更新病案诊断记录
        /// </summary>
        /// <param name="dgMc">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int UpdateDiagnose(Neusoft.HISFC.Models.HealthRecord.Diagnose dg)
        {
            this.SetDB(diagMgr);
            return diagMgr.UpdateDiagnose(dg);
        }
        public int DeleteDiagnoseSingle(string InpatientNO, int happenNO, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes OperType)
        {
            this.SetDB(diagMgr);
            return diagMgr.DeleteDiagnoseSingle(InpatientNO, happenNO, OperType);
        }

        /// <summary>
        /// 查询患者诊断,不包括手术诊断 met_com_diagnose {5F752A30-7971-4b65-A84B-D233EF2A4406}
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryDiagnoseNoOps(string inpatientNO)
        {
            this.SetDB(diagMgr);
            return diagMgr.QueryDiagnoseNoOps(inpatientNO);
        }

        #region {6EF7D73B-4350-4790-B98C-C0BD0098516E}

        /// <summary>
        /// 查询所有科常用诊断
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        public ArrayList QueryDeptDiag(string deptID)
        {
            this.SetDB(icdMgr);

            return icdMgr.QueryDeptDiag(deptID);
        }

        #endregion

    }
}
