using System;


namespace Neusoft.HISFC.Object.HealthRecord {


	/// <summary>
	/// CTumourDetail 的摘要说明。
	/// </summary>
	public class CTumourDetail :Neusoft.NFC.Object.NeuObject 
	{
		public CTumourDetail()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private  string   inpatient_no;  // --住院流水号
		private int   happen_no;  // --发生序号
		private System.DateTime   cure_date;  // --治疗日期
		//药物信息
		private Neusoft.NFC.Object.NeuObject drugInfo = new Neusoft.NFC.Object.NeuObject();

		private decimal   qty;//   --剂量
		private string unit;//   --单位
		private string   period;//   --疗程
		private string   result; //  --疗效
		//操作员代号	
		private Neusoft.NFC.Object.NeuObject   operInfo = new Neusoft.NFC.Object.NeuObject();
		#region  属性
		/// <summary>
		/// 住院流水号
		/// </summary>
		public string InpatientNo
		{
			get
			{
				return inpatient_no;
			}
			set
			{
				inpatient_no = value;
			}
		}
		/// <summary>
		/// 发生序号
		/// </summary>
		public int HappenNO
		{
			get
			{
				return happen_no;
			}
			set
			{
				happen_no =  value;
			}
		}
		/// <summary>
		/// 治疗日期
		/// </summary>
		public System.DateTime CureDate
		{
			get
			{
				return cure_date;
			}
			set
			{
				cure_date = value;
			}
		}
		/// <summary>
		/// 药物信息
		/// </summary>
		public Neusoft.NFC.Object.NeuObject  DrugInfo
		{
			get
			{
				return drugInfo;
			}
			set
			{
				drugInfo = value;
			}
		}
		/// <summary>
		/// 剂量
		/// </summary>
		public decimal Qty
		{
			get
			{
				return qty;
			}
			set
			{
				qty = value;
			}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string Unit
		{
			get
			{
				if(unit == null)
				{
					unit = "";
				}
				return unit;
			}
			set
			{
				unit = value;
			}
		}
		/// <summary>
		/// 疗程
		/// </summary>
		public string Period 
		{
			get
			{
				if(period == null)
				{
					period  = "";
				}
				return period;
			}
			set
			{
				period = value;
			}
		}
		/// <summary>
		/// 疗效
		/// </summary>
		public string Result
		{
			get
			{
				if(result == null)
				{
					result = "";
				}
				return result;
			}
			set
			{
				result = value;
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
				operInfo =  value;
			}

		}
		#endregion


		public new CTumourDetail Clone()
		{
			CTumourDetail ctd = (CTumourDetail)base.Clone();
			ctd.drugInfo = this.drugInfo.Clone();
			ctd.operInfo = this.operInfo.Clone();
			return ctd;
		}
	}
}
