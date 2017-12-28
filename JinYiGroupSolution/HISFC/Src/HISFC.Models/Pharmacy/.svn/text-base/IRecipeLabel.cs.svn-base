using System;
using System.Collections;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// Copyright (C) 2004 东软股份有限公司
	/// 版权所有
	/// 
	/// 文件名：IRecipeLabel.cs
	/// 文件功能描述：门诊摆药标签接口
	/// 
	/// 
	/// 创建标识：梁俊泽 2006－04－28
	/// 创建说明：门诊摆药标签
	/// 
	/// </summary>
    //[Serializable]
    public interface IRecipeLabel
	{
		/// <summary>
		/// 患者信息
		/// </summary>
		Neusoft.HISFC.Models.Registration.Register PatientInfo
		{
			get;
			set;
		}
				

		/// <summary>
		/// 本次打印标签总页数
		/// </summary>
		decimal LabelTotNum
		{
			set;
		}
	

		/// <summary>
		/// 一次打印药品种类总数量
		/// </summary>
		decimal DrugTotNum
		{
			set;
		}


		/// <summary>
		/// 打印新摆药标签 单个药品
		/// </summary>
		/// <param name="info">摆药数据</param>
		void AddSingle(ApplyOut info);

		/// <summary>
		/// 打印配药标签 组合打印 
		/// </summary>
		/// <param name="alCombo">打印组合数据</param>
		void AddCombo(ArrayList alCombo);

		/// <summary>
		/// 打印配药清单
		/// </summary>
		/// <param name="al">所有待打印数据</param>
		void AddAllData(ArrayList al);
				
		/// <summary>
		/// 打印摆药单
		/// </summary>
		void Print();
	}
}
