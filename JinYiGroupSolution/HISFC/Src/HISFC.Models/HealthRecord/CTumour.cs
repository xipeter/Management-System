using System;


namespace Neusoft.HISFC.Object.HealthRecord {


	/// <summary>
	/// CTumour 的摘要说明。
	/// </summary>
	public class CTumour : Neusoft.NFC.Object.NeuObject
	{
		public CTumour()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		private string inpatientNo;//   --住院流水号
		private string  rmodeid; //  --放疗方式
		private string  rprocessid;//   --放疗程式
		private string  rdeviceid;//   --放疗装置
		private string cmodeid;//   --化疗方式
		private string  cmethod;//   --化疗方法
		private decimal  gy1;//   --原发灶gy剂量
		private decimal  time1;   //--原发灶次数
		private decimal  day1;//   --原发灶天数
		private System.DateTime begin_date1;//   --原发灶开始时间
		private System.DateTime   end_date1;//   --原发灶结束时间
		private decimal  gy2;//   --区域淋巴结gy剂量
		private decimal   time2; //  --区域淋巴结次数
		private decimal   day2; //  --区域淋巴结天数
		private System.DateTime    begin_date2;//   --区域淋巴结开始时间
		private System.DateTime   end_date2;//   --区域淋巴结结束时间
		private decimal   gy3;//   --转移灶gy剂量
		private decimal   time3;//   --转移灶次数
		private decimal   day3; //  --转移灶天数
		private System.DateTime   begin_date3;//   --转移灶开始时间
		private System.DateTime  end_date3;//   --转移灶结束时间
		//--操作员代号
		private Neusoft.NFC.Object.NeuObject operInfo = new Neusoft.NFC.Object.NeuObject() ;
		#region 属性 
		public string Cmethod
		{
			get
			{
				if(cmethod == null)
				{
					cmethod = "";
				}
				return cmethod;
			}
			set
			{
				cmethod = value;
			}
		}
		/// <summary>
		/// 操作员代号
		/// </summary>
		public Neusoft.NFC.Object.NeuObject OperInfo 
		{
			get
			{
				return operInfo;
			}
			set
			{
				operInfo = value;
			}
		}
		/// <summary>
		/// 转移灶结束时间
		/// </summary>
		public System.DateTime EndDate3
		{
			get
			{
				return end_date3;
			}
			set
			{
				end_date3 = value;
			}
		}
		/// <summary>
		/// 转移灶开始时间
		/// </summary>
		public System.DateTime BeginDate3
		{
			get
			{
				return begin_date3;
			}
			set
			{
				begin_date3 = value;
			}
		}
		/// <summary>
		/// 转移灶次数
		/// </summary>
		public decimal Time3
		{
			get
			{
				return time3;
			}
			set
			{
				time3 = value;
			}
		}
		/// <summary>
		/// 转移灶gy剂量
		/// </summary>
		public decimal Gy3
		{
			get
			{
				return gy3;
			}
			set
			{
				gy3 = value;
			}
		}
		/// <summary>
		/// 转移灶天数
		/// </summary>
		public decimal Day3
		{
			get
			{
				return day3; 
			}
			set
			{
				day3 = value;
			}
		}
		/// <summary>
		/// 区域淋巴结结束时间
		/// </summary>
		public System.DateTime EndDate2
		{
			get
			{
				return end_date2;
			}
			set
			{
				end_date2 = value;
			}
		}
		/// <summary>
		/// 区域淋巴结开始时间
		/// </summary>
		public System.DateTime BeginDate2
		{
			get
			{
				return begin_date2;
			}
			set
			{
				begin_date2 = value;
			}
		}
		/// <summary>
		/// 区域淋巴结天数
		/// </summary>
		public decimal Day2
		{
			get
			{
				return day2; 
			}
			set
			{
				day2 = value;
			}
		}
		/// <summary>
		/// 区域淋巴结次数
		/// </summary>
		public decimal Time2
		{
			get
			{
				return time2;
			}
			set
			{
				time2 = value;
			}
		}
		/// <summary>
		/// 区域淋巴结gy剂量
		/// </summary>
		public decimal Gy2
		{
			get
			{
				return gy2;
			}
			set
			{
				gy2 = value;
			}
		}

		/// <summary>
		/// 原发灶结束时间
		/// </summary>
		public System.DateTime EndDate1
		{
			get
			{
				return end_date1;
			}
			set
			{
				end_date1 = value;
			}
		}
		/// <summary>
		/// 原发灶开始时间
		/// </summary>
		public System.DateTime BeginDate1
		{
			get
			{
				return begin_date1;
			}
			set
			{
				begin_date1 = value;
			}
		}
		/// <summary>
		/// 原发灶天数
		/// </summary>
		public decimal Day1
		{
			get
			{
				return day1;
			}
			set
			{
				day1 = value;
			}
		}
		/// <summary>
		/// 原发灶次数
		/// </summary>
		public decimal Time1
		{
			get
			{
				return time1;
			}
			set
			{
				time1 = value;
			}
		}
		/// <summary>
		/// 原发灶gy剂量
		/// </summary>
		public decimal Gy1
		{
			get
			{
				return gy1 ;
			}
			set
			{
				gy1 = value;
			}
		}
		/// <summary>
		/// 化疗方式
		/// </summary>
		public string Cmodeid
		{
			get
			{
				if(cmodeid == null)
				{
					cmodeid = "";
				}
				return cmodeid;
			}
			set
			{
				cmodeid = value;
			}
		}
		/// <summary>
		/// 放疗装置
		/// </summary>
		public string  Rdeviceid
		{
			get
			{
				if(rdeviceid == null)
				{
					rdeviceid = "";
				}
				return rdeviceid;
			}
			set
			{
				rdeviceid = value;
			}
		}
		/// <summary>
		/// 放疗程式
		/// </summary>
		public  string Rprocessid
		{
			get
			{
				if(rprocessid == null)
				{
					rprocessid = "";
				}
				return rprocessid;
			}
			set
			{
				rprocessid = value;
			}
		}
		/// <summary>
		/// 放疗方式
		/// </summary>
		public string Rmodeid
		{
			get
			{
				if(rmodeid == null)
				{
					rmodeid = "";
				}
				return rmodeid;
			}
			set
			{
				rmodeid = value;
			}
		}
		/// <summary>
		/// 住院流水号
		/// </summary>
		public string InpatientNo
		{
			get
			{
				if(inpatientNo == null)
				{
					inpatientNo = "";
				}
				return inpatientNo;
			}
			set
			{
				 inpatientNo =value;
			}
		}
		#endregion 


		public new CTumour Clone()
		{
			CTumour ct = (CTumour)base.Clone();
			ct.operInfo = this.operInfo.Clone();
			return ct;
		}
	}
}
