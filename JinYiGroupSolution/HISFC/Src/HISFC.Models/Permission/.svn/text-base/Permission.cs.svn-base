using System;

namespace Neusoft.HISFC.Object.Permission
{
	/// <summary>
	/// 患者自费项目知情信息实体
	/// </summary>
	public class Permission:Neusoft.NFC.Object.NeuObject
	{
		public Permission()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 住院流水号
		/// </summary>
		public string InpatientNo="";
		/// <summary>
		/// 项目
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Item=new Neusoft.NFC.Object.NeuObject();
		/// <summary>
		/// 项目类别，0项目/1最小费用代码/2统计大类
		/// </summary>
		public enuItemType ItemType=enuItemType.StatFee;
		/// <summary>
		/// 是否同意
		/// </summary>
		public bool IsAgree=true;
		/// <summary>
		/// 操作员代码
		/// </summary>
		public string OperCode="";
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate;
	}
	public enum enuItemType
	{
		/// <summary>
		/// 具体项目
		/// </summary>
		Item,
		/// <summary>
		/// 最小费用
		/// </summary>
		MiniFee,
		/// <summary>
		/// 统计分类
		/// </summary>
		StatFee,
		/// <summary>
		/// 医保分类
		/// </summary>
		SI
	}

}
