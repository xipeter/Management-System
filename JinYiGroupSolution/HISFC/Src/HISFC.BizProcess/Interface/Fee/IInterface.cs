using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Neusoft.HISFC.Models.Registration;

namespace Neusoft.HISFC.BizProcess.Interface.FeeInterface
{

    /// <summary>
    /// IConnect 的摘要说明。
    /// </summary>
    public interface IMedcareTranscation
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        long Connect();

        /// <summary>
        /// 数据库关闭
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        long Disconnect();

        /// <summary>
        /// 数据库提交
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        long Commit();

        /// <summary>
        /// 数据库回滚
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        long Rollback();

        /// <summary>
        /// 开始数据库事务
        /// </summary>
        void BeginTranscation();
    }
    
    /// <summary>
    /// 医保接口
    /// </summary>
    public interface IMedcare : IMedcareTranscation
    {
        /// <summary>
        /// 本地数据连接
        /// </summary>
        System.Data.IDbTransaction Trans
        {
            set;
        }
        /// <summary>
        /// 设置本地数据库连接
        /// </summary>
        /// <param name="t"></param>
        void SetTrans(System.Data.IDbTransaction t);

        /// <summary>
        /// 错误编码
        /// </summary>
        string ErrCode
        {
            get;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrMsg
        {
            get;
        }

        /// <summary>
        /// 控件描述，最好填写。
        /// </summary>
        string Description
        {
            get;
        }

        #region 公有

        /// <summary>
        /// 获得黑名单信息
        /// </summary>
        /// <param name="blackLists">黑名单信息</param>
        /// <returns>成功 >= 1 失败 -1 没有获得数据 0</returns>
        int QueryBlackLists(ref ArrayList blackLists);

        /// <summary>
        /// 验证在院患者是否属于黑名单
        /// </summary>
        /// <param name="patient">在院患者基本信息</param>
        /// <returns>在黑名单内 true 不在和名单内false</returns>
        bool IsInBlackList(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 验证门诊患者是否属于黑名单
        /// </summary>
        /// <param name="r">门诊患者基本信息</param>
        /// <returns>在黑名单内 true 不在和名单内false</returns>
        bool IsInBlackList(Neusoft.HISFC.Models.Registration.Register r);

        /// <summary>
        /// 获得非药品信息目录
        /// </summary>
        /// <param name="undrugLists">非药品信息目录</param>
        /// <returns>成功 >= 1 失败: -1 没有获得数据 0</returns>
        int QueryUndrugLists(ref ArrayList undrugLists);

        /// <summary>
        /// 获得药品信息目录
        /// </summary>
        /// <param name="drugLists">药品信息目录</param>
        /// <returns>成功 >= 1 失败: -1 没有获得数据 0</returns>
        int QueryDrugLists(ref ArrayList drugLists);

        #endregion

        #region 门诊
        /// <summary>
        /// 门诊结算时是否整体上传
        /// </summary>
        /// <remarks>true 整体上传 false 部分上传</remarks>
        bool IsUploadAllFeeDetailsOutpatient
        {
            get;
        }

        /// <summary>
        /// 门诊挂号函数
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int UploadRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r);

        /// <summary>
        /// 取消入院登记方法
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <returns>成功 1 失败 -1 没有记录 0</returns>
        int CancelRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r);
        /// <summary>
        /// 获得医保挂号信息
        /// </summary>
        /// <param name="r">门诊挂号实体</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int GetRegInfoOutpatient(Neusoft.HISFC.Models.Registration.Register r);

        /// <summary>
        /// 单条上传费用明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="f">门诊费用明细</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int UploadFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f);

        /// <summary>
        /// 多条上传费用明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="feeDetails">费用明细实体集合</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int UploadFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails);
        #region {AD6E49F9-7409-48b1-A297-73610F0072C7}
        /// <summary>
        /// 查询上传费用明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="feeDetails">费用明细实体集合</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int QueryFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails); 
        #endregion

        /// <summary>
        /// 删除单条已经上传明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="f">费用明细信息</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int DeleteUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f);

        /// <summary>
        /// 删除患者的所有费用上传明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int DeleteUploadedFeeDetailsAllOutpatient(Neusoft.HISFC.Models.Registration.Register r);

        /// <summary>
        /// 删除指定数据集的明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="feeDetails">要删除的费用实体明细</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int DeleteUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails);

        /// <summary>
        /// 修改单条门诊已上传明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="f">要修改的费用实体明细</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int ModifyUploadedFeeDetailOutpatient(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f);

        /// <summary>
        /// 修改多条门诊已上传明细
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="feeDetails">要修改的费用实体明细集合</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int ModifyUploadedFeeDetailsOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails);

        /// <summary>
        /// 医保预结算
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeDetails">患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int PreBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails);

        /// <summary>
        /// 医保结算
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeDetails">患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int BalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails);

        /// <summary>
        /// 取消结算
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeDetails">要取消结算的患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int CancelBalanceOutpatient(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails);


        /// <summary>
        /// 取消结算(半退)
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeDetails">要取消结算的患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int CancelBalanceOutpatientHalf(Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails);

        #endregion

        #region 住院

        /// <summary>
        /// 更新费用信息
        /// /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="f">费用明细</param>
        /// <returns>成功 1 失败 -1 没有更新到数据 0</returns>
        int UpdateFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f);
        
        /// <summary>
        /// 重新计算费用明细
        /// </summary>
        /// <param name="patient">住院患者基本信息</param>
        /// <param name="feeItemList">住院费用单条明细</param>
        /// <returns>成功 1 失败 -1</returns>
        int RecomputeFeeItemListInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList);

        /// <summary>
        /// 住院登记函数
        /// </summary>
        /// <param name="patient">住院登记患者基本信息</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int UploadRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 取消入院登记方法
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <returns>成功 1 失败 -1 没有记录 0</returns>
        int CancelRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 出院召回方法
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <returns>成功 1 失败 -1 没有记录 0</returns>
        int RecallRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 获得医保住院登记信息
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int GetRegInfoInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 出院登记方法
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <returns>成功 1 失败 -1 没有记录 0</returns>
        int LogoutInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 单条上传费用明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="f">住院费用明细</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int UploadFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f);

        /// <summary>
        /// 多条上传费用明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">费用明细实体集合</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int UploadFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);
        #region {AD6E49F9-7409-48b1-A297-73610F0072C7}
        /// <summary>
        /// 查询上传费用明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">费用明细实体集合</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int QueryFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);

        #endregion
        /// <summary>
        /// 删除单条已经上传明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="f">费用明细信息</param>
        /// <returns>-1 失败 0 没有记录 1 成功</returns>
        int DeleteUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f);

        /// <summary>
        /// 删除患者的所有费用上传明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int DeleteUploadedFeeDetailsAllInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient);

        /// <summary>
        /// 删除指定数据集的明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">要删除的费用实体明细</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int DeleteUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);

        /// <summary>
        /// 修改单条住院已上传明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="f">要修改的费用实体明细</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int ModifyUploadedFeeDetailInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f);

        /// <summary>
        /// 修改多条住院已上传明细
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">要修改的费用实体明细集合</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int ModifyUploadedFeeDetailsInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);

        /// <summary>
        /// 住院医保预结算
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int PreBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);

        /// <summary>
        /// 住院医保中途结算
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int MidBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);

        /// <summary>
        /// 医保结算
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int BalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);

        /// <summary>
        /// 取消结算
        /// </summary>
        /// <param name="patient">住院登记基本信息</param>
        /// <param name="feeDetails">要取消结算的患者费用信息</param>
        /// <returns>-1 失败 0 没有记录 >=1 成功</returns>
        int CancelBalanceInpatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeDetails);

        #endregion

    }
    
    
    public interface IFeeExtend 
    {
        /// <summary>
        /// 特殊验证合法性
        /// </summary>
        /// <param name="feeItemList">当前收费项目信息</param>
        /// <param name="errText">错误信息</param>
        /// <returns>true合法 false不合法</returns>
        bool IsValid(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList, ref string errText);

    }

    /// <summary>
    /// 门诊收费再次判断有效性接口;{DA12F709-B696-4eb9-AD3B-6C9DB7D780CF}
    /// </summary>
    public interface IFeeExtendOutpatient 
    {
        /// <summary>
        /// 本地事务
        /// </summary>
        System.Data.IDbTransaction Trans
        {
            set;
        }
        
        /// <summary>
        /// 验证门诊收费正常业务结束后,事务提交前,补充判断的方法
        /// </summary>
        /// <param name="r">患者挂号实体</param>
        /// <param name="Invoices">发票实体集合</param>
        /// <param name="feeItemLists">费用明细实体结合</param>
        /// <param name="otherObjects">其他对象,根据当前项目实际传入判断,默认: object[0] 支付方式实体集合 object[1] 发票明细集合</param>
        /// <returns>成功 true 失败 false</returns>
        bool IsValid(Neusoft.HISFC.Models.Registration.Register r, ArrayList Invoices, ArrayList feeItemLists, params object[] otherObjects);

        /// <summary>
        /// 错误信息
        /// </summary>
        string Err
        {
            get;
        }
    }//{DA12F709-B696-4eb9-AD3B-6C9DB7D780CF}结束
    
    
    /// <summary>
    /// 住院登记扩展信息
    /// </summary>
    public interface IRegisterExtend 
    {
        /// <summary>
        /// 附加判断输入的合法性
        /// </summary>
        /// <returns>成功: true 失败: false</returns>
        bool IsInputValid(System.Windows.Forms.Control errControl, ref string errText);

        /// <summary>
        /// 在指定的TabIndex控件之后弹出扩展窗口
        /// </summary>
        /// <param name="tabIndex">指定的TabIndex</param>
        /// <param name="patient">当前的患者基本信息实体</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 1 失败: -1</returns>
        int OpenExtendInputWindow(int tabIndex, Neusoft.HISFC.Models.RADT.Patient patient, ref string errText);

        /// <summary>
        /// 如果有附加信息录入,那么获得该录入信息
        /// </summary>
        /// <param name="patient">当前患者基本信息实体</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 1 失败: -1</returns>
        int GetExtentPatientInfomation(Neusoft.HISFC.Models.RADT.Patient patient, ref string errText);

        /// <summary>
        /// 如果有附加信息,并且不在PatientInfo实体并且需要新的业务插入的时候,
        /// 如果主键重复,自己写处理.
        /// </summary>
        /// <param name="patient">当前患者基本信息实体</param>
        /// <param name="t">当前的数据库事务</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 1 失败: -1 没有插入数据 0</returns>
        int InsertOtherInfomation(Neusoft.HISFC.Models.RADT.Patient patient, Neusoft.FrameWork.Management.Transaction t, ref string errText);

        /// <summary>
        /// 如果有附加信息,并且不在PatientInfo实体并且需要新的业务更新的时候,
        /// 如果主键重复,自己写处理.
        /// </summary>
        /// <param name="patient">当前患者基本信息实体</param>
        /// <param name="t">当前的数据库事务</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 1 失败: -1 没有插入数据 0</returns>
        int UpdateOtherInfomation(Neusoft.HISFC.Models.RADT.Patient patient, ref string errText);

        /// <summary>
        /// 清空其他信息,包括新增的控件等
        /// </summary>
        void ClearOtherInfomation();

        /// <summary>
        /// 初始化扩展信息
        /// </summary>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        int InitExtendInfomation(ref string errText);
    }

    public interface IBackFeeRecipePrint
    {
        Neusoft.HISFC.Models.Registration.Register Patient
        {
            set;
        }

        int SetData(ArrayList alBackFee);

        void Print();
    }
    #region 住院证打印接口
    public interface IInpatientProofPrint
    {
        System.Data.IDbTransaction Trans
        {
            get;
            set;
        }
        /// <summary>
        /// 住院证信息
        /// </summary>
        int SetValue(Neusoft.HISFC.Models.RADT.InPatientProof InPatientProof);

        /// <summary>
        /// 预交金打印函数
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Print();

        /// <summary>
        /// 清空当前信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Clear();

        /// <summary>
        /// 设置本地数据库连接
        /// </summary>
        /// <param name="trans">数据库连接</param>
        void SetTrans(System.Data.IDbTransaction trans);
    }

    #endregion

    #region 预交金打印

    /// <summary>
    /// 预交金发票打印接口
    /// </summary>
    public interface IPrepayPrint 
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        System.Data.IDbTransaction Trans
        {
            get;
            set;
        }
        
        /// <summary>
        /// 设置发票打印参数
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <param name="prepay">预交金打印实体</param>
        /// <returns>成功 1 失败 -1</returns>
        int SetValue(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay);

        /// <summary>
        /// 预交金打印函数
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Print();

        /// <summary>
        /// 清空当前信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Clear();

        /// <summary>
        /// 设置本地数据库连接
        /// </summary>
        /// <param name="trans">数据库连接</param>
        void SetTrans(System.Data.IDbTransaction trans);
    }

    #endregion

    #region "住院发票打印"

    public interface IBalanceInvoicePrint
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        System.Data.IDbTransaction Trans
        {
            get;
            set;
        }

        #region liuqiang 2007-8-23 修改
        #region 修改原因
        //>     现在打印遇到个问题。按照刚才你和王儒超定的。可以按合同单位维护。
        //> 
        //> 但东电医院医保和生育保险是两种发票。但合同单位全是医保。是通过medicaltype区分是普通医保还是生育保险。
        //> 这种情况下，通过合同单位维护得方式就没法区分了。
        //> 
        //> 现在想 把 发票打印的接口增加两个属性。一个patientinfo，一个invoicetype。
        //> 发票打印时，核心里边先对patientinfo进行赋值。接口实现时根据patientinfo，设置invoicetype的值，
        //> 然后核心内取出invoicetype的值，根据这个值在核心内进行处理。并正常返回balancelist。
        //> 
        //> 你看这样有啥问题没？另外，门诊怎么处理？ 
        #endregion
        /// <summary>
        /// 患者综合实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            set;
        }
        /// <summary>
        /// 发票所属大类，如“ZY01”“ZY02”“ZY03”等
        /// </summary>
        string InvoiceType
        {
            get;
        } 
        #endregion

        /// <summary>
        /// 设置住院发票打印内容
        /// </summary>
        /// <param name="patientInfo">住院患者基本信息实体</param>
        /// <param name="balanceInfo">结算打印实体</param>
        /// <param name="alBalanceList">结算大类明细数组</param>
        /// /// <param name="alPayList">支付方式</param>{A9A96DBA-B9D1-4227-9336-B4D5BBC42B4A}
        /// <returns>成功 1 失败 -1</returns>
        int SetValueForPrint(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList, ArrayList alPayList);

        /// <summary>
        /// 设置住院发票预览打印内容
        /// </summary>
        /// <param name="patientInfo">住院患者基本信息实体</param>
        /// <param name="balanceInfo">结算打印实体</param>
        /// <param name="alBalanceList">结算大类明细数组</param>
        /// <param name="alPayList">支付方式</param>{A9A96DBA-B9D1-4227-9336-B4D5BBC42B4A}
        /// <returns>成功 1 失败 -1</returns>
        int SetValueForPreview(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance balanceInfo, ArrayList alBalanceList, ArrayList alPayList);
        /// <summary>
        /// 住院发票打印函数
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Print();

        /// <summary>
        /// 住院发票打印预览函数
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int PrintPreview();

        /// <summary>
        /// 清空当前信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        int Clear();

        /// <summary>
        /// 设置本地数据库连接
        /// </summary>
        /// <param name="trans">数据库连接</param>
        void SetTrans(System.Data.IDbTransaction trans);
    }
    public interface IBalanceInvoicePrintmy :IBalanceInvoicePrint
    {
        Neusoft.HISFC.Models.Base.EBlanceType IsMidwayBalance
        {
            get;
            set;
        }

    }
    #endregion

    #region 催款单打印接口
    public interface IMoneyAlert
    {
        //患者信息
        Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 显示患者信息
        /// </summary>
        void SetPatientInfo();
    }

    #endregion

    #region 门诊收费

    #region 门诊项目选择

    ///// <summary>
    ///// 当选择项目后触发
    ///// 增加价格，用于物资收费{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
    ///// </summary>
    ///// <param name="itemCode"></param>
    ///// <param name="drugFlag"></param>
    ///// <param name="exeDeptCode"></param>
    //public delegate void WhenGetItem(string itemCode, string drugFlag, string exeDeptCode, decimal price);

    ///// <summary>
    ///// 门诊选择项目控件接口
    ///// </summary>
    //public interface IChooseItemForOutpatient 
    //{
    //    /// <summary>
    //    /// 选择当前项目
    //    /// </summary>
    //    /// <returns></returns>
    //    int GetSelectedItem();
        
    //    /// <summary>
    //    /// 设置所有项目的DdataSet
    //    /// </summary>
    //    /// <param name="dsItem">所有要过滤的项目集合</param>
    //    void SetDataSet(System.Data.DataSet dsItem);

    //    /// <summary>
    //    /// 设置前台输入的过滤字符
    //    /// </summary>
    //    /// <param name="sender">传入的对象</param>
    //    /// <param name="inputChar">前台输入的过滤字符</param>
    //    /// <param name="inputType">类型</param>
    //    void SetInputChar(object sender, string inputChar, Neusoft.HISFC.Models.Base.InputTypes inputType);

    //    /// <summary>
    //    /// 获得选中的项目
    //    /// </summary>
    //    /// <param name="item">选中的项目</param>
    //    /// <returns>成功1 失败 -1</returns>
    //    int GetSelectedItem(ref Neusoft.HISFC.Models.Base.Item item);

    //    /// <summary>
    //    /// 设置坐标
    //    /// </summary>
    //    /// <param name="p">控件坐标</param>
    //    void SetLocation(System.Drawing.Point p);

    //    /// <summary>
    //    /// 排序方式
    //    /// </summary>
    //    string InputPrev { get; set; }

    //    /// <summary>
    //    /// 过滤方式
    //    /// </summary>
    //    string QueryType { get; set; }

    //    /// <summary>
    //    /// 当选择项目后触发
    //    /// </summary>
    //    event WhenGetItem SelectedItem;

    //    /// <summary>
    //    /// 是否模糊查询
    //    /// </summary>
    //    bool IsQueryLike { get; set; }

    //    /// <summary>
    //    /// 当前科室代码
    //    /// </summary>
    //    string DeptCode { get; set; }
        
    //    /// <summary>
    //    /// 项目类别
    //    /// </summary>
    //    Neusoft.HISFC.Models.Base.ItemKind ItemKind{ get; set; }

    //    /// <summary>
    //    /// 默认每页显示9条记录，以后会加入参数设置
    //    /// </summary>
    //    int ItemCount { get; set; }

    //    /// <summary>
    //    /// 当选择一条项目的时候是否关闭窗口
    //    /// </summary>
    //    bool IsSelectAndClose { get; set; }

    //    /// <summary>
    //    /// 当前选定的项目实体
    //    /// </summary>
    //    Neusoft.HISFC.Models.Base.Item NowItem { get; set; }

    //    /// <summary>
    //    /// 保存过滤后的的项目fpSheet
    //    /// </summary>
    //    object ObjectFilterObject { set; get; }

    //    /// <summary>
    //    /// 是否选择项目
    //    /// </summary>
    //    bool IsSelectItem { get; set; }

    //    /// <summary>
    //    /// 初始化方法
    //    /// </summary>
    //    /// <returns></returns>
    //    int Init();

    //    /// <summary>
    //    /// 是否选择项目的同时判断库存
    //    /// </summary>
    //    bool IsJudgeStore
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 输入字符触发检索项目方式
    //    /// </summary>
    //    ChooseItemTypes ChooseItemType
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 下一行
    //    /// </summary>
    //    void NextRow();

    //    /// <summary>
    //    /// 下一页
    //    /// </summary>
    //    void NextPage();

    //    /// <summary>
    //    /// 上一行
    //    /// </summary>
    //    void PriorRow();

    //    /// <summary>
    //    /// 上一页
    //    /// </summary>
    //    void PriorPage();

    //    //{E91E0D33-FCC6-4982-BA74-320A6E8A373C}
    //    #region
    //    /// <summary>
    //    /// 挂号实体
    //    /// </summary>
    //    Neusoft.HISFC.Models.Registration.Register RegPatientInfo
    //    {
    //        get;
    //        set;
    //    }

    //    Neusoft.HISFC.BizProcess.Interface.FeeInterface.IGetSiItemGrade IGetSiItemGrade
    //    {
    //        get;
    //        set;

    //    }
    //    #endregion
    //}

    ///// <summary>
    ///// 输入字符触发检索项目方式
    ///// </summary>
    //public enum ChooseItemTypes 
    //{
    //    /// <summary>
    //    /// 每次输入字符触发
    //    /// </summary>
    //    ItemChanging = 0,

    //    /// <summary>
    //    /// 输入完字符回车触发
    //    /// </summary>
    //    ItemInputEnd
    //}

    #endregion

    #region 患者基本信息

    ///// <summary>
    ///// 患者基本信息控件
    ///// </summary>
    //public interface IOutpatientInfomation 
    //{
    //    /// <summary>
    //    /// 获得所有划价保存信息.
    //    /// </summary>
    //    ArrayList FeeSameDetails { get; set; }
        
    //    /// <summary>
    //    /// 患者基本信息
    //    /// </summary>
    //    Neusoft.HISFC.Models.Registration.Register PatientInfo
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 上一个患者基本信息
    //    /// </summary>
    //    Neusoft.HISFC.Models.Registration.Register PrePatientInfo { get; set; }

    //    /// <summary>
    //    /// 清空
    //    /// </summary>
    //    void Clear();

    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    int Init();

    //    /// <summary>
    //    /// 可以更换焦点事件,一般这个时候传递PatientInfo
    //    /// </summary>
    //    event DelegateChangeSomething ChangeFocus;

    //    /// <summary>
    //    /// 更改了合同单位,患者合同单位变化后,影响费用项目的价格以及金额
    //    /// </summary>
    //    event DelegateChangeSomething PactChanged;

    //    /// <summary>
    //    /// 是否可以更改患者基本信息
    //    /// </summary>
    //    bool IsCanModifyPatientInfo
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 医生,科室输入编码是否要求全匹配
    //    /// </summary>
    //    bool IsDoctDeptCorrect
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 是否收费时候可以挂号医保患者
    //    /// </summary>
    //    bool IsRegWhenFee
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 是否默认等级编码
    //    /// </summary>
    //    bool IsClassCodePre
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 是否可以更改划价信息
    //    /// </summary>
    //    bool IsCanModifyChargeInfo
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 是否直接收费患者
    //    /// </summary>
    //    bool IsRecordDirectFee
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 是否可以增加项目
    //    /// </summary>
    //    bool IsCanAddItem
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 更改的项目信息
    //    /// </summary>
    //    ArrayList ModifyFeeDetails
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 患者费用信息集合
    //    /// </summary>
    //    ArrayList FeeDetails
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 当前选中的收费序列中的项目信息集合
    //    /// </summary>
    //    ArrayList FeeDetailsSelected
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 改变了收费序列时触发
    //    /// </summary>
    //    event DelegateChangeSomething RecipeSeqChanged;

    //    /// <summary>
    //    ///当修改看诊医生时触发
    //    /// </summary>
    //    event DelegateChangeDoctAndDept SeeDoctChanged;

    //    /// <summary>
    //    /// 当修改看诊科室时触发
    //    /// </summary>
    //    event DelegateChangeDoctAndDept SeeDeptChanaged;

    //    /// <summary>
    //    /// 更改年龄以及合同单位等需要同步价格时触发!
    //    /// </summary>
    //    event DelegateChangeSomething PriceRuleChanaged;

    //    /// <summary>
    //    /// 删除收费序列时触发
    //    /// </summary>
    //    event DelegateRecipeDeleted RecipeSeqDeleted;

    //    /// <summary>
    //    /// 当输入卡号有效后触发,主要为了控制显示挂号信息控件的位置。
    //    /// </summary>
    //    event DelegateEnter InputedCardAndEnter;

    //    /// <summary>
    //    /// 当前收费序列
    //    /// </summary>
    //    string RecipeSequence
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 变更修改信息
    //    /// </summary>
    //    void DealModifyDetails();

    //    /// <summary>
    //    /// 设置新的收费序列信息
    //    /// </summary>
    //    void SetNewRecipeInfo();

    //    /// <summary>
    //    /// 增加新处方
    //    /// </summary>
    //    void AddNewRecipe();

    //    /// <summary>
    //    /// 重新获得挂号信息
    //    /// </summary>
    //    void GetRegInfo();

    //    /// <summary>
    //    /// 设置挂号信息
    //    /// </summary>
    //    void SetRegInfo();

    //    /// <summary>
    //    /// 验证挂号信息是否合法
    //    /// </summary>
    //    /// <returns>true合法 false不合法</returns>
    //    bool IsPatientInfoValid();

    //    #region 路志鹏 累计用 2007-8-30
    //    /// <summary>
    //    /// 多张发票累计金额
    //    /// </summary>
    //    decimal AddUpCost
    //    {
    //        set;
    //        get;
    //    }
    //    /// <summary>
    //    /// 是否开始累计
    //    /// </summary>
    //    bool IsBeginAddUpCost
    //    {
    //        set;
    //        get;
    //    }
    //    /// <summary>
    //    /// 是否有累计操作
    //    /// </summary>
    //    bool IsAddUp
    //    {
    //        set;
    //        get;
    //    }
    //    #endregion
    //}

    ///// <summary>
    ///// 代理,更改了某些选项
    ///// </summary>
    //public delegate void DelegateChangeSomething();

    ///// <summary>
    ///// 当修改了处方的科室和医生时触发
    ///// </summary>
    //public delegate void DelegateChangeDoctAndDept(string recipeSeq, string deptCode, Neusoft.FrameWork.Models.NeuObject changeObj);

    ///// <summary>
    ///// 删除收费序列时触发
    ///// </summary>
    ///// <param name="al"></param>
    ///// <returns></returns>
    //public delegate int DelegateRecipeDeleted(ArrayList al);

    ///// <summary>
    ///// 谈出Car触发
    ///// </summary>
    ///// <param name="cardNO"></param>
    ///// <param name="orgNO"></param>
    ///// <param name="cardLocation"></param>
    ///// <param name="cardHeight"></param>
    ///// <returns></returns>
    //public delegate bool DelegateEnter(string cardNO, string orgNO, System.Drawing.Point cardLocation, int cardHeight);

    #endregion

    #region 项目录入

    //public interface IOutpatientItemInputAndDisplay
    //{
    //    /// <summary>
    //    /// 项目类别
    //    /// </summary>
    //    Neusoft.HISFC.Models.Base.ItemKind ItemKind { get; set; }
        
    //    /// <summary>
    //    /// 增加新行
    //    /// </summary>
    //    void AddNewRow();

    //    /// <summary>
    //    /// 增加自费侦察费
    //    /// </summary>
    //    void AddOwnDiagFee();

    //    /// <summary>
    //    /// 增加挂号费
    //    /// </summary>
    //    void AddRegFee();

    //    /// <summary>
    //    /// 增加指定行
    //    /// </summary>
    //    /// <param name="row">指定行</param>
    //    void AddRow(int row);

    //    /// <summary>
    //    /// 划价信息
    //    /// </summary>
    //    System.Collections.ArrayList ChargeInfoList { get; set; }

    //    /// <summary>
    //    /// 是否有效
    //    /// </summary>
    //    bool IsValid { get; set; }

    //    /// <summary>
    //    /// 清屏
    //    /// </summary>
    //    void Clear();

    //    /// <summary>
    //    /// 清除指定行
    //    /// </summary>
    //    /// <param name="row">指定行</param>
    //    void ClearRow(int row);

    //    /// <summary>
    //    /// 刷新合同单位
    //    /// </summary>
    //    void RefreshItemForPact();

    //    /// <summary>
    //    /// 通用挂号级别
    //    /// </summary>
    //    string ComRegLevel { get; set; }

    //    /// <summary>
    //    /// 默认价格单位
    //    /// </summary>
    //    string DefaultPriceUnit { get; set; }

    //    /// <summary>
    //    /// 按照项目删除指定行
    //    /// </summary>
    //    /// <param name="feeTemp">指定项目</param>
    //    /// <returns>成功 1 失败 -1</returns>
    //    int DeleteRow(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeTemp);

    //    /// <summary>
    //    /// 删除获得焦点行
    //    /// </summary>
    //    void DeleteRow();

    //    /// <summary>
    //    /// 错误信息
    //    /// </summary>
    //    string ErrText { get; set; }

    //    /// <summary>
    //    /// 频次显示状态, 0 编码 1 中文
    //    /// </summary>
    //    string FreqDisplayType { get; set; }

    //    /// <summary>
    //    /// 获得所有录入的费用明细
    //    /// </summary>
    //    /// <returns>成功 :所有录入的费用明细</returns>
    //    System.Collections.ArrayList GetFeeItemList();

    //    /// <summary>
    //    /// 获得所有录入的费用明细 为划价保存
    //    /// </summary>
    //    /// <returns>成功 所有录入的费用明细 为划价保存 失败 null</returns>
    //    System.Collections.ArrayList GetFeeItemListForCharge();

    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    /// <returns>成功 1 失败 -1</returns>
    //    int Init();

    //    /// <summary>
    //    /// 是否可以增加项目
    //    /// </summary>
    //    bool IsCanAddItem { get; set; }

    //    /// <summary>
    //    /// 是否可以更改划价明细
    //    /// </summary>
    //    bool IsCanModifyCharge { get; set; }

    //    /// <summary>
    //    /// 是否加载过期药品
    //    /// </summary>
    //    bool IsDisplayLackPha { get; set; }

    //    /// <summary>
    //    /// 每次用量是否可以为空
    //    /// </summary>
    //    bool IsDoseOnceNull { get; set; }

    //    /// <summary>
    //    /// 是否获得焦点
    //    /// </summary>
    //    bool IsFocus { get; set; }
        
    //    /// <summary>
    //    /// 是否验证库存
    //    /// </summary>
    //    bool IsJudgeStore { get; set; }

    //    /// <summary>
    //    /// 是否显示自费医保
    //    /// </summary>
    //    bool IsOwnDisplayYB { get; set; }

    //    /// <summary>
    //    /// 是否数量上取整
    //    /// </summary>
    //    bool IsQtyToCeiling { get; set; }

    //    /// <summary>
    //    /// 更改付数
    //    /// </summary>
    //    void ModifyDays();

    //    /// <summary>
    //    /// 更改价格
    //    /// </summary>
    //    void ModifyPrice();

    //    /// <summary>
    //    /// 没有挂号患者卡号第一位
    //    /// </summary>
    //    string NoRegFlagChar { get; set; }

    //    /// <summary>
    //    /// 自费诊查费编码
    //    /// </summary>
    //    string OwnDiagFeeCode { get; set; }

    //    /// <summary>
    //    /// 患者挂号信息
    //    /// </summary>
    //    Neusoft.HISFC.Models.Registration.Register PatientInfo { get; set; }

    //    /// <summary>
    //    /// 价格警戒线颜色
    //    /// </summary>
    //    int PriceWarinningColor { get; set; }

    //    /// <summary>
    //    /// 价格警戒线金额
    //    /// </summary>
    //    decimal PriceWarnning { get; set; }

    //    /// <summary>
    //    /// 刷新新比例
    //    /// </summary>
    //    void RefreshNewRate();
        
    //    /// <summary>
    //    ///根据项目列表刷新比例 
    //    /// </summary>
    //    /// <param name="feeDetails">项目列表</param>
    //    void RefreshNewRate(System.Collections.ArrayList feeDetails);

    //    /// <summary>
    //    /// 刷新看诊科室
    //    /// </summary>
    //    /// <param name="recipeSeq"></param>
    //    /// <param name="obj"></param>
    //    void RefreshSeeDept(string recipeSeq, Neusoft.FrameWork.Models.NeuObject obj);

    //    /// <summary>
    //    /// 刷新看诊医生
    //    /// </summary>
    //    /// <param name="recipeSeq"></param>
    //    /// <param name="deptCode"></param>
    //    /// <param name="obj"></param>
    //    void RefreshSeeDoc(string recipeSeq, string deptCode, Neusoft.FrameWork.Models.NeuObject obj);

    //    /// <summary>
    //    /// 挂号费项目编码
    //    /// </summary>
    //    string RegFeeItemCode { get; set; }

    //    /// <summary>
    //    /// 临时挂号科室
    //    /// </summary>
    //    string RegisterDept { get; set; }

    //    /// <summary>
    //    /// 设置获得焦点
    //    /// </summary>
    //    void SetFocus();

    //    /// <summary>
    //    /// 设置焦点在输入框
    //    /// </summary>
    //    void SetFocusToInputCode();

    //    /// <summary>
    //    /// 停止StopEditing
    //    /// </summary>
    //    void StopEdit();

    //    /// <summary>
    //    /// 计算小计
    //    /// </summary>
    //    void SumLittleCost();

    //    /// <summary>
    //    /// 当前收费序列
    //    /// </summary>
    //    string RecipeSequence { get; set; }

    //    /// <summary>
    //    /// 项目发生变化后触发
    //    /// </summary>
    //    event delegateFeeItemListChanged FeeItemListChanged;

    //    /// <summary>
    //    /// 左侧项目显示信息
    //    /// </summary>
    //    IOutpatientOtherInfomationLeft LeftControl { get; set; }

    //    IOutpatientOtherInfomationRight RightControl { get;set;}
    // }

    /// <summary>
	/// 项目变化代理
	/// </summary>
    public delegate void delegateFeeItemListChanged(ArrayList al);
		
    #endregion

    #region 门诊收费其他显示信息

    //public interface IOutpatientOtherInfomationRight 
    //{
    //    /// <summary>
    //    /// 清空
    //    /// </summary>
    //    void Clear();

    //    /// <summary>
    //    /// 设置药品费用信息
    //    /// </summary>
    //    Neusoft.FrameWork.Public.ObjectHelper DrugFeeCodeHelper { set; }

    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    /// <returns></returns>
    //    int Init();

    //    /// <summary>
    //    /// 设置待遇计算接口
    //    /// </summary>
    //    Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy MedcareInterfaceProxy { set; }

    //    /// <summary>
    //    /// 设置项目集合
    //    /// </summary>
    //    /// <param name="dsItem">项目集合</param>
    //    void SetDataSet(System.Data.DataSet dsItem);

    //    /// <summary>
    //    /// 设置药品费用信息
    //    /// </summary>
    //    /// <param name="drugFeeCodeHelper"></param>
    //    void SetFeeCodeIsDrugArrayListObj(Neusoft.FrameWork.Public.ObjectHelper drugFeeCodeHelper);

    //    /// <summary>
    //    /// 设置费用显示信息
    //    /// </summary>
    //    /// <param name="patient">挂号患者基本信息</param>
    //    /// <param name="ft">前台计算后的费用信息</param>
    //    /// <param name="feeItemLists">当前收费信息</param>
    //    /// <param name="diagLists">诊断信息</param>
    //    /// <param name="otherInfomations">其他信息</param>
    //    void SetInfomation(Neusoft.HISFC.Models.Registration.Register patient, Neusoft.HISFC.Models.Base.FT ft, System.Collections.ArrayList feeItemLists, System.Collections.ArrayList diagLists, params string[] otherInfomations);
        
    //    /// <summary>
    //    /// 设置待遇计算接口
    //    /// </summary>
    //    /// <param name="medcareInterfaceProxy">待遇计算接口</param>
    //    void SetMedcareInterfaceProxy(Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy);

    //    /// <summary>
    //    /// 设置单条项目显示信息
    //    /// </summary>
    //    /// <param name="f">单条项目</param>
    //    void SetSingleFeeItemInfomation(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f);
    //    /// <summary>
    //    /// 设置是否预结算
    //    /// </summary>

    //    bool IsPreFee { set;get;}
    //}

    ///// <summary>
    ///// 门诊收费显示其他信息左侧插件
    ///// </summary>
    //public interface IOutpatientOtherInfomationLeft
    //{
    //    /// <summary>
    //    /// 清空
    //    /// </summary>
    //    void Clear();

    //    /// <summary>
    //    /// false:划价 true:收费
    //    /// </summary>
    //    bool IsValidFee { get; set;}

    //    /// <summary>
    //    /// 是否预结算
    //    /// </summary>
    //    bool IsPreFee { get; set;}
        
    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    /// <returns>成功 1 失败 -1</returns>
    //    int Init();

    //    /// <summary>
    //    /// 是否所有显示信息有效
    //    /// </summary>
    //    /// <returns>成功 true 失败 false</returns>
    //    bool IsValid();

    //    /// <summary>
    //    /// 错误信息
    //    /// </summary>
    //    string ErrText { get; set; }

    //    /// <summary>
    //    /// 初始化发票
    //    /// </summary>
    //    /// <returns></returns>
    //    int InitInvoice();

    //    /// <summary>
    //    /// 发票预览类型
    //    /// </summary>
    //    string InvoicePreviewType { get; set; }
        
    //    /// <summary>
    //    /// 发票方式
    //    /// </summary>
    //    string InvoiceType { get; set; }
        
    //    /// <summary>
    //    /// 更新发票后触发
    //    /// </summary>
    //    event DelegateChangeSomething InvoiceUpdated;

    //    /// <summary>
    //    /// 患者挂号基本信息
    //    /// </summary>
    //    Neusoft.HISFC.Models.Registration.Register PatientInfo { get; set; }

    //    /// <summary>
    //    /// 刷新显示信息
    //    /// </summary>
    //    /// <param name="feeItemList"></param>
    //    /// <returns></returns>
    //    int RefreshDisplayInfomation(System.Collections.ArrayList feeItemList);

    //    /// <summary>
    //    /// 设置焦点
    //    /// </summary>
    //    void SetFocus();

    //    /// <summary>
    //    /// 更新发票
    //    /// </summary>
    //    /// <param name="invoiceNO">发票号</param>
    //    /// <returns>成功 1 失败 -1</returns>
    //    int UpdateInvoice(string invoiceNO);

    //    /// <summary>
    //    /// 发票号
    //    /// </summary>
    //    string InvoiceNO { get; set; }

    //    /// <summary>
    //    /// 获得发票号
    //    /// </summary>
    //    string GetInvoiceNO();
    //}

     #endregion

    #region 门诊发票打印

    /// <summary>
    /// 门诊发票打印
    /// </summary>
    public interface IInvoicePrint 
    {
        //{DF484D55-5A9E-4afd-9B82-21EF6DA6E400}
        #region liuqiang 2007-8-23 修改
        #region 修改原因
        //>     现在打印遇到个问题。按照刚才你和王儒超定的。可以按合同单位维护。
        //> 
        //> 但东电医院医保和生育保险是两种发票。但合同单位全是医保。是通过medicaltype区分是普通医保还是生育保险。
        //> 这种情况下，通过合同单位维护得方式就没法区分了。
        //> 
        //> 现在想 把 发票打印的接口增加两个属性。一个patientinfo，一个invoicetype。
        //> 发票打印时，核心里边先对patientinfo进行赋值。接口实现时根据patientinfo，设置invoicetype的值，
        //> 然后核心内取出invoicetype的值，根据这个值在核心内进行处理。并正常返回balancelist。
        //> 
        //> 你看这样有啥问题没？另外，门诊怎么处理？ 
        #endregion
        /// <summary>
        /// 挂号信息实体
        /// </summary>
        Neusoft.HISFC.Models.Registration.Register Register
        {
            set;
        }
        /// <summary>
        /// 发票所属大类，如“ZY01”“ZY02”“ZY03”等
        /// </summary>
        string InvoiceType
        {
            get;
        }
        #endregion
        /// <summary>
        /// 分发票后支付方式类别 1 不做处理 2 单独处理
        /// </summary>
        string SetPayModeType
        {
            set;
        }

        /// <summary>
        /// 分发票后的支付方式
        /// </summary>
        string SplitInvoicePayMode
        {
            set;
        }
        /// <summary>
        /// 控件描述，最好填写。
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// 设置是否为预览模式
        /// </summary>
        bool IsPreView
        {
            set;
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        System.Data.IDbTransaction Trans
        {
            set;
        }

        /// <summary>
        /// 设置是否为预览模式
        /// </summary>
        /// <param name="isPreView">true预览 false 不预览</param>
        void SetPreView(bool isPreView);

        /// <summary>
        /// 打印自身
        /// </summary>
        /// <returns>-1 失败 1 成功</returns>
        int Print();

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="t"></param>
        void SetTrans(System.Data.IDbTransaction trans);

        /// <summary>
        /// 设置发票打印内容
        /// </summary>
        /// <param name="regInfo">挂号信息</param>
        /// <param name="invoice">发票主表信息</param>
        /// <param name="invoiceDetails">发票明细信息</param>
        /// <param name="feeDetails">费用明细信息</param>
        /// <param name="isPreview">是否预览模式</param>
        /// <returns></returns>
        int SetPrintValue(Neusoft.HISFC.Models.Registration.Register regInfo, Neusoft.HISFC.Models.Fee.Outpatient.Balance invoice,
            ArrayList invoiceDetails, ArrayList feeDetails, bool isPreview);

        /// <summary>
        /// 设置打印其他内容
        /// </summary>
        /// <param name="regInfo">挂号信息</param>
        /// <param name="Invoices">所有主发票信息</param>
        /// <param name="invoiceDetails">所有发票明细信息</param>
        /// <param name="feeDetails">所有费用信息</param>
        /// <returns></returns>
        int SetPrintOtherInfomation(Neusoft.HISFC.Models.Registration.Register regInfo, ArrayList Invoices, ArrayList invoiceDetails, ArrayList feeDetails);

        /// <summary>
        /// 打印其他内容
        /// </summary>
        /// <returns>-1 失败 1 成功</returns>
        int PrintOtherInfomation();
    }
    #endregion

    #region 门诊分发票

    /// <summary>
    /// 门诊分发票
    /// </summary>
    public interface ISplitInvoice
    {
        /// <summary>
        /// 事务
        /// </summary>
        System.Data.IDbTransaction Trans
        {
            set;
        }
        /// <summary>
        /// 门诊分发票
        /// </summary>
        /// <param name=" register">患者的信息</param>
        /// <param name="feeItemLists">患者的总体费用明细</param>
        /// <returns>成功 分好的费用明细,每个ArrayList代表一组应该生成发票的费用明细 失败 null</returns>
        ArrayList SplitInvoice(Neusoft.HISFC.Models.Registration.Register register, ref ArrayList feeItemLists);
        /// <summary>
        /// 事务（需要时处理）
        /// </summary>
        /// <param name="trans"></param>
        void SetTrans(System.Data.IDbTransaction trans);
    }

    #endregion

    #region 门诊收费弹出选项

    ///// <summary>
    ///// 收费按钮触发
    ///// </summary>
    ///// <param name="alPayModes">支付方式信息</param>
    ///// <param name="invoices">发票信息（基本对应发票主表的信息，每个对象对应一个发票）</param>
    ///// <param name="invoiceDetails">发票明细信息（对应本次结算的全部费用明细）</param>
    ///// <param name="invoiceFeeItemDetails">发票费用明细信息（按发票分组后的费用明细，每个对象对应该发票下的费用明细）</param>
    //public delegate void DelegateFee(ArrayList balancePays, ArrayList invoices, ArrayList invoiceDetails, ArrayList invoiceFeeItemDetails);
  

    /// <summary>
    ///// 收费弹出控件
    ///// </summary>
    //public interface IOutpatientPopupFee 
    //{
    //    /// <summary>
    //    /// 划价触发
    //    /// </summary>
    //    event DelegateChangeSomething ChargeButtonClicked;
        
    //    /// <summary>
    //    /// 收费触发
    //    /// </summary>
    //    event DelegateFee FeeButtonClicked;
        
    //    /// <summary>
    //    /// 收费明细
    //    /// </summary>
    //    System.Collections.ArrayList FeeDetails { get; set; }
        
    //    /// <summary>
    //    /// 费用基本信息
    //    /// </summary>
    //    Neusoft.HISFC.Models.Base.FT FTFeeInfo { get; }
        
    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    /// <returns>成功 1 失败 -1</returns>
    //    int Init();

    //    /// <summary>
    //    /// 发票和发票明细数组
    //    /// </summary>
    //    System.Collections.ArrayList InvoiceAndDetails { get; set; }

    //    /// <summary>
    //    /// 发票明细数组
    //    /// </summary>
    //    System.Collections.ArrayList InvoiceDetails { get; set; }

    //    /// <summary>
    //    /// 发票数组
    //    /// </summary>
    //    System.Collections.ArrayList Invoices { get; set; }

    //    //{E6CD2A14-1DCB-4361-834C-9CF9B9DC669A}添加一个属性，保存按发票分组的费用明细 liuq
    //    /// <summary>
    //    /// 发票费用明细集合
    //    /// </summary>
    //    ArrayList InvoiceFeeDetails
    //    {
    //        get;
    //        set;
    //    }

    //    /// <summary>
    //    /// 是否可以现金支付
    //    /// </summary>
    //    bool IsCashPay { get; set; }

    //    /// <summary>
    //    /// 是否点击取消按钮
    //    /// </summary>
    //    bool IsPushCancelButton { get; set; }

    //    /// <summary>
    //    /// 是否是退费功能
    //    /// </summary>
    //    bool IsQuitFee { set; }

    //    /// <summary>
    //    /// 找零金额
    //    /// </summary>
    //    decimal LeastCost { set; }

    //    /// <summary>
    //    /// 超标药品金额
    //    /// </summary>
    //    decimal OverDrugCost { set; }

    //    /// <summary>
    //    /// 自费金额
    //    /// </summary>
    //    decimal OwnCost { get; set; }

    //    /// <summary>
    //    /// 当前患者合同单位
    //    /// </summary>
    //    Neusoft.HISFC.Models.Base.PactInfo PactInfo { set; }

    //    /// <summary>
    //    /// 患者挂号基本信息
    //    /// </summary>
    //    Neusoft.HISFC.Models.Registration.Register PatientInfo { set; }

    //    /// <summary>
    //    /// 自付金额
    //    /// </summary>
    //    decimal PayCost { get; set; }

    //    /// <summary>
    //    /// 公费金额
    //    /// </summary>
    //    decimal PubCost { get; set; }

    //    /// <summary>
    //    /// 实付金额
    //    /// </summary>
    //    decimal RealCost { set; }

    //    /// <summary>
    //    /// 划价保存信息
    //    /// </summary>
    //    /// <returns></returns>
    //    bool SaveCharge();

    //    /// <summary>
    //    /// 保存收费信息
    //    /// </summary>
    //    /// <returns></returns>
    //    bool SaveFee();

    //    /// <summary>
    //    /// 自费药品金额
    //    /// </summary>
    //    decimal SelfDrugCost { set; }

    //    /// <summary>
    //    /// 设置控件默认焦点
    //    /// </summary>
    //    void SetControlFocus();

    //    /// <summary>
    //    /// 总金额
    //    /// </summary>
    //    decimal TotCost { get; set; }

    //    /// <summary>
    //    /// 自费总金额
    //    /// </summary>
    //    decimal TotOwnCost { get; set; }

    //    /// <summary>
    //    /// 数据库连接
    //    /// </summary>
    //    Neusoft.FrameWork.Management.Transaction Trans { set; }
    //}

    #endregion

    #endregion

    #region 医保读卡按钮

    /// <summary>
    /// 医保读卡，设置患者基本信息接口
    /// </summary>
    public interface ISIReadCard 
    {
        /// <summary>
        /// 读卡方法
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <returns>成功 1 失败 －1</returns>
        int ReadCard(string pactCode);

        /// <summary>
        /// 设置界面医保患者信息
        /// </summary>
        /// <returns>成功 1 失败 －1</returns>
        int SetSIPatientInfo();
    }

    #endregion

    #region 住院记帐打印接口
    /// <summary>
    /// 住院记帐打印接口
    /// </summary>
    public interface IInpatientChargePrint
    {
        Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get;
            set;
        }

        int SetData(List<Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList> feeItemCollection);

        int Print();

        int Preview();
    }
    #endregion


    /// <summary>
    /// 处理门诊适应症 {6586C3F9-2B89-4597-B9DA-63122A296F22}
    /// </summary>
    public interface IAdptIllnessOutPatient
    {
        
        /// <summary>
        /// 保存门诊患者适应症
        /// </summary>
        /// <param name="registerObj">门诊患者实体</param>
        /// <param name="alOutFeeDetail">门诊费用实体数组</param>
        /// <returns></returns>
        int SaveOutPatientFeeDetail(Neusoft.HISFC.Models.Registration.Register registerObj ,ref ArrayList alOutFeeDetail);

        /// <summary>
        /// 门诊患者适应症处理方法
        /// </summary>
        /// <param name="registerObj">门诊患者实体</param>
        /// <param name="outFeeDetail">门诊费用实体</param>
        /// <returns></returns>
        int ProcessOutPatientFeeDetail(Neusoft.HISFC.Models.Registration.Register registerObj, ref Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList outFeeDetail);

    }

    /// <summary>
    /// 处理适住院应症{6586C3F9-2B89-4597-B9DA-63122A296F22}
    /// </summary>
    public interface IAdptIllnessInPatient
    {
        /// <summary>
        /// 住院患者适应症处理方法
        /// </summary>
        /// <param name="patientObj">住院患者实体</param>
        /// <param name="alInpatientDetail">住院费用实体数组</param>
        /// <returns></returns>
        int SaveInpatientFeeDetail(Neusoft.HISFC.Models.RADT.PatientInfo patientObj, ref ArrayList alInpatientDetail);

        /// <summary>
        /// 住院患者适应症处理方法
        /// </summary>
        /// <param name="patientObj">住院患者实体</param>
        /// <param name="alInpatientDetail">住院费用实体</param>
        /// <returns></returns>
        int ProcessInpatientFeeDetail(Neusoft.HISFC.Models.RADT.PatientInfo patientObj, ref Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList inpatientDetail);

    }

    /// <summary>
    /// 获取医保类别(1甲2乙3丙4自费定死)
    /// 
    /// {112B7DB5-0462-4432-AD9D-17A7912FFDBE}   项目医保类别显示接口
    /// </summary>
    public interface IGetSiItemGrade
    {
        /// <summary>
        /// 根据项目编码获取医保等级
        /// </summary>
        /// <param name="hisItemCode">医院项目编码</param>
        /// <param name="siGrade">医院项目编码</param>
        /// <returns>医保等级</returns>
        int GetSiItemGrade(string hisItemCode, ref string siGrade);

        /// <summary>
        /// 根据合同
        /// </summary>
        /// <param name="pactID">合同单位编码</param>
        /// <param name="hisItemCode">医院项目编码</param>
        /// <param name="siGrade">医保等级</param>
        /// <returns></returns>
        int GetSiItemGrade(string pactID, string hisItemCode, ref string siGrade);

    }

    public interface IFeeOweMessage
    {
        /// <summary>
        /// 欠费提示
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="ft">费用信息</param>
        /// <param name="feeItemLists">费用明细</param>
        /// <param name="type">欠费提示类型</param>
        /// <param name="err">提示信息</param>
        /// <returns>true:成功 false:函数内部报错</returns>
        //{2518013C-40B2-4693-B494-3DE193C002FF} //增加处理明细
        bool FeeOweMessage(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Base.FT ft, System.Collections.ArrayList feeItemLists, ref Neusoft.HISFC.Models.Base.MessType type, ref string err);
    }

    /// <summary>
    /// 担保金打印凭证{0374EA05-782E-4609-9CDC-03236AB97906}
    /// </summary>
    public interface IPrintSurety
    {
        void SetValue(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo);

        void Print();

        void PrintView();
    }

    /// <summary>
    /// 分处方
    /// </summary>
    public interface ISplitRecipe
    {
        /// <summary>
        /// 分处方号
        /// </summary>
        /// <param name="feeItemList">费用集合</param>
        /// <param name="errText">错误信息</param>
        /// <returns>true成功 false失败</returns>
        bool SplitRecipe(Register r,ArrayList feeItemList, ref string errText);
    }

    ////{AB19F92E-9561-4db9-A0CF-20C1355CD5D8}
    /// <summary>
    /// 医生站直接收费
    /// </summary>
    public interface IDoctIdirectFee
    {
        /// <summary>
        /// 医生站直接收费函数
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeItemLists">费用明细</param>
        /// <param name="FeeTime">收费时间</param>
        /// <param name="errText">错误信息</param>
        ///<returns>1成功 0为普通患者 -1失败</returns>
        int DoctIdirectFee(Neusoft.HISFC.Models.Registration.Register r, ArrayList feeItemLists, DateTime FeeTime, ref string errText);
        
        /// <summary>
        /// 直接收费后更新医嘱收费信息
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeItemLists">费用信息</param>
        /// <param name="alOrder">医嘱信息</param>
        /// <param name="feeTime">收费时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        int UpdateOrderFee(Neusoft.HISFC.Models.Registration.Register r, ArrayList alOrder, DateTime feeTime, ref string errText);

        /// <summary>
        /// 作废医嘱信息
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="order">医嘱实体</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        int CancelOrder(Neusoft.HISFC.Models.Registration.Register r, Neusoft.HISFC.Models.Order.OutPatient.Order order,ref string errText);
    }

    /// <summary>
    /// 合同单位优惠项目维护验证接口
    /// </summary>
    public interface IValidPactItemChoose
    {
        /// <summary>
        /// 合同单位优惠项目维护验证
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <param name="baseItem">项目</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        bool ValidPactItemChoose(string pactCode, Neusoft.HISFC.Models.Base.Item baseItem, ref string errText);
    }

    //{EBD77080-9D13-4e5a-91A2-ACFB7205D915}
    /// <summary>
    /// 是否设置密码校验
    /// </summary>
    public interface IShowFrmValidUserPassWord
    {
        bool ShowFrmValidUserPassWord( ref string err);
    }
    //{07CE8D65-9FF5-4073-8398-900EEE74E1DF}
    public interface IShowUndrugZtDetail 
    {
        void ShowUndrugZtDetail(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, ref string errText);
    }

    //{A97AE29B-F85A-4b53-B4CD-68A4A5EF5E6B}
    public interface IShowFeeTree
    {
        event EventHandler SelectItem;

        string ItemType
        {
            get;
            set;
        }

        string PatientDept
        {
            get;
            set;
        }
        string ArryFeeGate
        {
            get;
            set;
        }
    }
}
