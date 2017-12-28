using System;
using Neusoft.HISFC.Models;
using Neusoft.FrameWork.Models;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Manager
{
	/// <summary>
	/// Doctor 的摘要说明。
	/// </summary>
	public class Doctor:Neusoft.FrameWork.Management.Database 
	{
		public Doctor()
		{
		}
		#region"门诊"
		#region 医生限额
//		/// <summary>
//		/// 获得医生挂号是否到限额
//		/// </summary>
//		/// <param name="DoctorID"></param>
//		/// <param name="DeptID"></param>
//		/// <param name="NoonID"></param>
//		/// <param name="RegLevelID"></param>
//		/// <param name="dtDate"></param>
//		/// <returns></returns>
//		public bool GetDoctorRegLimit(string DoctorID,string DeptID,string NoonID,string RegLevelID,DateTime dtDate)
//		{
//			return true;
//		}
//		/// <summary>
//		/// 获得医生挂号限额
//		/// </summary>
//		/// <param name="Doctor">医生</param>
//		/// <returns></returns>
//		public Neusoft.HISFC.Models.Base.RegLimit GetDoctorRegLimit(NeuObject Doctor)
//		{
//			Object.Base.RegLimit DocRegLimit=new Object.Base.RegLimit();
//			return DocRegLimit;
//		}
//		/// <summary>
//		/// 更新医生挂号限额
//		/// </summary>
//		/// <param name="Doctor">医生</param>
//		/// <param name="DocRegLimit">限额</param>
//		/// <returns></returns>
//		public int UpdateDoctorRegLimit(NeuObject Doctor,Object.Base.RegLimit DocRegLimit)
//		{
//			return 0;
//		}
//		
//		public int DelDoctorRegLimit(NeuObject Doctor,Object.Base.RegLimit DocRegLimit)
//		{
//			return 0;
//		}
		#endregion 医生限额
		#region 获得医生
		/// <summary>
		/// 获得医生列表
		/// </summary>
		/// <returns></returns>
		public ArrayList GetClientDoctor()
		{
			return null;
		}

		#endregion 获得医生
		#endregion
		#region 住院
		/// <summary>
		/// 获得住院医生
		/// </summary>
		/// <returns></returns>
		public ArrayList GetDeptDoctore()
		{
			return null;
		}
		#endregion
	}
}
