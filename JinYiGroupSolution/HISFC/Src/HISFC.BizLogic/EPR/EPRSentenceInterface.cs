using System;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.EPR
{
	/// <summary>
	/// EPRSentenceInterface ,组套管理接口。
	/// </summary>
	public interface EPRSentenceInterface
	{
		/// <summary>
		/// 装载信息接口-生成列表
		/// </summary>
		/// <param name="alInfo">信息数组</param>
		void LoadInfo(ArrayList alInfo);
		/// <summary>
		/// 读取信息接口
		/// </summary>
		/// <returns>信息数组</returns>
		ArrayList GetInfo();
		/// <summary>
		/// 清除信息
		/// </summary>
		void ClsInfo();
		/// <summary>
		/// 设置分类组
		/// </summary>
		/// <param name="alGroup">分类组</param>
		void SetGroups(ArrayList alGroup);
		/// <summary>
		/// 获得分类组
		/// </summary>
		/// <returns>ArrayList 分类组</returns>
		ArrayList GetGoups();
	}
}
