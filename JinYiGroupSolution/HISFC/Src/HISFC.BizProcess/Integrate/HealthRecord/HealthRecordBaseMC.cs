using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.HealthRecord
{
    /// <summary>
    /// 类名称<br>HealthRecordBaseMC</br>
    /// <Font color='#FF1111'>医保诊断信息录入、查询等</Font><br></br>
    /// [创 建 者: ]<br>耿晓雷</br>
    /// [创建时间: ]<br>2007-08-13</br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public class HealthRecordBaseMC : IntegrateBase
    {
        	/// <summary>
	/// 构造函数
	/// </summary>
        public HealthRecordBaseMC()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 变量

        #region 私有
        //{3FE817A1-97AF-4857-9597-E81ADD845022}
        private Neusoft.HISFC.BizLogic.HealthRecord.Diagnose diagManager = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();

        #endregion

        #region 保护

        protected static Neusoft.HISFC.BizLogic.HealthRecord.ICDMedicare icdMgr = new Neusoft.HISFC.BizLogic.HealthRecord.ICDMedicare();
        protected static Neusoft.HISFC.BizLogic.HealthRecord.DiagnoseMedicare diagMgr = new Neusoft.HISFC.BizLogic.HealthRecord.DiagnoseMedicare();

        
        #endregion

        #region 公开
        #endregion

        #endregion

        #region 属性
        #endregion

        #region 方法

        #region 私有
        #endregion

        #region 保护
        #endregion

        #region 公开

        //{3FE817A1-97AF-4857-9597-E81ADD845022}
        public ArrayList QueryDiagnoseNoOps(string PatientNo)
        {
            this.SetDB(diagManager);
            return diagManager.QueryDiagnoseNoOps(PatientNo);
        }


        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            icdMgr.SetTrans(trans);
            diagMgr.SetTrans(trans);
        }
        /// <summary>
        /// 查询医保ICD
        /// </summary>
        /// <param name="dType">查询类别 0 全部，1 ICD10，2 市医保，3 省医保</param>
        /// <returns></returns>
        public ArrayList ICDQueryMc(String dType)
        {
            this.SetDB(icdMgr);
            return icdMgr.Query(dType);
        } 
        /// <summary>
        /// 插入病案诊断信息
        /// </summary>
        /// <param name="Item">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int InsertDiagnoseMC(Neusoft.HISFC.Models.HealthRecord.Diagnose Item)
        {
            this.SetDB(diagMgr);
            return diagMgr.InsertDiagnoseMedicare(Item);
        }
        /// <summary>
        /// 查询医保诊断信息
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <param name="HappenNo">发生序号 查询所有可输入%</param>
        /// <returns>诊断信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Diagnose</returns>
        public ArrayList QueryCaseDiagnose(string InpatientNO, string HappenNo)
        {
            this.SetDB(diagMgr);
            return diagMgr.QueryDiagnoseMedicare(InpatientNO, HappenNo);
        }
        /// <summary>
        /// 查询医保与病案全部的诊断信息
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <returns>诊断信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Diagnose</returns>
        public ArrayList QueryDiagnoseBoth(string InpatientNO)
        {
            this.SetDB(diagMgr);
            return diagMgr.QueryDiagnoseBoth(InpatientNO);
        }
        /// <summary>
        /// 更新医保诊断记录
        /// </summary>
        /// <param name="dgMc">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>int 0 成功 -1 失败</returns>
        public int UpdateDiagnoseMedicare(Neusoft.HISFC.Models.HealthRecord.Diagnose dgMc)
        {
            this.SetDB(diagMgr);
            return diagMgr.UpdateDiagnoseMedicare(dgMc);
        }
        public int DeleteDiagnoseMedicare(String InpatientNO, int happenNO)
        {
            this.SetDB(diagMgr);
            return diagMgr.DeleteDiagnoseMedicare(InpatientNO, happenNO);
        }
        /// <summary>
        /// 获取出院主诊断
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns></returns>
        public ArrayList GetOutMainDiagnose(string inpatientNo)
        {
            this.SetDB(diagMgr);
            return diagMgr.GetOutMainDiagnose(inpatientNo);
        }
        #endregion

        #endregion

        #region 接口实现
        #endregion


    }
}
