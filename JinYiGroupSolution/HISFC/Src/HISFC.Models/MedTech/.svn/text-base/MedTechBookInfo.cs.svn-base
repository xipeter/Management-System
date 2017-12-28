using System;

namespace neusoft.HISFC.Object.MedTech
{
	/// <summary>
	/// MedTechBookInfo 医技预约信息。 write by zhouxs  2006-3-8
	/// </summary>
	public class MedTechBookInfo :neusoft.neuFC.Object.neuObject 
	{
		public MedTechBookInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private string status;//预约状态
		private string bookid;//预约号
		private DateTime bookdate;//预约时间
	    
		/// <summary>
	    /// 预约状态
	    /// </summary>
		public string Status
		{
			get 
			{
				return status;
			}
			set
			{
				status = value;
			}

		}
		
		/// <summary>
		/// 预约单号
		/// </summary>
		public string BookId
		{
			get
			{
				return bookid;
			}
			set
			{
				bookid = value;
			}
		}
		
		/// <summary>
		/// 预约日期
		/// </summary>
		public DateTime BookDate
		{
			get
			{
				return bookdate;
			}
			set
			{
				bookdate = value;
			}
		}
		
		/// <summary>
		/// 进行克隆
		/// </summary>
		/// <returns></returns>
				
		public new MedTechBookInfo Clone()
		{
			MedTechBookInfo obj=base.Clone() as MedTechBookInfo;
			return obj;
		}
	}
}
