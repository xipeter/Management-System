using System.Collections;

namespace Neusoft.HISFC.BizLogic.PhysicalExamination.Base 
{

	/// <summary>
	/// 表业务层接口
	/// </summary>
	public interface TableInterface 
	{

		/// <summary>
		/// 插入表
		/// <param name="record">记录的承载对象</param>
		/// <returns>1－成功,-1-失败</returns>
		/// </summary>
		int Insert( Neusoft.FrameWork.Models.NeuObject record );

		/// <summary>
		/// 更新表
		/// <param name="record">记录的承载对象</param>
		/// <returns>1－成功,-1-失败</returns>
		/// </summary>
		int Update( Neusoft.FrameWork.Models.NeuObject record );

		/// <summary>
		/// 根据条件查询表
		/// <param name="recordList">返回的承载对象数组</param>
		/// <param name="whereCondition">SQL条件语句</param>
		/// <returns>1－成功,-1-失败</returns>
		/// </summary>
		int Select (ref ArrayList recordList, string whereCondition);
		
		/// <summary>
		/// 填充字段
		/// <param name="record">承载对象</param>
		/// </summary>
		void FillFields(Neusoft.FrameWork.Models.NeuObject record);

		/// <summary>
		/// 返回结果数组
		/// <param name="recordList">结果数组</param>
		/// </summary>
		void ReturnArray(ref ArrayList recordList);
	}
}
