using System;

namespace Neusoft.HISFC.Object.Fee
{
	/// <summary>
	/// 费用接口
	/// </summary>
	public interface FeeInterface
	{
		/// <summary>
		/// 添加患者 项目费用
		/// </summary>
		/// <param name="PatientInfo">患者信息</param>
		/// <param name="FeeItemList">交的费用项目信息</param>
		/// <returns><br>0 成功</br><br>-1 失败</br></returns>
		int AddPatientAccount(Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo,Object.Fee.FeeItemList  FeeItemList);
		/// <summary>
		/// 更新患者费用信息
		/// </summary>
		/// <param name="PatientInfo">患者信息</param>
		/// <param name="FeeInfo">费用信息</param>
		/// <returns><br>0 成功</br><br>-1 失败</br></returns>
		 int UpdateAccount(Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo,Object.Fee.FeeInfo FeeInfo);
			/// <summary>
		/// 清除患者费用信息
		/// </summary>
		/// <param name="PatientInfo">患者信息</param>
		/// <returns><br>0 成功</br><br>-1 失败</br></returns>
		 int PurgePatientAccount(Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo);
		
		/// <summary>
		/// 结帐患者信息
		/// </summary>
		/// <param name="PatientInfo">患者信息</param>
		/// <returns><br>0 成功</br><br>-1 失败</br></returns>
		int EndAccount(Neusoft.HISFC.Object.RADT.PatientInfo PatientInfo);
		
	}
}
