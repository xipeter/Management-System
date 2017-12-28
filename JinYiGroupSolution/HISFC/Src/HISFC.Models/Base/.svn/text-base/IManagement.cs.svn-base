using System.Collections;
using System;
using Neusoft.FrameWork.Models;

namespace Neusoft.HISFC.Models.Base
{
	/// <summary>
	/// IManagement<br></br>
	/// [功能描述: 实现实体基本属性]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-08-28]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    //[Serializable]
    public interface IManagement
	{
		/// <summary>
		/// 获得单个实体
		/// </summary>
		/// <param name="obj">实体类型</param>
		/// <returns>该实体的实例</returns>
		NeuObject Get(System.Object obj);

		/// <summary>
		/// 获得实体列表
		/// </summary>
		/// <returns></returns>
		ArrayList GetList();

		/// <summary>
		/// 设置单个实体
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		int Set(NeuObject obj);

		/// <summary>
		/// 设置实体列表
		/// </summary>
		/// <param name="al"></param>
		/// <returns></returns>
		int SetList(ArrayList al);

		/// <summary>
		/// 删除实体
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		int Del(System.Object obj);
	}
}
