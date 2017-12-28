using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Terminal 
{
	/// <summary>
	/// 完成医技项目的预约申请。
	/// 1.医技项目预约申请预申请--用于医生站调用 write by zhouxs
	/// </summary>
	public class MedTechItemBook : Neusoft.FrameWork.Management.Database
	{
		public MedTechItemBook()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//#region "医技预约申请"
		///// <summary>
		///// 医技预约申请
		///// </summary>
		///// <param name="objFeeItemlist"></param>
		///// <returns></returns>
		//public int CreateMedTechBookApply(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList objFeeItemlist, Neusoft.FrameWork.Management.Transaction t)
		//{

		//    Neusoft.HISFC.Models.Terminal.MedTechItem objMedTechItem = new Neusoft.HISFC.Models.Terminal.MedTechItem();
		//    Neusoft.HISFC.BizLogic.Terminal.MedTechItem MedTechItem = new MedTechItem();
		//    //根据科室和项目得到医技项目扩展信息
		//    objMedTechItem = MedTechItem.SelectDeptItem(objFeeItemlist.FeeInfo.ExeDept.ID, objFeeItemlist.Item.ID);
		//    if (objMedTechItem == null)
		//    {
		//    }
		//    return 0;
		//}
		//#endregion
		//#region "医技预约核准"
		//public int AffirmMedTechBookApply(Neusoft.HISFC.Models.Fee.FeeItemList objFeeItemList)
		//{

		//    return 0;
		//}

		//#endregion
		//#region "医技预约安排"
		///// <summary>
		///// 预约安排
		///// </summary>
		///// <returns></returns>
		//public int PlanTerminalBook()
		//{
		//    return 0;
		//}
		//#endregion
		//#region "医技预约取消"
		///// <summary>
		///// 医技预约取消
		///// </summary>
		///// <param name="objTerminalBookInfo"></param>
		///// <returns></returns>
		//public int CancelMedTechBookApply(Neusoft.HISFC.Models.Terminal.TerminalBookInfo objTerminalBookInfo)
		//{
		//    return 0;
		//}
		//#endregion
		//#region "按项目、科室、预约时间、午别查询排班信息"
		///// <summary>
		///// 按项目、科室、预约时间、午别查询排班信息
		///// </summary>
		///// <param name="strItem"></param>
		///// <param name="strDeptCode"></param>
		///// <param name="dtBookDate"></param>
		///// <param name="strNoonCode"></param>
		///// <returns></returns>
		//public int QueryTerminalSchema(string strItem, string strDeptCode, System.DateTime dtBookDate, string strNoonCode)
		//{
		//    return 0;
		//}

		//#endregion
		//#region "获取申请单号"

		///// <summary>
		///// 获得医技预约申请单号
		///// </summary>
		///// <returns></returns>
		//private string GetMedTechBookApplyID()
		//{
		//    return "0";
		//}
		///// <summary>
		///// 获取医技预约该项目该科室该时间该午别最大ID号
		///// </summary>
		///// <returns></returns>
		//private string GetMedTechBookApplySortID(string strItem, string strDeptCode, System.DateTime dtBookDate, string strNoonCode)
		//{
		//    return "";
		//}

		//#endregion
		//#region "插入医技预约申请项目表"

		//private int InsertTerminalApplyInfo(Neusoft.HISFC.Models.Terminal.MedTechBookApply objMedTechBookApply)
		//{
		//    string strSql = "";
		//    if (this.Sql.GetSql("Met.CreateMedTechBookApplyInfo", ref strSql) == -1)
		//        return -1;
		//    try
		//    {
		//        string OperId = this.Operator.ID;
		//        strSql = string.Format(strSql, GetParam(objMedTechBookApply));
		//        return this.ExecNoQuery(strSql);
		//    }
		//    catch (Exception ee)
		//    {
		//        this.Err = ee.Message;
		//        return -1;
		//    }
		//}
		//#endregion

		//#region "初始化参数信息"
		///// <summary>
		///// 
		///// </summary>
		///// <param name="obj"></param>
		///// <returns></returns>
		//private string[] GetParam(Neusoft.HISFC.Models.Terminal.MedTechBookApply objMedTechBookApply)
		//{
		//    string[] str = new string[] { };
		//    return str;
		//}
		//#endregion
	}
}
