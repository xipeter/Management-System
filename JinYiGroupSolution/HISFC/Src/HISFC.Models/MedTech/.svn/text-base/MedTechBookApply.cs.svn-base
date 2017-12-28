using System;

namespace neusoft.HISFC.Object.MedTech
{
	/// <summary>
	/// MedTechBookApply 用于生成医技预约信息。
	/// </summary>
	public class MedTechBookApply :neusoft.neuFC.Object.neuObject
	{
		public MedTechBookApply()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		///    医嘱流水号                   
		/// </summary>
		public string MoOrder
		{
			get
			{
				return ItemList.MoOrder;
			}
			set
			{
				ItemList.MoOrder = value;
			}
		}
		/// <summary>
		/// 午别
		/// </summary>
		public neusoft.neuFC.Object.neuObject noon = new neusoft.neuFC.Object.neuObject();
		private int sortid;
		/// <summary>
		/// 门诊费用实体
		/// </summary>
		/// <returns></returns>
		public neusoft.HISFC.Object.Fee.OutPatient.FeeItemList ItemList= new neusoft.HISFC.Object.Fee.OutPatient.FeeItemList();
        
		/// <summary>
		/// 项目预约扩展信息
		/// </summary>
		/// <returns></returns>
		public neusoft.HISFC.Object.MedTech.ItemExtend ItemExtend = new ItemExtend();


		/// <summary>
		/// 预约信息
		/// </summary>
		/// <returns></returns>
		public neusoft.HISFC.Object.MedTech.MedTechBookInfo MedTechBookInfo = new MedTechBookInfo();
		
		/// <summary>
		/// 排序号
		/// </summary>
		/// <returns></returns>
		public int SortID
		{
			get
			{
				return sortid;
				}
			set
			{
                sortid = value; 
			}

		}


		/// <summary>
		/// 健康状况
		/// </summary>
		public string HealthFlag;
		/// <summary>
		/// 执行地点
		/// </summary>
		public neusoft.neuFC.Object.neuObject ExecLocate = new neusoft.neuFC.Object.neuObject();
		/// <summary>
		/// 取报告时间
		/// </summary>
		public System.DateTime ReportDate ;
		/// <summary>
		/// 对成员进行克隆
		/// </summary>
		/// <returns></returns>
		public new MedTechBookApply Clone()
		{
			MedTechBookApply obj = base.Clone() as MedTechBookApply;
			obj.ItemList = this.ItemList.Clone();
			obj.ItemExtend = this.ItemExtend.Clone();
			obj.MedTechBookInfo = this.MedTechBookInfo.Clone();
			return obj;
		}

	}
}
