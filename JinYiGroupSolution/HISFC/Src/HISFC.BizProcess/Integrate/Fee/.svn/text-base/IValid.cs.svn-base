using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Integrate.FeeInterface
{

    public interface IFeeExtend 
    {
        /// <summary>
        /// 特殊验证合法性
        /// </summary>
        /// <param name="feeItemList">当前收费项目信息</param>
        /// <param name="errText">错误信息</param>
        /// <returns>true合法 false不合法</returns>
        bool IsValid(Neusoft.HISFC.Object.Fee.Inpatient.FeeItemList feeItemList, ref string errText);


    }
    
    
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
        int OpenExtendInputWindow(int tabIndex, Neusoft.HISFC.Object.RADT.Patient patient, ref string errText);

        /// <summary>
        /// 如果有附加信息录入,那么获得该录入信息
        /// </summary>
        /// <param name="patient">当前患者基本信息实体</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 1 失败: -1</returns>
        int GetExtentPatientInfomation(Neusoft.HISFC.Object.RADT.Patient patient, ref string errText);

        /// <summary>
        /// 如果有附加信息,并且不在PatientInfo实体并且需要新的业务插入的时候,
        /// 如果主键重复,自己写处理.
        /// </summary>
        /// <param name="patient">当前患者基本信息实体</param>
        /// <param name="t">当前的数据库事务</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 1 失败: -1 没有插入数据 0</returns>
        int InsertOtherInfomation(Neusoft.HISFC.Object.RADT.Patient patient, Neusoft.NFC.Management.Transaction t, ref string errText);

        /// <summary>
        /// 如果有附加信息,并且不在PatientInfo实体并且需要新的业务更新的时候,
        /// 如果主键重复,自己写处理.
        /// </summary>
        /// <param name="patient">当前患者基本信息实体</param>
        /// <param name="t">当前的数据库事务</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功: 1 失败: -1 没有插入数据 0</returns>
        int UpdateOtherInfomation(Neusoft.HISFC.Object.RADT.Patient patient, Neusoft.NFC.Management.Transaction t, ref string errText);

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
}
