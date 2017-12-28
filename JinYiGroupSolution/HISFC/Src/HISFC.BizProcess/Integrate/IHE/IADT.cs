using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Integrate.IHE
{
    /// <summary>
    /// [功能描述：ADT接口]
    /// [创 建 者：薛文进]
    /// [创建时间：2010-03-08]
    /// </summary>
    public interface IADT
    {
        /// <summary>
        /// 登记住院患者
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int RegInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 预登记住院患者
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int PreRegInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        int PreRegOutpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 登记出院患者
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int RegOutPatient(Neusoft.HISFC.Models.Registration.Register patient);

        /// <summary>
        /// 更新住院患者信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int UpdatePatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 传送住院患者信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int TransferPatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 取消转科
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int CancelTransferPatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 在院患者转出
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int InPatientToOutpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 患者转入
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int OutpatientToInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 合并患者
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="patient2"></param>
        /// <returns></returns>
        int MergeInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.RADT.PatientInfo patient2);

        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int DischargeInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 取消预约登记的患者
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int CancelPreRegInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 无费退院
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int CancelRegPatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 登记召回
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        int CancelDischargePatientMessage(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 生成住院患者转门诊的HL7消息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Neusoft.HISFC.Models.Registration.Register ProduceInpatientToOutPatientMessage(Neusoft.HISFC.Models.RADT.PatientInfo patient);

    }
}
